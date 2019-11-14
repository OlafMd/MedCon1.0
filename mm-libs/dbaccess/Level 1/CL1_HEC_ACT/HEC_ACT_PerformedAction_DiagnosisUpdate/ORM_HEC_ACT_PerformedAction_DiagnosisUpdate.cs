/* 
 * Generated on 05/27/15 10:49:58
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC_ACT
{
	[Serializable]
	public class ORM_HEC_ACT_PerformedAction_DiagnosisUpdate
	{
		public static readonly string TableName = "hec_act_performedaction_diagnosisupdates";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_ACT_PerformedAction_DiagnosisUpdate()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_ACT_PerformedAction_DiagnosisUpdateID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_ACT_PerformedAction_DiagnosisUpdateID = default(Guid);
		private String _HealthcarePerformedAction_DiagnosisITL = default(String);
		private Guid _HEC_ACT_PerformedAction_RefID = default(Guid);
		private Guid _HEC_Patient_Diagnosis_RefID = default(Guid);
		private Guid _PotentialDiagnosis_RefID = default(Guid);
		private Guid _DiagnosisState_RefID = default(Guid);
		private Boolean _IsDiagnosisAssumed = default(Boolean);
		private Boolean _IsDiagnosisConfirmed = default(Boolean);
		private Boolean _IsDiagnosisNegated = default(Boolean);
		private Boolean _IsDiagnosisCreated = default(Boolean);
		private Boolean _IsDiagnosisModified = default(Boolean);
		private Boolean _IsDiagnosisDeactivated = default(Boolean);
		private DateTime _ScheduledExpiryDate = default(DateTime);
		private DateTime _Deactivated_OnDate = default(DateTime);
		private Guid _DeactivatedBy_Doctor_RefID = default(Guid);
		private String _DiagnosisUpdateComment = default(String);
		private String _IM_PotentialDiagnosis_Name = default(String);
		private String _IM_PotentialDiagnosis_Code = default(String);
		private String _IM_PotentialDiagnosisCatalog_Name = default(String);
		private String _IM_PotentialDiagnosisState_Name = default(String);
		private String _IM_DeactivatingDoctor_FullName = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_ACT_PerformedAction_DiagnosisUpdateID { 
			get {
				return _HEC_ACT_PerformedAction_DiagnosisUpdateID;
			}
			set {
				if(_HEC_ACT_PerformedAction_DiagnosisUpdateID != value){
					_HEC_ACT_PerformedAction_DiagnosisUpdateID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String HealthcarePerformedAction_DiagnosisITL { 
			get {
				return _HealthcarePerformedAction_DiagnosisITL;
			}
			set {
				if(_HealthcarePerformedAction_DiagnosisITL != value){
					_HealthcarePerformedAction_DiagnosisITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid HEC_ACT_PerformedAction_RefID { 
			get {
				return _HEC_ACT_PerformedAction_RefID;
			}
			set {
				if(_HEC_ACT_PerformedAction_RefID != value){
					_HEC_ACT_PerformedAction_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid HEC_Patient_Diagnosis_RefID { 
			get {
				return _HEC_Patient_Diagnosis_RefID;
			}
			set {
				if(_HEC_Patient_Diagnosis_RefID != value){
					_HEC_Patient_Diagnosis_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid PotentialDiagnosis_RefID { 
			get {
				return _PotentialDiagnosis_RefID;
			}
			set {
				if(_PotentialDiagnosis_RefID != value){
					_PotentialDiagnosis_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DiagnosisState_RefID { 
			get {
				return _DiagnosisState_RefID;
			}
			set {
				if(_DiagnosisState_RefID != value){
					_DiagnosisState_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDiagnosisAssumed { 
			get {
				return _IsDiagnosisAssumed;
			}
			set {
				if(_IsDiagnosisAssumed != value){
					_IsDiagnosisAssumed = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDiagnosisConfirmed { 
			get {
				return _IsDiagnosisConfirmed;
			}
			set {
				if(_IsDiagnosisConfirmed != value){
					_IsDiagnosisConfirmed = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDiagnosisNegated { 
			get {
				return _IsDiagnosisNegated;
			}
			set {
				if(_IsDiagnosisNegated != value){
					_IsDiagnosisNegated = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDiagnosisCreated { 
			get {
				return _IsDiagnosisCreated;
			}
			set {
				if(_IsDiagnosisCreated != value){
					_IsDiagnosisCreated = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDiagnosisModified { 
			get {
				return _IsDiagnosisModified;
			}
			set {
				if(_IsDiagnosisModified != value){
					_IsDiagnosisModified = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDiagnosisDeactivated { 
			get {
				return _IsDiagnosisDeactivated;
			}
			set {
				if(_IsDiagnosisDeactivated != value){
					_IsDiagnosisDeactivated = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime ScheduledExpiryDate { 
			get {
				return _ScheduledExpiryDate;
			}
			set {
				if(_ScheduledExpiryDate != value){
					_ScheduledExpiryDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Deactivated_OnDate { 
			get {
				return _Deactivated_OnDate;
			}
			set {
				if(_Deactivated_OnDate != value){
					_Deactivated_OnDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DeactivatedBy_Doctor_RefID { 
			get {
				return _DeactivatedBy_Doctor_RefID;
			}
			set {
				if(_DeactivatedBy_Doctor_RefID != value){
					_DeactivatedBy_Doctor_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String DiagnosisUpdateComment { 
			get {
				return _DiagnosisUpdateComment;
			}
			set {
				if(_DiagnosisUpdateComment != value){
					_DiagnosisUpdateComment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IM_PotentialDiagnosis_Name { 
			get {
				return _IM_PotentialDiagnosis_Name;
			}
			set {
				if(_IM_PotentialDiagnosis_Name != value){
					_IM_PotentialDiagnosis_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IM_PotentialDiagnosis_Code { 
			get {
				return _IM_PotentialDiagnosis_Code;
			}
			set {
				if(_IM_PotentialDiagnosis_Code != value){
					_IM_PotentialDiagnosis_Code = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IM_PotentialDiagnosisCatalog_Name { 
			get {
				return _IM_PotentialDiagnosisCatalog_Name;
			}
			set {
				if(_IM_PotentialDiagnosisCatalog_Name != value){
					_IM_PotentialDiagnosisCatalog_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IM_PotentialDiagnosisState_Name { 
			get {
				return _IM_PotentialDiagnosisState_Name;
			}
			set {
				if(_IM_PotentialDiagnosisState_Name != value){
					_IM_PotentialDiagnosisState_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IM_DeactivatingDoctor_FullName { 
			get {
				return _IM_DeactivatingDoctor_FullName;
			}
			set {
				if(_IM_DeactivatingDoctor_FullName != value){
					_IM_DeactivatingDoctor_FullName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Creation_Timestamp { 
			get {
				return _Creation_Timestamp;
			}
			set {
				if(_Creation_Timestamp != value){
					_Creation_Timestamp = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Tenant_RefID { 
			get {
				return _Tenant_RefID;
			}
			set {
				if(_Tenant_RefID != value){
					_Tenant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDeleted { 
			get {
				return _IsDeleted;
			}
			set {
				if(_IsDeleted != value){
					_IsDeleted = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Modification_Timestamp { 
			get {
				return _Modification_Timestamp;
			}
			set {
				if(_Modification_Timestamp != value){
					_Modification_Timestamp = value;
					Status_IsDirty = true;
				}
			}
		} 
		 
		#endregion


		#region Save (Create/Update) Functions	
		public FR_Base Save(string DbConnectionString)
		{
			return Save(null, null, DbConnectionString);
		}

		public FR_Base Save(DbConnection Connection)
		{
			return Save(Connection, null, null);
		}

		public FR_Base Save(DbConnection Connection, DbTransaction Transaction)
		{
			return Save(Connection, Transaction, null);
		}

		protected FR_Base Save(DbConnection Connection, DbTransaction Transaction, string ConnectionString)
		{
			//Standard return type
			FR_Base retStatus = new FR_Base();

			bool cleanupConnection = false;
			bool cleanupTransaction = false;
			try
			{

				bool saveDictionary = false;
			    bool saveORMClass =   !Status_IsAlreadySaved || Status_IsDirty;


				//If Status Is Dirty (Meaning the data has been changed) or Status_IsAlreadySaved (Meaning the data is in the database, when loaded) just return
				if (saveORMClass == false && saveDictionary == false)
			    {
			        return FR_Base.Status_OK;
			    }


				#region Verify/Create Connections
				//Create Connection if Connection is null
				if (Connection == null)
				{
					cleanupConnection = true;
					Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
					Connection.Open();
				}

				//Create Transaction if null
				if (Transaction == null)
				{
					cleanupTransaction = true;
					Transaction = Connection.BeginTransaction();
				}

				#endregion

				#region Dictionary Management

				//Save dictionary management
				 if (saveDictionary == true)
				{ 
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					//Save the dictionary or update based on if it has already been saved to the database
					if (Status_IsAlreadySaved)
			        {
			            loader.Update();
			        }
			        else
			        {
			            loader.Save();
			        }
				}
				#endregion

				#region Command Execution
				if (saveORMClass == true) { 
					//Retrieve Querry
					string Query = "";

					if (Status_IsAlreadySaved == true)
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_ACT.HEC_ACT_PerformedAction_DiagnosisUpdate.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_ACT.HEC_ACT_PerformedAction_DiagnosisUpdate.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_ACT_PerformedAction_DiagnosisUpdateID", _HEC_ACT_PerformedAction_DiagnosisUpdateID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HealthcarePerformedAction_DiagnosisITL", _HealthcarePerformedAction_DiagnosisITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_ACT_PerformedAction_RefID", _HEC_ACT_PerformedAction_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_Patient_Diagnosis_RefID", _HEC_Patient_Diagnosis_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PotentialDiagnosis_RefID", _PotentialDiagnosis_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DiagnosisState_RefID", _DiagnosisState_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDiagnosisAssumed", _IsDiagnosisAssumed);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDiagnosisConfirmed", _IsDiagnosisConfirmed);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDiagnosisNegated", _IsDiagnosisNegated);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDiagnosisCreated", _IsDiagnosisCreated);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDiagnosisModified", _IsDiagnosisModified);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDiagnosisDeactivated", _IsDiagnosisDeactivated);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ScheduledExpiryDate", _ScheduledExpiryDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Deactivated_OnDate", _Deactivated_OnDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DeactivatedBy_Doctor_RefID", _DeactivatedBy_Doctor_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DiagnosisUpdateComment", _DiagnosisUpdateComment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IM_PotentialDiagnosis_Name", _IM_PotentialDiagnosis_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IM_PotentialDiagnosis_Code", _IM_PotentialDiagnosis_Code);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IM_PotentialDiagnosisCatalog_Name", _IM_PotentialDiagnosisCatalog_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IM_PotentialDiagnosisState_Name", _IM_PotentialDiagnosisState_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IM_DeactivatingDoctor_FullName", _IM_DeactivatingDoctor_FullName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Modification_Timestamp", _Modification_Timestamp);


					try
					{
						var dbChangeCount = command.ExecuteNonQuery();
						Status_IsAlreadySaved = true;
						Status_IsDirty = false;
					}
					catch (Exception ex)
					{
						throw;
					}
					#endregion

					#region Cleanup Transaction/Connection
					//If we started the transaction, we will commit it
					if (cleanupTransaction && Transaction!= null)
						Transaction.Commit();

					//If we opened the connection we will close it
					if (cleanupConnection && Connection != null)
						Connection.Close();
				}
				#endregion

			}
			catch (Exception ex)
			{
				try
				{
					if (cleanupTransaction == true && Transaction != null)
						Transaction.Rollback();
				}
				catch { }

				try
				{
					if (cleanupConnection == true && Connection != null)
						Connection.Close();
				}
				catch { }

				throw;
			}

			return retStatus;
		}
		#endregion

		#region Load Functions
		public FR_Base Load(string DbConnectionString, Guid ObjectID)
		{
			return Load(null, null, ObjectID, DbConnectionString);
		}

		public FR_Base Load(DbConnection Connection, Guid ObjectID)
		{
			return Load(Connection, null, ObjectID, null);
		}

		public FR_Base Load(DbConnection Connection, DbTransaction Transaction, Guid ObjectID)
		{
			return Load(Connection, Transaction, ObjectID, null);
		}

		private FR_Base Load(DbConnection Connection, DbTransaction Transaction, Guid ObjectID, string ConnectionString)
		{
			//Standard return type
			FR_Base retStatus = new FR_Base();

			bool cleanupConnection = false;
			bool cleanupTransaction = false;
			try
			{
				#region Verify/Create Connections
				//Create connection if Connection is null
				if(Connection == null)
				{
					cleanupConnection = true;
					Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
					Connection.Open();
				}
				//If transaction is not open/not valid
				if(Transaction == null)
				{
					cleanupTransaction = true;
					Transaction = Connection.BeginTransaction();
				}
				#endregion
				//Get the SelectQuerry
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_ACT.HEC_ACT_PerformedAction_DiagnosisUpdate.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_ACT_PerformedAction_DiagnosisUpdateID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_ACT_PerformedAction_DiagnosisUpdateID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_ACT_PerformedAction_DiagnosisUpdateID","HealthcarePerformedAction_DiagnosisITL","HEC_ACT_PerformedAction_RefID","HEC_Patient_Diagnosis_RefID","PotentialDiagnosis_RefID","DiagnosisState_RefID","IsDiagnosisAssumed","IsDiagnosisConfirmed","IsDiagnosisNegated","IsDiagnosisCreated","IsDiagnosisModified","IsDiagnosisDeactivated","ScheduledExpiryDate","Deactivated_OnDate","DeactivatedBy_Doctor_RefID","DiagnosisUpdateComment","IM_PotentialDiagnosis_Name","IM_PotentialDiagnosis_Code","IM_PotentialDiagnosisCatalog_Name","IM_PotentialDiagnosisState_Name","IM_DeactivatingDoctor_FullName","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_ACT_PerformedAction_DiagnosisUpdateID of type Guid
						_HEC_ACT_PerformedAction_DiagnosisUpdateID = reader.GetGuid(0);
						//1:Parameter HealthcarePerformedAction_DiagnosisITL of type String
						_HealthcarePerformedAction_DiagnosisITL = reader.GetString(1);
						//2:Parameter HEC_ACT_PerformedAction_RefID of type Guid
						_HEC_ACT_PerformedAction_RefID = reader.GetGuid(2);
						//3:Parameter HEC_Patient_Diagnosis_RefID of type Guid
						_HEC_Patient_Diagnosis_RefID = reader.GetGuid(3);
						//4:Parameter PotentialDiagnosis_RefID of type Guid
						_PotentialDiagnosis_RefID = reader.GetGuid(4);
						//5:Parameter DiagnosisState_RefID of type Guid
						_DiagnosisState_RefID = reader.GetGuid(5);
						//6:Parameter IsDiagnosisAssumed of type Boolean
						_IsDiagnosisAssumed = reader.GetBoolean(6);
						//7:Parameter IsDiagnosisConfirmed of type Boolean
						_IsDiagnosisConfirmed = reader.GetBoolean(7);
						//8:Parameter IsDiagnosisNegated of type Boolean
						_IsDiagnosisNegated = reader.GetBoolean(8);
						//9:Parameter IsDiagnosisCreated of type Boolean
						_IsDiagnosisCreated = reader.GetBoolean(9);
						//10:Parameter IsDiagnosisModified of type Boolean
						_IsDiagnosisModified = reader.GetBoolean(10);
						//11:Parameter IsDiagnosisDeactivated of type Boolean
						_IsDiagnosisDeactivated = reader.GetBoolean(11);
						//12:Parameter ScheduledExpiryDate of type DateTime
						_ScheduledExpiryDate = reader.GetDate(12);
						//13:Parameter Deactivated_OnDate of type DateTime
						_Deactivated_OnDate = reader.GetDate(13);
						//14:Parameter DeactivatedBy_Doctor_RefID of type Guid
						_DeactivatedBy_Doctor_RefID = reader.GetGuid(14);
						//15:Parameter DiagnosisUpdateComment of type String
						_DiagnosisUpdateComment = reader.GetString(15);
						//16:Parameter IM_PotentialDiagnosis_Name of type String
						_IM_PotentialDiagnosis_Name = reader.GetString(16);
						//17:Parameter IM_PotentialDiagnosis_Code of type String
						_IM_PotentialDiagnosis_Code = reader.GetString(17);
						//18:Parameter IM_PotentialDiagnosisCatalog_Name of type String
						_IM_PotentialDiagnosisCatalog_Name = reader.GetString(18);
						//19:Parameter IM_PotentialDiagnosisState_Name of type String
						_IM_PotentialDiagnosisState_Name = reader.GetString(19);
						//20:Parameter IM_DeactivatingDoctor_FullName of type String
						_IM_DeactivatingDoctor_FullName = reader.GetString(20);
						//21:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(21);
						//22:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(22);
						//23:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(23);
						//24:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(24);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_ACT_PerformedAction_DiagnosisUpdateID != Guid.Empty){
						//Successfully loaded
						Status_IsAlreadySaved = true;
						Status_IsDirty = false;
					} else {
						//Fault in loading due to invalid UUID (Guid)
						Status_IsAlreadySaved = false;
						Status_IsDirty = false;
					}
				}
				catch (Exception ex)
				{
					throw;
				}
				#endregion

				#region Cleanup Transaction/Connection
				//If we started the transaction, we will commit it
				if (cleanupTransaction && Transaction!= null)
					Transaction.Commit();

				//If we opened the connection we will close it
				if (cleanupConnection && Connection != null)
					Connection.Close();

				#endregion

			} catch (Exception ex) {
				try
				{
					if (cleanupTransaction == true && Transaction != null)
						Transaction.Rollback();
				}
				catch { }

				try
				{
					if (cleanupConnection == true && Connection != null)
						Connection.Close();
				}
				catch { }

				throw;
			}

			return retStatus;
		}
		#endregion

		#region Remove Functions
		public FR_Base Remove(string DbConnectionString)
		{
			return Remove(null, null, DbConnectionString);
		}

		public FR_Base Remove(DbConnection Connection)
		{
			return Remove(Connection, null, null);
		}

		public FR_Base Remove(DbConnection Connection, DbTransaction Transaction)
		{
			return Remove(Connection, Transaction, null);
		}

		public FR_Base Remove(DbConnection Connection, DbTransaction Transaction, string ConnectionString)
		{
			this.IsDeleted = true;
			return this.Save(Connection, Transaction, ConnectionString);

		}
		#endregion


		#region Custom Queries
		public class Query : CSV2Core_MySQL.BaseFilterQuery<Query>
        {
			public Guid? HEC_ACT_PerformedAction_DiagnosisUpdateID {	get; set; }
			public String HealthcarePerformedAction_DiagnosisITL {	get; set; }
			public Guid? HEC_ACT_PerformedAction_RefID {	get; set; }
			public Guid? HEC_Patient_Diagnosis_RefID {	get; set; }
			public Guid? PotentialDiagnosis_RefID {	get; set; }
			public Guid? DiagnosisState_RefID {	get; set; }
			public Boolean? IsDiagnosisAssumed {	get; set; }
			public Boolean? IsDiagnosisConfirmed {	get; set; }
			public Boolean? IsDiagnosisNegated {	get; set; }
			public Boolean? IsDiagnosisCreated {	get; set; }
			public Boolean? IsDiagnosisModified {	get; set; }
			public Boolean? IsDiagnosisDeactivated {	get; set; }
			public DateTime? ScheduledExpiryDate {	get; set; }
			public DateTime? Deactivated_OnDate {	get; set; }
			public Guid? DeactivatedBy_Doctor_RefID {	get; set; }
			public String DiagnosisUpdateComment {	get; set; }
			public String IM_PotentialDiagnosis_Name {	get; set; }
			public String IM_PotentialDiagnosis_Code {	get; set; }
			public String IM_PotentialDiagnosisCatalog_Name {	get; set; }
			public String IM_PotentialDiagnosisState_Name {	get; set; }
			public String IM_DeactivatingDoctor_FullName {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			public DateTime? Modification_Timestamp {	get; set; }
			 

			#region Exists
			public static bool Exists(string connectionString, Query query)
			{
			    return Query.Exists(query, connectionString, null, null);
			}

			public static bool Exists(DbConnection connection, Query query)
			{
			    return Query.Exists(query, null, connection, null);
			}

			public static bool Exists(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Exists(query, null, connection, transaction);
			}

			private static bool Exists(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
				try
				{
					managedConnection.set(connectionString, connection, transaction);
					DbCommand command = managedConnection.manage(query.CreateExistsQuery(TableName));
					query.SetParameters(command);

					var reader = command.ExecuteReader();
					reader.Read();
					int resultCount = reader.GetInt32(0);
					reader.Close();
					managedConnection.commit();
					return resultCount == 1;
				} 
				catch(Exception ex)
				{
					managedConnection.rollback();
					throw;
				}
			}
			#endregion

			#region Search
			public static List<ORM_HEC_ACT_PerformedAction_DiagnosisUpdate> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_ACT_PerformedAction_DiagnosisUpdate> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_ACT_PerformedAction_DiagnosisUpdate> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_ACT_PerformedAction_DiagnosisUpdate> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_ACT_PerformedAction_DiagnosisUpdate> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_ACT_PerformedAction_DiagnosisUpdate>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_ACT_PerformedAction_DiagnosisUpdateID","HealthcarePerformedAction_DiagnosisITL","HEC_ACT_PerformedAction_RefID","HEC_Patient_Diagnosis_RefID","PotentialDiagnosis_RefID","DiagnosisState_RefID","IsDiagnosisAssumed","IsDiagnosisConfirmed","IsDiagnosisNegated","IsDiagnosisCreated","IsDiagnosisModified","IsDiagnosisDeactivated","ScheduledExpiryDate","Deactivated_OnDate","DeactivatedBy_Doctor_RefID","DiagnosisUpdateComment","IM_PotentialDiagnosis_Name","IM_PotentialDiagnosis_Code","IM_PotentialDiagnosisCatalog_Name","IM_PotentialDiagnosisState_Name","IM_DeactivatingDoctor_FullName","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_ACT_PerformedAction_DiagnosisUpdate item = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate();
						//0:Parameter HEC_ACT_PerformedAction_DiagnosisUpdateID of type Guid
						item.HEC_ACT_PerformedAction_DiagnosisUpdateID = reader.GetGuid(0);
						//1:Parameter HealthcarePerformedAction_DiagnosisITL of type String
						item.HealthcarePerformedAction_DiagnosisITL = reader.GetString(1);
						//2:Parameter HEC_ACT_PerformedAction_RefID of type Guid
						item.HEC_ACT_PerformedAction_RefID = reader.GetGuid(2);
						//3:Parameter HEC_Patient_Diagnosis_RefID of type Guid
						item.HEC_Patient_Diagnosis_RefID = reader.GetGuid(3);
						//4:Parameter PotentialDiagnosis_RefID of type Guid
						item.PotentialDiagnosis_RefID = reader.GetGuid(4);
						//5:Parameter DiagnosisState_RefID of type Guid
						item.DiagnosisState_RefID = reader.GetGuid(5);
						//6:Parameter IsDiagnosisAssumed of type Boolean
						item.IsDiagnosisAssumed = reader.GetBoolean(6);
						//7:Parameter IsDiagnosisConfirmed of type Boolean
						item.IsDiagnosisConfirmed = reader.GetBoolean(7);
						//8:Parameter IsDiagnosisNegated of type Boolean
						item.IsDiagnosisNegated = reader.GetBoolean(8);
						//9:Parameter IsDiagnosisCreated of type Boolean
						item.IsDiagnosisCreated = reader.GetBoolean(9);
						//10:Parameter IsDiagnosisModified of type Boolean
						item.IsDiagnosisModified = reader.GetBoolean(10);
						//11:Parameter IsDiagnosisDeactivated of type Boolean
						item.IsDiagnosisDeactivated = reader.GetBoolean(11);
						//12:Parameter ScheduledExpiryDate of type DateTime
						item.ScheduledExpiryDate = reader.GetDate(12);
						//13:Parameter Deactivated_OnDate of type DateTime
						item.Deactivated_OnDate = reader.GetDate(13);
						//14:Parameter DeactivatedBy_Doctor_RefID of type Guid
						item.DeactivatedBy_Doctor_RefID = reader.GetGuid(14);
						//15:Parameter DiagnosisUpdateComment of type String
						item.DiagnosisUpdateComment = reader.GetString(15);
						//16:Parameter IM_PotentialDiagnosis_Name of type String
						item.IM_PotentialDiagnosis_Name = reader.GetString(16);
						//17:Parameter IM_PotentialDiagnosis_Code of type String
						item.IM_PotentialDiagnosis_Code = reader.GetString(17);
						//18:Parameter IM_PotentialDiagnosisCatalog_Name of type String
						item.IM_PotentialDiagnosisCatalog_Name = reader.GetString(18);
						//19:Parameter IM_PotentialDiagnosisState_Name of type String
						item.IM_PotentialDiagnosisState_Name = reader.GetString(19);
						//20:Parameter IM_DeactivatingDoctor_FullName of type String
						item.IM_DeactivatingDoctor_FullName = reader.GetString(20);
						//21:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(21);
						//22:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(22);
						//23:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(23);
						//24:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(24);


						item.Status_IsAlreadySaved = true;
			            item.Status_IsDirty = false;
			            items.Add(item);
			        }
			        reader.Close();
			        loader.Load();
			        managedConnection.commit();
			    }
			    catch (Exception ex)
			    {
			        managedConnection.rollback();
			        throw;
			    }
			    return items;
			}
			#endregion

			#region Update
			public static int Update(string connectionString, Query query, Query values)
			{
			    return Query.Update(query, values, connectionString, null, null);
			}

			public static int Update(DbConnection connection, Query query, Query values)
			{
			    return Query.Update(query, values, null, connection, null);
			}

			public static int Update(DbConnection connection, DbTransaction transaction, Query query, Query values)
			{
			    return Query.Update(query, values, null, connection, transaction);
			}

			private static int Update(Query query, Query values, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
				try
				{
					managedConnection.set(connectionString, connection, transaction);
					DbCommand command = managedConnection.manage(query.CreateUpdateQuery(TableName,values.CreateSetStatement()));
					query.SetParameters(command);
					values.SetUpdateValues(command);
					int result = command.ExecuteNonQuery();
					managedConnection.commit();
					return result;
				} 
				catch(Exception ex)
				{
					managedConnection.rollback();
					throw;
				}
			}
			#endregion

			#region Soft Recover
			public static int SoftRecover(string connectionString, Query query)
			{
			    return Query.SoftRecover(query, connectionString, null, null);
			}

			public static int SoftRecover(DbConnection connection, Query query)
			{
			    return Query.SoftRecover(query, null, connection, null);
			}

			public static int SoftRecover(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.SoftRecover(query, null, connection, transaction);
			}

			private static int SoftRecover(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
				try
				{
					managedConnection.set(connectionString, connection, transaction);
					DbCommand command = managedConnection.manage(query.CreateSoftDeleteQuery(TableName,false));
					query.SetParameters(command);
					int result = command.ExecuteNonQuery();
					managedConnection.commit();
					return result;
				} 
				catch(Exception ex)
				{
					managedConnection.rollback();
					throw;
				}
			}
			#endregion

			#region Soft Delete
			public static int SoftDelete(string connectionString, Query query)
			{
			    return Query.SoftDelete(query, connectionString, null, null);
			}

			public static int SoftDelete(DbConnection connection, Query query)
			{
			    return Query.SoftDelete(query, null, connection, null);
			}

			public static int SoftDelete(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.SoftDelete(query, null, connection, transaction);
			}

			private static int SoftDelete(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
				try
				{
					managedConnection.set(connectionString, connection, transaction);
					DbCommand command = managedConnection.manage(query.CreateSoftDeleteQuery(TableName,true));
					query.SetParameters(command);
					int result = command.ExecuteNonQuery();
					managedConnection.commit();
					return result;
				} 
				catch(Exception ex)
				{
					managedConnection.rollback();
					throw;
				}
			}
			#endregion			
		}
		#endregion
	}	
}
