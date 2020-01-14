using System;
using System.Collections.Generic;
using System.Text;

namespace SuurballeRundown.Models
{
    public class Relation
    {
        public int InboundIndex { get; set; }

        public int OutboundIndex { get; set; }

        public Relation(int inbound, int outbound)
        {
            InboundIndex = inbound;
            OutboundIndex = outbound;
        }
    }
}
