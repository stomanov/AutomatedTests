using NUnit.Framework;
using SeleniumProject.BaseProject;
using SeleniumProject.Pages.AutomateThePlanet;
using System.Linq;

namespace SeleniumProject.Tests.AutomateThePlanet
{
    public class AutomateThePlanetTests : BaseTest
    {
        private HomePage homePage;
        private BlogPage blogPage;
        private ArticlePage articlePage;

        [SetUp]
        public void Setup()
        {
            homePage = new HomePage(Driver);
            blogPage = new BlogPage(Driver);
            articlePage = new ArticlePage(Driver);

            Driver.NavigateTo(homePage.URL);
            homePage.BlogButton.WaitAndClick();
            blogPage.Articles[0].WaitAndClick();
            Driver.NavigateTo("https://www.automatetheplanet.com/api-usability-part-one/");
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void ArticleMainTitlesIsTheSameNameWithTheHeader_When_Compared()
        {
            for (int index = 0; index < articlePage.NavigationMainTitles.Count; index++)
            {
                articlePage.ScrollTo(articlePage.QuickNavigation);
                articlePage.ScrollUp(120);

                var text = articlePage.NavigationMainTitles[index].Text;

                articlePage.NavigationMainTitles[index].WaitAndClick();
                Assert.IsTrue(articlePage.MainHeaders[index].Displayed);
            }

            var navigationTitles = articlePage.NavigationMainTitles.Select(e => e.Text).ToList();
            var titles = articlePage.MainHeaders.Select(e => e.Text).ToList();
            CollectionAssert.AreEqual(navigationTitles, titles);
        }

        [Test]
        public void TagNamesAlwaysIsh2Andh3_When_Compared()
        {
            var mainTitlesTags = articlePage.MainHeaders.Select(e => e.TagName).ToList();
            var smallTitleTags = articlePage.SecondaryHeaders.Select(e => e.TagName).ToList();

            mainTitlesTags.ForEach(t => Assert.AreEqual("h2", t));
            smallTitleTags.ForEach(t => Assert.AreEqual("h3", t));

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