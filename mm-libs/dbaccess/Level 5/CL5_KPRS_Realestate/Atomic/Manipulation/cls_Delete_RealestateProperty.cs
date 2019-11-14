/* 
 * Generated on 7/2/2013 9:23:23 AM
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
	[DataContract]
	public class cls_Delete_RealestateProperty
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5RE_DREP_0954 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here
            ORM_RES_RealestateProperty.Query realestatePropertyQuery = new ORM_RES_RealestateProperty.Query();
            realestatePropertyQuery.RES_RealestatePropertyID = Parameter.RES_RealestatePropertyID;
            realestatePropertyQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_RES_RealestateProperty> realestates=ORM_RES_RealestateProperty.Query.Search(Connection, Transaction, realestatePropertyQuery);
            ORM_RES_RealestateProperty.Query.SoftDelete(Connection, Transaction, realestatePropertyQuery);



            ORM_RES_RealestateProperty_2_PropertyType.Query realestatePropertyType = new ORM_RES_RealestateProperty_2_PropertyType.Query();
            realestatePropertyType.RES_RealestateProperty_Type_RefID = Parameter.RES_RealestatePropertyID;
            realestatePropertyType.Tenant_RefID = securityTicket.TenantID;
            ORM_RES_RealestateProperty_2_PropertyType.Query.SoftDelete(Connection, Transaction, realestatePropertyType);

            ORM_RES_RealestateProperty_2_PropertySourceOfInformation.Query sourceOfInformationQuery = new ORM_RES_RealestateProperty_2_PropertySourceOfInformation.Query();
            sourceOfInformationQuery.RES_RealestateProperty_RefID = Parameter.RES_RealestatePropertyID;
            sourceOfInformationQuery.Tenant_RefID = securityTicket.TenantID;
            ORM_RES_RealestateProperty_2_PropertySourceOfInformation.Query.SoftDelete(Connection, Transaction, sourceOfInformationQuery);

            ORM_RES_RealestateProperty_2_PropertyConstructionType.Query constructionTypeQuery = new ORM_RES_RealestateProperty_2_PropertyConstructionType.Query();
            constructionTypeQuery.RES_RealestateProperty_RefID = Parameter.RES_RealestatePropertyID;
            constructionTypeQuery.Tenant_RefID = securityTicket.TenantID;
            ORM_RES_RealestateProperty_2_PropertyConstructionType.Query.SoftDelete(Connection, Transaction, constructionTypeQuery);


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L5RE_DREP_0954 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5RE_DREP_0954 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RE_DREP_0954 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RE_DREP_0954 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5RE_DREP_0954 for attribute P_L5RE_DREP_0954
		[DataContract]
		public class P_L5RE_DREP_0954 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_RealestatePropertyID { get; set; } 

		}
		#endregion

	#endregion
}
