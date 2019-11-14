/* 
 * Generated on 7/16/2014 10:44:05 AM
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
using System.Runtime.Serialization;

namespace CL5_APOAdmin_ArticlesInfo.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Shipment_History_for_ArticleID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Shipment_History_for_ArticleID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AI_GSHfA_1559_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AI_GSHfA_1559 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AI_GSHfA_1559_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_ArticlesInfo.Atomic.Retrieval.SQL.cls_Get_Shipment_History_for_ArticleID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ArticleID", Parameter.ArticleID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Status", Parameter.Status);



			List<L5AI_GSHfA_1559> results = new List<L5AI_GSHfA_1559>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RecepientBP","QuantityToShip","ShipmentPosition_ValueWithoutTax","Creation_Timestamp","ShippedStatusCreator","CustomerOrder_Number","ShipmentHeader_Number","InternalOrganizationalUnitSimpleName" });
				while(reader.Read())
				{
					L5AI_GSHfA_1559 resultItem = new L5AI_GSHfA_1559();
					//0:Parameter RecepientBP of type String
					resultItem.RecepientBP = reader.GetString(0);
					//1:Parameter QuantityToShip of type String
					resultItem.QuantityToShip = reader.GetString(1);
					//2:Parameter ShipmentPosition_ValueWithoutTax of type decimal
					resultItem.ShipmentPosition_ValueWithoutTax = reader.GetDecimal(2);
					//3:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(3);
					//4:Parameter ShippedStatusCreator of type String
					resultItem.ShippedStatusCreator = reader.GetString(4);
					//5:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(5);
					//6:Parameter ShipmentHeader_Number of type String
					resultItem.ShipmentHeader_Number = reader.GetString(6);
					//7:Parameter InternalOrganizationalUnitSimpleName of type String
					resultItem.InternalOrganizationalUnitSimpleName = reader.GetString(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Shipment_History_for_ArticleID",ex);
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
		public static FR_L5AI_GSHfA_1559_Array Invoke(string ConnectionString,P_L5AI_GSHfA_1559 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AI_GSHfA_1559_Array Invoke(DbConnection Connection,P_L5AI_GSHfA_1559 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AI_GSHfA_1559_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AI_GSHfA_1559 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AI_GSHfA_1559_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AI_GSHfA_1559 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AI_GSHfA_1559_Array functionReturn = new FR_L5AI_GSHfA_1559_Array();
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

				throw new Exception("Exception occured in method cls_Get_Shipment_History_for_ArticleID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AI_GSHfA_1559_Array : FR_Base
	{
		public L5AI_GSHfA_1559[] Result	{ get; set; } 
		public FR_L5AI_GSHfA_1559_Array() : base() {}

		public FR_L5AI_GSHfA_1559_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AI_GSHfA_1559 for attribute P_L5AI_GSHfA_1559
		[DataContract]
		public class P_L5AI_GSHfA_1559 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 
			[DataMember]
			public String Status { get; set; } 

		}
		#endregion
		#region SClass L5AI_GSHfA_1559 for attribute L5AI_GSHfA_1559
		[DataContract]
		public class L5AI_GSHfA_1559 
		{
			//Standard type parameters
			[DataMember]
			public String RecepientBP { get; set; } 
			[DataMember]
			public String QuantityToShip { get; set; } 
			[DataMember]
			public decimal ShipmentPosition_ValueWithoutTax { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String ShippedStatusCreator { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public String ShipmentHeader_Number { get; set; } 
			[DataMember]
			public String InternalOrganizationalUnitSimpleName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AI_GSHfA_1559_Array cls_Get_Shipment_History_for_ArticleID(,P_L5AI_GSHfA_1559 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AI_GSHfA_1559_Array invocationResult = cls_Get_Shipment_History_for_ArticleID.Invoke(connectionString,P_L5AI_GSHfA_1559 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_ArticlesInfo.Atomic.Retrieval.P_L5AI_GSHfA_1559();
parameter.ArticleID = ...;
parameter.Status = ...;

*/
