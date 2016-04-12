using System.Collections.Generic;
using System.Text;

namespace beaglemapexample.Model
{
    public class ChomokuResultApiViewModel
    {
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public List<ChomokuRegionApiViewModel> ChomokuRegionApiViewModels { get; set; }
    }
}