/* 
 * Generated on 3/19/2014 11:23:17 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_LOG_WRH_INJ
{
	[Serializable]
	public class ORM_LOG_WRH_INJ_InventoryJob_CountingRun
	{
		public static readonly string TableName = "log_wrh_inj_inventoryjob_countingruns";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_LOG_WRH_INJ_InventoryJob_CountingRun()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_LOG_WRH_INJ_InventoryJob_CountingRunID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _LOG_WRH_INJ_InventoryJob_CountingRunID = default(Guid);
		private Guid _InventoryJob_Process_RefID = default(Guid);
		private Guid _ExecutingBusinessParticipant_RefID = default(Guid);
		private int _SequenceNumber = default(int);
		private Boolean _IsCounting_Started = default(Boolean);
		private Boolean _IsCounting_Completed = default(Boolean);
		private Boolean _IsCountingListPrinted = default(Boolean);
		private Boolean _IsDifferenceFound = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid LOG_WRH_INJ_InventoryJob_CountingRunID { 
			get {
				return _LOG_WRH_INJ_InventoryJob_CountingRunID;
			}
			set {
				if(_LOG_WRH_INJ_InventoryJob_CountingRunID != value){
					_LOG_WRH_INJ_InventoryJob_CountingRunID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid InventoryJob_Process_RefID { 
			get {
				return _InventoryJob_Process_RefID;
			}
			set {
				if(_InventoryJob_Process_RefID != value){
					_InventoryJob_Process_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ExecutingBusinessParticipant_RefID { 
			get {
				return _ExecutingBusinessParticipant_RefID;
			}
			set {
				if(_ExecutingBusinessParticipant_RefID != value){
					_ExecutingBusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int SequenceNumber { 
			get {
				return _SequenceNumber;
			}
			set {
				if(_SequenceNumber != value){
					_SequenceNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCounting_Started { 
			get {
				return _IsCounting_Started;
			}
			set {
				if(_IsCounting_Started != value){
					_IsCounting_Started = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCounting_Completed { 
			get {
				return _IsCounting_Completed;
			}
			set {
				if(_IsCounting_Completed != value){
					_IsCounting_Completed = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCountingListPrinted { 
			get {
				return _IsCountingListPrinted;
			}
			set {
				if(_IsCountingListPrinted != value){
					_IsCountingListPrinted = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDifferenceFound { 
			get {
				return _IsDifferenceFound;
			}
			set {
				if(_IsDifferenceFound != value){
					_IsDifferenceFound = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH_INJ.LOG_WRH_INJ_InventoryJob_CountingRun.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH_INJ.LOG_WRH_INJ_InventoryJob_CountingRun.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LOG_WRH_INJ_InventoryJob_CountingRunID", _LOG_WRH_INJ_InventoryJob_CountingRunID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InventoryJob_Process_RefID", _InventoryJob_Process_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ExecutingBusinessParticipant_RefID", _ExecutingBusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SequenceNumber", _SequenceNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCounting_Started", _IsCounting_Started);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCounting_Completed", _IsCounting_Completed);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCountingListPrinted", _IsCountingListPrinted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDifferenceFound", _IsDifferenceFound);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);


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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_WRH_INJ.LOG_WRH_INJ_InventoryJob_CountingRun.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_LOG_WRH_INJ_InventoryJob_CountingRunID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LOG_WRH_INJ_InventoryJob_CountingRunID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_WRH_INJ_InventoryJob_CountingRunID","InventoryJob_Process_RefID","ExecutingBusinessParticipant_RefID","SequenceNumber","IsCounting_Started","IsCounting_Completed","IsCountingListPrinted","IsDifferenceFound","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter LOG_WRH_INJ_InventoryJob_CountingRunID of type Guid
						_LOG_WRH_INJ_InventoryJob_CountingRunID = reader.GetGuid(0);
						//1:Parameter InventoryJob_Process_RefID of type Guid
						_InventoryJob_Process_RefID = reader.GetGuid(1);
						//2:Parameter ExecutingBusinessParticipant_RefID of type Guid
						_ExecutingBusinessParticipant_RefID = reader.GetGuid(2);
						//3:Parameter SequenceNumber of type int
						_SequenceNumber = reader.GetInteger(3);
						//4:Parameter IsCounting_Started of type Boolean
						_IsCounting_Started = reader.GetBoolean(4);
						//5:Parameter IsCounting_Completed of type Boolean
						_IsCounting_Completed = reader.GetBoolean(5);
						//6:Parameter IsCountingListPrinted of type Boolean
						_IsCountingListPrinted = reader.GetBoolean(6);
						//7:Parameter IsDifferenceFound of type Boolean
						_IsDifferenceFound = reader.GetBoolean(7);
						//8:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(8);
						//9:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(9);
						//10:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(10);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_LOG_WRH_INJ_InventoryJob_CountingRunID != Guid.Empty){
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
			public Guid? LOG_WRH_INJ_InventoryJob_CountingRunID {	get; set; }
			public Guid? InventoryJob_Process_RefID {	get; set; }
			public Guid? ExecutingBusinessParticipant_RefID {	get; set; }
			public int? SequenceNumber {	get; set; }
			public Boolean? IsCounting_Started {	get; set; }
			public Boolean? IsCounting_Completed {	get; set; }
			public Boolean? IsCountingListPrinted {	get; set; }
			public Boolean? IsDifferenceFound {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			 

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
			public static List<ORM_LOG_WRH_INJ_InventoryJob_CountingRun> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_LOG_WRH_INJ_InventoryJob_CountingRun> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_LOG_WRH_INJ_InventoryJob_CountingRun> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_LOG_WRH_INJ_InventoryJob_CountingRun> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_LOG_WRH_INJ_InventoryJob_CountingRun> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_LOG_WRH_INJ_InventoryJob_CountingRun>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_WRH_INJ_InventoryJob_CountingRunID","InventoryJob_Process_RefID","ExecutingBusinessParticipant_RefID","SequenceNumber","IsCounting_Started","IsCounting_Completed","IsCountingListPrinted","IsDifferenceFound","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_LOG_WRH_INJ_InventoryJob_CountingRun item = new ORM_LOG_WRH_INJ_InventoryJob_CountingRun();
						//0:Parameter LOG_WRH_INJ_InventoryJob_CountingRunID of type Guid
						item.LOG_WRH_INJ_InventoryJob_CountingRunID = reader.GetGuid(0);
						//1:Parameter InventoryJob_Process_RefID of type Guid
						item.InventoryJob_Process_RefID = reader.GetGuid(1);
						//2:Parameter ExecutingBusinessParticipant_RefID of type Guid
						item.ExecutingBusinessParticipant_RefID = reader.GetGuid(2);
						//3:Parameter SequenceNumber of type int
						item.SequenceNumber = reader.GetInteger(3);
						//4:Parameter IsCounting_Started of type Boolean
						item.IsCounting_Started = reader.GetBoolean(4);
						//5:Parameter IsCounting_Completed of type Boolean
						item.IsCounting_Completed = reader.GetBoolean(5);
						//6:Parameter IsCountingListPrinted of type Boolean
						item.IsCountingListPrinted = reader.GetBoolean(6);
						//7:Parameter IsDifferenceFound of type Boolean
						item.IsDifferenceFound = reader.GetBoolean(7);
						//8:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(8);
						//9:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(9);
						//10:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(10);


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
