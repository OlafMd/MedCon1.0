/* 
 * Generated on 3/3/2015 2:28:32 PM
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
using CL3_Shipment.Atomic.Retrieval;

namespace CL5_Zugseil_DistributionOrder.Complex.Retrieval
{
	/// <summary>
    /// Get_All_Shipment_Information_for_ShipmentPositionID
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Shipment_Information_for_ShipmentPositionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Shipment_Information_for_ShipmentPositionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DO_GASIfSP_1537 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_GASIfSP_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5DO_GASIfSP_1537();
			//Put your code here

            returnValue.Result = new L5DO_GASIfSP_1537();
            returnValue.Result.ShipmentInformation = new L3S_GSIfSP_1437();
          
            P_L3S_GSIfSP_1437 parameter = new P_L3S_GSIfSP_1437();
            parameter.ShipmentPositionID = Parameter.ShipmentPositionID;
            parameter.LanguageID = Parameter.LanguageID;

            var shipmentInformation = cls_Get_Shipment_Information_for_ShipmentPositionID.Invoke(Connection, Transaction, parameter, securityTicket).Result;

            P_L3S_GOPfSbSP_1458 parameterPos = new P_L3S_GOPfSbSP_1458();
            parameterPos.ShipmentHeaderID = Parameter.ShipmentHeaderID;
            parameterPos.LanguageID = Parameter.LanguageID;

            var shipmentPositions = cls_Get_ShipmentPositions_for_Shipment_by_ShipmentHeaderID.Invoke(Connection, Transaction, parameterPos, securityTicket).Result;

            P_L3S_GSHSfSP_1536 paremeterHis = new P_L3S_GSHSfSP_1536();
            paremeterHis.ShipmentHeaderID = Parameter.ShipmentHeaderID;
            paremeterHis.LanguageID = Parameter.LanguageID;

            var shipmentStatusHistory = cls_Get_Shipment_History_Statuses_for_ShipmentPositionID.Invoke(Connection, Transaction, paremeterHis, securityTicket).Result;

            returnValue.Result.ShipmentInformation = shipmentInformation;
            returnValue.Result.ShipmentPositions = shipmentPositions;
            returnValue.Result.ShipmentStatusHistory = shipmentStatusHistory;


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DO_GASIfSP_1537 Invoke(string ConnectionString,P_L5DO_GASIfSP_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DO_GASIfSP_1537 Invoke(DbConnection Connection,P_L5DO_GASIfSP_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DO_GASIfSP_1537 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_GASIfSP_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DO_GASIfSP_1537 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_GASIfSP_1537 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DO_GASIfSP_1537 functionReturn = new FR_L5DO_GASIfSP_1537();
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

				throw new Exception("Exception occured in method cls_Get_All_Shipment_Information_for_ShipmentPositionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DO_GASIfSP_1537 : FR_Base
	{
		public L5DO_GASIfSP_1537 Result	{ get; set; }

		public FR_L5DO_GASIfSP_1537() : base() {}

		public FR_L5DO_GASIfSP_1537(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DO_GASIfSP_1537 for attribute P_L5DO_GASIfSP_1537
		[DataContract]
		public class P_L5DO_GASIfSP_1537 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentPositionID { get; set; } 
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion
		#region SClass L5DO_GASIfSP_1537 for attribute L5DO_GASIfSP_1537
		[DataContract]
		public class L5DO_GASIfSP_1537 
		{
			//Standard type parameters
			[DataMember]
			public L3S_GSIfSP_1437 ShipmentInformation { get; set; } 
			[DataMember]
			public L3S_GOPfSbSP_1458[] ShipmentPositions { get; set; } 
			[DataMember]
			public L3S_GSHSfSP_1536[] ShipmentStatusHistory { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DO_GASIfSP_1537 cls_Get_All_Shipment_Information_for_ShipmentPositionID(,P_L5DO_GASIfSP_1537 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DO_GASIfSP_1537 invocationResult = cls_Get_All_Shipment_Information_for_ShipmentPositionID.Invoke(connectionString,P_L5DO_GASIfSP_1537 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_DistributionOrder.Complex.Retrieval.P_L5DO_GASIfSP_1537();
parameter.ShipmentPositionID = ...;
parameter.ShipmentHeaderID = ...;
parameter.LanguageID = ...;

*/
