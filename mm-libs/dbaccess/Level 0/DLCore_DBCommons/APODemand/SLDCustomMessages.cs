using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DLCore_DBCommons.APODemand
{
    public enum ECustomMessages
    {
        [Description("comment.article-replaced")]
        ArticleReplaced
    }

    public static partial class ResourceFilePath
    {
        public static String CustomMessages = "DLCore_DBCommons.APODemand.StaticListDataResource.custom-messages.xml";
    }
}
