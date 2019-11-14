/* 
 * Generated on 10/14/2014 4:14:20 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC_DIA
{
	[Serializable]
	public class ORM_HEC_DIA_PotentialDiagnosis_Catalog
	{
		public static readonly string TableName = "hec_dia_potentialdiagnosis_catalogs";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_DIA_PotentialDiagnosis_Catalog()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_DIA_PotentialDiagnosis_CatalogID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_DIA_PotentialDiagnosis_CatalogID = default(Guid);
		private String _GlobalPropertyMatchingID = default(String);
		private String _Catalog_DisplayName = default(String);
		private Dict _Catalog_Name = new Dict(TableName);
		private Boolean _IsUsingSelfLearningPriorities = default(Boolean);
		private int _SelfLearningPriorities_InitializationTreshold = default(int);
		private Boolean _IsPrivateCatalog = default(Boolean);
		private int _R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed = default(int);
		private int _SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount = default(int);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_DIA_PotentialDiagnosis_CatalogID { 
			get {
				return _HEC_DIA_PotentialDiagnosis_CatalogID;
			}
			set {
				if(_HEC_DIA_PotentialDiagnosis_CatalogID != value){
					_HEC_DIA_PotentialDiagnosis_CatalogID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String GlobalPropertyMatchingID { 
			get {
				return _GlobalPropertyMatchingID;
			}
			set {
				if(_GlobalPropertyMatchingID != value){
					_GlobalPropertyMatchingID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Catalog_DisplayName { 
			get {
				return _Catalog_DisplayName;
			}
			set {
				if(_Catalog_DisplayName != value){
					_Catalog_DisplayName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Catalog_Name { 
			get {
				return _Catalog_Name;
			}
			set {
				if(_Catalog_Name != value){
					_Catalog_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsUsingSelfLearningPriorities { 
			get {
				return _IsUsingSelfLearningPriorities;
			}
			set {
				if(_IsUsingSelfLearningPriorities != value){
					_IsUsingSelfLearningPriorities = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int SelfLearningPriorities_InitializationTreshold { 
			get {
				return _SelfLearningPriorities_InitializationTreshold;
			}
			set {
				if(_SelfLearningPriorities_InitializationTreshold != value){
					_SelfLearningPriorities_InitializationTreshold = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPrivateCatalog { 
			get {
				return _IsPrivateCatalog;
			}
			set {
				if(_IsPrivateCatalog != value){
					_IsPrivateCatalog = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed { 
			get {
				return _R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed;
			}
			set {
				if(_R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed != value){
					_R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount { 
			get {
				return _SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount;
			}
			set {
				if(_SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount != value){
					_SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || Catalog_Name.IsDirty ;
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
								loader.Append(Catalog_Name,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_DIA.HEC_DIA_PotentialDiagnosis_Catalog.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_DIA.HEC_DIA_PotentialDiagnosis_Catalog.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_DIA_PotentialDiagnosis_CatalogID", _HEC_DIA_PotentialDiagnosis_CatalogID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "GlobalPropertyMatchingID", _GlobalPropertyMatchingID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Catalog_DisplayName", _Catalog_DisplayName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Catalog_Name", _Catalog_Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsUsingSelfLearningPriorities", _IsUsingSelfLearningPriorities);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SelfLearningPriorities_InitializationTreshold", _SelfLearningPriorities_InitializationTreshold);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPrivateCatalog", _IsPrivateCatalog);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed", _R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount", _SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_DIA.HEC_DIA_PotentialDiagnosis_Catalog.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_DIA_PotentialDiagnosis_CatalogID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_DIA_PotentialDiagnosis_CatalogID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_DIA_PotentialDiagnosis_CatalogID","GlobalPropertyMatchingID","Catalog_DisplayName","Catalog_Name_DictID","IsUsingSelfLearningPriorities","SelfLearningPriorities_InitializationTreshold","IsPrivateCatalog","R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed","SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_DIA_PotentialDiagnosis_CatalogID of type Guid
						_HEC_DIA_PotentialDiagnosis_CatalogID = reader.GetGuid(0);
						//1:Parameter GlobalPropertyMatchingID of type String
						_GlobalPropertyMatchingID = reader.GetString(1);
						//2:Parameter Catalog_DisplayName of type String
						_Catalog_DisplayName = reader.GetString(2);
						//3:Parameter Catalog_Name of type Dict
						_Catalog_Name = reader.GetDictionary(3);
						loader.Append(_Catalog_Name,TableName);
						//4:Parameter IsUsingSelfLearningPriorities of type Boolean
						_IsUsingSelfLearningPriorities = reader.GetBoolean(4);
						//5:Parameter SelfLearningPriorities_InitializationTreshold of type int
						_SelfLearningPriorities_InitializationTreshold = reader.GetInteger(5);
						//6:Parameter IsPrivateCatalog of type Boolean
						_IsPrivateCatalog = reader.GetBoolean(6);
						//7:Parameter R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed of type int
						_R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed = reader.GetInteger(7);
						//8:Parameter SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount of type int
						_SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount = reader.GetInteger(8);
						//9:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(9);
						//10:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(10);
						//11:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(11);
						//12:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(12);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_DIA_PotentialDiagnosis_CatalogID != Guid.Empty){
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
			public Guid? HEC_DIA_PotentialDiagnosis_CatalogID {	get; set; }
			public String GlobalPropertyMatchingID {	get; set; }
			public String Catalog_DisplayName {	get; set; }
			public Dict Catalog_Name {	get; set; }
			public Boolean? IsUsingSelfLearningPriorities {	get; set; }
			public int? SelfLearningPriorities_InitializationTreshold {	get; set; }
			public Boolean? IsPrivateCatalog {	get; set; }
			public int? R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed {	get; set; }
			public int? SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount {	get; set; }
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
			public static List<ORM_HEC_DIA_PotentialDiagnosis_Catalog> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_DIA_PotentialDiagnosis_Catalog> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_DIA_PotentialDiagnosis_Catalog> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_DIA_PotentialDiagnosis_Catalog> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_DIA_PotentialDiagnosis_Catalog> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_DIA_PotentialDiagnosis_Catalog>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_DIA_PotentialDiagnosis_CatalogID","GlobalPropertyMatchingID","Catalog_DisplayName","Catalog_Name_DictID","IsUsingSelfLearningPriorities","SelfLearningPriorities_InitializationTreshold","IsPrivateCatalog","R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed","SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_DIA_PotentialDiagnosis_Catalog item = new ORM_HEC_DIA_PotentialDiagnosis_Catalog();
						//0:Parameter HEC_DIA_PotentialDiagnosis_CatalogID of type Guid
						item.HEC_DIA_PotentialDiagnosis_CatalogID = reader.GetGuid(0);
						//1:Parameter GlobalPropertyMatchingID of type String
						item.GlobalPropertyMatchingID = reader.GetString(1);
						//2:Parameter Catalog_DisplayName of type String
						item.Catalog_DisplayName = reader.GetString(2);
						//3:Parameter Catalog_Name of type Dict
						item.Catalog_Name = reader.GetDictionary(3);
						loader.Append(item.Catalog_Name,TableName);
						//4:Parameter IsUsingSelfLearningPriorities of type Boolean
						item.IsUsingSelfLearningPriorities = reader.GetBoolean(4);
						//5:Parameter SelfLearningPriorities_InitializationTreshold of type int
						item.SelfLearningPriorities_InitializationTreshold = reader.GetInteger(5);
						//6:Parameter IsPrivateCatalog of type Boolean
						item.IsPrivateCatalog = reader.GetBoolean(6);
						//7:Parameter R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed of type int
						item.R_InitializationTreshold_NumberOfRelevantDiagnosisPerformed = reader.GetInteger(7);
						//8:Parameter SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount of type int
						item.SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount = reader.GetInteger(8);
						//9:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(9);
						//10:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(10);
						//11:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(11);
						//12:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(12);


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
