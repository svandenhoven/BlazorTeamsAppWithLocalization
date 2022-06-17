using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Localization;
using System.Globalization; 

namespace BlazorTeamsApp.Utils

{
    public static class LocalizationUtil
    {
        public static void SetCulture(NavigationManager navigationManager)
        {
            var uri = new Uri(navigationManager.Uri);
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("culture", out var culture))
            {
                if (!string.IsNullOrEmpty(culture))
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(culture.ToString());
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture.ToString());
                }
            }
        }
    }
}
