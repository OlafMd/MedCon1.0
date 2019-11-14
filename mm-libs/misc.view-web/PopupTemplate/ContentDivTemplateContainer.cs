using System.Web.UI;

namespace PopupTemplate
{
    class ContentDivTemplateContainer : Control, INamingContainer
    {
        private PopupTemplate parent;

        public ContentDivTemplateContainer(PopupTemplate parent)
        {
            this.parent = parent;
        }
    }
}
