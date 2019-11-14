/* 
 * Generated on 6/18/2013 4:51:11 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_STR_PPS
{
	[Serializable]
	public class ORM_CMN_STR_PPS_WorkArea
	{
		public static readonly string TableName = "cmn_str_pps_workareas";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_STR_PPS_WorkArea()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_STR_PPS_WorkAreaID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_STR_PPS_WorkAreaID = default(Guid);
		private Guid _Office_RefID = default(Guid);
		private Guid _CMN_BPT_STA_SettingProfile_RefID = default(Guid);
		private Guid _Parent_RefID = default(Guid);
		private Guid _WorkArea_Type_RefID = default(Guid);
		private Dict _Name = new Dict(TableName);
		private Dict _Description = new Dict(TableName);
		private Guid _CMN_CAL_CalendarInstance_RefID = default(Guid);
		private int _Default_StartWorkingHour = default(int);
		private String _ShortName = default(String);
		private Boolean _IsMockObject = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_STR_PPS_WorkAreaID { 
			get {
				return _CMN_STR_PPS_WorkAreaID;
			}
			set {
				if(_CMN_STR_PPS_WorkAreaID != value){
					_CMN_STR_PPS_WorkAreaID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Office_RefID { 
			get {
				return _Office_RefID;
			}
			set {
				if(_Office_RefID != value){
					_Office_RefID = value;
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
		public Guid Parent_RefID { 
			get {
				return _Parent_RefID;
			}
			set {
				if(_Parent_RefID != value){
					_Parent_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid WorkArea_Type_RefID { 
			get {
				return _WorkArea_Type_RefID;
			}
			set {
				if(_WorkArea_Type_RefID != value){
					_WorkArea_Type_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Name { 
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
		public Dict Description { 
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
		public int Default_StartWorkingHour { 
			get {
				return _Default_StartWorkingHour;
			}
			set {
				if(_Default_StartWorkingHour != value){
					_Default_StartWorkingHour = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ShortName { 
			get {
				return _ShortName;
			}
			set {
				if(_ShortName != value){
					_ShortName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsMockObject { 
			get {
				return _IsMockObject;
			}
			set {
				if(_IsMockObject != value){
					_IsMockObject = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || Name.IsDirty || Description.IsDirty ;
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
								loader.Append(Name,TableName);
								loader.Append(Description,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_PPS.CMN_STR_PPS_WorkArea.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_PPS.CMN_STR_PPS_WorkArea.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_STR_PPS_WorkAreaID", _CMN_STR_PPS_WorkAreaID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Office_RefID", _Office_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_STA_SettingProfile_RefID", _CMN_BPT_STA_SettingProfile_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Parent_RefID", _Parent_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkArea_Type_RefID", _WorkArea_Type_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Name", _Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Description", _Description.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_CAL_CalendarInstance_RefID", _CMN_CAL_CalendarInstance_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_StartWorkingHour", _Default_StartWorkingHour);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShortName", _ShortName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsMockObject", _IsMockObject);
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
						throw ex;
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

				throw ex;
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_PPS.CMN_STR_PPS_WorkArea.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_STR_PPS_WorkAreaID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_STR_PPS_WorkAreaID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_STR_PPS_WorkAreaID","Office_RefID","CMN_BPT_STA_SettingProfile_RefID","Parent_RefID","WorkArea_Type_RefID","Name_DictID","Description_DictID","CMN_CAL_CalendarInstance_RefID","Default_StartWorkingHour","ShortName","IsMockObject","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_STR_PPS_WorkAreaID of type Guid
						_CMN_STR_PPS_WorkAreaID = reader.GetGuid(0);
						//1:Parameter Office_RefID of type Guid
						_Office_RefID = reader.GetGuid(1);
						//2:Parameter CMN_BPT_STA_SettingProfile_RefID of type Guid
						_CMN_BPT_STA_SettingProfile_RefID = reader.GetGuid(2);
						//3:Parameter Parent_RefID of type Guid
						_Parent_RefID = reader.GetGuid(3);
						//4:Parameter WorkArea_Type_RefID of type Guid
						_WorkArea_Type_RefID = reader.GetGuid(4);
						//5:Parameter Name of type Dict
						_Name = reader.GetDictionary(5);
						loader.Append(_Name,TableName);
						//6:Parameter Description of type Dict
						_Description = reader.GetDictionary(6);
						loader.Append(_Description,TableName);
						//7:Parameter CMN_CAL_CalendarInstance_RefID of type Guid
						_CMN_CAL_CalendarInstance_RefID = reader.GetGuid(7);
						//8:Parameter Default_StartWorkingHour of type int
						_Default_StartWorkingHour = reader.GetInteger(8);
						//9:Parameter ShortName of type String
						_ShortName = reader.GetString(9);
						//10:Parameter IsMockObject of type Boolean
						_IsMockObject = reader.GetBoolean(10);
						//11:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(11);
						//12:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(12);
						//13:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(13);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_STR_PPS_WorkAreaID != Guid.Empty){
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
					throw ex;
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

				throw ex;
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
			public Guid? CMN_STR_PPS_WorkAreaID {	get; set; }
			public Guid? Office_RefID {	get; set; }
			public Guid? CMN_BPT_STA_SettingProfile_RefID {	get; set; }
			public Guid? Parent_RefID {	get; set; }
			public Guid? WorkArea_Type_RefID {	get; set; }
			public Dict Name {	get; set; }
			public Dict Description {	get; set; }
			public Guid? CMN_CAL_CalendarInstance_RefID {	get; set; }
			public int? Default_StartWorkingHour {	get; set; }
			public String ShortName {	get; set; }
			public Boolean? IsMockObject {	get; set; }
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
					throw ex;
				}
			}
			#endregion

			#region Search
			public static List<ORM_CMN_STR_PPS_WorkArea> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_STR_PPS_WorkArea> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_STR_PPS_WorkArea> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_STR_PPS_WorkArea> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_STR_PPS_WorkArea> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_STR_PPS_WorkArea>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_STR_PPS_WorkAreaID","Office_RefID","CMN_BPT_STA_SettingProfile_RefID","Parent_RefID","WorkArea_Type_RefID","Name_DictID","Description_DictID","CMN_CAL_CalendarInstance_RefID","Default_StartWorkingHour","ShortName","IsMockObject","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_STR_PPS_WorkArea item = new ORM_CMN_STR_PPS_WorkArea();
						//0:Parameter CMN_STR_PPS_WorkAreaID of type Guid
						item.CMN_STR_PPS_WorkAreaID = reader.GetGuid(0);
						//1:Parameter Office_RefID of type Guid
						item.Office_RefID = reader.GetGuid(1);
						//2:Parameter CMN_BPT_STA_SettingProfile_RefID of type Guid
						item.CMN_BPT_STA_SettingProfile_RefID = reader.GetGuid(2);
						//3:Parameter Parent_RefID of type Guid
						item.Parent_RefID = reader.GetGuid(3);
						//4:Parameter WorkArea_Type_RefID of type Guid
						item.WorkArea_Type_RefID = reader.GetGuid(4);
						//5:Parameter Name of type Dict
						item.Name = reader.GetDictionary(5);
						loader.Append(item.Name,TableName);
						//6:Parameter Description of type Dict
						item.Description = reader.GetDictionary(6);
						loader.Append(item.Description,TableName);
						//7:Parameter CMN_CAL_CalendarInstance_RefID of type Guid
						item.CMN_CAL_CalendarInstance_RefID = reader.GetGuid(7);
						//8:Parameter Default_StartWorkingHour of type int
						item.Default_StartWorkingHour = reader.GetInteger(8);
						//9:Parameter ShortName of type String
						item.ShortName = reader.GetString(9);
						//10:Parameter IsMockObject of type Boolean
						item.IsMockObject = reader.GetBoolean(10);
						//11:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(11);
						//12:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(12);
						//13:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(13);


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
			        throw ex;
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
					throw ex;
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
					throw ex;
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
					throw ex;
				}
			}
			#endregion			
		}
		#endregion
	}	
}
