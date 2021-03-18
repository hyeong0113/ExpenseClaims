using AspNetCoreHero.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetAllPaged
{
    public class GetAllExpenseClaimsResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string RequesterId { get; set; }
        public string ApproverId { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string RequesterComments { get; set; }
        public string ApproverComments { get; set; }
        public string FinanceComments { get; set; }
    }
}
