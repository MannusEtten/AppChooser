using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Configuration;

namespace EsriApplicationChooser
{
    class UrlHandler
    {
        private UrlElement _url;

        public UrlHandler(UrlElement url)
        {
            _url = url;
        }

        internal void Handle()
        {
            string browser = ConfigurationManager.AppSettings["browser"];
            ProcessStartInfo proces = new ProcessStartInfo(browser, _url.Url);
            Process.Start(proces);
        }
    }
}