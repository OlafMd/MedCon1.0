/* 
 * Generated on 7/31/2013 3:44:45 PM
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

namespace CL5_KPRS_Actions.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_get_Actions_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_get_Actions_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AT_GAFT_1131_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AT_GAFT_1131_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_Actions.Atomic.Retrieval.SQL.cls_get_Actions_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5AT_GAFT_1131_raw> results = new List<L5AT_GAFT_1131_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RES_ACT_ActionID","CurrentVersion_RefID","RES_ACT_Action_VersionID","Action_Name_DictID","Action_Description_DictID","Action_Version","CMN_Price_ValueID","CMN_PriceID","PriceValue_Currency_RefID","PriceValue_Amount","CMN_UnitID","Label_DictID" });
				while(reader.Read())
				{
					L5AT_GAFT_1131_raw resultItem = new L5AT_GAFT_1131_raw();
					//0:Parameter RES_ACT_ActionID of type Guid
					resultItem.RES_ACT_ActionID = reader.GetGuid(0);
					//1:Parameter CurrentVersion_RefID of type Guid
					resultItem.CurrentVersion_RefID = reader.GetGuid(1);
					//2:Parameter RES_ACT_Action_VersionID of type Guid
					resultItem.RES_ACT_Action_VersionID = reader.GetGuid(2);
					//3:Parameter Action_Name of type Dict
					resultItem.Action_Name = reader.GetDictionary(3);
					resultItem.Action_Name.SourceTable = "res_act_action_version";
					loader.Append(resultItem.Action_Name);
					//4:Parameter Action_Description of type Dict
					resultItem.Action_Description = reader.GetDictionary(4);
					resultItem.Action_Description.SourceTable = "res_act_action_version";
					loader.Append(resultItem.Action_Description);
					//5:Parameter Action_Version of type int
					resultItem.Action_Version = reader.GetInteger(5);
					//6:Parameter CMN_Price_ValueID of type Guid
					resultItem.CMN_Price_ValueID = reader.GetGuid(6);
					//7:Parameter CMN_PriceID of type Guid
					resultItem.CMN_PriceID = reader.GetGuid(7);
					//8:Parameter PriceValue_Currency_RefID of type Guid
					resultItem.PriceValue_Currency_RefID = reader.GetGuid(8);
					//9:Parameter PriceValue_Amount of type double
					resultItem.PriceValue_Amount = reader.GetDouble(9);
					//10:Parameter CMN_UnitID of type Guid
					resultItem.CMN_UnitID = reader.GetGuid(10);
					//11:Parameter Label of type Dict
					resultItem.Label = reader.GetDictionary(11);
					resultItem.Label.SourceTable = "cmn_units";
					loader.Append(resultItem.Label);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_get_Actions_For_Tenant",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5AT_GAFT_1131_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AT_GAFT_1131_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AT_GAFT_1131_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AT_GAFT_1131_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AT_GAFT_1131_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AT_GAFT_1131_Array functionReturn = new FR_L5AT_GAFT_1131_Array();
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

				throw new Exception("Exception occured in method cls_get_Actions_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5AT_GAFT_1131_raw 
	{
		public Guid RES_ACT_ActionID; 
		public Guid CurrentVersion_RefID; 
		public Guid RES_ACT_Action_VersionID; 
		public Dict Action_Name; 
		public Dict Action_Description; 
		public int Action_Version; 
		public Guid CMN_Price_ValueID; 
		public Guid CMN_PriceID; 
		public Guid PriceValue_Currency_RefID; 
		public double PriceValue_Amount; 
		public Guid CMN_UnitID; 
		public Dict Label; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5AT_GAFT_1131[] Convert(List<L5AT_GAFT_1131_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5AT_GAFT_1131 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_ACT_ActionID)).ToArray()
	group el_L5AT_GAFT_1131 by new 
	{ 
		el_L5AT_GAFT_1131.RES_ACT_ActionID,

	}
	into gfunct_L5AT_GAFT_1131
	select new L5AT_GAFT_1131
	{     
		RES_ACT_ActionID = gfunct_L5AT_GAFT_1131.Key.RES_ACT_ActionID ,
		CurrentVersion_RefID = gfunct_L5AT_GAFT_1131.FirstOrDefault().CurrentVersion_RefID ,
		RES_ACT_Action_VersionID = gfunct_L5AT_GAFT_1131.FirstOrDefault().RES_ACT_Action_VersionID ,
		Action_Name = gfunct_L5AT_GAFT_1131.FirstOrDefault().Action_Name ,
		Action_Description = gfunct_L5AT_GAFT_1131.FirstOrDefault().Action_Description ,
		Action_Version = gfunct_L5AT_GAFT_1131.FirstOrDefault().Action_Version ,
		CMN_Price_ValueID = gfunct_L5AT_GAFT_1131.FirstOrDefault().CMN_Price_ValueID ,
		CMN_PriceID = gfunct_L5AT_GAFT_1131.FirstOrDefault().CMN_PriceID ,
		PriceValue_Currency_RefID = gfunct_L5AT_GAFT_1131.FirstOrDefault().PriceValue_Currency_RefID ,
		PriceValue_Amount = gfunct_L5AT_GAFT_1131.FirstOrDefault().PriceValue_Amount ,
		CMN_UnitID = gfunct_L5AT_GAFT_1131.FirstOrDefault().CMN_UnitID ,
		Label = gfunct_L5AT_GAFT_1131.FirstOrDefault().Label ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5AT_GAFT_1131_Array : FR_Base
	{
		public L5AT_GAFT_1131[] Result	{ get; set; } 
		public FR_L5AT_GAFT_1131_Array() : base() {}

		public FR_L5AT_GAFT_1131_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5AT_GAFT_1131 for attribute L5AT_GAFT_1131
		[DataContract]
		public class L5AT_GAFT_1131 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_ACT_ActionID { get; set; } 
			[DataMember]
			public Guid CurrentVersion_RefID { get; set; } 
			[DataMember]
			public Guid RES_ACT_Action_VersionID { get; set; } 
			[DataMember]
			public Dict Action_Name { get; set; } 
			[DataMember]
			public Dict Action_Description { get; set; } 
			[DataMember]
			public int Action_Version { get; set; } 
			[DataMember]
			public Guid CMN_Price_ValueID { get; set; } 
			[DataMember]
			public Guid CMN_PriceID { get; set; } 
			[DataMember]
			public Guid PriceValue_Currency_RefID { get; set; } 
			[DataMember]
			public double PriceValue_Amount { get; set; } 
			[DataMember]
			public Guid CMN_UnitID { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AT_GAFT_1131_Array cls_get_Actions_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AT_GAFT_1131_Array invocationResult = cls_get_Actions_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
