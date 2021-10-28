using FluentValidation;
using ProductManagement.Api.Model.Campaign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Api.Validation
{
    public class CampaignValidator : AbstractValidator<CreateCampaignDto>
    {
        public CampaignValidator()
        {
            RuleFor(campaing => campaing.CampaignName).NotEmpty().WithMessage("Campaign Name field is required");
            RuleFor(campaing => campaing.ProductCode).NotEmpty().WithMessage("Product Code field is required");

            RuleFor(campaing => campaing.Duration).NotEmpty().WithMessage("Duration field is required");
            RuleFor(campaing => campaing.Duration).GreaterThan(0).WithMessage("Duration field must be greater than 0");

            RuleFor(campaing => campaing.Limit).NotEmpty().WithMessage("Limit field is required");
            RuleFor(campaing => campaing.Limit).GreaterThan(0).WithMessage("Limit field must be greater than 0");

            RuleFor(campaing => campaing.TargetSalesCount).NotEmpty().WithMessage("TargetSalesCount field is required");
            RuleFor(campaing => campaing.TargetSalesCount).GreaterThan(0).WithMessage("TargetSalesCount field must be greater than 0");
        }
    }
}
