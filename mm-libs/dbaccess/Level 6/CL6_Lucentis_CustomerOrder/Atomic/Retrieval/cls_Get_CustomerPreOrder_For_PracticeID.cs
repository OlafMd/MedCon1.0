/* 
 * Generated on 7/8/2013 3:18:27 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL6_Lucentis_CustomerOrder.Atomic.Retrieval
{
	[Serializable]
	public class cls_Get_CustomerPreOrder_For_PracticeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6CO_GCPOFPID_1432_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6CO_GCPOFPID_1432 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6CO_GCPOFPID_1432_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_Lucentis_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_CustomerPreOrder_For_PracticeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PharmacyID", Parameter.PharmacyID);


			List<L6CO_GCPOFPID_1432_raw> results = new List<L6CO_GCPOFPID_1432_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IfSheduled_Date","FirstName","LastName","PracticeName","HEC_Patient_TreatmentID","ArticlID","HEC_Patient_Treatment_RequiredProductID","Articles_Name_DictID","BoundTo_CustomerOrderPosition_RefID","HEC_DoctorID","DoctorFirstName","DoctorLastname","DoctorTitle" });
				while(reader.Read())
				{
					L6CO_GCPOFPID_1432_raw resultItem = new L6CO_GCPOFPID_1432_raw();
					//0:Parameter IfSheduled_Date of type DateTime
					resultItem.IfSheduled_Date = reader.GetDate(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(3);
					//4:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(4);
					//5:Parameter ArticlID of type Guid
					resultItem.ArticlID = reader.GetGuid(5);
					//6:Parameter HEC_Patient_Treatment_RequiredProductID of type Guid
					resultItem.HEC_Patient_Treatment_RequiredProductID = reader.GetGuid(6);
					//7:Parameter Articles_Name_DictID of type Dict
					resultItem.Articles_Name_DictID = reader.GetDictionary(7);
					resultItem.Articles_Name_DictID.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Articles_Name_DictID);
					//8:Parameter BoundTo_CustomerOrderPosition_RefID of type Guid
					resultItem.BoundTo_CustomerOrderPosition_RefID = reader.GetGuid(8);
					//9:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(9);
					//10:Parameter DoctorFirstName of type String
					resultItem.DoctorFirstName = reader.GetString(10);
					//11:Parameter DoctorLastname of type String
					resultItem.DoctorLastname = reader.GetString(11);
					//12:Parameter DoctorTitle of type String
					resultItem.DoctorTitle = reader.GetString(12);

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

			returnStatus.Result = L6CO_GCPOFPID_1432_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6CO_GCPOFPID_1432_Array Invoke(string ConnectionString,P_L6CO_GCPOFPID_1432 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6CO_GCPOFPID_1432_Array Invoke(DbConnection Connection,P_L6CO_GCPOFPID_1432 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6CO_GCPOFPID_1432_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6CO_GCPOFPID_1432 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6CO_GCPOFPID_1432_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6CO_GCPOFPID_1432 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6CO_GCPOFPID_1432_Array functionReturn = new FR_L6CO_GCPOFPID_1432_Array();
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
	public class L6CO_GCPOFPID_1432_raw 
	{
		public DateTime IfSheduled_Date; 
		public String FirstName; 
		public String LastName; 
		public String PracticeName; 
		public Guid HEC_Patient_TreatmentID; 
		public Guid ArticlID; 
		public Guid HEC_Patient_Treatment_RequiredProductID; 
		public Dict Articles_Name_DictID; 
		public Guid BoundTo_CustomerOrderPosition_RefID; 
		public Guid HEC_DoctorID; 
		public String DoctorFirstName; 
		public String DoctorLastname; 
		public String DoctorTitle; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6CO_GCPOFPID_1432[] Convert(List<L6CO_GCPOFPID_1432_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6CO_GCPOFPID_1432 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_TreatmentID)).ToArray()
	group el_L6CO_GCPOFPID_1432 by new 
	{ 
		el_L6CO_GCPOFPID_1432.HEC_Patient_TreatmentID,

	}
	into gfunct_L6CO_GCPOFPID_1432
	select new L6CO_GCPOFPID_1432
	{     
		IfSheduled_Date = gfunct_L6CO_GCPOFPID_1432.FirstOrDefault().IfSheduled_Date ,
		FirstName = gfunct_L6CO_GCPOFPID_1432.FirstOrDefault().FirstName ,
		LastName = gfunct_L6CO_GCPOFPID_1432.FirstOrDefault().LastName ,
		PracticeName = gfunct_L6CO_GCPOFPID_1432.FirstOrDefault().PracticeName ,
		HEC_Patient_TreatmentID = gfunct_L6CO_GCPOFPID_1432.Key.HEC_Patient_TreatmentID ,

		Articles = 
		(
			from el_Articles in gfunct_L6CO_GCPOFPID_1432.Where(element => !EqualsDefaultValue(element.ArticlID)).ToArray()
			group el_Articles by new 
			{ 
				el_Articles.ArticlID,

			}
			into gfunct_Articles
			select new L6CO_GCOFPID_1129_Articles
			{     
				ArticlID = gfunct_Articles.Key.ArticlID ,
				HEC_Patient_Treatment_RequiredProductID = gfunct_Articles.FirstOrDefault().HEC_Patient_Treatment_RequiredProductID ,
				Articles_Name_DictID = gfunct_Articles.FirstOrDefault().Articles_Name_DictID ,
				BoundTo_CustomerOrderPosition_RefID = gfunct_Articles.FirstOrDefault().BoundTo_CustomerOrderPosition_RefID ,

			}
		).ToArray(),
		DoctorPerformed = 
		(
			from el_DoctorPerformed in gfunct_L6CO_GCPOFPID_1432.ToArray()
			select new L6CO_GCOFPID_1129_Doctors
			{     
				HEC_DoctorID = el_DoctorPerformed.HEC_DoctorID,
				DoctorFirstName = el_DoctorPerformed.DoctorFirstName,
				DoctorLastname = el_DoctorPerformed.DoctorLastname,
				DoctorTitle = el_DoctorPerformed.DoctorTitle,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6CO_GCPOFPID_1432_Array : FR_Base
	{
		public L6CO_GCPOFPID_1432[] Result	{ get; set; } 
		public FR_L6CO_GCPOFPID_1432_Array() : base() {}

		public FR_L6CO_GCPOFPID_1432_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6CO_GCPOFPID_1432 for attribute P_L6CO_GCPOFPID_1432
		[Serializable]
		public class P_L6CO_GCPOFPID_1432 
		{
			//Standard type parameters
			public Guid PharmacyID; 

		}
		#endregion
		#region SClass L6CO_GCPOFPID_1432 for attribute L6CO_GCPOFPID_1432
		[Serializable]
		public class L6CO_GCPOFPID_1432 
		{
			public L6CO_GCOFPID_1129_Articles[] Articles;  
			public L6CO_GCOFPID_1129_Doctors DoctorPerformed;  

			//Standard type parameters
			public DateTime IfSheduled_Date; 
			public String FirstName; 
			public String LastName; 
			public String PracticeName; 
			public Guid HEC_Patient_TreatmentID; 

		}
		#endregion
		#region SClass L6CO_GCOFPID_1129_Articles for attribute Articles
		[Serializable]
		public class L6CO_GCOFPID_1129_Articles 
		{
			//Standard type parameters
			public Guid ArticlID; 
			public Guid HEC_Patient_Treatment_RequiredProductID; 
			public Dict Articles_Name_DictID; 
			public Guid BoundTo_CustomerOrderPosition_RefID; 

		}
		#endregion
		#region SClass L6CO_GCOFPID_1129_Doctors for attribute DoctorPerformed
		[Serializable]
		public class L6CO_GCOFPID_1129_Doctors 
		{
			//Standard type parameters
			public Guid HEC_DoctorID; 
			public String DoctorFirstName; 
			public String DoctorLastname; 
			public String DoctorTitle; 

		}
		#endregion

	#endregion
}
