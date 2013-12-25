using System;
using System.Globalization;

namespace Ewk.SoundCloud.ApiLibrary
{
    class DateTimeConverter
    {
        const string Format = "yyyy/MM/dd HH:mm:ss zzzz";

        public DateTime? Convert(string source)
        {
            DateTime result;

            if(DateTime.TryParseExact(source, Format, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out result))
            {
                return result;
            }

            return null;
        }
    }
}