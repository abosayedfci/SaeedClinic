using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaeedClinick.Data
{
    using System;
    using System.Collections.Generic;

    public partial class Visit
    {
        public List<int> Labs { get; set; }
        public List<int> Treatments { get; set;}
        public List<int> Us { get; set; }
        public List<string> LK_Labs { get; set; }
        public List<string> LK_Treatments { get; set; }
        public List<string> LK_US { get; set; }
        
    }
    public class Lb
    {
        public int Id { get; set; }
        public string LabTitle { get; set; }
    }
    public class TR
    {
        public int Id { get; set; }
        public string TreatmentTitle { get; set; }
    }
    public class Us
    {
        public int Id { get; set; }
        public string UsTitle { get; set; }
    }
    public class LookUpList
    {
        public List<LK_Labs> LabsList { get; set; }
        public List<LK_Treatment> TreatmentList { get; set; }
        public List<LK_US> USList { get; set; }
    }
}