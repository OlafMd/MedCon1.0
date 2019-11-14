using CL1_CMN_CTR;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Model;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDocAppInterfaces;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectDocAppServices
{
    public class DoctorDataService : BaseVerification, IDoctorDataService
    {
        #region RETRIEVAL
        public DO_GDBIfLD_1031 GetDoctorInformation(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var method = MethodInfo.GetCurrentMethod();

            var securityTicket = VerifySessionToken(sessionTicket);

            transaction = new TransactionalInformation();
            transaction.IsAuthenicated = true;
            try
            {
                var docData = cls_Get_Doctor_BasicInformation_for_Logged_Doctor.Invoke(connectionString, securityTicket).Result;
                if (docData == null)
                {
                    transaction.ReturnMessage = new List<string>();
                    string errorMessage = "Zugriff nicht gestattet.";
                    transaction.ReturnStatus = false;
                    transaction.IsAuthenicated = false;
                    transaction.ReturnMessage.Add(errorMessage);
                }
                return docData;
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), "GetDoctorInformation");

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;

                return null;
            }
        }


        public IEnumerable<DO_GDBIfDfDP_1525> GetDoctorsFromDifferentPractice(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var method = MethodInfo.GetCurrentMethod();

            var securityTicket = VerifySessionToken(sessionTicket);

            transaction = new TransactionalInformation();
            transaction.IsAuthenicated = true;
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            try
            {
                var doctors = cls_Get_Doctor_Basic_Information_for_Doctors_from_Different_Practice.Invoke(connectionString, new P_DO_GDBIfDfDP_1525
                {
                    MedicalPracticeID = data.PracticeID
                }, securityTicket).Result;

                if (doctors == null)
                {
                    transaction.ReturnMessage = new List<string>();
                    string errorMessage = "Zugriff nicht gestattet.";
                    transaction.ReturnStatus = false;
                    transaction.IsAuthenicated = false;
                    transaction.ReturnMessage.Add(errorMessage);
                }
                return doctors;
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;

                return null;
            }

        }


        public IEnumerable<DO_GDBIfDfDP_1525> GetDoctorsFromDifferentPracticeWithOctContract(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            //This method is needed for automated tests

            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var method = MethodInfo.GetCurrentMethod();

            var securityTicket = VerifySessionToken(sessionTicket);

            transaction = new TransactionalInformation();
            transaction.IsAuthenicated = true;
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            try
            {
                var doctors = cls_Get_Doctor_Basic_Information_for_Doctors_from_Different_Practice.Invoke(connectionString, new P_DO_GDBIfDfDP_1525
                {
                    MedicalPracticeID = data.PracticeID
                }, securityTicket).Result;

                var allDoctorsWithOctContract = cls_Get_DoctorIDs_with_Oct_Contract.Invoke(connectionString, securityTicket).Result.GroupBy(x => x.DoctorID).ToDictionary(x => x.Key, x => x.ToList());
                var allContractParameters = ORM_CMN_CTR_Contract_Parameter.Query.Search(connectionString, new ORM_CMN_CTR_Contract_Parameter.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false });
                var doctorsProperties = cls_Get_Doctors_Properties.Invoke(connectionString, securityTicket).Result.GroupBy(x => x.DoctorID).ToDictionary(x => x.Key, x => x.ToList());

                var doctorsWithValidContract = new List<Guid>();

                foreach (var doc in allDoctorsWithOctContract)
                {
                    if (doc.Value.Any())
                    {
                        var allContractIDs = doc.Value.Select(x => x.ContractID).Distinct();

                        var contractParameters = allContractParameters.Where(x => allContractIDs.Contains(x.Contract_RefID));

                        var allContractsWithCertificate = contractParameters.Where(x => x.ParameterName == EContractParameter.DoctorNeedCertification.Value()).Select(x => x.Contract_RefID);
                        var allContractsWithoutCertificate = allContractIDs.Where(x => !allContractsWithCertificate.Contains(x));

                        var doctor_id = doc.Value.First().DoctorID;
                        if (allContractsWithoutCertificate.Any())
                        {
                            doctorsWithValidContract.Add(doctor_id);
                        }

                        if (allContractsWithCertificate.Any())
                        {
                            var doctor_properties = doctorsProperties.ContainsKey(doctor_id) ? doctorsProperties[doctor_id] : new List<DO_GDP_1757>();
                            var is_certificated_for_oct = doctor_properties.SingleOrDefault(x => x.GlobalPropertyMatchingID == EDoctorPropertyType.OctCertificated.Value());
                            if (is_certificated_for_oct != null ? is_certificated_for_oct.Value_Boolean : false)
                            {
                                doctorsWithValidContract.Add(doctor_id);
                            }
                        }
                    }
                }

                doctors = doctors.Where(x => doctorsWithValidContract.Any(t => t == x.doctor_id)).ToArray();


                if (doctors == null)
                {
                    transaction.ReturnMessage = new List<string>();
                    string errorMessage = "Zugriff nicht gestattet.";
                    transaction.ReturnStatus = false;
                    transaction.IsAuthenicated = false;
                    transaction.ReturnMessage.Add(errorMessage);
                }
                return doctors;
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;

                return null;
            }


        }

        public DO_GDBIfLD_1031 GetDoctorInfoForDoctorName(String doctorFullName, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var method = MethodInfo.GetCurrentMethod();

            var securityTicket = VerifySessionToken(sessionTicket);

            transaction = new TransactionalInformation();
            transaction.IsAuthenicated = true;
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;
            try
            {
                var doctors = cls_Get_Doctor_Details_on_Tenant.Invoke(connectionString, securityTicket).Result;

                if (doctors == null)
                {
                    transaction.ReturnMessage = new List<string>();
                    string errorMessage = "Zugriff nicht gestattet.";
                    transaction.ReturnStatus = false;
                    transaction.IsAuthenicated = false;
                    transaction.ReturnMessage.Add(errorMessage);
                }

                var doctor = doctors.FirstOrDefault(x => String.Format("{0} {1} {2}", x.title, x.first_name, x.last_name) == doctorFullName);
                return new DO_GDBIfLD_1031
                {
                    doctor_id = doctor.id,
                    first_name = doctor.first_name,
                    lanr = doctor.lanr,
                    last_name = doctor.last_name,
                    praxis = doctor.practice_name,
                    title = doctor.title
                };
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;

                return null;
            }

        }
        #endregion
    }
}
