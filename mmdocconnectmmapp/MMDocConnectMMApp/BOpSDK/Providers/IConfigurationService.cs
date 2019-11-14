using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers
{
    public interface IConfigurationService
    {
        Configuration GetProviderConfiguration(ProviderType type);
    }
}
