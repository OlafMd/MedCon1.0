/* 
 * Generated on 14-Apr-14 14:59:26
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_CMN_BPT_EMP
{
	[Serializable]
	public class ORM_CMN_BPT_EMP_Employee_LeaveRequest
	{
		public static readonly string TableName = "cmn_bpt_emp_employee_leaverequests";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_EMP_Employee_LeaveRequest()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_EMP_Employee_LeaveRequestID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_EMP_Employee_LeaveRequestID = default(Guid);
		private Guid _RequestedBy_Employee_RefID = default(Guid);
		private Guid _RequestedFor_Employee_RefID = default(Guid);
		private Guid _CMN_CAL_Event_RefID = default(Guid);
		private Guid _CMN_CAL_Event_Approval_RefID = default(Guid);
		private Guid _CMN_BPT_STA_AbsenceReason_RefID = default(Guid);
		private String _Comment = default(String);
		private String _LeaveRequestCreationSource = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_EMP_Employee_LeaveRequestID { 
			get {
				return _CMN_BPT_EMP_Employee_LeaveRequestID;
			}
			set {
				if(_CMN_BPT_EMP_Employee_LeaveRequestID != value){
					_CMN_BPT_EMP_Employee_LeaveRequestID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid RequestedBy_Employee_RefID { 
			get {
				return _RequestedBy_Employee_RefID;
			}
			set {
				if(_RequestedBy_Employee_RefID != value){
					_RequestedBy_Employee_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid RequestedFor_Employee_RefID { 
			get {
				return _RequestedFor_Employee_RefID;
			}
			set {
				if(_RequestedFor_Employee_RefID != value){
					_RequestedFor_Employee_RefID = value;
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
		public Guid CMN_CAL_Event_Approval_RefID { 
			get {
				return _CMN_CAL_Event_Approval_RefID;
			}
			set {
				if(_CMN_CAL_Event_Approval_RefID != value){
					_CMN_CAL_Event_Approval_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_BPT_STA_AbsenceReason_RefID { 
			get {
				return _CMN_BPT_STA_AbsenceReason_RefID;
			}
			set {
				if(_CMN_BPT_STA_AbsenceReason_RefID != value){
					_CMN_BPT_STA_AbsenceReason_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Comment { 
			get {
				return _Comment;
			}
			set {
				if(_Comment != value){
					_Comment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String LeaveRequestCreationSource { 
			get {
				return _LeaveRequestCreationSource;
			}
			set {
				if(_LeaveRequestCreationSource != value){
					_LeaveRequestCreationSource = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_Employee_LeaveRequest.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_Employee_LeaveRequest.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_EMP_Employee_LeaveRequestID", _CMN_BPT_EMP_Employee_LeaveRequestID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestedBy_Employee_RefID", _RequestedBy_Employee_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequestedFor_Employee_RefID", _RequestedFor_Employee_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_CAL_Event_RefID", _CMN_CAL_Event_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_CAL_Event_Approval_RefID", _CMN_CAL_Event_Approval_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_STA_AbsenceReason_RefID", _CMN_BPT_STA_AbsenceReason_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment", _Comment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LeaveRequestCreationSource", _LeaveRequestCreationSource);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_Employee_LeaveRequest.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_EMP_Employee_LeaveRequestID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_EMP_Employee_LeaveRequestID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_Employee_LeaveRequestID","RequestedBy_Employee_RefID","RequestedFor_Employee_RefID","CMN_CAL_Event_RefID","CMN_CAL_Event_Approval_RefID","CMN_BPT_STA_AbsenceReason_RefID","Comment","LeaveRequestCreationSource","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_EMP_Employee_LeaveRequestID of type Guid
						_CMN_BPT_EMP_Employee_LeaveRequestID = reader.GetGuid(0);
						//1:Parameter RequestedBy_Employee_RefID of type Guid
						_RequestedBy_Employee_RefID = reader.GetGuid(1);
						//2:Parameter RequestedFor_Employee_RefID of type Guid
						_RequestedFor_Employee_RefID = reader.GetGuid(2);
						//3:Parameter CMN_CAL_Event_RefID of type Guid
						_CMN_CAL_Event_RefID = reader.GetGuid(3);
						//4:Parameter CMN_CAL_Event_Approval_RefID of type Guid
						_CMN_CAL_Event_Approval_RefID = reader.GetGuid(4);
						//5:Parameter CMN_BPT_STA_AbsenceReason_RefID of type Guid
						_CMN_BPT_STA_AbsenceReason_RefID = reader.GetGuid(5);
						//6:Parameter Comment of type String
						_Comment = reader.GetString(6);
						//7:Parameter LeaveRequestCreationSource of type String
						_LeaveRequestCreationSource = reader.GetString(7);
						//8:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(8);
						//9:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(9);
						//10:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(10);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_EMP_Employee_LeaveRequestID != Guid.Empty){
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
			public Guid? CMN_BPT_EMP_Employee_LeaveRequestID {	get; set; }
			public Guid? RequestedBy_Employee_RefID {	get; set; }
			public Guid? RequestedFor_Employee_RefID {	get; set; }
			public Guid? CMN_CAL_Event_RefID {	get; set; }
			public Guid? CMN_CAL_Event_Approval_RefID {	get; set; }
			public Guid? CMN_BPT_STA_AbsenceReason_RefID {	get; set; }
			public String Comment {	get; set; }
			public String LeaveRequestCreationSource {	get; set; }
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
			public static List<ORM_CMN_BPT_EMP_Employee_LeaveRequest> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_EMP_Employee_LeaveRequest> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_EMP_Employee_LeaveRequest> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_EMP_Employee_LeaveRequest> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_EMP_Employee_LeaveRequest> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_EMP_Employee_LeaveRequest>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_Employee_LeaveRequestID","RequestedBy_Employee_RefID","RequestedFor_Employee_RefID","CMN_CAL_Event_RefID","CMN_CAL_Event_Approval_RefID","CMN_BPT_STA_AbsenceReason_RefID","Comment","LeaveRequestCreationSource","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_EMP_Employee_LeaveRequest item = new ORM_CMN_BPT_EMP_Employee_LeaveRequest();
						//0:Parameter CMN_BPT_EMP_Employee_LeaveRequestID of type Guid
						item.CMN_BPT_EMP_Employee_LeaveRequestID = reader.GetGuid(0);
						//1:Parameter RequestedBy_Employee_RefID of type Guid
						item.RequestedBy_Employee_RefID = reader.GetGuid(1);
						//2:Parameter RequestedFor_Employee_RefID of type Guid
						item.RequestedFor_Employee_RefID = reader.GetGuid(2);
						//3:Parameter CMN_CAL_Event_RefID of type Guid
						item.CMN_CAL_Event_RefID = reader.GetGuid(3);
						//4:Parameter CMN_CAL_Event_Approval_RefID of type Guid
						item.CMN_CAL_Event_Approval_RefID = reader.GetGuid(4);
						//5:Parameter CMN_BPT_STA_AbsenceReason_RefID of type Guid
						item.CMN_BPT_STA_AbsenceReason_RefID = reader.GetGuid(5);
						//6:Parameter Comment of type String
						item.Comment = reader.GetString(6);
						//7:Parameter LeaveRequestCreationSource of type String
						item.LeaveRequestCreationSource = reader.GetString(7);
						//8:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(8);
						//9:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(9);
						//10:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(10);


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
