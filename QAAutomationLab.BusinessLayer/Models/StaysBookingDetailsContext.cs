namespace QAAutomationLab.BusinessLayer.Models
{
    public class StaysBookingDetailsContext
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ConfirmEmail { get; set; }

        public static StaysBookingDetailsContext GetDefaultContext()
        {
            return new StaysBookingDetailsContext()
            {
                FirstName = "Korora",
                LastName = "Foreza",
                Email = "differentmail@yand.ru",
                ConfirmEmail = "differentmail@yand.ru"
            };
        }
    }
}
