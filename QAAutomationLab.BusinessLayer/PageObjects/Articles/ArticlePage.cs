using QAAutomationLab.BusinessLayer.PageObjects.Articles.Components;
using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.Articles
{
    public class ArticlePage : BasePage
    {
        public ArticlePage()
            : base()
        {
            MainContent = new ArticleMainContent();
        }

        public ArticleMainContent MainContent { get; private set; }
    }
}
