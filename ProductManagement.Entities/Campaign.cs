using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Entities
{
    public class Campaign
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public int Duration { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public int TotalSales { get; set; }
        public double TurnOver { get; set; }
        public double AverageItemPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
