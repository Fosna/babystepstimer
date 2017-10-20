using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyStepTimer
{
    public interface IWallClock
    {
        DateTime Now();
        void Sleep(int ms);
    }
}
