using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Contracts
{
    public interface IRefresh
    {
        event Action RefreshRequested;
        void CallRequestRefresh();
    }
}
