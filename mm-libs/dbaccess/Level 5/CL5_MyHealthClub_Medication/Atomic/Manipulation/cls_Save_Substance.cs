/* 
 * Generated on 2/17/2015 13:22:04
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
using CL2_Language.Atomic.Retrieval;
using System.Web;
using CL1_HEC_SUB;

namespace CL5_MyHealthClub_Medication.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Substance.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Substance
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_SS_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            returnValue.Result = Guid.Empty;
            P_L2LN_GALFTID_1530 langParam = new P_L2LN_GALFTID_1530();
            langParam.Tenant_RefID = securityTicket.TenantID;
            var DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, langParam, securityTicket).Result;
            //var serializer = new JsonNetSerializer();
            //var connection = new ElasticConnection((String)HttpContext.GetGlobalResourceObject("Global", "ElasticConnection"), 9200);

            #region Save
            if (Parameter.Substance_ID == Guid.Empty)
            {
                ORM_HEC_SUB_Substance newSubstance = new ORM_HEC_SUB_Substance();
                newSubstance.HEC_SUB_SubstanceID = Guid.NewGuid();
                newSubstance.GlobalPropertyMatchingID = Parameter.Substance_Name;
                newSubstance.Tenant_RefID  =securityTicket.TenantID;
                newSubstance.Save(Connection,Transaction);

                ORM_HEC_SUB_Substance_Name newSubstanceName= new ORM_HEC_SUB_Substance_Name();
                newSubstanceName.HEC_SUB_Substance_NameID = Guid.NewGuid();
                newSubstanceName.HEC_SUB_Substance_RefID = newSubstance.HEC_SUB_SubstanceID;
                Dict name = new Dict("hec_sub_substance_name");
                for (int i = 0; i < DBLanguages.Length; i++)
                {
                    name.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.Substance_Name);
                }
                Dict nameOrigin = new Dict("hec_sub_substance_name");
                for (int i = 0; i < DBLanguages.Length; i++)
                {
                    nameOrigin.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.Substance_Name);
                }
                newSubstanceName.SubstanceName_Label = name;
                newSubstanceName.SubstanceName_Origin = nameOrigin;
                newSubstanceName.Tenant_RefID = securityTicket.TenantID;
                newSubstanceName.Save(Connection,Transaction);
                //#region Upload To Elastic
                //bool indexExists = true;

                //#region set Mapping
                //string jsonMapping = new MapBuilder<Models.Substance>()
                //                        .RootObject("substance", ro => ro
                //                        .Properties(pr => pr
                //                            .MultiField("name", mfp => mfp.Fields(f => f
                //                                .String("name", sp => sp.IndexAnalyzer("autocomplete").SearchAnalyzer(DefaultAnalyzers.standard))
                //                                .String("lower_case_sort", sp => sp.Analyzer("caseinsensitive"))
                //                                )
                //                            )
                //                            )).BuildBeautified();
                //#endregion

                //try
                //{
                //    connection.Head(new IndexExistsCommand(securityTicket.TenantID.ToString()));
                //}
                //catch (OperationException ex)
                //{
                //    if (ex.HttpStatusCode == 404)
                //        indexExists = false;
                //}

                //if (!indexExists)
                //{
                //    #region set index settings
                //    string settings = new IndexSettingsBuilder()
                //                          .Analysis(anl => anl
                //                              .Filter(fil => fil
                //                                  .EdgeNGram("autocomplete_filter", gr => gr.MinGram(1).MaxGram(20)))
                //                              .Analyzer(a => a
                //                                  .Custom("caseinsensitive", custom => custom
                //                                      .Tokenizer(DefaultTokenizers.keyword)
                //                                      .Filter("lowercase")
                //                                  )
                //                                  .Custom("autocomplete", custom => custom
                //                                      .Tokenizer(DefaultTokenizers.standard)
                //                                      .Filter("lowercase", "autocomplete_filter")
                //                                  )
                //                              )
                //                          )
                //                          .BuildBeautified();
                //    #endregion
                //    connection.Put(securityTicket.TenantID.ToString(), settings);
                //}

                //#region check if type exists

                //bool typeExists = true;

                //try
                //{
                //    connection.Head(new IndexExistsCommand(securityTicket.TenantID.ToString() + "/substance"));
                //}
                //catch (OperationException ex)
                //{
                //    if (ex.HttpStatusCode == 404)
                //        typeExists = false;
                //}
                //#endregion


                //if (!typeExists)
                //    connection.Put(new PutMappingCommand(securityTicket.TenantID.ToString(), "substance"), jsonMapping);

                //string bulkCommand = new BulkCommand(index: securityTicket.TenantID.ToString(), type: "substance").Refresh();

                //List<Models.Substance> substanceList = new List<Models.Substance>();
                //Models.Substance substance = new Models.Substance();
                //substance.id = newSubstance.HEC_SUB_SubstanceID.ToString();
                //substance.name = Parameter.Substance_Name;
                
                //substanceList.Add(substance);

                //string bulkJson = new BulkBuilder(serializer)
                //        .BuildCollection(substanceList, (builder, pro) => builder.Index(data: pro, id: pro.id)
                //        );
                //connection.Post(bulkCommand, bulkJson);

                //#endregion
                returnValue.Result = newSubstance.HEC_SUB_SubstanceID;
            }
            #endregion
            else
            {
                var substanceQuery = new ORM_HEC_SUB_Substance.Query();
                substanceQuery.IsDeleted = false;
                substanceQuery.HEC_SUB_SubstanceID = Parameter.Substance_ID;

                var substance = ORM_HEC_SUB_Substance.Query.Search(Connection, Transaction, substanceQuery).Single();

                var substanceNameQuery = new ORM_HEC_SUB_Substance_Name.Query();
                substanceNameQuery.IsDeleted = false;
                substanceNameQuery.HEC_SUB_Substance_RefID = Parameter.Substance_ID;

                var substanceName = ORM_HEC_SUB_Substance_Name.Query.Search(Connection, Transaction, substanceNameQuery).Single();
                #region Delete
                if (Parameter.IsDeleted)
                {
                    substance.IsDeleted = true;
                    substance.Save(Connection, Transaction);

                    substanceName.IsDeleted = true;
                    substanceName.Save(Connection,Transaction);

                    //// delete on Elastic
                    //connection.Delete(securityTicket.TenantID.ToString() + "/substance/" + Parameter.Substance_ID.ToString());
                }
                #endregion
                #region Edit
                else
                {
                    Dict name = new Dict("hec_sub_substance_name");
                    for (int i = 0; i < DBLanguages.Length; i++)
                    {
                        name.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.Substance_Name);
                    }
                    Dict nameOrigin = new Dict("hec_sub_substance_name");
                    for (int i = 0; i < DBLanguages.Length; i++)
                    {
                        nameOrigin.AddEntry(DBLanguages[i].CMN_LanguageID, Parameter.Substance_Name);
                    }

                    substanceName.SubstanceName_Label = name;
                    substanceName.SubstanceName_Origin = nameOrigin;
                    substanceName.Save(Connection, Transaction);

                    //string command = Commands.Index(index: securityTicket.TenantID.ToString(), type: "substance", id: Parameter.Substance_ID.ToString()).Refresh();

                    //Models.Substance substanceEdit = new Models.Substance();
                    //substanceEdit.id = Parameter.Substance_ID.ToString();
                    //substanceEdit.name = Parameter.Substance_Name;

                    //string jsonData = serializer.ToJson(substanceEdit);
                    //string response = connection.Put(command, jsonData);

                }
                returnValue.Result = substance.HEC_SUB_SubstanceID;
                #endregion
            }


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5ME_SS_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5ME_SS_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_SS_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_SS_1120 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_Substance",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5ME_SS_1120 for attribute P_L5ME_SS_1120
		[DataContract]
		public class P_L5ME_SS_1120 
		{
			//Standard type parameters
			[DataMember]
			public String Substance_Name { get; set; } 
			[DataMember]
			public Guid Substance_ID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Substance(,P_L5ME_SS_1120 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Substance.Invoke(connectionString,P_L5ME_SS_1120 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Medication.Atomic.Manipulation.P_L5ME_SS_1120();
parameter.Substance_Name = ...;
parameter.Substance_ID = ...;
parameter.IsDeleted = ...;

*/
