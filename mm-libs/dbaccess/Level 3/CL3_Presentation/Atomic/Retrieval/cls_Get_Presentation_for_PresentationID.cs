/* 
 * Generated on 8/29/2014 9:55:46 AM
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

namespace CL3_Presentation.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Presentation_for_PresentationID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Presentation_for_PresentationID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_GPfPID_0941 Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_GPfPID_0941 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PR_GPfPID_0941();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Presentation.Atomic.Retrieval.SQL.cls_Get_Presentation_for_PresentationID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PresentationID", Parameter.PresentationID);



			List<L3PR_GPfPID_0941> results = new List<L3PR_GPfPID_0941>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_CAL_EVT_PresentationID","PresentationLocation","MaximumNumberOfParticipants","PresentationTitle_DictID","PresentationDescription_DictID","StartTime","IsFeaturedEvent","PresenterDisplayName" });
				while(reader.Read())
				{
					L3PR_GPfPID_0941 resultItem = new L3PR_GPfPID_0941();
					//0:Parameter CMN_CAL_EVT_PresentationID of type Guid
					resultItem.CMN_CAL_EVT_PresentationID = reader.GetGuid(0);
					//1:Parameter PresentationLocation of type String
					resultItem.PresentationLocation = reader.GetString(1);
					//2:Parameter MaximumNumberOfParticipants of type int
					resultItem.MaximumNumberOfParticipants = reader.GetInteger(2);
					//3:Parameter PresentationTitle of type Dict
					resultItem.PresentationTitle = reader.GetDictionary(3);
					resultItem.PresentationTitle.SourceTable = "cmn_cal_evt_presentations";
					loader.Append(resultItem.PresentationTitle);
					//4:Parameter PresentationDescription of type Dict
					resultItem.PresentationDescription = reader.GetDictionary(4);
					resultItem.PresentationDescription.SourceTable = "cmn_cal_evt_presentations";
					loader.Append(resultItem.PresentationDescription);
					//5:Parameter StartTime of type DateTime
					resultItem.StartTime = reader.GetDate(5);
					//6:Parameter IsFeaturedEvent of type bool
					resultItem.IsFeaturedEvent = reader.GetBoolean(6);
					//7:Parameter PresenterDisplayName of type String
					resultItem.PresenterDisplayName = reader.GetString(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Presentation_for_PresentationID",ex);
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
		public static FR_L3PR_GPfPID_0941 Invoke(string ConnectionString,P_L3PR_GPfPID_0941 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_GPfPID_0941 Invoke(DbConnection Connection,P_L3PR_GPfPID_0941 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_GPfPID_0941 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_GPfPID_0941 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_GPfPID_0941 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_GPfPID_0941 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_GPfPID_0941 functionReturn = new FR_L3PR_GPfPID_0941();
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

				throw new Exception("Exception occured in method cls_Get_Presentation_for_PresentationID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_GPfPID_0941 : FR_Base
	{
		public L3PR_GPfPID_0941 Result	{ get; set; }

		public FR_L3PR_GPfPID_0941() : base() {}

		public FR_L3PR_GPfPID_0941(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_GPfPID_0941 for attribute P_L3PR_GPfPID_0941
		[DataContract]
		public class P_L3PR_GPfPID_0941 
		{
			//Standard type parameters
			[DataMember]
			public Guid PresentationID { get; set; } 

		}
		#endregion
		#region SClass L3PR_GPfPID_0941 for attribute L3PR_GPfPID_0941
		[DataContract]
		public class L3PR_GPfPID_0941 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_CAL_EVT_PresentationID { get; set; } 
			[DataMember]
			public String PresentationLocation { get; set; } 
			[DataMember]
			public int MaximumNumberOfParticipants { get; set; } 
			[DataMember]
			public Dict PresentationTitle { get; set; } 
			[DataMember]
			public Dict PresentationDescription { get; set; } 
			[DataMember]
			public DateTime StartTime { get; set; } 
			[DataMember]
			public bool IsFeaturedEvent { get; set; } 
			[DataMember]
			public String PresenterDisplayName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_GPfPID_0941 cls_Get_Presentation_for_PresentationID(,P_L3PR_GPfPID_0941 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_GPfPID_0941 invocationResult = cls_Get_Presentation_for_PresentationID.Invoke(connectionString,P_L3PR_GPfPID_0941 Parameter,securityTicket);
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
var parameter = new CL3_Presentation.Atomic.Retrieval.P_L3PR_GPfPID_0941();
parameter.PresentationID = ...;

*/
