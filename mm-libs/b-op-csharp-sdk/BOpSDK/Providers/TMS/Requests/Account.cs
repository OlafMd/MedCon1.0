using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.TMS.Requests
{
    [DataContract]
    public class Account
    {
        [DataMember(Name = "id")]
        public Guid ID { get; set; }
        [DataMember(Name = "tenantId")]
        public Guid TenantID { get; set; }
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "passwordHash")]
        public string PasswordHash { get; set; }
        [DataMember(Name = "newPasswordHash")]
        public string NewPasswordHash { get; set; }
        [DataMember(Name = "verified")]
        public bool Verified { get; set; }
        [DataMember(Name = "disabled")]
        public bool Disabled { get; set; }
        [DataMember(Name = "disabledReason")]
        public string DisabledReason { get; set; }
        [DataMember(Name = "passwordChangeOnNextLogin")]
        public bool PasswordChangeOnNextLogin { get; set; }
        [DataMember(Name = "profileImageId")]
        public string ProfileImageId { get; set; }
        [DataMember(Name = "profileImageUrl")]
        public string ProfileImageUrl { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "accountType")]
        public EAccountType AccountType { get; set; }
        [DataMember(Name = "defaultContactPerson")]
        public bool DefaultContactPerson { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "locale")]
        public Locale Locale { get; set; }
        [DataMember(Name="company")]
        public bool Company { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "person")]
        public Person Person { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "organization")]
        public Organization Organization { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "address")]
        public Address Address { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "communicationContacts")]
        public List<CommunicationContact> CommunicationContacts { get; set; }
    }
   

    [DataContract]
    public class Person
    {
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        [DataMember(Name = "middleName")]
        public string MiddleName { get; set; }
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "gender")]
        public EGender Gender { get; set; }
        [DataMember(Name = "dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
    }

    [DataContract]
    public class Organization
    {
        [DataMember(Name = "vatNumber")]
        public string VatNumber { get; set; }
        [DataMember(Name = "organizationName1")]
        public string OrganizationName1 { get; set; }
        [DataMember(Name = "organizationName2")]
        public string OrganizationName2 { get; set; }
        [DataMember(Name = "numberOfEmployees")]
        public int NumberOfEmployees { get; set; }
        [DataMember(Name = "annualRevenue")]
        public double AnnualRevenue { get; set; }
    }

    [DataContract]
    public class Locale
    {
        [DataMember(Name = "country")]
        public string Country { get; set; }
        [DataMember(Name = "currency")]
        public string Currency { get; set; }
        [DataMember(Name = "language")]
        public string Language { get; set; }
    }

    [DataContract]
    public class Address
    {
        [DataMember(Name = "id")]
        public Guid ID { get; set; }
        [DataMember(Name = "countryCodeAlpha2")]
        public string CountryCodeAlpha2 { get; set; }
        [DataMember(Name = "region")]
        public string Region { get; set; }
        [DataMember(Name = "locality")]
        public string Locality { get; set; }
        [DataMember(Name = "postalCode")]
        public string PostalCode { get; set; }
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }
        [DataMember(Name = "lastName")]
        public string LastName { get; set; }
        [DataMember(Name = "companyName")]
        public string CompanyName { get; set; }
        [DataMember(Name = "careOf")]
        public string CareOf { get; set; }
        [DataMember(Name = "streetNumber")]
        public string StreetNumber { get; set; }
        [DataMember(Name = "streetAddress")]
        public string StreetAddress { get; set; }
        [DataMember(Name = "extendedAddress")]
        public string ExtendedAddress { get; set; }
        [DataMember(Name = "poBox")]
        public string PoBox { get; set; }
    }


    public enum ETenantType
    {
        Person = 0,
        Organization = 1,
    }

    public enum EAccountType
    {
        Master = 0,
        System = 1,
        Standard = 2,
        Transient = 3,
        Device = 4
    }

    public enum EGender
    {
        NotSpecified = 0,
        Male = 1,
        Female = 2,
        Other = 3,
    }
}
