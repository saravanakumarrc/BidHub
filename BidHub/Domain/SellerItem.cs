using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidHub.API.Domain
{
    public class SellerItem
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public decimal BasePrice { get; set; }
    }
}
