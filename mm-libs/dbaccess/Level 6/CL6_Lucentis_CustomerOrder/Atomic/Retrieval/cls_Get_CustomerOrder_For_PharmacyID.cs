/* 
 * Generated on 3/6/2014 3:00:12 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL6_Lucentis_CustomerOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrder_For_PharmacyID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrder_For_PharmacyID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6CO_GCOFPID_1129_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6CO_GCOFPID_1129 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6CO_GCOFPID_1129_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_Lucentis_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_CustomerOrder_For_PharmacyID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PharmacyID", Parameter.PharmacyID);



			List<L6CO_GCOFPID_1129_raw> results = new List<L6CO_GCOFPID_1129_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Status_Code","Status_Name_DictID","ORD_CUO_CustomerOrder_StatusID","ORD_CUO_CustomerOrder_HeaderID","GlobalPropertyMatchingID","CustomerOrder_Number","CustomerOrder_Date","HEC_Patient_TreatmentID","HEC_Patient_Treatment_RequiredProductID","CMN_COM_CompanyInfoID","CMN_BPT_BusinessParticipantID","DisplayName","HEC_MedicalPractiseID","ExpectedDateOfDelivery","Product_Name_DictID","ORD_CUO_CustomerOrder_PositionID","CMN_PRO_ProductID","Position_OrdinalNumber","Position_Quantity","Position_ValuePerUnit","Position_ValueTotal","Position_Comment","Product_Number","Position_RequestedDateOfDelivery","DoctorFirstName","DoctorLastname","DoctorTitle","DoctorFirstNameScheduled","DoctorLastnameScheduled","DoctorTitleScheduled" });
				while(reader.Read())
				{
					L6CO_GCOFPID_1129_raw resultItem = new L6CO_GCOFPID_1129_raw();
					//0:Parameter Status_Code of type String
					resultItem.Status_Code = reader.GetString(0);
					//1:Parameter Status_Name of type Dict
					resultItem.Status_Name = reader.GetDictionary(1);
					resultItem.Status_Name.SourceTable = "ord_cuo_customerorder_statuses";
					loader.Append(resultItem.Status_Name);
					//2:Parameter ORD_CUO_CustomerOrder_StatusID of type Guid
					resultItem.ORD_CUO_CustomerOrder_StatusID = reader.GetGuid(2);
					//3:Parameter ORD_CUO_CustomerOrder_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrder_HeaderID = reader.GetGuid(3);
					//4:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(4);
					//5:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(5);
					//6:Parameter CustomerOrder_Date of type DateTime
					resultItem.CustomerOrder_Date = reader.GetDate(6);
					//7:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(7);
					//8:Parameter HEC_Patient_Treatment_RequiredProductID of type Guid
					resultItem.HEC_Patient_Treatment_RequiredProductID = reader.GetGuid(8);
					//9:Parameter CMN_COM_CompanyInfoID of type Guid
					resultItem.CMN_COM_CompanyInfoID = reader.GetGuid(9);
					//10:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(10);
					//11:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(11);
					//12:Parameter HEC_MedicalPractiseID of type Guid
					resultItem.HEC_MedicalPractiseID = reader.GetGuid(12);
					//13:Parameter ExpectedDateOfDelivery of type DateTime
					resultItem.ExpectedDateOfDelivery = reader.GetDate(13);
					//14:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(14);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//15:Parameter ORD_CUO_CustomerOrder_PositionID of type Guid
					resultItem.ORD_CUO_CustomerOrder_PositionID = reader.GetGuid(15);
					//16:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(16);
					//17:Parameter Position_OrdinalNumber of type String
					resultItem.Position_OrdinalNumber = reader.GetString(17);
					//18:Parameter Position_Quantity of type String
					resultItem.Position_Quantity = reader.GetString(18);
					//19:Parameter Position_ValuePerUnit of type String
					resultItem.Position_ValuePerUnit = reader.GetString(19);
					//20:Parameter Position_ValueTotal of type String
					resultItem.Position_ValueTotal = reader.GetString(20);
					//21:Parameter Position_Comment of type String
					resultItem.Position_Comment = reader.GetString(21);
					//22:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(22);
					//23:Parameter Position_RequestedDateOfDelivery of type DateTime
					resultItem.Position_RequestedDateOfDelivery = reader.GetDate(23);
					//24:Parameter DoctorFirstName of type String
					resultItem.DoctorFirstName = reader.GetString(24);
					//25:Parameter DoctorLastname of type String
					resultItem.DoctorLastname = reader.GetString(25);
					//26:Parameter DoctorTitle of type String
					resultItem.DoctorTitle = reader.GetString(26);
					//27:Parameter DoctorFirstNameScheduled of type String
					resultItem.DoctorFirstNameScheduled = reader.GetString(27);
					//28:Parameter DoctorLastnameScheduled of type String
					resultItem.DoctorLastnameScheduled = reader.GetString(28);
					//29:Parameter DoctorTitleScheduled of type String
					resultItem.DoctorTitleScheduled = reader.GetString(29);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CustomerOrder_For_PharmacyID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L6CO_GCOFPID_1129_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6CO_GCOFPID_1129_Array Invoke(string ConnectionString,P_L6CO_GCOFPID_1129 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6CO_GCOFPID_1129_Array Invoke(DbConnection Connection,P_L6CO_GCOFPID_1129 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6CO_GCOFPID_1129_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6CO_GCOFPID_1129 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6CO_GCOFPID_1129_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6CO_GCOFPID_1129 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6CO_GCOFPID_1129_Array functionReturn = new FR_L6CO_GCOFPID_1129_Array();
			try
			{

				if (cleanupConnection == true) 
				{
					Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
					Connection.Open();
				}
				if (cleanupTransaction == true)
				{
					Transaction = Connection.BeginTransaction();
				}

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

				#region Cleanup Connection/Transaction
				//Commit the transaction 
				if (cleanupTransaction == true)
				{
					Transaction.Commit();
				}
				//Close the connection
				if (cleanupConnection == true)
				{
					Connection.Close();
				}
				#endregion
			}
			catch (Exception ex)
			{
				try
				{
					if (cleanupTransaction == true && Transaction!=null)
					{
						Transaction.Rollback();
					}
				}
				catch { }

				try
				{
					if (cleanupConnection == true && Connection != null)
					{
						Connection.Close();
					}
				}
				catch { }

				throw new Exception("Exception occured in method cls_Get_CustomerOrder_For_PharmacyID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L6CO_GCOFPID_1129_raw 
	{
		public String Status_Code; 
		public Dict Status_Name; 
		public Guid ORD_CUO_CustomerOrder_StatusID; 
		public Guid ORD_CUO_CustomerOrder_HeaderID; 
		public String GlobalPropertyMatchingID; 
		public String CustomerOrder_Number; 
		public DateTime CustomerOrder_Date; 
		public Guid HEC_Patient_TreatmentID; 
		public Guid HEC_Patient_Treatment_RequiredProductID; 
		public Guid CMN_COM_CompanyInfoID; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public String DisplayName; 
		public Guid HEC_MedicalPractiseID; 
		public DateTime ExpectedDateOfDelivery; 
		public Dict Product_Name; 
		public Guid ORD_CUO_CustomerOrder_PositionID; 
		public Guid CMN_PRO_ProductID; 
		public String Position_OrdinalNumber; 
		public String Position_Quantity; 
		public String Position_ValuePerUnit; 
		public String Position_ValueTotal; 
		public String Position_Comment; 
		public String Product_Number; 
		public DateTime Position_RequestedDateOfDelivery; 
		public String DoctorFirstName; 
		public String DoctorLastname; 
		public String DoctorTitle; 
		public String DoctorFirstNameScheduled; 
		public String DoctorLastnameScheduled; 
		public String DoctorTitleScheduled; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6CO_GCOFPID_1129[] Convert(List<L6CO_GCOFPID_1129_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6CO_GCOFPID_1129 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ORD_CUO_CustomerOrder_HeaderID)).ToArray()
	group el_L6CO_GCOFPID_1129 by new 
	{ 
		el_L6CO_GCOFPID_1129.ORD_CUO_CustomerOrder_HeaderID,

	}
	into gfunct_L6CO_GCOFPID_1129
	select new L6CO_GCOFPID_1129
	{     
		Status_Code = gfunct_L6CO_GCOFPID_1129.FirstOrDefault().Status_Code ,
		Status_Name = gfunct_L6CO_GCOFPID_1129.FirstOrDefault().Status_Name ,
		ORD_CUO_CustomerOrder_StatusID = gfunct_L6CO_GCOFPID_1129.FirstOrDefault().ORD_CUO_CustomerOrder_StatusID ,
		ORD_CUO_CustomerOrder_HeaderID = gfunct_L6CO_GCOFPID_1129.Key.ORD_CUO_CustomerOrder_HeaderID ,
		GlobalPropertyMatchingID = gfunct_L6CO_GCOFPID_1129.FirstOrDefault().GlobalPropertyMatchingID ,
		CustomerOrder_Number = gfunct_L6CO_GCOFPID_1129.FirstOrDefault().CustomerOrder_Number ,
		CustomerOrder_Date = gfunct_L6CO_GCOFPID_1129.FirstOrDefault().CustomerOrder_Date ,
		HEC_Patient_TreatmentID = gfunct_L6CO_GCOFPID_1129.FirstOrDefault().HEC_Patient_TreatmentID ,
		HEC_Patient_Treatment_RequiredProductID = gfunct_L6CO_GCOFPID_1129.FirstOrDefault().HEC_Patient_Treatment_RequiredProductID ,
		CMN_COM_CompanyInfoID = gfunct_L6CO_GCOFPID_1129.FirstOrDefault().CMN_COM_CompanyInfoID ,
		CMN_BPT_BusinessParticipantID = gfunct_L6CO_GCOFPID_1129.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
		DisplayName = gfunct_L6CO_GCOFPID_1129.FirstOrDefault().DisplayName ,
		HEC_MedicalPractiseID = gfunct_L6CO_GCOFPID_1129.FirstOrDefault().HEC_MedicalPractiseID ,
		ExpectedDateOfDelivery = gfunct_L6CO_GCOFPID_1129.FirstOrDefault().ExpectedDateOfDelivery ,

		Positions = 
		(
			from el_Positions in gfunct_L6CO_GCOFPID_1129.Where(element => !EqualsDefaultValue(element.ORD_CUO_CustomerOrder_PositionID)).ToArray()
			group el_Positions by new 
			{ 
				el_Positions.ORD_CUO_CustomerOrder_PositionID,

			}
			into gfunct_Positions
			select new L6CO_GCOFPID_1129_Position
			{     
				Product_Name = gfunct_Positions.FirstOrDefault().Product_Name ,
				ORD_CUO_CustomerOrder_PositionID = gfunct_Positions.Key.ORD_CUO_CustomerOrder_PositionID ,
				CMN_PRO_ProductID = gfunct_Positions.FirstOrDefault().CMN_PRO_ProductID ,
				Position_OrdinalNumber = gfunct_Positions.FirstOrDefault().Position_OrdinalNumber ,
				Position_Quantity = gfunct_Positions.FirstOrDefault().Position_Quantity ,
				Position_ValuePerUnit = gfunct_Positions.FirstOrDefault().Position_ValuePerUnit ,
				Position_ValueTotal = gfunct_Positions.FirstOrDefault().Position_ValueTotal ,
				Position_Comment = gfunct_Positions.FirstOrDefault().Position_Comment ,
				Product_Number = gfunct_Positions.FirstOrDefault().Product_Number ,
				Position_RequestedDateOfDelivery = gfunct_Positions.FirstOrDefault().Position_RequestedDateOfDelivery ,

			}
		).ToArray(),
		DoctorPerformed = 
		(
			from el_DoctorPerformed in gfunct_L6CO_GCOFPID_1129.ToArray()
			select new L6CO_GCOFPID_1129_DoctorsPerformed
			{     
				DoctorFirstName = el_DoctorPerformed.DoctorFirstName,
				DoctorLastname = el_DoctorPerformed.DoctorLastname,
				DoctorTitle = el_DoctorPerformed.DoctorTitle,

			}
		).FirstOrDefault(),
		DoctorScheduled = 
		(
			from el_DoctorScheduled in gfunct_L6CO_GCOFPID_1129.ToArray()
			select new L6CO_GCOFPID_1129_DoctorsScheduled
			{     
				DoctorFirstNameScheduled = el_DoctorScheduled.DoctorFirstNameScheduled,
				DoctorLastnameScheduled = el_DoctorScheduled.DoctorLastnameScheduled,
				DoctorTitleScheduled = el_DoctorScheduled.DoctorTitleScheduled,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6CO_GCOFPID_1129_Array : FR_Base
	{
		public L6CO_GCOFPID_1129[] Result	{ get; set; } 
		public FR_L6CO_GCOFPID_1129_Array() : base() {}

		public FR_L6CO_GCOFPID_1129_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6CO_GCOFPID_1129 for attribute P_L6CO_GCOFPID_1129
		[DataContract]
		public class P_L6CO_GCOFPID_1129 
		{
			//Standard type parameters
			[DataMember]
			public Guid PharmacyID { get; set; } 

		}
		#endregion
		#region SClass L6CO_GCOFPID_1129 for attribute L6CO_GCOFPID_1129
		[DataContract]
		public class L6CO_GCOFPID_1129 
		{
			[DataMember]
			public L6CO_GCOFPID_1129_Position[] Positions { get; set; }
			[DataMember]
			public L6CO_GCOFPID_1129_DoctorsPerformed DoctorPerformed { get; set; }
			[DataMember]
			public L6CO_GCOFPID_1129_DoctorsScheduled DoctorScheduled { get; set; }

			//Standard type parameters
			[DataMember]
			public String Status_Code { get; set; } 
			[DataMember]
			public Dict Status_Name { get; set; } 
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_StatusID { get; set; } 
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_HeaderID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public DateTime CustomerOrder_Date { get; set; } 
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public Guid HEC_Patient_Treatment_RequiredProductID { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfoID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public DateTime ExpectedDateOfDelivery { get; set; } 

		}
		#endregion
		#region SClass L6CO_GCOFPID_1129_Position for attribute Positions
		[DataContract]
		public class L6CO_GCOFPID_1129_Position 
		{
			//Standard type parameters
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_PositionID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public String Position_OrdinalNumber { get; set; } 
			[DataMember]
			public String Position_Quantity { get; set; } 
			[DataMember]
			public String Position_ValuePerUnit { get; set; } 
			[DataMember]
			public String Position_ValueTotal { get; set; } 
			[DataMember]
			public String Position_Comment { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public DateTime Position_RequestedDateOfDelivery { get; set; } 

		}
		#endregion
		#region SClass L6CO_GCOFPID_1129_DoctorsPerformed for attribute DoctorPerformed
		[DataContract]
		public class L6CO_GCOFPID_1129_DoctorsPerformed 
		{
			//Standard type parameters
			[DataMember]
			public String DoctorFirstName { get; set; } 
			[DataMember]
			public String DoctorLastname { get; set; } 
			[DataMember]
			public String DoctorTitle { get; set; } 

		}
		#endregion
		#region SClass L6CO_GCOFPID_1129_DoctorsScheduled for attribute DoctorScheduled
		[DataContract]
		public class L6CO_GCOFPID_1129_DoctorsScheduled 
		{
			//Standard type parameters
			[DataMember]
			public String DoctorFirstNameScheduled { get; set; } 
			[DataMember]
			public String DoctorLastnameScheduled { get; set; } 
			[DataMember]
			public String DoctorTitleScheduled { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6CO_GCOFPID_1129_Array cls_Get_CustomerOrder_For_PharmacyID(,P_L6CO_GCOFPID_1129 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6CO_GCOFPID_1129_Array invocationResult = cls_Get_CustomerOrder_For_PharmacyID.Invoke(connectionString,P_L6CO_GCOFPID_1129 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new CL6_Lucentis_CustomerOrder.Atomic.Retrieval.P_L6CO_GCOFPID_1129();
parameter.PharmacyID = ...;

*/
