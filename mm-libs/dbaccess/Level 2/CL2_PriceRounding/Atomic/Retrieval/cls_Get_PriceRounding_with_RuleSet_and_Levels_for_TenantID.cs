/* 
 * Generated on 18/12/2013 11:04:23
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

namespace CL2_PriceRounding.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PriceRounding_with_RuleSet_and_Levels_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PriceRounding_with_RuleSet_and_Levels_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PR_GPRwRSaLfT_1358_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2PR_GPRwRSaLfT_1358_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_PriceRounding.Atomic.Retrieval.SQL.cls_Get_PriceRounding_with_RuleSet_and_Levels_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2PR_GPRwRSaLfT_1358_raw> results = new List<L2PR_GPRwRSaLfT_1358_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_SLS_Price_RoundingRuleSetID","RuleSet_Name_DictID","MaximumPriceIncreaseInPercent","MaximumPriceDecreaseInPercent","CMN_SLS_Price_RoundingID","Amount_From","Amount_To","IsAmountTo_Specified","IsRoundingDeleted","CMN_SLS_Price_RoundingLevelID","RoundingAmount","IsDeleted" });
				while(reader.Read())
				{
					L2PR_GPRwRSaLfT_1358_raw resultItem = new L2PR_GPRwRSaLfT_1358_raw();
					//0:Parameter CMN_SLS_Price_RoundingRuleSetID of type Guid
					resultItem.CMN_SLS_Price_RoundingRuleSetID = reader.GetGuid(0);
					//1:Parameter RuleSet_Name of type Dict
					resultItem.RuleSet_Name = reader.GetDictionary(1);
					resultItem.RuleSet_Name.SourceTable = "cmn_sls_price_roundingruleset";
					loader.Append(resultItem.RuleSet_Name);
					//2:Parameter MaximumPriceIncreaseInPercent of type decimal
					resultItem.MaximumPriceIncreaseInPercent = reader.GetDecimal(2);
					//3:Parameter MaximumPriceDecreaseInPercent of type decimal
					resultItem.MaximumPriceDecreaseInPercent = reader.GetDecimal(3);
					//4:Parameter CMN_SLS_Price_RoundingID of type Guid
					resultItem.CMN_SLS_Price_RoundingID = reader.GetGuid(4);
					//5:Parameter Amount_From of type decimal
					resultItem.Amount_From = reader.GetDecimal(5);
					//6:Parameter Amount_To of type decimal
					resultItem.Amount_To = reader.GetDecimal(6);
					//7:Parameter IsAmountTo_Specified of type bool
					resultItem.IsAmountTo_Specified = reader.GetBoolean(7);
					//8:Parameter IsRoundingDeleted of type bool
					resultItem.IsRoundingDeleted = reader.GetBoolean(8);
					//9:Parameter CMN_SLS_Price_RoundingLevelID of type Guid
					resultItem.CMN_SLS_Price_RoundingLevelID = reader.GetGuid(9);
					//10:Parameter RoundingAmount of type double
					resultItem.RoundingAmount = reader.GetDouble(10);
					//11:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PriceRounding_with_RuleSet_and_Levels_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L2PR_GPRwRSaLfT_1358_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2PR_GPRwRSaLfT_1358_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PR_GPRwRSaLfT_1358_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PR_GPRwRSaLfT_1358_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PR_GPRwRSaLfT_1358_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PR_GPRwRSaLfT_1358_Array functionReturn = new FR_L2PR_GPRwRSaLfT_1358_Array();
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

				throw new Exception("Exception occured in method cls_Get_PriceRounding_with_RuleSet_and_Levels_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L2PR_GPRwRSaLfT_1358_raw 
	{
		public Guid CMN_SLS_Price_RoundingRuleSetID; 
		public Dict RuleSet_Name; 
		public decimal MaximumPriceIncreaseInPercent; 
		public decimal MaximumPriceDecreaseInPercent; 
		public Guid CMN_SLS_Price_RoundingID; 
		public decimal Amount_From; 
		public decimal Amount_To; 
		public bool IsAmountTo_Specified; 
		public bool IsRoundingDeleted; 
		public Guid CMN_SLS_Price_RoundingLevelID; 
		public double RoundingAmount; 
		public bool IsDeleted; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L2PR_GPRwRSaLfT_1358[] Convert(List<L2PR_GPRwRSaLfT_1358_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L2PR_GPRwRSaLfT_1358 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_SLS_Price_RoundingID)).ToArray()
	group el_L2PR_GPRwRSaLfT_1358 by new 
	{ 
		el_L2PR_GPRwRSaLfT_1358.CMN_SLS_Price_RoundingID,

	}
	into gfunct_L2PR_GPRwRSaLfT_1358
	select new L2PR_GPRwRSaLfT_1358
	{     
		CMN_SLS_Price_RoundingRuleSetID = gfunct_L2PR_GPRwRSaLfT_1358.FirstOrDefault().CMN_SLS_Price_RoundingRuleSetID ,
		RuleSet_Name = gfunct_L2PR_GPRwRSaLfT_1358.FirstOrDefault().RuleSet_Name ,
		MaximumPriceIncreaseInPercent = gfunct_L2PR_GPRwRSaLfT_1358.FirstOrDefault().MaximumPriceIncreaseInPercent ,
		MaximumPriceDecreaseInPercent = gfunct_L2PR_GPRwRSaLfT_1358.FirstOrDefault().MaximumPriceDecreaseInPercent ,
		CMN_SLS_Price_RoundingID = gfunct_L2PR_GPRwRSaLfT_1358.Key.CMN_SLS_Price_RoundingID ,
		Amount_From = gfunct_L2PR_GPRwRSaLfT_1358.FirstOrDefault().Amount_From ,
		Amount_To = gfunct_L2PR_GPRwRSaLfT_1358.FirstOrDefault().Amount_To ,
		IsAmountTo_Specified = gfunct_L2PR_GPRwRSaLfT_1358.FirstOrDefault().IsAmountTo_Specified ,
		IsRoundingDeleted = gfunct_L2PR_GPRwRSaLfT_1358.FirstOrDefault().IsRoundingDeleted ,

		RoundingLevels = 
		(
			from el_RoundingLevels in gfunct_L2PR_GPRwRSaLfT_1358.Where(element => !EqualsDefaultValue(element.CMN_SLS_Price_RoundingLevelID)).ToArray()
			group el_RoundingLevels by new 
			{ 
				el_RoundingLevels.CMN_SLS_Price_RoundingLevelID,

			}
			into gfunct_RoundingLevels
			select new L2PR_GPRwRSaLfT_1358_RoundingLevel
			{     
				CMN_SLS_Price_RoundingLevelID = gfunct_RoundingLevels.Key.CMN_SLS_Price_RoundingLevelID ,
				RoundingAmount = gfunct_RoundingLevels.FirstOrDefault().RoundingAmount ,
				IsDeleted = gfunct_RoundingLevels.FirstOrDefault().IsDeleted ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L2PR_GPRwRSaLfT_1358_Array : FR_Base
	{
		public L2PR_GPRwRSaLfT_1358[] Result	{ get; set; } 
		public FR_L2PR_GPRwRSaLfT_1358_Array() : base() {}

		public FR_L2PR_GPRwRSaLfT_1358_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2PR_GPRwRSaLfT_1358 for attribute L2PR_GPRwRSaLfT_1358
		[DataContract]
		public class L2PR_GPRwRSaLfT_1358 
		{
			[DataMember]
			public L2PR_GPRwRSaLfT_1358_RoundingLevel[] RoundingLevels { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_Price_RoundingRuleSetID { get; set; } 
			[DataMember]
			public Dict RuleSet_Name { get; set; } 
			[DataMember]
			public decimal MaximumPriceIncreaseInPercent { get; set; } 
			[DataMember]
			public decimal MaximumPriceDecreaseInPercent { get; set; } 
			[DataMember]
			public Guid CMN_SLS_Price_RoundingID { get; set; } 
			[DataMember]
			public decimal Amount_From { get; set; } 
			[DataMember]
			public decimal Amount_To { get; set; } 
			[DataMember]
			public bool IsAmountTo_Specified { get; set; } 
			[DataMember]
			public bool IsRoundingDeleted { get; set; } 

		}
		#endregion
		#region SClass L2PR_GPRwRSaLfT_1358_RoundingLevel for attribute RoundingLevels
		[DataContract]
		public class L2PR_GPRwRSaLfT_1358_RoundingLevel 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_Price_RoundingLevelID { get; set; } 
			[DataMember]
			public double RoundingAmount { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PR_GPRwRSaLfT_1358_Array cls_Get_PriceRounding_with_RuleSet_and_Levels_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PR_GPRwRSaLfT_1358_Array invocationResult = cls_Get_PriceRounding_with_RuleSet_and_Levels_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

