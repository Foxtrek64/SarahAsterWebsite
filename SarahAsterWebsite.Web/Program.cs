using System;
using System.Threading.Tasks;
using System.Linq;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace SarahAsterWebsite.Web
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var bootstrapper = Bootstrapper
                .Factory
                .CreateWeb(args)
                .ConfigureSettings(settings =>
                {
                    settings[Keys.Host] = args.Contains("--development") || args.Contains("preview") ? string.Empty : "sarahaster.ghpages.com";
                })
                .AddShortcode(Constants.EditLink,
                    (content, parameters, document, context)
                    => document[Constants.EditLink] is string editLink ? editLink : "https://github.com/Foxtrek64/SarahAsterWebsite");

            /*
            // Currently broken. Comment out for now.
            bootstrapper.DeployToGithubPagesBranch(
                "Foxtrek64",
                "SarahAsterWebsite",
                Config.FromSettings<string>("GITHUB_TOKEN"),
                "gh_pages"
            );
            */

            return await bootstrapper.RunAsync();
        }
    }
}
