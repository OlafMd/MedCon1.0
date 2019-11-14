using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocApp
{
    public class SynchronizedSequentialNumberGeneratorCase
    {
        private static SynchronizedSequentialNumberGeneratorCase instance;
        private int latest;
        private static object lockObj = new object();
        private static object lockRoot = new object();

        private SynchronizedSequentialNumberGeneratorCase()
        {
            latest = 0;
        }

        public static SynchronizedSequentialNumberGeneratorCase Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockRoot)
                    {
                        instance = new SynchronizedSequentialNumberGeneratorCase();
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
