﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidHub.API.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public short MaxBidders { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AutoIncrementLimit { get; set; }
        public SellerItem SellerItemInfo { get; set; }
        public ICollection<Bid> Bids { get; set; }
        public decimal WinningBid { get; private set; }
        public Buyer Winner { get; private set; }

        public decimal ProcessBids()
        {
            do
            {
                decimal currentMaxBid = 0;
                decimal buyerNextBid = 0;

                foreach (var bid in Bids)
                {
                    if (bid.HasExceededMaxBid) continue;

                    buyerNextBid  = bid.GetNextBidPrice();

                    if(currentMaxBid < buyerNextBid)
                    {
                        currentMaxBid = buyerNextBid;
                        Winner = bid.BuyerInfo;
                        WinningBid = currentMaxBid;
                    }
                }

            } while (Bids.Count(buyer => !buyer.HasExceededMaxBid) > 1);

            return WinningBid;
        }

    }
}
