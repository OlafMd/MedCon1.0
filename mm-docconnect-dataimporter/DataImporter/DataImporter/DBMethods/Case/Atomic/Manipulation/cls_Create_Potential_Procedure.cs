/* 
 * Generated on 06/30/15 17:34:11
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
using CL1_HEC_TRE;

namespace DataImporter.DBMethods.Case.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_Potential_Procedure.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Potential_Procedure
	{
        public static readonly int QueryTimeout = 360;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            #region POTENTIAL PROCEDURE

            ORM_HEC_TRE_PotentialProcedure_Package.Query intraocular_procedure_packageQ = new ORM_HEC_TRE_PotentialProcedure_Package.Query();
            intraocular_procedure_packageQ.Tenant_RefID = securityTicket.TenantID;
            intraocular_procedure_packageQ.GlobalPropertyMatchingID = "mm.docconect.doc.app.intraocular.package";
            intraocular_procedure_packageQ.IsDeleted = false;

            var intraocular_procedure_package = ORM_HEC_TRE_PotentialProcedure_Package.Query.Search(Connection, Transaction, intraocular_procedure_packageQ).SingleOrDefault();

            if (intraocular_procedure_package == null)
            {
                intraocular_procedure_package = new ORM_HEC_TRE_PotentialProcedure_Package();
                intraocular_procedure_package.GlobalPropertyMatchingID = "mm.docconect.doc.app.intraocular.package";
                intraocular_procedure_package.Tenant_RefID = securityTicket.TenantID;
                intraocular_procedure_package.IsDeleted = false;
                intraocular_procedure_package.Creation_Timestamp = DateTime.Now;
                intraocular_procedure_package.Modification_Timestamp = DateTime.Now;
                intraocular_procedure_package.HEC_TRE_PotentialProcedure_PackageID = Guid.NewGuid();

                intraocular_procedure_package.Save(Connection, Transaction);
            }

            ORM_HEC_TRE_PotentialProcedure_2_ProcedurePackage.Query procedure_2_packageQ = new ORM_HEC_TRE_PotentialProcedure_2_ProcedurePackage.Query();
            procedure_2_packageQ.HEC_TRE_PotentialProcedure_Package_RefID = intraocular_procedure_package.HEC_TRE_PotentialProcedure_PackageID;
            procedure_2_packageQ.Tenant_RefID = securityTicket.TenantID;
            procedure_2_packageQ.IsDeleted = false;

            var procedure_2_package = ORM_HEC_TRE_PotentialProcedure_2_ProcedurePackage.Query.Search(Connection, Transaction, procedure_2_packageQ).SingleOrDefault();
            if (procedure_2_package == null)
            {
                ORM_HEC_TRE_PotentialProcedure intraocular_procedure = new ORM_HEC_TRE_PotentialProcedure();
                intraocular_procedure.Creation_Timestamp = DateTime.Now;
                intraocular_procedure.HEC_TRE_PotentialProcedureID = Guid.NewGuid();
                intraocular_procedure.Modification_Timestamp = DateTime.Now;
                intraocular_procedure.Tenant_RefID = securityTicket.TenantID;

                returnValue.Result = intraocular_procedure.HEC_TRE_PotentialProcedureID;

                intraocular_procedure.Save(Connection, Transaction);

                procedure_2_package = new ORM_HEC_TRE_PotentialProcedure_2_ProcedurePackage();
                procedure_2_package.HEC_TRE_PotentialProcedure_Package_RefID = intraocular_procedure_package.HEC_TRE_PotentialProcedure_PackageID;
                procedure_2_package.HEC_TRE_PotentialProcedure_RefID = intraocular_procedure.HEC_TRE_PotentialProcedureID;
                procedure_2_package.Tenant_RefID = securityTicket.TenantID;
                procedure_2_package.Creation_Timestamp = DateTime.Now;
                procedure_2_package.AssignmentID = Guid.NewGuid();

                procedure_2_package.Save(Connection, Transaction);
            }
            else
            {
                ORM_HEC_TRE_PotentialProcedure.Query intraocular_procedureQ = new ORM_HEC_TRE_PotentialProcedure.Query();
                intraocular_procedureQ.Tenant_RefID = securityTicket.TenantID;
                intraocular_procedureQ.IsDeleted = false;
                intraocular_procedureQ.HEC_TRE_PotentialProcedureID = procedure_2_package.HEC_TRE_PotentialProcedure_RefID;

                var intraocular_procedure = ORM_HEC_TRE_PotentialProcedure.Query.Search(Connection, Transaction, intraocular_procedureQ).SingleOrDefault();
                if (intraocular_procedure != null)
                {
                    returnValue.Result = intraocular_procedure.HEC_TRE_PotentialProcedureID;
                }
                else
                {
                    intraocular_procedure.Creation_Timestamp = DateTime.Now;
                    intraocular_procedure.HEC_TRE_PotentialProcedureID = Guid.NewGuid();
                    intraocular_procedure.Modification_Timestamp = DateTime.Now;
                    intraocular_procedure.Tenant_RefID = securityTicket.TenantID;

                    returnValue.Result = intraocular_procedure.HEC_TRE_PotentialProcedureID;

                    intraocular_procedure.Save(Connection, Transaction);
                    procedure_2_package.HEC_TRE_PotentialProcedure_Package_RefID = intraocular_procedure_package.HEC_TRE_PotentialProcedure_PackageID;
                    procedure_2_package.HEC_TRE_PotentialProcedure_RefID = intraocular_procedure.HEC_TRE_PotentialProcedureID;
                    procedure_2_package.Tenant_RefID = securityTicket.TenantID;
                    procedure_2_package.Creation_Timestamp = DateTime.Now;
                    procedure_2_package.AssignmentID = Guid.NewGuid();

                    procedure_2_package.Save(Connection, Transaction);
                }
            }
            #endregion POTENTIAL PROCEDURE
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Create_Potential_Procedure",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_Potential_Procedure(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_Potential_Procedure.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

