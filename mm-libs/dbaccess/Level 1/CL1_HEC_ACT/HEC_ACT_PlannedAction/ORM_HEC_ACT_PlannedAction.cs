/* 
 * Generated on 05/28/15 13:59:30
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
	public class ORM_HEC_ACT_PlannedAction
	{
		public static readonly string TableName = "hec_act_plannedactions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
        public static readonly int QueryTimeout = 6000;

		#region Class Constructor
		public ORM_HEC_ACT_PlannedAction()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_ACT_PlannedActionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_ACT_PlannedActionID = default(Guid);
		private String _HealthcarePlannedActionITL = default(String);
		private Guid _Patient_RefID = default(Guid);
		private Guid _Appointment_RefID = default(Guid);
		private DateTime _PlannedFor_Date = default(DateTime);
		private Boolean _IsPerformed = default(Boolean);
		private Guid _IfPerformed_PerformedAction_RefID = default(Guid);
		private Boolean _IsToBePerformedExternally = default(Boolean);
		private Guid _MedicalPractice_RefID = default(Guid);
		private Guid _MedicalPracticeType_RefID = default(Guid);
		private Guid _ToBePerformedBy_BusinessParticipant_RefID = default(Guid);
		private Boolean _IsPlannedFollowup = default(Boolean);
		private Guid _IfPlannedFollowup_PreviousAction_RefID = default(Guid);
		private Boolean _IsCancelled = default(Boolean);
		private String _IfCancelled_Reason = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_ACT_PlannedActionID { 
			get {
				return _HEC_ACT_PlannedActionID;
			}
			set {
				if(_HEC_ACT_PlannedActionID != value){
					_HEC_ACT_PlannedActionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String HealthcarePlannedActionITL { 
			get {
				return _HealthcarePlannedActionITL;
			}
			set {
				if(_HealthcarePlannedActionITL != value){
					_HealthcarePlannedActionITL = value;
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
		public Guid Appointment_RefID { 
			get {
				return _Appointment_RefID;
			}
			set {
				if(_Appointment_RefID != value){
					_Appointment_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime PlannedFor_Date { 
			get {
				return _PlannedFor_Date;
			}
			set {
				if(_PlannedFor_Date != value){
					_PlannedFor_Date = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPerformed { 
			get {
				return _IsPerformed;
			}
			set {
				if(_IsPerformed != value){
					_IsPerformed = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfPerformed_PerformedAction_RefID { 
			get {
				return _IfPerformed_PerformedAction_RefID;
			}
			set {
				if(_IfPerformed_PerformedAction_RefID != value){
					_IfPerformed_PerformedAction_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsToBePerformedExternally { 
			get {
				return _IsToBePerformedExternally;
			}
			set {
				if(_IsToBePerformedExternally != value){
					_IsToBePerformedExternally = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid MedicalPractice_RefID { 
			get {
				return _MedicalPractice_RefID;
			}
			set {
				if(_MedicalPractice_RefID != value){
					_MedicalPractice_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid MedicalPracticeType_RefID { 
			get {
				return _MedicalPracticeType_RefID;
			}
			set {
				if(_MedicalPracticeType_RefID != value){
					_MedicalPracticeType_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ToBePerformedBy_BusinessParticipant_RefID { 
			get {
				return _ToBePerformedBy_BusinessParticipant_RefID;
			}
			set {
				if(_ToBePerformedBy_BusinessParticipant_RefID != value){
					_ToBePerformedBy_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPlannedFollowup { 
			get {
				return _IsPlannedFollowup;
			}
			set {
				if(_IsPlannedFollowup != value){
					_IsPlannedFollowup = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfPlannedFollowup_PreviousAction_RefID { 
			get {
				return _IfPlannedFollowup_PreviousAction_RefID;
			}
			set {
				if(_IfPlannedFollowup_PreviousAction_RefID != value){
					_IfPlannedFollowup_PreviousAction_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCancelled { 
			get {
				return _IsCancelled;
			}
			set {
				if(_IsCancelled != value){
					_IsCancelled = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IfCancelled_Reason { 
			get {
				return _IfCancelled_Reason;
			}
			set {
				if(_IfCancelled_Reason != value){
					_IfCancelled_Reason = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_ACT.HEC_ACT_PlannedAction.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_ACT.HEC_ACT_PlannedAction.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_ACT_PlannedActionID", _HEC_ACT_PlannedActionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HealthcarePlannedActionITL", _HealthcarePlannedActionITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Patient_RefID", _Patient_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Appointment_RefID", _Appointment_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PlannedFor_Date", _PlannedFor_Date);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPerformed", _IsPerformed);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfPerformed_PerformedAction_RefID", _IfPerformed_PerformedAction_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsToBePerformedExternally", _IsToBePerformedExternally);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "MedicalPractice_RefID", _MedicalPractice_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "MedicalPracticeType_RefID", _MedicalPracticeType_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ToBePerformedBy_BusinessParticipant_RefID", _ToBePerformedBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPlannedFollowup", _IsPlannedFollowup);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfPlannedFollowup_PreviousAction_RefID", _IfPlannedFollowup_PreviousAction_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCancelled", _IsCancelled);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfCancelled_Reason", _IfCancelled_Reason);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_ACT.HEC_ACT_PlannedAction.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_ACT_PlannedActionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_ACT_PlannedActionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_ACT_PlannedActionID","HealthcarePlannedActionITL","Patient_RefID","Appointment_RefID","PlannedFor_Date","IsPerformed","IfPerformed_PerformedAction_RefID","IsToBePerformedExternally","MedicalPractice_RefID","MedicalPracticeType_RefID","ToBePerformedBy_BusinessParticipant_RefID","IsPlannedFollowup","IfPlannedFollowup_PreviousAction_RefID","IsCancelled","IfCancelled_Reason","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_ACT_PlannedActionID of type Guid
						_HEC_ACT_PlannedActionID = reader.GetGuid(0);
						//1:Parameter HealthcarePlannedActionITL of type String
						_HealthcarePlannedActionITL = reader.GetString(1);
						//2:Parameter Patient_RefID of type Guid
						_Patient_RefID = reader.GetGuid(2);
						//3:Parameter Appointment_RefID of type Guid
						_Appointment_RefID = reader.GetGuid(3);
						//4:Parameter PlannedFor_Date of type DateTime
						_PlannedFor_Date = reader.GetDate(4);
						//5:Parameter IsPerformed of type Boolean
						_IsPerformed = reader.GetBoolean(5);
						//6:Parameter IfPerformed_PerformedAction_RefID of type Guid
						_IfPerformed_PerformedAction_RefID = reader.GetGuid(6);
						//7:Parameter IsToBePerformedExternally of type Boolean
						_IsToBePerformedExternally = reader.GetBoolean(7);
						//8:Parameter MedicalPractice_RefID of type Guid
						_MedicalPractice_RefID = reader.GetGuid(8);
						//9:Parameter MedicalPracticeType_RefID of type Guid
						_MedicalPracticeType_RefID = reader.GetGuid(9);
						//10:Parameter ToBePerformedBy_BusinessParticipant_RefID of type Guid
						_ToBePerformedBy_BusinessParticipant_RefID = reader.GetGuid(10);
						//11:Parameter IsPlannedFollowup of type Boolean
						_IsPlannedFollowup = reader.GetBoolean(11);
						//12:Parameter IfPlannedFollowup_PreviousAction_RefID of type Guid
						_IfPlannedFollowup_PreviousAction_RefID = reader.GetGuid(12);
						//13:Parameter IsCancelled of type Boolean
						_IsCancelled = reader.GetBoolean(13);
						//14:Parameter IfCancelled_Reason of type String
						_IfCancelled_Reason = reader.GetString(14);
						//15:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(15);
						//16:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(16);
						//17:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(17);
						//18:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(18);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_ACT_PlannedActionID != Guid.Empty){
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
			public Guid? HEC_ACT_PlannedActionID {	get; set; }
			public String HealthcarePlannedActionITL {	get; set; }
			public Guid? Patient_RefID {	get; set; }
			public Guid? Appointment_RefID {	get; set; }
			public DateTime? PlannedFor_Date {	get; set; }
			public Boolean? IsPerformed {	get; set; }
			public Guid? IfPerformed_PerformedAction_RefID {	get; set; }
			public Boolean? IsToBePerformedExternally {	get; set; }
			public Guid? MedicalPractice_RefID {	get; set; }
			public Guid? MedicalPracticeType_RefID {	get; set; }
			public Guid? ToBePerformedBy_BusinessParticipant_RefID {	get; set; }
			public Boolean? IsPlannedFollowup {	get; set; }
			public Guid? IfPlannedFollowup_PreviousAction_RefID {	get; set; }
			public Boolean? IsCancelled {	get; set; }
			public String IfCancelled_Reason {	get; set; }
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
			public static List<ORM_HEC_ACT_PlannedAction> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_ACT_PlannedAction> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_ACT_PlannedAction> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_ACT_PlannedAction> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_ACT_PlannedAction> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_ACT_PlannedAction>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_ACT_PlannedActionID","HealthcarePlannedActionITL","Patient_RefID","Appointment_RefID","PlannedFor_Date","IsPerformed","IfPerformed_PerformedAction_RefID","IsToBePerformedExternally","MedicalPractice_RefID","MedicalPracticeType_RefID","ToBePerformedBy_BusinessParticipant_RefID","IsPlannedFollowup","IfPlannedFollowup_PreviousAction_RefID","IsCancelled","IfCancelled_Reason","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_ACT_PlannedAction item = new ORM_HEC_ACT_PlannedAction();
						//0:Parameter HEC_ACT_PlannedActionID of type Guid
						item.HEC_ACT_PlannedActionID = reader.GetGuid(0);
						//1:Parameter HealthcarePlannedActionITL of type String
						item.HealthcarePlannedActionITL = reader.GetString(1);
						//2:Parameter Patient_RefID of type Guid
						item.Patient_RefID = reader.GetGuid(2);
						//3:Parameter Appointment_RefID of type Guid
						item.Appointment_RefID = reader.GetGuid(3);
						//4:Parameter PlannedFor_Date of type DateTime
						item.PlannedFor_Date = reader.GetDate(4);
						//5:Parameter IsPerformed of type Boolean
						item.IsPerformed = reader.GetBoolean(5);
						//6:Parameter IfPerformed_PerformedAction_RefID of type Guid
						item.IfPerformed_PerformedAction_RefID = reader.GetGuid(6);
						//7:Parameter IsToBePerformedExternally of type Boolean
						item.IsToBePerformedExternally = reader.GetBoolean(7);
						//8:Parameter MedicalPractice_RefID of type Guid
						item.MedicalPractice_RefID = reader.GetGuid(8);
						//9:Parameter MedicalPracticeType_RefID of type Guid
						item.MedicalPracticeType_RefID = reader.GetGuid(9);
						//10:Parameter ToBePerformedBy_BusinessParticipant_RefID of type Guid
						item.ToBePerformedBy_BusinessParticipant_RefID = reader.GetGuid(10);
						//11:Parameter IsPlannedFollowup of type Boolean
						item.IsPlannedFollowup = reader.GetBoolean(11);
						//12:Parameter IfPlannedFollowup_PreviousAction_RefID of type Guid
						item.IfPlannedFollowup_PreviousAction_RefID = reader.GetGuid(12);
						//13:Parameter IsCancelled of type Boolean
						item.IsCancelled = reader.GetBoolean(13);
						//14:Parameter IfCancelled_Reason of type String
						item.IfCancelled_Reason = reader.GetString(14);
						//15:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(15);
						//16:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(16);
						//17:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(17);
						//18:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(18);


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
