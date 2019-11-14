using BOp.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOp.Exceptions;

namespace BOp
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void test()
        {
            //  try
            //{
            //var provider = ProviderFactory.Instance.CreateSessionServiceProvider();
            //var res = provider.SignIn("test123@test.com", "asdasdas");
            //}
            //  catch (SDKServiceException ex)
            //  {

            //  }
            try
            {
                var provider = ProviderFactory.Instance.CreateAccountServiceProvider();
                var res = provider.GetAllAccountsForTenant(Guid.NewGuid());
            }
            catch (SDKServiceException ex)
            {

            }
            
        }
    }
}
