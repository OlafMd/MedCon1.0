/* 
 * Generated on 04-Dec-14 10:43:19 AM
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

namespace CL3_Feature.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_FeaturesInfo_for_FeatureID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_FeaturesInfo_for_FeatureID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3FE_GFIfFID_0825 Execute(DbConnection Connection,DbTransaction Transaction,P_L3FE_GFIfFID_0825 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3FE_GFIfFID_0825();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Features.Atomic.Retrieval.SQL.cls_Get_FeaturesInfo_for_FeatureID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FeatureID", Parameter.FeatureID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IncludeArchived", Parameter.IncludeArchived);



			List<L3FE_GFIfFID_0825> results = new List<L3FE_GFIfFID_0825>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DeveloperTask_RefID","Name_DictID","TMS_PRO_FeatureID","IdentificationNumber","DOC_Structure_Header_RefID","Description_DictID","Feature_Deadline","Creation_Timestamp","Feature_Type_DictID","Feature_Status_DictID","TMS_PRO_Feature_TypeID","Feature_StatusID","Project_RefID","Parent_RefID","TMS_PRO_ProjectMemberID","AssignmentID" });
				while(reader.Read())
				{
					L3FE_GFIfFID_0825 resultItem = new L3FE_GFIfFID_0825();
					//0:Parameter DeveloperTask_RefID of type Guid
					resultItem.DeveloperTask_RefID = reader.GetGuid(0);
					//1:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(1);
					resultItem.Name.SourceTable = "tms_pro_feature";
					loader.Append(resultItem.Name);
					//2:Parameter TMS_PRO_FeatureID of type Guid
					resultItem.TMS_PRO_FeatureID = reader.GetGuid(2);
					//3:Parameter IdentificationNumber of type String
					resultItem.IdentificationNumber = reader.GetString(3);
					//4:Parameter DOC_Structure_Header_RefID of type Guid
					resultItem.DOC_Structure_Header_RefID = reader.GetGuid(4);
					//5:Parameter Description of type Dict
					resultItem.Description = reader.GetDictionary(5);
					resultItem.Description.SourceTable = "tms_pro_feature";
					loader.Append(resultItem.Description);
					//6:Parameter Feature_Deadline of type String
					resultItem.Feature_Deadline = reader.GetString(6);
					//7:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(7);
					//8:Parameter Feature_Type of type Dict
					resultItem.Feature_Type = reader.GetDictionary(8);
					resultItem.Feature_Type.SourceTable = "tms_pro_feature_type";
					loader.Append(resultItem.Feature_Type);
					//9:Parameter Feature_Status of type Dict
					resultItem.Feature_Status = reader.GetDictionary(9);
					resultItem.Feature_Status.SourceTable = "tms_pro_feature_statuses";
					loader.Append(resultItem.Feature_Status);
					//10:Parameter TMS_PRO_Feature_TypeID of type Guid
					resultItem.TMS_PRO_Feature_TypeID = reader.GetGuid(10);
					//11:Parameter Feature_StatusID of type Guid
					resultItem.Feature_StatusID = reader.GetGuid(11);
					//12:Parameter Project_RefID of type Guid
					resultItem.Project_RefID = reader.GetGuid(12);
					//13:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(13);
					//14:Parameter TMS_PRO_ProjectMemberID of type Guid
					resultItem.TMS_PRO_ProjectMemberID = reader.GetGuid(14);
					//15:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_FeaturesInfo_for_FeatureID",ex);
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
		public static FR_L3FE_GFIfFID_0825 Invoke(string ConnectionString,P_L3FE_GFIfFID_0825 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3FE_GFIfFID_0825 Invoke(DbConnection Connection,P_L3FE_GFIfFID_0825 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3FE_GFIfFID_0825 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3FE_GFIfFID_0825 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3FE_GFIfFID_0825 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3FE_GFIfFID_0825 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3FE_GFIfFID_0825 functionReturn = new FR_L3FE_GFIfFID_0825();
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

				throw new Exception("Exception occured in method cls_Get_FeaturesInfo_for_FeatureID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3FE_GFIfFID_0825 : FR_Base
	{
		public L3FE_GFIfFID_0825 Result	{ get; set; }

		public FR_L3FE_GFIfFID_0825() : base() {}

		public FR_L3FE_GFIfFID_0825(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3FE_GFIfFID_0825 for attribute P_L3FE_GFIfFID_0825
		[DataContract]
		public class P_L3FE_GFIfFID_0825 
		{
			//Standard type parameters
			[DataMember]
			public Guid FeatureID { get; set; } 
			[DataMember]
			public Guid IncludeArchived { get; set; } 

		}
		#endregion
		#region SClass L3FE_GFIfFID_0825 for attribute L3FE_GFIfFID_0825
		[DataContract]
		public class L3FE_GFIfFID_0825 
		{
			[DataMember]
			public L3FE_GFIfFID_0825_Subscription[] Subscription { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid DeveloperTask_RefID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Guid TMS_PRO_FeatureID { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public Guid DOC_Structure_Header_RefID { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 
			[DataMember]
			public String Feature_Deadline { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Dict Feature_Type { get; set; } 
			[DataMember]
			public Dict Feature_Status { get; set; } 
			[DataMember]
			public Guid TMS_PRO_Feature_TypeID { get; set; } 
			[DataMember]
			public Guid Feature_StatusID { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Guid TMS_PRO_ProjectMemberID { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 

		}
		#endregion
		#region SClass L3FE_GFIfFID_0825_Subscription for attribute Subscription
		[DataContract]
		public class L3FE_GFIfFID_0825_Subscription 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3FE_GFIfFID_0825 cls_Get_FeaturesInfo_for_FeatureID(,P_L3FE_GFIfFID_0825 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3FE_GFIfFID_0825 invocationResult = cls_Get_FeaturesInfo_for_FeatureID.Invoke(connectionString,P_L3FE_GFIfFID_0825 Parameter,securityTicket);
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
var parameter = new CL3_Feature.Atomic.Retrieval.P_L3FE_GFIfFID_0825();
parameter.FeatureID = ...;
parameter.IncludeArchived = ...;

*/
