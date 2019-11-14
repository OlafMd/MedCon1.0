/* 
 * Generated on 10/15/2013 9:29:22 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_BPT
{
	[Serializable]
	public class ORM_CMN_BPT_InvestedWorkTime
	{
		public static readonly string TableName = "cmn_bpt_investedworktimes";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_InvestedWorkTime()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_InvestedWorkTimeID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_InvestedWorkTimeID = default(Guid);
		private Guid _BusinessParticipant_RefID = default(Guid);
		private Guid _ChargingLevel_RefID = default(Guid);
		private String _WorkTime_InternalIdentifier = default(String);
		private String _WorkTime_Source = default(String);
		private Dict _WorkTime_Comment = new Dict(TableName);
		private long _WorkTime_Amount_min = default(long);
		private DateTime _WorkTime_Start = default(DateTime);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_InvestedWorkTimeID { 
			get {
				return _CMN_BPT_InvestedWorkTimeID;
			}
			set {
				if(_CMN_BPT_InvestedWorkTimeID != value){
					_CMN_BPT_InvestedWorkTimeID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid BusinessParticipant_RefID { 
			get {
				return _BusinessParticipant_RefID;
			}
			set {
				if(_BusinessParticipant_RefID != value){
					_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ChargingLevel_RefID { 
			get {
				return _ChargingLevel_RefID;
			}
			set {
				if(_ChargingLevel_RefID != value){
					_ChargingLevel_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String WorkTime_InternalIdentifier { 
			get {
				return _WorkTime_InternalIdentifier;
			}
			set {
				if(_WorkTime_InternalIdentifier != value){
					_WorkTime_InternalIdentifier = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String WorkTime_Source { 
			get {
				return _WorkTime_Source;
			}
			set {
				if(_WorkTime_Source != value){
					_WorkTime_Source = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict WorkTime_Comment { 
			get {
				return _WorkTime_Comment;
			}
			set {
				if(_WorkTime_Comment != value){
					_WorkTime_Comment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public long WorkTime_Amount_min { 
			get {
				return _WorkTime_Amount_min;
			}
			set {
				if(_WorkTime_Amount_min != value){
					_WorkTime_Amount_min = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime WorkTime_Start { 
			get {
				return _WorkTime_Start;
			}
			set {
				if(_WorkTime_Start != value){
					_WorkTime_Start = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || WorkTime_Comment.IsDirty ;
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
								loader.Append(WorkTime_Comment,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT.CMN_BPT_InvestedWorkTime.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT.CMN_BPT_InvestedWorkTime.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_InvestedWorkTimeID", _CMN_BPT_InvestedWorkTimeID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BusinessParticipant_RefID", _BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ChargingLevel_RefID", _ChargingLevel_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkTime_InternalIdentifier", _WorkTime_InternalIdentifier);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkTime_Source", _WorkTime_Source);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkTime_Comment", _WorkTime_Comment.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkTime_Amount_min", _WorkTime_Amount_min);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkTime_Start", _WorkTime_Start);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT.CMN_BPT_InvestedWorkTime.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_InvestedWorkTimeID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_InvestedWorkTimeID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_InvestedWorkTimeID","BusinessParticipant_RefID","ChargingLevel_RefID","WorkTime_InternalIdentifier","WorkTime_Source","WorkTime_Comment_DictID","WorkTime_Amount_min","WorkTime_Start","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_InvestedWorkTimeID of type Guid
						_CMN_BPT_InvestedWorkTimeID = reader.GetGuid(0);
						//1:Parameter BusinessParticipant_RefID of type Guid
						_BusinessParticipant_RefID = reader.GetGuid(1);
						//2:Parameter ChargingLevel_RefID of type Guid
						_ChargingLevel_RefID = reader.GetGuid(2);
						//3:Parameter WorkTime_InternalIdentifier of type String
						_WorkTime_InternalIdentifier = reader.GetString(3);
						//4:Parameter WorkTime_Source of type String
						_WorkTime_Source = reader.GetString(4);
						//5:Parameter WorkTime_Comment of type Dict
						_WorkTime_Comment = reader.GetDictionary(5);
						loader.Append(_WorkTime_Comment,TableName);
						//6:Parameter WorkTime_Amount_min of type long
						_WorkTime_Amount_min = reader.GetLong(6);
						//7:Parameter WorkTime_Start of type DateTime
						_WorkTime_Start = reader.GetDate(7);
						//8:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(8);
						//9:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(9);
						//10:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(10);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_InvestedWorkTimeID != Guid.Empty){
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
			public Guid? CMN_BPT_InvestedWorkTimeID {	get; set; }
			public Guid? BusinessParticipant_RefID {	get; set; }
			public Guid? ChargingLevel_RefID {	get; set; }
			public String WorkTime_InternalIdentifier {	get; set; }
			public String WorkTime_Source {	get; set; }
			public Dict WorkTime_Comment {	get; set; }
			public long? WorkTime_Amount_min {	get; set; }
			public DateTime? WorkTime_Start {	get; set; }
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
					throw;
				}
			}
			#endregion

			#region Search
			public static List<ORM_CMN_BPT_InvestedWorkTime> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_InvestedWorkTime> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_InvestedWorkTime> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_InvestedWorkTime> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_InvestedWorkTime> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_InvestedWorkTime>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_InvestedWorkTimeID","BusinessParticipant_RefID","ChargingLevel_RefID","WorkTime_InternalIdentifier","WorkTime_Source","WorkTime_Comment_DictID","WorkTime_Amount_min","WorkTime_Start","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_InvestedWorkTime item = new ORM_CMN_BPT_InvestedWorkTime();
						//0:Parameter CMN_BPT_InvestedWorkTimeID of type Guid
						item.CMN_BPT_InvestedWorkTimeID = reader.GetGuid(0);
						//1:Parameter BusinessParticipant_RefID of type Guid
						item.BusinessParticipant_RefID = reader.GetGuid(1);
						//2:Parameter ChargingLevel_RefID of type Guid
						item.ChargingLevel_RefID = reader.GetGuid(2);
						//3:Parameter WorkTime_InternalIdentifier of type String
						item.WorkTime_InternalIdentifier = reader.GetString(3);
						//4:Parameter WorkTime_Source of type String
						item.WorkTime_Source = reader.GetString(4);
						//5:Parameter WorkTime_Comment of type Dict
						item.WorkTime_Comment = reader.GetDictionary(5);
						loader.Append(item.WorkTime_Comment,TableName);
						//6:Parameter WorkTime_Amount_min of type long
						item.WorkTime_Amount_min = reader.GetLong(6);
						//7:Parameter WorkTime_Start of type DateTime
						item.WorkTime_Start = reader.GetDate(7);
						//8:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(8);
						//9:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(9);
						//10:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(10);


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
