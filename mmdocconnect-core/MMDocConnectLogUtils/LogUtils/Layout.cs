using log4net.Core;
using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using log4net.Util;
using System.IO;
using log4net.Repository;
using System.Collections;

namespace LogUtils
{

    public class CustomPatternConverter : PatternConverter
    {
        protected override void Convert(TextWriter writer, object state)
        {
            var loggingEvent = state as LoggingEvent;
            var actionInfo = loggingEvent.MessageObject as LogEntry;

            if (actionInfo == null)
            {
                writer.Write(SystemInfo.NullText);
            }
            else
            {
                if (actionInfo.LogObjectInfo != null)
                {
                    RenderObjectData(actionInfo.LogObjectInfo, writer);
                }
            }
        }

        private void RenderObjectData(object obj, TextWriter writer)
        {
            var ms = new MemoryStream();
            var xmlWriter = new XmlTextWriter(ms, new UTF8Encoding(false)) { Formatting = Formatting.Indented };

            var properties = obj.GetType().GetProperties();

            xmlWriter.WriteStartElement(obj.GetType().Name);

            foreach (var prop in properties)
            {
                if (prop.GetType() == typeof(IEnumerable))
                {
                    xmlWriter.WriteStartElement(prop.Name);
                    foreach (var o in prop.GetValue(obj, null) as IEnumerable)
                    {
                        xmlWriter.WriteStartElement(o.GetType().Name);
                        if (o != null)
                        {
                            try
                            {
                                RenderObjectData(o, writer);

                            }
                            catch (Exception ex)
                            {
                                xmlWriter.WriteString(o.ToString());
                            }
                        }
                        else
                        {
                            xmlWriter.WriteString(SystemInfo.NullText);
                        }
                        xmlWriter.WriteEndElement();
                    }
                    xmlWriter.WriteEndElement();
                }
                else
                {
                    var val = prop.GetValue(obj, null);
                    xmlWriter.WriteStartElement(prop.Name);
                    if (val != null)
                    {
                        try
                        {
                            RenderObjectData(val, writer);

                        }
                        catch (Exception ex)
                        {
                            xmlWriter.WriteString(val.ToString());
                        }
                    }
                    else
                    {
                        xmlWriter.WriteString(SystemInfo.NullText);
                    }

                    xmlWriter.WriteEndElement();

                }
            }

            xmlWriter.WriteEndElement();
            xmlWriter.Flush();

            var xmlString = Encoding.UTF8.GetString(ms.ToArray());
            writer.WriteLine();
            writer.WriteLine(xmlString);
        }
    }


    public class CustomLayout : PatternLayout
    {
        public CustomLayout()
        {
            AddConverter(new ConverterInfo { Name = "mcPatternLayout", Type = typeof(CustomPatternConverter) });
        }

    }
}

