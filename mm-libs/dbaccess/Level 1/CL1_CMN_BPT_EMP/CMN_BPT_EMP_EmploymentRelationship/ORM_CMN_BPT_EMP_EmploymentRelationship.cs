/* 
 * Generated on 22-Oct-13 14:25:04
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
	public class ORM_CMN_BPT_EMP_EmploymentRelationship
	{
		public static readonly string TableName = "cmn_bpt_emp_employmentrelationships";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_EMP_EmploymentRelationship()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_EMP_EmploymentRelationshipID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_EMP_EmploymentRelationshipID = default(Guid);
		private Boolean _IsLockedFor_TemplateUpdates = default(Boolean);
		private Guid _Employee_RefID = default(Guid);
		private DateTime _Work_StartDate = default(DateTime);
		private DateTime _Work_EndDate = default(DateTime);
		private Boolean _HasWorkRelationEnded = default(Boolean);
		private Guid _InstanceOf_EmploymentRelationships_Template_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_EMP_EmploymentRelationshipID { 
			get {
				return _CMN_BPT_EMP_EmploymentRelationshipID;
			}
			set {
				if(_CMN_BPT_EMP_EmploymentRelationshipID != value){
					_CMN_BPT_EMP_EmploymentRelationshipID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLockedFor_TemplateUpdates { 
			get {
				return _IsLockedFor_TemplateUpdates;
			}
			set {
				if(_IsLockedFor_TemplateUpdates != value){
					_IsLockedFor_TemplateUpdates = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Employee_RefID { 
			get {
				return _Employee_RefID;
			}
			set {
				if(_Employee_RefID != value){
					_Employee_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Work_StartDate { 
			get {
				return _Work_StartDate;
			}
			set {
				if(_Work_StartDate != value){
					_Work_StartDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Work_EndDate { 
			get {
				return _Work_EndDate;
			}
			set {
				if(_Work_EndDate != value){
					_Work_EndDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean HasWorkRelationEnded { 
			get {
				return _HasWorkRelationEnded;
			}
			set {
				if(_HasWorkRelationEnded != value){
					_HasWorkRelationEnded = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid InstanceOf_EmploymentRelationships_Template_RefID { 
			get {
				return _InstanceOf_EmploymentRelationships_Template_RefID;
			}
			set {
				if(_InstanceOf_EmploymentRelationships_Template_RefID != value){
					_InstanceOf_EmploymentRelationships_Template_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_EmploymentRelationship.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_EmploymentRelationship.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_EMP_EmploymentRelationshipID", _CMN_BPT_EMP_EmploymentRelationshipID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLockedFor_TemplateUpdates", _IsLockedFor_TemplateUpdates);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Employee_RefID", _Employee_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Work_StartDate", _Work_StartDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Work_EndDate", _Work_EndDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HasWorkRelationEnded", _HasWorkRelationEnded);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InstanceOf_EmploymentRelationships_Template_RefID", _InstanceOf_EmploymentRelationships_Template_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_EmploymentRelationship.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_EMP_EmploymentRelationshipID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_EMP_EmploymentRelationshipID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_EmploymentRelationshipID","IsLockedFor_TemplateUpdates","Employee_RefID","Work_StartDate","Work_EndDate","HasWorkRelationEnded","InstanceOf_EmploymentRelationships_Template_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_EMP_EmploymentRelationshipID of type Guid
						_CMN_BPT_EMP_EmploymentRelationshipID = reader.GetGuid(0);
						//1:Parameter IsLockedFor_TemplateUpdates of type Boolean
						_IsLockedFor_TemplateUpdates = reader.GetBoolean(1);
						//2:Parameter Employee_RefID of type Guid
						_Employee_RefID = reader.GetGuid(2);
						//3:Parameter Work_StartDate of type DateTime
						_Work_StartDate = reader.GetDate(3);
						//4:Parameter Work_EndDate of type DateTime
						_Work_EndDate = reader.GetDate(4);
						//5:Parameter HasWorkRelationEnded of type Boolean
						_HasWorkRelationEnded = reader.GetBoolean(5);
						//6:Parameter InstanceOf_EmploymentRelationships_Template_RefID of type Guid
						_InstanceOf_EmploymentRelationships_Template_RefID = reader.GetGuid(6);
						//7:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(7);
						//8:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(8);
						//9:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(9);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_EMP_EmploymentRelationshipID != Guid.Empty){
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
			public Guid? CMN_BPT_EMP_EmploymentRelationshipID {	get; set; }
			public Boolean? IsLockedFor_TemplateUpdates {	get; set; }
			public Guid? Employee_RefID {	get; set; }
			public DateTime? Work_StartDate {	get; set; }
			public DateTime? Work_EndDate {	get; set; }
			public Boolean? HasWorkRelationEnded {	get; set; }
			public Guid? InstanceOf_EmploymentRelationships_Template_RefID {	get; set; }
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
			public static List<ORM_CMN_BPT_EMP_EmploymentRelationship> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_EMP_EmploymentRelationship> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_EMP_EmploymentRelationship> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_EMP_EmploymentRelationship> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_EMP_EmploymentRelationship> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_EMP_EmploymentRelationship>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_EmploymentRelationshipID","IsLockedFor_TemplateUpdates","Employee_RefID","Work_StartDate","Work_EndDate","HasWorkRelationEnded","InstanceOf_EmploymentRelationships_Template_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_EMP_EmploymentRelationship item = new ORM_CMN_BPT_EMP_EmploymentRelationship();
						//0:Parameter CMN_BPT_EMP_EmploymentRelationshipID of type Guid
						item.CMN_BPT_EMP_EmploymentRelationshipID = reader.GetGuid(0);
						//1:Parameter IsLockedFor_TemplateUpdates of type Boolean
						item.IsLockedFor_TemplateUpdates = reader.GetBoolean(1);
						//2:Parameter Employee_RefID of type Guid
						item.Employee_RefID = reader.GetGuid(2);
						//3:Parameter Work_StartDate of type DateTime
						item.Work_StartDate = reader.GetDate(3);
						//4:Parameter Work_EndDate of type DateTime
						item.Work_EndDate = reader.GetDate(4);
						//5:Parameter HasWorkRelationEnded of type Boolean
						item.HasWorkRelationEnded = reader.GetBoolean(5);
						//6:Parameter InstanceOf_EmploymentRelationships_Template_RefID of type Guid
						item.InstanceOf_EmploymentRelationships_Template_RefID = reader.GetGuid(6);
						//7:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(7);
						//8:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(8);
						//9:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(9);


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
