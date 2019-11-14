/* 
 * Generated on 10/15/2013 9:37:49 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_TMS
{
	[Serializable]
	public class ORM_TMS_QuickTask
	{
		public static readonly string TableName = "tms_quicktasks";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_TMS_QuickTask()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_TMS_QuickTaskID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _TMS_QuickTaskID = default(Guid);
		private String _IdentificationNumber = default(String);
		private Boolean _IsManuallyEntered = default(Boolean);
		private Dict _QuickTask_Title = new Dict(TableName);
		private Dict _QuickTask_Description = new Dict(TableName);
		private Guid _QuickTask_Type_RefID = default(Guid);
		private Double _R_QuickTask_InvestedTime_min = default(Double);
		private Guid _QuickTask_CreatedByAccount_RefID = default(Guid);
		private Guid _QuickTask_DocumentStructureHeader_RefID = default(Guid);
		private DateTime _QuickTask_StartTime = default(DateTime);
		private Guid _AssignedTo_Project_RefID = default(Guid);
		private Guid _AssignedTo_BusinessTask_RefID = default(Guid);
		private Guid _AssignedTo_Feature_RefID = default(Guid);
		private Guid _AssignedTo_DeveloperTask_RefID = default(Guid);
		private Guid _Tenant_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid TMS_QuickTaskID { 
			get {
				return _TMS_QuickTaskID;
			}
			set {
				if(_TMS_QuickTaskID != value){
					_TMS_QuickTaskID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IdentificationNumber { 
			get {
				return _IdentificationNumber;
			}
			set {
				if(_IdentificationNumber != value){
					_IdentificationNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsManuallyEntered { 
			get {
				return _IsManuallyEntered;
			}
			set {
				if(_IsManuallyEntered != value){
					_IsManuallyEntered = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict QuickTask_Title { 
			get {
				return _QuickTask_Title;
			}
			set {
				if(_QuickTask_Title != value){
					_QuickTask_Title = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict QuickTask_Description { 
			get {
				return _QuickTask_Description;
			}
			set {
				if(_QuickTask_Description != value){
					_QuickTask_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid QuickTask_Type_RefID { 
			get {
				return _QuickTask_Type_RefID;
			}
			set {
				if(_QuickTask_Type_RefID != value){
					_QuickTask_Type_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double R_QuickTask_InvestedTime_min { 
			get {
				return _R_QuickTask_InvestedTime_min;
			}
			set {
				if(_R_QuickTask_InvestedTime_min != value){
					_R_QuickTask_InvestedTime_min = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid QuickTask_CreatedByAccount_RefID { 
			get {
				return _QuickTask_CreatedByAccount_RefID;
			}
			set {
				if(_QuickTask_CreatedByAccount_RefID != value){
					_QuickTask_CreatedByAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid QuickTask_DocumentStructureHeader_RefID { 
			get {
				return _QuickTask_DocumentStructureHeader_RefID;
			}
			set {
				if(_QuickTask_DocumentStructureHeader_RefID != value){
					_QuickTask_DocumentStructureHeader_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime QuickTask_StartTime { 
			get {
				return _QuickTask_StartTime;
			}
			set {
				if(_QuickTask_StartTime != value){
					_QuickTask_StartTime = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid AssignedTo_Project_RefID { 
			get {
				return _AssignedTo_Project_RefID;
			}
			set {
				if(_AssignedTo_Project_RefID != value){
					_AssignedTo_Project_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid AssignedTo_BusinessTask_RefID { 
			get {
				return _AssignedTo_BusinessTask_RefID;
			}
			set {
				if(_AssignedTo_BusinessTask_RefID != value){
					_AssignedTo_BusinessTask_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid AssignedTo_Feature_RefID { 
			get {
				return _AssignedTo_Feature_RefID;
			}
			set {
				if(_AssignedTo_Feature_RefID != value){
					_AssignedTo_Feature_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid AssignedTo_DeveloperTask_RefID { 
			get {
				return _AssignedTo_DeveloperTask_RefID;
			}
			set {
				if(_AssignedTo_DeveloperTask_RefID != value){
					_AssignedTo_DeveloperTask_RefID = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || QuickTask_Title.IsDirty || QuickTask_Description.IsDirty ;
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
								loader.Append(QuickTask_Title,TableName);
								loader.Append(QuickTask_Description,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_TMS.TMS_QuickTask.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_TMS.TMS_QuickTask.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TMS_QuickTaskID", _TMS_QuickTaskID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IdentificationNumber", _IdentificationNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsManuallyEntered", _IsManuallyEntered);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuickTask_Title", _QuickTask_Title.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuickTask_Description", _QuickTask_Description.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuickTask_Type_RefID", _QuickTask_Type_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_QuickTask_InvestedTime_min", _R_QuickTask_InvestedTime_min);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuickTask_CreatedByAccount_RefID", _QuickTask_CreatedByAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuickTask_DocumentStructureHeader_RefID", _QuickTask_DocumentStructureHeader_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuickTask_StartTime", _QuickTask_StartTime);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AssignedTo_Project_RefID", _AssignedTo_Project_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AssignedTo_BusinessTask_RefID", _AssignedTo_BusinessTask_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AssignedTo_Feature_RefID", _AssignedTo_Feature_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AssignedTo_DeveloperTask_RefID", _AssignedTo_DeveloperTask_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_TMS.TMS_QuickTask.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_TMS_QuickTaskID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TMS_QuickTaskID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "TMS_QuickTaskID","IdentificationNumber","IsManuallyEntered","QuickTask_Title_DictID","QuickTask_Description_DictID","QuickTask_Type_RefID","R_QuickTask_InvestedTime_min","QuickTask_CreatedByAccount_RefID","QuickTask_DocumentStructureHeader_RefID","QuickTask_StartTime","AssignedTo_Project_RefID","AssignedTo_BusinessTask_RefID","AssignedTo_Feature_RefID","AssignedTo_DeveloperTask_RefID","Tenant_RefID","Creation_Timestamp","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter TMS_QuickTaskID of type Guid
						_TMS_QuickTaskID = reader.GetGuid(0);
						//1:Parameter IdentificationNumber of type String
						_IdentificationNumber = reader.GetString(1);
						//2:Parameter IsManuallyEntered of type Boolean
						_IsManuallyEntered = reader.GetBoolean(2);
						//3:Parameter QuickTask_Title of type Dict
						_QuickTask_Title = reader.GetDictionary(3);
						loader.Append(_QuickTask_Title,TableName);
						//4:Parameter QuickTask_Description of type Dict
						_QuickTask_Description = reader.GetDictionary(4);
						loader.Append(_QuickTask_Description,TableName);
						//5:Parameter QuickTask_Type_RefID of type Guid
						_QuickTask_Type_RefID = reader.GetGuid(5);
						//6:Parameter R_QuickTask_InvestedTime_min of type Double
						_R_QuickTask_InvestedTime_min = reader.GetDouble(6);
						//7:Parameter QuickTask_CreatedByAccount_RefID of type Guid
						_QuickTask_CreatedByAccount_RefID = reader.GetGuid(7);
						//8:Parameter QuickTask_DocumentStructureHeader_RefID of type Guid
						_QuickTask_DocumentStructureHeader_RefID = reader.GetGuid(8);
						//9:Parameter QuickTask_StartTime of type DateTime
						_QuickTask_StartTime = reader.GetDate(9);
						//10:Parameter AssignedTo_Project_RefID of type Guid
						_AssignedTo_Project_RefID = reader.GetGuid(10);
						//11:Parameter AssignedTo_BusinessTask_RefID of type Guid
						_AssignedTo_BusinessTask_RefID = reader.GetGuid(11);
						//12:Parameter AssignedTo_Feature_RefID of type Guid
						_AssignedTo_Feature_RefID = reader.GetGuid(12);
						//13:Parameter AssignedTo_DeveloperTask_RefID of type Guid
						_AssignedTo_DeveloperTask_RefID = reader.GetGuid(13);
						//14:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(14);
						//15:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(15);
						//16:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(16);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_TMS_QuickTaskID != Guid.Empty){
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
			public Guid? TMS_QuickTaskID {	get; set; }
			public String IdentificationNumber {	get; set; }
			public Boolean? IsManuallyEntered {	get; set; }
			public Dict QuickTask_Title {	get; set; }
			public Dict QuickTask_Description {	get; set; }
			public Guid? QuickTask_Type_RefID {	get; set; }
			public Double? R_QuickTask_InvestedTime_min {	get; set; }
			public Guid? QuickTask_CreatedByAccount_RefID {	get; set; }
			public Guid? QuickTask_DocumentStructureHeader_RefID {	get; set; }
			public DateTime? QuickTask_StartTime {	get; set; }
			public Guid? AssignedTo_Project_RefID {	get; set; }
			public Guid? AssignedTo_BusinessTask_RefID {	get; set; }
			public Guid? AssignedTo_Feature_RefID {	get; set; }
			public Guid? AssignedTo_DeveloperTask_RefID {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
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
			public static List<ORM_TMS_QuickTask> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_TMS_QuickTask> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_TMS_QuickTask> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_TMS_QuickTask> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_TMS_QuickTask> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_TMS_QuickTask>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "TMS_QuickTaskID","IdentificationNumber","IsManuallyEntered","QuickTask_Title_DictID","QuickTask_Description_DictID","QuickTask_Type_RefID","R_QuickTask_InvestedTime_min","QuickTask_CreatedByAccount_RefID","QuickTask_DocumentStructureHeader_RefID","QuickTask_StartTime","AssignedTo_Project_RefID","AssignedTo_BusinessTask_RefID","AssignedTo_Feature_RefID","AssignedTo_DeveloperTask_RefID","Tenant_RefID","Creation_Timestamp","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_TMS_QuickTask item = new ORM_TMS_QuickTask();
						//0:Parameter TMS_QuickTaskID of type Guid
						item.TMS_QuickTaskID = reader.GetGuid(0);
						//1:Parameter IdentificationNumber of type String
						item.IdentificationNumber = reader.GetString(1);
						//2:Parameter IsManuallyEntered of type Boolean
						item.IsManuallyEntered = reader.GetBoolean(2);
						//3:Parameter QuickTask_Title of type Dict
						item.QuickTask_Title = reader.GetDictionary(3);
						loader.Append(item.QuickTask_Title,TableName);
						//4:Parameter QuickTask_Description of type Dict
						item.QuickTask_Description = reader.GetDictionary(4);
						loader.Append(item.QuickTask_Description,TableName);
						//5:Parameter QuickTask_Type_RefID of type Guid
						item.QuickTask_Type_RefID = reader.GetGuid(5);
						//6:Parameter R_QuickTask_InvestedTime_min of type Double
						item.R_QuickTask_InvestedTime_min = reader.GetDouble(6);
						//7:Parameter QuickTask_CreatedByAccount_RefID of type Guid
						item.QuickTask_CreatedByAccount_RefID = reader.GetGuid(7);
						//8:Parameter QuickTask_DocumentStructureHeader_RefID of type Guid
						item.QuickTask_DocumentStructureHeader_RefID = reader.GetGuid(8);
						//9:Parameter QuickTask_StartTime of type DateTime
						item.QuickTask_StartTime = reader.GetDate(9);
						//10:Parameter AssignedTo_Project_RefID of type Guid
						item.AssignedTo_Project_RefID = reader.GetGuid(10);
						//11:Parameter AssignedTo_BusinessTask_RefID of type Guid
						item.AssignedTo_BusinessTask_RefID = reader.GetGuid(11);
						//12:Parameter AssignedTo_Feature_RefID of type Guid
						item.AssignedTo_Feature_RefID = reader.GetGuid(12);
						//13:Parameter AssignedTo_DeveloperTask_RefID of type Guid
						item.AssignedTo_DeveloperTask_RefID = reader.GetGuid(13);
						//14:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(14);
						//15:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(15);
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
