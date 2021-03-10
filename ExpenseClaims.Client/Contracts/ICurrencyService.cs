using ExpenseClaims.Client.Services.Base;
using ExpenseClaims.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Contracts
{
    public interface ICurrencyService
    {
        Task<List<CurrencyListVM>> GetAllCurrencies();
        Task<CurrencyDetailVM> GetCurrencyById(int id);
        Task<ApiResponse<int>> CreateCurrency(CurrencyDetailVM currency);
        Task<ApiResponse<int>> UpdateCurrency(int id, CurrencyDetailVM currency);
        Task<ApiResponse<int>> DeleteCurrency(int id);
    }
}
