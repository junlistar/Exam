using System.Diagnostics;
using System.Reflection;
using System;

namespace Exam.Admin
{
    public class Versions
    {
        private static string _version = null;

        /// <summary>
        /// js、css版本控制
        /// </summary>
        /// <returns></returns>
        public static string Ver
        {
            get
            {
                if (_version == null)
                {
                    //Assembly assembly = Assembly.GetExecutingAssembly();
                    //FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                    //string version = fvi.FileVersion;
                    return string.Format("?t={0}", DateTime.Now.Ticks);
                }
                return _version;
            }
        }
    }
}