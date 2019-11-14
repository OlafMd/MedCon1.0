using BOp.Providers.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.TD
{
    public interface ITenantIntroductionServiceProvider
    {
        void RequestTenantIntroduction(IntroductionRequest  introductionRequest);
        void RespondToTenantIntroduction(IntroductionResponse introductionResponse);
    }
}
