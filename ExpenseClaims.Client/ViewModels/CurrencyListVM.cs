using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.ViewModels
{
    public class CurrencyListVM
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public double Rate { get; set; }
    }
}
