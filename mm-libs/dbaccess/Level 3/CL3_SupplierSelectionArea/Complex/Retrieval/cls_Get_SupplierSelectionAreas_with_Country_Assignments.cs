/* 
 * Generated on 2.2.2015 2:09:29
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

namespace CL3_SupplierSelectionArea.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_SupplierSelectionAreas_with_Country_Assignments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_SupplierSelectionAreas_with_Country_Assignments
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3SA_GSSAwCA_0203_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3SA_GSSAwCA_0203_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_SupplierSelectionArea.Complex.Retrieval.SQL.cls_Get_SupplierSelectionAreas_with_Country_Assignments.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3SA_GSSAwCA_0203_raw> results = new List<L3SA_GSSAwCA_0203_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_REG_SupplierSelectionAreaID","SupplierSelectionArea_Name_DictID","SupplierSelectionArea_Description_DictID","AssignmentID","CMN_CountryID","Country_Name_DictID","Country_ISOCode_Alpha2","IsActive","IsDefault" });
				while(reader.Read())
				{
					L3SA_GSSAwCA_0203_raw resultItem = new L3SA_GSSAwCA_0203_raw();
					//0:Parameter LOG_REG_SupplierSelectionAreaID of type Guid
					resultItem.LOG_REG_SupplierSelectionAreaID = reader.GetGuid(0);
					//1:Parameter SupplierSelectionArea_Name of type Dict
					resultItem.SupplierSelectionArea_Name = reader.GetDictionary(1);
					resultItem.SupplierSelectionArea_Name.SourceTable = "log_reg_supplierselectionareas";
					loader.Append(resultItem.SupplierSelectionArea_Name);
					//2:Parameter SupplierSelectionArea_Description of type Dict
					resultItem.SupplierSelectionArea_Description = reader.GetDictionary(2);
					resultItem.SupplierSelectionArea_Description.SourceTable = "log_reg_supplierselectionareas";
					loader.Append(resultItem.SupplierSelectionArea_Description);
					//3:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(3);
					//4:Parameter CMN_CountryID of type Guid
					resultItem.CMN_CountryID = reader.GetGuid(4);
					//5:Parameter Country_Name of type Dict
					resultItem.Country_Name = reader.GetDictionary(5);
					resultItem.Country_Name.SourceTable = "cmn_countries";
					loader.Append(resultItem.Country_Name);
					//6:Parameter Country_ISOCode_Alpha2 of type string
					resultItem.Country_ISOCode_Alpha2 = reader.GetString(6);
					//7:Parameter IsActive of type bool
					resultItem.IsActive = reader.GetBoolean(7);
					//8:Parameter IsDefault of type bool
					resultItem.IsDefault = reader.GetBoolean(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_SupplierSelectionAreas_with_Country_Assignments",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3SA_GSSAwCA_0203_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3SA_GSSAwCA_0203_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3SA_GSSAwCA_0203_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3SA_GSSAwCA_0203_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3SA_GSSAwCA_0203_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3SA_GSSAwCA_0203_Array functionReturn = new FR_L3SA_GSSAwCA_0203_Array();
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

				throw new Exception("Exception occured in method cls_Get_SupplierSelectionAreas_with_Country_Assignments",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3SA_GSSAwCA_0203_raw 
	{
		public Guid LOG_REG_SupplierSelectionAreaID; 
		public Dict SupplierSelectionArea_Name; 
		public Dict SupplierSelectionArea_Description; 
		public Guid AssignmentID; 
		public Guid CMN_CountryID; 
		public Dict Country_Name; 
		public string Country_ISOCode_Alpha2; 
		public bool IsActive; 
		public bool IsDefault; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3SA_GSSAwCA_0203[] Convert(List<L3SA_GSSAwCA_0203_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3SA_GSSAwCA_0203 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.LOG_REG_SupplierSelectionAreaID)).ToArray()
	group el_L3SA_GSSAwCA_0203 by new 
	{ 
		el_L3SA_GSSAwCA_0203.LOG_REG_SupplierSelectionAreaID,

	}
	into gfunct_L3SA_GSSAwCA_0203
	select new L3SA_GSSAwCA_0203
	{     
		LOG_REG_SupplierSelectionAreaID = gfunct_L3SA_GSSAwCA_0203.Key.LOG_REG_SupplierSelectionAreaID ,
		SupplierSelectionArea_Name = gfunct_L3SA_GSSAwCA_0203.FirstOrDefault().SupplierSelectionArea_Name ,
		SupplierSelectionArea_Description = gfunct_L3SA_GSSAwCA_0203.FirstOrDefault().SupplierSelectionArea_Description ,

		CountryAssignments = 
		(
			from el_CountryAssignments in gfunct_L3SA_GSSAwCA_0203.ToArray()
			select new L3SA_GSSAwCA_0203a
			{     
				AssignmentID = el_CountryAssignments.AssignmentID,
				CMN_CountryID = el_CountryAssignments.CMN_CountryID,
				Country_Name = el_CountryAssignments.Country_Name,
				Country_ISOCode_Alpha2 = el_CountryAssignments.Country_ISOCode_Alpha2,
				IsActive = el_CountryAssignments.IsActive,
				IsDefault = el_CountryAssignments.IsDefault,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3SA_GSSAwCA_0203_Array : FR_Base
	{
		public L3SA_GSSAwCA_0203[] Result	{ get; set; } 
		public FR_L3SA_GSSAwCA_0203_Array() : base() {}

		public FR_L3SA_GSSAwCA_0203_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3SA_GSSAwCA_0203 for attribute L3SA_GSSAwCA_0203
		[DataContract]
		public class L3SA_GSSAwCA_0203 
		{
			[DataMember]
			public L3SA_GSSAwCA_0203a[] CountryAssignments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid LOG_REG_SupplierSelectionAreaID { get; set; } 
			[DataMember]
			public Dict SupplierSelectionArea_Name { get; set; } 
			[DataMember]
			public Dict SupplierSelectionArea_Description { get; set; } 

		}
		#endregion
		#region SClass L3SA_GSSAwCA_0203a for attribute CountryAssignments
		[DataContract]
		public class L3SA_GSSAwCA_0203a 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid CMN_CountryID { get; set; } 
			[DataMember]
			public Dict Country_Name { get; set; } 
			[DataMember]
			public string Country_ISOCode_Alpha2 { get; set; } 
			[DataMember]
			public bool IsActive { get; set; } 
			[DataMember]
			public bool IsDefault { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3SA_GSSAwCA_0203_Array cls_Get_SupplierSelectionAreas_with_Country_Assignments(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3SA_GSSAwCA_0203_Array invocationResult = cls_Get_SupplierSelectionAreas_with_Country_Assignments.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

