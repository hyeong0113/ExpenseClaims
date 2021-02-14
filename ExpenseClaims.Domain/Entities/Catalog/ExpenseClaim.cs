using AspNetCoreHero.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Domain.Entities.Catalog
{
    public class ExpenseClaim : AuditableEntity
    {
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

        public virtual ICollection<ExpenseItem> Items { get; set; }
    }
}
