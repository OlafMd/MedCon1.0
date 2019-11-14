/* 
 * Generated on 8/28/2013 3:17:51 PM
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

namespace CL6_KPRS_RealestateProperty.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_all_RealestateProperties_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_all_RealestateProperties_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6RP_GaRPfT_1139_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6RP_GaRPfT_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

            var returnStatus = new FR_L6RP_GaRPfT_1139_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_KPRS_RealestateProperty.Atomic.Retrieval.SQL.cls_Get_all_RealestateProperties_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
            CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "UploaderUserName", Parameter.UploaderUserName);

            if (Parameter.UploaderUserName_IsSpecified == false)
            {
                var regex = new System.Text.RegularExpressions.Regex(@"((and|or)\s*)?(\w*\.)?\w*\s*(=|like|<|>)\s*@UploaderUserName(\s*collate\s+\w+)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                command.CommandText = regex.Replace(command.CommandText, "");
            }
            CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Title", Parameter.Title);

            if (Parameter.Title_IsSpecified == false)
            {
                var regex = new System.Text.RegularExpressions.Regex(@"((and|or)\s*)?(\w*\.)?\w*\s*(=|like|<|>)\s*@Title(\s*collate\s+\w+)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                command.CommandText = regex.Replace(command.CommandText, "");
            }
            CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "StreetName", Parameter.StreetName);

            if (Parameter.StreetName_IsSpecified == false)
            {
                var regex = new System.Text.RegularExpressions.Regex(@"((and|or)\s*)?(\w*\.)?\w*\s*(=|like|<|>)\s*@StreetName(\s*collate\s+\w+)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                command.CommandText = regex.Replace(command.CommandText, "");
            }
            CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "StreetNumber", Parameter.StreetNumber);

            if (Parameter.StreetNumber_IsSpecified == false)
            {
                var regex = new System.Text.RegularExpressions.Regex(@"((and|or)\s*)?(\w*\.)?\w*\s*(=|like|<|>)\s*@StreetNumber(\s*collate\s+\w+)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                command.CommandText = regex.Replace(command.CommandText, "");
            }
            CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "City", Parameter.City);

            if (Parameter.City_IsSpecified == false)
            {
                var regex = new System.Text.RegularExpressions.Regex(@"((and|or)\s*)?(\w*\.)?\w*\s*(=|like|<|>)\s*@City(\s*collate\s+\w+)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                command.CommandText = regex.Replace(command.CommandText, "");
            }
            CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Province", Parameter.Province);

            if (Parameter.Province_IsSpecified == false)
            {
                var regex = new System.Text.RegularExpressions.Regex(@"((and|or)\s*)?(\w*\.)?\w*\s*(=|like|<|>)\s*@Province(\s*collate\s+\w+)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                command.CommandText = regex.Replace(command.CommandText, "");
            }
            CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Region", Parameter.Region);

            if (Parameter.Region_IsSpecified == false)
            {
                var regex = new System.Text.RegularExpressions.Regex(@"((and|or)\s*)?(\w*\.)?\w*\s*(=|like|<|>)\s*@Region(\s*collate\s+\w+)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                command.CommandText = regex.Replace(command.CommandText, "");
            }
            CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ZipCode", Parameter.ZipCode);

            if (Parameter.ZipCode_IsSpecified == false)
            {
                var regex = new System.Text.RegularExpressions.Regex(@"((and|or)\s*)?(\w*\.)?\w*\s*(=|like|<|>)\s*@ZipCode(\s*collate\s+\w+)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                command.CommandText = regex.Replace(command.CommandText, "");
            }
            
            if (Parameter.Country_IsSpecified == true)
            {
                //var regex = new System.Text.RegularExpressions.Regex(@"((and|or)\s*)?(\w*\.)?\w*\s*(=|like|<|>)\s*@Country(\s*collate\s+\w+)?", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //command.CommandText = regex.Replace(command.CommandText, "");
                command.CommandText += " And \ncmn_addresses.Country_ISOCode In (@CountryISO)";
                CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CountryISO", Parameter.Country);
            }
            
			List<L6RP_GaRPfT_1139_raw> results = new List<L6RP_GaRPfT_1139_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Username","USR_AccountID","RealestateProperty_Title","Street_Name","Street_Number","City_AdministrativeDistrict","City_Region","City_Name","Province_Name","City_PostalCode","Country_Name","Country_ISOCode","RES_RealestatePropertyID","Creation_Timestamp","Geolocation_Lattitude","Geolocation_Longitude","RES_BLD_BuildingID","Building_Name","Building_BalconyPortionPercent" });
				while(reader.Read())
				{
					L6RP_GaRPfT_1139_raw resultItem = new L6RP_GaRPfT_1139_raw();
					//0:Parameter Username of type String
					resultItem.Username = reader.GetString(0);
					//1:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(1);
					//2:Parameter RealestateProperty_Title of type String
					resultItem.RealestateProperty_Title = reader.GetString(2);
					//3:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(3);
					//4:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(4);
					//5:Parameter City_AdministrativeDistrict of type String
					resultItem.City_AdministrativeDistrict = reader.GetString(5);
					//6:Parameter City_Region of type String
					resultItem.City_Region = reader.GetString(6);
					//7:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(7);
					//8:Parameter Province_Name of type String
					resultItem.Province_Name = reader.GetString(8);
					//9:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(9);
					//10:Parameter Country_Name of type String
					resultItem.Country_Name = reader.GetString(10);
					//11:Parameter Country_ISOCode of type String
					resultItem.Country_ISOCode = reader.GetString(11);
					//12:Parameter RES_RealestatePropertyID of type Guid
					resultItem.RES_RealestatePropertyID = reader.GetGuid(12);
					//13:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(13);
					//14:Parameter Geolocation_Lattitude of type String
					resultItem.Geolocation_Lattitude = reader.GetString(14);
					//15:Parameter Geolocation_Longitude of type String
					resultItem.Geolocation_Longitude = reader.GetString(15);
					//16:Parameter RES_BLD_BuildingID of type Guid
					resultItem.RES_BLD_BuildingID = reader.GetGuid(16);
					//17:Parameter Building_Name of type String
					resultItem.Building_Name = reader.GetString(17);
					//18:Parameter Building_BalconyPortionPercent of type String
					resultItem.Building_BalconyPortionPercent = reader.GetString(18);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

            returnStatus.Result = L6RP_GaRPfT_1139_raw.Convert(results, Parameter.StartIndex, Parameter.RowCount).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6RP_GaRPfT_1139_Array Invoke(string ConnectionString,P_L6RP_GaRPfT_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6RP_GaRPfT_1139_Array Invoke(DbConnection Connection,P_L6RP_GaRPfT_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6RP_GaRPfT_1139_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6RP_GaRPfT_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6RP_GaRPfT_1139_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6RP_GaRPfT_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6RP_GaRPfT_1139_Array functionReturn = new FR_L6RP_GaRPfT_1139_Array();
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

	#region Raw Grouping Class
	[Serializable]
	public class L6RP_GaRPfT_1139_raw 
	{
		public String Username; 
		public Guid USR_AccountID; 
		public String RealestateProperty_Title; 
		public String Street_Name; 
		public String Street_Number; 
		public String City_AdministrativeDistrict; 
		public String City_Region; 
		public String City_Name; 
		public String Province_Name; 
		public String City_PostalCode; 
		public String Country_Name; 
		public String Country_ISOCode; 
		public Guid RES_RealestatePropertyID; 
		public DateTime Creation_Timestamp; 
		public String Geolocation_Lattitude; 
		public String Geolocation_Longitude; 
		public Guid RES_BLD_BuildingID; 
		public String Building_Name; 
		public String Building_BalconyPortionPercent; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6RP_GaRPfT_1139[] Convert(List<L6RP_GaRPfT_1139_raw> rawResult, int startIndex, int rowCount)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6RP_GaRPfT_1139 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.Creation_Timestamp)).ToArray()
	group el_L6RP_GaRPfT_1139 by new 
	{ 
		el_L6RP_GaRPfT_1139.Creation_Timestamp,

	}
	into gfunct_L6RP_GaRPfT_1139
	select new L6RP_GaRPfT_1139
	{     
		Username = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().Username ,
		USR_AccountID = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().USR_AccountID ,
		RealestateProperty_Title = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().RealestateProperty_Title ,
		Street_Name = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().Street_Name ,
		Street_Number = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().Street_Number ,
		City_AdministrativeDistrict = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().City_AdministrativeDistrict ,
		City_Region = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().City_Region ,
		City_Name = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().City_Name ,
		Province_Name = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().Province_Name ,
		City_PostalCode = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().City_PostalCode ,
		Country_Name = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().Country_Name ,
		Country_ISOCode = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().Country_ISOCode ,
		RES_RealestatePropertyID = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().RES_RealestatePropertyID ,
		Creation_Timestamp = gfunct_L6RP_GaRPfT_1139.Key.Creation_Timestamp ,
		Geolocation_Lattitude = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().Geolocation_Lattitude ,
		Geolocation_Longitude = gfunct_L6RP_GaRPfT_1139.FirstOrDefault().Geolocation_Longitude ,

		Building = 
		(
			from el_Building in gfunct_L6RP_GaRPfT_1139.Where(element => !EqualsDefaultValue(element.RES_BLD_BuildingID)).ToArray()
			group el_Building by new 
			{ 
				el_Building.RES_BLD_BuildingID,

			}
			into gfunct_Building
			select new L6RP_GaRPfT_1139_Building
			{     
				RES_BLD_BuildingID = gfunct_Building.Key.RES_BLD_BuildingID ,
				Building_Name = gfunct_Building.FirstOrDefault().Building_Name ,
				Building_BalconyPortionPercent = gfunct_Building.FirstOrDefault().Building_BalconyPortionPercent ,

			}
		).ToArray(),

	};

            return groupResult.Skip(startIndex).Take(rowCount).ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6RP_GaRPfT_1139_Array : FR_Base
	{
		public L6RP_GaRPfT_1139[] Result	{ get; set; } 
		public FR_L6RP_GaRPfT_1139_Array() : base() {}

		public FR_L6RP_GaRPfT_1139_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6RP_GaRPfT_1139 for attribute P_L6RP_GaRPfT_1139
		[DataContract]
		public class P_L6RP_GaRPfT_1139 
		{
			//Standard type parameters
			[DataMember]
            public String UploaderUserName { get; set; }
            [DataMember] //Special parameter for query parsing
            public bool UploaderUserName_IsSpecified { get; set; }
			[DataMember]
            public String Title { get; set; }
            [DataMember] //Special parameter for query parsing
            public bool Title_IsSpecified { get; set; }
			[DataMember]
            public String StreetName { get; set; }
            [DataMember] //Special parameter for query parsing
            public bool StreetName_IsSpecified { get; set; }
			[DataMember]
            public String StreetNumber { get; set; }
            [DataMember] //Special parameter for query parsing
            public bool StreetNumber_IsSpecified { get; set; }
			[DataMember]
            public String City { get; set; }
            [DataMember] //Special parameter for query parsing
            public bool City_IsSpecified { get; set; }
			[DataMember]
            public String Province { get; set; }
            [DataMember] //Special parameter for query parsing
            public bool Province_IsSpecified { get; set; }
			[DataMember]
            public String Region { get; set; }
            [DataMember] //Special parameter for query parsing
            public bool Region_IsSpecified { get; set; }
			[DataMember]
            public String ZipCode { get; set; }
            [DataMember] //Special parameter for query parsing
            public bool ZipCode_IsSpecified { get; set; }
			[DataMember]
            public String Country { get; set; }
            [DataMember] //Special parameter for query parsing
            public bool Country_IsSpecified { get; set; }
			[DataMember]
			public int RowCount { get; set; } 
			[DataMember]
			public int StartIndex { get; set; } 

		}
		#endregion
		#region SClass L6RP_GaRPfT_1139 for attribute L6RP_GaRPfT_1139
		[DataContract]
		public class L6RP_GaRPfT_1139 
		{
			[DataMember]
			public L6RP_GaRPfT_1139_Building[] Building { get; set; }

			//Standard type parameters
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public String RealestateProperty_Title { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_AdministrativeDistrict { get; set; } 
			[DataMember]
			public String City_Region { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String Province_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 
			[DataMember]
			public Guid RES_RealestatePropertyID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String Geolocation_Lattitude { get; set; } 
			[DataMember]
			public String Geolocation_Longitude { get; set; } 

		}
		#endregion
		#region SClass L6RP_GaRPfT_1139_Building for attribute Building
		[DataContract]
		public class L6RP_GaRPfT_1139_Building 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_BuildingID { get; set; } 
			[DataMember]
			public String Building_Name { get; set; } 
			[DataMember]
			public String Building_BalconyPortionPercent { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6RP_GaRPfT_1139_Array cls_Get_all_RealestateProperties_for_Tenant(P_L6RP_GaRPfT_1139 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L6RP_GaRPfT_1139_Array result = cls_Get_all_RealestateProperties_for_Tenant.Invoke(connectionString,P_L6RP_GaRPfT_1139 Parameter,securityTicket);
	 return result;
}
*/