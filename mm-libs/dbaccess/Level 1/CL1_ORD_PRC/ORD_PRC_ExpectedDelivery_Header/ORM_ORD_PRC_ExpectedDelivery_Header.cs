/* 
 * Generated on 4/7/2014 5:29:11 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_ORD_PRC
{
	[Serializable]
	public class ORM_ORD_PRC_ExpectedDelivery_Header
	{
		public static readonly string TableName = "ord_prc_expecteddelivery_headers";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_ORD_PRC_ExpectedDelivery_Header()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_ORD_PRC_ExpectedDelivery_HeaderID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _ORD_PRC_ExpectedDelivery_HeaderID = default(Guid);
		private String _ExpectedDeliveryHeaderITL = default(String);
		private DateTime _ExpectedDeliveryDate = default(DateTime);
		private String _ExpectedDeliveryNumber = default(String);
		private Guid _LOG_WRH_Warehouse_RefID = default(Guid);
		private Boolean _IsDeliveryOpen = default(Boolean);
		private Boolean _IsDeliveryClosed = default(Boolean);
		private Boolean _IsDeliveryManuallyCreated = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid ORD_PRC_ExpectedDelivery_HeaderID { 
			get {
				return _ORD_PRC_ExpectedDelivery_HeaderID;
			}
			set {
				if(_ORD_PRC_ExpectedDelivery_HeaderID != value){
					_ORD_PRC_ExpectedDelivery_HeaderID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ExpectedDeliveryHeaderITL { 
			get {
				return _ExpectedDeliveryHeaderITL;
			}
			set {
				if(_ExpectedDeliveryHeaderITL != value){
					_ExpectedDeliveryHeaderITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime ExpectedDeliveryDate { 
			get {
				return _ExpectedDeliveryDate;
			}
			set {
				if(_ExpectedDeliveryDate != value){
					_ExpectedDeliveryDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ExpectedDeliveryNumber { 
			get {
				return _ExpectedDeliveryNumber;
			}
			set {
				if(_ExpectedDeliveryNumber != value){
					_ExpectedDeliveryNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid LOG_WRH_Warehouse_RefID { 
			get {
				return _LOG_WRH_Warehouse_RefID;
			}
			set {
				if(_LOG_WRH_Warehouse_RefID != value){
					_LOG_WRH_Warehouse_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDeliveryOpen { 
			get {
				return _IsDeliveryOpen;
			}
			set {
				if(_IsDeliveryOpen != value){
					_IsDeliveryOpen = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDeliveryClosed { 
			get {
				return _IsDeliveryClosed;
			}
			set {
				if(_IsDeliveryClosed != value){
					_IsDeliveryClosed = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDeliveryManuallyCreated { 
			get {
				return _IsDeliveryManuallyCreated;
			}
			set {
				if(_IsDeliveryManuallyCreated != value){
					_IsDeliveryManuallyCreated = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ExpectedDelivery_Header.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ExpectedDelivery_Header.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ORD_PRC_ExpectedDelivery_HeaderID", _ORD_PRC_ExpectedDelivery_HeaderID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ExpectedDeliveryHeaderITL", _ExpectedDeliveryHeaderITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ExpectedDeliveryDate", _ExpectedDeliveryDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ExpectedDeliveryNumber", _ExpectedDeliveryNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LOG_WRH_Warehouse_RefID", _LOG_WRH_Warehouse_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeliveryOpen", _IsDeliveryOpen);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeliveryClosed", _IsDeliveryClosed);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeliveryManuallyCreated", _IsDeliveryManuallyCreated);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_ORD_PRC.ORD_PRC_ExpectedDelivery_Header.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_ORD_PRC_ExpectedDelivery_HeaderID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ORD_PRC_ExpectedDelivery_HeaderID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_ExpectedDelivery_HeaderID","ExpectedDeliveryHeaderITL","ExpectedDeliveryDate","ExpectedDeliveryNumber","LOG_WRH_Warehouse_RefID","IsDeliveryOpen","IsDeliveryClosed","IsDeliveryManuallyCreated","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter ORD_PRC_ExpectedDelivery_HeaderID of type Guid
						_ORD_PRC_ExpectedDelivery_HeaderID = reader.GetGuid(0);
						//1:Parameter ExpectedDeliveryHeaderITL of type String
						_ExpectedDeliveryHeaderITL = reader.GetString(1);
						//2:Parameter ExpectedDeliveryDate of type DateTime
						_ExpectedDeliveryDate = reader.GetDate(2);
						//3:Parameter ExpectedDeliveryNumber of type String
						_ExpectedDeliveryNumber = reader.GetString(3);
						//4:Parameter LOG_WRH_Warehouse_RefID of type Guid
						_LOG_WRH_Warehouse_RefID = reader.GetGuid(4);
						//5:Parameter IsDeliveryOpen of type Boolean
						_IsDeliveryOpen = reader.GetBoolean(5);
						//6:Parameter IsDeliveryClosed of type Boolean
						_IsDeliveryClosed = reader.GetBoolean(6);
						//7:Parameter IsDeliveryManuallyCreated of type Boolean
						_IsDeliveryManuallyCreated = reader.GetBoolean(7);
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

					if(_ORD_PRC_ExpectedDelivery_HeaderID != Guid.Empty){
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
			public Guid? ORD_PRC_ExpectedDelivery_HeaderID {	get; set; }
			public String ExpectedDeliveryHeaderITL {	get; set; }
			public DateTime? ExpectedDeliveryDate {	get; set; }
			public String ExpectedDeliveryNumber {	get; set; }
			public Guid? LOG_WRH_Warehouse_RefID {	get; set; }
			public Boolean? IsDeliveryOpen {	get; set; }
			public Boolean? IsDeliveryClosed {	get; set; }
			public Boolean? IsDeliveryManuallyCreated {	get; set; }
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
			public static List<ORM_ORD_PRC_ExpectedDelivery_Header> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_ORD_PRC_ExpectedDelivery_Header> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_ORD_PRC_ExpectedDelivery_Header> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_ORD_PRC_ExpectedDelivery_Header> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_ORD_PRC_ExpectedDelivery_Header> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_ORD_PRC_ExpectedDelivery_Header>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "ORD_PRC_ExpectedDelivery_HeaderID","ExpectedDeliveryHeaderITL","ExpectedDeliveryDate","ExpectedDeliveryNumber","LOG_WRH_Warehouse_RefID","IsDeliveryOpen","IsDeliveryClosed","IsDeliveryManuallyCreated","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_ORD_PRC_ExpectedDelivery_Header item = new ORM_ORD_PRC_ExpectedDelivery_Header();
						//0:Parameter ORD_PRC_ExpectedDelivery_HeaderID of type Guid
						item.ORD_PRC_ExpectedDelivery_HeaderID = reader.GetGuid(0);
						//1:Parameter ExpectedDeliveryHeaderITL of type String
						item.ExpectedDeliveryHeaderITL = reader.GetString(1);
						//2:Parameter ExpectedDeliveryDate of type DateTime
						item.ExpectedDeliveryDate = reader.GetDate(2);
						//3:Parameter ExpectedDeliveryNumber of type String
						item.ExpectedDeliveryNumber = reader.GetString(3);
						//4:Parameter LOG_WRH_Warehouse_RefID of type Guid
						item.LOG_WRH_Warehouse_RefID = reader.GetGuid(4);
						//5:Parameter IsDeliveryOpen of type Boolean
						item.IsDeliveryOpen = reader.GetBoolean(5);
						//6:Parameter IsDeliveryClosed of type Boolean
						item.IsDeliveryClosed = reader.GetBoolean(6);
						//7:Parameter IsDeliveryManuallyCreated of type Boolean
						item.IsDeliveryManuallyCreated = reader.GetBoolean(7);
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
