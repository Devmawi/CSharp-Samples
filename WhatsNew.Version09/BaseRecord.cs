using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Version09
{
    internal record BaseRecord
    {
        public int Value { get; init; } = default;
        public DateTime DateTime { get; init; } = DateTime.Now;
    }
}
