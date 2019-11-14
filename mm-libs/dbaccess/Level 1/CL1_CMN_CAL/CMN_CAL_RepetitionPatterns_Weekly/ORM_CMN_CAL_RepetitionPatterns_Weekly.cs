/* 
 * Generated on 7/8/2013 11:37:26 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_CAL
{
	[Serializable]
	public class ORM_CMN_CAL_RepetitionPatterns_Weekly
	{
		public static readonly string TableName = "cmn_cal_repetitionpatterns_weekly";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_CAL_RepetitionPatterns_Weekly()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_CAL_RepetitionPattern_WeeklyID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_CAL_RepetitionPattern_WeeklyID = default(Guid);
		private Guid _Repetition_RefID = default(Guid);
		private int _Repetition_EveryNumberOfWeeks = default(int);
		private Boolean _HasRepeatingOn_Mondays = default(Boolean);
		private Boolean _HasRepeatingOn_Tuesdays = default(Boolean);
		private Boolean _HasRepeatingOn_Wednesdays = default(Boolean);
		private Boolean _HasRepeatingOn_Thursdays = default(Boolean);
		private Boolean _HasRepeatingOn_Fridays = default(Boolean);
		private Boolean _HasRepeatingOn_Saturdays = default(Boolean);
		private Boolean _HasRepeatingOn_Sundays = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_CAL_RepetitionPattern_WeeklyID { 
			get {
				return _CMN_CAL_RepetitionPattern_WeeklyID;
			}
			set {
				if(_CMN_CAL_RepetitionPattern_WeeklyID != value){
					_CMN_CAL_RepetitionPattern_WeeklyID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Repetition_RefID { 
			get {
				return _Repetition_RefID;
			}
			set {
				if(_Repetition_RefID != value){
					_Repetition_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Repetition_EveryNumberOfWeeks { 
			get {
				return _Repetition_EveryNumberOfWeeks;
			}
			set {
				if(_Repetition_EveryNumberOfWeeks != value){
					_Repetition_EveryNumberOfWeeks = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean HasRepeatingOn_Mondays { 
			get {
				return _HasRepeatingOn_Mondays;
			}
			set {
				if(_HasRepeatingOn_Mondays != value){
					_HasRepeatingOn_Mondays = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean HasRepeatingOn_Tuesdays { 
			get {
				return _HasRepeatingOn_Tuesdays;
			}
			set {
				if(_HasRepeatingOn_Tuesdays != value){
					_HasRepeatingOn_Tuesdays = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean HasRepeatingOn_Wednesdays { 
			get {
				return _HasRepeatingOn_Wednesdays;
			}
			set {
				if(_HasRepeatingOn_Wednesdays != value){
					_HasRepeatingOn_Wednesdays = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean HasRepeatingOn_Thursdays { 
			get {
				return _HasRepeatingOn_Thursdays;
			}
			set {
				if(_HasRepeatingOn_Thursdays != value){
					_HasRepeatingOn_Thursdays = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean HasRepeatingOn_Fridays { 
			get {
				return _HasRepeatingOn_Fridays;
			}
			set {
				if(_HasRepeatingOn_Fridays != value){
					_HasRepeatingOn_Fridays = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean HasRepeatingOn_Saturdays { 
			get {
				return _HasRepeatingOn_Saturdays;
			}
			set {
				if(_HasRepeatingOn_Saturdays != value){
					_HasRepeatingOn_Saturdays = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean HasRepeatingOn_Sundays { 
			get {
				return _HasRepeatingOn_Sundays;
			}
			set {
				if(_HasRepeatingOn_Sundays != value){
					_HasRepeatingOn_Sundays = value;
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


				#region VerifySessionToken/Create Connections
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_CAL.CMN_CAL_RepetitionPatterns_Weekly.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_CAL.CMN_CAL_RepetitionPatterns_Weekly.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_CAL_RepetitionPattern_WeeklyID", _CMN_CAL_RepetitionPattern_WeeklyID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Repetition_RefID", _Repetition_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Repetition_EveryNumberOfWeeks", _Repetition_EveryNumberOfWeeks);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HasRepeatingOn_Mondays", _HasRepeatingOn_Mondays);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HasRepeatingOn_Tuesdays", _HasRepeatingOn_Tuesdays);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HasRepeatingOn_Wednesdays", _HasRepeatingOn_Wednesdays);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HasRepeatingOn_Thursdays", _HasRepeatingOn_Thursdays);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HasRepeatingOn_Fridays", _HasRepeatingOn_Fridays);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HasRepeatingOn_Saturdays", _HasRepeatingOn_Saturdays);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HasRepeatingOn_Sundays", _HasRepeatingOn_Sundays);
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
				#region VerifySessionToken/Create Connections
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_CAL.CMN_CAL_RepetitionPatterns_Weekly.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_CAL_RepetitionPattern_WeeklyID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_CAL_RepetitionPattern_WeeklyID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_CAL_RepetitionPattern_WeeklyID","Repetition_RefID","Repetition_EveryNumberOfWeeks","HasRepeatingOn_Mondays","HasRepeatingOn_Tuesdays","HasRepeatingOn_Wednesdays","HasRepeatingOn_Thursdays","HasRepeatingOn_Fridays","HasRepeatingOn_Saturdays","HasRepeatingOn_Sundays","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_CAL_RepetitionPattern_WeeklyID of type Guid
						_CMN_CAL_RepetitionPattern_WeeklyID = reader.GetGuid(0);
						//1:Parameter Repetition_RefID of type Guid
						_Repetition_RefID = reader.GetGuid(1);
						//2:Parameter Repetition_EveryNumberOfWeeks of type int
						_Repetition_EveryNumberOfWeeks = reader.GetInteger(2);
						//3:Parameter HasRepeatingOn_Mondays of type Boolean
						_HasRepeatingOn_Mondays = reader.GetBoolean(3);
						//4:Parameter HasRepeatingOn_Tuesdays of type Boolean
						_HasRepeatingOn_Tuesdays = reader.GetBoolean(4);
						//5:Parameter HasRepeatingOn_Wednesdays of type Boolean
						_HasRepeatingOn_Wednesdays = reader.GetBoolean(5);
						//6:Parameter HasRepeatingOn_Thursdays of type Boolean
						_HasRepeatingOn_Thursdays = reader.GetBoolean(6);
						//7:Parameter HasRepeatingOn_Fridays of type Boolean
						_HasRepeatingOn_Fridays = reader.GetBoolean(7);
						//8:Parameter HasRepeatingOn_Saturdays of type Boolean
						_HasRepeatingOn_Saturdays = reader.GetBoolean(8);
						//9:Parameter HasRepeatingOn_Sundays of type Boolean
						_HasRepeatingOn_Sundays = reader.GetBoolean(9);
						//10:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(10);
						//11:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(11);
						//12:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(12);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_CAL_RepetitionPattern_WeeklyID != Guid.Empty){
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
			public Guid? CMN_CAL_RepetitionPattern_WeeklyID {	get; set; }
			public Guid? Repetition_RefID {	get; set; }
			public int? Repetition_EveryNumberOfWeeks {	get; set; }
			public Boolean? HasRepeatingOn_Mondays {	get; set; }
			public Boolean? HasRepeatingOn_Tuesdays {	get; set; }
			public Boolean? HasRepeatingOn_Wednesdays {	get; set; }
			public Boolean? HasRepeatingOn_Thursdays {	get; set; }
			public Boolean? HasRepeatingOn_Fridays {	get; set; }
			public Boolean? HasRepeatingOn_Saturdays {	get; set; }
			public Boolean? HasRepeatingOn_Sundays {	get; set; }
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
			public static List<ORM_CMN_CAL_RepetitionPatterns_Weekly> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_CAL_RepetitionPatterns_Weekly> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_CAL_RepetitionPatterns_Weekly> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_CAL_RepetitionPatterns_Weekly> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_CAL_RepetitionPatterns_Weekly> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_CAL_RepetitionPatterns_Weekly>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_CAL_RepetitionPattern_WeeklyID","Repetition_RefID","Repetition_EveryNumberOfWeeks","HasRepeatingOn_Mondays","HasRepeatingOn_Tuesdays","HasRepeatingOn_Wednesdays","HasRepeatingOn_Thursdays","HasRepeatingOn_Fridays","HasRepeatingOn_Saturdays","HasRepeatingOn_Sundays","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_CAL_RepetitionPatterns_Weekly item = new ORM_CMN_CAL_RepetitionPatterns_Weekly();
						//0:Parameter CMN_CAL_RepetitionPattern_WeeklyID of type Guid
						item.CMN_CAL_RepetitionPattern_WeeklyID = reader.GetGuid(0);
						//1:Parameter Repetition_RefID of type Guid
						item.Repetition_RefID = reader.GetGuid(1);
						//2:Parameter Repetition_EveryNumberOfWeeks of type int
						item.Repetition_EveryNumberOfWeeks = reader.GetInteger(2);
						//3:Parameter HasRepeatingOn_Mondays of type Boolean
						item.HasRepeatingOn_Mondays = reader.GetBoolean(3);
						//4:Parameter HasRepeatingOn_Tuesdays of type Boolean
						item.HasRepeatingOn_Tuesdays = reader.GetBoolean(4);
						//5:Parameter HasRepeatingOn_Wednesdays of type Boolean
						item.HasRepeatingOn_Wednesdays = reader.GetBoolean(5);
						//6:Parameter HasRepeatingOn_Thursdays of type Boolean
						item.HasRepeatingOn_Thursdays = reader.GetBoolean(6);
						//7:Parameter HasRepeatingOn_Fridays of type Boolean
						item.HasRepeatingOn_Fridays = reader.GetBoolean(7);
						//8:Parameter HasRepeatingOn_Saturdays of type Boolean
						item.HasRepeatingOn_Saturdays = reader.GetBoolean(8);
						//9:Parameter HasRepeatingOn_Sundays of type Boolean
						item.HasRepeatingOn_Sundays = reader.GetBoolean(9);
						//10:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(10);
						//11:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(11);
						//12:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(12);


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
