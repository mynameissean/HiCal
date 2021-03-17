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
            //GivenTest(new HiCalMatch());
        }

        private void GivenTest(HiCalBase MeetingMerger)
        {
            List<Meeting> meetingsToCheck = new List<Meeting> { new Meeting(0, 1), new Meeting(3, 5), new Meeting(4, 8), new Meeting(10, 12), new Meeting(9, 10) };
            List<Meeting> expectedOutput = new List<Meeting> { new Meeting(0, 1), new Meeting(3, 8), new Meeting(9, 12) };
            Assert.AreEqual(MeetingMerger.ToString(expectedOutput), MeetingMerger.ToString(MeetingMerger.MergeRanges(meetingsToCheck)));
        }

        [TestMethod]
        public void SimpleTestSetup()
        {
            SimpleTest(new HiCalBrute());
            //SimpleTestSetup(new HiCalMatch());
        }

        private void SimpleTest(HiCalBase MeetingMerger)
        {
            List<Meeting> meetingsToCheck = new List<Meeting> { new Meeting(0, 1), new Meeting(1, 2), new Meeting(2, 3), new Meeting(3, 4), new Meeting(4, 5) };
            List<Meeting> expectedOutput = new List<Meeting> { new Meeting(0, 5) };
            Assert.AreEqual(MeetingMerger.ToString(expectedOutput), MeetingMerger.ToString(MeetingMerger.MergeRanges(meetingsToCheck)));
            meetingsToCheck = new List<Meeting> {  new Meeting(4, 5), new Meeting(3, 4), new Meeting(2, 3), new Meeting(1, 2), new Meeting(0, 1) };
            Assert.AreEqual(MeetingMerger.ToString(expectedOutput), MeetingMerger.ToString(MeetingMerger.MergeRanges(meetingsToCheck)));

            //Now with spaces in between
            meetingsToCheck = new List<Meeting> { new Meeting(0, 1), new Meeting(2, 3), new Meeting(4, 5), new Meeting(6, 7), new Meeting(8, 9) };
            expectedOutput = new List<Meeting> { new Meeting(0, 1), new Meeting(2, 3), new Meeting(4, 5), new Meeting(6, 7), new Meeting(8, 9) };
            Assert.AreEqual(MeetingMerger.ToString(expectedOutput), MeetingMerger.ToString(MeetingMerger.MergeRanges(meetingsToCheck)));
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
