/* 
 * Generated on 8/14/2014 4:55:34 PM
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

namespace CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProfesionsNeededForWebWidget.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProfesionsNeededForWebWidget
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AP_GPNFWW_1653_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AP_GPNFWW_1653_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.SQL.cls_Get_ProfesionsNeededForWebWidget.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5AP_GPNFWW_1653_raw> results = new List<L5AP_GPNFWW_1653_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_STR_ProfessionID","CMN_STR_SkillID" });
				while(reader.Read())
				{
					L5AP_GPNFWW_1653_raw resultItem = new L5AP_GPNFWW_1653_raw();
					//0:Parameter CMN_STR_ProfessionID of type Guid
					resultItem.CMN_STR_ProfessionID = reader.GetGuid(0);
					//1:Parameter CMN_STR_SkillID of type Guid
					resultItem.CMN_STR_SkillID = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProfesionsNeededForWebWidget",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AP_GPNFWW_1653_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AP_GPNFWW_1653_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AP_GPNFWW_1653_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AP_GPNFWW_1653_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AP_GPNFWW_1653_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AP_GPNFWW_1653_Array functionReturn = new FR_L5AP_GPNFWW_1653_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProfesionsNeededForWebWidget",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AP_GPNFWW_1653_raw 
	{
		public Guid CMN_STR_ProfessionID; 
		public Guid CMN_STR_SkillID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AP_GPNFWW_1653[] Convert(List<L5AP_GPNFWW_1653_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AP_GPNFWW_1653 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_STR_ProfessionID)).ToArray()
	group el_L5AP_GPNFWW_1653 by new 
	{ 
		el_L5AP_GPNFWW_1653.CMN_STR_ProfessionID,

	}
	into gfunct_L5AP_GPNFWW_1653
	select new L5AP_GPNFWW_1653
	{     
		CMN_STR_ProfessionID = gfunct_L5AP_GPNFWW_1653.Key.CMN_STR_ProfessionID ,

		Skill = 
		(
			from el_Skill in gfunct_L5AP_GPNFWW_1653.Where(element => !EqualsDefaultValue(element.CMN_STR_SkillID)).ToArray()
			group el_Skill by new 
			{ 
				el_Skill.CMN_STR_SkillID,

			}
			into gfunct_Skill
			select new L5AP_GPNFWW_1653_Skill
			{     
				CMN_STR_SkillID = gfunct_Skill.Key.CMN_STR_SkillID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AP_GPNFWW_1653_Array : FR_Base
	{
		public L5AP_GPNFWW_1653[] Result	{ get; set; } 
		public FR_L5AP_GPNFWW_1653_Array() : base() {}

		public FR_L5AP_GPNFWW_1653_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5AP_GPNFWW_1653 for attribute L5AP_GPNFWW_1653
		[DataContract]
		public class L5AP_GPNFWW_1653 
		{
			[DataMember]
			public L5AP_GPNFWW_1653_Skill[] Skill { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_ProfessionID { get; set; } 

		}
		#endregion
		#region SClass L5AP_GPNFWW_1653_Skill for attribute Skill
		[DataContract]
		public class L5AP_GPNFWW_1653_Skill 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_SkillID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AP_GPNFWW_1653_Array cls_Get_ProfesionsNeededForWebWidget(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AP_GPNFWW_1653_Array invocationResult = cls_Get_ProfesionsNeededForWebWidget.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
