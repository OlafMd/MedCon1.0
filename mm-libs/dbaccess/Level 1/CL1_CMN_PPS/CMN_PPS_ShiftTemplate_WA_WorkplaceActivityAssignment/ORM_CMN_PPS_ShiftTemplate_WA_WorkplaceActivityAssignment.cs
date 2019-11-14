/* 
 * Generated on 11/18/2013 3:07:33 PM
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
	public class ORM_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignment
	{
		public static readonly string TableName = "cmn_pps_shifttemplate_wa_workplaceactivityassignments";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignment()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID = default(Guid);
		private Guid _ShiftTemplate_WorkplaceAssignment_RefID = default(Guid);
		private Guid _CMN_STR_PPS_Workplace_Activity_RefID = default(Guid);
		private Double _WorkplaceAssignment_Offset_sec = default(Double);
		private Double _WorkplaceAssignment_Duration_sec = default(Double);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID { 
			get {
				return _CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID;
			}
			set {
				if(_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID != value){
					_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ShiftTemplate_WorkplaceAssignment_RefID { 
			get {
				return _ShiftTemplate_WorkplaceAssignment_RefID;
			}
			set {
				if(_ShiftTemplate_WorkplaceAssignment_RefID != value){
					_ShiftTemplate_WorkplaceAssignment_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_STR_PPS_Workplace_Activity_RefID { 
			get {
				return _CMN_STR_PPS_Workplace_Activity_RefID;
			}
			set {
				if(_CMN_STR_PPS_Workplace_Activity_RefID != value){
					_CMN_STR_PPS_Workplace_Activity_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double WorkplaceAssignment_Offset_sec { 
			get {
				return _WorkplaceAssignment_Offset_sec;
			}
			set {
				if(_WorkplaceAssignment_Offset_sec != value){
					_WorkplaceAssignment_Offset_sec = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double WorkplaceAssignment_Duration_sec { 
			get {
				return _WorkplaceAssignment_Duration_sec;
			}
			set {
				if(_WorkplaceAssignment_Duration_sec != value){
					_WorkplaceAssignment_Duration_sec = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PPS.CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignment.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PPS.CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignment.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID", _CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShiftTemplate_WorkplaceAssignment_RefID", _ShiftTemplate_WorkplaceAssignment_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_STR_PPS_Workplace_Activity_RefID", _CMN_STR_PPS_Workplace_Activity_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkplaceAssignment_Offset_sec", _WorkplaceAssignment_Offset_sec);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkplaceAssignment_Duration_sec", _WorkplaceAssignment_Duration_sec);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PPS.CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignment.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID","ShiftTemplate_WorkplaceAssignment_RefID","CMN_STR_PPS_Workplace_Activity_RefID","WorkplaceAssignment_Offset_sec","WorkplaceAssignment_Duration_sec","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID of type Guid
						_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID = reader.GetGuid(0);
						//1:Parameter ShiftTemplate_WorkplaceAssignment_RefID of type Guid
						_ShiftTemplate_WorkplaceAssignment_RefID = reader.GetGuid(1);
						//2:Parameter CMN_STR_PPS_Workplace_Activity_RefID of type Guid
						_CMN_STR_PPS_Workplace_Activity_RefID = reader.GetGuid(2);
						//3:Parameter WorkplaceAssignment_Offset_sec of type Double
						_WorkplaceAssignment_Offset_sec = reader.GetDouble(3);
						//4:Parameter WorkplaceAssignment_Duration_sec of type Double
						_WorkplaceAssignment_Duration_sec = reader.GetDouble(4);
						//5:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(5);
						//6:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(6);
						//7:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(7);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID != Guid.Empty){
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
			public Guid? CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID {	get; set; }
			public Guid? ShiftTemplate_WorkplaceAssignment_RefID {	get; set; }
			public Guid? CMN_STR_PPS_Workplace_Activity_RefID {	get; set; }
			public Double? WorkplaceAssignment_Offset_sec {	get; set; }
			public Double? WorkplaceAssignment_Duration_sec {	get; set; }
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
			public static List<ORM_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignment> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignment> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignment> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignment> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignment> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignment>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID","ShiftTemplate_WorkplaceAssignment_RefID","CMN_STR_PPS_Workplace_Activity_RefID","WorkplaceAssignment_Offset_sec","WorkplaceAssignment_Duration_sec","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignment item = new ORM_CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignment();
						//0:Parameter CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID of type Guid
						item.CMN_PPS_ShiftTemplate_WA_WorkplaceActivityAssignmentID = reader.GetGuid(0);
						//1:Parameter ShiftTemplate_WorkplaceAssignment_RefID of type Guid
						item.ShiftTemplate_WorkplaceAssignment_RefID = reader.GetGuid(1);
						//2:Parameter CMN_STR_PPS_Workplace_Activity_RefID of type Guid
						item.CMN_STR_PPS_Workplace_Activity_RefID = reader.GetGuid(2);
						//3:Parameter WorkplaceAssignment_Offset_sec of type Double
						item.WorkplaceAssignment_Offset_sec = reader.GetDouble(3);
						//4:Parameter WorkplaceAssignment_Duration_sec of type Double
						item.WorkplaceAssignment_Duration_sec = reader.GetDouble(4);
						//5:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(5);
						//6:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(6);
						//7:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(7);


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
