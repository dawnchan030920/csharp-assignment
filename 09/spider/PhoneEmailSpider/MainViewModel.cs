using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.RegularExpressions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PhoneEmailSpider;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private string _url;

    [ObservableProperty] private string _status = "OK";

    public ObservableCollection<string> Emails { get; } = new();

    public ObservableCollection<string> Phones { get; } = new();

    [RelayCommand]
    private async Task GetPhonesAndEmails()
    {
        try
        {
            using var client = new HttpClient();
            var content = await client.GetStringAsync(Url);

            var emailPattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}"; // email with @ and domain
            var emailMatches = Regex.Matches(content, emailPattern);
            Emails.Clear();
            foreach (Match match in emailMatches) Emails.Add(match.Value);

            var phonePattern = @"\b\d{3}[-.]?\d{4}[-.]?\d{4}\b"; // 11 decimal digits with - or . separator
            var phoneMatches = Regex.Matches(content, phonePattern);
            Phones.Clear();
            foreach (Match match in phoneMatches) Phones.Add(match.Value);
        }
        catch (Exception ex)
        {
            Status = $"Error: {ex.Message}";
        }
    }
}
