/* 
 * Generated on 11/13/2014 3:38:53 PM
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
	public class ORM_HEC_Patient_Prescription_Position
	{
		public static readonly string TableName = "hec_patient_prescription_positions";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_Patient_Prescription_Position()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_Patient_Prescription_PositionID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_Patient_Prescription_PositionID = default(Guid);
		private Guid _PrescriptionHeader_RefID = default(Guid);
		private Guid _HEC_Product_RefID = default(Guid);
		private Guid _ProductProvidingPharmacy_RefID = default(Guid);
		private Guid _BoundTo_CustomerOrderPosition_RefID = default(Guid);
		private Guid _IfSubstance_Substance_RefiD = default(Guid);
		private Boolean _IsSubstance = default(Boolean);
		private Boolean _IsHealthcareProduct = default(Boolean);
		private string _IfSubstance_Unit = default(string);
		private Guid _InitializedFrom_PatientMedication_RefID = default(Guid);
		private string _IfSubstance_Strength = default(string);
		private string _DosageText = default(string);
		private Guid _Dosage_RefID = default(Guid);
		private DateTime _Modification_Timestamp = default(DateTime);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_Patient_Prescription_PositionID { 
			get {
				return _HEC_Patient_Prescription_PositionID;
			}
			set {
				if(_HEC_Patient_Prescription_PositionID != value){
					_HEC_Patient_Prescription_PositionID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid PrescriptionHeader_RefID { 
			get {
				return _PrescriptionHeader_RefID;
			}
			set {
				if(_PrescriptionHeader_RefID != value){
					_PrescriptionHeader_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid HEC_Product_RefID { 
			get {
				return _HEC_Product_RefID;
			}
			set {
				if(_HEC_Product_RefID != value){
					_HEC_Product_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ProductProvidingPharmacy_RefID { 
			get {
				return _ProductProvidingPharmacy_RefID;
			}
			set {
				if(_ProductProvidingPharmacy_RefID != value){
					_ProductProvidingPharmacy_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid BoundTo_CustomerOrderPosition_RefID { 
			get {
				return _BoundTo_CustomerOrderPosition_RefID;
			}
			set {
				if(_BoundTo_CustomerOrderPosition_RefID != value){
					_BoundTo_CustomerOrderPosition_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfSubstance_Substance_RefiD { 
			get {
				return _IfSubstance_Substance_RefiD;
			}
			set {
				if(_IfSubstance_Substance_RefiD != value){
					_IfSubstance_Substance_RefiD = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsSubstance { 
			get {
				return _IsSubstance;
			}
			set {
				if(_IsSubstance != value){
					_IsSubstance = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsHealthcareProduct { 
			get {
				return _IsHealthcareProduct;
			}
			set {
				if(_IsHealthcareProduct != value){
					_IsHealthcareProduct = value;
					Status_IsDirty = true;
				}
			}
		} 
		public string IfSubstance_Unit { 
			get {
				return _IfSubstance_Unit;
			}
			set {
				if(_IfSubstance_Unit != value){
					_IfSubstance_Unit = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid InitializedFrom_PatientMedication_RefID { 
			get {
				return _InitializedFrom_PatientMedication_RefID;
			}
			set {
				if(_InitializedFrom_PatientMedication_RefID != value){
					_InitializedFrom_PatientMedication_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public string IfSubstance_Strength { 
			get {
				return _IfSubstance_Strength;
			}
			set {
				if(_IfSubstance_Strength != value){
					_IfSubstance_Strength = value;
					Status_IsDirty = true;
				}
			}
		} 
		public string DosageText { 
			get {
				return _DosageText;
			}
			set {
				if(_DosageText != value){
					_DosageText = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Dosage_RefID { 
			get {
				return _Dosage_RefID;
			}
			set {
				if(_Dosage_RefID != value){
					_Dosage_RefID = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Prescription_Position.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Prescription_Position.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_Patient_Prescription_PositionID", _HEC_Patient_Prescription_PositionID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PrescriptionHeader_RefID", _PrescriptionHeader_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_Product_RefID", _HEC_Product_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProductProvidingPharmacy_RefID", _ProductProvidingPharmacy_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "BoundTo_CustomerOrderPosition_RefID", _BoundTo_CustomerOrderPosition_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfSubstance_Substance_RefiD", _IfSubstance_Substance_RefiD);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsSubstance", _IsSubstance);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsHealthcareProduct", _IsHealthcareProduct);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfSubstance_Unit", _IfSubstance_Unit);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "InitializedFrom_PatientMedication_RefID", _InitializedFrom_PatientMedication_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfSubstance_Strength", _IfSubstance_Strength);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DosageText", _DosageText);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Dosage_RefID", _Dosage_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Modification_Timestamp", _Modification_Timestamp);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC.HEC_Patient_Prescription_Position.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_Patient_Prescription_PositionID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_Patient_Prescription_PositionID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_Patient_Prescription_PositionID","PrescriptionHeader_RefID","HEC_Product_RefID","ProductProvidingPharmacy_RefID","BoundTo_CustomerOrderPosition_RefID","IfSubstance_Substance_RefiD","IsSubstance","IsHealthcareProduct","IfSubstance_Unit","InitializedFrom_PatientMedication_RefID","IfSubstance_Strength","DosageText","Dosage_RefID","Modification_Timestamp","Creation_Timestamp","IsDeleted","Tenant_RefID" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_Patient_Prescription_PositionID of type Guid
						_HEC_Patient_Prescription_PositionID = reader.GetGuid(0);
						//1:Parameter PrescriptionHeader_RefID of type Guid
						_PrescriptionHeader_RefID = reader.GetGuid(1);
						//2:Parameter HEC_Product_RefID of type Guid
						_HEC_Product_RefID = reader.GetGuid(2);
						//3:Parameter ProductProvidingPharmacy_RefID of type Guid
						_ProductProvidingPharmacy_RefID = reader.GetGuid(3);
						//4:Parameter BoundTo_CustomerOrderPosition_RefID of type Guid
						_BoundTo_CustomerOrderPosition_RefID = reader.GetGuid(4);
						//5:Parameter IfSubstance_Substance_RefiD of type Guid
						_IfSubstance_Substance_RefiD = reader.GetGuid(5);
						//6:Parameter IsSubstance of type Boolean
						_IsSubstance = reader.GetBoolean(6);
						//7:Parameter IsHealthcareProduct of type Boolean
						_IsHealthcareProduct = reader.GetBoolean(7);
						//8:Parameter IfSubstance_Unit of type string
						_IfSubstance_Unit = reader.GetString(8);
						//9:Parameter InitializedFrom_PatientMedication_RefID of type Guid
						_InitializedFrom_PatientMedication_RefID = reader.GetGuid(9);
						//10:Parameter IfSubstance_Strength of type string
						_IfSubstance_Strength = reader.GetString(10);
						//11:Parameter DosageText of type string
						_DosageText = reader.GetString(11);
						//12:Parameter Dosage_RefID of type Guid
						_Dosage_RefID = reader.GetGuid(12);
						//13:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(13);
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

					if(_HEC_Patient_Prescription_PositionID != Guid.Empty){
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
			public Guid? HEC_Patient_Prescription_PositionID {	get; set; }
			public Guid? PrescriptionHeader_RefID {	get; set; }
			public Guid? HEC_Product_RefID {	get; set; }
			public Guid? ProductProvidingPharmacy_RefID {	get; set; }
			public Guid? BoundTo_CustomerOrderPosition_RefID {	get; set; }
			public Guid? IfSubstance_Substance_RefiD {	get; set; }
			public Boolean? IsSubstance {	get; set; }
			public Boolean? IsHealthcareProduct {	get; set; }
			public string IfSubstance_Unit {	get; set; }
			public Guid? InitializedFrom_PatientMedication_RefID {	get; set; }
			public string IfSubstance_Strength {	get; set; }
			public string DosageText {	get; set; }
			public Guid? Dosage_RefID {	get; set; }
			public DateTime? Modification_Timestamp {	get; set; }
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
					throw;
				}
			}
			#endregion

			#region Search
			public static List<ORM_HEC_Patient_Prescription_Position> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_Patient_Prescription_Position> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_Patient_Prescription_Position> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_Patient_Prescription_Position> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_Patient_Prescription_Position> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_Patient_Prescription_Position>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_Patient_Prescription_PositionID","PrescriptionHeader_RefID","HEC_Product_RefID","ProductProvidingPharmacy_RefID","BoundTo_CustomerOrderPosition_RefID","IfSubstance_Substance_RefiD","IsSubstance","IsHealthcareProduct","IfSubstance_Unit","InitializedFrom_PatientMedication_RefID","IfSubstance_Strength","DosageText","Dosage_RefID","Modification_Timestamp","Creation_Timestamp","IsDeleted","Tenant_RefID" });
			        while (reader.Read())
			        {
			            ORM_HEC_Patient_Prescription_Position item = new ORM_HEC_Patient_Prescription_Position();
						//0:Parameter HEC_Patient_Prescription_PositionID of type Guid
						item.HEC_Patient_Prescription_PositionID = reader.GetGuid(0);
						//1:Parameter PrescriptionHeader_RefID of type Guid
						item.PrescriptionHeader_RefID = reader.GetGuid(1);
						//2:Parameter HEC_Product_RefID of type Guid
						item.HEC_Product_RefID = reader.GetGuid(2);
						//3:Parameter ProductProvidingPharmacy_RefID of type Guid
						item.ProductProvidingPharmacy_RefID = reader.GetGuid(3);
						//4:Parameter BoundTo_CustomerOrderPosition_RefID of type Guid
						item.BoundTo_CustomerOrderPosition_RefID = reader.GetGuid(4);
						//5:Parameter IfSubstance_Substance_RefiD of type Guid
						item.IfSubstance_Substance_RefiD = reader.GetGuid(5);
						//6:Parameter IsSubstance of type Boolean
						item.IsSubstance = reader.GetBoolean(6);
						//7:Parameter IsHealthcareProduct of type Boolean
						item.IsHealthcareProduct = reader.GetBoolean(7);
						//8:Parameter IfSubstance_Unit of type string
						item.IfSubstance_Unit = reader.GetString(8);
						//9:Parameter InitializedFrom_PatientMedication_RefID of type Guid
						item.InitializedFrom_PatientMedication_RefID = reader.GetGuid(9);
						//10:Parameter IfSubstance_Strength of type string
						item.IfSubstance_Strength = reader.GetString(10);
						//11:Parameter DosageText of type string
						item.DosageText = reader.GetString(11);
						//12:Parameter Dosage_RefID of type Guid
						item.Dosage_RefID = reader.GetGuid(12);
						//13:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(13);
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
