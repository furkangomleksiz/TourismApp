using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourismApp.Domain.Entities
{
    public class OrderPayment
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid TourProductPriceId { get; set; }
        public OrderTourProductPrice OrderTourProductPrice { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal Amount { get; set; }
    }
    public enum PaymentType
    {
        Payment,
        Payback
    }
}