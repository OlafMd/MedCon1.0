/* 
 * Generated on 10/30/2014 10:52:58 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL5_MyHealthClub_Diagnosis.Atomic.Manipulation;
using CL5_MyHealthClub_Diagnosis.Atomic.Retrieval;

namespace CL6_MyHealthClub_Diagnosis.Complex.Retrieval
{
	[Serializable]
	public class cls_Get_AllFavouritesDiagnosis_with_DiagnosisCount
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DI_GAFDwDC_1145 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DI_GAFDwDC_1145 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6DI_GAFDwDC_1145();
            returnValue.Result = new L6DI_GAFDwDC_1145();
            L5DI_GFD_1113 diagnosesList = new  L5DI_GFD_1113();
            returnValue.Result.Diagnoses = diagnosesList;
            returnValue.Result.CurrentPage = 1;
            returnValue.Result.NumberOfPages = 1;
            returnValue.Result.NumberOfElements = 0;

            P_L5DI_GFD_1113 par = new P_L5DI_GFD_1113();
            if (Parameter.IsASC_Order == false)
                par.OrderBy = "DESC";
            else
                par.OrderBy = "ASC";
            par.OrderValue = Parameter.OrderValue;
            par.StartIndex = (Parameter.PageClicked - 1) * Parameter.NumberOfElementsPerPage;
            par.NumberOfElements = Parameter.NumberOfElementsPerPage;

            String searchCriterium = "";

            if (Parameter.Search_Param != null && Parameter.Search_Param != "")
                searchCriterium = " AND LOWER( hec_dia_potentialdiagnoses.ICD10_Code ) LIKE '%" + Parameter.Search_Param.ToLower() + "%' OR " +
                    " Lower(hec_dia_potentialdiagnoses_de.Content) Like '%" + Parameter.Search_Param.ToLower() + "%'";

            par.SearchCriterium = searchCriterium;
            par.CatalogID = Parameter.CatalogID;
            par.LanguageID = Parameter.LanguageID;

            returnValue.Result.Diagnoses = cls_Get_Favourite_Diagnoses.Invoke(Connection, Transaction, par, securityTicket).Result;

            /*@
            * 
            * Get diagnosis number
            * ************************************/
            P_L5DI_GCoFD_1632 parameter = new P_L5DI_GCoFD_1632();
            parameter.SearchCriterium = searchCriterium;
            parameter.CatalogID = Parameter.CatalogID;
            parameter.LanguageID = Parameter.LanguageID;

            var value = cls_Get_Count_Of_FavouriteDiagnoses.Invoke(Connection, Transaction, parameter, securityTicket).Result.FirstOrDefault();
            int numberOfElements = 0;
            if (value != null)
            {
                numberOfElements = value.NumberOfElements;
                returnValue.Result.NumberOfElements = value.NumberOfElements;
            }
            else
            {
                returnValue.Result.NumberOfElements = 0;
            }
            int pageCount = (numberOfElements + Parameter.NumberOfElementsPerPage - 1) / Parameter.NumberOfElementsPerPage;
            returnValue.Result.NumberOfPages = pageCount;
            returnValue.Result.CurrentPage = Parameter.PageClicked;


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DI_GAFDwDC_1145 Invoke(string ConnectionString,P_L6DI_GAFDwDC_1145 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DI_GAFDwDC_1145 Invoke(DbConnection Connection,P_L6DI_GAFDwDC_1145 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DI_GAFDwDC_1145 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DI_GAFDwDC_1145 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DI_GAFDwDC_1145 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DI_GAFDwDC_1145 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DI_GAFDwDC_1145 functionReturn = new FR_L6DI_GAFDwDC_1145();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L6DI_GAFDwDC_1145 : FR_Base
	{
		public L6DI_GAFDwDC_1145 Result	{ get; set; }

		public FR_L6DI_GAFDwDC_1145() : base() {}

		public FR_L6DI_GAFDwDC_1145(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DI_GAFDwDC_1145 for attribute P_L6DI_GAFDwDC_1145
		[Serializable]
		public class P_L6DI_GAFDwDC_1145 
		{
			//Standard type parameters
			public bool IsASC_Order; 
			public String OrderValue; 
			public int PageClicked; 
			public int NumberOfElementsPerPage; 
			public String Search_Param; 
			public Guid LanguageID; 
			public Guid CatalogID; 

		}
		#endregion
		#region SClass L6DI_GAFDwDC_1145 for attribute L6DI_GAFDwDC_1145
		[Serializable]
		public class L6DI_GAFDwDC_1145 
		{
			//Standard type parameters
			public L5DI_GFD_1113 Diagnoses; 
			public int NumberOfPages; 
			public int CurrentPage; 
			public int NumberOfElements; 

		}
		#endregion

	#endregion
}
