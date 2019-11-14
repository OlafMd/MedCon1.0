/* 
 * Generated on 12/3/2013 4:47:13 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_CMN_PER
{
	[Serializable]
	public class ORM_CMN_PER_PersonInfo_2_Address
	{
		public static readonly string TableName = "cmn_per_personinfo_2_address";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_PER_PersonInfo_2_Address()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_AssignmentID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _AssignmentID = default(Guid);
		private String _AddressLabel = default(String);
		private Guid _CMN_Address_RefID = default(Guid);
		private Guid _CMN_PER_PersonInfo_RefID = default(Guid);
		private int _SequenceNumber = default(int);
		private Boolean _IsPrimary = default(Boolean);
		private Boolean _IsAddress_Contact = default(Boolean);
		private Boolean _IsAddress_Billing = default(Boolean);
		private Boolean _IsAddress_Shipping = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid AssignmentID { 
			get {
				return _AssignmentID;
			}
			set {
				if(_AssignmentID != value){
					_AssignmentID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String AddressLabel { 
			get {
				return _AddressLabel;
			}
			set {
				if(_AddressLabel != value){
					_AddressLabel = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_Address_RefID { 
			get {
				return _CMN_Address_RefID;
			}
			set {
				if(_CMN_Address_RefID != value){
					_CMN_Address_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_PER_PersonInfo_RefID { 
			get {
				return _CMN_PER_PersonInfo_RefID;
			}
			set {
				if(_CMN_PER_PersonInfo_RefID != value){
					_CMN_PER_PersonInfo_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int SequenceNumber { 
			get {
				return _SequenceNumber;
			}
			set {
				if(_SequenceNumber != value){
					_SequenceNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPrimary { 
			get {
				return _IsPrimary;
			}
			set {
				if(_IsPrimary != value){
					_IsPrimary = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAddress_Contact { 
			get {
				return _IsAddress_Contact;
			}
			set {
				if(_IsAddress_Contact != value){
					_IsAddress_Contact = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAddress_Billing { 
			get {
				return _IsAddress_Billing;
			}
			set {
				if(_IsAddress_Billing != value){
					_IsAddress_Billing = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAddress_Shipping { 
			get {
				return _IsAddress_Shipping;
			}
			set {
				if(_IsAddress_Shipping != value){
					_IsAddress_Shipping = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PER.CMN_PER_PersonInfo_2_Address.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PER.CMN_PER_PersonInfo_2_Address.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AssignmentID", _AssignmentID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AddressLabel", _AddressLabel);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_Address_RefID", _CMN_Address_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PER_PersonInfo_RefID", _CMN_PER_PersonInfo_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SequenceNumber", _SequenceNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPrimary", _IsPrimary);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAddress_Contact", _IsAddress_Contact);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAddress_Billing", _IsAddress_Billing);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAddress_Shipping", _IsAddress_Shipping);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);


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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PER.CMN_PER_PersonInfo_2_Address.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_AssignmentID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AssignmentID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "AssignmentID","AddressLabel","CMN_Address_RefID","CMN_PER_PersonInfo_RefID","SequenceNumber","IsPrimary","IsAddress_Contact","IsAddress_Billing","IsAddress_Shipping","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter AssignmentID of type Guid
						_AssignmentID = reader.GetGuid(0);
						//1:Parameter AddressLabel of type String
						_AddressLabel = reader.GetString(1);
						//2:Parameter CMN_Address_RefID of type Guid
						_CMN_Address_RefID = reader.GetGuid(2);
						//3:Parameter CMN_PER_PersonInfo_RefID of type Guid
						_CMN_PER_PersonInfo_RefID = reader.GetGuid(3);
						//4:Parameter SequenceNumber of type int
						_SequenceNumber = reader.GetInteger(4);
						//5:Parameter IsPrimary of type Boolean
						_IsPrimary = reader.GetBoolean(5);
						//6:Parameter IsAddress_Contact of type Boolean
						_IsAddress_Contact = reader.GetBoolean(6);
						//7:Parameter IsAddress_Billing of type Boolean
						_IsAddress_Billing = reader.GetBoolean(7);
						//8:Parameter IsAddress_Shipping of type Boolean
						_IsAddress_Shipping = reader.GetBoolean(8);
						//9:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(9);
						//10:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(10);
						//11:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(11);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_AssignmentID != Guid.Empty){
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
			public Guid? AssignmentID {	get; set; }
			public String AddressLabel {	get; set; }
			public Guid? CMN_Address_RefID {	get; set; }
			public Guid? CMN_PER_PersonInfo_RefID {	get; set; }
			public int? SequenceNumber {	get; set; }
			public Boolean? IsPrimary {	get; set; }
			public Boolean? IsAddress_Contact {	get; set; }
			public Boolean? IsAddress_Billing {	get; set; }
			public Boolean? IsAddress_Shipping {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			 

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
			public static List<ORM_CMN_PER_PersonInfo_2_Address> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_PER_PersonInfo_2_Address> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_PER_PersonInfo_2_Address> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_PER_PersonInfo_2_Address> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_PER_PersonInfo_2_Address> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_PER_PersonInfo_2_Address>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "AssignmentID","AddressLabel","CMN_Address_RefID","CMN_PER_PersonInfo_RefID","SequenceNumber","IsPrimary","IsAddress_Contact","IsAddress_Billing","IsAddress_Shipping","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_PER_PersonInfo_2_Address item = new ORM_CMN_PER_PersonInfo_2_Address();
						//0:Parameter AssignmentID of type Guid
						item.AssignmentID = reader.GetGuid(0);
						//1:Parameter AddressLabel of type String
						item.AddressLabel = reader.GetString(1);
						//2:Parameter CMN_Address_RefID of type Guid
						item.CMN_Address_RefID = reader.GetGuid(2);
						//3:Parameter CMN_PER_PersonInfo_RefID of type Guid
						item.CMN_PER_PersonInfo_RefID = reader.GetGuid(3);
						//4:Parameter SequenceNumber of type int
						item.SequenceNumber = reader.GetInteger(4);
						//5:Parameter IsPrimary of type Boolean
						item.IsPrimary = reader.GetBoolean(5);
						//6:Parameter IsAddress_Contact of type Boolean
						item.IsAddress_Contact = reader.GetBoolean(6);
						//7:Parameter IsAddress_Billing of type Boolean
						item.IsAddress_Billing = reader.GetBoolean(7);
						//8:Parameter IsAddress_Shipping of type Boolean
						item.IsAddress_Shipping = reader.GetBoolean(8);
						//9:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(9);
						//10:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(10);
						//11:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(11);


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
