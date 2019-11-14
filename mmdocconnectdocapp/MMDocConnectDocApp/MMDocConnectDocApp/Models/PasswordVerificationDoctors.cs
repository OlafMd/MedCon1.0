using MMDocConnectDocAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MMDocConnectDocApp.Models
{
    public class PasswordVerificationDoctors
    {
        public List<AutocompleteModel> doctors { get; set; }
        public bool is_practice { get; set; }
    }
}