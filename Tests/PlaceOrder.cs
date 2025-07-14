using PlaywrightE2E.Pages;
using Allure.Xunit.Attributes;
using Xunit;
using Allure.Commons;
using System.Data;

namespace PlaywrightE2E.Tests
{
    public class HomeTests : TestBase
    {
        [AllureTag("E2E", "smoke", "regression", "checkout")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.critical)]
        [AllureOwner("Humberto Ramos")]
        [AllureFeature("Shopping cart")]
        [AllureStory("Purchase of products for a user with an existing account")]
        [Fact]
        public async Task PlaceOrder()
        {
            var homePage = new HomePage(Driver.Page);
            var productInfo = new ProductInformationPage(Driver.Page);
            var cartPage = new CartPage(Driver.Page);
            var orderForm = new OrderForm(Driver.Page);
            var orderConfirmationModal = new OrderConfirmationModal(Driver.Page);

            //Remove any items from the cart
            await homePage.clickCart();
            if(await cartPage.cartHasItems())
            {
                await cartPage.removeCartItems();
            }

            //Add Items
            await homePage.clickHomeButton();
            await homePage.selectPhonesCategory();
            await homePage.clickNokiaLumiaOption();            
            await productInfo.clickAddToCart();          
            await homePage.clickHomeButton();
            await homePage.selectPhonesCategory();
            await homePage.scrollDown();
            await homePage.clickHTCOption();
            await productInfo.clickAddToCart();
            await homePage.clickHomeButton();
            await homePage.selectLaptopsCategory();
            await homePage.clickSonyVaioOption();
            await productInfo.clickAddToCart();
            await homePage.clickHomeButton();
            await homePage.selectLaptopsCategory();
            await homePage.scrollDown();
            await homePage.clickMacBookProOption();
            await productInfo.clickAddToCart();
            await homePage.clickHomeButton();
            await homePage.selectMonitorsCategory();
            await homePage.clickAppleMonitorOption();
            await productInfo.clickAddToCart();

            //Go to cart and remove some items
            await homePage.clickCart();
            await cartPage.clickDeleteButton("HTC One M9"); //remove a specific item
            await cartPage.clickDeleteButton("MacBook Pro");

            //Fill out form to complete order
            await cartPage.clickPlaceOrderButton();
            await orderForm.FillNameField();
            await orderForm.FillCountryField();
            await orderForm.FillCityField();
            await orderForm.FillCreditCardField();
            await orderForm.FillMonthField();
            await orderForm.FillYearField();
            await orderForm.pressTab(); //this will help scroll down so the "purchase" button is visible
            await orderForm.clickPurchaseButton();

            //Assert
            var orderIsPlaced = await orderConfirmationModal.orderIsConfirmed();
            Assert.True(orderIsPlaced);

            await orderConfirmationModal.clickOKButton();
            await orderForm.clickCloseButton();
        }
    }
}
