/* 
 * Generated on 12/4/2014 05:15:21
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

namespace CL3_Assortment.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Active_DefaultAssortment_for_CostCenterOrder.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Active_DefaultAssortment_for_CostCenterOrder
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3AS_GADAfCCO_0119_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3AS_GADAfCCO_0119_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Assortment.Atomic.Retrieval.SQL.cls_Get_Active_DefaultAssortment_for_CostCenterOrder.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3AS_GADAfCCO_0119> results = new List<L3AS_GADAfCCO_0119>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "cmn_pro_ass_assortmentID","AssortmentName_DictID","AvailableForOrderingFrom","AvailableForOrderingThrough" });
				while(reader.Read())
				{
					L3AS_GADAfCCO_0119 resultItem = new L3AS_GADAfCCO_0119();
					//0:Parameter cmn_pro_ass_assortmentID of type Guid
					resultItem.cmn_pro_ass_assortmentID = reader.GetGuid(0);
					//1:Parameter AssortmentName of type Dict
					resultItem.AssortmentName = reader.GetDictionary(1);
					resultItem.AssortmentName.SourceTable = "CMN_PRO_ASS_Assortments";
					loader.Append(resultItem.AssortmentName);
					//2:Parameter AvailableForOrderingFrom of type DateTime
					resultItem.AvailableForOrderingFrom = reader.GetDate(2);
					//3:Parameter AvailableForOrderingThrough of type DateTime
					resultItem.AvailableForOrderingThrough = reader.GetDate(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Active_DefaultAssortment_for_CostCenterOrder",ex);
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
		public static FR_L3AS_GADAfCCO_0119_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3AS_GADAfCCO_0119_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3AS_GADAfCCO_0119_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3AS_GADAfCCO_0119_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3AS_GADAfCCO_0119_Array functionReturn = new FR_L3AS_GADAfCCO_0119_Array();
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

				throw new Exception("Exception occured in method cls_Get_Active_DefaultAssortment_for_CostCenterOrder",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3AS_GADAfCCO_0119_Array : FR_Base
	{
		public L3AS_GADAfCCO_0119[] Result	{ get; set; } 
		public FR_L3AS_GADAfCCO_0119_Array() : base() {}

		public FR_L3AS_GADAfCCO_0119_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3AS_GADAfCCO_0119 for attribute L3AS_GADAfCCO_0119
		[DataContract]
		public class L3AS_GADAfCCO_0119 
		{
			//Standard type parameters
			[DataMember]
			public Guid cmn_pro_ass_assortmentID { get; set; } 
			[DataMember]
			public Dict AssortmentName { get; set; } 
			[DataMember]
			public DateTime AvailableForOrderingFrom { get; set; } 
			[DataMember]
			public DateTime AvailableForOrderingThrough { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3AS_GADAfCCO_0119_Array cls_Get_Active_DefaultAssortment_for_CostCenterOrder(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AS_GADAfCCO_0119_Array invocationResult = cls_Get_Active_DefaultAssortment_for_CostCenterOrder.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

