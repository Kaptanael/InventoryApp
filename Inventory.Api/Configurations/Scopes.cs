using IdentityServer4.Models;

namespace Inventory.Api.Configurations
{
    internal static class Scopes
    {
        public static List<ApiScope> GetScopes()
        {
            var scopes = new List<ApiScope>
            {
                new ApiScope
                {
                    Name ="recruitment.fullaccess",
                    Enabled = true,
                    DisplayName = "Recruitment Web API Resource"
                }
            };            
            return scopes;
        }        
    }    
}
