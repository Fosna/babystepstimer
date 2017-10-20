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
        private SoundPlayer _player;

        public Sound(string url)
        {
            _player = Load(url);
        }

        private SoundPlayer Load(string url)
        {
            var inputStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BabyStepTimer.Resources." + url);
            return new SoundPlayer(inputStream);
        }

        public void Play()
        {
            var playThread = new Thread(() =>
            {
                _player.Play();
            });
            playThread.IsBackground = true;
            playThread.Start();
        }

    }
}
