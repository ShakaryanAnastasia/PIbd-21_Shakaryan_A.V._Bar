using BarModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceImplementDataBase
{
    public class BarDbContext : DbContext
    {

        public BarDbContext() : base("BarDatabase")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
            System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Habitue> Habitues { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Cocktail> Cocktails { get; set; }
        public virtual DbSet<Bartender> Bartenders { get; set; }
        public virtual DbSet<CocktailIngredient> CocktailIngredients { get; set; }
        public virtual DbSet<Pantry> Pantrys { get; set; }
        public virtual DbSet<PantryIngredient> PantryIngredients { get; set; }
    }
}
