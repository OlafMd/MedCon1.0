/* 
 * Generated on 05/21/15 11:49:16
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC_CAS
{
	[Serializable]
	public class ORM_HEC_CAS_Case
	{
		public static readonly string TableName = "hec_cas_cases";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_CAS_Case()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_CAS_CaseID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_CAS_CaseID = default(Guid);
		private Guid _Patient_RefID = default(Guid);
		private Guid _CreatedBy_BusinessParticipant_RefID = default(Guid);
		private String _CaseNumber = default(String);
		private Dict _CaseTitle = new Dict(TableName);
		private Dict _CaseDescription = new Dict(TableName);
		private Boolean _IsClosed = default(Boolean);
		private Boolean _IsSolved = default(Boolean);
		private String _Patient_FirstName = default(String);
		private String _Patient_LastName = default(String);
		private int _Patient_Gender = default(int);
		private int _Patient_Age = default(int);
		private DateTime _Patient_BirthDate = default(DateTime);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_CAS_CaseID { 
			get {
				return _HEC_CAS_CaseID;
			}
			set {
				if(_HEC_CAS_CaseID != value){
					_HEC_CAS_CaseID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Patient_RefID { 
			get {
				return _Patient_RefID;
			}
			set {
				if(_Patient_RefID != value){
					_Patient_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CreatedBy_BusinessParticipant_RefID { 
			get {
				return _CreatedBy_BusinessParticipant_RefID;
			}
			set {
				if(_CreatedBy_BusinessParticipant_RefID != value){
					_CreatedBy_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CaseNumber { 
			get {
				return _CaseNumber;
			}
			set {
				if(_CaseNumber != value){
					_CaseNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict CaseTitle { 
			get {
				return _CaseTitle;
			}
			set {
				if(_CaseTitle != value){
					_CaseTitle = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict CaseDescription { 
			get {
				return _CaseDescription;
			}
			set {
				if(_CaseDescription != value){
					_CaseDescription = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsClosed { 
			get {
				return _IsClosed;
			}
			set {
				if(_IsClosed != value){
					_IsClosed = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsSolved { 
			get {
				return _IsSolved;
			}
			set {
				if(_IsSolved != value){
					_IsSolved = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Patient_FirstName { 
			get {
				return _Patient_FirstName;
			}
			set {
				if(_Patient_FirstName != value){
					_Patient_FirstName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Patient_LastName { 
			get {
				return _Patient_LastName;
			}
			set {
				if(_Patient_LastName != value){
					_Patient_LastName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Patient_Gender { 
			get {
				return _Patient_Gender;
			}
			set {
				if(_Patient_Gender != value){
					_Patient_Gender = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Patient_Age { 
			get {
				return _Patient_Age;
			}
			set {
				if(_Patient_Age != value){
					_Patient_Age = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Patient_BirthDate { 
			get {
				return _Patient_BirthDate;
			}
			set {
				if(_Patient_BirthDate != value){
					_Patient_BirthDate = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || CaseTitle.IsDirty || CaseDescription.IsDirty ;
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
								loader.Append(CaseTitle,TableName);
								loader.Append(CaseDescription,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_CAS.HEC_CAS_Case.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_CAS.HEC_CAS_Case.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_CAS_CaseID", _HEC_CAS_CaseID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Patient_RefID", _Patient_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CreatedBy_BusinessParticipant_RefID", _CreatedBy_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CaseNumber", _CaseNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CaseTitle", _CaseTitle.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CaseDescription", _CaseDescription.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsClosed", _IsClosed);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsSolved", _IsSolved);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Patient_FirstName", _Patient_FirstName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Patient_LastName", _Patient_LastName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Patient_Gender", _Patient_Gender);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Patient_Age", _Patient_Age);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Patient_BirthDate", _Patient_BirthDate);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_CAS.HEC_CAS_Case.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_CAS_CaseID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_CAS_CaseID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_CAS_CaseID","Patient_RefID","CreatedBy_BusinessParticipant_RefID","CaseNumber","CaseTitle_DictID","CaseDescription_DictID","IsClosed","IsSolved","Patient_FirstName","Patient_LastName","Patient_Gender","Patient_Age","Patient_BirthDate","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_CAS_CaseID of type Guid
						_HEC_CAS_CaseID = reader.GetGuid(0);
						//1:Parameter Patient_RefID of type Guid
						_Patient_RefID = reader.GetGuid(1);
						//2:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
						_CreatedBy_BusinessParticipant_RefID = reader.GetGuid(2);
						//3:Parameter CaseNumber of type String
						_CaseNumber = reader.GetString(3);
						//4:Parameter CaseTitle of type Dict
						_CaseTitle = reader.GetDictionary(4);
						loader.Append(_CaseTitle,TableName);
						//5:Parameter CaseDescription of type Dict
						_CaseDescription = reader.GetDictionary(5);
						loader.Append(_CaseDescription,TableName);
						//6:Parameter IsClosed of type Boolean
						_IsClosed = reader.GetBoolean(6);
						//7:Parameter IsSolved of type Boolean
						_IsSolved = reader.GetBoolean(7);
						//8:Parameter Patient_FirstName of type String
						_Patient_FirstName = reader.GetString(8);
						//9:Parameter Patient_LastName of type String
						_Patient_LastName = reader.GetString(9);
						//10:Parameter Patient_Gender of type int
						_Patient_Gender = reader.GetInteger(10);
						//11:Parameter Patient_Age of type int
						_Patient_Age = reader.GetInteger(11);
						//12:Parameter Patient_BirthDate of type DateTime
						_Patient_BirthDate = reader.GetDate(12);
						//13:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(15);
						//16:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(16);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_CAS_CaseID != Guid.Empty){
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
			public Guid? HEC_CAS_CaseID {	get; set; }
			public Guid? Patient_RefID {	get; set; }
			public Guid? CreatedBy_BusinessParticipant_RefID {	get; set; }
			public String CaseNumber {	get; set; }
			public Dict CaseTitle {	get; set; }
			public Dict CaseDescription {	get; set; }
			public Boolean? IsClosed {	get; set; }
			public Boolean? IsSolved {	get; set; }
			public String Patient_FirstName {	get; set; }
			public String Patient_LastName {	get; set; }
			public int? Patient_Gender {	get; set; }
			public int? Patient_Age {	get; set; }
			public DateTime? Patient_BirthDate {	get; set; }
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
			public static List<ORM_HEC_CAS_Case> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_CAS_Case> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_CAS_Case> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_CAS_Case> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_CAS_Case> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_CAS_Case>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_CAS_CaseID","Patient_RefID","CreatedBy_BusinessParticipant_RefID","CaseNumber","CaseTitle_DictID","CaseDescription_DictID","IsClosed","IsSolved","Patient_FirstName","Patient_LastName","Patient_Gender","Patient_Age","Patient_BirthDate","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_CAS_Case item = new ORM_HEC_CAS_Case();
						//0:Parameter HEC_CAS_CaseID of type Guid
						item.HEC_CAS_CaseID = reader.GetGuid(0);
						//1:Parameter Patient_RefID of type Guid
						item.Patient_RefID = reader.GetGuid(1);
						//2:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
						item.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(2);
						//3:Parameter CaseNumber of type String
						item.CaseNumber = reader.GetString(3);
						//4:Parameter CaseTitle of type Dict
						item.CaseTitle = reader.GetDictionary(4);
						loader.Append(item.CaseTitle,TableName);
						//5:Parameter CaseDescription of type Dict
						item.CaseDescription = reader.GetDictionary(5);
						loader.Append(item.CaseDescription,TableName);
						//6:Parameter IsClosed of type Boolean
						item.IsClosed = reader.GetBoolean(6);
						//7:Parameter IsSolved of type Boolean
						item.IsSolved = reader.GetBoolean(7);
						//8:Parameter Patient_FirstName of type String
						item.Patient_FirstName = reader.GetString(8);
						//9:Parameter Patient_LastName of type String
						item.Patient_LastName = reader.GetString(9);
						//10:Parameter Patient_Gender of type int
						item.Patient_Gender = reader.GetInteger(10);
						//11:Parameter Patient_Age of type int
						item.Patient_Age = reader.GetInteger(11);
						//12:Parameter Patient_BirthDate of type DateTime
						item.Patient_BirthDate = reader.GetDate(12);
						//13:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(15);
						//16:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(16);


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
