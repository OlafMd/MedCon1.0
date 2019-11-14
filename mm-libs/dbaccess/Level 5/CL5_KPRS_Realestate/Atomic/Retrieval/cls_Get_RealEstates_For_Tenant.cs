/* 
 * Generated on 8/1/2013 11:56:50 AM
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
    /// var result = cls_Get_Realestates_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Realestates_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RE_GREFT_1534_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5RE_GREFT_1534_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_Realestate.Atomic.Retrieval.SQL.cls_Get_Realestates_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5RE_GREFT_1534_raw> results = new List<L5RE_GREFT_1534_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RES_RealestatePropertyID","InformationSubmittedBy_Account_RefID","RealestateProperty_Address_RefID","RealestateProperty_Location_RefID","RealestateProperty_GroundValuePrice_RefID","RealestateProperty_AverageAreaRentPrice_RefID","Geolocation_Lattitude","Geolocation_Longitude","RealestateProperty_Title","RealestateProperty_InternalID","RealestateProperty_ConstructionDate","RealestateProperty_RefurbishmentDate","RealestateProperty_LivingSpace_in_sqm","RealestateProperty_InformationDate","RealestateProperty_NumberOfResidentialUnits","CMN_PER_PersonInfoID","FirstName","LastName","Username","IsLocked","IsArchived","Creation_Timestamp" });
				while(reader.Read())
				{
					L5RE_GREFT_1534_raw resultItem = new L5RE_GREFT_1534_raw();
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
					//19:Parameter IsLocked of type bool
					resultItem.IsLocked = reader.GetBoolean(19);
					//20:Parameter IsArchived of type bool
					resultItem.IsArchived = reader.GetBoolean(20);
					//21:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(21);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Realestates_For_Tenant",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5RE_GREFT_1534_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5RE_GREFT_1534_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RE_GREFT_1534_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RE_GREFT_1534_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RE_GREFT_1534_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RE_GREFT_1534_Array functionReturn = new FR_L5RE_GREFT_1534_Array();
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

				throw new Exception("Exception occured in method cls_Get_Realestates_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5RE_GREFT_1534_raw 
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
		public bool IsLocked; 
		public bool IsArchived; 
		public DateTime Creation_Timestamp; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5RE_GREFT_1534[] Convert(List<L5RE_GREFT_1534_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5RE_GREFT_1534 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_RealestatePropertyID)).ToArray()
	group el_L5RE_GREFT_1534 by new 
	{ 
		el_L5RE_GREFT_1534.RES_RealestatePropertyID,

	}
	into gfunct_L5RE_GREFT_1534
	select new L5RE_GREFT_1534
	{     
		RES_RealestatePropertyID = gfunct_L5RE_GREFT_1534.Key.RES_RealestatePropertyID ,
		InformationSubmittedBy_Account_RefID = gfunct_L5RE_GREFT_1534.FirstOrDefault().InformationSubmittedBy_Account_RefID ,
		RealestateProperty_Address_RefID = gfunct_L5RE_GREFT_1534.FirstOrDefault().RealestateProperty_Address_RefID ,
		RealestateProperty_Location_RefID = gfunct_L5RE_GREFT_1534.FirstOrDefault().RealestateProperty_Location_RefID ,
		RealestateProperty_GroundValuePrice_RefID = gfunct_L5RE_GREFT_1534.FirstOrDefault().RealestateProperty_GroundValuePrice_RefID ,
		RealestateProperty_AverageAreaRentPrice_RefID = gfunct_L5RE_GREFT_1534.FirstOrDefault().RealestateProperty_AverageAreaRentPrice_RefID ,
		Geolocation_Lattitude = gfunct_L5RE_GREFT_1534.FirstOrDefault().Geolocation_Lattitude ,
		Geolocation_Longitude = gfunct_L5RE_GREFT_1534.FirstOrDefault().Geolocation_Longitude ,
		RealestateProperty_Title = gfunct_L5RE_GREFT_1534.FirstOrDefault().RealestateProperty_Title ,
		RealestateProperty_InternalID = gfunct_L5RE_GREFT_1534.FirstOrDefault().RealestateProperty_InternalID ,
		RealestateProperty_ConstructionDate = gfunct_L5RE_GREFT_1534.FirstOrDefault().RealestateProperty_ConstructionDate ,
		RealestateProperty_RefurbishmentDate = gfunct_L5RE_GREFT_1534.FirstOrDefault().RealestateProperty_RefurbishmentDate ,
		RealestateProperty_LivingSpace_in_sqm = gfunct_L5RE_GREFT_1534.FirstOrDefault().RealestateProperty_LivingSpace_in_sqm ,
		RealestateProperty_InformationDate = gfunct_L5RE_GREFT_1534.FirstOrDefault().RealestateProperty_InformationDate ,
		RealestateProperty_NumberOfResidentialUnits = gfunct_L5RE_GREFT_1534.FirstOrDefault().RealestateProperty_NumberOfResidentialUnits ,
		CMN_PER_PersonInfoID = gfunct_L5RE_GREFT_1534.FirstOrDefault().CMN_PER_PersonInfoID ,
		FirstName = gfunct_L5RE_GREFT_1534.FirstOrDefault().FirstName ,
		LastName = gfunct_L5RE_GREFT_1534.FirstOrDefault().LastName ,
		Username = gfunct_L5RE_GREFT_1534.FirstOrDefault().Username ,
		IsLocked = gfunct_L5RE_GREFT_1534.FirstOrDefault().IsLocked ,
		IsArchived = gfunct_L5RE_GREFT_1534.FirstOrDefault().IsArchived ,
		Creation_Timestamp = gfunct_L5RE_GREFT_1534.FirstOrDefault().Creation_Timestamp ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5RE_GREFT_1534_Array : FR_Base
	{
		public L5RE_GREFT_1534[] Result	{ get; set; } 
		public FR_L5RE_GREFT_1534_Array() : base() {}

		public FR_L5RE_GREFT_1534_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5RE_GREFT_1534 for attribute L5RE_GREFT_1534
		[DataContract]
		public class L5RE_GREFT_1534 
		{
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
			public bool IsLocked { get; set; } 
			[DataMember]
			public bool IsArchived { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RE_GREFT_1534_Array cls_Get_Realestates_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5RE_GREFT_1534_Array invocationResult = cls_Get_Realestates_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
