/* 
 * Generated on 12/13/2013 2:45:08 PM
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

namespace CL5_Lucentis_Practice.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllPractices_and_Pharmacies_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllPractices_and_Pharmacies_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MP_GAPaPfT_1758_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5MP_GAPaPfT_1758_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Practice.Atomic.Retrieval.SQL.cls_Get_AllPractices_and_Pharmacies_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5MP_GAPaPfT_1758_raw> results = new List<L5MP_GAPaPfT_1758_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PracticeID","PracticeName","CMN_BPT_BusinessParticipantID","My_HEC_DoctorID","PharmacyID","PharmacyName","IsDefaultPharmacy","Doctors_CMN_BPT_BusinessParticipantID","HEC_DoctorID","FirstName","LastName","Title","Account_RefID","CooperatinbussinessParticnID","CooperatingPracticeName" });
				while(reader.Read())
				{
					L5MP_GAPaPfT_1758_raw resultItem = new L5MP_GAPaPfT_1758_raw();
					//0:Parameter PracticeID of type Guid
					resultItem.PracticeID = reader.GetGuid(0);
					//1:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(1);
					//2:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(2);
					//3:Parameter My_HEC_DoctorID of type Guid
					resultItem.My_HEC_DoctorID = reader.GetGuid(3);
					//4:Parameter PharmacyID of type Guid
					resultItem.PharmacyID = reader.GetGuid(4);
					//5:Parameter PharmacyName of type String
					resultItem.PharmacyName = reader.GetString(5);
					//6:Parameter IsDefaultPharmacy of type bool
					resultItem.IsDefaultPharmacy = reader.GetBoolean(6);
					//7:Parameter Doctors_CMN_BPT_BusinessParticipantID of type Guid
					resultItem.Doctors_CMN_BPT_BusinessParticipantID = reader.GetGuid(7);
					//8:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(8);
					//9:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(9);
					//10:Parameter LastName of type String
					resultItem.LastName = reader.GetString(10);
					//11:Parameter Title of type String
					resultItem.Title = reader.GetString(11);
					//12:Parameter Account_RefID of type Guid
					resultItem.Account_RefID = reader.GetGuid(12);
					//13:Parameter CooperatinbussinessParticnID of type Guid
					resultItem.CooperatinbussinessParticnID = reader.GetGuid(13);
					//14:Parameter CooperatingPracticeName of type String
					resultItem.CooperatingPracticeName = reader.GetString(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllPractices_and_Pharmacies_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5MP_GAPaPfT_1758_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5MP_GAPaPfT_1758_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MP_GAPaPfT_1758_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MP_GAPaPfT_1758_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MP_GAPaPfT_1758_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MP_GAPaPfT_1758_Array functionReturn = new FR_L5MP_GAPaPfT_1758_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllPractices_and_Pharmacies_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5MP_GAPaPfT_1758_raw 
	{
		public Guid PracticeID; 
		public String PracticeName; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public Guid My_HEC_DoctorID; 
		public Guid PharmacyID; 
		public String PharmacyName; 
		public bool IsDefaultPharmacy; 
		public Guid Doctors_CMN_BPT_BusinessParticipantID; 
		public Guid HEC_DoctorID; 
		public String FirstName; 
		public String LastName; 
		public String Title; 
		public Guid Account_RefID; 
		public Guid CooperatinbussinessParticnID; 
		public String CooperatingPracticeName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5MP_GAPaPfT_1758[] Convert(List<L5MP_GAPaPfT_1758_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5MP_GAPaPfT_1758 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.PracticeID)).ToArray()
	group el_L5MP_GAPaPfT_1758 by new 
	{ 
		el_L5MP_GAPaPfT_1758.PracticeID,

	}
	into gfunct_L5MP_GAPaPfT_1758
	select new L5MP_GAPaPfT_1758
	{     
		PracticeID = gfunct_L5MP_GAPaPfT_1758.Key.PracticeID ,
		PracticeName = gfunct_L5MP_GAPaPfT_1758.FirstOrDefault().PracticeName ,
		CMN_BPT_BusinessParticipantID = gfunct_L5MP_GAPaPfT_1758.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
		My_HEC_DoctorID = gfunct_L5MP_GAPaPfT_1758.FirstOrDefault().My_HEC_DoctorID ,

		Pharmacies = 
		(
			from el_Pharmacies in gfunct_L5MP_GAPaPfT_1758.Where(element => !EqualsDefaultValue(element.PharmacyID)).ToArray()
			group el_Pharmacies by new 
			{ 
				el_Pharmacies.PharmacyID,

			}
			into gfunct_Pharmacies
			select new L5MP_GAPaPfT_1758a
			{     
				PharmacyID = gfunct_Pharmacies.Key.PharmacyID ,
				PharmacyName = gfunct_Pharmacies.FirstOrDefault().PharmacyName ,
				IsDefaultPharmacy = gfunct_Pharmacies.FirstOrDefault().IsDefaultPharmacy ,

			}
		).ToArray(),
		Doctors = 
		(
			from el_Doctors in gfunct_L5MP_GAPaPfT_1758.Where(element => !EqualsDefaultValue(element.HEC_DoctorID)).ToArray()
			group el_Doctors by new 
			{ 
				el_Doctors.HEC_DoctorID,

			}
			into gfunct_Doctors
			select new L5MP_GAPaPfT_1758b
			{     
				Doctors_CMN_BPT_BusinessParticipantID = gfunct_Doctors.FirstOrDefault().Doctors_CMN_BPT_BusinessParticipantID ,
				HEC_DoctorID = gfunct_Doctors.Key.HEC_DoctorID ,
				FirstName = gfunct_Doctors.FirstOrDefault().FirstName ,
				LastName = gfunct_Doctors.FirstOrDefault().LastName ,
				Title = gfunct_Doctors.FirstOrDefault().Title ,
				Account_RefID = gfunct_Doctors.FirstOrDefault().Account_RefID ,

			}
		).ToArray(),
		CooperatingPracitces = 
		(
			from el_CooperatingPracitces in gfunct_L5MP_GAPaPfT_1758.Where(element => !EqualsDefaultValue(element.CooperatinbussinessParticnID)).ToArray()
			group el_CooperatingPracitces by new 
			{ 
				el_CooperatingPracitces.CooperatinbussinessParticnID,

			}
			into gfunct_CooperatingPracitces
			select new L5MP_GAPaPfT_1758c
			{     
				CooperatinbussinessParticnID = gfunct_CooperatingPracitces.Key.CooperatinbussinessParticnID ,
				CooperatingPracticeName = gfunct_CooperatingPracitces.FirstOrDefault().CooperatingPracticeName ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5MP_GAPaPfT_1758_Array : FR_Base
	{
		public L5MP_GAPaPfT_1758[] Result	{ get; set; } 
		public FR_L5MP_GAPaPfT_1758_Array() : base() {}

		public FR_L5MP_GAPaPfT_1758_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5MP_GAPaPfT_1758 for attribute L5MP_GAPaPfT_1758
		[DataContract]
		public class L5MP_GAPaPfT_1758 
		{
			[DataMember]
			public L5MP_GAPaPfT_1758a[] Pharmacies { get; set; }
			[DataMember]
			public L5MP_GAPaPfT_1758b[] Doctors { get; set; }
			[DataMember]
			public L5MP_GAPaPfT_1758c[] CooperatingPracitces { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid My_HEC_DoctorID { get; set; } 

		}
		#endregion
		#region SClass L5MP_GAPaPfT_1758a for attribute Pharmacies
		[DataContract]
		public class L5MP_GAPaPfT_1758a 
		{
			//Standard type parameters
			[DataMember]
			public Guid PharmacyID { get; set; } 
			[DataMember]
			public String PharmacyName { get; set; } 
			[DataMember]
			public bool IsDefaultPharmacy { get; set; } 

		}
		#endregion
		#region SClass L5MP_GAPaPfT_1758b for attribute Doctors
		[DataContract]
		public class L5MP_GAPaPfT_1758b 
		{
			//Standard type parameters
			[DataMember]
			public Guid Doctors_CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public Guid Account_RefID { get; set; } 

		}
		#endregion
		#region SClass L5MP_GAPaPfT_1758c for attribute CooperatingPracitces
		[DataContract]
		public class L5MP_GAPaPfT_1758c 
		{
			//Standard type parameters
			[DataMember]
			public Guid CooperatinbussinessParticnID { get; set; } 
			[DataMember]
			public String CooperatingPracticeName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5MP_GAPaPfT_1758_Array cls_Get_AllPractices_and_Pharmacies_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MP_GAPaPfT_1758_Array invocationResult = cls_Get_AllPractices_and_Pharmacies_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

