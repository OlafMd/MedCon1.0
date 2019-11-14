/* 
 * Generated on 6/18/2013 5:42:39 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_TMS_PRO
{
	[Serializable]
	public class ORM_TMS_PRO_Feature
	{
		public static readonly string TableName = "tms_pro_feature";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_TMS_PRO_Feature()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_TMS_PRO_FeatureID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _TMS_PRO_FeatureID = default(Guid);
		private String _IdentificationNumber = default(String);
		private Guid _DOC_Structure_Header_RefID = default(Guid);
		private Guid _Project_RefID = default(Guid);
		private Guid _Component_RefID = default(Guid);
		private Guid _Parent_RefID = default(Guid);
		private Guid _Type_RefID = default(Guid);
		private Guid _Status_RefID = default(Guid);
		private Dict _Name = new Dict(TableName);
		private Dict _Description = new Dict(TableName);
		private DateTime _Feature_Deadline = default(DateTime);
		private Boolean _IsArchived = default(Boolean);
		private Guid _CreatedByAccount_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid TMS_PRO_FeatureID { 
			get {
				return _TMS_PRO_FeatureID;
			}
			set {
				if(_TMS_PRO_FeatureID != value){
					_TMS_PRO_FeatureID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String IdentificationNumber { 
			get {
				return _IdentificationNumber;
			}
			set {
				if(_IdentificationNumber != value){
					_IdentificationNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DOC_Structure_Header_RefID { 
			get {
				return _DOC_Structure_Header_RefID;
			}
			set {
				if(_DOC_Structure_Header_RefID != value){
					_DOC_Structure_Header_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Project_RefID { 
			get {
				return _Project_RefID;
			}
			set {
				if(_Project_RefID != value){
					_Project_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Component_RefID { 
			get {
				return _Component_RefID;
			}
			set {
				if(_Component_RefID != value){
					_Component_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Parent_RefID { 
			get {
				return _Parent_RefID;
			}
			set {
				if(_Parent_RefID != value){
					_Parent_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Type_RefID { 
			get {
				return _Type_RefID;
			}
			set {
				if(_Type_RefID != value){
					_Type_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Status_RefID { 
			get {
				return _Status_RefID;
			}
			set {
				if(_Status_RefID != value){
					_Status_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Name { 
			get {
				return _Name;
			}
			set {
				if(_Name != value){
					_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Description { 
			get {
				return _Description;
			}
			set {
				if(_Description != value){
					_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Feature_Deadline { 
			get {
				return _Feature_Deadline;
			}
			set {
				if(_Feature_Deadline != value){
					_Feature_Deadline = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsArchived { 
			get {
				return _IsArchived;
			}
			set {
				if(_IsArchived != value){
					_IsArchived = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CreatedByAccount_RefID { 
			get {
				return _CreatedByAccount_RefID;
			}
			set {
				if(_CreatedByAccount_RefID != value){
					_CreatedByAccount_RefID = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || Name.IsDirty || Description.IsDirty ;
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
								loader.Append(Name,TableName);
								loader.Append(Description,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_TMS_PRO.TMS_PRO_Feature.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_TMS_PRO.TMS_PRO_Feature.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TMS_PRO_FeatureID", _TMS_PRO_FeatureID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IdentificationNumber", _IdentificationNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DOC_Structure_Header_RefID", _DOC_Structure_Header_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Project_RefID", _Project_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Component_RefID", _Component_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Parent_RefID", _Parent_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Type_RefID", _Type_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Status_RefID", _Status_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Name", _Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Description", _Description.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Feature_Deadline", _Feature_Deadline);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsArchived", _IsArchived);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CreatedByAccount_RefID", _CreatedByAccount_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_TMS_PRO.TMS_PRO_Feature.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_TMS_PRO_FeatureID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TMS_PRO_FeatureID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "TMS_PRO_FeatureID","IdentificationNumber","DOC_Structure_Header_RefID","Project_RefID","Component_RefID","Parent_RefID","Type_RefID","Status_RefID","Name_DictID","Description_DictID","Feature_Deadline","IsArchived","CreatedByAccount_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter TMS_PRO_FeatureID of type Guid
						_TMS_PRO_FeatureID = reader.GetGuid(0);
						//1:Parameter IdentificationNumber of type String
						_IdentificationNumber = reader.GetString(1);
						//2:Parameter DOC_Structure_Header_RefID of type Guid
						_DOC_Structure_Header_RefID = reader.GetGuid(2);
						//3:Parameter Project_RefID of type Guid
						_Project_RefID = reader.GetGuid(3);
						//4:Parameter Component_RefID of type Guid
						_Component_RefID = reader.GetGuid(4);
						//5:Parameter Parent_RefID of type Guid
						_Parent_RefID = reader.GetGuid(5);
						//6:Parameter Type_RefID of type Guid
						_Type_RefID = reader.GetGuid(6);
						//7:Parameter Status_RefID of type Guid
						_Status_RefID = reader.GetGuid(7);
						//8:Parameter Name of type Dict
						_Name = reader.GetDictionary(8);
						loader.Append(_Name,TableName);
						//9:Parameter Description of type Dict
						_Description = reader.GetDictionary(9);
						loader.Append(_Description,TableName);
						//10:Parameter Feature_Deadline of type DateTime
						_Feature_Deadline = reader.GetDate(10);
						//11:Parameter IsArchived of type Boolean
						_IsArchived = reader.GetBoolean(11);
						//12:Parameter CreatedByAccount_RefID of type Guid
						_CreatedByAccount_RefID = reader.GetGuid(12);
						//13:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(13);
						//14:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(14);
						//15:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(15);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_TMS_PRO_FeatureID != Guid.Empty){
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
			public Guid? TMS_PRO_FeatureID {	get; set; }
			public String IdentificationNumber {	get; set; }
			public Guid? DOC_Structure_Header_RefID {	get; set; }
			public Guid? Project_RefID {	get; set; }
			public Guid? Component_RefID {	get; set; }
			public Guid? Parent_RefID {	get; set; }
			public Guid? Type_RefID {	get; set; }
			public Guid? Status_RefID {	get; set; }
			public Dict Name {	get; set; }
			public Dict Description {	get; set; }
			public DateTime? Feature_Deadline {	get; set; }
			public Boolean? IsArchived {	get; set; }
			public Guid? CreatedByAccount_RefID {	get; set; }
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
			public static List<ORM_TMS_PRO_Feature> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_TMS_PRO_Feature> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_TMS_PRO_Feature> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_TMS_PRO_Feature> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_TMS_PRO_Feature> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_TMS_PRO_Feature>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "TMS_PRO_FeatureID","IdentificationNumber","DOC_Structure_Header_RefID","Project_RefID","Component_RefID","Parent_RefID","Type_RefID","Status_RefID","Name_DictID","Description_DictID","Feature_Deadline","IsArchived","CreatedByAccount_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_TMS_PRO_Feature item = new ORM_TMS_PRO_Feature();
						//0:Parameter TMS_PRO_FeatureID of type Guid
						item.TMS_PRO_FeatureID = reader.GetGuid(0);
						//1:Parameter IdentificationNumber of type String
						item.IdentificationNumber = reader.GetString(1);
						//2:Parameter DOC_Structure_Header_RefID of type Guid
						item.DOC_Structure_Header_RefID = reader.GetGuid(2);
						//3:Parameter Project_RefID of type Guid
						item.Project_RefID = reader.GetGuid(3);
						//4:Parameter Component_RefID of type Guid
						item.Component_RefID = reader.GetGuid(4);
						//5:Parameter Parent_RefID of type Guid
						item.Parent_RefID = reader.GetGuid(5);
						//6:Parameter Type_RefID of type Guid
						item.Type_RefID = reader.GetGuid(6);
						//7:Parameter Status_RefID of type Guid
						item.Status_RefID = reader.GetGuid(7);
						//8:Parameter Name of type Dict
						item.Name = reader.GetDictionary(8);
						loader.Append(item.Name,TableName);
						//9:Parameter Description of type Dict
						item.Description = reader.GetDictionary(9);
						loader.Append(item.Description,TableName);
						//10:Parameter Feature_Deadline of type DateTime
						item.Feature_Deadline = reader.GetDate(10);
						//11:Parameter IsArchived of type Boolean
						item.IsArchived = reader.GetBoolean(11);
						//12:Parameter CreatedByAccount_RefID of type Guid
						item.CreatedByAccount_RefID = reader.GetGuid(12);
						//13:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(13);
						//14:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(14);
						//15:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(15);


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
