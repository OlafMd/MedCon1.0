using System;
using CSV2Core.SessionSecurity;
using BOp.Infrastructure;
using BOp.Infrastructure.Authentication;

namespace Core_ClassLibrarySupport.CoreAPISupport
{
    public class BaseVerification
    {

        [Obsolete("Verify is deprecated, please use DLCore_TokenVerification (\"C:\\SourceCode\\libs\\dbaccess\\Level 0\\DLCore_TokenVerification\") class and VerifySessionToken method instead and catch \"FaultException<VerificationFault>\" instead \"VerificationException\"")]
        public SessionSecurityTicket Verify(String SessionToken)
        {
            var authService = InfrastructureFactory.CreateAuthenticationService();

            var verificationResult = authService.VerifyToken(SessionToken);

            if (verificationResult.Status == CASResponseCode.OK)
            {
                try { 
                    SessionTokenInformation result = authService.GetSessionTokenInformation(SessionToken);
                    return SessionTokenInformationUtil.getSessionSecurityTicket(result);
                    
                }catch(Exception){

                    throw new VerificationException(VerificationException.VerificationException_Message);
                }

            }
            else
            {
                throw new VerificationException(VerificationException.VerificationException_Message);
            }
                
        }
    }

    public class VerificationException : Exception
    {
        public static String VerificationException_Message = "Session token is not valid";

        public VerificationException()
        {
        }

        public VerificationException(string message) : base(message)
        {

        }

    }
}
