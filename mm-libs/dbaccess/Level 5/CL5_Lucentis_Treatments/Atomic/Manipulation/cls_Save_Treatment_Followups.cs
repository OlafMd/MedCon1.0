/* 
 * Generated on 7/8/2013 11:13:03 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL1_HEC;

namespace CL5_Lucentis_Treatments.Atomic.Manipulation
{
	[Serializable]
	public class cls_Save_Treatment_Followups
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5TR_STF_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var item = new ORM_HEC_Patient_Treatment();
            if (Parameter.HEC_Patient_TreatmentID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.HEC_Patient_TreatmentID);
                if (result.Status != FR_Status.Success || item.HEC_Patient_TreatmentID == Guid.Empty)
                {
                    //Item doesn't exist, create it
                    Parameter.HEC_Patient_TreatmentID = Guid.Empty;

                    if (Parameter.IsDeleted)
                        return returnValue;
                }
            }

            if (Parameter.IsDeleted == true)
            {

                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.HEC_Patient_TreatmentID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.HEC_Patient_TreatmentID == Guid.Empty)
            {
                item.HEC_Patient_TreatmentID = Guid.NewGuid();
                item.Tenant_RefID = securityTicket.TenantID;

            }

            item.TreatmentPractice_RefID = Parameter.TreatmentPractice_RefID;
            item.IsTreatmentPerformed = Parameter.IsTreatmentPerformed;
            item.IfTreatmentPerformed_ByDoctor_RefID = Parameter.IfTreatmentPerformed_ByDoctor_RefID;
            item.IfTreatmentPerformed_Date = Parameter.IfTreatmentPerformed_Date;
            item.IsTreatmentFollowup = Parameter.IsTreatmentFollowup;
            item.IfTreatmentFollowup_FromTreatment_RefID = Parameter.IfTreatmentFollowup_FromTreatment_RefID;
            item.IsScheduled = Parameter.IsScheduled;
            item.IfSheduled_Date = Parameter.IfSheduled_Date;
            item.IfSheduled_ForDoctor_RefID = Parameter.IfSheduled_ForDoctor_RefID;
            item.IsTreatmentBilled = Parameter.IsTreatmentBilled;
            item.IfTreatmentBilled_Date = Parameter.IfTreatmentBilled_Date;
            item.Treatment_Comment = Parameter.Treatment_Comment;

            return new FR_Guid(item.Save(Connection, Transaction), item.HEC_Patient_TreatmentID);

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5TR_STF_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5TR_STF_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TR_STF_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TR_STF_1712 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L5TR_STF_1712 for attribute P_L5TR_STF_1712
		[Serializable]
		public class P_L5TR_STF_1712 
		{
			//Standard type parameters
			public Guid HEC_Patient_TreatmentID; 
			public Guid TreatmentPractice_RefID; 
			public Guid Patient_RefID; 
			public Boolean IsTreatmentPerformed; 
			public Guid IfTreatmentPerformed_ByDoctor_RefID; 
			public DateTime IfTreatmentPerformed_Date; 
			public Boolean IsTreatmentFollowup; 
			public Guid IfTreatmentFollowup_FromTreatment_RefID; 
			public Boolean IsScheduled; 
			public DateTime IfSheduled_Date; 
			public Boolean IsTreatmentBilled; 
			public DateTime IfTreatmentBilled_Date; 
			public Guid IfSheduled_ForDoctor_RefID; 
			public String Treatment_Comment; 
			public Boolean IsDeleted; 

		}
		#endregion

	#endregion
}
