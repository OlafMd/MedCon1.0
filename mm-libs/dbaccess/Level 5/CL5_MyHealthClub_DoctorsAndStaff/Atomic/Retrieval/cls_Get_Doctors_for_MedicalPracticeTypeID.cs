/* 
 * Generated on 3/13/2015 12:24:10
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

namespace CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Doctors_for_MedicalPracticeTypeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctors_for_MedicalPracticeTypeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DO_GDfMPTID_0848_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_GDfMPTID_0848 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DO_GDfMPTID_0848_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval.SQL.cls_Get_Doctors_for_MedicalPracticeTypeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"MedicalPracticeTypeID", Parameter.MedicalPracticeTypeID);



			List<L5DO_GDfMPTID_0848> results = new List<L5DO_GDfMPTID_0848>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "doctor","doctor_id","HEC_MedicalPractiseID" });
				while(reader.Read())
				{
					L5DO_GDfMPTID_0848 resultItem = new L5DO_GDfMPTID_0848();
					//0:Parameter doctor of type String
					resultItem.doctor = reader.GetString(0);
					//1:Parameter doctor_id of type Guid
					resultItem.doctor_id = reader.GetGuid(1);
					//2:Parameter HEC_MedicalPractiseID of type Guid
					resultItem.HEC_MedicalPractiseID = reader.GetGuid(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctors_for_MedicalPracticeTypeID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DO_GDfMPTID_0848_Array Invoke(string ConnectionString,P_L5DO_GDfMPTID_0848 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DO_GDfMPTID_0848_Array Invoke(DbConnection Connection,P_L5DO_GDfMPTID_0848 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DO_GDfMPTID_0848_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_GDfMPTID_0848 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DO_GDfMPTID_0848_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_GDfMPTID_0848 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DO_GDfMPTID_0848_Array functionReturn = new FR_L5DO_GDfMPTID_0848_Array();
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

				throw new Exception("Exception occured in method cls_Get_Doctors_for_MedicalPracticeTypeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DO_GDfMPTID_0848_Array : FR_Base
	{
		public L5DO_GDfMPTID_0848[] Result	{ get; set; } 
		public FR_L5DO_GDfMPTID_0848_Array() : base() {}

		public FR_L5DO_GDfMPTID_0848_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DO_GDfMPTID_0848 for attribute P_L5DO_GDfMPTID_0848
		[DataContract]
		public class P_L5DO_GDfMPTID_0848 
		{
			//Standard type parameters
			[DataMember]
			public Guid MedicalPracticeTypeID { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDfMPTID_0848 for attribute L5DO_GDfMPTID_0848
		[DataContract]
		public class L5DO_GDfMPTID_0848 
		{
			//Standard type parameters
			[DataMember]
			public String doctor { get; set; } 
			[DataMember]
			public Guid doctor_id { get; set; } 
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DO_GDfMPTID_0848_Array cls_Get_Doctors_for_MedicalPracticeTypeID(,P_L5DO_GDfMPTID_0848 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DO_GDfMPTID_0848_Array invocationResult = cls_Get_Doctors_for_MedicalPracticeTypeID.Invoke(connectionString,P_L5DO_GDfMPTID_0848 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval.P_L5DO_GDfMPTID_0848();
parameter.MedicalPracticeTypeID = ...;

*/
