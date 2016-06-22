using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task269
{
    class Break
    {
        private int[] line;
        private int lineLen;
        public int this[int i]
        {
            get
            {
                return line[i];
            }
        }
        public int Count()
        {
            return lineLen;
        }
        public Break(string line)
        {
            lineLen = line.Length;
            this.line = new int[lineLen];
            for (int i = 0; i < lineLen; ++i)
                this.line[i] = int.Parse(line.Substring(i, 1));
        }
    }
}
