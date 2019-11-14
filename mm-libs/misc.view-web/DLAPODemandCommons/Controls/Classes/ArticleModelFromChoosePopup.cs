using System;

namespace DLAPODemandCommons.Controls.Classes
{
    [Serializable]
    public class ArticleModelFromChoosePopup
    {
        public Guid ProductID { get; set; }

        public String ProductITL { get; set; }

        public String PZN { get; set; }

        public String ArticleName { get; set; }

        public String DosageForm { get; set; }

        public String Unit { get; set; }

        public decimal ABDAPrice { get; set; }

        public String Producer { get; set; }

        

    }
}