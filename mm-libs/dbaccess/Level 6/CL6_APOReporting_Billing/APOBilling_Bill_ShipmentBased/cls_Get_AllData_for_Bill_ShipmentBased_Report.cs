/* 
 * Generated on 07.11.2014 10:47:58
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
using CL1_CMN;
using CL1_CMN_BPT;
using CL1_CMN_BPT_CTM;
using CL1_ACC_PAY;
using CL5_APOBilling_Bill.Complex.Retrieval;
using CL5_APOBilling_CustomerOrderReturn.Complex.Retrieval;

namespace CL6_APOReporting_Billing.APOBilling_Bill_ShipmentBased
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllData_for_Bill_ShipmentBased_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllData_for_Bill_ShipmentBased_Report
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6BL_GADfBSBR_1010 Execute(DbConnection Connection,DbTransaction Transaction,P_L6BL_GADfBSBR_1010 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6BL_GADfBSBR_1010();
			//Put your code here

            #region Retrieving bill header.

            ORM_BIL_BillHeader billHeader = new ORM_BIL_BillHeader();
            FR_Base billHeaderLoad = billHeader.Load(Connection, Transaction, Parameter.BillHeaderID);
            if (billHeaderLoad.Status != FR_Status.Success)
            {
                Exception ex = new Exception(billHeaderLoad.ErrorMessage);
                return new FR_L6BL_GADfBSBR_1010(ex);
            }

            #endregion

            #region Retrieving universal contact details.

            ORM_CMN_UniversalContactDetail universalContactDetails = new ORM_CMN_UniversalContactDetail();
            FR_Base universalContactDetailsLoad = universalContactDetails.Load(Connection, Transaction, billHeader.BillingAddress_UCD_RefID);
            if (universalContactDetailsLoad.Status != FR_Status.Success)
            {
                Exception ex = new Exception(universalContactDetailsLoad.ErrorMessage);
                return new FR_L6BL_GADfBSBR_1010(ex);
            }

            #endregion

            #region Retrieving business participants details.

            ORM_CMN_BPT_BusinessParticipant businessParticipant = new ORM_CMN_BPT_BusinessParticipant();
            FR_Base businessParticipantLoad = businessParticipant.Load(Connection, Transaction, billHeader.BillRecipient_BuisnessParticipant_RefID);
            if (businessParticipantLoad.Status != FR_Status.Success)
            {
                Exception ex = new Exception(businessParticipantLoad.ErrorMessage);
                return new FR_L6BL_GADfBSBR_1010(ex);
            }

            #endregion

            #region Retrieving customer details.

            ORM_CMN_BPT_CTM_Customer customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_Customer.Query { Ext_BusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID }).FirstOrDefault();
            if (customer == null)
            {
                Exception ex = new Exception("Retrieving ORM_CMN_BPT_CTM_Customer details failed.");
                return new FR_L6BL_GADfBSBR_1010(ex);
            }

            #endregion

            #region Retriving method of payments (taking first one)

            ORM_BIL_BillHeader_MethodOfPayment methodOfPayment = ORM_BIL_BillHeader_MethodOfPayment.Query.Search(Connection, Transaction, new ORM_BIL_BillHeader_MethodOfPayment.Query
            {
                BIL_BillHeader_RefID = billHeader.BIL_BillHeaderID
            }).FirstOrDefault();

            #endregion

            #region Retrieving payment type

            ORM_ACC_PAY_Type type = null;
            if (methodOfPayment != null)
            {
                type = ORM_ACC_PAY_Type.Query.Search(Connection, Transaction, new ORM_ACC_PAY_Type.Query { ACC_PAY_TypeID = methodOfPayment.ACC_PAY_Type_RefID }).Single();
            }

            #endregion

            #region Retrieving payment condition

            ORM_ACC_PAY_Condition condition = ORM_ACC_PAY_Condition.Query.Search(Connection, Transaction, new ORM_ACC_PAY_Condition.Query { ACC_PAY_ConditionID = billHeader.BillHeader_PaymentCondition_RefID }).FirstOrDefault();

            #endregion


            #region Retrieving bill positions

            var allBillPositions = cls_Get_AllPositions_with_Articles_for_BillHeader.Invoke(Connection, Transaction, new P_L5BL_GAPwAfBH_1118 { BillHeaderID = billHeader.BIL_BillHeaderID }, securityTicket).Result;


            #endregion


            returnValue.Result = new L6BL_GADfBSBR_1010();
            returnValue.Result.BillShipmentBasedReportHeaderDetails = new L6BL_GADfBSBR_1010a();

            returnValue.Result.BillShipmentBasedReportHeaderDetails.BillHeaderComment = billHeader.BillComment;
            returnValue.Result.BillShipmentBasedReportHeaderDetails.BillHeaderDate = billHeader.DateOnBill;
            returnValue.Result.BillShipmentBasedReportHeaderDetails.BillHeaderNumber = billHeader.BillNumber;
            returnValue.Result.BillShipmentBasedReportHeaderDetails.BillHeaderTotalValue_BeforeTax = billHeader.TotalValue_BeforeTax;
            returnValue.Result.BillShipmentBasedReportHeaderDetails.BillHeaderTotalValue_IncludingTax = billHeader.TotalValue_IncludingTax;

            if (condition != null)
            {
                returnValue.Result.BillShipmentBasedReportHeaderDetails.BillHeaderPaymentDeadline = billHeader.DateOnBill.AddDays(condition.MaximumPaymentTreshold_InDays);
            }
            if (type != null)
            {
                returnValue.Result.BillShipmentBasedReportHeaderDetails.BillHeaderPaymentType = type.PaymentType_Name;
            }
            if (businessParticipant != null)
            {
                returnValue.Result.BillShipmentBasedReportHeaderDetails.RecepientBusinessParticipantDisplayName = businessParticipant.DisplayName;
            }
            if (customer != null)
            {
                returnValue.Result.BillShipmentBasedReportHeaderDetails.RecepientBusinessParticipantNumber = customer.InternalCustomerNumber;
            }
            if (universalContactDetails != null)
            {
                returnValue.Result.BillShipmentBasedReportHeaderDetails.RecepientBusinessParticipantStreetName = universalContactDetails.Street_Name;
                returnValue.Result.BillShipmentBasedReportHeaderDetails.RecepientBusinessParticipantStreetNumber = universalContactDetails.Street_Number;
                returnValue.Result.BillShipmentBasedReportHeaderDetails.RecepientBusinessParticipantCity = universalContactDetails.Town;
                returnValue.Result.BillShipmentBasedReportHeaderDetails.RecepientBusinessParticipantZipCode = universalContactDetails.ZIP;
            }


            #region bill positions

            returnValue.Result.BillPositions = null;
            List<L6BL_GADfBSBR_1010bp> unsortedBillPositionsTemp = new List<L6BL_GADfBSBR_1010bp>();

            if (allBillPositions.ShipmentBillPositions != null)
            {
                var unsortedBillPositions =
                    allBillPositions.ShipmentBillPositions.Where(x => x.BillPosition.CMN_BPT_CTM_OrganizationalUnitID == Guid.Empty).ToList();

                foreach (L5BL_GBPwAfBH_1848 unsortedBillPosition in unsortedBillPositions)
                {
                    L6BL_GADfBSBR_1010bp tempBillPosition = new L6BL_GADfBSBR_1010bp();
                    tempBillPosition.BIL_BillPositionID = unsortedBillPosition.BillPosition.BIL_BillPositionID;
                    tempBillPosition.BillPosition_ValuePerUnit_BeforeTax = (double)unsortedBillPosition.BillPosition.PositionPricePerUnitValue_BeforeTax;
                    tempBillPosition.BillPosition_ValuePerUnit_AfterTax = (double)unsortedBillPosition.BillPosition.PositionPricePerUnitValue_IncludingTax;
                    tempBillPosition.ACC_TAX_TaxeID = unsortedBillPosition.Article.Taxes.First().ACC_TAX_TaxeID;
                    tempBillPosition.TaxRate = unsortedBillPosition.Article.Taxes.First().TaxRate;
                    tempBillPosition.TaxName_DictID = unsortedBillPosition.Article.Taxes.First().TaxName_DictID;
                    tempBillPosition.HeaderID = unsortedBillPosition.BillPosition.LOG_SHP_Shipment_HeaderID;
                    tempBillPosition.Header_Number = unsortedBillPosition.BillPosition.ShipmentHeader_Number;
                    tempBillPosition.Creation_Timestamp = unsortedBillPosition.BillPosition.LOG_SHP_ShipmentHeader_Creation_Timestamp;
                    tempBillPosition.IsShipmentPosition = true;
                    tempBillPosition.Quantity = unsortedBillPosition.BillPosition.Quantity;
                    unsortedBillPositionsTemp.Add(tempBillPosition);
                }
            }
            // now for customer orders return
            if (allBillPositions.OrderReturnBillPosition != null)
            {
                var unsortedCustomerOrderReturnPositions =
                   allBillPositions.OrderReturnBillPosition.Where(x => x.OrderReturnBillPosition.CMN_BPT_CTM_OrganizationalUnitID == Guid.Empty).OrderBy(x => x.OrderReturnBillPosition.DateOfCustomerReturn).ToList();

                foreach (L5OR_GCORPwAfBH_1051 unsortedBillPosition in unsortedCustomerOrderReturnPositions)
                {
                    L6BL_GADfBSBR_1010bp tempBillPosition = new L6BL_GADfBSBR_1010bp();
                    tempBillPosition.BIL_BillPositionID = unsortedBillPosition.OrderReturnBillPosition.BIL_BillPositionID;
                    tempBillPosition.BillPosition_ValuePerUnit_BeforeTax = (double)unsortedBillPosition.OrderReturnBillPosition.PositionPricePerUnitValue_BeforeTax;
                    tempBillPosition.BillPosition_ValuePerUnit_AfterTax = (double)unsortedBillPosition.OrderReturnBillPosition.PositionPricePerUnitValue_IncludingTax;
                    tempBillPosition.ACC_TAX_TaxeID = unsortedBillPosition.Article.Taxes.First().ACC_TAX_TaxeID;
                    tempBillPosition.TaxRate = unsortedBillPosition.Article.Taxes.First().TaxRate;
                    tempBillPosition.TaxName_DictID = unsortedBillPosition.Article.Taxes.First().TaxName_DictID;
                    tempBillPosition.HeaderID = unsortedBillPosition.OrderReturnBillPosition.ORD_CUO_CustomerOrderReturn_HeaderID;
                    tempBillPosition.Header_Number = unsortedBillPosition.OrderReturnBillPosition.CustomerOrderReturnNumber;
                    tempBillPosition.Creation_Timestamp = unsortedBillPosition.OrderReturnBillPosition.Creation_Timestamp;
                    tempBillPosition.IsShipmentPosition = false;
                    tempBillPosition.Quantity = unsortedBillPosition.OrderReturnBillPosition.Quantity;
                    unsortedBillPositionsTemp.Add(tempBillPosition);
                }
            }

            returnValue.Result.BillPositions = unsortedBillPositionsTemp.ToArray();


            #region bill position organisation unit

            returnValue.Result.OrganizationalUnits = null;
            List<L6BL_GADfBSBR_1010bo> organizationalUnitsTemp = new List<L6BL_GADfBSBR_1010bo>();

            if (allBillPositions.ShipmentBillPositions != null)
            {
                List<L5BL_GBPwAfBH_1848> sortedBillPositions = allBillPositions.ShipmentBillPositions.Where(x => x.BillPosition.CMN_BPT_CTM_OrganizationalUnitID != Guid.Empty).ToList();

                foreach (L5BL_GBPwAfBH_1848 sortedBillPosition in sortedBillPositions)
                {

                    L6BL_GADfBSBR_1010bo tempOrganizationalUnit = organizationalUnitsTemp.FirstOrDefault(organizationalUnitTemp => organizationalUnitTemp.CMN_BPT_CTM_OrganizationalUnitID == sortedBillPosition.BillPosition.CMN_BPT_CTM_OrganizationalUnitID);


                    if (tempOrganizationalUnit == null)
                    {
                        tempOrganizationalUnit = new L6BL_GADfBSBR_1010bo();
                        tempOrganizationalUnit.BillPositions = new L6BL_GADfBSBR_1010bp[0];

                        tempOrganizationalUnit.CMN_BPT_CTM_OrganizationalUnitID = sortedBillPosition.BillPosition.CMN_BPT_CTM_OrganizationalUnitID;
                        tempOrganizationalUnit.OrganizationalUnit_SimpleName = sortedBillPosition.BillPosition.OrganizationalUnit_SimpleName;
                        tempOrganizationalUnit.OrganizationalUnit_Name = sortedBillPosition.BillPosition.OrganizationalUnit_Name_DictID;
                        tempOrganizationalUnit.OrganizationalUnit_Description = sortedBillPosition.BillPosition.OrganizationalUnit_Name_DictID;
                        tempOrganizationalUnit.InternalOrganizationalUnitNumber = sortedBillPosition.BillPosition.InternalOrganizationalUnitNumber;
                        tempOrganizationalUnit.InternalOrganizationalUnitSimpleName = sortedBillPosition.BillPosition.InternalOrganizationalUnitSimpleName;
                        tempOrganizationalUnit.ExternalOrganizationalUnitNumber = sortedBillPosition.BillPosition.ExternalOrganizationalUnitNumber;

                        organizationalUnitsTemp.Add(tempOrganizationalUnit);

                    }

                    L6BL_GADfBSBR_1010bp tempBillPosition = new L6BL_GADfBSBR_1010bp();
                    tempBillPosition.BIL_BillPositionID = sortedBillPosition.BillPosition.BIL_BillPositionID;
                    tempBillPosition.BillPosition_ValuePerUnit_BeforeTax = (double)sortedBillPosition.BillPosition.PositionPricePerUnitValue_BeforeTax;
                    tempBillPosition.BillPosition_ValuePerUnit_AfterTax = (double)sortedBillPosition.BillPosition.PositionPricePerUnitValue_IncludingTax;
                    tempBillPosition.ACC_TAX_TaxeID = sortedBillPosition.Article.Taxes.First().ACC_TAX_TaxeID;
                    tempBillPosition.TaxRate = sortedBillPosition.Article.Taxes.First().TaxRate;
                    tempBillPosition.TaxName_DictID = sortedBillPosition.Article.Taxes.First().TaxName_DictID;
                    tempBillPosition.HeaderID = sortedBillPosition.BillPosition.LOG_SHP_Shipment_HeaderID;
                    tempBillPosition.Header_Number = sortedBillPosition.BillPosition.ShipmentHeader_Number;
                    tempBillPosition.Creation_Timestamp = sortedBillPosition.BillPosition.LOG_SHP_ShipmentHeader_Creation_Timestamp;
                    tempBillPosition.IsShipmentPosition = true;
                    tempBillPosition.Quantity = sortedBillPosition.BillPosition.Quantity;
                    //hate this

                    List<L6BL_GADfBSBR_1010bp> currentBillPositions = tempOrganizationalUnit.BillPositions.ToList();
                    currentBillPositions.Add(tempBillPosition);
                    tempOrganizationalUnit.BillPositions = currentBillPositions.ToArray();

                }
            }

            // now for organization unit in customer order return

            if (allBillPositions.OrderReturnBillPosition != null)
            {
                List<L5OR_GCORPwAfBH_1051> sortedBillPositionsforCustomerOrderReturn = allBillPositions.OrderReturnBillPosition.Where(x => x.OrderReturnBillPosition.CMN_BPT_CTM_OrganizationalUnitID != Guid.Empty).OrderBy(x => x.OrderReturnBillPosition.DateOfCustomerReturn).ToList();

                foreach (L5OR_GCORPwAfBH_1051 sortedBillPosition in sortedBillPositionsforCustomerOrderReturn)
                {

                    L6BL_GADfBSBR_1010bo tempOrganizationalUnit = organizationalUnitsTemp.FirstOrDefault(organizationalUnitTemp => organizationalUnitTemp.CMN_BPT_CTM_OrganizationalUnitID == sortedBillPosition.OrderReturnBillPosition.CMN_BPT_CTM_OrganizationalUnitID);


                    if (tempOrganizationalUnit == null)
                    {
                        tempOrganizationalUnit = new L6BL_GADfBSBR_1010bo();
                        tempOrganizationalUnit.BillPositions = new L6BL_GADfBSBR_1010bp[0];

                        tempOrganizationalUnit.CMN_BPT_CTM_OrganizationalUnitID = sortedBillPosition.OrderReturnBillPosition.CMN_BPT_CTM_OrganizationalUnitID;
                        tempOrganizationalUnit.OrganizationalUnit_SimpleName = sortedBillPosition.OrderReturnBillPosition.OrganizationalUnit_SimpleName;
                        tempOrganizationalUnit.OrganizationalUnit_Name = sortedBillPosition.OrderReturnBillPosition.OrganizationalUnit_Name_DictID;
                        tempOrganizationalUnit.OrganizationalUnit_Description = sortedBillPosition.OrderReturnBillPosition.OrganizationalUnit_Name_DictID;
                        tempOrganizationalUnit.InternalOrganizationalUnitNumber = sortedBillPosition.OrderReturnBillPosition.InternalOrganizationalUnitNumber;
                        tempOrganizationalUnit.InternalOrganizationalUnitSimpleName = sortedBillPosition.OrderReturnBillPosition.InternalOrganizationalUnitSimpleName;
                        tempOrganizationalUnit.ExternalOrganizationalUnitNumber = sortedBillPosition.OrderReturnBillPosition.ExternalOrganizationalUnitNumber;

                        organizationalUnitsTemp.Add(tempOrganizationalUnit);

                    }

                    L6BL_GADfBSBR_1010bp tempBillPosition = new L6BL_GADfBSBR_1010bp();
                    tempBillPosition.BIL_BillPositionID = sortedBillPosition.OrderReturnBillPosition.BIL_BillPositionID;
                    tempBillPosition.BillPosition_ValuePerUnit_BeforeTax = (double)sortedBillPosition.OrderReturnBillPosition.PositionPricePerUnitValue_BeforeTax;
                    tempBillPosition.BillPosition_ValuePerUnit_AfterTax = (double)sortedBillPosition.OrderReturnBillPosition.PositionPricePerUnitValue_IncludingTax;
                    tempBillPosition.ACC_TAX_TaxeID = sortedBillPosition.Article.Taxes.First().ACC_TAX_TaxeID;
                    tempBillPosition.TaxRate = sortedBillPosition.Article.Taxes.First().TaxRate;
                    tempBillPosition.TaxName_DictID = sortedBillPosition.Article.Taxes.First().TaxName_DictID;
                    tempBillPosition.HeaderID = sortedBillPosition.OrderReturnBillPosition.ORD_CUO_CustomerOrderReturn_HeaderID;
                    tempBillPosition.Header_Number = sortedBillPosition.OrderReturnBillPosition.CustomerOrderReturnNumber;
                    tempBillPosition.Creation_Timestamp = sortedBillPosition.OrderReturnBillPosition.Creation_Timestamp;
                    tempBillPosition.IsShipmentPosition = false;
                    tempBillPosition.Quantity = sortedBillPosition.OrderReturnBillPosition.Quantity;
                    //hate this

                    List<L6BL_GADfBSBR_1010bp> currentBillPositions = tempOrganizationalUnit.BillPositions.ToList();
                    currentBillPositions.Add(tempBillPosition);
                    tempOrganizationalUnit.BillPositions = currentBillPositions.ToArray();

                }
            }

            returnValue.Result.OrganizationalUnits = organizationalUnitsTemp.ToArray();
            #endregion


            #endregion

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6BL_GADfBSBR_1010 Invoke(string ConnectionString,P_L6BL_GADfBSBR_1010 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6BL_GADfBSBR_1010 Invoke(DbConnection Connection,P_L6BL_GADfBSBR_1010 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6BL_GADfBSBR_1010 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6BL_GADfBSBR_1010 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6BL_GADfBSBR_1010 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6BL_GADfBSBR_1010 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6BL_GADfBSBR_1010 functionReturn = new FR_L6BL_GADfBSBR_1010();
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

				throw new Exception("Exception occured in method cls_Get_AllData_for_Bill_ShipmentBased_Report",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6BL_GADfBSBR_1010 : FR_Base
	{
		public L6BL_GADfBSBR_1010 Result	{ get; set; }

		public FR_L6BL_GADfBSBR_1010() : base() {}

		public FR_L6BL_GADfBSBR_1010(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6BL_GADfBSBR_1010 for attribute P_L6BL_GADfBSBR_1010
		[DataContract]
		public class P_L6BL_GADfBSBR_1010 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 

		}
		#endregion
		#region SClass L6BL_GADfBSBR_1010 for attribute L6BL_GADfBSBR_1010
		[DataContract]
		public class L6BL_GADfBSBR_1010 
		{
			[DataMember]
			public L6BL_GADfBSBR_1010a BillShipmentBasedReportHeaderDetails { get; set; }
			[DataMember]
			public L6BL_GADfBSBR_1010bo[] OrganizationalUnits { get; set; }

			//Standard type parameters
			[DataMember]
			public L6BL_GADfBSBR_1010bp[] BillPositions { get; set; } 

		}
		#endregion
		#region SClass L6BL_GADfBSBR_1010a for attribute BillShipmentBasedReportHeaderDetails
		[DataContract]
		public class L6BL_GADfBSBR_1010a 
		{
			//Standard type parameters
			[DataMember]
			public String RecepientBusinessParticipantDisplayName { get; set; } 
			[DataMember]
			public String RecepientBusinessParticipantNumber { get; set; } 
			[DataMember]
			public String RecepientBusinessParticipantStreetName { get; set; } 
			[DataMember]
			public String RecepientBusinessParticipantStreetNumber { get; set; } 
			[DataMember]
			public String RecepientBusinessParticipantZipCode { get; set; } 
			[DataMember]
			public String RecepientBusinessParticipantCity { get; set; } 
			[DataMember]
			public String BillHeaderNumber { get; set; } 
			[DataMember]
			public Dict BillHeaderPaymentType { get; set; } 
			[DataMember]
			public DateTime BillHeaderPaymentDeadline { get; set; } 
			[DataMember]
			public DateTime BillHeaderDate { get; set; } 
			[DataMember]
			public String BillHeaderComment { get; set; } 
			[DataMember]
			public decimal BillHeaderTotalValue_BeforeTax { get; set; } 
			[DataMember]
			public decimal BillHeaderTotalValue_IncludingTax { get; set; } 

		}
		#endregion
		#region SClass L6BL_GADfBSBR_1010bo for attribute OrganizationalUnits
		[DataContract]
		public class L6BL_GADfBSBR_1010bo 
		{
			[DataMember]
			public L6BL_GADfBSBR_1010bp[] BillPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_CTM_OrganizationalUnitID { get; set; } 
			[DataMember]
			public String OrganizationalUnit_SimpleName { get; set; } 
			[DataMember]
			public Dict OrganizationalUnit_Name { get; set; } 
			[DataMember]
			public Dict OrganizationalUnit_Description { get; set; } 
			[DataMember]
			public String InternalOrganizationalUnitNumber { get; set; } 
			[DataMember]
			public String InternalOrganizationalUnitSimpleName { get; set; } 
			[DataMember]
			public String ExternalOrganizationalUnitNumber { get; set; } 

		}
		#endregion
		#region SClass L6BL_GADfBSBR_1010bp for attribute BillPositions
		[DataContract]
		public class L6BL_GADfBSBR_1010bp 
		{
			//Standard type parameters
			[DataMember]
			public Guid BIL_BillPositionID { get; set; } 
			[DataMember]
			public double BillPosition_ValuePerUnit_BeforeTax { get; set; } 
			[DataMember]
			public double BillPosition_ValuePerUnit_AfterTax { get; set; } 
			[DataMember]
			public Guid ACC_TAX_TaxeID { get; set; } 
			[DataMember]
			public double TaxRate { get; set; } 
			[DataMember]
			public Dict TaxName_DictID { get; set; } 
			[DataMember]
			public Guid HeaderID { get; set; } 
			[DataMember]
			public String Header_Number { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Boolean IsShipmentPosition { get; set; } 
			[DataMember]
			public double Quantity { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6BL_GADfBSBR_1010 cls_Get_AllData_for_Bill_ShipmentBased_Report(,P_L6BL_GADfBSBR_1010 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6BL_GADfBSBR_1010 invocationResult = cls_Get_AllData_for_Bill_ShipmentBased_Report.Invoke(connectionString,P_L6BL_GADfBSBR_1010 Parameter,securityTicket);
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
var parameter = new CL6_APOReporting_Billing.APOBilling_Bill_ShipmentBased.P_L6BL_GADfBSBR_1010();
parameter.BillHeaderID = ...;

*/
