using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Context
{
   public class OrderContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-VJ74E6E;initial Catalog=MultiShopOrderDb; integrated Security=True;Trust Server Certificate=True");
        }
        DbSet<Address> addresses { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Ordering> Orderings { get; set; }
    }
}
