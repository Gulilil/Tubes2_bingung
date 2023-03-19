using System;

namespace src
{
    public class Point
    {
        private int row;
        private int col;
        private int visitedCount;

        // ctor
        public Point ()
        {
            row = 0; col = 0; visitedCount = 0;
        }

        public Point(int r, int c)
        {
            row = r; col = c; visitedCount = 0;
        }

        public Point(Point p)
        {
            this.row = p.getRow();
            this.col = p.getCol();
            this.visitedCount = 0;
        }

        // setter getter
        public int getRow()
        {
            return row;
        }

        public int getCol()
        {
            return col;
        }
        public int getVisitedCount(){
            return this.visitedCount;
        }

        public void setRow(int r)
        {
            this.row = r;
        }

        public void setCol(int c)
        {
            this.col = c;
        }
        public void setVisitedCount(int vc){
            this.visitedCount = vc;
        }

        // other methods
        public void increaseVisitedCount(){
            this.visitedCount++;
        }
        public void copyPoint(Point p){
            this.row = p.getRow();
            this.col = p.getCol();
        }
        public void goLeft()
        {
            this.col--;
        }

        public void goRight()
        {
            this.col++;
        }

        public void goUp() 
        {
            this.row--;
        }
        
        public void goDown()
        {
            this.row++;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {            
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Point p = (Point) obj;
            return (getRow() == p.getRow() && getCol() == p.getCol());
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (row,col).GetHashCode();
        }
        public bool isTheSame(Point p){
            return (this.getRow() == p.getRow() && this.getCol() == p.getCol());
        }

        public bool isLeftOf(Point p)
        {
            return (this.getRow() == p.getRow() && this.getCol() == p.getCol()-1);
        }
        public bool isRightOf(Point p)
        {
            return (this.getRow() == p.getRow() && this.getCol() == p.getCol()+1);
        }

        public bool isUpOf(Point p)
        {
            return (this.getRow() == p.getRow()-1 && this.getCol() == p.getCol());
        }
        public bool isDownOf(Point p)
        {
            return (this.getRow() == p.getRow()+1 && this.getCol() == p.getCol());
        }

        // print and display
        public void displayPoint(){
            Console.Write("("+this.row +", "+this.col+")");
        }

    }
}