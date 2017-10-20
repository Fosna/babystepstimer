using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyStepTimer.CharacterizationTest
{
    class TestWallClock : IWallClock
    {
        public DateTime Current { get; set; }

        public DateTime Now()
        {
            return Current;
        }

        public void Sleep(int ms)
        {
            Current.AddMilliseconds(ms);
        }
    }
}
