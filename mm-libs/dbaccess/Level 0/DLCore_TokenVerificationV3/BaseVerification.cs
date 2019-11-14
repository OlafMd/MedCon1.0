using System;
using System.ServiceModel;
using System.Runtime.Serialization;
using CSV2Core.SessionSecurity;
using BOp.Providers;
using BOp.Providers.TMS;

namespace DLCore_TokenVerification
{
    public class BaseVerification
    {
        [Obsolete("Verify is deprecated, please use VerifySessionToken instead and catch \"FaultException<VerificationFault>\" instead \"VerificationException\"")]
        public SessionSecurityTicket Verify(String SessionToken)
        {
            ProviderFactory _providerFactory = ProviderFactory.Instance;
            var service = _providerFactory.CreateSessionServiceProvider();

            var verificationResult = service.CheckIfSessionIsValid(SessionToken);

            if (verificationResult)
            {
                try
                {
                    Session result = service.GetSessionInformation(SessionToken);
                    return SessionTokenInformationUtil.getSessionSecurityTicket(result);

                }
                catch (Exception)
                {

                    throw new VerificationException(VerificationException.VerificationException_Message);
                }

            }
            else
            {
                throw new VerificationException(VerificationException.VerificationException_Message);
            }

        }


        public SessionSecurityTicket VerifySessionToken(String SessionToken)
        {

            ProviderFactory _providerFactory = ProviderFactory.Instance;
            var service = _providerFactory.CreateSessionServiceProvider();

            var verificationResult = service.CheckIfSessionIsValid(SessionToken);

            if (verificationResult)
            {
                Session result = service.GetSessionInformation(SessionToken);
                return SessionTokenInformationUtil.getSessionSecurityTicket(result);
            }
            else
            {
                var fault = new VerificationFault();
                fault.Message = "Session token is not valid";

                throw new FaultException<VerificationFault>(fault);
            }

        }
    }

    [Obsolete]
    public class VerificationException : Exception
    {
        public static String VerificationException_Message = "Session token is not valid";

        public VerificationException()
        {
        }

        public VerificationException(string message)
            : base(message)
        {

        }

    }

    [DataContract]
    public class VerificationFault
    {
        [DataMember]
        public String Message { get; set; }

    }
}
