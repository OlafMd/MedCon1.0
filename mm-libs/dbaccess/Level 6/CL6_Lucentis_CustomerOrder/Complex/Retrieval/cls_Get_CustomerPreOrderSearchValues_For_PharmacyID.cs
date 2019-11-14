/* 
 * Generated on 6/28/2013 11:01:05 AM
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
using CL6_Lucentis_CustomerOrder.Atomic.Retrieval;

namespace CLE_L6_CustomerOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerPreOrderSearchValues_For_PharmacyID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerPreOrderSearchValues_For_PharmacyID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6CO_GCPOSVfPID_0951 Execute(DbConnection Connection,DbTransaction Transaction,P_L6CO_GCPOSVfPID_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6CO_GCPOSVfPID_0951();
			
            P_L6CO_GCPOFPID_1432 param = new P_L6CO_GCPOFPID_1432();
            param.PharmacyID = Parameter.PharmacyID;
            List<L6CO_GCPOFPID_1432> AllPreOrders = cls_Get_CustomerPreOrder_For_PracticeID.Invoke(Connection, Transaction, param, securityTicket).Result.ToList();
            List<L6CO_GCPOFPID_1432> notContainedArticles = new List<L6CO_GCPOFPID_1432>();

            if (Parameter.Practice != String.Empty)
            {
                AllPreOrders = AllPreOrders.Where(i => i.PracticeName.ToLower().Contains(Parameter.Practice.ToLower())).ToList();             
            }

            if (Parameter.PatientFirstName != String.Empty)
            {
                foreach (var preorder in AllPreOrders)
                {
                    if (preorder.FirstName.ToLower().Contains(Parameter.PatientFirstName.ToLower()) == false)
                        notContainedArticles.Add(preorder);
                }

                foreach(var preorder in notContainedArticles )
                {
                    AllPreOrders.Remove(preorder);
                }
            }




            if (Parameter.PatientLastName != String.Empty)
            {
                foreach (var preorder in AllPreOrders)
                {
                    if (preorder.LastName.ToLower().Contains(Parameter.PatientLastName.ToLower()) == false)
                        notContainedArticles.Add(preorder);
                }

                foreach (var preorder in notContainedArticles)
                {
                    AllPreOrders.Remove(preorder);
                }
            }

            if (Parameter.DoctorFirstName != String.Empty)
            {
                foreach (var preorder in AllPreOrders)
                {
                    if (preorder.DoctorPerformed.DoctorFirstName.ToLower().Contains(Parameter.DoctorFirstName.ToLower()) == false)
                        notContainedArticles.Add(preorder);
                }

                foreach (var preorder in notContainedArticles)
                {
                    AllPreOrders.Remove(preorder);
                }
            }

            if (Parameter.DoctorLastName != String.Empty)
            {
                foreach (var preorder in AllPreOrders)
                {
                    if (preorder.DoctorPerformed.DoctorLastname.ToLower().Contains(Parameter.DoctorLastName.ToLower()) == false)
                        notContainedArticles.Add(preorder);
                }

                foreach (var preorder in notContainedArticles)
                {
                    AllPreOrders.Remove(preorder);
                }
            }

            if (Parameter.DateFrom != null)
            {
                AllPreOrders = AllPreOrders.Where(i => i.IfSheduled_Date > Parameter.DateFrom).ToList();
            }

            if (Parameter.DateTo != null)
            {
                AllPreOrders = AllPreOrders.Where(i => i.IfSheduled_Date < Parameter.DateTo).ToList();
            }

            if (Parameter.Article != String.Empty)
            {
                
                List<L6CO_GCOFPID_1129_Articles> articless = new List<L6CO_GCOFPID_1129_Articles>();

                foreach (var preorder in AllPreOrders)
                {
                    
                    foreach (var preorderArticle in preorder.Articles.ToList())
                    {
                        if (preorderArticle.Articles_Name_DictID.GetContent(Parameter.LanguageID).ToLower().Contains(Parameter.Article))
                            articless.Add(preorderArticle);                        
                    }
                    foreach (var artikl in articless)
                    {
                        preorder.Articles.ToList().Remove(artikl);
                    }
                }
            }

            returnValue.Result = new L6CO_GCPOSVfPID_0951();
            returnValue.Result.AllPreOrers = AllPreOrders.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6CO_GCPOSVfPID_0951 Invoke(string ConnectionString,P_L6CO_GCPOSVfPID_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6CO_GCPOSVfPID_0951 Invoke(DbConnection Connection,P_L6CO_GCPOSVfPID_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6CO_GCPOSVfPID_0951 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6CO_GCPOSVfPID_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6CO_GCPOSVfPID_0951 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6CO_GCPOSVfPID_0951 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6CO_GCPOSVfPID_0951 functionReturn = new FR_L6CO_GCPOSVfPID_0951();
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
	public class FR_L6CO_GCPOSVfPID_0951 : FR_Base
	{
		public L6CO_GCPOSVfPID_0951 Result	{ get; set; }

		public FR_L6CO_GCPOSVfPID_0951() : base() {}

		public FR_L6CO_GCPOSVfPID_0951(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6CO_GCPOSVfPID_0951 for attribute P_L6CO_GCPOSVfPID_0951
		[DataContract]
		public class P_L6CO_GCPOSVfPID_0951 
		{
			//Standard type parameters
			[DataMember]
			public Guid PharmacyID { get; set; } 
			[DataMember]
			public String PatientFirstName { get; set; } 
			[DataMember]
			public String PatientLastName { get; set; } 
			[DataMember]
			public String DoctorFirstName { get; set; } 
			[DataMember]
			public String DoctorLastName { get; set; } 
			[DataMember]
			public String Article { get; set; } 
			[DataMember]
			public String Practice { get; set; } 
			[DataMember]
			public DateTime? DateFrom { get; set; } 
			[DataMember]
			public DateTime? DateTo { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion
		#region SClass L6CO_GCPOSVfPID_0951 for attribute L6CO_GCPOSVfPID_0951
		[DataContract]
		public class L6CO_GCPOSVfPID_0951 
		{
			//Standard type parameters
			[DataMember]
			public L6CO_GCPOFPID_1432[] AllPreOrers { get; set; } 

		}
		#endregion

	#endregion
}
