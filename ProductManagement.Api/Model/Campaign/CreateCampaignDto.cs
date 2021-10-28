using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Api.Model.Campaign
{
    public class CreateCampaignDto
    {
        public string CampaignName { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int Limit { get; set; }
        public int TargetSalesCount { get; set; }
    }
}
