/* 
 * Generated on 29.1.2015 10:27:48
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

namespace CL3_EconomicRegion.Atomic.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_EconomicRegion_with_Country_Assignments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_EconomicRegion_with_Country_Assignments
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L2ER_GERwCA_1017_Array Execute(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            var returnStatus = new FR_L2ER_GERwCA_1017_Array();

            DbCommand command = Connection.CreateCommand();
            command.Connection = Connection;
            command.Transaction = Transaction;
            var commandLocation = "CL3_EconomicRegion.Atomic.Retrieval.SQL.cls_Get_EconomicRegion_with_Country_Assignments.sql";
            command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
            CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ticket", securityTicket);
            command.CommandTimeout = QueryTimeout;

            List<L2ER_GERwCA_1017_raw> results = new List<L2ER_GERwCA_1017_raw>();
            var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection, Transaction);
            var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
            try
            {
                reader.SetOrdinals(new string[] { "CMN_EconomicRegionID", "ParentEconomicRegion_RefID", "EconomicRegion_Name_DictID", "EconomicRegion_Description_DictID", "IsEconomicRegionCountry", "AssignmentID", "CMN_CountryID", "Country_Name_DictID", "Country_ISOCode_Alpha2", "IsActive", "IsDefault" });
                while (reader.Read())
                {
                    L2ER_GERwCA_1017_raw resultItem = new L2ER_GERwCA_1017_raw();
                    //0:Parameter CMN_EconomicRegionID of type Guid
                    resultItem.CMN_EconomicRegionID = reader.GetGuid(0);
                    //1:Parameter ParentEconomicRegion_RefID of type Guid
                    resultItem.ParentEconomicRegion_RefID = reader.GetGuid(1);
                    //2:Parameter EconomicRegion_Name of type Dict
                    resultItem.EconomicRegion_Name = reader.GetDictionary(2);
                    resultItem.EconomicRegion_Name.SourceTable = "cmn_economicregion";
                    loader.Append(resultItem.EconomicRegion_Name);
                    //3:Parameter EconomicRegion_Description of type Dict
                    resultItem.EconomicRegion_Description = reader.GetDictionary(3);
                    resultItem.EconomicRegion_Description.SourceTable = "cmn_economicregion";
                    loader.Append(resultItem.EconomicRegion_Description);
                    //4:Parameter IsEconomicRegionCountry of type bool
                    resultItem.IsEconomicRegionCountry = reader.GetBoolean(4);
                    //5:Parameter AssignmentID of type Guid
                    resultItem.AssignmentID = reader.GetGuid(5);
                    //6:Parameter CMN_CountryID of type Guid
                    resultItem.CMN_CountryID = reader.GetGuid(6);
                    //7:Parameter Country_Name of type Dict
                    resultItem.Country_Name = reader.GetDictionary(7);
                    resultItem.Country_Name.SourceTable = "cmn_countries";
                    loader.Append(resultItem.Country_Name);
                    //8:Parameter Country_ISOCode_Alpha2 of type string
                    resultItem.Country_ISOCode_Alpha2 = reader.GetString(8);
                    //9:Parameter IsActive of type bool
                    resultItem.IsActive = reader.GetBoolean(9);
                    //10:Parameter IsDefault of type bool
                    resultItem.IsDefault = reader.GetBoolean(10);

                    results.Add(resultItem);
                }


            }
            catch (Exception ex)
            {
                reader.Close();
                throw new Exception("Exception occured durng data retrieval in method cls_Get_EconomicRegion_with_Country_Assignments", ex);
            }
            reader.Close();
            //Load all the dictionaries from the datatables
            loader.Load();

            returnStatus.Result = L2ER_GERwCA_1017_raw.Convert(results).ToArray();
            return returnStatus;
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L2ER_GERwCA_1017_Array Invoke(string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L2ER_GERwCA_1017_Array Invoke(DbConnection Connection, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L2ER_GERwCA_1017_Array Invoke(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L2ER_GERwCA_1017_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L2ER_GERwCA_1017_Array functionReturn = new FR_L2ER_GERwCA_1017_Array();
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

                functionReturn = Execute(Connection, Transaction, securityTicket);

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
                    if (cleanupTransaction == true && Transaction != null)
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

                throw new Exception("Exception occured in method cls_Get_EconomicRegion_with_Country_Assignments", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Raw Grouping Class
    [Serializable]
    public class L2ER_GERwCA_1017_raw
    {
        public Guid CMN_EconomicRegionID;
        public Guid ParentEconomicRegion_RefID;
        public Dict EconomicRegion_Name;
        public Dict EconomicRegion_Description;
        public bool IsEconomicRegionCountry;
        public Guid AssignmentID;
        public Guid CMN_CountryID;
        public Dict Country_Name;
        public string Country_ISOCode_Alpha2;
        public bool IsActive;
        public bool IsDefault;


        private static bool EqualsDefaultValue<T>(T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default(T));
        }

        public static L2ER_GERwCA_1017[] Convert(List<L2ER_GERwCA_1017_raw> rawResult)
        {
            var gfunct_rawResult = rawResult;
            var groupResult = from el_L2ER_GERwCA_1017 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_EconomicRegionID)).ToArray()
                              group el_L2ER_GERwCA_1017 by new
                              {
                                  el_L2ER_GERwCA_1017.CMN_EconomicRegionID,

                              }
                                  into gfunct_L2ER_GERwCA_1017
                                  select new L2ER_GERwCA_1017
                                  {
                                      CMN_EconomicRegionID = gfunct_L2ER_GERwCA_1017.Key.CMN_EconomicRegionID,
                                      ParentEconomicRegion_RefID = gfunct_L2ER_GERwCA_1017.FirstOrDefault().ParentEconomicRegion_RefID,
                                      EconomicRegion_Name = gfunct_L2ER_GERwCA_1017.FirstOrDefault().EconomicRegion_Name,
                                      EconomicRegion_Description = gfunct_L2ER_GERwCA_1017.FirstOrDefault().EconomicRegion_Description,
                                      IsEconomicRegionCountry = gfunct_L2ER_GERwCA_1017.FirstOrDefault().IsEconomicRegionCountry,

                                      CountryAssignments =
                                      (
                                          from el_CountryAssignments in gfunct_L2ER_GERwCA_1017.ToArray()
                                          select new L2ER_GERwCA_1017a
                                          {
                                              AssignmentID = el_CountryAssignments.AssignmentID,
                                              CMN_CountryID = el_CountryAssignments.CMN_CountryID,
                                              Country_Name = el_CountryAssignments.Country_Name,
                                              Country_ISOCode_Alpha2 = el_CountryAssignments.Country_ISOCode_Alpha2,
                                              IsActive = el_CountryAssignments.IsActive,
                                              IsDefault = el_CountryAssignments.IsDefault,

                                          }
                                      ).ToArray(),

                                  };

            return groupResult.ToArray();
        }
    }
    #endregion

    #region Custom Return Type
    [Serializable]
    public class FR_L2ER_GERwCA_1017_Array : FR_Base
    {
        public L2ER_GERwCA_1017[] Result { get; set; }
        public FR_L2ER_GERwCA_1017_Array() : base() { }

        public FR_L2ER_GERwCA_1017_Array(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass L2ER_GERwCA_1017 for attribute L2ER_GERwCA_1017
    [DataContract]
    public class L2ER_GERwCA_1017
    {
        [DataMember]
        public L2ER_GERwCA_1017a[] CountryAssignments { get; set; }

        //Standard type parameters
        [DataMember]
        public Guid CMN_EconomicRegionID { get; set; }
        [DataMember]
        public Guid ParentEconomicRegion_RefID { get; set; }
        [DataMember]
        public Dict EconomicRegion_Name { get; set; }
        [DataMember]
        public Dict EconomicRegion_Description { get; set; }
        [DataMember]
        public bool IsEconomicRegionCountry { get; set; }

    }
    #endregion
    #region SClass L2ER_GERwCA_1017a for attribute CountryAssignments
    [DataContract]
    public class L2ER_GERwCA_1017a
    {
        //Standard type parameters
        [DataMember]
        public Guid AssignmentID { get; set; }
        [DataMember]
        public Guid CMN_CountryID { get; set; }
        [DataMember]
        public Dict Country_Name { get; set; }
        [DataMember]
        public string Country_ISOCode_Alpha2 { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public bool IsDefault { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2ER_GERwCA_1017_Array cls_Get_EconomicRegion_with_Country_Assignments(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2ER_GERwCA_1017_Array invocationResult = cls_Get_EconomicRegion_with_Country_Assignments.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

