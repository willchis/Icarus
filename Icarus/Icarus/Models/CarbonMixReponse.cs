using System.Collections.Generic;

namespace Icarus.Models
{
    // Generated from the JSON returned from the https://api.carbonintensity.org.uk/ API.
    //
    // e.g. {"data":{"from":"2020-02-13T00:00Z","to":"2020-02-13T00:30Z","generationmix":
    //[{"fuel":"biomass","perc":10},{"fuel":"coal","perc":2.7},{"fuel":"imports","perc":12.8},
    //{"fuel":"gas","perc":29},{"fuel":"nuclear","perc":26.1},{"fuel":"other","perc":0.6},
    //{"fuel":"hydro","perc":2.7},{"fuel":"solar","perc":0},{"fuel":"wind","perc":16.1}]}}

    public class CarbonMixReponse
    {
        public Data data { get; set; }
    }
    public class Generationmix
    {
        public string fuel { get; set; }
        public double perc { get; set; }
    }

    public class Data
    {
        public string from { get; set; }
        public string to { get; set; }
        public List<Generationmix> generationmix { get; set; }
    }
}
