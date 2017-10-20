using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace BabyStepTimer.CharacterizationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void ShowsTwoMinutesTimeWhenApplicationIsStarted()
        {
            string html = "";

            act(() =>
            {
                html = getProgramHtml();
            });

            Assert.IsTrue(html.Contains("02:00"), "Expected html to contain 02:00 (was: " + html + ").");
        }

        [TestMethod]
        public void CountDownAfterPressingStart()
        {
            string html = "";

            act(() =>
            {
                click("start");
                wait(TimeSpan.FromSeconds(1));
                html = getProgramHtml();
            });

            Assert.IsFalse(html.Contains("02:00"), "Expected html to contain something other than 2:00 (was: " + html + ").");
        }

        [TestMethod]
        public void StopCountingDownAfterPressingStop()
        {
            string html = "";

            act(() =>
            {
                click("start");
                wait(TimeSpan.FromSeconds(1));
                click("stop");
                wait(TimeSpan.FromSeconds(1));
                html = getProgramHtml();
            });

            Assert.IsTrue(html.Contains("02:00"), "Expected html to contain 02:00 (was: " + html + ").");
        }

        delegate void ActCommands();
        private void act(ActCommands commands)
        {
            var controlThread = new Thread(() =>
            {
                Thread.Sleep(100);

                commands();

                click("quit");
            });
            controlThread.Start();

            Program.Main();
        }

        private void wait(TimeSpan delay)
        {
            Thread.Sleep(delay);
        }

        private string getProgramHtml()
        {
            var getHtmlFunc = new Func<string>(() => Program._webBrowser.DocumentText);
            if (Program._webBrowser.InvokeRequired)
                return (string)Program._webBrowser.Invoke(getHtmlFunc);
            return getHtmlFunc();
        }

        private void click(string command)
        {
            var clickAction = new Action<string>(cmd => Program._webBrowser.Navigate($"command://{cmd}/"));

            if (Program._webBrowser.InvokeRequired)
                Program._webBrowser.Invoke(clickAction, command);
            else
                clickAction(command);

            Thread.Sleep(10);
        }
    }


}
