using System.Text;

namespace Application.Extensions
{
    public static class StringExtensions
    {
        public static string GetFullAddress(this string address1, string street, string city, string pincode, string state, string country)
        {
            var addressFormat = new StringBuilder();
            addressFormat.Append(address1);
            if (!string.IsNullOrEmpty(street))
                addressFormat.AppendFormat(", {0}", street);
            if (!string.IsNullOrEmpty(city))
                addressFormat.AppendFormat(", {0}", city);
            if (!string.IsNullOrEmpty(pincode))
                addressFormat.AppendFormat(", {0}", pincode);
            if (!string.IsNullOrEmpty(state))
                addressFormat.AppendFormat(", {0}", state);
            if (!string.IsNullOrEmpty(country))
                addressFormat.AppendFormat(", {0}", country);
            return addressFormat.ToString();
        }
    }
}
