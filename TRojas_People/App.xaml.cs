using TRojas_People.Data;

namespace TRojas_People;

public partial class App : Application
{
    private static PersonaDatabase database;

    public static PersonaDatabase Database
    {
        get
        {
            if (database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "persona.db3");
                database = new PersonaDatabase(dbPath);
            }
            return database;
        }
    }

    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
