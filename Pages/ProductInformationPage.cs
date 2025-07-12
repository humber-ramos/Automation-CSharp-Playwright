using Microsoft.Playwright;

namespace PlaywrightE2E.Pages
{
    public class ProductInformationPage
    {
        private readonly IPage _page;
        private ILocator addToCartButton => _page.GetByRole(AriaRole.Link, new() { Name = "Add to cart" });

        public ProductInformationPage(IPage page)
        {
            _page = page;
        }

        public async Task clickAddToCart()
        {
            await addToCartButton.ClickAsync();
        }
    }
}
