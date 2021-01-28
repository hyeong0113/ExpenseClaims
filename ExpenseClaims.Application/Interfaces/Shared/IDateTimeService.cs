using System;

namespace ExpenseClaims.Application.Interfaces.Shared
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}