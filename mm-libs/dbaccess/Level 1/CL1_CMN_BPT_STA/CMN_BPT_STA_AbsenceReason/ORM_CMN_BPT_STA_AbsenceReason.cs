/* 
 * Generated on 05-Jun-14 14:34:28
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_BPT_STA
{
	[Serializable]
	public class ORM_CMN_BPT_STA_AbsenceReason
	{
		public static readonly string TableName = "cmn_bpt_sta_absencereasons";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_BPT_STA_AbsenceReason()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_BPT_STA_AbsenceReasonID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_BPT_STA_AbsenceReasonID = default(Guid);
		private String _ShortName = default(String);
		private Dict _Name = new Dict(TableName);
		private Dict _Description = new Dict(TableName);
		private Guid _AbsenceReason_Type_RefID = default(Guid);
		private String _ColorCode = default(String);
		private Guid _Parent_RefID = default(Guid);
		private Boolean _IsAuthorizationRequired = default(Boolean);
		private Boolean _IsIncludedInCapacityCalculation = default(Boolean);
		private Boolean _IsAllowedAbsence = default(Boolean);
		private Boolean _IsDeactivated = default(Boolean);
		private Boolean _IsCarryOverEnabled = default(Boolean);
		private Boolean _IsCaryOverLimited = default(Boolean);
		private Double _IfCarryOverLimited_MaximumAmount_Hrs = default(Double);
		private Boolean _IsLeaveTimeReducing_WorkingHours = default(Boolean);
		private Boolean _IsLeaveTimeReducing_OverHours = default(Boolean);
		private Boolean _IsLeaveTimeReducing_OverDays = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_BPT_STA_AbsenceReasonID { 
			get {
				return _CMN_BPT_STA_AbsenceReasonID;
			}
			set {
				if(_CMN_BPT_STA_AbsenceReasonID != value){
					_CMN_BPT_STA_AbsenceReasonID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ShortName { 
			get {
				return _ShortName;
			}
			set {
				if(_ShortName != value){
					_ShortName = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Name { 
			get {
				return _Name;
			}
			set {
				if(_Name != value){
					_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Description { 
			get {
				return _Description;
			}
			set {
				if(_Description != value){
					_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid AbsenceReason_Type_RefID { 
			get {
				return _AbsenceReason_Type_RefID;
			}
			set {
				if(_AbsenceReason_Type_RefID != value){
					_AbsenceReason_Type_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ColorCode { 
			get {
				return _ColorCode;
			}
			set {
				if(_ColorCode != value){
					_ColorCode = value;
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
		public Boolean IsAuthorizationRequired { 
			get {
				return _IsAuthorizationRequired;
			}
			set {
				if(_IsAuthorizationRequired != value){
					_IsAuthorizationRequired = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsIncludedInCapacityCalculation { 
			get {
				return _IsIncludedInCapacityCalculation;
			}
			set {
				if(_IsIncludedInCapacityCalculation != value){
					_IsIncludedInCapacityCalculation = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAllowedAbsence { 
			get {
				return _IsAllowedAbsence;
			}
			set {
				if(_IsAllowedAbsence != value){
					_IsAllowedAbsence = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsDeactivated { 
			get {
				return _IsDeactivated;
			}
			set {
				if(_IsDeactivated != value){
					_IsDeactivated = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCarryOverEnabled { 
			get {
				return _IsCarryOverEnabled;
			}
			set {
				if(_IsCarryOverEnabled != value){
					_IsCarryOverEnabled = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCaryOverLimited { 
			get {
				return _IsCaryOverLimited;
			}
			set {
				if(_IsCaryOverLimited != value){
					_IsCaryOverLimited = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Double IfCarryOverLimited_MaximumAmount_Hrs { 
			get {
				return _IfCarryOverLimited_MaximumAmount_Hrs;
			}
			set {
				if(_IfCarryOverLimited_MaximumAmount_Hrs != value){
					_IfCarryOverLimited_MaximumAmount_Hrs = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLeaveTimeReducing_WorkingHours { 
			get {
				return _IsLeaveTimeReducing_WorkingHours;
			}
			set {
				if(_IsLeaveTimeReducing_WorkingHours != value){
					_IsLeaveTimeReducing_WorkingHours = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLeaveTimeReducing_OverHours { 
			get {
				return _IsLeaveTimeReducing_OverHours;
			}
			set {
				if(_IsLeaveTimeReducing_OverHours != value){
					_IsLeaveTimeReducing_OverHours = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsLeaveTimeReducing_OverDays { 
			get {
				return _IsLeaveTimeReducing_OverDays;
			}
			set {
				if(_IsLeaveTimeReducing_OverDays != value){
					_IsLeaveTimeReducing_OverDays = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || Name.IsDirty || Description.IsDirty ;
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
								loader.Append(Name,TableName);
								loader.Append(Description,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_STA.CMN_BPT_STA_AbsenceReason.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_STA.CMN_BPT_STA_AbsenceReason.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_BPT_STA_AbsenceReasonID", _CMN_BPT_STA_AbsenceReasonID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ShortName", _ShortName);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Name", _Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Description", _Description.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "AbsenceReason_Type_RefID", _AbsenceReason_Type_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ColorCode", _ColorCode);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Parent_RefID", _Parent_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAuthorizationRequired", _IsAuthorizationRequired);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsIncludedInCapacityCalculation", _IsIncludedInCapacityCalculation);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAllowedAbsence", _IsAllowedAbsence);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeactivated", _IsDeactivated);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCarryOverEnabled", _IsCarryOverEnabled);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCaryOverLimited", _IsCaryOverLimited);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfCarryOverLimited_MaximumAmount_Hrs", _IfCarryOverLimited_MaximumAmount_Hrs);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLeaveTimeReducing_WorkingHours", _IsLeaveTimeReducing_WorkingHours);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLeaveTimeReducing_OverHours", _IsLeaveTimeReducing_OverHours);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsLeaveTimeReducing_OverDays", _IsLeaveTimeReducing_OverDays);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_BPT_STA.CMN_BPT_STA_AbsenceReason.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_BPT_STA_AbsenceReasonID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_STA_AbsenceReasonID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_STA_AbsenceReasonID","ShortName","Name_DictID","Description_DictID","AbsenceReason_Type_RefID","ColorCode","Parent_RefID","IsAuthorizationRequired","IsIncludedInCapacityCalculation","IsAllowedAbsence","IsDeactivated","IsCarryOverEnabled","IsCaryOverLimited","IfCarryOverLimited_MaximumAmount_Hrs","IsLeaveTimeReducing_WorkingHours","IsLeaveTimeReducing_OverHours","IsLeaveTimeReducing_OverDays","Creation_Timestamp","Tenant_RefID","IsDeleted" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_BPT_STA_AbsenceReasonID of type Guid
						_CMN_BPT_STA_AbsenceReasonID = reader.GetGuid(0);
						//1:Parameter ShortName of type String
						_ShortName = reader.GetString(1);
						//2:Parameter Name of type Dict
						_Name = reader.GetDictionary(2);
						loader.Append(_Name,TableName);
						//3:Parameter Description of type Dict
						_Description = reader.GetDictionary(3);
						loader.Append(_Description,TableName);
						//4:Parameter AbsenceReason_Type_RefID of type Guid
						_AbsenceReason_Type_RefID = reader.GetGuid(4);
						//5:Parameter ColorCode of type String
						_ColorCode = reader.GetString(5);
						//6:Parameter Parent_RefID of type Guid
						_Parent_RefID = reader.GetGuid(6);
						//7:Parameter IsAuthorizationRequired of type Boolean
						_IsAuthorizationRequired = reader.GetBoolean(7);
						//8:Parameter IsIncludedInCapacityCalculation of type Boolean
						_IsIncludedInCapacityCalculation = reader.GetBoolean(8);
						//9:Parameter IsAllowedAbsence of type Boolean
						_IsAllowedAbsence = reader.GetBoolean(9);
						//10:Parameter IsDeactivated of type Boolean
						_IsDeactivated = reader.GetBoolean(10);
						//11:Parameter IsCarryOverEnabled of type Boolean
						_IsCarryOverEnabled = reader.GetBoolean(11);
						//12:Parameter IsCaryOverLimited of type Boolean
						_IsCaryOverLimited = reader.GetBoolean(12);
						//13:Parameter IfCarryOverLimited_MaximumAmount_Hrs of type Double
						_IfCarryOverLimited_MaximumAmount_Hrs = reader.GetDouble(13);
						//14:Parameter IsLeaveTimeReducing_WorkingHours of type Boolean
						_IsLeaveTimeReducing_WorkingHours = reader.GetBoolean(14);
						//15:Parameter IsLeaveTimeReducing_OverHours of type Boolean
						_IsLeaveTimeReducing_OverHours = reader.GetBoolean(15);
						//16:Parameter IsLeaveTimeReducing_OverDays of type Boolean
						_IsLeaveTimeReducing_OverDays = reader.GetBoolean(16);
						//17:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(17);
						//18:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(18);
						//19:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(19);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_BPT_STA_AbsenceReasonID != Guid.Empty){
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
			public Guid? CMN_BPT_STA_AbsenceReasonID {	get; set; }
			public String ShortName {	get; set; }
			public Dict Name {	get; set; }
			public Dict Description {	get; set; }
			public Guid? AbsenceReason_Type_RefID {	get; set; }
			public String ColorCode {	get; set; }
			public Guid? Parent_RefID {	get; set; }
			public Boolean? IsAuthorizationRequired {	get; set; }
			public Boolean? IsIncludedInCapacityCalculation {	get; set; }
			public Boolean? IsAllowedAbsence {	get; set; }
			public Boolean? IsDeactivated {	get; set; }
			public Boolean? IsCarryOverEnabled {	get; set; }
			public Boolean? IsCaryOverLimited {	get; set; }
			public Double? IfCarryOverLimited_MaximumAmount_Hrs {	get; set; }
			public Boolean? IsLeaveTimeReducing_WorkingHours {	get; set; }
			public Boolean? IsLeaveTimeReducing_OverHours {	get; set; }
			public Boolean? IsLeaveTimeReducing_OverDays {	get; set; }
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
					throw ex;
				}
			}
			#endregion

			#region Search
			public static List<ORM_CMN_BPT_STA_AbsenceReason> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_BPT_STA_AbsenceReason> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_BPT_STA_AbsenceReason> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_BPT_STA_AbsenceReason> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_BPT_STA_AbsenceReason> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_BPT_STA_AbsenceReason>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_BPT_STA_AbsenceReasonID","ShortName","Name_DictID","Description_DictID","AbsenceReason_Type_RefID","ColorCode","Parent_RefID","IsAuthorizationRequired","IsIncludedInCapacityCalculation","IsAllowedAbsence","IsDeactivated","IsCarryOverEnabled","IsCaryOverLimited","IfCarryOverLimited_MaximumAmount_Hrs","IsLeaveTimeReducing_WorkingHours","IsLeaveTimeReducing_OverHours","IsLeaveTimeReducing_OverDays","Creation_Timestamp","Tenant_RefID","IsDeleted" });
			        while (reader.Read())
			        {
			            ORM_CMN_BPT_STA_AbsenceReason item = new ORM_CMN_BPT_STA_AbsenceReason();
						//0:Parameter CMN_BPT_STA_AbsenceReasonID of type Guid
						item.CMN_BPT_STA_AbsenceReasonID = reader.GetGuid(0);
						//1:Parameter ShortName of type String
						item.ShortName = reader.GetString(1);
						//2:Parameter Name of type Dict
						item.Name = reader.GetDictionary(2);
						loader.Append(item.Name,TableName);
						//3:Parameter Description of type Dict
						item.Description = reader.GetDictionary(3);
						loader.Append(item.Description,TableName);
						//4:Parameter AbsenceReason_Type_RefID of type Guid
						item.AbsenceReason_Type_RefID = reader.GetGuid(4);
						//5:Parameter ColorCode of type String
						item.ColorCode = reader.GetString(5);
						//6:Parameter Parent_RefID of type Guid
						item.Parent_RefID = reader.GetGuid(6);
						//7:Parameter IsAuthorizationRequired of type Boolean
						item.IsAuthorizationRequired = reader.GetBoolean(7);
						//8:Parameter IsIncludedInCapacityCalculation of type Boolean
						item.IsIncludedInCapacityCalculation = reader.GetBoolean(8);
						//9:Parameter IsAllowedAbsence of type Boolean
						item.IsAllowedAbsence = reader.GetBoolean(9);
						//10:Parameter IsDeactivated of type Boolean
						item.IsDeactivated = reader.GetBoolean(10);
						//11:Parameter IsCarryOverEnabled of type Boolean
						item.IsCarryOverEnabled = reader.GetBoolean(11);
						//12:Parameter IsCaryOverLimited of type Boolean
						item.IsCaryOverLimited = reader.GetBoolean(12);
						//13:Parameter IfCarryOverLimited_MaximumAmount_Hrs of type Double
						item.IfCarryOverLimited_MaximumAmount_Hrs = reader.GetDouble(13);
						//14:Parameter IsLeaveTimeReducing_WorkingHours of type Boolean
						item.IsLeaveTimeReducing_WorkingHours = reader.GetBoolean(14);
						//15:Parameter IsLeaveTimeReducing_OverHours of type Boolean
						item.IsLeaveTimeReducing_OverHours = reader.GetBoolean(15);
						//16:Parameter IsLeaveTimeReducing_OverDays of type Boolean
						item.IsLeaveTimeReducing_OverDays = reader.GetBoolean(16);
						//17:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(17);
						//18:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(18);
						//19:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(19);


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
