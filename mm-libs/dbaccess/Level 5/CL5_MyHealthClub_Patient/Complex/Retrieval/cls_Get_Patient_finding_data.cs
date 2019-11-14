/* 
 * Generated on 12/26/2014 1:08:26 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL3_Offices.Atomic.Retrieval;
using CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval;
using CL5_MyHealthClub_Patient.Atomic.Retrieval;
using CL5_MyHealthClub_OrgUnits.Atomic.Retrieval;

namespace CL5_MyHealthClub_Patient.Complex.Retrieval
{
	[Serializable]
	public class cls_Get_Patient_finding_data
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PA_GPFD_1252 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_GPFD_1252 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PA_GPFD_1252();
            returnValue.Result = new L5PA_GPFD_1252();
            returnValue.Result.static_data = new L5PA_GPFD_1252_StaticData();

            returnValue.Result.static_data.Practices = cls_Get_AllOfficess_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result.Where(i=>i.IsMedicalPractice==true).ToArray();
            returnValue.Result.static_data.Doctors = cls_Get_Doctors_for_PracticeID.Invoke(Connection, Transaction, new P_L5DO_GDfPID_1316 { OfficeID = returnValue.Result.static_data.Practices[0].OfficeID }, securityTicket).Result;
            returnValue.Result.static_data.ReferalType = cls_Get_MedicalPracticeTypes_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            returnValue.Result.Findings = cls_Get_PatientFindings.Invoke(Connection, Transaction, new P_L5PA_GPF_1649 { PatientID = Parameter.PatientID}, securityTicket).Result;
            returnValue.Result.static_data.ReferalPractices = cls_Get_ReferalPractices_BaseData.Invoke(Connection, Transaction, securityTicket).Result;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PA_GPFD_1252 Invoke(string ConnectionString,P_L5PA_GPFD_1252 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_GPFD_1252 Invoke(DbConnection Connection,P_L5PA_GPFD_1252 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_GPFD_1252 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_GPFD_1252 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_GPFD_1252 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_GPFD_1252 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_GPFD_1252 functionReturn = new FR_L5PA_GPFD_1252();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L5PA_GPFD_1252 : FR_Base
	{
		public L5PA_GPFD_1252 Result	{ get; set; }

		public FR_L5PA_GPFD_1252() : base() {}

		public FR_L5PA_GPFD_1252(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PA_GPFD_1252 for attribute P_L5PA_GPFD_1252
		[Serializable]
		public class P_L5PA_GPFD_1252 
		{
			//Standard type parameters
			public Guid PatientID; 

		}
		#endregion
		#region SClass L5PA_GPFD_1252 for attribute L5PA_GPFD_1252
		[Serializable]
		public class L5PA_GPFD_1252 
		{
			public L5PA_GPFD_1252_StaticData static_data;  

			//Standard type parameters
			public L5PA_GPF_1649[] Findings; 

		}
		#endregion
		#region SClass L5PA_GPFD_1252_StaticData for attribute static_data
		[Serializable]
		public class L5PA_GPFD_1252_StaticData 
		{
			//Standard type parameters
			public L3O_GAOfTID_0911[] Practices; 
			public L5DO_GDfPID_1316[] Doctors; 
			public L3O_GMPTFTID_1640[] ReferalType; 
			public L5OU_GRPBD_1305[] ReferalPractices; 

		}
		#endregion

	#endregion
}
