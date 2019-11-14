/* 
 * Generated on 1/20/2015 3:22:54 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC
{
	[Serializable]
	public class ORM_HEC_Patient
	{
		public static readonly string TableName = "hec_patients";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_Patient()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_PatientID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_PatientID = default(Guid);
		private Guid _CMN_BPT_BusinessParticipant_RefID = default(Guid);
		private Boolean _HasSignedParticipationPolicyDocument = default(Boolean);
		private String _PatientComment = default(String);
		private Boolean _IsPatientParticipationPolicyValidated = default(Boolean);
		private Guid _PatientParticipationPolicyValidatedBy_Account_RefID = default(Guid);
		private String _EmployerCompanyName = default(String);
		private String _PatientProfession = default(String);
		private Boolean _IsTenant = default(Boolean);
		private String _Current_EMRFile_ExternalURL = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_PatientID { 
			get {
				return _HEC_PatientID;
			}
			set {
				if(_HEC_PatientID != value){
					_HEC_PatientID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_BPT_BusinessParticipant_RefID { 
			get {
				return _CMN_BPT_BusinessParticipant_RefID;
			}
			set {
				if(_CMN_BPT_BusinessParticipant_RefID != value){
					_CMN_BPT_BusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean HasSignedParticipationPolicyDocument { 
			get {
				return _HasSignedParticipationPolicyDocument;
			}
			set {
				if(_HasSignedParticipationPolicyDocument != value){
					_HasSignedParticipationPolicyDocument = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String PatientComment { 
			get {
				return _PatientComment;
			}
			set {
				if(_PatientComment != value){
					_PatientComment = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPatientParticipationPolicyValidated { 
			get {
				return _IsPatientParticipationPolicyValidated;
			}
			set {
				if(_IsPatientParticipationPolicyValidated != value){
					_IsPatientParticipationPolicyValidated = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid PatientParticipationPolicyValidatedBy_Account_RefID { 
			get {
				return _PatientParticipationPolicyValidatedBy_Account_RefID;
			}
			set {
				if(_PatientParticipationPolicyValidatedBy_Account_RefID != value){
					_PatientParticipationPolicyValidatedBy_Account_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String EmployerCompanyName { 
			get {
				return _EmployerCompanyName;
			}
			set {
				if(_EmployerCompanyName != value){
					_EmployerCompanyName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String PatientProfession { 
			get {
				return _PatientProfession;
			}
			set {
				if(_PatientProfession != value){
					_PatientProfession = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsTenant { 
			get {
				return _IsTenant;
			}
			set {
				if(_IsTenant != value){
					_IsTenant = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Current_EMRFile_ExternalURL { 
			get {
				return _Current_EMRFile_ExternalURL;
			}
			set {
				if(_Current_EMRFile_ExternalURL != value){
					_Current_EMRFile_ExternalURL = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_PatientID", _HEC_PatientID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_BusinessParticipant_RefID", _CMN_BPT_BusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HasSignedParticipationPolicyDocument", _HasSignedParticipationPolicyDocument);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PatientComment", _PatientComment);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPatientParticipationPolicyValidated", _IsPatientParticipationPolicyValidated);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PatientParticipationPolicyValidatedBy_Account_RefID", _PatientParticipationPolicyValidatedBy_Account_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "EmployerCompanyName", _EmployerCompanyName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PatientProfession", _PatientProfession);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsTenant", _IsTenant);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Current_EMRFile_ExternalURL", _Current_EMRFile_ExternalURL);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_PatientID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_PatientID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_PatientID","CMN_BPT_BusinessParticipant_RefID","HasSignedParticipationPolicyDocument","PatientComment","IsPatientParticipationPolicyValidated","PatientParticipationPolicyValidatedBy_Account_RefID","EmployerCompanyName","PatientProfession","IsTenant","Current_EMRFile_ExternalURL","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_PatientID of type Guid
						_HEC_PatientID = reader.GetGuid(0);
						//1:Parameter CMN_BPT_BusinessParticipant_RefID of type Guid
						_CMN_BPT_BusinessParticipant_RefID = reader.GetGuid(1);
						//2:Parameter HasSignedParticipationPolicyDocument of type Boolean
						_HasSignedParticipationPolicyDocument = reader.GetBoolean(2);
						//3:Parameter PatientComment of type String
						_PatientComment = reader.GetString(3);
						//4:Parameter IsPatientParticipationPolicyValidated of type Boolean
						_IsPatientParticipationPolicyValidated = reader.GetBoolean(4);
						//5:Parameter PatientParticipationPolicyValidatedBy_Account_RefID of type Guid
						_PatientParticipationPolicyValidatedBy_Account_RefID = reader.GetGuid(5);
						//6:Parameter EmployerCompanyName of type String
						_EmployerCompanyName = reader.GetString(6);
						//7:Parameter PatientProfession of type String
						_PatientProfession = reader.GetString(7);
						//8:Parameter IsTenant of type Boolean
						_IsTenant = reader.GetBoolean(8);
						//9:Parameter Current_EMRFile_ExternalURL of type String
						_Current_EMRFile_ExternalURL = reader.GetString(9);
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

					if(_HEC_PatientID != Guid.Empty){
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
			public Guid? HEC_PatientID {	get; set; }
			public Guid? CMN_BPT_BusinessParticipant_RefID {	get; set; }
			public Boolean? HasSignedParticipationPolicyDocument {	get; set; }
			public String PatientComment {	get; set; }
			public Boolean? IsPatientParticipationPolicyValidated {	get; set; }
			public Guid? PatientParticipationPolicyValidatedBy_Account_RefID {	get; set; }
			public String EmployerCompanyName {	get; set; }
			public String PatientProfession {	get; set; }
			public Boolean? IsTenant {	get; set; }
			public String Current_EMRFile_ExternalURL {	get; set; }
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
			public static List<ORM_HEC_Patient> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_Patient> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_Patient> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_Patient> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_Patient> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_Patient>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_PatientID","CMN_BPT_BusinessParticipant_RefID","HasSignedParticipationPolicyDocument","PatientComment","IsPatientParticipationPolicyValidated","PatientParticipationPolicyValidatedBy_Account_RefID","EmployerCompanyName","PatientProfession","IsTenant","Current_EMRFile_ExternalURL","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_Patient item = new ORM_HEC_Patient();
						//0:Parameter HEC_PatientID of type Guid
						item.HEC_PatientID = reader.GetGuid(0);
						//1:Parameter CMN_BPT_BusinessParticipant_RefID of type Guid
						item.CMN_BPT_BusinessParticipant_RefID = reader.GetGuid(1);
						//2:Parameter HasSignedParticipationPolicyDocument of type Boolean
						item.HasSignedParticipationPolicyDocument = reader.GetBoolean(2);
						//3:Parameter PatientComment of type String
						item.PatientComment = reader.GetString(3);
						//4:Parameter IsPatientParticipationPolicyValidated of type Boolean
						item.IsPatientParticipationPolicyValidated = reader.GetBoolean(4);
						//5:Parameter PatientParticipationPolicyValidatedBy_Account_RefID of type Guid
						item.PatientParticipationPolicyValidatedBy_Account_RefID = reader.GetGuid(5);
						//6:Parameter EmployerCompanyName of type String
						item.EmployerCompanyName = reader.GetString(6);
						//7:Parameter PatientProfession of type String
						item.PatientProfession = reader.GetString(7);
						//8:Parameter IsTenant of type Boolean
						item.IsTenant = reader.GetBoolean(8);
						//9:Parameter Current_EMRFile_ExternalURL of type String
						item.Current_EMRFile_ExternalURL = reader.GetString(9);
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
