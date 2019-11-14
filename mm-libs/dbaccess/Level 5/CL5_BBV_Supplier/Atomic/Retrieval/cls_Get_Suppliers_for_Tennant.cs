/* 
 * Generated on 7/16/2013 11:35:24 AM
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

namespace CL5_BBV_Supplier.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Suppliers_for_Tennant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Suppliers_for_Tennant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SP_GSI_0933_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SP_GSI_0933_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_BBV_Supplier.Atomic.Retrieval.SQL.cls_Get_Suppliers_for_Tennant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L5SP_GSI_0933_raw> results = new List<L5SP_GSI_0933_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_SupplierID","CMN_BPT_BusinessParticipantID","CompanyName_Line1" });
				while(reader.Read())
				{
					L5SP_GSI_0933_raw resultItem = new L5SP_GSI_0933_raw();
					//0:Parameter CMN_BPT_SupplierID of type Guid
					resultItem.CMN_BPT_SupplierID = reader.GetGuid(0);
					//1:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(1);
					//2:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5SP_GSI_0933_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SP_GSI_0933_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SP_GSI_0933_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SP_GSI_0933_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SP_GSI_0933_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SP_GSI_0933_Array functionReturn = new FR_L5SP_GSI_0933_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5SP_GSI_0933_raw 
	{
		public Guid CMN_BPT_SupplierID; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public String CompanyName_Line1; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5SP_GSI_0933[] Convert(List<L5SP_GSI_0933_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5SP_GSI_0933 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_SupplierID)).ToArray()
	group el_L5SP_GSI_0933 by new 
	{ 
		el_L5SP_GSI_0933.CMN_BPT_SupplierID,

	}
	into gfunct_L5SP_GSI_0933
	select new L5SP_GSI_0933
	{     
		CMN_BPT_SupplierID = gfunct_L5SP_GSI_0933.Key.CMN_BPT_SupplierID ,
		CMN_BPT_BusinessParticipantID = gfunct_L5SP_GSI_0933.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
		CompanyName_Line1 = gfunct_L5SP_GSI_0933.FirstOrDefault().CompanyName_Line1 ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5SP_GSI_0933_Array : FR_Base
	{
		public L5SP_GSI_0933[] Result	{ get; set; } 
		public FR_L5SP_GSI_0933_Array() : base() {}

		public FR_L5SP_GSI_0933_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5SP_GSI_0933 for attribute L5SP_GSI_0933
		[DataContract]
		public class L5SP_GSI_0933 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_SupplierID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 

		}
		#endregion

	#endregion
}
