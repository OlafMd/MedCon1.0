/* 
 * Generated on 22-Oct-13 14:24:58
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_BPT_EMP
{
	[Serializable]
	public class ORM_CMN_BPT_EMP_EmploymentRelationship_Template
	{
		public static readonly string TableName = "cmn_bpt_emp_employmentrelationship_templates";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_EMP_EmploymentRelationship_Template()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_EMP_EmploymentRelationship_TemplateID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_EMP_EmploymentRelationship_TemplateID = default(Guid);
		private DateTime _Template_StartDate = default(DateTime);
		private DateTime _Template_EndDate = default(DateTime);
		private Dict _Template_Name = new Dict(TableName);
		private Double _RequiredMonthlyHours = default(Double);
		private Double _RequiredWeeklyHours = default(Double);
		private Double _RequiredDailyHours = default(Double);
		private String _R_WeeklyWorkPattern = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_EMP_EmploymentRelationship_TemplateID { 
			get {
				return _CMN_BPT_EMP_EmploymentRelationship_TemplateID;
			}
			set {
				if(_CMN_BPT_EMP_EmploymentRelationship_TemplateID != value){
					_CMN_BPT_EMP_EmploymentRelationship_TemplateID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Template_StartDate { 
			get {
				return _Template_StartDate;
			}
			set {
				if(_Template_StartDate != value){
					_Template_StartDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime Template_EndDate { 
			get {
				return _Template_EndDate;
			}
			set {
				if(_Template_EndDate != value){
					_Template_EndDate = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Template_Name { 
			get {
				return _Template_Name;
			}
			set {
				if(_Template_Name != value){
					_Template_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double RequiredMonthlyHours { 
			get {
				return _RequiredMonthlyHours;
			}
			set {
				if(_RequiredMonthlyHours != value){
					_RequiredMonthlyHours = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double RequiredWeeklyHours { 
			get {
				return _RequiredWeeklyHours;
			}
			set {
				if(_RequiredWeeklyHours != value){
					_RequiredWeeklyHours = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double RequiredDailyHours { 
			get {
				return _RequiredDailyHours;
			}
			set {
				if(_RequiredDailyHours != value){
					_RequiredDailyHours = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String R_WeeklyWorkPattern { 
			get {
				return _R_WeeklyWorkPattern;
			}
			set {
				if(_R_WeeklyWorkPattern != value){
					_R_WeeklyWorkPattern = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || Template_Name.IsDirty ;
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
								loader.Append(Template_Name,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_EmploymentRelationship_Template.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_EmploymentRelationship_Template.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_EMP_EmploymentRelationship_TemplateID", _CMN_BPT_EMP_EmploymentRelationship_TemplateID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Template_StartDate", _Template_StartDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Template_EndDate", _Template_EndDate);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Template_Name", _Template_Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequiredMonthlyHours", _RequiredMonthlyHours);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequiredWeeklyHours", _RequiredWeeklyHours);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "RequiredDailyHours", _RequiredDailyHours);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_WeeklyWorkPattern", _R_WeeklyWorkPattern);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_EMP.CMN_BPT_EMP_EmploymentRelationship_Template.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_EMP_EmploymentRelationship_TemplateID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_EMP_EmploymentRelationship_TemplateID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_EmploymentRelationship_TemplateID","Template_StartDate","Template_EndDate","Template_Name_DictID","RequiredMonthlyHours","RequiredWeeklyHours","RequiredDailyHours","R_WeeklyWorkPattern","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_EMP_EmploymentRelationship_TemplateID of type Guid
						_CMN_BPT_EMP_EmploymentRelationship_TemplateID = reader.GetGuid(0);
						//1:Parameter Template_StartDate of type DateTime
						_Template_StartDate = reader.GetDate(1);
						//2:Parameter Template_EndDate of type DateTime
						_Template_EndDate = reader.GetDate(2);
						//3:Parameter Template_Name of type Dict
						_Template_Name = reader.GetDictionary(3);
						loader.Append(_Template_Name,TableName);
						//4:Parameter RequiredMonthlyHours of type Double
						_RequiredMonthlyHours = reader.GetDouble(4);
						//5:Parameter RequiredWeeklyHours of type Double
						_RequiredWeeklyHours = reader.GetDouble(5);
						//6:Parameter RequiredDailyHours of type Double
						_RequiredDailyHours = reader.GetDouble(6);
						//7:Parameter R_WeeklyWorkPattern of type String
						_R_WeeklyWorkPattern = reader.GetString(7);
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

					if(_CMN_BPT_EMP_EmploymentRelationship_TemplateID != Guid.Empty){
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
			public Guid? CMN_BPT_EMP_EmploymentRelationship_TemplateID {	get; set; }
			public DateTime? Template_StartDate {	get; set; }
			public DateTime? Template_EndDate {	get; set; }
			public Dict Template_Name {	get; set; }
			public Double? RequiredMonthlyHours {	get; set; }
			public Double? RequiredWeeklyHours {	get; set; }
			public Double? RequiredDailyHours {	get; set; }
			public String R_WeeklyWorkPattern {	get; set; }
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
			public static List<ORM_CMN_BPT_EMP_EmploymentRelationship_Template> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_EMP_EmploymentRelationship_Template> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_EMP_EmploymentRelationship_Template> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_EMP_EmploymentRelationship_Template> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_EMP_EmploymentRelationship_Template> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_EMP_EmploymentRelationship_Template>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_EMP_EmploymentRelationship_TemplateID","Template_StartDate","Template_EndDate","Template_Name_DictID","RequiredMonthlyHours","RequiredWeeklyHours","RequiredDailyHours","R_WeeklyWorkPattern","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_EMP_EmploymentRelationship_Template item = new ORM_CMN_BPT_EMP_EmploymentRelationship_Template();
						//0:Parameter CMN_BPT_EMP_EmploymentRelationship_TemplateID of type Guid
						item.CMN_BPT_EMP_EmploymentRelationship_TemplateID = reader.GetGuid(0);
						//1:Parameter Template_StartDate of type DateTime
						item.Template_StartDate = reader.GetDate(1);
						//2:Parameter Template_EndDate of type DateTime
						item.Template_EndDate = reader.GetDate(2);
						//3:Parameter Template_Name of type Dict
						item.Template_Name = reader.GetDictionary(3);
						loader.Append(item.Template_Name,TableName);
						//4:Parameter RequiredMonthlyHours of type Double
						item.RequiredMonthlyHours = reader.GetDouble(4);
						//5:Parameter RequiredWeeklyHours of type Double
						item.RequiredWeeklyHours = reader.GetDouble(5);
						//6:Parameter RequiredDailyHours of type Double
						item.RequiredDailyHours = reader.GetDouble(6);
						//7:Parameter R_WeeklyWorkPattern of type String
						item.R_WeeklyWorkPattern = reader.GetString(7);
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
