/* 
 * Generated on 2.2.2015 2:05:04
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

namespace CL3_DistributionArea.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DistributionAreas_With_Country_Assignments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DistributionAreas_With_Country_Assignments
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DA_GDAwCA_0137_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DA_GDAwCA_0137_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_DistributionArea.Complex.Retrieval.SQL.cls_Get_DistributionAreas_With_Country_Assignments.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3DA_GDAwCA_0137_raw> results = new List<L3DA_GDAwCA_0137_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_REG_DistributionAreaID","DistributionArea_Name_DictID","DistributionArea_Description_DictID","AssignmentID","CMN_CountryID","Country_Name_DictID","Country_ISOCode_Alpha2","IsActive","IsDefault" });
				while(reader.Read())
				{
					L3DA_GDAwCA_0137_raw resultItem = new L3DA_GDAwCA_0137_raw();
					//0:Parameter LOG_REG_DistributionAreaID of type Guid
					resultItem.LOG_REG_DistributionAreaID = reader.GetGuid(0);
					//1:Parameter DistributionArea_Name of type Dict
					resultItem.DistributionArea_Name = reader.GetDictionary(1);
					resultItem.DistributionArea_Name.SourceTable = "log_reg_distributionareas";
					loader.Append(resultItem.DistributionArea_Name);
					//2:Parameter DistributionArea_Description of type Dict
					resultItem.DistributionArea_Description = reader.GetDictionary(2);
					resultItem.DistributionArea_Description.SourceTable = "log_reg_distributionareas";
					loader.Append(resultItem.DistributionArea_Description);
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
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DistributionAreas_With_Country_Assignments",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3DA_GDAwCA_0137_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3DA_GDAwCA_0137_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DA_GDAwCA_0137_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DA_GDAwCA_0137_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DA_GDAwCA_0137_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DA_GDAwCA_0137_Array functionReturn = new FR_L3DA_GDAwCA_0137_Array();
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

				throw new Exception("Exception occured in method cls_Get_DistributionAreas_With_Country_Assignments",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3DA_GDAwCA_0137_raw 
	{
		public Guid LOG_REG_DistributionAreaID; 
		public Dict DistributionArea_Name; 
		public Dict DistributionArea_Description; 
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

		public static L3DA_GDAwCA_0137[] Convert(List<L3DA_GDAwCA_0137_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3DA_GDAwCA_0137 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.LOG_REG_DistributionAreaID)).ToArray()
	group el_L3DA_GDAwCA_0137 by new 
	{ 
		el_L3DA_GDAwCA_0137.LOG_REG_DistributionAreaID,

	}
	into gfunct_L3DA_GDAwCA_0137
	select new L3DA_GDAwCA_0137
	{     
		LOG_REG_DistributionAreaID = gfunct_L3DA_GDAwCA_0137.Key.LOG_REG_DistributionAreaID ,
		DistributionArea_Name = gfunct_L3DA_GDAwCA_0137.FirstOrDefault().DistributionArea_Name ,
		DistributionArea_Description = gfunct_L3DA_GDAwCA_0137.FirstOrDefault().DistributionArea_Description ,

		CountryAssignments = 
		(
			from el_CountryAssignments in gfunct_L3DA_GDAwCA_0137.ToArray()
			select new L3DA_GDAwCA_0137a
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
	public class FR_L3DA_GDAwCA_0137_Array : FR_Base
	{
		public L3DA_GDAwCA_0137[] Result	{ get; set; } 
		public FR_L3DA_GDAwCA_0137_Array() : base() {}

		public FR_L3DA_GDAwCA_0137_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3DA_GDAwCA_0137 for attribute L3DA_GDAwCA_0137
		[DataContract]
		public class L3DA_GDAwCA_0137 
		{
			[DataMember]
			public L3DA_GDAwCA_0137a[] CountryAssignments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid LOG_REG_DistributionAreaID { get; set; } 
			[DataMember]
			public Dict DistributionArea_Name { get; set; } 
			[DataMember]
			public Dict DistributionArea_Description { get; set; } 

		}
		#endregion
		#region SClass L3DA_GDAwCA_0137a for attribute CountryAssignments
		[DataContract]
		public class L3DA_GDAwCA_0137a 
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
FR_L3DA_GDAwCA_0137_Array cls_Get_DistributionAreas_With_Country_Assignments(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DA_GDAwCA_0137_Array invocationResult = cls_Get_DistributionAreas_With_Country_Assignments.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

