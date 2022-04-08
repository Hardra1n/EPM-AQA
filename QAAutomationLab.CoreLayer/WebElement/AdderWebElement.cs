using System;

namespace QAAutomationLab.CoreLayer.WebElement
{
    public class AdderWebElement
    {
        public BaseWebElement AddOneToValueButton { get; set; }

        public BaseWebElement RemoveOneFromValueButton { get; set; }

        public BaseWebElement ValueElement { get; set; }

        public int GetValue()
        {
            try
            {
                return int.Parse(ValueElement.Text);
            }
            catch
            {
                ValueElement._logger.Error("AdderWebElement.GetValue:Error");
                throw;
            }
        }

        public void SetValue(int value)
        {
            int valueDifference = GetValue() - value;
            for (int i = 0; i < Math.Abs(valueDifference); i++)
            {
                if (valueDifference > 0)
                {
                    RemoveOneFromValueButton.Click();
                }
                else
                {
                    AddOneToValueButton.Click();
                }
            }
        }
    }
}
