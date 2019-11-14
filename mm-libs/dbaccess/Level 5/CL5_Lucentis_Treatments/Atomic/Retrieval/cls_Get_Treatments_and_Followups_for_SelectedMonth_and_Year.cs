/* 
 * Generated on 3/27/2014 3:30:30 PM
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

namespace CL5_Lucentis_Treatments.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Treatments_and_Followups_for_SelectedMonth_and_Year.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Treatments_and_Followups_for_SelectedMonth_and_Year
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TR_GTaFfSMaY_1619_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5TR_GTaFfSMaY_1619 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TR_GTaFfSMaY_1619_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Treatments.Atomic.Retrieval.SQL.cls_Get_Treatments_and_Followups_for_SelectedMonth_and_Year.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SelectedMounth", Parameter.SelectedMounth);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SelectedYear", Parameter.SelectedYear);



			List<L5TR_GTaFfSMaY_1619> results = new List<L5TR_GTaFfSMaY_1619>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_TreatmentID","IsTreatmentFollowup","IfTreatmentPerformed_Date","IfTreatmentFollowup_FromTreatment_RefID" });
				while(reader.Read())
				{
					L5TR_GTaFfSMaY_1619 resultItem = new L5TR_GTaFfSMaY_1619();
					//0:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(0);
					//1:Parameter IsTreatmentFollowup of type bool
					resultItem.IsTreatmentFollowup = reader.GetBoolean(1);
					//2:Parameter IfTreatmentPerformed_Date of type DateTime
					resultItem.IfTreatmentPerformed_Date = reader.GetDate(2);
					//3:Parameter IfTreatmentFollowup_FromTreatment_RefID of type Guid
					resultItem.IfTreatmentFollowup_FromTreatment_RefID = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Treatments_and_Followups_for_SelectedMonth_and_Year",ex);
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
		public static FR_L5TR_GTaFfSMaY_1619_Array Invoke(string ConnectionString,P_L5TR_GTaFfSMaY_1619 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TR_GTaFfSMaY_1619_Array Invoke(DbConnection Connection,P_L5TR_GTaFfSMaY_1619 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TR_GTaFfSMaY_1619_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TR_GTaFfSMaY_1619 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TR_GTaFfSMaY_1619_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TR_GTaFfSMaY_1619 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TR_GTaFfSMaY_1619_Array functionReturn = new FR_L5TR_GTaFfSMaY_1619_Array();
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

				throw new Exception("Exception occured in method cls_Get_Treatments_and_Followups_for_SelectedMonth_and_Year",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5TR_GTaFfSMaY_1619_Array : FR_Base
	{
		public L5TR_GTaFfSMaY_1619[] Result	{ get; set; } 
		public FR_L5TR_GTaFfSMaY_1619_Array() : base() {}

		public FR_L5TR_GTaFfSMaY_1619_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5TR_GTaFfSMaY_1619 for attribute P_L5TR_GTaFfSMaY_1619
		[DataContract]
		public class P_L5TR_GTaFfSMaY_1619 
		{
			//Standard type parameters
			[DataMember]
			public int SelectedMounth { get; set; } 
			[DataMember]
			public int SelectedYear { get; set; } 

		}
		#endregion
		#region SClass L5TR_GTaFfSMaY_1619 for attribute L5TR_GTaFfSMaY_1619
		[DataContract]
		public class L5TR_GTaFfSMaY_1619 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public bool IsTreatmentFollowup { get; set; } 
			[DataMember]
			public DateTime IfTreatmentPerformed_Date { get; set; } 
			[DataMember]
			public Guid IfTreatmentFollowup_FromTreatment_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TR_GTaFfSMaY_1619_Array cls_Get_Treatments_and_Followups_for_SelectedMonth_and_Year(,P_L5TR_GTaFfSMaY_1619 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TR_GTaFfSMaY_1619_Array invocationResult = cls_Get_Treatments_and_Followups_for_SelectedMonth_and_Year.Invoke(connectionString,P_L5TR_GTaFfSMaY_1619 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Treatments.Atomic.Retrieval.P_L5TR_GTaFfSMaY_1619();
parameter.SelectedMounth = ...;
parameter.SelectedYear = ...;

*/
