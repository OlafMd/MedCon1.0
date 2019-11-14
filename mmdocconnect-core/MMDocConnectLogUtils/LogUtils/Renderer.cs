using log4net.ObjectRenderer;
using log4net.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LogUtils
{
    public class CustomRenderer : IObjectRenderer
    {
        public void RenderObject(RendererMap rendererMap, object obj, TextWriter writer)
        {
            var array = obj as IEnumerable;
            if (array == null)
            {
                RenderObjectData(obj, writer);
            }
            else
            {
                foreach (var ob in array)
                {
                    RenderObjectData(ob, writer);
                }
            }
        }

        private void RenderObjectData(object obj, TextWriter writer)
        {
            var ms = new MemoryStream();
            var xmlWriter = new XmlTextWriter(ms, new UTF8Encoding(true)) { Formatting = Formatting.Indented };

            var xmlString = RenderXMLObject(obj, xmlWriter, ms);

            writer.WriteLine();
            writer.WriteLine(xmlString);
        }

        private string RenderXMLObject(Object obj, XmlTextWriter xmlWriter, MemoryStream ms)
        {
            try
            {
                var ex = obj as Exception;
                if (ex == null)
                {
                    var properties = obj.GetType().GetProperties();

                    xmlWriter.WriteStartElement(obj.GetType().Name);

                    foreach (var prop in properties)
                    {
                        object val = null;
                        try
                        {
                            val = prop.GetValue(obj, null);
                        }
                        catch (Exception val_ex)
                        {
                            // Left empty since we are checking for null afterwards
                        }
                        if (val != null)
                        {
                            if (val as IEnumerable != null && prop.PropertyType != typeof(String))
                            {
                                xmlWriter.WriteStartElement(prop.Name);
                                foreach (var o in prop.GetValue(obj, null) as IEnumerable)
                                {
                                    xmlWriter.WriteStartElement(o.GetType().Name);
                                    if (o != null)
                                    {
                                        if (!o.GetType().IsPrimitive && o.GetType() != typeof(DateTime) && o.GetType() != typeof(string) && o.GetType() != typeof(Guid))
                                        {
                                            RenderXMLObject(o, xmlWriter, ms);
                                        }
                                        else
                                        {
                                            if (o.GetType() != typeof(DateTime))
                                            {
                                                xmlWriter.WriteString(o.ToString());
                                            }
                                            else
                                            {
                                                xmlWriter.WriteString(((DateTime)o).ToString("yyyy-MM-dd"));
                                            }
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
                                xmlWriter.WriteStartElement(prop.Name);
                                if (!prop.PropertyType.IsPrimitive && prop.PropertyType != typeof(DateTime) && prop.PropertyType != typeof(string) && prop.PropertyType != typeof(Guid))
                                {
                                    if (val != null)
                                    {
                                        RenderXMLObject(val, xmlWriter, ms);
                                    }
                                    else
                                    {
                                        xmlWriter.WriteString(SystemInfo.NullText);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        val = prop.GetValue(obj, null);
                                    }
                                    catch (Exception objEx)
                                    {
                                        if (obj.GetType() != typeof(DateTime))
                                        {
                                            xmlWriter.WriteString(obj.ToString());
                                        }
                                        else
                                        {
                                            xmlWriter.WriteString(((DateTime)obj).ToString("yyyy-MM-dd"));
                                        }

                                    }

                                    if (val != null)
                                    {
                                        if (prop.PropertyType != typeof(DateTime))
                                        {
                                            xmlWriter.WriteString(val.ToString());
                                        }
                                        else
                                        {
                                            xmlWriter.WriteString(((DateTime)val).ToString("yyyy-MM-dd"));
                                        }
                                    }
                                }

                                xmlWriter.WriteEndElement();

                                xmlWriter.Flush();
                            }
                        }
                    }

                    xmlWriter.WriteEndElement();

                    xmlWriter.Flush();
                }
                else
                {
                    xmlWriter.WriteStartElement("Exception");
                    RenderException(ex, xmlWriter, ms);

                    xmlWriter.WriteEndElement();

                    xmlWriter.Flush();
                }
            }
            catch (Exception ex) { }

            return Encoding.UTF8.GetString(ms.ToArray());
        }

        private void RenderException(Exception ex, XmlTextWriter xmlWriter, MemoryStream ms)
        {
            xmlWriter.WriteStartElement("Type");
            xmlWriter.WriteString(ex.GetType().FullName);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Message");
            xmlWriter.WriteString(ex.Message);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Source");
            xmlWriter.WriteString(ex.Source);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("TargetSite");
            xmlWriter.WriteString(ex.TargetSite.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("StackTrace");
            xmlWriter.WriteString(ex.StackTrace);
            xmlWriter.WriteEndElement();

            if (ex.InnerException != null)
            {
                xmlWriter.WriteStartElement("InnerException");
                RenderException(ex.InnerException, xmlWriter, ms);
                xmlWriter.WriteEndElement();
            }
        }
    }

}
