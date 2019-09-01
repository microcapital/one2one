﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OneTwoOne.Module.Shipping.Models;
using OneTwoOne.Module.ShippingPrices.Services;
using OneTwoOne.Module.ShippingTableRate.Models;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Core.Services;

namespace OneTwoOne.Module.ShippingTableRate.Services
{
    public class TableRateShippingServiceProvider : IShippingPriceServiceProvider
    {
        public readonly IRepository<PriceAndDestination> _priceAndDestinationRepository;
        private readonly ICurrencyService _currencyService;

        public TableRateShippingServiceProvider(IRepository<PriceAndDestination> priceAndDestinationRepository, ICurrencyService currencyService)
        {
            _priceAndDestinationRepository = priceAndDestinationRepository;
            _currencyService = currencyService;
        }

        public async Task<GetShippingPriceResponse> GetShippingPrices(GetShippingPriceRequest request, ShippingProvider provider)
        {
            var response = new GetShippingPriceResponse { IsSuccess = true };
            var priceAndDestinations = await _priceAndDestinationRepository.Query().ToListAsync();

            var query = priceAndDestinations.Where(x =>
                (x.CountryId == null || x.CountryId == request.ShippingAddress.CountryId)
                && (x.StateOrProvinceId == null || x.StateOrProvinceId == request.ShippingAddress.StateOrProvinceId)
                && (x.DistrictId == null || x.DistrictId == request.ShippingAddress.DistrictId)
                && (x.ZipCode == null || x.ZipCode == request.ShippingAddress.ZipCode)
                && request.OrderAmount >= x.MinOrderSubtotal);

            var cheapestApplicable = query.OrderBy(x => x.ShippingPrice).FirstOrDefault();

            if(cheapestApplicable != null)
            {
                response.ApplicablePrices.Add(new ShippingPrice(_currencyService)
                {
                    Name = "Standard",
                    Price = cheapestApplicable.ShippingPrice
                });
            }

            return response;
        }
    }
}
