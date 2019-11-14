/* 
 * Generated on 1/16/2014 3:29:02 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_CMN
{
	[Serializable]
	public class ORM_CMN_Tenant
	{
		public static readonly string TableName = "cmn_tenants";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_Tenant()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_TenantID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_TenantID = default(Guid);
		private String _TenantITL = default(String);
		private Guid _UniversalContactDetail_RefID = default(Guid);
		private Guid _CMN_CAL_CalendarInstance_RefID = default(Guid);
		private Boolean _IsUsing_Offices = default(Boolean);
		private Boolean _IsUsing_WorkAreas = default(Boolean);
		private Boolean _IsUsing_Workplaces = default(Boolean);
		private Boolean _IsUsing_CostCenters = default(Boolean);
		private Guid _CMN_BPT_STA_SettingProfile_RefID = default(Guid);
		private String _DocumentServerRootURL = default(String);
		private Guid _Customers_DefaultPricelist_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_TenantID { 
			get {
				return _CMN_TenantID;
			}
			set {
				if(_CMN_TenantID != value){
					_CMN_TenantID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String TenantITL { 
			get {
				return _TenantITL;
			}
			set {
				if(_TenantITL != value){
					_TenantITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid UniversalContactDetail_RefID { 
			get {
				return _UniversalContactDetail_RefID;
			}
			set {
				if(_UniversalContactDetail_RefID != value){
					_UniversalContactDetail_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_CAL_CalendarInstance_RefID { 
			get {
				return _CMN_CAL_CalendarInstance_RefID;
			}
			set {
				if(_CMN_CAL_CalendarInstance_RefID != value){
					_CMN_CAL_CalendarInstance_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsUsing_Offices { 
			get {
				return _IsUsing_Offices;
			}
			set {
				if(_IsUsing_Offices != value){
					_IsUsing_Offices = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsUsing_WorkAreas { 
			get {
				return _IsUsing_WorkAreas;
			}
			set {
				if(_IsUsing_WorkAreas != value){
					_IsUsing_WorkAreas = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsUsing_Workplaces { 
			get {
				return _IsUsing_Workplaces;
			}
			set {
				if(_IsUsing_Workplaces != value){
					_IsUsing_Workplaces = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsUsing_CostCenters { 
			get {
				return _IsUsing_CostCenters;
			}
			set {
				if(_IsUsing_CostCenters != value){
					_IsUsing_CostCenters = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_BPT_STA_SettingProfile_RefID { 
			get {
				return _CMN_BPT_STA_SettingProfile_RefID;
			}
			set {
				if(_CMN_BPT_STA_SettingProfile_RefID != value){
					_CMN_BPT_STA_SettingProfile_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String DocumentServerRootURL { 
			get {
				return _DocumentServerRootURL;
			}
			set {
				if(_DocumentServerRootURL != value){
					_DocumentServerRootURL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Customers_DefaultPricelist_RefID { 
			get {
				return _Customers_DefaultPricelist_RefID;
			}
			set {
				if(_Customers_DefaultPricelist_RefID != value){
					_Customers_DefaultPricelist_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN.CMN_Tenant.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN.CMN_Tenant.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_TenantID", _CMN_TenantID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TenantITL", _TenantITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "UniversalContactDetail_RefID", _UniversalContactDetail_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_CAL_CalendarInstance_RefID", _CMN_CAL_CalendarInstance_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsUsing_Offices", _IsUsing_Offices);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsUsing_WorkAreas", _IsUsing_WorkAreas);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsUsing_Workplaces", _IsUsing_Workplaces);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsUsing_CostCenters", _IsUsing_CostCenters);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_STA_SettingProfile_RefID", _CMN_BPT_STA_SettingProfile_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DocumentServerRootURL", _DocumentServerRootURL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Customers_DefaultPricelist_RefID", _Customers_DefaultPricelist_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN.CMN_Tenant.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_TenantID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_TenantID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_TenantID","TenantITL","UniversalContactDetail_RefID","CMN_CAL_CalendarInstance_RefID","IsUsing_Offices","IsUsing_WorkAreas","IsUsing_Workplaces","IsUsing_CostCenters","CMN_BPT_STA_SettingProfile_RefID","DocumentServerRootURL","Customers_DefaultPricelist_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_TenantID of type Guid
						_CMN_TenantID = reader.GetGuid(0);
						//1:Parameter TenantITL of type String
						_TenantITL = reader.GetString(1);
						//2:Parameter UniversalContactDetail_RefID of type Guid
						_UniversalContactDetail_RefID = reader.GetGuid(2);
						//3:Parameter CMN_CAL_CalendarInstance_RefID of type Guid
						_CMN_CAL_CalendarInstance_RefID = reader.GetGuid(3);
						//4:Parameter IsUsing_Offices of type Boolean
						_IsUsing_Offices = reader.GetBoolean(4);
						//5:Parameter IsUsing_WorkAreas of type Boolean
						_IsUsing_WorkAreas = reader.GetBoolean(5);
						//6:Parameter IsUsing_Workplaces of type Boolean
						_IsUsing_Workplaces = reader.GetBoolean(6);
						//7:Parameter IsUsing_CostCenters of type Boolean
						_IsUsing_CostCenters = reader.GetBoolean(7);
						//8:Parameter CMN_BPT_STA_SettingProfile_RefID of type Guid
						_CMN_BPT_STA_SettingProfile_RefID = reader.GetGuid(8);
						//9:Parameter DocumentServerRootURL of type String
						_DocumentServerRootURL = reader.GetString(9);
						//10:Parameter Customers_DefaultPricelist_RefID of type Guid
						_Customers_DefaultPricelist_RefID = reader.GetGuid(10);
						//11:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(11);
						//12:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(12);
						//13:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(13);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_TenantID != Guid.Empty){
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
			public Guid? CMN_TenantID {	get; set; }
			public String TenantITL {	get; set; }
			public Guid? UniversalContactDetail_RefID {	get; set; }
			public Guid? CMN_CAL_CalendarInstance_RefID {	get; set; }
			public Boolean? IsUsing_Offices {	get; set; }
			public Boolean? IsUsing_WorkAreas {	get; set; }
			public Boolean? IsUsing_Workplaces {	get; set; }
			public Boolean? IsUsing_CostCenters {	get; set; }
			public Guid? CMN_BPT_STA_SettingProfile_RefID {	get; set; }
			public String DocumentServerRootURL {	get; set; }
			public Guid? Customers_DefaultPricelist_RefID {	get; set; }
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
			public static List<ORM_CMN_Tenant> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_Tenant> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_Tenant> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_Tenant> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_Tenant> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_Tenant>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_TenantID","TenantITL","UniversalContactDetail_RefID","CMN_CAL_CalendarInstance_RefID","IsUsing_Offices","IsUsing_WorkAreas","IsUsing_Workplaces","IsUsing_CostCenters","CMN_BPT_STA_SettingProfile_RefID","DocumentServerRootURL","Customers_DefaultPricelist_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_Tenant item = new ORM_CMN_Tenant();
						//0:Parameter CMN_TenantID of type Guid
						item.CMN_TenantID = reader.GetGuid(0);
						//1:Parameter TenantITL of type String
						item.TenantITL = reader.GetString(1);
						//2:Parameter UniversalContactDetail_RefID of type Guid
						item.UniversalContactDetail_RefID = reader.GetGuid(2);
						//3:Parameter CMN_CAL_CalendarInstance_RefID of type Guid
						item.CMN_CAL_CalendarInstance_RefID = reader.GetGuid(3);
						//4:Parameter IsUsing_Offices of type Boolean
						item.IsUsing_Offices = reader.GetBoolean(4);
						//5:Parameter IsUsing_WorkAreas of type Boolean
						item.IsUsing_WorkAreas = reader.GetBoolean(5);
						//6:Parameter IsUsing_Workplaces of type Boolean
						item.IsUsing_Workplaces = reader.GetBoolean(6);
						//7:Parameter IsUsing_CostCenters of type Boolean
						item.IsUsing_CostCenters = reader.GetBoolean(7);
						//8:Parameter CMN_BPT_STA_SettingProfile_RefID of type Guid
						item.CMN_BPT_STA_SettingProfile_RefID = reader.GetGuid(8);
						//9:Parameter DocumentServerRootURL of type String
						item.DocumentServerRootURL = reader.GetString(9);
						//10:Parameter Customers_DefaultPricelist_RefID of type Guid
						item.Customers_DefaultPricelist_RefID = reader.GetGuid(10);
						//11:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(11);
						//12:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(12);
						//13:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(13);


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
