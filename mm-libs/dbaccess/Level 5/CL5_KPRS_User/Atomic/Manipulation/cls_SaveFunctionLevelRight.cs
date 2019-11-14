/* 
 * Generated on 7/2/2013 9:36:04 AM
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
using CL1_USR;

namespace CL5_KPRS_User.Atomic.Manipulation
{
	[DataContract]
	public class cls_SaveFunctionLevelRight
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5US_SFLR_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 

			var returnValue = new FR_Guid();
            ORM_USR_Account_2_FunctionLevelRight.Query query = new ORM_USR_Account_2_FunctionLevelRight.Query();
            query.Account_RefID = Parameter.USR_AccountID;
            query.IsDeleted = false;
            List<ORM_USR_Account_2_FunctionLevelRight> functionAssigments = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, query);

            if (functionAssigments != null)
            {
                foreach (var FunctionLevel in Parameter.functionLevelRights)
                {
                    if (functionAssigments.Where(i => i.FunctionLevelRight_RefID == FunctionLevel.FunctionLevelRightID).ToArray().Length != 0)
                    {
                        ORM_USR_Account_2_FunctionLevelRight LevelRight = functionAssigments.Where(i => i.FunctionLevelRight_RefID == FunctionLevel.FunctionLevelRightID).FirstOrDefault();
                        if (!FunctionLevel.hasRight)
                        {
                            ORM_USR_Account_2_FunctionLevelRight.Query deleteQuery = new ORM_USR_Account_2_FunctionLevelRight.Query();
                            deleteQuery.Account_RefID = Parameter.USR_AccountID;
                            deleteQuery.FunctionLevelRight_RefID = FunctionLevel.FunctionLevelRightID;
                            deleteQuery.IsDeleted = false;
                            ORM_USR_Account_2_FunctionLevelRight.Query.SoftDelete(Connection, Transaction, deleteQuery);
                        }
                    }
                    else
                    {
                        if (FunctionLevel.hasRight)
                        {
                            ORM_USR_Account_2_FunctionLevelRight levelRight = new ORM_USR_Account_2_FunctionLevelRight();
                            levelRight.Account_RefID = Parameter.USR_AccountID;
                            levelRight.FunctionLevelRight_RefID = FunctionLevel.FunctionLevelRightID;
                            levelRight.Tenant_RefID = securityTicket.TenantID;
                            FR_Base res = levelRight.Save(Connection, Transaction);
                            if (res.Status != FR_Status.Success)
                            {
                                returnValue.ErrorMessage = res.ErrorMessage;
                                returnValue.Status = res.Status;
                                return returnValue;
                            }
                        }

                    }
                }
            }


                foreach (var functionLevelRight in Parameter.functionLevelRights)
                {
                    ORM_USR_Account_FunctionLevelRight right = new ORM_USR_Account_FunctionLevelRight();
                    if (functionLevelRight.FunctionLevelRightID != Guid.Empty)
                    {
                        var result = right.Load(Connection, Transaction, functionLevelRight.FunctionLevelRightID);
                        if (result.Status != FR_Status.Success || right.USR_Account_FunctionLevelRightID == Guid.Empty)
                        {
                            if (functionLevelRight.FunctionLevelRightID == Guid.Parse("ffc73b10-e870-483f-a9b5-1a3f43601da2"))
                            {
                                right.RightName = "KPRS.Administrator";
                            }
                            else if (functionLevelRight.FunctionLevelRightID == Guid.Parse("49cf6397-4c5d-4584-9556-a740c9b12249"))
                            {
                                right.RightName = "KPRS.BackOfficeUser";
                            }
                            else if (functionLevelRight.FunctionLevelRightID == Guid.Parse("eb3c7806-8bc2-4a78-bdae-5a7c215a443e"))
                            {
                                right.RightName = "KPRS.FieldAgent";
                            }

                            right.USR_Account_FunctionLevelRightID = functionLevelRight.FunctionLevelRightID;
                            right.Save(Connection, Transaction);

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
		public static FR_Guid Invoke(string ConnectionString,P_L5US_SFLR_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5US_SFLR_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5US_SFLR_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5US_SFLR_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5US_SFLR_1313 for attribute P_L5US_SFLR_1313
		[DataContract]
		public class P_L5US_SFLR_1313 
		{
			[DataMember]
			public P_L6_SFLR_1313_USR_Account_FunctionLevelRights[] functionLevelRights { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid USR_AccountID { get; set; } 

		}
		#endregion
		#region SClass P_L6_SFLR_1313_USR_Account_FunctionLevelRights for attribute functionLevelRights
		[DataContract]
		public class P_L6_SFLR_1313_USR_Account_FunctionLevelRights 
		{
			//Standard type parameters
			[DataMember]
			public Guid FunctionLevelRightID { get; set; } 
			[DataMember]
			public bool hasRight { get; set; } 

		}
		#endregion

	#endregion
}
