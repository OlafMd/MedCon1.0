/* 
 * Generated on 7/8/2013 9:29:06 AM
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

namespace CL5_KPRS_Realestate.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RealestateProperties_For_RealestatePropertiesID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RealestateProperties_For_RealestatePropertiesID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RE_GRPFRP_0846 Execute(DbConnection Connection,DbTransaction Transaction,P_L5RE_GRPFRP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5RE_GRPFRP_0846();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_Realestate.Atomic.Retrieval.SQL.cls_Get_RealestateProperties_For_RealestatePropertiesID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RealestatePropertyID", Parameter.RealestatePropertyID);



			List<L5RE_GRPFRP_0846_raw> results = new List<L5RE_GRPFRP_0846_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RES_RealestatePropertyID","InformationSubmittedBy_Account_RefID","RealestateProperty_Address_RefID","RealestateProperty_Location_RefID","RealestateProperty_GroundValuePrice_RefID","RealestateProperty_AverageAreaRentPrice_RefID","Geolocation_Lattitude","Geolocation_Longitude","RealestateProperty_Title","RealestateProperty_InternalID","RealestateProperty_ConstructionDate","RealestateProperty_RefurbishmentDate","RealestateProperty_LivingSpace_in_sqm","RealestateProperty_InformationDate","RealestateProperty_NumberOfResidentialUnits","CMN_PER_PersonInfoID","FirstName","LastName","Username","RealestateProperty_GroundAreaSize_in_sqm","ConstructionTypeAssigmentID","ConstructionType_Name_DictID","ConstructionType_Description_DictID","ConstructionTypeComment","RES_RealestateProperty_ConstructionTypeID","RES_RealestateProperty_TypeID","PropertyTypeAssigment","RealestatePropertyType_Name_DictID","RealestatePropertyType_Description_DictID","PropertyTypeComment","SourceOfInformationComment","SourceOfInformation_Description_DictID","SourceOfInformation_Name_DictID","SourceOfInformationAssigmentID","RES_RealestateProperty_SourceOfInformationID" });
				while(reader.Read())
				{
					L5RE_GRPFRP_0846_raw resultItem = new L5RE_GRPFRP_0846_raw();
					//0:Parameter RES_RealestatePropertyID of type Guid
					resultItem.RES_RealestatePropertyID = reader.GetGuid(0);
					//1:Parameter InformationSubmittedBy_Account_RefID of type Guid
					resultItem.InformationSubmittedBy_Account_RefID = reader.GetGuid(1);
					//2:Parameter RealestateProperty_Address_RefID of type Guid
					resultItem.RealestateProperty_Address_RefID = reader.GetGuid(2);
					//3:Parameter RealestateProperty_Location_RefID of type Guid
					resultItem.RealestateProperty_Location_RefID = reader.GetGuid(3);
					//4:Parameter RealestateProperty_GroundValuePrice_RefID of type Guid
					resultItem.RealestateProperty_GroundValuePrice_RefID = reader.GetGuid(4);
					//5:Parameter RealestateProperty_AverageAreaRentPrice_RefID of type Guid
					resultItem.RealestateProperty_AverageAreaRentPrice_RefID = reader.GetGuid(5);
					//6:Parameter Geolocation_Lattitude of type String
					resultItem.Geolocation_Lattitude = reader.GetString(6);
					//7:Parameter Geolocation_Longitude of type String
					resultItem.Geolocation_Longitude = reader.GetString(7);
					//8:Parameter RealestateProperty_Title of type String
					resultItem.RealestateProperty_Title = reader.GetString(8);
					//9:Parameter RealestateProperty_InternalID of type String
					resultItem.RealestateProperty_InternalID = reader.GetString(9);
					//10:Parameter RealestateProperty_ConstructionDate of type DateTime
					resultItem.RealestateProperty_ConstructionDate = reader.GetDate(10);
					//11:Parameter RealestateProperty_RefurbishmentDate of type DateTime
					resultItem.RealestateProperty_RefurbishmentDate = reader.GetDate(11);
					//12:Parameter RealestateProperty_LivingSpace_in_sqm of type String
					resultItem.RealestateProperty_LivingSpace_in_sqm = reader.GetString(12);
					//13:Parameter RealestateProperty_InformationDate of type DateTime
					resultItem.RealestateProperty_InformationDate = reader.GetDate(13);
					//14:Parameter RealestateProperty_NumberOfResidentialUnits of type String
					resultItem.RealestateProperty_NumberOfResidentialUnits = reader.GetString(14);
					//15:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(15);
					//16:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(16);
					//17:Parameter LastName of type String
					resultItem.LastName = reader.GetString(17);
					//18:Parameter Username of type String
					resultItem.Username = reader.GetString(18);
					//19:Parameter RealestateProperty_GroundAreaSize_in_sqm of type double
					resultItem.RealestateProperty_GroundAreaSize_in_sqm = reader.GetDouble(19);
					//20:Parameter ConstructionTypeAssigmentID of type Guid
					resultItem.ConstructionTypeAssigmentID = reader.GetGuid(20);
					//21:Parameter ConstructionType_Name of type Dict
					resultItem.ConstructionType_Name = reader.GetDictionary(21);
					resultItem.ConstructionType_Name.SourceTable = "res_realestateproperty_constructiontypes";
					loader.Append(resultItem.ConstructionType_Name);
					//22:Parameter ConstructionType_Description of type Dict
					resultItem.ConstructionType_Description = reader.GetDictionary(22);
					resultItem.ConstructionType_Description.SourceTable = "res_realestateproperty_constructiontypes";
					loader.Append(resultItem.ConstructionType_Description);
					//23:Parameter ConstructionTypeComment of type String
					resultItem.ConstructionTypeComment = reader.GetString(23);
					//24:Parameter RES_RealestateProperty_ConstructionTypeID of type Guid
					resultItem.RES_RealestateProperty_ConstructionTypeID = reader.GetGuid(24);
					//25:Parameter RES_RealestateProperty_TypeID of type Guid
					resultItem.RES_RealestateProperty_TypeID = reader.GetGuid(25);
					//26:Parameter PropertyTypeAssigment of type String
					resultItem.PropertyTypeAssigment = reader.GetString(26);
					//27:Parameter RealestatePropertyType_Name of type Dict
					resultItem.RealestatePropertyType_Name = reader.GetDictionary(27);
					resultItem.RealestatePropertyType_Name.SourceTable = "res_realestateproperty_types";
					loader.Append(resultItem.RealestatePropertyType_Name);
					//28:Parameter RealestatePropertyType_Description of type Dict
					resultItem.RealestatePropertyType_Description = reader.GetDictionary(28);
					resultItem.RealestatePropertyType_Description.SourceTable = "res_realestateproperty_types";
					loader.Append(resultItem.RealestatePropertyType_Description);
					//29:Parameter PropertyTypeComment of type String
					resultItem.PropertyTypeComment = reader.GetString(29);
					//30:Parameter SourceOfInformationComment of type String
					resultItem.SourceOfInformationComment = reader.GetString(30);
					//31:Parameter SourceOfInformation_Description of type Dict
					resultItem.SourceOfInformation_Description = reader.GetDictionary(31);
					resultItem.SourceOfInformation_Description.SourceTable = "res_realestateproperty_sourceofinformation";
					loader.Append(resultItem.SourceOfInformation_Description);
					//32:Parameter SourceOfInformation_Name of type Dict
					resultItem.SourceOfInformation_Name = reader.GetDictionary(32);
					resultItem.SourceOfInformation_Name.SourceTable = "res_realestateproperty_sourceofinformation";
					loader.Append(resultItem.SourceOfInformation_Name);
					//33:Parameter SourceOfInformationAssigmentID of type Guid
					resultItem.SourceOfInformationAssigmentID = reader.GetGuid(33);
					//34:Parameter RES_RealestateProperty_SourceOfInformationID of type Guid
					resultItem.RES_RealestateProperty_SourceOfInformationID = reader.GetGuid(34);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RealestateProperties_For_RealestatePropertiesID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5RE_GRPFRP_0846_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5RE_GRPFRP_0846 Invoke(string ConnectionString,P_L5RE_GRPFRP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RE_GRPFRP_0846 Invoke(DbConnection Connection,P_L5RE_GRPFRP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RE_GRPFRP_0846 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RE_GRPFRP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RE_GRPFRP_0846 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RE_GRPFRP_0846 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RE_GRPFRP_0846 functionReturn = new FR_L5RE_GRPFRP_0846();
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

				throw new Exception("Exception occured in method cls_Get_RealestateProperties_For_RealestatePropertiesID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5RE_GRPFRP_0846_raw 
	{
		public Guid RES_RealestatePropertyID; 
		public Guid InformationSubmittedBy_Account_RefID; 
		public Guid RealestateProperty_Address_RefID; 
		public Guid RealestateProperty_Location_RefID; 
		public Guid RealestateProperty_GroundValuePrice_RefID; 
		public Guid RealestateProperty_AverageAreaRentPrice_RefID; 
		public String Geolocation_Lattitude; 
		public String Geolocation_Longitude; 
		public String RealestateProperty_Title; 
		public String RealestateProperty_InternalID; 
		public DateTime RealestateProperty_ConstructionDate; 
		public DateTime RealestateProperty_RefurbishmentDate; 
		public String RealestateProperty_LivingSpace_in_sqm; 
		public DateTime RealestateProperty_InformationDate; 
		public String RealestateProperty_NumberOfResidentialUnits; 
		public Guid CMN_PER_PersonInfoID; 
		public String FirstName; 
		public String LastName; 
		public String Username; 
		public double RealestateProperty_GroundAreaSize_in_sqm; 
		public Guid ConstructionTypeAssigmentID; 
		public Dict ConstructionType_Name; 
		public Dict ConstructionType_Description; 
		public String ConstructionTypeComment; 
		public Guid RES_RealestateProperty_ConstructionTypeID; 
		public Guid RES_RealestateProperty_TypeID; 
		public String PropertyTypeAssigment; 
		public Dict RealestatePropertyType_Name; 
		public Dict RealestatePropertyType_Description; 
		public String PropertyTypeComment; 
		public String SourceOfInformationComment; 
		public Dict SourceOfInformation_Description; 
		public Dict SourceOfInformation_Name; 
		public Guid SourceOfInformationAssigmentID; 
		public Guid RES_RealestateProperty_SourceOfInformationID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5RE_GRPFRP_0846[] Convert(List<L5RE_GRPFRP_0846_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5RE_GRPFRP_0846 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_RealestatePropertyID)).ToArray()
	group el_L5RE_GRPFRP_0846 by new 
	{ 
		el_L5RE_GRPFRP_0846.RES_RealestatePropertyID,

	}
	into gfunct_L5RE_GRPFRP_0846
	select new L5RE_GRPFRP_0846
	{     
		RES_RealestatePropertyID = gfunct_L5RE_GRPFRP_0846.Key.RES_RealestatePropertyID ,
		InformationSubmittedBy_Account_RefID = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().InformationSubmittedBy_Account_RefID ,
		RealestateProperty_Address_RefID = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().RealestateProperty_Address_RefID ,
		RealestateProperty_Location_RefID = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().RealestateProperty_Location_RefID ,
		RealestateProperty_GroundValuePrice_RefID = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().RealestateProperty_GroundValuePrice_RefID ,
		RealestateProperty_AverageAreaRentPrice_RefID = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().RealestateProperty_AverageAreaRentPrice_RefID ,
		Geolocation_Lattitude = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().Geolocation_Lattitude ,
		Geolocation_Longitude = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().Geolocation_Longitude ,
		RealestateProperty_Title = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().RealestateProperty_Title ,
		RealestateProperty_InternalID = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().RealestateProperty_InternalID ,
		RealestateProperty_ConstructionDate = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().RealestateProperty_ConstructionDate ,
		RealestateProperty_RefurbishmentDate = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().RealestateProperty_RefurbishmentDate ,
		RealestateProperty_LivingSpace_in_sqm = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().RealestateProperty_LivingSpace_in_sqm ,
		RealestateProperty_InformationDate = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().RealestateProperty_InformationDate ,
		RealestateProperty_NumberOfResidentialUnits = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().RealestateProperty_NumberOfResidentialUnits ,
		CMN_PER_PersonInfoID = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().CMN_PER_PersonInfoID ,
		FirstName = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().FirstName ,
		LastName = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().LastName ,
		Username = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().Username ,
		RealestateProperty_GroundAreaSize_in_sqm = gfunct_L5RE_GRPFRP_0846.FirstOrDefault().RealestateProperty_GroundAreaSize_in_sqm ,

		ConstructionType = 
		(
			from el_ConstructionType in gfunct_L5RE_GRPFRP_0846.Where(element => !EqualsDefaultValue(element.RES_RealestateProperty_ConstructionTypeID)).ToArray()
			group el_ConstructionType by new 
			{ 
				el_ConstructionType.RES_RealestateProperty_ConstructionTypeID,

			}
			into gfunct_ConstructionType
			select new L5RE_GRPFRP_0846_ConstructionType
			{     
				ConstructionTypeAssigmentID = gfunct_ConstructionType.FirstOrDefault().ConstructionTypeAssigmentID ,
				ConstructionType_Name = gfunct_ConstructionType.FirstOrDefault().ConstructionType_Name ,
				ConstructionType_Description = gfunct_ConstructionType.FirstOrDefault().ConstructionType_Description ,
				ConstructionTypeComment = gfunct_ConstructionType.FirstOrDefault().ConstructionTypeComment ,
				RES_RealestateProperty_ConstructionTypeID = gfunct_ConstructionType.Key.RES_RealestateProperty_ConstructionTypeID ,

			}
		).FirstOrDefault(),
		PropertyType = 
		(
			from el_PropertyType in gfunct_L5RE_GRPFRP_0846.Where(element => !EqualsDefaultValue(element.RES_RealestateProperty_TypeID)).ToArray()
			group el_PropertyType by new 
			{ 
				el_PropertyType.RES_RealestateProperty_TypeID,

			}
			into gfunct_PropertyType
			select new L5RE_GRPFRP_0846_PropertyType
			{     
				RES_RealestateProperty_TypeID = gfunct_PropertyType.Key.RES_RealestateProperty_TypeID ,
				PropertyTypeAssigment = gfunct_PropertyType.FirstOrDefault().PropertyTypeAssigment ,
				RealestatePropertyType_Name = gfunct_PropertyType.FirstOrDefault().RealestatePropertyType_Name ,
				RealestatePropertyType_Description = gfunct_PropertyType.FirstOrDefault().RealestatePropertyType_Description ,
				PropertyTypeComment = gfunct_PropertyType.FirstOrDefault().PropertyTypeComment ,

			}
		).FirstOrDefault(),
		SourceOfInformation = 
		(
			from el_SourceOfInformation in gfunct_L5RE_GRPFRP_0846.Where(element => !EqualsDefaultValue(element.RES_RealestateProperty_SourceOfInformationID)).ToArray()
			group el_SourceOfInformation by new 
			{ 
				el_SourceOfInformation.RES_RealestateProperty_SourceOfInformationID,

			}
			into gfunct_SourceOfInformation
			select new L5RE_GRPFRP_0846_SourceOfInformation
			{     
				SourceOfInformationComment = gfunct_SourceOfInformation.FirstOrDefault().SourceOfInformationComment ,
				SourceOfInformation_Description = gfunct_SourceOfInformation.FirstOrDefault().SourceOfInformation_Description ,
				SourceOfInformation_Name = gfunct_SourceOfInformation.FirstOrDefault().SourceOfInformation_Name ,
				SourceOfInformationAssigmentID = gfunct_SourceOfInformation.FirstOrDefault().SourceOfInformationAssigmentID ,
				RES_RealestateProperty_SourceOfInformationID = gfunct_SourceOfInformation.Key.RES_RealestateProperty_SourceOfInformationID ,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5RE_GRPFRP_0846 : FR_Base
	{
		public L5RE_GRPFRP_0846 Result	{ get; set; }

		public FR_L5RE_GRPFRP_0846() : base() {}

		public FR_L5RE_GRPFRP_0846(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5RE_GRPFRP_0846 for attribute P_L5RE_GRPFRP_0846
		[DataContract]
		public class P_L5RE_GRPFRP_0846 
		{
			//Standard type parameters
			[DataMember]
			public Guid RealestatePropertyID { get; set; } 

		}
		#endregion
		#region SClass L5RE_GRPFRP_0846 for attribute L5RE_GRPFRP_0846
		[DataContract]
		public class L5RE_GRPFRP_0846 
		{
			[DataMember]
			public L5RE_GRPFRP_0846_ConstructionType ConstructionType { get; set; }
			[DataMember]
			public L5RE_GRPFRP_0846_PropertyType PropertyType { get; set; }
			[DataMember]
			public L5RE_GRPFRP_0846_SourceOfInformation SourceOfInformation { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_RealestatePropertyID { get; set; } 
			[DataMember]
			public Guid InformationSubmittedBy_Account_RefID { get; set; } 
			[DataMember]
			public Guid RealestateProperty_Address_RefID { get; set; } 
			[DataMember]
			public Guid RealestateProperty_Location_RefID { get; set; } 
			[DataMember]
			public Guid RealestateProperty_GroundValuePrice_RefID { get; set; } 
			[DataMember]
			public Guid RealestateProperty_AverageAreaRentPrice_RefID { get; set; } 
			[DataMember]
			public String Geolocation_Lattitude { get; set; } 
			[DataMember]
			public String Geolocation_Longitude { get; set; } 
			[DataMember]
			public String RealestateProperty_Title { get; set; } 
			[DataMember]
			public String RealestateProperty_InternalID { get; set; } 
			[DataMember]
			public DateTime RealestateProperty_ConstructionDate { get; set; } 
			[DataMember]
			public DateTime RealestateProperty_RefurbishmentDate { get; set; } 
			[DataMember]
			public String RealestateProperty_LivingSpace_in_sqm { get; set; } 
			[DataMember]
			public DateTime RealestateProperty_InformationDate { get; set; } 
			[DataMember]
			public String RealestateProperty_NumberOfResidentialUnits { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public double RealestateProperty_GroundAreaSize_in_sqm { get; set; } 

		}
		#endregion
		#region SClass L5RE_GRPFRP_0846_ConstructionType for attribute ConstructionType
		[DataContract]
		public class L5RE_GRPFRP_0846_ConstructionType 
		{
			//Standard type parameters
			[DataMember]
			public Guid ConstructionTypeAssigmentID { get; set; } 
			[DataMember]
			public Dict ConstructionType_Name { get; set; } 
			[DataMember]
			public Dict ConstructionType_Description { get; set; } 
			[DataMember]
			public String ConstructionTypeComment { get; set; } 
			[DataMember]
			public Guid RES_RealestateProperty_ConstructionTypeID { get; set; } 

		}
		#endregion
		#region SClass L5RE_GRPFRP_0846_PropertyType for attribute PropertyType
		[DataContract]
		public class L5RE_GRPFRP_0846_PropertyType 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_RealestateProperty_TypeID { get; set; } 
			[DataMember]
			public String PropertyTypeAssigment { get; set; } 
			[DataMember]
			public Dict RealestatePropertyType_Name { get; set; } 
			[DataMember]
			public Dict RealestatePropertyType_Description { get; set; } 
			[DataMember]
			public String PropertyTypeComment { get; set; } 

		}
		#endregion
		#region SClass L5RE_GRPFRP_0846_SourceOfInformation for attribute SourceOfInformation
		[DataContract]
		public class L5RE_GRPFRP_0846_SourceOfInformation 
		{
			//Standard type parameters
			[DataMember]
			public String SourceOfInformationComment { get; set; } 
			[DataMember]
			public Dict SourceOfInformation_Description { get; set; } 
			[DataMember]
			public Dict SourceOfInformation_Name { get; set; } 
			[DataMember]
			public Guid SourceOfInformationAssigmentID { get; set; } 
			[DataMember]
			public Guid RES_RealestateProperty_SourceOfInformationID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RE_GRPFRP_0846 cls_Get_RealestateProperties_For_RealestatePropertiesID(,P_L5RE_GRPFRP_0846 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5RE_GRPFRP_0846 invocationResult = cls_Get_RealestateProperties_For_RealestatePropertiesID.Invoke(connectionString,P_L5RE_GRPFRP_0846 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_Realestate.Atomic.Retrieval.P_L5RE_GRPFRP_0846();
parameter.RealestatePropertyID = ...;

*/