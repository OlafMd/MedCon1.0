/* 
 * Generated on 10/20/2014 1:12:19 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_STR
{
	[Serializable]
	public class ORM_CMN_STR_Office
	{
		public static readonly string TableName = "cmn_str_offices";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_STR_Office()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_STR_OfficeID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_STR_OfficeID = default(Guid);
		private String _OfficeITL = default(String);
		private Guid _Parent_RefID = default(Guid);
		private Guid _Country_RefID = default(Guid);
		private Guid _Region_RefID = default(Guid);
		private Guid _Default_BillingAddress_RefID = default(Guid);
		private Guid _Default_ShippingAddress_RefID = default(Guid);
		private Guid _CMN_CAL_CalendarInstance_RefID = default(Guid);
		private String _Default_PhoneNumber = default(String);
		private String _Default_FaxNumber = default(String);
		private String _Default_Website = default(String);
		private String _Default_Email = default(String);
		private Dict _Office_Name = new Dict(TableName);
		private Dict _Office_Description = new Dict(TableName);
		private String _Office_ShortName = default(String);
		private Boolean _IsMockObject = default(Boolean);
		private String _Office_InternalName = default(String);
		private String _Office_InternalNumber = default(String);
		private String _Comment = default(String);
		private Guid _DisplayImage_Document_RefID = default(Guid);
		private Boolean _IsMedicalPractice = default(Boolean);
		private Guid _IfMedicalPractise_HEC_MedicalPractice_RefID = default(Guid);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_STR_OfficeID { 
			get {
				return _CMN_STR_OfficeID;
			}
			set {
				if(_CMN_STR_OfficeID != value){
					_CMN_STR_OfficeID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String OfficeITL { 
			get {
				return _OfficeITL;
			}
			set {
				if(_OfficeITL != value){
					_OfficeITL = value;
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
		public Guid Country_RefID { 
			get {
				return _Country_RefID;
			}
			set {
				if(_Country_RefID != value){
					_Country_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Region_RefID { 
			get {
				return _Region_RefID;
			}
			set {
				if(_Region_RefID != value){
					_Region_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Default_BillingAddress_RefID { 
			get {
				return _Default_BillingAddress_RefID;
			}
			set {
				if(_Default_BillingAddress_RefID != value){
					_Default_BillingAddress_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Default_ShippingAddress_RefID { 
			get {
				return _Default_ShippingAddress_RefID;
			}
			set {
				if(_Default_ShippingAddress_RefID != value){
					_Default_ShippingAddress_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CMN_CAL_CalendarInstance_RefID { 
			get {
				return _CMN_CAL_CalendarInstance_RefID;
			}
			set {
				if(_CMN_CAL_CalendarInstance_RefID != value){
					_CMN_CAL_CalendarInstance_RefID = value;
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
		public String Default_Website { 
			get {
				return _Default_Website;
			}
			set {
				if(_Default_Website != value){
					_Default_Website = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Default_Email { 
			get {
				return _Default_Email;
			}
			set {
				if(_Default_Email != value){
					_Default_Email = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Office_Name { 
			get {
				return _Office_Name;
			}
			set {
				if(_Office_Name != value){
					_Office_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Office_Description { 
			get {
				return _Office_Description;
			}
			set {
				if(_Office_Description != value){
					_Office_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Office_ShortName { 
			get {
				return _Office_ShortName;
			}
			set {
				if(_Office_ShortName != value){
					_Office_ShortName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsMockObject { 
			get {
				return _IsMockObject;
			}
			set {
				if(_IsMockObject != value){
					_IsMockObject = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Office_InternalName { 
			get {
				return _Office_InternalName;
			}
			set {
				if(_Office_InternalName != value){
					_Office_InternalName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Office_InternalNumber { 
			get {
				return _Office_InternalNumber;
			}
			set {
				if(_Office_InternalNumber != value){
					_Office_InternalNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Comment { 
			get {
				return _Comment;
			}
			set {
				if(_Comment != value){
					_Comment = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || Office_Name.IsDirty || Office_Description.IsDirty ;
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
								loader.Append(Office_Name,TableName);
								loader.Append(Office_Description,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR.CMN_STR_Office.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR.CMN_STR_Office.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_STR_OfficeID", _CMN_STR_OfficeID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OfficeITL", _OfficeITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Parent_RefID", _Parent_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Country_RefID", _Country_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Region_RefID", _Region_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_BillingAddress_RefID", _Default_BillingAddress_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_ShippingAddress_RefID", _Default_ShippingAddress_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_CAL_CalendarInstance_RefID", _CMN_CAL_CalendarInstance_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_PhoneNumber", _Default_PhoneNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_FaxNumber", _Default_FaxNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_Website", _Default_Website);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Default_Email", _Default_Email);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Office_Name", _Office_Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Office_Description", _Office_Description.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Office_ShortName", _Office_ShortName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsMockObject", _IsMockObject);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Office_InternalName", _Office_InternalName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Office_InternalNumber", _Office_InternalNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment", _Comment);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_STR.CMN_STR_Office.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_STR_OfficeID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_STR_OfficeID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_STR_OfficeID","OfficeITL","Parent_RefID","Country_RefID","Region_RefID","Default_BillingAddress_RefID","Default_ShippingAddress_RefID","CMN_CAL_CalendarInstance_RefID","Default_PhoneNumber","Default_FaxNumber","Default_Website","Default_Email","Office_Name_DictID","Office_Description_DictID","Office_ShortName","IsMockObject","Office_InternalName","Office_InternalNumber","Comment","DisplayImage_Document_RefID","IsMedicalPractice","IfMedicalPractise_HEC_MedicalPractice_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_STR_OfficeID of type Guid
						_CMN_STR_OfficeID = reader.GetGuid(0);
						//1:Parameter OfficeITL of type String
						_OfficeITL = reader.GetString(1);
						//2:Parameter Parent_RefID of type Guid
						_Parent_RefID = reader.GetGuid(2);
						//3:Parameter Country_RefID of type Guid
						_Country_RefID = reader.GetGuid(3);
						//4:Parameter Region_RefID of type Guid
						_Region_RefID = reader.GetGuid(4);
						//5:Parameter Default_BillingAddress_RefID of type Guid
						_Default_BillingAddress_RefID = reader.GetGuid(5);
						//6:Parameter Default_ShippingAddress_RefID of type Guid
						_Default_ShippingAddress_RefID = reader.GetGuid(6);
						//7:Parameter CMN_CAL_CalendarInstance_RefID of type Guid
						_CMN_CAL_CalendarInstance_RefID = reader.GetGuid(7);
						//8:Parameter Default_PhoneNumber of type String
						_Default_PhoneNumber = reader.GetString(8);
						//9:Parameter Default_FaxNumber of type String
						_Default_FaxNumber = reader.GetString(9);
						//10:Parameter Default_Website of type String
						_Default_Website = reader.GetString(10);
						//11:Parameter Default_Email of type String
						_Default_Email = reader.GetString(11);
						//12:Parameter Office_Name of type Dict
						_Office_Name = reader.GetDictionary(12);
						loader.Append(_Office_Name,TableName);
						//13:Parameter Office_Description of type Dict
						_Office_Description = reader.GetDictionary(13);
						loader.Append(_Office_Description,TableName);
						//14:Parameter Office_ShortName of type String
						_Office_ShortName = reader.GetString(14);
						//15:Parameter IsMockObject of type Boolean
						_IsMockObject = reader.GetBoolean(15);
						//16:Parameter Office_InternalName of type String
						_Office_InternalName = reader.GetString(16);
						//17:Parameter Office_InternalNumber of type String
						_Office_InternalNumber = reader.GetString(17);
						//18:Parameter Comment of type String
						_Comment = reader.GetString(18);
						//19:Parameter DisplayImage_Document_RefID of type Guid
						_DisplayImage_Document_RefID = reader.GetGuid(19);
						//20:Parameter IsMedicalPractice of type Boolean
						_IsMedicalPractice = reader.GetBoolean(20);
						//21:Parameter IfMedicalPractise_HEC_MedicalPractice_RefID of type Guid
						_IfMedicalPractise_HEC_MedicalPractice_RefID = reader.GetGuid(21);
						//22:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(22);
						//23:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(23);
						//24:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(24);
						//25:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(25);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_STR_OfficeID != Guid.Empty){
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
			public Guid? CMN_STR_OfficeID {	get; set; }
			public String OfficeITL {	get; set; }
			public Guid? Parent_RefID {	get; set; }
			public Guid? Country_RefID {	get; set; }
			public Guid? Region_RefID {	get; set; }
			public Guid? Default_BillingAddress_RefID {	get; set; }
			public Guid? Default_ShippingAddress_RefID {	get; set; }
			public Guid? CMN_CAL_CalendarInstance_RefID {	get; set; }
			public String Default_PhoneNumber {	get; set; }
			public String Default_FaxNumber {	get; set; }
			public String Default_Website {	get; set; }
			public String Default_Email {	get; set; }
			public Dict Office_Name {	get; set; }
			public Dict Office_Description {	get; set; }
			public String Office_ShortName {	get; set; }
			public Boolean? IsMockObject {	get; set; }
			public String Office_InternalName {	get; set; }
			public String Office_InternalNumber {	get; set; }
			public String Comment {	get; set; }
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
			public static List<ORM_CMN_STR_Office> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_STR_Office> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_STR_Office> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_STR_Office> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_STR_Office> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_STR_Office>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_STR_OfficeID","OfficeITL","Parent_RefID","Country_RefID","Region_RefID","Default_BillingAddress_RefID","Default_ShippingAddress_RefID","CMN_CAL_CalendarInstance_RefID","Default_PhoneNumber","Default_FaxNumber","Default_Website","Default_Email","Office_Name_DictID","Office_Description_DictID","Office_ShortName","IsMockObject","Office_InternalName","Office_InternalNumber","Comment","DisplayImage_Document_RefID","IsMedicalPractice","IfMedicalPractise_HEC_MedicalPractice_RefID","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_CMN_STR_Office item = new ORM_CMN_STR_Office();
						//0:Parameter CMN_STR_OfficeID of type Guid
						item.CMN_STR_OfficeID = reader.GetGuid(0);
						//1:Parameter OfficeITL of type String
						item.OfficeITL = reader.GetString(1);
						//2:Parameter Parent_RefID of type Guid
						item.Parent_RefID = reader.GetGuid(2);
						//3:Parameter Country_RefID of type Guid
						item.Country_RefID = reader.GetGuid(3);
						//4:Parameter Region_RefID of type Guid
						item.Region_RefID = reader.GetGuid(4);
						//5:Parameter Default_BillingAddress_RefID of type Guid
						item.Default_BillingAddress_RefID = reader.GetGuid(5);
						//6:Parameter Default_ShippingAddress_RefID of type Guid
						item.Default_ShippingAddress_RefID = reader.GetGuid(6);
						//7:Parameter CMN_CAL_CalendarInstance_RefID of type Guid
						item.CMN_CAL_CalendarInstance_RefID = reader.GetGuid(7);
						//8:Parameter Default_PhoneNumber of type String
						item.Default_PhoneNumber = reader.GetString(8);
						//9:Parameter Default_FaxNumber of type String
						item.Default_FaxNumber = reader.GetString(9);
						//10:Parameter Default_Website of type String
						item.Default_Website = reader.GetString(10);
						//11:Parameter Default_Email of type String
						item.Default_Email = reader.GetString(11);
						//12:Parameter Office_Name of type Dict
						item.Office_Name = reader.GetDictionary(12);
						loader.Append(item.Office_Name,TableName);
						//13:Parameter Office_Description of type Dict
						item.Office_Description = reader.GetDictionary(13);
						loader.Append(item.Office_Description,TableName);
						//14:Parameter Office_ShortName of type String
						item.Office_ShortName = reader.GetString(14);
						//15:Parameter IsMockObject of type Boolean
						item.IsMockObject = reader.GetBoolean(15);
						//16:Parameter Office_InternalName of type String
						item.Office_InternalName = reader.GetString(16);
						//17:Parameter Office_InternalNumber of type String
						item.Office_InternalNumber = reader.GetString(17);
						//18:Parameter Comment of type String
						item.Comment = reader.GetString(18);
						//19:Parameter DisplayImage_Document_RefID of type Guid
						item.DisplayImage_Document_RefID = reader.GetGuid(19);
						//20:Parameter IsMedicalPractice of type Boolean
						item.IsMedicalPractice = reader.GetBoolean(20);
						//21:Parameter IfMedicalPractise_HEC_MedicalPractice_RefID of type Guid
						item.IfMedicalPractise_HEC_MedicalPractice_RefID = reader.GetGuid(21);
						//22:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(22);
						//23:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(23);
						//24:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(24);
						//25:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(25);


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
