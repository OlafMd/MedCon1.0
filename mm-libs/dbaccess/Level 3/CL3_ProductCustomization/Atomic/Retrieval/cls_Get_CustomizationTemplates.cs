/* 
 * Generated on 2/12/2015 16:08:57
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

namespace CL3_ProductCustomization.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomizationTemplates.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomizationTemplates
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PC_GCT_1646_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PC_GCT_1646_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_ProductCustomization.Atomic.Retrieval.SQL.cls_Get_CustomizationTemplates.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3PC_GCT_1646> results = new List<L3PC_GCT_1646>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_CUS_Customization_TemplateID","CustomizationTemplate_Name_DictID","CustomizationTemplate_Description_DictID" });
				while(reader.Read())
				{
					L3PC_GCT_1646 resultItem = new L3PC_GCT_1646();
					//0:Parameter CMN_PRO_CUS_Customization_TemplateID of type Guid
					resultItem.CMN_PRO_CUS_Customization_TemplateID = reader.GetGuid(0);
					//1:Parameter CustomizationTemplate_Name of type Dict
					resultItem.CustomizationTemplate_Name = reader.GetDictionary(1);
					resultItem.CustomizationTemplate_Name.SourceTable = "cmn_pro_cus_customization_templates";
					loader.Append(resultItem.CustomizationTemplate_Name);
					//2:Parameter CustomizationTemplate_Description of type Dict
					resultItem.CustomizationTemplate_Description = reader.GetDictionary(2);
					resultItem.CustomizationTemplate_Description.SourceTable = "cmn_pro_cus_customization_templates";
					loader.Append(resultItem.CustomizationTemplate_Description);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CustomizationTemplates",ex);
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
		public static FR_L3PC_GCT_1646_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PC_GCT_1646_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PC_GCT_1646_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PC_GCT_1646_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PC_GCT_1646_Array functionReturn = new FR_L3PC_GCT_1646_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_CustomizationTemplates",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PC_GCT_1646_Array : FR_Base
	{
		public L3PC_GCT_1646[] Result	{ get; set; } 
		public FR_L3PC_GCT_1646_Array() : base() {}

		public FR_L3PC_GCT_1646_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3PC_GCT_1646 for attribute L3PC_GCT_1646
		[DataContract]
		public class L3PC_GCT_1646 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_CUS_Customization_TemplateID { get; set; } 
			[DataMember]
			public Dict CustomizationTemplate_Name { get; set; } 
			[DataMember]
			public Dict CustomizationTemplate_Description { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PC_GCT_1646_Array cls_Get_CustomizationTemplates(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PC_GCT_1646_Array invocationResult = cls_Get_CustomizationTemplates.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

