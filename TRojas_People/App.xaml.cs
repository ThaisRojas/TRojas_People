using TRojas_People.Data;

namespace TRojas_People;

public partial class App : Application
{
    private static NotesDatabase database;

    public static NotesDatabase Database
    {
        get
        {
            if (database == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.db3");
                database = new NotesDatabase(dbPath);
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
