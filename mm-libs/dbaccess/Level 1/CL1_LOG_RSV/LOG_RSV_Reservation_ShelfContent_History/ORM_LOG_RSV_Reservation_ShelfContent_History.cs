/* 
 * Generated on 3/15/2014 4:35:56 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_LOG_RSV
{
	[Serializable]
	public class ORM_LOG_RSV_Reservation_ShelfContent_History
	{
		public static readonly string TableName = "log_rsv_reservation_shelfcontent_history";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_LOG_RSV_Reservation_ShelfContent_History()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_LOG_RSV_Reservation_ShelfContent_HistoryID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _LOG_RSV_Reservation_ShelfContent_HistoryID = default(Guid);
		private Guid _LOG_WRH_Shelf_Content_RefID = default(Guid);
		private Boolean _IsReservationMade = default(Boolean);
		private Boolean _IsReservationReleased = default(Boolean);
		private double _NewReservedQuantity = default(double);
		private double _ReservedQuantity = default(double);
		private double _ReleasedQuantity = default(double);
		private String _Comment = default(String);
		private Guid _IfReservationMade_Reservation_RefID = default(Guid);
		private Guid _IfReservationReleased_ReleasedReservation_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid LOG_RSV_Reservation_ShelfContent_HistoryID { 
			get {
				return _LOG_RSV_Reservation_ShelfContent_HistoryID;
			}
			set {
				if(_LOG_RSV_Reservation_ShelfContent_HistoryID != value){
					_LOG_RSV_Reservation_ShelfContent_HistoryID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid LOG_WRH_Shelf_Content_RefID { 
			get {
				return _LOG_WRH_Shelf_Content_RefID;
			}
			set {
				if(_LOG_WRH_Shelf_Content_RefID != value){
					_LOG_WRH_Shelf_Content_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsReservationMade { 
			get {
				return _IsReservationMade;
			}
			set {
				if(_IsReservationMade != value){
					_IsReservationMade = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsReservationReleased { 
			get {
				return _IsReservationReleased;
			}
			set {
				if(_IsReservationReleased != value){
					_IsReservationReleased = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double NewReservedQuantity { 
			get {
				return _NewReservedQuantity;
			}
			set {
				if(_NewReservedQuantity != value){
					_NewReservedQuantity = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double ReservedQuantity { 
			get {
				return _ReservedQuantity;
			}
			set {
				if(_ReservedQuantity != value){
					_ReservedQuantity = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double ReleasedQuantity { 
			get {
				return _ReleasedQuantity;
			}
			set {
				if(_ReleasedQuantity != value){
					_ReleasedQuantity = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Comment { 
			get {
				return _Comment;
			}
			set {
				if(_Comment != value){
					_Comment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfReservationMade_Reservation_RefID { 
			get {
				return _IfReservationMade_Reservation_RefID;
			}
			set {
				if(_IfReservationMade_Reservation_RefID != value){
					_IfReservationMade_Reservation_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfReservationReleased_ReleasedReservation_RefID { 
			get {
				return _IfReservationReleased_ReleasedReservation_RefID;
			}
			set {
				if(_IfReservationReleased_ReleasedReservation_RefID != value){
					_IfReservationReleased_ReleasedReservation_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_RSV.LOG_RSV_Reservation_ShelfContent_History.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_RSV.LOG_RSV_Reservation_ShelfContent_History.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LOG_RSV_Reservation_ShelfContent_HistoryID", _LOG_RSV_Reservation_ShelfContent_HistoryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LOG_WRH_Shelf_Content_RefID", _LOG_WRH_Shelf_Content_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsReservationMade", _IsReservationMade);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsReservationReleased", _IsReservationReleased);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "NewReservedQuantity", _NewReservedQuantity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ReservedQuantity", _ReservedQuantity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ReleasedQuantity", _ReleasedQuantity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment", _Comment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfReservationMade_Reservation_RefID", _IfReservationMade_Reservation_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfReservationReleased_ReleasedReservation_RefID", _IfReservationReleased_ReleasedReservation_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG_RSV.LOG_RSV_Reservation_ShelfContent_History.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_LOG_RSV_Reservation_ShelfContent_HistoryID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LOG_RSV_Reservation_ShelfContent_HistoryID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_RSV_Reservation_ShelfContent_HistoryID","LOG_WRH_Shelf_Content_RefID","IsReservationMade","IsReservationReleased","NewReservedQuantity","ReservedQuantity","ReleasedQuantity","Comment","IfReservationMade_Reservation_RefID","IfReservationReleased_ReleasedReservation_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter LOG_RSV_Reservation_ShelfContent_HistoryID of type Guid
						_LOG_RSV_Reservation_ShelfContent_HistoryID = reader.GetGuid(0);
						//1:Parameter LOG_WRH_Shelf_Content_RefID of type Guid
						_LOG_WRH_Shelf_Content_RefID = reader.GetGuid(1);
						//2:Parameter IsReservationMade of type Boolean
						_IsReservationMade = reader.GetBoolean(2);
						//3:Parameter IsReservationReleased of type Boolean
						_IsReservationReleased = reader.GetBoolean(3);
						//4:Parameter NewReservedQuantity of type double
						_NewReservedQuantity = reader.GetDouble(4);
						//5:Parameter ReservedQuantity of type double
						_ReservedQuantity = reader.GetDouble(5);
						//6:Parameter ReleasedQuantity of type double
						_ReleasedQuantity = reader.GetDouble(6);
						//7:Parameter Comment of type String
						_Comment = reader.GetString(7);
						//8:Parameter IfReservationMade_Reservation_RefID of type Guid
						_IfReservationMade_Reservation_RefID = reader.GetGuid(8);
						//9:Parameter IfReservationReleased_ReleasedReservation_RefID of type Guid
						_IfReservationReleased_ReleasedReservation_RefID = reader.GetGuid(9);
						//10:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(10);
						//11:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(11);
						//12:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(12);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_LOG_RSV_Reservation_ShelfContent_HistoryID != Guid.Empty){
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
			public Guid? LOG_RSV_Reservation_ShelfContent_HistoryID {	get; set; }
			public Guid? LOG_WRH_Shelf_Content_RefID {	get; set; }
			public Boolean? IsReservationMade {	get; set; }
			public Boolean? IsReservationReleased {	get; set; }
			public double? NewReservedQuantity {	get; set; }
			public double? ReservedQuantity {	get; set; }
			public double? ReleasedQuantity {	get; set; }
			public String Comment {	get; set; }
			public Guid? IfReservationMade_Reservation_RefID {	get; set; }
			public Guid? IfReservationReleased_ReleasedReservation_RefID {	get; set; }
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
			public static List<ORM_LOG_RSV_Reservation_ShelfContent_History> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_LOG_RSV_Reservation_ShelfContent_History> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_LOG_RSV_Reservation_ShelfContent_History> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_LOG_RSV_Reservation_ShelfContent_History> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_LOG_RSV_Reservation_ShelfContent_History> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_LOG_RSV_Reservation_ShelfContent_History>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_RSV_Reservation_ShelfContent_HistoryID","LOG_WRH_Shelf_Content_RefID","IsReservationMade","IsReservationReleased","NewReservedQuantity","ReservedQuantity","ReleasedQuantity","Comment","IfReservationMade_Reservation_RefID","IfReservationReleased_ReleasedReservation_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_LOG_RSV_Reservation_ShelfContent_History item = new ORM_LOG_RSV_Reservation_ShelfContent_History();
						//0:Parameter LOG_RSV_Reservation_ShelfContent_HistoryID of type Guid
						item.LOG_RSV_Reservation_ShelfContent_HistoryID = reader.GetGuid(0);
						//1:Parameter LOG_WRH_Shelf_Content_RefID of type Guid
						item.LOG_WRH_Shelf_Content_RefID = reader.GetGuid(1);
						//2:Parameter IsReservationMade of type Boolean
						item.IsReservationMade = reader.GetBoolean(2);
						//3:Parameter IsReservationReleased of type Boolean
						item.IsReservationReleased = reader.GetBoolean(3);
						//4:Parameter NewReservedQuantity of type double
						item.NewReservedQuantity = reader.GetDouble(4);
						//5:Parameter ReservedQuantity of type double
						item.ReservedQuantity = reader.GetDouble(5);
						//6:Parameter ReleasedQuantity of type double
						item.ReleasedQuantity = reader.GetDouble(6);
						//7:Parameter Comment of type String
						item.Comment = reader.GetString(7);
						//8:Parameter IfReservationMade_Reservation_RefID of type Guid
						item.IfReservationMade_Reservation_RefID = reader.GetGuid(8);
						//9:Parameter IfReservationReleased_ReleasedReservation_RefID of type Guid
						item.IfReservationReleased_ReleasedReservation_RefID = reader.GetGuid(9);
						//10:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(10);
						//11:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(11);
						//12:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(12);


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
