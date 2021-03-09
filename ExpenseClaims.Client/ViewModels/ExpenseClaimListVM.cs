using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.ViewModels
{
    public class ExpenseClaimListVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public System.DateTimeOffset SubmitDate { get; set; }

        public System.DateTimeOffset ApprovalDate { get; set; }

        public System.DateTimeOffset ProcessedDate { get; set; }

        public double TotalAmount { get; set; }

        public string Status { get; set; }

        public string RequesterComments { get; set; }

        public string ApproverComments { get; set; }

        public string FinanceComments { get; set; }
    }
}
