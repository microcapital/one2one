﻿using System.Threading.Tasks;

namespace OneTwoOne.Module.Pricing.Services
{
    public interface ICouponService
    {
        Task<CouponValidationResult> Validate(long customerId, string couponCode, CartInfoForCoupon cart);

        void AddCouponUsage(long customerId, long orderId, CouponValidationResult couponValidationResult);
    }
}
