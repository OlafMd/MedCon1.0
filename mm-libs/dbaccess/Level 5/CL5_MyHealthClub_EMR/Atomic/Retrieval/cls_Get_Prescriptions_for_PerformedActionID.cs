/* 
 * Generated on 27.01.2015 10:54:04
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
    /// var result = cls_Get_Prescriptions_for_PerformedActionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Prescriptions_for_PerformedActionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GPfPAID_1216_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_GPfPAID_1216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ME_GPfPAID_1216_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_EMR.Atomic.Retrieval.SQL.cls_Get_Prescriptions_for_PerformedActionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PerformedActionID", Parameter.PerformedActionID);



			List<L5ME_GPfPAID_1216_raw> results = new List<L5ME_GPfPAID_1216_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PrescribedBy_Doctor_RefID","HEC_Patient_Prescription_HeaderID","Prescription_Date","HEC_Patient_Prescription_PositionID","InitializedFrom_PatientMedication_RefID" });
				while(reader.Read())
				{
					L5ME_GPfPAID_1216_raw resultItem = new L5ME_GPfPAID_1216_raw();
					//0:Parameter PrescribedBy_Doctor_RefID of type Guid
					resultItem.PrescribedBy_Doctor_RefID = reader.GetGuid(0);
					//1:Parameter HEC_Patient_Prescription_HeaderID of type Guid
					resultItem.HEC_Patient_Prescription_HeaderID = reader.GetGuid(1);
					//2:Parameter Prescription_Date of type DateTime
					resultItem.Prescription_Date = reader.GetDate(2);
					//3:Parameter HEC_Patient_Prescription_PositionID of type Guid
					resultItem.HEC_Patient_Prescription_PositionID = reader.GetGuid(3);
					//4:Parameter InitializedFrom_PatientMedication_RefID of type Guid
					resultItem.InitializedFrom_PatientMedication_RefID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Prescriptions_for_PerformedActionID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5ME_GPfPAID_1216_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GPfPAID_1216_Array Invoke(string ConnectionString,P_L5ME_GPfPAID_1216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GPfPAID_1216_Array Invoke(DbConnection Connection,P_L5ME_GPfPAID_1216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GPfPAID_1216_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_GPfPAID_1216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GPfPAID_1216_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_GPfPAID_1216 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GPfPAID_1216_Array functionReturn = new FR_L5ME_GPfPAID_1216_Array();
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

				throw new Exception("Exception occured in method cls_Get_Prescriptions_for_PerformedActionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5ME_GPfPAID_1216_raw 
	{
		public Guid PrescribedBy_Doctor_RefID; 
		public Guid HEC_Patient_Prescription_HeaderID; 
		public DateTime Prescription_Date; 
		public Guid HEC_Patient_Prescription_PositionID; 
		public Guid InitializedFrom_PatientMedication_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ME_GPfPAID_1216[] Convert(List<L5ME_GPfPAID_1216_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ME_GPfPAID_1216 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_Prescription_HeaderID)).ToArray()
	group el_L5ME_GPfPAID_1216 by new 
	{ 
		el_L5ME_GPfPAID_1216.HEC_Patient_Prescription_HeaderID,

	}
	into gfunct_L5ME_GPfPAID_1216
	select new L5ME_GPfPAID_1216
	{     
		PrescribedBy_Doctor_RefID = gfunct_L5ME_GPfPAID_1216.FirstOrDefault().PrescribedBy_Doctor_RefID ,
		HEC_Patient_Prescription_HeaderID = gfunct_L5ME_GPfPAID_1216.Key.HEC_Patient_Prescription_HeaderID ,
		Prescription_Date = gfunct_L5ME_GPfPAID_1216.FirstOrDefault().Prescription_Date ,

		Positions = 
		(
			from el_Positions in gfunct_L5ME_GPfPAID_1216.Where(element => !EqualsDefaultValue(element.HEC_Patient_Prescription_PositionID)).ToArray()
			group el_Positions by new 
			{ 
				el_Positions.HEC_Patient_Prescription_PositionID,

			}
			into gfunct_Positions
			select new L5ME_GPfPAID_1216_Position
			{     
				HEC_Patient_Prescription_PositionID = gfunct_Positions.Key.HEC_Patient_Prescription_PositionID ,
				InitializedFrom_PatientMedication_RefID = gfunct_Positions.FirstOrDefault().InitializedFrom_PatientMedication_RefID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GPfPAID_1216_Array : FR_Base
	{
		public L5ME_GPfPAID_1216[] Result	{ get; set; } 
		public FR_L5ME_GPfPAID_1216_Array() : base() {}

		public FR_L5ME_GPfPAID_1216_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_GPfPAID_1216 for attribute P_L5ME_GPfPAID_1216
		[DataContract]
		public class P_L5ME_GPfPAID_1216 
		{
			//Standard type parameters
			[DataMember]
			public Guid PerformedActionID { get; set; } 

		}
		#endregion
		#region SClass L5ME_GPfPAID_1216 for attribute L5ME_GPfPAID_1216
		[DataContract]
		public class L5ME_GPfPAID_1216 
		{
			[DataMember]
			public L5ME_GPfPAID_1216_Position[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PrescribedBy_Doctor_RefID { get; set; } 
			[DataMember]
			public Guid HEC_Patient_Prescription_HeaderID { get; set; } 
			[DataMember]
			public DateTime Prescription_Date { get; set; } 

		}
		#endregion
		#region SClass L5ME_GPfPAID_1216_Position for attribute Positions
		[DataContract]
		public class L5ME_GPfPAID_1216_Position 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_Prescription_PositionID { get; set; } 
			[DataMember]
			public Guid InitializedFrom_PatientMedication_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ME_GPfPAID_1216_Array cls_Get_Prescriptions_for_PerformedActionID(,P_L5ME_GPfPAID_1216 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ME_GPfPAID_1216_Array invocationResult = cls_Get_Prescriptions_for_PerformedActionID.Invoke(connectionString,P_L5ME_GPfPAID_1216 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_EMR.Atomic.Retrieval.P_L5ME_GPfPAID_1216();
parameter.PerformedActionID = ...;

*/
