/* 
 * Generated on 10/15/2013 10:29:44 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_TMS_PRO
{
	[Serializable]
	public class ORM_TMS_PRO_DeveloperTask
	{
		public static readonly string TableName = "tms_pro_developertasks";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_TMS_PRO_DeveloperTask()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_TMS_PRO_DeveloperTaskID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _TMS_PRO_DeveloperTaskID = default(Guid);
		private String _IdentificationNumber = default(String);
		private Guid _DOC_Structure_Header_RefID = default(Guid);
		private Guid _CreatedBy_ProjectMember_RefID = default(Guid);
		private Guid _Priority_RefID = default(Guid);
		private Guid _Project_RefID = default(Guid);
		private Guid _DeveloperTask_Type_RefID = default(Guid);
		private Boolean _IsTaskEstimable = default(Boolean);
		private Double _DeveloperTime_RequiredEstimation_min = default(Double);
		private Double _DeveloperTime_CurrentInvestment_min = default(Double);
		private Guid _GrabbedByMember_RefID = default(Guid);
		private DateTime _Completion_Deadline = default(DateTime);
		private DateTime _Completion_Timestamp = default(DateTime);
		private String _PercentageComplete = default(String);
		private String _Name = default(String);
		private String _Description = default(String);
		private int _Developer_Points = default(int);
		private Boolean _IsComplete = default(Boolean);
		private Boolean _IsIncompleteInformation = default(Boolean);
		private Boolean _IsArchived = default(Boolean);
		private Boolean _IsBeingPrepared = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid TMS_PRO_DeveloperTaskID { 
			get {
				return _TMS_PRO_DeveloperTaskID;
			}
			set {
				if(_TMS_PRO_DeveloperTaskID != value){
					_TMS_PRO_DeveloperTaskID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IdentificationNumber { 
			get {
				return _IdentificationNumber;
			}
			set {
				if(_IdentificationNumber != value){
					_IdentificationNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DOC_Structure_Header_RefID { 
			get {
				return _DOC_Structure_Header_RefID;
			}
			set {
				if(_DOC_Structure_Header_RefID != value){
					_DOC_Structure_Header_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CreatedBy_ProjectMember_RefID { 
			get {
				return _CreatedBy_ProjectMember_RefID;
			}
			set {
				if(_CreatedBy_ProjectMember_RefID != value){
					_CreatedBy_ProjectMember_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Priority_RefID { 
			get {
				return _Priority_RefID;
			}
			set {
				if(_Priority_RefID != value){
					_Priority_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Project_RefID { 
			get {
				return _Project_RefID;
			}
			set {
				if(_Project_RefID != value){
					_Project_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DeveloperTask_Type_RefID { 
			get {
				return _DeveloperTask_Type_RefID;
			}
			set {
				if(_DeveloperTask_Type_RefID != value){
					_DeveloperTask_Type_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsTaskEstimable { 
			get {
				return _IsTaskEstimable;
			}
			set {
				if(_IsTaskEstimable != value){
					_IsTaskEstimable = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double DeveloperTime_RequiredEstimation_min { 
			get {
				return _DeveloperTime_RequiredEstimation_min;
			}
			set {
				if(_DeveloperTime_RequiredEstimation_min != value){
					_DeveloperTime_RequiredEstimation_min = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double DeveloperTime_CurrentInvestment_min { 
			get {
				return _DeveloperTime_CurrentInvestment_min;
			}
			set {
				if(_DeveloperTime_CurrentInvestment_min != value){
					_DeveloperTime_CurrentInvestment_min = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid GrabbedByMember_RefID { 
			get {
				return _GrabbedByMember_RefID;
			}
			set {
				if(_GrabbedByMember_RefID != value){
					_GrabbedByMember_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Completion_Deadline { 
			get {
				return _Completion_Deadline;
			}
			set {
				if(_Completion_Deadline != value){
					_Completion_Deadline = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Completion_Timestamp { 
			get {
				return _Completion_Timestamp;
			}
			set {
				if(_Completion_Timestamp != value){
					_Completion_Timestamp = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String PercentageComplete { 
			get {
				return _PercentageComplete;
			}
			set {
				if(_PercentageComplete != value){
					_PercentageComplete = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Name { 
			get {
				return _Name;
			}
			set {
				if(_Name != value){
					_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Description { 
			get {
				return _Description;
			}
			set {
				if(_Description != value){
					_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Developer_Points { 
			get {
				return _Developer_Points;
			}
			set {
				if(_Developer_Points != value){
					_Developer_Points = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsComplete { 
			get {
				return _IsComplete;
			}
			set {
				if(_IsComplete != value){
					_IsComplete = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsIncompleteInformation { 
			get {
				return _IsIncompleteInformation;
			}
			set {
				if(_IsIncompleteInformation != value){
					_IsIncompleteInformation = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsArchived { 
			get {
				return _IsArchived;
			}
			set {
				if(_IsArchived != value){
					_IsArchived = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsBeingPrepared { 
			get {
				return _IsBeingPrepared;
			}
			set {
				if(_IsBeingPrepared != value){
					_IsBeingPrepared = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_TMS_PRO.TMS_PRO_DeveloperTask.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_TMS_PRO.TMS_PRO_DeveloperTask.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TMS_PRO_DeveloperTaskID", _TMS_PRO_DeveloperTaskID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IdentificationNumber", _IdentificationNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DOC_Structure_Header_RefID", _DOC_Structure_Header_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CreatedBy_ProjectMember_RefID", _CreatedBy_ProjectMember_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Priority_RefID", _Priority_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Project_RefID", _Project_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DeveloperTask_Type_RefID", _DeveloperTask_Type_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsTaskEstimable", _IsTaskEstimable);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DeveloperTime_RequiredEstimation_min", _DeveloperTime_RequiredEstimation_min);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DeveloperTime_CurrentInvestment_min", _DeveloperTime_CurrentInvestment_min);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "GrabbedByMember_RefID", _GrabbedByMember_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Completion_Deadline", _Completion_Deadline);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Completion_Timestamp", _Completion_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PercentageComplete", _PercentageComplete);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Name", _Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Description", _Description);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Developer_Points", _Developer_Points);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsComplete", _IsComplete);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsIncompleteInformation", _IsIncompleteInformation);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsArchived", _IsArchived);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsBeingPrepared", _IsBeingPrepared);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);


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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_TMS_PRO.TMS_PRO_DeveloperTask.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_TMS_PRO_DeveloperTaskID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TMS_PRO_DeveloperTaskID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "TMS_PRO_DeveloperTaskID","IdentificationNumber","DOC_Structure_Header_RefID","CreatedBy_ProjectMember_RefID","Priority_RefID","Project_RefID","DeveloperTask_Type_RefID","IsTaskEstimable","DeveloperTime_RequiredEstimation_min","DeveloperTime_CurrentInvestment_min","GrabbedByMember_RefID","Completion_Deadline","Completion_Timestamp","PercentageComplete","Name","Description","Developer_Points","IsComplete","IsIncompleteInformation","IsArchived","IsBeingPrepared","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter TMS_PRO_DeveloperTaskID of type Guid
						_TMS_PRO_DeveloperTaskID = reader.GetGuid(0);
						//1:Parameter IdentificationNumber of type String
						_IdentificationNumber = reader.GetString(1);
						//2:Parameter DOC_Structure_Header_RefID of type Guid
						_DOC_Structure_Header_RefID = reader.GetGuid(2);
						//3:Parameter CreatedBy_ProjectMember_RefID of type Guid
						_CreatedBy_ProjectMember_RefID = reader.GetGuid(3);
						//4:Parameter Priority_RefID of type Guid
						_Priority_RefID = reader.GetGuid(4);
						//5:Parameter Project_RefID of type Guid
						_Project_RefID = reader.GetGuid(5);
						//6:Parameter DeveloperTask_Type_RefID of type Guid
						_DeveloperTask_Type_RefID = reader.GetGuid(6);
						//7:Parameter IsTaskEstimable of type Boolean
						_IsTaskEstimable = reader.GetBoolean(7);
						//8:Parameter DeveloperTime_RequiredEstimation_min of type Double
						_DeveloperTime_RequiredEstimation_min = reader.GetDouble(8);
						//9:Parameter DeveloperTime_CurrentInvestment_min of type Double
						_DeveloperTime_CurrentInvestment_min = reader.GetDouble(9);
						//10:Parameter GrabbedByMember_RefID of type Guid
						_GrabbedByMember_RefID = reader.GetGuid(10);
						//11:Parameter Completion_Deadline of type DateTime
						_Completion_Deadline = reader.GetDate(11);
						//12:Parameter Completion_Timestamp of type DateTime
						_Completion_Timestamp = reader.GetDate(12);
						//13:Parameter PercentageComplete of type String
						_PercentageComplete = reader.GetString(13);
						//14:Parameter Name of type String
						_Name = reader.GetString(14);
						//15:Parameter Description of type String
						_Description = reader.GetString(15);
						//16:Parameter Developer_Points of type int
						_Developer_Points = reader.GetInteger(16);
						//17:Parameter IsComplete of type Boolean
						_IsComplete = reader.GetBoolean(17);
						//18:Parameter IsIncompleteInformation of type Boolean
						_IsIncompleteInformation = reader.GetBoolean(18);
						//19:Parameter IsArchived of type Boolean
						_IsArchived = reader.GetBoolean(19);
						//20:Parameter IsBeingPrepared of type Boolean
						_IsBeingPrepared = reader.GetBoolean(20);
						//21:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(21);
						//22:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(22);
						//23:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(23);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_TMS_PRO_DeveloperTaskID != Guid.Empty){
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
			public Guid? TMS_PRO_DeveloperTaskID {	get; set; }
			public String IdentificationNumber {	get; set; }
			public Guid? DOC_Structure_Header_RefID {	get; set; }
			public Guid? CreatedBy_ProjectMember_RefID {	get; set; }
			public Guid? Priority_RefID {	get; set; }
			public Guid? Project_RefID {	get; set; }
			public Guid? DeveloperTask_Type_RefID {	get; set; }
			public Boolean? IsTaskEstimable {	get; set; }
			public Double? DeveloperTime_RequiredEstimation_min {	get; set; }
			public Double? DeveloperTime_CurrentInvestment_min {	get; set; }
			public Guid? GrabbedByMember_RefID {	get; set; }
			public DateTime? Completion_Deadline {	get; set; }
			public DateTime? Completion_Timestamp {	get; set; }
			public String PercentageComplete {	get; set; }
			public String Name {	get; set; }
			public String Description {	get; set; }
			public int? Developer_Points {	get; set; }
			public Boolean? IsComplete {	get; set; }
			public Boolean? IsIncompleteInformation {	get; set; }
			public Boolean? IsArchived {	get; set; }
			public Boolean? IsBeingPrepared {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			 

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
			public static List<ORM_TMS_PRO_DeveloperTask> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_TMS_PRO_DeveloperTask> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_TMS_PRO_DeveloperTask> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_TMS_PRO_DeveloperTask> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_TMS_PRO_DeveloperTask> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_TMS_PRO_DeveloperTask>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "TMS_PRO_DeveloperTaskID","IdentificationNumber","DOC_Structure_Header_RefID","CreatedBy_ProjectMember_RefID","Priority_RefID","Project_RefID","DeveloperTask_Type_RefID","IsTaskEstimable","DeveloperTime_RequiredEstimation_min","DeveloperTime_CurrentInvestment_min","GrabbedByMember_RefID","Completion_Deadline","Completion_Timestamp","PercentageComplete","Name","Description","Developer_Points","IsComplete","IsIncompleteInformation","IsArchived","IsBeingPrepared","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_TMS_PRO_DeveloperTask item = new ORM_TMS_PRO_DeveloperTask();
						//0:Parameter TMS_PRO_DeveloperTaskID of type Guid
						item.TMS_PRO_DeveloperTaskID = reader.GetGuid(0);
						//1:Parameter IdentificationNumber of type String
						item.IdentificationNumber = reader.GetString(1);
						//2:Parameter DOC_Structure_Header_RefID of type Guid
						item.DOC_Structure_Header_RefID = reader.GetGuid(2);
						//3:Parameter CreatedBy_ProjectMember_RefID of type Guid
						item.CreatedBy_ProjectMember_RefID = reader.GetGuid(3);
						//4:Parameter Priority_RefID of type Guid
						item.Priority_RefID = reader.GetGuid(4);
						//5:Parameter Project_RefID of type Guid
						item.Project_RefID = reader.GetGuid(5);
						//6:Parameter DeveloperTask_Type_RefID of type Guid
						item.DeveloperTask_Type_RefID = reader.GetGuid(6);
						//7:Parameter IsTaskEstimable of type Boolean
						item.IsTaskEstimable = reader.GetBoolean(7);
						//8:Parameter DeveloperTime_RequiredEstimation_min of type Double
						item.DeveloperTime_RequiredEstimation_min = reader.GetDouble(8);
						//9:Parameter DeveloperTime_CurrentInvestment_min of type Double
						item.DeveloperTime_CurrentInvestment_min = reader.GetDouble(9);
						//10:Parameter GrabbedByMember_RefID of type Guid
						item.GrabbedByMember_RefID = reader.GetGuid(10);
						//11:Parameter Completion_Deadline of type DateTime
						item.Completion_Deadline = reader.GetDate(11);
						//12:Parameter Completion_Timestamp of type DateTime
						item.Completion_Timestamp = reader.GetDate(12);
						//13:Parameter PercentageComplete of type String
						item.PercentageComplete = reader.GetString(13);
						//14:Parameter Name of type String
						item.Name = reader.GetString(14);
						//15:Parameter Description of type String
						item.Description = reader.GetString(15);
						//16:Parameter Developer_Points of type int
						item.Developer_Points = reader.GetInteger(16);
						//17:Parameter IsComplete of type Boolean
						item.IsComplete = reader.GetBoolean(17);
						//18:Parameter IsIncompleteInformation of type Boolean
						item.IsIncompleteInformation = reader.GetBoolean(18);
						//19:Parameter IsArchived of type Boolean
						item.IsArchived = reader.GetBoolean(19);
						//20:Parameter IsBeingPrepared of type Boolean
						item.IsBeingPrepared = reader.GetBoolean(20);
						//21:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(21);
						//22:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(22);
						//23:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(23);


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
