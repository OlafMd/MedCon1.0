/* 
 * Generated on 11/7/2013 2:08:49 PM
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
    /// var result = cls_Get_ApartmentSubmisionInfo_For_RevisionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ApartmentSubmisionInfo_For_RevisionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DD_GASIfRID_1007_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DD_GASIfRID_1007 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DD_GASIfRID_1007_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_DueDiligences.Atomic.Retrieval.SQL.cls_Get_ApartmentSubmisionInfo_For_RevisionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RevisionID", Parameter.RevisionID);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BuildingPartID", Parameter.BuildingPartID);

            if (Parameter.BuildingPartID_IsSpecified == false)
            {
                var regex = new System.Text.RegularExpressions.Regex(@"((and|or)\s*)?(\w*\.)?\w*\s*(=|like|<|>)\s*@BuildingPartID", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                command.CommandText = regex.Replace(command.CommandText, "");
            } 

			List<L5DD_GASIfRID_1007_raw> results = new List<L5DD_GASIfRID_1007_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RES_STR_ApartmentID","RES_BLD_Apartment_RefID","AverageRating_RefID","Apartment_DocumentHeader_RefID","Apartment_Comment","IsAppartment_ForRent","ApartmentSize_Unit_RefID","ApartmentSize_Value","TypeOfHeating_RefID","TypeOfFlooring_RefID","TypeOfWallCovering_RefID","RES_STR_Apartment_PropertyAssessmentID","Rating_RefID","DocumentHeader_RefID","GlobalPropertyMatchingID","RES_STR_Apartment_PropertyID","PropertyAssessment_Comment","RES_STR_Apartment_RequiredActionID","SelectedActionVersion_RefID","RequiredAction_Comment","Action_PricePerUnit_RefID","Action_Unit_RefID","Action_UnitAmount","IsCustom","IfCustom_Name","IfCustom_Description","EffectivePrice_RefID","Action_Timeframe_RefID","Action_Name_DictID","PriceValue_Amount" });
				while(reader.Read())
				{
					L5DD_GASIfRID_1007_raw resultItem = new L5DD_GASIfRID_1007_raw();
					//0:Parameter RES_STR_ApartmentID of type Guid
					resultItem.RES_STR_ApartmentID = reader.GetGuid(0);
					//1:Parameter RES_BLD_Apartment_RefID of type Guid
					resultItem.RES_BLD_Apartment_RefID = reader.GetGuid(1);
					//2:Parameter AverageRating_RefID of type Guid
					resultItem.AverageRating_RefID = reader.GetGuid(2);
					//3:Parameter Apartment_DocumentHeader_RefID of type Guid
					resultItem.Apartment_DocumentHeader_RefID = reader.GetGuid(3);
					//4:Parameter Apartment_Comment of type String
					resultItem.Apartment_Comment = reader.GetString(4);
					//5:Parameter IsAppartment_ForRent of type bool
					resultItem.IsAppartment_ForRent = reader.GetBoolean(5);
					//6:Parameter ApartmentSize_Unit_RefID of type Guid
					resultItem.ApartmentSize_Unit_RefID = reader.GetGuid(6);
					//7:Parameter ApartmentSize_Value of type double
					resultItem.ApartmentSize_Value = reader.GetDouble(7);
					//8:Parameter TypeOfHeating_RefID of type Guid
					resultItem.TypeOfHeating_RefID = reader.GetGuid(8);
					//9:Parameter TypeOfFlooring_RefID of type Guid
					resultItem.TypeOfFlooring_RefID = reader.GetGuid(9);
					//10:Parameter TypeOfWallCovering_RefID of type Guid
					resultItem.TypeOfWallCovering_RefID = reader.GetGuid(10);
					//11:Parameter RES_STR_Apartment_PropertyAssessmentID of type Guid
					resultItem.RES_STR_Apartment_PropertyAssessmentID = reader.GetGuid(11);
					//12:Parameter Rating_RefID of type Guid
					resultItem.Rating_RefID = reader.GetGuid(12);
					//13:Parameter DocumentHeader_RefID of type Guid
					resultItem.DocumentHeader_RefID = reader.GetGuid(13);
					//14:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(14);
					//15:Parameter RES_STR_Apartment_PropertyID of type Guid
					resultItem.RES_STR_Apartment_PropertyID = reader.GetGuid(15);
					//16:Parameter PropertyAssessment_Comment of type String
					resultItem.PropertyAssessment_Comment = reader.GetString(16);
					//17:Parameter RES_STR_Apartment_RequiredActionID of type Guid
					resultItem.RES_STR_Apartment_RequiredActionID = reader.GetGuid(17);
					//18:Parameter SelectedActionVersion_RefID of type Guid
					resultItem.SelectedActionVersion_RefID = reader.GetGuid(18);
					//19:Parameter RequiredAction_Comment of type String
					resultItem.RequiredAction_Comment = reader.GetString(19);
					//20:Parameter Action_PricePerUnit_RefID of type Guid
					resultItem.Action_PricePerUnit_RefID = reader.GetGuid(20);
					//21:Parameter Action_Unit_RefID of type Guid
					resultItem.Action_Unit_RefID = reader.GetGuid(21);
					//22:Parameter Action_UnitAmount of type double
					resultItem.Action_UnitAmount = reader.GetDouble(22);
					//23:Parameter IsCustom of type bool
					resultItem.IsCustom = reader.GetBoolean(23);
					//24:Parameter IfCustom_Name of type String
					resultItem.IfCustom_Name = reader.GetString(24);
					//25:Parameter IfCustom_Description of type String
					resultItem.IfCustom_Description = reader.GetString(25);
					//26:Parameter EffectivePrice_RefID of type Guid
					resultItem.EffectivePrice_RefID = reader.GetGuid(26);
					//27:Parameter Action_Timeframe_RefID of type Guid
					resultItem.Action_Timeframe_RefID = reader.GetGuid(27);
					//28:Parameter Action_Name of type Dict
					resultItem.Action_Name = reader.GetDictionary(28);
					resultItem.Action_Name.SourceTable = "res_act_action_version";
					loader.Append(resultItem.Action_Name);
					//29:Parameter PriceValue_Amount of type double
					resultItem.PriceValue_Amount = reader.GetDouble(29);

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

			returnStatus.Result = L5DD_GASIfRID_1007_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DD_GASIfRID_1007_Array Invoke(string ConnectionString,P_L5DD_GASIfRID_1007 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DD_GASIfRID_1007_Array Invoke(DbConnection Connection,P_L5DD_GASIfRID_1007 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DD_GASIfRID_1007_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DD_GASIfRID_1007 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DD_GASIfRID_1007_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DD_GASIfRID_1007 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DD_GASIfRID_1007_Array functionReturn = new FR_L5DD_GASIfRID_1007_Array();
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
	public class L5DD_GASIfRID_1007_raw 
	{
		public Guid RES_STR_ApartmentID; 
		public Guid RES_BLD_Apartment_RefID; 
		public Guid AverageRating_RefID; 
		public Guid Apartment_DocumentHeader_RefID; 
		public String Apartment_Comment; 
		public bool IsAppartment_ForRent; 
		public Guid ApartmentSize_Unit_RefID; 
		public double ApartmentSize_Value; 
		public Guid TypeOfHeating_RefID; 
		public Guid TypeOfFlooring_RefID; 
		public Guid TypeOfWallCovering_RefID; 
		public Guid RES_STR_Apartment_PropertyAssessmentID; 
		public Guid Rating_RefID; 
		public Guid DocumentHeader_RefID; 
		public String GlobalPropertyMatchingID; 
		public Guid RES_STR_Apartment_PropertyID; 
		public String PropertyAssessment_Comment; 
		public Guid RES_STR_Apartment_RequiredActionID; 
		public Guid SelectedActionVersion_RefID; 
		public String RequiredAction_Comment; 
		public Guid Action_PricePerUnit_RefID; 
		public Guid Action_Unit_RefID; 
		public double Action_UnitAmount; 
		public bool IsCustom; 
		public String IfCustom_Name; 
		public String IfCustom_Description; 
		public Guid EffectivePrice_RefID; 
		public Guid Action_Timeframe_RefID; 
		public Dict Action_Name; 
		public double PriceValue_Amount; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DD_GASIfRID_1007[] Convert(List<L5DD_GASIfRID_1007_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DD_GASIfRID_1007 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.RES_STR_ApartmentID)).ToArray()
	group el_L5DD_GASIfRID_1007 by new 
	{ 
		el_L5DD_GASIfRID_1007.RES_STR_ApartmentID,

	}
	into gfunct_L5DD_GASIfRID_1007
	select new L5DD_GASIfRID_1007
	{     
		RES_STR_ApartmentID = gfunct_L5DD_GASIfRID_1007.Key.RES_STR_ApartmentID ,
		RES_BLD_Apartment_RefID = gfunct_L5DD_GASIfRID_1007.FirstOrDefault().RES_BLD_Apartment_RefID ,
		AverageRating_RefID = gfunct_L5DD_GASIfRID_1007.FirstOrDefault().AverageRating_RefID ,
		Apartment_DocumentHeader_RefID = gfunct_L5DD_GASIfRID_1007.FirstOrDefault().Apartment_DocumentHeader_RefID ,
		Apartment_Comment = gfunct_L5DD_GASIfRID_1007.FirstOrDefault().Apartment_Comment ,
		IsAppartment_ForRent = gfunct_L5DD_GASIfRID_1007.FirstOrDefault().IsAppartment_ForRent ,
		ApartmentSize_Unit_RefID = gfunct_L5DD_GASIfRID_1007.FirstOrDefault().ApartmentSize_Unit_RefID ,
		ApartmentSize_Value = gfunct_L5DD_GASIfRID_1007.FirstOrDefault().ApartmentSize_Value ,
		TypeOfHeating_RefID = gfunct_L5DD_GASIfRID_1007.FirstOrDefault().TypeOfHeating_RefID ,
		TypeOfFlooring_RefID = gfunct_L5DD_GASIfRID_1007.FirstOrDefault().TypeOfFlooring_RefID ,
		TypeOfWallCovering_RefID = gfunct_L5DD_GASIfRID_1007.FirstOrDefault().TypeOfWallCovering_RefID ,

		ApartmentPropertyAsessments = 
		(
			from el_ApartmentPropertyAsessments in gfunct_L5DD_GASIfRID_1007.Where(element => !EqualsDefaultValue(element.RES_STR_Apartment_PropertyAssessmentID)).ToArray()
			group el_ApartmentPropertyAsessments by new 
			{ 
				el_ApartmentPropertyAsessments.RES_STR_Apartment_PropertyAssessmentID,

			}
			into gfunct_ApartmentPropertyAsessments
			select new L5DD_GASIfRID_1007_ApartmentPropertyAsessment
			{     
				RES_STR_Apartment_PropertyAssessmentID = gfunct_ApartmentPropertyAsessments.Key.RES_STR_Apartment_PropertyAssessmentID ,
				Rating_RefID = gfunct_ApartmentPropertyAsessments.FirstOrDefault().Rating_RefID ,
				DocumentHeader_RefID = gfunct_ApartmentPropertyAsessments.FirstOrDefault().DocumentHeader_RefID ,
				GlobalPropertyMatchingID = gfunct_ApartmentPropertyAsessments.FirstOrDefault().GlobalPropertyMatchingID ,
				RES_STR_Apartment_PropertyID = gfunct_ApartmentPropertyAsessments.FirstOrDefault().RES_STR_Apartment_PropertyID ,
				PropertyAssessment_Comment = gfunct_ApartmentPropertyAsessments.FirstOrDefault().PropertyAssessment_Comment ,

				ApartmentReqActions = 
				(
					from el_ApartmentReqActions in gfunct_ApartmentPropertyAsessments.Where(element => !EqualsDefaultValue(element.RES_STR_Apartment_RequiredActionID)).ToArray()
					group el_ApartmentReqActions by new 
					{ 
						el_ApartmentReqActions.RES_STR_Apartment_RequiredActionID,

					}
					into gfunct_ApartmentReqActions
					select new L5DD_GASIfRID_1007_ApartmentReqAction
					{     
						RES_STR_Apartment_RequiredActionID = gfunct_ApartmentReqActions.Key.RES_STR_Apartment_RequiredActionID ,
						SelectedActionVersion_RefID = gfunct_ApartmentReqActions.FirstOrDefault().SelectedActionVersion_RefID ,
						RequiredAction_Comment = gfunct_ApartmentReqActions.FirstOrDefault().RequiredAction_Comment ,
						Action_PricePerUnit_RefID = gfunct_ApartmentReqActions.FirstOrDefault().Action_PricePerUnit_RefID ,
						Action_Unit_RefID = gfunct_ApartmentReqActions.FirstOrDefault().Action_Unit_RefID ,
						Action_UnitAmount = gfunct_ApartmentReqActions.FirstOrDefault().Action_UnitAmount ,
						IsCustom = gfunct_ApartmentReqActions.FirstOrDefault().IsCustom ,
						IfCustom_Name = gfunct_ApartmentReqActions.FirstOrDefault().IfCustom_Name ,
						IfCustom_Description = gfunct_ApartmentReqActions.FirstOrDefault().IfCustom_Description ,
						EffectivePrice_RefID = gfunct_ApartmentReqActions.FirstOrDefault().EffectivePrice_RefID ,
						Action_Timeframe_RefID = gfunct_ApartmentReqActions.FirstOrDefault().Action_Timeframe_RefID ,
						Action_Name = gfunct_ApartmentReqActions.FirstOrDefault().Action_Name ,
						PriceValue_Amount = gfunct_ApartmentReqActions.FirstOrDefault().PriceValue_Amount ,

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
	public class FR_L5DD_GASIfRID_1007_Array : FR_Base
	{
		public L5DD_GASIfRID_1007[] Result	{ get; set; } 
		public FR_L5DD_GASIfRID_1007_Array() : base() {}

		public FR_L5DD_GASIfRID_1007_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DD_GASIfRID_1007 for attribute P_L5DD_GASIfRID_1007
		[DataContract]
		public class P_L5DD_GASIfRID_1007 
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
		#region SClass L5DD_GASIfRID_1007 for attribute L5DD_GASIfRID_1007
		[DataContract]
		public class L5DD_GASIfRID_1007 
		{
			[DataMember]
			public L5DD_GASIfRID_1007_ApartmentPropertyAsessment[] ApartmentPropertyAsessments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_ApartmentID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Apartment_RefID { get; set; } 
			[DataMember]
			public Guid AverageRating_RefID { get; set; } 
			[DataMember]
			public Guid Apartment_DocumentHeader_RefID { get; set; } 
			[DataMember]
			public String Apartment_Comment { get; set; } 
			[DataMember]
			public bool IsAppartment_ForRent { get; set; } 
			[DataMember]
			public Guid ApartmentSize_Unit_RefID { get; set; } 
			[DataMember]
			public double ApartmentSize_Value { get; set; } 
			[DataMember]
			public Guid TypeOfHeating_RefID { get; set; } 
			[DataMember]
			public Guid TypeOfFlooring_RefID { get; set; } 
			[DataMember]
			public Guid TypeOfWallCovering_RefID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GASIfRID_1007_ApartmentPropertyAsessment for attribute ApartmentPropertyAsessments
		[DataContract]
		public class L5DD_GASIfRID_1007_ApartmentPropertyAsessment 
		{
			[DataMember]
			public L5DD_GASIfRID_1007_ApartmentReqAction[] ApartmentReqActions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Apartment_PropertyAssessmentID { get; set; } 
			[DataMember]
			public Guid Rating_RefID { get; set; } 
			[DataMember]
			public Guid DocumentHeader_RefID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid RES_STR_Apartment_PropertyID { get; set; } 
			[DataMember]
			public String PropertyAssessment_Comment { get; set; } 

		}
		#endregion
		#region SClass L5DD_GASIfRID_1007_ApartmentReqAction for attribute ApartmentReqActions
		[DataContract]
		public class L5DD_GASIfRID_1007_ApartmentReqAction 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Apartment_RequiredActionID { get; set; } 
			[DataMember]
			public Guid SelectedActionVersion_RefID { get; set; } 
			[DataMember]
			public String RequiredAction_Comment { get; set; } 
			[DataMember]
			public Guid Action_PricePerUnit_RefID { get; set; } 
			[DataMember]
			public Guid Action_Unit_RefID { get; set; } 
			[DataMember]
			public double Action_UnitAmount { get; set; } 
			[DataMember]
			public bool IsCustom { get; set; } 
			[DataMember]
			public String IfCustom_Name { get; set; } 
			[DataMember]
			public String IfCustom_Description { get; set; } 
			[DataMember]
			public Guid EffectivePrice_RefID { get; set; } 
			[DataMember]
			public Guid Action_Timeframe_RefID { get; set; } 
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
FR_L5DD_GASIfRID_1007_Array cls_Get_ApartmentSubmisionInfo_For_RevisionID(P_L5DD_GASIfRID_1007 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5DD_GASIfRID_1007_Array result = cls_Get_ApartmentSubmisionInfo_For_RevisionID.Invoke(connectionString,P_L5DD_GASIfRID_1007 Parameter,securityTicket);
	 return result;
}
*/