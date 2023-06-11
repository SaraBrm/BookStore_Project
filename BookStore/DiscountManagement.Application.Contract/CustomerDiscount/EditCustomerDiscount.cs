using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class EditCustomerDiscount : DefineCustomerDiscount
    {
        public long Id { get; set; }
    }
}
