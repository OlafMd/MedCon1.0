/* 
 * Generated on 09/12/2014 16:02:40
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_PPS
{
	[Serializable]
	public class ORM_CMN_PPS_ShiftTemplate_Group
	{
		public static readonly string TableName = "cmn_pps_shifttemplate_groups";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_PPS_ShiftTemplate_Group()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_PPS_ShiftTemplate_GroupID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_PPS_ShiftTemplate_GroupID = default(Guid);
		private String _GroupShortName = default(String);
		private Dict _GroupName = new Dict(TableName);
		private Guid _CMN_STR_Office_RefID = default(Guid);
		private Guid _CMN_STR_Workarea_RefID = default(Guid);
		private Guid _CMN_STR_Workplace_RefID = default(Guid);
		private Boolean _IsDefault_ForMonday = default(Boolean);
		private Boolean _IsDefault_ForTuesday = default(Boolean);
		private Boolean _IsDefault_ForWednesday = default(Boolean);
		private Boolean _IsDefault_ForThursday = default(Boolean);
		private Boolean _IsDefault_ForFriday = default(Boolean);
		private Boolean _IsDefault_ForSaturday = default(Boolean);
		private Boolean _IsDefault_ForSunday = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_PPS_ShiftTemplate_GroupID { 
			get {
				return _CMN_PPS_ShiftTemplate_GroupID;
			}
			set {
				if(_CMN_PPS_ShiftTemplate_GroupID != value){
					_CMN_PPS_ShiftTemplate_GroupID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String GroupShortName { 
			get {
				return _GroupShortName;
			}
			set {
				if(_GroupShortName != value){
					_GroupShortName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict GroupName { 
			get {
				return _GroupName;
			}
			set {
				if(_GroupName != value){
					_GroupName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_STR_Office_RefID { 
			get {
				return _CMN_STR_Office_RefID;
			}
			set {
				if(_CMN_STR_Office_RefID != value){
					_CMN_STR_Office_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_STR_Workarea_RefID { 
			get {
				return _CMN_STR_Workarea_RefID;
			}
			set {
				if(_CMN_STR_Workarea_RefID != value){
					_CMN_STR_Workarea_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_STR_Workplace_RefID { 
			get {
				return _CMN_STR_Workplace_RefID;
			}
			set {
				if(_CMN_STR_Workplace_RefID != value){
					_CMN_STR_Workplace_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDefault_ForMonday { 
			get {
				return _IsDefault_ForMonday;
			}
			set {
				if(_IsDefault_ForMonday != value){
					_IsDefault_ForMonday = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDefault_ForTuesday { 
			get {
				return _IsDefault_ForTuesday;
			}
			set {
				if(_IsDefault_ForTuesday != value){
					_IsDefault_ForTuesday = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDefault_ForWednesday { 
			get {
				return _IsDefault_ForWednesday;
			}
			set {
				if(_IsDefault_ForWednesday != value){
					_IsDefault_ForWednesday = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDefault_ForThursday { 
			get {
				return _IsDefault_ForThursday;
			}
			set {
				if(_IsDefault_ForThursday != value){
					_IsDefault_ForThursday = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDefault_ForFriday { 
			get {
				return _IsDefault_ForFriday;
			}
			set {
				if(_IsDefault_ForFriday != value){
					_IsDefault_ForFriday = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDefault_ForSaturday { 
			get {
				return _IsDefault_ForSaturday;
			}
			set {
				if(_IsDefault_ForSaturday != value){
					_IsDefault_ForSaturday = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDefault_ForSunday { 
			get {
				return _IsDefault_ForSunday;
			}
			set {
				if(_IsDefault_ForSunday != value){
					_IsDefault_ForSunday = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || GroupName.IsDirty ;
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
								loader.Append(GroupName,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PPS.CMN_PPS_ShiftTemplate_Group.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PPS.CMN_PPS_ShiftTemplate_Group.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PPS_ShiftTemplate_GroupID", _CMN_PPS_ShiftTemplate_GroupID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "GroupShortName", _GroupShortName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "GroupName", _GroupName.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_STR_Office_RefID", _CMN_STR_Office_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_STR_Workarea_RefID", _CMN_STR_Workarea_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_STR_Workplace_RefID", _CMN_STR_Workplace_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDefault_ForMonday", _IsDefault_ForMonday);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDefault_ForTuesday", _IsDefault_ForTuesday);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDefault_ForWednesday", _IsDefault_ForWednesday);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDefault_ForThursday", _IsDefault_ForThursday);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDefault_ForFriday", _IsDefault_ForFriday);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDefault_ForSaturday", _IsDefault_ForSaturday);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDefault_ForSunday", _IsDefault_ForSunday);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PPS.CMN_PPS_ShiftTemplate_Group.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_PPS_ShiftTemplate_GroupID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_PPS_ShiftTemplate_GroupID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PPS_ShiftTemplate_GroupID","GroupShortName","GroupName_DictID","CMN_STR_Office_RefID","CMN_STR_Workarea_RefID","CMN_STR_Workplace_RefID","IsDefault_ForMonday","IsDefault_ForTuesday","IsDefault_ForWednesday","IsDefault_ForThursday","IsDefault_ForFriday","IsDefault_ForSaturday","IsDefault_ForSunday","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_PPS_ShiftTemplate_GroupID of type Guid
						_CMN_PPS_ShiftTemplate_GroupID = reader.GetGuid(0);
						//1:Parameter GroupShortName of type String
						_GroupShortName = reader.GetString(1);
						//2:Parameter GroupName of type Dict
						_GroupName = reader.GetDictionary(2);
						loader.Append(_GroupName,TableName);
						//3:Parameter CMN_STR_Office_RefID of type Guid
						_CMN_STR_Office_RefID = reader.GetGuid(3);
						//4:Parameter CMN_STR_Workarea_RefID of type Guid
						_CMN_STR_Workarea_RefID = reader.GetGuid(4);
						//5:Parameter CMN_STR_Workplace_RefID of type Guid
						_CMN_STR_Workplace_RefID = reader.GetGuid(5);
						//6:Parameter IsDefault_ForMonday of type Boolean
						_IsDefault_ForMonday = reader.GetBoolean(6);
						//7:Parameter IsDefault_ForTuesday of type Boolean
						_IsDefault_ForTuesday = reader.GetBoolean(7);
						//8:Parameter IsDefault_ForWednesday of type Boolean
						_IsDefault_ForWednesday = reader.GetBoolean(8);
						//9:Parameter IsDefault_ForThursday of type Boolean
						_IsDefault_ForThursday = reader.GetBoolean(9);
						//10:Parameter IsDefault_ForFriday of type Boolean
						_IsDefault_ForFriday = reader.GetBoolean(10);
						//11:Parameter IsDefault_ForSaturday of type Boolean
						_IsDefault_ForSaturday = reader.GetBoolean(11);
						//12:Parameter IsDefault_ForSunday of type Boolean
						_IsDefault_ForSunday = reader.GetBoolean(12);
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

					if(_CMN_PPS_ShiftTemplate_GroupID != Guid.Empty){
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
			public Guid? CMN_PPS_ShiftTemplate_GroupID {	get; set; }
			public String GroupShortName {	get; set; }
			public Dict GroupName {	get; set; }
			public Guid? CMN_STR_Office_RefID {	get; set; }
			public Guid? CMN_STR_Workarea_RefID {	get; set; }
			public Guid? CMN_STR_Workplace_RefID {	get; set; }
			public Boolean? IsDefault_ForMonday {	get; set; }
			public Boolean? IsDefault_ForTuesday {	get; set; }
			public Boolean? IsDefault_ForWednesday {	get; set; }
			public Boolean? IsDefault_ForThursday {	get; set; }
			public Boolean? IsDefault_ForFriday {	get; set; }
			public Boolean? IsDefault_ForSaturday {	get; set; }
			public Boolean? IsDefault_ForSunday {	get; set; }
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
			public static List<ORM_CMN_PPS_ShiftTemplate_Group> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_PPS_ShiftTemplate_Group> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_PPS_ShiftTemplate_Group> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_PPS_ShiftTemplate_Group> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_PPS_ShiftTemplate_Group> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_PPS_ShiftTemplate_Group>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PPS_ShiftTemplate_GroupID","GroupShortName","GroupName_DictID","CMN_STR_Office_RefID","CMN_STR_Workarea_RefID","CMN_STR_Workplace_RefID","IsDefault_ForMonday","IsDefault_ForTuesday","IsDefault_ForWednesday","IsDefault_ForThursday","IsDefault_ForFriday","IsDefault_ForSaturday","IsDefault_ForSunday","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_CMN_PPS_ShiftTemplate_Group item = new ORM_CMN_PPS_ShiftTemplate_Group();
						//0:Parameter CMN_PPS_ShiftTemplate_GroupID of type Guid
						item.CMN_PPS_ShiftTemplate_GroupID = reader.GetGuid(0);
						//1:Parameter GroupShortName of type String
						item.GroupShortName = reader.GetString(1);
						//2:Parameter GroupName of type Dict
						item.GroupName = reader.GetDictionary(2);
						loader.Append(item.GroupName,TableName);
						//3:Parameter CMN_STR_Office_RefID of type Guid
						item.CMN_STR_Office_RefID = reader.GetGuid(3);
						//4:Parameter CMN_STR_Workarea_RefID of type Guid
						item.CMN_STR_Workarea_RefID = reader.GetGuid(4);
						//5:Parameter CMN_STR_Workplace_RefID of type Guid
						item.CMN_STR_Workplace_RefID = reader.GetGuid(5);
						//6:Parameter IsDefault_ForMonday of type Boolean
						item.IsDefault_ForMonday = reader.GetBoolean(6);
						//7:Parameter IsDefault_ForTuesday of type Boolean
						item.IsDefault_ForTuesday = reader.GetBoolean(7);
						//8:Parameter IsDefault_ForWednesday of type Boolean
						item.IsDefault_ForWednesday = reader.GetBoolean(8);
						//9:Parameter IsDefault_ForThursday of type Boolean
						item.IsDefault_ForThursday = reader.GetBoolean(9);
						//10:Parameter IsDefault_ForFriday of type Boolean
						item.IsDefault_ForFriday = reader.GetBoolean(10);
						//11:Parameter IsDefault_ForSaturday of type Boolean
						item.IsDefault_ForSaturday = reader.GetBoolean(11);
						//12:Parameter IsDefault_ForSunday of type Boolean
						item.IsDefault_ForSunday = reader.GetBoolean(12);
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
