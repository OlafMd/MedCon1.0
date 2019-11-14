/* 
 * Generated on 10/27/2014 2:37:01 PM
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

namespace CL3_Dimension.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Dimension_Templates_With_Values.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Dimension_Templates_With_Values
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2DM_GADTWV_1413_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2DM_GADTWV_1413_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Dimension.Atomic.Retrieval.SQL.cls_Get_All_Dimension_Templates_With_Values.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2DM_GADTWV_1413_raw> results = new List<L2DM_GADTWV_1413_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_DimensionID","Product_RefID","Abbreviation","DimensionName_DictID","Dimension_Ordersequence","IsDimensionTemplate","Dimension_Creation_Timestamp","Dimension_Modification_Timestamp","CMN_PRO_Dimension_ValueID","Dimensions_RefID","DimensionValue_Text_DictID","DimensionValue_Ordersequence","DimensionValue_Creation_Timestamp","DimensionValue_Modification_Timestamp" });
				while(reader.Read())
				{
					L2DM_GADTWV_1413_raw resultItem = new L2DM_GADTWV_1413_raw();
					//0:Parameter CMN_PRO_DimensionID of type Guid
					resultItem.CMN_PRO_DimensionID = reader.GetGuid(0);
					//1:Parameter Product_RefID of type Guid
					resultItem.Product_RefID = reader.GetGuid(1);
					//2:Parameter Abbreviation of type string
					resultItem.Abbreviation = reader.GetString(2);
					//3:Parameter DimensionName of type Dict
					resultItem.DimensionName = reader.GetDictionary(3);
					resultItem.DimensionName.SourceTable = "cmn_pro_dimensions";
					loader.Append(resultItem.DimensionName);
					//4:Parameter Dimension_Ordersequence of type int
					resultItem.Dimension_Ordersequence = reader.GetInteger(4);
					//5:Parameter IsDimensionTemplate of type bool
					resultItem.IsDimensionTemplate = reader.GetBoolean(5);
					//6:Parameter Dimension_Creation_Timestamp of type DateTime
					resultItem.Dimension_Creation_Timestamp = reader.GetDate(6);
					//7:Parameter Dimension_Modification_Timestamp of type DateTime
					resultItem.Dimension_Modification_Timestamp = reader.GetDate(7);
					//8:Parameter CMN_PRO_Dimension_ValueID of type Guid
					resultItem.CMN_PRO_Dimension_ValueID = reader.GetGuid(8);
					//9:Parameter Dimensions_RefID of type Guid
					resultItem.Dimensions_RefID = reader.GetGuid(9);
					//10:Parameter DimensionValue_Text of type Dict
					resultItem.DimensionValue_Text = reader.GetDictionary(10);
					resultItem.DimensionValue_Text.SourceTable = "cmn_pro_dimension_values";
					loader.Append(resultItem.DimensionValue_Text);
					//11:Parameter DimensionValue_Ordersequence of type int
					resultItem.DimensionValue_Ordersequence = reader.GetInteger(11);
					//12:Parameter DimensionValue_Creation_Timestamp of type DateTime
					resultItem.DimensionValue_Creation_Timestamp = reader.GetDate(12);
					//13:Parameter DimensionValue_Modification_Timestamp of type DateTime
					resultItem.DimensionValue_Modification_Timestamp = reader.GetDate(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Dimension_Templates_With_Values",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L2DM_GADTWV_1413_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2DM_GADTWV_1413_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2DM_GADTWV_1413_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2DM_GADTWV_1413_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2DM_GADTWV_1413_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2DM_GADTWV_1413_Array functionReturn = new FR_L2DM_GADTWV_1413_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Dimension_Templates_With_Values",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L2DM_GADTWV_1413_raw 
	{
		public Guid CMN_PRO_DimensionID; 
		public Guid Product_RefID; 
		public string Abbreviation; 
		public Dict DimensionName; 
		public int Dimension_Ordersequence; 
		public bool IsDimensionTemplate; 
		public DateTime Dimension_Creation_Timestamp; 
		public DateTime Dimension_Modification_Timestamp; 
		public Guid CMN_PRO_Dimension_ValueID; 
		public Guid Dimensions_RefID; 
		public Dict DimensionValue_Text; 
		public int DimensionValue_Ordersequence; 
		public DateTime DimensionValue_Creation_Timestamp; 
		public DateTime DimensionValue_Modification_Timestamp; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L2DM_GADTWV_1413[] Convert(List<L2DM_GADTWV_1413_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L2DM_GADTWV_1413 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_PRO_DimensionID)).ToArray()
	group el_L2DM_GADTWV_1413 by new 
	{ 
		el_L2DM_GADTWV_1413.CMN_PRO_DimensionID,

	}
	into gfunct_L2DM_GADTWV_1413
	select new L2DM_GADTWV_1413
	{     
		CMN_PRO_DimensionID = gfunct_L2DM_GADTWV_1413.Key.CMN_PRO_DimensionID ,
		Product_RefID = gfunct_L2DM_GADTWV_1413.FirstOrDefault().Product_RefID ,
		Abbreviation = gfunct_L2DM_GADTWV_1413.FirstOrDefault().Abbreviation ,
		DimensionName = gfunct_L2DM_GADTWV_1413.FirstOrDefault().DimensionName ,
		Dimension_Ordersequence = gfunct_L2DM_GADTWV_1413.FirstOrDefault().Dimension_Ordersequence ,
		IsDimensionTemplate = gfunct_L2DM_GADTWV_1413.FirstOrDefault().IsDimensionTemplate ,
		Dimension_Creation_Timestamp = gfunct_L2DM_GADTWV_1413.FirstOrDefault().Dimension_Creation_Timestamp ,
		Dimension_Modification_Timestamp = gfunct_L2DM_GADTWV_1413.FirstOrDefault().Dimension_Modification_Timestamp ,

		DimensionValues = 
		(
			from el_DimensionValues in gfunct_L2DM_GADTWV_1413.Where(element => !EqualsDefaultValue(element.CMN_PRO_Dimension_ValueID)).ToArray()
			group el_DimensionValues by new 
			{ 
				el_DimensionValues.CMN_PRO_Dimension_ValueID,

			}
			into gfunct_DimensionValues
			select new L2DM_GADTWV_1413a
			{     
				CMN_PRO_Dimension_ValueID = gfunct_DimensionValues.Key.CMN_PRO_Dimension_ValueID ,
				Dimensions_RefID = gfunct_DimensionValues.FirstOrDefault().Dimensions_RefID ,
				DimensionValue_Text = gfunct_DimensionValues.FirstOrDefault().DimensionValue_Text ,
				DimensionValue_Ordersequence = gfunct_DimensionValues.FirstOrDefault().DimensionValue_Ordersequence ,
				DimensionValue_Creation_Timestamp = gfunct_DimensionValues.FirstOrDefault().DimensionValue_Creation_Timestamp ,
				DimensionValue_Modification_Timestamp = gfunct_DimensionValues.FirstOrDefault().DimensionValue_Modification_Timestamp ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L2DM_GADTWV_1413_Array : FR_Base
	{
		public L2DM_GADTWV_1413[] Result	{ get; set; } 
		public FR_L2DM_GADTWV_1413_Array() : base() {}

		public FR_L2DM_GADTWV_1413_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2DM_GADTWV_1413 for attribute L2DM_GADTWV_1413
		[DataContract]
		public class L2DM_GADTWV_1413 
		{
			[DataMember]
			public L2DM_GADTWV_1413a[] DimensionValues { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_DimensionID { get; set; } 
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public string Abbreviation { get; set; } 
			[DataMember]
			public Dict DimensionName { get; set; } 
			[DataMember]
			public int Dimension_Ordersequence { get; set; } 
			[DataMember]
			public bool IsDimensionTemplate { get; set; } 
			[DataMember]
			public DateTime Dimension_Creation_Timestamp { get; set; } 
			[DataMember]
			public DateTime Dimension_Modification_Timestamp { get; set; } 

		}
		#endregion
		#region SClass L2DM_GADTWV_1413a for attribute DimensionValues
		[DataContract]
		public class L2DM_GADTWV_1413a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Dimension_ValueID { get; set; } 
			[DataMember]
			public Guid Dimensions_RefID { get; set; } 
			[DataMember]
			public Dict DimensionValue_Text { get; set; } 
			[DataMember]
			public int DimensionValue_Ordersequence { get; set; } 
			[DataMember]
			public DateTime DimensionValue_Creation_Timestamp { get; set; } 
			[DataMember]
			public DateTime DimensionValue_Modification_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2DM_GADTWV_1413_Array cls_Get_All_Dimension_Templates_With_Values(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2DM_GADTWV_1413_Array invocationResult = cls_Get_All_Dimension_Templates_With_Values.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

