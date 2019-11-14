/* 
 * Generated on 8/1/2013 3:58:01 PM
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

namespace CL5_KPRS_DueDiligences.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_HVACRSubmisionInfo_For_RevisionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_HVACRSubmisionInfo_For_RevisionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DD_GHSIfRID_1448_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DD_GHSIfRID_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DD_GHSIfRID_1448_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_DueDiligences.Atomic.Retrieval.SQL.cls_Get_HVACRSubmisionInfo_For_RevisionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RevisionID", Parameter.RevisionID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BuildingPartID", Parameter.BuildingPartID);

			if(Parameter.BuildingPartID_IsSpecified == false) 
			{
				var regex = new System.Text.RegularExpressions.Regex(@"((and|or)\s*)?(\w*\.)?\w*\s*(=|like|<|>)\s*@BuildingPartID",System.Text.RegularExpressions.RegexOptions.IgnoreCase);
				command.CommandText = regex.Replace(command.CommandText,"");
			} 


			List<L5DD_GHSIfRID_1448_raw> results = new List<L5DD_GHSIfRID_1448_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RES_STR_HVACRID","RES_BLD_HVACR_RefID","HVACR_DocumentHeader_RefID","AverageRating_RefID","HVACR_Comment","RES_STR_HVACR_PropertyAssessmentID","GlobalPropertyMatchingID","Rating_RefID","PropertyAssessment_Comment","DocumentHeader_RefID","RES_STR_HVACR_PropertyID","Action_Timeframe_RefID","IfCustom_Description","IfCustom_Name","IsCustom","Action_Unit_RefID","Action_PricePerUnit_RefID","Action_UnitAmount","SelectedActionVersion_RefID","RES_STR_HVACR_RequiredActionID","RequiredAction_Comment","EffectivePrice_RefID","Action_Name_DictID","PriceValue_Amount" });
				while(reader.Read())
				{
					L5DD_GHSIfRID_1448_raw resultItem = new L5DD_GHSIfRID_1448_raw();
					//0:Parameter RES_STR_HVACRID of type Guid
					resultItem.RES_STR_HVACRID = reader.GetGuid(0);
					//1:Parameter RES_BLD_HVACR_RefID of type Guid
					resultItem.RES_BLD_HVACR_RefID = reader.GetGuid(1);
					//2:Parameter HVACR_DocumentHeader_RefID of type Guid
					resultItem.HVACR_DocumentHeader_RefID = reader.GetGuid(2);
					//3:Parameter AverageRating_RefID of type Guid
					resultItem.AverageRating_RefID = reader.GetGuid(3);
					//4:Parameter HVACR_Comment of type String
					resultItem.HVACR_Comment = reader.GetString(4);
					//5:Parameter RES_STR_HVACR_PropertyAssessmentID of type Guid
					resultItem.RES_STR_HVACR_PropertyAssessmentID = reader.GetGuid(5);
					//6:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(6);
					//7:Parameter Rating_RefID of type Guid
					resultItem.Rating_RefID = reader.GetGuid(7);
					//8:Parameter PropertyAssessment_Comment of type String
					resultItem.PropertyAssessment_Comment = reader.GetString(8);
					//9:Parameter DocumentHeader_RefID of type Guid
					resultItem.DocumentHeader_RefID = reader.GetGuid(9);
					//10:Parameter RES_STR_HVACR_PropertyID of type Guid
					resultItem.RES_STR_HVACR_PropertyID = reader.GetGuid(10);
					//11:Parameter Action_Timeframe_RefID of type Guid
					resultItem.Action_Timeframe_RefID = reader.GetGuid(11);
					//12:Parameter IfCustom_Description of type String
					resultItem.IfCustom_Description = reader.GetString(12);
					//13:Parameter IfCustom_Name of type String
					resultItem.IfCustom_Name = reader.GetString(13);
					//14:Parameter IsCustom of type bool
					resultItem.IsCustom = reader.GetBoolean(14);
					//15:Parameter Action_Unit_RefID of type Guid
					resultItem.Action_Unit_RefID = reader.GetGuid(15);
					//16:Parameter Action_PricePerUnit_RefID of type Guid
					resultItem.Action_PricePerUnit_RefID = reader.GetGuid(16);
					//17:Parameter Action_UnitAmount of type double
					resultItem.Action_UnitAmount = reader.GetDouble(17);
					//18:Parameter SelectedActionVersion_RefID of type Guid
					resultItem.SelectedActionVersion_RefID = reader.GetGuid(18);
					//19:Parameter RES_STR_HVACR_RequiredActionID of type Guid
					resultItem.RES_STR_HVACR_RequiredActionID = reader.GetGuid(19);
					//20:Parameter RequiredAction_Comment of type String
					resultItem.RequiredAction_Comment = reader.GetString(20);
					//21:Parameter EffectivePrice_RefID of type Guid
					resultItem.EffectivePrice_RefID = reader.GetGuid(21);
					//22:Parameter Action_Name of type Dict
					resultItem.Action_Name = reader.GetDictionary(22);
					resultItem.Action_Name.SourceTable = "res_act_action_version";
					loader.Append(resultItem.Action_Name);
					//23:Parameter PriceValue_Amount of type double
					resultItem.PriceValue_Amount = reader.GetDouble(23);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_HVACRSubmisionInfo_For_RevisionID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5DD_GHSIfRID_1448_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DD_GHSIfRID_1448_Array Invoke(string ConnectionString,P_L5DD_GHSIfRID_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DD_GHSIfRID_1448_Array Invoke(DbConnection Connection,P_L5DD_GHSIfRID_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DD_GHSIfRID_1448_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DD_GHSIfRID_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DD_GHSIfRID_1448_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DD_GHSIfRID_1448 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DD_GHSIfRID_1448_Array functionReturn = new FR_L5DD_GHSIfRID_1448_Array();
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

				throw new Exception("Exception occured in method cls_Get_HVACRSubmisionInfo_For_RevisionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5DD_GHSIfRID_1448_raw 
	{
		public Guid RES_STR_HVACRID; 
		public Guid RES_BLD_HVACR_RefID; 
		public Guid HVACR_DocumentHeader_RefID; 
		public Guid AverageRating_RefID; 
		public String HVACR_Comment; 
		public Guid RES_STR_HVACR_PropertyAssessmentID; 
		public String GlobalPropertyMatchingID; 
		public Guid Rating_RefID; 
		public String PropertyAssessment_Comment; 
		public Guid DocumentHeader_RefID; 
		public Guid RES_STR_HVACR_PropertyID; 
		public Guid Action_Timeframe_RefID; 
		public String IfCustom_Description; 
		public String IfCustom_Name; 
		public bool IsCustom; 
		public Guid Action_Unit_RefID; 
		public Guid Action_PricePerUnit_RefID; 
		public double Action_UnitAmount; 
		public Guid SelectedActionVersion_RefID; 
		public Guid RES_STR_HVACR_RequiredActionID; 
		public String RequiredAction_Comment; 
		public Guid EffectivePrice_RefID; 
		public Dict Action_Name; 
		public double PriceValue_Amount; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DD_GHSIfRID_1448[] Convert(List<L5DD_GHSIfRID_1448_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DD_GHSIfRID_1448 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_STR_HVACRID)).ToArray()
	group el_L5DD_GHSIfRID_1448 by new 
	{ 
		el_L5DD_GHSIfRID_1448.RES_STR_HVACRID,

	}
	into gfunct_L5DD_GHSIfRID_1448
	select new L5DD_GHSIfRID_1448
	{     
		RES_STR_HVACRID = gfunct_L5DD_GHSIfRID_1448.Key.RES_STR_HVACRID ,
		RES_BLD_HVACR_RefID = gfunct_L5DD_GHSIfRID_1448.FirstOrDefault().RES_BLD_HVACR_RefID ,
		HVACR_DocumentHeader_RefID = gfunct_L5DD_GHSIfRID_1448.FirstOrDefault().HVACR_DocumentHeader_RefID ,
		AverageRating_RefID = gfunct_L5DD_GHSIfRID_1448.FirstOrDefault().AverageRating_RefID ,
		HVACR_Comment = gfunct_L5DD_GHSIfRID_1448.FirstOrDefault().HVACR_Comment ,

		HVACRPropertyAsessments = 
		(
			from el_HVACRPropertyAsessments in gfunct_L5DD_GHSIfRID_1448.Where(element => !EqualsDefaultValue(element.RES_STR_HVACR_PropertyAssessmentID)).ToArray()
			group el_HVACRPropertyAsessments by new 
			{ 
				el_HVACRPropertyAsessments.RES_STR_HVACR_PropertyAssessmentID,

			}
			into gfunct_HVACRPropertyAsessments
			select new L5DD_GHSIfRID_1448_HVACRPropertyAsessment
			{     
				RES_STR_HVACR_PropertyAssessmentID = gfunct_HVACRPropertyAsessments.Key.RES_STR_HVACR_PropertyAssessmentID ,
				GlobalPropertyMatchingID = gfunct_HVACRPropertyAsessments.FirstOrDefault().GlobalPropertyMatchingID ,
				Rating_RefID = gfunct_HVACRPropertyAsessments.FirstOrDefault().Rating_RefID ,
				PropertyAssessment_Comment = gfunct_HVACRPropertyAsessments.FirstOrDefault().PropertyAssessment_Comment ,
				DocumentHeader_RefID = gfunct_HVACRPropertyAsessments.FirstOrDefault().DocumentHeader_RefID ,
				RES_STR_HVACR_PropertyID = gfunct_HVACRPropertyAsessments.FirstOrDefault().RES_STR_HVACR_PropertyID ,

				HVACRReqActions = 
				(
					from el_HVACRReqActions in gfunct_HVACRPropertyAsessments.Where(element => !EqualsDefaultValue(element.RES_STR_HVACR_RequiredActionID)).ToArray()
					group el_HVACRReqActions by new 
					{ 
						el_HVACRReqActions.RES_STR_HVACR_RequiredActionID,

					}
					into gfunct_HVACRReqActions
					select new L5DD_GHSIfRID_1448_HVACRReqAction
					{     
						Action_Timeframe_RefID = gfunct_HVACRReqActions.FirstOrDefault().Action_Timeframe_RefID ,
						IfCustom_Description = gfunct_HVACRReqActions.FirstOrDefault().IfCustom_Description ,
						IfCustom_Name = gfunct_HVACRReqActions.FirstOrDefault().IfCustom_Name ,
						IsCustom = gfunct_HVACRReqActions.FirstOrDefault().IsCustom ,
						Action_Unit_RefID = gfunct_HVACRReqActions.FirstOrDefault().Action_Unit_RefID ,
						Action_PricePerUnit_RefID = gfunct_HVACRReqActions.FirstOrDefault().Action_PricePerUnit_RefID ,
						Action_UnitAmount = gfunct_HVACRReqActions.FirstOrDefault().Action_UnitAmount ,
						SelectedActionVersion_RefID = gfunct_HVACRReqActions.FirstOrDefault().SelectedActionVersion_RefID ,
						RES_STR_HVACR_RequiredActionID = gfunct_HVACRReqActions.Key.RES_STR_HVACR_RequiredActionID ,
						RequiredAction_Comment = gfunct_HVACRReqActions.FirstOrDefault().RequiredAction_Comment ,
						EffectivePrice_RefID = gfunct_HVACRReqActions.FirstOrDefault().EffectivePrice_RefID ,
						Action_Name = gfunct_HVACRReqActions.FirstOrDefault().Action_Name ,
						PriceValue_Amount = gfunct_HVACRReqActions.FirstOrDefault().PriceValue_Amount ,

					}
				).ToArray(),

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5DD_GHSIfRID_1448_Array : FR_Base
	{
		public L5DD_GHSIfRID_1448[] Result	{ get; set; } 
		public FR_L5DD_GHSIfRID_1448_Array() : base() {}

		public FR_L5DD_GHSIfRID_1448_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DD_GHSIfRID_1448 for attribute P_L5DD_GHSIfRID_1448
		[DataContract]
		public class P_L5DD_GHSIfRID_1448 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionID { get; set; } 
			[DataMember]
			public Guid? BuildingPartID { get; set; } 
			[DataMember] //Special parameter for query parsing
			public bool BuildingPartID_IsSpecified { get; set; }

		}
		#endregion
		#region SClass L5DD_GHSIfRID_1448 for attribute L5DD_GHSIfRID_1448
		[DataContract]
		public class L5DD_GHSIfRID_1448 
		{
			[DataMember]
			public L5DD_GHSIfRID_1448_HVACRPropertyAsessment[] HVACRPropertyAsessments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_HVACRID { get; set; } 
			[DataMember]
			public Guid RES_BLD_HVACR_RefID { get; set; } 
			[DataMember]
			public Guid HVACR_DocumentHeader_RefID { get; set; } 
			[DataMember]
			public Guid AverageRating_RefID { get; set; } 
			[DataMember]
			public String HVACR_Comment { get; set; } 

		}
		#endregion
		#region SClass L5DD_GHSIfRID_1448_HVACRPropertyAsessment for attribute HVACRPropertyAsessments
		[DataContract]
		public class L5DD_GHSIfRID_1448_HVACRPropertyAsessment 
		{
			[DataMember]
			public L5DD_GHSIfRID_1448_HVACRReqAction[] HVACRReqActions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_HVACR_PropertyAssessmentID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid Rating_RefID { get; set; } 
			[DataMember]
			public String PropertyAssessment_Comment { get; set; } 
			[DataMember]
			public Guid DocumentHeader_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_HVACR_PropertyID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GHSIfRID_1448_HVACRReqAction for attribute HVACRReqActions
		[DataContract]
		public class L5DD_GHSIfRID_1448_HVACRReqAction 
		{
			//Standard type parameters
			[DataMember]
			public Guid Action_Timeframe_RefID { get; set; } 
			[DataMember]
			public String IfCustom_Description { get; set; } 
			[DataMember]
			public String IfCustom_Name { get; set; } 
			[DataMember]
			public bool IsCustom { get; set; } 
			[DataMember]
			public Guid Action_Unit_RefID { get; set; } 
			[DataMember]
			public Guid Action_PricePerUnit_RefID { get; set; } 
			[DataMember]
			public double Action_UnitAmount { get; set; } 
			[DataMember]
			public Guid SelectedActionVersion_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_HVACR_RequiredActionID { get; set; } 
			[DataMember]
			public String RequiredAction_Comment { get; set; } 
			[DataMember]
			public Guid EffectivePrice_RefID { get; set; } 
			[DataMember]
			public Dict Action_Name { get; set; } 
			[DataMember]
			public double PriceValue_Amount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DD_GHSIfRID_1448_Array cls_Get_HVACRSubmisionInfo_For_RevisionID(,P_L5DD_GHSIfRID_1448 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DD_GHSIfRID_1448_Array invocationResult = cls_Get_HVACRSubmisionInfo_For_RevisionID.Invoke(connectionString,P_L5DD_GHSIfRID_1448 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_DueDiligences.Atomic.Retrieval.P_L5DD_GHSIfRID_1448();
parameter.RevisionID = ...;
parameter.BuildingPartID = ...;
parameter.BuildingPartID_IsSpecified = false;

*/