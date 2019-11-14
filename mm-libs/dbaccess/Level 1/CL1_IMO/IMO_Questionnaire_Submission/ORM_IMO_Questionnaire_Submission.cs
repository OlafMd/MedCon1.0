/* 
 * Generated on 6/18/2013 5:03:19 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_IMO
{
	[Serializable]
	public class ORM_IMO_Questionnaire_Submission
	{
		public static readonly string TableName = "imo_questionnaire_submissions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_IMO_Questionnaire_Submission()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_IMO_Questionnaire_SubmissionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _IMO_Questionnaire_SubmissionID = default(Guid);
		private Guid _Questionnaire_RefID = default(Guid);
		private Guid _SubmittedBy_Account_RefID = default(Guid);
		private Guid _QuestionnaireVersion_RefID = default(Guid);
		private Guid _RealEstate_RefID = default(Guid);
		private Guid _ImageGroup_RefID = default(Guid);
		private Guid _Questionnaire_SubmissionBinder_RefID = default(Guid);
		private String _Title = default(String);
		private DateTime _SubmittedOn = default(DateTime);
		private DateTime _CreatedOn = default(DateTime);
		private DateTime _LastUpdateOn = default(DateTime);
		private int _ResubmissionVersion = default(int);
		private Guid _LastEdited_ByAccount_RefID = default(Guid);
		private DateTime _LastEdited_Date = default(DateTime);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid IMO_Questionnaire_SubmissionID { 
			get {
				return _IMO_Questionnaire_SubmissionID;
			}
			set {
				if(_IMO_Questionnaire_SubmissionID != value){
					_IMO_Questionnaire_SubmissionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Questionnaire_RefID { 
			get {
				return _Questionnaire_RefID;
			}
			set {
				if(_Questionnaire_RefID != value){
					_Questionnaire_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid SubmittedBy_Account_RefID { 
			get {
				return _SubmittedBy_Account_RefID;
			}
			set {
				if(_SubmittedBy_Account_RefID != value){
					_SubmittedBy_Account_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid QuestionnaireVersion_RefID { 
			get {
				return _QuestionnaireVersion_RefID;
			}
			set {
				if(_QuestionnaireVersion_RefID != value){
					_QuestionnaireVersion_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid RealEstate_RefID { 
			get {
				return _RealEstate_RefID;
			}
			set {
				if(_RealEstate_RefID != value){
					_RealEstate_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ImageGroup_RefID { 
			get {
				return _ImageGroup_RefID;
			}
			set {
				if(_ImageGroup_RefID != value){
					_ImageGroup_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Questionnaire_SubmissionBinder_RefID { 
			get {
				return _Questionnaire_SubmissionBinder_RefID;
			}
			set {
				if(_Questionnaire_SubmissionBinder_RefID != value){
					_Questionnaire_SubmissionBinder_RefID = value;
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
		public DateTime SubmittedOn { 
			get {
				return _SubmittedOn;
			}
			set {
				if(_SubmittedOn != value){
					_SubmittedOn = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime CreatedOn { 
			get {
				return _CreatedOn;
			}
			set {
				if(_CreatedOn != value){
					_CreatedOn = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime LastUpdateOn { 
			get {
				return _LastUpdateOn;
			}
			set {
				if(_LastUpdateOn != value){
					_LastUpdateOn = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int ResubmissionVersion { 
			get {
				return _ResubmissionVersion;
			}
			set {
				if(_ResubmissionVersion != value){
					_ResubmissionVersion = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid LastEdited_ByAccount_RefID { 
			get {
				return _LastEdited_ByAccount_RefID;
			}
			set {
				if(_LastEdited_ByAccount_RefID != value){
					_LastEdited_ByAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime LastEdited_Date { 
			get {
				return _LastEdited_Date;
			}
			set {
				if(_LastEdited_Date != value){
					_LastEdited_Date = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_IMO.IMO_Questionnaire_Submission.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_IMO.IMO_Questionnaire_Submission.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IMO_Questionnaire_SubmissionID", _IMO_Questionnaire_SubmissionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Questionnaire_RefID", _Questionnaire_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SubmittedBy_Account_RefID", _SubmittedBy_Account_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuestionnaireVersion_RefID", _QuestionnaireVersion_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RealEstate_RefID", _RealEstate_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ImageGroup_RefID", _ImageGroup_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Questionnaire_SubmissionBinder_RefID", _Questionnaire_SubmissionBinder_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Title", _Title);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SubmittedOn", _SubmittedOn);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CreatedOn", _CreatedOn);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LastUpdateOn", _LastUpdateOn);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ResubmissionVersion", _ResubmissionVersion);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LastEdited_ByAccount_RefID", _LastEdited_ByAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "LastEdited_Date", _LastEdited_Date);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_IMO.IMO_Questionnaire_Submission.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_IMO_Questionnaire_SubmissionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IMO_Questionnaire_SubmissionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "IMO_Questionnaire_SubmissionID","Questionnaire_RefID","SubmittedBy_Account_RefID","QuestionnaireVersion_RefID","RealEstate_RefID","ImageGroup_RefID","Questionnaire_SubmissionBinder_RefID","Title","SubmittedOn","CreatedOn","LastUpdateOn","ResubmissionVersion","LastEdited_ByAccount_RefID","LastEdited_Date","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter IMO_Questionnaire_SubmissionID of type Guid
						_IMO_Questionnaire_SubmissionID = reader.GetGuid(0);
						//1:Parameter Questionnaire_RefID of type Guid
						_Questionnaire_RefID = reader.GetGuid(1);
						//2:Parameter SubmittedBy_Account_RefID of type Guid
						_SubmittedBy_Account_RefID = reader.GetGuid(2);
						//3:Parameter QuestionnaireVersion_RefID of type Guid
						_QuestionnaireVersion_RefID = reader.GetGuid(3);
						//4:Parameter RealEstate_RefID of type Guid
						_RealEstate_RefID = reader.GetGuid(4);
						//5:Parameter ImageGroup_RefID of type Guid
						_ImageGroup_RefID = reader.GetGuid(5);
						//6:Parameter Questionnaire_SubmissionBinder_RefID of type Guid
						_Questionnaire_SubmissionBinder_RefID = reader.GetGuid(6);
						//7:Parameter Title of type String
						_Title = reader.GetString(7);
						//8:Parameter SubmittedOn of type DateTime
						_SubmittedOn = reader.GetDate(8);
						//9:Parameter CreatedOn of type DateTime
						_CreatedOn = reader.GetDate(9);
						//10:Parameter LastUpdateOn of type DateTime
						_LastUpdateOn = reader.GetDate(10);
						//11:Parameter ResubmissionVersion of type int
						_ResubmissionVersion = reader.GetInteger(11);
						//12:Parameter LastEdited_ByAccount_RefID of type Guid
						_LastEdited_ByAccount_RefID = reader.GetGuid(12);
						//13:Parameter LastEdited_Date of type DateTime
						_LastEdited_Date = reader.GetDate(13);
						//14:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(14);
						//15:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(15);
						//16:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(16);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_IMO_Questionnaire_SubmissionID != Guid.Empty){
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
			public Guid? IMO_Questionnaire_SubmissionID {	get; set; }
			public Guid? Questionnaire_RefID {	get; set; }
			public Guid? SubmittedBy_Account_RefID {	get; set; }
			public Guid? QuestionnaireVersion_RefID {	get; set; }
			public Guid? RealEstate_RefID {	get; set; }
			public Guid? ImageGroup_RefID {	get; set; }
			public Guid? Questionnaire_SubmissionBinder_RefID {	get; set; }
			public String Title {	get; set; }
			public DateTime? SubmittedOn {	get; set; }
			public DateTime? CreatedOn {	get; set; }
			public DateTime? LastUpdateOn {	get; set; }
			public int? ResubmissionVersion {	get; set; }
			public Guid? LastEdited_ByAccount_RefID {	get; set; }
			public DateTime? LastEdited_Date {	get; set; }
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
			public static List<ORM_IMO_Questionnaire_Submission> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_IMO_Questionnaire_Submission> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_IMO_Questionnaire_Submission> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_IMO_Questionnaire_Submission> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_IMO_Questionnaire_Submission> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_IMO_Questionnaire_Submission>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "IMO_Questionnaire_SubmissionID","Questionnaire_RefID","SubmittedBy_Account_RefID","QuestionnaireVersion_RefID","RealEstate_RefID","ImageGroup_RefID","Questionnaire_SubmissionBinder_RefID","Title","SubmittedOn","CreatedOn","LastUpdateOn","ResubmissionVersion","LastEdited_ByAccount_RefID","LastEdited_Date","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_IMO_Questionnaire_Submission item = new ORM_IMO_Questionnaire_Submission();
						//0:Parameter IMO_Questionnaire_SubmissionID of type Guid
						item.IMO_Questionnaire_SubmissionID = reader.GetGuid(0);
						//1:Parameter Questionnaire_RefID of type Guid
						item.Questionnaire_RefID = reader.GetGuid(1);
						//2:Parameter SubmittedBy_Account_RefID of type Guid
						item.SubmittedBy_Account_RefID = reader.GetGuid(2);
						//3:Parameter QuestionnaireVersion_RefID of type Guid
						item.QuestionnaireVersion_RefID = reader.GetGuid(3);
						//4:Parameter RealEstate_RefID of type Guid
						item.RealEstate_RefID = reader.GetGuid(4);
						//5:Parameter ImageGroup_RefID of type Guid
						item.ImageGroup_RefID = reader.GetGuid(5);
						//6:Parameter Questionnaire_SubmissionBinder_RefID of type Guid
						item.Questionnaire_SubmissionBinder_RefID = reader.GetGuid(6);
						//7:Parameter Title of type String
						item.Title = reader.GetString(7);
						//8:Parameter SubmittedOn of type DateTime
						item.SubmittedOn = reader.GetDate(8);
						//9:Parameter CreatedOn of type DateTime
						item.CreatedOn = reader.GetDate(9);
						//10:Parameter LastUpdateOn of type DateTime
						item.LastUpdateOn = reader.GetDate(10);
						//11:Parameter ResubmissionVersion of type int
						item.ResubmissionVersion = reader.GetInteger(11);
						//12:Parameter LastEdited_ByAccount_RefID of type Guid
						item.LastEdited_ByAccount_RefID = reader.GetGuid(12);
						//13:Parameter LastEdited_Date of type DateTime
						item.LastEdited_Date = reader.GetDate(13);
						//14:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(14);
						//15:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(15);
						//16:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(16);


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
