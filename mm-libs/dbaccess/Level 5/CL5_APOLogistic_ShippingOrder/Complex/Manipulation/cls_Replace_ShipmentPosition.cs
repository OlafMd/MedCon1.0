/* 
 * Generated on 11/7/2014 11:26:29 AM
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
using CL2_Language.Atomic.Retrieval;
using DLCore_DBCommons.APODemand;
using CL1_LOG_SHP;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons;
using CSV2Core.SessionSecurity;
using CL1_LOG_RSV;
using CL1_CMN_PRO;

namespace CL5_APOLogistic_ShippingOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Replace_ShipmentPosition.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Replace_ShipmentPosition
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_RSP_1524 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_RSP_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5SO_RSP_1524();
            returnValue.Result = new L5SO_RSP_1524();

            var shipmentPositionToReplace = new ORM_LOG_SHP_Shipment_Position();
            shipmentPositionToReplace.Load(Connection, Transaction, Parameter.PositionID);

            var startProduct = new ORM_CMN_PRO_Product();
            startProduct.Load(Connection, Transaction, shipmentPositionToReplace.CMN_PRO_Product_RefID);

            var finalProduct = new ORM_CMN_PRO_Product();
            finalProduct.Load(Connection, Transaction, Parameter.ProductID);


            shipmentPositionToReplace.ShipmentPosition_PricePerUnitValueWithoutTax = Parameter.Price;
            shipmentPositionToReplace.ShipmentPosition_ValueWithoutTax = Parameter.Price * (Decimal)shipmentPositionToReplace.QuantityToShip;
            shipmentPositionToReplace.CMN_PRO_Product_RefID = Parameter.ProductID;

            returnValue.Result.ReplacedPosition = new FR_Guid(shipmentPositionToReplace.Save(Connection, Transaction), shipmentPositionToReplace.LOG_SHP_Shipment_PositionID).Result;

            P_L2LN_GALFTID_1530 langParam = new P_L2LN_GALFTID_1530();
            langParam.Tenant_RefID = securityTicket.TenantID;
            SessionSecurityTicket fakeTicket = new SessionSecurityTicket();
            var DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, langParam, fakeTicket).Result;
            var languages = DBLanguages.Select(i => new ISOLanguage() { ISO = i.ISO_639_1, LanguageID = i.CMN_LanguageID }).ToList();

            var dicts = EnumUtils.GetDictObjectsForStaticListData<ECustomMessages>(ResourceFilePath.CustomMessages, ORM_LOG_SHP_Shipment_Note.TableName, languages);

            ORM_LOG_SHP_Shipment_Note note = new ORM_LOG_SHP_Shipment_Note();
            note.LOG_SHP_Shipment_NoteID = Guid.NewGuid();
            note.Shipment_Header_RefID = Parameter.ShipmentHeaderID;
            note.Comment = String.Format(dicts["comment.article-replaced"].Contents[1].Content,
                startProduct.Product_Name.Contents[0].Content, startProduct.Product_Number, finalProduct.Product_Name.Contents[0].Content, finalProduct.Product_Number);
            note.Tenant_RefID = securityTicket.TenantID;
            note.IsNotePrintedOnDeliveryPaper = true;
            note.Save(Connection, Transaction);

            returnValue.Result.ReplacedPosition = new FR_Guid(shipmentPositionToReplace.Save(Connection, Transaction), shipmentPositionToReplace.LOG_SHP_Shipment_PositionID).Result;

            ORM_LOG_RSV_Reservation.Query.SoftDelete(Connection, Transaction,
                new ORM_LOG_RSV_Reservation.Query
                {
                    LOG_SHP_Shipment_Position_RefID = shipmentPositionToReplace.LOG_SHP_Shipment_PositionID,
                    IsDeleted = false
                });

            #region CommentedUseful

            #endregion

            cls_Update_Current_TotalValue_on_ShipmentHeader_from_Positions.Invoke(Connection, Transaction, new P_L5SO_UCTVoSHfP_1549 { ShipmentHeaderID = Parameter.ShipmentHeaderID }, securityTicket);

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SO_RSP_1524 Invoke(string ConnectionString,P_L5SO_RSP_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_RSP_1524 Invoke(DbConnection Connection,P_L5SO_RSP_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_RSP_1524 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_RSP_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_RSP_1524 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_RSP_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_RSP_1524 functionReturn = new FR_L5SO_RSP_1524();
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

				throw new Exception("Exception occured in method cls_Replace_ShipmentPosition",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SO_RSP_1524 : FR_Base
	{
		public L5SO_RSP_1524 Result	{ get; set; }

		public FR_L5SO_RSP_1524() : base() {}

		public FR_L5SO_RSP_1524(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_RSP_1524 for attribute P_L5SO_RSP_1524
		[DataContract]
		public class P_L5SO_RSP_1524 
		{
			//Standard type parameters
			[DataMember]
			public Guid PositionID { get; set; } 
			[DataMember]
			public double ChangedQuantity { get; set; } 
			[DataMember]
			public decimal Price { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SO_RSP_1524 for attribute L5SO_RSP_1524
		[DataContract]
		public class L5SO_RSP_1524 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReplacedPosition { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SO_RSP_1524 cls_Replace_ShipmentPosition(,P_L5SO_RSP_1524 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SO_RSP_1524 invocationResult = cls_Replace_ShipmentPosition.Invoke(connectionString,P_L5SO_RSP_1524 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ShippingOrder.Complex.Manipulation.P_L5SO_RSP_1524();
parameter.PositionID = ...;
parameter.ChangedQuantity = ...;
parameter.Price = ...;
parameter.ProductID = ...;
parameter.ShipmentHeaderID = ...;

*/
