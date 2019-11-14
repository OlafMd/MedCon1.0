/* 
 * Generated on 21-Nov-13 10:11:59
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
	public class ORM_CMN_PPS_ShiftTemplate
	{
		public static readonly string TableName = "cmn_pps_shifttemplates";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_PPS_ShiftTemplate()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_PPS_ShiftTemplateID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_PPS_ShiftTemplateID = default(Guid);
		private String _ShiftTemplate_ShortName = default(String);
		private Dict _ShiftTemplate_Name = new Dict(TableName);
		private Guid _CMN_STR_Office_RefID = default(Guid);
		private Guid _CMN_STR_Workarea_RefID = default(Guid);
		private Guid _CMN_STR_Workplace_RefID = default(Guid);
		private int _Default_StartTime_in_sec = default(int);
		private Boolean _IsWorkPattern = default(Boolean);
		private Guid _Default_AllowedBreakTimeTemplate_RefID = default(Guid);
		private String _DisplayColor = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_PPS_ShiftTemplateID { 
			get {
				return _CMN_PPS_ShiftTemplateID;
			}
			set {
				if(_CMN_PPS_ShiftTemplateID != value){
					_CMN_PPS_ShiftTemplateID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ShiftTemplate_ShortName { 
			get {
				return _ShiftTemplate_ShortName;
			}
			set {
				if(_ShiftTemplate_ShortName != value){
					_ShiftTemplate_ShortName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict ShiftTemplate_Name { 
			get {
				return _ShiftTemplate_Name;
			}
			set {
				if(_ShiftTemplate_Name != value){
					_ShiftTemplate_Name = value;
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
		public int Default_StartTime_in_sec { 
			get {
				return _Default_StartTime_in_sec;
			}
			set {
				if(_Default_StartTime_in_sec != value){
					_Default_StartTime_in_sec = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWorkPattern { 
			get {
				return _IsWorkPattern;
			}
			set {
				if(_IsWorkPattern != value){
					_IsWorkPattern = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Default_AllowedBreakTimeTemplate_RefID { 
			get {
				return _Default_AllowedBreakTimeTemplate_RefID;
			}
			set {
				if(_Default_AllowedBreakTimeTemplate_RefID != value){
					_Default_AllowedBreakTimeTemplate_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String DisplayColor { 
			get {
				return _DisplayColor;
			}
			set {
				if(_DisplayColor != value){
					_DisplayColor = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || ShiftTemplate_Name.IsDirty ;
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
								loader.Append(ShiftTemplate_Name,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PPS.CMN_PPS_ShiftTemplate.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PPS.CMN_PPS_ShiftTemplate.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PPS_ShiftTemplateID", _CMN_PPS_ShiftTemplateID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShiftTemplate_ShortName", _ShiftTemplate_ShortName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShiftTemplate_Name", _ShiftTemplate_Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_STR_Office_RefID", _CMN_STR_Office_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_STR_Workarea_RefID", _CMN_STR_Workarea_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_STR_Workplace_RefID", _CMN_STR_Workplace_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_StartTime_in_sec", _Default_StartTime_in_sec);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWorkPattern", _IsWorkPattern);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_AllowedBreakTimeTemplate_RefID", _Default_AllowedBreakTimeTemplate_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DisplayColor", _DisplayColor);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PPS.CMN_PPS_ShiftTemplate.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_PPS_ShiftTemplateID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_PPS_ShiftTemplateID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PPS_ShiftTemplateID","ShiftTemplate_ShortName","ShiftTemplate_Name_DictID","CMN_STR_Office_RefID","CMN_STR_Workarea_RefID","CMN_STR_Workplace_RefID","Default_StartTime_in_sec","IsWorkPattern","Default_AllowedBreakTimeTemplate_RefID","DisplayColor","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_PPS_ShiftTemplateID of type Guid
						_CMN_PPS_ShiftTemplateID = reader.GetGuid(0);
						//1:Parameter ShiftTemplate_ShortName of type String
						_ShiftTemplate_ShortName = reader.GetString(1);
						//2:Parameter ShiftTemplate_Name of type Dict
						_ShiftTemplate_Name = reader.GetDictionary(2);
						loader.Append(_ShiftTemplate_Name,TableName);
						//3:Parameter CMN_STR_Office_RefID of type Guid
						_CMN_STR_Office_RefID = reader.GetGuid(3);
						//4:Parameter CMN_STR_Workarea_RefID of type Guid
						_CMN_STR_Workarea_RefID = reader.GetGuid(4);
						//5:Parameter CMN_STR_Workplace_RefID of type Guid
						_CMN_STR_Workplace_RefID = reader.GetGuid(5);
						//6:Parameter Default_StartTime_in_sec of type int
						_Default_StartTime_in_sec = reader.GetInteger(6);
						//7:Parameter IsWorkPattern of type Boolean
						_IsWorkPattern = reader.GetBoolean(7);
						//8:Parameter Default_AllowedBreakTimeTemplate_RefID of type Guid
						_Default_AllowedBreakTimeTemplate_RefID = reader.GetGuid(8);
						//9:Parameter DisplayColor of type String
						_DisplayColor = reader.GetString(9);
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

					if(_CMN_PPS_ShiftTemplateID != Guid.Empty){
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
			public Guid? CMN_PPS_ShiftTemplateID {	get; set; }
			public String ShiftTemplate_ShortName {	get; set; }
			public Dict ShiftTemplate_Name {	get; set; }
			public Guid? CMN_STR_Office_RefID {	get; set; }
			public Guid? CMN_STR_Workarea_RefID {	get; set; }
			public Guid? CMN_STR_Workplace_RefID {	get; set; }
			public int? Default_StartTime_in_sec {	get; set; }
			public Boolean? IsWorkPattern {	get; set; }
			public Guid? Default_AllowedBreakTimeTemplate_RefID {	get; set; }
			public String DisplayColor {	get; set; }
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
					throw ex;
				}
			}
			#endregion

			#region Search
			public static List<ORM_CMN_PPS_ShiftTemplate> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_PPS_ShiftTemplate> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_PPS_ShiftTemplate> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_PPS_ShiftTemplate> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_PPS_ShiftTemplate> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_PPS_ShiftTemplate>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PPS_ShiftTemplateID","ShiftTemplate_ShortName","ShiftTemplate_Name_DictID","CMN_STR_Office_RefID","CMN_STR_Workarea_RefID","CMN_STR_Workplace_RefID","Default_StartTime_in_sec","IsWorkPattern","Default_AllowedBreakTimeTemplate_RefID","DisplayColor","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_PPS_ShiftTemplate item = new ORM_CMN_PPS_ShiftTemplate();
						//0:Parameter CMN_PPS_ShiftTemplateID of type Guid
						item.CMN_PPS_ShiftTemplateID = reader.GetGuid(0);
						//1:Parameter ShiftTemplate_ShortName of type String
						item.ShiftTemplate_ShortName = reader.GetString(1);
						//2:Parameter ShiftTemplate_Name of type Dict
						item.ShiftTemplate_Name = reader.GetDictionary(2);
						loader.Append(item.ShiftTemplate_Name,TableName);
						//3:Parameter CMN_STR_Office_RefID of type Guid
						item.CMN_STR_Office_RefID = reader.GetGuid(3);
						//4:Parameter CMN_STR_Workarea_RefID of type Guid
						item.CMN_STR_Workarea_RefID = reader.GetGuid(4);
						//5:Parameter CMN_STR_Workplace_RefID of type Guid
						item.CMN_STR_Workplace_RefID = reader.GetGuid(5);
						//6:Parameter Default_StartTime_in_sec of type int
						item.Default_StartTime_in_sec = reader.GetInteger(6);
						//7:Parameter IsWorkPattern of type Boolean
						item.IsWorkPattern = reader.GetBoolean(7);
						//8:Parameter Default_AllowedBreakTimeTemplate_RefID of type Guid
						item.Default_AllowedBreakTimeTemplate_RefID = reader.GetGuid(8);
						//9:Parameter DisplayColor of type String
						item.DisplayColor = reader.GetString(9);
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
