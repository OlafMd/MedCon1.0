using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectUtils
{
    public class TransactionalInformation
    {
        public Boolean IsOpRole { get; set; }
        public Boolean IsAuthenicated;
        public Boolean IsException;
        public bool ReturnStatus { get; set; }
        public List<String> ReturnMessage { get; set; }
        public Hashtable ValidationErrors;
        public string logoutUrl { get; set; }
        public string redirectUrl { get; set; }

        public TransactionalInformation()
        {
            ReturnMessage = new List<String>();
            ReturnStatus = true;
            ValidationErrors = new Hashtable();
            IsAuthenicated = false;
        }
    }
}
