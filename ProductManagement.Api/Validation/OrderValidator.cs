using FluentValidation;
using ProductManagement.Api.Model.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Api.Validation
{
    public class OrderValidator : AbstractValidator<CreateOrderDto>
    {
        public OrderValidator()
        {
            RuleFor(order => order.ProductCode).NotEmpty().WithMessage("Product code field is required");
            RuleFor(order => order.Quantity).NotEmpty().WithMessage("Quantity field is required");
            RuleFor(order => order.Quantity).GreaterThan(0).WithMessage("Quantity field must be greater than 0");
        }
    }
}
