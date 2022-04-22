using QAAutomationLab.BusinessLayer.PageObjects.Articles.Components;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Articles
{
    public class ArticlesMainPage : BasePage
    {
        public ArticlesMainPage()
            : base()
        {
            TopicsContainer = new ArticlesTopicsContainer();
            ArticlesContainer = new ArticlesContainer();
        }

        public ArticlesTopicsContainer TopicsContainer { get; private set; }

        public ArticlesContainer ArticlesContainer { get; private set; }
    }
}
