using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell
{
    class Polygon//хранит замкнутую линию
    {
        List<Line> lines { get; }
        
        public Polygon(List<Line> lines)
        {
            this.lines = lines;
        }
    }
}
