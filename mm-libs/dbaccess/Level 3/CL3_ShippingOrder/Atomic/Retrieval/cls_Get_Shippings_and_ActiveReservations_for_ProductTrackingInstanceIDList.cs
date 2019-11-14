/* 
 * Generated on 10/22/2014 4:20:54 PM
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

namespace CL3_ShippingOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Shippings_and_ActiveReservations_for_ProductTrackingInstanceIDList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Shippings_and_ActiveReservations_for_ProductTrackingInstanceIDList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3SO_GSaARfPTIL_1153_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3SO_GSaUERfPTIL_1153 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3SO_GSaARfPTIL_1153_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_ShippingOrder.Atomic.Retrieval.SQL.cls_Get_Shippings_and_ActiveReservations_for_ProductTrackingInstanceIDList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProductTrackingInstanceIDList"," IN $$ProductTrackingInstanceIDList$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProductTrackingInstanceIDList$",Parameter.ProductTrackingInstanceIDList);


			List<L3SO_GSaARfPTIL_1153_raw> results = new List<L3SO_GSaARfPTIL_1153_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_ProductTrackingInstance_RefID","LOG_RSV_Reservation_TrackingInstanceID","ReservedQuantityFromTrackingInstance","LOG_RSV_ReservationID","LOG_SHP_Shipment_PositionID","LOG_SHP_Shipment_HeaderID" });
				while(reader.Read())
				{
					L3SO_GSaARfPTIL_1153_raw resultItem = new L3SO_GSaARfPTIL_1153_raw();
					//0:Parameter LOG_ProductTrackingInstance_RefID of type Guid
					resultItem.LOG_ProductTrackingInstance_RefID = reader.GetGuid(0);
					//1:Parameter LOG_RSV_Reservation_TrackingInstanceID of type Guid
					resultItem.LOG_RSV_Reservation_TrackingInstanceID = reader.GetGuid(1);
					//2:Parameter ReservedQuantityFromTrackingInstance of type Double
					resultItem.ReservedQuantityFromTrackingInstance = reader.GetDouble(2);
					//3:Parameter LOG_RSV_ReservationID of type Guid
					resultItem.LOG_RSV_ReservationID = reader.GetGuid(3);
					//4:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(4);
					//5:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Shippings_and_ActiveReservations_for_ProductTrackingInstanceIDList",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3SO_GSaARfPTIL_1153_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3SO_GSaARfPTIL_1153_Array Invoke(string ConnectionString,P_L3SO_GSaUERfPTIL_1153 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3SO_GSaARfPTIL_1153_Array Invoke(DbConnection Connection,P_L3SO_GSaUERfPTIL_1153 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3SO_GSaARfPTIL_1153_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SO_GSaUERfPTIL_1153 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3SO_GSaARfPTIL_1153_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SO_GSaUERfPTIL_1153 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3SO_GSaARfPTIL_1153_Array functionReturn = new FR_L3SO_GSaARfPTIL_1153_Array();
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

				throw new Exception("Exception occured in method cls_Get_Shippings_and_ActiveReservations_for_ProductTrackingInstanceIDList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3SO_GSaARfPTIL_1153_raw 
	{
		public Guid LOG_ProductTrackingInstance_RefID; 
		public Guid LOG_RSV_Reservation_TrackingInstanceID; 
		public Double ReservedQuantityFromTrackingInstance; 
		public Guid LOG_RSV_ReservationID; 
		public Guid LOG_SHP_Shipment_PositionID; 
		public Guid LOG_SHP_Shipment_HeaderID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3SO_GSaARfPTIL_1153[] Convert(List<L3SO_GSaARfPTIL_1153_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3SO_GSaARfPTIL_1153 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.LOG_ProductTrackingInstance_RefID)).ToArray()
	group el_L3SO_GSaARfPTIL_1153 by new 
	{ 
		el_L3SO_GSaARfPTIL_1153.LOG_ProductTrackingInstance_RefID,

	}
	into gfunct_L3SO_GSaARfPTIL_1153
	select new L3SO_GSaARfPTIL_1153
	{     
		LOG_ProductTrackingInstance_RefID = gfunct_L3SO_GSaARfPTIL_1153.Key.LOG_ProductTrackingInstance_RefID ,

		Reservations = 
		(
			from el_Reservations in gfunct_L3SO_GSaARfPTIL_1153.Where(element => !EqualsDefaultValue(element.LOG_RSV_Reservation_TrackingInstanceID)).ToArray()
			group el_Reservations by new 
			{ 
				el_Reservations.LOG_RSV_Reservation_TrackingInstanceID,

			}
			into gfunct_Reservations
			select new L3SO_GSaARfPTIL_1153a
			{     
				LOG_RSV_Reservation_TrackingInstanceID = gfunct_Reservations.Key.LOG_RSV_Reservation_TrackingInstanceID ,
				ReservedQuantityFromTrackingInstance = gfunct_Reservations.FirstOrDefault().ReservedQuantityFromTrackingInstance ,
				LOG_RSV_ReservationID = gfunct_Reservations.FirstOrDefault().LOG_RSV_ReservationID ,
				LOG_SHP_Shipment_PositionID = gfunct_Reservations.FirstOrDefault().LOG_SHP_Shipment_PositionID ,
				LOG_SHP_Shipment_HeaderID = gfunct_Reservations.FirstOrDefault().LOG_SHP_Shipment_HeaderID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3SO_GSaARfPTIL_1153_Array : FR_Base
	{
		public L3SO_GSaARfPTIL_1153[] Result	{ get; set; } 
		public FR_L3SO_GSaARfPTIL_1153_Array() : base() {}

		public FR_L3SO_GSaARfPTIL_1153_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3SO_GSaUERfPTIL_1153 for attribute P_L3SO_GSaUERfPTIL_1153
		[DataContract]
		public class P_L3SO_GSaUERfPTIL_1153 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProductTrackingInstanceIDList { get; set; } 

		}
		#endregion
		#region SClass L3SO_GSaARfPTIL_1153 for attribute L3SO_GSaARfPTIL_1153
		[DataContract]
		public class L3SO_GSaARfPTIL_1153 
		{
			[DataMember]
			public L3SO_GSaARfPTIL_1153a[] Reservations { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid LOG_ProductTrackingInstance_RefID { get; set; } 

		}
		#endregion
		#region SClass L3SO_GSaARfPTIL_1153a for attribute Reservations
		[DataContract]
		public class L3SO_GSaARfPTIL_1153a 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_RSV_Reservation_TrackingInstanceID { get; set; } 
			[DataMember]
			public Double ReservedQuantityFromTrackingInstance { get; set; } 
			[DataMember]
			public Guid LOG_RSV_ReservationID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3SO_GSaARfPTIL_1153_Array cls_Get_Shippings_and_ActiveReservations_for_ProductTrackingInstanceIDList(,P_L3SO_GSaUERfPTIL_1153 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3SO_GSaARfPTIL_1153_Array invocationResult = cls_Get_Shippings_and_ActiveReservations_for_ProductTrackingInstanceIDList.Invoke(connectionString,P_L3SO_GSaUERfPTIL_1153 Parameter,securityTicket);
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
var parameter = new CL3_ShippingOrder.Atomic.Retrieval.P_L3SO_GSaUERfPTIL_1153();
parameter.ProductTrackingInstanceIDList = ...;

*/
