/* 
 * Generated on 7/5/2013 1:56:03 PM
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

namespace CL6_BBV_Prescription.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BBV_GetTransaction_for_TransactionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BBV_GetTransaction_for_TransactionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6TS_GTfT_1345 Execute(DbConnection Connection,DbTransaction Transaction,P_L6TS_GTfT_1345 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6TS_GTfT_1345();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_BBV_Prescription.Atomic.Retrieval.SQL.cls_Get_BBV_GetTransaction_for_TransactionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TransactionID", Parameter.TransactionID);


			List<L6TS_GTfT_1345_raw> results = new List<L6TS_GTfT_1345_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_Prescription_TransactionID","PrescriptionTransaction_InternalNubmer","PrescriptionTransaction_IsComplete","PrescriptionTransaction_RequestedDateOfDeliveryFrom","PrescriptionTransaction_RequestedDateOfDeliveryTo","PrescriptionTransaction_CreatedByBusinessParticpant_RefID","PrescriptionTransaction_Comment","PrescriptionTransaction_Patient_RefID","PerscriptionTransaction_DeliveryAddress_RefID","PrescriptionTransaction_UsePatientAddress","PrescriptionTransaction_UseReceiptAddress","PrescriptionTransaction_UseParticipationPolicyAddress","Creation_Timestamp","Street_Name","Street_Number","City_PostalCode","Province_Name","City_Name","Driver_FirstName","Driver_LastName","Driver_CompanyName","Patient_FristName","Patient_LastName","Patient_InsuranceNumber","Salutation_General","HEC_Patient_Prescription_HeaderID","DOC_DocumentRevisionID","File_ServerLocation" });
				while(reader.Read())
				{
					L6TS_GTfT_1345_raw resultItem = new L6TS_GTfT_1345_raw();
					//0:Parameter HEC_Patient_Prescription_TransactionID of type Guid
					resultItem.HEC_Patient_Prescription_TransactionID = reader.GetGuid(0);
					//1:Parameter PrescriptionTransaction_InternalNubmer of type String
					resultItem.PrescriptionTransaction_InternalNubmer = reader.GetString(1);
					//2:Parameter PrescriptionTransaction_IsComplete of type Boolean
					resultItem.PrescriptionTransaction_IsComplete = reader.GetBoolean(2);
					//3:Parameter PrescriptionTransaction_RequestedDateOfDeliveryFrom of type DateTime
					resultItem.PrescriptionTransaction_RequestedDateOfDeliveryFrom = reader.GetDate(3);
					//4:Parameter PrescriptionTransaction_RequestedDateOfDeliveryTo of type DateTime
					resultItem.PrescriptionTransaction_RequestedDateOfDeliveryTo = reader.GetDate(4);
					//5:Parameter PrescriptionTransaction_CreatedByBusinessParticpant_RefID of type Guid
					resultItem.PrescriptionTransaction_CreatedByBusinessParticpant_RefID = reader.GetGuid(5);
					//6:Parameter PrescriptionTransaction_Comment of type String
					resultItem.PrescriptionTransaction_Comment = reader.GetString(6);
					//7:Parameter PrescriptionTransaction_Patient_RefID of type Guid
					resultItem.PrescriptionTransaction_Patient_RefID = reader.GetGuid(7);
					//8:Parameter PerscriptionTransaction_DeliveryAddress_RefID of type Guid
					resultItem.PerscriptionTransaction_DeliveryAddress_RefID = reader.GetGuid(8);
					//9:Parameter PrescriptionTransaction_UsePatientAddress of type Boolean
					resultItem.PrescriptionTransaction_UsePatientAddress = reader.GetBoolean(9);
					//10:Parameter PrescriptionTransaction_UseReceiptAddress of type Boolean
					resultItem.PrescriptionTransaction_UseReceiptAddress = reader.GetBoolean(10);
					//11:Parameter PrescriptionTransaction_UseParticipationPolicyAddress of type Boolean
					resultItem.PrescriptionTransaction_UseParticipationPolicyAddress = reader.GetBoolean(11);
					//12:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(12);
					//13:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(13);
					//14:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(14);
					//15:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(15);
					//16:Parameter Province_Name of type String
					resultItem.Province_Name = reader.GetString(16);
					//17:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(17);
					//18:Parameter Driver_FirstName of type String
					resultItem.Driver_FirstName = reader.GetString(18);
					//19:Parameter Driver_LastName of type String
					resultItem.Driver_LastName = reader.GetString(19);
					//20:Parameter Driver_CompanyName of type String
					resultItem.Driver_CompanyName = reader.GetString(20);
					//21:Parameter Patient_FristName of type String
					resultItem.Patient_FristName = reader.GetString(21);
					//22:Parameter Patient_LastName of type String
					resultItem.Patient_LastName = reader.GetString(22);
					//23:Parameter Patient_InsuranceNumber of type String
					resultItem.Patient_InsuranceNumber = reader.GetString(23);
					//24:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(24);
					//25:Parameter HEC_Patient_Prescription_HeaderID of type Guid
					resultItem.HEC_Patient_Prescription_HeaderID = reader.GetGuid(25);
					//26:Parameter DOC_DocumentRevisionID of type Guid
					resultItem.DOC_DocumentRevisionID = reader.GetGuid(26);
					//27:Parameter File_ServerLocation of type String
					resultItem.File_ServerLocation = reader.GetString(27);

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

			returnStatus.Result = L6TS_GTfT_1345_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6TS_GTfT_1345 Invoke(string ConnectionString,P_L6TS_GTfT_1345 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TS_GTfT_1345 Invoke(DbConnection Connection,P_L6TS_GTfT_1345 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TS_GTfT_1345 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TS_GTfT_1345 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TS_GTfT_1345 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TS_GTfT_1345 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TS_GTfT_1345 functionReturn = new FR_L6TS_GTfT_1345();
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

	#region Raw Grouping Class
	[Serializable]
	public class L6TS_GTfT_1345_raw 
	{
		public Guid HEC_Patient_Prescription_TransactionID; 
		public String PrescriptionTransaction_InternalNubmer; 
		public Boolean PrescriptionTransaction_IsComplete; 
		public DateTime PrescriptionTransaction_RequestedDateOfDeliveryFrom; 
		public DateTime PrescriptionTransaction_RequestedDateOfDeliveryTo; 
		public Guid PrescriptionTransaction_CreatedByBusinessParticpant_RefID; 
		public String PrescriptionTransaction_Comment; 
		public Guid PrescriptionTransaction_Patient_RefID; 
		public Guid PerscriptionTransaction_DeliveryAddress_RefID; 
		public Boolean PrescriptionTransaction_UsePatientAddress; 
		public Boolean PrescriptionTransaction_UseReceiptAddress; 
		public Boolean PrescriptionTransaction_UseParticipationPolicyAddress; 
		public DateTime Creation_Timestamp; 
		public String Street_Name; 
		public String Street_Number; 
		public String City_PostalCode; 
		public String Province_Name; 
		public String City_Name; 
		public String Driver_FirstName; 
		public String Driver_LastName; 
		public String Driver_CompanyName; 
		public String Patient_FristName; 
		public String Patient_LastName; 
		public String Patient_InsuranceNumber; 
		public String Salutation_General; 
		public Guid HEC_Patient_Prescription_HeaderID; 
		public Guid DOC_DocumentRevisionID; 
		public String File_ServerLocation; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6TS_GTfT_1345[] Convert(List<L6TS_GTfT_1345_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6TS_GTfT_1345 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_Prescription_TransactionID)).ToArray()
	group el_L6TS_GTfT_1345 by new 
	{ 
		el_L6TS_GTfT_1345.HEC_Patient_Prescription_TransactionID,

	}
	into gfunct_L6TS_GTfT_1345
	select new L6TS_GTfT_1345
	{     
		HEC_Patient_Prescription_TransactionID = gfunct_L6TS_GTfT_1345.Key.HEC_Patient_Prescription_TransactionID ,
		PrescriptionTransaction_InternalNubmer = gfunct_L6TS_GTfT_1345.FirstOrDefault().PrescriptionTransaction_InternalNubmer ,
		PrescriptionTransaction_IsComplete = gfunct_L6TS_GTfT_1345.FirstOrDefault().PrescriptionTransaction_IsComplete ,
		PrescriptionTransaction_RequestedDateOfDeliveryFrom = gfunct_L6TS_GTfT_1345.FirstOrDefault().PrescriptionTransaction_RequestedDateOfDeliveryFrom ,
		PrescriptionTransaction_RequestedDateOfDeliveryTo = gfunct_L6TS_GTfT_1345.FirstOrDefault().PrescriptionTransaction_RequestedDateOfDeliveryTo ,
		PrescriptionTransaction_CreatedByBusinessParticpant_RefID = gfunct_L6TS_GTfT_1345.FirstOrDefault().PrescriptionTransaction_CreatedByBusinessParticpant_RefID ,
		PrescriptionTransaction_Comment = gfunct_L6TS_GTfT_1345.FirstOrDefault().PrescriptionTransaction_Comment ,
		PrescriptionTransaction_Patient_RefID = gfunct_L6TS_GTfT_1345.FirstOrDefault().PrescriptionTransaction_Patient_RefID ,
		PerscriptionTransaction_DeliveryAddress_RefID = gfunct_L6TS_GTfT_1345.FirstOrDefault().PerscriptionTransaction_DeliveryAddress_RefID ,
		PrescriptionTransaction_UsePatientAddress = gfunct_L6TS_GTfT_1345.FirstOrDefault().PrescriptionTransaction_UsePatientAddress ,
		PrescriptionTransaction_UseReceiptAddress = gfunct_L6TS_GTfT_1345.FirstOrDefault().PrescriptionTransaction_UseReceiptAddress ,
		PrescriptionTransaction_UseParticipationPolicyAddress = gfunct_L6TS_GTfT_1345.FirstOrDefault().PrescriptionTransaction_UseParticipationPolicyAddress ,
		Creation_Timestamp = gfunct_L6TS_GTfT_1345.FirstOrDefault().Creation_Timestamp ,
		Street_Name = gfunct_L6TS_GTfT_1345.FirstOrDefault().Street_Name ,
		Street_Number = gfunct_L6TS_GTfT_1345.FirstOrDefault().Street_Number ,
		City_PostalCode = gfunct_L6TS_GTfT_1345.FirstOrDefault().City_PostalCode ,
		Province_Name = gfunct_L6TS_GTfT_1345.FirstOrDefault().Province_Name ,
		City_Name = gfunct_L6TS_GTfT_1345.FirstOrDefault().City_Name ,
		Driver_FirstName = gfunct_L6TS_GTfT_1345.FirstOrDefault().Driver_FirstName ,
		Driver_LastName = gfunct_L6TS_GTfT_1345.FirstOrDefault().Driver_LastName ,
		Driver_CompanyName = gfunct_L6TS_GTfT_1345.FirstOrDefault().Driver_CompanyName ,
		Patient_FristName = gfunct_L6TS_GTfT_1345.FirstOrDefault().Patient_FristName ,
		Patient_LastName = gfunct_L6TS_GTfT_1345.FirstOrDefault().Patient_LastName ,
		Patient_InsuranceNumber = gfunct_L6TS_GTfT_1345.FirstOrDefault().Patient_InsuranceNumber ,
		Salutation_General = gfunct_L6TS_GTfT_1345.FirstOrDefault().Salutation_General ,

		Prescriptions = 
		(
			from el_Prescriptions in gfunct_L6TS_GTfT_1345.Where(element => !EqualsDefaultValue(element.HEC_Patient_Prescription_HeaderID)).ToArray()
			group el_Prescriptions by new 
			{ 
				el_Prescriptions.HEC_Patient_Prescription_HeaderID,

			}
			into gfunct_Prescriptions
			select new L6TS_GTfT_1345a
			{     
				HEC_Patient_Prescription_HeaderID = gfunct_Prescriptions.Key.HEC_Patient_Prescription_HeaderID ,
				DOC_DocumentRevisionID = gfunct_Prescriptions.FirstOrDefault().DOC_DocumentRevisionID ,
				File_ServerLocation = gfunct_Prescriptions.FirstOrDefault().File_ServerLocation ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6TS_GTfT_1345 : FR_Base
	{
		public L6TS_GTfT_1345 Result	{ get; set; }

		public FR_L6TS_GTfT_1345() : base() {}

		public FR_L6TS_GTfT_1345(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6TS_GTfT_1345 for attribute P_L6TS_GTfT_1345
		[DataContract]
		public class P_L6TS_GTfT_1345 
		{
			//Standard type parameters
			[DataMember]
			public Guid TransactionID { get; set; } 

		}
		#endregion
		#region SClass L6TS_GTfT_1345 for attribute L6TS_GTfT_1345
		[DataContract]
		public class L6TS_GTfT_1345 
		{
			[DataMember]
			public L6TS_GTfT_1345a[] Prescriptions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_Prescription_TransactionID { get; set; } 
			[DataMember]
			public String PrescriptionTransaction_InternalNubmer { get; set; } 
			[DataMember]
			public Boolean PrescriptionTransaction_IsComplete { get; set; } 
			[DataMember]
			public DateTime PrescriptionTransaction_RequestedDateOfDeliveryFrom { get; set; } 
			[DataMember]
			public DateTime PrescriptionTransaction_RequestedDateOfDeliveryTo { get; set; } 
			[DataMember]
			public Guid PrescriptionTransaction_CreatedByBusinessParticpant_RefID { get; set; } 
			[DataMember]
			public String PrescriptionTransaction_Comment { get; set; } 
			[DataMember]
			public Guid PrescriptionTransaction_Patient_RefID { get; set; } 
			[DataMember]
			public Guid PerscriptionTransaction_DeliveryAddress_RefID { get; set; } 
			[DataMember]
			public Boolean PrescriptionTransaction_UsePatientAddress { get; set; } 
			[DataMember]
			public Boolean PrescriptionTransaction_UseReceiptAddress { get; set; } 
			[DataMember]
			public Boolean PrescriptionTransaction_UseParticipationPolicyAddress { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Province_Name { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String Driver_FirstName { get; set; } 
			[DataMember]
			public String Driver_LastName { get; set; } 
			[DataMember]
			public String Driver_CompanyName { get; set; } 
			[DataMember]
			public String Patient_FristName { get; set; } 
			[DataMember]
			public String Patient_LastName { get; set; } 
			[DataMember]
			public String Patient_InsuranceNumber { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 

		}
		#endregion
		#region SClass L6TS_GTfT_1345a for attribute Prescriptions
		[DataContract]
		public class L6TS_GTfT_1345a 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_Prescription_HeaderID { get; set; } 
			[DataMember]
			public Guid DOC_DocumentRevisionID { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 

		}
		#endregion

	#endregion
}
