/* 
 * Generated on 10/14/2014 4:11:48 PM
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
	public class ORM_HEC_MedicalPractis
	{
		public static readonly string TableName = "hec_medicalpractises";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_MedicalPractis()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_MedicalPractiseID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_MedicalPractiseID = default(Guid);
		private Guid _WeeklyOfficeHours_Template_RefID = default(Guid);
		private Guid _Ext_CompanyInfo_RefID = default(Guid);
		private Guid _AssociatedWith_PhysitianAssociation_RefID = default(Guid);
		private Guid _ContactPerson_RefID = default(Guid);
		private Guid _WeeklySurgeryHours_Template_RefID = default(Guid);
		private String _Contact_EmergencyPhoneNumber = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private Boolean _IsHospital = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_MedicalPractiseID { 
			get {
				return _HEC_MedicalPractiseID;
			}
			set {
				if(_HEC_MedicalPractiseID != value){
					_HEC_MedicalPractiseID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid WeeklyOfficeHours_Template_RefID { 
			get {
				return _WeeklyOfficeHours_Template_RefID;
			}
			set {
				if(_WeeklyOfficeHours_Template_RefID != value){
					_WeeklyOfficeHours_Template_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Ext_CompanyInfo_RefID { 
			get {
				return _Ext_CompanyInfo_RefID;
			}
			set {
				if(_Ext_CompanyInfo_RefID != value){
					_Ext_CompanyInfo_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid AssociatedWith_PhysitianAssociation_RefID { 
			get {
				return _AssociatedWith_PhysitianAssociation_RefID;
			}
			set {
				if(_AssociatedWith_PhysitianAssociation_RefID != value){
					_AssociatedWith_PhysitianAssociation_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ContactPerson_RefID { 
			get {
				return _ContactPerson_RefID;
			}
			set {
				if(_ContactPerson_RefID != value){
					_ContactPerson_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid WeeklySurgeryHours_Template_RefID { 
			get {
				return _WeeklySurgeryHours_Template_RefID;
			}
			set {
				if(_WeeklySurgeryHours_Template_RefID != value){
					_WeeklySurgeryHours_Template_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Contact_EmergencyPhoneNumber { 
			get {
				return _Contact_EmergencyPhoneNumber;
			}
			set {
				if(_Contact_EmergencyPhoneNumber != value){
					_Contact_EmergencyPhoneNumber = value;
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
		public Boolean IsHospital { 
			get {
				return _IsHospital;
			}
			set {
				if(_IsHospital != value){
					_IsHospital = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_MedicalPractis.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_MedicalPractis.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_MedicalPractiseID", _HEC_MedicalPractiseID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WeeklyOfficeHours_Template_RefID", _WeeklyOfficeHours_Template_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Ext_CompanyInfo_RefID", _Ext_CompanyInfo_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AssociatedWith_PhysitianAssociation_RefID", _AssociatedWith_PhysitianAssociation_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ContactPerson_RefID", _ContactPerson_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WeeklySurgeryHours_Template_RefID", _WeeklySurgeryHours_Template_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Contact_EmergencyPhoneNumber", _Contact_EmergencyPhoneNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsHospital", _IsHospital);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_MedicalPractis.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_MedicalPractiseID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_MedicalPractiseID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_MedicalPractiseID","WeeklyOfficeHours_Template_RefID","Ext_CompanyInfo_RefID","AssociatedWith_PhysitianAssociation_RefID","ContactPerson_RefID","WeeklySurgeryHours_Template_RefID","Contact_EmergencyPhoneNumber","Creation_Timestamp","Tenant_RefID","IsDeleted","IsHospital","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_MedicalPractiseID of type Guid
						_HEC_MedicalPractiseID = reader.GetGuid(0);
						//1:Parameter WeeklyOfficeHours_Template_RefID of type Guid
						_WeeklyOfficeHours_Template_RefID = reader.GetGuid(1);
						//2:Parameter Ext_CompanyInfo_RefID of type Guid
						_Ext_CompanyInfo_RefID = reader.GetGuid(2);
						//3:Parameter AssociatedWith_PhysitianAssociation_RefID of type Guid
						_AssociatedWith_PhysitianAssociation_RefID = reader.GetGuid(3);
						//4:Parameter ContactPerson_RefID of type Guid
						_ContactPerson_RefID = reader.GetGuid(4);
						//5:Parameter WeeklySurgeryHours_Template_RefID of type Guid
						_WeeklySurgeryHours_Template_RefID = reader.GetGuid(5);
						//6:Parameter Contact_EmergencyPhoneNumber of type String
						_Contact_EmergencyPhoneNumber = reader.GetString(6);
						//7:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(7);
						//8:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(8);
						//9:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(9);
						//10:Parameter IsHospital of type Boolean
						_IsHospital = reader.GetBoolean(10);
						//11:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(11);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_MedicalPractiseID != Guid.Empty){
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
			public Guid? HEC_MedicalPractiseID {	get; set; }
			public Guid? WeeklyOfficeHours_Template_RefID {	get; set; }
			public Guid? Ext_CompanyInfo_RefID {	get; set; }
			public Guid? AssociatedWith_PhysitianAssociation_RefID {	get; set; }
			public Guid? ContactPerson_RefID {	get; set; }
			public Guid? WeeklySurgeryHours_Template_RefID {	get; set; }
			public String Contact_EmergencyPhoneNumber {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			public Boolean? IsHospital {	get; set; }
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
			public static List<ORM_HEC_MedicalPractis> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_MedicalPractis> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_MedicalPractis> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_MedicalPractis> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_MedicalPractis> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_MedicalPractis>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_MedicalPractiseID","WeeklyOfficeHours_Template_RefID","Ext_CompanyInfo_RefID","AssociatedWith_PhysitianAssociation_RefID","ContactPerson_RefID","WeeklySurgeryHours_Template_RefID","Contact_EmergencyPhoneNumber","Creation_Timestamp","Tenant_RefID","IsDeleted","IsHospital","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_MedicalPractis item = new ORM_HEC_MedicalPractis();
						//0:Parameter HEC_MedicalPractiseID of type Guid
						item.HEC_MedicalPractiseID = reader.GetGuid(0);
						//1:Parameter WeeklyOfficeHours_Template_RefID of type Guid
						item.WeeklyOfficeHours_Template_RefID = reader.GetGuid(1);
						//2:Parameter Ext_CompanyInfo_RefID of type Guid
						item.Ext_CompanyInfo_RefID = reader.GetGuid(2);
						//3:Parameter AssociatedWith_PhysitianAssociation_RefID of type Guid
						item.AssociatedWith_PhysitianAssociation_RefID = reader.GetGuid(3);
						//4:Parameter ContactPerson_RefID of type Guid
						item.ContactPerson_RefID = reader.GetGuid(4);
						//5:Parameter WeeklySurgeryHours_Template_RefID of type Guid
						item.WeeklySurgeryHours_Template_RefID = reader.GetGuid(5);
						//6:Parameter Contact_EmergencyPhoneNumber of type String
						item.Contact_EmergencyPhoneNumber = reader.GetString(6);
						//7:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(7);
						//8:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(8);
						//9:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(9);
						//10:Parameter IsHospital of type Boolean
						item.IsHospital = reader.GetBoolean(10);
						//11:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(11);


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
