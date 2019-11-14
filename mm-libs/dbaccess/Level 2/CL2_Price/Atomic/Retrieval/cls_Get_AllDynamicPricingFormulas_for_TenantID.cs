/* 
 * Generated on 10/20/2014 1:30:55 PM
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

namespace CL2_Price.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllDynamicPricingFormulas_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllDynamicPricingFormulas_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2DF_GADPFfPL_1017_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2DF_GADPFfPL_1017_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Price.Atomic.Retrieval.SQL.cls_Get_AllDynamicPricingFormulas_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2DF_GADPFfPL_1017_raw> results = new List<L2DF_GADPFfPL_1017_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_SLS_DynamicPricingFormula_TypeID","DynamicPricingFormulaType_Name_DictID","DefaultDynamicPricingFormula","CMN_SLS_DPF_Type_ProcurementPriceDependencyID","ApplicableFrom_ProcurementPrice","ApplicableThrough_ProcurementPrice","DynamicPricingFormula","IsDeleted" });
				while(reader.Read())
				{
					L2DF_GADPFfPL_1017_raw resultItem = new L2DF_GADPFfPL_1017_raw();
					//0:Parameter CMN_SLS_DynamicPricingFormula_TypeID of type Guid
					resultItem.CMN_SLS_DynamicPricingFormula_TypeID = reader.GetGuid(0);
					//1:Parameter DynamicPricingFormulaType_Name of type Dict
					resultItem.DynamicPricingFormulaType_Name = reader.GetDictionary(1);
					resultItem.DynamicPricingFormulaType_Name.SourceTable = "cmn_sls_dynamicpricingformula_types";
					loader.Append(resultItem.DynamicPricingFormulaType_Name);
					//2:Parameter DefaultDynamicPricingFormula of type String
					resultItem.DefaultDynamicPricingFormula = reader.GetString(2);
					//3:Parameter CMN_SLS_DPF_Type_ProcurementPriceDependencyID of type Guid
					resultItem.CMN_SLS_DPF_Type_ProcurementPriceDependencyID = reader.GetGuid(3);
					//4:Parameter ApplicableFrom_ProcurementPrice of type Decimal
					resultItem.ApplicableFrom_ProcurementPrice = reader.GetDecimal(4);
					//5:Parameter ApplicableThrough_ProcurementPrice of type Decimal
					resultItem.ApplicableThrough_ProcurementPrice = reader.GetDecimal(5);
					//6:Parameter DynamicPricingFormula of type String
					resultItem.DynamicPricingFormula = reader.GetString(6);
					//7:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllDynamicPricingFormulas_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L2DF_GADPFfPL_1017_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2DF_GADPFfPL_1017_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2DF_GADPFfPL_1017_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2DF_GADPFfPL_1017_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2DF_GADPFfPL_1017_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2DF_GADPFfPL_1017_Array functionReturn = new FR_L2DF_GADPFfPL_1017_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllDynamicPricingFormulas_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L2DF_GADPFfPL_1017_raw 
	{
		public Guid CMN_SLS_DynamicPricingFormula_TypeID; 
		public Dict DynamicPricingFormulaType_Name; 
		public String DefaultDynamicPricingFormula; 
		public Guid CMN_SLS_DPF_Type_ProcurementPriceDependencyID; 
		public Decimal ApplicableFrom_ProcurementPrice; 
		public Decimal ApplicableThrough_ProcurementPrice; 
		public String DynamicPricingFormula; 
		public bool IsDeleted; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L2DF_GADPFfPL_1017[] Convert(List<L2DF_GADPFfPL_1017_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L2DF_GADPFfPL_1017 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_SLS_DynamicPricingFormula_TypeID)).ToArray()
	group el_L2DF_GADPFfPL_1017 by new 
	{ 
		el_L2DF_GADPFfPL_1017.CMN_SLS_DynamicPricingFormula_TypeID,

	}
	into gfunct_L2DF_GADPFfPL_1017
	select new L2DF_GADPFfPL_1017
	{     
		CMN_SLS_DynamicPricingFormula_TypeID = gfunct_L2DF_GADPFfPL_1017.Key.CMN_SLS_DynamicPricingFormula_TypeID ,
		DynamicPricingFormulaType_Name = gfunct_L2DF_GADPFfPL_1017.FirstOrDefault().DynamicPricingFormulaType_Name ,
		DefaultDynamicPricingFormula = gfunct_L2DF_GADPFfPL_1017.FirstOrDefault().DefaultDynamicPricingFormula ,

		PriceRanges = 
		(
			from el_PriceRanges in gfunct_L2DF_GADPFfPL_1017.Where(element => !EqualsDefaultValue(element.CMN_SLS_DPF_Type_ProcurementPriceDependencyID)).ToArray()
			group el_PriceRanges by new 
			{ 
				el_PriceRanges.CMN_SLS_DPF_Type_ProcurementPriceDependencyID,

			}
			into gfunct_PriceRanges
			select new L2DF_GADPFfPL_1017a
			{     
				CMN_SLS_DPF_Type_ProcurementPriceDependencyID = gfunct_PriceRanges.Key.CMN_SLS_DPF_Type_ProcurementPriceDependencyID ,
				ApplicableFrom_ProcurementPrice = gfunct_PriceRanges.FirstOrDefault().ApplicableFrom_ProcurementPrice ,
				ApplicableThrough_ProcurementPrice = gfunct_PriceRanges.FirstOrDefault().ApplicableThrough_ProcurementPrice ,
				DynamicPricingFormula = gfunct_PriceRanges.FirstOrDefault().DynamicPricingFormula ,
				IsDeleted = gfunct_PriceRanges.FirstOrDefault().IsDeleted ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L2DF_GADPFfPL_1017_Array : FR_Base
	{
		public L2DF_GADPFfPL_1017[] Result	{ get; set; } 
		public FR_L2DF_GADPFfPL_1017_Array() : base() {}

		public FR_L2DF_GADPFfPL_1017_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2DF_GADPFfPL_1017 for attribute L2DF_GADPFfPL_1017
		[DataContract]
		public class L2DF_GADPFfPL_1017 
		{
			[DataMember]
			public L2DF_GADPFfPL_1017a[] PriceRanges { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_DynamicPricingFormula_TypeID { get; set; } 
			[DataMember]
			public Dict DynamicPricingFormulaType_Name { get; set; } 
			[DataMember]
			public String DefaultDynamicPricingFormula { get; set; } 

		}
		#endregion
		#region SClass L2DF_GADPFfPL_1017a for attribute PriceRanges
		[DataContract]
		public class L2DF_GADPFfPL_1017a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_DPF_Type_ProcurementPriceDependencyID { get; set; } 
			[DataMember]
			public Decimal ApplicableFrom_ProcurementPrice { get; set; } 
			[DataMember]
			public Decimal ApplicableThrough_ProcurementPrice { get; set; } 
			[DataMember]
			public String DynamicPricingFormula { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2DF_GADPFfPL_1017_Array cls_Get_AllDynamicPricingFormulas_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2DF_GADPFfPL_1017_Array invocationResult = cls_Get_AllDynamicPricingFormulas_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

