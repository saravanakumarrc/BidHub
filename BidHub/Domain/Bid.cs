using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidHub.API.Domain
{
    public class Bid
    {
        public Buyer BuyerInfo { get; set; }
        public int EventId { get; set; }
        public decimal StartingBid { get; set; }
        public decimal MaxBid { get; set; }
        public decimal AutoIncrementAmount { get; set; }
        public decimal CurrentBid { get; private set; }
        public bool HasExceededMaxBid { get; private set; }

        public Bid(int eventId, decimal startingBid, decimal maxBid, decimal autoIncrementAmount)
        {

        }

        /// <summary>
        /// Get the next bid and also increment the CurrentBid
        /// </summary>
        /// <returns></returns>
        public decimal GetNextBidPrice()
        {
            if (CurrentBid == 0)
            {
                CurrentBid = StartingBid;
            }
            else if (MaxBid <= (CurrentBid + AutoIncrementAmount))
            {
                CurrentBid = CurrentBid + AutoIncrementAmount;
            }
            else
            {
                HasExceededMaxBid = true;
            }

            return CurrentBid;
        }
    }
}
