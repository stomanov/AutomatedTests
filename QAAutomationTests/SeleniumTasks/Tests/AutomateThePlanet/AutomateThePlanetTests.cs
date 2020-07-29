using NUnit.Framework;
using SeleniumTasks.Pages.AutomateThePlanet;
using System.Linq;

namespace SeleniumTasks.Tests.AutomateThePlanet
{
    public class AutomateThePlanetTests : BaseTest
    {
        private HomePage _homePage;
        private BlogPage _blogPage;
        private ArticlePage _articlePage;

        [SetUp]
        public void Setup()
        {
            InitializeMaximizedBrowser();

            _homePage = new HomePage(Driver);
            _blogPage = new BlogPage(Driver);
            _articlePage = new ArticlePage(Driver);

            Driver.NavigateTo(_homePage.URL);
            _homePage.BlogButton.Click();
            _blogPage.Articles[0].Click();
            Driver.NavigateTo("https://www.automatetheplanet.com/api-usability-part-one/");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

        [Test]
        public void ArticleMainTitlesIsTheSameNameWithTheHeader_When_Compared()
        {
            for (int index = 0; index < _articlePage.NavigationMainTitles.Count; index++)
            {
                Driver.ScrollToElement(_articlePage.QuickNavigation);
                _articlePage.ScrollUp(120);

                var text = _articlePage.NavigationMainTitles[index].Text;

                _articlePage.NavigationMainTitles[index].Click();
                Assert.IsTrue(_articlePage.MainHeaders[index].Displayed);
            }

            var navigationTitles = _articlePage.NavigationMainTitles.Select(e => e.Text).ToList();
            var titles = _articlePage.MainHeaders.Select(e => e.Text).ToList();

            CollectionAssert.AreEqual(navigationTitles, titles);
        }

        [Test]
        public void TagNamesAlwaysIsh2Andh3_When_Compared()
        {
            var mainTitlesTags = _articlePage.MainHeaders.Select(e => e.TagName).ToList();
            var smallTitleTags = _articlePage.SecondaryHeaders.Select(e => e.TagName).ToList();

            for (int i = 0; i < mainTitlesTags.Count; i++)
            {
                Assert.AreEqual("h2", mainTitlesTags[i]);
            }

            for (int i = 0; i < smallTitleTags.Count; i++)
            {
                Assert.AreEqual("h3", smallTitleTags[i]);
            }
        }
    }
}