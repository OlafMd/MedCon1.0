/* 
 * Generated on 09.03.2015 14:55:09
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
	public class ORM_HEC_Patient_Parameter
	{
		public static readonly string TableName = "hec_patient_parameters";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_Patient_Parameter()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_Patient_ParameterID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_Patient_ParameterID = default(Guid);
		private String _PatientParameterITL = default(String);
		private String _GlobalPropertyMatchingID = default(String);
		private Dict _Parameter_Name = new Dict(TableName);
		private Boolean _IsFloat = default(Boolean);
		private double _IfFloat_MinValue = default(double);
		private double _IfFloat_MaxValue = default(double);
		private Guid _IsFloat_ApplicableUnit_RefID = default(Guid);
		private Boolean _IsString = default(Boolean);
		private Boolean _IsVitalParameter = default(Boolean);
		private Boolean _HasHighRelevance = default(Boolean);
		private Guid _ParameterType_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_Patient_ParameterID { 
			get {
				return _HEC_Patient_ParameterID;
			}
			set {
				if(_HEC_Patient_ParameterID != value){
					_HEC_Patient_ParameterID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String PatientParameterITL { 
			get {
				return _PatientParameterITL;
			}
			set {
				if(_PatientParameterITL != value){
					_PatientParameterITL = value;
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
		public Dict Parameter_Name { 
			get {
				return _Parameter_Name;
			}
			set {
				if(_Parameter_Name != value){
					_Parameter_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsFloat { 
			get {
				return _IsFloat;
			}
			set {
				if(_IsFloat != value){
					_IsFloat = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double IfFloat_MinValue { 
			get {
				return _IfFloat_MinValue;
			}
			set {
				if(_IfFloat_MinValue != value){
					_IfFloat_MinValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double IfFloat_MaxValue { 
			get {
				return _IfFloat_MaxValue;
			}
			set {
				if(_IfFloat_MaxValue != value){
					_IfFloat_MaxValue = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IsFloat_ApplicableUnit_RefID { 
			get {
				return _IsFloat_ApplicableUnit_RefID;
			}
			set {
				if(_IsFloat_ApplicableUnit_RefID != value){
					_IsFloat_ApplicableUnit_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsString { 
			get {
				return _IsString;
			}
			set {
				if(_IsString != value){
					_IsString = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsVitalParameter { 
			get {
				return _IsVitalParameter;
			}
			set {
				if(_IsVitalParameter != value){
					_IsVitalParameter = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean HasHighRelevance { 
			get {
				return _HasHighRelevance;
			}
			set {
				if(_HasHighRelevance != value){
					_HasHighRelevance = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ParameterType_RefID { 
			get {
				return _ParameterType_RefID;
			}
			set {
				if(_ParameterType_RefID != value){
					_ParameterType_RefID = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || Parameter_Name.IsDirty ;
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
								loader.Append(Parameter_Name,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Parameter.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Parameter.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_Patient_ParameterID", _HEC_Patient_ParameterID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PatientParameterITL", _PatientParameterITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "GlobalPropertyMatchingID", _GlobalPropertyMatchingID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Parameter_Name", _Parameter_Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsFloat", _IsFloat);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfFloat_MinValue", _IfFloat_MinValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfFloat_MaxValue", _IfFloat_MaxValue);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsFloat_ApplicableUnit_RefID", _IsFloat_ApplicableUnit_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsString", _IsString);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsVitalParameter", _IsVitalParameter);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HasHighRelevance", _HasHighRelevance);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ParameterType_RefID", _ParameterType_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Parameter.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_Patient_ParameterID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_Patient_ParameterID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_Patient_ParameterID","PatientParameterITL","GlobalPropertyMatchingID","Parameter_Name_DictID","IsFloat","IfFloat_MinValue","IfFloat_MaxValue","IsFloat_ApplicableUnit_RefID","IsString","IsVitalParameter","HasHighRelevance","ParameterType_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_Patient_ParameterID of type Guid
						_HEC_Patient_ParameterID = reader.GetGuid(0);
						//1:Parameter PatientParameterITL of type String
						_PatientParameterITL = reader.GetString(1);
						//2:Parameter GlobalPropertyMatchingID of type String
						_GlobalPropertyMatchingID = reader.GetString(2);
						//3:Parameter Parameter_Name of type Dict
						_Parameter_Name = reader.GetDictionary(3);
						loader.Append(_Parameter_Name,TableName);
						//4:Parameter IsFloat of type Boolean
						_IsFloat = reader.GetBoolean(4);
						//5:Parameter IfFloat_MinValue of type double
						_IfFloat_MinValue = reader.GetDouble(5);
						//6:Parameter IfFloat_MaxValue of type double
						_IfFloat_MaxValue = reader.GetDouble(6);
						//7:Parameter IsFloat_ApplicableUnit_RefID of type Guid
						_IsFloat_ApplicableUnit_RefID = reader.GetGuid(7);
						//8:Parameter IsString of type Boolean
						_IsString = reader.GetBoolean(8);
						//9:Parameter IsVitalParameter of type Boolean
						_IsVitalParameter = reader.GetBoolean(9);
						//10:Parameter HasHighRelevance of type Boolean
						_HasHighRelevance = reader.GetBoolean(10);
						//11:Parameter ParameterType_RefID of type Guid
						_ParameterType_RefID = reader.GetGuid(11);
						//12:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(12);
						//13:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(13);
						//14:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(14);
						//15:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(15);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_Patient_ParameterID != Guid.Empty){
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
			public Guid? HEC_Patient_ParameterID {	get; set; }
			public String PatientParameterITL {	get; set; }
			public String GlobalPropertyMatchingID {	get; set; }
			public Dict Parameter_Name {	get; set; }
			public Boolean? IsFloat {	get; set; }
			public double? IfFloat_MinValue {	get; set; }
			public double? IfFloat_MaxValue {	get; set; }
			public Guid? IsFloat_ApplicableUnit_RefID {	get; set; }
			public Boolean? IsString {	get; set; }
			public Boolean? IsVitalParameter {	get; set; }
			public Boolean? HasHighRelevance {	get; set; }
			public Guid? ParameterType_RefID {	get; set; }
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
			public static List<ORM_HEC_Patient_Parameter> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_Patient_Parameter> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_Patient_Parameter> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_Patient_Parameter> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_Patient_Parameter> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_Patient_Parameter>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_Patient_ParameterID","PatientParameterITL","GlobalPropertyMatchingID","Parameter_Name_DictID","IsFloat","IfFloat_MinValue","IfFloat_MaxValue","IsFloat_ApplicableUnit_RefID","IsString","IsVitalParameter","HasHighRelevance","ParameterType_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_Patient_Parameter item = new ORM_HEC_Patient_Parameter();
						//0:Parameter HEC_Patient_ParameterID of type Guid
						item.HEC_Patient_ParameterID = reader.GetGuid(0);
						//1:Parameter PatientParameterITL of type String
						item.PatientParameterITL = reader.GetString(1);
						//2:Parameter GlobalPropertyMatchingID of type String
						item.GlobalPropertyMatchingID = reader.GetString(2);
						//3:Parameter Parameter_Name of type Dict
						item.Parameter_Name = reader.GetDictionary(3);
						loader.Append(item.Parameter_Name,TableName);
						//4:Parameter IsFloat of type Boolean
						item.IsFloat = reader.GetBoolean(4);
						//5:Parameter IfFloat_MinValue of type double
						item.IfFloat_MinValue = reader.GetDouble(5);
						//6:Parameter IfFloat_MaxValue of type double
						item.IfFloat_MaxValue = reader.GetDouble(6);
						//7:Parameter IsFloat_ApplicableUnit_RefID of type Guid
						item.IsFloat_ApplicableUnit_RefID = reader.GetGuid(7);
						//8:Parameter IsString of type Boolean
						item.IsString = reader.GetBoolean(8);
						//9:Parameter IsVitalParameter of type Boolean
						item.IsVitalParameter = reader.GetBoolean(9);
						//10:Parameter HasHighRelevance of type Boolean
						item.HasHighRelevance = reader.GetBoolean(10);
						//11:Parameter ParameterType_RefID of type Guid
						item.ParameterType_RefID = reader.GetGuid(11);
						//12:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(12);
						//13:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(13);
						//14:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(14);
						//15:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(15);


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
