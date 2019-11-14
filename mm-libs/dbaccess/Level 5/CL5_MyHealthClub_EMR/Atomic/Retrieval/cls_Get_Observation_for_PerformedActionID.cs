/* 
 * Generated on 27.01.2015 10:53:30
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
    /// var result = cls_Get_Observation_for_PerformedActionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Observation_for_PerformedActionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GOfPAID_1940_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_GOfPAID_1940 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ME_GOfPAID_1940_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_EMR.Atomic.Retrieval.SQL.cls_Get_Observation_for_PerformedActionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PerformedActionID", Parameter.PerformedActionID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientDiagnosisID", Parameter.PatientDiagnosisID);



			List<L5ME_GOfPAID_1940_raw> results = new List<L5ME_GOfPAID_1940_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Comment","HEC_ACT_PerformedAction_ObservationID","DOC_Document_RefID" });
				while(reader.Read())
				{
					L5ME_GOfPAID_1940_raw resultItem = new L5ME_GOfPAID_1940_raw();
					//0:Parameter Comment of type String
					resultItem.Comment = reader.GetString(0);
					//1:Parameter HEC_ACT_PerformedAction_ObservationID of type Guid
					resultItem.HEC_ACT_PerformedAction_ObservationID = reader.GetGuid(1);
					//2:Parameter DOC_Document_RefID of type Guid
					resultItem.DOC_Document_RefID = reader.GetGuid(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Observation_for_PerformedActionID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5ME_GOfPAID_1940_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GOfPAID_1940_Array Invoke(string ConnectionString,P_L5ME_GOfPAID_1940 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GOfPAID_1940_Array Invoke(DbConnection Connection,P_L5ME_GOfPAID_1940 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GOfPAID_1940_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_GOfPAID_1940 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GOfPAID_1940_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_GOfPAID_1940 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GOfPAID_1940_Array functionReturn = new FR_L5ME_GOfPAID_1940_Array();
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

				throw new Exception("Exception occured in method cls_Get_Observation_for_PerformedActionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5ME_GOfPAID_1940_raw 
	{
		public String Comment; 
		public Guid HEC_ACT_PerformedAction_ObservationID; 
		public Guid DOC_Document_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ME_GOfPAID_1940[] Convert(List<L5ME_GOfPAID_1940_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ME_GOfPAID_1940 in gfunct_rawResult.ToArray()
	group el_L5ME_GOfPAID_1940 by new 
	{ 
	}
	into gfunct_L5ME_GOfPAID_1940
	select new L5ME_GOfPAID_1940
	{     
		Comment = gfunct_L5ME_GOfPAID_1940.FirstOrDefault().Comment ,
		HEC_ACT_PerformedAction_ObservationID = gfunct_L5ME_GOfPAID_1940.FirstOrDefault().HEC_ACT_PerformedAction_ObservationID ,

		Document = 
		(
			from el_Document in gfunct_L5ME_GOfPAID_1940.Where(element => !EqualsDefaultValue(element.DOC_Document_RefID)).ToArray()
			group el_Document by new 
			{ 
				el_Document.DOC_Document_RefID,

			}
			into gfunct_Document
			select new L5ME_GOfPAID_1940_Documents
			{     
				DOC_Document_RefID = gfunct_Document.Key.DOC_Document_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GOfPAID_1940_Array : FR_Base
	{
		public L5ME_GOfPAID_1940[] Result	{ get; set; } 
		public FR_L5ME_GOfPAID_1940_Array() : base() {}

		public FR_L5ME_GOfPAID_1940_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_GOfPAID_1940 for attribute P_L5ME_GOfPAID_1940
		[DataContract]
		public class P_L5ME_GOfPAID_1940 
		{
			//Standard type parameters
			[DataMember]
			public Guid PerformedActionID { get; set; } 
			[DataMember]
			public Guid PatientDiagnosisID { get; set; } 

		}
		#endregion
		#region SClass L5ME_GOfPAID_1940 for attribute L5ME_GOfPAID_1940
		[DataContract]
		public class L5ME_GOfPAID_1940 
		{
			[DataMember]
			public L5ME_GOfPAID_1940_Documents[] Document { get; set; }

			//Standard type parameters
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public Guid HEC_ACT_PerformedAction_ObservationID { get; set; } 

		}
		#endregion
		#region SClass L5ME_GOfPAID_1940_Documents for attribute Document
		[DataContract]
		public class L5ME_GOfPAID_1940_Documents 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_Document_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ME_GOfPAID_1940_Array cls_Get_Observation_for_PerformedActionID(,P_L5ME_GOfPAID_1940 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ME_GOfPAID_1940_Array invocationResult = cls_Get_Observation_for_PerformedActionID.Invoke(connectionString,P_L5ME_GOfPAID_1940 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_EMR.Atomic.Retrieval.P_L5ME_GOfPAID_1940();
parameter.PerformedActionID = ...;
parameter.PatientDiagnosisID = ...;

*/
