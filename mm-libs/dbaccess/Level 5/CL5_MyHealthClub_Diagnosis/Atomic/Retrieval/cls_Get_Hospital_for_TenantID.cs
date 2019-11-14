/* 
 * Generated on 11/13/2014 4:52:53 PM
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

namespace CL5_MyHealthClub_Diagnosis.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Hospital_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Hospital_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DI_GHfTID_1158_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DI_GHfTID_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DI_GHfTID_1158_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.SQL.cls_Get_Hospital_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsHospital", Parameter.IsHospital);



			List<L5DI_GHfTID_1158_raw> results = new List<L5DI_GHfTID_1158_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ContactPersonTitle","ContactPersonFirstName","ContactPersonLastName","Street_Name","Street_Number","Town","HEC_MedicalPractiseID","ServiceName_DictID","OrganizationalUnit_Name_DictID","Default_PhoneNumber","HEC_MedicalPractice_TypeID","MedicalPracticeType_Name_DictID" });
				while(reader.Read())
				{
					L5DI_GHfTID_1158_raw resultItem = new L5DI_GHfTID_1158_raw();
					//0:Parameter ContactPersonTitle of type String
					resultItem.ContactPersonTitle = reader.GetString(0);
					//1:Parameter ContactPersonFirstName of type String
					resultItem.ContactPersonFirstName = reader.GetString(1);
					//2:Parameter ContactPersonLastName of type String
					resultItem.ContactPersonLastName = reader.GetString(2);
					//3:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(3);
					//4:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(4);
					//5:Parameter Town of type String
					resultItem.Town = reader.GetString(5);
					//6:Parameter HEC_MedicalPractiseID of type Guid
					resultItem.HEC_MedicalPractiseID = reader.GetGuid(6);
					//7:Parameter ServiceName of type Dict
					resultItem.ServiceName = reader.GetDictionary(7);
					resultItem.ServiceName.SourceTable = "hec_medicalservices";
					loader.Append(resultItem.ServiceName);
					//8:Parameter OrganizationalUnit_Name of type Dict
					resultItem.OrganizationalUnit_Name = reader.GetDictionary(8);
					resultItem.OrganizationalUnit_Name.SourceTable = "cmn_bpt_ctm_organizationalunits";
					loader.Append(resultItem.OrganizationalUnit_Name);
					//9:Parameter Default_PhoneNumber of type String
					resultItem.Default_PhoneNumber = reader.GetString(9);
					//10:Parameter HEC_MedicalPractice_TypeID of type Guid
					resultItem.HEC_MedicalPractice_TypeID = reader.GetGuid(10);
					//11:Parameter MedicalPracticeType_Name of type Dict
					resultItem.MedicalPracticeType_Name = reader.GetDictionary(11);
					resultItem.MedicalPracticeType_Name.SourceTable = "hec_medicalpractice_types";
					loader.Append(resultItem.MedicalPracticeType_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Hospital_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5DI_GHfTID_1158_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DI_GHfTID_1158_Array Invoke(string ConnectionString,P_L5DI_GHfTID_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DI_GHfTID_1158_Array Invoke(DbConnection Connection,P_L5DI_GHfTID_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DI_GHfTID_1158_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DI_GHfTID_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DI_GHfTID_1158_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DI_GHfTID_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DI_GHfTID_1158_Array functionReturn = new FR_L5DI_GHfTID_1158_Array();
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

				throw new Exception("Exception occured in method cls_Get_Hospital_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5DI_GHfTID_1158_raw 
	{
		public String ContactPersonTitle; 
		public String ContactPersonFirstName; 
		public String ContactPersonLastName; 
		public String Street_Name; 
		public String Street_Number; 
		public String Town; 
		public Guid HEC_MedicalPractiseID; 
		public Dict ServiceName; 
		public Dict OrganizationalUnit_Name; 
		public String Default_PhoneNumber; 
		public Guid HEC_MedicalPractice_TypeID; 
		public Dict MedicalPracticeType_Name; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DI_GHfTID_1158[] Convert(List<L5DI_GHfTID_1158_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DI_GHfTID_1158 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_MedicalPractiseID)).ToArray()
	group el_L5DI_GHfTID_1158 by new 
	{ 
		el_L5DI_GHfTID_1158.HEC_MedicalPractiseID,

	}
	into gfunct_L5DI_GHfTID_1158
	select new L5DI_GHfTID_1158
	{     
		ContactPersonTitle = gfunct_L5DI_GHfTID_1158.FirstOrDefault().ContactPersonTitle ,
		ContactPersonFirstName = gfunct_L5DI_GHfTID_1158.FirstOrDefault().ContactPersonFirstName ,
		ContactPersonLastName = gfunct_L5DI_GHfTID_1158.FirstOrDefault().ContactPersonLastName ,
		Street_Name = gfunct_L5DI_GHfTID_1158.FirstOrDefault().Street_Name ,
		Street_Number = gfunct_L5DI_GHfTID_1158.FirstOrDefault().Street_Number ,
		Town = gfunct_L5DI_GHfTID_1158.FirstOrDefault().Town ,
		HEC_MedicalPractiseID = gfunct_L5DI_GHfTID_1158.Key.HEC_MedicalPractiseID ,
		ServiceName = gfunct_L5DI_GHfTID_1158.FirstOrDefault().ServiceName ,
		OrganizationalUnit_Name = gfunct_L5DI_GHfTID_1158.FirstOrDefault().OrganizationalUnit_Name ,
		Default_PhoneNumber = gfunct_L5DI_GHfTID_1158.FirstOrDefault().Default_PhoneNumber ,

		MedicalPracticeTypes = 
		(
			from el_MedicalPracticeTypes in gfunct_L5DI_GHfTID_1158.Where(element => !EqualsDefaultValue(element.HEC_MedicalPractice_TypeID)).ToArray()
			group el_MedicalPracticeTypes by new 
			{ 
				el_MedicalPracticeTypes.HEC_MedicalPractice_TypeID,

			}
			into gfunct_MedicalPracticeTypes
			select new L5DI_GHfTID_1158_MedicalPracticeTypes
			{     
				HEC_MedicalPractice_TypeID = gfunct_MedicalPracticeTypes.Key.HEC_MedicalPractice_TypeID ,
				MedicalPracticeType_Name = gfunct_MedicalPracticeTypes.FirstOrDefault().MedicalPracticeType_Name ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5DI_GHfTID_1158_Array : FR_Base
	{
		public L5DI_GHfTID_1158[] Result	{ get; set; } 
		public FR_L5DI_GHfTID_1158_Array() : base() {}

		public FR_L5DI_GHfTID_1158_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DI_GHfTID_1158 for attribute P_L5DI_GHfTID_1158
		[DataContract]
		public class P_L5DI_GHfTID_1158 
		{
			//Standard type parameters
			[DataMember]
			public bool IsHospital { get; set; } 

		}
		#endregion
		#region SClass L5DI_GHfTID_1158 for attribute L5DI_GHfTID_1158
		[DataContract]
		public class L5DI_GHfTID_1158 
		{
			[DataMember]
			public L5DI_GHfTID_1158_MedicalPracticeTypes[] MedicalPracticeTypes { get; set; }

			//Standard type parameters
			[DataMember]
			public String ContactPersonTitle { get; set; } 
			[DataMember]
			public String ContactPersonFirstName { get; set; } 
			[DataMember]
			public String ContactPersonLastName { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public Dict ServiceName { get; set; } 
			[DataMember]
			public Dict OrganizationalUnit_Name { get; set; } 
			[DataMember]
			public String Default_PhoneNumber { get; set; } 

		}
		#endregion
		#region SClass L5DI_GHfTID_1158_MedicalPracticeTypes for attribute MedicalPracticeTypes
		[DataContract]
		public class L5DI_GHfTID_1158_MedicalPracticeTypes 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractice_TypeID { get; set; } 
			[DataMember]
			public Dict MedicalPracticeType_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DI_GHfTID_1158_Array cls_Get_Hospital_for_TenantID(,P_L5DI_GHfTID_1158 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DI_GHfTID_1158_Array invocationResult = cls_Get_Hospital_for_TenantID.Invoke(connectionString,P_L5DI_GHfTID_1158 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Diagnosis.Atomic.Retrieval.P_L5DI_GHfTID_1158();
parameter.IsHospital = ...;

*/
