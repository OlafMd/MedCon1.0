/* 
 * Generated on 17.02.2015 15:11:17
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

namespace CL5_MyHealthClub_EMR.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Referrals_for_PerformedActionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Referrals_for_PerformedActionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ME_GRfPAID_1557_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ME_GRfPAID_1557 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ME_GRfPAID_1557_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_EMR.Atomic.Retrieval.SQL.cls_Get_Referrals_for_PerformedActionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PerformedActionID", Parameter.PerformedActionID);



			List<L5ME_GRfPAID_1557_raw> results = new List<L5ME_GRfPAID_1557_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_ACT_PerformedAction_ReferralID","ReferralComment","HEC_MedicalPractice_TypeID","MedicalPracticeType_Name_DictID","HEC_MedicalPractiseID","OrganizationalUnit_Name_DictID","HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedureID","HEC_TRE_PotentialProcedureID","ProposedDate","PotentialProcedure_Name_DictID" });
				while(reader.Read())
				{
					L5ME_GRfPAID_1557_raw resultItem = new L5ME_GRfPAID_1557_raw();
					//0:Parameter HEC_ACT_PerformedAction_ReferralID of type Guid
					resultItem.HEC_ACT_PerformedAction_ReferralID = reader.GetGuid(0);
					//1:Parameter ReferralComment of type String
					resultItem.ReferralComment = reader.GetString(1);
					//2:Parameter HEC_MedicalPractice_TypeID of type Guid
					resultItem.HEC_MedicalPractice_TypeID = reader.GetGuid(2);
					//3:Parameter MedicalPracticeType_Name of type Dict
					resultItem.MedicalPracticeType_Name = reader.GetDictionary(3);
					resultItem.MedicalPracticeType_Name.SourceTable = "hec_medicalpractice_types";
					loader.Append(resultItem.MedicalPracticeType_Name);
					//4:Parameter HEC_MedicalPractiseID of type Guid
					resultItem.HEC_MedicalPractiseID = reader.GetGuid(4);
					//5:Parameter OrganizationalUnit_Name of type Dict
					resultItem.OrganizationalUnit_Name = reader.GetDictionary(5);
					resultItem.OrganizationalUnit_Name.SourceTable = "cmn_bpt_ctm_organizationalunits";
					loader.Append(resultItem.OrganizationalUnit_Name);
					//6:Parameter HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedureID of type Guid
					resultItem.HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedureID = reader.GetGuid(6);
					//7:Parameter HEC_TRE_PotentialProcedureID of type Guid
					resultItem.HEC_TRE_PotentialProcedureID = reader.GetGuid(7);
					//8:Parameter ProposedDate of type DateTime
					resultItem.ProposedDate = reader.GetDate(8);
					//9:Parameter PotentialProcedure_Name of type Dict
					resultItem.PotentialProcedure_Name = reader.GetDictionary(9);
					resultItem.PotentialProcedure_Name.SourceTable = "hec_tre_potentialprocedures";
					loader.Append(resultItem.PotentialProcedure_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Referrals_for_PerformedActionID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5ME_GRfPAID_1557_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ME_GRfPAID_1557_Array Invoke(string ConnectionString,P_L5ME_GRfPAID_1557 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ME_GRfPAID_1557_Array Invoke(DbConnection Connection,P_L5ME_GRfPAID_1557 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ME_GRfPAID_1557_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ME_GRfPAID_1557 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ME_GRfPAID_1557_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ME_GRfPAID_1557 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ME_GRfPAID_1557_Array functionReturn = new FR_L5ME_GRfPAID_1557_Array();
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

				throw new Exception("Exception occured in method cls_Get_Referrals_for_PerformedActionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5ME_GRfPAID_1557_raw 
	{
		public Guid HEC_ACT_PerformedAction_ReferralID; 
		public String ReferralComment; 
		public Guid HEC_MedicalPractice_TypeID; 
		public Dict MedicalPracticeType_Name; 
		public Guid HEC_MedicalPractiseID; 
		public Dict OrganizationalUnit_Name; 
		public Guid HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedureID; 
		public Guid HEC_TRE_PotentialProcedureID; 
		public DateTime ProposedDate; 
		public Dict PotentialProcedure_Name; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ME_GRfPAID_1557[] Convert(List<L5ME_GRfPAID_1557_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ME_GRfPAID_1557 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_ACT_PerformedAction_ReferralID)).ToArray()
	group el_L5ME_GRfPAID_1557 by new 
	{ 
		el_L5ME_GRfPAID_1557.HEC_ACT_PerformedAction_ReferralID,

	}
	into gfunct_L5ME_GRfPAID_1557
	select new L5ME_GRfPAID_1557
	{     
		HEC_ACT_PerformedAction_ReferralID = gfunct_L5ME_GRfPAID_1557.Key.HEC_ACT_PerformedAction_ReferralID ,
		ReferralComment = gfunct_L5ME_GRfPAID_1557.FirstOrDefault().ReferralComment ,

		PracticeType = 
		(
			from el_PracticeType in gfunct_L5ME_GRfPAID_1557.Where(element => !EqualsDefaultValue(element.HEC_MedicalPractice_TypeID)).ToArray()
			group el_PracticeType by new 
			{ 
				el_PracticeType.HEC_MedicalPractice_TypeID,

			}
			into gfunct_PracticeType
			select new L5ME_GRfPAID_1557_PracticeType
			{     
				HEC_MedicalPractice_TypeID = gfunct_PracticeType.Key.HEC_MedicalPractice_TypeID ,
				MedicalPracticeType_Name = gfunct_PracticeType.FirstOrDefault().MedicalPracticeType_Name ,

			}
		).FirstOrDefault(),
		Practice = 
		(
			from el_Practice in gfunct_L5ME_GRfPAID_1557.Where(element => !EqualsDefaultValue(element.HEC_MedicalPractiseID)).ToArray()
			group el_Practice by new 
			{ 
				el_Practice.HEC_MedicalPractiseID,

			}
			into gfunct_Practice
			select new L5ME_GRfPAID_1557_Practice
			{     
				HEC_MedicalPractiseID = gfunct_Practice.Key.HEC_MedicalPractiseID ,
				OrganizationalUnit_Name = gfunct_Practice.FirstOrDefault().OrganizationalUnit_Name ,

			}
		).FirstOrDefault(),
		Procedure = 
		(
			from el_Procedure in gfunct_L5ME_GRfPAID_1557.Where(element => !EqualsDefaultValue(element.HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedureID)).ToArray()
			group el_Procedure by new 
			{ 
				el_Procedure.HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedureID,

			}
			into gfunct_Procedure
			select new L5ME_GRfPAID_1557_Procedures
			{     
				HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedureID = gfunct_Procedure.Key.HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedureID ,
				HEC_TRE_PotentialProcedureID = gfunct_Procedure.FirstOrDefault().HEC_TRE_PotentialProcedureID ,
				ProposedDate = gfunct_Procedure.FirstOrDefault().ProposedDate ,
				PotentialProcedure_Name = gfunct_Procedure.FirstOrDefault().PotentialProcedure_Name ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ME_GRfPAID_1557_Array : FR_Base
	{
		public L5ME_GRfPAID_1557[] Result	{ get; set; } 
		public FR_L5ME_GRfPAID_1557_Array() : base() {}

		public FR_L5ME_GRfPAID_1557_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ME_GRfPAID_1557 for attribute P_L5ME_GRfPAID_1557
		[DataContract]
		public class P_L5ME_GRfPAID_1557 
		{
			//Standard type parameters
			[DataMember]
			public Guid PerformedActionID { get; set; } 

		}
		#endregion
		#region SClass L5ME_GRfPAID_1557 for attribute L5ME_GRfPAID_1557
		[DataContract]
		public class L5ME_GRfPAID_1557 
		{
			[DataMember]
			public L5ME_GRfPAID_1557_PracticeType PracticeType { get; set; }
			[DataMember]
			public L5ME_GRfPAID_1557_Practice Practice { get; set; }
			[DataMember]
			public L5ME_GRfPAID_1557_Procedures[] Procedure { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_ACT_PerformedAction_ReferralID { get; set; } 
			[DataMember]
			public String ReferralComment { get; set; } 

		}
		#endregion
		#region SClass L5ME_GRfPAID_1557_PracticeType for attribute PracticeType
		[DataContract]
		public class L5ME_GRfPAID_1557_PracticeType 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractice_TypeID { get; set; } 
			[DataMember]
			public Dict MedicalPracticeType_Name { get; set; } 

		}
		#endregion
		#region SClass L5ME_GRfPAID_1557_Practice for attribute Practice
		[DataContract]
		public class L5ME_GRfPAID_1557_Practice 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public Dict OrganizationalUnit_Name { get; set; } 

		}
		#endregion
		#region SClass L5ME_GRfPAID_1557_Procedures for attribute Procedure
		[DataContract]
		public class L5ME_GRfPAID_1557_Procedures 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_ACT_PerformedAction_Referral_RequestedPotentialProcedureID { get; set; } 
			[DataMember]
			public Guid HEC_TRE_PotentialProcedureID { get; set; } 
			[DataMember]
			public DateTime ProposedDate { get; set; } 
			[DataMember]
			public Dict PotentialProcedure_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ME_GRfPAID_1557_Array cls_Get_Referrals_for_PerformedActionID(,P_L5ME_GRfPAID_1557 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ME_GRfPAID_1557_Array invocationResult = cls_Get_Referrals_for_PerformedActionID.Invoke(connectionString,P_L5ME_GRfPAID_1557 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_EMR.Atomic.Retrieval.P_L5ME_GRfPAID_1557();
parameter.PerformedActionID = ...;

*/
