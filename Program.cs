using System;
using System.Collections.Generic;

namespace TsortAdjMx
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph topOrder = new Graph();
            topOrder.AddVertex('A');
            topOrder.AddVertex('B');
            topOrder.AddVertex('C');
            topOrder.AddVertex('D');
            topOrder.AddVertex('E');
            topOrder.AddVertex('F');
            topOrder.AddVertex('G');
            topOrder.AddVertex('H');

            topOrder.AddEdges(0,3);
            topOrder.AddEdges(0,4);
            topOrder.AddEdges(1,4);
            topOrder.AddEdges(2,5);
            topOrder.AddEdges(3,6);
            topOrder.AddEdges(4,6);
            topOrder.AddEdges(5,7);
            topOrder.AddEdges(6,7);

            topOrder.topSort();
            topOrder.displayResult();

        }
    }

    class Vertex{
        public char label;
        public Vertex(char lb){
            this.label=lb;
        }
    }

    class Graph{
        public Vertex [] vertexList;
        public int INITIAL_SIZE=8;
        public int [,] adjMatx;

        public int nVert;

        public Stack<Vertex> nodeWithNoSUccesssors;

        public Graph(){
            vertexList= new Vertex[INITIAL_SIZE];
            adjMatx= new int[INITIAL_SIZE,INITIAL_SIZE];
            nVert=0;
            nodeWithNoSUccesssors= new Stack<Vertex>();

        }
 public void AddVertex(char lb){
     vertexList[nVert]= new Vertex(lb);
     nVert++;
 }


 public void AddEdges(int start, int end){
     adjMatx[start,end]=1;
 }

 public void displayResult(){
     while (nodeWithNoSUccesssors.Count!=0)
     {
         Console.Write(nodeWithNoSUccesssors.Pop().label + " ");
     }
 }
public void topSort(){
    int originalVerts= nVert;
    while(nVert>0){
        int currentVert = noSuccessor();
        if(currentVert==-1){
            Console.Write("Graph has cycle");
            return;
        }
        nodeWithNoSUccesssors.Push(vertexList[currentVert]);
        deleteVertex(currentVert);
    }
}
public int noSuccessor(){
   bool isEdge;
   for (int row = 0; row < nVert; row++)
   {
       isEdge= false;
       for (int col = 0; col < nVert; col++)
       {
          if(adjMatx[row,col]>0){
              isEdge= true;
              break;
          } 
       }

       if (! isEdge)
       {
        return row;   
       }
   }

   return -1;
}
public void deleteVertex(int vert){
  if(vert!=nVert-1)// not the last vertext
  {
   for (int i = vert; i < nVert-1; i++)
   {
      vertexList[i]= vertexList[i+1]; 
   }
   for (int row = vert; row < nVert-1; row++)
   {
       moveRowUp(row,nVert);
   }
   for (int col =vert ; col < nVert-1; col++)   {
       moveColLeft(col,nVert);
   }
  }  
  nVert --;
}

private void moveRowUp(int row, int length){
    for (int colm = 0; colm < length; colm++)
    {
        adjMatx[row,colm]=adjMatx[row+1,colm];
    }
}

private void moveColLeft(int col, int length){
    for (int row = 0; row < length; row++)
    {
      adjMatx[row,col] = adjMatx[row,col+1];  
    }
}
    }
}
