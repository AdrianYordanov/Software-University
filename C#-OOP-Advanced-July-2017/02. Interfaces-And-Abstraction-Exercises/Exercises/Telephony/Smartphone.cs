using System;
using System.Collections.Generic;
using System.Linq;

public class Smartphone : ICallable, IBrowsable
{
    private readonly IList<string> numbers;
    private readonly IList<string> sites;

    public Smartphone()
    {
        this.numbers = new List<string>();
        this.sites = new List<string>();
    }

    public void AddPhone(string phone)
    {
        this.numbers.Add(!phone.All(char.IsDigit) ? "Invalid number!" : $"Calling... {phone}");
    }

    public void AddSite(string site)
    {
        this.sites.Add(site.Any(char.IsDigit) ? "Invalid URL!" : $"Browsing: {site}!");
    }

    public string Call()
    {
        return string.Join(Environment.NewLine, this.numbers);
    }

    public string Browse()
    {
        return string.Join(Environment.NewLine, this.sites);
    }
}