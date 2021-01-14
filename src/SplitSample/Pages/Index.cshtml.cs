using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Splitio.Services.Client.Classes;
using SplitSample.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            _logger.LogInformation(MyLogEvents.GetItemNotFound, "before configuration options");
            var config = new ConfigurationOptions();
            _logger.LogInformation(MyLogEvents.GetItemNotFound, "after configuration options {config}", config);

            var factory = new SplitFactory("1o65cgkedt2ur0ra8sgkj3m6buv8on1pdhv4", config);
            var splitClient = factory.Client();
            try
            {
                splitClient.BlockUntilReady(10000);
            }
            catch (Exception ex)
            {

                _logger.Log<ConfigurationOptions>(LogLevel.Debug, MyLogEvents.GetItemNotFound, config, ex, (a, b) => $"{a.AuthServiceURL} is not valid {b.Message}");
                // log & handle
            }


            var treatment = splitClient.GetTreatment("kkraus", // unique identifier for your user
                                               "KevinSplit");

            if (treatment == "on")
            {
                // insert on code here
                System.Diagnostics.Debug.WriteLine("feature is on");
                splitClient.Track("kevinindexget", "playtime", "kevinspliton", 10, new Dictionary<string, object>() { { "meta1", "someinfo" } });

            }
            else if (treatment == "off")
            {
                // insert off code here
                System.Diagnostics.Debug.WriteLine("feature is off");
                splitClient.Track("kevinindexget", "playtime", "kevinsplitoff", 10, new Dictionary<string, object>() { { "meta1", "someinfo" } });

            }
            else
            {
                // insert control code here
            }



        }
    }
}
