using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BabyStepTimer
{
    class Sound
    {
        public static void PlaySound(string url)
        {
            var playThread = new Thread(() =>
            {
                var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BabyStepTimer.Resources." + url);
                SoundPlayer player = new SoundPlayer(inputStream);
                player.Play();
            });
            playThread.IsBackground = true;
            playThread.Start();
        }

    }
}
