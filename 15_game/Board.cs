using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_game
{
    public class Board
    {
        int Size; 
        int ZeroX, ZeroY;
        public int [ , ] Field {get;}
        public int GenNum {get;}
        public Board Previous {get;}
        public Board(int N)
        {
            Size = N;
            ZeroX = N-1;
            ZeroY = N-1;
            Field = new int[N, N];
            GenNum = 0;
            Previous = null;
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    Field[i, j] = i*N+j+1;
                }
            }
            Field[ZeroX, ZeroY] = 0;
        }
        public Board(Board Prev)
        {
            Size = Prev.Size;
            ZeroX = Prev.ZeroX;
            ZeroY = Prev.ZeroY;
            Field = new int [Size, Size];
            GenNum = Prev.GenNum + 1;
            Previous = Prev;
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    Field[i, j] = Prev.Field[i, j];
                }
            }
        }
        public void Print()
        {
            Console.WriteLine();
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    Console.Write($"{Field[i, j]} ");
                }
                Console.WriteLine();
            }           
        }

        public bool LeftMove()
        {
            if(0 == ZeroX)
            {
                return false;
            }
            
            Field[ZeroX, ZeroY] = Field[ZeroX-1, ZeroY];
            ZeroX--;
            Field[ZeroX, ZeroY] = 0;

            return true;
        }

        public bool RightMove()
        {
            if(Size-1 == ZeroX)
            {
                return false;
            }
            
            Field[ZeroX, ZeroY] = Field[ZeroX+1, ZeroY];
            ZeroX++;
            Field[ZeroX, ZeroY] = 0;

            return true;
        }

        public bool UpMove()
        {
            if(0 == ZeroY)
            {
                return false;
            }
            
            Field[ZeroX, ZeroY] = Field[ZeroX, ZeroY-1];
            ZeroY--;
            Field[ZeroX, ZeroY] = 0;

            return true;
        }
        public bool DownMove()
        {
            if(Size-1 == ZeroY)
            {
                return false;
            }
            
            Field[ZeroX, ZeroY] = Field[ZeroX, ZeroY+1];
            ZeroY++;
            Field[ZeroX, ZeroY] = 0;

            return true;
        }
        public void RandomMix(int N)
        {
            Random rand = new Random();
            int dir;
            for(int i = 0; i < N; i++)
            {
                dir = rand.Next()%4;
                switch(dir)
                {
                    case 0:
                        LeftMove();
                        break;
                    case 1:
                        RightMove();
                        break;
                    case 2:
                        UpMove();
                        break;
                    case 3:
                        DownMove();
                        break;
                    
                }
            }
        }

        public double Distance(Board OtherBoard, double a, double b)
        {
            double res = b * (GenNum + OtherBoard.GenNum);
            int i_cor, j_cor;
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    if(Field[i, j] == 0)
                    {
                        res += a*(Math.Abs(i-Size+1)+Math.Abs(j-Size+1));
                    }
                    else
                    {
                        i_cor = (Field[i, j]-1)/Size;
                        j_cor = (Field[i, j]-1)%Size;
                        res += a*(Math.Abs(i-i_cor)+Math.Abs(j-j_cor));
                    }
                }
            }
            return res; 
        }
        /*public static bool operator == (Board board1, Board board2)
        {
            if(board1.Size != board2.Size)
            {
                return false;
            }
            for(int i = 0; i < board1.Size; i++)
            {
                for(int j = 0; j< board1.Size; j++)
                {
                    if(board1.Field[i, j] != board2.Field[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator != (Board board1, Board board2)
        {   
            return !(board1 == board2);
        }*/

        public override string ToString()
        {
            string res = "";
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    res += $"{Field[i, j]},";
                }
            }
            return res;
        }
        
    }
}