using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDBMethods.Pharmacy.Model
{
    public class Pharmacy
    {
        [JsonProperty(PropertyName = "pharmacyID")]
        public Guid PharmacyID { get; set; }

        //Pharmacy info
        [JsonProperty(PropertyName = "pharmacyName")]
        public String PharmacyName { get; set; }
        [JsonProperty(PropertyName = "email")]
        public String Email { get; set; }
        [JsonProperty(PropertyName = "phoneNumber")]
        public String PhoneNumber { get; set; }
        [JsonProperty(PropertyName = "fax")]
        public String Fax { get; set; }
        [JsonProperty(PropertyName = "street")]
        public String Street { get; set; }
        [JsonProperty(PropertyName = "streetNumber")]
        public String StreetNumber { get; set; }
        [JsonProperty(PropertyName = "zipCode")]
        public String ZipCode { get; set; }
        [JsonProperty(PropertyName = "town")]
        public String Town { get; set; }
        [JsonProperty(PropertyName = "isExternalPharmacy")]
        public Boolean IsExternalPharmacy { get; set; }

        //Contact person info
        [JsonProperty(PropertyName = "contactPersonName")]
        public String ContactPersonName { get; set; }


        public Pharmacy(Guid PharmacyID, String PharmacyName, String Email, String PhoneNumber, String Fax, String Street, String StreetNumber, String ZipCode, String Town, bool IsExternalPharmacy, String ContactPersonName)
        {
            this.PharmacyID = PharmacyID;
            this.PharmacyName = PharmacyName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Fax = Fax;
            this.Street = Street;
            this.StreetNumber = StreetNumber;
            this.ZipCode = ZipCode;
            this.Town = Town;
            this.IsExternalPharmacy = IsExternalPharmacy;
            this.ContactPersonName = ContactPersonName;
        }
    }

    public class DeletePharmacy
    {
        public Guid pharmacyID { get; set; }
    }

    public class SortPharmacy
    {
        public bool isAsc { get; set; }
        public String sortBy { get; set; }
    }
}
