using System.Collections.Generic;
using System.Text;

namespace beaglemapexample.Model
{
    public class ChomokuRegionApiViewModel
    {
        public long Id { get; set; }
        public string KenCode { get; set; }
        public string KenName { get; set; }
        public string CityCode { get; set; }
        public string GstName { get; set; }
        public string Kihon1Code { get; set; }
        public string CssName { get; set; }

        public LongtitudeLatitudeViewModel CentralPoint { get; set; }
        public List<LongtitudeLatitudeViewModel> RangePoints { get; set; } = new List<LongtitudeLatitudeViewModel>();
        
    }
}