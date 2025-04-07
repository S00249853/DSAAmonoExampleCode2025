namespace BuiltinDataStructureExamples2025
{
    
    class Player
    {
        public int ID { get; set; }
        public string GameTag { get; set; }
        public int XP { get; set; }

        public override string ToString()
        {

            return
                "ID: " + ID.ToString()
                    + " Game Tag: " + GameTag
                    + " XP: " + XP.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int i = 25;
            float f = 34.067f;
            print<int>(i);
            print<float>(f);

            Player p = new Player()
            {
                ID = 2,
                GameTag = "Willow Maker",
                XP = 200
            };
            //print<Player>(p);
            LL_ex();
            //ST_ex();
            //Queue_ex();
            //Dict_ex();

            Console.ReadLine();
        }

        static void print<T>(T obj) 
        {
            if(obj != null)
                Console.WriteLine("{0}", obj.ToString());
        }

        static void LL_ex()
        {
            LinkedList<int> someLinkedList = new LinkedList<int>();
            someLinkedList.AddFirst(34);
            someLinkedList.AddFirst(2);
            //someLinkedList.AddLast(45);
            someLinkedList.AddBefore(someLinkedList.Last, 23);
            int sum;
            sum = 0;
            Console.WriteLine("First is {0} Last is {1}. ", someLinkedList.First.Value.ToString(), someLinkedList.Last.Value.ToString());
            LinkedListNode<int> node = someLinkedList.First;
            // Last Node is always null;
            while (node != null)
            {
                Console.WriteLine("Chaining through {0} . ", node.Value.ToString());
                sum += node.Value;
                node = node.Next;
                Console.ReadKey();
            }

        }

        static void ST_ex()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            int i = stack.Pop();
            Console.WriteLine("Item popped is {0} stack count is {1}. current top item is {2} ", 
                                i.ToString(), stack.Count(), stack.Peek());
            Console.ReadKey();
        }
        static void Queue_ex()
        {
            Queue<int> fifo = new Queue<int>();
            fifo.Enqueue(1);
            fifo.Enqueue(2);
            int i = fifo.Dequeue();
            Console.WriteLine("Item dequeued is {0} stack count is {1}. current top item is {2} ", i.ToString(), fifo.Count(), fifo.Peek());
            Console.ReadKey();
        }

        static void Dict_ex()
        {
            Dictionary<int, Player> players = new Dictionary<int, Player>();
            players[42] = new Player()
            {   
                ID = 42,GameTag = "EMO", XP = 400
            };
            players[50] = new Player()
            {
                ID = 50, GameTag = "Shadow", XP = 200
            };
            players.Add(60, new Player()
            {
                ID = 60, GameTag = "Sunny", XP = 300
            });

            Player p = players[42];
            print(p);

            Player p2;
            print(players[50]);

            // Printing out Dictionary Keys and Values
            foreach (KeyValuePair<int, Player> kvp in players)
            {
                print(kvp.Key);
                print(kvp.Value);
            }

            if (players.TryGetValue(50, out p2))
            {
                p2.GameTag = "Bob a Job";
                print(p2);
            }
            else Console.WriteLine("Player not found");




        }
    }
}
