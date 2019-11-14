/* 
 * Generated on 06/02/15 11:09:23
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN_PRO
{
	[Serializable]
	public class ORM_CMN_PRO_Product
	{
		public static readonly string TableName = "cmn_pro_products";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_PRO_Product()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_PRO_ProductID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_PRO_ProductID = default(Guid);
		private String _ProductITL = default(String);
		private Guid _ProductType_RefID = default(Guid);
		private Guid _Product_DocumentationStructure_RefID = default(Guid);
		private Dict _Product_Name = new Dict(TableName);
		private Dict _Product_Description = new Dict(TableName);
		private String _Product_Number = default(String);
		private Boolean _HasProductVariants = default(Boolean);
		private Guid _ProducingBusinessParticipant_RefID = default(Guid);
		private Guid _PackageInfo_RefID = default(Guid);
		private Boolean _IsProduct_Article = default(Boolean);
		private Boolean _IsProduct_Service = default(Boolean);
		private Boolean _IsPlaceholderArticle = default(Boolean);
		private Guid _ProductSuccessor_RefID = default(Guid);
		private Boolean _IsImportedFromExternalCatalog = default(Boolean);
		private long _DefaultExpirationPeriod_in_sec = default(long);
		private double _DefaultStorageTemperature_max_in_kelvin = default(double);
		private double _DefaultStorageTemperature_min_in_kelvin = default(double);
		private Guid _IfImportedFromExternalCatalog_CatalogSubscription_RefID = default(Guid);
		private Boolean _IsProductAvailableForOrdering = default(Boolean);
		private Boolean _IsStorage_CoolingRequired = default(Boolean);
		private Boolean _IsStorage_BatchNumberMandatory = default(Boolean);
		private Boolean _IsStorage_SerialNumberMandatory = default(Boolean);
		private Boolean _IsStorage_ExpiryDateMandatory = default(Boolean);
		private int _OutboundPickingPrinciple = default(int);
		private Boolean _IsDeleted = default(Boolean);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsProductPartOfDefaultStock = default(Boolean);
		private String _ProductAdditionalInfoXML = default(String);
		private Guid _Counting_Unit_RefID = default(Guid);
		private Boolean _IsObsolete = default(Boolean);
		private Boolean _IsProductForInternalDistributionOnly = default(Boolean);
		private Boolean _IsProductHiddenFromDisplay = default(Boolean);
		private Boolean _IsCustomizable = default(Boolean);
		private Boolean _IsProducable_Internally = default(Boolean);
		private DateTime _Creation_Timestamp = default(DateTime);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_PRO_ProductID { 
			get {
				return _CMN_PRO_ProductID;
			}
			set {
				if(_CMN_PRO_ProductID != value){
					_CMN_PRO_ProductID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ProductITL { 
			get {
				return _ProductITL;
			}
			set {
				if(_ProductITL != value){
					_ProductITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ProductType_RefID { 
			get {
				return _ProductType_RefID;
			}
			set {
				if(_ProductType_RefID != value){
					_ProductType_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Product_DocumentationStructure_RefID { 
			get {
				return _Product_DocumentationStructure_RefID;
			}
			set {
				if(_Product_DocumentationStructure_RefID != value){
					_Product_DocumentationStructure_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Product_Name { 
			get {
				return _Product_Name;
			}
			set {
				if(_Product_Name != value){
					_Product_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Dict Product_Description { 
			get {
				return _Product_Description;
			}
			set {
				if(_Product_Description != value){
					_Product_Description = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Product_Number { 
			get {
				return _Product_Number;
			}
			set {
				if(_Product_Number != value){
					_Product_Number = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean HasProductVariants { 
			get {
				return _HasProductVariants;
			}
			set {
				if(_HasProductVariants != value){
					_HasProductVariants = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ProducingBusinessParticipant_RefID { 
			get {
				return _ProducingBusinessParticipant_RefID;
			}
			set {
				if(_ProducingBusinessParticipant_RefID != value){
					_ProducingBusinessParticipant_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid PackageInfo_RefID { 
			get {
				return _PackageInfo_RefID;
			}
			set {
				if(_PackageInfo_RefID != value){
					_PackageInfo_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsProduct_Article { 
			get {
				return _IsProduct_Article;
			}
			set {
				if(_IsProduct_Article != value){
					_IsProduct_Article = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsProduct_Service { 
			get {
				return _IsProduct_Service;
			}
			set {
				if(_IsProduct_Service != value){
					_IsProduct_Service = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsPlaceholderArticle { 
			get {
				return _IsPlaceholderArticle;
			}
			set {
				if(_IsPlaceholderArticle != value){
					_IsPlaceholderArticle = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid ProductSuccessor_RefID { 
			get {
				return _ProductSuccessor_RefID;
			}
			set {
				if(_ProductSuccessor_RefID != value){
					_ProductSuccessor_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsImportedFromExternalCatalog { 
			get {
				return _IsImportedFromExternalCatalog;
			}
			set {
				if(_IsImportedFromExternalCatalog != value){
					_IsImportedFromExternalCatalog = value;
					Status_IsDirty = true;
				}
			}
		} 
		public long DefaultExpirationPeriod_in_sec { 
			get {
				return _DefaultExpirationPeriod_in_sec;
			}
			set {
				if(_DefaultExpirationPeriod_in_sec != value){
					_DefaultExpirationPeriod_in_sec = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double DefaultStorageTemperature_max_in_kelvin { 
			get {
				return _DefaultStorageTemperature_max_in_kelvin;
			}
			set {
				if(_DefaultStorageTemperature_max_in_kelvin != value){
					_DefaultStorageTemperature_max_in_kelvin = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double DefaultStorageTemperature_min_in_kelvin { 
			get {
				return _DefaultStorageTemperature_min_in_kelvin;
			}
			set {
				if(_DefaultStorageTemperature_min_in_kelvin != value){
					_DefaultStorageTemperature_min_in_kelvin = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid IfImportedFromExternalCatalog_CatalogSubscription_RefID { 
			get {
				return _IfImportedFromExternalCatalog_CatalogSubscription_RefID;
			}
			set {
				if(_IfImportedFromExternalCatalog_CatalogSubscription_RefID != value){
					_IfImportedFromExternalCatalog_CatalogSubscription_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsProductAvailableForOrdering { 
			get {
				return _IsProductAvailableForOrdering;
			}
			set {
				if(_IsProductAvailableForOrdering != value){
					_IsProductAvailableForOrdering = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStorage_CoolingRequired { 
			get {
				return _IsStorage_CoolingRequired;
			}
			set {
				if(_IsStorage_CoolingRequired != value){
					_IsStorage_CoolingRequired = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStorage_BatchNumberMandatory { 
			get {
				return _IsStorage_BatchNumberMandatory;
			}
			set {
				if(_IsStorage_BatchNumberMandatory != value){
					_IsStorage_BatchNumberMandatory = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStorage_SerialNumberMandatory { 
			get {
				return _IsStorage_SerialNumberMandatory;
			}
			set {
				if(_IsStorage_SerialNumberMandatory != value){
					_IsStorage_SerialNumberMandatory = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsStorage_ExpiryDateMandatory { 
			get {
				return _IsStorage_ExpiryDateMandatory;
			}
			set {
				if(_IsStorage_ExpiryDateMandatory != value){
					_IsStorage_ExpiryDateMandatory = value;
					Status_IsDirty = true;
				}
			}
		} 
		public int OutboundPickingPrinciple { 
			get {
				return _OutboundPickingPrinciple;
			}
			set {
				if(_OutboundPickingPrinciple != value){
					_OutboundPickingPrinciple = value;
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
		public Boolean IsProductPartOfDefaultStock { 
			get {
				return _IsProductPartOfDefaultStock;
			}
			set {
				if(_IsProductPartOfDefaultStock != value){
					_IsProductPartOfDefaultStock = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ProductAdditionalInfoXML { 
			get {
				return _ProductAdditionalInfoXML;
			}
			set {
				if(_ProductAdditionalInfoXML != value){
					_ProductAdditionalInfoXML = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Counting_Unit_RefID { 
			get {
				return _Counting_Unit_RefID;
			}
			set {
				if(_Counting_Unit_RefID != value){
					_Counting_Unit_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsObsolete { 
			get {
				return _IsObsolete;
			}
			set {
				if(_IsObsolete != value){
					_IsObsolete = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsProductForInternalDistributionOnly { 
			get {
				return _IsProductForInternalDistributionOnly;
			}
			set {
				if(_IsProductForInternalDistributionOnly != value){
					_IsProductForInternalDistributionOnly = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsProductHiddenFromDisplay { 
			get {
				return _IsProductHiddenFromDisplay;
			}
			set {
				if(_IsProductHiddenFromDisplay != value){
					_IsProductHiddenFromDisplay = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCustomizable { 
			get {
				return _IsCustomizable;
			}
			set {
				if(_IsCustomizable != value){
					_IsCustomizable = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsProducable_Internally { 
			get {
				return _IsProducable_Internally;
			}
			set {
				if(_IsProducable_Internally != value){
					_IsProducable_Internally = value;
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

				bool saveDictionary = !Status_IsAlreadySaved || Product_Name.IsDirty || Product_Description.IsDirty ;
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
								loader.Append(Product_Name,TableName);
								loader.Append(Product_Description,TableName);

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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PRO.CMN_PRO_Product.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PRO.CMN_PRO_Product.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_PRO_ProductID", _CMN_PRO_ProductID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProductITL", _ProductITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProductType_RefID", _ProductType_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Product_DocumentationStructure_RefID", _Product_DocumentationStructure_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Product_Name", _Product_Name.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Product_Description", _Product_Description.DictionaryID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Product_Number", _Product_Number);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "HasProductVariants", _HasProductVariants);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProducingBusinessParticipant_RefID", _ProducingBusinessParticipant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PackageInfo_RefID", _PackageInfo_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsProduct_Article", _IsProduct_Article);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsProduct_Service", _IsProduct_Service);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsPlaceholderArticle", _IsPlaceholderArticle);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProductSuccessor_RefID", _ProductSuccessor_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsImportedFromExternalCatalog", _IsImportedFromExternalCatalog);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DefaultExpirationPeriod_in_sec", _DefaultExpirationPeriod_in_sec);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DefaultStorageTemperature_max_in_kelvin", _DefaultStorageTemperature_max_in_kelvin);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "DefaultStorageTemperature_min_in_kelvin", _DefaultStorageTemperature_min_in_kelvin);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IfImportedFromExternalCatalog_CatalogSubscription_RefID", _IfImportedFromExternalCatalog_CatalogSubscription_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsProductAvailableForOrdering", _IsProductAvailableForOrdering);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStorage_CoolingRequired", _IsStorage_CoolingRequired);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStorage_BatchNumberMandatory", _IsStorage_BatchNumberMandatory);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStorage_SerialNumberMandatory", _IsStorage_SerialNumberMandatory);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsStorage_ExpiryDateMandatory", _IsStorage_ExpiryDateMandatory);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "OutboundPickingPrinciple", _OutboundPickingPrinciple);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsDeleted", _IsDeleted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsProductPartOfDefaultStock", _IsProductPartOfDefaultStock);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ProductAdditionalInfoXML", _ProductAdditionalInfoXML);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Counting_Unit_RefID", _Counting_Unit_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsObsolete", _IsObsolete);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsProductForInternalDistributionOnly", _IsProductForInternalDistributionOnly);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsProductHiddenFromDisplay", _IsProductHiddenFromDisplay);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCustomizable", _IsCustomizable);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsProducable_Internally", _IsProducable_Internally);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN_PRO.CMN_PRO_Product.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_PRO_ProductID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_PRO_ProductID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","ProductITL","ProductType_RefID","Product_DocumentationStructure_RefID","Product_Name_DictID","Product_Description_DictID","Product_Number","HasProductVariants","ProducingBusinessParticipant_RefID","PackageInfo_RefID","IsProduct_Article","IsProduct_Service","IsPlaceholderArticle","ProductSuccessor_RefID","IsImportedFromExternalCatalog","DefaultExpirationPeriod_in_sec","DefaultStorageTemperature_max_in_kelvin","DefaultStorageTemperature_min_in_kelvin","IfImportedFromExternalCatalog_CatalogSubscription_RefID","IsProductAvailableForOrdering","IsStorage_CoolingRequired","IsStorage_BatchNumberMandatory","IsStorage_SerialNumberMandatory","IsStorage_ExpiryDateMandatory","OutboundPickingPrinciple","IsDeleted","Tenant_RefID","IsProductPartOfDefaultStock","ProductAdditionalInfoXML","Counting_Unit_RefID","IsObsolete","IsProductForInternalDistributionOnly","IsProductHiddenFromDisplay","IsCustomizable","IsProducable_Internally","Creation_Timestamp","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_PRO_ProductID of type Guid
						_CMN_PRO_ProductID = reader.GetGuid(0);
						//1:Parameter ProductITL of type String
						_ProductITL = reader.GetString(1);
						//2:Parameter ProductType_RefID of type Guid
						_ProductType_RefID = reader.GetGuid(2);
						//3:Parameter Product_DocumentationStructure_RefID of type Guid
						_Product_DocumentationStructure_RefID = reader.GetGuid(3);
						//4:Parameter Product_Name of type Dict
						_Product_Name = reader.GetDictionary(4);
						loader.Append(_Product_Name,TableName);
						//5:Parameter Product_Description of type Dict
						_Product_Description = reader.GetDictionary(5);
						loader.Append(_Product_Description,TableName);
						//6:Parameter Product_Number of type String
						_Product_Number = reader.GetString(6);
						//7:Parameter HasProductVariants of type Boolean
						_HasProductVariants = reader.GetBoolean(7);
						//8:Parameter ProducingBusinessParticipant_RefID of type Guid
						_ProducingBusinessParticipant_RefID = reader.GetGuid(8);
						//9:Parameter PackageInfo_RefID of type Guid
						_PackageInfo_RefID = reader.GetGuid(9);
						//10:Parameter IsProduct_Article of type Boolean
						_IsProduct_Article = reader.GetBoolean(10);
						//11:Parameter IsProduct_Service of type Boolean
						_IsProduct_Service = reader.GetBoolean(11);
						//12:Parameter IsPlaceholderArticle of type Boolean
						_IsPlaceholderArticle = reader.GetBoolean(12);
						//13:Parameter ProductSuccessor_RefID of type Guid
						_ProductSuccessor_RefID = reader.GetGuid(13);
						//14:Parameter IsImportedFromExternalCatalog of type Boolean
						_IsImportedFromExternalCatalog = reader.GetBoolean(14);
						//15:Parameter DefaultExpirationPeriod_in_sec of type long
						_DefaultExpirationPeriod_in_sec = reader.GetLong(15);
						//16:Parameter DefaultStorageTemperature_max_in_kelvin of type double
						_DefaultStorageTemperature_max_in_kelvin = reader.GetDouble(16);
						//17:Parameter DefaultStorageTemperature_min_in_kelvin of type double
						_DefaultStorageTemperature_min_in_kelvin = reader.GetDouble(17);
						//18:Parameter IfImportedFromExternalCatalog_CatalogSubscription_RefID of type Guid
						_IfImportedFromExternalCatalog_CatalogSubscription_RefID = reader.GetGuid(18);
						//19:Parameter IsProductAvailableForOrdering of type Boolean
						_IsProductAvailableForOrdering = reader.GetBoolean(19);
						//20:Parameter IsStorage_CoolingRequired of type Boolean
						_IsStorage_CoolingRequired = reader.GetBoolean(20);
						//21:Parameter IsStorage_BatchNumberMandatory of type Boolean
						_IsStorage_BatchNumberMandatory = reader.GetBoolean(21);
						//22:Parameter IsStorage_SerialNumberMandatory of type Boolean
						_IsStorage_SerialNumberMandatory = reader.GetBoolean(22);
						//23:Parameter IsStorage_ExpiryDateMandatory of type Boolean
						_IsStorage_ExpiryDateMandatory = reader.GetBoolean(23);
						//24:Parameter OutboundPickingPrinciple of type int
						_OutboundPickingPrinciple = reader.GetInteger(24);
						//25:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(25);
						//26:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(26);
						//27:Parameter IsProductPartOfDefaultStock of type Boolean
						_IsProductPartOfDefaultStock = reader.GetBoolean(27);
						//28:Parameter ProductAdditionalInfoXML of type String
						_ProductAdditionalInfoXML = reader.GetString(28);
						//29:Parameter Counting_Unit_RefID of type Guid
						_Counting_Unit_RefID = reader.GetGuid(29);
						//30:Parameter IsObsolete of type Boolean
						_IsObsolete = reader.GetBoolean(30);
						//31:Parameter IsProductForInternalDistributionOnly of type Boolean
						_IsProductForInternalDistributionOnly = reader.GetBoolean(31);
						//32:Parameter IsProductHiddenFromDisplay of type Boolean
						_IsProductHiddenFromDisplay = reader.GetBoolean(32);
						//33:Parameter IsCustomizable of type Boolean
						_IsCustomizable = reader.GetBoolean(33);
						//34:Parameter IsProducable_Internally of type Boolean
						_IsProducable_Internally = reader.GetBoolean(34);
						//35:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(35);
						//36:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(36);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_PRO_ProductID != Guid.Empty){
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
			public Guid? CMN_PRO_ProductID {	get; set; }
			public String ProductITL {	get; set; }
			public Guid? ProductType_RefID {	get; set; }
			public Guid? Product_DocumentationStructure_RefID {	get; set; }
			public Dict Product_Name {	get; set; }
			public Dict Product_Description {	get; set; }
			public String Product_Number {	get; set; }
			public Boolean? HasProductVariants {	get; set; }
			public Guid? ProducingBusinessParticipant_RefID {	get; set; }
			public Guid? PackageInfo_RefID {	get; set; }
			public Boolean? IsProduct_Article {	get; set; }
			public Boolean? IsProduct_Service {	get; set; }
			public Boolean? IsPlaceholderArticle {	get; set; }
			public Guid? ProductSuccessor_RefID {	get; set; }
			public Boolean? IsImportedFromExternalCatalog {	get; set; }
			public long? DefaultExpirationPeriod_in_sec {	get; set; }
			public double? DefaultStorageTemperature_max_in_kelvin {	get; set; }
			public double? DefaultStorageTemperature_min_in_kelvin {	get; set; }
			public Guid? IfImportedFromExternalCatalog_CatalogSubscription_RefID {	get; set; }
			public Boolean? IsProductAvailableForOrdering {	get; set; }
			public Boolean? IsStorage_CoolingRequired {	get; set; }
			public Boolean? IsStorage_BatchNumberMandatory {	get; set; }
			public Boolean? IsStorage_SerialNumberMandatory {	get; set; }
			public Boolean? IsStorage_ExpiryDateMandatory {	get; set; }
			public int? OutboundPickingPrinciple {	get; set; }
			public Boolean? IsDeleted {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public Boolean? IsProductPartOfDefaultStock {	get; set; }
			public String ProductAdditionalInfoXML {	get; set; }
			public Guid? Counting_Unit_RefID {	get; set; }
			public Boolean? IsObsolete {	get; set; }
			public Boolean? IsProductForInternalDistributionOnly {	get; set; }
			public Boolean? IsProductHiddenFromDisplay {	get; set; }
			public Boolean? IsCustomizable {	get; set; }
			public Boolean? IsProducable_Internally {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
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
			public static List<ORM_CMN_PRO_Product> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_PRO_Product> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_PRO_Product> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_PRO_Product> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_PRO_Product> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_PRO_Product>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","ProductITL","ProductType_RefID","Product_DocumentationStructure_RefID","Product_Name_DictID","Product_Description_DictID","Product_Number","HasProductVariants","ProducingBusinessParticipant_RefID","PackageInfo_RefID","IsProduct_Article","IsProduct_Service","IsPlaceholderArticle","ProductSuccessor_RefID","IsImportedFromExternalCatalog","DefaultExpirationPeriod_in_sec","DefaultStorageTemperature_max_in_kelvin","DefaultStorageTemperature_min_in_kelvin","IfImportedFromExternalCatalog_CatalogSubscription_RefID","IsProductAvailableForOrdering","IsStorage_CoolingRequired","IsStorage_BatchNumberMandatory","IsStorage_SerialNumberMandatory","IsStorage_ExpiryDateMandatory","OutboundPickingPrinciple","IsDeleted","Tenant_RefID","IsProductPartOfDefaultStock","ProductAdditionalInfoXML","Counting_Unit_RefID","IsObsolete","IsProductForInternalDistributionOnly","IsProductHiddenFromDisplay","IsCustomizable","IsProducable_Internally","Creation_Timestamp","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_CMN_PRO_Product item = new ORM_CMN_PRO_Product();
						//0:Parameter CMN_PRO_ProductID of type Guid
						item.CMN_PRO_ProductID = reader.GetGuid(0);
						//1:Parameter ProductITL of type String
						item.ProductITL = reader.GetString(1);
						//2:Parameter ProductType_RefID of type Guid
						item.ProductType_RefID = reader.GetGuid(2);
						//3:Parameter Product_DocumentationStructure_RefID of type Guid
						item.Product_DocumentationStructure_RefID = reader.GetGuid(3);
						//4:Parameter Product_Name of type Dict
						item.Product_Name = reader.GetDictionary(4);
						loader.Append(item.Product_Name,TableName);
						//5:Parameter Product_Description of type Dict
						item.Product_Description = reader.GetDictionary(5);
						loader.Append(item.Product_Description,TableName);
						//6:Parameter Product_Number of type String
						item.Product_Number = reader.GetString(6);
						//7:Parameter HasProductVariants of type Boolean
						item.HasProductVariants = reader.GetBoolean(7);
						//8:Parameter ProducingBusinessParticipant_RefID of type Guid
						item.ProducingBusinessParticipant_RefID = reader.GetGuid(8);
						//9:Parameter PackageInfo_RefID of type Guid
						item.PackageInfo_RefID = reader.GetGuid(9);
						//10:Parameter IsProduct_Article of type Boolean
						item.IsProduct_Article = reader.GetBoolean(10);
						//11:Parameter IsProduct_Service of type Boolean
						item.IsProduct_Service = reader.GetBoolean(11);
						//12:Parameter IsPlaceholderArticle of type Boolean
						item.IsPlaceholderArticle = reader.GetBoolean(12);
						//13:Parameter ProductSuccessor_RefID of type Guid
						item.ProductSuccessor_RefID = reader.GetGuid(13);
						//14:Parameter IsImportedFromExternalCatalog of type Boolean
						item.IsImportedFromExternalCatalog = reader.GetBoolean(14);
						//15:Parameter DefaultExpirationPeriod_in_sec of type long
						item.DefaultExpirationPeriod_in_sec = reader.GetLong(15);
						//16:Parameter DefaultStorageTemperature_max_in_kelvin of type double
						item.DefaultStorageTemperature_max_in_kelvin = reader.GetDouble(16);
						//17:Parameter DefaultStorageTemperature_min_in_kelvin of type double
						item.DefaultStorageTemperature_min_in_kelvin = reader.GetDouble(17);
						//18:Parameter IfImportedFromExternalCatalog_CatalogSubscription_RefID of type Guid
						item.IfImportedFromExternalCatalog_CatalogSubscription_RefID = reader.GetGuid(18);
						//19:Parameter IsProductAvailableForOrdering of type Boolean
						item.IsProductAvailableForOrdering = reader.GetBoolean(19);
						//20:Parameter IsStorage_CoolingRequired of type Boolean
						item.IsStorage_CoolingRequired = reader.GetBoolean(20);
						//21:Parameter IsStorage_BatchNumberMandatory of type Boolean
						item.IsStorage_BatchNumberMandatory = reader.GetBoolean(21);
						//22:Parameter IsStorage_SerialNumberMandatory of type Boolean
						item.IsStorage_SerialNumberMandatory = reader.GetBoolean(22);
						//23:Parameter IsStorage_ExpiryDateMandatory of type Boolean
						item.IsStorage_ExpiryDateMandatory = reader.GetBoolean(23);
						//24:Parameter OutboundPickingPrinciple of type int
						item.OutboundPickingPrinciple = reader.GetInteger(24);
						//25:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(25);
						//26:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(26);
						//27:Parameter IsProductPartOfDefaultStock of type Boolean
						item.IsProductPartOfDefaultStock = reader.GetBoolean(27);
						//28:Parameter ProductAdditionalInfoXML of type String
						item.ProductAdditionalInfoXML = reader.GetString(28);
						//29:Parameter Counting_Unit_RefID of type Guid
						item.Counting_Unit_RefID = reader.GetGuid(29);
						//30:Parameter IsObsolete of type Boolean
						item.IsObsolete = reader.GetBoolean(30);
						//31:Parameter IsProductForInternalDistributionOnly of type Boolean
						item.IsProductForInternalDistributionOnly = reader.GetBoolean(31);
						//32:Parameter IsProductHiddenFromDisplay of type Boolean
						item.IsProductHiddenFromDisplay = reader.GetBoolean(32);
						//33:Parameter IsCustomizable of type Boolean
						item.IsCustomizable = reader.GetBoolean(33);
						//34:Parameter IsProducable_Internally of type Boolean
						item.IsProducable_Internally = reader.GetBoolean(34);
						//35:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(35);
						//36:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(36);


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
