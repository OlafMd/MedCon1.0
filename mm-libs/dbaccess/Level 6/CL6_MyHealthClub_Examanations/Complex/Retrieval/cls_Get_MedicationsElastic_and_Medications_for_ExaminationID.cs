/* 
 * Generated on 2/13/2015 12:16:15
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
using CL5_MyHealthClub_MedProCommunity.Atomic.Retrieval;
using CL5_MyHealthClub_EMR.Atomic.Retrieval;
using CL1_CMN;
using CL1_HEC;

namespace CL6_MyHealthClub_Examanations.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_MedicationsElastic_and_Medications_for_ExaminationID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [ Serializable]
	public class cls_Get_MedicationsElastic_and_Medications_for_ExaminationID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6EX_GMEaMfEID_1340 Execute(DbConnection Connection,DbTransaction Transaction,P_L6EX_GMEaMfEID_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6EX_GMEaMfEID_1340();
			//Put your code here
            //P_L5MPC_GAPaASE_1022 medicationsElasticParam = new P_L5MPC_GAPaASE_1022();
            //medicationsElasticParam.is_substance_count = Parameter.is_substance_count;
            //medicationsElasticParam.number_of_elements = Parameter.number_of_elements;
            //medicationsElasticParam.search_params = Parameter.search_params.ToString();
            //medicationsElasticParam.sort_by = Parameter.sort_by.ToString();
            //medicationsElasticParam.sort_order = Parameter.sort_order.ToString();
            //medicationsElasticParam.start_row_index = Parameter.start_row_index;

            //var elasticResult = cls_Get_AllProducts_and_AllSupstances_Elastic.Invoke(Connection, Transaction, medicationsElasticParam,securityTicket).Result;
            //returnValue.Result = new L6EX_GMEaMfEID_1340();
            //returnValue.Result.medications = elasticResult;
            P_L5ME_GMIfEID_1534 patientMedicationsParameter = new P_L5ME_GMIfEID_1534();
            patientMedicationsParameter.PerformedActionID = Parameter.ExaminationID;
            var patientMedications = cls_Get_MedicationInfo_for_ExaminationID.Invoke(Connection, Transaction, patientMedicationsParameter, securityTicket).Result;
            returnValue.Result.patientMedications = new List<L5ME_GMIfEID_1534>().ToArray();
            returnValue.Result.patientMedications = patientMedications;
            P_L5EMR_GSfEID_1210 substancesparameter= new P_L5EMR_GSfEID_1210();
            substancesparameter.PerformedActionID = Parameter.ExaminationID;
            var patientSubstances = cls_Get_Substances_for_ExaminationID.Invoke(Connection, Transaction, substancesparameter, securityTicket).Result;
            returnValue.Result.patientSubstances = new List<L5EMR_GSfEID_1210>().ToArray();
            returnValue.Result.patientSubstances = patientSubstances;

            var units = ORM_CMN_Unit.Query.Search(Connection, Transaction, new ORM_CMN_Unit.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Select(unit => new
            {
                ID = unit.CMN_UnitID,
                ISOCode = unit.ISOCode,
                Label = unit.Label
            });

            List<L6EX_GMEaMfEID_1340Units> UnitsPrepacked = new List<L6EX_GMEaMfEID_1340Units>();
            foreach (var unit in units)
            {
                L6EX_GMEaMfEID_1340Units Unit = new L6EX_GMEaMfEID_1340Units();
                Unit.ISOCode = unit.ISOCode;
                Unit.UnitID = unit.ID;
                Unit.UnitLabel = unit.Label;
                UnitsPrepacked.Add(Unit);
            }

            var dosagesForTenant = ORM_HEC_Dosage.Query.Search(Connection, Transaction, new ORM_HEC_Dosage.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            List<L6EX_GMEaMfEID_1340Dosages> dosages = new List<L6EX_GMEaMfEID_1340Dosages>();
            foreach (var dosage in dosagesForTenant)
            {
                L6EX_GMEaMfEID_1340Dosages Dosage = new L6EX_GMEaMfEID_1340Dosages();
                Dosage.DosageID = dosage.HEC_DosageID;
                Dosage.DosageName = dosage.DosageText;
                dosages.Add(Dosage);
            }
            returnValue.Result.units = new List<L6EX_GMEaMfEID_1340Units>().ToArray();
            returnValue.Result.units = UnitsPrepacked.ToArray();
            returnValue.Result.dosages = new List<L6EX_GMEaMfEID_1340Dosages>().ToArray();
            returnValue.Result.dosages = dosages.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6EX_GMEaMfEID_1340 Invoke(string ConnectionString,P_L6EX_GMEaMfEID_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6EX_GMEaMfEID_1340 Invoke(DbConnection Connection,P_L6EX_GMEaMfEID_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6EX_GMEaMfEID_1340 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6EX_GMEaMfEID_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6EX_GMEaMfEID_1340 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6EX_GMEaMfEID_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6EX_GMEaMfEID_1340 functionReturn = new FR_L6EX_GMEaMfEID_1340();
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

				throw new Exception("Exception occured in method cls_Get_MedicationsElastic_and_Medications_for_ExaminationID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6EX_GMEaMfEID_1340 : FR_Base
	{
		public L6EX_GMEaMfEID_1340 Result	{ get; set; }

		public FR_L6EX_GMEaMfEID_1340() : base() {}

		public FR_L6EX_GMEaMfEID_1340(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6EX_GMEaMfEID_1340 for attribute P_L6EX_GMEaMfEID_1340
		[ Serializable]
		public class P_L6EX_GMEaMfEID_1340 
		{
			//Standard type parameters
			  
			public Guid ExaminationID { get; set; } 
			  
			public int start_row_index { get; set; } 
			  
			public int number_of_elements { get; set; } 
			  
			public String sort_by { get; set; } 
			  
			public String sort_order { get; set; } 
			  
			public String search_params { get; set; } 
			  
			public bool is_substance_count { get; set; } 

		}
		#endregion
		#region SClass L6EX_GMEaMfEID_1340 for attribute L6EX_GMEaMfEID_1340
		[ Serializable]
		public class L6EX_GMEaMfEID_1340 
		{
              
            //public L5MPC_GAPaASE_1022 medications { get; set; }
			  
			public L5ME_GMIfEID_1534[] patientMedications { get; set; }
			  
			public L5EMR_GSfEID_1210[] patientSubstances { get; set; }
			  
			public L6EX_GMEaMfEID_1340Dosages[] dosages { get; set; }
			  
			public L6EX_GMEaMfEID_1340Units[] units { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L6EX_GMEaMfEID_1340Dosages for attribute dosages
		[ Serializable]
		public class L6EX_GMEaMfEID_1340Dosages 
		{
			//Standard type parameters
			  
			public String DosageName { get; set; } 
			  
			public Guid DosageID { get; set; } 

		}
		#endregion
		#region SClass L6EX_GMEaMfEID_1340Units for attribute units
		[ Serializable]
		public class L6EX_GMEaMfEID_1340Units 
		{
			//Standard type parameters
			  
			public Guid UnitID { get; set; } 
			  
			public String ISOCode { get; set; } 
			  
			public Dict UnitLabel { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6EX_GMEaMfEID_1340 cls_Get_MedicationsElastic_and_Medications_for_ExaminationID(,P_L6EX_GMEaMfEID_1340 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6EX_GMEaMfEID_1340 invocationResult = cls_Get_MedicationsElastic_and_Medications_for_ExaminationID.Invoke(connectionString,P_L6EX_GMEaMfEID_1340 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Examanations.Complex.Retrieval.P_L6EX_GMEaMfEID_1340();
parameter.ExaminationID = ...;
parameter.start_row_index = ...;
parameter.number_of_elements = ...;
parameter.sort_by = ...;
parameter.sort_order = ...;
parameter.search_params = ...;
parameter.is_substance_count = ...;

*/
