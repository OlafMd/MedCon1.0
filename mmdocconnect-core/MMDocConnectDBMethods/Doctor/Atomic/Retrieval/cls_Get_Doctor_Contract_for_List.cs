/* 
 * Generated on 10/22/15 17:52:15
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

namespace MMDocConnectDBMethods.Doctor.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Doctor_Contract_for_List.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_Contract_for_List
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GDfCL_0902_Array Execute(DbConnection Connection,DbTransaction Transaction,P_DO_GDfCL_0902 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GDfCL_0902_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Doctor.Atomic.Retrieval.SQL.cls_Get_Doctor_Contract_for_List.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DoctorID", Parameter.DoctorID);



			List<DO_GDfCL_0902_raw> results = new List<DO_GDfCL_0902_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_CTR_ContractID","ContractName","HEC_CRT_InsuranceToBrokerContractID","ValidFrom","ValidThrough","DoctorAssignment","HIPID","DisplayName" });
				while(reader.Read())
				{
					DO_GDfCL_0902_raw resultItem = new DO_GDfCL_0902_raw();
					//0:Parameter CMN_CTR_ContractID of type Guid
					resultItem.CMN_CTR_ContractID = reader.GetGuid(0);
					//1:Parameter ContractName of type String
					resultItem.ContractName = reader.GetString(1);
					//2:Parameter HEC_CRT_InsuranceToBrokerContractID of type Guid
					resultItem.HEC_CRT_InsuranceToBrokerContractID = reader.GetGuid(2);
					//3:Parameter ValidFrom of type DateTime
					resultItem.ValidFrom = reader.GetDate(3);
					//4:Parameter ValidThrough of type DateTime
					resultItem.ValidThrough = reader.GetDate(4);
					//5:Parameter DoctorAssignment of type Guid
					resultItem.DoctorAssignment = reader.GetGuid(5);
					//6:Parameter HIPID of type Guid
					resultItem.HIPID = reader.GetGuid(6);
					//7:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctor_Contract_for_List",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = DO_GDfCL_0902_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_DO_GDfCL_0902_Array Invoke(string ConnectionString,P_DO_GDfCL_0902 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GDfCL_0902_Array Invoke(DbConnection Connection,P_DO_GDfCL_0902 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GDfCL_0902_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_GDfCL_0902 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GDfCL_0902_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_GDfCL_0902 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GDfCL_0902_Array functionReturn = new FR_DO_GDfCL_0902_Array();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_Contract_for_List",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class DO_GDfCL_0902_raw 
	{
		public Guid CMN_CTR_ContractID; 
		public String ContractName; 
		public Guid HEC_CRT_InsuranceToBrokerContractID; 
		public DateTime ValidFrom; 
		public DateTime ValidThrough; 
		public Guid DoctorAssignment; 
		public Guid HIPID; 
		public String DisplayName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static DO_GDfCL_0902[] Convert(List<DO_GDfCL_0902_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_DO_GDfCL_0902 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.DoctorAssignment)).ToArray()
	group el_DO_GDfCL_0902 by new 
	{ 
		el_DO_GDfCL_0902.DoctorAssignment,

	}
	into gfunct_DO_GDfCL_0902
	select new DO_GDfCL_0902
	{     
		CMN_CTR_ContractID = gfunct_DO_GDfCL_0902.FirstOrDefault().CMN_CTR_ContractID ,
		ContractName = gfunct_DO_GDfCL_0902.FirstOrDefault().ContractName ,
		HEC_CRT_InsuranceToBrokerContractID = gfunct_DO_GDfCL_0902.FirstOrDefault().HEC_CRT_InsuranceToBrokerContractID ,
		ValidFrom = gfunct_DO_GDfCL_0902.FirstOrDefault().ValidFrom ,
		ValidThrough = gfunct_DO_GDfCL_0902.FirstOrDefault().ValidThrough ,
		DoctorAssignment = gfunct_DO_GDfCL_0902.Key.DoctorAssignment ,

		HIP = 
		(
			from el_HIP in gfunct_DO_GDfCL_0902.Where(element => !EqualsDefaultValue(element.HIPID)).ToArray()
			group el_HIP by new 
			{ 
				el_HIP.HIPID,

			}
			into gfunct_HIP
			select new DO_GDfCL_0902_HIP
			{     
				HIPID = gfunct_HIP.Key.HIPID ,
				DisplayName = gfunct_HIP.FirstOrDefault().DisplayName ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GDfCL_0902_Array : FR_Base
	{
		public DO_GDfCL_0902[] Result	{ get; set; } 
		public FR_DO_GDfCL_0902_Array() : base() {}

		public FR_DO_GDfCL_0902_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_GDfCL_0902 for attribute P_DO_GDfCL_0902
		[DataContract]
		public class P_DO_GDfCL_0902 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 

		}
		#endregion
		#region SClass DO_GDfCL_0902 for attribute DO_GDfCL_0902
		[DataContract]
		public class DO_GDfCL_0902 
		{
			[DataMember]
			public DO_GDfCL_0902_HIP[] HIP { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_CTR_ContractID { get; set; } 
			[DataMember]
			public String ContractName { get; set; } 
			[DataMember]
			public Guid HEC_CRT_InsuranceToBrokerContractID { get; set; } 
			[DataMember]
			public DateTime ValidFrom { get; set; } 
			[DataMember]
			public DateTime ValidThrough { get; set; } 
			[DataMember]
			public Guid DoctorAssignment { get; set; } 

		}
		#endregion
		#region SClass DO_GDfCL_0902_HIP for attribute HIP
		[DataContract]
		public class DO_GDfCL_0902_HIP 
		{
			//Standard type parameters
			[DataMember]
			public Guid HIPID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GDfCL_0902_Array cls_Get_Doctor_Contract_for_List(,P_DO_GDfCL_0902 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GDfCL_0902_Array invocationResult = cls_Get_Doctor_Contract_for_List.Invoke(connectionString,P_DO_GDfCL_0902 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Retrieval.P_DO_GDfCL_0902();
parameter.DoctorID = ...;

*/
