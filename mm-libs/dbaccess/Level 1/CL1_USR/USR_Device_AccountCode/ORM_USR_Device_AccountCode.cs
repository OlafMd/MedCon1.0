/* 
 * Generated on 12/4/2013 12:24:08 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_USR
{
	[Serializable]
	public class ORM_USR_Device_AccountCode
	{
		public static readonly string TableName = "usr_device_accountcodes";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_USR_Device_AccountCode()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_USR_Device_AccountCodeID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _USR_Device_AccountCodeID = default(Guid);
		private Guid _Account_RefID = default(Guid);
		private String _AccountCode_Value = default(String);
		private DateTime _AccountCode_ValidFrom = default(DateTime);
		private DateTime _AccountCode_ValidTo = default(DateTime);
		private Boolean _IsAccountCode_Expirable = default(Boolean);
		private Guid _AccountCode_CurrentStatus_RefID = default(Guid);
		private int _AccountCode_NumberOfAccesses_MaximumValue = default(int);
		private int _AccountCode_NumberOfAccesses_CurrentValue = default(int);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid USR_Device_AccountCodeID { 
			get {
				return _USR_Device_AccountCodeID;
			}
			set {
				if(_USR_Device_AccountCodeID != value){
					_USR_Device_AccountCodeID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Account_RefID { 
			get {
				return _Account_RefID;
			}
			set {
				if(_Account_RefID != value){
					_Account_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String AccountCode_Value { 
			get {
				return _AccountCode_Value;
			}
			set {
				if(_AccountCode_Value != value){
					_AccountCode_Value = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime AccountCode_ValidFrom { 
			get {
				return _AccountCode_ValidFrom;
			}
			set {
				if(_AccountCode_ValidFrom != value){
					_AccountCode_ValidFrom = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime AccountCode_ValidTo { 
			get {
				return _AccountCode_ValidTo;
			}
			set {
				if(_AccountCode_ValidTo != value){
					_AccountCode_ValidTo = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAccountCode_Expirable { 
			get {
				return _IsAccountCode_Expirable;
			}
			set {
				if(_IsAccountCode_Expirable != value){
					_IsAccountCode_Expirable = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid AccountCode_CurrentStatus_RefID { 
			get {
				return _AccountCode_CurrentStatus_RefID;
			}
			set {
				if(_AccountCode_CurrentStatus_RefID != value){
					_AccountCode_CurrentStatus_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int AccountCode_NumberOfAccesses_MaximumValue { 
			get {
				return _AccountCode_NumberOfAccesses_MaximumValue;
			}
			set {
				if(_AccountCode_NumberOfAccesses_MaximumValue != value){
					_AccountCode_NumberOfAccesses_MaximumValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int AccountCode_NumberOfAccesses_CurrentValue { 
			get {
				return _AccountCode_NumberOfAccesses_CurrentValue;
			}
			set {
				if(_AccountCode_NumberOfAccesses_CurrentValue != value){
					_AccountCode_NumberOfAccesses_CurrentValue = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_USR.USR_Device_AccountCode.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_USR.USR_Device_AccountCode.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "USR_Device_AccountCodeID", _USR_Device_AccountCodeID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Account_RefID", _Account_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AccountCode_Value", _AccountCode_Value);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AccountCode_ValidFrom", _AccountCode_ValidFrom);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AccountCode_ValidTo", _AccountCode_ValidTo);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAccountCode_Expirable", _IsAccountCode_Expirable);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AccountCode_CurrentStatus_RefID", _AccountCode_CurrentStatus_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AccountCode_NumberOfAccesses_MaximumValue", _AccountCode_NumberOfAccesses_MaximumValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AccountCode_NumberOfAccesses_CurrentValue", _AccountCode_NumberOfAccesses_CurrentValue);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_USR.USR_Device_AccountCode.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_USR_Device_AccountCodeID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"USR_Device_AccountCodeID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "USR_Device_AccountCodeID","Account_RefID","AccountCode_Value","AccountCode_ValidFrom","AccountCode_ValidTo","IsAccountCode_Expirable","AccountCode_CurrentStatus_RefID","AccountCode_NumberOfAccesses_MaximumValue","AccountCode_NumberOfAccesses_CurrentValue","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter USR_Device_AccountCodeID of type Guid
						_USR_Device_AccountCodeID = reader.GetGuid(0);
						//1:Parameter Account_RefID of type Guid
						_Account_RefID = reader.GetGuid(1);
						//2:Parameter AccountCode_Value of type String
						_AccountCode_Value = reader.GetString(2);
						//3:Parameter AccountCode_ValidFrom of type DateTime
						_AccountCode_ValidFrom = reader.GetDate(3);
						//4:Parameter AccountCode_ValidTo of type DateTime
						_AccountCode_ValidTo = reader.GetDate(4);
						//5:Parameter IsAccountCode_Expirable of type Boolean
						_IsAccountCode_Expirable = reader.GetBoolean(5);
						//6:Parameter AccountCode_CurrentStatus_RefID of type Guid
						_AccountCode_CurrentStatus_RefID = reader.GetGuid(6);
						//7:Parameter AccountCode_NumberOfAccesses_MaximumValue of type int
						_AccountCode_NumberOfAccesses_MaximumValue = reader.GetInteger(7);
						//8:Parameter AccountCode_NumberOfAccesses_CurrentValue of type int
						_AccountCode_NumberOfAccesses_CurrentValue = reader.GetInteger(8);
						//9:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(9);
						//10:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(10);
						//11:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(11);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_USR_Device_AccountCodeID != Guid.Empty){
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
			public Guid? USR_Device_AccountCodeID {	get; set; }
			public Guid? Account_RefID {	get; set; }
			public String AccountCode_Value {	get; set; }
			public DateTime? AccountCode_ValidFrom {	get; set; }
			public DateTime? AccountCode_ValidTo {	get; set; }
			public Boolean? IsAccountCode_Expirable {	get; set; }
			public Guid? AccountCode_CurrentStatus_RefID {	get; set; }
			public int? AccountCode_NumberOfAccesses_MaximumValue {	get; set; }
			public int? AccountCode_NumberOfAccesses_CurrentValue {	get; set; }
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
			public static List<ORM_USR_Device_AccountCode> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_USR_Device_AccountCode> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_USR_Device_AccountCode> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_USR_Device_AccountCode> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_USR_Device_AccountCode> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_USR_Device_AccountCode>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "USR_Device_AccountCodeID","Account_RefID","AccountCode_Value","AccountCode_ValidFrom","AccountCode_ValidTo","IsAccountCode_Expirable","AccountCode_CurrentStatus_RefID","AccountCode_NumberOfAccesses_MaximumValue","AccountCode_NumberOfAccesses_CurrentValue","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_USR_Device_AccountCode item = new ORM_USR_Device_AccountCode();
						//0:Parameter USR_Device_AccountCodeID of type Guid
						item.USR_Device_AccountCodeID = reader.GetGuid(0);
						//1:Parameter Account_RefID of type Guid
						item.Account_RefID = reader.GetGuid(1);
						//2:Parameter AccountCode_Value of type String
						item.AccountCode_Value = reader.GetString(2);
						//3:Parameter AccountCode_ValidFrom of type DateTime
						item.AccountCode_ValidFrom = reader.GetDate(3);
						//4:Parameter AccountCode_ValidTo of type DateTime
						item.AccountCode_ValidTo = reader.GetDate(4);
						//5:Parameter IsAccountCode_Expirable of type Boolean
						item.IsAccountCode_Expirable = reader.GetBoolean(5);
						//6:Parameter AccountCode_CurrentStatus_RefID of type Guid
						item.AccountCode_CurrentStatus_RefID = reader.GetGuid(6);
						//7:Parameter AccountCode_NumberOfAccesses_MaximumValue of type int
						item.AccountCode_NumberOfAccesses_MaximumValue = reader.GetInteger(7);
						//8:Parameter AccountCode_NumberOfAccesses_CurrentValue of type int
						item.AccountCode_NumberOfAccesses_CurrentValue = reader.GetInteger(8);
						//9:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(9);
						//10:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(10);
						//11:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(11);


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
