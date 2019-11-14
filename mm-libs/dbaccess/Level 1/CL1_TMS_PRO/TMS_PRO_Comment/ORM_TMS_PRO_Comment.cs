/* 
 * Generated on 6/18/2013 5:42:42 PM
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
	public class ORM_TMS_PRO_Comment
	{
		public static readonly string TableName = "tms_pro_comments";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_TMS_PRO_Comment()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_TMS_PRO_CommentID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _TMS_PRO_CommentID = default(Guid);
		private Guid _Comment_BoundTo_Project_RefID = default(Guid);
		private Guid _Comment_BoundTo_BusinessTask_RefID = default(Guid);
		private Guid _Comment_BoundTo_Feature_RefID = default(Guid);
		private Guid _Comment_BoundTo_DeveloperTask_RefID = default(Guid);
		private Boolean _IsComment_BoundToBusinessTask = default(Boolean);
		private Boolean _IsComment_BoundToFeature = default(Boolean);
		private Boolean _IsComment_BoundToDeveloperTask = default(Boolean);
		private Guid _Comment_Quoatation_RefID = default(Guid);
		private Guid _Comment_CreatedByAccount_RefID = default(Guid);
		private String _Comment_Quotation_Text = default(String);
		private String _Comment_TextContent = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid TMS_PRO_CommentID { 
			get {
				return _TMS_PRO_CommentID;
			}
			set {
				if(_TMS_PRO_CommentID != value){
					_TMS_PRO_CommentID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Comment_BoundTo_Project_RefID { 
			get {
				return _Comment_BoundTo_Project_RefID;
			}
			set {
				if(_Comment_BoundTo_Project_RefID != value){
					_Comment_BoundTo_Project_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Comment_BoundTo_BusinessTask_RefID { 
			get {
				return _Comment_BoundTo_BusinessTask_RefID;
			}
			set {
				if(_Comment_BoundTo_BusinessTask_RefID != value){
					_Comment_BoundTo_BusinessTask_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Comment_BoundTo_Feature_RefID { 
			get {
				return _Comment_BoundTo_Feature_RefID;
			}
			set {
				if(_Comment_BoundTo_Feature_RefID != value){
					_Comment_BoundTo_Feature_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Comment_BoundTo_DeveloperTask_RefID { 
			get {
				return _Comment_BoundTo_DeveloperTask_RefID;
			}
			set {
				if(_Comment_BoundTo_DeveloperTask_RefID != value){
					_Comment_BoundTo_DeveloperTask_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsComment_BoundToBusinessTask { 
			get {
				return _IsComment_BoundToBusinessTask;
			}
			set {
				if(_IsComment_BoundToBusinessTask != value){
					_IsComment_BoundToBusinessTask = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsComment_BoundToFeature { 
			get {
				return _IsComment_BoundToFeature;
			}
			set {
				if(_IsComment_BoundToFeature != value){
					_IsComment_BoundToFeature = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsComment_BoundToDeveloperTask { 
			get {
				return _IsComment_BoundToDeveloperTask;
			}
			set {
				if(_IsComment_BoundToDeveloperTask != value){
					_IsComment_BoundToDeveloperTask = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Comment_Quoatation_RefID { 
			get {
				return _Comment_Quoatation_RefID;
			}
			set {
				if(_Comment_Quoatation_RefID != value){
					_Comment_Quoatation_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Comment_CreatedByAccount_RefID { 
			get {
				return _Comment_CreatedByAccount_RefID;
			}
			set {
				if(_Comment_CreatedByAccount_RefID != value){
					_Comment_CreatedByAccount_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Comment_Quotation_Text { 
			get {
				return _Comment_Quotation_Text;
			}
			set {
				if(_Comment_Quotation_Text != value){
					_Comment_Quotation_Text = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Comment_TextContent { 
			get {
				return _Comment_TextContent;
			}
			set {
				if(_Comment_TextContent != value){
					_Comment_TextContent = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_TMS_PRO.TMS_PRO_Comment.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_TMS_PRO.TMS_PRO_Comment.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TMS_PRO_CommentID", _TMS_PRO_CommentID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment_BoundTo_Project_RefID", _Comment_BoundTo_Project_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment_BoundTo_BusinessTask_RefID", _Comment_BoundTo_BusinessTask_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment_BoundTo_Feature_RefID", _Comment_BoundTo_Feature_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment_BoundTo_DeveloperTask_RefID", _Comment_BoundTo_DeveloperTask_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsComment_BoundToBusinessTask", _IsComment_BoundToBusinessTask);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsComment_BoundToFeature", _IsComment_BoundToFeature);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsComment_BoundToDeveloperTask", _IsComment_BoundToDeveloperTask);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment_Quoatation_RefID", _Comment_Quoatation_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment_CreatedByAccount_RefID", _Comment_CreatedByAccount_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment_Quotation_Text", _Comment_Quotation_Text);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Comment_TextContent", _Comment_TextContent);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_TMS_PRO.TMS_PRO_Comment.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_TMS_PRO_CommentID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TMS_PRO_CommentID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "TMS_PRO_CommentID","Comment_BoundTo_Project_RefID","Comment_BoundTo_BusinessTask_RefID","Comment_BoundTo_Feature_RefID","Comment_BoundTo_DeveloperTask_RefID","IsComment_BoundToBusinessTask","IsComment_BoundToFeature","IsComment_BoundToDeveloperTask","Comment_Quoatation_RefID","Comment_CreatedByAccount_RefID","Comment_Quotation_Text","Comment_TextContent","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter TMS_PRO_CommentID of type Guid
						_TMS_PRO_CommentID = reader.GetGuid(0);
						//1:Parameter Comment_BoundTo_Project_RefID of type Guid
						_Comment_BoundTo_Project_RefID = reader.GetGuid(1);
						//2:Parameter Comment_BoundTo_BusinessTask_RefID of type Guid
						_Comment_BoundTo_BusinessTask_RefID = reader.GetGuid(2);
						//3:Parameter Comment_BoundTo_Feature_RefID of type Guid
						_Comment_BoundTo_Feature_RefID = reader.GetGuid(3);
						//4:Parameter Comment_BoundTo_DeveloperTask_RefID of type Guid
						_Comment_BoundTo_DeveloperTask_RefID = reader.GetGuid(4);
						//5:Parameter IsComment_BoundToBusinessTask of type Boolean
						_IsComment_BoundToBusinessTask = reader.GetBoolean(5);
						//6:Parameter IsComment_BoundToFeature of type Boolean
						_IsComment_BoundToFeature = reader.GetBoolean(6);
						//7:Parameter IsComment_BoundToDeveloperTask of type Boolean
						_IsComment_BoundToDeveloperTask = reader.GetBoolean(7);
						//8:Parameter Comment_Quoatation_RefID of type Guid
						_Comment_Quoatation_RefID = reader.GetGuid(8);
						//9:Parameter Comment_CreatedByAccount_RefID of type Guid
						_Comment_CreatedByAccount_RefID = reader.GetGuid(9);
						//10:Parameter Comment_Quotation_Text of type String
						_Comment_Quotation_Text = reader.GetString(10);
						//11:Parameter Comment_TextContent of type String
						_Comment_TextContent = reader.GetString(11);
						//12:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(12);
						//13:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(13);
						//14:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(14);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_TMS_PRO_CommentID != Guid.Empty){
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
			public Guid? TMS_PRO_CommentID {	get; set; }
			public Guid? Comment_BoundTo_Project_RefID {	get; set; }
			public Guid? Comment_BoundTo_BusinessTask_RefID {	get; set; }
			public Guid? Comment_BoundTo_Feature_RefID {	get; set; }
			public Guid? Comment_BoundTo_DeveloperTask_RefID {	get; set; }
			public Boolean? IsComment_BoundToBusinessTask {	get; set; }
			public Boolean? IsComment_BoundToFeature {	get; set; }
			public Boolean? IsComment_BoundToDeveloperTask {	get; set; }
			public Guid? Comment_Quoatation_RefID {	get; set; }
			public Guid? Comment_CreatedByAccount_RefID {	get; set; }
			public String Comment_Quotation_Text {	get; set; }
			public String Comment_TextContent {	get; set; }
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
			public static List<ORM_TMS_PRO_Comment> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_TMS_PRO_Comment> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_TMS_PRO_Comment> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_TMS_PRO_Comment> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_TMS_PRO_Comment> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_TMS_PRO_Comment>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "TMS_PRO_CommentID","Comment_BoundTo_Project_RefID","Comment_BoundTo_BusinessTask_RefID","Comment_BoundTo_Feature_RefID","Comment_BoundTo_DeveloperTask_RefID","IsComment_BoundToBusinessTask","IsComment_BoundToFeature","IsComment_BoundToDeveloperTask","Comment_Quoatation_RefID","Comment_CreatedByAccount_RefID","Comment_Quotation_Text","Comment_TextContent","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_TMS_PRO_Comment item = new ORM_TMS_PRO_Comment();
						//0:Parameter TMS_PRO_CommentID of type Guid
						item.TMS_PRO_CommentID = reader.GetGuid(0);
						//1:Parameter Comment_BoundTo_Project_RefID of type Guid
						item.Comment_BoundTo_Project_RefID = reader.GetGuid(1);
						//2:Parameter Comment_BoundTo_BusinessTask_RefID of type Guid
						item.Comment_BoundTo_BusinessTask_RefID = reader.GetGuid(2);
						//3:Parameter Comment_BoundTo_Feature_RefID of type Guid
						item.Comment_BoundTo_Feature_RefID = reader.GetGuid(3);
						//4:Parameter Comment_BoundTo_DeveloperTask_RefID of type Guid
						item.Comment_BoundTo_DeveloperTask_RefID = reader.GetGuid(4);
						//5:Parameter IsComment_BoundToBusinessTask of type Boolean
						item.IsComment_BoundToBusinessTask = reader.GetBoolean(5);
						//6:Parameter IsComment_BoundToFeature of type Boolean
						item.IsComment_BoundToFeature = reader.GetBoolean(6);
						//7:Parameter IsComment_BoundToDeveloperTask of type Boolean
						item.IsComment_BoundToDeveloperTask = reader.GetBoolean(7);
						//8:Parameter Comment_Quoatation_RefID of type Guid
						item.Comment_Quoatation_RefID = reader.GetGuid(8);
						//9:Parameter Comment_CreatedByAccount_RefID of type Guid
						item.Comment_CreatedByAccount_RefID = reader.GetGuid(9);
						//10:Parameter Comment_Quotation_Text of type String
						item.Comment_Quotation_Text = reader.GetString(10);
						//11:Parameter Comment_TextContent of type String
						item.Comment_TextContent = reader.GetString(11);
						//12:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(12);
						//13:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(13);
						//14:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(14);


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
