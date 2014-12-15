using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EsriApplicationChooser
{
    class ClickHandler
    {
        private string _tag;

        public ClickHandler(string tag)
        {
            this._tag = tag;
        }

        internal void HandleClick()
        {
            Configuration config = Configuration.GetConfig();
            ServiceElement service = config.Services[_tag];
            UrlElement url = config.Urls[_tag];
            ApplicationElement application = config.Applications[_tag];
            if (service != null) { HandleService(service); }
            if (url != null) { HandleUrl(url); }
            if (application != null) { HandleApplication(application); }
        }

        private void HandleService(ServiceElement service)
        {
            ServiceHandler handler = new ServiceHandler();
            handler.Handle(service.Name);
        }

        private void HandleUrl(UrlElement url)
        {
            UrlHandler handler = new UrlHandler(url);
            handler.Handle();
        }

        private void HandleApplication(ApplicationElement application)
        {
            ApplicationHandler handler = new ApplicationHandler(application);
            handler.Handle();
        }
    }
}