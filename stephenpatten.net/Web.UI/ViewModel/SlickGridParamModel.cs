using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.UI.ViewModel
{
    public class SlickGridParamModel
    {
        public string Query { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
        public string Sort { get; set; }
    }
}