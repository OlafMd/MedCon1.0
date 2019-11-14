using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocApp
{
    public class SynchronizedSequentialNumberGenerator
    {
        private static SynchronizedSequentialNumberGenerator instance;
        private int latest;
        private static object lockObj = new object();
        private static object lockRoot = new object();

        private SynchronizedSequentialNumberGenerator()
        {
            latest = 0;
        }

        public static SynchronizedSequentialNumberGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockRoot)
                    {
                        instance = new SynchronizedSequentialNumberGenerator();
                    }
                }

                return instance;
            }
        }

        public int Generate(int latestInDb)
        {
            lock (lockObj)
            {
                if (latest < latestInDb)
                {
                    latest = latestInDb + 1;
                    return latest;
                }

                return ++latest;
            }
        }
    }
}
