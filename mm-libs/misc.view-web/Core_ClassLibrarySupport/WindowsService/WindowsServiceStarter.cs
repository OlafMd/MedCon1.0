using System;
using System.ServiceProcess;

namespace Core_ClassLibrarySupport.WindowsService
{
    public class WindowsServiceStarter
    {
        private string nameOfService = string.Empty;

        public WindowsServiceStarter(string nameOfService)
        {
            this.nameOfService = nameOfService;
        }

        #region "Start/Stop Window Service"
        public void StartWindowService()
        {
            ServiceController svcController = new ServiceController(nameOfService);
            if (svcController != null)
            {
                try
                {
                    if (svcController.Status != ServiceControllerStatus.Running &&
                        svcController.Status != ServiceControllerStatus.StartPending)
                        svcController.Start();
                }
                catch (Exception ex) { throw ex; }
            }
        }

        public void StopWindowService()
        {
            ServiceController svcController = new ServiceController(nameOfService);
            if (svcController != null)
            {
                try
                {
                    if (svcController.Status == ServiceControllerStatus.Running &&
                        svcController.CanStop)
                    {
                        svcController.Stop();
                        svcController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                    }
                }
                catch (Exception ex) { throw ex; }
            }
        }
        #endregion
    }
}
