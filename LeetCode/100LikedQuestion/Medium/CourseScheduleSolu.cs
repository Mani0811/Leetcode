using System.Collections.Generic;

namespace LeetCode._100LikedQuestion
{
    class CourseScheduleSolu : BaseClass
    {
        public override void Run()
        {
            base.Run();

            var result = !CanFinish(3, new int[][]{ new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 0 } });
           
        }
        List<List<int>> adj;
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {

            // Adjacency List as ArrayList 
            // of ArrayList's  
            adj = new List<List<int>>(numCourses);
            for (int i = 0; i < numCourses; i++)
                adj.Add(new List<int>());

            for (int i = 0; i < prerequisites.Length; i++)
            {
                adj[prerequisites[i][0]].Add(prerequisites[i][1]);
            }

            bool[] visited = new bool[numCourses];
            bool[] recStack = new bool[numCourses];


            // Call the recursive helper function to  
            // detect cycle in different DFS trees  
            for (int i = 0; i < numCourses; i++)
                if (isCyclicUtil(i, visited, recStack))
                    return false;

            return true;

        }
        private bool isCyclicUtil(int i, bool[] visited,
                                    bool[] recStack = null)
        {

            // Mark the current node as visited and  
            // part of recursion stack  
            if (recStack[i])
                return true;

            if (visited[i])
                return false;

            visited[i] = true;

            recStack[i] = true;
            List<int> children = adj[i];

            foreach (int c in children)
                if (isCyclicUtil(c, visited, recStack))
                    return true;

            recStack[i] = false;

            return false;
        }

    }
}

