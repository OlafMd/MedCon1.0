using log4net.Appender;
using log4net.Config;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogUtils
{
    class CustomAppender : RollingFileAppender
    {
        protected override void WriteHeader()
        {
            if (LockingModel.AcquireLock().Length == 0)
            {
                try
                {
                    var log4netSection = ConfigurationManager.GetSection("log4net") as XmlElement;
                    var innerXML = log4netSection.InnerXml;
                    innerXML = "<RandomTag>" + innerXML + "</RandomTag>";

                    var log4netData = new XmlDocument();
                    log4netData.LoadXml(innerXML);
                    var footer = log4netData.GetElementsByTagName("footer").Cast<XmlElement>().First();
                    var fileElement = log4netData.GetElementsByTagName("file").Cast<XmlElement>().First();
                    var fileValue = fileElement.GetAttribute("value");
                    var datePatternElement = log4netData.GetElementsByTagName("datePattern").Cast<XmlElement>().First();
                    var datePatternValue = datePatternElement.GetAttribute("value");
                    var extension = datePatternValue.Substring(datePatternValue.IndexOf("\'") + 1);
                    var format = datePatternValue.Substring(0, datePatternValue.Substring(0, datePatternValue.IndexOf("\'")).Length);
                    if (fileValue.Contains("LogDirectory"))
                    {
                        var fileDir = fileValue.Substring(0, fileValue.IndexOf('%'));
                        var directories = Directory.GetDirectories(fileDir);
                        foreach (var dir in directories)
                        {
                            var folderName = dir.Remove(0, dir.Substring(0, dir.LastIndexOf('\\')).Length + 1);
                            var filename = fileValue.Replace("%property{LogDirectory}", folderName) + DateTime.Now.AddDays(-1).ToString(format);

                            var loc = filename + extension.Substring(0, extension.Length - 1);

                            string file = System.IO.File.ReadAllText(loc);

                            if (!file.Contains(footer.GetAttribute("value")))
                                System.IO.File.WriteAllText(loc, file + "\n" + footer.GetAttribute("value"), Encoding.UTF8);
                        }
                    }
                    else
                    {
                        var filename = fileValue + DateTime.Now.AddDays(-1).ToString(format);

                        var loc = filename + extension.Substring(0, extension.Length - 1);

                        string file = System.IO.File.ReadAllText(loc);

                        if (!file.Contains(footer.GetAttribute("value")))
                            System.IO.File.WriteAllText(loc, file + "\n" + footer.GetAttribute("value"), Encoding.UTF8);
                    }
                }
                catch (Exception ex) { }

                base.WriteHeader();
            }
        }

        protected override void WriteFooter()
        {
            try
            {
                var log4netSection = ConfigurationManager.GetSection("log4net") as XmlElement;
                var innerXML = log4netSection.InnerXml;
                innerXML = "<RandomTag>" + innerXML + "</RandomTag>";

                var log4netData = new XmlDocument();
                log4netData.LoadXml(innerXML);
                var footer = log4netData.GetElementsByTagName("footer").Cast<XmlElement>().First();
                var fileElement = log4netData.GetElementsByTagName("file").Cast<XmlElement>().First();
                var datePatternElement = log4netData.GetElementsByTagName("datePattern").Cast<XmlElement>().First();
                var datePatternValue = datePatternElement.GetAttribute("value");
                var extension = datePatternValue.Substring(datePatternValue.IndexOf("\'") + 1);
                var format = datePatternValue.Substring(0, datePatternValue.Substring(0, datePatternValue.IndexOf("\'")).Length);
                var filename = fileElement.GetAttribute("value") + DateTime.Now.ToString(format);

                var loc = filename + extension.Substring(0, extension.Length - 1);

                string file = System.IO.File.ReadAllText(loc);
                var replaced = file.Replace(footer.GetAttribute("value"), "");
                System.IO.File.WriteAllText(loc, replaced, Encoding.UTF8);
            }
            catch (Exception ex) { }

            base.WriteFooter();
        }
    }
}
