using System;
using System.Collections.Generic;

namespace DLAPODemandCommons.Controls.Classes
{
    public class ArticlesChosenArgs : EventArgs
    {
        public List<String> SelectedITLList { get; set; }
    }

    public class ArticlesChosenAndImportedArgs : EventArgs
    {
        public Tuple<String,Guid>[] ImportedItlIdPairs { get; set; }
    }

}
