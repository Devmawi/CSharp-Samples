using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew.Version10
{
    internal record class RecordClass
    {
        public int Value { get; set; }
        public DateTime DateTime { get; set; }

        internal void Deconstruct(out int value, out DateTime time) => (value, time) = (Value, DateTime);

    }
}
