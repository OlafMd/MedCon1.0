/* 
 * Generated on 7/8/2013 12:06:43 PM
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

namespace CL5_Lucentis_Practice.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Practice_For_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Practice_For_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MP_GPRAFID_1008 Execute(DbConnection Connection,DbTransaction Transaction,P_L5MP_GPRAFID_1008 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5MP_GPRAFID_1008();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Practice.Atomic.Retrieval.SQL.cls_Get_Practice_For_ID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_MedicalPractiseID", Parameter.HEC_MedicalPractiseID);


			List<L5MP_GPRAFID_1008> results = new List<L5MP_GPRAFID_1008>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "AffinityStatus_Name_DictID","HEC_MedicalPractiseID","Contact_EmergencyPhoneNumber","HEC_PublicHealthcare_PhysitianAssociationID","HealthAssociation_Name","PracticeName","Practice_CMN_BPT_BusinessParticipantID","CMN_COM_CompanyInfoID","Contact_UCD_RefID","CMN_COM_CompanyInfo_TypeID","CompanyType_Name_DictID","Contact_CMN_UniversalContactDetailID","Contact_Email","Contact_Website_URL","Shipping_CMN_UniversalContactDetailID","CMN_COM_CompanyInfo_AddressID","WeeklySurgeryHours_Template_RefID","ContactPerson_RefID","WeeklyOfficeHours_Template_RefID","ContactPersonName","ConsultingHours_FormattedOfficeHours","WorkingHours_FormattedOfficeHours","CMN_BPT_CTM_CustomerID","CMN_BPT_CTM_AffinityStatusID","ZIP","Town","Street_Number","Street_Name","Region_Name","Street_Name1","Street_Number1","ZIP1","Town1","Region_Name1" });
				while(reader.Read())
				{
					L5MP_GPRAFID_1008 resultItem = new L5MP_GPRAFID_1008();
					//0:Parameter AffinityStatus_Name of type Dict
					resultItem.AffinityStatus_Name = reader.GetDictionary(0);
					resultItem.AffinityStatus_Name.SourceTable = "cmn_bpt_ctm_affinitystatuses";
					loader.Append(resultItem.AffinityStatus_Name);
					//1:Parameter HEC_MedicalPractiseID of type Guid
					resultItem.HEC_MedicalPractiseID = reader.GetGuid(1);
					//2:Parameter Contact_EmergencyPhoneNumber of type String
					resultItem.Contact_EmergencyPhoneNumber = reader.GetString(2);
					//3:Parameter HEC_PublicHealthcare_PhysitianAssociationID of type Guid
					resultItem.HEC_PublicHealthcare_PhysitianAssociationID = reader.GetGuid(3);
					//4:Parameter HealthAssociation_Name of type String
					resultItem.HealthAssociation_Name = reader.GetString(4);
					//5:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(5);
					//6:Parameter Practice_CMN_BPT_BusinessParticipantID of type Guid
					resultItem.Practice_CMN_BPT_BusinessParticipantID = reader.GetGuid(6);
					//7:Parameter CMN_COM_CompanyInfoID of type Guid
					resultItem.CMN_COM_CompanyInfoID = reader.GetGuid(7);
					//8:Parameter Contact_UCD_RefID of type Guid
					resultItem.Contact_UCD_RefID = reader.GetGuid(8);
					//9:Parameter CMN_COM_CompanyInfo_TypeID of type Guid
					resultItem.CMN_COM_CompanyInfo_TypeID = reader.GetGuid(9);
					//10:Parameter CompanyType_Name of type Dict
					resultItem.CompanyType_Name = reader.GetDictionary(10);
					resultItem.CompanyType_Name.SourceTable = "cmn_com_companyinfo_types";
					loader.Append(resultItem.CompanyType_Name);
					//11:Parameter Contact_CMN_UniversalContactDetailID of type Guid
					resultItem.Contact_CMN_UniversalContactDetailID = reader.GetGuid(11);
					//12:Parameter Contact_Email of type String
					resultItem.Contact_Email = reader.GetString(12);
					//13:Parameter Contact_Website_URL of type String
					resultItem.Contact_Website_URL = reader.GetString(13);
					//14:Parameter Shipping_CMN_UniversalContactDetailID of type Guid
					resultItem.Shipping_CMN_UniversalContactDetailID = reader.GetGuid(14);
					//15:Parameter CMN_COM_CompanyInfo_AddressID of type Guid
					resultItem.CMN_COM_CompanyInfo_AddressID = reader.GetGuid(15);
					//16:Parameter WeeklySurgeryHours_Template_RefID of type Guid
					resultItem.WeeklySurgeryHours_Template_RefID = reader.GetGuid(16);
					//17:Parameter ContactPerson_RefID of type Guid
					resultItem.ContactPerson_RefID = reader.GetGuid(17);
					//18:Parameter WeeklyOfficeHours_Template_RefID of type Guid
					resultItem.WeeklyOfficeHours_Template_RefID = reader.GetGuid(18);
					//19:Parameter ContactPersonName of type String
					resultItem.ContactPersonName = reader.GetString(19);
					//20:Parameter ConsultingHours_FormattedOfficeHours of type String
					resultItem.ConsultingHours_FormattedOfficeHours = reader.GetString(20);
					//21:Parameter WorkingHours_FormattedOfficeHours of type String
					resultItem.WorkingHours_FormattedOfficeHours = reader.GetString(21);
					//22:Parameter CMN_BPT_CTM_CustomerID of type Guid
					resultItem.CMN_BPT_CTM_CustomerID = reader.GetGuid(22);
					//23:Parameter CMN_BPT_CTM_AffinityStatusID of type Guid
					resultItem.CMN_BPT_CTM_AffinityStatusID = reader.GetGuid(23);
					//24:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(24);
					//25:Parameter Town of type String
					resultItem.Town = reader.GetString(25);
					//26:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(26);
					//27:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(27);
					//28:Parameter Region_Name of type String
					resultItem.Region_Name = reader.GetString(28);
					//29:Parameter Street_Name1 of type String
					resultItem.Street_Name1 = reader.GetString(29);
					//30:Parameter Street_Number1 of type String
					resultItem.Street_Number1 = reader.GetString(30);
					//31:Parameter ZIP1 of type String
					resultItem.ZIP1 = reader.GetString(31);
					//32:Parameter Town1 of type String
					resultItem.Town1 = reader.GetString(32);
					//33:Parameter Region_Name1 of type String
					resultItem.Region_Name1 = reader.GetString(33);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5MP_GPRAFID_1008 Invoke(string ConnectionString,P_L5MP_GPRAFID_1008 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MP_GPRAFID_1008 Invoke(DbConnection Connection,P_L5MP_GPRAFID_1008 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MP_GPRAFID_1008 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MP_GPRAFID_1008 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MP_GPRAFID_1008 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MP_GPRAFID_1008 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MP_GPRAFID_1008 functionReturn = new FR_L5MP_GPRAFID_1008();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5MP_GPRAFID_1008 : FR_Base
	{
		public L5MP_GPRAFID_1008 Result	{ get; set; }

		public FR_L5MP_GPRAFID_1008() : base() {}

		public FR_L5MP_GPRAFID_1008(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5MP_GPRAFID_1008 for attribute P_L5MP_GPRAFID_1008
		[DataContract]
		public class P_L5MP_GPRAFID_1008 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 

		}
		#endregion
		#region SClass L5MP_GPRAFID_1008 for attribute L5MP_GPRAFID_1008
		[DataContract]
		public class L5MP_GPRAFID_1008 
		{
			//Standard type parameters
			[DataMember]
			public Dict AffinityStatus_Name { get; set; } 
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public String Contact_EmergencyPhoneNumber { get; set; } 
			[DataMember]
			public Guid HEC_PublicHealthcare_PhysitianAssociationID { get; set; } 
			[DataMember]
			public String HealthAssociation_Name { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public Guid Practice_CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfoID { get; set; } 
			[DataMember]
			public Guid Contact_UCD_RefID { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfo_TypeID { get; set; } 
			[DataMember]
			public Dict CompanyType_Name { get; set; } 
			[DataMember]
			public Guid Contact_CMN_UniversalContactDetailID { get; set; } 
			[DataMember]
			public String Contact_Email { get; set; } 
			[DataMember]
			public String Contact_Website_URL { get; set; } 
			[DataMember]
			public Guid Shipping_CMN_UniversalContactDetailID { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfo_AddressID { get; set; } 
			[DataMember]
			public Guid WeeklySurgeryHours_Template_RefID { get; set; } 
			[DataMember]
			public Guid ContactPerson_RefID { get; set; } 
			[DataMember]
			public Guid WeeklyOfficeHours_Template_RefID { get; set; } 
			[DataMember]
			public String ContactPersonName { get; set; } 
			[DataMember]
			public String ConsultingHours_FormattedOfficeHours { get; set; } 
			[DataMember]
			public String WorkingHours_FormattedOfficeHours { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_CustomerID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_AffinityStatusID { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Region_Name { get; set; } 
			[DataMember]
			public String Street_Name1 { get; set; } 
			[DataMember]
			public String Street_Number1 { get; set; } 
			[DataMember]
			public String ZIP1 { get; set; } 
			[DataMember]
			public String Town1 { get; set; } 
			[DataMember]
			public String Region_Name1 { get; set; } 

		}
		#endregion

	#endregion
}
