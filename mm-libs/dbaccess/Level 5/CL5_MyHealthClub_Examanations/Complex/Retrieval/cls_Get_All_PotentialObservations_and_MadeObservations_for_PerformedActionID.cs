/* 
 * Generated on 1/23/2015 14:46:15
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
using CL1_HEC;
using CL1_HEC_ACT;
namespace CL5_MyHealthClub_Examinations.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_PotentialObservations_and_MadeObservations_for_PerformedActionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_PotentialObservations_and_MadeObservations_for_PerformedActionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EX_GAPOaMOfPAID_1639 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_GAPOaMOfPAID_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5EX_GAPOaMOfPAID_1639();
			//Put your code here
             L5EX_GAPOaMOfPAID_1639 madeAndPotentialObservations = new L5EX_GAPOaMOfPAID_1639();
            var allPotentialObservations = ORM_HEC_PotentialObservation.Query.Search(Connection, Transaction, new ORM_HEC_PotentialObservation.Query()
            {
                IsDeleted=false,
                Tenant_RefID = securityTicket.TenantID
            }).ToArray();
            var madeObservationsForPerformedActionID = ORM_HEC_ACT_PerformedAction_MadeObservation.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction_MadeObservation.Query()
            {
                IsDeleted=false,
                Tenant_RefID = securityTicket.TenantID,
                HEC_ACT_PerformedAction_RefID=Parameter.PerformedActionID
            }).ToArray();

            List<L5EX_GAPOaMOfPAID_1639MadeObservations> madeObservations = new List<L5EX_GAPOaMOfPAID_1639MadeObservations>();
            foreach (var observation in madeObservationsForPerformedActionID)
            {
                L5EX_GAPOaMOfPAID_1639MadeObservations newObservation = new L5EX_GAPOaMOfPAID_1639MadeObservations();
                newObservation.Comment = observation.Comment;
                newObservation.PotentialObservationRef_ID = observation.PotentialObservation_RefID;
                madeObservations.Add(newObservation);
            }

            madeAndPotentialObservations.MadeObservations = madeObservations.ToArray();
            madeAndPotentialObservations.PotentialObservations = allPotentialObservations.ToArray();
            returnValue.Result= madeAndPotentialObservations;
			return returnValue;

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EX_GAPOaMOfPAID_1639 Invoke(string ConnectionString,P_L5EX_GAPOaMOfPAID_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EX_GAPOaMOfPAID_1639 Invoke(DbConnection Connection,P_L5EX_GAPOaMOfPAID_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EX_GAPOaMOfPAID_1639 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_GAPOaMOfPAID_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EX_GAPOaMOfPAID_1639 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_GAPOaMOfPAID_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EX_GAPOaMOfPAID_1639 functionReturn = new FR_L5EX_GAPOaMOfPAID_1639();
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

				throw new Exception("Exception occured in method cls_Get_All_PotentialObservations_and_MadeObservations_for_PerformedActionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EX_GAPOaMOfPAID_1639 : FR_Base
	{
		public L5EX_GAPOaMOfPAID_1639 Result	{ get; set; }

		public FR_L5EX_GAPOaMOfPAID_1639() : base() {}

		public FR_L5EX_GAPOaMOfPAID_1639(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EX_GAPOaMOfPAID_1639 for attribute P_L5EX_GAPOaMOfPAID_1639
		[DataContract]
		public class P_L5EX_GAPOaMOfPAID_1639 
		{
			//Standard type parameters
			[DataMember]
			public Guid PerformedActionID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L5EX_GAPOaMOfPAID_1639 for attribute L5EX_GAPOaMOfPAID_1639
		[DataContract]
		public class L5EX_GAPOaMOfPAID_1639 
		{
			[DataMember]
			public L5EX_GAPOaMOfPAID_1639MadeObservations[] MadeObservations { get; set; }
			[DataMember]
			public ORM_HEC_PotentialObservation[] PotentialObservations { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5EX_GAPOaMOfPAID_1639MadeObservations for attribute MadeObservations
		[DataContract]
		public class L5EX_GAPOaMOfPAID_1639MadeObservations 
		{
			//Standard type parameters
			[DataMember]
			public Guid PotentialObservationRef_ID { get; set; } 
			[DataMember]
			public String Comment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EX_GAPOaMOfPAID_1639 cls_Get_All_PotentialObservations_and_MadeObservations_for_PerformedActionID(,P_L5EX_GAPOaMOfPAID_1639 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EX_GAPOaMOfPAID_1639 invocationResult = cls_Get_All_PotentialObservations_and_MadeObservations_for_PerformedActionID.Invoke(connectionString,P_L5EX_GAPOaMOfPAID_1639 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Examinations.Complex.Retrieval.P_L5EX_GAPOaMOfPAID_1639();
parameter.PerformedActionID = ...;
parameter.PatientID = ...;

*/
