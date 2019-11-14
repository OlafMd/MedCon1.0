/* 
 * Generated on 7/22/2013 5:13:44 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_RES_ACT
{
	[Serializable]
	public class ORM_RES_ACT_Action_Version
	{
		public static readonly string TableName = "res_act_action_version";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_RES_ACT_Action_Version()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_RES_ACT_Action_VersionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _RES_ACT_Action_VersionID = default(Guid);
		private Guid _Action_RefID = default(Guid);
		private Dict _Action_Name = new Dict(TableName);
		private Dict _Action_Description = new Dict(TableName);
		private int _Action_Version = default(int);
		private Guid _Default_PricePerUnit_RefID = default(Guid);
		private Guid _Default_Unit_RefID = default(Guid);
		private double _Default_UnitAmount = default(double);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid RES_ACT_Action_VersionID { 
			get {
				return _RES_ACT_Action_VersionID;
			}
			set {
				if(_RES_ACT_Action_VersionID != value){
					_RES_ACT_Action_VersionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Action_RefID { 
			get {
				return _Action_RefID;
			}
			set {
				if(_Action_RefID != value){
					_Action_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Action_Name { 
			get {
				return _Action_Name;
			}
			set {
				if(_Action_Name != value){
					_Action_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Action_Description { 
			get {
				return _Action_Description;
			}
			set {
				if(_Action_Description != value){
					_Action_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Action_Version { 
			get {
				return _Action_Version;
			}
			set {
				if(_Action_Version != value){
					_Action_Version = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Default_PricePerUnit_RefID { 
			get {
				return _Default_PricePerUnit_RefID;
			}
			set {
				if(_Default_PricePerUnit_RefID != value){
					_Default_PricePerUnit_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Default_Unit_RefID { 
			get {
				return _Default_Unit_RefID;
			}
			set {
				if(_Default_Unit_RefID != value){
					_Default_Unit_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double Default_UnitAmount { 
			get {
				return _Default_UnitAmount;
			}
			set {
				if(_Default_UnitAmount != value){
					_Default_UnitAmount = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || Action_Name.IsDirty || Action_Description.IsDirty ;
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
								loader.Append(Action_Name,TableName);
								loader.Append(Action_Description,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES_ACT.RES_ACT_Action_Version.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES_ACT.RES_ACT_Action_Version.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RES_ACT_Action_VersionID", _RES_ACT_Action_VersionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Action_RefID", _Action_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Action_Name", _Action_Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Action_Description", _Action_Description.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Action_Version", _Action_Version);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_PricePerUnit_RefID", _Default_PricePerUnit_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_Unit_RefID", _Default_Unit_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_UnitAmount", _Default_UnitAmount);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_RES_ACT.RES_ACT_Action_Version.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_RES_ACT_Action_VersionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RES_ACT_Action_VersionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "RES_ACT_Action_VersionID","Action_RefID","Action_Name_DictID","Action_Description_DictID","Action_Version","Default_PricePerUnit_RefID","Default_Unit_RefID","Default_UnitAmount","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter RES_ACT_Action_VersionID of type Guid
						_RES_ACT_Action_VersionID = reader.GetGuid(0);
						//1:Parameter Action_RefID of type Guid
						_Action_RefID = reader.GetGuid(1);
						//2:Parameter Action_Name of type Dict
						_Action_Name = reader.GetDictionary(2);
						loader.Append(_Action_Name,TableName);
						//3:Parameter Action_Description of type Dict
						_Action_Description = reader.GetDictionary(3);
						loader.Append(_Action_Description,TableName);
						//4:Parameter Action_Version of type int
						_Action_Version = reader.GetInteger(4);
						//5:Parameter Default_PricePerUnit_RefID of type Guid
						_Default_PricePerUnit_RefID = reader.GetGuid(5);
						//6:Parameter Default_Unit_RefID of type Guid
						_Default_Unit_RefID = reader.GetGuid(6);
						//7:Parameter Default_UnitAmount of type double
						_Default_UnitAmount = reader.GetDouble(7);
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

					if(_RES_ACT_Action_VersionID != Guid.Empty){
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
			public Guid? RES_ACT_Action_VersionID {	get; set; }
			public Guid? Action_RefID {	get; set; }
			public Dict Action_Name {	get; set; }
			public Dict Action_Description {	get; set; }
			public int? Action_Version {	get; set; }
			public Guid? Default_PricePerUnit_RefID {	get; set; }
			public Guid? Default_Unit_RefID {	get; set; }
			public double? Default_UnitAmount {	get; set; }
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
			public static List<ORM_RES_ACT_Action_Version> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_RES_ACT_Action_Version> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_RES_ACT_Action_Version> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_RES_ACT_Action_Version> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_RES_ACT_Action_Version> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_RES_ACT_Action_Version>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "RES_ACT_Action_VersionID","Action_RefID","Action_Name_DictID","Action_Description_DictID","Action_Version","Default_PricePerUnit_RefID","Default_Unit_RefID","Default_UnitAmount","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_RES_ACT_Action_Version item = new ORM_RES_ACT_Action_Version();
						//0:Parameter RES_ACT_Action_VersionID of type Guid
						item.RES_ACT_Action_VersionID = reader.GetGuid(0);
						//1:Parameter Action_RefID of type Guid
						item.Action_RefID = reader.GetGuid(1);
						//2:Parameter Action_Name of type Dict
						item.Action_Name = reader.GetDictionary(2);
						loader.Append(item.Action_Name,TableName);
						//3:Parameter Action_Description of type Dict
						item.Action_Description = reader.GetDictionary(3);
						loader.Append(item.Action_Description,TableName);
						//4:Parameter Action_Version of type int
						item.Action_Version = reader.GetInteger(4);
						//5:Parameter Default_PricePerUnit_RefID of type Guid
						item.Default_PricePerUnit_RefID = reader.GetGuid(5);
						//6:Parameter Default_Unit_RefID of type Guid
						item.Default_Unit_RefID = reader.GetGuid(6);
						//7:Parameter Default_UnitAmount of type double
						item.Default_UnitAmount = reader.GetDouble(7);
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
