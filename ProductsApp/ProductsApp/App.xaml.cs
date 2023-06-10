using ProductsApp.Database;
using ProductsApp.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProductsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // tworzenie bazy danych 
            var database = new ProductsDbContext();

            // upewnia się że baza danych jest stworzona, jeśli jest to używa istniejącej
            database.Database.EnsureCreated();

            // przypisanie do databaseLocator bazy danych m
            DatabaseLocator.Database = database;
        }
    }
}
