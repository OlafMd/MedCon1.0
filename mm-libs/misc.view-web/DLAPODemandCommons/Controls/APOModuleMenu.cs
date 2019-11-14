using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using DLCore_DBCommons.APODemand;
using BOp.Message;
using System.Xml.Serialization;
using DLCore_DBCommons.Utils;
using Logger;


namespace DLAPODemandCommons.Controls
{
    

    public enum EModuleType
    {
        Dashboard,
        Admin,
        Procurement,
        Warehousing,
        Workshop,
        Bookeeping,
        Cashier,
        Backoffice,
        Webshop,
        CustomerManagement,
        Unknown
    }

    public class APOModuleMenu : Control
    {
        private const String NO_RIGHTS_REQUIRED = "no-rights-required";

        #region Public Properties

        public List<EAccountFunctionLevelRight> UserRights
        {
            get
            {
                object userRights = ViewState["UserRights"];
                return (userRights == null) ? null : (List<EAccountFunctionLevelRight>)userRights;
            }
            set
            {
                ViewState["UserRights"] = value;
            }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            var output = "<div class='modulmenu'> <ul>";

            foreach (var menuitem in GetAvailableModulesForCurrentUser())
            {
                output += String.Format("<li> <a class='{0}' href='{1}'> {2} </a></li>",
                    menuitem.Css,
                    menuitem.Url,
                    menuitem.Label
                    );
            }
            
            output += "</ul></div>";

            writer.Write(output);
        }

        public static void Init_Menu(string path)
        {
            XMLModelReader.FilePath = path;
        }

   
        private List<APOModuleMenuItem> GetAvailableModulesForCurrentUser()
        {
            var  availableModules = new List<APOModuleMenuItem>();
            foreach (var module in XMLModelReader.Instance.MenuModel.APOModuleMenuItems)
            {

                if (module.UserRights.Count(i => i.Trim() == NO_RIGHTS_REQUIRED) == 1)
                    availableModules.Add(module);
                else if(module.UserRights.Intersect(UserRights.Select(i=>EnumUtils.GetEnumDescription(i))).Any())
                    availableModules.Add(module);
            }

            return availableModules.ToList();
        }

       
    }

    public sealed class XMLModelReader
    {
        private static XMLModelReader instance = null;
        private static readonly object padlock = new object();

        
        public APOModuleMenuModel MenuModel;
        public static string FilePath;

        XMLModelReader()
        {
            MenuModel = ReadModuleMenuModel();
        }

        

        public static XMLModelReader Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new XMLModelReader();
                    }
                    return instance;
                }
            }
        }

        

        private APOModuleMenuModel ReadModuleMenuModel()
        {
            try
            {
                using (var reader = new StreamReader(FilePath))
                {
                    var fileContent = reader.ReadToEnd();
                    return APOModuleMenuModel.GetModel(fileContent);
                }

            }
            catch (Exception ex)
            {
                ServerLog.Instance.Error(ex);
            }
            return new APOModuleMenuModel();
        }

        private string ResolveLocalFileDestination(string fileName)
        {
            return string.Format(@"{0}\{1}"
                , AppDomain.CurrentDomain.BaseDirectory
                , fileName);
        }

        private string ResolveDestinationFilePath(string destinationFolder, string fileName)
        {
            return string.Format(@"{0}\{1}"
                , destinationFolder
                , fileName);
        }

    }

    #region DataModel

    public class APOModuleMenuModel
    {
        [XmlArray("APOModuleMenuItems")]
        [XmlArrayItem("APOModuleMenu")]
        public List<APOModuleMenuItem> APOModuleMenuItems { get; set; }

        public static APOModuleMenuModel GetModel(string payload)
        {
            return SerializationUtils.ParseFromPayload<APOModuleMenuModel>(payload);
        }
    }

    public class APOModuleMenuItem
    {
        public string Label { get; set; }
        public string Url { get; set; }
        public string Css { get; set; }

        [XmlArray("UserRights")]
        [XmlArrayItem("UserRight")]
        public List<String> UserRights { get; set; }
    }

    #endregion
}
