using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class Autocomplete_Data<T> : TransactionalInformation
    {
        public T[] items { get; set; }
    }
}