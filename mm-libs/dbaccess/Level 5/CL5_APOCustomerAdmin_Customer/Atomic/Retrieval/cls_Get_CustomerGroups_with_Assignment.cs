/* 
 * Generated on 15.11.2014 17:50:25
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

namespace CL5_APOCustomerAdmin_Customer.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerGroups_with_Assignment.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerGroups_with_Assignment
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CU_GCGwA_1237_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CU_GCGwA_1237_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOCustomerAdmin_Customer.Atomic.Retrieval.SQL.cls_Get_CustomerGroups_with_Assignment.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5CU_GCGwA_1237_raw> results = new List<L5CU_GCGwA_1237_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_BusinessParticipant_GroupID","BusinessParticipantGroup_Name_DictID","BusinessParticipantGroup_Description_DictID","AssignmentID","CMN_BPT_BusinessParticipant_RefID","CMN_BPT_BusinessParticipant_Group_RefID" });
				while(reader.Read())
				{
					L5CU_GCGwA_1237_raw resultItem = new L5CU_GCGwA_1237_raw();
					//0:Parameter CMN_BPT_BusinessParticipant_GroupID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_GroupID = reader.GetGuid(0);
					//1:Parameter BusinessParticipantGroup_Name of type Dict
					resultItem.BusinessParticipantGroup_Name = reader.GetDictionary(1);
					resultItem.BusinessParticipantGroup_Name.SourceTable = "cmn_bpt_businessparticipant_groups";
					loader.Append(resultItem.BusinessParticipantGroup_Name);
					//2:Parameter BusinessParticipantGroup_Description of type Dict
					resultItem.BusinessParticipantGroup_Description = reader.GetDictionary(2);
					resultItem.BusinessParticipantGroup_Description.SourceTable = "cmn_bpt_businessparticipant_groups";
					loader.Append(resultItem.BusinessParticipantGroup_Description);
					//3:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(3);
					//4:Parameter CMN_BPT_BusinessParticipant_RefID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_RefID = reader.GetGuid(4);
					//5:Parameter CMN_BPT_BusinessParticipant_Group_RefID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_Group_RefID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CustomerGroups_with_Assignment",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5CU_GCGwA_1237_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CU_GCGwA_1237_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CU_GCGwA_1237_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CU_GCGwA_1237_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CU_GCGwA_1237_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CU_GCGwA_1237_Array functionReturn = new FR_L5CU_GCGwA_1237_Array();
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

				throw new Exception("Exception occured in method cls_Get_CustomerGroups_with_Assignment",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5CU_GCGwA_1237_raw 
	{
		public Guid CMN_BPT_BusinessParticipant_GroupID; 
		public Dict BusinessParticipantGroup_Name; 
		public Dict BusinessParticipantGroup_Description; 
		public Guid AssignmentID; 
		public Guid CMN_BPT_BusinessParticipant_RefID; 
		public Guid CMN_BPT_BusinessParticipant_Group_RefID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5CU_GCGwA_1237[] Convert(List<L5CU_GCGwA_1237_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5CU_GCGwA_1237 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipant_GroupID)).ToArray()
	group el_L5CU_GCGwA_1237 by new 
	{ 
		el_L5CU_GCGwA_1237.CMN_BPT_BusinessParticipant_GroupID,

	}
	into gfunct_L5CU_GCGwA_1237
	select new L5CU_GCGwA_1237
	{     
		CMN_BPT_BusinessParticipant_GroupID = gfunct_L5CU_GCGwA_1237.Key.CMN_BPT_BusinessParticipant_GroupID ,
		BusinessParticipantGroup_Name = gfunct_L5CU_GCGwA_1237.FirstOrDefault().BusinessParticipantGroup_Name ,
		BusinessParticipantGroup_Description = gfunct_L5CU_GCGwA_1237.FirstOrDefault().BusinessParticipantGroup_Description ,

		Assignments = 
		(
			from el_Assignments in gfunct_L5CU_GCGwA_1237.ToArray()
			select new L5CU_GCGwA_1237a
			{     
				AssignmentID = el_Assignments.AssignmentID,
				CMN_BPT_BusinessParticipant_RefID = el_Assignments.CMN_BPT_BusinessParticipant_RefID,
				CMN_BPT_BusinessParticipant_Group_RefID = el_Assignments.CMN_BPT_BusinessParticipant_Group_RefID,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5CU_GCGwA_1237_Array : FR_Base
	{
		public L5CU_GCGwA_1237[] Result	{ get; set; } 
		public FR_L5CU_GCGwA_1237_Array() : base() {}

		public FR_L5CU_GCGwA_1237_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5CU_GCGwA_1237 for attribute L5CU_GCGwA_1237
		[DataContract]
		public class L5CU_GCGwA_1237 
		{
			[DataMember]
			public L5CU_GCGwA_1237a[] Assignments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_GroupID { get; set; } 
			[DataMember]
			public Dict BusinessParticipantGroup_Name { get; set; } 
			[DataMember]
			public Dict BusinessParticipantGroup_Description { get; set; } 

		}
		#endregion
		#region SClass L5CU_GCGwA_1237a for attribute Assignments
		[DataContract]
		public class L5CU_GCGwA_1237a 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_Group_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CU_GCGwA_1237_Array cls_Get_CustomerGroups_with_Assignment(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CU_GCGwA_1237_Array invocationResult = cls_Get_CustomerGroups_with_Assignment.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

