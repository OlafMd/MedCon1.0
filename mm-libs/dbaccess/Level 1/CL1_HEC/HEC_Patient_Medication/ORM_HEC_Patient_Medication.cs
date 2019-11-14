/* 
 * Generated on 12/11/2014 3:19:21 PM
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
	public class ORM_HEC_Patient_Medication
	{
		public static readonly string TableName = "hec_patient_medications";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_Patient_Medication()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_Patient_MedicationID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_Patient_MedicationID = default(Guid);
		private Guid _Patient_RefID = default(Guid);
		private Boolean _R_IsActive = default(Boolean);
		private DateTime _R_ActiveUntill = default(DateTime);
		private DateTime _R_DateOfAdding = default(DateTime);
		private DateTime _R_DateOfRemoval = default(DateTime);
		private Boolean _R_IsHealthcareProduct = default(Boolean);
		private Guid _R_HEC_Product_RefID = default(Guid);
		private Boolean _R_IsSubstance = default(Boolean);
		private String _R_IfSubstance_Strength = default(String);
		private Guid _R_IfSubstance_Unit_RefID = default(Guid);
		private Guid _R_IfSubstance_Substance_RefiD = default(Guid);
		private String _R_DosageText = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_Patient_MedicationID { 
			get {
				return _HEC_Patient_MedicationID;
			}
			set {
				if(_HEC_Patient_MedicationID != value){
					_HEC_Patient_MedicationID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Patient_RefID { 
			get {
				return _Patient_RefID;
			}
			set {
				if(_Patient_RefID != value){
					_Patient_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean R_IsActive { 
			get {
				return _R_IsActive;
			}
			set {
				if(_R_IsActive != value){
					_R_IsActive = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime R_ActiveUntill { 
			get {
				return _R_ActiveUntill;
			}
			set {
				if(_R_ActiveUntill != value){
					_R_ActiveUntill = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime R_DateOfAdding { 
			get {
				return _R_DateOfAdding;
			}
			set {
				if(_R_DateOfAdding != value){
					_R_DateOfAdding = value;
					Status_IsDirty = true;
				}
			}
		} 
		public DateTime R_DateOfRemoval { 
			get {
				return _R_DateOfRemoval;
			}
			set {
				if(_R_DateOfRemoval != value){
					_R_DateOfRemoval = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean R_IsHealthcareProduct { 
			get {
				return _R_IsHealthcareProduct;
			}
			set {
				if(_R_IsHealthcareProduct != value){
					_R_IsHealthcareProduct = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid R_HEC_Product_RefID { 
			get {
				return _R_HEC_Product_RefID;
			}
			set {
				if(_R_HEC_Product_RefID != value){
					_R_HEC_Product_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean R_IsSubstance { 
			get {
				return _R_IsSubstance;
			}
			set {
				if(_R_IsSubstance != value){
					_R_IsSubstance = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String R_IfSubstance_Strength { 
			get {
				return _R_IfSubstance_Strength;
			}
			set {
				if(_R_IfSubstance_Strength != value){
					_R_IfSubstance_Strength = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid R_IfSubstance_Unit_RefID { 
			get {
				return _R_IfSubstance_Unit_RefID;
			}
			set {
				if(_R_IfSubstance_Unit_RefID != value){
					_R_IfSubstance_Unit_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid R_IfSubstance_Substance_RefiD { 
			get {
				return _R_IfSubstance_Substance_RefiD;
			}
			set {
				if(_R_IfSubstance_Substance_RefiD != value){
					_R_IfSubstance_Substance_RefiD = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String R_DosageText { 
			get {
				return _R_DosageText;
			}
			set {
				if(_R_DosageText != value){
					_R_DosageText = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Medication.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Medication.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_Patient_MedicationID", _HEC_Patient_MedicationID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Patient_RefID", _Patient_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_IsActive", _R_IsActive);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_ActiveUntill", _R_ActiveUntill);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_DateOfAdding", _R_DateOfAdding);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_DateOfRemoval", _R_DateOfRemoval);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_IsHealthcareProduct", _R_IsHealthcareProduct);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_HEC_Product_RefID", _R_HEC_Product_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_IsSubstance", _R_IsSubstance);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_IfSubstance_Strength", _R_IfSubstance_Strength);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_IfSubstance_Unit_RefID", _R_IfSubstance_Unit_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_IfSubstance_Substance_RefiD", _R_IfSubstance_Substance_RefiD);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "R_DosageText", _R_DosageText);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Medication.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_Patient_MedicationID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_Patient_MedicationID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_Patient_MedicationID","Patient_RefID","R_IsActive","R_ActiveUntill","R_DateOfAdding","R_DateOfRemoval","R_IsHealthcareProduct","R_HEC_Product_RefID","R_IsSubstance","R_IfSubstance_Strength","R_IfSubstance_Unit_RefID","R_IfSubstance_Substance_RefiD","R_DosageText","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_Patient_MedicationID of type Guid
						_HEC_Patient_MedicationID = reader.GetGuid(0);
						//1:Parameter Patient_RefID of type Guid
						_Patient_RefID = reader.GetGuid(1);
						//2:Parameter R_IsActive of type Boolean
						_R_IsActive = reader.GetBoolean(2);
						//3:Parameter R_ActiveUntill of type DateTime
						_R_ActiveUntill = reader.GetDate(3);
						//4:Parameter R_DateOfAdding of type DateTime
						_R_DateOfAdding = reader.GetDate(4);
						//5:Parameter R_DateOfRemoval of type DateTime
						_R_DateOfRemoval = reader.GetDate(5);
						//6:Parameter R_IsHealthcareProduct of type Boolean
						_R_IsHealthcareProduct = reader.GetBoolean(6);
						//7:Parameter R_HEC_Product_RefID of type Guid
						_R_HEC_Product_RefID = reader.GetGuid(7);
						//8:Parameter R_IsSubstance of type Boolean
						_R_IsSubstance = reader.GetBoolean(8);
						//9:Parameter R_IfSubstance_Strength of type String
						_R_IfSubstance_Strength = reader.GetString(9);
						//10:Parameter R_IfSubstance_Unit_RefID of type Guid
						_R_IfSubstance_Unit_RefID = reader.GetGuid(10);
						//11:Parameter R_IfSubstance_Substance_RefiD of type Guid
						_R_IfSubstance_Substance_RefiD = reader.GetGuid(11);
						//12:Parameter R_DosageText of type String
						_R_DosageText = reader.GetString(12);
						//13:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(15);
						//16:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(16);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_Patient_MedicationID != Guid.Empty){
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
			public Guid? HEC_Patient_MedicationID {	get; set; }
			public Guid? Patient_RefID {	get; set; }
			public Boolean? R_IsActive {	get; set; }
			public DateTime? R_ActiveUntill {	get; set; }
			public DateTime? R_DateOfAdding {	get; set; }
			public DateTime? R_DateOfRemoval {	get; set; }
			public Boolean? R_IsHealthcareProduct {	get; set; }
			public Guid? R_HEC_Product_RefID {	get; set; }
			public Boolean? R_IsSubstance {	get; set; }
			public String R_IfSubstance_Strength {	get; set; }
			public Guid? R_IfSubstance_Unit_RefID {	get; set; }
			public Guid? R_IfSubstance_Substance_RefiD {	get; set; }
			public String R_DosageText {	get; set; }
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
			public static List<ORM_HEC_Patient_Medication> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_Patient_Medication> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_Patient_Medication> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_Patient_Medication> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_Patient_Medication> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_Patient_Medication>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_Patient_MedicationID","Patient_RefID","R_IsActive","R_ActiveUntill","R_DateOfAdding","R_DateOfRemoval","R_IsHealthcareProduct","R_HEC_Product_RefID","R_IsSubstance","R_IfSubstance_Strength","R_IfSubstance_Unit_RefID","R_IfSubstance_Substance_RefiD","R_DosageText","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_Patient_Medication item = new ORM_HEC_Patient_Medication();
						//0:Parameter HEC_Patient_MedicationID of type Guid
						item.HEC_Patient_MedicationID = reader.GetGuid(0);
						//1:Parameter Patient_RefID of type Guid
						item.Patient_RefID = reader.GetGuid(1);
						//2:Parameter R_IsActive of type Boolean
						item.R_IsActive = reader.GetBoolean(2);
						//3:Parameter R_ActiveUntill of type DateTime
						item.R_ActiveUntill = reader.GetDate(3);
						//4:Parameter R_DateOfAdding of type DateTime
						item.R_DateOfAdding = reader.GetDate(4);
						//5:Parameter R_DateOfRemoval of type DateTime
						item.R_DateOfRemoval = reader.GetDate(5);
						//6:Parameter R_IsHealthcareProduct of type Boolean
						item.R_IsHealthcareProduct = reader.GetBoolean(6);
						//7:Parameter R_HEC_Product_RefID of type Guid
						item.R_HEC_Product_RefID = reader.GetGuid(7);
						//8:Parameter R_IsSubstance of type Boolean
						item.R_IsSubstance = reader.GetBoolean(8);
						//9:Parameter R_IfSubstance_Strength of type String
						item.R_IfSubstance_Strength = reader.GetString(9);
						//10:Parameter R_IfSubstance_Unit_RefID of type Guid
						item.R_IfSubstance_Unit_RefID = reader.GetGuid(10);
						//11:Parameter R_IfSubstance_Substance_RefiD of type Guid
						item.R_IfSubstance_Substance_RefiD = reader.GetGuid(11);
						//12:Parameter R_DosageText of type String
						item.R_DosageText = reader.GetString(12);
						//13:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(13);
						//14:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(14);
						//15:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(15);
						//16:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(16);


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
