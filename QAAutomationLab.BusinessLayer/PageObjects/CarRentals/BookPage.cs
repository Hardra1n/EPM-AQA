using QAAutomationLab.CoreLayer.BasePage;

namespace QAAutomationLab.BusinessLayer.PageObjects.CarRentals
{
    public class BookPage : BasePage
    {
        public BookPage()
            : base()
        {
            BookPageDetailsBar = new BookPageDetailsBar();
        }

        public BookPageDetailsBar BookPageDetailsBar { get; private set; }
    }
}
