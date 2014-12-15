using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRINederland.Framework.Configuration;
using System.Configuration;
namespace EsriApplicationChooser
{
    internal class Configuration : ConfigurationSection
    {
        public static Configuration GetConfig()
        {
            Configuration result = null;
            result = ConfigurationManager.GetSection("esriapps") as Configuration;
            return result;
        }

        [ConfigurationProperty("applications", IsRequired = true)]
        public GenericConfigurationElementCollection<ApplicationElement> Applications
        {
            get
            {
                return this["applications"] as GenericConfigurationElementCollection<ApplicationElement>;
            }
        }

        [ConfigurationProperty("urls", IsRequired = true)]
        public GenericConfigurationElementCollection<UrlElement> Urls
        {
            get
            {
                return this["urls"] as GenericConfigurationElementCollection<UrlElement>;
            }
        }

        [ConfigurationProperty("services", IsRequired = true)]
        public GenericConfigurationElementCollection<ServiceElement> Services
        {
            get
            {
                return this["services"] as GenericConfigurationElementCollection<ServiceElement>;
            }
        }
    }
    internal class UrlElement : ConfigurationElementBase
    {
        [ConfigurationProperty("title", IsRequired = true)]
        public string Title
        {
            get
            {
                return this["title"] as string;
            }
        }

        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get
            {
                return this["url"] as string;
            }
        }

        public override string ElementName
        {
            get { return "url"; }
        }
    }
    internal class ApplicationElement : ConfigurationElementBase
    {
        [ConfigurationProperty("title", IsRequired = true)]
        public string Title
        {
            get
            {
                return this["title"] as string;
            }
        }

        [ConfigurationProperty("location", IsRequired = true)]
        public string Location
        {
            get
            {
                return this["location"] as string;
            }
        }

        public override string ElementName
        {
            get { return "application"; }
        }
    }
    internal class ServiceElement : ConfigurationElementBase
    {
        [ConfigurationProperty("title", IsRequired = true)]
        public string Title
        {
            get
            {
                return this["title"] as string;
            }
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
        }

        public override string ElementName
        {
            get { return "service"; }
        }
    }
}