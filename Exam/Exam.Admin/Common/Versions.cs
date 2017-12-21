using System.Diagnostics;
using System.Reflection;

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
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                    string version = fvi.FileVersion;
                    return string.Format("?{0}", version);
                }
                return _version;
            }
        }
    }
}