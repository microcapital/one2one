using Microsoft.EntityFrameworkCore;
using OneTwoOne.Infrastructure.Data;
using OneTwoOne.Module.Payments.Models;

namespace OneTwoOne.Module.Payments.Data
{
    public class PaymentsCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentProvider>().ToTable("Payments_PaymentProvider");
        }
    }
}
