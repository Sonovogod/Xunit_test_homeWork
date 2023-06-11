using Microsoft.AspNetCore.Mvc;
using Xunit;
using XUnitStudyProject.Controllers;
using XUnitStudyProject.Models;


namespace XUnitStudyProject.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.NotNull(result);
            Assert.Equal("Main", result.ViewName);
            Assert.Equal(typeof(IndexViewModel), result.Model.GetType());
            Assert.NotNull(result.Model);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Добрый день, это тестовый текст на главной странице", result?.ViewData["Message"] as string);
        }
        
        [Fact]
        public void PrivacyTest()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Privacy() as ViewResult;
            Assert.Contains("Текст политики конфидециальности", result?.ViewData["Policy"] as string);
            Assert.Equal("Privacy", result?.ViewName);
            Assert.True(result?.Model is null);
            Assert.EndsWith("сайта.", result?.ViewData["Policy"] as string);
            Assert.Equal(39, (result?.ViewData["Policy"] as string).Length);
        }
        
        [Fact]
        public void TestPage()
        {
            HomeController controller = new HomeController();
            int page = 1;
            ViewResult result = controller.TestPage(page) as ViewResult;
            var viewModel = (TestPageViewModel)result.Model;
            Assert.NotNull(result);
            Assert.Equal(typeof(TestPageViewModel), result.Model.GetType());
            Assert.NotNull(result.Model);
            Assert.Equal(++page, controller.ViewBag.PageIncrement);
            Assert.True(viewModel.Page > 0);
        }
    }
}