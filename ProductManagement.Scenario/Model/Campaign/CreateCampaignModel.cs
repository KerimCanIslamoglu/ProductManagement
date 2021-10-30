using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Scenario.Model.Campaign
{
    public class CreateCampaignModel
    {
        public string CampaignName { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int Limit { get; set; }
        public int TargetSalesCount { get; set; }
    }
}
