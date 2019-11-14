/* 
 * Generated on 10/3/2014 3:15:48 PM
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
using CL1_HEC;

namespace CL5_MyHealthClub_Diagnosis.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PotentialObservation.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PotentialObservation
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_SPO_1452 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guids();
			//Put your code here

            List<Guid> resultID = new List<Guid>();
            foreach (var observationParam in Parameter.PotentialObservation)
            {
                ORM_HEC_DIA_TypicalPotentialObservation typicalPotentialObservation = ORM_HEC_DIA_TypicalPotentialObservation.Query.Search(Connection,Transaction, new ORM_HEC_DIA_TypicalPotentialObservation.Query{
                    HEC_DIA_TypicalPotentialObservationID = observationParam.TypicalPotentialObservationID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).SingleOrDefault();
                if (!observationParam.IsDeleted)
                {
                    if (observationParam.NewPotentialObservation)
                    {
                        ORM_HEC_PotentialObservation potentialObservation = new ORM_HEC_PotentialObservation();
                        potentialObservation.HEC_PotentialObservationID = observationParam.PotentialObservationID;
                        potentialObservation.Observation_Text = observationParam.Observation_Text;
                        potentialObservation.IsDeleted = false;
                        potentialObservation.Tenant_RefID = securityTicket.TenantID;
                        potentialObservation.Save(Connection, Transaction);
                    }
                    if (typicalPotentialObservation == null)
                    {
                        typicalPotentialObservation = new ORM_HEC_DIA_TypicalPotentialObservation();
                        typicalPotentialObservation.HEC_DIA_TypicalPotentialObservationID = observationParam.TypicalPotentialObservationID;
                    }
                    typicalPotentialObservation.PotentialDiagnosis_RefID = observationParam.PotentialDiagnosis_RefID;
                    typicalPotentialObservation.PotentialObservation_RefID = observationParam.PotentialObservationID;
                    typicalPotentialObservation.IsDeleted = false;
                    typicalPotentialObservation.Tenant_RefID = securityTicket.TenantID;
                    typicalPotentialObservation.Save(Connection, Transaction);
                    resultID.Add(typicalPotentialObservation.HEC_DIA_TypicalPotentialObservationID);
                }
                else if (typicalPotentialObservation != null && observationParam.IsDeleted)
                {
                    typicalPotentialObservation.IsDeleted = true;
                    typicalPotentialObservation.Save(Connection, Transaction);
                    resultID.Add(typicalPotentialObservation.HEC_DIA_TypicalPotentialObservationID);
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
		public static FR_Guids Invoke(string ConnectionString,P_L5DI_SPO_1452 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5DI_SPO_1452 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_SPO_1452 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_SPO_1452 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_PotentialObservation",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DI_SPO_1452 for attribute P_L5DI_SPO_1452
		[DataContract]
		public class P_L5DI_SPO_1452 
		{
			[DataMember]
			public P_L5DI_SPO_1452_PotentialObservation[] PotentialObservation { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5DI_SPO_1452_PotentialObservation for attribute PotentialObservation
		[DataContract]
		public class P_L5DI_SPO_1452_PotentialObservation 
		{
			//Standard type parameters
			[DataMember]
			public Guid TypicalPotentialObservationID { get; set; } 
			[DataMember]
			public Guid PotentialObservationID { get; set; } 
			[DataMember]
			public Guid PotentialDiagnosis_RefID { get; set; } 
			[DataMember]
			public Dict Observation_Text { get; set; } 
			[DataMember]
			public bool NewPotentialObservation { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Save_PotentialObservation(,P_L5DI_SPO_1452 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Save_PotentialObservation.Invoke(connectionString,P_L5DI_SPO_1452 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Diagnosis.Atomic.Manipulation.P_L5DI_SPO_1452();
parameter.PotentialObservation = ...;


*/
