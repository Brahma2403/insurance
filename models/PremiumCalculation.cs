using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace insuranceWebApi.models
{
    public class PremiumCalculation
    {
        [Key]
        public int CalculationId { get; set; }

        [ForeignKey("Policy")]
        public int PolicyId { get; set; }
        public virtual Policy Policy { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public double BasePremium { get; set; }

        public double AdjustedPremium { get; set; }
    }
}
