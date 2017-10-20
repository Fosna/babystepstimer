using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BabyStepTimer
{
    class SystemWallClock : IWallClock
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public void Sleep(int ms)
        {
            Thread.Sleep(ms);
        }
    }
}
