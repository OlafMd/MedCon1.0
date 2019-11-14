/* 
 * Generated on 10/14/2014 6:04:21 PM
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

namespace CL6_MyHealthClub_Medications.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RecommendedSubstance_for_tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RecommendedSubstance_for_tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6_GRSfT_1639_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6_GRSfT_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6_GRSfT_1639_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_MyHealthClub_Medications.Atomic.Retrieval.SQL.cls_Get_RecommendedSubstance_for_tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Tenant", Parameter.Tenant);



			List<L6_GRSfT_1639> results = new List<L6_GRSfT_1639>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ISOCode","HEC_DIA_RecommendedSubstanceID","PotentialDiagnosis_RefID","Substance_RefID","SubstanceStrength","Substance_Unit_RefID","IsDefault","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_TimestampRecommendedSubstances","Modification_TimestampUnits" });
				while(reader.Read())
				{
					L6_GRSfT_1639 resultItem = new L6_GRSfT_1639();
					//0:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(0);
					//1:Parameter HEC_DIA_RecommendedSubstanceID of type Guid
					resultItem.HEC_DIA_RecommendedSubstanceID = reader.GetGuid(1);
					//2:Parameter PotentialDiagnosis_RefID of type Guid
					resultItem.PotentialDiagnosis_RefID = reader.GetGuid(2);
					//3:Parameter Substance_RefID of type Guid
					resultItem.Substance_RefID = reader.GetGuid(3);
					//4:Parameter SubstanceStrength of type String
					resultItem.SubstanceStrength = reader.GetString(4);
					//5:Parameter Substance_Unit_RefID of type Guid
					resultItem.Substance_Unit_RefID = reader.GetGuid(5);
					//6:Parameter IsDefault of type bool
					resultItem.IsDefault = reader.GetBoolean(6);
					//7:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(7);
					//8:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(8);
					//9:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(9);
					//10:Parameter Modification_TimestampRecommendedSubstances of type DateTime
					resultItem.Modification_TimestampRecommendedSubstances = reader.GetDate(10);
					//11:Parameter Modification_TimestampUnits of type DateTime
					resultItem.Modification_TimestampUnits = reader.GetDate(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RecommendedSubstance_for_tenant",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6_GRSfT_1639_Array Invoke(string ConnectionString,P_L6_GRSfT_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6_GRSfT_1639_Array Invoke(DbConnection Connection,P_L6_GRSfT_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6_GRSfT_1639_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6_GRSfT_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6_GRSfT_1639_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6_GRSfT_1639 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6_GRSfT_1639_Array functionReturn = new FR_L6_GRSfT_1639_Array();
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

				throw new Exception("Exception occured in method cls_Get_RecommendedSubstance_for_tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6_GRSfT_1639_Array : FR_Base
	{
		public L6_GRSfT_1639[] Result	{ get; set; } 
		public FR_L6_GRSfT_1639_Array() : base() {}

		public FR_L6_GRSfT_1639_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6_GRSfT_1639 for attribute P_L6_GRSfT_1639
		[DataContract]
		public class P_L6_GRSfT_1639 
		{
			//Standard type parameters
			[DataMember]
			public Guid Tenant { get; set; } 

		}
		#endregion
		#region SClass L6_GRSfT_1639 for attribute L6_GRSfT_1639
		[DataContract]
		public class L6_GRSfT_1639 
		{
			//Standard type parameters
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public Guid HEC_DIA_RecommendedSubstanceID { get; set; } 
			[DataMember]
			public Guid PotentialDiagnosis_RefID { get; set; } 
			[DataMember]
			public Guid Substance_RefID { get; set; } 
			[DataMember]
			public String SubstanceStrength { get; set; } 
			[DataMember]
			public Guid Substance_Unit_RefID { get; set; } 
			[DataMember]
			public bool IsDefault { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampRecommendedSubstances { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampUnits { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6_GRSfT_1639_Array cls_Get_RecommendedSubstance_for_tenant(,P_L6_GRSfT_1639 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6_GRSfT_1639_Array invocationResult = cls_Get_RecommendedSubstance_for_tenant.Invoke(connectionString,P_L6_GRSfT_1639 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Medications.Atomic.Retrieval.P_L6_GRSfT_1639();
parameter.Tenant = ...;

*/
