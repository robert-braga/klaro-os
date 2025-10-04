using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klaro.Domain
{
    public class Subscription
    {
        public Guid Id { get; private init; }
        public Guid UserId { get; private init; }
        public string Name { get; private set; }

        /// <summary>
        /// Value object property - its objectif is to define an immutable attribute, which doesn't have an identity
        /// </summary>
        public Money Price { get; private set; }
        public DateOnly RenewalDate { get; private set; }
        public string BillingCycle { get; private set; } //Monthly or Yearly

        private Subscription() { }

        public Subscription(Guid id, Guid userId, string name, decimal price, string currency, DateOnly renewalDate, string billingCycle)
        {
            if (price < 0)
            {
                throw new ArgumentException("The price cannot be negative", nameof(price));
            }

            if (billingCycle != "Monthly" || billingCycle != "Yearly")
            {
                throw new ArgumentException("The billing cycle must be either Monthly or Yearly", nameof(billingCycle));
            }

            Id = id;
            UserId = userId;
            Name = name;
            Price = price;
            Currency = currency;
            RenewalDate = renewalDate;
            BillingCycle = billingCycle;
        }

        /// <summary>
        /// Method to control the state of RenewalDate in a safe mode
        /// </summary>
        /// <param name="newDate">The new value for renewal date.</param>
        public void UpdateRenewalDate(DateOnly newDate)
        {
            // Business rule: cannot set a past date as a new renewal date
            if(newDate < DateOnly.FromDateTime(DateTime.UtcNow))
            {
                throw new ArgumentException("A past date cannot be set as Renewal date", nameof(newDate));
            }
        }
    }
}
