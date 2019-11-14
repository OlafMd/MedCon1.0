using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace BOp.Tests
{
    class ResourceLoader
    {
        /// <summary>
        /// Gets the resPath from the resources folder.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string GetResource(string path)
        {
            return File.ReadAllText(GetResourcePath(path));
        }

        public static string GetResourcePath(string relativePath)
        {
            var resPath = "BOp.Tests.Resources." + relativePath.Replace('/', '.').Replace('\\', '.');
            using (var resStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resPath))
            {
                if (resStream == null)
                {
                    throw new ArgumentException("Resource not found or not an embedded resource");
                }
                using (StreamReader reader = new StreamReader(resStream))
                {
                    string resource = reader.ReadToEnd();
                    string path = Path.Combine(Path.GetTempPath(), resPath);
                    File.WriteAllText(path, resource);
                    return path;
                }
            }


        }

        private static string AssemblyDirectory
        {
            get
            {
                string codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
