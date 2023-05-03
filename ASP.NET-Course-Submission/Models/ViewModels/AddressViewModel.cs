using ASP.NET_Course_Submission.Models.Interfaces;

namespace ASP.NET_Course_Submission.Models.ViewModels
{
    public class AddressViewModel : IAddress
    {
        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
