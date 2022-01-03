using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace ClassLibraryEntity
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext() : base("Data Source=.\\SQLExpress01;Initial Catalog=DbMiniProjetEcommerce;Integrated Security=True")
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Commande> Commandes { get; set; }
        public DbSet<Produit> Produits { get; set; }

    }
}
