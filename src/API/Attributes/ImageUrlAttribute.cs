using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PetStore.Attributes
{
    public class ImageUrlAttribute : ValidationAttribute
    {
        public ImageUrlAttribute() : base("The image must come from imgur.com") { }

        public override bool IsValid(object value)
        {
            try
            {
                var uri = new Uri(value.ToString());
                var match = uri.Host.Equals("i.imgur.com", StringComparison.InvariantCultureIgnoreCase);

                return match;
            }catch(UriFormatException)
            {
                return false;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }
    }
}
