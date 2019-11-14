/* 
 * Generated on 10/14/2014 4:37:59 PM
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
	public class ORM_HEC_DIA_PotentialDiagnosis
	{
		public static readonly string TableName = "hec_dia_potentialdiagnoses";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_DIA_PotentialDiagnosis()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_DIA_PotentialDiagnosisID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_DIA_PotentialDiagnosisID = default(Guid);
		private String _PotentialDiagnosisITL = default(String);
		private Dict _PotentialDiagnosis_Name = new Dict(TableName);
		private Dict _PotentialDiagnosis_Description = new Dict(TableName);
		private String _ICD10_Code = default(String);
		private Boolean _IsHospitalTransmissionIndicated = default(Boolean);
		private Boolean _IsRefferalIndicated = default(Boolean);
		private Boolean _IsAllergy = default(Boolean);
		private Guid _IsRefferalIndicated_PracticeType_RefID = default(Guid);
		private int _DefaultTimeUntillDeactivation_InDays = default(int);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_DIA_PotentialDiagnosisID { 
			get {
				return _HEC_DIA_PotentialDiagnosisID;
			}
			set {
				if(_HEC_DIA_PotentialDiagnosisID != value){
					_HEC_DIA_PotentialDiagnosisID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String PotentialDiagnosisITL { 
			get {
				return _PotentialDiagnosisITL;
			}
			set {
				if(_PotentialDiagnosisITL != value){
					_PotentialDiagnosisITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict PotentialDiagnosis_Name { 
			get {
				return _PotentialDiagnosis_Name;
			}
			set {
				if(_PotentialDiagnosis_Name != value){
					_PotentialDiagnosis_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict PotentialDiagnosis_Description { 
			get {
				return _PotentialDiagnosis_Description;
			}
			set {
				if(_PotentialDiagnosis_Description != value){
					_PotentialDiagnosis_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ICD10_Code { 
			get {
				return _ICD10_Code;
			}
			set {
				if(_ICD10_Code != value){
					_ICD10_Code = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsHospitalTransmissionIndicated { 
			get {
				return _IsHospitalTransmissionIndicated;
			}
			set {
				if(_IsHospitalTransmissionIndicated != value){
					_IsHospitalTransmissionIndicated = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsRefferalIndicated { 
			get {
				return _IsRefferalIndicated;
			}
			set {
				if(_IsRefferalIndicated != value){
					_IsRefferalIndicated = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAllergy { 
			get {
				return _IsAllergy;
			}
			set {
				if(_IsAllergy != value){
					_IsAllergy = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IsRefferalIndicated_PracticeType_RefID { 
			get {
				return _IsRefferalIndicated_PracticeType_RefID;
			}
			set {
				if(_IsRefferalIndicated_PracticeType_RefID != value){
					_IsRefferalIndicated_PracticeType_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int DefaultTimeUntillDeactivation_InDays { 
			get {
				return _DefaultTimeUntillDeactivation_InDays;
			}
			set {
				if(_DefaultTimeUntillDeactivation_InDays != value){
					_DefaultTimeUntillDeactivation_InDays = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || PotentialDiagnosis_Name.IsDirty || PotentialDiagnosis_Description.IsDirty ;
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
								loader.Append(PotentialDiagnosis_Name,TableName);
								loader.Append(PotentialDiagnosis_Description,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_DIA.HEC_DIA_PotentialDiagnosis.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_DIA.HEC_DIA_PotentialDiagnosis.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_DIA_PotentialDiagnosisID", _HEC_DIA_PotentialDiagnosisID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PotentialDiagnosisITL", _PotentialDiagnosisITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PotentialDiagnosis_Name", _PotentialDiagnosis_Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PotentialDiagnosis_Description", _PotentialDiagnosis_Description.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ICD10_Code", _ICD10_Code);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsHospitalTransmissionIndicated", _IsHospitalTransmissionIndicated);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsRefferalIndicated", _IsRefferalIndicated);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAllergy", _IsAllergy);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsRefferalIndicated_PracticeType_RefID", _IsRefferalIndicated_PracticeType_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DefaultTimeUntillDeactivation_InDays", _DefaultTimeUntillDeactivation_InDays);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_DIA.HEC_DIA_PotentialDiagnosis.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_DIA_PotentialDiagnosisID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_DIA_PotentialDiagnosisID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_DIA_PotentialDiagnosisID","PotentialDiagnosisITL","PotentialDiagnosis_Name_DictID","PotentialDiagnosis_Description_DictID","ICD10_Code","IsHospitalTransmissionIndicated","IsRefferalIndicated","IsAllergy","IsRefferalIndicated_PracticeType_RefID","DefaultTimeUntillDeactivation_InDays","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_DIA_PotentialDiagnosisID of type Guid
						_HEC_DIA_PotentialDiagnosisID = reader.GetGuid(0);
						//1:Parameter PotentialDiagnosisITL of type String
						_PotentialDiagnosisITL = reader.GetString(1);
						//2:Parameter PotentialDiagnosis_Name of type Dict
						_PotentialDiagnosis_Name = reader.GetDictionary(2);
						loader.Append(_PotentialDiagnosis_Name,TableName);
						//3:Parameter PotentialDiagnosis_Description of type Dict
						_PotentialDiagnosis_Description = reader.GetDictionary(3);
						loader.Append(_PotentialDiagnosis_Description,TableName);
						//4:Parameter ICD10_Code of type String
						_ICD10_Code = reader.GetString(4);
						//5:Parameter IsHospitalTransmissionIndicated of type Boolean
						_IsHospitalTransmissionIndicated = reader.GetBoolean(5);
						//6:Parameter IsRefferalIndicated of type Boolean
						_IsRefferalIndicated = reader.GetBoolean(6);
						//7:Parameter IsAllergy of type Boolean
						_IsAllergy = reader.GetBoolean(7);
						//8:Parameter IsRefferalIndicated_PracticeType_RefID of type Guid
						_IsRefferalIndicated_PracticeType_RefID = reader.GetGuid(8);
						//9:Parameter DefaultTimeUntillDeactivation_InDays of type int
						_DefaultTimeUntillDeactivation_InDays = reader.GetInteger(9);
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

					if(_HEC_DIA_PotentialDiagnosisID != Guid.Empty){
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
			public Guid? HEC_DIA_PotentialDiagnosisID {	get; set; }
			public String PotentialDiagnosisITL {	get; set; }
			public Dict PotentialDiagnosis_Name {	get; set; }
			public Dict PotentialDiagnosis_Description {	get; set; }
			public String ICD10_Code {	get; set; }
			public Boolean? IsHospitalTransmissionIndicated {	get; set; }
			public Boolean? IsRefferalIndicated {	get; set; }
			public Boolean? IsAllergy {	get; set; }
			public Guid? IsRefferalIndicated_PracticeType_RefID {	get; set; }
			public int? DefaultTimeUntillDeactivation_InDays {	get; set; }
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
			public static List<ORM_HEC_DIA_PotentialDiagnosis> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_DIA_PotentialDiagnosis> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_DIA_PotentialDiagnosis> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_DIA_PotentialDiagnosis> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_DIA_PotentialDiagnosis> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_DIA_PotentialDiagnosis>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_DIA_PotentialDiagnosisID","PotentialDiagnosisITL","PotentialDiagnosis_Name_DictID","PotentialDiagnosis_Description_DictID","ICD10_Code","IsHospitalTransmissionIndicated","IsRefferalIndicated","IsAllergy","IsRefferalIndicated_PracticeType_RefID","DefaultTimeUntillDeactivation_InDays","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_DIA_PotentialDiagnosis item = new ORM_HEC_DIA_PotentialDiagnosis();
						//0:Parameter HEC_DIA_PotentialDiagnosisID of type Guid
						item.HEC_DIA_PotentialDiagnosisID = reader.GetGuid(0);
						//1:Parameter PotentialDiagnosisITL of type String
						item.PotentialDiagnosisITL = reader.GetString(1);
						//2:Parameter PotentialDiagnosis_Name of type Dict
						item.PotentialDiagnosis_Name = reader.GetDictionary(2);
						loader.Append(item.PotentialDiagnosis_Name,TableName);
						//3:Parameter PotentialDiagnosis_Description of type Dict
						item.PotentialDiagnosis_Description = reader.GetDictionary(3);
						loader.Append(item.PotentialDiagnosis_Description,TableName);
						//4:Parameter ICD10_Code of type String
						item.ICD10_Code = reader.GetString(4);
						//5:Parameter IsHospitalTransmissionIndicated of type Boolean
						item.IsHospitalTransmissionIndicated = reader.GetBoolean(5);
						//6:Parameter IsRefferalIndicated of type Boolean
						item.IsRefferalIndicated = reader.GetBoolean(6);
						//7:Parameter IsAllergy of type Boolean
						item.IsAllergy = reader.GetBoolean(7);
						//8:Parameter IsRefferalIndicated_PracticeType_RefID of type Guid
						item.IsRefferalIndicated_PracticeType_RefID = reader.GetGuid(8);
						//9:Parameter DefaultTimeUntillDeactivation_InDays of type int
						item.DefaultTimeUntillDeactivation_InDays = reader.GetInteger(9);
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
