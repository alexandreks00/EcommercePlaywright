using PlaywrightSharp;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EcommercePlaywright
{
    public class Home : IDisposable
    {

        public IPage page;
        public IBrowser Browser;
        private string _url = "https://cinemark.hml.cineticket.com.br/";

        public Home()
        {
            if (Browser == null)
            {
                Browser = Task.Run(() => GetBrowserAsync()).Result;
            }
        }

        private async Task<IBrowser> GetBrowserAsync()
        {
            await Playwright.InstallAsync();
            var playwright = await Playwright.CreateAsync();
            return await playwright.Chromium.LaunchAsync(headless: false);
        }

        
        public void Dispose()
        {
            page?.CloseAsync();
        }



        [Fact]
        public async Task AlteraCidade()
        {
            var context = await Browser.NewContextAsync();
            page = await context.NewPageAsync();
            await page.GoToAsync(_url);
            await page.HoverAsync(".location");
            await page.ClickAsync("[id='form-troca-cidade'] .icon");
            await page.ClickAsync("[for='citySlug']");
            await page.ClickAsync("[data-value='salvador']");


        }
    }
}
