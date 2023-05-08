// See https://aka.ms/new-console-template for more information


using System.Net;
using Newtonsoft.Json;
using PolyclinicChecker.Model;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

public class SiteChecker
{
    private string Id => @"bd425865-1ddd-461a-807a-027b87660f3f";
    private Uri Uri => new("https://uslugi.mosreg.ru/");
    private string PoliceNumber => @"5058720877001795";
    private DateTime DateTime => new DateTime(1972, 01, 22);

    public bool Check()
    {
        var authUri = new Uri("https://uslugi.mosreg.ru/zdrav/doctor_appointment/api/personal");
        var payload = @"sPol=&nPol=5058720877001795&birthday=22.01.1972&auth=1&pol=5058720877001795";
        var clientHandler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
        var httpClient = new HttpClient(clientHandler)
        {
            DefaultRequestHeaders =
            {
                {
                    "Cookie",
                    "polis_login_failed=0; da_sPol=; da_nPol=5058720877001795; da_birthday=22.01.1972; da_auth=true; SSESSa8582a3dc976377cc65d7fbc474627fe=zrFT-lgK4DsyH6ctylCN5KrXhqtXrN7TeNXYiLjRUeY; has_js=1"
                },
                { "Accept", "application/json, text/javascript, */*; q=0.01" },
                { "Accept-Encoding", "gzip, deflate, br" },
                { "Accept-Language", "ru-RU,ru;q=0.9" },
                { "Connection", "keep-alive" },
                { "ContentType", "application/x-www-form-urlencoded; charset=UTF-8" },
                { "Host", "uslugi.mosreg.ru" },
                { "Origin", "https,//uslugi.mosreg.ru" },
                { "Referer", "https,//uslugi.mosreg.ru/zdrav/" },
                { "sec-ch-ua", "\"Chromium\";v=\"112\", \"Google Chrome\";v=\"112\", \"Not,A-Brand\";v=\"99\"" },
                { "sec-ch-ua-mobile", "?0" },
                { "sec-ch-ua-platform", "Windows" },
                { "Sec-Fetch-Dest", "empty" },
                { "Sec-Fetch-Mode", "cors" },
                { "Sec-Fetch-Site", "same-origin" },
                { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/112.0.0.0 Safari/537.36" },
                { "X-Requested-With", "XMLHttpRequest" },
            }
        };
        var allTherapethtsUri = new Uri(@"https://uslugi.mosreg.ru/zdrav/doctor_appointment/api/doctors?lpuCode=&departmentId=76&doctorId=&days=14");
        var allTherapPayload = "lpuCode=&departmentId=76&doctorId=&days=14";
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, allTherapethtsUri)
        {
            Content = new StringContent(allTherapPayload),
            Method = HttpMethod.Get,
        };
        var message = httpClient.Send(httpRequestMessage);
        var content = message.Content.ReadAsStringAsync().Result;
        var result = JsonConvert.DeserializeObject<PoliclinicResponse>(content);
        IEnumerable<Items> myMed = result.items.Where(i => i.lpu_code == "010103");
        return myMed.Select(m => m.doctors).Any(doctors =>
            doctors.Where(doctor => doctor.id != "c145d476-c049-4928-99b0-86971825841b8bbc9b32-023c-4a29-8d63-f47d629f3817")
                .Any(doctor => doctor.schedule.Any(schedule => schedule.count_tickets > 0)));
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        // var siteChecker = new SiteChecker();
        // siteChecker.Check();
        var token = "5567816135:AAHf76dljBR6Mx8D3wUBgnE63MjJKp3a8tU";
        var client = new TelegramBotClient(token);
        var task = client.SendTextMessageAsync(new ChatId(415191327), "asdsadasd").Result;
    }
}