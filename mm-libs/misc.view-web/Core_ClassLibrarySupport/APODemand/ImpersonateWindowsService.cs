using Core_ClassLibrarySupport.WindowsService;

namespace Core_ClassLibrarySupport.APODemand
{
    public class ImpersonateWindowsService
    {
        private string _nameOfService = "Shopping Cart Orders Service";
        private string _domainName = ".";
        private string _userName = "Administrator";
        private string _userPassword = "Iv26an03st09st21";

        public void RestartShoppingCartService()
        {
            //--need to impersonate with the user having appropriate rights to start the service
            Impersonate objImpersonate = new Impersonate(_domainName, _userName, _userPassword);
            if (objImpersonate.impersonateValidUser())
            {
                var starter = new WindowsServiceStarter(_nameOfService);
                starter.StopWindowService();
                System.Threading.Thread.Sleep(1000);
                starter.StartWindowService();
                objImpersonate.undoImpersonation();
            }
        }
    }
}
