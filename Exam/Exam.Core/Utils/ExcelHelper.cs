using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using System.Data.OleDb;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.Web;
using System.Collections;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;
using NPOI.SS.Util;
using Exam.Domain.Excel;

namespace Exam.Core.Utils
{
    public class ExcelHelper
    {
        /// <summary>
        /// 读取 Excel 文件第一个工作表的内容到 DataTable，同事返回工作表的数量。
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="sheetNum">返回的工作表的数量</param>
        /// <returns></returns>
        public static DataTable FileToDataTable(string filePath, out int sheetNum)
        {

            string connStr = "";

            sheetNum = 0;
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filePath + ";" + ";Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1\"";

            OleDbConnection conn = null;
            OleDbDataAdapter myAdapter = null;
            DataTable schemaTable = null;
            DataSet dsItem = null;
            DataTable returnTable = new DataTable();

            try
            {
                int sheetIndex = 1;
                string sheetName = "";

                //初始化连接，并打开
                conn = new OleDbConnection(connStr);
                conn.Open();

                //获取数据源的表定义元数据                       
                schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null); //conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                //计算工作表的数量
                string sheetNameString = "";
                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    sheetName = (string)schemaTable.Rows[i]["TABLE_NAME"];
                    sheetName = sheetName.Replace("$", "");
                    if (sheetNameString.IndexOf(sheetName) < 0)
                    {
                        sheetNum++;
                        sheetNameString += sheetName;
                    }
                }

                // 初始化适配器
                myAdapter = new OleDbDataAdapter();
                sheetName = (string)schemaTable.Rows[sheetIndex - 1]["TABLE_NAME"];

                myAdapter.SelectCommand = new OleDbCommand(String.Format("Select * FROM [{0}]", sheetName), conn);
                dsItem = new DataSet();
                myAdapter.Fill(dsItem, "Table" + sheetIndex);
                returnTable = dsItem.Tables[0].Copy();

            }
            catch (Exception ex)
            {
                string errText = ex.Message;
                //nothing
            }
            finally
            {
                if (dsItem != null) dsItem.Dispose();
                if (myAdapter != null) myAdapter.Dispose();

                // 关闭连接
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Dispose();
                }
            }

            return returnTable;
        }
         

        public static void ExportExcel(List<SheetInfo> sheets, ExcelInfo excelinfo, ref string error)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();

            if (sheets.Count <= 0)
            {
                return;
            }
            foreach (var item in sheets)
            {
                var table = item.Data;
                var lstCloumInfo = item.CloumnInfos;
                if (table.Rows.Count > 65536)
                {
                    error = "数据表超出excel容量";
                    return;
                }

                //创建sheet
                ISheet sheet = workbook.CreateSheet(item.SheetName);

                //开始填充数据
                IRow firstRow = sheet.CreateRow(0);

                //单元格样式
                ICellStyle cellStyle = workbook.CreateCellStyle();
                cellStyle.Alignment = HorizontalAlignment.Center;
                cellStyle.VerticalAlignment = VerticalAlignment.Center;

                //自提
                IFont font = workbook.CreateFont();
                font.FontName = "宋体";
                font.FontHeightInPoints = 10;
                font.Boldweight = (short)FontBoldWeight.Bold;
                font.Color = NPOI.HSSF.Util.HSSFColor.Black.Index;
                cellStyle.SetFont(font);

                //根据传入各列内容样式初始化表格
                for (int i = 0; i < lstCloumInfo.Count; i++)
                {
                    var column = lstCloumInfo[i];
                    ICell cell = firstRow.CreateCell(i, CellType.String);
                    cell.SetCellValue(column.Header);
                    cell.CellStyle = cellStyle;
                    sheet.SetColumnWidth(i, column.Width * 256);

                    if (column.AutoFilter)
                    {
                        sheet.SetAutoFilter(CellRangeAddress.ValueOf(((char)(65 + i)).ToString() + "1"));
                    }
                }

                ICellStyle contentCellStyle = workbook.CreateCellStyle();  // 内容列样式
                contentCellStyle.VerticalAlignment = VerticalAlignment.Center;
                contentCellStyle.BorderTop = BorderStyle.Thin;
                contentCellStyle.BorderRight = BorderStyle.Thin;
                contentCellStyle.BorderBottom = BorderStyle.Thin;
                contentCellStyle.BorderLeft = BorderStyle.Thin;

                ICellStyle numberCellStyle = workbook.CreateCellStyle();     // 数值列样式
                numberCellStyle.VerticalAlignment = VerticalAlignment.Center;
                numberCellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.000");
                numberCellStyle.Alignment = HorizontalAlignment.Right;
                numberCellStyle.BorderTop = BorderStyle.Thin;
                numberCellStyle.BorderRight = BorderStyle.Thin;
                numberCellStyle.BorderBottom = BorderStyle.Thin;
                numberCellStyle.BorderLeft = BorderStyle.Thin;

                int dataIndex = 1;
                foreach (DataRow row in table.Rows)
                {
                    IRow dataRow = sheet.CreateRow(dataIndex);
                    dataRow.HeightInPoints = 20;

                    for (int i = 0; i < lstCloumInfo.Count; i++)
                    {
                        ICell cell = dataRow.CreateCell(i);
                        switch (lstCloumInfo[i].CellDataType)
                        {
                            case CellDataType.contentCellStyle:
                                cell.SetCellValue(row[i].ToString());
                                cell.CellStyle = contentCellStyle;
                                break;
                            case CellDataType.numberCellStyle:
                                double str = (double)decimal.Parse(row[i].ToString(), 0);
                                cell.SetCellValue(str);
                                cell.CellStyle = numberCellStyle;
                                break;

                            //case CellDataType.combinecontentCellStyle:
                            //    cell.SetCellValue(row[i].ToString() + "-" + row[i].ToString());
                            //    cell.CellStyle = contentCellStyle;
                            //    break;
                            default: break;

                        }
                    }

                    dataIndex++;
                }
                sheet.ForceFormulaRecalculation = true;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);

                byte[] data = ms.ToArray();
                HttpResponse response = System.Web.HttpContext.Current.Response;
                response.Clear();
                response.Charset = "UTF-8";
                response.ContentType = "application/vnd-excel";

                string filename = HttpUtility.UrlEncode("机会宝" + excelinfo.FileName + "(" + DateTime.Now.ToString("yyyy-MM-dd") + ").xls", System.Text.Encoding.UTF8);
                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + filename));
                System.Web.HttpContext.Current.Response.BinaryWrite(data);


                workbook = null;
            }
        }

        #region 2003
        public class x2003
        {
            #region Excel2003
            /// <summary>
            /// 将Excel文件中的数据读出到DataTable中(xls)
            /// </summary>
            /// <param name="file"></param>
            /// <returns></returns>
            public static DataTable ExcelToTableForXLS(string file, int sheetIndex = 0)
            {
                DataTable dt = new DataTable();
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    HSSFWorkbook hssfworkbook = new HSSFWorkbook(fs);
                    ISheet sheet = hssfworkbook.GetSheetAt(sheetIndex);

                    //表头
                    IRow header = sheet.GetRow(sheet.FirstRowNum);
                    List<int> columns = new List<int>();
                    for (int i = 0; i < header.LastCellNum; i++)
                    {
                        object obj = GetValueTypeForXLS(header.GetCell(i) as HSSFCell);
                        if (obj == null || obj.ToString() == string.Empty)
                        {
                            dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                            //continue;
                        }
                        else
                            dt.Columns.Add(new DataColumn(obj.ToString()));
                        columns.Add(i);
                    }
                    //数据
                    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                    {
                        DataRow dr = dt.NewRow();
                        bool hasValue = false;
                        foreach (int j in columns)
                        {
                            dr[j] = GetValueTypeForXLS(sheet.GetRow(i).GetCell(j) as HSSFCell);
                            if (dr[j] != null && dr[j].ToString() != string.Empty)
                            {
                                hasValue = true;
                            }
                        }
                        if (hasValue)
                        {
                            dt.Rows.Add(dr);
                        }
                    }
                }
                return dt;
            }

            /// <summary>
            /// 将DataTable数据导出到Excel文件中(xls)
            /// </summary>
            /// <param name="dt"></param>
            /// <param name="file"></param>
            public static void TableToExcelForXLS(DataTable dt, string file)
            {
                HSSFWorkbook hssfworkbook = new HSSFWorkbook();
                ISheet sheet = hssfworkbook.CreateSheet("Test");

                //表头
                IRow row = sheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = row.CreateCell(i);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                }

                //数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row1 = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                //转为字节数组
                MemoryStream stream = new MemoryStream();
                hssfworkbook.Write(stream);
                var buf = stream.ToArray();

                //保存为Excel文件
                using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(buf, 0, buf.Length);
                    fs.Flush();
                }
            }

            /// <summary>
            /// 获取单元格类型(xls)
            /// </summary>
            /// <param name="cell"></param>
            /// <returns></returns>
            private static object GetValueTypeForXLS(HSSFCell cell)
            {
                if (cell == null)
                    return null;
                switch (cell.CellType)
                {
                    case CellType.Blank: //BLANK:
                        return null;
                    case CellType.Boolean: //BOOLEAN:
                        return cell.BooleanCellValue;
                    case CellType.Numeric: //NUMERIC:
                        return cell.NumericCellValue;
                    case CellType.String: //STRING:
                        return cell.StringCellValue;
                    case CellType.Error: //ERROR:
                        return cell.ErrorCellValue;
                    case CellType.Formula: //FORMULA:
                    default:
                        return "=" + cell.CellFormula;
                }
            }
            #endregion
        }
        #endregion

        #region 2007
        public class x2007
        {
            #region Excel2007
            /// <summary>
            /// 将Excel文件中的数据读出到DataTable中(xlsx)
            /// </summary>
            /// <param name="file"></param>
            /// <returns></returns>
            public static DataTable ExcelToTableForXLSX(string file, int sheetIndex = 0)
            {
                DataTable dt = new DataTable();
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    XSSFWorkbook xssfworkbook = new XSSFWorkbook(fs);
                    ISheet sheet = xssfworkbook.GetSheetAt(sheetIndex);

                    //表头
                    IRow header = sheet.GetRow(sheet.FirstRowNum);
                    List<int> columns = new List<int>();
                    for (int i = 0; i < header.LastCellNum; i++)
                    {
                        object obj = GetValueTypeForXLSX(header.GetCell(i) as XSSFCell);
                        if (obj == null || obj.ToString() == string.Empty)
                        {
                            dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                            //continue;
                        }
                        else
                            dt.Columns.Add(new DataColumn(obj.ToString()));
                        columns.Add(i);
                    }
                    //数据
                    for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum - 2; i++)
                    {
                        DataRow dr = dt.NewRow();
                        bool hasValue = false;
                        foreach (int j in columns)
                        {
                            dr[j] = GetValueTypeForXLSX(sheet.GetRow(i).GetCell(j) as XSSFCell);
                            if (dr[j] != null && dr[j].ToString() != string.Empty)
                            {
                                hasValue = true;
                            }
                        }
                        if (hasValue)
                        {
                            dt.Rows.Add(dr);
                        }
                    }
                }
                return dt;
            }

            /// <summary>
            /// 将DataTable数据导出到Excel文件中(xlsx)
            /// </summary>
            /// <param name="dt"></param>
            /// <param name="file"></param>
            public static void TableToExcelForXLSX(DataTable dt, string file)
            {
                XSSFWorkbook xssfworkbook = new XSSFWorkbook();
                ISheet sheet = xssfworkbook.CreateSheet("Test");

                //表头
                IRow row = sheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = row.CreateCell(i);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                }

                //数据
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row1 = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                //转为字节数组
                MemoryStream stream = new MemoryStream();
                xssfworkbook.Write(stream);
                var buf = stream.ToArray();

                //保存为Excel文件
                using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(buf, 0, buf.Length);
                    fs.Flush();
                }
            }

            /// <summary>
            /// 获取单元格类型(xlsx)
            /// </summary>
            /// <param name="cell"></param>
            /// <returns></returns>
            private static object GetValueTypeForXLSX(XSSFCell cell)
            {
                if (cell == null)
                    return null;
                switch (cell.CellType)
                {
                    case CellType.Blank: //BLANK:
                        return null;
                    case CellType.Boolean: //BOOLEAN:
                        return cell.BooleanCellValue;
                    case CellType.Numeric: //NUMERIC:
                        return cell.NumericCellValue;
                    case CellType.String: //STRING:
                        return cell.StringCellValue;
                    case CellType.Error: //ERROR:
                        return cell.ErrorCellValue;
                    case CellType.Formula: //FORMULA:
                    default:
                        return "=" + cell.CellFormula;
                }
            }
            #endregion
        }
        #endregion

        #region 需特殊处理2003文档
        //加载Excel 
        public static DataSet LoadDataFromExcel(string filePath)
        {
            try
            {
                string strConn;
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";
                OleDbConnection OleConn = new OleDbConnection(strConn);
                OleConn.Open();
                String sql = "SELECT * FROM  [调研雷达数据表$]";//可是更改Sheet名称，比如sheet2，等等 

                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle, "调研雷达数据表");
                OleConn.Close();
                return OleDsExcle;
            }
            catch (Exception err)
            {
                return null;
            }
        }
        #endregion

        #region 列表集合转换成datatable
        public static DataTable ListToDataTable<T>(List<T> _list)
        {
            DataTable dt = new DataTable();
            if (_list != null)
            {
                //通过反射获取list中的字段 
                System.Reflection.PropertyInfo[] p = _list[0].GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo pi in p)
                {
                    var type = System.Type.GetType(pi.PropertyType.ToString());

                    if (type != null)
                    {
                        dt.Columns.Add(pi.Name, type);
                    }
                    else
                    {
                        dt.Columns.Add(pi.Name);
                    }
                }
                for (int i = 0; i < _list.Count; i++)
                {
                    IList TempList = new ArrayList();
                    //将IList中的一条记录写入ArrayList
                    foreach (System.Reflection.PropertyInfo pi in p)
                    {
                        object oo = pi.GetValue(_list[i], null);
                        TempList.Add(oo);
                    }
                    object[] itm = new object[p.Length];
                    for (int j = 0; j < TempList.Count; j++)
                    {
                        itm.SetValue(TempList[j], j);
                    }
                    dt.LoadDataRow(itm, true);
                }
            }

            return dt;
        }
        #endregion
         

        /// <summary>  
        /// 反一个M行N列的二维数组转换为DataTable  
        /// </summary>  
        /// <param name="ColumnNames">一维数组，代表列名，不能有重复值</param>  
        /// <param name="Arrays">M行N列的二维数组</param>  
        /// <returns>返回DataTable</returns>  
        public static DataTable ConvertArrayToDataTable(List<string> ColumnNames, object[,] Arrays)
        {
            DataTable dt = new DataTable();

            foreach (string ColumnName in ColumnNames)
            {
                dt.Columns.Add(ColumnName, typeof(string));
            }

            for (int i1 = 1; i1 <= Arrays.GetLength(0); i1++)
            {
                DataRow dr = dt.NewRow();
                for (int i = 1; i < ColumnNames.Count + 1; i++)
                {
                    if (Arrays[i1, i] != null)
                    {
                        dr[i - 1] = Arrays[i1, i].ToString();
                    }
                    else
                    {
                        dr[i - 1] = "";
                    }
                }
                dt.Rows.Add(dr);
            }

            return dt;

        }

        private static void NAR(object o)
        {
            try
            {
                while (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) > 0) ;

            }
            catch
            { }
            finally
            {
                o = null;
            }
        }

        private static void killPro()
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process item in ps)
            {
                if (item.ProcessName == "EXCEL")
                {
                    item.Kill();
                }
            }
        }
    }
}
