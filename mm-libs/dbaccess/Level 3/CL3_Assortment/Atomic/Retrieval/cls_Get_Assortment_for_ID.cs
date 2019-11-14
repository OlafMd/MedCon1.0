/* 
 * Generated on 2/10/2015 2:30:07 PM
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
    /// var result = cls_Get_Assortment_for_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Assortment_for_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3ASS_GAFID_1815 Execute(DbConnection Connection,DbTransaction Transaction,P_L3ASS_GAFID_1815 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3ASS_GAFID_1815();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Assortment.Atomic.Retrieval.SQL.cls_Get_Assortment_for_ID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AssortmentID", Parameter.AssortmentID);



			List<L3ASS_GAFID_1815> results = new List<L3ASS_GAFID_1815>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ASS_AssortmentID","AssortmentName_DictID","AvailableForOrderingFrom","AvailableForOrderingThrough","IsDefaultAssortment_ForPersonalOrder","IsDefaultAssortment_ForOfficeOrder","IsDefaultAssortment_ForCostcenterOrder","IsDefaultAssortment_ForWarehouseOrder","IsDeleted","Tenant_RefID" });
				while(reader.Read())
				{
					L3ASS_GAFID_1815 resultItem = new L3ASS_GAFID_1815();
					//0:Parameter CMN_PRO_ASS_AssortmentID of type Guid
					resultItem.CMN_PRO_ASS_AssortmentID = reader.GetGuid(0);
					//1:Parameter AssortmentName of type Dict
					resultItem.AssortmentName = reader.GetDictionary(1);
					resultItem.AssortmentName.SourceTable = "cmn_pro_ass_assortments";
					loader.Append(resultItem.AssortmentName);
					//2:Parameter AvailableForOrderingFrom of type DateTime
					resultItem.AvailableForOrderingFrom = reader.GetDate(2);
					//3:Parameter AvailableForOrderingThrough of type DateTime
					resultItem.AvailableForOrderingThrough = reader.GetDate(3);
					//4:Parameter IsDefaultAssortment_ForPersonalOrder of type bool
					resultItem.IsDefaultAssortment_ForPersonalOrder = reader.GetBoolean(4);
					//5:Parameter IsDefaultAssortment_ForOfficeOrder of type bool
					resultItem.IsDefaultAssortment_ForOfficeOrder = reader.GetBoolean(5);
					//6:Parameter IsDefaultAssortment_ForCostcenterOrder of type bool
					resultItem.IsDefaultAssortment_ForCostcenterOrder = reader.GetBoolean(6);
					//7:Parameter IsDefaultAssortment_ForWarehouseOrder of type bool
					resultItem.IsDefaultAssortment_ForWarehouseOrder = reader.GetBoolean(7);
					//8:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(8);
					//9:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Assortment_for_ID",ex);
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
		public static FR_L3ASS_GAFID_1815 Invoke(string ConnectionString,P_L3ASS_GAFID_1815 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3ASS_GAFID_1815 Invoke(DbConnection Connection,P_L3ASS_GAFID_1815 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3ASS_GAFID_1815 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3ASS_GAFID_1815 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3ASS_GAFID_1815 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3ASS_GAFID_1815 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3ASS_GAFID_1815 functionReturn = new FR_L3ASS_GAFID_1815();
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

				throw new Exception("Exception occured in method cls_Get_Assortment_for_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3ASS_GAFID_1815 : FR_Base
	{
		public L3ASS_GAFID_1815 Result	{ get; set; }

		public FR_L3ASS_GAFID_1815() : base() {}

		public FR_L3ASS_GAFID_1815(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3ASS_GAFID_1815 for attribute P_L3ASS_GAFID_1815
		[DataContract]
		public class P_L3ASS_GAFID_1815 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssortmentID { get; set; } 

		}
		#endregion
		#region SClass L3ASS_GAFID_1815 for attribute L3ASS_GAFID_1815
		[DataContract]
		public class L3ASS_GAFID_1815 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ASS_AssortmentID { get; set; } 
			[DataMember]
			public Dict AssortmentName { get; set; } 
			[DataMember]
			public DateTime AvailableForOrderingFrom { get; set; } 
			[DataMember]
			public DateTime AvailableForOrderingThrough { get; set; } 
			[DataMember]
			public bool IsDefaultAssortment_ForPersonalOrder { get; set; } 
			[DataMember]
			public bool IsDefaultAssortment_ForOfficeOrder { get; set; } 
			[DataMember]
			public bool IsDefaultAssortment_ForCostcenterOrder { get; set; } 
			[DataMember]
			public bool IsDefaultAssortment_ForWarehouseOrder { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3ASS_GAFID_1815 cls_Get_Assortment_for_ID(,P_L3ASS_GAFID_1815 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3ASS_GAFID_1815 invocationResult = cls_Get_Assortment_for_ID.Invoke(connectionString,P_L3ASS_GAFID_1815 Parameter,securityTicket);
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
var parameter = new CL3_Assortment.Atomic.Retrieval.P_L3ASS_GAFID_1815();
parameter.AssortmentID = ...;

*/
