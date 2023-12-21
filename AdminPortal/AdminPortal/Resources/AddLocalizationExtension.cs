using AdminPortal.Localizations;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AdminPortal.Resources
{
    public static class AddLocalizationExtension
    {
        public static IServiceCollection AddInfraLocalization(this IServiceCollection services)
        {
            services.AddSingleton<CultureLocalizer>();

            return services;
        }

        public static WebApplication UseInfraLocalization(this WebApplication app)
        {
            var cultureLocalizer = app.Services.GetRequiredService<CultureLocalizer>();

            string fileContent = GetLocalizationJsonContent();
            var localizations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LocalizationItem>>(fileContent);

            cultureLocalizer.LoadLocalizations(localizations);

            return app;
        }

        private static string GetLocalizationJsonContent()
        {
            var assembly = Assembly.GetEntryAssembly();

            string result = "";
            string fileName = assembly.GetName().Name + ".localization.json";
            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }

            return result;
        }
    }

    public class LocalizationItem
    {
        public LocalizationItem()
        {
            Values = new Dictionary<string, string>();
        }

        public string Key { get; set; }
        public Dictionary<string, string> Values { get; set; }
    }
}
