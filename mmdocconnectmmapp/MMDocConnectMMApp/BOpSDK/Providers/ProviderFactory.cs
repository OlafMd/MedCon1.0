using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOp.Providers.TMS;
using BOp.Services.Rest;
using RestSharp;
using BOp.Providers.DOC;
using BOp.Providers.Message;
using BOp.RAA;
using BOp.Providers.TD;
using BOp.Providers.TrustRelation;
using BOp.Config;
using System.Runtime.Caching;
using BOp.Providers.PCH;

namespace BOp.Providers
{
    public class ProviderFactory
    {
        private static ProviderFactory _instance;
        private BOpConfiguration _config;

        public static ProviderFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProviderFactory(new BOpConfiguration());
                }
                return _instance;
            }
        }


        public ProviderFactory(BOpConfiguration config)
        {
            if (config == null) throw new ArgumentNullException("configurationService", "Configuration service must not be null");
            _config = config;
        }


        public ISessionServiceProvider CreateSessionServiceProvider()
        {
            Configuration config = _config.GetProviderConfiguration(ProviderType.Session);
            IRestClient client = new JSONClient(config.BaseUrl, config.Authenticator);
            client.PreAuthenticate = true;
            var provider = new SessionServiceProvider(client, MemoryCache.Default);
            return provider;
        }

        public ITenantServiceProvider CreateTenantServiceProvider()
        {
            Configuration config = _config.GetProviderConfiguration(ProviderType.Tenant);
            IRestClient client = new JSONClient(config.BaseUrl, config.Authenticator);
            client.PreAuthenticate = true;
            var provider = new TenantServiceProvider(client);
            return provider;
        }

        public IAccountServiceProvider CreateAccountServiceProvider()
        {
            Configuration config = _config.GetProviderConfiguration(ProviderType.Account);
            IRestClient client = new JSONClient(config.BaseUrl, config.Authenticator);
            client.PreAuthenticate = true;
            var provider = new AccountServiceProvider(client);
            return provider;
        }

        public IDocumentServiceProvider CreateDocumentServiceProvider()
        {
            Configuration config = _config.GetProviderConfiguration(ProviderType.Document);
            IRestClient client = new JSONClient(config.BaseUrl, config.Authenticator);
            client.PreAuthenticate = true;
            var provider = new DocumentServiceProvider(client);
            return provider;
        }

        public IMessageServiceProvider CreateMessageServiceProvider()
        {
            Configuration config = _config.GetProviderConfiguration(ProviderType.Message);
            IRestClient client = new JSONClient(config.BaseUrl, config.Authenticator);
            client.PreAuthenticate = true;
            var provider = new MessageServiceProvider(client);
            return provider;
        }

        public ITenantIntroductionServiceProvider CreateTenantIntroductionServiceProvider()
        {
            var provider = new TenantIntroductionServiceProvider();
            return provider;
        }

        public ITrustRelationTypeServiceProvider CreateTrustRelationTypeServiceProvider()
        {
            Configuration config = _config.GetProviderConfiguration(ProviderType.TrustRelation);
            IRestClient client = new JSONClient(config.BaseUrl, config.Authenticator);
            client.PreAuthenticate = true;
            var provider = new TrustRelationTypeServiceProvider(client);
            return provider;
        }

        public ITrustRelationRequestInvitationServiceProvider CreateTrustRelationRequestInvitationServiceProvider()
        {
            Configuration config = _config.GetProviderConfiguration(ProviderType.TrustRelation);
            IRestClient client = new JSONClient(config.BaseUrl, config.Authenticator);
            client.PreAuthenticate = true;
            var provider = new TrustRelationRequestInvivationServiceProvider(client);
            return provider;
        }


        public ITrustRelationRequestServiceProvider CreateTrustRelationRequestServiceProvider()
        {
            Configuration config = _config.GetProviderConfiguration(ProviderType.TrustRelation);
            IRestClient client = new JSONClient(config.BaseUrl, config.Authenticator);
            client.PreAuthenticate = true;
            var provider = new TrustRelationRequestServiceProvider(client);
            return provider;
        }

        public ITrustRelationServiceProvider CreateTrustRelationServiceProvider()
        {
            Configuration config = _config.GetProviderConfiguration(ProviderType.TrustRelation);
            IRestClient client = new JSONClient(config.BaseUrl, config.Authenticator);
            client.PreAuthenticate = true;
            var provider = new TrustRelationServiceProvider(client);
            return provider;
        }

        public IPrintingServiceProvider CreatePrintingServiceProvider()
        {
            Configuration config = _config.GetProviderConfiguration(ProviderType.Printer);
            IRestClient client = new JSONClient(config.BaseUrl, config.Authenticator);
            var provider = new PrintingServiceProvider(client);
            return provider;            
        }
    }
}
