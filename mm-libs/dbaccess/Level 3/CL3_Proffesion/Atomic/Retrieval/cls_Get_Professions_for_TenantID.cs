/* 
 * Generated on 10/31/2014 1:29:46 PM
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
    /// var result = cls_Get_Professions_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Professions_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3P_GPfT_1537_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3P_GPfT_1537_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Profession.Atomic.Retrieval.SQL.cls_Get_Professions_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3P_GPfT_1537_raw> results = new List<L3P_GPfT_1537_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ProfessionName_DictID","CMN_STR_ProfessionID","CMN_STR_ProfessionKeyID","SocialSecurityProfessionKey","CMN_STR_SkillID","Skill_Name_DictID" });
				while(reader.Read())
				{
					L3P_GPfT_1537_raw resultItem = new L3P_GPfT_1537_raw();
					//0:Parameter ProfessionName of type Dict
					resultItem.ProfessionName = reader.GetDictionary(0);
					resultItem.ProfessionName.SourceTable = "cmn_str_professions";
					loader.Append(resultItem.ProfessionName);
					//1:Parameter CMN_STR_ProfessionID of type Guid
					resultItem.CMN_STR_ProfessionID = reader.GetGuid(1);
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
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Professions_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3P_GPfT_1537_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3P_GPfT_1537_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3P_GPfT_1537_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3P_GPfT_1537_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3P_GPfT_1537_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3P_GPfT_1537_Array functionReturn = new FR_L3P_GPfT_1537_Array();
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

				throw new Exception("Exception occured in method cls_Get_Professions_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3P_GPfT_1537_raw 
	{
		public Dict ProfessionName; 
		public Guid CMN_STR_ProfessionID; 
		public Guid CMN_STR_ProfessionKeyID; 
		public String SocialSecurityProfessionKey; 
		public Guid CMN_STR_SkillID; 
		public Dict Skill_Name; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3P_GPfT_1537[] Convert(List<L3P_GPfT_1537_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3P_GPfT_1537 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_STR_ProfessionID)).ToArray()
	group el_L3P_GPfT_1537 by new 
	{ 
		el_L3P_GPfT_1537.CMN_STR_ProfessionID,

	}
	into gfunct_L3P_GPfT_1537
	select new L3P_GPfT_1537
	{     
		ProfessionName = gfunct_L3P_GPfT_1537.FirstOrDefault().ProfessionName ,
		CMN_STR_ProfessionID = gfunct_L3P_GPfT_1537.Key.CMN_STR_ProfessionID ,
		CMN_STR_ProfessionKeyID = gfunct_L3P_GPfT_1537.FirstOrDefault().CMN_STR_ProfessionKeyID ,
		SocialSecurityProfessionKey = gfunct_L3P_GPfT_1537.FirstOrDefault().SocialSecurityProfessionKey ,

		Skills = 
		(
			from el_Skills in gfunct_L3P_GPfT_1537.Where(element => !EqualsDefaultValue(element.CMN_STR_SkillID)).ToArray()
			group el_Skills by new 
			{ 
				el_Skills.CMN_STR_SkillID,

			}
			into gfunct_Skills
			select new L3P_GPfT_1537_Skills
			{     
				CMN_STR_SkillID = gfunct_Skills.Key.CMN_STR_SkillID ,
				Skill_Name = gfunct_Skills.FirstOrDefault().Skill_Name ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3P_GPfT_1537_Array : FR_Base
	{
		public L3P_GPfT_1537[] Result	{ get; set; } 
		public FR_L3P_GPfT_1537_Array() : base() {}

		public FR_L3P_GPfT_1537_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3P_GPfT_1537 for attribute L3P_GPfT_1537
		[DataContract]
		public class L3P_GPfT_1537 
		{
			[DataMember]
			public L3P_GPfT_1537_Skills[] Skills { get; set; }

			//Standard type parameters
			[DataMember]
			public Dict ProfessionName { get; set; } 
			[DataMember]
			public Guid CMN_STR_ProfessionID { get; set; } 
			[DataMember]
			public Guid CMN_STR_ProfessionKeyID { get; set; } 
			[DataMember]
			public String SocialSecurityProfessionKey { get; set; } 

		}
		#endregion
		#region SClass L3P_GPfT_1537_Skills for attribute Skills
		[DataContract]
		public class L3P_GPfT_1537_Skills 
		{
			//Standard type parameters
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
FR_L3P_GPfT_1537_Array cls_Get_Professions_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3P_GPfT_1537_Array invocationResult = cls_Get_Professions_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

