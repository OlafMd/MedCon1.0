/* 
 * Generated on 7/5/2013 4:01:26 PM
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
    /// var result = cls_get_Submission_For_SubmissioniD.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_get_Submission_For_SubmissioniD
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DD_GSFS_1538_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DD_GSFS_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DD_GSFS_1538_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_DueDiligences.Atomic.Retrieval.SQL.cls_get_Submission_For_SubmissioniD.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RevisionID", Parameter.RevisionID);



			List<L5DD_GSFS_1538> results = new List<L5DD_GSFS_1538>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "RES_DUD_RevisionID","RevisionGroup_RefID","RES_BLD_Building_RefID","Revision_Comment","Revision_Title","ScopeOfInspectionIncludes_Internal","ScopeOfInspectionIncludes_External","QuestionnaireVersion_RefID","RES_BLD_BuildingID","Building_BalconyPortionPercent","Building_Name","Building_DocumentationStructure_RefID","Creation_Timestamp","IsContaminationSuspected","Building_NumberOfFloors","Building_ElevatorCoveragePercent","Building_NumberOfAppartments","Building_NumberOfOccupiedAppartments","Building_NumberOfOffices","Building_NumberOfRetailUnits","Building_NumberOfProductionUnits","Building_NumberOfOtherUnits","Building_CurrentAverageRentPrice_per_sqm_RefID","BuildingRevisionHeader_RefID" });
				while(reader.Read())
				{
					L5DD_GSFS_1538 resultItem = new L5DD_GSFS_1538();
					//0:Parameter RES_DUD_RevisionID of type Guid
					resultItem.RES_DUD_RevisionID = reader.GetGuid(0);
					//1:Parameter RevisionGroup_RefID of type Guid
					resultItem.RevisionGroup_RefID = reader.GetGuid(1);
					//2:Parameter RES_BLD_Building_RefID of type Guid
					resultItem.RES_BLD_Building_RefID = reader.GetGuid(2);
					//3:Parameter Revision_Comment of type String
					resultItem.Revision_Comment = reader.GetString(3);
					//4:Parameter Revision_Title of type String
					resultItem.Revision_Title = reader.GetString(4);
					//5:Parameter ScopeOfInspectionIncludes_Internal of type String
					resultItem.ScopeOfInspectionIncludes_Internal = reader.GetString(5);
					//6:Parameter ScopeOfInspectionIncludes_External of type String
					resultItem.ScopeOfInspectionIncludes_External = reader.GetString(6);
					//7:Parameter QuestionnaireVersion_RefID of type Guid
					resultItem.QuestionnaireVersion_RefID = reader.GetGuid(7);
					//8:Parameter RES_BLD_BuildingID of type Guid
					resultItem.RES_BLD_BuildingID = reader.GetGuid(8);
					//9:Parameter Building_BalconyPortionPercent of type String
					resultItem.Building_BalconyPortionPercent = reader.GetString(9);
					//10:Parameter Building_Name of type String
					resultItem.Building_Name = reader.GetString(10);
					//11:Parameter Building_DocumentationStructure_RefID of type Guid
					resultItem.Building_DocumentationStructure_RefID = reader.GetGuid(11);
					//12:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(12);
					//13:Parameter IsContaminationSuspected of type bool
					resultItem.IsContaminationSuspected = reader.GetBoolean(13);
					//14:Parameter Building_NumberOfFloors of type String
					resultItem.Building_NumberOfFloors = reader.GetString(14);
					//15:Parameter Building_ElevatorCoveragePercent of type String
					resultItem.Building_ElevatorCoveragePercent = reader.GetString(15);
					//16:Parameter Building_NumberOfAppartments of type String
					resultItem.Building_NumberOfAppartments = reader.GetString(16);
					//17:Parameter Building_NumberOfOccupiedAppartments of type String
					resultItem.Building_NumberOfOccupiedAppartments = reader.GetString(17);
					//18:Parameter Building_NumberOfOffices of type String
					resultItem.Building_NumberOfOffices = reader.GetString(18);
					//19:Parameter Building_NumberOfRetailUnits of type String
					resultItem.Building_NumberOfRetailUnits = reader.GetString(19);
					//20:Parameter Building_NumberOfProductionUnits of type String
					resultItem.Building_NumberOfProductionUnits = reader.GetString(20);
					//21:Parameter Building_NumberOfOtherUnits of type String
					resultItem.Building_NumberOfOtherUnits = reader.GetString(21);
					//22:Parameter Building_CurrentAverageRentPrice_per_sqm_RefID of type Guid
					resultItem.Building_CurrentAverageRentPrice_per_sqm_RefID = reader.GetGuid(22);
					//23:Parameter BuildingRevisionHeader_RefID of type Guid
					resultItem.BuildingRevisionHeader_RefID = reader.GetGuid(23);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_get_Submission_For_SubmissioniD",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DD_GSFS_1538_Array Invoke(string ConnectionString,P_L5DD_GSFS_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DD_GSFS_1538_Array Invoke(DbConnection Connection,P_L5DD_GSFS_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DD_GSFS_1538_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DD_GSFS_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DD_GSFS_1538_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DD_GSFS_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DD_GSFS_1538_Array functionReturn = new FR_L5DD_GSFS_1538_Array();
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

				throw new Exception("Exception occured in method cls_get_Submission_For_SubmissioniD",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DD_GSFS_1538_Array : FR_Base
	{
		public L5DD_GSFS_1538[] Result	{ get; set; } 
		public FR_L5DD_GSFS_1538_Array() : base() {}

		public FR_L5DD_GSFS_1538_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DD_GSFS_1538 for attribute P_L5DD_GSFS_1538
		[DataContract]
		public class P_L5DD_GSFS_1538 
		{
			//Standard type parameters
			[DataMember]
			public Guid RevisionID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538 for attribute L5DD_GSFS_1538
		[DataContract]
		public class L5DD_GSFS_1538 
		{
			[DataMember]
			public L5DD_GSFS_1538_Documents[] Documents { get; set; }
			[DataMember]
			public L5DD_GSFS_1538_Appartments[] Appartments { get; set; }
			[DataMember]
			public L5DD_GSFS_1538_Attic[] Attic { get; set; }
			[DataMember]
			public L5DD_GSFS_1538_Facades[] Facades { get; set; }
			[DataMember]
			public L5DD_GSFS_1538_Outdoor_Facilities[] Outdoor_Facilities { get; set; }
			[DataMember]
			public L5DD_GSFS_1538_Staircases[] Staircases { get; set; }
			[DataMember]
			public L5DD_GSFS_1538_Basements[] Basements { get; set; }
			[DataMember]
			public L5DD_GSFS_1538_HVACR[] HVACR { get; set; }
			[DataMember]
			public L5DD_GSFS_1538_Roof[] Roof { get; set; }
			[DataMember]
			public L5DD_GSFS_1538_Questionnaires[] Questionnaires { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_DUD_RevisionID { get; set; } 
			[DataMember]
			public Guid RevisionGroup_RefID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Building_RefID { get; set; } 
			[DataMember]
			public String Revision_Comment { get; set; } 
			[DataMember]
			public String Revision_Title { get; set; } 
			[DataMember]
			public String ScopeOfInspectionIncludes_Internal { get; set; } 
			[DataMember]
			public String ScopeOfInspectionIncludes_External { get; set; } 
			[DataMember]
			public Guid QuestionnaireVersion_RefID { get; set; } 
			[DataMember]
			public Guid RES_BLD_BuildingID { get; set; } 
			[DataMember]
			public String Building_BalconyPortionPercent { get; set; } 
			[DataMember]
			public String Building_Name { get; set; } 
			[DataMember]
			public Guid Building_DocumentationStructure_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsContaminationSuspected { get; set; } 
			[DataMember]
			public String Building_NumberOfFloors { get; set; } 
			[DataMember]
			public String Building_ElevatorCoveragePercent { get; set; } 
			[DataMember]
			public String Building_NumberOfAppartments { get; set; } 
			[DataMember]
			public String Building_NumberOfOccupiedAppartments { get; set; } 
			[DataMember]
			public String Building_NumberOfOffices { get; set; } 
			[DataMember]
			public String Building_NumberOfRetailUnits { get; set; } 
			[DataMember]
			public String Building_NumberOfProductionUnits { get; set; } 
			[DataMember]
			public String Building_NumberOfOtherUnits { get; set; } 
			[DataMember]
			public Guid Building_CurrentAverageRentPrice_per_sqm_RefID { get; set; } 
			[DataMember]
			public Guid BuildingRevisionHeader_RefID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Documents for attribute Documents
		[DataContract]
		public class L5DD_GSFS_1538_Documents 
		{
			//Standard type parameters
			[DataMember]
			public String Alias { get; set; } 
			[DataMember]
			public String PrimaryType { get; set; } 
			[DataMember]
			public Guid DOC_DocumentID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Appartments for attribute Appartments
		[DataContract]
		public class L5DD_GSFS_1538_Appartments 
		{
			[DataMember]
			public L5DD_GSFS_1538_Appartment_Documents[] Documents { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_ApartmentID { get; set; } 
			[DataMember]
			public Guid RES_STR_ApartmentID { get; set; } 
			[DataMember]
			public Guid RES_STR_Apartment_PropertyAssessmentID { get; set; } 
			[DataMember]
			public Guid RES_STR_Apartment_PropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_Apartment_RequiredActionID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Apartment_Type_RefID { get; set; } 
			[DataMember]
			public Guid ApartmentType_RefID { get; set; } 
			[DataMember]
			public String ApartmentSize_Value { get; set; } 
			[DataMember]
			public bool IsAppartment_ForRent { get; set; } 
			[DataMember]
			public Guid ApartmentSize_Unit_RefID { get; set; } 
			[DataMember]
			public Guid AverageRating_RefID { get; set; } 
			[DataMember]
			public Guid Rating_RefID { get; set; } 
			[DataMember]
			public String Appartmnet_AssessmentComment { get; set; } 
			[DataMember]
			public Dict ApartmentProperty_Name { get; set; } 
			[DataMember]
			public Guid SelectedActionVersion_RefID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Appartment_Documents for attribute Documents
		[DataContract]
		public class L5DD_GSFS_1538_Appartment_Documents 
		{
			//Standard type parameters
			[DataMember]
			public String Alias { get; set; } 
			[DataMember]
			public String PrimaryType { get; set; } 
			[DataMember]
			public Guid DOC_DocumentID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Attic for attribute Attic
		[DataContract]
		public class L5DD_GSFS_1538_Attic 
		{
			[DataMember]
			public L5DD_GSFS_1538_Attic_Documents[] Documents { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_AtticID { get; set; } 
			[DataMember]
			public Guid RES_STR_AtticID { get; set; } 
			[DataMember]
			public Guid RES_STR_Attic_PropertyAssessmentID { get; set; } 
			[DataMember]
			public Guid RES_STR_Attic_RequiredActionID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Attic_Type_RefID { get; set; } 
			[DataMember]
			public String AverageRating_RefID1 { get; set; } 
			[DataMember]
			public String Rating_RefID1 { get; set; } 
			[DataMember]
			public String Attic_AssessmentComment { get; set; } 
			[DataMember]
			public Dict AtticProperty_Name { get; set; } 
			[DataMember]
			public String SelectedActionVersion_RefID1 { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Attic_Documents for attribute Documents
		[DataContract]
		public class L5DD_GSFS_1538_Attic_Documents 
		{
			//Standard type parameters
			[DataMember]
			public String Alias { get; set; } 
			[DataMember]
			public String PrimaryType { get; set; } 
			[DataMember]
			public Guid DOC_DocumentID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Facades for attribute Facades
		[DataContract]
		public class L5DD_GSFS_1538_Facades 
		{
			[DataMember]
			public L5DD_GSFS_1538_Facade_Documents[] Documents { get; set; }

			//Standard type parameters
			[DataMember]
			public String SelectedActionVersion_RefID2 { get; set; } 
			[DataMember]
			public Dict FacadeProperty_Name { get; set; } 
			[DataMember]
			public String Rating_RefID2 { get; set; } 
			[DataMember]
			public String Facade_AssessmentComment { get; set; } 
			[DataMember]
			public String AverageRating_RefID2 { get; set; } 
			[DataMember]
			public Guid RES_BLD_Facade_Type_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_Facade_RequiredActionID { get; set; } 
			[DataMember]
			public Guid RES_STR_Facade_PropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_Facade_PropertyAssessmentID { get; set; } 
			[DataMember]
			public Guid RES_STR_FacadeID { get; set; } 
			[DataMember]
			public Guid REL_BLD_FacadeID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Facade_Documents for attribute Documents
		[DataContract]
		public class L5DD_GSFS_1538_Facade_Documents 
		{
			//Standard type parameters
			[DataMember]
			public String Alias { get; set; } 
			[DataMember]
			public String PrimaryType { get; set; } 
			[DataMember]
			public Guid DOC_DocumentID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Outdoor_Facilities for attribute Outdoor_Facilities
		[DataContract]
		public class L5DD_GSFS_1538_Outdoor_Facilities 
		{
			[DataMember]
			public L5DD_GSFS_1538_OutdoorF_Documents[] Documents { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_OutdoorFacilityID { get; set; } 
			[DataMember]
			public Guid RES_STR_OutdoorFacilityID { get; set; } 
			[DataMember]
			public Guid RES_STR_OutdoorFacility_PropertyAssessmentID { get; set; } 
			[DataMember]
			public Guid RES_STR_OutdoorFacility_PropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_OutdoorFacility_RequiredActionID { get; set; } 
			[DataMember]
			public String NumberOfGaragePlaces { get; set; } 
			[DataMember]
			public String NumberOfRentedGaragePlaces { get; set; } 
			[DataMember]
			public Guid RES_BLD_OutdoorFacility_Type_RefID { get; set; } 
			[DataMember]
			public String AverageRating_RefID3 { get; set; } 
			[DataMember]
			public String Rating_RefID3 { get; set; } 
			[DataMember]
			public String Outdoor_AssessmentComment { get; set; } 
			[DataMember]
			public Dict OutdoorFacilityProperty_Name { get; set; } 
			[DataMember]
			public String SelectedActionVersion_RefID3 { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_OutdoorF_Documents for attribute Documents
		[DataContract]
		public class L5DD_GSFS_1538_OutdoorF_Documents 
		{
			//Standard type parameters
			[DataMember]
			public String Alias { get; set; } 
			[DataMember]
			public String PrimaryType { get; set; } 
			[DataMember]
			public Guid DOC_DocumentID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Staircases for attribute Staircases
		[DataContract]
		public class L5DD_GSFS_1538_Staircases 
		{
			[DataMember]
			public L5DD_GSFS_1538_Staircase_Documents[] Documents { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_StaircaseID { get; set; } 
			[DataMember]
			public Guid RES_STR_StaircaseID { get; set; } 
			[DataMember]
			public Guid RES_STR_Staircase_PropertyAssessmentID { get; set; } 
			[DataMember]
			public Guid RES_STR_Staircase_PropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_Staircase_RequiredActionID { get; set; } 
			[DataMember]
			public Guid StaircaseSize_Unit_RefID { get; set; } 
			[DataMember]
			public String StaircaseSize_Value { get; set; } 
			[DataMember]
			public Guid RES_BLD_Staircase_Type_RefID { get; set; } 
			[DataMember]
			public String AverageRating_RefID4 { get; set; } 
			[DataMember]
			public String Rating_RefID4 { get; set; } 
			[DataMember]
			public String Staircase_AssessmentComment { get; set; } 
			[DataMember]
			public Dict StaircaseProperty_Name { get; set; } 
			[DataMember]
			public String SelectedActionVersion_RefID4 { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Staircase_Documents for attribute Documents
		[DataContract]
		public class L5DD_GSFS_1538_Staircase_Documents 
		{
			//Standard type parameters
			[DataMember]
			public String Alias { get; set; } 
			[DataMember]
			public String PrimaryType { get; set; } 
			[DataMember]
			public Guid DOC_DocumentID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Basements for attribute Basements
		[DataContract]
		public class L5DD_GSFS_1538_Basements 
		{
			[DataMember]
			public L5DD_GSFS_1538_BasementDocuments[] Documents { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_STR_Basement_PropertyAssessmentID { get; set; } 
			[DataMember]
			public Guid RES_STR_Basement_PropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_Basement_RequiredActionID { get; set; } 
			[DataMember]
			public Guid RES_STR_BasementID { get; set; } 
			[DataMember]
			public Guid RES_BLD_BasementID { get; set; } 
			[DataMember]
			public String Basement_Assessment_Comment { get; set; } 
			[DataMember]
			public String Rating_RefID5 { get; set; } 
			[DataMember]
			public Dict BasementProperty_Name { get; set; } 
			[DataMember]
			public String AverageRating_RefID5 { get; set; } 
			[DataMember]
			public Guid RES_BLD_Basement_Type_RefID { get; set; } 
			[DataMember]
			public String SelectedActionVersion_RefID5 { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_BasementDocuments for attribute Documents
		[DataContract]
		public class L5DD_GSFS_1538_BasementDocuments 
		{
			//Standard type parameters
			[DataMember]
			public String Alias { get; set; } 
			[DataMember]
			public String PrimaryType { get; set; } 
			[DataMember]
			public Guid DOC_DocumentID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_HVACR for attribute HVACR
		[DataContract]
		public class L5DD_GSFS_1538_HVACR 
		{
			[DataMember]
			public L5DD_GSFS_1538_HVACR_Documents[] Documents { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_HVACRID { get; set; } 
			[DataMember]
			public Guid RES_STR_HVACRID { get; set; } 
			[DataMember]
			public Guid RES_STR_HVACR_PropertyAssessmentID { get; set; } 
			[DataMember]
			public Guid RES_STR_HVACR_PropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_HVACR_RequiredActionID { get; set; } 
			[DataMember]
			public Guid RES_BLD_HVACR_Type_RefID { get; set; } 
			[DataMember]
			public String AverageRating_RefID6 { get; set; } 
			[DataMember]
			public String Rating_RefID6 { get; set; } 
			[DataMember]
			public String HVACR__AssessmentComment { get; set; } 
			[DataMember]
			public Dict HVACRProperty_Name { get; set; } 
			[DataMember]
			public String SelectedActionVersion_RefID6 { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_HVACR_Documents for attribute Documents
		[DataContract]
		public class L5DD_GSFS_1538_HVACR_Documents 
		{
			//Standard type parameters
			[DataMember]
			public String Alias { get; set; } 
			[DataMember]
			public String PrimaryType { get; set; } 
			[DataMember]
			public Guid DOC_DocumentID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Roof for attribute Roof
		[DataContract]
		public class L5DD_GSFS_1538_Roof 
		{
			[DataMember]
			public L5DD_GSFS_1538_Roof_Documents[] Documents { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid RES_BLD_RoofID { get; set; } 
			[DataMember]
			public Guid RES_STR_Roof_PropertyAssessmentID { get; set; } 
			[DataMember]
			public Guid RES_STR_RoofID { get; set; } 
			[DataMember]
			public Guid RES_STR_Roof_PropertyID { get; set; } 
			[DataMember]
			public Guid RES_STR_Roof_RequiredActionID { get; set; } 
			[DataMember]
			public Guid RES_BLD_Roof_Type_RefID { get; set; } 
			[DataMember]
			public String AverageRating_RefID7 { get; set; } 
			[DataMember]
			public String Rating_RefID7 { get; set; } 
			[DataMember]
			public String Rood_AssessmentComment { get; set; } 
			[DataMember]
			public Dict RoofProperty_Name { get; set; } 
			[DataMember]
			public String SelectedActionVersion_RefID7 { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Roof_Documents for attribute Documents
		[DataContract]
		public class L5DD_GSFS_1538_Roof_Documents 
		{
			//Standard type parameters
			[DataMember]
			public String Alias { get; set; } 
			[DataMember]
			public String PrimaryType { get; set; } 
			[DataMember]
			public Guid DOC_DocumentID { get; set; } 

		}
		#endregion
		#region SClass L5DD_GSFS_1538_Questionnaires for attribute Questionnaires
		[DataContract]
		public class L5DD_GSFS_1538_Questionnaires 
		{
			//Standard type parameters
			[DataMember]
			public Guid RES_QST_QuestionnaireID { get; set; } 
			[DataMember]
			public Guid RES_QST_Questionnaire_VersionID { get; set; } 
			[DataMember]
			public Guid RES_QST_OutdoorFacility_AvailablePropertyID { get; set; } 
			[DataMember]
			public Guid RES_QST_Staircase_AvailablePropertyID { get; set; } 
			[DataMember]
			public Guid RES_QST_Roof_AvailablePropertyID { get; set; } 
			[DataMember]
			public Guid RES_QST_Facade_AvailablePropertyID { get; set; } 
			[DataMember]
			public Guid RES_QST_Attic_AvailablePropertyID { get; set; } 
			[DataMember]
			public Guid RES_QST_Basement_AvailablePropertyID { get; set; } 
			[DataMember]
			public Guid RES_QST_Apartment_AvailablePropertyID { get; set; } 
			[DataMember]
			public Guid RES_QST_HVACR_AvailablePropertyID { get; set; } 
			[DataMember]
			public Dict Questionnaire_Name { get; set; } 
			[DataMember]
			public Dict Questionnaire_Description { get; set; } 
			[DataMember]
			public String QuestionnaireVersion_Comment { get; set; } 
			[DataMember]
			public String QuestionnaireVersion_VersionNumber { get; set; } 
			[DataMember]
			public bool IsApartmentStructureVisible { get; set; } 
			[DataMember]
			public bool IsStaircaseStructureVisible { get; set; } 
			[DataMember]
			public bool IsOutdoorFacilityVisible { get; set; } 
			[DataMember]
			public bool IsFacadeVisible { get; set; } 
			[DataMember]
			public bool IsRoofVisible { get; set; } 
			[DataMember]
			public bool IsBasementVisible { get; set; } 
			[DataMember]
			public bool IsHVACRVisible { get; set; } 
			[DataMember]
			public Guid RES_STR_OutdoorFacility_Property_RefID { get; set; } 
			[DataMember]
			public bool IsAtticVisible { get; set; } 
			[DataMember]
			public Guid RES_STR_Staircase_Property_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_Roof_Property_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_Facade_Property_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_Basement_Property_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_Attic_Property_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_Apartment_Property_RefID { get; set; } 
			[DataMember]
			public Guid RES_STR_HVACR_Property_RefID { get; set; } 
			[DataMember]
			public Guid RES_QST_Questionnaire_Version_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DD_GSFS_1538_Array cls_get_Submission_For_SubmissioniD(,P_L5DD_GSFS_1538 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DD_GSFS_1538_Array invocationResult = cls_get_Submission_For_SubmissioniD.Invoke(connectionString,P_L5DD_GSFS_1538 Parameter,securityTicket);
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
var parameter = new CL5_KPRS_DueDiligences.Atomic.Retrieval.P_L5DD_GSFS_1538();
parameter.RevisionID = ...;

*/