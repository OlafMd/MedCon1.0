/* 
 * Generated on 9/16/2013 3:44:21 PM
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
using CL1_CMN;
using CL1_RES_ACT;
using CL1_RES_STR;

namespace CL5_KPRS_Actions.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Action.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Action
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AT_SA_1301 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            ORM_RES_ACT_Action_Version oldVersion = new ORM_RES_ACT_Action_Version();
            ORM_RES_ACT_Action action = new ORM_RES_ACT_Action();
            int versionNumber = 0;
            if (Parameter.RES_ACT_ActionID != Guid.Empty)
            {
                var result = action.Load(Connection, Transaction, Parameter.RES_ACT_ActionID);
                if (result.Status != FR_Status.Success || action.RES_ACT_ActionID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                ORM_RES_ACT_Action_Version.Query versionQuery = new ORM_RES_ACT_Action_Version.Query();
                versionQuery.Tenant_RefID = securityTicket.TenantID;
                versionQuery.IsDeleted = false;
                versionQuery.Action_RefID = action.RES_ACT_ActionID;
                List<ORM_RES_ACT_Action_Version> versions = ORM_RES_ACT_Action_Version.Query.Search(Connection, Transaction, versionQuery);

                action.RES_ACT_ActionID = Parameter.RES_ACT_ActionID;
                versionNumber = versions.Max(i => i.Action_Version);
                oldVersion = versions.FirstOrDefault(i => i.Action_Version == versionNumber);
                versionNumber++;
            }
            else
            {
                versionNumber = 1;
                action.Tenant_RefID = securityTicket.TenantID;
            }

            action.ActionType_RefID = Parameter.ActionType_RefID;


            ORM_CMN_Price price = new ORM_CMN_Price();
            if (Parameter.Default_PricePerUnit_RefID != Guid.Empty)
            {
                var result = price.Load(Connection, Transaction, Parameter.Default_PricePerUnit_RefID);
                if (result.Status != FR_Status.Success || action.RES_ACT_ActionID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            price.Tenant_RefID = securityTicket.TenantID;
            price.Save(Connection,Transaction);

            ORM_CMN_Price_Value.Query priceQuery = new ORM_CMN_Price_Value.Query();
            priceQuery.Tenant_RefID = securityTicket.TenantID;
            priceQuery.Price_RefID = price.CMN_PriceID;
            priceQuery.IsDeleted = false;
            List<ORM_CMN_Price_Value> priceValueList=ORM_CMN_Price_Value.Query.Search(Connection, Transaction, priceQuery);
           
            ORM_CMN_Price_Value priceValue = new ORM_CMN_Price_Value();
            if (priceValueList.Count != 0)
            {
                priceValue.Load(Connection, Transaction, priceValueList[0].CMN_Price_ValueID);
            }
            priceValue.Tenant_RefID = securityTicket.TenantID;
            priceValue.Price_RefID = price.CMN_PriceID;
            priceValue.PriceValue_Amount = Parameter.Default_PricePerUnit;
            priceValue.Save(Connection, Transaction);


            ORM_RES_ACT_Action_Version version = new ORM_RES_ACT_Action_Version();
            version.Action_Description = Parameter.Action_Description_DictID;
            version.Action_Name = Parameter.Action_Name_DictID;
            version.Action_RefID = action.RES_ACT_ActionID;
            version.Action_Version = Parameter.Action_Version;
            version.Default_PricePerUnit_RefID = price.CMN_PriceID;
            version.Default_Unit_RefID = Parameter.Default_Unit_RefID;
            version.Default_UnitAmount = Parameter.Default_UnitAmount;
            version.Tenant_RefID = securityTicket.TenantID;
            version.Action_Version = versionNumber;
            version.Save(Connection, Transaction);

            action.CurrentVersion_RefID = version.RES_ACT_Action_VersionID;
            action.Save(Connection, Transaction);

            if (Parameter.RES_ACT_ActionID != Guid.Empty)
            {

                ORM_RES_STR_OutdoorFacility_Property_AvailableAction.Query query1 = new ORM_RES_STR_OutdoorFacility_Property_AvailableAction.Query();
                query1.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
                ORM_RES_STR_OutdoorFacility_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query1);

                ORM_RES_STR_Facade_Property_AvailableAction.Query query2 = new ORM_RES_STR_Facade_Property_AvailableAction.Query();
                query2.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
                ORM_RES_STR_Facade_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query2);

                ORM_RES_STR_Roof_Property_AvailableAction.Query query3 = new ORM_RES_STR_Roof_Property_AvailableAction.Query();
                query3.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
                ORM_RES_STR_Roof_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query3);

                ORM_RES_STR_Attic_Property_AvailableAction.Query query4 = new ORM_RES_STR_Attic_Property_AvailableAction.Query();
                query4.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
                ORM_RES_STR_Attic_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query4);

                ORM_RES_STR_Staircase_Property_AvailableAction.Query query5 = new ORM_RES_STR_Staircase_Property_AvailableAction.Query();
                query5.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
                ORM_RES_STR_Staircase_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query5);

                ORM_RES_STR_Basement_Property_AvailableAction.Query query6 = new ORM_RES_STR_Basement_Property_AvailableAction.Query();
                query6.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
                ORM_RES_STR_Basement_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query6);

                ORM_RES_STR_HVACR_Property_AvailableAction.Query query7 = new ORM_RES_STR_HVACR_Property_AvailableAction.Query();
                query7.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
                ORM_RES_STR_HVACR_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query7);

                ORM_RES_STR_Apartment_Property_AvailableAction.Query query8 = new ORM_RES_STR_Apartment_Property_AvailableAction.Query();
                query8.RES_ACT_Action_RefID = Parameter.RES_ACT_ActionID;
                ORM_RES_STR_Apartment_Property_AvailableAction.Query.SoftDelete(Connection, Transaction, query8);
            }

            if(Parameter.availableQuestions!=null)
            foreach (var question in Parameter.availableQuestions)
            {
                if (question.questionType == "OutdoorFacility")
                {
                    ORM_RES_STR_OutdoorFacility_Property_AvailableAction item = new ORM_RES_STR_OutdoorFacility_Property_AvailableAction();
                    item.RES_STR_OutdoorFacility_Property_RefID = question.questionID;
                    item.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }

                if (question.questionType == "Facade")
                {
                    ORM_RES_STR_Facade_Property_AvailableAction item = new ORM_RES_STR_Facade_Property_AvailableAction();
                    item.RES_STR_Facade_Property_RefID = question.questionID;
                    item.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }

                if (question.questionType == "Roof")
                {
                    ORM_RES_STR_Roof_Property_AvailableAction item = new ORM_RES_STR_Roof_Property_AvailableAction();
                    item.RES_STR_Roof_Property_RefID = question.questionID;
                    item.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }

                if (question.questionType == "Attic")
                {
                    ORM_RES_STR_Attic_Property_AvailableAction item = new ORM_RES_STR_Attic_Property_AvailableAction();
                    item.RES_STR_Attic_Property_RefID = question.questionID;
                    item.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }

                if (question.questionType == "Staircase")
                {
                    ORM_RES_STR_Staircase_Property_AvailableAction item = new ORM_RES_STR_Staircase_Property_AvailableAction();
                    item.RES_STR_Staircase_Property_RefID = question.questionID;
                    item.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }

                if (question.questionType == "Basement")
                {
                    ORM_RES_STR_Basement_Property_AvailableAction item = new ORM_RES_STR_Basement_Property_AvailableAction();
                    item.RES_STR_Basement_Property_RefID = question.questionID;
                    item.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }

                if (question.questionType == "HVCAR")
                {
                    ORM_RES_STR_HVACR_Property_AvailableAction item = new ORM_RES_STR_HVACR_Property_AvailableAction();
                    item.RES_STR_HVACR_Property_RefID = question.questionID;
                    item.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);
                }

                if (question.questionType == "Apartment")
                {
                    ORM_RES_STR_Apartment_Property_AvailableAction item = new ORM_RES_STR_Apartment_Property_AvailableAction();
                    item.RES_STR_Apartment_Property_RefID = question.questionID;
                    item.RES_ACT_Action_RefID = action.RES_ACT_ActionID;
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.Save(Connection, Transaction);

                }
            }


            returnValue.Result = action.RES_ACT_ActionID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AT_SA_1301 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AT_SA_1301 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AT_SA_1301 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AT_SA_1301 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_Action",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AT_SA_1301 for attribute P_L5AT_SA_1301
		[DataContract]
		public class P_L5AT_SA_1301 
		{
			[DataMember]
			public P_L5AT_SA_1301_availableQuestions[] availableQuestions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_ACT_ActionID { get; set; } 
			[DataMember]
			public Guid ActionType_RefID { get; set; } 
			[DataMember]
			public Guid RES_ACT_Action_VersionID { get; set; } 
			[DataMember]
			public Dict Action_Name_DictID { get; set; } 
			[DataMember]
			public Dict Action_Description_DictID { get; set; } 
			[DataMember]
			public int Action_Version { get; set; } 
			[DataMember]
			public Guid Default_PricePerUnit_RefID { get; set; } 
			[DataMember]
			public Double Default_PricePerUnit { get; set; } 
			[DataMember]
			public Guid Default_Unit_RefID { get; set; } 
			[DataMember]
			public double Default_UnitAmount { get; set; } 

		}
		#endregion
		#region SClass P_L5AT_SA_1301_availableQuestions for attribute availableQuestions
		[DataContract]
		public class P_L5AT_SA_1301_availableQuestions 
		{
			//Standard type parameters
			[DataMember]
			public Guid questionID { get; set; } 
			[DataMember]
			public String questionType { get; set; } 
			[DataMember]
			public bool questionIsAvailable { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Action(,P_L5AT_SA_1301 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Action.Invoke(connectionString,P_L5AT_SA_1301 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_Actions.Atomic.Manipulation.P_L5AT_SA_1301();
parameter.availableQuestions = ...;

parameter.RES_ACT_ActionID = ...;
parameter.ActionType_RefID = ...;
parameter.RES_ACT_Action_VersionID = ...;
parameter.Action_Name_DictID = ...;
parameter.Action_Description_DictID = ...;
parameter.Action_Version = ...;
parameter.Default_PricePerUnit_RefID = ...;
parameter.Default_PricePerUnit = ...;
parameter.Default_Unit_RefID = ...;
parameter.Default_UnitAmount = ...;

*/