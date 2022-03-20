using MotusPloux.Data;
using MotusPloux.Services;
using MotusPloux.Views;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MotusPloux
{
    public partial class App : Application
    {
        private static WordDataBase _database;

        // Create the database connection as a singleton.
        public static WordDataBase Database
        {
            get
            {
                if (_database == null)
                {
                    string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Words.db3");
                    Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                    Stream populatedDatabaseStream = assembly.GetManifestResourceStream("MotusPloux.Words.db3");

                    if (File.Exists(databasePath))
                    {
                        File.Delete(databasePath);
                    }

                    if (!File.Exists(databasePath))
                    {
                        FileStream fileStream = File.Create(databasePath);
                        populatedDatabaseStream.Seek(0, SeekOrigin.Begin);
                        populatedDatabaseStream.CopyTo(fileStream);
                        fileStream.Close();
                    }

                    _database = new WordDataBase(databasePath);
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
