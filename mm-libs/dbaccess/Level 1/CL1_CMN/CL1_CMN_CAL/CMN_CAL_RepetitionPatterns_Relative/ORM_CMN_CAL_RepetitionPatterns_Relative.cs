/* 
 * Generated on 6/18/2013 4:35:40 PM
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
	public class ORM_CMN_CAL_RepetitionPatterns_Relative
	{
		public static readonly string TableName = "cmn_cal_repetitionpatterns_relative";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_CAL_RepetitionPatterns_Relative()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_CAL_RepetitionPattern_RelativeID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_CAL_RepetitionPattern_RelativeID = default(Guid);
		private int _Ordinal = default(int);
		private Boolean _IsWeekDay = default(Boolean);
		private Boolean _IsWeekendDay = default(Boolean);
		private Boolean _IsMonday = default(Boolean);
		private Boolean _IsTuesday = default(Boolean);
		private Boolean _IsWednesday = default(Boolean);
		private Boolean _IsThursday = default(Boolean);
		private Boolean _IsFriday = default(Boolean);
		private Boolean _IsSaturday = default(Boolean);
		private Boolean _IsSunday = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_CAL_RepetitionPattern_RelativeID { 
			get {
				return _CMN_CAL_RepetitionPattern_RelativeID;
			}
			set {
				if(_CMN_CAL_RepetitionPattern_RelativeID != value){
					_CMN_CAL_RepetitionPattern_RelativeID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Ordinal { 
			get {
				return _Ordinal;
			}
			set {
				if(_Ordinal != value){
					_Ordinal = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWeekDay { 
			get {
				return _IsWeekDay;
			}
			set {
				if(_IsWeekDay != value){
					_IsWeekDay = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWeekendDay { 
			get {
				return _IsWeekendDay;
			}
			set {
				if(_IsWeekendDay != value){
					_IsWeekendDay = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsMonday { 
			get {
				return _IsMonday;
			}
			set {
				if(_IsMonday != value){
					_IsMonday = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsTuesday { 
			get {
				return _IsTuesday;
			}
			set {
				if(_IsTuesday != value){
					_IsTuesday = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsWednesday { 
			get {
				return _IsWednesday;
			}
			set {
				if(_IsWednesday != value){
					_IsWednesday = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsThursday { 
			get {
				return _IsThursday;
			}
			set {
				if(_IsThursday != value){
					_IsThursday = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsFriday { 
			get {
				return _IsFriday;
			}
			set {
				if(_IsFriday != value){
					_IsFriday = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsSaturday { 
			get {
				return _IsSaturday;
			}
			set {
				if(_IsSaturday != value){
					_IsSaturday = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsSunday { 
			get {
				return _IsSunday;
			}
			set {
				if(_IsSunday != value){
					_IsSunday = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_CAL.CMN_CAL_RepetitionPatterns_Relative.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_CAL.CMN_CAL_RepetitionPatterns_Relative.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_CAL_RepetitionPattern_RelativeID", _CMN_CAL_RepetitionPattern_RelativeID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Ordinal", _Ordinal);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWeekDay", _IsWeekDay);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWeekendDay", _IsWeekendDay);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsMonday", _IsMonday);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsTuesday", _IsTuesday);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsWednesday", _IsWednesday);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsThursday", _IsThursday);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsFriday", _IsFriday);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsSaturday", _IsSaturday);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsSunday", _IsSunday);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_CAL.CMN_CAL_RepetitionPatterns_Relative.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_CAL_RepetitionPattern_RelativeID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_CAL_RepetitionPattern_RelativeID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_CAL_RepetitionPattern_RelativeID","Ordinal","IsWeekDay","IsWeekendDay","IsMonday","IsTuesday","IsWednesday","IsThursday","IsFriday","IsSaturday","IsSunday","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_CAL_RepetitionPattern_RelativeID of type Guid
						_CMN_CAL_RepetitionPattern_RelativeID = reader.GetGuid(0);
						//1:Parameter Ordinal of type int
						_Ordinal = reader.GetInteger(1);
						//2:Parameter IsWeekDay of type Boolean
						_IsWeekDay = reader.GetBoolean(2);
						//3:Parameter IsWeekendDay of type Boolean
						_IsWeekendDay = reader.GetBoolean(3);
						//4:Parameter IsMonday of type Boolean
						_IsMonday = reader.GetBoolean(4);
						//5:Parameter IsTuesday of type Boolean
						_IsTuesday = reader.GetBoolean(5);
						//6:Parameter IsWednesday of type Boolean
						_IsWednesday = reader.GetBoolean(6);
						//7:Parameter IsThursday of type Boolean
						_IsThursday = reader.GetBoolean(7);
						//8:Parameter IsFriday of type Boolean
						_IsFriday = reader.GetBoolean(8);
						//9:Parameter IsSaturday of type Boolean
						_IsSaturday = reader.GetBoolean(9);
						//10:Parameter IsSunday of type Boolean
						_IsSunday = reader.GetBoolean(10);
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

					if(_CMN_CAL_RepetitionPattern_RelativeID != Guid.Empty){
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
			public Guid? CMN_CAL_RepetitionPattern_RelativeID {	get; set; }
			public int? Ordinal {	get; set; }
			public Boolean? IsWeekDay {	get; set; }
			public Boolean? IsWeekendDay {	get; set; }
			public Boolean? IsMonday {	get; set; }
			public Boolean? IsTuesday {	get; set; }
			public Boolean? IsWednesday {	get; set; }
			public Boolean? IsThursday {	get; set; }
			public Boolean? IsFriday {	get; set; }
			public Boolean? IsSaturday {	get; set; }
			public Boolean? IsSunday {	get; set; }
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
			public static List<ORM_CMN_CAL_RepetitionPatterns_Relative> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_CAL_RepetitionPatterns_Relative> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_CAL_RepetitionPatterns_Relative> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_CAL_RepetitionPatterns_Relative> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_CAL_RepetitionPatterns_Relative> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_CAL_RepetitionPatterns_Relative>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_CAL_RepetitionPattern_RelativeID","Ordinal","IsWeekDay","IsWeekendDay","IsMonday","IsTuesday","IsWednesday","IsThursday","IsFriday","IsSaturday","IsSunday","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_CAL_RepetitionPatterns_Relative item = new ORM_CMN_CAL_RepetitionPatterns_Relative();
						//0:Parameter CMN_CAL_RepetitionPattern_RelativeID of type Guid
						item.CMN_CAL_RepetitionPattern_RelativeID = reader.GetGuid(0);
						//1:Parameter Ordinal of type int
						item.Ordinal = reader.GetInteger(1);
						//2:Parameter IsWeekDay of type Boolean
						item.IsWeekDay = reader.GetBoolean(2);
						//3:Parameter IsWeekendDay of type Boolean
						item.IsWeekendDay = reader.GetBoolean(3);
						//4:Parameter IsMonday of type Boolean
						item.IsMonday = reader.GetBoolean(4);
						//5:Parameter IsTuesday of type Boolean
						item.IsTuesday = reader.GetBoolean(5);
						//6:Parameter IsWednesday of type Boolean
						item.IsWednesday = reader.GetBoolean(6);
						//7:Parameter IsThursday of type Boolean
						item.IsThursday = reader.GetBoolean(7);
						//8:Parameter IsFriday of type Boolean
						item.IsFriday = reader.GetBoolean(8);
						//9:Parameter IsSaturday of type Boolean
						item.IsSaturday = reader.GetBoolean(9);
						//10:Parameter IsSunday of type Boolean
						item.IsSunday = reader.GetBoolean(10);
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