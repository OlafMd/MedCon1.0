/* 
 * Generated on 27.01.2015 10:54:36
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

namespace CL5_MyHealthClub_EMR.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Vitals_for_PerformedActionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Vitals_for_PerformedActionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GPPfPAID_1524_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_GPPfPAID_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ME_GPPfPAID_1524_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_EMR.Atomic.Retrieval.SQL.cls_Get_Vitals_for_PerformedActionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PerformedActionID", Parameter.PerformedActionID);



			List<L5ME_GPPfPAID_1524_raw> results = new List<L5ME_GPPfPAID_1524_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ConfirmedBy_Doctor_RefID","HEC_Patient_ParameterValueID","HEC_Patient_ParameterID","StringValue","IsVitalParameter","IsConfirmed","DateOfValue","DateOfEntry" });
				while(reader.Read())
				{
					L5ME_GPPfPAID_1524_raw resultItem = new L5ME_GPPfPAID_1524_raw();
					//0:Parameter ConfirmedBy_Doctor_RefID of type Guid
					resultItem.ConfirmedBy_Doctor_RefID = reader.GetGuid(0);
					//1:Parameter HEC_Patient_ParameterValueID of type Guid
					resultItem.HEC_Patient_ParameterValueID = reader.GetGuid(1);
					//2:Parameter HEC_Patient_ParameterID of type Guid
					resultItem.HEC_Patient_ParameterID = reader.GetGuid(2);
					//3:Parameter StringValue of type String
					resultItem.StringValue = reader.GetString(3);
					//4:Parameter IsVitalParameter of type bool
					resultItem.IsVitalParameter = reader.GetBoolean(4);
					//5:Parameter IsConfirmed of type bool
					resultItem.IsConfirmed = reader.GetBoolean(5);
					//6:Parameter DateOfValue of type DateTime
					resultItem.DateOfValue = reader.GetDate(6);
					//7:Parameter DateOfEntry of type DateTime
					resultItem.DateOfEntry = reader.GetDate(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Vitals_for_PerformedActionID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5ME_GPPfPAID_1524_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GPPfPAID_1524_Array Invoke(string ConnectionString,P_L5ME_GPPfPAID_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GPPfPAID_1524_Array Invoke(DbConnection Connection,P_L5ME_GPPfPAID_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GPPfPAID_1524_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_GPPfPAID_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GPPfPAID_1524_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_GPPfPAID_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GPPfPAID_1524_Array functionReturn = new FR_L5ME_GPPfPAID_1524_Array();
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

				throw new Exception("Exception occured in method cls_Get_Vitals_for_PerformedActionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5ME_GPPfPAID_1524_raw 
	{
		public Guid ConfirmedBy_Doctor_RefID; 
		public Guid HEC_Patient_ParameterValueID; 
		public Guid HEC_Patient_ParameterID; 
		public String StringValue; 
		public bool IsVitalParameter; 
		public bool IsConfirmed; 
		public DateTime DateOfValue; 
		public DateTime DateOfEntry; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ME_GPPfPAID_1524[] Convert(List<L5ME_GPPfPAID_1524_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ME_GPPfPAID_1524 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_ParameterValueID)).ToArray()
	group el_L5ME_GPPfPAID_1524 by new 
	{ 
		el_L5ME_GPPfPAID_1524.HEC_Patient_ParameterValueID,

	}
	into gfunct_L5ME_GPPfPAID_1524
	select new L5ME_GPPfPAID_1524
	{     
		ConfirmedBy_Doctor_RefID = gfunct_L5ME_GPPfPAID_1524.FirstOrDefault().ConfirmedBy_Doctor_RefID ,
		HEC_Patient_ParameterValueID = gfunct_L5ME_GPPfPAID_1524.Key.HEC_Patient_ParameterValueID ,
		HEC_Patient_ParameterID = gfunct_L5ME_GPPfPAID_1524.FirstOrDefault().HEC_Patient_ParameterID ,
		StringValue = gfunct_L5ME_GPPfPAID_1524.FirstOrDefault().StringValue ,
		IsVitalParameter = gfunct_L5ME_GPPfPAID_1524.FirstOrDefault().IsVitalParameter ,
		IsConfirmed = gfunct_L5ME_GPPfPAID_1524.FirstOrDefault().IsConfirmed ,
		DateOfValue = gfunct_L5ME_GPPfPAID_1524.FirstOrDefault().DateOfValue ,
		DateOfEntry = gfunct_L5ME_GPPfPAID_1524.FirstOrDefault().DateOfEntry ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GPPfPAID_1524_Array : FR_Base
	{
		public L5ME_GPPfPAID_1524[] Result	{ get; set; } 
		public FR_L5ME_GPPfPAID_1524_Array() : base() {}

		public FR_L5ME_GPPfPAID_1524_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_GPPfPAID_1524 for attribute P_L5ME_GPPfPAID_1524
		[DataContract]
		public class P_L5ME_GPPfPAID_1524 
		{
			//Standard type parameters
			[DataMember]
			public Guid PerformedActionID { get; set; } 

		}
		#endregion
		#region SClass L5ME_GPPfPAID_1524 for attribute L5ME_GPPfPAID_1524
		[DataContract]
		public class L5ME_GPPfPAID_1524 
		{
			//Standard type parameters
			[DataMember]
			public Guid ConfirmedBy_Doctor_RefID { get; set; } 
			[DataMember]
			public Guid HEC_Patient_ParameterValueID { get; set; } 
			[DataMember]
			public Guid HEC_Patient_ParameterID { get; set; } 
			[DataMember]
			public String StringValue { get; set; } 
			[DataMember]
			public bool IsVitalParameter { get; set; } 
			[DataMember]
			public bool IsConfirmed { get; set; } 
			[DataMember]
			public DateTime DateOfValue { get; set; } 
			[DataMember]
			public DateTime DateOfEntry { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ME_GPPfPAID_1524_Array cls_Get_Vitals_for_PerformedActionID(,P_L5ME_GPPfPAID_1524 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ME_GPPfPAID_1524_Array invocationResult = cls_Get_Vitals_for_PerformedActionID.Invoke(connectionString,P_L5ME_GPPfPAID_1524 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_EMR.Atomic.Retrieval.P_L5ME_GPPfPAID_1524();
parameter.PerformedActionID = ...;

*/
