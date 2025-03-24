using DSATrees;

namespace ConversationConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConversationTree conversataion = new ConversationTree();

            conversataion.root = new ConversationNode("What is your Name",
                                    new List<string>()
                                                {"None of your Business",
                                                    "My Name is Bill",
                                                    "I've lost my memory"}, WHO.COMPUTER);

            //ConversationNode phrase = conversataion.Find(conversataion.root, "None of your Business");
            conversataion.InsertAfter("None of your Business", "How rude");

            Console.WriteLine("{0}", conversataion.root.phrase);
            int i = 1;
            foreach (ConversationNode answer in conversataion.root.children)
            {
                Console.WriteLine("Your Choices {0} {1}", i++, answer.phrase);
                if(answer.children.Count() > 0)
                {
                    int j = 1;
                    foreach (ConversationNode response in answer.children)
                    {
                        Console.WriteLine("Responses {0} {1}", j++, response.phrase);
                    }
                }
            }
            ConversationNode n = conversataion.HoldConversation(conversataion.root);
            Console.WriteLine("Computer says {0}", n.phrase);

            Console.ReadKey();
        }
    }
}
