/* 
 * Generated on 06.03.2014 11:03:42
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
using CL1_BIL;
using System.Globalization;
using EdifactInterface;
using CL1_HEC;
using System.Resources;
using System.Web;

namespace CL6_Lucenits_Treatments.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Persist_TreatmentsBillData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Persist_TreatmentsBillData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_PBD_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();

            if(Parameter.OutputData == null) return returnValue;

            var treatmentIDs = Parameter.OutputData.Select(s => Guid.Parse(s.strTreatmentID)).Distinct().ToArray();

            ORM_BIL_BillHeader header = ORM_BIL_BillHeader.Query.Search(Connection, Transaction, new ORM_BIL_BillHeader.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                BIL_BillHeaderID = Parameter.HeaderID
            }).Single();

            ORM_BIL_BillHeaderExtension_EDIFACT edifact = new ORM_BIL_BillHeaderExtension_EDIFACT();
            edifact.BIL_BillHeader_RefID = header.BIL_BillHeaderID;
            edifact.BIL_BillHeaderExtension_EDIFACTID = Guid.NewGuid();
            edifact.EDIFACTCounter = Parameter.EdifactNumber;
            edifact.Tenant_RefID = securityTicket.TenantID;
            edifact.Modification_Timestamp = DateTime.Now;
            edifact.Save(Connection, Transaction);

            var ci = CultureInfo.InvariantCulture.Clone() as CultureInfo;
            ci.NumberFormat.NumberDecimalSeparator = ",";

            foreach (var treatmentID in treatmentIDs)
            {
                bool IsArticleAdded = false;
                var treatment = ORM_HEC_Patient_Treatment.Query.Search(Connection, Transaction, new ORM_HEC_Patient_Treatment.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    HEC_Patient_TreatmentID = treatmentID
                }).Single();
                treatment.IsTreatmentBilled = true;
                treatment.IfTreatmentBilled_Date = DateTime.Now;
                treatment.Modification_Timestamp = DateTime.Now;
                treatment.Save(Connection, Transaction);

                foreach (var item in Parameter.OutputData.Where(i => i.strTreatmentID == treatmentID.ToString()).ToList())
                {
                    ORM_BIL_BillPosition billPosition = new ORM_BIL_BillPosition();
                    billPosition.Tenant_RefID = securityTicket.TenantID;
                    //billPosition.PositionIndex = i;
                    billPosition.BIL_BilHeader_RefID = header.BIL_BillHeaderID;
                    billPosition.BIL_BillPositionID = Guid.NewGuid();
                    billPosition.External_PositionCode = item.strGpos;
                    billPosition.External_PositionReferenceField = item.iProcessNumber.ToString();
                    billPosition.PositionValue_IncludingTax = decimal.Parse(item.strChargedValue, ci);
                    billPosition.Modification_Timestamp = DateTime.Now;

                    switch (item.iTypeOfBillingPosition)
                    {
                        case 1:
                            billPosition.External_PositionType = "Behandlung";
                            break;
                        case 2:
                            billPosition.External_PositionType = "Nachsorge";
                            break;
                        case 3:
                            billPosition.External_PositionType = "Behandlung | Nachsorge";
                            break;
                        case 4:
                            billPosition.External_PositionType = "Zusatzposition Bevacuzimab";
                            break;
                        case 5:
                            billPosition.External_PositionType = "Wartezeitenmanagement";
                            break;
                        default:
                            throw new Exception("Wrong bill position type!");
                    }

                    billPosition.Save(Connection, Transaction);

                    ORM_BIL_BillPosition_2_PatientTreatment p2t = new ORM_BIL_BillPosition_2_PatientTreatment();
                    p2t.AssignmentID = Guid.NewGuid();
                    p2t.Tenant_RefID = securityTicket.TenantID;
                    p2t.BIL_BillPosition_RefID = billPosition.BIL_BillPositionID;
                    p2t.HEC_Patient_Treatment_RefID = treatment.HEC_Patient_TreatmentID;
                    p2t.Save(Connection, Transaction);

                    ORM_BIL_BillPosition_TransmitionStatus billPositionTransmitionStatus = new ORM_BIL_BillPosition_TransmitionStatus();
                    billPositionTransmitionStatus.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                    billPositionTransmitionStatus.BillPosition_RefID = billPosition.BIL_BillPositionID;
                    billPositionTransmitionStatus.TransmitionCode = 2;
                    billPositionTransmitionStatus.PrimaryComment =  (String)HttpContext.GetGlobalResourceObject("Global", "TransferedToAOKStatus");
                    billPositionTransmitionStatus.IsActive = true;
                    billPositionTransmitionStatus.Tenant_RefID = securityTicket.TenantID;
                    billPositionTransmitionStatus.Creation_Timestamp = DateTime.Now;
                    billPositionTransmitionStatus.TransmittedOnDate = DateTime.Now;
                    billPositionTransmitionStatus.Save(Connection, Transaction);

                    if (!treatment.IsTreatmentFollowup && item.aiRelevantArticle != null && !IsArticleAdded)
                    {
                        Guid articleID;
                        if (Guid.TryParse(item.aiRelevantArticle.strArticleID, out articleID))
                        {
                            IsArticleAdded = true;
                            ORM_BIL_BillPosition_2_Product billToProduct1 = new ORM_BIL_BillPosition_2_Product();
                            billToProduct1.Tenant_RefID = securityTicket.TenantID;
                            billToProduct1.Creation_Timestamp = DateTime.Now;
                            billToProduct1.AssignmentID = Guid.NewGuid();
                            billToProduct1.BIL_BillPosition_RefID = billPosition.BIL_BillPositionID;
                            billToProduct1.CMN_PRO_Product_RefID = articleID;
                            billToProduct1.Quantity = item.aiRelevantArticle.iQuantity.ToString();
                            billToProduct1.Save(Connection, Transaction);
                        }
                    }
                }           
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L6TR_PBD_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L6TR_PBD_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_PBD_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_PBD_1706 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Persist_TreatmentsBillData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6TR_PBD_1706 for attribute P_L6TR_PBD_1706
		[DataContract]
		public class P_L6TR_PBD_1706 
		{
			//Standard type parameters
			[DataMember]
			public Guid HeaderID { get; set; } 
			[DataMember]
			public int EdifactNumber { get; set; } 
			[DataMember]
			public ExcelOutput[] OutputData { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Persist_TreatmentsBillData(,P_L6TR_PBD_1706 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Persist_TreatmentsBillData.Invoke(connectionString,P_L6TR_PBD_1706 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Complex.Manipulation.P_L6TR_PBD_1706();
parameter.HeaderID = ...;
parameter.EdifactNumber = ...;
parameter.OutputData = ...;

*/
