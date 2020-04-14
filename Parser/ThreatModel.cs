using System;
using System.Collections.Generic;
using System.Text;

namespace Parser
{
    public class ThreatModel
    {
        public int ThreatId { get; set; }
        public string ThreatName { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public bool ConfidentialityBreach { get; set; }
        public bool IntegrityViolation { get; set; }
        public bool AccessViolation { get; set; }
    }
}
