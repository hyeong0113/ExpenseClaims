using ExpenseClaims.Application.Interfaces.Shared;
using System;

namespace ExpenseClaims.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}