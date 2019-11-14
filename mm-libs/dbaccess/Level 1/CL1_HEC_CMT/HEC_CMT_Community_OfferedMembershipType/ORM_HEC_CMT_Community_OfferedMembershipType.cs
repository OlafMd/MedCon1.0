/* 
 * Generated on 20.03.2015 11:08:40
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC_CMT
{
	[Serializable]
	public class ORM_HEC_CMT_Community_OfferedMembershipType
	{
		public static readonly string TableName = "hec_cmt_community_offeredmembershiptypes";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_CMT_Community_OfferedMembershipType()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_CMT_Community_OfferedMembershipTypeID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_CMT_Community_OfferedMembershipTypeID = default(Guid);
		private String _HealthcareCommunityOfferedMembershipTypesITL = default(String);
		private Guid _Community_RefID = default(Guid);
		private String _OfferedMembershipType_DisplayName = default(String);
		private Dict _OfferedMembershipType_Name = new Dict(TableName);
		private Boolean _IsAvailableFor_Tenants = default(Boolean);
		private Boolean _IsAvailableFor_Doctors = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_CMT_Community_OfferedMembershipTypeID { 
			get {
				return _HEC_CMT_Community_OfferedMembershipTypeID;
			}
			set {
				if(_HEC_CMT_Community_OfferedMembershipTypeID != value){
					_HEC_CMT_Community_OfferedMembershipTypeID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String HealthcareCommunityOfferedMembershipTypesITL { 
			get {
				return _HealthcareCommunityOfferedMembershipTypesITL;
			}
			set {
				if(_HealthcareCommunityOfferedMembershipTypesITL != value){
					_HealthcareCommunityOfferedMembershipTypesITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Community_RefID { 
			get {
				return _Community_RefID;
			}
			set {
				if(_Community_RefID != value){
					_Community_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String OfferedMembershipType_DisplayName { 
			get {
				return _OfferedMembershipType_DisplayName;
			}
			set {
				if(_OfferedMembershipType_DisplayName != value){
					_OfferedMembershipType_DisplayName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict OfferedMembershipType_Name { 
			get {
				return _OfferedMembershipType_Name;
			}
			set {
				if(_OfferedMembershipType_Name != value){
					_OfferedMembershipType_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAvailableFor_Tenants { 
			get {
				return _IsAvailableFor_Tenants;
			}
			set {
				if(_IsAvailableFor_Tenants != value){
					_IsAvailableFor_Tenants = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAvailableFor_Doctors { 
			get {
				return _IsAvailableFor_Doctors;
			}
			set {
				if(_IsAvailableFor_Doctors != value){
					_IsAvailableFor_Doctors = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || OfferedMembershipType_Name.IsDirty ;
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
								loader.Append(OfferedMembershipType_Name,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_CMT.HEC_CMT_Community_OfferedMembershipType.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_CMT.HEC_CMT_Community_OfferedMembershipType.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_CMT_Community_OfferedMembershipTypeID", _HEC_CMT_Community_OfferedMembershipTypeID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HealthcareCommunityOfferedMembershipTypesITL", _HealthcareCommunityOfferedMembershipTypesITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Community_RefID", _Community_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OfferedMembershipType_DisplayName", _OfferedMembershipType_DisplayName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OfferedMembershipType_Name", _OfferedMembershipType_Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAvailableFor_Tenants", _IsAvailableFor_Tenants);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAvailableFor_Doctors", _IsAvailableFor_Doctors);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_CMT.HEC_CMT_Community_OfferedMembershipType.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_CMT_Community_OfferedMembershipTypeID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_CMT_Community_OfferedMembershipTypeID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_CMT_Community_OfferedMembershipTypeID","HealthcareCommunityOfferedMembershipTypesITL","Community_RefID","OfferedMembershipType_DisplayName","OfferedMembershipType_Name_DictID","IsAvailableFor_Tenants","IsAvailableFor_Doctors","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_CMT_Community_OfferedMembershipTypeID of type Guid
						_HEC_CMT_Community_OfferedMembershipTypeID = reader.GetGuid(0);
						//1:Parameter HealthcareCommunityOfferedMembershipTypesITL of type String
						_HealthcareCommunityOfferedMembershipTypesITL = reader.GetString(1);
						//2:Parameter Community_RefID of type Guid
						_Community_RefID = reader.GetGuid(2);
						//3:Parameter OfferedMembershipType_DisplayName of type String
						_OfferedMembershipType_DisplayName = reader.GetString(3);
						//4:Parameter OfferedMembershipType_Name of type Dict
						_OfferedMembershipType_Name = reader.GetDictionary(4);
						loader.Append(_OfferedMembershipType_Name,TableName);
						//5:Parameter IsAvailableFor_Tenants of type Boolean
						_IsAvailableFor_Tenants = reader.GetBoolean(5);
						//6:Parameter IsAvailableFor_Doctors of type Boolean
						_IsAvailableFor_Doctors = reader.GetBoolean(6);
						//7:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(7);
						//8:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(8);
						//9:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(9);
						//10:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(10);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_CMT_Community_OfferedMembershipTypeID != Guid.Empty){
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
			public Guid? HEC_CMT_Community_OfferedMembershipTypeID {	get; set; }
			public String HealthcareCommunityOfferedMembershipTypesITL {	get; set; }
			public Guid? Community_RefID {	get; set; }
			public String OfferedMembershipType_DisplayName {	get; set; }
			public Dict OfferedMembershipType_Name {	get; set; }
			public Boolean? IsAvailableFor_Tenants {	get; set; }
			public Boolean? IsAvailableFor_Doctors {	get; set; }
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
			public static List<ORM_HEC_CMT_Community_OfferedMembershipType> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_CMT_Community_OfferedMembershipType> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_CMT_Community_OfferedMembershipType> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_CMT_Community_OfferedMembershipType> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_CMT_Community_OfferedMembershipType> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_CMT_Community_OfferedMembershipType>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_CMT_Community_OfferedMembershipTypeID","HealthcareCommunityOfferedMembershipTypesITL","Community_RefID","OfferedMembershipType_DisplayName","OfferedMembershipType_Name_DictID","IsAvailableFor_Tenants","IsAvailableFor_Doctors","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_CMT_Community_OfferedMembershipType item = new ORM_HEC_CMT_Community_OfferedMembershipType();
						//0:Parameter HEC_CMT_Community_OfferedMembershipTypeID of type Guid
						item.HEC_CMT_Community_OfferedMembershipTypeID = reader.GetGuid(0);
						//1:Parameter HealthcareCommunityOfferedMembershipTypesITL of type String
						item.HealthcareCommunityOfferedMembershipTypesITL = reader.GetString(1);
						//2:Parameter Community_RefID of type Guid
						item.Community_RefID = reader.GetGuid(2);
						//3:Parameter OfferedMembershipType_DisplayName of type String
						item.OfferedMembershipType_DisplayName = reader.GetString(3);
						//4:Parameter OfferedMembershipType_Name of type Dict
						item.OfferedMembershipType_Name = reader.GetDictionary(4);
						loader.Append(item.OfferedMembershipType_Name,TableName);
						//5:Parameter IsAvailableFor_Tenants of type Boolean
						item.IsAvailableFor_Tenants = reader.GetBoolean(5);
						//6:Parameter IsAvailableFor_Doctors of type Boolean
						item.IsAvailableFor_Doctors = reader.GetBoolean(6);
						//7:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(7);
						//8:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(8);
						//9:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(9);
						//10:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(10);


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
