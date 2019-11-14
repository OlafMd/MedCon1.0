/* 
 * Generated on 8/15/2013 12:44:33 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_HEC
{
	[Serializable]
	public class ORM_HEC_Patient_Treatment_RelevantDiagnosis
	{
		public static readonly string TableName = "hec_patient_treatment_relevantdiagnoses";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_Patient_Treatment_RelevantDiagnosis()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_Patient_Treatment_RelevantDiagnosisID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_Patient_Treatment_RelevantDiagnosisID = default(Guid);
		private Guid _Patient_Treatment_RefID = default(Guid);
		private Guid _Doctor_RefID = default(Guid);
		private Guid _DIA_PotentialDiagnosis_RefID = default(Guid);
		private Guid _DIA_State_RefID = default(Guid);
		private String _RelevantDiagnosis_Comment = default(String);
		private DateTime _DiagnosedOnDate = default(DateTime);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_Patient_Treatment_RelevantDiagnosisID { 
			get {
				return _HEC_Patient_Treatment_RelevantDiagnosisID;
			}
			set {
				if(_HEC_Patient_Treatment_RelevantDiagnosisID != value){
					_HEC_Patient_Treatment_RelevantDiagnosisID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Patient_Treatment_RefID { 
			get {
				return _Patient_Treatment_RefID;
			}
			set {
				if(_Patient_Treatment_RefID != value){
					_Patient_Treatment_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Doctor_RefID { 
			get {
				return _Doctor_RefID;
			}
			set {
				if(_Doctor_RefID != value){
					_Doctor_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DIA_PotentialDiagnosis_RefID { 
			get {
				return _DIA_PotentialDiagnosis_RefID;
			}
			set {
				if(_DIA_PotentialDiagnosis_RefID != value){
					_DIA_PotentialDiagnosis_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DIA_State_RefID { 
			get {
				return _DIA_State_RefID;
			}
			set {
				if(_DIA_State_RefID != value){
					_DIA_State_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String RelevantDiagnosis_Comment { 
			get {
				return _RelevantDiagnosis_Comment;
			}
			set {
				if(_RelevantDiagnosis_Comment != value){
					_RelevantDiagnosis_Comment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime DiagnosedOnDate { 
			get {
				return _DiagnosedOnDate;
			}
			set {
				if(_DiagnosedOnDate != value){
					_DiagnosedOnDate = value;
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


				#region VerifySessionToken/Create Connections
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Treatment_RelevantDiagnosis.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Treatment_RelevantDiagnosis.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_Patient_Treatment_RelevantDiagnosisID", _HEC_Patient_Treatment_RelevantDiagnosisID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Patient_Treatment_RefID", _Patient_Treatment_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Doctor_RefID", _Doctor_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DIA_PotentialDiagnosis_RefID", _DIA_PotentialDiagnosis_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DIA_State_RefID", _DIA_State_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RelevantDiagnosis_Comment", _RelevantDiagnosis_Comment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DiagnosedOnDate", _DiagnosedOnDate);
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
				#region VerifySessionToken/Create Connections
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Treatment_RelevantDiagnosis.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_Patient_Treatment_RelevantDiagnosisID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_Patient_Treatment_RelevantDiagnosisID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_Patient_Treatment_RelevantDiagnosisID","Patient_Treatment_RefID","Doctor_RefID","DIA_PotentialDiagnosis_RefID","DIA_State_RefID","RelevantDiagnosis_Comment","DiagnosedOnDate","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_Patient_Treatment_RelevantDiagnosisID of type Guid
						_HEC_Patient_Treatment_RelevantDiagnosisID = reader.GetGuid(0);
						//1:Parameter Patient_Treatment_RefID of type Guid
						_Patient_Treatment_RefID = reader.GetGuid(1);
						//2:Parameter Doctor_RefID of type Guid
						_Doctor_RefID = reader.GetGuid(2);
						//3:Parameter DIA_PotentialDiagnosis_RefID of type Guid
						_DIA_PotentialDiagnosis_RefID = reader.GetGuid(3);
						//4:Parameter DIA_State_RefID of type Guid
						_DIA_State_RefID = reader.GetGuid(4);
						//5:Parameter RelevantDiagnosis_Comment of type String
						_RelevantDiagnosis_Comment = reader.GetString(5);
						//6:Parameter DiagnosedOnDate of type DateTime
						_DiagnosedOnDate = reader.GetDate(6);
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

					if(_HEC_Patient_Treatment_RelevantDiagnosisID != Guid.Empty){
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
			public Guid? HEC_Patient_Treatment_RelevantDiagnosisID {	get; set; }
			public Guid? Patient_Treatment_RefID {	get; set; }
			public Guid? Doctor_RefID {	get; set; }
			public Guid? DIA_PotentialDiagnosis_RefID {	get; set; }
			public Guid? DIA_State_RefID {	get; set; }
			public String RelevantDiagnosis_Comment {	get; set; }
			public DateTime? DiagnosedOnDate {	get; set; }
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
			public static List<ORM_HEC_Patient_Treatment_RelevantDiagnosis> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_Patient_Treatment_RelevantDiagnosis> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_Patient_Treatment_RelevantDiagnosis> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_Patient_Treatment_RelevantDiagnosis> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_Patient_Treatment_RelevantDiagnosis> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_Patient_Treatment_RelevantDiagnosis>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_Patient_Treatment_RelevantDiagnosisID","Patient_Treatment_RefID","Doctor_RefID","DIA_PotentialDiagnosis_RefID","DIA_State_RefID","RelevantDiagnosis_Comment","DiagnosedOnDate","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_HEC_Patient_Treatment_RelevantDiagnosis item = new ORM_HEC_Patient_Treatment_RelevantDiagnosis();
						//0:Parameter HEC_Patient_Treatment_RelevantDiagnosisID of type Guid
						item.HEC_Patient_Treatment_RelevantDiagnosisID = reader.GetGuid(0);
						//1:Parameter Patient_Treatment_RefID of type Guid
						item.Patient_Treatment_RefID = reader.GetGuid(1);
						//2:Parameter Doctor_RefID of type Guid
						item.Doctor_RefID = reader.GetGuid(2);
						//3:Parameter DIA_PotentialDiagnosis_RefID of type Guid
						item.DIA_PotentialDiagnosis_RefID = reader.GetGuid(3);
						//4:Parameter DIA_State_RefID of type Guid
						item.DIA_State_RefID = reader.GetGuid(4);
						//5:Parameter RelevantDiagnosis_Comment of type String
						item.RelevantDiagnosis_Comment = reader.GetString(5);
						//6:Parameter DiagnosedOnDate of type DateTime
						item.DiagnosedOnDate = reader.GetDate(6);
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
