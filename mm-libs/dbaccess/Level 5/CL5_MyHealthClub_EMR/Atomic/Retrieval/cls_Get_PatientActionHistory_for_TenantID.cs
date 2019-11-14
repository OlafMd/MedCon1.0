/* 
 * Generated on 27.01.2015 12:44:06
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
    /// var result = cls_Get_PatientActionHistory_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatientActionHistory_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GPAHfT_1213_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ME_GPAHfT_1213_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_EMR.Atomic.Retrieval.SQL.cls_Get_PatientActionHistory_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5ME_GPAHfT_1213_raw> results = new List<L5ME_GPAHfT_1213_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_PatientID","HEC_ACT_PlannedActionID","PlannedFor_Date","HEC_ACT_PerformedActionID","IfPerfomed_DateOfAction","HEC_PAT_ElectronicMedicalRecord_CreationRequestID","IsEMRFileCreated","RequestDate" });
				while(reader.Read())
				{
					L5ME_GPAHfT_1213_raw resultItem = new L5ME_GPAHfT_1213_raw();
					//0:Parameter HEC_PatientID of type Guid
					resultItem.HEC_PatientID = reader.GetGuid(0);
					//1:Parameter HEC_ACT_PlannedActionID of type Guid
					resultItem.HEC_ACT_PlannedActionID = reader.GetGuid(1);
					//2:Parameter PlannedFor_Date of type DateTime
					resultItem.PlannedFor_Date = reader.GetDate(2);
					//3:Parameter HEC_ACT_PerformedActionID of type Guid
					resultItem.HEC_ACT_PerformedActionID = reader.GetGuid(3);
					//4:Parameter IfPerfomed_DateOfAction of type DateTime
					resultItem.IfPerfomed_DateOfAction = reader.GetDate(4);
					//5:Parameter HEC_PAT_ElectronicMedicalRecord_CreationRequestID of type Guid
					resultItem.HEC_PAT_ElectronicMedicalRecord_CreationRequestID = reader.GetGuid(5);
					//6:Parameter IsEMRFileCreated of type bool
					resultItem.IsEMRFileCreated = reader.GetBoolean(6);
					//7:Parameter RequestDate of type DateTime
					resultItem.RequestDate = reader.GetDate(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PatientActionHistory_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5ME_GPAHfT_1213_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GPAHfT_1213_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GPAHfT_1213_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GPAHfT_1213_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GPAHfT_1213_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GPAHfT_1213_Array functionReturn = new FR_L5ME_GPAHfT_1213_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_PatientActionHistory_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5ME_GPAHfT_1213_raw 
	{
		public Guid HEC_PatientID; 
		public Guid HEC_ACT_PlannedActionID; 
		public DateTime PlannedFor_Date; 
		public Guid HEC_ACT_PerformedActionID; 
		public DateTime IfPerfomed_DateOfAction; 
		public Guid HEC_PAT_ElectronicMedicalRecord_CreationRequestID; 
		public bool IsEMRFileCreated; 
		public DateTime RequestDate; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ME_GPAHfT_1213[] Convert(List<L5ME_GPAHfT_1213_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ME_GPAHfT_1213 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_PatientID)).ToArray()
	group el_L5ME_GPAHfT_1213 by new 
	{ 
		el_L5ME_GPAHfT_1213.HEC_PatientID,

	}
	into gfunct_L5ME_GPAHfT_1213
	select new L5ME_GPAHfT_1213
	{     
		HEC_PatientID = gfunct_L5ME_GPAHfT_1213.Key.HEC_PatientID ,

		PlannedActions = 
		(
			from el_PlannedActions in gfunct_L5ME_GPAHfT_1213.Where(element => !EqualsDefaultValue(element.HEC_ACT_PlannedActionID)).ToArray()
			group el_PlannedActions by new 
			{ 
				el_PlannedActions.HEC_ACT_PlannedActionID,

			}
			into gfunct_PlannedActions
			select new L5ME_GPAHfT_1213_PlannedAction
			{     
				HEC_ACT_PlannedActionID = gfunct_PlannedActions.Key.HEC_ACT_PlannedActionID ,
				PlannedFor_Date = gfunct_PlannedActions.FirstOrDefault().PlannedFor_Date ,

			}
		).ToArray(),
		PerformedActions = 
		(
			from el_PerformedActions in gfunct_L5ME_GPAHfT_1213.Where(element => !EqualsDefaultValue(element.HEC_ACT_PerformedActionID)).ToArray()
			group el_PerformedActions by new 
			{ 
				el_PerformedActions.HEC_ACT_PerformedActionID,

			}
			into gfunct_PerformedActions
			select new L5ME_GPAHfT_1213_PerformedAction
			{     
				HEC_ACT_PerformedActionID = gfunct_PerformedActions.Key.HEC_ACT_PerformedActionID ,
				IfPerfomed_DateOfAction = gfunct_PerformedActions.FirstOrDefault().IfPerfomed_DateOfAction ,

			}
		).ToArray(),
		EMRCreationRequest = 
		(
			from el_EMRCreationRequest in gfunct_L5ME_GPAHfT_1213.Where(element => !EqualsDefaultValue(element.HEC_PAT_ElectronicMedicalRecord_CreationRequestID)).ToArray()
			group el_EMRCreationRequest by new 
			{ 
				el_EMRCreationRequest.HEC_PAT_ElectronicMedicalRecord_CreationRequestID,

			}
			into gfunct_EMRCreationRequest
			select new L5ME_GPAHfT_1213_EMRCreationRequest
			{     
				HEC_PAT_ElectronicMedicalRecord_CreationRequestID = gfunct_EMRCreationRequest.Key.HEC_PAT_ElectronicMedicalRecord_CreationRequestID ,
				IsEMRFileCreated = gfunct_EMRCreationRequest.FirstOrDefault().IsEMRFileCreated ,
				RequestDate = gfunct_EMRCreationRequest.FirstOrDefault().RequestDate ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GPAHfT_1213_Array : FR_Base
	{
		public L5ME_GPAHfT_1213[] Result	{ get; set; } 
		public FR_L5ME_GPAHfT_1213_Array() : base() {}

		public FR_L5ME_GPAHfT_1213_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5ME_GPAHfT_1213 for attribute L5ME_GPAHfT_1213
		[DataContract]
		public class L5ME_GPAHfT_1213 
		{
			[DataMember]
			public L5ME_GPAHfT_1213_PlannedAction[] PlannedActions { get; set; }
			[DataMember]
			public L5ME_GPAHfT_1213_PerformedAction[] PerformedActions { get; set; }
			[DataMember]
			public L5ME_GPAHfT_1213_EMRCreationRequest[] EMRCreationRequest { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_PatientID { get; set; } 

		}
		#endregion
		#region SClass L5ME_GPAHfT_1213_PlannedAction for attribute PlannedActions
		[DataContract]
		public class L5ME_GPAHfT_1213_PlannedAction 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_ACT_PlannedActionID { get; set; } 
			[DataMember]
			public DateTime PlannedFor_Date { get; set; } 

		}
		#endregion
		#region SClass L5ME_GPAHfT_1213_PerformedAction for attribute PerformedActions
		[DataContract]
		public class L5ME_GPAHfT_1213_PerformedAction 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_ACT_PerformedActionID { get; set; } 
			[DataMember]
			public DateTime IfPerfomed_DateOfAction { get; set; } 

		}
		#endregion
		#region SClass L5ME_GPAHfT_1213_EMRCreationRequest for attribute EMRCreationRequest
		[DataContract]
		public class L5ME_GPAHfT_1213_EMRCreationRequest 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_PAT_ElectronicMedicalRecord_CreationRequestID { get; set; } 
			[DataMember]
			public bool IsEMRFileCreated { get; set; } 
			[DataMember]
			public DateTime RequestDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ME_GPAHfT_1213_Array cls_Get_PatientActionHistory_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ME_GPAHfT_1213_Array invocationResult = cls_Get_PatientActionHistory_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

