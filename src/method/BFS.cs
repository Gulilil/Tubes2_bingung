using Drawing
using System

namespace src

    class BFS : Solver
    
        bool TSP

        // ctor
        BFS()
            this.TSP <- false
        

        // setter getter
        bool getTSP()
            -> this.TSP
        

        procedure setTSP(bool tsp)
            this.TSP <- tsp
        

        // other methods
        bool isAllTreasureTaken(Stack<Point> path, Point[] tLoc)
            for (int i <- 0 i < tLoc.Length i++)
                if (!path.Contains(tLoc[i]))
                    -> false
                
            
            -> true
        

        Stack<Point> solve(Nodes n, Map m)
            Queue<Stack<Point>> q <- new Queue<Stack<Point>>() 
            Queue<Nodes> nQueue <- new Queue<Nodes>()
            Stack<Point> s <- new Stack<Point>()
            s.Push(m.getStartLoc())
            q.Enqueue(s)
            n.setNode(m.getStartLoc())
            nQueue.Enqueue(n)
            //int count <- 1
            while (q.Count > 0 and !isAllTreasureTaken(q.Peek(), m.getTreasureLocations()))
                n <- nQueue.Dequeue()
                Stack<Point> temp <- q.Dequeue()
                m.setCurLoc(temp.Peek())
                Point cl <- m.getCurLoc()
                m.increaseVCAtCoordinate(cl)
                bool noOtherPath <- true
                for(int i <- 0 i < 3 i++)
                    if (noOtherPath)
                        if (i = 2 and noOtherPath)
                        
                            -> new Stack<Point>()
                        
                        if (cl.getRow() !<- 0 and m.getValueAtCoordinate(cl.getRow() - 1, cl.getCol()) !<- 'X')
                        
                            // check Up
                            Point newLoc <- new Point(cl)
                            newLoc.goUp()
                            if (!temp.Contains(newLoc) or (i = 1 and noOtherPath))
                                Stack<Point> temp2 <- new Stack<Point>(temp)
                                Stack<Point> temp1 <- new Stack<Point>(temp2)
                                temp1.Push(newLoc)
                                n.setUpChild(newLoc)
                                nQueue.Enqueue(n.getUpChild())
                                q.Enqueue(temp1)
                                noOtherPath <- false
                            
                        
                        if (cl.getCol() !<- 0 and m.getValueAtCoordinate(cl.getRow(), cl.getCol()-1) !<- 'X')
                        
                            // check Left
                            Point newLoc <- new Point(cl)
                            newLoc.goLeft()
                            if (!temp.Contains(newLoc) or (i = 1 and noOtherPath))
                                Stack<Point> temp2 <- new Stack<Point>(temp)
                                Stack<Point> temp1 <- new Stack<Point>(temp2)
                                temp1.Push(newLoc)
                                n.setLeftChild(newLoc)
                                nQueue.Enqueue(n.getLeftChild())
                                q.Enqueue(temp1)
                                noOtherPath <- false
                            
                        
                        if (cl.getCol() !<- m.getCol() - 1 and m.getValueAtCoordinate(cl.getRow(), cl.getCol() + 1) !<- 'X')
                        
                            // check Right
                            Point newLoc <- new Point(cl)
                            newLoc.goRight()
                            if (!temp.Contains(newLoc) or (i = 1 and noOtherPath))
                                Stack<Point> temp2 <- new Stack<Point>(temp)
                                Stack<Point> temp1 <- new Stack<Point>(temp2)
                                temp1.Push(newLoc)
                                n.setRightChild(newLoc)
                                nQueue.Enqueue(n.getRightChild())
                                q.Enqueue(temp1)
                                noOtherPath <- false
                            
                        
                        if (cl.getRow() !<- m.getRow() - 1 and m.getValueAtCoordinate(cl.getRow() + 1, cl.getCol()) !<- 'X')
                        
                            // check Down
                            Point newLoc <- new Point(cl)
                            newLoc.goDown()
                            if (!temp.Contains(newLoc) or (i = 1 and noOtherPath))
                                Stack<Point> temp2 <- new Stack<Point>(temp)
                                Stack<Point> temp1 <- new Stack<Point>(temp2)
                                temp1.Push(newLoc)
                                n.setDownChild(newLoc)
                                nQueue.Enqueue(n.getDownChild())
                                q.Enqueue(temp1)
                                noOtherPath <- false
                            
                        
                    
                
                //count++
            
            if (TSP)
                n <- nQueue.Dequeue()
                while(nQueue.Count > 0)
                
                    nQueue.Dequeue()
                
                nQueue.Enqueue(n)
                Stack<Point> sol <- q.Dequeue()
                while (q.Count > 0)
                    q.Dequeue()
                
                q.Enqueue(sol)
                while(!q.Peek().Peek().Equals(m.getStartLoc()))
                    n <- nQueue.Dequeue()
                    Stack<Point> temp <- q.Dequeue()
                    m.setCurLoc(temp.Peek())
                    Point cl <- m.getCurLoc()
                    if (cl.getRow() !<- 0 and m.getValueAtCoordinate(cl.getRow() - 1, cl.getCol()) !<- 'X')
                    
                        // check Up
                        Point newLoc <- new Point(cl)
                        newLoc.goUp()
                        Stack<Point> temp2 <- new Stack<Point>(temp)
                        Stack<Point> temp1 <- new Stack<Point>(temp2)
                        n.setUpChild(newLoc)
                        nQueue.Enqueue(n)
                        temp1.Push(newLoc)
                        q.Enqueue(temp1)
                    
                    if (cl.getCol() !<- 0 and m.getValueAtCoordinate(cl.getRow(), cl.getCol()-1) !<- 'X')
                    
                        // check Left
                        Point newLoc <- new Point(cl)
                        newLoc.goLeft()
                        Stack<Point> temp2 <- new Stack<Point>(temp)
                        Stack<Point> temp1 <- new Stack<Point>(temp2)
                        n.setLeftChild(newLoc)
                        nQueue.Enqueue(n)
                        temp1.Push(newLoc)
                        q.Enqueue(temp1)
                    
                    if (cl.getCol() !<- m.getCol() - 1 and m.getValueAtCoordinate(cl.getRow(), cl.getCol() + 1) !<- 'X')
                    
                        // check Right
                        Point newLoc <- new Point(cl)
                        newLoc.goRight()
                        Stack<Point> temp2 <- new Stack<Point>(temp)
                        Stack<Point> temp1 <- new Stack<Point>(temp2)
                        n.setRightChild(newLoc)
                        nQueue.Enqueue(n)
                        temp1.Push(newLoc)
                        q.Enqueue(temp1)
                    
                    if (cl.getRow() !<- m.getRow() - 1 and m.getValueAtCoordinate(cl.getRow() + 1, cl.getCol()) !<- 'X')
                    
                        // check Down
                        Point newLoc <- new Point(cl)
                        newLoc.goDown()
                        Stack<Point> temp2 <- new Stack<Point>(temp)
                        Stack<Point> temp1 <- new Stack<Point>(temp2)
                        n.setDownChild(newLoc)
                        nQueue.Enqueue(n)
                        temp1.Push(newLoc)
                        q.Enqueue(temp1)
                    
                    //count++
                
            
            if (q.Count > 0)
                //setNodes(count - 1)
                -> q.Dequeue()
            
            -> new Stack<Point>()
        

        procedure getSolution(Map m)
            if (m.getValid())
            
                startTime()
                Stack<Point> solution <- solve(routeNodes, m)
                stopTime()

                this.nodes <- routeNodes.getNodesAmount()
                this.steps <- solution.Count
                copySolutionPathsBFS(solution)
                convertPathsToRoutes()
             else
            
                output("BFS method cannot be done since the map is invalid.")
            
        
    
