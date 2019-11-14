/* 
 * Generated on 11/7/2014 5:22:56 PM
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

namespace CL3_DeveloperTask.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ActiveDeveloperTask_for_ActiveUser.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ActiveDeveloperTask_for_ActiveUser
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DT_GADTfAU_1505_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3DT_GADTfAU_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DT_GADTfAU_1505_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_ActiveDeveloperTask_for_ActiveUser.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsBeingPrepared_Only", Parameter.IsBeingPrepared_Only);



			List<L3DT_GADTfAU_1505_raw> results = new List<L3DT_GADTfAU_1505_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DeveloperTask_ID","DeveloperTask_InvolvementID","DeveloperTask_PercentageComplete","DeveloperTask_StatusID","DeveloperTask_StatusCreationTimeStamp" });
				while(reader.Read())
				{
					L3DT_GADTfAU_1505_raw resultItem = new L3DT_GADTfAU_1505_raw();
					//0:Parameter DeveloperTask_ID of type Guid
					resultItem.DeveloperTask_ID = reader.GetGuid(0);
					//1:Parameter DeveloperTask_InvolvementID of type Guid
					resultItem.DeveloperTask_InvolvementID = reader.GetGuid(1);
					//2:Parameter DeveloperTask_PercentageComplete of type double
					resultItem.DeveloperTask_PercentageComplete = reader.GetDouble(2);
					//3:Parameter DeveloperTask_StatusID of type Guid
					resultItem.DeveloperTask_StatusID = reader.GetGuid(3);
					//4:Parameter DeveloperTask_StatusCreationTimeStamp of type DateTime
					resultItem.DeveloperTask_StatusCreationTimeStamp = reader.GetDate(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ActiveDeveloperTask_for_ActiveUser",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3DT_GADTfAU_1505_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3DT_GADTfAU_1505_Array Invoke(string ConnectionString,P_L3DT_GADTfAU_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DT_GADTfAU_1505_Array Invoke(DbConnection Connection,P_L3DT_GADTfAU_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DT_GADTfAU_1505_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DT_GADTfAU_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DT_GADTfAU_1505_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DT_GADTfAU_1505 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DT_GADTfAU_1505_Array functionReturn = new FR_L3DT_GADTfAU_1505_Array();
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

				throw new Exception("Exception occured in method cls_Get_ActiveDeveloperTask_for_ActiveUser",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3DT_GADTfAU_1505_raw 
	{
		public Guid DeveloperTask_ID; 
		public Guid DeveloperTask_InvolvementID; 
		public double DeveloperTask_PercentageComplete; 
		public Guid DeveloperTask_StatusID; 
		public DateTime DeveloperTask_StatusCreationTimeStamp; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3DT_GADTfAU_1505[] Convert(List<L3DT_GADTfAU_1505_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3DT_GADTfAU_1505 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.DeveloperTask_ID)).ToArray()
	group el_L3DT_GADTfAU_1505 by new 
	{ 
		el_L3DT_GADTfAU_1505.DeveloperTask_ID,

	}
	into gfunct_L3DT_GADTfAU_1505
	select new L3DT_GADTfAU_1505
	{     
		DeveloperTask_ID = gfunct_L3DT_GADTfAU_1505.Key.DeveloperTask_ID ,
		DeveloperTask_InvolvementID = gfunct_L3DT_GADTfAU_1505.FirstOrDefault().DeveloperTask_InvolvementID ,
		DeveloperTask_PercentageComplete = gfunct_L3DT_GADTfAU_1505.FirstOrDefault().DeveloperTask_PercentageComplete ,

		DeveloperTask_StatusHistory = 
		(
			from el_DeveloperTask_StatusHistory in gfunct_L3DT_GADTfAU_1505.ToArray()
			select new L3DT_GADTfAU_1505a
			{     
				DeveloperTask_StatusID = el_DeveloperTask_StatusHistory.DeveloperTask_StatusID,
				DeveloperTask_StatusCreationTimeStamp = el_DeveloperTask_StatusHistory.DeveloperTask_StatusCreationTimeStamp,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3DT_GADTfAU_1505_Array : FR_Base
	{
		public L3DT_GADTfAU_1505[] Result	{ get; set; } 
		public FR_L3DT_GADTfAU_1505_Array() : base() {}

		public FR_L3DT_GADTfAU_1505_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3DT_GADTfAU_1505 for attribute P_L3DT_GADTfAU_1505
		[DataContract]
		public class P_L3DT_GADTfAU_1505 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsBeingPrepared_Only { get; set; } 

		}
		#endregion
		#region SClass L3DT_GADTfAU_1505 for attribute L3DT_GADTfAU_1505
		[DataContract]
		public class L3DT_GADTfAU_1505 
		{
			[DataMember]
			public L3DT_GADTfAU_1505a[] DeveloperTask_StatusHistory { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid DeveloperTask_ID { get; set; } 
			[DataMember]
			public Guid DeveloperTask_InvolvementID { get; set; } 
			[DataMember]
			public double DeveloperTask_PercentageComplete { get; set; } 

		}
		#endregion
		#region SClass L3DT_GADTfAU_1505a for attribute DeveloperTask_StatusHistory
		[DataContract]
		public class L3DT_GADTfAU_1505a 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTask_StatusID { get; set; } 
			[DataMember]
			public DateTime DeveloperTask_StatusCreationTimeStamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DT_GADTfAU_1505_Array cls_Get_ActiveDeveloperTask_for_ActiveUser(,P_L3DT_GADTfAU_1505 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DT_GADTfAU_1505_Array invocationResult = cls_Get_ActiveDeveloperTask_for_ActiveUser.Invoke(connectionString,P_L3DT_GADTfAU_1505 Parameter,securityTicket);
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
var parameter = new CL3_DeveloperTask.Atomic.Retrieval.P_L3DT_GADTfAU_1505();
parameter.IsBeingPrepared_Only = ...;

*/
