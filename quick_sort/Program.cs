using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quick_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start, end;
            MyComparer comp=new MyComparer();
            comp.Reset();
            Random rnd=new Random();
            int n=Convert.ToInt32(args[0]);
            int MinBlockSize=Convert.ToInt32(args[1]);
            double[] array=new double[n], array_copy=new double[n];

            for(int i=0; i<n; i++)
            {
                array[i]=10*rnd.NextDouble();
                array_copy[i]=array[i];
            }
            Console.WriteLine("QuickSort from standart library:");
            start=DateTime.Now;
            Array.Sort(array,comp);
            end=DateTime.Now;
            Console.WriteLine("Correct: "+CheckSort(array, comp).ToString());
            Console.WriteLine("WorkTime: "+(end-start).TotalMilliseconds.ToString()+"ms");
            Console.WriteLine("Num of compares: " + comp.Count.ToString());
            
            comp.Reset();
            for(int i=0; i<n; i++)
            {
                array[i]=array_copy[i];
            }
            Console.WriteLine("\nMy QuickSort:");
            start=DateTime.Now;
            QuickSort(array, 0, n-1, comp, MinBlockSize);
            end=DateTime.Now;
            Console.WriteLine("Correct: "+CheckSort(array, comp).ToString());
            Console.WriteLine("WorkTime: "+(end-start).TotalMilliseconds.ToString()+"ms");
            Console.WriteLine("Num of compares: " + comp.Count.ToString());
            Array.Sort(array,comp);
            
        }
        
        static void InsertionSort(double[] a, int start, int end, MyComparer comp)
        {
            int n = a.Length;
            for (int i=start+1; i<=end; i++)
            {
                int j=i;
                double t=a[j];
                while (j>0 && comp.Compare(t, a[j-1])<=0)
                {
                    a[j]=a[j-1];
                    j--;
                }
                a[j]=t;
            }
        }
        static bool CheckSort(double[] a, MyComparer comp)
        {
            int n=a.Length;
            for(int i=1; i<n; i++)
            {
                if(1==comp.Compare(a[i-1], a[i]))
                {
                    return false;
                }
            }
            return true;
        }

        static void QuickSort(double[] a, int start, int end, MyComparer comp, int MinBlockSize)
        {
            int i=start, j=end, size=end-start+1;
            double[] elems=new double[3];
            double elem, cur;            
            Random rand=new Random();
            while(size>MinBlockSize)
            {
                for(int k=0;k<3;k++)
                {
                    elems[k]=a[start+rand.Next()%size];
                }
                InsertionSort(elems,0,2,comp);
                elem=elems[1];
                do
                {
                    while(-1==comp.Compare(a[i],elem))
                    {
                        i++;
                    }
                    while(1==comp.Compare(a[j],elem))
                    {
                        j--;
                    }
                    if(i<=j)
                    {
                        cur=a[i];
                        a[i]=a[j];
                        a[j]=cur;
                        i++;
                        j--;
                    }
                }
                while(i<j);
                
                if(j-start>end-i)
                {
                    if(i<end)
                    {
                        QuickSort(a, i, end, comp, MinBlockSize);
                    }
                    end=j;
                }
                else
                {
                    if(start<j)
                    {
                        QuickSort(a, start, j, comp, MinBlockSize);
                    }
                    start=i;
                }
                i=start; 
                j=end;
                size=end-start+1;
                
                
            }
            InsertionSort(a, start, end, comp);
        }
    }
}
