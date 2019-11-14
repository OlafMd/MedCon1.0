/* 
 * Generated on 1/22/2014 2:55:07 PM
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
using CL1_CMN_STR;
using CL1_CMN_BPT;
using CL1_CMN_BPT_EMP;
using CL1_CMN_PER;
using CL1_CMN;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Office.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_get_Offices_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_get_Offices_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OF_GOFT_1157_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5OF_GOFT_1157_Array();
            ORM_CMN_STR_Office.Query officesQuery=new ORM_CMN_STR_Office.Query();
            officesQuery.IsDeleted=false;
            officesQuery.Tenant_RefID=securityTicket.TenantID;
            List<ORM_CMN_STR_Office> officesResult=ORM_CMN_STR_Office.Query.Search(Connection,Transaction,officesQuery);
            List<L5OF_GOFT_1157> officesResultList=new List<L5OF_GOFT_1157>();
            foreach(var office in officesResult){

            L5OF_GOFT_1157 result=new L5OF_GOFT_1157(); 
            var item = new ORM_CMN_STR_Office();

                var resultOffice = item.Load(Connection, Transaction, office.CMN_STR_OfficeID);
                if (resultOffice.Status != FR_Status.Success || item.CMN_STR_OfficeID == Guid.Empty)
				{
					var error = new FR_Guid();
					error.ErrorMessage = "No Such ID";
					error.Status = FR_Status.Error_Internal;
                    return null;
				
				}
			
            result.CMN_CAL_CalendarInstance_RefID=item.CMN_CAL_CalendarInstance_RefID;
            result.CMN_STR_OfficeID=item.CMN_STR_OfficeID;
            result.Country_RefID=item.Country_RefID;
            result.Default_FaxNumber=item.Default_FaxNumber;
            result.Default_PhoneNumber=item.Default_PhoneNumber;
            result.Office_ShortName=item.Office_ShortName;
            result.OfficeDescription=item.Office_Description;
            result.OfficeName=item.Office_Name;
            result.Region_RefID=item.Region_RefID;
            result.BillingAddress_CMN_AddressID=item.Default_BillingAddress_RefID;
           


			var address = new ORM_CMN_Address();
				var resultItem = address.Load(Connection, Transaction, item.Default_BillingAddress_RefID);
                if (resultItem.Status != FR_Status.Success || address.CMN_AddressID == Guid.Empty)
				{
					var error = new FR_Guid();
					error.ErrorMessage = "No Such ID";
					error.Status = FR_Status.Error_Internal;
                    return null;
				}
			
			result.BillingAddress_City_Name = address.City_Name;
			result.BillingAddress_City_AdministrativeDistrict = address.City_AdministrativeDistrict;
			result.BillingAddress_City_PostalCode = address.City_PostalCode;
			result.BillingAddress_City_Region = address.City_Region;
			result.BillingAddress_Country_Name = address.Country_Name;
			result.BillingAddress_Province_Name = address.Province_Name;
			result.BillingAddress_Street_Name = address.Street_Name;
			result.BillingAddress_Street_Number = address.Street_Number;
            result.BillingAddress_Country_ISOCode=address.Country_ISOCode;




            ORM_CMN_STR_Office_2_CostCenter.Query officeToCostcenterQuery =new  ORM_CMN_STR_Office_2_CostCenter.Query();
            officeToCostcenterQuery.Office_RefID = office.CMN_STR_OfficeID;
            officeToCostcenterQuery.Tenant_RefID=securityTicket.TenantID;
            officeToCostcenterQuery.IsDeleted=false;
            List<ORM_CMN_STR_Office_2_CostCenter> officeToCostcenterList=ORM_CMN_STR_Office_2_CostCenter.Query.Search(Connection,Transaction,officeToCostcenterQuery);
            if(officeToCostcenterList.Count!=0){
                L5OF_GOFT_1157_Costcenter costCenter=new L5OF_GOFT_1157_Costcenter();
                ORM_CMN_STR_CostCenter costCenterItem=new ORM_CMN_STR_CostCenter();
                costCenterItem.Load(Connection, Transaction, officeToCostcenterList[0].CostCenter_RefID);
                if(!costCenterItem.IsDeleted){
                    costCenter.AssignmentID=officeToCostcenterList[0].AssignmentID;
                    costCenter.CMN_STR_CostCenterID=officeToCostcenterList[0].CostCenter_RefID;
                    costCenter.CostcenterName=costCenterItem.Name;
                    costCenter.InternalID=costCenterItem.InternalID;
                    result.Costcenter=costCenter;
                }
            }
            var responsiblePersonsQuery = new ORM_CMN_STR_Office_ResponsiblePerson.Query();
            responsiblePersonsQuery.Tenant_RefID = securityTicket.TenantID;
            responsiblePersonsQuery.Office_RefID = item.CMN_STR_OfficeID;
            responsiblePersonsQuery.IsDeleted=false;
            var responsiblePersonsList = ORM_CMN_STR_Office_ResponsiblePerson.Query.Search(Connection, Transaction, responsiblePersonsQuery);
            List<L5OF_GOFT_1157_ResponsiblePersons> responsiblePresonsResultList=new List<L5OF_GOFT_1157_ResponsiblePersons>();
                foreach(var responsiblePerson in responsiblePersonsList)
                {
                    L5OF_GOFT_1157_ResponsiblePersons responsiblePersonResult=new L5OF_GOFT_1157_ResponsiblePersons();
                    responsiblePersonResult.CMN_BPT_EMP_EmployeeID=responsiblePerson.CMN_BPT_EMP_Employee_RefID;
                    responsiblePersonResult.CMN_STR_Office_ResponsiblePersonID=responsiblePerson.CMN_STR_Office_ResponsiblePersonID;

                    ORM_CMN_BPT_EMP_Employee employee = new ORM_CMN_BPT_EMP_Employee();
                    employee.Load(Connection, Transaction, responsiblePerson.CMN_BPT_EMP_Employee_RefID);

                    ORM_CMN_BPT_BusinessParticipant bParticipant=new ORM_CMN_BPT_BusinessParticipant();
                    bParticipant.Load(Connection, Transaction, employee.BusinessParticipant_RefID);

                    ORM_CMN_PER_PersonInfo person=new ORM_CMN_PER_PersonInfo();
                    person.Load(Connection, Transaction, bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID);

                    responsiblePersonResult.CMN_BPT_BusinessParticipantID=bParticipant.CMN_BPT_BusinessParticipantID;
                    responsiblePersonResult.FirstName=person.FirstName;
                    responsiblePersonResult.LastName=person.LastName;
                    responsiblePresonsResultList.Add(responsiblePersonResult);
                }         
            result.Managers=responsiblePresonsResultList.ToArray();
                officesResultList.Add(result);
            }
            returnValue.Result=officesResultList.ToArray();
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OF_GOFT_1157_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OF_GOFT_1157_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OF_GOFT_1157_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OF_GOFT_1157_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OF_GOFT_1157_Array functionReturn = new FR_L5OF_GOFT_1157_Array();
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

				throw new Exception("Exception occured in method cls_get_Offices_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5OF_GOFT_1157_raw 
	{
		public Guid CMN_STR_OfficeID; 
		public Guid Region_RefID; 
		public Guid BillingAddress_CMN_AddressID; 
		public String BillingAddress_Street_Name; 
		public String BillingAddress_Street_Number; 
		public String BillingAddress_City_AdministrativeDistrict; 
		public String BillingAddress_City_Region; 
		public String BillingAddress_City_Name; 
		public String BillingAddress_City_PostalCode; 
		public String BillingAddress_Province_Name; 
		public String BillingAddress_Country_Name; 
		public String BillingAddress_Country_ISOCode; 
		public Guid ShippingAddress_CMN_AddressID; 
		public String ShippingAddress_Street_Name; 
		public String ShippingAddress_City_AdministrativeDistrict; 
		public String ShippingAddress_Street_Number; 
		public String ShippingAddress_City_Region; 
		public String ShippingAddress_City_Name; 
		public String ShippingAddress_Province_Name; 
		public String ShippingAddress_City_PostalCode; 
		public String ShippingAddress_Country_Name; 
		public String ShippingAddress_Country_ISOCode; 
		public String Default_PhoneNumber; 
		public String Default_FaxNumber; 
		public Dict OfficeName; 
		public Dict OfficeDescription; 
		public String Office_ShortName; 
		public Guid CMN_CAL_CalendarInstance_RefID; 
		public Guid Country_RefID; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public Guid CMN_BPT_EMP_EmployeeID; 
		public String LastName; 
		public Guid CMN_STR_Office_ResponsiblePersonID; 
		public String FirstName; 
		public Guid AssignmentID; 
		public Guid CMN_STR_CostCenterID; 
		public String InternalID; 
		public Dict CostcenterName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5OF_GOFT_1157[] Convert(List<L5OF_GOFT_1157_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5OF_GOFT_1157 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_STR_OfficeID)).ToArray()
	group el_L5OF_GOFT_1157 by new 
	{ 
		el_L5OF_GOFT_1157.CMN_STR_OfficeID,

	}
	into gfunct_L5OF_GOFT_1157
	select new L5OF_GOFT_1157
	{     
		CMN_STR_OfficeID = gfunct_L5OF_GOFT_1157.Key.CMN_STR_OfficeID ,
		Region_RefID = gfunct_L5OF_GOFT_1157.FirstOrDefault().Region_RefID ,
		BillingAddress_CMN_AddressID = gfunct_L5OF_GOFT_1157.FirstOrDefault().BillingAddress_CMN_AddressID ,
		BillingAddress_Street_Name = gfunct_L5OF_GOFT_1157.FirstOrDefault().BillingAddress_Street_Name ,
		BillingAddress_Street_Number = gfunct_L5OF_GOFT_1157.FirstOrDefault().BillingAddress_Street_Number ,
		BillingAddress_City_AdministrativeDistrict = gfunct_L5OF_GOFT_1157.FirstOrDefault().BillingAddress_City_AdministrativeDistrict ,
		BillingAddress_City_Region = gfunct_L5OF_GOFT_1157.FirstOrDefault().BillingAddress_City_Region ,
		BillingAddress_City_Name = gfunct_L5OF_GOFT_1157.FirstOrDefault().BillingAddress_City_Name ,
		BillingAddress_City_PostalCode = gfunct_L5OF_GOFT_1157.FirstOrDefault().BillingAddress_City_PostalCode ,
		BillingAddress_Province_Name = gfunct_L5OF_GOFT_1157.FirstOrDefault().BillingAddress_Province_Name ,
		BillingAddress_Country_Name = gfunct_L5OF_GOFT_1157.FirstOrDefault().BillingAddress_Country_Name ,
		BillingAddress_Country_ISOCode = gfunct_L5OF_GOFT_1157.FirstOrDefault().BillingAddress_Country_ISOCode ,
		ShippingAddress_CMN_AddressID = gfunct_L5OF_GOFT_1157.FirstOrDefault().ShippingAddress_CMN_AddressID ,
		ShippingAddress_Street_Name = gfunct_L5OF_GOFT_1157.FirstOrDefault().ShippingAddress_Street_Name ,
		ShippingAddress_City_AdministrativeDistrict = gfunct_L5OF_GOFT_1157.FirstOrDefault().ShippingAddress_City_AdministrativeDistrict ,
		ShippingAddress_Street_Number = gfunct_L5OF_GOFT_1157.FirstOrDefault().ShippingAddress_Street_Number ,
		ShippingAddress_City_Region = gfunct_L5OF_GOFT_1157.FirstOrDefault().ShippingAddress_City_Region ,
		ShippingAddress_City_Name = gfunct_L5OF_GOFT_1157.FirstOrDefault().ShippingAddress_City_Name ,
		ShippingAddress_Province_Name = gfunct_L5OF_GOFT_1157.FirstOrDefault().ShippingAddress_Province_Name ,
		ShippingAddress_City_PostalCode = gfunct_L5OF_GOFT_1157.FirstOrDefault().ShippingAddress_City_PostalCode ,
		ShippingAddress_Country_Name = gfunct_L5OF_GOFT_1157.FirstOrDefault().ShippingAddress_Country_Name ,
		ShippingAddress_Country_ISOCode = gfunct_L5OF_GOFT_1157.FirstOrDefault().ShippingAddress_Country_ISOCode ,
		Default_PhoneNumber = gfunct_L5OF_GOFT_1157.FirstOrDefault().Default_PhoneNumber ,
		Default_FaxNumber = gfunct_L5OF_GOFT_1157.FirstOrDefault().Default_FaxNumber ,
		OfficeName = gfunct_L5OF_GOFT_1157.FirstOrDefault().OfficeName ,
		OfficeDescription = gfunct_L5OF_GOFT_1157.FirstOrDefault().OfficeDescription ,
		Office_ShortName = gfunct_L5OF_GOFT_1157.FirstOrDefault().Office_ShortName ,
		CMN_CAL_CalendarInstance_RefID = gfunct_L5OF_GOFT_1157.FirstOrDefault().CMN_CAL_CalendarInstance_RefID ,
		Country_RefID = gfunct_L5OF_GOFT_1157.FirstOrDefault().Country_RefID ,

		Managers = 
		(
			from el_Managers in gfunct_L5OF_GOFT_1157.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_EmployeeID)).ToArray()
			group el_Managers by new 
			{ 
				el_Managers.CMN_BPT_EMP_EmployeeID,

			}
			into gfunct_Managers
			select new L5OF_GOFT_1157_ResponsiblePersons
			{     
				CMN_BPT_BusinessParticipantID = gfunct_Managers.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
				CMN_BPT_EMP_EmployeeID = gfunct_Managers.Key.CMN_BPT_EMP_EmployeeID ,
				LastName = gfunct_Managers.FirstOrDefault().LastName ,
				CMN_STR_Office_ResponsiblePersonID = gfunct_Managers.FirstOrDefault().CMN_STR_Office_ResponsiblePersonID ,
				FirstName = gfunct_Managers.FirstOrDefault().FirstName ,

			}
		).ToArray(),
		Costcenter = 
		(
			from el_Costcenter in gfunct_L5OF_GOFT_1157.Where(element => !EqualsDefaultValue(element.AssignmentID)).ToArray()
			group el_Costcenter by new 
			{ 
				el_Costcenter.AssignmentID,

			}
			into gfunct_Costcenter
			select new L5OF_GOFT_1157_Costcenter
			{     
				AssignmentID = gfunct_Costcenter.Key.AssignmentID ,
				CMN_STR_CostCenterID = gfunct_Costcenter.FirstOrDefault().CMN_STR_CostCenterID ,
				InternalID = gfunct_Costcenter.FirstOrDefault().InternalID ,
				CostcenterName = gfunct_Costcenter.FirstOrDefault().CostcenterName ,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5OF_GOFT_1157_Array : FR_Base
	{
		public L5OF_GOFT_1157[] Result	{ get; set; } 
		public FR_L5OF_GOFT_1157_Array() : base() {}

		public FR_L5OF_GOFT_1157_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OF_GOFT_1157_Array cls_get_Offices_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OF_GOFT_1157_Array invocationResult = cls_get_Offices_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
