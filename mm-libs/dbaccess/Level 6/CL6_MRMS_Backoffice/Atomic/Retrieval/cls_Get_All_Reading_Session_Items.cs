/* 
 * Generated on 3/8/2015 6:55:56 PM
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

namespace CL6_MRMS_Backoffice.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Reading_Session_Items.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Reading_Session_Items
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6MRMS_GARSI_2117_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6MRMS_GARSI_2117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6MRMS_GARSI_2117_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_MRMS_Backoffice.Atomic.Retrieval.SQL.cls_Get_All_Reading_Session_Items.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ReadingSessionId", Parameter.ReadingSessionId);



			List<L6MRMS_GARSI_2117_raw> results = new List<L6MRMS_GARSI_2117_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "MeasurementID","MeterSerialNumber","ContractNumber","OwnerFirstName","OwnerLastName","StreetName","StreetNumber","City","City_PostalCode","RouteName","SequenceInRoute","MRS_RUT_RouteID","MRS_RUN_MeasurementRun_RouteID","BoundTo_Account_RefID","MRS_RUN_Measurement_TariffID","MRS_RUN_Measurement_ValueID","MeasuredAt_Time","MeasurementValue","Tariff_GlobalPropertyMatchingID","AcqusitionTypeGPM","MeasurementTariffName_DictID" });
				while(reader.Read())
				{
					L6MRMS_GARSI_2117_raw resultItem = new L6MRMS_GARSI_2117_raw();
					//0:Parameter MeasurementID of type Guid
					resultItem.MeasurementID = reader.GetGuid(0);
					//1:Parameter MeterSerialNumber of type string
					resultItem.MeterSerialNumber = reader.GetString(1);
					//2:Parameter ContractNumber of type string
					resultItem.ContractNumber = reader.GetString(2);
					//3:Parameter OwnerFirstName of type string
					resultItem.OwnerFirstName = reader.GetString(3);
					//4:Parameter OwnerLastName of type string
					resultItem.OwnerLastName = reader.GetString(4);
					//5:Parameter StreetName of type string
					resultItem.StreetName = reader.GetString(5);
					//6:Parameter StreetNumber of type string
					resultItem.StreetNumber = reader.GetString(6);
					//7:Parameter City of type string
					resultItem.City = reader.GetString(7);
					//8:Parameter City_PostalCode of type string
					resultItem.City_PostalCode = reader.GetString(8);
					//9:Parameter RouteName of type string
					resultItem.RouteName = reader.GetString(9);
					//10:Parameter SequenceInRoute of type int
					resultItem.SequenceInRoute = reader.GetInteger(10);
					//11:Parameter MRS_RUT_RouteID of type Guid
					resultItem.MRS_RUT_RouteID = reader.GetGuid(11);
					//12:Parameter MRS_RUN_MeasurementRun_RouteID of type Guid
					resultItem.MRS_RUN_MeasurementRun_RouteID = reader.GetGuid(12);
					//13:Parameter BoundTo_Account_RefID of type Guid
					resultItem.BoundTo_Account_RefID = reader.GetGuid(13);
					//14:Parameter MRS_RUN_Measurement_TariffID of type Guid
					resultItem.MRS_RUN_Measurement_TariffID = reader.GetGuid(14);
					//15:Parameter MRS_RUN_Measurement_ValueID of type Guid
					resultItem.MRS_RUN_Measurement_ValueID = reader.GetGuid(15);
					//16:Parameter MeasuredAt_Time of type DateTime
					resultItem.MeasuredAt_Time = reader.GetDate(16);
					//17:Parameter MeasurementValue of type double
					resultItem.MeasurementValue = reader.GetDouble(17);
					//18:Parameter Tariff_GlobalPropertyMatchingID of type string
					resultItem.Tariff_GlobalPropertyMatchingID = reader.GetString(18);
					//19:Parameter AcqusitionTypeGPM of type string
					resultItem.AcqusitionTypeGPM = reader.GetString(19);
					//20:Parameter MeasurementTariffName of type Dict
					resultItem.MeasurementTariffName = reader.GetDictionary(20);
					resultItem.MeasurementTariffName.SourceTable = "mrs_run_measurement_tariffs";
					loader.Append(resultItem.MeasurementTariffName);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Reading_Session_Items",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L6MRMS_GARSI_2117_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6MRMS_GARSI_2117_Array Invoke(string ConnectionString,P_L6MRMS_GARSI_2117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6MRMS_GARSI_2117_Array Invoke(DbConnection Connection,P_L6MRMS_GARSI_2117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6MRMS_GARSI_2117_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6MRMS_GARSI_2117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6MRMS_GARSI_2117_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6MRMS_GARSI_2117 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6MRMS_GARSI_2117_Array functionReturn = new FR_L6MRMS_GARSI_2117_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Reading_Session_Items",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L6MRMS_GARSI_2117_raw 
	{
		public Guid MeasurementID; 
		public string MeterSerialNumber; 
		public string ContractNumber; 
		public string OwnerFirstName; 
		public string OwnerLastName; 
		public string StreetName; 
		public string StreetNumber; 
		public string City; 
		public string City_PostalCode; 
		public string RouteName; 
		public int SequenceInRoute; 
		public Guid MRS_RUT_RouteID; 
		public Guid MRS_RUN_MeasurementRun_RouteID; 
		public Guid BoundTo_Account_RefID; 
		public Guid MRS_RUN_Measurement_TariffID; 
		public Guid MRS_RUN_Measurement_ValueID; 
		public DateTime MeasuredAt_Time; 
		public double MeasurementValue; 
		public string Tariff_GlobalPropertyMatchingID; 
		public string AcqusitionTypeGPM; 
		public Dict MeasurementTariffName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6MRMS_GARSI_2117[] Convert(List<L6MRMS_GARSI_2117_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6MRMS_GARSI_2117 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.MeasurementID)).ToArray()
	group el_L6MRMS_GARSI_2117 by new 
	{ 
		el_L6MRMS_GARSI_2117.MeasurementID,

	}
	into gfunct_L6MRMS_GARSI_2117
	select new L6MRMS_GARSI_2117
	{     
		MeasurementID = gfunct_L6MRMS_GARSI_2117.Key.MeasurementID ,
		MeterSerialNumber = gfunct_L6MRMS_GARSI_2117.FirstOrDefault().MeterSerialNumber ,
		ContractNumber = gfunct_L6MRMS_GARSI_2117.FirstOrDefault().ContractNumber ,
		OwnerFirstName = gfunct_L6MRMS_GARSI_2117.FirstOrDefault().OwnerFirstName ,
		OwnerLastName = gfunct_L6MRMS_GARSI_2117.FirstOrDefault().OwnerLastName ,
		StreetName = gfunct_L6MRMS_GARSI_2117.FirstOrDefault().StreetName ,
		StreetNumber = gfunct_L6MRMS_GARSI_2117.FirstOrDefault().StreetNumber ,
		City = gfunct_L6MRMS_GARSI_2117.FirstOrDefault().City ,
		City_PostalCode = gfunct_L6MRMS_GARSI_2117.FirstOrDefault().City_PostalCode ,
		RouteName = gfunct_L6MRMS_GARSI_2117.FirstOrDefault().RouteName ,
		SequenceInRoute = gfunct_L6MRMS_GARSI_2117.FirstOrDefault().SequenceInRoute ,
		MRS_RUT_RouteID = gfunct_L6MRMS_GARSI_2117.FirstOrDefault().MRS_RUT_RouteID ,
		MRS_RUN_MeasurementRun_RouteID = gfunct_L6MRMS_GARSI_2117.FirstOrDefault().MRS_RUN_MeasurementRun_RouteID ,
		BoundTo_Account_RefID = gfunct_L6MRMS_GARSI_2117.FirstOrDefault().BoundTo_Account_RefID ,

		MeasurementValues = 
		(
			from el_MeasurementValues in gfunct_L6MRMS_GARSI_2117.Where(element => !EqualsDefaultValue(element.MRS_RUN_Measurement_ValueID)).ToArray()
			group el_MeasurementValues by new 
			{ 
				el_MeasurementValues.MRS_RUN_Measurement_ValueID,

			}
			into gfunct_MeasurementValues
			select new L6MRMS_GARSI_2117_MeasurementValue
			{     
				MRS_RUN_Measurement_TariffID = gfunct_MeasurementValues.FirstOrDefault().MRS_RUN_Measurement_TariffID ,
				MRS_RUN_Measurement_ValueID = gfunct_MeasurementValues.Key.MRS_RUN_Measurement_ValueID ,
				MeasuredAt_Time = gfunct_MeasurementValues.FirstOrDefault().MeasuredAt_Time ,
				MeasurementValue = gfunct_MeasurementValues.FirstOrDefault().MeasurementValue ,
				Tariff_GlobalPropertyMatchingID = gfunct_MeasurementValues.FirstOrDefault().Tariff_GlobalPropertyMatchingID ,
				AcqusitionTypeGPM = gfunct_MeasurementValues.FirstOrDefault().AcqusitionTypeGPM ,
				MeasurementTariffName = gfunct_MeasurementValues.FirstOrDefault().MeasurementTariffName ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6MRMS_GARSI_2117_Array : FR_Base
	{
		public L6MRMS_GARSI_2117[] Result	{ get; set; } 
		public FR_L6MRMS_GARSI_2117_Array() : base() {}

		public FR_L6MRMS_GARSI_2117_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6MRMS_GARSI_2117 for attribute P_L6MRMS_GARSI_2117
		[DataContract]
		public class P_L6MRMS_GARSI_2117 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReadingSessionId { get; set; } 

		}
		#endregion
		#region SClass L6MRMS_GARSI_2117 for attribute L6MRMS_GARSI_2117
		[DataContract]
		public class L6MRMS_GARSI_2117 
		{
			[DataMember]
			public L6MRMS_GARSI_2117_MeasurementValue[] MeasurementValues { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid MeasurementID { get; set; } 
			[DataMember]
			public string MeterSerialNumber { get; set; } 
			[DataMember]
			public string ContractNumber { get; set; } 
			[DataMember]
			public string OwnerFirstName { get; set; } 
			[DataMember]
			public string OwnerLastName { get; set; } 
			[DataMember]
			public string StreetName { get; set; } 
			[DataMember]
			public string StreetNumber { get; set; } 
			[DataMember]
			public string City { get; set; } 
			[DataMember]
			public string City_PostalCode { get; set; } 
			[DataMember]
			public string RouteName { get; set; } 
			[DataMember]
			public int SequenceInRoute { get; set; } 
			[DataMember]
			public Guid MRS_RUT_RouteID { get; set; } 
			[DataMember]
			public Guid MRS_RUN_MeasurementRun_RouteID { get; set; } 
			[DataMember]
			public Guid BoundTo_Account_RefID { get; set; } 

		}
		#endregion
		#region SClass L6MRMS_GARSI_2117_MeasurementValue for attribute MeasurementValues
		[DataContract]
		public class L6MRMS_GARSI_2117_MeasurementValue 
		{
			//Standard type parameters
			[DataMember]
			public Guid MRS_RUN_Measurement_TariffID { get; set; } 
			[DataMember]
			public Guid MRS_RUN_Measurement_ValueID { get; set; } 
			[DataMember]
			public DateTime MeasuredAt_Time { get; set; } 
			[DataMember]
			public double MeasurementValue { get; set; } 
			[DataMember]
			public string Tariff_GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public string AcqusitionTypeGPM { get; set; } 
			[DataMember]
			public Dict MeasurementTariffName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6MRMS_GARSI_2117_Array cls_Get_All_Reading_Session_Items(,P_L6MRMS_GARSI_2117 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6MRMS_GARSI_2117_Array invocationResult = cls_Get_All_Reading_Session_Items.Invoke(connectionString,P_L6MRMS_GARSI_2117 Parameter,securityTicket);
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
var parameter = new CL6_MRMS_Backoffice.Atomic.Retrieval.P_L6MRMS_GARSI_2117();
parameter.ReadingSessionId = ...;

*/
