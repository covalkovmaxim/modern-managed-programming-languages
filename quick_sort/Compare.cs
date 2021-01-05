using System;
using System.Collections.Generic;

namespace quick_sort
{
    class MyComparer : IComparer<double>
    {
        public int Compare(double x, double y)
        {
            count++;
            
            if(Math.Abs(x-y)<1e-15)
            {
                return 0;
            }
            if(x>y)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        private int count;
        public int Count
        {
            get { return count; }
        }

        public void Reset()
        {
            count = 0;
        }

        
    }
}