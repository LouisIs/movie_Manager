using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rabaswende002.Models;

namespace Rabaswende002.ViewModel
{
    public class NewcustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}