using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.UI.Models
{
    public class FoodDescription
    {
        public string NDB_No { get; set; }
        public string FdGrp_Cd { get; set; }
        public string Long_Desc { get; set; }
        public string Shrt_Desc { get; set; }
        public string ComName { get; set; }
        public string ManufacName { get; set; }
        public string Survey { get; set; }
        public string Ref_Desc { get; set; }
        public Int16? Refuse { get; set; }
        public string SciName { get; set; }
        public Decimal? N_Factor { get; set; }
        public Decimal? Pro_Factor { get; set; }
        public Decimal? Fat_Factor { get; set; }
        public Decimal? CHO_Factor { get; set; }
    }
}