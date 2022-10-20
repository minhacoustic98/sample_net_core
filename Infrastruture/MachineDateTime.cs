using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastruture
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
