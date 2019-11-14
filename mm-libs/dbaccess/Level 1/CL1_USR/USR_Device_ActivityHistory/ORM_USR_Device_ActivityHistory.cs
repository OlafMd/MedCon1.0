/* 
 * Generated on 3/20/2015 9:02:21 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_USR
{
	[Serializable]
	public class ORM_USR_Device_ActivityHistory
	{
		public static readonly string TableName = "usr_device_activityhistory";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_USR_Device_ActivityHistory()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_USR_Device_ActivityHistoryID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _USR_Device_ActivityHistoryID = default(Guid);
		private Guid _Device_RefID = default(Guid);
		private Guid _Performing_Account_RefID = default(Guid);
		private DateTime _DateOfActivity = default(DateTime);
		private Boolean _WasDevice_Configured = default(Boolean);
		private Guid _WasDevice_Configured_WithConfigurationCode_RefID = default(Guid);
		private Boolean _WasDevice_RequestingDSC = default(Boolean);
		private Boolean _WasBanned = default(Boolean);
		private Boolean _WasUnbanned = default(Boolean);
		private Boolean _WasCreatedSession = default(Boolean);
		private Boolean _WasOtherRelevantActivity = default(Boolean);
		private String _ActivityComment = default(String);
		private String _AccountComment = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid USR_Device_ActivityHistoryID { 
			get {
				return _USR_Device_ActivityHistoryID;
			}
			set {
				if(_USR_Device_ActivityHistoryID != value){
					_USR_Device_ActivityHistoryID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Device_RefID { 
			get {
				return _Device_RefID;
			}
			set {
				if(_Device_RefID != value){
					_Device_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Performing_Account_RefID { 
			get {
				return _Performing_Account_RefID;
			}
			set {
				if(_Performing_Account_RefID != value){
					_Performing_Account_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime DateOfActivity { 
			get {
				return _DateOfActivity;
			}
			set {
				if(_DateOfActivity != value){
					_DateOfActivity = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean WasDevice_Configured { 
			get {
				return _WasDevice_Configured;
			}
			set {
				if(_WasDevice_Configured != value){
					_WasDevice_Configured = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid WasDevice_Configured_WithConfigurationCode_RefID { 
			get {
				return _WasDevice_Configured_WithConfigurationCode_RefID;
			}
			set {
				if(_WasDevice_Configured_WithConfigurationCode_RefID != value){
					_WasDevice_Configured_WithConfigurationCode_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean WasDevice_RequestingDSC { 
			get {
				return _WasDevice_RequestingDSC;
			}
			set {
				if(_WasDevice_RequestingDSC != value){
					_WasDevice_RequestingDSC = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean WasBanned { 
			get {
				return _WasBanned;
			}
			set {
				if(_WasBanned != value){
					_WasBanned = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean WasUnbanned { 
			get {
				return _WasUnbanned;
			}
			set {
				if(_WasUnbanned != value){
					_WasUnbanned = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean WasCreatedSession { 
			get {
				return _WasCreatedSession;
			}
			set {
				if(_WasCreatedSession != value){
					_WasCreatedSession = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean WasOtherRelevantActivity { 
			get {
				return _WasOtherRelevantActivity;
			}
			set {
				if(_WasOtherRelevantActivity != value){
					_WasOtherRelevantActivity = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ActivityComment { 
			get {
				return _ActivityComment;
			}
			set {
				if(_ActivityComment != value){
					_ActivityComment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String AccountComment { 
			get {
				return _AccountComment;
			}
			set {
				if(_AccountComment != value){
					_AccountComment = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_USR.USR_Device_ActivityHistory.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_USR.USR_Device_ActivityHistory.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "USR_Device_ActivityHistoryID", _USR_Device_ActivityHistoryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Device_RefID", _Device_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Performing_Account_RefID", _Performing_Account_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DateOfActivity", _DateOfActivity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WasDevice_Configured", _WasDevice_Configured);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WasDevice_Configured_WithConfigurationCode_RefID", _WasDevice_Configured_WithConfigurationCode_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WasDevice_RequestingDSC", _WasDevice_RequestingDSC);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WasBanned", _WasBanned);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WasUnbanned", _WasUnbanned);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WasCreatedSession", _WasCreatedSession);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WasOtherRelevantActivity", _WasOtherRelevantActivity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ActivityComment", _ActivityComment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AccountComment", _AccountComment);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_USR.USR_Device_ActivityHistory.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_USR_Device_ActivityHistoryID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"USR_Device_ActivityHistoryID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "USR_Device_ActivityHistoryID","Device_RefID","Performing_Account_RefID","DateOfActivity","WasDevice_Configured","WasDevice_Configured_WithConfigurationCode_RefID","WasDevice_RequestingDSC","WasBanned","WasUnbanned","WasCreatedSession","WasOtherRelevantActivity","ActivityComment","AccountComment","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter USR_Device_ActivityHistoryID of type Guid
						_USR_Device_ActivityHistoryID = reader.GetGuid(0);
						//1:Parameter Device_RefID of type Guid
						_Device_RefID = reader.GetGuid(1);
						//2:Parameter Performing_Account_RefID of type Guid
						_Performing_Account_RefID = reader.GetGuid(2);
						//3:Parameter DateOfActivity of type DateTime
						_DateOfActivity = reader.GetDate(3);
						//4:Parameter WasDevice_Configured of type Boolean
						_WasDevice_Configured = reader.GetBoolean(4);
						//5:Parameter WasDevice_Configured_WithConfigurationCode_RefID of type Guid
						_WasDevice_Configured_WithConfigurationCode_RefID = reader.GetGuid(5);
						//6:Parameter WasDevice_RequestingDSC of type Boolean
						_WasDevice_RequestingDSC = reader.GetBoolean(6);
						//7:Parameter WasBanned of type Boolean
						_WasBanned = reader.GetBoolean(7);
						//8:Parameter WasUnbanned of type Boolean
						_WasUnbanned = reader.GetBoolean(8);
						//9:Parameter WasCreatedSession of type Boolean
						_WasCreatedSession = reader.GetBoolean(9);
						//10:Parameter WasOtherRelevantActivity of type Boolean
						_WasOtherRelevantActivity = reader.GetBoolean(10);
						//11:Parameter ActivityComment of type String
						_ActivityComment = reader.GetString(11);
						//12:Parameter AccountComment of type String
						_AccountComment = reader.GetString(12);
						//13:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(15);
						//16:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(16);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_USR_Device_ActivityHistoryID != Guid.Empty){
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
			public Guid? USR_Device_ActivityHistoryID {	get; set; }
			public Guid? Device_RefID {	get; set; }
			public Guid? Performing_Account_RefID {	get; set; }
			public DateTime? DateOfActivity {	get; set; }
			public Boolean? WasDevice_Configured {	get; set; }
			public Guid? WasDevice_Configured_WithConfigurationCode_RefID {	get; set; }
			public Boolean? WasDevice_RequestingDSC {	get; set; }
			public Boolean? WasBanned {	get; set; }
			public Boolean? WasUnbanned {	get; set; }
			public Boolean? WasCreatedSession {	get; set; }
			public Boolean? WasOtherRelevantActivity {	get; set; }
			public String ActivityComment {	get; set; }
			public String AccountComment {	get; set; }
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
			public static List<ORM_USR_Device_ActivityHistory> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_USR_Device_ActivityHistory> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_USR_Device_ActivityHistory> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_USR_Device_ActivityHistory> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_USR_Device_ActivityHistory> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_USR_Device_ActivityHistory>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "USR_Device_ActivityHistoryID","Device_RefID","Performing_Account_RefID","DateOfActivity","WasDevice_Configured","WasDevice_Configured_WithConfigurationCode_RefID","WasDevice_RequestingDSC","WasBanned","WasUnbanned","WasCreatedSession","WasOtherRelevantActivity","ActivityComment","AccountComment","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_USR_Device_ActivityHistory item = new ORM_USR_Device_ActivityHistory();
						//0:Parameter USR_Device_ActivityHistoryID of type Guid
						item.USR_Device_ActivityHistoryID = reader.GetGuid(0);
						//1:Parameter Device_RefID of type Guid
						item.Device_RefID = reader.GetGuid(1);
						//2:Parameter Performing_Account_RefID of type Guid
						item.Performing_Account_RefID = reader.GetGuid(2);
						//3:Parameter DateOfActivity of type DateTime
						item.DateOfActivity = reader.GetDate(3);
						//4:Parameter WasDevice_Configured of type Boolean
						item.WasDevice_Configured = reader.GetBoolean(4);
						//5:Parameter WasDevice_Configured_WithConfigurationCode_RefID of type Guid
						item.WasDevice_Configured_WithConfigurationCode_RefID = reader.GetGuid(5);
						//6:Parameter WasDevice_RequestingDSC of type Boolean
						item.WasDevice_RequestingDSC = reader.GetBoolean(6);
						//7:Parameter WasBanned of type Boolean
						item.WasBanned = reader.GetBoolean(7);
						//8:Parameter WasUnbanned of type Boolean
						item.WasUnbanned = reader.GetBoolean(8);
						//9:Parameter WasCreatedSession of type Boolean
						item.WasCreatedSession = reader.GetBoolean(9);
						//10:Parameter WasOtherRelevantActivity of type Boolean
						item.WasOtherRelevantActivity = reader.GetBoolean(10);
						//11:Parameter ActivityComment of type String
						item.ActivityComment = reader.GetString(11);
						//12:Parameter AccountComment of type String
						item.AccountComment = reader.GetString(12);
						//13:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(15);
						//16:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(16);


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
