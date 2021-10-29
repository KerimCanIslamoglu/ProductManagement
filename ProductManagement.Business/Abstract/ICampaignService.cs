using ProductManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Business.Abstract
{
    public interface ICampaignService
    {
        Campaign CreateCampaign(string campaignName, string productCode, int duration, int limit, int targetSalesCount);

        Campaign GetCampaignByName(string campaignName);

    }
}
