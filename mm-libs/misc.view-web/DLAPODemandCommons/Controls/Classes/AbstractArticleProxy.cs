using System;
using System.Collections.Generic;
using BOp.Infrastructure.Authentication;
using Danulabs.Utils;

namespace DLAPODemandCommons.Controls.Classes
{
    public abstract class AbstractArticleProxy
    {
        public String SessionTicket
        {
            get
            {
                SessionTokenInformation sessionTokenInfo = SessionGlobal.Instance.SessionTokenInfo;
                return sessionTokenInfo.Session.SessionToken;
            }
        }

        public abstract Tuple<String, Guid>[] ImportSelectedArticlesAndGetResult(List<String> selectedITLs);

        public abstract List<ArticleModelFromChoosePopup> GetSelectedArticlesModel(List<String> selectedITLs);
    }
}
