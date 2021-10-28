using FluentValidation;
using ProductManagement.Api.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Api.Validation
{
    public class ProductValidator:AbstractValidator<CreateProductDto>
    {
        public ProductValidator()
        {
            RuleFor(product => product.ProductCode).NotEmpty().WithMessage("Product code field is required");

            RuleFor(product => product.Price).NotEmpty().WithMessage("Price field is required");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Price field must be greater than 0");

            RuleFor(product => product.Stock).NotEmpty().WithMessage("Stock field is required");
            RuleFor(product => product.Stock).GreaterThan(0).WithMessage("Stock field must be greater than 0");
        }
    }
}
