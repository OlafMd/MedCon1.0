/* 
 * Generated on 8/13/2014 4:42:09 PM
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
using CL1_MRS_MPT;
using CL1_MRS_RUN;

namespace CL6_MRMS_Measurements.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_MeasurementsUpload.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_MeasurementsUpload
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6_SMU_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            
            ORM_MRS_RUN_Measurement.Query measurementQ = new ORM_MRS_RUN_Measurement.Query()
            {
                MRS_RUN_MeasurementID = Parameter.measurementID,
                IsDeleted = false
            };
            
            ORM_MRS_RUN_Measurement measurement = ORM_MRS_RUN_Measurement.Query.Search(Connection, Transaction, measurementQ).FirstOrDefault();
            if (measurement == null)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.ErrorMessage = "No sucuh measurement";
            }

            measurement.IsMeasured = true;
            //TODO: mode
            measurement.Save(Connection,Transaction);

            var valueAcquisionType = ORM_MRS_RUN_Measurement_ValueAcquisitionType.Query.Search(Connection, Transaction, new ORM_MRS_RUN_Measurement_ValueAcquisitionType.Query() 
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                GlobalPropertyMatchingID = Parameter.mode
            }).SingleOrDefault();

            foreach(var valParam in Parameter.measurementValues)
            {
                var measurementValue = ORM_MRS_RUN_Measurement_Value.Query.Search(Connection, Transaction, new ORM_MRS_RUN_Measurement_Value.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Measurement_RefID = measurement.MRS_RUN_MeasurementID,
                    MeasurementTariff_RefID = valParam.tarrifRefID
                }).SingleOrDefault();
                if(measurementValue == null)
                {
                    measurementValue = new ORM_MRS_RUN_Measurement_Value()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        Measurement_RefID = measurement.MRS_RUN_MeasurementID,
                        MRS_RUN_Measurement_ValueID = Guid.NewGuid(),
                        MeasurementTariff_RefID = valParam.tarrifRefID
                    };
                }

                measurementValue.MeasuredAt_Time = valParam.measuredAt;
                //measurementValue.MeasuredAt_Lattitude
                measurementValue.MeasurementValue = double.Parse(valParam.value);
                if(valueAcquisionType != null)
                    measurementValue.Measurement_AcquisitionType_RefID = valueAcquisionType.MRS_RUN_Measurement_ValueAcquisitionTypeID;
                measurementValue.Save(Connection, Transaction);
            }

            foreach(var noteParam in Parameter.notes)
            {

            }

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6_SMU_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6_SMU_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6_SMU_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6_SMU_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_MeasurementsUpload",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6_SMU_1157 for attribute P_L6_SMU_1157
		[DataContract]
		public class P_L6_SMU_1157 
		{
			[DataMember]
			public P_L6_SMU_1157_MeasurementValues[] measurementValues { get; set; }
			[DataMember]
			public P_L6_SMU_1157_Note[] notes { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid measurementID { get; set; } 
			[DataMember]
			public String mode { get; set; } 

		}
		#endregion
		#region SClass P_L6_SMU_1157_MeasurementValues for attribute measurementValues
		[DataContract]
		public class P_L6_SMU_1157_MeasurementValues 
		{
			//Standard type parameters
			[DataMember]
			public String value { get; set; } 
			[DataMember]
			public Guid tarrifRefID { get; set; } 
			[DataMember]
			public DateTime measuredAt { get; set; } 

		}
		#endregion
		#region SClass P_L6_SMU_1157_Note for attribute notes
		[DataContract]
		public class P_L6_SMU_1157_Note 
		{
			//Standard type parameters
			[DataMember]
			public String text { get; set; } 
			[DataMember]
			public Guid createdByBPID { get; set; } 
			[DataMember]
			public Guid measuringPointID { get; set; } 
			[DataMember]
			public DateTime creationTimestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_MeasurementsUpload(,P_L6_SMU_1157 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_MeasurementsUpload.Invoke(connectionString,P_L6_SMU_1157 Parameter,securityTicket);
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
var parameter = new CL6_MRMS_Measurements.Complex.Manipulation.P_L6_SMU_1157();
parameter.measurementValues = ...;
parameter.notes = ...;

parameter.measurementID = ...;
parameter.mode = ...;

*/
