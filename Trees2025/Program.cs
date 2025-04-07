using DSATrees;

namespace Trees2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericTree<string> t = new DSATrees.GenericTree<string>();

            t.Root = new TNode<string>("A", new List<TNode<string>>()
            {
                new TNode<string>("B", new List<TNode<string>>() // A->B
                {
                    new TNode<string>("X", // A->B->X
                    children: new List<TNode<string>>{ new TNode<string>("G")}), // A->B->X->G
                    new TNode<string>("G") // A->B->G
                }),
                new TNode<string>("C", children:new List<TNode<string>>() // A->C
                {
                    new TNode<string>("D"), // a->C->D
                    new TNode<string>("E") // A->C->E
                }) 
            });

            Stack<TNode<string>> frontier = new Stack<TNode<string>>();
            frontier.Push(t.Root);
            //
            Stack<TNode<string>>? SolutionPath =  t.dfs(Current:t.Root, 
                                                        Path:new Stack<TNode<string>>() { },
                                                        frontier, 
                                                        visited:new List<TNode<string>>(), 
                                                        Goal:new TNode<string>("G"));
            if(SolutionPath != null)
            {
                Console.WriteLine("Solution Path:");
                foreach (var node in SolutionPath)
                {
                    Console.WriteLine(node.Value);
                }
            }
            else
            {
                Console.WriteLine("No solution found");
            }
            Console.ReadLine();
        }
    }
}
