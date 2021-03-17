using HiCal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace HiCalTest
{
    [TestClass]
    public class HiCalTest
    {
        [TestMethod]
        public void GivenTestSetup()
        {
            GivenTest(new HiCalBrute());
            GivenTest(new HiCalMatch());
        }

        private void GivenTest(HiCalBase MeetingMerger)
        {

        }

        private void TimingTestExecution(HiCalBase MeetingMerger,
                                         List<Meeting> input,
                                         int numberofruns)
        {
            Trace.Write("Testing " + MeetingMerger.ToString() + " with " + numberofruns + ": ");
            var watch = new Stopwatch();
            watch.Start();

            for (int i = 0; i < numberofruns; i++)
            {
                MeetingMerger.MergeRanges(input);
            }
            watch.Stop();
            Trace.WriteLine(watch.ElapsedMilliseconds);
        }
    }
}
