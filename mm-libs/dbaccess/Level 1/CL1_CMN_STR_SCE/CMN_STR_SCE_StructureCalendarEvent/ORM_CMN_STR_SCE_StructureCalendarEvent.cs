/* 
 * Generated on 3/26/2014 2:38:34 PM
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
	public class ORM_CMN_STR_SCE_StructureCalendarEvent
	{
		public static readonly string TableName = "cmn_str_sce_structurecalendarevents";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_STR_SCE_StructureCalendarEvent()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_STR_SCE_StructureCalendarEventID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_STR_SCE_StructureCalendarEventID = default(Guid);
		private Guid _CMN_CAL_Event_RefID = default(Guid);
		private Dict _StructureEvent_Name = new Dict(TableName);
		private Dict _StructureEvent_Description = new Dict(TableName);
		private Guid _R_CalendarInstance_RefID = default(Guid);
		private Boolean _IsHavingCapacityRestriction = default(Boolean);
		private Guid _IfHavingCapacityRestriction_Restriction_RefID = default(Guid);
		private Guid _StructureCalendarEvent_Type_RefID = default(Guid);
		private Boolean _IsShowingNotification = default(Boolean);
		private Boolean _IsWorkingDayEvent = default(Boolean);
		private Boolean _IsWorkingHalfDayEvent = default(Boolean);
		private Boolean _IsNonWorkingDay = default(Boolean);
		private Boolean _IsEvent_ImportedFromTemplate = default(Boolean);
		private Boolean _IsBusinessDay = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_STR_SCE_StructureCalendarEventID { 
			get {
				return _CMN_STR_SCE_StructureCalendarEventID;
			}
			set {
				if(_CMN_STR_SCE_StructureCalendarEventID != value){
					_CMN_STR_SCE_StructureCalendarEventID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_CAL_Event_RefID { 
			get {
				return _CMN_CAL_Event_RefID;
			}
			set {
				if(_CMN_CAL_Event_RefID != value){
					_CMN_CAL_Event_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict StructureEvent_Name { 
			get {
				return _StructureEvent_Name;
			}
			set {
				if(_StructureEvent_Name != value){
					_StructureEvent_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict StructureEvent_Description { 
			get {
				return _StructureEvent_Description;
			}
			set {
				if(_StructureEvent_Description != value){
					_StructureEvent_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid R_CalendarInstance_RefID { 
			get {
				return _R_CalendarInstance_RefID;
			}
			set {
				if(_R_CalendarInstance_RefID != value){
					_R_CalendarInstance_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsHavingCapacityRestriction { 
			get {
				return _IsHavingCapacityRestriction;
			}
			set {
				if(_IsHavingCapacityRestriction != value){
					_IsHavingCapacityRestriction = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfHavingCapacityRestriction_Restriction_RefID { 
			get {
				return _IfHavingCapacityRestriction_Restriction_RefID;
			}
			set {
				if(_IfHavingCapacityRestriction_Restriction_RefID != value){
					_IfHavingCapacityRestriction_Restriction_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid StructureCalendarEvent_Type_RefID { 
			get {
				return _StructureCalendarEvent_Type_RefID;
			}
			set {
				if(_StructureCalendarEvent_Type_RefID != value){
					_StructureCalendarEvent_Type_RefID = value;
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
		public Boolean IsWorkingDayEvent { 
			get {
				return _IsWorkingDayEvent;
			}
			set {
				if(_IsWorkingDayEvent != value){
					_IsWorkingDayEvent = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWorkingHalfDayEvent { 
			get {
				return _IsWorkingHalfDayEvent;
			}
			set {
				if(_IsWorkingHalfDayEvent != value){
					_IsWorkingHalfDayEvent = value;
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
		public Boolean IsEvent_ImportedFromTemplate { 
			get {
				return _IsEvent_ImportedFromTemplate;
			}
			set {
				if(_IsEvent_ImportedFromTemplate != value){
					_IsEvent_ImportedFromTemplate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsBusinessDay { 
			get {
				return _IsBusinessDay;
			}
			set {
				if(_IsBusinessDay != value){
					_IsBusinessDay = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || StructureEvent_Name.IsDirty || StructureEvent_Description.IsDirty ;
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
								loader.Append(StructureEvent_Name,TableName);
								loader.Append(StructureEvent_Description,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_SCE.CMN_STR_SCE_StructureCalendarEvent.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_SCE.CMN_STR_SCE_StructureCalendarEvent.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_STR_SCE_StructureCalendarEventID", _CMN_STR_SCE_StructureCalendarEventID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_CAL_Event_RefID", _CMN_CAL_Event_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "StructureEvent_Name", _StructureEvent_Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "StructureEvent_Description", _StructureEvent_Description.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_CalendarInstance_RefID", _R_CalendarInstance_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsHavingCapacityRestriction", _IsHavingCapacityRestriction);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfHavingCapacityRestriction_Restriction_RefID", _IfHavingCapacityRestriction_Restriction_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "StructureCalendarEvent_Type_RefID", _StructureCalendarEvent_Type_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsShowingNotification", _IsShowingNotification);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWorkingDayEvent", _IsWorkingDayEvent);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWorkingHalfDayEvent", _IsWorkingHalfDayEvent);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsNonWorkingDay", _IsNonWorkingDay);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsEvent_ImportedFromTemplate", _IsEvent_ImportedFromTemplate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsBusinessDay", _IsBusinessDay);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR_SCE.CMN_STR_SCE_StructureCalendarEvent.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_STR_SCE_StructureCalendarEventID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_STR_SCE_StructureCalendarEventID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_STR_SCE_StructureCalendarEventID","CMN_CAL_Event_RefID","StructureEvent_Name_DictID","StructureEvent_Description_DictID","R_CalendarInstance_RefID","IsHavingCapacityRestriction","IfHavingCapacityRestriction_Restriction_RefID","StructureCalendarEvent_Type_RefID","IsShowingNotification","IsWorkingDayEvent","IsWorkingHalfDayEvent","IsNonWorkingDay","IsEvent_ImportedFromTemplate","IsBusinessDay","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_STR_SCE_StructureCalendarEventID of type Guid
						_CMN_STR_SCE_StructureCalendarEventID = reader.GetGuid(0);
						//1:Parameter CMN_CAL_Event_RefID of type Guid
						_CMN_CAL_Event_RefID = reader.GetGuid(1);
						//2:Parameter StructureEvent_Name of type Dict
						_StructureEvent_Name = reader.GetDictionary(2);
						loader.Append(_StructureEvent_Name,TableName);
						//3:Parameter StructureEvent_Description of type Dict
						_StructureEvent_Description = reader.GetDictionary(3);
						loader.Append(_StructureEvent_Description,TableName);
						//4:Parameter R_CalendarInstance_RefID of type Guid
						_R_CalendarInstance_RefID = reader.GetGuid(4);
						//5:Parameter IsHavingCapacityRestriction of type Boolean
						_IsHavingCapacityRestriction = reader.GetBoolean(5);
						//6:Parameter IfHavingCapacityRestriction_Restriction_RefID of type Guid
						_IfHavingCapacityRestriction_Restriction_RefID = reader.GetGuid(6);
						//7:Parameter StructureCalendarEvent_Type_RefID of type Guid
						_StructureCalendarEvent_Type_RefID = reader.GetGuid(7);
						//8:Parameter IsShowingNotification of type Boolean
						_IsShowingNotification = reader.GetBoolean(8);
						//9:Parameter IsWorkingDayEvent of type Boolean
						_IsWorkingDayEvent = reader.GetBoolean(9);
						//10:Parameter IsWorkingHalfDayEvent of type Boolean
						_IsWorkingHalfDayEvent = reader.GetBoolean(10);
						//11:Parameter IsNonWorkingDay of type Boolean
						_IsNonWorkingDay = reader.GetBoolean(11);
						//12:Parameter IsEvent_ImportedFromTemplate of type Boolean
						_IsEvent_ImportedFromTemplate = reader.GetBoolean(12);
						//13:Parameter IsBusinessDay of type Boolean
						_IsBusinessDay = reader.GetBoolean(13);
						//14:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(14);
						//15:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(15);
						//16:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(16);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_STR_SCE_StructureCalendarEventID != Guid.Empty){
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
			public Guid? CMN_STR_SCE_StructureCalendarEventID {	get; set; }
			public Guid? CMN_CAL_Event_RefID {	get; set; }
			public Dict StructureEvent_Name {	get; set; }
			public Dict StructureEvent_Description {	get; set; }
			public Guid? R_CalendarInstance_RefID {	get; set; }
			public Boolean? IsHavingCapacityRestriction {	get; set; }
			public Guid? IfHavingCapacityRestriction_Restriction_RefID {	get; set; }
			public Guid? StructureCalendarEvent_Type_RefID {	get; set; }
			public Boolean? IsShowingNotification {	get; set; }
			public Boolean? IsWorkingDayEvent {	get; set; }
			public Boolean? IsWorkingHalfDayEvent {	get; set; }
			public Boolean? IsNonWorkingDay {	get; set; }
			public Boolean? IsEvent_ImportedFromTemplate {	get; set; }
			public Boolean? IsBusinessDay {	get; set; }
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
			public static List<ORM_CMN_STR_SCE_StructureCalendarEvent> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_STR_SCE_StructureCalendarEvent> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_STR_SCE_StructureCalendarEvent> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_STR_SCE_StructureCalendarEvent> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_STR_SCE_StructureCalendarEvent> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_STR_SCE_StructureCalendarEvent>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_STR_SCE_StructureCalendarEventID","CMN_CAL_Event_RefID","StructureEvent_Name_DictID","StructureEvent_Description_DictID","R_CalendarInstance_RefID","IsHavingCapacityRestriction","IfHavingCapacityRestriction_Restriction_RefID","StructureCalendarEvent_Type_RefID","IsShowingNotification","IsWorkingDayEvent","IsWorkingHalfDayEvent","IsNonWorkingDay","IsEvent_ImportedFromTemplate","IsBusinessDay","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_STR_SCE_StructureCalendarEvent item = new ORM_CMN_STR_SCE_StructureCalendarEvent();
						//0:Parameter CMN_STR_SCE_StructureCalendarEventID of type Guid
						item.CMN_STR_SCE_StructureCalendarEventID = reader.GetGuid(0);
						//1:Parameter CMN_CAL_Event_RefID of type Guid
						item.CMN_CAL_Event_RefID = reader.GetGuid(1);
						//2:Parameter StructureEvent_Name of type Dict
						item.StructureEvent_Name = reader.GetDictionary(2);
						loader.Append(item.StructureEvent_Name,TableName);
						//3:Parameter StructureEvent_Description of type Dict
						item.StructureEvent_Description = reader.GetDictionary(3);
						loader.Append(item.StructureEvent_Description,TableName);
						//4:Parameter R_CalendarInstance_RefID of type Guid
						item.R_CalendarInstance_RefID = reader.GetGuid(4);
						//5:Parameter IsHavingCapacityRestriction of type Boolean
						item.IsHavingCapacityRestriction = reader.GetBoolean(5);
						//6:Parameter IfHavingCapacityRestriction_Restriction_RefID of type Guid
						item.IfHavingCapacityRestriction_Restriction_RefID = reader.GetGuid(6);
						//7:Parameter StructureCalendarEvent_Type_RefID of type Guid
						item.StructureCalendarEvent_Type_RefID = reader.GetGuid(7);
						//8:Parameter IsShowingNotification of type Boolean
						item.IsShowingNotification = reader.GetBoolean(8);
						//9:Parameter IsWorkingDayEvent of type Boolean
						item.IsWorkingDayEvent = reader.GetBoolean(9);
						//10:Parameter IsWorkingHalfDayEvent of type Boolean
						item.IsWorkingHalfDayEvent = reader.GetBoolean(10);
						//11:Parameter IsNonWorkingDay of type Boolean
						item.IsNonWorkingDay = reader.GetBoolean(11);
						//12:Parameter IsEvent_ImportedFromTemplate of type Boolean
						item.IsEvent_ImportedFromTemplate = reader.GetBoolean(12);
						//13:Parameter IsBusinessDay of type Boolean
						item.IsBusinessDay = reader.GetBoolean(13);
						//14:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(14);
						//15:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(15);
						//16:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(16);


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
