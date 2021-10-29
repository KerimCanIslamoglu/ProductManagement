using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Api.Model.Campaign
{
    public class CampaignInfoDto
    {
        public string CampaignName { get; set; }
        public string Status { get; set; }
        public int TargetSales { get; set; }
        public int TotalSales { get; set; }
        public double TurnOver { get; set; }
        public double AverageItemPrice { get; set; }
    }
}
