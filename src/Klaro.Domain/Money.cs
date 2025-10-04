using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klaro.Domain
{
    /// <summary>
    /// Value object definition for Money
    /// - record = to make it immutable and because it offers equality based on properties values
    /// - struct = because it's lighter than a class and efficient for small objects
    /// </summary>
    public record struct Money
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; }

        public Money(decimal amount, string currency)
        {
            if (string.IsNullOrWhiteSpace(currency))
            {
                throw new ArgumentException("Currency must be provided", nameof(currency));
            }

            Amount = amount;
            Currency = currency;
        }
    }
}
