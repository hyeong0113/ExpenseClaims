using ExpenseClaims.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Wrapper.ExpenseItem
{
    public class ExpenseItemWrapper
    {
        public ExpenseItemDetailVM Item { get; set; }
        public bool IsExist { get; set; }

        public ExpenseItemWrapper(ExpenseItemDetailVM item, bool isExist)
        {
            Item = item;
            IsExist = isExist;
        }
    }
}
