/* 
 * Generated on 11/18/2013 3:51:39 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL2_Products.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProductAnnotations_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProductAnnotations_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PD_GAPAfT_1431_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2PD_GAPAfT_1431_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Products.Atomic.Retrieval.SQL.cls_Get_ProductAnnotations_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2PD_GAPAfT_1431> results = new List<L2PD_GAPAfT_1431>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_Product_AnnotationID","GlobalPropertyMatchingID","ProductAnnotation_Abbreviation","ProductAnnotation_Name_DictID","Creation_Timestamp","Tenant_RefID","IsValueBoolean","IsValueNumber" });
				while(reader.Read())
				{
					L2PD_GAPAfT_1431 resultItem = new L2PD_GAPAfT_1431();
					//0:Parameter CMN_PRO_Product_AnnotationID of type Guid
					resultItem.CMN_PRO_Product_AnnotationID = reader.GetGuid(0);
					//1:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(1);
					//2:Parameter ProductAnnotation_Abbreviation of type String
					resultItem.ProductAnnotation_Abbreviation = reader.GetString(2);
					//3:Parameter ProductAnnotation_Name_DictID of type Dict
					resultItem.ProductAnnotation_Name_DictID = reader.GetDictionary(3);
					resultItem.ProductAnnotation_Name_DictID.SourceTable = "cmn_pro_product_annotations";
					loader.Append(resultItem.ProductAnnotation_Name_DictID);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(5);
					//6:Parameter IsValueBoolean of type Boolean
					resultItem.IsValueBoolean = reader.GetBoolean(6);
					//7:Parameter IsValueNumber of type Boolean
					resultItem.IsValueNumber = reader.GetBoolean(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProductAnnotations_for_TenantID",ex);
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
		public static FR_L2PD_GAPAfT_1431_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PD_GAPAfT_1431_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PD_GAPAfT_1431_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PD_GAPAfT_1431_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PD_GAPAfT_1431_Array functionReturn = new FR_L2PD_GAPAfT_1431_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProductAnnotations_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PD_GAPAfT_1431_Array : FR_Base
	{
		public L2PD_GAPAfT_1431[] Result	{ get; set; } 
		public FR_L2PD_GAPAfT_1431_Array() : base() {}

		public FR_L2PD_GAPAfT_1431_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2PD_GAPAfT_1431 for attribute L2PD_GAPAfT_1431
		[DataContract]
		public class L2PD_GAPAfT_1431 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_AnnotationID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String ProductAnnotation_Abbreviation { get; set; } 
			[DataMember]
			public Dict ProductAnnotation_Name_DictID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Boolean IsValueBoolean { get; set; } 
			[DataMember]
			public Boolean IsValueNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PD_GAPAfT_1431_Array cls_Get_ProductAnnotations_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PD_GAPAfT_1431_Array invocationResult = cls_Get_ProductAnnotations_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

