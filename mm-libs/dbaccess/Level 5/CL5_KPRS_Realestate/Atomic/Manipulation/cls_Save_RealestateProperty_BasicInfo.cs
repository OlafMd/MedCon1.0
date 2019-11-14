/* 
 * Generated on 8/21/2013 2:13:44 PM
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
using CL1_RES;

namespace CL5_KPRS_Realestate.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_RealestateProperty_BasicInfo.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_RealestateProperty_BasicInfo
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5RE_SREPBI_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            ORM_RES_RealestateProperty realestateProperty = new ORM_RES_RealestateProperty();
            if (Parameter.RES_RealestatePropertyID != Guid.Empty)
            {
                var result = realestateProperty.Load(Connection, Transaction, Parameter.RES_RealestatePropertyID);
                if (result.Status != FR_Status.Success || realestateProperty.RES_RealestatePropertyID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            realestateProperty.RealestateProperty_Title = Parameter.RealestateProperty_Title;
            realestateProperty.InformationSubmittedBy_Account_RefID = securityTicket.AccountID;
            realestateProperty.RealestateProperty_InformationDate = Parameter.RealestateProperty_InformationDate;
            realestateProperty.RealestateProperty_InternalID = Parameter.RealestateProperty_InternalID;
            realestateProperty.RealestateProperty_ConstructionDate = Parameter.RealestateProperty_ConstructionDate;
            realestateProperty.RealestateProperty_RefurbishmentDate = Parameter.RealestateProperty_RefurbishmentDate;
            realestateProperty.RealestateProperty_LivingSpace_in_sqm = Parameter.RealestateProperty_LivingSpace_in_sqm;
            realestateProperty.RealestateProperty_NumberOfResidentialUnits = Parameter.RealestateProperty_NumberOfResidentialUnits;
            realestateProperty.RealestateProperty_GroundAreaSize_in_sqm = Parameter.LandRegistrationEntry_GroundAreaSize_in_sqm;
            realestateProperty.Tenant_RefID = securityTicket.TenantID;
            realestateProperty.Geolocation_Lattitude = Parameter.Lattitude;
            realestateProperty.Geolocation_Longitude = Parameter.Longitude;
            realestateProperty.Save(Connection, Transaction);

            

            #region ConstructionType
         
            ORM_RES_RealestateProperty_2_PropertyConstructionType.Query constructionQuery = new ORM_RES_RealestateProperty_2_PropertyConstructionType.Query();
            constructionQuery.RES_RealestateProperty_RefID = realestateProperty.RES_RealestatePropertyID;
            constructionQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_RES_RealestateProperty_2_PropertyConstructionType> constructionTypes=ORM_RES_RealestateProperty_2_PropertyConstructionType.Query.Search(Connection, Transaction, constructionQuery);

            if (constructionTypes.Count != 0)
            {
                ORM_RES_RealestateProperty_2_PropertyConstructionType constructionType = constructionTypes[0];
                constructionType.RES_RealestateProperty_ConstructionType_RefID = Parameter.RES_RealestateProperty_ConstructionTypeID;
                constructionType.Save(Connection, Transaction);
            }
            else
            {
                ORM_RES_RealestateProperty_2_PropertyConstructionType constructionType = new ORM_RES_RealestateProperty_2_PropertyConstructionType();
                constructionType.RES_RealestateProperty_ConstructionType_RefID = Parameter.RES_RealestateProperty_ConstructionTypeID;
                constructionType.RES_RealestateProperty_RefID = realestateProperty.RES_RealestatePropertyID;
                constructionType.Tenant_RefID = securityTicket.TenantID;
                constructionType.Save(Connection, Transaction);
            }
            #endregion

            #region sourceOfInformation

            ORM_RES_RealestateProperty_2_PropertySourceOfInformation.Query sourceOfInformationQuery = new ORM_RES_RealestateProperty_2_PropertySourceOfInformation.Query();
            sourceOfInformationQuery.RES_RealestateProperty_RefID = realestateProperty.RES_RealestatePropertyID;
            sourceOfInformationQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_RES_RealestateProperty_2_PropertySourceOfInformation> sourceOfInformations = ORM_RES_RealestateProperty_2_PropertySourceOfInformation.Query.Search(Connection, Transaction, sourceOfInformationQuery);

            if (sourceOfInformations.Count != 0)
            {
                ORM_RES_RealestateProperty_2_PropertySourceOfInformation sourceOfInformation = sourceOfInformations[0];
                sourceOfInformation.RES_RealestateProperty_SourceOfInformation_RefID = Parameter.RES_RealestateProperty_SourceOfInformationID;
                sourceOfInformation.Save(Connection, Transaction);
            }
            else
            {
                ORM_RES_RealestateProperty_2_PropertySourceOfInformation sourceOfInformation = new ORM_RES_RealestateProperty_2_PropertySourceOfInformation();
                sourceOfInformation.RES_RealestateProperty_SourceOfInformation_RefID = Parameter.RES_RealestateProperty_SourceOfInformationID;
                sourceOfInformation.RES_RealestateProperty_RefID = realestateProperty.RES_RealestatePropertyID;
                sourceOfInformation.Tenant_RefID = securityTicket.TenantID;
                sourceOfInformation.Save(Connection, Transaction);
            }
            #endregion

            #region PropertyType

            ORM_RES_RealestateProperty_2_PropertyType.Query propertyTypeQuery = new ORM_RES_RealestateProperty_2_PropertyType.Query();
            propertyTypeQuery.RES_RealestateProperty_RefID = realestateProperty.RES_RealestatePropertyID;
            propertyTypeQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_RES_RealestateProperty_2_PropertyType> propertyTypes = ORM_RES_RealestateProperty_2_PropertyType.Query.Search(Connection, Transaction, propertyTypeQuery);

            if (propertyTypes.Count != 0)
            {
                ORM_RES_RealestateProperty_2_PropertyType propertyType = propertyTypes[0];
                propertyType.RES_RealestateProperty_Type_RefID = Parameter.RES_RealestateProperty_TypeID;
                propertyType.Save(Connection, Transaction);
            }
            else
            {
                ORM_RES_RealestateProperty_2_PropertyType propertyType = new ORM_RES_RealestateProperty_2_PropertyType();
                propertyType.RES_RealestateProperty_Type_RefID = Parameter.RES_RealestateProperty_TypeID;
                propertyType.RES_RealestateProperty_RefID = realestateProperty.RES_RealestatePropertyID;
                propertyType.Tenant_RefID = securityTicket.TenantID;
                propertyType.Save(Connection, Transaction);
            }
            #endregion

            returnValue.Result = realestateProperty.RES_RealestatePropertyID;
            
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5RE_SREPBI_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5RE_SREPBI_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RE_SREPBI_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RE_SREPBI_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_RealestateProperty_BasicInfo",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5RE_SREPBI_0846 for attribute P_L5RE_SREPBI_0846
		[DataContract]
		public class P_L5RE_SREPBI_0846 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_RealestatePropertyID { get; set; } 
			[DataMember]
			public String RealestateProperty_Title { get; set; } 
			[DataMember]
			public String RealestateProperty_InternalID { get; set; } 
			[DataMember]
			public Guid InformationSubmittedBy_Account_RefID { get; set; } 
			[DataMember]
			public DateTime RealestateProperty_ConstructionDate { get; set; } 
			[DataMember]
			public DateTime RealestateProperty_RefurbishmentDate { get; set; } 
			[DataMember]
			public DateTime RealestateProperty_InformationDate { get; set; } 
			[DataMember]
			public double RealestateProperty_LivingSpace_in_sqm { get; set; } 
			[DataMember]
			public int RealestateProperty_NumberOfResidentialUnits { get; set; } 
			[DataMember]
			public double LandRegistrationEntry_GroundAreaSize_in_sqm { get; set; } 
			[DataMember]
			public Guid RES_RealestateProperty_ConstructionTypeID { get; set; } 
			[DataMember]
			public Guid RES_RealestateProperty_TypeID { get; set; } 
			[DataMember]
			public Guid RES_RealestateProperty_SourceOfInformationID { get; set; } 
			[DataMember]
			public double Lattitude { get; set; } 
			[DataMember]
			public double Longitude { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_RealestateProperty_BasicInfo(,P_L5RE_SREPBI_0846 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_RealestateProperty_BasicInfo.Invoke(connectionString,P_L5RE_SREPBI_0846 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_Realestate.Atomic.Manipulation.P_L5RE_SREPBI_0846();
parameter.RES_RealestatePropertyID = ...;
parameter.RealestateProperty_Title = ...;
parameter.RealestateProperty_InternalID = ...;
parameter.InformationSubmittedBy_Account_RefID = ...;
parameter.RealestateProperty_ConstructionDate = ...;
parameter.RealestateProperty_RefurbishmentDate = ...;
parameter.RealestateProperty_InformationDate = ...;
parameter.RealestateProperty_LivingSpace_in_sqm = ...;
parameter.RealestateProperty_NumberOfResidentialUnits = ...;
parameter.LandRegistrationEntry_GroundAreaSize_in_sqm = ...;
parameter.RES_RealestateProperty_ConstructionTypeID = ...;
parameter.RES_RealestateProperty_TypeID = ...;
parameter.RES_RealestateProperty_SourceOfInformationID = ...;
parameter.Lattitude = ...;
parameter.Longitude = ...;

*/