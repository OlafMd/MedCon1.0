/* 
 * Generated on 7/2/2013 9:29:46 AM
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
using CL1_RES_STR;

namespace CL5_KPRS_Question_Properties.Complex.Retrieval
{
	[DataContract]
	public class cls_Get_Properties_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GPFT_0911 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5PR_GPFT_0911();
            returnValue.Result = new L5PR_GPFT_0911();
            ORM_RES_STR_Apartment_Property.Query appartmentQuerry = new ORM_RES_STR_Apartment_Property.Query();
            appartmentQuerry.Tenant_RefID = securityTicket.TenantID;
            appartmentQuerry.IsDeleted = false;
            List<ORM_RES_STR_Apartment_Property> appartmentResults = ORM_RES_STR_Apartment_Property.Query.Search(Connection, Transaction, appartmentQuerry);
            List<L5PR_GPFT_0911_Apartments> apartments = new List<L5PR_GPFT_0911_Apartments>();
            foreach (var item in appartmentResults)
            {
                L5PR_GPFT_0911_Apartments temp = new L5PR_GPFT_0911_Apartments();
                temp.GlobalPropertyMatchingID = item.GlobalPropertyMatchingID;
                temp.Description = item.ApartmentProperty_Description;
                temp.Name = item.ApartmentProperty_Name;
                temp.RES_STR_Apartment_PropertyID = item.RES_STR_Apartment_PropertyID;
                apartments.Add(temp);
            }

            returnValue.Result.Apartments = apartments.ToArray();

            ORM_RES_STR_Attic_Property.Query AtticQuerry = new ORM_RES_STR_Attic_Property.Query();
            AtticQuerry.Tenant_RefID = securityTicket.TenantID;
            AtticQuerry.IsDeleted = false;
            List<ORM_RES_STR_Attic_Property> AtticResults = ORM_RES_STR_Attic_Property.Query.Search(Connection, Transaction, AtticQuerry);
            List<L5PR_GPFT_0911_Attic> attics = new List<L5PR_GPFT_0911_Attic>();
            foreach (var item in AtticResults)
            {
                L5PR_GPFT_0911_Attic temp = new L5PR_GPFT_0911_Attic();
                temp.GlobalPropertyMatchingID = item.GlobalPropertyMatchingID;
                temp.Description = item.AtticProperty_Description;
                temp.Name = item.AtticProperty_Name;
                temp.RES_STR_Attic_PropertyID = item.RES_STR_Attic_PropertyID;
                attics.Add(temp);
            }
            returnValue.Result.Attic = attics.ToArray();

            ORM_RES_STR_Basement_Property.Query basementQuerry = new ORM_RES_STR_Basement_Property.Query();
            basementQuerry.Tenant_RefID = securityTicket.TenantID;
            basementQuerry.IsDeleted = false;
            List<ORM_RES_STR_Basement_Property> basementResults = ORM_RES_STR_Basement_Property.Query.Search(Connection, Transaction, basementQuerry);
            List<L5PR_GPFT_0911_Basement> basements = new List<L5PR_GPFT_0911_Basement>();
            foreach (var item in basementResults)
            {
                L5PR_GPFT_0911_Basement temp = new L5PR_GPFT_0911_Basement();
                temp.GlobalPropertyMatchingID = item.GlobalPropertyMatchingID;
                temp.Description = item.BasementProperty_Description;
                temp.Name = item.BasementProperty_Name;
                temp.RES_STR_Basement_PropertyID = item.RES_STR_Basement_PropertyID;
                basements.Add(temp);
            }
            returnValue.Result.Basement = basements.ToArray();

            ORM_RES_STR_Facade_Property.Query facadeQuerry = new ORM_RES_STR_Facade_Property.Query();
            facadeQuerry.Tenant_RefID = securityTicket.TenantID;
            facadeQuerry.IsDeleted = false;
            List<ORM_RES_STR_Facade_Property> facadeResults = ORM_RES_STR_Facade_Property.Query.Search(Connection, Transaction, facadeQuerry);
            List<L5PR_GPFT_0911_Facade> facades = new List<L5PR_GPFT_0911_Facade>();
            foreach (var item in facadeResults)
            {
                L5PR_GPFT_0911_Facade temp = new L5PR_GPFT_0911_Facade();
                temp.GlobalPropertyMatchingID = item.GlobalPropertyMatchingID;
                temp.Description = item.FacadeProperty_Description;
                temp.Name = item.FacadeProperty_Name;
                temp.RES_STR_Facade_PropertyID = item.RES_STR_Facade_PropertyID;
                facades.Add(temp);
            }
            returnValue.Result.Facade = facades.ToArray();

            ORM_RES_STR_HVACR_Property.Query HVACRQuerry = new ORM_RES_STR_HVACR_Property.Query();
            HVACRQuerry.Tenant_RefID = securityTicket.TenantID;
            HVACRQuerry.IsDeleted = false;
            List<ORM_RES_STR_HVACR_Property> HVACRResults = ORM_RES_STR_HVACR_Property.Query.Search(Connection, Transaction, HVACRQuerry);
            List<L5PR_GPFT_0911_HVACR> HVACRs = new List<L5PR_GPFT_0911_HVACR>();
            foreach (var item in HVACRResults)
            {
                L5PR_GPFT_0911_HVACR temp = new L5PR_GPFT_0911_HVACR();
                temp.GlobalPropertyMatchingID = item.GlobalPropertyMatchingID;
                temp.Description = item.HVACRProperty_Description;
                temp.Name = item.HVACRProperty_Name;
                temp.RES_STR_HVACR_PropertyID = item.RES_STR_HVACR_PropertyID;
                HVACRs.Add(temp);
            }
            returnValue.Result.HVACR = HVACRs.ToArray();

            ORM_RES_STR_OutdoorFacility_Property.Query outdoorFacilityQuerry = new ORM_RES_STR_OutdoorFacility_Property.Query();
            outdoorFacilityQuerry.Tenant_RefID = securityTicket.TenantID;
            outdoorFacilityQuerry.IsDeleted = false;
            List<ORM_RES_STR_OutdoorFacility_Property> outdoorFacilityResults = ORM_RES_STR_OutdoorFacility_Property.Query.Search(Connection, Transaction, outdoorFacilityQuerry);
            List<L5PR_GPFT_0911_OutdoorFacility> outdoorFacilitys = new List<L5PR_GPFT_0911_OutdoorFacility>();
            foreach (var item in outdoorFacilityResults)
            {
                L5PR_GPFT_0911_OutdoorFacility temp = new L5PR_GPFT_0911_OutdoorFacility();
                temp.GlobalPropertyMatchingID = item.GlobalPropertyMatchingID.ToString();
                temp.Description = item.OutdoorFacilityProperty_Description;
                temp.Name = item.OutdoorFacilityProperty_Name;
                temp.RES_STR_OutdoorFacility_PropertyID = item.RES_STR_OutdoorFacility_PropertyID;
                outdoorFacilitys.Add(temp);
            }
            returnValue.Result.OutdoorFacility = outdoorFacilitys.ToArray();

            ORM_RES_STR_Roof_Property.Query roofQuerry = new ORM_RES_STR_Roof_Property.Query();
            roofQuerry.Tenant_RefID = securityTicket.TenantID;
            roofQuerry.IsDeleted = false;
            List<ORM_RES_STR_Roof_Property> roofResults = ORM_RES_STR_Roof_Property.Query.Search(Connection, Transaction, roofQuerry);
            List<L5PR_GPFT_0911_Roof> roofs = new List<L5PR_GPFT_0911_Roof>();
            foreach (var item in roofResults)
            {
                L5PR_GPFT_0911_Roof temp = new L5PR_GPFT_0911_Roof();
                temp.GlobalPropertyMatchingID = item.GlobalPropertyMatchingID;
                temp.Description = item.RoofProperty_Description;
                temp.Name = item.RoofProperty_Name;
                temp.RES_STR_Roof_PropertyID = item.RES_STR_Roof_PropertyID;
                roofs.Add(temp);
            }
            returnValue.Result.Roof = roofs.ToArray();

            ORM_RES_STR_Staircase_Property.Query staircaseQuerry = new ORM_RES_STR_Staircase_Property.Query();
            staircaseQuerry.Tenant_RefID = securityTicket.TenantID;
            staircaseQuerry.IsDeleted = false;
            List<ORM_RES_STR_Staircase_Property> staircaseResults = ORM_RES_STR_Staircase_Property.Query.Search(Connection, Transaction, staircaseQuerry);
            List<L5PR_GPFT_0911_Staircases> staircases = new List<L5PR_GPFT_0911_Staircases>();
            foreach (var item in staircaseResults)
            {
                L5PR_GPFT_0911_Staircases temp = new L5PR_GPFT_0911_Staircases();
                temp.GlobalPropertyMatchingID = item.GlobalPropertyMatchingID;
                temp.Description = item.StaircaseProperty_Description;
                temp.Name = item.StaircaseProperty_Name;
                temp.RES_STR_Staircase_PropertyID = item.RES_STR_Staircase_PropertyID;
                staircases.Add(temp);
            }
            returnValue.Result.Staircases = staircases.ToArray();

            //Put your code here
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PR_GPFT_0911 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GPFT_0911 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GPFT_0911 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GPFT_0911 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GPFT_0911 functionReturn = new FR_L5PR_GPFT_0911();
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
	public class FR_L5PR_GPFT_0911 : FR_Base
	{
		public L5PR_GPFT_0911 Result	{ get; set; }

		public FR_L5PR_GPFT_0911() : base() {}

		public FR_L5PR_GPFT_0911(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5PR_GPFT_0911 for attribute L5PR_GPFT_0911
		[DataContract]
		public class L5PR_GPFT_0911 
		{
			[DataMember]
			public L5PR_GPFT_0911_Apartments[] Apartments { get; set; }
			[DataMember]
			public L5PR_GPFT_0911_Staircases[] Staircases { get; set; }
			[DataMember]
			public L5PR_GPFT_0911_OutdoorFacility[] OutdoorFacility { get; set; }
			[DataMember]
			public L5PR_GPFT_0911_Facade[] Facade { get; set; }
			[DataMember]
			public L5PR_GPFT_0911_Attic[] Attic { get; set; }
			[DataMember]
			public L5PR_GPFT_0911_HVACR[] HVACR { get; set; }
			[DataMember]
			public L5PR_GPFT_0911_Basement[] Basement { get; set; }
			[DataMember]
			public L5PR_GPFT_0911_Roof[] Roof { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5PR_GPFT_0911_Apartments for attribute Apartments
		[DataContract]
		public class L5PR_GPFT_0911_Apartments 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Apartment_PropertyID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5PR_GPFT_0911_Staircases for attribute Staircases
		[DataContract]
		public class L5PR_GPFT_0911_Staircases 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Staircase_PropertyID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5PR_GPFT_0911_OutdoorFacility for attribute OutdoorFacility
		[DataContract]
		public class L5PR_GPFT_0911_OutdoorFacility 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_OutdoorFacility_PropertyID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5PR_GPFT_0911_Facade for attribute Facade
		[DataContract]
		public class L5PR_GPFT_0911_Facade 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Facade_PropertyID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5PR_GPFT_0911_Attic for attribute Attic
		[DataContract]
		public class L5PR_GPFT_0911_Attic 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Attic_PropertyID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5PR_GPFT_0911_HVACR for attribute HVACR
		[DataContract]
		public class L5PR_GPFT_0911_HVACR 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_HVACR_PropertyID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5PR_GPFT_0911_Basement for attribute Basement
		[DataContract]
		public class L5PR_GPFT_0911_Basement 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Basement_PropertyID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion
		#region SClass L5PR_GPFT_0911_Roof for attribute Roof
		[DataContract]
		public class L5PR_GPFT_0911_Roof 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Roof_PropertyID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 

		}
		#endregion

	#endregion
}
