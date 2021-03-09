﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.ViewModels
{
    public class ExpenseClaimDetailVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The title of the claim should be 50 characters or less")]
        public string Title { get; set; }

        [Required]
        public System.DateTimeOffset SubmitDate { get; set; }

        public System.DateTimeOffset ApprovalDate { get; set; }

        public System.DateTimeOffset ProcessedDate { get; set; }

        public double TotalAmount { get; set; }

        public string Status { get; set; }

        [StringLength(500, ErrorMessage = "The comment should be 500 characters or less")]
        public string RequesterComments { get; set; }

        [StringLength(500, ErrorMessage = "The comment should be 500 characters or less")]
        public string ApproverComments { get; set; }

        [StringLength(500, ErrorMessage = "The comment should be 500 characters or less")]
        public string FinanceComments { get; set; }

        public System.Collections.Generic.ICollection<ExpenseItemDetailVM> Items { get; set; }
    }
}
