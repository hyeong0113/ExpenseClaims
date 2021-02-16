﻿using ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetById;
using ExpenseClaims.Application.Wrappers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseClaim
{
    public partial class ExpenseClaimDetail
    {
        private const int apiVersion = 1;
        public GetExpenseClaimByIdResponse Claim { get; set; } = null;

        [Parameter]
        public int ClaimId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);

            ClaimId = ClaimId;
            var response = await Http.GetFromJsonAsync<Response<GetExpenseClaimByIdResponse>>($"api/v{apiVersion}/ExpenseClaim/{ClaimId}");
            Claim = response.Data;
        }
    }
}
