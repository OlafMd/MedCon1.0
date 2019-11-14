/* 
 * Generated on 3/11/2015 6:39:47 PM
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
using CL1_MRS_RUN;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.MRMS;
using CL1_USR;
using CL1_CMN_PER;
using CL1_CMN_BPT;
using CL6_MRMS_Backoffice.Utils;
using CL1_MRS_MPT;
using CL1_CMN_BPT_CTM;
using CL1_CMN;
using CL1_MRS_RUT;

namespace CL6_MRMS_Backoffice.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_CreateUpdate_MRMS_Backoffice_Entities.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_CreateUpdate_MRMS_Backoffice_Entities
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6MB_CUMBE_2302 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var statusUploaded = ORM_MRS_RUN_MeasurementRun_Status.Query.Search(Connection, Transaction, new ORM_MRS_RUN_MeasurementRun_Status.Query()
            {
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(MeasurementRunStatus.Uploaded),
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            var run = new ORM_MRS_RUN_MeasurementRun()
            {
                Tenant_RefID = securityTicket.TenantID,
                MRS_RUN_MeasurementRunID = Guid.NewGuid(),
                DateFrom = DateTime.Now,
                DateThrough = DateTime.MaxValue,
                CurrentStatus_RefID = statusUploaded.MRS_RUN_MeasurementRun_StatusID
            };

            returnValue.Result = run.MRS_RUN_MeasurementRunID;

            var account = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                USR_AccountID = securityTicket.AccountID
            }).Single();


            var runHistory = new ORM_MRS_RUN_MeasurementRun_StatusHistory()
            {
                Tenant_RefID = securityTicket.TenantID,
                MRS_RUN_MeasurementRun_StatusHistoryID = Guid.NewGuid(),
                MeasurementRun_Status_RefID = statusUploaded.MRS_RUN_MeasurementRun_StatusID,
                TriggeredBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID,
                MeasurementRun_RefID = run.MRS_RUN_MeasurementRunID,
                Comment = string.Empty
            };

            run.Save(Connection, Transaction);
            runHistory.Save(Connection, Transaction);

            foreach (var row in Parameter.Positions)
            {
                #region reader
                var readerPersonInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    PrimaryEmail = row.ReaderEmail
                }).SingleOrDefault();

                if (readerPersonInfo == null)
                {
                    readerPersonInfo = new ORM_CMN_PER_PersonInfo()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        PrimaryEmail = row.ReaderEmail,
                        CMN_PER_PersonInfoID = Guid.NewGuid()
                    };
                }

                readerPersonInfo.FirstName = row.ReaderFirstName;
                readerPersonInfo.LastName = row.ReaderLastName;

                readerPersonInfo.Save(Connection, Transaction);

                var readerBP = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    IsNaturalPerson = true,
                    IfNaturalPerson_CMN_PER_PersonInfo_RefID = readerPersonInfo.CMN_PER_PersonInfoID
                }).SingleOrDefault();

                if (readerBP == null)
                {
                    readerBP = new ORM_CMN_BPT_BusinessParticipant()
                    {
                        CMN_BPT_BusinessParticipantID = Guid.NewGuid(),
                        Tenant_RefID = securityTicket.TenantID,
                        IsNaturalPerson = true,
                        IfNaturalPerson_CMN_PER_PersonInfo_RefID = readerPersonInfo.CMN_PER_PersonInfoID,
                    };

                    readerBP.Save(Connection, Transaction);
                }

                var bpCode = ORM_CMN_BPT_BusinessParticipant_AccessCode.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_AccessCode.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    BusinessParticipant_RefID = readerBP.CMN_BPT_BusinessParticipantID,
                    IsValid = true,
                    IsDeviceAccessCode = true
                }).SingleOrDefault();

                if(bpCode == null)
                {
                    bpCode = new ORM_CMN_BPT_BusinessParticipant_AccessCode()
                    {
                        CMN_BPT_BusinessParticipant_AccessCodeID = Guid.NewGuid(),
                        Tenant_RefID = securityTicket.TenantID,
                        BusinessParticipant_RefID = readerBP.CMN_BPT_BusinessParticipantID,
                        IsValid = true,
                        IsDeviceAccessCode = true,
                        ValidFrom = DateTime.Now,
                        ValidThrough = DateTime.MaxValue,
                        Code = StringUtils.CodeGen(8).ToLower()
                    };
                    bpCode.Save(Connection, Transaction);
                }

                #endregion

                #region meter
                var meter = ORM_MRS_MPT_Meter.Query.Search(Connection, Transaction, new ORM_MRS_MPT_Meter.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    SerialNumber = row.MeterSerialNumber
                }).SingleOrDefault();

                if (meter == null)
                {
                    meter = new ORM_MRS_MPT_Meter()
                    {
                        MRS_MPT_MeterID = Guid.NewGuid(),
                        SerialNumber = row.MeterSerialNumber,
                        Tenant_RefID = securityTicket.TenantID,
                    };
                    meter.Save(Connection, Transaction);
                }

                var meterBinding = ORM_MRS_MPT_MeasuringPoint_MeterBinding.Query.Search(Connection, Transaction, new ORM_MRS_MPT_MeasuringPoint_MeterBinding.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Meter_RefID = meter.MRS_MPT_MeterID
                }).SingleOrDefault();

                if (meterBinding == null)
                {
                    meterBinding = new ORM_MRS_MPT_MeasuringPoint_MeterBinding()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        ActiveFrom = DateTime.Now,
                        Meter_RefID = meter.MRS_MPT_MeterID,
                        MRS_MPT_MeasuringPoint_MeterBindingID = Guid.NewGuid()
                    };
                    meterBinding.Save(Connection, Transaction);
                }

                var measurentPoint = ORM_MRS_MPT_MeasuringPoint.Query.Search(Connection, Transaction, new ORM_MRS_MPT_MeasuringPoint.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    MRS_MPT_MeasuringPointID = meterBinding.MeasuringPoint_RefID
                }).SingleOrDefault();

                if (measurentPoint == null)
                {
                    measurentPoint = new ORM_MRS_MPT_MeasuringPoint()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        MRS_MPT_MeasuringPointID = Guid.NewGuid()
                    };

                    meterBinding.MeasuringPoint_RefID = measurentPoint.MRS_MPT_MeasuringPointID;
                    meterBinding.Save(Connection, Transaction);

                    measurentPoint.Save(Connection, Transaction);
                }

                #endregion

                #region customer
                var customerOwnership = ORM_MRS_MPT_CustomerOwnership.Query.Search(Connection, Transaction, new ORM_MRS_MPT_CustomerOwnership.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    ContractNumber = row.ContractNumber
                }).SingleOrDefault();

                if (customerOwnership == null)
                {
                    var customerPersonInfo = new ORM_CMN_PER_PersonInfo()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        FirstName = row.ContractOwnerFirstName,
                        LastName = row.ContractOwnerLastName,
                        CMN_PER_PersonInfoID = Guid.NewGuid()
                    };
                    customerPersonInfo.Save(Connection, Transaction);

                    var customerBP = new ORM_CMN_BPT_BusinessParticipant()
                    {
                        CMN_BPT_BusinessParticipantID = Guid.NewGuid(),
                        Tenant_RefID = securityTicket.TenantID,
                        IsNaturalPerson = true,
                        IfNaturalPerson_CMN_PER_PersonInfo_RefID = customerPersonInfo.CMN_PER_PersonInfoID,
                    };
                    customerBP.Save(Connection, Transaction);

                    var customer = new ORM_CMN_BPT_CTM_Customer()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        CMN_BPT_CTM_CustomerID = Guid.NewGuid(),
                        Ext_BusinessParticipant_RefID = customerBP.CMN_BPT_BusinessParticipantID
                    };
                    customer.Save(Connection, Transaction);

                    customerOwnership = new ORM_MRS_MPT_CustomerOwnership()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        MRS_MPT_CustomerOwnershipID = Guid.NewGuid(),
                        ContractNumber = row.ContractNumber,
                        ValidFrom = DateTime.Now,
                        Customer_RefID = customer.CMN_BPT_CTM_CustomerID,
                        MeasuringPoint_RefID = measurentPoint.MRS_MPT_MeasuringPointID
                    };
                    customerOwnership.Save(Connection, Transaction);
                }
                else
                {
                    var customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_Customer.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        CMN_BPT_CTM_CustomerID = customerOwnership.Customer_RefID
                    }).Single();

                    var customerBP = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        CMN_BPT_BusinessParticipantID = customer.Ext_BusinessParticipant_RefID
                    }).Single();

                    var customerPI = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        CMN_PER_PersonInfoID = customerBP.IfNaturalPerson_CMN_PER_PersonInfo_RefID
                    }).Single();

                    customerPI.FirstName = row.ContractOwnerFirstName;
                    customerPI.LastName = row.ContractOwnerLastName;
                    customerPI.Save(Connection, Transaction);
                }

                customerOwnership.MeasuringPoint_RefID = measurentPoint.MRS_MPT_MeasuringPointID;
                customerOwnership.Save(Connection, Transaction);

                #region address
                var address = ORM_CMN_Address.Query.Search(Connection, Transaction, new ORM_CMN_Address.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    City_Name = row.City,
                    Street_Name = row.AddressName,
                    Street_Number = row.AddressNumber,
                    City_PostalCode = row.ZipCode

                }).SingleOrDefault();

                if (address == null)
                {
                    address = new ORM_CMN_Address()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        City_Name = row.City,
                        Street_Name = row.AddressName,
                        Street_Number = row.AddressNumber,
                        City_PostalCode = row.ZipCode,
                        CMN_AddressID = Guid.NewGuid()
                    };
                    address.Save(Connection, Transaction);
                }

                measurentPoint.CurrentAddress_RefID = address.CMN_AddressID;
                measurentPoint.Save(Connection, Transaction);

                #endregion

                #endregion

                #region route

                var route = ORM_MRS_RUT_Route.Query.Search(Connection, Transaction, new ORM_MRS_RUT_Route.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    DisplayName = row.RouteName
                }).SingleOrDefault();

                if(route == null)
                {
                    route = new ORM_MRS_RUT_Route()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        MRS_RUT_RouteID = Guid.NewGuid(),
                        DisplayName = row.RouteName,
                        //Default_RouteReaderAccount_RefID = readerBP.CMN_BPT_BusinessParticipantID
                    };
                    route.Save(Connection, Transaction);
                }

                var routeMeasuringPoint = ORM_MRS_RUT_Route_MeasuringPoint.Query.Search(Connection, Transaction, new ORM_MRS_RUT_Route_MeasuringPoint.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Route_RefID = route.MRS_RUT_RouteID,
                    MeasuringPoint_RefID = measurentPoint.MRS_MPT_MeasuringPointID
                }).SingleOrDefault();

                if (routeMeasuringPoint == null)
                {
                    routeMeasuringPoint = new ORM_MRS_RUT_Route_MeasuringPoint()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        MRS_RUT_Route_MeasuringPointID = Guid.NewGuid(),
                        Route_RefID = route.MRS_RUT_RouteID,
                        MeasuringPoint_RefID = measurentPoint.MRS_MPT_MeasuringPointID
                    };
                }

                routeMeasuringPoint.OrderSequence = row.SequenceInRoute;
                routeMeasuringPoint.Save(Connection, Transaction);


                #endregion

                #region measurement

                var measurement = new ORM_MRS_RUN_Measurement()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    MRS_RUN_MeasurementID = Guid.NewGuid(),
                    MeasurementRun_RefID = run.MRS_RUN_MeasurementRunID,
                    MeasuringPoint_RefID = routeMeasuringPoint.MRS_RUT_Route_MeasuringPointID
                };
                measurement.Save(Connection, Transaction);


                var run2route = ORM_MRS_RUN_MeasurementRun_Route.Query.Search(Connection, Transaction, new ORM_MRS_RUN_MeasurementRun_Route.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Route_RefID = route.MRS_RUT_RouteID,
                    MeasurementRun_RefID = run.MRS_RUN_MeasurementRunID
                }).SingleOrDefault();

                if (run2route == null)
                    run2route = new ORM_MRS_RUN_MeasurementRun_Route()
                    {
                        MRS_RUN_MeasurementRun_RouteID = Guid.NewGuid(),
                        Tenant_RefID = securityTicket.TenantID,
                        Route_RefID = route.MRS_RUT_RouteID,
                        MeasurementRun_RefID = run.MRS_RUN_MeasurementRunID
                    };

                run2route.BoundTo_Account_RefID = readerBP.CMN_BPT_BusinessParticipantID;
                run2route.Save(Connection, Transaction);


                #endregion
            }
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6MB_CUMBE_2302 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6MB_CUMBE_2302 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6MB_CUMBE_2302 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6MB_CUMBE_2302 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_CreateUpdate_MRMS_Backoffice_Entities",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6MB_CUMBE_2302 for attribute P_L6MB_CUMBE_2302
		[DataContract]
		public class P_L6MB_CUMBE_2302 
		{
			[DataMember]
			public P_L6MB_CUMBE_2302_Row[] Positions { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L6MB_CUMBE_2302_Row for attribute Positions
		[DataContract]
		public class P_L6MB_CUMBE_2302_Row 
		{
			//Standard type parameters
			[DataMember]
			public string MeterSerialNumber { get; set; } 
			[DataMember]
			public string ReaderEmail { get; set; } 
			[DataMember]
			public string MeterType { get; set; } 
			[DataMember]
			public string ContractNumber { get; set; } 
			[DataMember]
			public string ContractOwnerFirstName { get; set; } 
			[DataMember]
			public string ContractOwnerLastName { get; set; } 
			[DataMember]
			public string AddressName { get; set; } 
			[DataMember]
			public string AddressNumber { get; set; } 
			[DataMember]
			public string ZipCode { get; set; } 
			[DataMember]
			public string City { get; set; } 
			[DataMember]
			public string RouteName { get; set; } 
			[DataMember]
			public int SequenceInRoute { get; set; } 
			[DataMember]
			public string ReaderFirstName { get; set; } 
			[DataMember]
			public string ReaderLastName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_CreateUpdate_MRMS_Backoffice_Entities(,P_L6MB_CUMBE_2302 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_CreateUpdate_MRMS_Backoffice_Entities.Invoke(connectionString,P_L6MB_CUMBE_2302 Parameter,securityTicket);
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
var parameter = new CL6_MRMS_Backoffice.Complex.Manipulation.P_L6MB_CUMBE_2302();
parameter.Positions = ...;


*/
