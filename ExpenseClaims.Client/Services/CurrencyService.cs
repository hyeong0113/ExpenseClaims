using AutoMapper;
using Blazored.LocalStorage;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Services.Api;
using ExpenseClaims.Client.Services.Base;
using ExpenseClaims.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Services
{
    public class CurrencyService : BaseDataService, ICurrencyService
    {
        private readonly IMapper _mapper;

        public CurrencyService(IMapper mapper, IBaseClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<CurrencyListVM>> GetAllCurrencies()
        {
            await AddBearerToken();

            var currencyList = await _client.GetAllCurrenciesAsync(ApiVersion.apiVersion);
            var mappedCurrencyList = _mapper.Map<IEnumerable<CurrencyListVM>>(currencyList.Data);
            return mappedCurrencyList.ToList();
        }

        public async Task<CurrencyDetailVM> GetCurrencyById(int id)
        {
            await AddBearerToken();

            var currency = await _client.GetCurrencyByIdAsync(id, ApiVersion.apiVersion);
            var mappedCurrency = _mapper.Map<CurrencyDetailVM>(currency.Data);
            return mappedCurrency;
        }

        public async Task<ApiResponse<int>> CreateCurrency(CurrencyDetailVM currency)
        {
            try
            {
                await AddBearerToken();
                var mappedCurrency = _mapper.Map<CreateCurrencyCommand>(currency);
                var response = await _client.CreateCurrencyAsync(ApiVersion.apiVersion, mappedCurrency);
                return new ApiResponse<int>() { Data = response.Data, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ApiResponse<int>> UpdateCurrency(int id, CurrencyDetailVM currency)
        {
            try
            {
                await AddBearerToken();
                var mappedCurrency = _mapper.Map<UpdateCurrencyCommand>(currency);
                var response = await _client.UpdateCurrencyAsync(id, ApiVersion.apiVersion, mappedCurrency);
                return new ApiResponse<int>() { Data = response.Data, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ApiResponse<int>> DeleteCurrency(int id)
        {
            try
            {
                await AddBearerToken();
                var response = await _client.DeleteCurrencyAsync(id, ApiVersion.apiVersion);
                return new ApiResponse<int>() { Data = response.Data, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
