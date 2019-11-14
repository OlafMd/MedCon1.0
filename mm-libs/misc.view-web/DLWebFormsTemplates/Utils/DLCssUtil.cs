using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace DLWebFormsTemplates.Utils
{
    public class DLCssUtil : IDLCssUtil
    {

        /// <summary>
        /// Toggles the specified css class on the specified web control.
        /// </summary>
        /// <param name="Control"></param>
        /// <param name="ClassName"></param>
        public void ToggleCssClass(WebControl Control, string ClassName)
        {
            if (Control.CssClass.IndexOf(ClassName) == -1)
            {
                Control.CssClass += " " + ClassName;
            }
            else
            {
                Control.CssClass = Control.CssClass.Replace(ClassName, "");
            }
            Control.CssClass = Control.CssClass.Trim();
        }

        /// <summary>
        /// Removes the specified css class on the specified web control.
        /// </summary>
        /// <param name="Control"></param>
        /// <param name="ClassName"></param>
        public void RemoveCssClass(WebControl Control, string ClassName)
        {
            if (Control.CssClass.IndexOf(ClassName) != -1)
            {
                Control.CssClass = Control.CssClass.Replace(ClassName, "");
            }
            Control.CssClass = Control.CssClass.Trim();
        }  

        /// <summary>
        /// Determins whether the specified web control has the specified class.
        /// </summary>
        /// <param name="Control"></param>
        /// <param name="ClassName"></param>
        /// <returns></returns>
        public bool HasCssClass(WebControl Control, string ClassName)
        {
            return (Control.CssClass.IndexOf(ClassName) == -1);
          
        }

        /// <summary>
        /// Sets or removes specified class on the specified web control, depending in the direction parameter;
        /// </summary>
        /// <param name="Control"></param>
        /// <param name="ClassName"></param>
        /// <param name="Direction">true - set class, false - remove class</param>
        public void SetCssClass(WebControl Control, string ClassName, bool Direction = true)
        {
            if (Control.CssClass.IndexOf(ClassName) == -1 && Direction == true)
            {
                Control.CssClass += " " + ClassName;
            }
            else if (Control.CssClass.IndexOf(ClassName) > -1 && Direction == false)
            {
                Control.CssClass = Control.CssClass.Replace(ClassName, "");
            }
        }

        /// <summary>
        /// Sets or removes specified class on the specified web control, depending in the direction parameter;
        /// </summary>
        /// <param name="Control"></param>
        /// <param name="ClassName"></param>
        /// <param name="Direction">true - set class, false - remove class</param>
        public bool isControlContainsCssClass(WebControl Control, string ClassName)
        {
            if (Control.CssClass.IndexOf(ClassName) == -1)
            {
                return true;
            }
            else
            {
                return false;
            }      
        }

        /// <summary>
        /// Sets EXACTLY specified class on the specified web control, depending in the direction parameter;
        /// </summary>
        /// <param name="Control"></param>
        /// <param name="ClassName"></param>
        public void SetExactCssClass(WebControl Control, string ClassName)
        {
            if (Control.CssClass.IndexOf(ClassName) == -1)
            {
                Control.CssClass = ClassName;
            }
            else if (Control.CssClass.IndexOf(ClassName) > -1)
            {
                Control.CssClass = Control.CssClass.Replace(ClassName, "");
            }
        }

        /// <summary>
        /// Sets or removes the id on the session
        /// </summary>
        /// <param name="DataID"></param>
        public void ToggleIDOnSession(Guid DataID)
        {
            List<Guid> SelectedGuids = (List<Guid>)HttpContext.Current.Session["SelectedGuids"];
            if (SelectedGuids == null) SelectedGuids = new List<Guid>();

            if (SelectedGuids.Contains(DataID))
            {
                SelectedGuids.Remove(DataID);
            }
            else
            {
                SelectedGuids.Add(DataID);
            }
            HttpContext.Current.Session["SelectedGuids"] = SelectedGuids;
        }

        /// <summary>
        /// Determins whether the specified guid is in the list of selected guids on the session
        /// </summary>
        /// <param name="DataID"></param>
        /// <returns></returns>
        public bool IsIDOnSession(Guid DataID)
        {
            List<Guid> SelectedGuids = (List<Guid>)HttpContext.Current.Session["SelectedGuids"];
            if (SelectedGuids == null)
            {
                return false;
            }
            else
            {
                return SelectedGuids.Contains(DataID);
            }
        }
    }
}