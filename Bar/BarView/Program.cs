using BarServiceDAL.Interfaces;
using BarServiceImplement.Implementations;
using System;
using System.Collections.Generic;
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
            currentContainer.RegisterType<IHabitueService, HabitueServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IIngredientService, IngredientServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICocktailService, CocktailServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceList>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPantryService, PantryServiceList>(new
            HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
