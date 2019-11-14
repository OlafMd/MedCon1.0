/* 
 * Generated on 15.11.2014 23:19:27
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
using CL1_CMN_BPT;

namespace CL5_APOCustomerAdmin_Customer.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CustomerGroups_and_Assignments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CustomerGroups_and_Assignments
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CU_SCgaA_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            ORM_CMN_BPT_BusinessParticipant_Group group = null;
            if (Parameter.GroupID != Guid.Empty)
            {
                group = ORM_CMN_BPT_BusinessParticipant_Group.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_Group.Query
                {
                    CMN_BPT_BusinessParticipant_GroupID = Parameter.GroupID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();
            }

            if (group == null && !Parameter.DeleteGroup) {group = new ORM_CMN_BPT_BusinessParticipant_Group { 
                CMN_BPT_BusinessParticipant_GroupID = Guid.NewGuid(),
                BusinessParticipantGroup_Name = Parameter.BusinessParticipantGroup_Name,
                BusinessParticipantGroup_Description = Parameter.BusinessParticipantGroup_Description,
                Tenant_RefID = securityTicket.TenantID
            };
            }
            else if (group != null && !Parameter.DeleteGroup)
            {
                if (Parameter.BusinessParticipantGroup_Name != null)
                    group.BusinessParticipantGroup_Name = Parameter.BusinessParticipantGroup_Name;
                if(Parameter.BusinessParticipantGroup_Description != null)
                    group.BusinessParticipantGroup_Description = Parameter.BusinessParticipantGroup_Description;
            };

            if (!Parameter.DeleteGroup) 
            {
                group.Save(Connection, Transaction);
            }
            else group.Remove(Connection, Transaction);

            var Assignments = ORM_CMN_BPT_BusinessParticipant_2_BusinessParticipantGroup.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_2_BusinessParticipantGroup.Query
            {
                  CMN_BPT_BusinessParticipant_Group_RefID = Parameter.GroupID,
                  Tenant_RefID = securityTicket.TenantID,
                  IsDeleted = false
            });


            if (Parameter.DeleteGroup)
            {
                foreach (var item in Assignments)
                {
                    item.Remove(Connection, Transaction);
                }
            }
            else
            {
                foreach (var BPID in Parameter.BusinessParticipantID)
                {
                    if (BPID != Guid.Empty)
                        if (!Assignments.Select(x => x.CMN_BPT_BusinessParticipant_RefID).Contains(BPID))
                        {
                            var assignment = new ORM_CMN_BPT_BusinessParticipant_2_BusinessParticipantGroup();
                            assignment.AssignmentID = Guid.NewGuid();
                            assignment.CMN_BPT_BusinessParticipant_Group_RefID = group.CMN_BPT_BusinessParticipant_GroupID;
                            assignment.CMN_BPT_BusinessParticipant_RefID = BPID;
                            assignment.Tenant_RefID = securityTicket.TenantID;
                            assignment.Save(Connection, Transaction);
                        }
                }


                var assignmentsForDelete = Assignments.Where(a => !Parameter.BusinessParticipantID.Any(b => b == a.CMN_BPT_BusinessParticipant_RefID));


                foreach (var forDelete in assignmentsForDelete)
                {
                    forDelete.Remove(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,P_L5CU_SCgaA_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CU_SCgaA_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CU_SCgaA_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CU_SCgaA_1535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CustomerGroups_and_Assignments",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CU_SCgaA_1535 for attribute P_L5CU_SCgaA_1535
		[DataContract]
		public class P_L5CU_SCgaA_1535 
		{
			//Standard type parameters
			[DataMember]
			public Guid GroupID { get; set; } 
			[DataMember]
			public Boolean DeleteGroup { get; set; } 
			[DataMember]
			public Dict BusinessParticipantGroup_Name { get; set; } 
			[DataMember]
			public Dict BusinessParticipantGroup_Description { get; set; } 
			[DataMember]
			public Guid[] BusinessParticipantID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CustomerGroups_and_Assignments(,P_L5CU_SCgaA_1535 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CustomerGroups_and_Assignments.Invoke(connectionString,P_L5CU_SCgaA_1535 Parameter,securityTicket);
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
var parameter = new CL5_APOCustomerAdmin_Customer.Complex.Manipulation.P_L5CU_SCgaA_1535();
parameter.GroupID = ...;
parameter.DeleteGroup = ...;
parameter.BusinessParticipantGroup_Name = ...;
parameter.BusinessParticipantGroup_Description = ...;
parameter.BusinessParticipantID = ...;

*/
