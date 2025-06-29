using TRojas_People.Models;

namespace TRojas_People;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        LoadNotes(); // Carga notas al iniciar
    }

    private async void OnSaveNoteClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(noteEntry.Text))
        {
            var note = new Persona
            {
                Text = noteEntry.Text,
                Date = DateTime.Now
            };

            await App.Database.SaveNoteAsync(note);
            noteEntry.Text = string.Empty;
            await LoadNotes();
        }
    }

    private async Task LoadNotes()
    {
        var notes = await App.Database.GetNotesAsync();
        notesListView.ItemsSource = notes;
    }
}

