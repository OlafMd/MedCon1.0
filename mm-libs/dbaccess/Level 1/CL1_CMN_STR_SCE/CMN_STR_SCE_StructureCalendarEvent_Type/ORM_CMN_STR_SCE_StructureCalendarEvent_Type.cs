/* 
 * Generated on 6/18/2013 4:52:36 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_STR_SCE
{
	[Serializable]
	public class ORM_CMN_STR_SCE_StructureCalendarEvent_Type
	{
		public static readonly string TableName = "cmn_str_sce_structurecalendarevent_types";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_STR_SCE_StructureCalendarEvent_Type()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_STR_SCE_StructureCalendarEvent_TypeID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_STR_SCE_StructureCalendarEvent_TypeID = default(Guid);
		private Dict _CalendaEventName = new Dict(TableName);
		private Guid _EventIcon_RefID = default(Guid);
		private int _PriorityOrdinal = default(int);
		private String _ColorCode_Foreground = default(String);
		private String _ColorCode_Background = default(String);
		private Double _ColorCode_Alpha = default(Double);
		private Boolean _IsShowingNotification = default(Boolean);
		private Boolean _IsWorkingDay = default(Boolean);
		private Boolean _IsHalfWorkingDay = default(Boolean);
		private Boolean _IsNonWorkingDay = default(Boolean);
		private String _InternalEventTypeID = default(String);
		private Boolean _IsEventType_Imported = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_STR_SCE_StructureCalendarEvent_TypeID { 
			get {
				return _CMN_STR_SCE_StructureCalendarEvent_TypeID;
			}
			set {
				if(_CMN_STR_SCE_StructureCalendarEvent_TypeID != value){
					_CMN_STR_SCE_StructureCalendarEvent_TypeID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict CalendaEventName { 
			get {
				return _CalendaEventName;
			}
			set {
				if(_CalendaEventName != value){
					_CalendaEventName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid EventIcon_RefID { 
			get {
				return _EventIcon_RefID;
			}
			set {
				if(_EventIcon_RefID != value){
					_EventIcon_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int PriorityOrdinal { 
			get {
				return _PriorityOrdinal;
			}
			set {
				if(_PriorityOrdinal != value){
					_PriorityOrdinal = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ColorCode_Foreground { 
			get {
				return _ColorCode_Foreground;
			}
			set {
				if(_ColorCode_Foreground != value){
					_ColorCode_Foreground = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ColorCode_Background { 
			get {
				return _ColorCode_Background;
			}
			set {
				if(_ColorCode_Background != value){
					_ColorCode_Background = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double ColorCode_Alpha { 
			get {
				return _ColorCode_Alpha;
			}
			set {
				if(_ColorCode_Alpha != value){
					_ColorCode_Alpha = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsShowingNotification { 
			get {
				return _IsShowingNotification;
			}
			set {
				if(_IsShowingNotification != value){
					_IsShowingNotification = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWorkingDay { 
			get {
				return _IsWorkingDay;
			}
			set {
				if(_IsWorkingDay != value){
					_IsWorkingDay = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsHalfWorkingDay { 
			get {
				return _IsHalfWorkingDay;
			}
			set {
				if(_IsHalfWorkingDay != value){
					_IsHalfWorkingDay = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsNonWorkingDay { 
			get {
				return _IsNonWorkingDay;
			}
			set {
				if(_IsNonWorkingDay != value){
					_IsNonWorkingDay = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String InternalEventTypeID { 
			get {
				return _InternalEventTypeID;
			}
			set {
				if(_InternalEventTypeID != value){
					_InternalEventTypeID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsEventType_Imported { 
			get {
				return _IsEventType_Imported;
			}
			set {
				if(_IsEventType_Imported != value){
					_IsEventType_Imported = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || CalendaEventName.IsDirty ;
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
								loader.Append(CalendaEventName,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_SCE.CMN_STR_SCE_StructureCalendarEvent_Type.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_SCE.CMN_STR_SCE_StructureCalendarEvent_Type.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_STR_SCE_StructureCalendarEvent_TypeID", _CMN_STR_SCE_StructureCalendarEvent_TypeID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CalendaEventName", _CalendaEventName.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "EventIcon_RefID", _EventIcon_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PriorityOrdinal", _PriorityOrdinal);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ColorCode_Foreground", _ColorCode_Foreground);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ColorCode_Background", _ColorCode_Background);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ColorCode_Alpha", _ColorCode_Alpha);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsShowingNotification", _IsShowingNotification);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWorkingDay", _IsWorkingDay);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsHalfWorkingDay", _IsHalfWorkingDay);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsNonWorkingDay", _IsNonWorkingDay);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InternalEventTypeID", _InternalEventTypeID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsEventType_Imported", _IsEventType_Imported);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_SCE.CMN_STR_SCE_StructureCalendarEvent_Type.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_STR_SCE_StructureCalendarEvent_TypeID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_STR_SCE_StructureCalendarEvent_TypeID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_STR_SCE_StructureCalendarEvent_TypeID","CalendaEventName_DictID","EventIcon_RefID","PriorityOrdinal","ColorCode_Foreground","ColorCode_Background","ColorCode_Alpha","IsShowingNotification","IsWorkingDay","IsHalfWorkingDay","IsNonWorkingDay","InternalEventTypeID","IsEventType_Imported","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_STR_SCE_StructureCalendarEvent_TypeID of type Guid
						_CMN_STR_SCE_StructureCalendarEvent_TypeID = reader.GetGuid(0);
						//1:Parameter CalendaEventName of type Dict
						_CalendaEventName = reader.GetDictionary(1);
						loader.Append(_CalendaEventName,TableName);
						//2:Parameter EventIcon_RefID of type Guid
						_EventIcon_RefID = reader.GetGuid(2);
						//3:Parameter PriorityOrdinal of type int
						_PriorityOrdinal = reader.GetInteger(3);
						//4:Parameter ColorCode_Foreground of type String
						_ColorCode_Foreground = reader.GetString(4);
						//5:Parameter ColorCode_Background of type String
						_ColorCode_Background = reader.GetString(5);
						//6:Parameter ColorCode_Alpha of type Double
						_ColorCode_Alpha = reader.GetDouble(6);
						//7:Parameter IsShowingNotification of type Boolean
						_IsShowingNotification = reader.GetBoolean(7);
						//8:Parameter IsWorkingDay of type Boolean
						_IsWorkingDay = reader.GetBoolean(8);
						//9:Parameter IsHalfWorkingDay of type Boolean
						_IsHalfWorkingDay = reader.GetBoolean(9);
						//10:Parameter IsNonWorkingDay of type Boolean
						_IsNonWorkingDay = reader.GetBoolean(10);
						//11:Parameter InternalEventTypeID of type String
						_InternalEventTypeID = reader.GetString(11);
						//12:Parameter IsEventType_Imported of type Boolean
						_IsEventType_Imported = reader.GetBoolean(12);
						//13:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(13);
						//14:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(14);
						//15:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(15);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_STR_SCE_StructureCalendarEvent_TypeID != Guid.Empty){
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
			public Guid? CMN_STR_SCE_StructureCalendarEvent_TypeID {	get; set; }
			public Dict CalendaEventName {	get; set; }
			public Guid? EventIcon_RefID {	get; set; }
			public int? PriorityOrdinal {	get; set; }
			public String ColorCode_Foreground {	get; set; }
			public String ColorCode_Background {	get; set; }
			public Double? ColorCode_Alpha {	get; set; }
			public Boolean? IsShowingNotification {	get; set; }
			public Boolean? IsWorkingDay {	get; set; }
			public Boolean? IsHalfWorkingDay {	get; set; }
			public Boolean? IsNonWorkingDay {	get; set; }
			public String InternalEventTypeID {	get; set; }
			public Boolean? IsEventType_Imported {	get; set; }
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
			public static List<ORM_CMN_STR_SCE_StructureCalendarEvent_Type> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_STR_SCE_StructureCalendarEvent_Type> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_STR_SCE_StructureCalendarEvent_Type> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_STR_SCE_StructureCalendarEvent_Type> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_STR_SCE_StructureCalendarEvent_Type> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_STR_SCE_StructureCalendarEvent_Type>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_STR_SCE_StructureCalendarEvent_TypeID","CalendaEventName_DictID","EventIcon_RefID","PriorityOrdinal","ColorCode_Foreground","ColorCode_Background","ColorCode_Alpha","IsShowingNotification","IsWorkingDay","IsHalfWorkingDay","IsNonWorkingDay","InternalEventTypeID","IsEventType_Imported","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_STR_SCE_StructureCalendarEvent_Type item = new ORM_CMN_STR_SCE_StructureCalendarEvent_Type();
						//0:Parameter CMN_STR_SCE_StructureCalendarEvent_TypeID of type Guid
						item.CMN_STR_SCE_StructureCalendarEvent_TypeID = reader.GetGuid(0);
						//1:Parameter CalendaEventName of type Dict
						item.CalendaEventName = reader.GetDictionary(1);
						loader.Append(item.CalendaEventName,TableName);
						//2:Parameter EventIcon_RefID of type Guid
						item.EventIcon_RefID = reader.GetGuid(2);
						//3:Parameter PriorityOrdinal of type int
						item.PriorityOrdinal = reader.GetInteger(3);
						//4:Parameter ColorCode_Foreground of type String
						item.ColorCode_Foreground = reader.GetString(4);
						//5:Parameter ColorCode_Background of type String
						item.ColorCode_Background = reader.GetString(5);
						//6:Parameter ColorCode_Alpha of type Double
						item.ColorCode_Alpha = reader.GetDouble(6);
						//7:Parameter IsShowingNotification of type Boolean
						item.IsShowingNotification = reader.GetBoolean(7);
						//8:Parameter IsWorkingDay of type Boolean
						item.IsWorkingDay = reader.GetBoolean(8);
						//9:Parameter IsHalfWorkingDay of type Boolean
						item.IsHalfWorkingDay = reader.GetBoolean(9);
						//10:Parameter IsNonWorkingDay of type Boolean
						item.IsNonWorkingDay = reader.GetBoolean(10);
						//11:Parameter InternalEventTypeID of type String
						item.InternalEventTypeID = reader.GetString(11);
						//12:Parameter IsEventType_Imported of type Boolean
						item.IsEventType_Imported = reader.GetBoolean(12);
						//13:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(13);
						//14:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(14);
						//15:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(15);


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
