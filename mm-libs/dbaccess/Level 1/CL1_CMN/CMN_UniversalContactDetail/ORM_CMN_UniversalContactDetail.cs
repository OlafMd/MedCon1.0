/* 
 * Generated on 12/23/2014 4:40:45 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;

namespace CL1_CMN
{
	[Serializable]
	public class ORM_CMN_UniversalContactDetail
	{
		public static readonly string TableName = "cmn_universalcontactdetails";
		public bool Status_IsAlreadySaved { get; set; }
		public bool Status_IsDirty { get; set; }
		public static readonly int QueryTimeout = 60;

		#region Class Constructor
		public ORM_CMN_UniversalContactDetail()
		{
			Status_IsAlreadySaved = false;
			Status_IsDirty = false;
			//When creating a new class, generate a new UUID
			_CMN_UniversalContactDetailID = Guid.NewGuid();
			_IsDeleted = false;
			_Creation_Timestamp = DateTime.Now;
		}
		#endregion

		#region Class Fields - Private
		private Guid _CMN_UniversalContactDetailID = default(Guid);
		private String _UniversalContactDetailsITL = default(String);
		private Guid _Region_RefID = default(Guid);
		private Boolean _IsCompany = default(Boolean);
		private String _CompanyName_Line1 = default(String);
		private String _CompanyName_Line2 = default(String);
		private String _WorkDescription = default(String);
		private String _Salutation = default(String);
		private String _Title = default(String);
		private String _First_Name = default(String);
		private String _Last_Name = default(String);
		private String _CareOf = default(String);
		private String _Country_Name = default(String);
		private String _Country_639_1_ISOCode = default(String);
		private String _Region_Name = default(String);
		private String _Region_Code = default(String);
		private String _Street_Name = default(String);
		private String _Street_Number = default(String);
		private String _Street_Name_Line2 = default(String);
		private String _Street_Number_Line2 = default(String);
		private String _PostalAddress_Number = default(String);
		private String _PostalAddress_Formatted = default(String);
		private String _ZIP = default(String);
		private String _Town = default(String);
		private String _Contact_Email = default(String);
		private String _Contact_Telephone = default(String);
		private String _Contact_Fax = default(String);
		private String _Contact_Website_URL = default(String);
		private Guid _Tenant_RefID = default(Guid);
		private Boolean _IsReadOnly = default(Boolean);
		private double _Lattitude = default(double);
		private double _Longitude = default(double);
		private String _POBox = default(String);
		private DateTime _Creation_Timestamp = default(DateTime);
		private Boolean _IsDeleted = default(Boolean);
		private DateTime _Modification_Timestamp = default(DateTime);
		 
		#endregion

		#region Class Fields - Public Get/Set
		public Guid CMN_UniversalContactDetailID { 
			get {
				return _CMN_UniversalContactDetailID;
			}
			set {
				if(_CMN_UniversalContactDetailID != value){
					_CMN_UniversalContactDetailID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String UniversalContactDetailsITL { 
			get {
				return _UniversalContactDetailsITL;
			}
			set {
				if(_UniversalContactDetailsITL != value){
					_UniversalContactDetailsITL = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Guid Region_RefID { 
			get {
				return _Region_RefID;
			}
			set {
				if(_Region_RefID != value){
					_Region_RefID = value;
					Status_IsDirty = true;
				}
			}
		} 
		public Boolean IsCompany { 
			get {
				return _IsCompany;
			}
			set {
				if(_IsCompany != value){
					_IsCompany = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CompanyName_Line1 { 
			get {
				return _CompanyName_Line1;
			}
			set {
				if(_CompanyName_Line1 != value){
					_CompanyName_Line1 = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CompanyName_Line2 { 
			get {
				return _CompanyName_Line2;
			}
			set {
				if(_CompanyName_Line2 != value){
					_CompanyName_Line2 = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String WorkDescription { 
			get {
				return _WorkDescription;
			}
			set {
				if(_WorkDescription != value){
					_WorkDescription = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Salutation { 
			get {
				return _Salutation;
			}
			set {
				if(_Salutation != value){
					_Salutation = value;
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
		public String First_Name { 
			get {
				return _First_Name;
			}
			set {
				if(_First_Name != value){
					_First_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Last_Name { 
			get {
				return _Last_Name;
			}
			set {
				if(_Last_Name != value){
					_Last_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String CareOf { 
			get {
				return _CareOf;
			}
			set {
				if(_CareOf != value){
					_CareOf = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Country_Name { 
			get {
				return _Country_Name;
			}
			set {
				if(_Country_Name != value){
					_Country_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Country_639_1_ISOCode { 
			get {
				return _Country_639_1_ISOCode;
			}
			set {
				if(_Country_639_1_ISOCode != value){
					_Country_639_1_ISOCode = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Region_Name { 
			get {
				return _Region_Name;
			}
			set {
				if(_Region_Name != value){
					_Region_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Region_Code { 
			get {
				return _Region_Code;
			}
			set {
				if(_Region_Code != value){
					_Region_Code = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Street_Name { 
			get {
				return _Street_Name;
			}
			set {
				if(_Street_Name != value){
					_Street_Name = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Street_Number { 
			get {
				return _Street_Number;
			}
			set {
				if(_Street_Number != value){
					_Street_Number = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Street_Name_Line2 { 
			get {
				return _Street_Name_Line2;
			}
			set {
				if(_Street_Name_Line2 != value){
					_Street_Name_Line2 = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Street_Number_Line2 { 
			get {
				return _Street_Number_Line2;
			}
			set {
				if(_Street_Number_Line2 != value){
					_Street_Number_Line2 = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String PostalAddress_Number { 
			get {
				return _PostalAddress_Number;
			}
			set {
				if(_PostalAddress_Number != value){
					_PostalAddress_Number = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String PostalAddress_Formatted { 
			get {
				return _PostalAddress_Formatted;
			}
			set {
				if(_PostalAddress_Formatted != value){
					_PostalAddress_Formatted = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String ZIP { 
			get {
				return _ZIP;
			}
			set {
				if(_ZIP != value){
					_ZIP = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Town { 
			get {
				return _Town;
			}
			set {
				if(_Town != value){
					_Town = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Contact_Email { 
			get {
				return _Contact_Email;
			}
			set {
				if(_Contact_Email != value){
					_Contact_Email = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Contact_Telephone { 
			get {
				return _Contact_Telephone;
			}
			set {
				if(_Contact_Telephone != value){
					_Contact_Telephone = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Contact_Fax { 
			get {
				return _Contact_Fax;
			}
			set {
				if(_Contact_Fax != value){
					_Contact_Fax = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String Contact_Website_URL { 
			get {
				return _Contact_Website_URL;
			}
			set {
				if(_Contact_Website_URL != value){
					_Contact_Website_URL = value;
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
		public Boolean IsReadOnly { 
			get {
				return _IsReadOnly;
			}
			set {
				if(_IsReadOnly != value){
					_IsReadOnly = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double Lattitude { 
			get {
				return _Lattitude;
			}
			set {
				if(_Lattitude != value){
					_Lattitude = value;
					Status_IsDirty = true;
				}
			}
		} 
		public double Longitude { 
			get {
				return _Longitude;
			}
			set {
				if(_Longitude != value){
					_Longitude = value;
					Status_IsDirty = true;
				}
			}
		} 
		public String POBox { 
			get {
				return _POBox;
			}
			set {
				if(_POBox != value){
					_POBox = value;
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
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN.CMN_UniversalContactDetail.SQL.Update.sql")).ReadToEnd();
					}
					else
					{
						Query = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN.CMN_UniversalContactDetail.SQL.Insert.sql")).ReadToEnd();
					}

					DbCommand command = Connection.CreateCommand();
					command.Connection = Connection;
					command.Transaction = Transaction;
					command.CommandText = Query;
					command.CommandTimeout = QueryTimeout;

					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CMN_UniversalContactDetailID", _CMN_UniversalContactDetailID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "UniversalContactDetailsITL", _UniversalContactDetailsITL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Region_RefID", _Region_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsCompany", _IsCompany);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CompanyName_Line1", _CompanyName_Line1);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CompanyName_Line2", _CompanyName_Line2);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "WorkDescription", _WorkDescription);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Salutation", _Salutation);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Title", _Title);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "First_Name", _First_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Last_Name", _Last_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "CareOf", _CareOf);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Country_Name", _Country_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Country_639_1_ISOCode", _Country_639_1_ISOCode);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Region_Name", _Region_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Region_Code", _Region_Code);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Street_Name", _Street_Name);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Street_Number", _Street_Number);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Street_Name_Line2", _Street_Name_Line2);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Street_Number_Line2", _Street_Number_Line2);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PostalAddress_Number", _PostalAddress_Number);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "PostalAddress_Formatted", _PostalAddress_Formatted);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "ZIP", _ZIP);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Town", _Town);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Contact_Email", _Contact_Email);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Contact_Telephone", _Contact_Telephone);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Contact_Fax", _Contact_Fax);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Contact_Website_URL", _Contact_Website_URL);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Tenant_RefID", _Tenant_RefID);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "IsReadOnly", _IsReadOnly);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Lattitude", _Lattitude);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Longitude", _Longitude);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "POBox", _POBox);
					CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command, "Creation_Timestamp", _Creation_Timestamp);
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
				string SelectQuery = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("CL1_CMN.CMN_UniversalContactDetail.SQL.Select.sql")).ReadToEnd();

				DbCommand command = Connection.CreateCommand();
				//Set Connection/Transaction
				command.Connection = Connection;
				command.Transaction = Transaction;
				//Set Query/Timeout
				command.CommandText =  SelectQuery;
				command.CommandTimeout = QueryTimeout;

				//Firstly, before loading, set the GUID to empty
				//So the entity does not exist, it will have a GUID set to empty
				_CMN_UniversalContactDetailID = Guid.Empty;
				CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_UniversalContactDetailID", ObjectID );

				#region Command Execution
				try
				{
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
					var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_UniversalContactDetailID","UniversalContactDetailsITL","Region_RefID","IsCompany","CompanyName_Line1","CompanyName_Line2","WorkDescription","Salutation","Title","First_Name","Last_Name","CareOf","Country_Name","Country_639_1_ISOCode","Region_Name","Region_Code","Street_Name","Street_Number","Street_Name_Line2","Street_Number_Line2","PostalAddress_Number","PostalAddress_Formatted","ZIP","Town","Contact_Email","Contact_Telephone","Contact_Fax","Contact_Website_URL","Tenant_RefID","IsReadOnly","Lattitude","Longitude","POBox","Creation_Timestamp","IsDeleted","Modification_Timestamp" });
					if (reader.HasRows == true)
					{
						reader.Read(); //Single result only
						//0:Parameter CMN_UniversalContactDetailID of type Guid
						_CMN_UniversalContactDetailID = reader.GetGuid(0);
						//1:Parameter UniversalContactDetailsITL of type String
						_UniversalContactDetailsITL = reader.GetString(1);
						//2:Parameter Region_RefID of type Guid
						_Region_RefID = reader.GetGuid(2);
						//3:Parameter IsCompany of type Boolean
						_IsCompany = reader.GetBoolean(3);
						//4:Parameter CompanyName_Line1 of type String
						_CompanyName_Line1 = reader.GetString(4);
						//5:Parameter CompanyName_Line2 of type String
						_CompanyName_Line2 = reader.GetString(5);
						//6:Parameter WorkDescription of type String
						_WorkDescription = reader.GetString(6);
						//7:Parameter Salutation of type String
						_Salutation = reader.GetString(7);
						//8:Parameter Title of type String
						_Title = reader.GetString(8);
						//9:Parameter First_Name of type String
						_First_Name = reader.GetString(9);
						//10:Parameter Last_Name of type String
						_Last_Name = reader.GetString(10);
						//11:Parameter CareOf of type String
						_CareOf = reader.GetString(11);
						//12:Parameter Country_Name of type String
						_Country_Name = reader.GetString(12);
						//13:Parameter Country_639_1_ISOCode of type String
						_Country_639_1_ISOCode = reader.GetString(13);
						//14:Parameter Region_Name of type String
						_Region_Name = reader.GetString(14);
						//15:Parameter Region_Code of type String
						_Region_Code = reader.GetString(15);
						//16:Parameter Street_Name of type String
						_Street_Name = reader.GetString(16);
						//17:Parameter Street_Number of type String
						_Street_Number = reader.GetString(17);
						//18:Parameter Street_Name_Line2 of type String
						_Street_Name_Line2 = reader.GetString(18);
						//19:Parameter Street_Number_Line2 of type String
						_Street_Number_Line2 = reader.GetString(19);
						//20:Parameter PostalAddress_Number of type String
						_PostalAddress_Number = reader.GetString(20);
						//21:Parameter PostalAddress_Formatted of type String
						_PostalAddress_Formatted = reader.GetString(21);
						//22:Parameter ZIP of type String
						_ZIP = reader.GetString(22);
						//23:Parameter Town of type String
						_Town = reader.GetString(23);
						//24:Parameter Contact_Email of type String
						_Contact_Email = reader.GetString(24);
						//25:Parameter Contact_Telephone of type String
						_Contact_Telephone = reader.GetString(25);
						//26:Parameter Contact_Fax of type String
						_Contact_Fax = reader.GetString(26);
						//27:Parameter Contact_Website_URL of type String
						_Contact_Website_URL = reader.GetString(27);
						//28:Parameter Tenant_RefID of type Guid
						_Tenant_RefID = reader.GetGuid(28);
						//29:Parameter IsReadOnly of type Boolean
						_IsReadOnly = reader.GetBoolean(29);
						//30:Parameter Lattitude of type double
						_Lattitude = reader.GetDouble(30);
						//31:Parameter Longitude of type double
						_Longitude = reader.GetDouble(31);
						//32:Parameter POBox of type String
						_POBox = reader.GetString(32);
						//33:Parameter Creation_Timestamp of type DateTime
						_Creation_Timestamp = reader.GetDate(33);
						//34:Parameter IsDeleted of type Boolean
						_IsDeleted = reader.GetBoolean(34);
						//35:Parameter Modification_Timestamp of type DateTime
						_Modification_Timestamp = reader.GetDate(35);

					}
					//Close the reader so other connections can use it
					reader.Close();

					loader.Load();

					if(_CMN_UniversalContactDetailID != Guid.Empty){
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
			public Guid? CMN_UniversalContactDetailID {	get; set; }
			public String UniversalContactDetailsITL {	get; set; }
			public Guid? Region_RefID {	get; set; }
			public Boolean? IsCompany {	get; set; }
			public String CompanyName_Line1 {	get; set; }
			public String CompanyName_Line2 {	get; set; }
			public String WorkDescription {	get; set; }
			public String Salutation {	get; set; }
			public String Title {	get; set; }
			public String First_Name {	get; set; }
			public String Last_Name {	get; set; }
			public String CareOf {	get; set; }
			public String Country_Name {	get; set; }
			public String Country_639_1_ISOCode {	get; set; }
			public String Region_Name {	get; set; }
			public String Region_Code {	get; set; }
			public String Street_Name {	get; set; }
			public String Street_Number {	get; set; }
			public String Street_Name_Line2 {	get; set; }
			public String Street_Number_Line2 {	get; set; }
			public String PostalAddress_Number {	get; set; }
			public String PostalAddress_Formatted {	get; set; }
			public String ZIP {	get; set; }
			public String Town {	get; set; }
			public String Contact_Email {	get; set; }
			public String Contact_Telephone {	get; set; }
			public String Contact_Fax {	get; set; }
			public String Contact_Website_URL {	get; set; }
			public Guid? Tenant_RefID {	get; set; }
			public Boolean? IsReadOnly {	get; set; }
			public double? Lattitude {	get; set; }
			public double? Longitude {	get; set; }
			public String POBox {	get; set; }
			public DateTime? Creation_Timestamp {	get; set; }
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
			public static List<ORM_CMN_UniversalContactDetail> Search(string connectionString, Query query)
			{
			    return Query.Search(query, connectionString, null, null);
			}

			public static List<ORM_CMN_UniversalContactDetail> Search(DbConnection connection, Query query)
			{
			    return Query.Search(query, null, connection, null);
			}

			public static List<ORM_CMN_UniversalContactDetail> Search(DbConnection connection, DbTransaction transaction, Query query)
			{
			    return Query.Search(query, null, connection, transaction);
			}

			private static List<ORM_CMN_UniversalContactDetail> Search(Query query, string connectionString, DbConnection connection, DbTransaction transaction)
			{
				CSV2Core.Core.Interfaces.IManagedConnection managedConnection = new CSV2Core_MySQL.MySQLManagedConnection();
			    List<ORM_CMN_UniversalContactDetail> items;

				try
			    {
			        managedConnection.set(connectionString, connection, transaction);
					var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(managedConnection.getConnection(), managedConnection.getTransaction());

			        DbCommand command = managedConnection.manage(query.CreateSelectQuery(TableName));
			        query.SetParameters(command);

			        items = new List<ORM_CMN_UniversalContactDetail>();

			        var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
					reader.SetOrdinals(new string[] { "CMN_UniversalContactDetailID","UniversalContactDetailsITL","Region_RefID","IsCompany","CompanyName_Line1","CompanyName_Line2","WorkDescription","Salutation","Title","First_Name","Last_Name","CareOf","Country_Name","Country_639_1_ISOCode","Region_Name","Region_Code","Street_Name","Street_Number","Street_Name_Line2","Street_Number_Line2","PostalAddress_Number","PostalAddress_Formatted","ZIP","Town","Contact_Email","Contact_Telephone","Contact_Fax","Contact_Website_URL","Tenant_RefID","IsReadOnly","Lattitude","Longitude","POBox","Creation_Timestamp","IsDeleted","Modification_Timestamp" });
			        while (reader.Read())
			        {
			            ORM_CMN_UniversalContactDetail item = new ORM_CMN_UniversalContactDetail();
						//0:Parameter CMN_UniversalContactDetailID of type Guid
						item.CMN_UniversalContactDetailID = reader.GetGuid(0);
						//1:Parameter UniversalContactDetailsITL of type String
						item.UniversalContactDetailsITL = reader.GetString(1);
						//2:Parameter Region_RefID of type Guid
						item.Region_RefID = reader.GetGuid(2);
						//3:Parameter IsCompany of type Boolean
						item.IsCompany = reader.GetBoolean(3);
						//4:Parameter CompanyName_Line1 of type String
						item.CompanyName_Line1 = reader.GetString(4);
						//5:Parameter CompanyName_Line2 of type String
						item.CompanyName_Line2 = reader.GetString(5);
						//6:Parameter WorkDescription of type String
						item.WorkDescription = reader.GetString(6);
						//7:Parameter Salutation of type String
						item.Salutation = reader.GetString(7);
						//8:Parameter Title of type String
						item.Title = reader.GetString(8);
						//9:Parameter First_Name of type String
						item.First_Name = reader.GetString(9);
						//10:Parameter Last_Name of type String
						item.Last_Name = reader.GetString(10);
						//11:Parameter CareOf of type String
						item.CareOf = reader.GetString(11);
						//12:Parameter Country_Name of type String
						item.Country_Name = reader.GetString(12);
						//13:Parameter Country_639_1_ISOCode of type String
						item.Country_639_1_ISOCode = reader.GetString(13);
						//14:Parameter Region_Name of type String
						item.Region_Name = reader.GetString(14);
						//15:Parameter Region_Code of type String
						item.Region_Code = reader.GetString(15);
						//16:Parameter Street_Name of type String
						item.Street_Name = reader.GetString(16);
						//17:Parameter Street_Number of type String
						item.Street_Number = reader.GetString(17);
						//18:Parameter Street_Name_Line2 of type String
						item.Street_Name_Line2 = reader.GetString(18);
						//19:Parameter Street_Number_Line2 of type String
						item.Street_Number_Line2 = reader.GetString(19);
						//20:Parameter PostalAddress_Number of type String
						item.PostalAddress_Number = reader.GetString(20);
						//21:Parameter PostalAddress_Formatted of type String
						item.PostalAddress_Formatted = reader.GetString(21);
						//22:Parameter ZIP of type String
						item.ZIP = reader.GetString(22);
						//23:Parameter Town of type String
						item.Town = reader.GetString(23);
						//24:Parameter Contact_Email of type String
						item.Contact_Email = reader.GetString(24);
						//25:Parameter Contact_Telephone of type String
						item.Contact_Telephone = reader.GetString(25);
						//26:Parameter Contact_Fax of type String
						item.Contact_Fax = reader.GetString(26);
						//27:Parameter Contact_Website_URL of type String
						item.Contact_Website_URL = reader.GetString(27);
						//28:Parameter Tenant_RefID of type Guid
						item.Tenant_RefID = reader.GetGuid(28);
						//29:Parameter IsReadOnly of type Boolean
						item.IsReadOnly = reader.GetBoolean(29);
						//30:Parameter Lattitude of type double
						item.Lattitude = reader.GetDouble(30);
						//31:Parameter Longitude of type double
						item.Longitude = reader.GetDouble(31);
						//32:Parameter POBox of type String
						item.POBox = reader.GetString(32);
						//33:Parameter Creation_Timestamp of type DateTime
						item.Creation_Timestamp = reader.GetDate(33);
						//34:Parameter IsDeleted of type Boolean
						item.IsDeleted = reader.GetBoolean(34);
						//35:Parameter Modification_Timestamp of type DateTime
						item.Modification_Timestamp = reader.GetDate(35);


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
