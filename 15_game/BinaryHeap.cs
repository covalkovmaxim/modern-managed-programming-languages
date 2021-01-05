using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_game
{
    public class BinaryHeap
    {
        Board[] Heap;
        Board StartPosition;
        int Size;
        int Length;
        double a, b;
        public BinaryHeap(int N, double c1, double c2)
        {
            a = c1; 
            b = c2;
            Size = 100;
            Length = 0;
            Heap = new Board[Size];
            StartPosition = new Board(N);
        }
        void ShiftDown(int Index)
        {
            int LeftChildIndex, RightChildIndex, NewIndex;
            while(2*Index+1 < Length)
            {
                LeftChildIndex = 2*Index+1;
                RightChildIndex = 2*Index+2;
                NewIndex = (RightChildIndex < Length &&
                            Heap[RightChildIndex].Distance(StartPosition, a, b) <
                            Heap[LeftChildIndex].Distance(StartPosition, a, b)) ?
                            RightChildIndex :
                            LeftChildIndex;
                if(Heap[Index].Distance(StartPosition, a, b) <= Heap[NewIndex].Distance(StartPosition, a, b))
                {
                    break;
                }
                Board cur = Heap[Index];
                Heap[Index] = Heap[NewIndex];
                Heap[NewIndex] = cur;
                Index = NewIndex;
            }
        }
        void ShiftUp(int Index)
        {
            while (Heap[Index].Distance(StartPosition, a, b) < Heap[(Index-1)/2].Distance(StartPosition, a, b))
            {
                Board cur = Heap[Index];
                Heap[Index] = Heap[(Index-1)/2];
                Heap[(Index-1)/2] = cur;
                Index = (Index-1)/2;
            }
        }
        public Board ExtractMin()
        {
            Board min = Heap[0];
            Heap[0] = Heap[Length-1];
            Length--;
            ShiftDown(0);
            return min; 
        }
        public void Insert(Board Key)
        {
            if(Length == Size)
            {
                Size *= 2;
                Array.Resize(ref Heap, Size);
            }
            Length++;
            Heap[Length-1] = Key;
            ShiftUp(Length-1);
        }
    }
}