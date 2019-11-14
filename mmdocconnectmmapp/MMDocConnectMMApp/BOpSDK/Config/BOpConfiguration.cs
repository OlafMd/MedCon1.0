using BOp.Providers;
using BOp.Services.Auth;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using RestSharp.Authenticators;

namespace BOp.Config
{
    public class BOpConfiguration
    {
        private NameValueCollection _config;


        public BOpConfiguration()
        {
            _config = ConfigurationManager.AppSettings;
        }

        public BOpConfiguration(NameValueCollection config)
        {
            _config = config;
        }

        public string BOpCookieName
        {
            get
            {
                return _config["bop.config.cookie-name"] ?? "bops";
            }
        }

        public IAuthenticator GetAuthenticator(ProviderType provider)
        {
            IAuthenticator auth;
            string authenticationType = _config["bop.config.auth.type"];
            if ("digest".Equals(authenticationType))
            {
                string username = _config["bop.config.auth.username"];
                string password = _config["bop.config.auth.password"];
                auth = new DigestAuthentication(username, password);
            }
            else
            {
                auth = null;
            }
            return auth;
        }

        public BOp.Providers.Configuration GetProviderConfiguration(ProviderType provider)
        {
            var configuration = new BOp.Providers.Configuration();
            configuration.Authenticator = GetAuthenticator(provider);
            configuration.BaseUrl = GetProviderEndpoint(provider);

            return configuration;
        }
        public Uri GetProviderEndpoint(ProviderType provider)
        {
            string providerKey = GetServiceProviderPropertyKey(provider);
            string value = _config[providerKey];
            if (value == null)
            {
                var message = String.Format("Specified provider with key {0} is not configured. Please add the required configuration in <appSettings> section.", providerKey);
                throw new ArgumentException(message, "provider");
            }

            if (Uri.IsWellFormedUriString(value, UriKind.Absolute) == false)
            {
                var message = String.Format("Specified provider with key {0} is not a valid URI. Please add a valid absolute URI configuration in <appSettings> section.", providerKey);
                throw new ArgumentException(message, "provider");
            }
            else
            {
                return new Uri(value);
            }
        }


        private string GetServiceProviderPropertyKey(ProviderType provider)
        {
            switch (provider)
            {
                case ProviderType.Account:
                case ProviderType.Session:
                case ProviderType.Tenant:
                    return "bop.config.provider.tms";
                case ProviderType.TrustRelation:
                    return "bop.config.provider.trust";
                case ProviderType.RealmApplicationAccess:
                    return "bop.config.provider.rps";
                case ProviderType.Message:
                    return "bop.config.provider.rms";
                case ProviderType.Document:
                    return "bop.config.provider.doc";
                case ProviderType.Printer:
                    return "bop.config.provider.pch";
                default:
                    throw new ArgumentException(String.Format("Provider Error: The provider {0} does not have a key assigned to it", provider));
            }
        }

    }


}
