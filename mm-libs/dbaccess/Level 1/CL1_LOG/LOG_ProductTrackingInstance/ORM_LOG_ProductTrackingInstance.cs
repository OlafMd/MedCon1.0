/* 
 * Generated on 7/30/2014 1:09:21 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_LOG
{
	[Serializable]
	public class ORM_LOG_ProductTrackingInstance
	{
		public static readonly string TableName = "log_producttrackinginstances";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_LOG_ProductTrackingInstance()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_LOG_ProductTrackingInstanceID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _LOG_ProductTrackingInstanceID = default(Guid);
		private Guid _TrackingInstanceTakenFromSourceTrackingInstance_RefID = default(Guid);
		private String _TrackingCode = default(String);
		private String _SerialNumber = default(String);
		private String _BatchNumber = default(String);
		private Guid _OwnedBy_BusinessParticipant_RefID = default(Guid);
		private Guid _CMN_PRO_Product_RefID = default(Guid);
		private Guid _CMN_PRO_Product_Variant_RefID = default(Guid);
		private Guid _CMN_PRO_Product_Release_RefID = default(Guid);
		private DateTime _ExpirationDate = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		private double _InitialQuantityOnTrackingInstance = default(double);
		private double _CurrentQuantityOnTrackingInstance = default(double);
		private double _R_ReservedQuantity = default(double);
		private double _R_FreeQuantity = default(double);
		private DateTime _Creation_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid LOG_ProductTrackingInstanceID { 
			get {
				return _LOG_ProductTrackingInstanceID;
			}
			set {
				if(_LOG_ProductTrackingInstanceID != value){
					_LOG_ProductTrackingInstanceID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid TrackingInstanceTakenFromSourceTrackingInstance_RefID { 
			get {
				return _TrackingInstanceTakenFromSourceTrackingInstance_RefID;
			}
			set {
				if(_TrackingInstanceTakenFromSourceTrackingInstance_RefID != value){
					_TrackingInstanceTakenFromSourceTrackingInstance_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String TrackingCode { 
			get {
				return _TrackingCode;
			}
			set {
				if(_TrackingCode != value){
					_TrackingCode = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String SerialNumber { 
			get {
				return _SerialNumber;
			}
			set {
				if(_SerialNumber != value){
					_SerialNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String BatchNumber { 
			get {
				return _BatchNumber;
			}
			set {
				if(_BatchNumber != value){
					_BatchNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid OwnedBy_BusinessParticipant_RefID { 
			get {
				return _OwnedBy_BusinessParticipant_RefID;
			}
			set {
				if(_OwnedBy_BusinessParticipant_RefID != value){
					_OwnedBy_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_PRO_Product_RefID { 
			get {
				return _CMN_PRO_Product_RefID;
			}
			set {
				if(_CMN_PRO_Product_RefID != value){
					_CMN_PRO_Product_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_PRO_Product_Variant_RefID { 
			get {
				return _CMN_PRO_Product_Variant_RefID;
			}
			set {
				if(_CMN_PRO_Product_Variant_RefID != value){
					_CMN_PRO_Product_Variant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_PRO_Product_Release_RefID { 
			get {
				return _CMN_PRO_Product_Release_RefID;
			}
			set {
				if(_CMN_PRO_Product_Release_RefID != value){
					_CMN_PRO_Product_Release_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime ExpirationDate { 
			get {
				return _ExpirationDate;
			}
			set {
				if(_ExpirationDate != value){
					_ExpirationDate = value;
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
		public double InitialQuantityOnTrackingInstance { 
			get {
				return _InitialQuantityOnTrackingInstance;
			}
			set {
				if(_InitialQuantityOnTrackingInstance != value){
					_InitialQuantityOnTrackingInstance = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double CurrentQuantityOnTrackingInstance { 
			get {
				return _CurrentQuantityOnTrackingInstance;
			}
			set {
				if(_CurrentQuantityOnTrackingInstance != value){
					_CurrentQuantityOnTrackingInstance = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double R_ReservedQuantity { 
			get {
				return _R_ReservedQuantity;
			}
			set {
				if(_R_ReservedQuantity != value){
					_R_ReservedQuantity = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double R_FreeQuantity { 
			get {
				return _R_FreeQuantity;
			}
			set {
				if(_R_FreeQuantity != value){
					_R_FreeQuantity = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG.LOG_ProductTrackingInstance.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG.LOG_ProductTrackingInstance.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LOG_ProductTrackingInstanceID", _LOG_ProductTrackingInstanceID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TrackingInstanceTakenFromSourceTrackingInstance_RefID", _TrackingInstanceTakenFromSourceTrackingInstance_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TrackingCode", _TrackingCode);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SerialNumber", _SerialNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BatchNumber", _BatchNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OwnedBy_BusinessParticipant_RefID", _OwnedBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_Product_RefID", _CMN_PRO_Product_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_Product_Variant_RefID", _CMN_PRO_Product_Variant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_Product_Release_RefID", _CMN_PRO_Product_Release_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ExpirationDate", _ExpirationDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InitialQuantityOnTrackingInstance", _InitialQuantityOnTrackingInstance);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CurrentQuantityOnTrackingInstance", _CurrentQuantityOnTrackingInstance);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_ReservedQuantity", _R_ReservedQuantity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_FreeQuantity", _R_FreeQuantity);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);


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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_LOG.LOG_ProductTrackingInstance.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_LOG_ProductTrackingInstanceID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LOG_ProductTrackingInstanceID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_ProductTrackingInstanceID","TrackingInstanceTakenFromSourceTrackingInstance_RefID","TrackingCode","SerialNumber","BatchNumber","OwnedBy_BusinessParticipant_RefID","CMN_PRO_Product_RefID","CMN_PRO_Product_Variant_RefID","CMN_PRO_Product_Release_RefID","ExpirationDate","IsDeleted","Tenant_RefID","InitialQuantityOnTrackingInstance","CurrentQuantityOnTrackingInstance","R_ReservedQuantity","R_FreeQuantity","Creation_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter LOG_ProductTrackingInstanceID of type Guid
						_LOG_ProductTrackingInstanceID = reader.GetGuid(0);
						//1:Parameter TrackingInstanceTakenFromSourceTrackingInstance_RefID of type Guid
						_TrackingInstanceTakenFromSourceTrackingInstance_RefID = reader.GetGuid(1);
						//2:Parameter TrackingCode of type String
						_TrackingCode = reader.GetString(2);
						//3:Parameter SerialNumber of type String
						_SerialNumber = reader.GetString(3);
						//4:Parameter BatchNumber of type String
						_BatchNumber = reader.GetString(4);
						//5:Parameter OwnedBy_BusinessParticipant_RefID of type Guid
						_OwnedBy_BusinessParticipant_RefID = reader.GetGuid(5);
						//6:Parameter CMN_PRO_Product_RefID of type Guid
						_CMN_PRO_Product_RefID = reader.GetGuid(6);
						//7:Parameter CMN_PRO_Product_Variant_RefID of type Guid
						_CMN_PRO_Product_Variant_RefID = reader.GetGuid(7);
						//8:Parameter CMN_PRO_Product_Release_RefID of type Guid
						_CMN_PRO_Product_Release_RefID = reader.GetGuid(8);
						//9:Parameter ExpirationDate of type DateTime
						_ExpirationDate = reader.GetDate(9);
						//10:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(10);
						//11:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(11);
						//12:Parameter InitialQuantityOnTrackingInstance of type double
						_InitialQuantityOnTrackingInstance = reader.GetDouble(12);
						//13:Parameter CurrentQuantityOnTrackingInstance of type double
						_CurrentQuantityOnTrackingInstance = reader.GetDouble(13);
						//14:Parameter R_ReservedQuantity of type double
						_R_ReservedQuantity = reader.GetDouble(14);
						//15:Parameter R_FreeQuantity of type double
						_R_FreeQuantity = reader.GetDouble(15);
						//16:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(16);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_LOG_ProductTrackingInstanceID != Guid.Empty){
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
			public Guid? LOG_ProductTrackingInstanceID {	get; set; }
			public Guid? TrackingInstanceTakenFromSourceTrackingInstance_RefID {	get; set; }
			public String TrackingCode {	get; set; }
			public String SerialNumber {	get; set; }
			public String BatchNumber {	get; set; }
			public Guid? OwnedBy_BusinessParticipant_RefID {	get; set; }
			public Guid? CMN_PRO_Product_RefID {	get; set; }
			public Guid? CMN_PRO_Product_Variant_RefID {	get; set; }
			public Guid? CMN_PRO_Product_Release_RefID {	get; set; }
			public DateTime? ExpirationDate {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public double? InitialQuantityOnTrackingInstance {	get; set; }
			public double? CurrentQuantityOnTrackingInstance {	get; set; }
			public double? R_ReservedQuantity {	get; set; }
			public double? R_FreeQuantity {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			 

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
			public static List<ORM_LOG_ProductTrackingInstance> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_LOG_ProductTrackingInstance> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_LOG_ProductTrackingInstance> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_LOG_ProductTrackingInstance> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_LOG_ProductTrackingInstance> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_LOG_ProductTrackingInstance>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "LOG_ProductTrackingInstanceID","TrackingInstanceTakenFromSourceTrackingInstance_RefID","TrackingCode","SerialNumber","BatchNumber","OwnedBy_BusinessParticipant_RefID","CMN_PRO_Product_RefID","CMN_PRO_Product_Variant_RefID","CMN_PRO_Product_Release_RefID","ExpirationDate","IsDeleted","Tenant_RefID","InitialQuantityOnTrackingInstance","CurrentQuantityOnTrackingInstance","R_ReservedQuantity","R_FreeQuantity","Creation_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_LOG_ProductTrackingInstance item = new ORM_LOG_ProductTrackingInstance();
						//0:Parameter LOG_ProductTrackingInstanceID of type Guid
						item.LOG_ProductTrackingInstanceID = reader.GetGuid(0);
						//1:Parameter TrackingInstanceTakenFromSourceTrackingInstance_RefID of type Guid
						item.TrackingInstanceTakenFromSourceTrackingInstance_RefID = reader.GetGuid(1);
						//2:Parameter TrackingCode of type String
						item.TrackingCode = reader.GetString(2);
						//3:Parameter SerialNumber of type String
						item.SerialNumber = reader.GetString(3);
						//4:Parameter BatchNumber of type String
						item.BatchNumber = reader.GetString(4);
						//5:Parameter OwnedBy_BusinessParticipant_RefID of type Guid
						item.OwnedBy_BusinessParticipant_RefID = reader.GetGuid(5);
						//6:Parameter CMN_PRO_Product_RefID of type Guid
						item.CMN_PRO_Product_RefID = reader.GetGuid(6);
						//7:Parameter CMN_PRO_Product_Variant_RefID of type Guid
						item.CMN_PRO_Product_Variant_RefID = reader.GetGuid(7);
						//8:Parameter CMN_PRO_Product_Release_RefID of type Guid
						item.CMN_PRO_Product_Release_RefID = reader.GetGuid(8);
						//9:Parameter ExpirationDate of type DateTime
						item.ExpirationDate = reader.GetDate(9);
						//10:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(10);
						//11:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(11);
						//12:Parameter InitialQuantityOnTrackingInstance of type double
						item.InitialQuantityOnTrackingInstance = reader.GetDouble(12);
						//13:Parameter CurrentQuantityOnTrackingInstance of type double
						item.CurrentQuantityOnTrackingInstance = reader.GetDouble(13);
						//14:Parameter R_ReservedQuantity of type double
						item.R_ReservedQuantity = reader.GetDouble(14);
						//15:Parameter R_FreeQuantity of type double
						item.R_FreeQuantity = reader.GetDouble(15);
						//16:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(16);


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
