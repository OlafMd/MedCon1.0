/* 
 * Generated on 7/9/2013 11:34:53 AM
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
using CL1_RES_DUD;

namespace CL5_KPRS_DueDiligences.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_DueDiligences.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_DueDiligences
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L5DD_SDD_0945 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();

            ORM_RES_DUD_RevisionGroup revisionGroup = new ORM_RES_DUD_RevisionGroup();
            if (Parameter.RES_DUD_Revision_GroupID != Guid.Empty)
            {
                var result = revisionGroup.Load(Connection, Transaction, Parameter.RES_DUD_Revision_GroupID);
                if (result.Status != FR_Status.Success || revisionGroup.RES_DUD_Revision_GroupID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            revisionGroup.RevisionGroup_Name = Parameter.RevisionGroup_Name;
            revisionGroup.RevisionGroup_Comment = Parameter.RevisionGroup_Description;
            revisionGroup.RevisionGroup_SubmittedBy_Account_RefID = securityTicket.AccountID;
            revisionGroup.Tenant_RefID = securityTicket.TenantID;
            revisionGroup.RealestateProperty_RefID = Parameter.RealestateProperty_RefID;
            revisionGroup.Save(Connection, Transaction);



            if (Parameter.Revisions != null)
            {
                ORM_RES_DUD_Revision.Query revisionQuery = new ORM_RES_DUD_Revision.Query();
                revisionQuery.Tenant_RefID = securityTicket.TenantID;
                revisionQuery.RevisionGroup_RefID = revisionGroup.RES_DUD_Revision_GroupID;
                revisionQuery.IsDeleted = false;
                List<ORM_RES_DUD_Revision> oldRevisions = ORM_RES_DUD_Revision.Query.Search(Connection, Transaction, revisionQuery);

                foreach (var oldRevision in oldRevisions)
                {
                    if (!Parameter.Revisions.Any(i => i.RES_BLD_Building_RefID == oldRevision.RES_BLD_Building_RefID))
                    {
                        ORM_RES_DUD_Revision revisionToDelete = new ORM_RES_DUD_Revision();
                        revisionToDelete.Load(Connection, Transaction, oldRevision.RES_DUD_RevisionID);
                        revisionToDelete.IsDeleted = true;
                        revisionToDelete.Save(Connection, Transaction);
                    }
                }

                foreach (var revisionParam in Parameter.Revisions)
                {
                    revisionQuery = new ORM_RES_DUD_Revision.Query();
                    revisionQuery.Tenant_RefID = securityTicket.TenantID;
                    revisionQuery.RevisionGroup_RefID = revisionGroup.RES_DUD_Revision_GroupID;
                    revisionQuery.RES_BLD_Building_RefID = revisionParam.RES_BLD_Building_RefID;
                    revisionQuery.IsDeleted = false;
                    ORM_RES_DUD_Revision foundRevision = ORM_RES_DUD_Revision.Query.Search(Connection, Transaction, revisionQuery).FirstOrDefault();
                    ORM_RES_DUD_Revision revision = new ORM_RES_DUD_Revision();
                    if (foundRevision != null)
                    {
                        var result = revision.Load(Connection, Transaction, foundRevision.RES_DUD_RevisionID);
                        if (result.Status != FR_Status.Success || revision.RES_DUD_RevisionID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                    }
                    revision.QuestionnaireVersion_RefID = revisionParam.QuestionnaireVersion_RefID;
                    revision.RES_BLD_Building_RefID = revisionParam.RES_BLD_Building_RefID;
                    revision.RevisionGroup_RefID = revisionGroup.RES_DUD_Revision_GroupID;
                    revision.Tenant_RefID = securityTicket.TenantID;
                    revision.Save(Connection, Transaction);
                }
            }



            returnValue.Result = revisionGroup.RES_DUD_Revision_GroupID;
            //Put your code here
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_L5DD_SDD_0945 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L5DD_SDD_0945 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L5DD_SDD_0945 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5DD_SDD_0945 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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
                    if (cleanupTransaction == true && Transaction != null)
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

                throw new Exception("Exception occured in method cls_Save_DueDiligences", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L5DD_SDD_0945 for attribute P_L5DD_SDD_0945
    [DataContract]
    public class P_L5DD_SDD_0945
    {
        [DataMember]
        public P_L5DD_SDD_0945_Revisions[] Revisions { get; set; }

        //Standard type parameters
        [DataMember]
        public String RevisionGroup_Name { get; set; }
        [DataMember]
        public String RevisionGroup_Description { get; set; }
        [DataMember]
        public Guid RevisionGroup_SubmittedBy_Account_RefID { get; set; }
        [DataMember]
        public Guid RES_DUD_Revision_GroupID { get; set; }
        [DataMember]
        public Guid RealestateProperty_RefID { get; set; }

    }
    #endregion
    #region SClass P_L5DD_SDD_0945_Revisions for attribute Revisions
    [DataContract]
    public class P_L5DD_SDD_0945_Revisions
    {
        //Standard type parameters
        [DataMember]
        public Guid RES_BLD_Building_RefID { get; set; }
        [DataMember]
        public Guid QuestionnaireVersion_RefID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DueDiligences(,P_L5DD_SDD_0945 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DueDiligences.Invoke(connectionString,P_L5DD_SDD_0945 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_DueDiligences.Atomic.Manipulation.P_L5DD_SDD_0945();
parameter.Revisions = ...;

parameter.RevisionGroup_Name = ...;
parameter.RevisionGroup_Description = ...;
parameter.RevisionGroup_SubmittedBy_Account_RefID = ...;
parameter.RES_DUD_Revision_GroupID = ...;
parameter.RealestateProperty_RefID = ...;

*/