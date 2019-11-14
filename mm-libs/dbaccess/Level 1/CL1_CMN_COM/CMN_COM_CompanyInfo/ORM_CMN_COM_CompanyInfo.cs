/* 
 * Generated on 11/5/2013 2:36:28 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;

namespace CL1_CMN_COM
{
	[Serializable]
	public class ORM_CMN_COM_CompanyInfo
	{
		public static readonly string TableName = "cmn_com_companyinfo";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_COM_CompanyInfo()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_COM_CompanyInfoID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_COM_CompanyInfoID = default(Guid);
		private Guid _CompanyLogo_Document_RefID = default(Guid);
		private Guid _Contact_UCD_RefID = default(Guid);
		private Guid _CompanyType_RefID = default(Guid);
		private long _NumberOfEmployees = default(long);
		private String _CompanyInfo_EstablishmentNumber = default(String);
		private Guid _AnnualRevenueAmountValue_RefID = default(Guid);
		private String _VATIdentificationNumber = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_COM_CompanyInfoID { 
			get {
				return _CMN_COM_CompanyInfoID;
			}
			set {
				if(_CMN_COM_CompanyInfoID != value){
					_CMN_COM_CompanyInfoID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CompanyLogo_Document_RefID { 
			get {
				return _CompanyLogo_Document_RefID;
			}
			set {
				if(_CompanyLogo_Document_RefID != value){
					_CompanyLogo_Document_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Contact_UCD_RefID { 
			get {
				return _Contact_UCD_RefID;
			}
			set {
				if(_Contact_UCD_RefID != value){
					_Contact_UCD_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CompanyType_RefID { 
			get {
				return _CompanyType_RefID;
			}
			set {
				if(_CompanyType_RefID != value){
					_CompanyType_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public long NumberOfEmployees { 
			get {
				return _NumberOfEmployees;
			}
			set {
				if(_NumberOfEmployees != value){
					_NumberOfEmployees = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CompanyInfo_EstablishmentNumber { 
			get {
				return _CompanyInfo_EstablishmentNumber;
			}
			set {
				if(_CompanyInfo_EstablishmentNumber != value){
					_CompanyInfo_EstablishmentNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid AnnualRevenueAmountValue_RefID { 
			get {
				return _AnnualRevenueAmountValue_RefID;
			}
			set {
				if(_AnnualRevenueAmountValue_RefID != value){
					_AnnualRevenueAmountValue_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String VATIdentificationNumber { 
			get {
				return _VATIdentificationNumber;
			}
			set {
				if(_VATIdentificationNumber != value){
					_VATIdentificationNumber = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_COM.CMN_COM_CompanyInfo.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_COM.CMN_COM_CompanyInfo.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_COM_CompanyInfoID", _CMN_COM_CompanyInfoID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CompanyLogo_Document_RefID", _CompanyLogo_Document_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Contact_UCD_RefID", _Contact_UCD_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CompanyType_RefID", _CompanyType_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "NumberOfEmployees", _NumberOfEmployees);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CompanyInfo_EstablishmentNumber", _CompanyInfo_EstablishmentNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AnnualRevenueAmountValue_RefID", _AnnualRevenueAmountValue_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "VATIdentificationNumber", _VATIdentificationNumber);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_COM.CMN_COM_CompanyInfo.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_COM_CompanyInfoID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_COM_CompanyInfoID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_COM_CompanyInfoID","CompanyLogo_Document_RefID","Contact_UCD_RefID","CompanyType_RefID","NumberOfEmployees","CompanyInfo_EstablishmentNumber","AnnualRevenueAmountValue_RefID","VATIdentificationNumber","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_COM_CompanyInfoID of type Guid
						_CMN_COM_CompanyInfoID = reader.GetGuid(0);
						//1:Parameter CompanyLogo_Document_RefID of type Guid
						_CompanyLogo_Document_RefID = reader.GetGuid(1);
						//2:Parameter Contact_UCD_RefID of type Guid
						_Contact_UCD_RefID = reader.GetGuid(2);
						//3:Parameter CompanyType_RefID of type Guid
						_CompanyType_RefID = reader.GetGuid(3);
						//4:Parameter NumberOfEmployees of type long
						_NumberOfEmployees = reader.GetLong(4);
						//5:Parameter CompanyInfo_EstablishmentNumber of type String
						_CompanyInfo_EstablishmentNumber = reader.GetString(5);
						//6:Parameter AnnualRevenueAmountValue_RefID of type Guid
						_AnnualRevenueAmountValue_RefID = reader.GetGuid(6);
						//7:Parameter VATIdentificationNumber of type String
						_VATIdentificationNumber = reader.GetString(7);
						//8:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(8);
						//9:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(9);
						//10:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(10);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_COM_CompanyInfoID != Guid.Empty){
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
			public Guid? CMN_COM_CompanyInfoID {	get; set; }
			public Guid? CompanyLogo_Document_RefID {	get; set; }
			public Guid? Contact_UCD_RefID {	get; set; }
			public Guid? CompanyType_RefID {	get; set; }
			public long? NumberOfEmployees {	get; set; }
			public String CompanyInfo_EstablishmentNumber {	get; set; }
			public Guid? AnnualRevenueAmountValue_RefID {	get; set; }
			public String VATIdentificationNumber {	get; set; }
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
					throw;
				}
			}
			#endregion

			#region Search
			public static List<ORM_CMN_COM_CompanyInfo> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_COM_CompanyInfo> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_COM_CompanyInfo> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_COM_CompanyInfo> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_COM_CompanyInfo> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_COM_CompanyInfo>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_COM_CompanyInfoID","CompanyLogo_Document_RefID","Contact_UCD_RefID","CompanyType_RefID","NumberOfEmployees","CompanyInfo_EstablishmentNumber","AnnualRevenueAmountValue_RefID","VATIdentificationNumber","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_COM_CompanyInfo item = new ORM_CMN_COM_CompanyInfo();
						//0:Parameter CMN_COM_CompanyInfoID of type Guid
						item.CMN_COM_CompanyInfoID = reader.GetGuid(0);
						//1:Parameter CompanyLogo_Document_RefID of type Guid
						item.CompanyLogo_Document_RefID = reader.GetGuid(1);
						//2:Parameter Contact_UCD_RefID of type Guid
						item.Contact_UCD_RefID = reader.GetGuid(2);
						//3:Parameter CompanyType_RefID of type Guid
						item.CompanyType_RefID = reader.GetGuid(3);
						//4:Parameter NumberOfEmployees of type long
						item.NumberOfEmployees = reader.GetLong(4);
						//5:Parameter CompanyInfo_EstablishmentNumber of type String
						item.CompanyInfo_EstablishmentNumber = reader.GetString(5);
						//6:Parameter AnnualRevenueAmountValue_RefID of type Guid
						item.AnnualRevenueAmountValue_RefID = reader.GetGuid(6);
						//7:Parameter VATIdentificationNumber of type String
						item.VATIdentificationNumber = reader.GetString(7);
						//8:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(8);
						//9:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(9);
						//10:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(10);


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
