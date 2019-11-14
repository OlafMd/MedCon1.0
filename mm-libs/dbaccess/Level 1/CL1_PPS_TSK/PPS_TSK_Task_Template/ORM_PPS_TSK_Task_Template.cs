/* 
 * Generated on 6/26/2014 9:16:21 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_PPS_TSK
{
	[Serializable]
	public class ORM_PPS_TSK_Task_Template
	{
		public static readonly string TableName = "pps_tsk_task_templates";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_PPS_TSK_Task_Template()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_PPS_TSK_Task_TemplateID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _PPS_TSK_Task_TemplateID = default(Guid);
		private String _TaskTemplateNumber = default(String);
		private String _TaskTemplateDisplayName = default(String);
		private Dict _TaskTemplateName = new Dict(TableName);
		private Dict _TaskTemplateDescription = new Dict(TableName);
		private float _Duration_EstimatedMin_in_sec = default(float);
		private float _Duration_Recommended_in_sec = default(float);
		private float _Duration_EstimatedMax_in_sec = default(float);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid PPS_TSK_Task_TemplateID { 
			get {
				return _PPS_TSK_Task_TemplateID;
			}
			set {
				if(_PPS_TSK_Task_TemplateID != value){
					_PPS_TSK_Task_TemplateID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String TaskTemplateNumber { 
			get {
				return _TaskTemplateNumber;
			}
			set {
				if(_TaskTemplateNumber != value){
					_TaskTemplateNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String TaskTemplateDisplayName { 
			get {
				return _TaskTemplateDisplayName;
			}
			set {
				if(_TaskTemplateDisplayName != value){
					_TaskTemplateDisplayName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict TaskTemplateName { 
			get {
				return _TaskTemplateName;
			}
			set {
				if(_TaskTemplateName != value){
					_TaskTemplateName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict TaskTemplateDescription { 
			get {
				return _TaskTemplateDescription;
			}
			set {
				if(_TaskTemplateDescription != value){
					_TaskTemplateDescription = value;
					Status_IsDirty = true;
				}
			}
		} 
		public float Duration_EstimatedMin_in_sec { 
			get {
				return _Duration_EstimatedMin_in_sec;
			}
			set {
				if(_Duration_EstimatedMin_in_sec != value){
					_Duration_EstimatedMin_in_sec = value;
					Status_IsDirty = true;
				}
			}
		} 
		public float Duration_Recommended_in_sec { 
			get {
				return _Duration_Recommended_in_sec;
			}
			set {
				if(_Duration_Recommended_in_sec != value){
					_Duration_Recommended_in_sec = value;
					Status_IsDirty = true;
				}
			}
		} 
		public float Duration_EstimatedMax_in_sec { 
			get {
				return _Duration_EstimatedMax_in_sec;
			}
			set {
				if(_Duration_EstimatedMax_in_sec != value){
					_Duration_EstimatedMax_in_sec = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || TaskTemplateName.IsDirty || TaskTemplateDescription.IsDirty ;
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
								loader.Append(TaskTemplateName,TableName);
								loader.Append(TaskTemplateDescription,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_PPS_TSK.PPS_TSK_Task_Template.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_PPS_TSK.PPS_TSK_Task_Template.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PPS_TSK_Task_TemplateID", _PPS_TSK_Task_TemplateID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TaskTemplateNumber", _TaskTemplateNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TaskTemplateDisplayName", _TaskTemplateDisplayName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TaskTemplateName", _TaskTemplateName.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TaskTemplateDescription", _TaskTemplateDescription.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Duration_EstimatedMin_in_sec", _Duration_EstimatedMin_in_sec);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Duration_Recommended_in_sec", _Duration_Recommended_in_sec);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Duration_EstimatedMax_in_sec", _Duration_EstimatedMax_in_sec);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_PPS_TSK.PPS_TSK_Task_Template.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_PPS_TSK_Task_TemplateID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PPS_TSK_Task_TemplateID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "PPS_TSK_Task_TemplateID","TaskTemplateNumber","TaskTemplateDisplayName","TaskTemplateName_DictID","TaskTemplateDescription_DictID","Duration_EstimatedMin_in_sec","Duration_Recommended_in_sec","Duration_EstimatedMax_in_sec","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter PPS_TSK_Task_TemplateID of type Guid
						_PPS_TSK_Task_TemplateID = reader.GetGuid(0);
						//1:Parameter TaskTemplateNumber of type String
						_TaskTemplateNumber = reader.GetString(1);
						//2:Parameter TaskTemplateDisplayName of type String
						_TaskTemplateDisplayName = reader.GetString(2);
						//3:Parameter TaskTemplateName of type Dict
						_TaskTemplateName = reader.GetDictionary(3);
						loader.Append(_TaskTemplateName,TableName);
						//4:Parameter TaskTemplateDescription of type Dict
						_TaskTemplateDescription = reader.GetDictionary(4);
						loader.Append(_TaskTemplateDescription,TableName);
						//5:Parameter Duration_EstimatedMin_in_sec of type float
						_Duration_EstimatedMin_in_sec = (float)reader.GetDouble(5);
						//6:Parameter Duration_Recommended_in_sec of type float
                        _Duration_Recommended_in_sec = (float)reader.GetDouble(6);
						//7:Parameter Duration_EstimatedMax_in_sec of type float
                        _Duration_EstimatedMax_in_sec = (float)reader.GetDouble(7);
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

					if(_PPS_TSK_Task_TemplateID != Guid.Empty){
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
			public Guid? PPS_TSK_Task_TemplateID {	get; set; }
			public String TaskTemplateNumber {	get; set; }
			public String TaskTemplateDisplayName {	get; set; }
			public Dict TaskTemplateName {	get; set; }
			public Dict TaskTemplateDescription {	get; set; }
			public float? Duration_EstimatedMin_in_sec {	get; set; }
			public float? Duration_Recommended_in_sec {	get; set; }
			public float? Duration_EstimatedMax_in_sec {	get; set; }
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
					throw;
				}
			}
			#endregion

			#region Search
			public static List<ORM_PPS_TSK_Task_Template> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_PPS_TSK_Task_Template> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_PPS_TSK_Task_Template> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_PPS_TSK_Task_Template> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_PPS_TSK_Task_Template> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_PPS_TSK_Task_Template>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "PPS_TSK_Task_TemplateID","TaskTemplateNumber","TaskTemplateDisplayName","TaskTemplateName_DictID","TaskTemplateDescription_DictID","Duration_EstimatedMin_in_sec","Duration_Recommended_in_sec","Duration_EstimatedMax_in_sec","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_PPS_TSK_Task_Template item = new ORM_PPS_TSK_Task_Template();
						//0:Parameter PPS_TSK_Task_TemplateID of type Guid
						item.PPS_TSK_Task_TemplateID = reader.GetGuid(0);
						//1:Parameter TaskTemplateNumber of type String
						item.TaskTemplateNumber = reader.GetString(1);
						//2:Parameter TaskTemplateDisplayName of type String
						item.TaskTemplateDisplayName = reader.GetString(2);
						//3:Parameter TaskTemplateName of type Dict
						item.TaskTemplateName = reader.GetDictionary(3);
						loader.Append(item.TaskTemplateName,TableName);
						//4:Parameter TaskTemplateDescription of type Dict
						item.TaskTemplateDescription = reader.GetDictionary(4);
						loader.Append(item.TaskTemplateDescription,TableName);
						//5:Parameter Duration_EstimatedMin_in_sec of type float
						item.Duration_EstimatedMin_in_sec = (float)reader.GetDouble(5);
						//6:Parameter Duration_Recommended_in_sec of type float
                        item.Duration_Recommended_in_sec = (float)reader.GetDouble(6);
						//7:Parameter Duration_EstimatedMax_in_sec of type float
                        item.Duration_EstimatedMax_in_sec = (float)reader.GetDouble(7);
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
