/* 
 * Generated on 9/1/2014 14:02:52
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

namespace CL3_Features.Atomic.Retrieval
{
	/// <summary>
    /// Get all Features(Archived or NotArchived) for ProjectIDList
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Features_SimpleView_for_ProjectIDList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Features_SimpleView_for_ProjectIDList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3FE_GFSVfPL_1553_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3FE_GFSVfPL_1553 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3FE_GFSVfPL_1553_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Features.Atomic.Retrieval.SQL.cls_Get_Features_SimpleView_for_ProjectIDList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProjectIDList"," IN $$ProjectIDList$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProjectIDList$",Parameter.ProjectIDList);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Is_ArchivedFeatures_Included", Parameter.Is_ArchivedFeatures_Included);



			List<L3FE_GFSVfPL_1553> results = new List<L3FE_GFSVfPL_1553>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_FeatureID","IdentificationNumber","DOC_Structure_Header_RefID","Project_RefID","Name_DictID","IsArchived","BusinessTask_RefID","Status_RefID" });
				while(reader.Read())
				{
					L3FE_GFSVfPL_1553 resultItem = new L3FE_GFSVfPL_1553();
					//0:Parameter TMS_PRO_FeatureID of type Guid
					resultItem.TMS_PRO_FeatureID = reader.GetGuid(0);
					//1:Parameter IdentificationNumber of type String
					resultItem.IdentificationNumber = reader.GetString(1);
					//2:Parameter DOC_Structure_Header_RefID of type Guid
					resultItem.DOC_Structure_Header_RefID = reader.GetGuid(2);
					//3:Parameter Project_RefID of type Guid
					resultItem.Project_RefID = reader.GetGuid(3);
					//4:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(4);
					resultItem.Name.SourceTable = "tms_pro_feature";
					loader.Append(resultItem.Name);
					//5:Parameter IsArchived of type Boolean
					resultItem.IsArchived = reader.GetBoolean(5);
					//6:Parameter BusinessTask_RefID of type Guid
					resultItem.BusinessTask_RefID = reader.GetGuid(6);
					//7:Parameter Status_RefID of type Guid
					resultItem.Status_RefID = reader.GetGuid(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Features_SimpleView_for_ProjectIDList",ex);
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
		public static FR_L3FE_GFSVfPL_1553_Array Invoke(string ConnectionString,P_L3FE_GFSVfPL_1553 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3FE_GFSVfPL_1553_Array Invoke(DbConnection Connection,P_L3FE_GFSVfPL_1553 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3FE_GFSVfPL_1553_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3FE_GFSVfPL_1553 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3FE_GFSVfPL_1553_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3FE_GFSVfPL_1553 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3FE_GFSVfPL_1553_Array functionReturn = new FR_L3FE_GFSVfPL_1553_Array();
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

				throw new Exception("Exception occured in method cls_Get_Features_SimpleView_for_ProjectIDList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3FE_GFSVfPL_1553_Array : FR_Base
	{
		public L3FE_GFSVfPL_1553[] Result	{ get; set; } 
		public FR_L3FE_GFSVfPL_1553_Array() : base() {}

		public FR_L3FE_GFSVfPL_1553_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3FE_GFSVfPL_1553 for attribute P_L3FE_GFSVfPL_1553
		[DataContract]
		public class P_L3FE_GFSVfPL_1553 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProjectIDList { get; set; } 
			[DataMember]
			public Boolean Is_ArchivedFeatures_Included { get; set; } 

		}
		#endregion
		#region SClass L3FE_GFSVfPL_1553 for attribute L3FE_GFSVfPL_1553
		[DataContract]
		public class L3FE_GFSVfPL_1553 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_FeatureID { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public Guid DOC_Structure_Header_RefID { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Boolean IsArchived { get; set; } 
			[DataMember]
			public Guid BusinessTask_RefID { get; set; } 
			[DataMember]
			public Guid Status_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3FE_GFSVfPL_1553_Array cls_Get_Features_SimpleView_for_ProjectIDList(,P_L3FE_GFSVfPL_1553 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3FE_GFSVfPL_1553_Array invocationResult = cls_Get_Features_SimpleView_for_ProjectIDList.Invoke(connectionString,P_L3FE_GFSVfPL_1553 Parameter,securityTicket);
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
var parameter = new CL3_Features.Atomic.Retrieval.P_L3FE_GFSVfPL_1553();
parameter.ProjectIDList = ...;
parameter.Is_ArchivedFeatures_Included = ...;

*/
