using BOp.Exceptions;
using BOp.Providers.Message;
using BOp.Providers.Message.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.TD
{
    public class TenantIntroductionServiceProvider : ITenantIntroductionServiceProvider
    {
        public void RequestTenantIntroduction(Message.IntroductionRequest introductionRequest)
        {
            try
            {
                Guid ownTenant = Guid.Parse(introductionRequest.RequestingTenantId);
                Guid targetTenant = Guid.Empty;
                var builder = MessageBuilder.ForMessage(new MessageTarget(ownTenant), new MessageTarget(targetTenant), IntroductionRequest.MESSAGE_TYPE, introductionRequest.ToPayload()).setMessageID(Guid.NewGuid());
                builder.setMessageType("tenant-introduction");

                var message = builder.build();
                var provider = ProviderFactory.Instance.CreateMessageServiceProvider();
                try
                {
                    provider.SendMessage(message);
                }
                catch (SDKServiceException ex)
                {
                    throw new SDKServiceException(ex.Message, ex.ServiceError);
                }
                catch (MessageException ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("Could not parse guid", ex);
            }
            catch (FormatException ex)
            {
                throw new Exception("Could not parse guid", ex);
            }
        }

        public void RespondToTenantIntroduction(Message.IntroductionResponse introductionResponse)
        {
            try
            {
                Guid ownTenant = Guid.Parse(introductionResponse.ApprovingTenantID);
                Guid targetTenant = Guid.Empty;
                var builder = MessageBuilder.ForMessage(new MessageTarget(ownTenant), new MessageTarget(targetTenant), IntroductionResponse.MESSAGE_TYPE, introductionResponse.ToPayload());
                builder.setMessageType("tenant-introduction");
                var message = builder.build();
                var provider = ProviderFactory.Instance.CreateMessageServiceProvider();
                try
                {
                    provider.SendMessage(message);
                }
                catch (SDKServiceException ex)
                {
                    throw new SDKServiceException(ex.Message, ex.ServiceError);
                }
                catch (MessageException ex)
                {
                    throw new Exception(ex.Message, ex);
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("Could not parse guid", ex);
            }
            catch (FormatException ex)
            {
                throw new Exception("Could not parse guid", ex);
            }
        }
    }
}
