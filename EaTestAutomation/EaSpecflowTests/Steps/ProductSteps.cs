using EaSpecflowTests.Models;
using EaSpecflowTests.Pages;
using Microsoft.Playwright;
using TechTalk.SpecFlow.Assist;

namespace EaSpecflowTests.Steps;

[Binding]
public sealed class ProductSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly IProductPage _productPage;
    private readonly IProductListPage _productListPage;

    public ProductSteps(ScenarioContext scenarioContext, IProductPage productPage, IProductListPage productListPage)
    {
        _scenarioContext = scenarioContext;
        _productPage = productPage;
        _productListPage = productListPage;
    }


    [Given(@"I click the Product menu")]
    public async Task GivenIClickTheProductMenu()
    {
        await _productListPage.CreateProductAsync();
    }

    [Given(@"I create product with following details")]
    public async Task GivenICreateProductWithFollowingDetails(Table table)
    {
        var product = table.CreateInstance<Product>();
        
        await _productPage.CreateProduct(product);
        await _productPage.ClickCreate();
        
        _scenarioContext.Set(product);
    }

    [When(@"I click the Details link of the newly created product")]
    public async Task WhenIClickTheDetailsLinkOfTheNewlyCreatedProduct()
    {
        var product = _scenarioContext.Get<Product>();
        await _productListPage.ClickProductFromList(product.Name);
    }

    [Then(@"I see all the product details are created as expected")]
    public async Task ThenISeeAllTheProductDetailsAreCreatedAsExpected()
    {
        var product = _scenarioContext.Get<Product>();
        
        var element = _productListPage.IsProductCreated(product.Name);
        await Assertions.Expect(element).ToBeVisibleAsync();
    }
}