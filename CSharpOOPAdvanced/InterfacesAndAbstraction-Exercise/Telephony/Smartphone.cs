using System.Linq;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        
        public string Call(string phoneNumber)
        {
            if (phoneNumber.Any(c => !char.IsDigit(c)))
                return "Invalid number!";

            return $"Calling... {phoneNumber}";
        }

        public string Browse(string site)
        {
            if (site.Any(c => char.IsDigit(c)))
                return "Invalid URL!";

            return $"Browsing: {site}!";
        }

    }
}
