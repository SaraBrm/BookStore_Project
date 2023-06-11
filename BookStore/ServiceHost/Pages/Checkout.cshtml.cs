﻿using _0_Framework.Application;
using _0_Framework.Application.ZarinPal;
using _01_BookStoreQuery.Contracts;
using _01_BookStoreQuery.Contracts.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;
using System.Collections.Generic;
using System.Linq;

namespace ServiceHost.Pages
{
    [Authorize]
    public class CheckoutModel : PageModel
    {
        public Cart Cart;
        public const string CookieName = "cart-items";

        private readonly IAuthHelper _authHelper;
        private readonly ICartService _cartService;
        private readonly IProductQuery _productQuery;
        private readonly IZarinPalFactory _zarinPalFactory;
        private readonly IOrderApplication _orderApplication;
        private readonly ICartCalculatorService _cartCalculatorService;

        public CheckoutModel(IAuthHelper authHelper, ICartService cartService, IProductQuery productQuery, 
            IZarinPalFactory zarinPalFactory, IOrderApplication orderApplication, ICartCalculatorService cartCalculatorService)
        {
            Cart = new Cart();
            _authHelper = authHelper;
            _cartService = cartService;
            _productQuery = productQuery;
            _zarinPalFactory = zarinPalFactory;
            _orderApplication = orderApplication;
            _cartCalculatorService = cartCalculatorService;
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            foreach (var item in cartItems)
                item.CalculateTotalItemPrice();

            Cart = _cartCalculatorService.ComputeCart(cartItems);
            _cartService.Set(Cart);

        }

        public IActionResult OnGetPay()
        {
            var cart = _cartService.Get();
            var result = _productQuery.CheckInventoryStatus(cart.Items);
            if (result.Any(x => !x.IsInStock))
                return RedirectToPage("/Cart");

            var orderId = _orderApplication.PlaceOrder(cart);
            var accountUserName = _authHelper.CurrentAccountInfo().Username;
            var paymentResponse = _zarinPalFactory.CreatePaymentRequest(
                    cart.PayAmount.ToString(), "", accountUserName,
                    "خرید از درگاه فرازبوک", orderId);

            return Redirect(
                    $"https://{_zarinPalFactory.Prefix}.zarinpal.com/pg/StartPay/{paymentResponse.Authority}");
        }

        public IActionResult OnGetCallBack([FromQuery] string authority, [FromQuery] string status,
            [FromQuery] long oId)
        {
            return null;
        }
    }
}