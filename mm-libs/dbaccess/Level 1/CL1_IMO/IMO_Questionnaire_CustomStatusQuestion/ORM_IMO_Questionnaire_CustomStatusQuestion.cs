/* 
 * Generated on 6/18/2013 5:03:23 PM
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
	public class ORM_IMO_Questionnaire_CustomStatusQuestion
	{
		public static readonly string TableName = "imo_questionnaire_customstatusquestions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_IMO_Questionnaire_CustomStatusQuestion()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_IMO_Questionnaire_CustomStatusQuestionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _IMO_Questionnaire_CustomStatusQuestionID = default(Guid);
		private Guid _CustomStatusQuestionGroup_RefID = default(Guid);
		private Dict _QuestionText = new Dict(TableName);
		private int _SequenceNumber = default(int);
		private Boolean _IsAnswerBoolean = default(Boolean);
		private Boolean _IsAnswerNumber = default(Boolean);
		private Boolean _IsAnswerText = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid IMO_Questionnaire_CustomStatusQuestionID { 
			get {
				return _IMO_Questionnaire_CustomStatusQuestionID;
			}
			set {
				if(_IMO_Questionnaire_CustomStatusQuestionID != value){
					_IMO_Questionnaire_CustomStatusQuestionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid CustomStatusQuestionGroup_RefID { 
			get {
				return _CustomStatusQuestionGroup_RefID;
			}
			set {
				if(_CustomStatusQuestionGroup_RefID != value){
					_CustomStatusQuestionGroup_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict QuestionText { 
			get {
				return _QuestionText;
			}
			set {
				if(_QuestionText != value){
					_QuestionText = value;
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
		public Boolean IsAnswerBoolean { 
			get {
				return _IsAnswerBoolean;
			}
			set {
				if(_IsAnswerBoolean != value){
					_IsAnswerBoolean = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAnswerNumber { 
			get {
				return _IsAnswerNumber;
			}
			set {
				if(_IsAnswerNumber != value){
					_IsAnswerNumber = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAnswerText { 
			get {
				return _IsAnswerText;
			}
			set {
				if(_IsAnswerText != value){
					_IsAnswerText = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || QuestionText.IsDirty ;
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
								loader.Append(QuestionText,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_IMO.IMO_Questionnaire_CustomStatusQuestion.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_IMO.IMO_Questionnaire_CustomStatusQuestion.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IMO_Questionnaire_CustomStatusQuestionID", _IMO_Questionnaire_CustomStatusQuestionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CustomStatusQuestionGroup_RefID", _CustomStatusQuestionGroup_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "QuestionText", _QuestionText.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "SequenceNumber", _SequenceNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAnswerBoolean", _IsAnswerBoolean);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAnswerNumber", _IsAnswerNumber);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAnswerText", _IsAnswerText);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_IMO.IMO_Questionnaire_CustomStatusQuestion.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_IMO_Questionnaire_CustomStatusQuestionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IMO_Questionnaire_CustomStatusQuestionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "IMO_Questionnaire_CustomStatusQuestionID","CustomStatusQuestionGroup_RefID","QuestionText_DictID","SequenceNumber","IsAnswerBoolean","IsAnswerNumber","IsAnswerText","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter IMO_Questionnaire_CustomStatusQuestionID of type Guid
						_IMO_Questionnaire_CustomStatusQuestionID = reader.GetGuid(0);
						//1:Parameter CustomStatusQuestionGroup_RefID of type Guid
						_CustomStatusQuestionGroup_RefID = reader.GetGuid(1);
						//2:Parameter QuestionText of type Dict
						_QuestionText = reader.GetDictionary(2);
						loader.Append(_QuestionText,TableName);
						//3:Parameter SequenceNumber of type int
						_SequenceNumber = reader.GetInteger(3);
						//4:Parameter IsAnswerBoolean of type Boolean
						_IsAnswerBoolean = reader.GetBoolean(4);
						//5:Parameter IsAnswerNumber of type Boolean
						_IsAnswerNumber = reader.GetBoolean(5);
						//6:Parameter IsAnswerText of type Boolean
						_IsAnswerText = reader.GetBoolean(6);
						//7:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(7);
						//8:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(8);
						//9:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(9);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_IMO_Questionnaire_CustomStatusQuestionID != Guid.Empty){
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
			public Guid? IMO_Questionnaire_CustomStatusQuestionID {	get; set; }
			public Guid? CustomStatusQuestionGroup_RefID {	get; set; }
			public Dict QuestionText {	get; set; }
			public int? SequenceNumber {	get; set; }
			public Boolean? IsAnswerBoolean {	get; set; }
			public Boolean? IsAnswerNumber {	get; set; }
			public Boolean? IsAnswerText {	get; set; }
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
			public static List<ORM_IMO_Questionnaire_CustomStatusQuestion> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_IMO_Questionnaire_CustomStatusQuestion> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_IMO_Questionnaire_CustomStatusQuestion> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_IMO_Questionnaire_CustomStatusQuestion> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_IMO_Questionnaire_CustomStatusQuestion> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_IMO_Questionnaire_CustomStatusQuestion>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "IMO_Questionnaire_CustomStatusQuestionID","CustomStatusQuestionGroup_RefID","QuestionText_DictID","SequenceNumber","IsAnswerBoolean","IsAnswerNumber","IsAnswerText","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_IMO_Questionnaire_CustomStatusQuestion item = new ORM_IMO_Questionnaire_CustomStatusQuestion();
						//0:Parameter IMO_Questionnaire_CustomStatusQuestionID of type Guid
						item.IMO_Questionnaire_CustomStatusQuestionID = reader.GetGuid(0);
						//1:Parameter CustomStatusQuestionGroup_RefID of type Guid
						item.CustomStatusQuestionGroup_RefID = reader.GetGuid(1);
						//2:Parameter QuestionText of type Dict
						item.QuestionText = reader.GetDictionary(2);
						loader.Append(item.QuestionText,TableName);
						//3:Parameter SequenceNumber of type int
						item.SequenceNumber = reader.GetInteger(3);
						//4:Parameter IsAnswerBoolean of type Boolean
						item.IsAnswerBoolean = reader.GetBoolean(4);
						//5:Parameter IsAnswerNumber of type Boolean
						item.IsAnswerNumber = reader.GetBoolean(5);
						//6:Parameter IsAnswerText of type Boolean
						item.IsAnswerText = reader.GetBoolean(6);
						//7:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(7);
						//8:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(8);
						//9:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(9);


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
