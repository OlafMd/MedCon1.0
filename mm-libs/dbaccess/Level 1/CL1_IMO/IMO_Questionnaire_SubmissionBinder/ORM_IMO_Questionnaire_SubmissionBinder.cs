/* 
 * Generated on 6/18/2013 5:03:20 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_IMO
{
	[Serializable]
	public class ORM_IMO_Questionnaire_SubmissionBinder
	{
		public static readonly string TableName = "imo_questionnaire_submissionbinders";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_IMO_Questionnaire_SubmissionBinder()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_IMO_Questionnaire_SubmissionBinderID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _IMO_Questionnaire_SubmissionBinderID = default(Guid);
		private Guid _Newest_Questionnaire_Submission_RefID = default(Guid);
		private Boolean _IsBinderArchived = default(Boolean);
		private Boolean _IsLocked_ForResubmission = default(Boolean);
		private Boolean _IsLocked_ForDownloading = default(Boolean);
		private Boolean _IsCheckedOut = default(Boolean);
		private Guid _CheckedOut_ByAccount_RefID = default(Guid);
		private DateTime _CheckedOut_Date = default(DateTime);
		private Guid _Locked_ByAccount_RefID = default(Guid);
		private DateTime _Locked_Date = default(DateTime);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid IMO_Questionnaire_SubmissionBinderID { 
			get {
				return _IMO_Questionnaire_SubmissionBinderID;
			}
			set {
				if(_IMO_Questionnaire_SubmissionBinderID != value){
					_IMO_Questionnaire_SubmissionBinderID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Newest_Questionnaire_Submission_RefID { 
			get {
				return _Newest_Questionnaire_Submission_RefID;
			}
			set {
				if(_Newest_Questionnaire_Submission_RefID != value){
					_Newest_Questionnaire_Submission_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsBinderArchived { 
			get {
				return _IsBinderArchived;
			}
			set {
				if(_IsBinderArchived != value){
					_IsBinderArchived = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLocked_ForResubmission { 
			get {
				return _IsLocked_ForResubmission;
			}
			set {
				if(_IsLocked_ForResubmission != value){
					_IsLocked_ForResubmission = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLocked_ForDownloading { 
			get {
				return _IsLocked_ForDownloading;
			}
			set {
				if(_IsLocked_ForDownloading != value){
					_IsLocked_ForDownloading = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCheckedOut { 
			get {
				return _IsCheckedOut;
			}
			set {
				if(_IsCheckedOut != value){
					_IsCheckedOut = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CheckedOut_ByAccount_RefID { 
			get {
				return _CheckedOut_ByAccount_RefID;
			}
			set {
				if(_CheckedOut_ByAccount_RefID != value){
					_CheckedOut_ByAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime CheckedOut_Date { 
			get {
				return _CheckedOut_Date;
			}
			set {
				if(_CheckedOut_Date != value){
					_CheckedOut_Date = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Locked_ByAccount_RefID { 
			get {
				return _Locked_ByAccount_RefID;
			}
			set {
				if(_Locked_ByAccount_RefID != value){
					_Locked_ByAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Locked_Date { 
			get {
				return _Locked_Date;
			}
			set {
				if(_Locked_Date != value){
					_Locked_Date = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_IMO.IMO_Questionnaire_SubmissionBinder.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_IMO.IMO_Questionnaire_SubmissionBinder.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IMO_Questionnaire_SubmissionBinderID", _IMO_Questionnaire_SubmissionBinderID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Newest_Questionnaire_Submission_RefID", _Newest_Questionnaire_Submission_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsBinderArchived", _IsBinderArchived);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLocked_ForResubmission", _IsLocked_ForResubmission);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLocked_ForDownloading", _IsLocked_ForDownloading);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCheckedOut", _IsCheckedOut);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CheckedOut_ByAccount_RefID", _CheckedOut_ByAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CheckedOut_Date", _CheckedOut_Date);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Locked_ByAccount_RefID", _Locked_ByAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Locked_Date", _Locked_Date);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_IMO.IMO_Questionnaire_SubmissionBinder.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_IMO_Questionnaire_SubmissionBinderID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IMO_Questionnaire_SubmissionBinderID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "IMO_Questionnaire_SubmissionBinderID","Newest_Questionnaire_Submission_RefID","IsBinderArchived","IsLocked_ForResubmission","IsLocked_ForDownloading","IsCheckedOut","CheckedOut_ByAccount_RefID","CheckedOut_Date","Locked_ByAccount_RefID","Locked_Date","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter IMO_Questionnaire_SubmissionBinderID of type Guid
						_IMO_Questionnaire_SubmissionBinderID = reader.GetGuid(0);
						//1:Parameter Newest_Questionnaire_Submission_RefID of type Guid
						_Newest_Questionnaire_Submission_RefID = reader.GetGuid(1);
						//2:Parameter IsBinderArchived of type Boolean
						_IsBinderArchived = reader.GetBoolean(2);
						//3:Parameter IsLocked_ForResubmission of type Boolean
						_IsLocked_ForResubmission = reader.GetBoolean(3);
						//4:Parameter IsLocked_ForDownloading of type Boolean
						_IsLocked_ForDownloading = reader.GetBoolean(4);
						//5:Parameter IsCheckedOut of type Boolean
						_IsCheckedOut = reader.GetBoolean(5);
						//6:Parameter CheckedOut_ByAccount_RefID of type Guid
						_CheckedOut_ByAccount_RefID = reader.GetGuid(6);
						//7:Parameter CheckedOut_Date of type DateTime
						_CheckedOut_Date = reader.GetDate(7);
						//8:Parameter Locked_ByAccount_RefID of type Guid
						_Locked_ByAccount_RefID = reader.GetGuid(8);
						//9:Parameter Locked_Date of type DateTime
						_Locked_Date = reader.GetDate(9);
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

					if(_IMO_Questionnaire_SubmissionBinderID != Guid.Empty){
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
			public Guid? IMO_Questionnaire_SubmissionBinderID {	get; set; }
			public Guid? Newest_Questionnaire_Submission_RefID {	get; set; }
			public Boolean? IsBinderArchived {	get; set; }
			public Boolean? IsLocked_ForResubmission {	get; set; }
			public Boolean? IsLocked_ForDownloading {	get; set; }
			public Boolean? IsCheckedOut {	get; set; }
			public Guid? CheckedOut_ByAccount_RefID {	get; set; }
			public DateTime? CheckedOut_Date {	get; set; }
			public Guid? Locked_ByAccount_RefID {	get; set; }
			public DateTime? Locked_Date {	get; set; }
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
			public static List<ORM_IMO_Questionnaire_SubmissionBinder> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_IMO_Questionnaire_SubmissionBinder> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_IMO_Questionnaire_SubmissionBinder> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_IMO_Questionnaire_SubmissionBinder> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_IMO_Questionnaire_SubmissionBinder> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_IMO_Questionnaire_SubmissionBinder>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "IMO_Questionnaire_SubmissionBinderID","Newest_Questionnaire_Submission_RefID","IsBinderArchived","IsLocked_ForResubmission","IsLocked_ForDownloading","IsCheckedOut","CheckedOut_ByAccount_RefID","CheckedOut_Date","Locked_ByAccount_RefID","Locked_Date","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_IMO_Questionnaire_SubmissionBinder item = new ORM_IMO_Questionnaire_SubmissionBinder();
						//0:Parameter IMO_Questionnaire_SubmissionBinderID of type Guid
						item.IMO_Questionnaire_SubmissionBinderID = reader.GetGuid(0);
						//1:Parameter Newest_Questionnaire_Submission_RefID of type Guid
						item.Newest_Questionnaire_Submission_RefID = reader.GetGuid(1);
						//2:Parameter IsBinderArchived of type Boolean
						item.IsBinderArchived = reader.GetBoolean(2);
						//3:Parameter IsLocked_ForResubmission of type Boolean
						item.IsLocked_ForResubmission = reader.GetBoolean(3);
						//4:Parameter IsLocked_ForDownloading of type Boolean
						item.IsLocked_ForDownloading = reader.GetBoolean(4);
						//5:Parameter IsCheckedOut of type Boolean
						item.IsCheckedOut = reader.GetBoolean(5);
						//6:Parameter CheckedOut_ByAccount_RefID of type Guid
						item.CheckedOut_ByAccount_RefID = reader.GetGuid(6);
						//7:Parameter CheckedOut_Date of type DateTime
						item.CheckedOut_Date = reader.GetDate(7);
						//8:Parameter Locked_ByAccount_RefID of type Guid
						item.Locked_ByAccount_RefID = reader.GetGuid(8);
						//9:Parameter Locked_Date of type DateTime
						item.Locked_Date = reader.GetDate(9);
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