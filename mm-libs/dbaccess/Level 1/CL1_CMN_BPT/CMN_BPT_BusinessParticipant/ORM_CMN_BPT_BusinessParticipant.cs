/* 
 * Generated on 1/20/2015 3:15:50 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_BPT
{
	[Serializable]
	public class ORM_CMN_BPT_BusinessParticipant
	{
		public static readonly string TableName = "cmn_bpt_businessparticipants";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_BusinessParticipant()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_BusinessParticipantID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_BusinessParticipantID = default(Guid);
		private String _BusinessParticipantITL = default(String);
		private String _ImportedFromSource = default(String);
		private String _DisplayName = default(String);
		private Boolean _IsNaturalPerson = default(Boolean);
		private Boolean _IsCompany = default(Boolean);
		private Guid _IfNaturalPerson_CMN_PER_PersonInfo_RefID = default(Guid);
		private Guid _IfCompany_CMN_COM_CompanyInfo_RefID = default(Guid);
		private Boolean _IsTenant = default(Boolean);
		private Guid _IfTenant_Tenant_RefID = default(Guid);
		private Guid _DisplayImage_RefID = default(Guid);
		private Guid _DefaultLanguage_RefID = default(Guid);
		private Guid _DefaultCurrency_RefID = default(Guid);
		private DateTime _LastContacted_Date = default(DateTime);
		private Guid _LastContacted_ByBusinessPartner_RefID = default(Guid);
		private Guid _Audit_UpdatedByAccount_RefID = default(Guid);
		private Guid _Audit_CreatedByAccount_RefID = default(Guid);
		private DateTime _Audit_UpdatedOn = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_BusinessParticipantID { 
			get {
				return _CMN_BPT_BusinessParticipantID;
			}
			set {
				if(_CMN_BPT_BusinessParticipantID != value){
					_CMN_BPT_BusinessParticipantID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String BusinessParticipantITL { 
			get {
				return _BusinessParticipantITL;
			}
			set {
				if(_BusinessParticipantITL != value){
					_BusinessParticipantITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ImportedFromSource { 
			get {
				return _ImportedFromSource;
			}
			set {
				if(_ImportedFromSource != value){
					_ImportedFromSource = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String DisplayName { 
			get {
				return _DisplayName;
			}
			set {
				if(_DisplayName != value){
					_DisplayName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsNaturalPerson { 
			get {
				return _IsNaturalPerson;
			}
			set {
				if(_IsNaturalPerson != value){
					_IsNaturalPerson = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCompany { 
			get {
				return _IsCompany;
			}
			set {
				if(_IsCompany != value){
					_IsCompany = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfNaturalPerson_CMN_PER_PersonInfo_RefID { 
			get {
				return _IfNaturalPerson_CMN_PER_PersonInfo_RefID;
			}
			set {
				if(_IfNaturalPerson_CMN_PER_PersonInfo_RefID != value){
					_IfNaturalPerson_CMN_PER_PersonInfo_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfCompany_CMN_COM_CompanyInfo_RefID { 
			get {
				return _IfCompany_CMN_COM_CompanyInfo_RefID;
			}
			set {
				if(_IfCompany_CMN_COM_CompanyInfo_RefID != value){
					_IfCompany_CMN_COM_CompanyInfo_RefID = value;
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
		public Guid IfTenant_Tenant_RefID { 
			get {
				return _IfTenant_Tenant_RefID;
			}
			set {
				if(_IfTenant_Tenant_RefID != value){
					_IfTenant_Tenant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DisplayImage_RefID { 
			get {
				return _DisplayImage_RefID;
			}
			set {
				if(_DisplayImage_RefID != value){
					_DisplayImage_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DefaultLanguage_RefID { 
			get {
				return _DefaultLanguage_RefID;
			}
			set {
				if(_DefaultLanguage_RefID != value){
					_DefaultLanguage_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid DefaultCurrency_RefID { 
			get {
				return _DefaultCurrency_RefID;
			}
			set {
				if(_DefaultCurrency_RefID != value){
					_DefaultCurrency_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime LastContacted_Date { 
			get {
				return _LastContacted_Date;
			}
			set {
				if(_LastContacted_Date != value){
					_LastContacted_Date = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid LastContacted_ByBusinessPartner_RefID { 
			get {
				return _LastContacted_ByBusinessPartner_RefID;
			}
			set {
				if(_LastContacted_ByBusinessPartner_RefID != value){
					_LastContacted_ByBusinessPartner_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Audit_UpdatedByAccount_RefID { 
			get {
				return _Audit_UpdatedByAccount_RefID;
			}
			set {
				if(_Audit_UpdatedByAccount_RefID != value){
					_Audit_UpdatedByAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Audit_CreatedByAccount_RefID { 
			get {
				return _Audit_CreatedByAccount_RefID;
			}
			set {
				if(_Audit_CreatedByAccount_RefID != value){
					_Audit_CreatedByAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Audit_UpdatedOn { 
			get {
				return _Audit_UpdatedOn;
			}
			set {
				if(_Audit_UpdatedOn != value){
					_Audit_UpdatedOn = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT.CMN_BPT_BusinessParticipant.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT.CMN_BPT_BusinessParticipant.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_BusinessParticipantID", _CMN_BPT_BusinessParticipantID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BusinessParticipantITL", _BusinessParticipantITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ImportedFromSource", _ImportedFromSource);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DisplayName", _DisplayName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsNaturalPerson", _IsNaturalPerson);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCompany", _IsCompany);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfNaturalPerson_CMN_PER_PersonInfo_RefID", _IfNaturalPerson_CMN_PER_PersonInfo_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfCompany_CMN_COM_CompanyInfo_RefID", _IfCompany_CMN_COM_CompanyInfo_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsTenant", _IsTenant);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfTenant_Tenant_RefID", _IfTenant_Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DisplayImage_RefID", _DisplayImage_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DefaultLanguage_RefID", _DefaultLanguage_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DefaultCurrency_RefID", _DefaultCurrency_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LastContacted_Date", _LastContacted_Date);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LastContacted_ByBusinessPartner_RefID", _LastContacted_ByBusinessPartner_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Audit_UpdatedByAccount_RefID", _Audit_UpdatedByAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Audit_CreatedByAccount_RefID", _Audit_CreatedByAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Audit_UpdatedOn", _Audit_UpdatedOn);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT.CMN_BPT_BusinessParticipant.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_BusinessParticipantID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_BusinessParticipantID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_BusinessParticipantID","BusinessParticipantITL","ImportedFromSource","DisplayName","IsNaturalPerson","IsCompany","IfNaturalPerson_CMN_PER_PersonInfo_RefID","IfCompany_CMN_COM_CompanyInfo_RefID","IsTenant","IfTenant_Tenant_RefID","DisplayImage_RefID","DefaultLanguage_RefID","DefaultCurrency_RefID","LastContacted_Date","LastContacted_ByBusinessPartner_RefID","Audit_UpdatedByAccount_RefID","Audit_CreatedByAccount_RefID","Audit_UpdatedOn","IsDeleted","Tenant_RefID","Creation_Timestamp","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_BusinessParticipantID of type Guid
						_CMN_BPT_BusinessParticipantID = reader.GetGuid(0);
						//1:Parameter BusinessParticipantITL of type String
						_BusinessParticipantITL = reader.GetString(1);
						//2:Parameter ImportedFromSource of type String
						_ImportedFromSource = reader.GetString(2);
						//3:Parameter DisplayName of type String
						_DisplayName = reader.GetString(3);
						//4:Parameter IsNaturalPerson of type Boolean
						_IsNaturalPerson = reader.GetBoolean(4);
						//5:Parameter IsCompany of type Boolean
						_IsCompany = reader.GetBoolean(5);
						//6:Parameter IfNaturalPerson_CMN_PER_PersonInfo_RefID of type Guid
						_IfNaturalPerson_CMN_PER_PersonInfo_RefID = reader.GetGuid(6);
						//7:Parameter IfCompany_CMN_COM_CompanyInfo_RefID of type Guid
						_IfCompany_CMN_COM_CompanyInfo_RefID = reader.GetGuid(7);
						//8:Parameter IsTenant of type Boolean
						_IsTenant = reader.GetBoolean(8);
						//9:Parameter IfTenant_Tenant_RefID of type Guid
						_IfTenant_Tenant_RefID = reader.GetGuid(9);
						//10:Parameter DisplayImage_RefID of type Guid
						_DisplayImage_RefID = reader.GetGuid(10);
						//11:Parameter DefaultLanguage_RefID of type Guid
						_DefaultLanguage_RefID = reader.GetGuid(11);
						//12:Parameter DefaultCurrency_RefID of type Guid
						_DefaultCurrency_RefID = reader.GetGuid(12);
						//13:Parameter LastContacted_Date of type DateTime
						_LastContacted_Date = reader.GetDate(13);
						//14:Parameter LastContacted_ByBusinessPartner_RefID of type Guid
						_LastContacted_ByBusinessPartner_RefID = reader.GetGuid(14);
						//15:Parameter Audit_UpdatedByAccount_RefID of type Guid
						_Audit_UpdatedByAccount_RefID = reader.GetGuid(15);
						//16:Parameter Audit_CreatedByAccount_RefID of type Guid
						_Audit_CreatedByAccount_RefID = reader.GetGuid(16);
						//17:Parameter Audit_UpdatedOn of type DateTime
						_Audit_UpdatedOn = reader.GetDate(17);
						//18:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(18);
						//19:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(19);
						//20:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(20);
						//21:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(21);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_BusinessParticipantID != Guid.Empty){
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
			public Guid? CMN_BPT_BusinessParticipantID {	get; set; }
			public String BusinessParticipantITL {	get; set; }
			public String ImportedFromSource {	get; set; }
			public String DisplayName {	get; set; }
			public Boolean? IsNaturalPerson {	get; set; }
			public Boolean? IsCompany {	get; set; }
			public Guid? IfNaturalPerson_CMN_PER_PersonInfo_RefID {	get; set; }
			public Guid? IfCompany_CMN_COM_CompanyInfo_RefID {	get; set; }
			public Boolean? IsTenant {	get; set; }
			public Guid? IfTenant_Tenant_RefID {	get; set; }
			public Guid? DisplayImage_RefID {	get; set; }
			public Guid? DefaultLanguage_RefID {	get; set; }
			public Guid? DefaultCurrency_RefID {	get; set; }
			public DateTime? LastContacted_Date {	get; set; }
			public Guid? LastContacted_ByBusinessPartner_RefID {	get; set; }
			public Guid? Audit_UpdatedByAccount_RefID {	get; set; }
			public Guid? Audit_CreatedByAccount_RefID {	get; set; }
			public DateTime? Audit_UpdatedOn {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
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
			public static List<ORM_CMN_BPT_BusinessParticipant> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_BusinessParticipant> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_BusinessParticipant> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_BusinessParticipant> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_BusinessParticipant> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_BusinessParticipant>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_BusinessParticipantID","BusinessParticipantITL","ImportedFromSource","DisplayName","IsNaturalPerson","IsCompany","IfNaturalPerson_CMN_PER_PersonInfo_RefID","IfCompany_CMN_COM_CompanyInfo_RefID","IsTenant","IfTenant_Tenant_RefID","DisplayImage_RefID","DefaultLanguage_RefID","DefaultCurrency_RefID","LastContacted_Date","LastContacted_ByBusinessPartner_RefID","Audit_UpdatedByAccount_RefID","Audit_CreatedByAccount_RefID","Audit_UpdatedOn","IsDeleted","Tenant_RefID","Creation_Timestamp","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_BusinessParticipant item = new ORM_CMN_BPT_BusinessParticipant();
						//0:Parameter CMN_BPT_BusinessParticipantID of type Guid
						item.CMN_BPT_BusinessParticipantID = reader.GetGuid(0);
						//1:Parameter BusinessParticipantITL of type String
						item.BusinessParticipantITL = reader.GetString(1);
						//2:Parameter ImportedFromSource of type String
						item.ImportedFromSource = reader.GetString(2);
						//3:Parameter DisplayName of type String
						item.DisplayName = reader.GetString(3);
						//4:Parameter IsNaturalPerson of type Boolean
						item.IsNaturalPerson = reader.GetBoolean(4);
						//5:Parameter IsCompany of type Boolean
						item.IsCompany = reader.GetBoolean(5);
						//6:Parameter IfNaturalPerson_CMN_PER_PersonInfo_RefID of type Guid
						item.IfNaturalPerson_CMN_PER_PersonInfo_RefID = reader.GetGuid(6);
						//7:Parameter IfCompany_CMN_COM_CompanyInfo_RefID of type Guid
						item.IfCompany_CMN_COM_CompanyInfo_RefID = reader.GetGuid(7);
						//8:Parameter IsTenant of type Boolean
						item.IsTenant = reader.GetBoolean(8);
						//9:Parameter IfTenant_Tenant_RefID of type Guid
						item.IfTenant_Tenant_RefID = reader.GetGuid(9);
						//10:Parameter DisplayImage_RefID of type Guid
						item.DisplayImage_RefID = reader.GetGuid(10);
						//11:Parameter DefaultLanguage_RefID of type Guid
						item.DefaultLanguage_RefID = reader.GetGuid(11);
						//12:Parameter DefaultCurrency_RefID of type Guid
						item.DefaultCurrency_RefID = reader.GetGuid(12);
						//13:Parameter LastContacted_Date of type DateTime
						item.LastContacted_Date = reader.GetDate(13);
						//14:Parameter LastContacted_ByBusinessPartner_RefID of type Guid
						item.LastContacted_ByBusinessPartner_RefID = reader.GetGuid(14);
						//15:Parameter Audit_UpdatedByAccount_RefID of type Guid
						item.Audit_UpdatedByAccount_RefID = reader.GetGuid(15);
						//16:Parameter Audit_CreatedByAccount_RefID of type Guid
						item.Audit_CreatedByAccount_RefID = reader.GetGuid(16);
						//17:Parameter Audit_UpdatedOn of type DateTime
						item.Audit_UpdatedOn = reader.GetDate(17);
						//18:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(18);
						//19:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(19);
						//20:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(20);
						//21:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(21);


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
