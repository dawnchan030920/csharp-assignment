using System.Net.Http;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HtmlAgilityPack;

namespace SearchEngine;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string? _searchText;

    [ObservableProperty]
    private string? _baiduResult;

    [ObservableProperty]
    private string? _bingResult;

    [RelayCommand]
    private async Task Search()
    {
        await SearchBaidu();
        await SearchBing();
    }
    
    private async Task SearchBaidu()
    {
        using var client = new HttpClient();
        var response = await client.GetAsync("https://www.baidu.com/s?wd=" + SearchText);
        BaiduResult = GetTwoHundredContent(await response.Content.ReadAsStringAsync());
    }
    
    private async Task SearchBing()
    {
        using var client = new HttpClient();
        var response = await client.GetAsync("https://www.bing.com/search?q=" + SearchText);
        BingResult = GetTwoHundredContent(await response.Content.ReadAsStringAsync());
    }
    
    private static string GetTwoHundredContent(string html)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(html);
        var paragraph = doc.DocumentNode.SelectNodes("//p");
        var sb = new StringBuilder();
        foreach (var p in paragraph)
        {
            sb.Append(p.InnerText);
            if (sb.Length > 200)
            {
                break;
            }
        }
        return sb.ToString();
    }
}