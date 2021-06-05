using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidHub.API.Domain
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Bid> Bids { get; set; }
    }
}
