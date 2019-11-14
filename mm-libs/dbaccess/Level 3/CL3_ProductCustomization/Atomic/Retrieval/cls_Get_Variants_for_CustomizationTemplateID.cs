/* 
 * Generated on 2/12/2015 16:09:00
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
    /// var result = cls_Get_Variants_for_CustomizationTemplateID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Variants_for_CustomizationTemplateID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PC_GVfCT_1706_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PC_GVfCT_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PC_GVfCT_1706_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_ProductCustomization.Atomic.Retrieval.SQL.cls_Get_Variants_for_CustomizationTemplateID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CustomizationTemplateID", Parameter.CustomizationTemplateID);



			List<L3PC_GVfCT_1706> results = new List<L3PC_GVfCT_1706>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_CUS_Customization_Variant_TemplateID","CustomizationVariantTemplate_Name_DictID","OrderSequence" });
				while(reader.Read())
				{
					L3PC_GVfCT_1706 resultItem = new L3PC_GVfCT_1706();
					//0:Parameter CMN_PRO_CUS_Customization_Variant_TemplateID of type Guid
					resultItem.CMN_PRO_CUS_Customization_Variant_TemplateID = reader.GetGuid(0);
					//1:Parameter CustomizationVariantTemplate_Name of type Dict
					resultItem.CustomizationVariantTemplate_Name = reader.GetDictionary(1);
					resultItem.CustomizationVariantTemplate_Name.SourceTable = "cmn_pro_cus_customization_variant_templates";
					loader.Append(resultItem.CustomizationVariantTemplate_Name);
					//2:Parameter OrderSequence of type int
					resultItem.OrderSequence = reader.GetInteger(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Variants_for_CustomizationTemplateID",ex);
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
		public static FR_L3PC_GVfCT_1706_Array Invoke(string ConnectionString,P_L3PC_GVfCT_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PC_GVfCT_1706_Array Invoke(DbConnection Connection,P_L3PC_GVfCT_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PC_GVfCT_1706_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PC_GVfCT_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PC_GVfCT_1706_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PC_GVfCT_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PC_GVfCT_1706_Array functionReturn = new FR_L3PC_GVfCT_1706_Array();
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

				throw new Exception("Exception occured in method cls_Get_Variants_for_CustomizationTemplateID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PC_GVfCT_1706_Array : FR_Base
	{
		public L3PC_GVfCT_1706[] Result	{ get; set; } 
		public FR_L3PC_GVfCT_1706_Array() : base() {}

		public FR_L3PC_GVfCT_1706_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PC_GVfCT_1706 for attribute P_L3PC_GVfCT_1706
		[DataContract]
		public class P_L3PC_GVfCT_1706 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomizationTemplateID { get; set; } 

		}
		#endregion
		#region SClass L3PC_GVfCT_1706 for attribute L3PC_GVfCT_1706
		[DataContract]
		public class L3PC_GVfCT_1706 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_CUS_Customization_Variant_TemplateID { get; set; } 
			[DataMember]
			public Dict CustomizationVariantTemplate_Name { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PC_GVfCT_1706_Array cls_Get_Variants_for_CustomizationTemplateID(,P_L3PC_GVfCT_1706 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PC_GVfCT_1706_Array invocationResult = cls_Get_Variants_for_CustomizationTemplateID.Invoke(connectionString,P_L3PC_GVfCT_1706 Parameter,securityTicket);
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
var parameter = new CL3_ProductCustomization.Atomic.Retrieval.P_L3PC_GVfCT_1706();
parameter.CustomizationTemplateID = ...;

*/
