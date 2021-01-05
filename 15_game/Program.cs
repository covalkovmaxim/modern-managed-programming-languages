using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(4);
            board.RandomMix(1000);
            board.Print();
            Board start = new Board(4);
            BinaryHeap Heap = new BinaryHeap(4, 10.0, 1.0);
            Heap.Insert(board); 
            Board ans;
            HashSet<string> BlackVertices = new HashSet<string>();
            Stack<Board> way = new Stack<Board>();
            BlackVertices.Add(board.ToString());
             
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
        }
    }
}
