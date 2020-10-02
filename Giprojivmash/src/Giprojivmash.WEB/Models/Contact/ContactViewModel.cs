using Giprojivmash.DataModels.Enums;

namespace Giprojivmash.WEB.Models.Contact
{
    public class ContactViewModel : BaseViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string Patronymic { get; set; }

        public string Photo { get; set; }

        public string Position { get; internal set; }

        public PositionType PositionType { get; set; }
    }
}
