using System;
using System.Globalization;
using OneTwoOne.Infrastructure.Localization;

namespace OneTwoOne.Module.Localization.Extensions
{
    public static class CultureInfoExtensions
    {
        public static LanguageDirection GetLanguageDirection(this CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                throw new ArgumentNullException(nameof(cultureInfo));
            }

            return cultureInfo.TextInfo.IsRightToLeft ? LanguageDirection.RTL : LanguageDirection.LTR;
        }
    }
}