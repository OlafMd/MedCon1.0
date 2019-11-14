/* 
 * Generated on 6/18/2013 5:03:23 PM
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
	public class ORM_IMO_Questionnaire_CustomAction
	{
		public static readonly string TableName = "imo_questionnaire_customactions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_IMO_Questionnaire_CustomAction()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_IMO_Questionnaire_CustomActionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _IMO_Questionnaire_CustomActionID = default(Guid);
		private Guid _Questionnaire_Status_RefID = default(Guid);
		private Guid _Default_Timeframe_RefID = default(Guid);
		private Guid _Unit_RefID = default(Guid);
		private Guid _Creator_Account_RefID = default(Guid);
		private Dict _Label = new Dict(TableName);
		private Double _Unit_Cost = default(Double);
		private Boolean _IsAuthorized = default(Boolean);
		private Boolean _IsPrivate = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid IMO_Questionnaire_CustomActionID { 
			get {
				return _IMO_Questionnaire_CustomActionID;
			}
			set {
				if(_IMO_Questionnaire_CustomActionID != value){
					_IMO_Questionnaire_CustomActionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Questionnaire_Status_RefID { 
			get {
				return _Questionnaire_Status_RefID;
			}
			set {
				if(_Questionnaire_Status_RefID != value){
					_Questionnaire_Status_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Default_Timeframe_RefID { 
			get {
				return _Default_Timeframe_RefID;
			}
			set {
				if(_Default_Timeframe_RefID != value){
					_Default_Timeframe_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Unit_RefID { 
			get {
				return _Unit_RefID;
			}
			set {
				if(_Unit_RefID != value){
					_Unit_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Creator_Account_RefID { 
			get {
				return _Creator_Account_RefID;
			}
			set {
				if(_Creator_Account_RefID != value){
					_Creator_Account_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Label { 
			get {
				return _Label;
			}
			set {
				if(_Label != value){
					_Label = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double Unit_Cost { 
			get {
				return _Unit_Cost;
			}
			set {
				if(_Unit_Cost != value){
					_Unit_Cost = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAuthorized { 
			get {
				return _IsAuthorized;
			}
			set {
				if(_IsAuthorized != value){
					_IsAuthorized = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPrivate { 
			get {
				return _IsPrivate;
			}
			set {
				if(_IsPrivate != value){
					_IsPrivate = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || Label.IsDirty ;
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
								loader.Append(Label,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_IMO.IMO_Questionnaire_CustomAction.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_IMO.IMO_Questionnaire_CustomAction.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IMO_Questionnaire_CustomActionID", _IMO_Questionnaire_CustomActionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Questionnaire_Status_RefID", _Questionnaire_Status_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_Timeframe_RefID", _Default_Timeframe_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Unit_RefID", _Unit_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creator_Account_RefID", _Creator_Account_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Label", _Label.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Unit_Cost", _Unit_Cost);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAuthorized", _IsAuthorized);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPrivate", _IsPrivate);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_IMO.IMO_Questionnaire_CustomAction.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_IMO_Questionnaire_CustomActionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IMO_Questionnaire_CustomActionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "IMO_Questionnaire_CustomActionID","Questionnaire_Status_RefID","Default_Timeframe_RefID","Unit_RefID","Creator_Account_RefID","Label_DictID","Unit_Cost","IsAuthorized","IsPrivate","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter IMO_Questionnaire_CustomActionID of type Guid
						_IMO_Questionnaire_CustomActionID = reader.GetGuid(0);
						//1:Parameter Questionnaire_Status_RefID of type Guid
						_Questionnaire_Status_RefID = reader.GetGuid(1);
						//2:Parameter Default_Timeframe_RefID of type Guid
						_Default_Timeframe_RefID = reader.GetGuid(2);
						//3:Parameter Unit_RefID of type Guid
						_Unit_RefID = reader.GetGuid(3);
						//4:Parameter Creator_Account_RefID of type Guid
						_Creator_Account_RefID = reader.GetGuid(4);
						//5:Parameter Label of type Dict
						_Label = reader.GetDictionary(5);
						loader.Append(_Label,TableName);
						//6:Parameter Unit_Cost of type Double
						_Unit_Cost = reader.GetDouble(6);
						//7:Parameter IsAuthorized of type Boolean
						_IsAuthorized = reader.GetBoolean(7);
						//8:Parameter IsPrivate of type Boolean
						_IsPrivate = reader.GetBoolean(8);
						//9:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(9);
						//10:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(10);
						//11:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(11);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_IMO_Questionnaire_CustomActionID != Guid.Empty){
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
			public Guid? IMO_Questionnaire_CustomActionID {	get; set; }
			public Guid? Questionnaire_Status_RefID {	get; set; }
			public Guid? Default_Timeframe_RefID {	get; set; }
			public Guid? Unit_RefID {	get; set; }
			public Guid? Creator_Account_RefID {	get; set; }
			public Dict Label {	get; set; }
			public Double? Unit_Cost {	get; set; }
			public Boolean? IsAuthorized {	get; set; }
			public Boolean? IsPrivate {	get; set; }
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
			public static List<ORM_IMO_Questionnaire_CustomAction> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_IMO_Questionnaire_CustomAction> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_IMO_Questionnaire_CustomAction> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_IMO_Questionnaire_CustomAction> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_IMO_Questionnaire_CustomAction> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_IMO_Questionnaire_CustomAction>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "IMO_Questionnaire_CustomActionID","Questionnaire_Status_RefID","Default_Timeframe_RefID","Unit_RefID","Creator_Account_RefID","Label_DictID","Unit_Cost","IsAuthorized","IsPrivate","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_IMO_Questionnaire_CustomAction item = new ORM_IMO_Questionnaire_CustomAction();
						//0:Parameter IMO_Questionnaire_CustomActionID of type Guid
						item.IMO_Questionnaire_CustomActionID = reader.GetGuid(0);
						//1:Parameter Questionnaire_Status_RefID of type Guid
						item.Questionnaire_Status_RefID = reader.GetGuid(1);
						//2:Parameter Default_Timeframe_RefID of type Guid
						item.Default_Timeframe_RefID = reader.GetGuid(2);
						//3:Parameter Unit_RefID of type Guid
						item.Unit_RefID = reader.GetGuid(3);
						//4:Parameter Creator_Account_RefID of type Guid
						item.Creator_Account_RefID = reader.GetGuid(4);
						//5:Parameter Label of type Dict
						item.Label = reader.GetDictionary(5);
						loader.Append(item.Label,TableName);
						//6:Parameter Unit_Cost of type Double
						item.Unit_Cost = reader.GetDouble(6);
						//7:Parameter IsAuthorized of type Boolean
						item.IsAuthorized = reader.GetBoolean(7);
						//8:Parameter IsPrivate of type Boolean
						item.IsPrivate = reader.GetBoolean(8);
						//9:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(9);
						//10:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(10);
						//11:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(11);


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
