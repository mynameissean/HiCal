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
         * Option 3 - Same as option 1, but delete meetings that you merge in
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

        protected bool IsOverlap(Meeting Meeting1, Meeting Meeting2)
        {
            bool retVal = false;
            
            if(Meeting1.StartTime <= Meeting2.EndTime && Meeting2.StartTime <= Meeting1.EndTime)
            {
                //Overlap
                retVal = true;
            }

            return retVal;
        }

       
        
    }

    public class HiCalBrute : HiCalBase
    {
        /**
         * Look at Meeting 1.  Then look at every other element to see if it
         * increases the size of element 1.  If it does, increase the size of the current meeting and continue searching.  
         * Loop back again and look at Meeting 2
         **/
        public override List<Meeting> MergeRanges(List<Meeting> MeetingsToMerge)
        {
            List<Meeting> retVal = new List<Meeting>();

           while(MeetingsToMerge.Count > 0)
            {
                Meeting currentTarget = MeetingsToMerge[0];
                //Now search through every other element in the list
                bool NoMerges = true;
                for(int j = 0; j < retVal.Count; j++)
                {
                    Meeting possibleTarget = retVal[j];
                    if(IsOverlap(currentTarget, possibleTarget))
                    {
                        //Merge them
                        possibleTarget.Merge(currentTarget);
                        NoMerges = false;
                    }
                    
                }
                //Add the currentTarget to the return string
                if (NoMerges == true)
                {
                    //We have a new unique element, add it into our return string
                    retVal.Add(currentTarget);
                }
                //Delete it from the search string
                MeetingsToMerge.RemoveAt(0);

            }

            return retVal;
        }

        
    }

    public class HiCalMatch : HiCalBase
    {
        public override List<Meeting> MergeRanges(List<Meeting> MeetingsToMerge)
        {
            return new List<Meeting> { new Meeting(0, 1), new Meeting(3, 8), new Meeting(9, 12) };
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

        public void Merge(Meeting MeetingToMerge)
        {
            StartTime = Math.Min(StartTime, MeetingToMerge.StartTime);
            EndTime = Math.Max(EndTime, MeetingToMerge.EndTime);
        }

        public override string ToString()
        {
            return $"({StartTime}, {EndTime})";
        }
    }
}
