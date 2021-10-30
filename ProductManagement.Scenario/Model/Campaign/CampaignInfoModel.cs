using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Scenario.Model.Campaign
{
    public class CampaignInfoModel
    {
        public string CampaignName { get; set; }
        public string Status { get; set; }
        public int TargetSales { get; set; }
        public int TotalSales { get; set; }
        public double TurnOver { get; set; }
        public double AverageItemPrice { get; set; }
    }
}
