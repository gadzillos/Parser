using System;
using System.Collections.Generic;
using System.Text;

namespace Parser
{
    public class DifferenceModel
    {
        public int ThreatId { get; set; }
        public string ChangedColumnName { get; set; }
        public string OldData { get; set; }
        public string NewData { get; set; }
    }
}
