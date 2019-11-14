/* 
 * Generated on 10.03.2014 14:38:27
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

namespace CL5_Lucentis_Treatments.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Treatment_and_HealthInsuranceCompanu_for_TreatmentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Treatment_and_HealthInsuranceCompanu_for_TreatmentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TR_GTHITID_1730_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5TR_GTHITID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TR_GTHITID_1730_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Treatments.Atomic.Retrieval.SQL.cls_Get_Treatment_and_HealthInsuranceCompanu_for_TreatmentID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@TreatmentID"," IN $$TreatmentID$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$TreatmentID$",Parameter.TreatmentID);


			List<L5TR_GTHITID_1730_raw> results = new List<L5TR_GTHITID_1730_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_TreatmentID","HealthInsurance_IKNumber","HIS_HealthInsurance_Company_RefID" });
				while(reader.Read())
				{
					L5TR_GTHITID_1730_raw resultItem = new L5TR_GTHITID_1730_raw();
					//0:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(0);
					//1:Parameter HealthInsurance_IKNumber of type string
					resultItem.HealthInsurance_IKNumber = reader.GetString(1);
					//2:Parameter HIS_HealthInsurance_Company_RefID of type Guid
					resultItem.HIS_HealthInsurance_Company_RefID = reader.GetGuid(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Treatment_and_HealthInsuranceCompanu_for_TreatmentID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5TR_GTHITID_1730_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TR_GTHITID_1730_Array Invoke(string ConnectionString,P_L5TR_GTHITID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TR_GTHITID_1730_Array Invoke(DbConnection Connection,P_L5TR_GTHITID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TR_GTHITID_1730_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TR_GTHITID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TR_GTHITID_1730_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TR_GTHITID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TR_GTHITID_1730_Array functionReturn = new FR_L5TR_GTHITID_1730_Array();
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

				throw new Exception("Exception occured in method cls_Get_Treatment_and_HealthInsuranceCompanu_for_TreatmentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5TR_GTHITID_1730_raw 
	{
		public Guid HEC_Patient_TreatmentID; 
		public string HealthInsurance_IKNumber; 
		public Guid HIS_HealthInsurance_Company_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5TR_GTHITID_1730[] Convert(List<L5TR_GTHITID_1730_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5TR_GTHITID_1730 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_TreatmentID)).ToArray()
	group el_L5TR_GTHITID_1730 by new 
	{ 
		el_L5TR_GTHITID_1730.HEC_Patient_TreatmentID,

	}
	into gfunct_L5TR_GTHITID_1730
	select new L5TR_GTHITID_1730
	{     
		HEC_Patient_TreatmentID = gfunct_L5TR_GTHITID_1730.Key.HEC_Patient_TreatmentID ,
		HealthInsurance_IKNumber = gfunct_L5TR_GTHITID_1730.FirstOrDefault().HealthInsurance_IKNumber ,
		HIS_HealthInsurance_Company_RefID = gfunct_L5TR_GTHITID_1730.FirstOrDefault().HIS_HealthInsurance_Company_RefID ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5TR_GTHITID_1730_Array : FR_Base
	{
		public L5TR_GTHITID_1730[] Result	{ get; set; } 
		public FR_L5TR_GTHITID_1730_Array() : base() {}

		public FR_L5TR_GTHITID_1730_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5TR_GTHITID_1730 for attribute P_L5TR_GTHITID_1730
		[DataContract]
		public class P_L5TR_GTHITID_1730 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] TreatmentID { get; set; } 

		}
		#endregion
		#region SClass L5TR_GTHITID_1730 for attribute L5TR_GTHITID_1730
		[DataContract]
		public class L5TR_GTHITID_1730 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public string HealthInsurance_IKNumber { get; set; } 
			[DataMember]
			public Guid HIS_HealthInsurance_Company_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TR_GTHITID_1730_Array cls_Get_Treatment_and_HealthInsuranceCompanu_for_TreatmentID(,P_L5TR_GTHITID_1730 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TR_GTHITID_1730_Array invocationResult = cls_Get_Treatment_and_HealthInsuranceCompanu_for_TreatmentID.Invoke(connectionString,P_L5TR_GTHITID_1730 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Treatments.Atomic.Retrieval.P_L5TR_GTHITID_1730();
parameter.TreatmentID = ...;

*/
