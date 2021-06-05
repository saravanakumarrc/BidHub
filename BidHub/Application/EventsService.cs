using BidHub.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BidHub.API.Application
{
    public class EventsService
    {

        public Event ProcessBiddings(Event eventInfo)
        {
            do
            {
                decimal currentMaxBid = 0;
                decimal buyerNextBid = 0;

                foreach (var bid in eventInfo.Bids)
                {
                    if (bid.HasExceededMaxBid) continue;

                    buyerNextBid = bid.GetNextBidPrice();

                    if (currentMaxBid < buyerNextBid)
                    {
                        currentMaxBid = buyerNextBid;
                        eventInfo.Winner = bid.BuyerInfo;
                        eventInfo.WinningBid = currentMaxBid;
                    }
                }

            } while (eventInfo.Bids.Count(buyer => !buyer.HasExceededMaxBid) > 1);

            return eventInfo;
        }

    }
}
