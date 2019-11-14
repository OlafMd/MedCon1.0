/* 
 * Generated on 2/12/2015 11:24:49 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_HEC_SUB
{
	[Serializable]
	public class ORM_HEC_SUB_Substance
	{
		public static readonly string TableName = "hec_sub_substances";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_HEC_SUB_Substance()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_HEC_SUB_SubstanceID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _HEC_SUB_SubstanceID = default(Guid);
		private String _HealthcareSubstanceITL = default(String);
		private String _GlobalPropertyMatchingID = default(String);
		private int _NarcoticAppendixStatus = default(int);
		private int _CategoryByLawStatus = default(int);
		private Boolean _IsAntroposhopicalMedicine = default(Boolean);
		private Boolean _IsChemical = default(Boolean);
		private Boolean _IsHomeophaticMedicine = default(Boolean);
		private Boolean _IsCOSubstance = default(Boolean);
		private Boolean _IsExcipient = default(Boolean);
		private Boolean _IsFoodAdditive = default(Boolean);
		private Boolean _IsNaturalStimulant = default(Boolean);
		private Boolean _IsAgriculturePesticide = default(Boolean);
		private Boolean _IsPerscriptionRequired = default(Boolean);
		private Boolean _IsCosmeticSubstance = default(Boolean);
		private Boolean _IsActiveComponent = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid HEC_SUB_SubstanceID { 
			get {
				return _HEC_SUB_SubstanceID;
			}
			set {
				if(_HEC_SUB_SubstanceID != value){
					_HEC_SUB_SubstanceID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String HealthcareSubstanceITL { 
			get {
				return _HealthcareSubstanceITL;
			}
			set {
				if(_HealthcareSubstanceITL != value){
					_HealthcareSubstanceITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String GlobalPropertyMatchingID { 
			get {
				return _GlobalPropertyMatchingID;
			}
			set {
				if(_GlobalPropertyMatchingID != value){
					_GlobalPropertyMatchingID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int NarcoticAppendixStatus { 
			get {
				return _NarcoticAppendixStatus;
			}
			set {
				if(_NarcoticAppendixStatus != value){
					_NarcoticAppendixStatus = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int CategoryByLawStatus { 
			get {
				return _CategoryByLawStatus;
			}
			set {
				if(_CategoryByLawStatus != value){
					_CategoryByLawStatus = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAntroposhopicalMedicine { 
			get {
				return _IsAntroposhopicalMedicine;
			}
			set {
				if(_IsAntroposhopicalMedicine != value){
					_IsAntroposhopicalMedicine = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsChemical { 
			get {
				return _IsChemical;
			}
			set {
				if(_IsChemical != value){
					_IsChemical = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsHomeophaticMedicine { 
			get {
				return _IsHomeophaticMedicine;
			}
			set {
				if(_IsHomeophaticMedicine != value){
					_IsHomeophaticMedicine = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCOSubstance { 
			get {
				return _IsCOSubstance;
			}
			set {
				if(_IsCOSubstance != value){
					_IsCOSubstance = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsExcipient { 
			get {
				return _IsExcipient;
			}
			set {
				if(_IsExcipient != value){
					_IsExcipient = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsFoodAdditive { 
			get {
				return _IsFoodAdditive;
			}
			set {
				if(_IsFoodAdditive != value){
					_IsFoodAdditive = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsNaturalStimulant { 
			get {
				return _IsNaturalStimulant;
			}
			set {
				if(_IsNaturalStimulant != value){
					_IsNaturalStimulant = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsAgriculturePesticide { 
			get {
				return _IsAgriculturePesticide;
			}
			set {
				if(_IsAgriculturePesticide != value){
					_IsAgriculturePesticide = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPerscriptionRequired { 
			get {
				return _IsPerscriptionRequired;
			}
			set {
				if(_IsPerscriptionRequired != value){
					_IsPerscriptionRequired = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCosmeticSubstance { 
			get {
				return _IsCosmeticSubstance;
			}
			set {
				if(_IsCosmeticSubstance != value){
					_IsCosmeticSubstance = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsActiveComponent { 
			get {
				return _IsActiveComponent;
			}
			set {
				if(_IsActiveComponent != value){
					_IsActiveComponent = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_SUB.HEC_SUB_Substance.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_SUB.HEC_SUB_Substance.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HEC_SUB_SubstanceID", _HEC_SUB_SubstanceID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HealthcareSubstanceITL", _HealthcareSubstanceITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "GlobalPropertyMatchingID", _GlobalPropertyMatchingID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "NarcoticAppendixStatus", _NarcoticAppendixStatus);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CategoryByLawStatus", _CategoryByLawStatus);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAntroposhopicalMedicine", _IsAntroposhopicalMedicine);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsChemical", _IsChemical);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsHomeophaticMedicine", _IsHomeophaticMedicine);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCOSubstance", _IsCOSubstance);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsExcipient", _IsExcipient);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsFoodAdditive", _IsFoodAdditive);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsNaturalStimulant", _IsNaturalStimulant);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsAgriculturePesticide", _IsAgriculturePesticide);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPerscriptionRequired", _IsPerscriptionRequired);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCosmeticSubstance", _IsCosmeticSubstance);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsActiveComponent", _IsActiveComponent);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_HEC_SUB.HEC_SUB_Substance.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_HEC_SUB_SubstanceID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_SUB_SubstanceID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_SUB_SubstanceID","HealthcareSubstanceITL","GlobalPropertyMatchingID","NarcoticAppendixStatus","CategoryByLawStatus","IsAntroposhopicalMedicine","IsChemical","IsHomeophaticMedicine","IsCOSubstance","IsExcipient","IsFoodAdditive","IsNaturalStimulant","IsAgriculturePesticide","IsPerscriptionRequired","IsCosmeticSubstance","IsActiveComponent","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter HEC_SUB_SubstanceID of type Guid
						_HEC_SUB_SubstanceID = reader.GetGuid(0);
						//1:Parameter HealthcareSubstanceITL of type String
						_HealthcareSubstanceITL = reader.GetString(1);
						//2:Parameter GlobalPropertyMatchingID of type String
						_GlobalPropertyMatchingID = reader.GetString(2);
						//3:Parameter NarcoticAppendixStatus of type int
						_NarcoticAppendixStatus = reader.GetInteger(3);
						//4:Parameter CategoryByLawStatus of type int
						_CategoryByLawStatus = reader.GetInteger(4);
						//5:Parameter IsAntroposhopicalMedicine of type Boolean
						_IsAntroposhopicalMedicine = reader.GetBoolean(5);
						//6:Parameter IsChemical of type Boolean
						_IsChemical = reader.GetBoolean(6);
						//7:Parameter IsHomeophaticMedicine of type Boolean
						_IsHomeophaticMedicine = reader.GetBoolean(7);
						//8:Parameter IsCOSubstance of type Boolean
						_IsCOSubstance = reader.GetBoolean(8);
						//9:Parameter IsExcipient of type Boolean
						_IsExcipient = reader.GetBoolean(9);
						//10:Parameter IsFoodAdditive of type Boolean
						_IsFoodAdditive = reader.GetBoolean(10);
						//11:Parameter IsNaturalStimulant of type Boolean
						_IsNaturalStimulant = reader.GetBoolean(11);
						//12:Parameter IsAgriculturePesticide of type Boolean
						_IsAgriculturePesticide = reader.GetBoolean(12);
						//13:Parameter IsPerscriptionRequired of type Boolean
						_IsPerscriptionRequired = reader.GetBoolean(13);
						//14:Parameter IsCosmeticSubstance of type Boolean
						_IsCosmeticSubstance = reader.GetBoolean(14);
						//15:Parameter IsActiveComponent of type Boolean
						_IsActiveComponent = reader.GetBoolean(15);
						//16:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(16);
						//17:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(17);
						//18:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(18);
						//19:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(19);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_HEC_SUB_SubstanceID != Guid.Empty){
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
			public Guid? HEC_SUB_SubstanceID {	get; set; }
			public String HealthcareSubstanceITL {	get; set; }
			public String GlobalPropertyMatchingID {	get; set; }
			public int? NarcoticAppendixStatus {	get; set; }
			public int? CategoryByLawStatus {	get; set; }
			public Boolean? IsAntroposhopicalMedicine {	get; set; }
			public Boolean? IsChemical {	get; set; }
			public Boolean? IsHomeophaticMedicine {	get; set; }
			public Boolean? IsCOSubstance {	get; set; }
			public Boolean? IsExcipient {	get; set; }
			public Boolean? IsFoodAdditive {	get; set; }
			public Boolean? IsNaturalStimulant {	get; set; }
			public Boolean? IsAgriculturePesticide {	get; set; }
			public Boolean? IsPerscriptionRequired {	get; set; }
			public Boolean? IsCosmeticSubstance {	get; set; }
			public Boolean? IsActiveComponent {	get; set; }
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
			public static List<ORM_HEC_SUB_Substance> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_HEC_SUB_Substance> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_HEC_SUB_Substance> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_HEC_SUB_Substance> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_HEC_SUB_Substance> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_HEC_SUB_Substance>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "HEC_SUB_SubstanceID","HealthcareSubstanceITL","GlobalPropertyMatchingID","NarcoticAppendixStatus","CategoryByLawStatus","IsAntroposhopicalMedicine","IsChemical","IsHomeophaticMedicine","IsCOSubstance","IsExcipient","IsFoodAdditive","IsNaturalStimulant","IsAgriculturePesticide","IsPerscriptionRequired","IsCosmeticSubstance","IsActiveComponent","Creation_Timestamp","Tenant_RefID","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_HEC_SUB_Substance item = new ORM_HEC_SUB_Substance();
						//0:Parameter HEC_SUB_SubstanceID of type Guid
						item.HEC_SUB_SubstanceID = reader.GetGuid(0);
						//1:Parameter HealthcareSubstanceITL of type String
						item.HealthcareSubstanceITL = reader.GetString(1);
						//2:Parameter GlobalPropertyMatchingID of type String
						item.GlobalPropertyMatchingID = reader.GetString(2);
						//3:Parameter NarcoticAppendixStatus of type int
						item.NarcoticAppendixStatus = reader.GetInteger(3);
						//4:Parameter CategoryByLawStatus of type int
						item.CategoryByLawStatus = reader.GetInteger(4);
						//5:Parameter IsAntroposhopicalMedicine of type Boolean
						item.IsAntroposhopicalMedicine = reader.GetBoolean(5);
						//6:Parameter IsChemical of type Boolean
						item.IsChemical = reader.GetBoolean(6);
						//7:Parameter IsHomeophaticMedicine of type Boolean
						item.IsHomeophaticMedicine = reader.GetBoolean(7);
						//8:Parameter IsCOSubstance of type Boolean
						item.IsCOSubstance = reader.GetBoolean(8);
						//9:Parameter IsExcipient of type Boolean
						item.IsExcipient = reader.GetBoolean(9);
						//10:Parameter IsFoodAdditive of type Boolean
						item.IsFoodAdditive = reader.GetBoolean(10);
						//11:Parameter IsNaturalStimulant of type Boolean
						item.IsNaturalStimulant = reader.GetBoolean(11);
						//12:Parameter IsAgriculturePesticide of type Boolean
						item.IsAgriculturePesticide = reader.GetBoolean(12);
						//13:Parameter IsPerscriptionRequired of type Boolean
						item.IsPerscriptionRequired = reader.GetBoolean(13);
						//14:Parameter IsCosmeticSubstance of type Boolean
						item.IsCosmeticSubstance = reader.GetBoolean(14);
						//15:Parameter IsActiveComponent of type Boolean
						item.IsActiveComponent = reader.GetBoolean(15);
						//16:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(16);
						//17:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(17);
						//18:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(18);
						//19:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(19);


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
