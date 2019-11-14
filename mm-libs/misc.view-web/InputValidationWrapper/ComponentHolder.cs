using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace InputValidationWrapper
{
    class ComponentHolder : Control, INamingContainer
    {
        private InputValidationWrapper parent;

        public ComponentHolder(InputValidationWrapper parent)
        {
            this.parent = parent;
        }
    }
}
