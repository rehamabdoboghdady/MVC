using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationUserIdentity : IdentityUser
    {

    }
    public class ApplicationUserStore : UserStore<ApplicationUserIdentity>
    {
        public ApplicationUserStore() : base(new ApplicationDBContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager()
            : base(new RoleStore<IdentityRole>(new ApplicationDBContext()))
        {

        }
        public ApplicationRoleManager(DbContext db)
            : base(new RoleStore<IdentityRole>(db))
        {

        }
    }
    public class ApplicationUserManager : UserManager<ApplicationUserIdentity>
    {
        public ApplicationUserManager() : base(new ApplicationUserStore())
        {

        }
        public ApplicationUserManager(DbContext db) : base(new ApplicationUserStore(db))
        {

        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category category { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("OrderUser")]
        public string userId { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int discount { get; set; }
        public virtual ApplicationUserIdentity OrderUser { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
    public class OrderDetails
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        public int TotalPrice { get; set; }

        [ForeignKey("OrderID ")]
        public virtual Order order { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product product { get; set; }
    }
    public class ApplicationDBContext : IdentityDbContext<ApplicationUserIdentity>
    {

    

         public ApplicationDBContext() :  base("name=SuperCs")
        {

        }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> products { get; set; }
        public virtual DbSet<Category> categoriess { get; set; }
        public virtual DbSet<OrderDetails> orderDetails { get; set; }
    }


}
