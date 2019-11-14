/* 
 * Generated on 6/2/2014 5:56:26 PM
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

namespace CL3_Profession.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Professions_for_ProfessionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Professions_for_ProfessionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3P_GPfP_1717_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3P_GPfP_1717 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3P_GPfP_1717_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Profession.Atomic.Retrieval.SQL.cls_Get_Professions_for_ProfessionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProfessionID", Parameter.ProfessionID);



			List<L3P_GPfP_1717> results = new List<L3P_GPfP_1717>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_STR_ProfessionID","ProfessionName_DictID","CMN_STR_ProfessionKeyID","SocialSecurityProfessionKey","CMN_STR_SkillID","Skill_Name_DictID" });
				while(reader.Read())
				{
					L3P_GPfP_1717 resultItem = new L3P_GPfP_1717();
					//0:Parameter CMN_STR_ProfessionID of type Guid
					resultItem.CMN_STR_ProfessionID = reader.GetGuid(0);
					//1:Parameter ProfessionName of type Dict
					resultItem.ProfessionName = reader.GetDictionary(1);
					resultItem.ProfessionName.SourceTable = "cmn_str_professions";
					loader.Append(resultItem.ProfessionName);
					//2:Parameter CMN_STR_ProfessionKeyID of type Guid
					resultItem.CMN_STR_ProfessionKeyID = reader.GetGuid(2);
					//3:Parameter SocialSecurityProfessionKey of type String
					resultItem.SocialSecurityProfessionKey = reader.GetString(3);
					//4:Parameter CMN_STR_SkillID of type Guid
					resultItem.CMN_STR_SkillID = reader.GetGuid(4);
					//5:Parameter Skill_Name of type Dict
					resultItem.Skill_Name = reader.GetDictionary(5);
					resultItem.Skill_Name.SourceTable = "cmn_str_skills";
					loader.Append(resultItem.Skill_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Professions_for_ProfessionID",ex);
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
		public static FR_L3P_GPfP_1717_Array Invoke(string ConnectionString,P_L3P_GPfP_1717 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3P_GPfP_1717_Array Invoke(DbConnection Connection,P_L3P_GPfP_1717 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3P_GPfP_1717_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3P_GPfP_1717 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3P_GPfP_1717_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3P_GPfP_1717 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3P_GPfP_1717_Array functionReturn = new FR_L3P_GPfP_1717_Array();
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

				throw new Exception("Exception occured in method cls_Get_Professions_for_ProfessionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3P_GPfP_1717_Array : FR_Base
	{
		public L3P_GPfP_1717[] Result	{ get; set; } 
		public FR_L3P_GPfP_1717_Array() : base() {}

		public FR_L3P_GPfP_1717_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3P_GPfP_1717 for attribute P_L3P_GPfP_1717
		[DataContract]
		public class P_L3P_GPfP_1717 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProfessionID { get; set; } 

		}
		#endregion
		#region SClass L3P_GPfP_1717 for attribute L3P_GPfP_1717
		[DataContract]
		public class L3P_GPfP_1717 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_ProfessionID { get; set; } 
			[DataMember]
			public Dict ProfessionName { get; set; } 
			[DataMember]
			public Guid CMN_STR_ProfessionKeyID { get; set; } 
			[DataMember]
			public String SocialSecurityProfessionKey { get; set; } 
			[DataMember]
			public Guid CMN_STR_SkillID { get; set; } 
			[DataMember]
			public Dict Skill_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3P_GPfP_1717_Array cls_Get_Professions_for_ProfessionID(,P_L3P_GPfP_1717 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3P_GPfP_1717_Array invocationResult = cls_Get_Professions_for_ProfessionID.Invoke(connectionString,P_L3P_GPfP_1717 Parameter,securityTicket);
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
var parameter = new CL3_Profession.Atomic.Retrieval.P_L3P_GPfP_1717();
parameter.ProfessionID = ...;

*/
