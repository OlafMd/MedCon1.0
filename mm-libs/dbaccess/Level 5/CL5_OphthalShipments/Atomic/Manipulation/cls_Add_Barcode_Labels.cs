/* 
 * Generated on 8/30/2013 11:02:05 AM
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
using CL1_LOG_SHP;
using CL1_HEC;
using CL5_OphthalDoctors.Atomic.Retrieval;
using CL5_OphthalShipments.Atomic.Retrieval;
using Core_ClassLibrarySupport.Utils;

namespace CL5_OphthalShipments.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Add_Barcode_Labels.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Add_Barcode_Labels
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5OS_ABL_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guids();
            List<Guid> retVal = new List<Guid>();

            Guid shippmentHeaderID = Guid.Empty;

            P_L5OS_GASFD_1234 param = new P_L5OS_GASFD_1234();
            param.HEC_DoctorID = Parameter.HEC_Doctor_RefID;
            var dateNow = DateTime.Now;
            param.ToDate = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 23, 59, 59, 999);
            param.FormDate = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 0, 0, 0, 0);

            var res = cls_Get_ActiveShippmentForDoctorID.Invoke(Connection, Transaction, param, securityTicket).Result;

            if (res != null && res.Length > 0)
            {
                shippmentHeaderID = res[0].LOG_SHP_Shipment_HeaderID;
            }

            if (shippmentHeaderID == Guid.Empty)
            {
                ORM_LOG_SHP_Shipment_Header header = new ORM_LOG_SHP_Shipment_Header();
                header.IsShipped = false;
                header.Tenant_RefID = securityTicket.TenantID;
                header.Save(Connection, Transaction);

                shippmentHeaderID = header.LOG_SHP_Shipment_HeaderID;
            }

            for (int i = 0; i < Parameter.Count; i++)
            {
                ORM_LOG_SHP_Shipment_Position logShippmentPosition = new ORM_LOG_SHP_Shipment_Position();
                logShippmentPosition.CMN_PRO_Product_RefID = Parameter.CMN_PRO_ProductID;
                logShippmentPosition.LOG_SHP_Shipment_Header_RefID = shippmentHeaderID;
                logShippmentPosition.Save(Connection, Transaction);

                ORM_HEC_ShippingPosition_BarcodeLabel shippmentLabel = new ORM_HEC_ShippingPosition_BarcodeLabel();
                shippmentLabel.Doctor_RefID = Parameter.HEC_Doctor_RefID;
                shippmentLabel.LOG_SHP_Shipment_Position_RefID = logShippmentPosition.LOG_SHP_Shipment_PositionID;
                shippmentLabel.R_IsSubmission_Complete = false;
                shippmentLabel.Tenant_RefID = securityTicket.TenantID;
                List<ORM_HEC_ShippingPosition_BarcodeLabel> positionLabels;
                String barcodeLabel = "";
                do
                {
                    barcodeLabel = RandomString.Generate(9);

                    var positionLabelsQuery = new ORM_HEC_ShippingPosition_BarcodeLabel.Query();
                    positionLabelsQuery.ShippingPosition_BarcodeLabel = barcodeLabel;
                    positionLabelsQuery.Tenant_RefID = securityTicket.TenantID;
                    positionLabelsQuery.IsDeleted = false;
                    positionLabels = ORM_HEC_ShippingPosition_BarcodeLabel.Query.Search(Connection, Transaction, positionLabelsQuery);

                } while (positionLabels != null && positionLabels.Count != 0);

                shippmentLabel.ShippingPosition_BarcodeLabel = barcodeLabel;
                shippmentLabel.Save(Connection, Transaction);

                retVal.Add(shippmentLabel.HEC_ShippingPosition_BarcodeLabelID);
            }
            returnValue.Result = retVal.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L5OS_ABL_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5OS_ABL_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OS_ABL_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OS_ABL_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guids functionReturn = new FR_Guids();
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

				throw new Exception("Exception occured in method cls_Add_Barcode_Labels",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OS_ABL_1157 for attribute P_L5OS_ABL_1157
		[DataContract]
		public class P_L5OS_ABL_1157 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Doctor_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public int Count { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Add_Barcode_Labels(,P_L5OS_ABL_1157 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Add_Barcode_Labels.Invoke(connectionString,P_L5OS_ABL_1157 Parameter,securityTicket);
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
var parameter = new CL5_OphthalShipments.Atomic.Manipulation.P_L5OS_ABL_1157();
parameter.HEC_Doctor_RefID = ...;
parameter.CMN_PRO_ProductID = ...;
parameter.Count = ...;

*/
