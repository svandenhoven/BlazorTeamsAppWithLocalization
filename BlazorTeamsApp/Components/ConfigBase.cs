using BlazorTeamsApp.Interop.TeamsSDK;
using BlazorTeamsApp.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace BlazorTeamsApp.Components
{
    public class ConfigBase : ComponentBase
    {
        [Inject] protected NavigationManager NavMan { get; set; }
        [Inject] private MicrosoftTeams MicrosoftTeams { get; set; }
        [Inject] protected IStringLocalizer<ConfigBase> Loc { get; set; }

        private Guid _entityId = Guid.NewGuid();
        protected string _buttonText;
             
        protected override void OnInitialized()
        {
            base.OnInitialized();
            _buttonText = Loc["Click"];
        }

        protected async Task ButtonClicked()
        {
            LocalizationUtil.SetCulture(NavMan);

            _buttonText = Loc["Language"];

            var settings = new TeamsInstanceSettings
            {
                SuggestedDisplayName = "My Tab",
                EntityId = _entityId.ToString(),
                ContentUrl = $"{NavMan.BaseUri}/tab",
                WebsiteUrl = $"{NavMan.BaseUri}/tab"
            };

            await MicrosoftTeams.InitializeAsync();
            await MicrosoftTeams.RegisterOnSaveHandlerAsync(settings);
        }
    }
}
