using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _15_game
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime StartTime, EndTime;
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";
            int BoardSize = args.Length > 0 ? Convert.ToInt32(args[0]) : 4;
            int StepNumber = args.Length > 1 ? Convert.ToInt32(args[1]) : 1000000;
            double Coef1 = args.Length > 2 ? Convert.ToDouble(args[2], provider) : 10;
            double Coef2 = args.Length > 3 ? Convert.ToDouble(args[3], provider) : 1;
            Board board = new Board(BoardSize);
            board.RandomMix(StepNumber);
            board.Print();
            Board start = new Board(BoardSize);
            BinaryHeap Heap = new BinaryHeap(BoardSize, Coef1, Coef2);
            Heap.Insert(board); 
            Board ans;
            HashSet<string> BlackVertices = new HashSet<string>();
            Stack<Board> way = new Stack<Board>();
            BlackVertices.Add(board.ToString());
            
            StartTime = DateTime.Now;
            while(true)
            {
                Board cur = Heap.ExtractMin();
                //cur.Print();
                if(cur.ToString() == start.ToString())
                {
                    ans = cur;
                    break;
                }
                else
                {
                    if(cur.LeftMove())
                    {
                        Board left = new Board(cur);
                        cur.RightMove();
                        if(!BlackVertices.Contains(left.ToString()))
                        {
                            Heap.Insert(left);
                            BlackVertices.Add(left.ToString());
                        }
                    }
                    
                    if(cur.RightMove())
                    {
                        Board right = new Board(cur);
                        cur.LeftMove();
                        if(!BlackVertices.Contains(right.ToString()))
                        {
                            Heap.Insert(right);
                            BlackVertices.Add(right.ToString());
                        }
                    }
                    if(cur.UpMove())
                    {
                        Board up = new Board(cur);
                        cur.DownMove();
                        if(!BlackVertices.Contains(up.ToString()))
                        {
                            Heap.Insert(up);
                            BlackVertices.Add(up.ToString());
                        }
                    }
                    
                    if(cur.DownMove())
                    {
                        Board down = new Board(cur);
                        cur.UpMove();
                        if(!BlackVertices.Contains(down.ToString()))
                        {
                            Heap.Insert(down);
                            BlackVertices.Add(down.ToString());
                        }
                    }
                }
            }
            EndTime = DateTime.Now;
            //ans.Print();
            int num = ans.GenNum;
            for(int i = 0; i < num; i++)
            {
                way.Push(ans);
                ans = ans.Previous;
            }
            while(way.Count > 0)
            {
                ans = way.Pop();
                ans.Print();
            }
            Console.WriteLine($"\nBlackVertices.Size = {BlackVertices.Count}");
            Console.WriteLine($"WorkTime: {(EndTime-StartTime).TotalMilliseconds} ms");
        }
    }
}
