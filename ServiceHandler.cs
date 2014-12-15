using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace EsriApplicationChooser
{
    internal class ServiceHandler
    {
        internal void Handle(string serviceName)
        {
            ServiceController myService = new ServiceController();
            myService.ServiceName = serviceName;
            try
            {
                if (myService.Status == ServiceControllerStatus.Stopped)
                {
                    myService.Start();
                }
                if (myService.Status == ServiceControllerStatus.Running)
                {
                    myService.Stop();
                }
            }
            catch (InvalidOperationException e)
            {

            }
        }
    }
}