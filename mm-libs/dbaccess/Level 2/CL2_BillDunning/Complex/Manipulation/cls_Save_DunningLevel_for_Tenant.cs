/* 
 * Generated on 28/5/2014 03:39:06
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
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_ACC_DUN;

namespace CL2_BillDunning.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DunningLevel_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DunningLevel_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2BD_SDLfT_1514 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            ORM_ACC_DUN_Dunning_Model.Query modelQuery = new ORM_ACC_DUN_Dunning_Model.Query();
            modelQuery.IsDeleted = false;
            modelQuery.IsDefaultCustomerModel = true;
            modelQuery.Tenant_RefID = securityTicket.TenantID;
            ORM_ACC_DUN_Dunning_Model model = ORM_ACC_DUN_Dunning_Model.Query.Search(Connection, Transaction, modelQuery).First();

            if (Parameter.DunningID != null && Parameter.DunningID != Guid.Empty)
            {
                ORM_ACC_DUN_Dunning_Level.Query existingLevelQuery = new ORM_ACC_DUN_Dunning_Level.Query();
                existingLevelQuery.Tenant_RefID = securityTicket.TenantID;
                existingLevelQuery.IsDeleted = false;
                existingLevelQuery.ACC_DUN_Dunning_LevelID = Parameter.DunningID;
                ORM_ACC_DUN_Dunning_Level existingLevel = ORM_ACC_DUN_Dunning_Level.Query.Search(Connection, Transaction, existingLevelQuery).First();

                if (Parameter.Deleting)
                {
                    existingLevel.IsDeleted = true;
                }
                else
                {
                    existingLevel.GlobalPropertyMatchingID = Parameter.DunningLevelName;
                    existingLevel.ParentLevel_RefID = Parameter.ParentLevelID;

                    Boolean contentExists = false;
                    foreach (var item in existingLevel.DunningLevelName.Contents)
                    {
                        if (item.LanguageID == Parameter.LanguageID)
                        {
                            contentExists = true;
                        }
                    }

                    if (contentExists)
                    {
                        existingLevel.DunningLevelName.UpdateEntry(Parameter.LanguageID, Parameter.DunningLevelName);
                    }
                    else
                    {
                        existingLevel.DunningLevelName.AddEntry(Parameter.LanguageID, Parameter.DunningLevelName);
                    }
                }
                ORM_ACC_DUN_DunningLevel_ModelAssignment.Query existingModelAssignmentQuery = new ORM_ACC_DUN_DunningLevel_ModelAssignment.Query();
                existingModelAssignmentQuery.Dunning_Level_RefID = existingLevel.ACC_DUN_Dunning_LevelID;
                existingModelAssignmentQuery.Dunning_Model_RefID = model.ACC_DUN_Dunning_ModelID;
                existingModelAssignmentQuery.Tenant_RefID = securityTicket.TenantID;
                existingModelAssignmentQuery.IsDeleted = false;
                ORM_ACC_DUN_DunningLevel_ModelAssignment existingModelAssignment = ORM_ACC_DUN_DunningLevel_ModelAssignment.Query.Search(Connection, Transaction, existingModelAssignmentQuery).First();

                if (Parameter.Deleting)
                {
                    existingModelAssignment.IsDeleted = true;
                }
                else
                {
                    existingModelAssignment.DunningFee = Parameter.DunningFee;
                    existingModelAssignment.OrderSequence = Parameter.OrderSequence;
                    existingModelAssignment.WaitPeriodToNextDunningLevel_In_Days = Parameter.WaitPeriod;
                }

                existingLevel.Save(Connection, Transaction);
                existingModelAssignment.Save(Connection, Transaction);

            }
            else
            {
                ORM_ACC_DUN_Dunning_Level newLevel = new ORM_ACC_DUN_Dunning_Level();
                newLevel.ACC_DUN_Dunning_LevelID = Guid.NewGuid();
                newLevel.ParentLevel_RefID = Parameter.ParentLevelID;
                newLevel.Tenant_RefID = securityTicket.TenantID;
                newLevel.Creation_Timestamp = DateTime.Now;
                newLevel.GlobalPropertyMatchingID = Parameter.DunningLevelName;
                newLevel.DunningLevelName = new Dict(ORM_ACC_DUN_Dunning_Level.TableName);
                newLevel.DunningLevelName.AddEntry(Parameter.LanguageID, Parameter.DunningLevelName);
                newLevel.IsDeleted = false;
                newLevel.Save(Connection, Transaction);

                ORM_ACC_DUN_DunningLevel_ModelAssignment newModelAssignment = new ORM_ACC_DUN_DunningLevel_ModelAssignment();
                newModelAssignment.ACC_DUN_DunningLevel_ModelAssignmentID = Guid.NewGuid();
                newModelAssignment.Tenant_RefID = securityTicket.TenantID;
                newModelAssignment.IsDeleted = false;
                newModelAssignment.Creation_Timestamp = DateTime.Now;
                newModelAssignment.Dunning_Level_RefID = newLevel.ACC_DUN_Dunning_LevelID;
                newModelAssignment.Dunning_Model_RefID = model.ACC_DUN_Dunning_ModelID;
                newModelAssignment.WaitPeriodToNextDunningLevel_In_Days = Parameter.WaitPeriod;
                newModelAssignment.DunningFee = Parameter.DunningFee;
                newModelAssignment.OrderSequence = Parameter.OrderSequence;
                newModelAssignment.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2BD_SDLfT_1514 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2BD_SDLfT_1514 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2BD_SDLfT_1514 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2BD_SDLfT_1514 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DunningLevel_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2BD_SDLfT_1514 for attribute P_L2BD_SDLfT_1514
		[DataContract]
		public class P_L2BD_SDLfT_1514 
		{
			//Standard type parameters
			[DataMember]
			public Guid ParentLevelID { get; set; } 
			[DataMember]
			public String DunningLevelName { get; set; } 
			[DataMember]
			public Decimal DunningFee { get; set; } 
			[DataMember]
			public int OrderSequence { get; set; } 
			[DataMember]
			public int WaitPeriod { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public Guid DunningID { get; set; } 
			[DataMember]
			public Boolean Deleting { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DunningLevel_for_Tenant(,P_L2BD_SDLfT_1514 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DunningLevel_for_Tenant.Invoke(connectionString,P_L2BD_SDLfT_1514 Parameter,securityTicket);
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
var parameter = new CL2_BillDunning.Complex.Manipulation.P_L2BD_SDLfT_1514();
parameter.ParentLevelID = ...;
parameter.DunningLevelName = ...;
parameter.DunningFee = ...;
parameter.OrderSequence = ...;
parameter.WaitPeriod = ...;
parameter.LanguageID = ...;
parameter.DunningID = ...;
parameter.Deleting = ...;

*/
