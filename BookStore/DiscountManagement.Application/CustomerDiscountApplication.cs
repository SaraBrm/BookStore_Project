using _0_Framework.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System.Collections.Generic;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            throw new System.NotImplementedException();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            throw new System.NotImplementedException();
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            throw new System.NotImplementedException();
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            throw new System.NotImplementedException();
        }
    }
}
