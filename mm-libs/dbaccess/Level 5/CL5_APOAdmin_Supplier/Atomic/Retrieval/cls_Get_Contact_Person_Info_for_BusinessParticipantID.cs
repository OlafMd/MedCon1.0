/* 
 * Generated on 6/11/2013 02:18:31
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
using System.Runtime.Serialization;

namespace CL5_APOAdmin_Supplier.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Contact_Person_Info_for_BusinessParticipantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Contact_Person_Info_for_BusinessParticipantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AAS_GCPIfBP_1607_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AAS_GCPIfBP_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AAS_GCPIfBP_1607_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_Supplier.Atomic.Retrieval.SQL.cls_Get_Contact_Person_Info_for_BusinessParticipantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BusinessParticipantID", Parameter.BusinessParticipantID);



			List<L5AAS_GCPIfBP_1607_raw> results = new List<L5AAS_GCPIfBP_1607_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_BusinessParticipantID","IsDeleted","AssociatedBusinessParticipant_RefID","AssociatedParticipant_FunctionName","CMN_PER_PersonInfoID","FirstName","LastName","CMN_AddressID","Street_Name","Street_Number","City_Name","City_PostalCode","Country_ISOCode","CareOf","CMN_PER_CommunicationContact_TypeID","CommunicationContact_Type","cmn_per_communicationcontacts_Content" });
				while(reader.Read())
				{
					L5AAS_GCPIfBP_1607_raw resultItem = new L5AAS_GCPIfBP_1607_raw();
					//0:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(0);
					//1:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(1);
					//2:Parameter AssociatedBusinessParticipant_RefID of type Guid
					resultItem.AssociatedBusinessParticipant_RefID = reader.GetGuid(2);
					//3:Parameter AssociatedParticipant_FunctionName of type String
					resultItem.AssociatedParticipant_FunctionName = reader.GetString(3);
					//4:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(4);
					//5:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(5);
					//6:Parameter LastName of type String
					resultItem.LastName = reader.GetString(6);
					//7:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(7);
					//8:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(8);
					//9:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(9);
					//10:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(10);
					//11:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(11);
					//12:Parameter Country_ISOCode of type String
					resultItem.Country_ISOCode = reader.GetString(12);
					//13:Parameter CareOf of type String
					resultItem.CareOf = reader.GetString(13);
					//14:Parameter CMN_PER_CommunicationContact_TypeID of type Guid
					resultItem.CMN_PER_CommunicationContact_TypeID = reader.GetGuid(14);
					//15:Parameter CommunicationContact_Type of type String
					resultItem.CommunicationContact_Type = reader.GetString(15);
					//16:Parameter cmn_per_communicationcontacts_Content of type String
					resultItem.cmn_per_communicationcontacts_Content = reader.GetString(16);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Contact_Person_Info_for_BusinessParticipantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AAS_GCPIfBP_1607_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AAS_GCPIfBP_1607_Array Invoke(string ConnectionString,P_L5AAS_GCPIfBP_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AAS_GCPIfBP_1607_Array Invoke(DbConnection Connection,P_L5AAS_GCPIfBP_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AAS_GCPIfBP_1607_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AAS_GCPIfBP_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AAS_GCPIfBP_1607_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AAS_GCPIfBP_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AAS_GCPIfBP_1607_Array functionReturn = new FR_L5AAS_GCPIfBP_1607_Array();
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

				throw new Exception("Exception occured in method cls_Get_Contact_Person_Info_for_BusinessParticipantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AAS_GCPIfBP_1607_raw 
	{
		public Guid CMN_BPT_BusinessParticipantID; 
		public bool IsDeleted; 
		public Guid AssociatedBusinessParticipant_RefID; 
		public String AssociatedParticipant_FunctionName; 
		public Guid CMN_PER_PersonInfoID; 
		public String FirstName; 
		public String LastName; 
		public Guid CMN_AddressID; 
		public String Street_Name; 
		public String Street_Number; 
		public String City_Name; 
		public String City_PostalCode; 
		public String Country_ISOCode; 
		public String CareOf; 
		public Guid CMN_PER_CommunicationContact_TypeID; 
		public String CommunicationContact_Type; 
		public String cmn_per_communicationcontacts_Content; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AAS_GCPIfBP_1607[] Convert(List<L5AAS_GCPIfBP_1607_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AAS_GCPIfBP_1607 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID)).ToArray()
	group el_L5AAS_GCPIfBP_1607 by new 
	{ 
		el_L5AAS_GCPIfBP_1607.CMN_BPT_BusinessParticipantID,

	}
	into gfunct_L5AAS_GCPIfBP_1607
	select new L5AAS_GCPIfBP_1607
	{     
		CMN_BPT_BusinessParticipantID = gfunct_L5AAS_GCPIfBP_1607.Key.CMN_BPT_BusinessParticipantID ,
		IsDeleted = gfunct_L5AAS_GCPIfBP_1607.FirstOrDefault().IsDeleted ,
		AssociatedBusinessParticipant_RefID = gfunct_L5AAS_GCPIfBP_1607.FirstOrDefault().AssociatedBusinessParticipant_RefID ,
		AssociatedParticipant_FunctionName = gfunct_L5AAS_GCPIfBP_1607.FirstOrDefault().AssociatedParticipant_FunctionName ,
		CMN_PER_PersonInfoID = gfunct_L5AAS_GCPIfBP_1607.FirstOrDefault().CMN_PER_PersonInfoID ,
		FirstName = gfunct_L5AAS_GCPIfBP_1607.FirstOrDefault().FirstName ,
		LastName = gfunct_L5AAS_GCPIfBP_1607.FirstOrDefault().LastName ,
		CMN_AddressID = gfunct_L5AAS_GCPIfBP_1607.FirstOrDefault().CMN_AddressID ,
		Street_Name = gfunct_L5AAS_GCPIfBP_1607.FirstOrDefault().Street_Name ,
		Street_Number = gfunct_L5AAS_GCPIfBP_1607.FirstOrDefault().Street_Number ,
		City_Name = gfunct_L5AAS_GCPIfBP_1607.FirstOrDefault().City_Name ,
		City_PostalCode = gfunct_L5AAS_GCPIfBP_1607.FirstOrDefault().City_PostalCode ,
		Country_ISOCode = gfunct_L5AAS_GCPIfBP_1607.FirstOrDefault().Country_ISOCode ,
		CareOf = gfunct_L5AAS_GCPIfBP_1607.FirstOrDefault().CareOf ,

		ContactTypes = 
		(
			from el_ContactTypes in gfunct_L5AAS_GCPIfBP_1607.Where(element => !EqualsDefaultValue(element.CMN_PER_CommunicationContact_TypeID)).ToArray()
			group el_ContactTypes by new 
			{ 
				el_ContactTypes.CMN_PER_CommunicationContact_TypeID,

			}
			into gfunct_ContactTypes
			select new L5AAS_GCPIfBP_1607_ContactTypeContent
			{     
				CMN_PER_CommunicationContact_TypeID = gfunct_ContactTypes.Key.CMN_PER_CommunicationContact_TypeID ,
				CommunicationContact_Type = gfunct_ContactTypes.FirstOrDefault().CommunicationContact_Type ,
				cmn_per_communicationcontacts_Content = gfunct_ContactTypes.FirstOrDefault().cmn_per_communicationcontacts_Content ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AAS_GCPIfBP_1607_Array : FR_Base
	{
		public L5AAS_GCPIfBP_1607[] Result	{ get; set; } 
		public FR_L5AAS_GCPIfBP_1607_Array() : base() {}

		public FR_L5AAS_GCPIfBP_1607_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AAS_GCPIfBP_1607 for attribute P_L5AAS_GCPIfBP_1607
		[DataContract]
		public class P_L5AAS_GCPIfBP_1607 
		{
			//Standard type parameters
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 

		}
		#endregion
		#region SClass L5AAS_GCPIfBP_1607 for attribute L5AAS_GCPIfBP_1607
		[DataContract]
		public class L5AAS_GCPIfBP_1607 
		{
			[DataMember]
			public L5AAS_GCPIfBP_1607_ContactTypeContent[] ContactTypes { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid AssociatedBusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String AssociatedParticipant_FunctionName { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 
			[DataMember]
			public String CareOf { get; set; } 

		}
		#endregion
		#region SClass L5AAS_GCPIfBP_1607_ContactTypeContent for attribute ContactTypes
		[DataContract]
		public class L5AAS_GCPIfBP_1607_ContactTypeContent 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PER_CommunicationContact_TypeID { get; set; } 
			[DataMember]
			public String CommunicationContact_Type { get; set; } 
			[DataMember]
			public String cmn_per_communicationcontacts_Content { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AAS_GCPIfBP_1607_Array cls_Get_Contact_Person_Info_for_BusinessParticipantID(,P_L5AAS_GCPIfBP_1607 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AAS_GCPIfBP_1607_Array invocationResult = cls_Get_Contact_Person_Info_for_BusinessParticipantID.Invoke(connectionString,P_L5AAS_GCPIfBP_1607 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Supplier.Atomic.Retrieval.P_L5AAS_GCPIfBP_1607();
parameter.BusinessParticipantID = ...;

*/
