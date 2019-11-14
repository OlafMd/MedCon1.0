/* 
 * Generated on 7/8/2013 11:17:31 AM
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
using CL5_Lucentis_Treatments.Complex.Retrieval;

namespace CL6_Lucenits_Treatments.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Treatments_for_Search.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Treatments_for_Search
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6TR_GTfS_1624 Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_GTfS_1624 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6TR_GTfS_1624();


            List<L5TR_GaTfT_1211> AllTreatments = cls_Get_all_Treatment_for_TennantID.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            List<L5TR_GaTfT_1211> FilteredTreatments = new List<L5TR_GaTfT_1211>();

            if (!Parameter.isBilled || !Parameter.isSheduled || !Parameter.isPerformed)
            {
                AllTreatments = AllTreatments.Where(x => (Parameter.isBilled == true && x.IsTreatmentBilled == Parameter.isBilled) ||
                    (Parameter.isPerformed == true && x.IsTreatmentPerformed == Parameter.isPerformed && x.IsTreatmentBilled == false) ||
                    (Parameter.isSheduled == true && x.IsScheduled == Parameter.isSheduled && x.IsTreatmentPerformed == false)).ToList();
            }


            if (Parameter.PracticeName != "")
            {
                foreach (var item in AllTreatments)
                {
                    if (Core_ClassLibrarySupport.Utils.StringExtensions.ContainsIgnoreCase(item.DisplayName, Parameter.PracticeName) == true)
                    {
                        FilteredTreatments.Add(item);
                    }
                }

                AllTreatments = FilteredTreatments;
                FilteredTreatments = new List<L5TR_GaTfT_1211>();
            }
            if (Parameter.FirstName != "")
            {

                foreach (var item in AllTreatments)
                {
                    if (Core_ClassLibrarySupport.Utils.StringExtensions.ContainsIgnoreCase(item.FirstName, Parameter.FirstName) == true)
                    {
                        FilteredTreatments.Add(item);
                    }
                }

                AllTreatments = FilteredTreatments;
                FilteredTreatments = new List<L5TR_GaTfT_1211>();
            }

            if (Parameter.LastName != "")
            {

                foreach (var item in AllTreatments)
                {
                    if (Core_ClassLibrarySupport.Utils.StringExtensions.ContainsIgnoreCase(item.LastName, Parameter.LastName) == true)
                    {
                        FilteredTreatments.Add(item);
                    }
                }

                AllTreatments = FilteredTreatments;
                FilteredTreatments = new List<L5TR_GaTfT_1211>();
            }


            if (Parameter.InsuranceName != "")
            {

                foreach (var item in AllTreatments)
                {
                    if (Core_ClassLibrarySupport.Utils.StringExtensions.ContainsIgnoreCase(item.CompanyName, Parameter.InsuranceName) == true)
                    {
                        FilteredTreatments.Add(item);
                    }
                }

            }

                if (Parameter.TreatmentFrom != null)
                {


                    foreach (var item in AllTreatments)
                    {

                       

                        if (item.IsTreatmentBilled == true)
                        {
                            if (item.IfTreatmentBilled_Date > Parameter.TreatmentFrom)
                            {
                                FilteredTreatments.Add(item);
                            }
                        }

                        else  if (item.IsTreatmentPerformed == true)
                        {
                            if (item.IfTreatmentPerformed_Date > Parameter.TreatmentFrom)
                            {
                                FilteredTreatments.Add(item);
                            }
                        }

                        else if (item.IsScheduled == true)
                        {
                            if (item.IfSheduled_Date > Parameter.TreatmentFrom)
                            {
                                FilteredTreatments.Add(item);
                            }
                        }

                    }

                    AllTreatments = FilteredTreatments;
                    FilteredTreatments = new List<L5TR_GaTfT_1211>();
                }


                if (Parameter.TreatmentTo != null)
                {


                    foreach (var item in AllTreatments)
                    {

                      

                        if (item.IsTreatmentBilled == true)
                        {
                            if (item.IfTreatmentBilled_Date < Parameter.TreatmentTo)
                            {
                                FilteredTreatments.Add(item);
                            }
                        }

                        else if (item.IsTreatmentPerformed == true)
                        {
                            if (item.IfTreatmentPerformed_Date < Parameter.TreatmentTo)
                            {
                                FilteredTreatments.Add(item);
                            }
                        }

                        else if (item.IsScheduled == true)
                        {
                            if (item.IfSheduled_Date < Parameter.TreatmentTo)
                            {
                                FilteredTreatments.Add(item);
                            }
                        }

                    }

                    AllTreatments = FilteredTreatments;
                    FilteredTreatments = new List<L5TR_GaTfT_1211>();
                }


         

            returnValue.Result = new L6TR_GTfS_1624();
            returnValue.Result.AllTreatments = AllTreatments.ToArray();
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6TR_GTfS_1624 Invoke(string ConnectionString,P_L6TR_GTfS_1624 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TR_GTfS_1624 Invoke(DbConnection Connection,P_L6TR_GTfS_1624 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TR_GTfS_1624 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_GTfS_1624 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TR_GTfS_1624 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_GTfS_1624 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TR_GTfS_1624 functionReturn = new FR_L6TR_GTfS_1624();
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
	public class FR_L6TR_GTfS_1624 : FR_Base
	{
		public L6TR_GTfS_1624 Result	{ get; set; }

		public FR_L6TR_GTfS_1624() : base() {}

		public FR_L6TR_GTfS_1624(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6TR_GTfS_1624 for attribute P_L6TR_GTfS_1624
		[DataContract]
		public class P_L6TR_GTfS_1624 
		{
			//Standard type parameters
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String InsuranceName { get; set; } 
			[DataMember]
			public bool isSheduled { get; set; } 
			[DataMember]
			public bool isPerformed { get; set; } 
			[DataMember]
			public bool isBilled { get; set; } 
			[DataMember]
			public DateTime? TreatmentFrom { get; set; } 
			[DataMember]
			public DateTime? TreatmentTo { get; set; } 

		}
		#endregion
		#region SClass L6TR_GTfS_1624 for attribute L6TR_GTfS_1624
		[DataContract]
		public class L6TR_GTfS_1624 
		{
			//Standard type parameters
			[DataMember]
			public L5TR_GaTfT_1211[] AllTreatments { get; set; } 

		}
		#endregion

	#endregion
}
