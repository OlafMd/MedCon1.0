/* 
 * Generated on 28.02.2014 16:51:37
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

namespace CL2_TrustRelation.Atomic.Retrieval
{
	/// <summary>
    /// 
      
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ConnectedTenants.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ConnectedTenants
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2TR_GCT_1749_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2TR_GCT_1749 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2TR_GCT_1749_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_TrustRelation.Atomic.Retrieval.SQL.cls_Get_ConnectedTenants.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TypeITL", Parameter.TypeITL);



			List<L2TR_GCT_1749_raw> results = new List<L2TR_GCT_1749_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TenantITL","DisplayName","CMN_BPT_BusinessParticipantID","BusinessParticipantITL","CMN_TRL_TrustRelationID","CMN_TRL_TrustRelationRequestID","TrustRelationRequestITL" });
				while(reader.Read())
				{
					L2TR_GCT_1749_raw resultItem = new L2TR_GCT_1749_raw();
					//0:Parameter TenantITL of type string
					resultItem.TenantITL = reader.GetString(0);
					//1:Parameter DisplayName of type string
					resultItem.DisplayName = reader.GetString(1);
					//2:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(2);
					//3:Parameter BusinessParticipantITL of type string
					resultItem.BusinessParticipantITL = reader.GetString(3);
					//4:Parameter CMN_TRL_TrustRelationID of type Guid
					resultItem.CMN_TRL_TrustRelationID = reader.GetGuid(4);
					//5:Parameter CMN_TRL_TrustRelationRequestID of type Guid
					resultItem.CMN_TRL_TrustRelationRequestID = reader.GetGuid(5);
					//6:Parameter TrustRelationRequestITL of type string
					resultItem.TrustRelationRequestITL = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ConnectedTenants",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L2TR_GCT_1749_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2TR_GCT_1749_Array Invoke(string ConnectionString,P_L2TR_GCT_1749 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2TR_GCT_1749_Array Invoke(DbConnection Connection,P_L2TR_GCT_1749 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2TR_GCT_1749_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2TR_GCT_1749 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2TR_GCT_1749_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2TR_GCT_1749 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2TR_GCT_1749_Array functionReturn = new FR_L2TR_GCT_1749_Array();
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

				throw new Exception("Exception occured in method cls_Get_ConnectedTenants",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L2TR_GCT_1749_raw 
	{
		public string TenantITL; 
		public string DisplayName; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public string BusinessParticipantITL; 
		public Guid CMN_TRL_TrustRelationID; 
		public Guid CMN_TRL_TrustRelationRequestID; 
		public string TrustRelationRequestITL; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L2TR_GCT_1749[] Convert(List<L2TR_GCT_1749_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L2TR_GCT_1749 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID)).ToArray()
	group el_L2TR_GCT_1749 by new 
	{ 
		el_L2TR_GCT_1749.CMN_BPT_BusinessParticipantID,

	}
	into gfunct_L2TR_GCT_1749
	select new L2TR_GCT_1749
	{     
		TenantITL = gfunct_L2TR_GCT_1749.FirstOrDefault().TenantITL ,
		DisplayName = gfunct_L2TR_GCT_1749.FirstOrDefault().DisplayName ,
		CMN_BPT_BusinessParticipantID = gfunct_L2TR_GCT_1749.Key.CMN_BPT_BusinessParticipantID ,
		BusinessParticipantITL = gfunct_L2TR_GCT_1749.FirstOrDefault().BusinessParticipantITL ,

		Trusteraltion = 
		(
			from el_Trusteraltion in gfunct_L2TR_GCT_1749.Where(element => !EqualsDefaultValue(element.CMN_TRL_TrustRelationRequestID)).ToArray()
			group el_Trusteraltion by new 
			{ 
				el_Trusteraltion.CMN_TRL_TrustRelationRequestID,

			}
			into gfunct_Trusteraltion
			select new L2TR_GCT_1749_Trusteraltion
			{     
				CMN_TRL_TrustRelationID = gfunct_Trusteraltion.FirstOrDefault().CMN_TRL_TrustRelationID ,
				CMN_TRL_TrustRelationRequestID = gfunct_Trusteraltion.Key.CMN_TRL_TrustRelationRequestID ,
				TrustRelationRequestITL = gfunct_Trusteraltion.FirstOrDefault().TrustRelationRequestITL ,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L2TR_GCT_1749_Array : FR_Base
	{
		public L2TR_GCT_1749[] Result	{ get; set; } 
		public FR_L2TR_GCT_1749_Array() : base() {}

		public FR_L2TR_GCT_1749_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2TR_GCT_1749 for attribute P_L2TR_GCT_1749
		[DataContract]
		public class P_L2TR_GCT_1749 
		{
			//Standard type parameters
			[DataMember]
			public string TypeITL { get; set; } 

		}
		#endregion
		#region SClass L2TR_GCT_1749 for attribute L2TR_GCT_1749
		[DataContract]
		public class L2TR_GCT_1749 
		{
			[DataMember]
			public L2TR_GCT_1749_Trusteraltion Trusteraltion { get; set; }

			//Standard type parameters
			[DataMember]
			public string TenantITL { get; set; } 
			[DataMember]
			public string DisplayName { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public string BusinessParticipantITL { get; set; } 

		}
		#endregion
		#region SClass L2TR_GCT_1749_Trusteraltion for attribute Trusteraltion
		[DataContract]
		public class L2TR_GCT_1749_Trusteraltion 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_TRL_TrustRelationID { get; set; } 
			[DataMember]
			public Guid CMN_TRL_TrustRelationRequestID { get; set; } 
			[DataMember]
			public string TrustRelationRequestITL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2TR_GCT_1749_Array cls_Get_ConnectedTenants(,P_L2TR_GCT_1749 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2TR_GCT_1749_Array invocationResult = cls_Get_ConnectedTenants.Invoke(connectionString,P_L2TR_GCT_1749 Parameter,securityTicket);
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
var parameter = new CL2_TrustRelation.Atomic.Retrieval.P_L2TR_GCT_1749();
parameter.TypeITL = ...;

*/
