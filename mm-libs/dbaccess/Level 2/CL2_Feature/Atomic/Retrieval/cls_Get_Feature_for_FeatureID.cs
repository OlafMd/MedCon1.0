/* 
 * Generated on 10-Dec-14 2:17:03 PM
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

namespace CL2_Feature.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Feature_for_FeatureID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Feature_for_FeatureID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2FE_GFfFID_1402 Execute(DbConnection Connection,DbTransaction Transaction,P_L2FE_GFfFID_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2FE_GFfFID_1402();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Feature.Atomic.Retrieval.SQL.cls_Get_Feature_for_FeatureID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FeatureID", Parameter.FeatureID);



			List<L2FE_GFfFID_1402> results = new List<L2FE_GFfFID_1402>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_FeatureID","IdentificationNumber","Project_RefID","Name_DictID","Description_DictID","Feature_Deadline","Creation_Timestamp" });
				while(reader.Read())
				{
					L2FE_GFfFID_1402 resultItem = new L2FE_GFfFID_1402();
					//0:Parameter TMS_PRO_FeatureID of type Guid
					resultItem.TMS_PRO_FeatureID = reader.GetGuid(0);
					//1:Parameter IdentificationNumber of type String
					resultItem.IdentificationNumber = reader.GetString(1);
					//2:Parameter Project_RefID of type Guid
					resultItem.Project_RefID = reader.GetGuid(2);
					//3:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(3);
					resultItem.Name.SourceTable = "tms_pro_feature";
					loader.Append(resultItem.Name);
					//4:Parameter Description of type Dict
					resultItem.Description = reader.GetDictionary(4);
					resultItem.Description.SourceTable = "tms_pro_feature";
					loader.Append(resultItem.Description);
					//5:Parameter Feature_Deadline of type DateTime
					resultItem.Feature_Deadline = reader.GetDate(5);
					//6:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Feature_for_FeatureID",ex);
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
		public static FR_L2FE_GFfFID_1402 Invoke(string ConnectionString,P_L2FE_GFfFID_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2FE_GFfFID_1402 Invoke(DbConnection Connection,P_L2FE_GFfFID_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2FE_GFfFID_1402 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2FE_GFfFID_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2FE_GFfFID_1402 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2FE_GFfFID_1402 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2FE_GFfFID_1402 functionReturn = new FR_L2FE_GFfFID_1402();
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

				throw new Exception("Exception occured in method cls_Get_Feature_for_FeatureID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2FE_GFfFID_1402 : FR_Base
	{
		public L2FE_GFfFID_1402 Result	{ get; set; }

		public FR_L2FE_GFfFID_1402() : base() {}

		public FR_L2FE_GFfFID_1402(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2FE_GFfFID_1402 for attribute P_L2FE_GFfFID_1402
		[DataContract]
		public class P_L2FE_GFfFID_1402 
		{
			//Standard type parameters
			[DataMember]
			public Guid FeatureID { get; set; } 

		}
		#endregion
		#region SClass L2FE_GFfFID_1402 for attribute L2FE_GFfFID_1402
		[DataContract]
		public class L2FE_GFfFID_1402 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_FeatureID { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 
			[DataMember]
			public DateTime Feature_Deadline { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2FE_GFfFID_1402 cls_Get_Feature_for_FeatureID(,P_L2FE_GFfFID_1402 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2FE_GFfFID_1402 invocationResult = cls_Get_Feature_for_FeatureID.Invoke(connectionString,P_L2FE_GFfFID_1402 Parameter,securityTicket);
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
var parameter = new CL2_Feature.Atomic.Retrieval.P_L2FE_GFfFID_1402();
parameter.FeatureID = ...;

*/
