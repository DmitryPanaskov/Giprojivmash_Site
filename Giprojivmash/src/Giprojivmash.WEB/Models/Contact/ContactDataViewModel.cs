using Giprojivmash.DataModels.Enums;

namespace Giprojivmash.WEB.Models.Contact
{
    public class ContactDataViewModel : BaseViewModel
    {
        public int ContactId { get; set; }

        public string Data { get; set; }

        public string SubData { get; set; }

        public ContactDataType ContactDataType { get; set; }
    }
}
