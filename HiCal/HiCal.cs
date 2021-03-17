using System;
using System.Collections.Generic;
using System.Text;

namespace HiCal
{
    public abstract class HiCalBase
    {
        public static void Main(string[] args)
        { }

        public HiCalBase()
        {

        }
        /* Here's a few thoughts about how to do this type of algorithm.  Here's an example data set:
         * Meeting 1: 1-3, Meeting 2: 5-7, Meeting 3: 2-4, Meeting 4: 8-10
         * Option 1 - Brute force search.  Look at Meeting 1.  Then look at every other element to see if it
         * increases the size of element 1.  Meeting 3 overlaps, so would increase the size of Meeting 1 from 1-4.
         * Delete Meeting 3, then continue search from Meeting 2.
         * Pro - Easy to code
         * Con - A lot of comparisons being done, list being traversed multiple times
         * Option 2 - For each new element, look through the array of already created ranges.  If there is no match,
         * add the element to the array. If there is a match, increase the size of element that was found.
         * Pro - 
         * Con - Duplicates the array memory, would need to efficiently search for matching elements in the array. 
         */
        public abstract List<Meeting> MergeRanges(List<Meeting> MeetingsToMerge);

        public string ToString(List<Meeting> MeetingsToDisplay)
        {
            StringBuilder retVal = new StringBuilder();
            foreach(Meeting meeting in MeetingsToDisplay)
            {
                retVal.Append(meeting.ToString() + ", ");
            }

            return retVal.ToString();
        }
        
    }

    public class HiCalBrute : HiCalBase
    {
        public override List<Meeting> MergeRanges(List<Meeting> MeetingsToMerge)
        {
            throw new NotImplementedException();
        }
    }

    public class HiCalMatch : HiCalBase
    {
        public override List<Meeting> MergeRanges(List<Meeting> MeetingsToMerge)
        {
            throw new NotImplementedException();
        }
    }



    public class Meeting
    {
        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public Meeting(int startTime, int endTime)
        {
            // Number of 30 min blocks past 9:00 am
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString()
        {
            return $"({StartTime}, {EndTime})";
        }
    }
}
