using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EsriApplicationChooser
{
    class ApplicationHandler
    {
        private ApplicationElement _application;

        public ApplicationHandler(ApplicationElement application)
        {
            _application = application;
        }

        internal void Handle()
        {
            ProcessStartInfo proces = new ProcessStartInfo(_application.Location);
            Process.Start(proces);
        }
    }
}