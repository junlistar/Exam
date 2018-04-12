using Exam.Business;
using Exam.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Domain.Model;
using System.Web;
using System.IO;
using Exam.Core.Utils;
using Exam.Domain.Model.Excel;

namespace Exam.Service
{
    public class ProblemService : IProblemService
    {
        /// <summary>
        /// The user biz
        /// </summary>
        private IProblemBusiness _ProblemBiz;
        private IProblemCategoryBusiness _ProblemCatoryBiz;
        private IBelongBusiness _BelongBiz;
        private ISubjectInfoBusiness _SubjectInfoBiz;
        private IChapterBusiness _ChapterBiz;
        private IAnswerBusiness _AnswerBiz;
        private ILogBusiness _LogBiz;

        public ProblemService(IProblemBusiness ProblemBiz,
            IProblemCategoryBusiness ProblemCatoryBiz,
            IBelongBusiness BelongBiz,
            ISubjectInfoBusiness SubjectInfoBiz,
            IChapterBusiness ChapterBiz, 
            IAnswerBusiness AnswerBiz,
            ILogBusiness LogBiz)
        {
            _ProblemBiz = ProblemBiz;
            _ProblemCatoryBiz = ProblemCatoryBiz;
            _BelongBiz = BelongBiz;
            _SubjectInfoBiz = SubjectInfoBiz;
            _ChapterBiz = ChapterBiz;
            _AnswerBiz = AnswerBiz;
            _LogBiz = LogBiz;
        }

        /// <summary>
        /// 根据ID查找实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Problem GetById(int id)
        {
            return this._ProblemBiz.GetById(id);
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Problem Insert(Problem model)
        {
            return this._ProblemBiz.Insert(model);
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Update(Problem model)
        {
            this._ProblemBiz.Update(model);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void Delete(Problem model)
        {
            this._ProblemBiz.Delete(model);
        }

        /// <summary>
        /// 判断是否名称存在
        /// </summary>
        /// <param name="name"></param> 
        /// <param name="chapterid"></param> 
        /// <returns></returns>
        public bool IsExistName(string name, int chapterid)
        {
            return this._ProblemBiz.IsExistName(name, chapterid);
        }

        /// <summary>
        /// 添加管理后台菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<Problem> GetManagerList(string name, int belongId, int chapterId, int subjectInfoId, int problemCategoryId, int pageNum, int pageSize, out int totalCount)
        {
            return this._ProblemBiz.GetManagerList(name, belongId, chapterId, subjectInfoId, problemCategoryId, pageNum, pageSize, out totalCount);
        }
        /// <summary>
        /// 获取所有
        /// </summary> 
        /// <returns></returns>
        public List<Problem> GetAll()
        {
            return this._ProblemBiz.GetAll();
        }
        /// <summary>
        /// 根据分类获取必刷题目
        /// </summary>
        /// <param name="belongId">分类编号，注会</param>
        /// <returns></returns>
        public List<Problem> GetIntensive(int belongId)
        {
            return this._ProblemBiz.GetIntensive(belongId);
        }


        /// <summary>
        /// 获取题目列表
        /// </summary>
        /// <param name="belongId">分类id</param>
        /// <param name="chapterId">章节id</param>
        /// <param name="SubjectInfoId">科目id</param>
        /// <returns></returns>
        public List<Problem> GetProblemList(int belongId, int chapterId, int SubjectInfoId)
        {
            return this._ProblemBiz.GetProblemList(belongId, chapterId, SubjectInfoId);
        }

        /// <summary>
        /// 导入题目文件
        /// </summary>
        /// <param name="fileServerPath"></param>
        /// <returns></returns>
        public ImportResponseModel ImportProblem(string fileServerPath)
        {

            ImportResponseModel response = new ImportResponseModel();

            string excelFilePath = fileServerPath;

            string textError = null;
            string textSuccessTitle = null;
            string textSuccessDetail = null;
            int successCount = 0;
            int failedCount = 0;

            var list = CheckExcelDataForInvition(excelFilePath, ref successCount, ref failedCount, ref textError, ref textSuccessTitle, ref textSuccessDetail);

            if (!string.IsNullOrEmpty(textError))
            {
                response.Result = false;
                response.Message = textError;
                return response;
            }
            else if (failedCount > 0)
            {
                response.Result = false;
                response.Message = textSuccessDetail;
                return response;
            }

            //TODO: 将数据导入到数据库
            //获取分类、层级、科目、章节列表
            var catelist = _ProblemCatoryBiz.GetAll();
            var belonglist = _BelongBiz.GetAll();
            var subjectlist = _SubjectInfoBiz.GetAll();
            var chapterlist = _ChapterBiz.GetAll();
            
            if (list != null && list.Count > 0)
            {
                successCount = 0; failedCount = list.Count;

                foreach (var item in list)
                {
                    try
                    {

                        Problem pitem = new Problem();
                        pitem.Title = item.Title;
                        pitem.Analysis = item.Analysis;
                        pitem.BelongId = belonglist.Where(p => p.Title == item.Belong.Trim()).FirstOrDefault().BelongId;
                        pitem.SubjectInfoId = subjectlist.Where(p => p.Title == item.Subject.Trim() && p.BelongId == pitem.BelongId).FirstOrDefault().SubjectInfoId;
                        pitem.ChapterId = chapterlist.Where(p => p.Title == item.Chapter.Trim() && p.SubjectInfoId == pitem.SubjectInfoId).FirstOrDefault().ChapterId;

                        if (item.Category.Trim() == "单选")
                        {
                            pitem.ProblemCategoryId = 1000;//等于4 单选
                        }
                        else if (item.Category.Trim() == "多选")
                        {
                            pitem.ProblemCategoryId = 1001;//等于5 多选
                        }
                        else if (item.Category.Trim() == "判断")
                        {
                            pitem.ProblemCategoryId = 1002;//等于6 判断
                        }
                        else
                        {
                            pitem.ProblemCategoryId = 1003;//计算回答
                        }
                        //默认值
                        pitem.Score = 1;
                        pitem.Sort = 1;
                        pitem.IsHot = 0;
                        pitem.IsImportant = 1;
                        pitem.CTime = DateTime.Now;
                        pitem.UTime = DateTime.Now;

                        //写入题目 
                        var returnProblemModel = Insert(pitem);
                        //单选，多选
                        if (item.Category.Trim() == "单选" || item.Category.Trim() == "多选")
                        {
                            var _options = item.Answers;
                            var _answer = item.Correct;

                            if (!string.IsNullOrWhiteSpace(_answer))
                            {
                                var _correctlist = _answer.Split('|');
                                var _optionlist = _options.Split('|');
                                for (int i = 0; i < _optionlist.Length; i++)
                                {
                                    Answer _answermodel = new Answer();
                                    _answermodel.ProblemId = returnProblemModel.ProblemId;
                                    _answermodel.Title = _optionlist[i];
                                    _answermodel.IsCorrect = _correctlist.Contains((i + 1).ToString()) ? 1 : 0;
                                    //添加答案
                                    _AnswerBiz.Insert(_answermodel);
                                }
                            }
                        }
                        //判断
                        else if (item.Category.Trim() == "判断")
                        {
                            Answer _answermodel = new Answer();
                            _answermodel.ProblemId = returnProblemModel.ProblemId;
                            _answermodel.Title = item.Analysis;
                            _answermodel.IsCorrect = item.Correct.Trim() == "正确" ? 1 : 0;
                            //添加答案
                            _AnswerBiz.Insert(_answermodel);
                        }
                        //回答
                        else
                        {
                            //计算题，回答题。 没有答案选项。忽略
                        }
                        successCount++; failedCount--;

                    }
                    catch (Exception ex)
                    {
                        _LogBiz.Insert(new Log()
                        {
                            CTime = DateTime.Now,
                            TargetTitle = ex.Message
                        });
                    }
                }
            }

            //返回值
            response.ImportSuccessCount = successCount;
            response.ImportFailCount = failedCount;
            textSuccessTitle = "成功 " + successCount + " 个，失败 " + failedCount + " 个。";
            response.Message = textSuccessTitle;
            response.Result = true;

            return response;
        }

        /// <summary>
        /// 数据校验
        /// </summary>
        /// <param name="inputExcelFile">待校验的文件名</param>
        /// <param name="textError">用户提交文件出现错误是，返回的错误描述信息。如：“您上传的文件格式不正确，邀请文件应该有 5 列”</param>
        /// <param name="textSuccessTitle">返回如处理成功后的主题。如：“成功 5 个，失败 2 个。”</param>
        /// <param name="textSuccessDetail">返回如处理成功后的其中错误行的具体描述，每行以回车换行分开。如：“第 1 行，手机号不正确\n第 6 行，邮箱格式不正确。”</param>
        /// <returns>返回一个 ProblemImport 集合，表示所有通过校验的数据。若无任何数据通过校验，则集合的 .Count 为零 </returns>
        /// <remarks>调用者应该先判断 textError 是否为空，若为非空，则表示有错，直接显示此错误即可。否则显示 textSuccessTitle，同时需判断详细描述 textSuccessDetail 是否有值，有值则显示之。 </remarks>
        List<ProblemImport> CheckExcelDataForInvition(string inputExcelFile, ref int successNum, ref int falseNum, ref string textError, ref string textSuccessTitle, ref string textSuccessDetail)
        {
            int totalNum = 0, colCount = 0, validColNum = 5, sheetNum = 0, maxRows = 1000;
            List<ProblemImport> returnInfo = new List<ProblemImport>();
            System.Data.DataTable tableExcel;
            long testLong;

            falseNum = 0;
            successNum = 0;
            textError = "";
            textSuccessTitle = "";
            textSuccessDetail = "";
            byte[] invisibleByte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 63, 127, 128 };
            char[] invisibleChar = System.Text.Encoding.ASCII.GetChars(invisibleByte);

            //获取 Excel 数据到变量
            tableExcel = ExcelHelper.FileToDataTable(inputExcelFile, out sheetNum);
            if (tableExcel == null) tableExcel = new System.Data.DataTable();

            totalNum = tableExcel.Rows.Count;
            colCount = tableExcel.Columns.Count;

            //if (sheetNum > 1)
            //{
            //    textError = "您上传的文件有含有多个工作表，请您按照模板的格式要求来填写数据，确保文件只有一个工作表。";
            //}
            //else 
            if ((totalNum == 0) || (colCount == 0))
            {
                textError = "未能读取到数据，请确保您上传的 Excel 文件的第一个工作表内含有数据。";
            }
            else if (totalNum < 2)
            {
                textError = "未能读取到有效数据，邀请文件应该至少有 2 行数据，第一行为表头（标题、类型、层级、科目、章节、答案、正确答案、分析），其余的行为有效数据。";
            }
            else if (colCount < validColNum)
            {
                textError = "您上传的文件格式不正确，邀请文件应该有 8 列，分别为：标题、类型、层级、科目、章节、答案、正确答案、分析.";
            }
            else if (totalNum > maxRows)
            {
                textError = "您上传的文件包含有太多的数据行。对于不需要的数据，您必须在 Excel 中整行选中后再右键选择删除；否则如果只是选中某些单元格再按 Delete 键，Excel 仍然认为这些格子有数据，只不过是数据是空字符。";
            }
            else
            {
                //去掉最后行的空数据
                int emptyRows = 0;
                bool findText = false;
                for (int iRow = totalNum - 1; iRow >= 0; iRow--)
                {
                    for (int loopCol = 0; loopCol < validColNum; loopCol++)
                    {
                        string cellValue = "";
                        if (tableExcel.Rows[iRow][loopCol] != null) { cellValue = tableExcel.Rows[iRow][loopCol].ToString().Trim(invisibleChar); }

                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            findText = true;
                            break;
                        }
                        else if (loopCol == (validColNum - 1))
                        {
                            emptyRows++;
                        }
                    }

                    if (findText) break;

                }

                totalNum = totalNum - emptyRows;
                if (totalNum < 2) { textError = "未能读取到有效数据，邀请文件应该至少有 2 行数据，第一行为表头（标题、类型、层级、科目、章节、答案、正确答案、分析），其余的行为有效数据。"; }
            }


            if (!string.IsNullOrEmpty(textError))
            {
                //nothing。在上面已经做了错误识别处理
            }
            else //校验第一行的表头
            {
                Problem headRow = new Problem();

                //姓名
                string title = tableExcel.Rows[0][0].ToString().Trim(invisibleChar);
                string category = tableExcel.Rows[0][1].ToString().Trim(invisibleChar);
                string belong = tableExcel.Rows[0][2].ToString().Trim(invisibleChar);
                string subject = tableExcel.Rows[0][3].ToString().Trim(invisibleChar);
                string chapter = tableExcel.Rows[0][4].ToString().Trim(invisibleChar);
                string answers = tableExcel.Rows[0][5].ToString().Trim(invisibleChar);
                string correct = tableExcel.Rows[0][6].ToString().Trim(invisibleChar);
                string analysis = tableExcel.Rows[0][7].ToString().Trim(invisibleChar);

                if (title.IndexOf("标题") < 0)
                { textError = "请确保文件表头（首行）第一列为“标题”"; }
                else if (category.IndexOf("类型") < 0)
                { textError = "请确保文件表头（首行）第二列为“类型”"; }
                else if (belong.IndexOf("层级") < 0)
                { textError = "请确保文件表头（首行）第三列为“层级”"; }
                else if (subject.IndexOf("科目") < 0)
                { textError = "请确保文件表头（首行）第四列为“科目”"; }
                else if (chapter.IndexOf("章节") < 0)
                { textError = "请确保文件表头（首行）第五列为“章节”"; }
                else if (answers.IndexOf("答案") < 0)
                { textError = "请确保文件表头（首行）第六列为“答案”"; }
                else if (correct.IndexOf("正确答案") < 0)
                { textError = "请确保文件表头（首行）第七列为“正确答案”"; }
                else if (analysis.IndexOf("分析") < 0)
                { textError = "请确保文件表头（首行）第八列为“分析”"; }

            }


            //返回--无需做详细校验
            if (!string.IsNullOrEmpty(textError)) return returnInfo;


            //获取分类、层级、科目、章节列表
            var catelist = _ProblemCatoryBiz.GetAll();
            var belonglist = _BelongBiz.GetAll();
            var subjectlist = _SubjectInfoBiz.GetAll();
            var chapterlist = _ChapterBiz.GetAll();

            //以下开始详细校验
            string[] errorRows = new string[totalNum];
            for (int iRow = totalNum - 1; iRow > 0; iRow--)//记得第一行是表头，无需校验。
            {
                ProblemImport oneRow = new ProblemImport();

                errorRows[iRow] = "";

                //标题
                oneRow.Title = tableExcel.Rows[iRow][0].ToString().Trim(invisibleChar);
                if (string.IsNullOrEmpty(oneRow.Title))
                { errorRows[iRow] = "第 " + (iRow + 1) + " 行，标题为空"; }
                //else if (!catelist.Any(p=>p.Title == oneRow.Title))
                //{ errorRows[iRow] = "第 " + (iRow + 1) + " 行，类型超长"; }


                //类型
                if (string.IsNullOrEmpty(errorRows[iRow]))
                {
                    oneRow.Category = tableExcel.Rows[iRow][1].ToString().Trim(invisibleChar);
                    if (string.IsNullOrEmpty(oneRow.Category))
                    { errorRows[iRow] = "第 " + (iRow + 1) + " 行，类型为空"; }
                    else if (!catelist.Any(p => p.Title == oneRow.Category))
                    { errorRows[iRow] = "第 " + (iRow + 1) + " 行，类型不在所选范围之内，不存在该类型"; }
                }


                //层级
                if (string.IsNullOrEmpty(errorRows[iRow]))
                {
                    oneRow.Belong = tableExcel.Rows[iRow][2].ToString().Trim(invisibleChar);
                    if (string.IsNullOrEmpty(oneRow.Belong))
                    { errorRows[iRow] = "第 " + (iRow + 1) + " 行，层级为空"; }
                    else if (!belonglist.Any(p => p.Title == oneRow.Belong))
                    { errorRows[iRow] = "第 " + (iRow + 1) + " 行，层级不在所选范围之内，不存在该层级"; }
                }

                //科目
                if (string.IsNullOrEmpty(errorRows[iRow]))
                {
                    // 获取层级信息
                    var _belongInfo = belonglist.Where(p => p.Title == oneRow.Belong).FirstOrDefault();

                    oneRow.Subject = tableExcel.Rows[iRow][3].ToString().Trim(invisibleChar);
                    if (string.IsNullOrEmpty(oneRow.Subject))
                    { errorRows[iRow] = "第 " + (iRow + 1) + " 行，科目为空"; }
                    else if (!subjectlist.Any(p => p.Title == oneRow.Subject))
                    { errorRows[iRow] = "第 " + (iRow + 1) + " 行，科目不在所选范围之内，不存在该科目"; }
                    else if (!subjectlist.Any(p => p.Title == oneRow.Subject && p.BelongId == _belongInfo.BelongId))
                    { errorRows[iRow] = "第 " + (iRow + 1) + " 行，当前层级中不包含此科目"; }
                }

                //章节
                if (string.IsNullOrEmpty(errorRows[iRow]))
                {
                    // 获取层级信息
                    var _belongInfo = belonglist.Where(p => p.Title == oneRow.Belong).FirstOrDefault();
                    //获取科目信息
                    var _subjectInfo = subjectlist.Where(p => p.Title == oneRow.Subject && p.BelongId == _belongInfo.BelongId).FirstOrDefault();

                    oneRow.Chapter = tableExcel.Rows[iRow][4].ToString().Trim(invisibleChar);
                    if (string.IsNullOrEmpty(oneRow.Chapter))
                    { errorRows[iRow] = "第 " + (iRow + 1) + " 行，章节为空"; }
                    else if (!chapterlist.Any(p => p.Title == oneRow.Chapter))
                    { errorRows[iRow] = "第 " + (iRow + 1) + " 行，章节不在所选范围之内，不存在该章节"; }
                    else if (!chapterlist.Any(p => p.Title == oneRow.Chapter && p.SubjectInfoId == _subjectInfo.SubjectInfoId))
                    { errorRows[iRow] = "第 " + (iRow + 1) + " 行，当前科目中不包含此章节"; }
                }

                //答案
                if (string.IsNullOrEmpty(errorRows[iRow]))
                {
                    oneRow.Answers = tableExcel.Rows[iRow][5].ToString().Trim(invisibleChar);
                    //如果题目不是简答题，要判断答案列表是否为空
                    if (oneRow.Category.Trim() != "回答" && string.IsNullOrEmpty(oneRow.Answers))
                    {
                        errorRows[iRow] = "第 " + (iRow + 1) + " 行，答案列表为空";
                    }
                }
                //正确答案
                if (string.IsNullOrEmpty(errorRows[iRow]))
                {
                    int _tParse = 0;
                    oneRow.Correct = tableExcel.Rows[iRow][6].ToString().Trim(invisibleChar);
                    //如果题目不是简答题，要判断答案列表是否为空
                    if (oneRow.Category.Trim() != "回答" && string.IsNullOrEmpty(oneRow.Correct))
                    {
                        errorRows[iRow] = "第 " + (iRow + 1) + " 行，正确答案为空";
                    }
                    else if (oneRow.Category.Trim() == "单选" && !int.TryParse(oneRow.Correct, out _tParse))
                    {
                        errorRows[iRow] = "第 " + (iRow + 1) + " 行，正确答案为非数字";
                    }
                    else if (oneRow.Category.Trim() == "判断" && !(oneRow.Correct.Trim() == "正确" || oneRow.Correct.Trim() == "错误"))
                    {
                        errorRows[iRow] = "第 " + (iRow + 1) + " 行，判断题类型需要在正确答案这一栏填‘正确’或者‘错误’";
                    }

                }
                //分析
                if (string.IsNullOrEmpty(errorRows[iRow]))
                {
                    oneRow.Analysis = tableExcel.Rows[iRow][7].ToString().Trim(invisibleChar);

                }

                //添加到返回集合中
                if (string.IsNullOrEmpty(errorRows[iRow])) { returnInfo.Add(oneRow); }

            }//for 循环结束


            //处理返回详细错误描述
            System.Text.StringBuilder errInfo = new System.Text.StringBuilder();
            for (int iRow = 0; iRow < totalNum; iRow++)
            {
                if (!string.IsNullOrEmpty(errorRows[iRow]))
                {
                    falseNum++;
                    //errInfo.AppendLine(errorRows[iRow]);
                    errInfo.Append(errorRows[iRow] + "<br>");
                }
            }
            if (falseNum > 0)
            {
                textSuccessDetail = errInfo.ToString();
                errInfo.Clear();
            }


            //返回的标题 去掉第一行标题
            totalNum--;
            successNum = totalNum - falseNum;
            textSuccessTitle = "成功 " + successNum + " 个，失败 " + falseNum + " 个。";

            return returnInfo;
        }

    }
}
