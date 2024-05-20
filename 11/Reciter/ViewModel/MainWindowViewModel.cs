using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Reciter.Data;
using Reciter.Entity;

namespace Reciter.ViewModel;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SubmitCommand))]
    private string _inputEnglish = string.Empty;

    [ObservableProperty]
    private string _english = string.Empty;

    [ObservableProperty]
    private string _chinese = string.Empty;

    [ObservableProperty]
    private string _result = string.Empty;

    private List<Word> Words { get; } = [];

    [RelayCommand(CanExecute = nameof(CanSubmit))]
    private void Submit()
    {
        Result = string.Equals(InputEnglish, English, StringComparison.CurrentCultureIgnoreCase) ? "Correct" : "Wrong. Please try again.";
    }

    private bool CanSubmit() => InputEnglish != string.Empty;

    [RelayCommand]
    private void Next()
    {
        SelectRandomWord();
    }

    private void SelectRandomWord()
    {
        var random = new Random();
        var word = Words[random.Next(Words.Count)];

        English = word.English;
        Chinese = word.Chinese;
        Result = "Not submitted";
        InputEnglish = string.Empty;
    }
    
    private void Reset()
    {
        Result = string.Empty;
        InputEnglish = string.Empty;
    }

    public MainWindowViewModel()
    {
        Words.Clear();

        using var context = new ReciterDataContext();
        foreach (var word in context.Words)
        {
            Words.Add(word);
        }

        SelectRandomWord();
    }
}