/* 
 * Generated on 06/16/15 11:31:59
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
	public class ORM_HEC_ACT_PerformedAction
	{
		public static readonly string TableName = "hec_act_performedactions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_ACT_PerformedAction()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_ACT_PerformedActionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_ACT_PerformedActionID = default(Guid);
		private String _HealthcarePerformedActionITL = default(String);
		private Guid _Patient_RefID = default(Guid);
		private Boolean _IsPerformed_Internally = default(Boolean);
		private Guid _IfPerformedInternaly_ResponsibleBusinessParticipant_RefID = default(Guid);
		private Boolean _IsPerformed_Externally = default(Boolean);
		private Guid _IsPerformed_MedicalPractice_RefID = default(Guid);
		private Guid _IfPerformed_MedicalPracticeType_RefID = default(Guid);
		private int _IfPerformed_DateOfAction_Year = default(int);
		private int _IfPerformed_DateOfAction_Month = default(int);
		private int _IfPerformed_DateOfAction_Day = default(int);
		private DateTime _IfPerfomed_DateOfAction = default(DateTime);
		private Boolean _IsFollowupPerformedAction = default(Boolean);
		private Guid _IsFollowupPerformed_PreviousPerformedAction_RefID = default(Guid);
		private Boolean _IsFinalized = default(Boolean);
		private String _IM_IfPerformed_MedicalPractice_Name = default(String);
		private String _IM_IfPerformed_MedicalPracticeType_Name = default(String);
		private String _IM_IfPerformed_ResponsibleBP_FullName = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_ACT_PerformedActionID { 
			get {
				return _HEC_ACT_PerformedActionID;
			}
			set {
				if(_HEC_ACT_PerformedActionID != value){
					_HEC_ACT_PerformedActionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String HealthcarePerformedActionITL { 
			get {
				return _HealthcarePerformedActionITL;
			}
			set {
				if(_HealthcarePerformedActionITL != value){
					_HealthcarePerformedActionITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Patient_RefID { 
			get {
				return _Patient_RefID;
			}
			set {
				if(_Patient_RefID != value){
					_Patient_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPerformed_Internally { 
			get {
				return _IsPerformed_Internally;
			}
			set {
				if(_IsPerformed_Internally != value){
					_IsPerformed_Internally = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfPerformedInternaly_ResponsibleBusinessParticipant_RefID { 
			get {
				return _IfPerformedInternaly_ResponsibleBusinessParticipant_RefID;
			}
			set {
				if(_IfPerformedInternaly_ResponsibleBusinessParticipant_RefID != value){
					_IfPerformedInternaly_ResponsibleBusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPerformed_Externally { 
			get {
				return _IsPerformed_Externally;
			}
			set {
				if(_IsPerformed_Externally != value){
					_IsPerformed_Externally = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IsPerformed_MedicalPractice_RefID { 
			get {
				return _IsPerformed_MedicalPractice_RefID;
			}
			set {
				if(_IsPerformed_MedicalPractice_RefID != value){
					_IsPerformed_MedicalPractice_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfPerformed_MedicalPracticeType_RefID { 
			get {
				return _IfPerformed_MedicalPracticeType_RefID;
			}
			set {
				if(_IfPerformed_MedicalPracticeType_RefID != value){
					_IfPerformed_MedicalPracticeType_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int IfPerformed_DateOfAction_Year { 
			get {
				return _IfPerformed_DateOfAction_Year;
			}
			set {
				if(_IfPerformed_DateOfAction_Year != value){
					_IfPerformed_DateOfAction_Year = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int IfPerformed_DateOfAction_Month { 
			get {
				return _IfPerformed_DateOfAction_Month;
			}
			set {
				if(_IfPerformed_DateOfAction_Month != value){
					_IfPerformed_DateOfAction_Month = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int IfPerformed_DateOfAction_Day { 
			get {
				return _IfPerformed_DateOfAction_Day;
			}
			set {
				if(_IfPerformed_DateOfAction_Day != value){
					_IfPerformed_DateOfAction_Day = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime IfPerfomed_DateOfAction { 
			get {
				return _IfPerfomed_DateOfAction;
			}
			set {
				if(_IfPerfomed_DateOfAction != value){
					_IfPerfomed_DateOfAction = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsFollowupPerformedAction { 
			get {
				return _IsFollowupPerformedAction;
			}
			set {
				if(_IsFollowupPerformedAction != value){
					_IsFollowupPerformedAction = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IsFollowupPerformed_PreviousPerformedAction_RefID { 
			get {
				return _IsFollowupPerformed_PreviousPerformedAction_RefID;
			}
			set {
				if(_IsFollowupPerformed_PreviousPerformedAction_RefID != value){
					_IsFollowupPerformed_PreviousPerformedAction_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsFinalized { 
			get {
				return _IsFinalized;
			}
			set {
				if(_IsFinalized != value){
					_IsFinalized = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IM_IfPerformed_MedicalPractice_Name { 
			get {
				return _IM_IfPerformed_MedicalPractice_Name;
			}
			set {
				if(_IM_IfPerformed_MedicalPractice_Name != value){
					_IM_IfPerformed_MedicalPractice_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IM_IfPerformed_MedicalPracticeType_Name { 
			get {
				return _IM_IfPerformed_MedicalPracticeType_Name;
			}
			set {
				if(_IM_IfPerformed_MedicalPracticeType_Name != value){
					_IM_IfPerformed_MedicalPracticeType_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IM_IfPerformed_ResponsibleBP_FullName { 
			get {
				return _IM_IfPerformed_ResponsibleBP_FullName;
			}
			set {
				if(_IM_IfPerformed_ResponsibleBP_FullName != value){
					_IM_IfPerformed_ResponsibleBP_FullName = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_ACT.HEC_ACT_PerformedAction.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_ACT.HEC_ACT_PerformedAction.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_ACT_PerformedActionID", _HEC_ACT_PerformedActionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HealthcarePerformedActionITL", _HealthcarePerformedActionITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Patient_RefID", _Patient_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPerformed_Internally", _IsPerformed_Internally);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfPerformedInternaly_ResponsibleBusinessParticipant_RefID", _IfPerformedInternaly_ResponsibleBusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPerformed_Externally", _IsPerformed_Externally);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPerformed_MedicalPractice_RefID", _IsPerformed_MedicalPractice_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfPerformed_MedicalPracticeType_RefID", _IfPerformed_MedicalPracticeType_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfPerformed_DateOfAction_Year", _IfPerformed_DateOfAction_Year);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfPerformed_DateOfAction_Month", _IfPerformed_DateOfAction_Month);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfPerformed_DateOfAction_Day", _IfPerformed_DateOfAction_Day);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfPerfomed_DateOfAction", _IfPerfomed_DateOfAction);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsFollowupPerformedAction", _IsFollowupPerformedAction);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsFollowupPerformed_PreviousPerformedAction_RefID", _IsFollowupPerformed_PreviousPerformedAction_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsFinalized", _IsFinalized);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IM_IfPerformed_MedicalPractice_Name", _IM_IfPerformed_MedicalPractice_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IM_IfPerformed_MedicalPracticeType_Name", _IM_IfPerformed_MedicalPracticeType_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IM_IfPerformed_ResponsibleBP_FullName", _IM_IfPerformed_ResponsibleBP_FullName);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_ACT.HEC_ACT_PerformedAction.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_ACT_PerformedActionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_ACT_PerformedActionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_ACT_PerformedActionID","HealthcarePerformedActionITL","Patient_RefID","IsPerformed_Internally","IfPerformedInternaly_ResponsibleBusinessParticipant_RefID","IsPerformed_Externally","IsPerformed_MedicalPractice_RefID","IfPerformed_MedicalPracticeType_RefID","IfPerformed_DateOfAction_Year","IfPerformed_DateOfAction_Month","IfPerformed_DateOfAction_Day","IfPerfomed_DateOfAction","IsFollowupPerformedAction","IsFollowupPerformed_PreviousPerformedAction_RefID","IsFinalized","IM_IfPerformed_MedicalPractice_Name","IM_IfPerformed_MedicalPracticeType_Name","IM_IfPerformed_ResponsibleBP_FullName","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_ACT_PerformedActionID of type Guid
						_HEC_ACT_PerformedActionID = reader.GetGuid(0);
						//1:Parameter HealthcarePerformedActionITL of type String
						_HealthcarePerformedActionITL = reader.GetString(1);
						//2:Parameter Patient_RefID of type Guid
						_Patient_RefID = reader.GetGuid(2);
						//3:Parameter IsPerformed_Internally of type Boolean
						_IsPerformed_Internally = reader.GetBoolean(3);
						//4:Parameter IfPerformedInternaly_ResponsibleBusinessParticipant_RefID of type Guid
						_IfPerformedInternaly_ResponsibleBusinessParticipant_RefID = reader.GetGuid(4);
						//5:Parameter IsPerformed_Externally of type Boolean
						_IsPerformed_Externally = reader.GetBoolean(5);
						//6:Parameter IsPerformed_MedicalPractice_RefID of type Guid
						_IsPerformed_MedicalPractice_RefID = reader.GetGuid(6);
						//7:Parameter IfPerformed_MedicalPracticeType_RefID of type Guid
						_IfPerformed_MedicalPracticeType_RefID = reader.GetGuid(7);
						//8:Parameter IfPerformed_DateOfAction_Year of type int
						_IfPerformed_DateOfAction_Year = reader.GetInteger(8);
						//9:Parameter IfPerformed_DateOfAction_Month of type int
						_IfPerformed_DateOfAction_Month = reader.GetInteger(9);
						//10:Parameter IfPerformed_DateOfAction_Day of type int
						_IfPerformed_DateOfAction_Day = reader.GetInteger(10);
						//11:Parameter IfPerfomed_DateOfAction of type DateTime
						_IfPerfomed_DateOfAction = reader.GetDate(11);
						//12:Parameter IsFollowupPerformedAction of type Boolean
						_IsFollowupPerformedAction = reader.GetBoolean(12);
						//13:Parameter IsFollowupPerformed_PreviousPerformedAction_RefID of type Guid
						_IsFollowupPerformed_PreviousPerformedAction_RefID = reader.GetGuid(13);
						//14:Parameter IsFinalized of type Boolean
						_IsFinalized = reader.GetBoolean(14);
						//15:Parameter IM_IfPerformed_MedicalPractice_Name of type String
						_IM_IfPerformed_MedicalPractice_Name = reader.GetString(15);
						//16:Parameter IM_IfPerformed_MedicalPracticeType_Name of type String
						_IM_IfPerformed_MedicalPracticeType_Name = reader.GetString(16);
						//17:Parameter IM_IfPerformed_ResponsibleBP_FullName of type String
						_IM_IfPerformed_ResponsibleBP_FullName = reader.GetString(17);
						//18:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(18);
						//19:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(19);
						//20:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(20);
						//21:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(21);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_ACT_PerformedActionID != Guid.Empty){
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
			public Guid? HEC_ACT_PerformedActionID {	get; set; }
			public String HealthcarePerformedActionITL {	get; set; }
			public Guid? Patient_RefID {	get; set; }
			public Boolean? IsPerformed_Internally {	get; set; }
			public Guid? IfPerformedInternaly_ResponsibleBusinessParticipant_RefID {	get; set; }
			public Boolean? IsPerformed_Externally {	get; set; }
			public Guid? IsPerformed_MedicalPractice_RefID {	get; set; }
			public Guid? IfPerformed_MedicalPracticeType_RefID {	get; set; }
			public int? IfPerformed_DateOfAction_Year {	get; set; }
			public int? IfPerformed_DateOfAction_Month {	get; set; }
			public int? IfPerformed_DateOfAction_Day {	get; set; }
			public DateTime? IfPerfomed_DateOfAction {	get; set; }
			public Boolean? IsFollowupPerformedAction {	get; set; }
			public Guid? IsFollowupPerformed_PreviousPerformedAction_RefID {	get; set; }
			public Boolean? IsFinalized {	get; set; }
			public String IM_IfPerformed_MedicalPractice_Name {	get; set; }
			public String IM_IfPerformed_MedicalPracticeType_Name {	get; set; }
			public String IM_IfPerformed_ResponsibleBP_FullName {	get; set; }
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
			public static List<ORM_HEC_ACT_PerformedAction> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_ACT_PerformedAction> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_ACT_PerformedAction> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_ACT_PerformedAction> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_ACT_PerformedAction> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_ACT_PerformedAction>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_ACT_PerformedActionID","HealthcarePerformedActionITL","Patient_RefID","IsPerformed_Internally","IfPerformedInternaly_ResponsibleBusinessParticipant_RefID","IsPerformed_Externally","IsPerformed_MedicalPractice_RefID","IfPerformed_MedicalPracticeType_RefID","IfPerformed_DateOfAction_Year","IfPerformed_DateOfAction_Month","IfPerformed_DateOfAction_Day","IfPerfomed_DateOfAction","IsFollowupPerformedAction","IsFollowupPerformed_PreviousPerformedAction_RefID","IsFinalized","IM_IfPerformed_MedicalPractice_Name","IM_IfPerformed_MedicalPracticeType_Name","IM_IfPerformed_ResponsibleBP_FullName","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_ACT_PerformedAction item = new ORM_HEC_ACT_PerformedAction();
						//0:Parameter HEC_ACT_PerformedActionID of type Guid
						item.HEC_ACT_PerformedActionID = reader.GetGuid(0);
						//1:Parameter HealthcarePerformedActionITL of type String
						item.HealthcarePerformedActionITL = reader.GetString(1);
						//2:Parameter Patient_RefID of type Guid
						item.Patient_RefID = reader.GetGuid(2);
						//3:Parameter IsPerformed_Internally of type Boolean
						item.IsPerformed_Internally = reader.GetBoolean(3);
						//4:Parameter IfPerformedInternaly_ResponsibleBusinessParticipant_RefID of type Guid
						item.IfPerformedInternaly_ResponsibleBusinessParticipant_RefID = reader.GetGuid(4);
						//5:Parameter IsPerformed_Externally of type Boolean
						item.IsPerformed_Externally = reader.GetBoolean(5);
						//6:Parameter IsPerformed_MedicalPractice_RefID of type Guid
						item.IsPerformed_MedicalPractice_RefID = reader.GetGuid(6);
						//7:Parameter IfPerformed_MedicalPracticeType_RefID of type Guid
						item.IfPerformed_MedicalPracticeType_RefID = reader.GetGuid(7);
						//8:Parameter IfPerformed_DateOfAction_Year of type int
						item.IfPerformed_DateOfAction_Year = reader.GetInteger(8);
						//9:Parameter IfPerformed_DateOfAction_Month of type int
						item.IfPerformed_DateOfAction_Month = reader.GetInteger(9);
						//10:Parameter IfPerformed_DateOfAction_Day of type int
						item.IfPerformed_DateOfAction_Day = reader.GetInteger(10);
						//11:Parameter IfPerfomed_DateOfAction of type DateTime
						item.IfPerfomed_DateOfAction = reader.GetDate(11);
						//12:Parameter IsFollowupPerformedAction of type Boolean
						item.IsFollowupPerformedAction = reader.GetBoolean(12);
						//13:Parameter IsFollowupPerformed_PreviousPerformedAction_RefID of type Guid
						item.IsFollowupPerformed_PreviousPerformedAction_RefID = reader.GetGuid(13);
						//14:Parameter IsFinalized of type Boolean
						item.IsFinalized = reader.GetBoolean(14);
						//15:Parameter IM_IfPerformed_MedicalPractice_Name of type String
						item.IM_IfPerformed_MedicalPractice_Name = reader.GetString(15);
						//16:Parameter IM_IfPerformed_MedicalPracticeType_Name of type String
						item.IM_IfPerformed_MedicalPracticeType_Name = reader.GetString(16);
						//17:Parameter IM_IfPerformed_ResponsibleBP_FullName of type String
						item.IM_IfPerformed_ResponsibleBP_FullName = reader.GetString(17);
						//18:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(18);
						//19:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(19);
						//20:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(20);
						//21:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(21);


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
