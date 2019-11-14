/* 
 * Generated on 12/15/2014 11:46:01 AM
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
using CL1_HEC_DIA;

namespace CL5_MyHealthClub_Diagnosis.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PotentialProcedures.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PotentialProcedures
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_SPP_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guids();
			//Put your code here
            List<Guid> resultID = new List<Guid>();
            foreach (var procedureParam in Parameter.PotentialProcedures)
            {
                ORM_HEC_DIA_TypicalPotentialProcedure typicalPotentialProcedure = ORM_HEC_DIA_TypicalPotentialProcedure.Query.Search(Connection, Transaction, new ORM_HEC_DIA_TypicalPotentialProcedure.Query
                {
                    HEC_DIA_TypicalPotentialProcedureID = procedureParam.HEC_DIA_TypicalPotentialProcedureID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).SingleOrDefault();

                if (!procedureParam.IsDeleted)
                {
                    if (typicalPotentialProcedure == null)
                    {
                        typicalPotentialProcedure = new ORM_HEC_DIA_TypicalPotentialProcedure();
                        typicalPotentialProcedure.HEC_DIA_TypicalPotentialProcedureID = procedureParam.HEC_DIA_TypicalPotentialProcedureID;
                    }
                    typicalPotentialProcedure.PotentialDiagnosis_RefID = procedureParam.PotentialDiagnosis_RefID;
                    typicalPotentialProcedure.PotentialProcedure_RefID = procedureParam.PotentialProcedure_RefID;
                    typicalPotentialProcedure.IsDeleted = false;
                    typicalPotentialProcedure.Tenant_RefID = securityTicket.TenantID;
                    typicalPotentialProcedure.Save(Connection, Transaction);
                    resultID.Add(typicalPotentialProcedure.HEC_DIA_TypicalPotentialProcedureID);
                }
                else if (typicalPotentialProcedure != null && procedureParam.IsDeleted)
                {
                    typicalPotentialProcedure.IsDeleted = true;
                    typicalPotentialProcedure.Save(Connection, Transaction);
                    resultID.Add(typicalPotentialProcedure.HEC_DIA_TypicalPotentialProcedureID);
                }
            }
            returnValue.Result = resultID.ToArray();


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L5DI_SPP_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5DI_SPP_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_SPP_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_SPP_1242 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guids functionReturn = new FR_Guids();
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

				throw new Exception("Exception occured in method cls_Save_PotentialProcedures",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DI_SPP_1242 for attribute P_L5DI_SPP_1242
		[DataContract]
		public class P_L5DI_SPP_1242 
		{
			[DataMember]
			public P_L5DI_SPP_1242_PotentialProcedures[] PotentialProcedures { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5DI_SPP_1242_PotentialProcedures for attribute PotentialProcedures
		[DataContract]
		public class P_L5DI_SPP_1242_PotentialProcedures 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_TypicalPotentialProcedureID { get; set; } 
			[DataMember]
			public Guid PotentialDiagnosis_RefID { get; set; } 
			[DataMember]
			public Guid PotentialProcedure_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Save_PotentialProcedures(,P_L5DI_SPP_1242 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Save_PotentialProcedures.Invoke(connectionString,P_L5DI_SPP_1242 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Diagnosis.Atomic.Manipulation.P_L5DI_SPP_1242();
parameter.PotentialProcedures = ...;


*/
