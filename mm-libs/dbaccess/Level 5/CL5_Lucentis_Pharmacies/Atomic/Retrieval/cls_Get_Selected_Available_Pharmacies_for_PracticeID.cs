/* 
 * Generated on 8/13/2013 4:46:44 PM
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

namespace CL5_Lucentis_Pharmacies.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Selected_Available_Pharmacies_for_PracticeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Selected_Available_Pharmacies_for_PracticeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PH_GPSAPfPID_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PH_GPSAPfPID Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PH_GPSAPfPID_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Pharmacies.Atomic.Retrieval.SQL.cls_Get_Selected_Available_Pharmacies_for_PracticeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PracticeID", Parameter.PracticeID);


			List<L5PH_GPSAPfPID_raw> results = new List<L5PH_GPSAPfPID_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Pharmacy_RefID","HEC_MedicalPractise_AvailablePharmaciesForOrderingID" });
				while(reader.Read())
				{
					L5PH_GPSAPfPID_raw resultItem = new L5PH_GPSAPfPID_raw();
					//0:Parameter HEC_Pharmacy_RefID of type Guid
					resultItem.HEC_Pharmacy_RefID = reader.GetGuid(0);
					//1:Parameter HEC_MedicalPractise_AvailablePharmaciesForOrderingID of type Guid
					resultItem.HEC_MedicalPractise_AvailablePharmaciesForOrderingID = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5PH_GPSAPfPID_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PH_GPSAPfPID_Array Invoke(string ConnectionString,P_L5PH_GPSAPfPID Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PH_GPSAPfPID_Array Invoke(DbConnection Connection,P_L5PH_GPSAPfPID Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PH_GPSAPfPID_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PH_GPSAPfPID Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PH_GPSAPfPID_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PH_GPSAPfPID Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PH_GPSAPfPID_Array functionReturn = new FR_L5PH_GPSAPfPID_Array();
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

	#region Raw Grouping Class
	[Serializable]
	public class L5PH_GPSAPfPID_raw 
	{
		public Guid HEC_Pharmacy_RefID; 
		public Guid HEC_MedicalPractise_AvailablePharmaciesForOrderingID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5PH_GPSAPfPID[] Convert(List<L5PH_GPSAPfPID_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5PH_GPSAPfPID in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_MedicalPractise_AvailablePharmaciesForOrderingID)).ToArray()
	group el_L5PH_GPSAPfPID by new 
	{ 
		el_L5PH_GPSAPfPID.HEC_MedicalPractise_AvailablePharmaciesForOrderingID,

	}
	into gfunct_L5PH_GPSAPfPID
	select new L5PH_GPSAPfPID
	{     
		HEC_Pharmacy_RefID = gfunct_L5PH_GPSAPfPID.FirstOrDefault().HEC_Pharmacy_RefID ,
		HEC_MedicalPractise_AvailablePharmaciesForOrderingID = gfunct_L5PH_GPSAPfPID.Key.HEC_MedicalPractise_AvailablePharmaciesForOrderingID ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5PH_GPSAPfPID_Array : FR_Base
	{
		public L5PH_GPSAPfPID[] Result	{ get; set; } 
		public FR_L5PH_GPSAPfPID_Array() : base() {}

		public FR_L5PH_GPSAPfPID_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PH_GPSAPfPID for attribute P_L5PH_GPSAPfPID
		[DataContract]
		public class P_L5PH_GPSAPfPID 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 

		}
		#endregion
		#region SClass L5PH_GPSAPfPID for attribute L5PH_GPSAPfPID
		[DataContract]
		public class L5PH_GPSAPfPID 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Pharmacy_RefID { get; set; } 
			[DataMember]
			public Guid HEC_MedicalPractise_AvailablePharmaciesForOrderingID { get; set; } 

		}
		#endregion

	#endregion
}
