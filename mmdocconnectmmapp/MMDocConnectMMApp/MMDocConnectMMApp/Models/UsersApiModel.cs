using MMDocConnectDocAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectMMApp.Models
{
    public class UsersApiModel
    {
        public List<Employee_Model> users { get; set; }

        public User user { get; set; }
    }
}