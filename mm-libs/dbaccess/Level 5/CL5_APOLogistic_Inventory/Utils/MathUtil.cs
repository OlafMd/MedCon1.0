using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CL5_APOLogistic_Inventory.Utils
{
    class MathUtil
    {
        public static int CountProcent(int complete, int total)
        {
            if (total == 0)
                return 0;

            int percentComplete = (int)Math.Round((double)(100 * complete) / total);
            return percentComplete;
        }
    }
}
