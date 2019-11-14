/* 
 * Generated on 9/3/2013 11:28:29 AM
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

namespace CL5_OphthalDoctors.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_SearchDoctors_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_SearchDoctors_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OD_GSDOCFT_1718_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5OD_GSDOCFT_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OD_GSDOCFT_1718_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_OphthalDoctors.Atomic.Retrieval.SQL.cls_Get_SearchDoctors_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ContactTypeID", Parameter.ContactTypeID);



			List<L5OD_GSDOCFT_1718_raw> results = new List<L5OD_GSDOCFT_1718_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DoctorID","HEC_MedicalPractiseID","Practice_AssociatedBusinessParticipant_RefID","CMN_BPT_BusinessParticipantID","CMN_PER_PersonInfoID","CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID","FirstName","PrimaryEmail","LastName","Title","Salutation_General","Salutation_Letter","AssociatedParticipant_FunctionName","ContactContent" });
				while(reader.Read())
				{
					L5OD_GSDOCFT_1718_raw resultItem = new L5OD_GSDOCFT_1718_raw();
					//0:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(0);
					//1:Parameter HEC_MedicalPractiseID of type Guid
					resultItem.HEC_MedicalPractiseID = reader.GetGuid(1);
					//2:Parameter Practice_AssociatedBusinessParticipant_RefID of type Guid
					resultItem.Practice_AssociatedBusinessParticipant_RefID = reader.GetGuid(2);
					//3:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(3);
					//4:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(4);
					//5:Parameter CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID = reader.GetGuid(5);
					//6:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(6);
					//7:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(7);
					//8:Parameter LastName of type String
					resultItem.LastName = reader.GetString(8);
					//9:Parameter Title of type String
					resultItem.Title = reader.GetString(9);
					//10:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(10);
					//11:Parameter Salutation_Letter of type String
					resultItem.Salutation_Letter = reader.GetString(11);
					//12:Parameter AssociatedParticipant_FunctionName of type String
					resultItem.AssociatedParticipant_FunctionName = reader.GetString(12);
					//13:Parameter ContactContent of type String
					resultItem.ContactContent = reader.GetString(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_SearchDoctors_For_Tenant",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5OD_GSDOCFT_1718_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OD_GSDOCFT_1718_Array Invoke(string ConnectionString,P_L5OD_GSDOCFT_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OD_GSDOCFT_1718_Array Invoke(DbConnection Connection,P_L5OD_GSDOCFT_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OD_GSDOCFT_1718_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OD_GSDOCFT_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OD_GSDOCFT_1718_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OD_GSDOCFT_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OD_GSDOCFT_1718_Array functionReturn = new FR_L5OD_GSDOCFT_1718_Array();
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

				throw new Exception("Exception occured in method cls_Get_SearchDoctors_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5OD_GSDOCFT_1718_raw 
	{
		public Guid HEC_DoctorID; 
		public Guid HEC_MedicalPractiseID; 
		public Guid Practice_AssociatedBusinessParticipant_RefID; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public Guid CMN_PER_PersonInfoID; 
		public Guid CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID; 
		public String FirstName; 
		public String PrimaryEmail; 
		public String LastName; 
		public String Title; 
		public String Salutation_General; 
		public String Salutation_Letter; 
		public String AssociatedParticipant_FunctionName; 
		public String ContactContent; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5OD_GSDOCFT_1718[] Convert(List<L5OD_GSDOCFT_1718_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5OD_GSDOCFT_1718 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID)).ToArray()
	group el_L5OD_GSDOCFT_1718 by new 
	{ 
		el_L5OD_GSDOCFT_1718.CMN_BPT_BusinessParticipantID,

	}
	into gfunct_L5OD_GSDOCFT_1718
	select new L5OD_GSDOCFT_1718
	{     
		HEC_DoctorID = gfunct_L5OD_GSDOCFT_1718.FirstOrDefault().HEC_DoctorID ,
		HEC_MedicalPractiseID = gfunct_L5OD_GSDOCFT_1718.FirstOrDefault().HEC_MedicalPractiseID ,
		Practice_AssociatedBusinessParticipant_RefID = gfunct_L5OD_GSDOCFT_1718.FirstOrDefault().Practice_AssociatedBusinessParticipant_RefID ,
		CMN_BPT_BusinessParticipantID = gfunct_L5OD_GSDOCFT_1718.Key.CMN_BPT_BusinessParticipantID ,
		CMN_PER_PersonInfoID = gfunct_L5OD_GSDOCFT_1718.FirstOrDefault().CMN_PER_PersonInfoID ,
		CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID = gfunct_L5OD_GSDOCFT_1718.FirstOrDefault().CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID ,
		FirstName = gfunct_L5OD_GSDOCFT_1718.FirstOrDefault().FirstName ,
		PrimaryEmail = gfunct_L5OD_GSDOCFT_1718.FirstOrDefault().PrimaryEmail ,
		LastName = gfunct_L5OD_GSDOCFT_1718.FirstOrDefault().LastName ,
		Title = gfunct_L5OD_GSDOCFT_1718.FirstOrDefault().Title ,
		Salutation_General = gfunct_L5OD_GSDOCFT_1718.FirstOrDefault().Salutation_General ,
		Salutation_Letter = gfunct_L5OD_GSDOCFT_1718.FirstOrDefault().Salutation_Letter ,
		AssociatedParticipant_FunctionName = gfunct_L5OD_GSDOCFT_1718.FirstOrDefault().AssociatedParticipant_FunctionName ,
		ContactContent = gfunct_L5OD_GSDOCFT_1718.FirstOrDefault().ContactContent ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5OD_GSDOCFT_1718_Array : FR_Base
	{
		public L5OD_GSDOCFT_1718[] Result	{ get; set; } 
		public FR_L5OD_GSDOCFT_1718_Array() : base() {}

		public FR_L5OD_GSDOCFT_1718_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OD_GSDOCFT_1718 for attribute P_L5OD_GSDOCFT_1718
		[DataContract]
		public class P_L5OD_GSDOCFT_1718 
		{
			//Standard type parameters
			[DataMember]
			public Guid ContactTypeID { get; set; } 

		}
		#endregion
		#region SClass L5OD_GSDOCFT_1718 for attribute L5OD_GSDOCFT_1718
		[DataContract]
		public class L5OD_GSDOCFT_1718 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public Guid Practice_AssociatedBusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public String Salutation_Letter { get; set; } 
			[DataMember]
			public String AssociatedParticipant_FunctionName { get; set; } 
			[DataMember]
			public String ContactContent { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OD_GSDOCFT_1718_Array cls_Get_SearchDoctors_For_Tenant(,P_L5OD_GSDOCFT_1718 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OD_GSDOCFT_1718_Array invocationResult = cls_Get_SearchDoctors_For_Tenant.Invoke(connectionString,P_L5OD_GSDOCFT_1718 Parameter,securityTicket);
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
var parameter = new CL5_OphthalDoctors.Atomic.Retrieval.P_L5OD_GSDOCFT_1718();
parameter.ContactTypeID = ...;

*/
