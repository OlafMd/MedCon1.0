/* 
 * Generated on 19.09.2014 12:36:50
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
using System.Runtime.Serialization;
using CL1_CMN_BPT;
using CL1_CMN_BPT_CTM;
using CL1_CMN_PER;

namespace CL2_Correspondences.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Correspondences.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Correspondences
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_CL5CO_SC_1724 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            Guid personInfoID = Guid.Empty;
          
            ORM_CMN_BPT_CTM_Customer.Query customerQuery = new ORM_CMN_BPT_CTM_Customer.Query();
            customerQuery.CMN_BPT_CTM_CustomerID = Parameter.CustomerID;
            customerQuery.IsDeleted = false;
            ORM_CMN_BPT_CTM_Customer customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery).Single();

            ORM_CMN_BPT_BusinessParticipant.Query businessParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
            businessParticipantQuery.CMN_BPT_BusinessParticipantID = customer.Ext_BusinessParticipant_RefID;
            businessParticipantQuery.IsDeleted = false;
            ORM_CMN_BPT_BusinessParticipant businessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantQuery).Single();

            if (businessParticipant.IsNaturalPerson)
            {
                personInfoID = businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
            }
            else
            {
                ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query associationQuery = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query();
                associationQuery.AssociatedBusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID;
                associationQuery.IsDeleted = false;
                List<ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant> associations = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, associationQuery);

                foreach (var association in associations)
                {
                    ORM_CMN_BPT_BusinessParticipant.Query bpQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                    bpQuery.CMN_BPT_BusinessParticipantID = association.BusinessParticipant_RefID;
                    bpQuery.IsDeleted = false;
                    bpQuery.IsNaturalPerson = true;
                    ORM_CMN_BPT_BusinessParticipant bp = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, bpQuery).First();
                    if (bp != null)
                    {
                        personInfoID = bp.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                        break;
                    }
                }
            }

            if (personInfoID != Guid.Empty)
            {
                if (Parameter.Correspondences.Any(x=> x.IsDefaultCorrespondence) && !Parameter.Correspondences.Any(x=> x.IsDeleted ))
                {
                var findDefaultCorrespondenceQuery = ORM_CMN_PER_PersonInfo_Correspondence.Query.Search(Connection, Transaction, 
                       new ORM_CMN_PER_PersonInfo_Correspondence.Query
                    {
                        CMN_PER_PersonInfo_RefID = personInfoID,
                        IsDefaultCorrespondence = true,
                        IsDeleted = false,
                        Tenant_RefID = customer.Tenant_RefID
                    });

                if (findDefaultCorrespondenceQuery != null && findDefaultCorrespondenceQuery.Any())
                    foreach (var item in findDefaultCorrespondenceQuery)
	                {
		                item.IsDefaultCorrespondence = false;
                        item.Save(Connection, Transaction);
	                }
                }

                foreach (var item in Parameter.Correspondences)
                {

                    ORM_CMN_PER_PersonInfo_Correspondence.Query correspondenceQuery = new ORM_CMN_PER_PersonInfo_Correspondence.Query();
                    correspondenceQuery.IsDeleted = false;
                    correspondenceQuery.CMN_PER_PersonInfo_CorrespondenceID = item.CorrespondenceID;
                    List<ORM_CMN_PER_PersonInfo_Correspondence> correspondences = ORM_CMN_PER_PersonInfo_Correspondence.Query.Search(Connection, Transaction, correspondenceQuery);

                    if (item.IsDeleted && correspondences.Count > 0)
                    {
                        correspondences.First().IsDeleted = true;
                        correspondences.First().Save(Connection, Transaction);
                    }
                    else if (!item.IsDeleted)
                    {
                        if (correspondences.Count > 0)
                        {
                            correspondences.First().CorrespondenceText = item.CorrespondenceText;

                            correspondences.First().IsDefaultCorrespondence = item.IsDefaultCorrespondence;
                            correspondences.First().CorrespondenceType_RefID = item.CorrespondenceTypeRefId;

                            correspondences.First().Save(Connection, Transaction);

                            // save name in correspodencetype
                            //var correspodenceTypeQuery = ORM_CMN_PER_PersonInfo_CorrespondenceType.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo_CorrespondenceType.Query{
                            //    CMN_PER_PersonInfo_CorrespondenceTypeID = correspondences.First().CorrespondenceType_RefID,
                            //    Tenant_RefID = customer.Tenant_RefID
                            //}).SingleOrDefault()

                            //if (correspodenceTypeQuery != null)
                            //{
                            //    correspodenceTypeQuery.DisplayName = item.CorrespondenceName;
                            //    correspodenceTypeQuery.Save(Connection, Transaction);
                            //}

                        }
                        else
                        {
                            ORM_CMN_PER_PersonInfo.Query personQuery = new ORM_CMN_PER_PersonInfo.Query();
                            personQuery.CMN_PER_PersonInfoID = personInfoID;
                            personQuery.IsDeleted = false;
                            ORM_CMN_PER_PersonInfo person = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, personQuery).First();

                            ORM_CMN_PER_PersonInfo_Correspondence newCorrespondance = new ORM_CMN_PER_PersonInfo_Correspondence();
                            newCorrespondance.CorrespondenceText = item.CorrespondenceText;
                            newCorrespondance.IsDefaultCorrespondence = item.IsDefaultCorrespondence;
                            newCorrespondance.CorrespondenceType_RefID = item.CorrespondenceTypeRefId;
                            newCorrespondance.IsDeleted = false;
                            newCorrespondance.Creation_Timestamp = DateTime.Now;
                            newCorrespondance.CMN_PER_PersonInfo_CorrespondenceID = Guid.NewGuid();
                            newCorrespondance.CMN_PER_PersonInfo_RefID = person.CMN_PER_PersonInfoID;
                            newCorrespondance.Tenant_RefID = customer.Tenant_RefID;
                            newCorrespondance.Save(Connection, Transaction);

                            //  We will need some of this code later
                            //var correspodenceTypeQuery = ORM_CMN_PER_PersonInfo_CorrespondenceType.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo_CorrespondenceType.Query{
                            //    CMN_PER_PersonInfo_CorrespondenceTypeID = newCorrespondance.CorrespondenceType_RefID,
                            //    Tenant_RefID = customer.Tenant_RefID
                            //}).SingleOrDefault()

                            //if (correspodenceTypeQuery != null)
                            //{
                            //    correspodenceTypeQuery.DisplayName = item.CorrespondenceName;
                            //    correspodenceTypeQuery.Save(Connection,Transaction);
                            //}
                            //else
                            //{
                            //    ORM_CMN_PER_PersonInfo_CorrespondenceType newCorrespodenceType = new ORM_CMN_PER_PersonInfo_CorrespondenceType();
                            //    newCorrespodenceType.Tenant_RefID = customer.Tenant_RefID;
                            //    newCorrespodenceType.CMN_PER_PersonInfo_CorrespondenceTypeID = newCorrespondance.CorrespondenceType_RefID;
                            //    newCorrespodenceType.DisplayName = item.CorrespondenceName;
                            //}
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
		public static FR_Guid Invoke(string ConnectionString,P_CL5CO_SC_1724 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_CL5CO_SC_1724 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_CL5CO_SC_1724 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CL5CO_SC_1724 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Correspondences",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_CL5CO_SC_1724 for attribute P_CL5CO_SC_1724
		[DataContract]
		public class P_CL5CO_SC_1724 
		{
			[DataMember]
			public P_CL5CO_SC_1724a[] Correspondences { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CustomerID { get; set; } 

		}
		#endregion
		#region SClass P_CL5CO_SC_1724a for attribute Correspondences
		[DataContract]
		public class P_CL5CO_SC_1724a 
		{
			//Standard type parameters
			[DataMember]
			public String CorrespondenceText { get; set; } 
			[DataMember]
			public Guid CorrespondenceID { get; set; } 
			[DataMember]
			public Guid CorrespondenceTypeRefId { get; set; } 
			[DataMember]
			public bool IsDefaultCorrespondence { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Correspondences(,P_CL5CO_SC_1724 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Correspondences.Invoke(connectionString,P_CL5CO_SC_1724 Parameter,securityTicket);
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
var parameter = new CL2_Correspondences.Atomic.Manipulation.P_CL5CO_SC_1724();
parameter.Correspondences = ...;

parameter.CustomerID = ...;

*/
