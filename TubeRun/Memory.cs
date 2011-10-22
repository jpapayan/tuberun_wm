using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TubeRun
{
    public class Memory
    {
        public String line;
        public String station;
        public String station_nice;
        public String direction;
        public Memory(String line, String station, String station_nice, String direction)
        {
            this.direction = direction;
            this.line = line;
            this.station = station;
            this.station_nice = station_nice;
        }
    }
}
