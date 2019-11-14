/* 
 * Generated on 9/15/2014 3:20:41 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_HEC;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_CMN;
using CL2_Contact.DomainManagement;
using System.Web;
using CL2_Contact.Complex.Retrieval;
namespace CL5_MyHealthClub_Patient.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PatientBaseData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PatientBaseData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_GPBD_1613 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            returnValue.Result = new Guid();
            var patient = new ORM_HEC_Patient();
            //var serializer = new JsonNetSerializer();
            //var connection = new ElasticConnection((String)HttpContext.GetGlobalResourceObject("Global", "ElasticConnection"), 9200);

            #region Save

            if (Parameter.ID == null || Parameter.ID == Guid.Empty)
            {
                //ORM_HEC_Patient
                patient.HEC_PatientID = Guid.NewGuid();
                patient.Tenant_RefID = securityTicket.TenantID;
                patient.Creation_Timestamp = DateTime.Now;
                patient.CMN_BPT_BusinessParticipant_RefID = Guid.NewGuid();
                patient.Save(Connection,Transaction);

                //ORM_CMN_BPT_BusinessParticipant
                var businessParticipant = new ORM_CMN_BPT_BusinessParticipant();
                businessParticipant.CMN_BPT_BusinessParticipantID = patient.CMN_BPT_BusinessParticipant_RefID;
                businessParticipant.IsNaturalPerson = true;
                businessParticipant.Tenant_RefID = securityTicket.TenantID;
                businessParticipant.Creation_Timestamp = DateTime.Now;
                businessParticipant.Modification_Timestamp = DateTime.Now;
                businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = Guid.NewGuid();
                businessParticipant.Save(Connection, Transaction);

                //ORM_CMN_PER_PersonInfo
                var personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.CMN_PER_PersonInfoID = businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                personInfo.FirstName = Parameter.FirstName;
                personInfo.LastName = Parameter.LastName;
                personInfo.PrimaryEmail = Parameter.PrimaryEmail;
                personInfo.Title = Parameter.Title;
                personInfo.ProfileImage_Document_RefID = Parameter.ProfileImage_Document_RefID;
                personInfo.BirthDate = Parameter.BirthDate;
                personInfo.Gender = Int32.Parse(Parameter.Gender);
                personInfo.Salutation_General = Parameter.AcademicTitle;
                personInfo.Address_RefID = Guid.NewGuid();
                personInfo.Tenant_RefID = securityTicket.TenantID;
                personInfo.Creation_Timestamp = DateTime.Now;
                personInfo.Modification_Timestamp = DateTime.Now;
                personInfo.AgeCalculation_YearOfBirth =DateTime.Now.Year - personInfo.BirthDate.Year;
                personInfo.Save(Connection, Transaction);

                //ORM_CMN_Address
                var address = new ORM_CMN_Address();
                address.CMN_AddressID = personInfo.Address_RefID;
                address.Street_Name = Parameter.Street_Name;
                address.Street_Number = Parameter.Street_Number;
                address.City_Name = Parameter.City_Name;
                address.City_PostalCode = Parameter.City_PostalCode;
                address.Country_ISOCode = Parameter.Country_ISOCode;
                address.Tenant_RefID = securityTicket.TenantID;
                address.Creation_Timestamp = DateTime.Now;
                address.Save(Connection, Transaction);

                //ORM_CMN_PER_PersonInfo_SocialSecurityNumber
                var socialSecurityNumber = new ORM_CMN_PER_PersonInfo_SocialSecurityNumber();
                socialSecurityNumber.CMN_PER_PersonInfo_SocialSecurityNumberID = Guid.NewGuid();
                socialSecurityNumber.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                socialSecurityNumber.SocialSecurityNumber = Parameter.SocialSecurityNumber;
                socialSecurityNumber.Tenant_RefID = securityTicket.TenantID;
                socialSecurityNumber.Creation_Timestamp = DateTime.Now;
                socialSecurityNumber.Save(Connection, Transaction);

                var TelephoneCompanyType = CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query.Search(Connection, Transaction,
                   new CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query()
                   {
                       Type = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Phone),
                       Tenant_RefID = securityTicket.TenantID,
                       IsDeleted = false
                   }).SingleOrDefault();

                var MobileCompanyType = CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query.Search(Connection, Transaction,
                       new CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query()
                       {
                           Type = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Mobile),
                           Tenant_RefID = securityTicket.TenantID,
                           IsDeleted = false
                       }).Single();
                var EmailType = CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query.Search(Connection, Transaction,
                       new CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query()
                       {
                           Type = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Email),
                           Tenant_RefID = securityTicket.TenantID,
                           IsDeleted = false
                       }).Single();
                //add into database
                //var UrlType = CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query.Search(Connection, Transaction,
                //      new CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query()
                //      {
                //          Type = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.URL),
                //          Tenant_RefID = securityTicket.TenantID,
                //          IsDeleted = false
                //      }).Single();
                var FaxType = CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query.Search(Connection, Transaction,
                      new CL1_CMN_PER.ORM_CMN_PER_CommunicationContact_Type.Query()
                      {
                          Type = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Fax),
                          Tenant_RefID = securityTicket.TenantID,
                          IsDeleted = false
                      }).Single();



                ORM_CMN_PER_CommunicationContact communicationContactsPhone = new ORM_CMN_PER_CommunicationContact();

                communicationContactsPhone.CMN_PER_CommunicationContactID = Guid.NewGuid();
                communicationContactsPhone.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                communicationContactsPhone.Contact_Type = TelephoneCompanyType.CMN_PER_CommunicationContact_TypeID;
                communicationContactsPhone.Content = Parameter.ContactTypes.Where(p => p.Type == DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Phone)).Single().Content;
                communicationContactsPhone.Creation_Timestamp = DateTime.Now;
                communicationContactsPhone.Modification_Timestamp = DateTime.Now;
                communicationContactsPhone.Tenant_RefID = securityTicket.TenantID;
                communicationContactsPhone.Save(Connection, Transaction);

                ORM_CMN_PER_CommunicationContact communicationContactsMobile = new ORM_CMN_PER_CommunicationContact();

                communicationContactsMobile.CMN_PER_CommunicationContactID = Guid.NewGuid();
                communicationContactsMobile.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                communicationContactsMobile.Contact_Type = MobileCompanyType.CMN_PER_CommunicationContact_TypeID;
                communicationContactsMobile.Content = Parameter.ContactTypes.Where(p => p.Type == DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Mobile)).Single().Content;
                communicationContactsMobile.Creation_Timestamp = DateTime.Now;
                communicationContactsMobile.Modification_Timestamp = DateTime.Now;
                communicationContactsMobile.Tenant_RefID = securityTicket.TenantID;

                communicationContactsMobile.Save(Connection, Transaction);

                ORM_CMN_PER_CommunicationContact communicationContactsEmail= new ORM_CMN_PER_CommunicationContact();

                communicationContactsEmail.CMN_PER_CommunicationContactID = Guid.NewGuid();
                communicationContactsEmail.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                communicationContactsEmail.Contact_Type = EmailType.CMN_PER_CommunicationContact_TypeID;
                communicationContactsEmail.Content = Parameter.ContactTypes.Where(p => p.Type == DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Email)).Single().Content;
                communicationContactsEmail.Creation_Timestamp = DateTime.Now;
                communicationContactsEmail.Modification_Timestamp = DateTime.Now;
                communicationContactsEmail.Tenant_RefID = securityTicket.TenantID;

                communicationContactsEmail.Save(Connection, Transaction);
              
                //*******************Save languages to patient************************

                if (Parameter.Languages != null && Parameter.Languages.Count() != 0)
                {
                    foreach (var language in Parameter.Languages)
                    {
                        ORM_CMN_BPT_BusinessParticipant_SpokenLanguage bpLanguage = new ORM_CMN_BPT_BusinessParticipant_SpokenLanguage();
                        bpLanguage.CMN_BPT_BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID;
                        bpLanguage.CMN_BPT_BusinessParticipant_SpokenLanguageID = Guid.NewGuid();
                        bpLanguage.CMN_Language_RefID = language.CMN_Language_RefID;
                        bpLanguage.IsDeleted = false;
                        bpLanguage.Tenant_RefID = securityTicket.TenantID;
                        bpLanguage.Save(Connection, Transaction);
                    }
                }

                //#region Upload To Elastic

                //bool indexExists = true;
                //#region set Mapping
                //string jsonPatientMapping = new MapBuilder<Patient>()
                //             .RootObject("patient", ro => ro
                //             .Properties(pr => pr
                //                 .MultiField("name", mfp => mfp.Fields(f => f
                //                     .String("name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                //                     .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                //                     )
                //                 )
                //                  .MultiField("last_name", mfp => mfp.Fields(f => f
                //                                     .String("last_name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                //                                     .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                //                                     )
                //                                  )
                //                    .MultiField("birthday", mfp => mfp.Fields(f => f
                //                                     .String("birthday", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                //                                     .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                //                                     )
                //                                  )
                //                 .MultiField("age", mfp => mfp.Fields(f => f
                //                                     .String("age", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                //                                     .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                //                                     )
                //                                  )
                //                 )).BuildBeautified();
                //#endregion


                //try
                //{
                //    connection.Head(new IndexExistsCommand(securityTicket.TenantID.ToString()));
                //}
                //catch (OperationException ex)
                //{
                //    if (ex.HttpStatusCode == 404)
                //        indexExists = false;
                //}

                //if (!indexExists)
                //{
            
                //    #region set index settings
                //    string settings = new IndexSettingsBuilder()
                //                          .Analysis(anl => anl
                //                              .Filter(fil => fil
                //                                  .EdgeNGram("autocomplete_filter", gr => gr.MinGram(1).MaxGram(20)))
                //                              .Analyzer(a => a
                //                                  .Custom("caseinsensitive", custom => custom
                //                                      .Tokenizer(DefaultTokenizers.keyword)
                //                                      .Filter("lowercase")
                //                                  )
                //                                  .Custom("autocomplete", custom => custom
                //                                      .Tokenizer(DefaultTokenizers.standard)
                //                                      .Filter("lowercase", "autocomplete_filter")
                //                                  )
                //                              )
                //                          )
                //                          .BuildBeautified();
                //    #endregion
                //    connection.Put(securityTicket.TenantID.ToString(), settings);

                //}


                //#region check if type exists

                //bool typeExists = true;

                //try
                //{
                //    connection.Head(new IndexExistsCommand(securityTicket.TenantID.ToString() + "/patient"));
                //}
                //catch (OperationException ex)
                //{
                //    if (ex.HttpStatusCode == 404)
                //        typeExists = false;
                //}
                //#endregion


                //if (!typeExists)
                //    connection.Put(new PutMappingCommand(securityTicket.TenantID.ToString(), "patient"), jsonPatientMapping);

                //string bulkCommand = new BulkCommand(index: securityTicket.TenantID.ToString(), type: "patient").Refresh();

                //List<Patient> patientList = new List<Patient>();
                //Patient patient_elastic = new Patient();
                //patient_elastic.id = patient.HEC_PatientID.ToString();
                //patient_elastic.age = (DateTime.Today.Year - Parameter.BirthDate.Year).ToString();
                //patient_elastic.birthday = Parameter.BirthDate.ToShortDateString();
                //patient_elastic.last_name = Parameter.LastName;
                //patient_elastic.name = Parameter.FirstName;
                //patientList.Add(patient_elastic);

                //string bulkJson = new BulkBuilder(serializer)
                //    .BuildCollection(patientList, (builder, pro) => builder.Index(data: pro, id: pro.id)
                //    );
                //connection.Post(bulkCommand, bulkJson);

                //#endregion

            }
            #endregion
            else
            {
                #region Delete
                if (Parameter.isDeleted)
                {
                    var patientQuery = new ORM_HEC_Patient.Query();
                    patientQuery.HEC_PatientID = Parameter.ID;
                    patientQuery.IsDeleted = false;
                    patientQuery.Tenant_RefID = securityTicket.TenantID;

                    patient = ORM_HEC_Patient.Query.Search(Connection, Transaction, patientQuery).Single();
                    patient.IsDeleted = true;
                    patient.Save(Connection,Transaction);

                    var businessParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                    businessParticipantQuery.CMN_BPT_BusinessParticipantID = patient.CMN_BPT_BusinessParticipant_RefID;
                    businessParticipantQuery.IsDeleted = false;
                    businessParticipantQuery.Tenant_RefID = securityTicket.TenantID;

                    var businessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantQuery).Single();
                    businessParticipant.IsDeleted = true;
                    businessParticipant.Save(Connection, Transaction);

                    var personInfoQuery = new ORM_CMN_PER_PersonInfo.Query();
                    personInfoQuery.CMN_PER_PersonInfoID = businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                    personInfoQuery.IsDeleted = false;
                    personInfoQuery.Tenant_RefID = securityTicket.TenantID;

                    var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, personInfoQuery).Single();
                    personInfo.IsDeleted = true;
                    personInfo.Save(Connection,Transaction);

                    var addressQuery = new ORM_CMN_Address.Query();
                    addressQuery.CMN_AddressID = personInfo.Address_RefID;
                    addressQuery.IsDeleted = false;
                    addressQuery.Tenant_RefID = securityTicket.TenantID;

                    var address = ORM_CMN_Address.Query.Search(Connection, Transaction, addressQuery).Single();
                    address.IsDeleted = true;
                    address.Save(Connection, Transaction);

                    var socialSecurityNumberQuery = new ORM_CMN_PER_PersonInfo_SocialSecurityNumber.Query();
                    socialSecurityNumberQuery.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                    socialSecurityNumberQuery.IsDeleted = false;
                    socialSecurityNumberQuery.Tenant_RefID = securityTicket.TenantID;

                    var socialSecurityNumber = ORM_CMN_PER_PersonInfo_SocialSecurityNumber.Query.Search(Connection, Transaction, socialSecurityNumberQuery).Single();
                    socialSecurityNumber.IsDeleted = true;
                    socialSecurityNumber.Save(Connection, Transaction);

                    var communicationContactQuery = new ORM_CMN_PER_CommunicationContact.Query();
                    communicationContactQuery.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                    communicationContactQuery.IsDeleted = false;
                    communicationContactQuery.Tenant_RefID = securityTicket.TenantID;

                    var communicationContactList = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, communicationContactQuery).ToList();

                    ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query.SoftDelete(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query { CMN_BPT_BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });

                    //// delete on Elastic
                    //connection.Delete(securityTicket.TenantID.ToString() + "/patient/" + Parameter.ID.ToString());
                }
                #endregion
                #region Edit            
                else
                {
                    var patientQuery = new ORM_HEC_Patient.Query();
                    patientQuery.HEC_PatientID = Parameter.ID;
                    patientQuery.IsDeleted = false;
                    patientQuery.Tenant_RefID = securityTicket.TenantID;

                    patient = ORM_HEC_Patient.Query.Search(Connection, Transaction, patientQuery).Single();

                    var businessParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                    businessParticipantQuery.CMN_BPT_BusinessParticipantID = patient.CMN_BPT_BusinessParticipant_RefID;
                    businessParticipantQuery.IsDeleted = false;
                    businessParticipantQuery.Tenant_RefID = securityTicket.TenantID;

                    var businessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantQuery).Single();

                    var personInfoQuery = new ORM_CMN_PER_PersonInfo.Query();
                    personInfoQuery.CMN_PER_PersonInfoID = businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                    personInfoQuery.IsDeleted = false;
                    personInfoQuery.Tenant_RefID = securityTicket.TenantID;
                    
                    var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, personInfoQuery).Single();
                    personInfo.FirstName = Parameter.FirstName;
                    personInfo.LastName = Parameter.LastName;
                    personInfo.PrimaryEmail = Parameter.PrimaryEmail;
                    personInfo.Title = Parameter.Title;
                    personInfo.Gender = Int32.Parse(Parameter.Gender);
                    personInfo.ProfileImage_Document_RefID = Parameter.ProfileImage_Document_RefID;
                    personInfo.BirthDate = Parameter.BirthDate;
                    personInfo.Salutation_General = Parameter.AcademicTitle;
                    personInfo.Modification_Timestamp = DateTime.Now;
                    personInfo.AgeCalculation_YearOfBirth = DateTime.Now.Year - personInfo.BirthDate.Year;
                    personInfo.Save(Connection, Transaction);

                    if (personInfo.Address_RefID != Guid.Empty)
                    {
                        var addressQuery = new ORM_CMN_Address.Query();
                        addressQuery.CMN_AddressID = personInfo.Address_RefID;
                        addressQuery.IsDeleted = false;
                        addressQuery.Tenant_RefID = securityTicket.TenantID;

                        var address = ORM_CMN_Address.Query.Search(Connection, Transaction, addressQuery).Single();
                        address.Street_Name = Parameter.Street_Name;
                        address.Street_Number = Parameter.Street_Number;
                        address.City_Name = Parameter.City_Name;
                        address.City_PostalCode = Parameter.City_PostalCode;
                        address.Country_ISOCode = Parameter.Country_ISOCode;
                        address.Save(Connection, Transaction);

                    }
                    else
                    {
                        var address = new ORM_CMN_Address();
                        address.CMN_AddressID = Guid.NewGuid();
                        address.Street_Name = Parameter.Street_Name;
                        address.Street_Number = Parameter.Street_Number;
                        address.City_Name = Parameter.City_Name;
                        address.City_PostalCode = Parameter.City_PostalCode;
                        address.Country_ISOCode = Parameter.Country_ISOCode;
                        address.Tenant_RefID = securityTicket.TenantID;
                        address.Creation_Timestamp = DateTime.Now;
                        address.Save(Connection, Transaction);


                        personInfo.Address_RefID = address.CMN_AddressID;
                        personInfo.Save(Connection, Transaction);
                    }

                   
                    var socialSecurityNumberQuery = new ORM_CMN_PER_PersonInfo_SocialSecurityNumber.Query();
                    socialSecurityNumberQuery.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                    socialSecurityNumberQuery.IsDeleted = false;
                    socialSecurityNumberQuery.Tenant_RefID = securityTicket.TenantID;

                    var socialSecurityNumber = ORM_CMN_PER_PersonInfo_SocialSecurityNumber.Query.Search(Connection, Transaction, socialSecurityNumberQuery).SingleOrDefault();

                    if (socialSecurityNumber == null)
                    {
                        socialSecurityNumber = new ORM_CMN_PER_PersonInfo_SocialSecurityNumber();
                        socialSecurityNumber.CMN_PER_PersonInfo_SocialSecurityNumberID = Guid.NewGuid();
                        socialSecurityNumber.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                        socialSecurityNumber.Tenant_RefID = securityTicket.TenantID;
                    }

                    socialSecurityNumber.SocialSecurityNumber = Parameter.SocialSecurityNumber;
                    socialSecurityNumber.Save(Connection, Transaction);

                    var communicationContactQuery = new ORM_CMN_PER_CommunicationContact.Query();
                    communicationContactQuery.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                    communicationContactQuery.IsDeleted = false;
                    communicationContactQuery.Tenant_RefID = securityTicket.TenantID;

                    var communicationContactList = ORM_CMN_PER_CommunicationContact.Query.Search(Connection, Transaction, communicationContactQuery).ToList();

                    List<string> unusedTypes = new List<string>() 
                    {
                        DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.URL),
                        DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Mobile),
                        DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Phone),
                        DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Email) 
                    };

                    foreach (var communicationContact in communicationContactList)
                    {
                        var communicationContact_TypeQuery = new ORM_CMN_PER_CommunicationContact_Type.Query();
                        communicationContact_TypeQuery.CMN_PER_CommunicationContact_TypeID = communicationContact.Contact_Type;
                        communicationContact_TypeQuery.IsDeleted = false;
                        communicationContact_TypeQuery.Tenant_RefID = securityTicket.TenantID;
                        var communicationContact_Type = ORM_CMN_PER_CommunicationContact_Type.Query.Search(Connection, Transaction, communicationContact_TypeQuery).Single();

                        var newType = Parameter.ContactTypes.Where(i => i.Type == communicationContact_Type.Type).Single();
                        communicationContact.Content = newType.Content;
                        communicationContact.Modification_Timestamp = DateTime.Now;
                        communicationContact.Save(Connection,Transaction);

                        if(unusedTypes.Contains(communicationContact_Type.Type))
                            unusedTypes.Remove(communicationContact_Type.Type);
                    }

                    var contactTypes = cls_Get_AllComunicationContactTypes.Invoke(Connection, Transaction, securityTicket).Result.ToList();
                    
                    foreach (var type in unusedTypes)
                    {
                        ORM_CMN_PER_CommunicationContact communicationContactsPhone = new ORM_CMN_PER_CommunicationContact();

                        communicationContactsPhone.CMN_PER_CommunicationContactID = Guid.NewGuid();
                        communicationContactsPhone.PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                        P_L2CN_GCTIDfGPMID_1359 contantTypeParam = new P_L2CN_GCTIDfGPMID_1359();
                        contantTypeParam.Type = type;
                        var contantTypeID = cls_Get_ContantTypeID_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, contantTypeParam, securityTicket).Result.ContactTypeID;
                        communicationContactsPhone.Contact_Type = contantTypeID;
                        communicationContactsPhone.Content = Parameter.ContactTypes.Where(p => p.Type == DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(CL2_Contact.DomainManagement.EComunactionContactType.Phone)).Single().Content;
                        communicationContactsPhone.Creation_Timestamp = DateTime.Now;
                        communicationContactsPhone.Modification_Timestamp = DateTime.Now;
                        communicationContactsPhone.Tenant_RefID = securityTicket.TenantID;
                        communicationContactsPhone.Save(Connection, Transaction);

                    }

                    //connection.Delete(securityTicket.TenantID.ToString() + "/patient/" + Parameter.ID.ToString());
                    //string bulkCommand = new BulkCommand(index: securityTicket.TenantID.ToString(), type: "patient").Refresh();

                    //List<Patient> patientList = new List<Patient>();
                    //Patient patient_elastic = new Patient();
                    //patient_elastic.id = patient.HEC_PatientID.ToString();
                    //patient_elastic.age = (DateTime.Today.Year - Parameter.BirthDate.Year).ToString();
                    //patient_elastic.birthday = Parameter.BirthDate.ToShortDateString();
                    //patient_elastic.last_name = Parameter.LastName;
                    //patient_elastic.name = Parameter.FirstName;
                    //patientList.Add(patient_elastic);

                    //string bulkJson = new BulkBuilder(serializer)
                    //    .BuildCollection(patientList, (builder, pro) => builder.Index(data: pro, id: pro.id)
                    //    );
                    //connection.Post(bulkCommand, bulkJson);


                    #region languages

                    if (Parameter.Languages == null || Parameter.Languages.Count() == 0)
                    {
                        P_L5PA_GPBD_1613_Languages Languages = new P_L5PA_GPBD_1613_Languages();
                        Languages.CMN_Language_RefID = Guid.Empty;
                    }
                    else if (Parameter.Languages != null || Parameter.Languages.Count() != 0)
                    {

                        foreach (var language in Parameter.Languages)
                        {
                            var languageToPatient = ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query { CMN_Language_RefID = language.CMN_Language_RefID, CMN_BPT_BusinessParticipant_RefID = patient.CMN_BPT_BusinessParticipant_RefID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                            if (languageToPatient == null)
                            {
                                ORM_CMN_BPT_BusinessParticipant_SpokenLanguage bpLanguage = new ORM_CMN_BPT_BusinessParticipant_SpokenLanguage();
                                bpLanguage.CMN_BPT_BusinessParticipant_RefID = patient.CMN_BPT_BusinessParticipant_RefID;
                                bpLanguage.CMN_BPT_BusinessParticipant_SpokenLanguageID = Guid.NewGuid();
                                bpLanguage.CMN_Language_RefID = language.CMN_Language_RefID;
                                bpLanguage.IsDeleted = false;
                                bpLanguage.Tenant_RefID = securityTicket.TenantID;
                                bpLanguage.Save(Connection, Transaction);
                            }
                        }

                        // deleting languages to patient that were deleted during edit

                        List<ORM_CMN_BPT_BusinessParticipant_SpokenLanguage> languageToDoctorList = ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query { CMN_BPT_BusinessParticipant_RefID = patient.CMN_BPT_BusinessParticipant_RefID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                        foreach (var languageToDoctor in languageToDoctorList)
                        {
                            if (Parameter.Languages.FirstOrDefault(x => x.CMN_Language_RefID == languageToDoctor.CMN_Language_RefID) == null)
                            {
                                languageToDoctor.IsDeleted = true;
                                languageToDoctor.Save(Connection, Transaction);
                            }
                        }

                    }
                    else
                    {
                        List<ORM_CMN_BPT_BusinessParticipant_SpokenLanguage> languageToDoctorList = ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_SpokenLanguage.Query { CMN_BPT_BusinessParticipant_RefID = patient.CMN_BPT_BusinessParticipant_RefID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                        if (languageToDoctorList != null || languageToDoctorList.Count() != 0)
                        {
                            foreach (var language in languageToDoctorList)
                            {
                                language.IsDeleted = true;
                                language.Save(Connection, Transaction);
                            }
                        }
                    }

                    #endregion

                }
                #endregion
            }
            returnValue.Result = patient.HEC_PatientID;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PA_GPBD_1613 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PA_GPBD_1613 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_GPBD_1613 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_GPBD_1613 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
			try
			{

				if (cleanupConnection == true) 
				{
					Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
					Connection.Open();
				}
				if (cleanupTransaction == true)
				{
					Transaction = Connection.BeginTransaction();
				}

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

				#region Cleanup Connection/Transaction
				//Commit the transaction 
				if (cleanupTransaction == true)
				{
					Transaction.Commit();
				}
				//Close the connection
				if (cleanupConnection == true)
				{
					Connection.Close();
				}
				#endregion
			}
			catch (Exception ex)
			{
				try
				{
					if (cleanupTransaction == true && Transaction!=null)
					{
						Transaction.Rollback();
					}
				}
				catch { }

				try
				{
					if (cleanupConnection == true && Connection != null)
					{
						Connection.Close();
					}
				}
				catch { }

				throw new Exception("Exception occured in method cls_Save_PatientBaseData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PA_GPBD_1613 for attribute P_L5PA_GPBD_1613
		[DataContract]
		public class P_L5PA_GPBD_1613 
		{
			[DataMember]
			public P_L5PA_GPBD_1613_ContactTypes[] ContactTypes { get; set; }
			[DataMember]
			public P_L5PA_GPBD_1613_Languages[] Languages { get; set; }

			//Standard type parameters
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 
			[DataMember]
			public Guid ID { get; set; } 
			[DataMember]
			public String Gender { get; set; } 
			[DataMember]
			public String AcademicTitle { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String SocialSecurityNumber { get; set; } 
			[DataMember]
			public Guid ProfileImage_Document_RefID { get; set; } 
			[DataMember]
			public bool isDeleted { get; set; } 

		}
		#endregion
		#region SClass P_L5PA_GPBD_1613_ContactTypes for attribute ContactTypes
		[DataContract]
		public class P_L5PA_GPBD_1613_ContactTypes 
		{
			//Standard type parameters
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public String Type { get; set; } 

		}
		#endregion
		#region SClass P_L5PA_GPBD_1613_Languages for attribute Languages
		[DataContract]
		public class P_L5PA_GPBD_1613_Languages 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_Language_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_PatientBaseData(,P_L5PA_GPBD_1613 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_PatientBaseData.Invoke(connectionString,P_L5PA_GPBD_1613 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new CL5_MyHealthClub_Patient.Atomic.Manipulation.P_L5PA_GPBD_1613();
parameter.ContactTypes = ...;
parameter.Languages = ...;

parameter.FirstName = ...;
parameter.LastName = ...;
parameter.PrimaryEmail = ...;
parameter.Street_Name = ...;
parameter.Street_Number = ...;
parameter.City_Name = ...;
parameter.Title = ...;
parameter.CMN_AddressID = ...;
parameter.Country_ISOCode = ...;
parameter.ID = ...;
parameter.Gender = ...;
parameter.AcademicTitle = ...;
parameter.BirthDate = ...;
parameter.City_PostalCode = ...;
parameter.SocialSecurityNumber = ...;
parameter.ProfileImage_Document_RefID = ...;
parameter.isDeleted = ...;

*/
