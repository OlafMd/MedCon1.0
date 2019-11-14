/* 
 * Generated on 10/21/2014 3:17:56 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_BPT_CTM
{
	[Serializable]
	public class ORM_CMN_BPT_CTM_OrganizationalUnit
	{
		public static readonly string TableName = "cmn_bpt_ctm_organizationalunits";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_CTM_OrganizationalUnit()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_CTM_OrganizationalUnitID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_CTM_OrganizationalUnitID = default(Guid);
		private String _CustomerTenant_OfficeITL = default(String);
		private String _InternalOrganizationalUnitNumber = default(String);
		private String _InternalOrganizationalUnitSimpleName = default(String);
		private String _ExternalOrganizationalUnitNumber = default(String);
		private Guid _Customer_RefID = default(Guid);
		private Guid _Parent_OrganizationalUnit_RefID = default(Guid);
		private String _OrganizationalUnit_SimpleName = default(String);
		private Dict _OrganizationalUnit_Name = new Dict(TableName);
		private Dict _OrganizationalUnit_Description = new Dict(TableName);
		private String _Default_PhoneNumber = default(String);
		private String _Default_FaxNumber = default(String);
		private Guid _DisplayImage_Document_RefID = default(Guid);
		private Boolean _IsMedicalPractice = default(Boolean);
		private Guid _IfMedicalPractise_HEC_MedicalPractice_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_CTM_OrganizationalUnitID { 
			get {
				return _CMN_BPT_CTM_OrganizationalUnitID;
			}
			set {
				if(_CMN_BPT_CTM_OrganizationalUnitID != value){
					_CMN_BPT_CTM_OrganizationalUnitID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CustomerTenant_OfficeITL { 
			get {
				return _CustomerTenant_OfficeITL;
			}
			set {
				if(_CustomerTenant_OfficeITL != value){
					_CustomerTenant_OfficeITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String InternalOrganizationalUnitNumber { 
			get {
				return _InternalOrganizationalUnitNumber;
			}
			set {
				if(_InternalOrganizationalUnitNumber != value){
					_InternalOrganizationalUnitNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String InternalOrganizationalUnitSimpleName { 
			get {
				return _InternalOrganizationalUnitSimpleName;
			}
			set {
				if(_InternalOrganizationalUnitSimpleName != value){
					_InternalOrganizationalUnitSimpleName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ExternalOrganizationalUnitNumber { 
			get {
				return _ExternalOrganizationalUnitNumber;
			}
			set {
				if(_ExternalOrganizationalUnitNumber != value){
					_ExternalOrganizationalUnitNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Customer_RefID { 
			get {
				return _Customer_RefID;
			}
			set {
				if(_Customer_RefID != value){
					_Customer_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Parent_OrganizationalUnit_RefID { 
			get {
				return _Parent_OrganizationalUnit_RefID;
			}
			set {
				if(_Parent_OrganizationalUnit_RefID != value){
					_Parent_OrganizationalUnit_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String OrganizationalUnit_SimpleName { 
			get {
				return _OrganizationalUnit_SimpleName;
			}
			set {
				if(_OrganizationalUnit_SimpleName != value){
					_OrganizationalUnit_SimpleName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict OrganizationalUnit_Name { 
			get {
				return _OrganizationalUnit_Name;
			}
			set {
				if(_OrganizationalUnit_Name != value){
					_OrganizationalUnit_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict OrganizationalUnit_Description { 
			get {
				return _OrganizationalUnit_Description;
			}
			set {
				if(_OrganizationalUnit_Description != value){
					_OrganizationalUnit_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Default_PhoneNumber { 
			get {
				return _Default_PhoneNumber;
			}
			set {
				if(_Default_PhoneNumber != value){
					_Default_PhoneNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Default_FaxNumber { 
			get {
				return _Default_FaxNumber;
			}
			set {
				if(_Default_FaxNumber != value){
					_Default_FaxNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DisplayImage_Document_RefID { 
			get {
				return _DisplayImage_Document_RefID;
			}
			set {
				if(_DisplayImage_Document_RefID != value){
					_DisplayImage_Document_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsMedicalPractice { 
			get {
				return _IsMedicalPractice;
			}
			set {
				if(_IsMedicalPractice != value){
					_IsMedicalPractice = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfMedicalPractise_HEC_MedicalPractice_RefID { 
			get {
				return _IfMedicalPractise_HEC_MedicalPractice_RefID;
			}
			set {
				if(_IfMedicalPractise_HEC_MedicalPractice_RefID != value){
					_IfMedicalPractise_HEC_MedicalPractice_RefID = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || OrganizationalUnit_Name.IsDirty || OrganizationalUnit_Description.IsDirty ;
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
								loader.Append(OrganizationalUnit_Name,TableName);
								loader.Append(OrganizationalUnit_Description,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_CTM.CMN_BPT_CTM_OrganizationalUnit.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_CTM.CMN_BPT_CTM_OrganizationalUnit.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_CTM_OrganizationalUnitID", _CMN_BPT_CTM_OrganizationalUnitID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CustomerTenant_OfficeITL", _CustomerTenant_OfficeITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InternalOrganizationalUnitNumber", _InternalOrganizationalUnitNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InternalOrganizationalUnitSimpleName", _InternalOrganizationalUnitSimpleName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ExternalOrganizationalUnitNumber", _ExternalOrganizationalUnitNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Customer_RefID", _Customer_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Parent_OrganizationalUnit_RefID", _Parent_OrganizationalUnit_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OrganizationalUnit_SimpleName", _OrganizationalUnit_SimpleName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OrganizationalUnit_Name", _OrganizationalUnit_Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OrganizationalUnit_Description", _OrganizationalUnit_Description.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_PhoneNumber", _Default_PhoneNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_FaxNumber", _Default_FaxNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DisplayImage_Document_RefID", _DisplayImage_Document_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsMedicalPractice", _IsMedicalPractice);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfMedicalPractise_HEC_MedicalPractice_RefID", _IfMedicalPractise_HEC_MedicalPractice_RefID);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_CTM.CMN_BPT_CTM_OrganizationalUnit.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_CTM_OrganizationalUnitID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_CTM_OrganizationalUnitID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_CTM_OrganizationalUnitID","CustomerTenant_OfficeITL","InternalOrganizationalUnitNumber","InternalOrganizationalUnitSimpleName","ExternalOrganizationalUnitNumber","Customer_RefID","Parent_OrganizationalUnit_RefID","OrganizationalUnit_SimpleName","OrganizationalUnit_Name_DictID","OrganizationalUnit_Description_DictID","Default_PhoneNumber","Default_FaxNumber","DisplayImage_Document_RefID","IsMedicalPractice","IfMedicalPractise_HEC_MedicalPractice_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_CTM_OrganizationalUnitID of type Guid
						_CMN_BPT_CTM_OrganizationalUnitID = reader.GetGuid(0);
						//1:Parameter CustomerTenant_OfficeITL of type String
						_CustomerTenant_OfficeITL = reader.GetString(1);
						//2:Parameter InternalOrganizationalUnitNumber of type String
						_InternalOrganizationalUnitNumber = reader.GetString(2);
						//3:Parameter InternalOrganizationalUnitSimpleName of type String
						_InternalOrganizationalUnitSimpleName = reader.GetString(3);
						//4:Parameter ExternalOrganizationalUnitNumber of type String
						_ExternalOrganizationalUnitNumber = reader.GetString(4);
						//5:Parameter Customer_RefID of type Guid
						_Customer_RefID = reader.GetGuid(5);
						//6:Parameter Parent_OrganizationalUnit_RefID of type Guid
						_Parent_OrganizationalUnit_RefID = reader.GetGuid(6);
						//7:Parameter OrganizationalUnit_SimpleName of type String
						_OrganizationalUnit_SimpleName = reader.GetString(7);
						//8:Parameter OrganizationalUnit_Name of type Dict
						_OrganizationalUnit_Name = reader.GetDictionary(8);
						loader.Append(_OrganizationalUnit_Name,TableName);
						//9:Parameter OrganizationalUnit_Description of type Dict
						_OrganizationalUnit_Description = reader.GetDictionary(9);
						loader.Append(_OrganizationalUnit_Description,TableName);
						//10:Parameter Default_PhoneNumber of type String
						_Default_PhoneNumber = reader.GetString(10);
						//11:Parameter Default_FaxNumber of type String
						_Default_FaxNumber = reader.GetString(11);
						//12:Parameter DisplayImage_Document_RefID of type Guid
						_DisplayImage_Document_RefID = reader.GetGuid(12);
						//13:Parameter IsMedicalPractice of type Boolean
						_IsMedicalPractice = reader.GetBoolean(13);
						//14:Parameter IfMedicalPractise_HEC_MedicalPractice_RefID of type Guid
						_IfMedicalPractise_HEC_MedicalPractice_RefID = reader.GetGuid(14);
						//15:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(15);
						//16:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(16);
						//17:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(17);
						//18:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(18);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_CTM_OrganizationalUnitID != Guid.Empty){
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
			public Guid? CMN_BPT_CTM_OrganizationalUnitID {	get; set; }
			public String CustomerTenant_OfficeITL {	get; set; }
			public String InternalOrganizationalUnitNumber {	get; set; }
			public String InternalOrganizationalUnitSimpleName {	get; set; }
			public String ExternalOrganizationalUnitNumber {	get; set; }
			public Guid? Customer_RefID {	get; set; }
			public Guid? Parent_OrganizationalUnit_RefID {	get; set; }
			public String OrganizationalUnit_SimpleName {	get; set; }
			public Dict OrganizationalUnit_Name {	get; set; }
			public Dict OrganizationalUnit_Description {	get; set; }
			public String Default_PhoneNumber {	get; set; }
			public String Default_FaxNumber {	get; set; }
			public Guid? DisplayImage_Document_RefID {	get; set; }
			public Boolean? IsMedicalPractice {	get; set; }
			public Guid? IfMedicalPractise_HEC_MedicalPractice_RefID {	get; set; }
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
			public static List<ORM_CMN_BPT_CTM_OrganizationalUnit> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_CTM_OrganizationalUnit> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_CTM_OrganizationalUnit> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_CTM_OrganizationalUnit> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_CTM_OrganizationalUnit> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_CTM_OrganizationalUnit>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_CTM_OrganizationalUnitID","CustomerTenant_OfficeITL","InternalOrganizationalUnitNumber","InternalOrganizationalUnitSimpleName","ExternalOrganizationalUnitNumber","Customer_RefID","Parent_OrganizationalUnit_RefID","OrganizationalUnit_SimpleName","OrganizationalUnit_Name_DictID","OrganizationalUnit_Description_DictID","Default_PhoneNumber","Default_FaxNumber","DisplayImage_Document_RefID","IsMedicalPractice","IfMedicalPractise_HEC_MedicalPractice_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_CTM_OrganizationalUnit item = new ORM_CMN_BPT_CTM_OrganizationalUnit();
						//0:Parameter CMN_BPT_CTM_OrganizationalUnitID of type Guid
						item.CMN_BPT_CTM_OrganizationalUnitID = reader.GetGuid(0);
						//1:Parameter CustomerTenant_OfficeITL of type String
						item.CustomerTenant_OfficeITL = reader.GetString(1);
						//2:Parameter InternalOrganizationalUnitNumber of type String
						item.InternalOrganizationalUnitNumber = reader.GetString(2);
						//3:Parameter InternalOrganizationalUnitSimpleName of type String
						item.InternalOrganizationalUnitSimpleName = reader.GetString(3);
						//4:Parameter ExternalOrganizationalUnitNumber of type String
						item.ExternalOrganizationalUnitNumber = reader.GetString(4);
						//5:Parameter Customer_RefID of type Guid
						item.Customer_RefID = reader.GetGuid(5);
						//6:Parameter Parent_OrganizationalUnit_RefID of type Guid
						item.Parent_OrganizationalUnit_RefID = reader.GetGuid(6);
						//7:Parameter OrganizationalUnit_SimpleName of type String
						item.OrganizationalUnit_SimpleName = reader.GetString(7);
						//8:Parameter OrganizationalUnit_Name of type Dict
						item.OrganizationalUnit_Name = reader.GetDictionary(8);
						loader.Append(item.OrganizationalUnit_Name,TableName);
						//9:Parameter OrganizationalUnit_Description of type Dict
						item.OrganizationalUnit_Description = reader.GetDictionary(9);
						loader.Append(item.OrganizationalUnit_Description,TableName);
						//10:Parameter Default_PhoneNumber of type String
						item.Default_PhoneNumber = reader.GetString(10);
						//11:Parameter Default_FaxNumber of type String
						item.Default_FaxNumber = reader.GetString(11);
						//12:Parameter DisplayImage_Document_RefID of type Guid
						item.DisplayImage_Document_RefID = reader.GetGuid(12);
						//13:Parameter IsMedicalPractice of type Boolean
						item.IsMedicalPractice = reader.GetBoolean(13);
						//14:Parameter IfMedicalPractise_HEC_MedicalPractice_RefID of type Guid
						item.IfMedicalPractise_HEC_MedicalPractice_RefID = reader.GetGuid(14);
						//15:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(15);
						//16:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(16);
						//17:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(17);
						//18:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(18);


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
