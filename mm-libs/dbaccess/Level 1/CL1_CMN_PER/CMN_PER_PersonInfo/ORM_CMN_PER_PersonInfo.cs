/* 
 * Generated on 11/3/2014 2:13:04 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_PER
{
	[Serializable]
	public class ORM_CMN_PER_PersonInfo
	{
		public static readonly string TableName = "cmn_per_personinfo";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_PER_PersonInfo()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_PER_PersonInfoID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_PER_PersonInfoID = default(Guid);
		private Guid _Address_RefID = default(Guid);
		private String _Title = default(String);
		private String _Salutation_General = default(String);
		private String _Salutation_Letter = default(String);
		private String _Initials = default(String);
		private String _FirstName = default(String);
		private String _LastName = default(String);
		private String _PrimaryEmail = default(String);
		private Guid _ProfileImage_Document_RefID = default(Guid);
		private DateTime _BirthDate = default(DateTime);
		private int _Gender = default(int);
		private int _NumberOfChildren = default(int);
		private Boolean _IsRepresentedByLegalGuardian = default(Boolean);
		private Boolean _IsDead = default(Boolean);
		private DateTime _DateOfDeath = default(DateTime);
		private int _AgeCalculation_YearOfBirth = default(int);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_PER_PersonInfoID { 
			get {
				return _CMN_PER_PersonInfoID;
			}
			set {
				if(_CMN_PER_PersonInfoID != value){
					_CMN_PER_PersonInfoID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Address_RefID { 
			get {
				return _Address_RefID;
			}
			set {
				if(_Address_RefID != value){
					_Address_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Title { 
			get {
				return _Title;
			}
			set {
				if(_Title != value){
					_Title = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Salutation_General { 
			get {
				return _Salutation_General;
			}
			set {
				if(_Salutation_General != value){
					_Salutation_General = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Salutation_Letter { 
			get {
				return _Salutation_Letter;
			}
			set {
				if(_Salutation_Letter != value){
					_Salutation_Letter = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Initials { 
			get {
				return _Initials;
			}
			set {
				if(_Initials != value){
					_Initials = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String FirstName { 
			get {
				return _FirstName;
			}
			set {
				if(_FirstName != value){
					_FirstName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String LastName { 
			get {
				return _LastName;
			}
			set {
				if(_LastName != value){
					_LastName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String PrimaryEmail { 
			get {
				return _PrimaryEmail;
			}
			set {
				if(_PrimaryEmail != value){
					_PrimaryEmail = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ProfileImage_Document_RefID { 
			get {
				return _ProfileImage_Document_RefID;
			}
			set {
				if(_ProfileImage_Document_RefID != value){
					_ProfileImage_Document_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime BirthDate { 
			get {
				return _BirthDate;
			}
			set {
				if(_BirthDate != value){
					_BirthDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int Gender { 
			get {
				return _Gender;
			}
			set {
				if(_Gender != value){
					_Gender = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int NumberOfChildren { 
			get {
				return _NumberOfChildren;
			}
			set {
				if(_NumberOfChildren != value){
					_NumberOfChildren = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsRepresentedByLegalGuardian { 
			get {
				return _IsRepresentedByLegalGuardian;
			}
			set {
				if(_IsRepresentedByLegalGuardian != value){
					_IsRepresentedByLegalGuardian = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDead { 
			get {
				return _IsDead;
			}
			set {
				if(_IsDead != value){
					_IsDead = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime DateOfDeath { 
			get {
				return _DateOfDeath;
			}
			set {
				if(_DateOfDeath != value){
					_DateOfDeath = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int AgeCalculation_YearOfBirth { 
			get {
				return _AgeCalculation_YearOfBirth;
			}
			set {
				if(_AgeCalculation_YearOfBirth != value){
					_AgeCalculation_YearOfBirth = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PER.CMN_PER_PersonInfo.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PER.CMN_PER_PersonInfo.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PER_PersonInfoID", _CMN_PER_PersonInfoID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Address_RefID", _Address_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Title", _Title);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Salutation_General", _Salutation_General);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Salutation_Letter", _Salutation_Letter);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Initials", _Initials);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "FirstName", _FirstName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LastName", _LastName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PrimaryEmail", _PrimaryEmail);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProfileImage_Document_RefID", _ProfileImage_Document_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BirthDate", _BirthDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Gender", _Gender);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "NumberOfChildren", _NumberOfChildren);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsRepresentedByLegalGuardian", _IsRepresentedByLegalGuardian);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDead", _IsDead);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DateOfDeath", _DateOfDeath);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AgeCalculation_YearOfBirth", _AgeCalculation_YearOfBirth);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PER.CMN_PER_PersonInfo.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_PER_PersonInfoID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_PER_PersonInfoID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PER_PersonInfoID","Address_RefID","Title","Salutation_General","Salutation_Letter","Initials","FirstName","LastName","PrimaryEmail","ProfileImage_Document_RefID","BirthDate","Gender","NumberOfChildren","IsRepresentedByLegalGuardian","IsDead","DateOfDeath","AgeCalculation_YearOfBirth","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_PER_PersonInfoID of type Guid
						_CMN_PER_PersonInfoID = reader.GetGuid(0);
						//1:Parameter Address_RefID of type Guid
						_Address_RefID = reader.GetGuid(1);
						//2:Parameter Title of type String
						_Title = reader.GetString(2);
						//3:Parameter Salutation_General of type String
						_Salutation_General = reader.GetString(3);
						//4:Parameter Salutation_Letter of type String
						_Salutation_Letter = reader.GetString(4);
						//5:Parameter Initials of type String
						_Initials = reader.GetString(5);
						//6:Parameter FirstName of type String
						_FirstName = reader.GetString(6);
						//7:Parameter LastName of type String
						_LastName = reader.GetString(7);
						//8:Parameter PrimaryEmail of type String
						_PrimaryEmail = reader.GetString(8);
						//9:Parameter ProfileImage_Document_RefID of type Guid
						_ProfileImage_Document_RefID = reader.GetGuid(9);
						//10:Parameter BirthDate of type DateTime
						_BirthDate = reader.GetDate(10);
						//11:Parameter Gender of type int
						_Gender = reader.GetInteger(11);
						//12:Parameter NumberOfChildren of type int
						_NumberOfChildren = reader.GetInteger(12);
						//13:Parameter IsRepresentedByLegalGuardian of type Boolean
						_IsRepresentedByLegalGuardian = reader.GetBoolean(13);
						//14:Parameter IsDead of type Boolean
						_IsDead = reader.GetBoolean(14);
						//15:Parameter DateOfDeath of type DateTime
						_DateOfDeath = reader.GetDate(15);
						//16:Parameter AgeCalculation_YearOfBirth of type int
						_AgeCalculation_YearOfBirth = reader.GetInteger(16);
						//17:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(17);
						//18:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(18);
						//19:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(19);
						//20:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(20);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_PER_PersonInfoID != Guid.Empty){
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
			public Guid? CMN_PER_PersonInfoID {	get; set; }
			public Guid? Address_RefID {	get; set; }
			public String Title {	get; set; }
			public String Salutation_General {	get; set; }
			public String Salutation_Letter {	get; set; }
			public String Initials {	get; set; }
			public String FirstName {	get; set; }
			public String LastName {	get; set; }
			public String PrimaryEmail {	get; set; }
			public Guid? ProfileImage_Document_RefID {	get; set; }
			public DateTime? BirthDate {	get; set; }
			public int? Gender {	get; set; }
			public int? NumberOfChildren {	get; set; }
			public Boolean? IsRepresentedByLegalGuardian {	get; set; }
			public Boolean? IsDead {	get; set; }
			public DateTime? DateOfDeath {	get; set; }
			public int? AgeCalculation_YearOfBirth {	get; set; }
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
					throw ex;
				}
			}
			#endregion

			#region Search
			public static List<ORM_CMN_PER_PersonInfo> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_PER_PersonInfo> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_PER_PersonInfo> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_PER_PersonInfo> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_PER_PersonInfo> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_PER_PersonInfo>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PER_PersonInfoID","Address_RefID","Title","Salutation_General","Salutation_Letter","Initials","FirstName","LastName","PrimaryEmail","ProfileImage_Document_RefID","BirthDate","Gender","NumberOfChildren","IsRepresentedByLegalGuardian","IsDead","DateOfDeath","AgeCalculation_YearOfBirth","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_CMN_PER_PersonInfo item = new ORM_CMN_PER_PersonInfo();
						//0:Parameter CMN_PER_PersonInfoID of type Guid
						item.CMN_PER_PersonInfoID = reader.GetGuid(0);
						//1:Parameter Address_RefID of type Guid
						item.Address_RefID = reader.GetGuid(1);
						//2:Parameter Title of type String
						item.Title = reader.GetString(2);
						//3:Parameter Salutation_General of type String
						item.Salutation_General = reader.GetString(3);
						//4:Parameter Salutation_Letter of type String
						item.Salutation_Letter = reader.GetString(4);
						//5:Parameter Initials of type String
						item.Initials = reader.GetString(5);
						//6:Parameter FirstName of type String
						item.FirstName = reader.GetString(6);
						//7:Parameter LastName of type String
						item.LastName = reader.GetString(7);
						//8:Parameter PrimaryEmail of type String
						item.PrimaryEmail = reader.GetString(8);
						//9:Parameter ProfileImage_Document_RefID of type Guid
						item.ProfileImage_Document_RefID = reader.GetGuid(9);
						//10:Parameter BirthDate of type DateTime
						item.BirthDate = reader.GetDate(10);
						//11:Parameter Gender of type int
						item.Gender = reader.GetInteger(11);
						//12:Parameter NumberOfChildren of type int
						item.NumberOfChildren = reader.GetInteger(12);
						//13:Parameter IsRepresentedByLegalGuardian of type Boolean
						item.IsRepresentedByLegalGuardian = reader.GetBoolean(13);
						//14:Parameter IsDead of type Boolean
						item.IsDead = reader.GetBoolean(14);
						//15:Parameter DateOfDeath of type DateTime
						item.DateOfDeath = reader.GetDate(15);
						//16:Parameter AgeCalculation_YearOfBirth of type int
						item.AgeCalculation_YearOfBirth = reader.GetInteger(16);
						//17:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(17);
						//18:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(18);
						//19:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(19);
						//20:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(20);


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
