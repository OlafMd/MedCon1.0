/* 
 * Generated on 21.4.2015 11:00:55
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_CTR
{
	[Serializable]
	public class ORM_CMN_CTR_Contract_Parameter
	{
		public static readonly string TableName = "cmn_ctr_contract_parameters";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
        public static readonly int QueryTimeout = 6000;

		#region Class Constructor
		public ORM_CMN_CTR_Contract_Parameter()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_CTR_Contract_ParameterID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_CTR_Contract_ParameterID = default(Guid);
		private Guid _Contract_DefaultParameter_RefID = default(Guid);
		private Guid _Contract_RefID = default(Guid);
		private String _ParameterName = default(String);
		private Boolean _IsStringValue = default(Boolean);
		private String _IfStringValue_Value = default(String);
		private Boolean _IsNumericValue = default(Boolean);
		private double _IfNumericValue_Value = default(double);
		private Boolean _IsBooleanValue = default(Boolean);
		private Boolean _IfBooleanValue_Value = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_CTR_Contract_ParameterID { 
			get {
				return _CMN_CTR_Contract_ParameterID;
			}
			set {
				if(_CMN_CTR_Contract_ParameterID != value){
					_CMN_CTR_Contract_ParameterID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Contract_DefaultParameter_RefID { 
			get {
				return _Contract_DefaultParameter_RefID;
			}
			set {
				if(_Contract_DefaultParameter_RefID != value){
					_Contract_DefaultParameter_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Contract_RefID { 
			get {
				return _Contract_RefID;
			}
			set {
				if(_Contract_RefID != value){
					_Contract_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ParameterName { 
			get {
				return _ParameterName;
			}
			set {
				if(_ParameterName != value){
					_ParameterName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStringValue { 
			get {
				return _IsStringValue;
			}
			set {
				if(_IsStringValue != value){
					_IsStringValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IfStringValue_Value { 
			get {
				return _IfStringValue_Value;
			}
			set {
				if(_IfStringValue_Value != value){
					_IfStringValue_Value = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsNumericValue { 
			get {
				return _IsNumericValue;
			}
			set {
				if(_IsNumericValue != value){
					_IsNumericValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double IfNumericValue_Value { 
			get {
				return _IfNumericValue_Value;
			}
			set {
				if(_IfNumericValue_Value != value){
					_IfNumericValue_Value = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsBooleanValue { 
			get {
				return _IsBooleanValue;
			}
			set {
				if(_IsBooleanValue != value){
					_IsBooleanValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IfBooleanValue_Value { 
			get {
				return _IfBooleanValue_Value;
			}
			set {
				if(_IfBooleanValue_Value != value){
					_IfBooleanValue_Value = value;
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
		public DateTime Modification_Timestamp { 
			get {
				return _Modification_Timestamp;
			}
			set {
				if(_Modification_Timestamp != value){
					_Modification_Timestamp = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_CTR.CMN_CTR_Contract_Parameter.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_CTR.CMN_CTR_Contract_Parameter.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_CTR_Contract_ParameterID", _CMN_CTR_Contract_ParameterID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Contract_DefaultParameter_RefID", _Contract_DefaultParameter_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Contract_RefID", _Contract_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ParameterName", _ParameterName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStringValue", _IsStringValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfStringValue_Value", _IfStringValue_Value);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsNumericValue", _IsNumericValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfNumericValue_Value", _IfNumericValue_Value);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsBooleanValue", _IsBooleanValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfBooleanValue_Value", _IfBooleanValue_Value);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Modification_Timestamp", _Modification_Timestamp);


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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_CTR.CMN_CTR_Contract_Parameter.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_CTR_Contract_ParameterID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_CTR_Contract_ParameterID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_CTR_Contract_ParameterID","Contract_DefaultParameter_RefID","Contract_RefID","ParameterName","IsStringValue","IfStringValue_Value","IsNumericValue","IfNumericValue_Value","IsBooleanValue","IfBooleanValue_Value","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_CTR_Contract_ParameterID of type Guid
						_CMN_CTR_Contract_ParameterID = reader.GetGuid(0);
						//1:Parameter Contract_DefaultParameter_RefID of type Guid
						_Contract_DefaultParameter_RefID = reader.GetGuid(1);
						//2:Parameter Contract_RefID of type Guid
						_Contract_RefID = reader.GetGuid(2);
						//3:Parameter ParameterName of type String
						_ParameterName = reader.GetString(3);
						//4:Parameter IsStringValue of type Boolean
						_IsStringValue = reader.GetBoolean(4);
						//5:Parameter IfStringValue_Value of type String
						_IfStringValue_Value = reader.GetString(5);
						//6:Parameter IsNumericValue of type Boolean
						_IsNumericValue = reader.GetBoolean(6);
						//7:Parameter IfNumericValue_Value of type double
						_IfNumericValue_Value = reader.GetDouble(7);
						//8:Parameter IsBooleanValue of type Boolean
						_IsBooleanValue = reader.GetBoolean(8);
						//9:Parameter IfBooleanValue_Value of type Boolean
						_IfBooleanValue_Value = reader.GetBoolean(9);
						//10:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(10);
						//11:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(11);
						//12:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(12);
						//13:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(13);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_CTR_Contract_ParameterID != Guid.Empty){
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
			public Guid? CMN_CTR_Contract_ParameterID {	get; set; }
			public Guid? Contract_DefaultParameter_RefID {	get; set; }
			public Guid? Contract_RefID {	get; set; }
			public String ParameterName {	get; set; }
			public Boolean? IsStringValue {	get; set; }
			public String IfStringValue_Value {	get; set; }
			public Boolean? IsNumericValue {	get; set; }
			public double? IfNumericValue_Value {	get; set; }
			public Boolean? IsBooleanValue {	get; set; }
			public Boolean? IfBooleanValue_Value {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			public DateTime? Modification_Timestamp {	get; set; }
			 

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
			public static List<ORM_CMN_CTR_Contract_Parameter> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_CTR_Contract_Parameter> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_CTR_Contract_Parameter> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_CTR_Contract_Parameter> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_CTR_Contract_Parameter> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_CTR_Contract_Parameter>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_CTR_Contract_ParameterID","Contract_DefaultParameter_RefID","Contract_RefID","ParameterName","IsStringValue","IfStringValue_Value","IsNumericValue","IfNumericValue_Value","IsBooleanValue","IfBooleanValue_Value","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_CMN_CTR_Contract_Parameter item = new ORM_CMN_CTR_Contract_Parameter();
						//0:Parameter CMN_CTR_Contract_ParameterID of type Guid
						item.CMN_CTR_Contract_ParameterID = reader.GetGuid(0);
						//1:Parameter Contract_DefaultParameter_RefID of type Guid
						item.Contract_DefaultParameter_RefID = reader.GetGuid(1);
						//2:Parameter Contract_RefID of type Guid
						item.Contract_RefID = reader.GetGuid(2);
						//3:Parameter ParameterName of type String
						item.ParameterName = reader.GetString(3);
						//4:Parameter IsStringValue of type Boolean
						item.IsStringValue = reader.GetBoolean(4);
						//5:Parameter IfStringValue_Value of type String
						item.IfStringValue_Value = reader.GetString(5);
						//6:Parameter IsNumericValue of type Boolean
						item.IsNumericValue = reader.GetBoolean(6);
						//7:Parameter IfNumericValue_Value of type double
						item.IfNumericValue_Value = reader.GetDouble(7);
						//8:Parameter IsBooleanValue of type Boolean
						item.IsBooleanValue = reader.GetBoolean(8);
						//9:Parameter IfBooleanValue_Value of type Boolean
						item.IfBooleanValue_Value = reader.GetBoolean(9);
						//10:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(10);
						//11:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(11);
						//12:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(12);
						//13:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(13);


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
