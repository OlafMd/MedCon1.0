/* 
 * Generated on 2/4/2015 1:32:23 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC
{
	[Serializable]
	public class ORM_HEC_Patient_Treatment
	{
		public static readonly string TableName = "hec_patient_treatment";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_Patient_Treatment()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_Patient_TreatmentID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_Patient_TreatmentID = default(Guid);
		private Guid _PotentialTreatment_RefID = default(Guid);
		private String _TreatmentITL = default(String);
		private Boolean _IsTreatmentFollowup = default(Boolean);
		private Guid _IfTreatmentFollowup_FromTreatment_RefID = default(Guid);
		private Guid _TreatmentPractice_RefID = default(Guid);
		private Boolean _IsTreatmentPerformed = default(Boolean);
		private Guid _IfTreatmentPerformed_ByDoctor_RefID = default(Guid);
		private DateTime _IfTreatmentPerformed_Date = default(DateTime);
		private Boolean _IsScheduled = default(Boolean);
		private DateTime _IfSheduled_Date = default(DateTime);
		private Guid _IfSheduled_ForDoctor_RefID = default(Guid);
		private Boolean _IsTreatmentBilled = default(Boolean);
		private DateTime _IfTreatmentBilled_Date = default(DateTime);
		private String _Treatment_Comment = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_Patient_TreatmentID { 
			get {
				return _HEC_Patient_TreatmentID;
			}
			set {
				if(_HEC_Patient_TreatmentID != value){
					_HEC_Patient_TreatmentID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid PotentialTreatment_RefID { 
			get {
				return _PotentialTreatment_RefID;
			}
			set {
				if(_PotentialTreatment_RefID != value){
					_PotentialTreatment_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String TreatmentITL { 
			get {
				return _TreatmentITL;
			}
			set {
				if(_TreatmentITL != value){
					_TreatmentITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsTreatmentFollowup { 
			get {
				return _IsTreatmentFollowup;
			}
			set {
				if(_IsTreatmentFollowup != value){
					_IsTreatmentFollowup = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfTreatmentFollowup_FromTreatment_RefID { 
			get {
				return _IfTreatmentFollowup_FromTreatment_RefID;
			}
			set {
				if(_IfTreatmentFollowup_FromTreatment_RefID != value){
					_IfTreatmentFollowup_FromTreatment_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid TreatmentPractice_RefID { 
			get {
				return _TreatmentPractice_RefID;
			}
			set {
				if(_TreatmentPractice_RefID != value){
					_TreatmentPractice_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsTreatmentPerformed { 
			get {
				return _IsTreatmentPerformed;
			}
			set {
				if(_IsTreatmentPerformed != value){
					_IsTreatmentPerformed = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfTreatmentPerformed_ByDoctor_RefID { 
			get {
				return _IfTreatmentPerformed_ByDoctor_RefID;
			}
			set {
				if(_IfTreatmentPerformed_ByDoctor_RefID != value){
					_IfTreatmentPerformed_ByDoctor_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime IfTreatmentPerformed_Date { 
			get {
				return _IfTreatmentPerformed_Date;
			}
			set {
				if(_IfTreatmentPerformed_Date != value){
					_IfTreatmentPerformed_Date = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsScheduled { 
			get {
				return _IsScheduled;
			}
			set {
				if(_IsScheduled != value){
					_IsScheduled = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime IfSheduled_Date { 
			get {
				return _IfSheduled_Date;
			}
			set {
				if(_IfSheduled_Date != value){
					_IfSheduled_Date = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfSheduled_ForDoctor_RefID { 
			get {
				return _IfSheduled_ForDoctor_RefID;
			}
			set {
				if(_IfSheduled_ForDoctor_RefID != value){
					_IfSheduled_ForDoctor_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsTreatmentBilled { 
			get {
				return _IsTreatmentBilled;
			}
			set {
				if(_IsTreatmentBilled != value){
					_IsTreatmentBilled = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime IfTreatmentBilled_Date { 
			get {
				return _IfTreatmentBilled_Date;
			}
			set {
				if(_IfTreatmentBilled_Date != value){
					_IfTreatmentBilled_Date = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Treatment_Comment { 
			get {
				return _Treatment_Comment;
			}
			set {
				if(_Treatment_Comment != value){
					_Treatment_Comment = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Treatment.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Treatment.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_Patient_TreatmentID", _HEC_Patient_TreatmentID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PotentialTreatment_RefID", _PotentialTreatment_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TreatmentITL", _TreatmentITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsTreatmentFollowup", _IsTreatmentFollowup);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfTreatmentFollowup_FromTreatment_RefID", _IfTreatmentFollowup_FromTreatment_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "TreatmentPractice_RefID", _TreatmentPractice_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsTreatmentPerformed", _IsTreatmentPerformed);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfTreatmentPerformed_ByDoctor_RefID", _IfTreatmentPerformed_ByDoctor_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfTreatmentPerformed_Date", _IfTreatmentPerformed_Date);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsScheduled", _IsScheduled);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfSheduled_Date", _IfSheduled_Date);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfSheduled_ForDoctor_RefID", _IfSheduled_ForDoctor_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsTreatmentBilled", _IsTreatmentBilled);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfTreatmentBilled_Date", _IfTreatmentBilled_Date);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Treatment_Comment", _Treatment_Comment);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Treatment.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_Patient_TreatmentID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_Patient_TreatmentID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_Patient_TreatmentID","PotentialTreatment_RefID","TreatmentITL","IsTreatmentFollowup","IfTreatmentFollowup_FromTreatment_RefID","TreatmentPractice_RefID","IsTreatmentPerformed","IfTreatmentPerformed_ByDoctor_RefID","IfTreatmentPerformed_Date","IsScheduled","IfSheduled_Date","IfSheduled_ForDoctor_RefID","IsTreatmentBilled","IfTreatmentBilled_Date","Treatment_Comment","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_Patient_TreatmentID of type Guid
						_HEC_Patient_TreatmentID = reader.GetGuid(0);
						//1:Parameter PotentialTreatment_RefID of type Guid
						_PotentialTreatment_RefID = reader.GetGuid(1);
						//2:Parameter TreatmentITL of type String
						_TreatmentITL = reader.GetString(2);
						//3:Parameter IsTreatmentFollowup of type Boolean
						_IsTreatmentFollowup = reader.GetBoolean(3);
						//4:Parameter IfTreatmentFollowup_FromTreatment_RefID of type Guid
						_IfTreatmentFollowup_FromTreatment_RefID = reader.GetGuid(4);
						//5:Parameter TreatmentPractice_RefID of type Guid
						_TreatmentPractice_RefID = reader.GetGuid(5);
						//6:Parameter IsTreatmentPerformed of type Boolean
						_IsTreatmentPerformed = reader.GetBoolean(6);
						//7:Parameter IfTreatmentPerformed_ByDoctor_RefID of type Guid
						_IfTreatmentPerformed_ByDoctor_RefID = reader.GetGuid(7);
						//8:Parameter IfTreatmentPerformed_Date of type DateTime
						_IfTreatmentPerformed_Date = reader.GetDate(8);
						//9:Parameter IsScheduled of type Boolean
						_IsScheduled = reader.GetBoolean(9);
						//10:Parameter IfSheduled_Date of type DateTime
						_IfSheduled_Date = reader.GetDate(10);
						//11:Parameter IfSheduled_ForDoctor_RefID of type Guid
						_IfSheduled_ForDoctor_RefID = reader.GetGuid(11);
						//12:Parameter IsTreatmentBilled of type Boolean
						_IsTreatmentBilled = reader.GetBoolean(12);
						//13:Parameter IfTreatmentBilled_Date of type DateTime
						_IfTreatmentBilled_Date = reader.GetDate(13);
						//14:Parameter Treatment_Comment of type String
						_Treatment_Comment = reader.GetString(14);
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

					if(_HEC_Patient_TreatmentID != Guid.Empty){
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
			public Guid? HEC_Patient_TreatmentID {	get; set; }
			public Guid? PotentialTreatment_RefID {	get; set; }
			public String TreatmentITL {	get; set; }
			public Boolean? IsTreatmentFollowup {	get; set; }
			public Guid? IfTreatmentFollowup_FromTreatment_RefID {	get; set; }
			public Guid? TreatmentPractice_RefID {	get; set; }
			public Boolean? IsTreatmentPerformed {	get; set; }
			public Guid? IfTreatmentPerformed_ByDoctor_RefID {	get; set; }
			public DateTime? IfTreatmentPerformed_Date {	get; set; }
			public Boolean? IsScheduled {	get; set; }
			public DateTime? IfSheduled_Date {	get; set; }
			public Guid? IfSheduled_ForDoctor_RefID {	get; set; }
			public Boolean? IsTreatmentBilled {	get; set; }
			public DateTime? IfTreatmentBilled_Date {	get; set; }
			public String Treatment_Comment {	get; set; }
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
			public static List<ORM_HEC_Patient_Treatment> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_Patient_Treatment> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_Patient_Treatment> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_Patient_Treatment> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_Patient_Treatment> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_Patient_Treatment>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_Patient_TreatmentID","PotentialTreatment_RefID","TreatmentITL","IsTreatmentFollowup","IfTreatmentFollowup_FromTreatment_RefID","TreatmentPractice_RefID","IsTreatmentPerformed","IfTreatmentPerformed_ByDoctor_RefID","IfTreatmentPerformed_Date","IsScheduled","IfSheduled_Date","IfSheduled_ForDoctor_RefID","IsTreatmentBilled","IfTreatmentBilled_Date","Treatment_Comment","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_Patient_Treatment item = new ORM_HEC_Patient_Treatment();
						//0:Parameter HEC_Patient_TreatmentID of type Guid
						item.HEC_Patient_TreatmentID = reader.GetGuid(0);
						//1:Parameter PotentialTreatment_RefID of type Guid
						item.PotentialTreatment_RefID = reader.GetGuid(1);
						//2:Parameter TreatmentITL of type String
						item.TreatmentITL = reader.GetString(2);
						//3:Parameter IsTreatmentFollowup of type Boolean
						item.IsTreatmentFollowup = reader.GetBoolean(3);
						//4:Parameter IfTreatmentFollowup_FromTreatment_RefID of type Guid
						item.IfTreatmentFollowup_FromTreatment_RefID = reader.GetGuid(4);
						//5:Parameter TreatmentPractice_RefID of type Guid
						item.TreatmentPractice_RefID = reader.GetGuid(5);
						//6:Parameter IsTreatmentPerformed of type Boolean
						item.IsTreatmentPerformed = reader.GetBoolean(6);
						//7:Parameter IfTreatmentPerformed_ByDoctor_RefID of type Guid
						item.IfTreatmentPerformed_ByDoctor_RefID = reader.GetGuid(7);
						//8:Parameter IfTreatmentPerformed_Date of type DateTime
						item.IfTreatmentPerformed_Date = reader.GetDate(8);
						//9:Parameter IsScheduled of type Boolean
						item.IsScheduled = reader.GetBoolean(9);
						//10:Parameter IfSheduled_Date of type DateTime
						item.IfSheduled_Date = reader.GetDate(10);
						//11:Parameter IfSheduled_ForDoctor_RefID of type Guid
						item.IfSheduled_ForDoctor_RefID = reader.GetGuid(11);
						//12:Parameter IsTreatmentBilled of type Boolean
						item.IsTreatmentBilled = reader.GetBoolean(12);
						//13:Parameter IfTreatmentBilled_Date of type DateTime
						item.IfTreatmentBilled_Date = reader.GetDate(13);
						//14:Parameter Treatment_Comment of type String
						item.Treatment_Comment = reader.GetString(14);
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
