using ExpenseClaims.Application.Features.ExpenseItems.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetById
{
    public class GetExpenseClaimByIdResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //public User Requester { get; set; }
        //public User Approver { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string RequesterComments { get; set; }
        public string ApproverComments { get; set; }
        public string FinanceComments { get; set; }

        public ICollection<GetExpenseItemByIdResponse> Items { get; set; }
    }
}
