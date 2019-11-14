/* 
 * Generated on 7/2/2013 9:31:43 AM
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

namespace CL5_KPRS_Realestate.Complex.Retrieval
{
	[DataContract]
	public class cls_Get_RealestateProperties_Data
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ER_GREPD_1350 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5ER_GREPD_1350();

            returnValue.Result=new L5ER_GREPD_1350();

            ORM_RES_RealestateProperty_Type.Query propertyTypeQuery=new ORM_RES_RealestateProperty_Type.Query();
            propertyTypeQuery.Tenant_RefID=securityTicket.TenantID;
            List<ORM_RES_RealestateProperty_Type> ormPropertyTypes=ORM_RES_RealestateProperty_Type.Query.Search(Connection,Transaction,propertyTypeQuery);
            List<L5ER_GREPD_1350_PropertyTypes> propertyTypes=new List<L5ER_GREPD_1350_PropertyTypes>();
            foreach(var propertyType in ormPropertyTypes){
                L5ER_GREPD_1350_PropertyTypes item=new L5ER_GREPD_1350_PropertyTypes();
                item.RealestatePropertyType_Description=propertyType.RealestatePropertyType_Description;
                item.RealestatePropertyType_Name=propertyType.RealestatePropertyType_Name;
                item.RES_RealestateProperty_TypeID=propertyType.RES_RealestateProperty_TypeID;
                propertyTypes.Add(item);
            }
            returnValue.Result.PropertyTypes=propertyTypes.ToArray();

            ORM_RES_RealestateProperty_SourceOfInformation.Query sourceOfInformationQuery=new ORM_RES_RealestateProperty_SourceOfInformation.Query();
            sourceOfInformationQuery.Tenant_RefID=securityTicket.TenantID;
            List<ORM_RES_RealestateProperty_SourceOfInformation> ormSourcesOfInformation=ORM_RES_RealestateProperty_SourceOfInformation.Query.Search(Connection,Transaction,sourceOfInformationQuery);
            List<L5ER_GREPD_1350_SourceOfInformation> sourcesOfInformation=new List<L5ER_GREPD_1350_SourceOfInformation>();
            foreach(var source in ormSourcesOfInformation){
                L5ER_GREPD_1350_SourceOfInformation item=new L5ER_GREPD_1350_SourceOfInformation();
                item.SourceOfInformation_Description=source.SourceOfInformation_Description;
                item.SourceOfInformation_Name=source.SourceOfInformation_Name;
                item.RES_RealestateProperty_SourceOfInformationID=source.RES_RealestateProperty_SourceOfInformationID;
                sourcesOfInformation.Add(item);
            }
            returnValue.Result.SourceOfInformations=sourcesOfInformation.ToArray();

            ORM_RES_RealestateProperty_ConstructionType.Query constructionTypeQuery = new ORM_RES_RealestateProperty_ConstructionType.Query();
            constructionTypeQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_RES_RealestateProperty_ConstructionType> ormConstructionTypes = ORM_RES_RealestateProperty_ConstructionType.Query.Search(Connection, Transaction, constructionTypeQuery);
            List<L5ER_GREPD_1350_ConstructionType> constructionTypes = new List<L5ER_GREPD_1350_ConstructionType>();
            foreach (var constructionType in ormConstructionTypes)
            {
                L5ER_GREPD_1350_ConstructionType item = new L5ER_GREPD_1350_ConstructionType();
                item.ConstructionType_Description = constructionType.ConstructionType_Description;
                item.ConstructionType_Name = constructionType.ConstructionType_Name;
                item.RES_RealestateProperty_ConstructionTypeID = constructionType.RES_RealestateProperty_ConstructionTypeID;
                constructionTypes.Add(item);
            }
            returnValue.Result.ConstructionTypes=constructionTypes.ToArray();

                

                
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ER_GREPD_1350 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ER_GREPD_1350 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ER_GREPD_1350 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ER_GREPD_1350 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ER_GREPD_1350 functionReturn = new FR_L5ER_GREPD_1350();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L5ER_GREPD_1350 : FR_Base
	{
		public L5ER_GREPD_1350 Result	{ get; set; }

		public FR_L5ER_GREPD_1350() : base() {}

		public FR_L5ER_GREPD_1350(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5ER_GREPD_1350 for attribute L5ER_GREPD_1350
		[DataContract]
		public class L5ER_GREPD_1350 
		{
			[DataMember]
			public L5ER_GREPD_1350_PropertyTypes[] PropertyTypes { get; set; }
			[DataMember]
			public L5ER_GREPD_1350_ConstructionType[] ConstructionTypes { get; set; }
			[DataMember]
			public L5ER_GREPD_1350_SourceOfInformation[] SourceOfInformations { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5ER_GREPD_1350_PropertyTypes for attribute PropertyTypes
		[DataContract]
		public class L5ER_GREPD_1350_PropertyTypes 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_RealestateProperty_TypeID { get; set; } 
			[DataMember]
			public Dict RealestatePropertyType_Name { get; set; } 
			[DataMember]
			public Dict RealestatePropertyType_Description { get; set; } 

		}
		#endregion
		#region SClass L5ER_GREPD_1350_ConstructionType for attribute ConstructionTypes
		[DataContract]
		public class L5ER_GREPD_1350_ConstructionType 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_RealestateProperty_ConstructionTypeID { get; set; } 
			[DataMember]
			public Dict ConstructionType_Name { get; set; } 
			[DataMember]
			public Dict ConstructionType_Description { get; set; } 

		}
		#endregion
		#region SClass L5ER_GREPD_1350_SourceOfInformation for attribute SourceOfInformations
		[DataContract]
		public class L5ER_GREPD_1350_SourceOfInformation 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_RealestateProperty_SourceOfInformationID { get; set; } 
			[DataMember]
			public Dict SourceOfInformation_Name { get; set; } 
			[DataMember]
			public Dict SourceOfInformation_Description { get; set; } 

		}
		#endregion

	#endregion
}
