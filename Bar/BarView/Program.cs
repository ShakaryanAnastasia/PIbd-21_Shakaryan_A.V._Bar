using BarServiceDAL.Interfaces;
using BarServiceImplement.Implementations;
using BarServiceImplementDataBase;
using BarServiceImplementDataBase.Implementations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace BarView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, BarDbContext>(new
HierarchicalLifetimeManager());
            currentContainer.RegisterType<IHabitueService, HabitueServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIngredientService, IngredientServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICocktailService, CocktailServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPantryService, PantryServiceDB>(new
            HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
