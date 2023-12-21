using AdminPortal.Resources;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace AdminPortal.Localizations
{
    public class CultureLocalizer
    {
        private List<LocalizationItem> localizations;

        public void LoadLocalizations(List<LocalizationItem> localizations)
        {
            this.localizations = localizations;
        }

        public string this[string key, string culture]
        {
            get
            {
                //string culture = httpContextAccessor?.HttpContext?.Request?.Cookies?.FirstOrDefault(x => x.Key == "AdminPortalCulture").Value?.Split("|uic=")?.LastOrDefault() ?? "en-US";
                
                var item = localizations.Where(x => x.Key == key).SingleOrDefault();
                if (item == null) return "";

                var value = item.Values.Where(x => x.Key == culture).SingleOrDefault().Value;

                return value;
            }
        }
    }


}
