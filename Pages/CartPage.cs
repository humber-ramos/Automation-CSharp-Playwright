using Microsoft.Playwright;

namespace PlaywrightE2E.Pages
{
    public class CartPage
    {
        private readonly IPage _page;
        private ILocator specificDeleteButton(string name) => _page.Locator($"tr:has-text('{name}') a").First;
        private ILocator generalDeleteButton => _page.GetByRole(AriaRole.Link, new() { Name = "Delete" }).First;
        private ILocator totalPrice => _page.GetByRole(AriaRole.Heading, new() { Name = "2010" });
        private ILocator placeOrderButton => _page.GetByRole(AriaRole.Button, new() { Name = "Place Order" });
        private ILocator cartItem => _page.Locator("#tbodyid");

        public CartPage(IPage page)
        {
            _page = page;
        }

        public async Task clickDeleteButton(string name)
        {
            await specificDeleteButton(name).WaitForAsync();
            await specificDeleteButton(name).ClickAsync();
        }
        public async Task clickPlaceOrderButton()
        {
            await totalPrice.WaitForAsync();
            await placeOrderButton.ClickAsync();
        }
        public async Task removeCartItems()
        {
            while (await generalDeleteButton.IsVisibleAsync())
            {
                await generalDeleteButton.ClickAsync();
                await Task.Delay(1000);
            }
        }
        public async Task<bool> cartHasItems()
        {
            try
            {
                await cartItem.WaitForAsync(new()
                {
                    State = WaitForSelectorState.Visible,
                    Timeout = 1000
                });
            } catch (TimeoutException)
            {
                return false;
            }
            return true;
        }
    }
}
