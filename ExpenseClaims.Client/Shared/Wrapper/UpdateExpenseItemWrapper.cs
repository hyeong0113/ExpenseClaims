using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Shared.Wrapper
{
    public class UpdateExpenseItemWrapper : CreateExpenseItemWrapper
    {
        public int Id { get; set; }
    }
}
