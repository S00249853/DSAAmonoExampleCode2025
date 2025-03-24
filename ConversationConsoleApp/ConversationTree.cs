using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DSATrees
{
    public enum WHO { HUMAN,COMPUTER}
    public class ConversationTree
    {
   
        public ConversationNode root;
  

        public ConversationNode InsertAfter(string phrase, string NextPhrase)
        {
            ConversationNode found = Find(root, phrase);
            if (found != null)
            {
                ConversationNode newNode = new ConversationNode(NextPhrase, null, found.talking == WHO.COMPUTER ? WHO.HUMAN : WHO.COMPUTER);
                found.children.Add(newNode);
                return newNode;
            }
            return null;
        }

        public ConversationNode Find(ConversationNode current, string Phrase)
        {
            if (current != null)
            {
                if (current.phrase == Phrase)
                {
                    return current;
                }
                else if (current.children.Count() > 0)
                    foreach (ConversationNode node in current.children)
                        if (node.phrase != Phrase)
                            Find(node, Phrase);
                        else return node;
            }
            return null;
        }

        public ConversationNode HoldConversation(ConversationNode Current)
        {
            
            while (Current != null)
            {
                int i = 0;
                if (Current.talking == WHO.COMPUTER && Current.children.Count > 0)
                {

                    foreach (ConversationNode answer in Current.children)
                    {
                        Console.WriteLine("Responses {0} {1}", i++, answer.phrase);
                    }
                    int ans;
                    if (Int32.TryParse(Console.ReadLine(), out ans) && ans > -1 && ans < Current.children.Count - 1)
                    {
                        Current = Current.children[ans];
                    }
                    else
                    {
                        Console.WriteLine("Incorrect choice");
                    }

                }
                else if (Current.talking == WHO.HUMAN && Current.children.Count == 1)
                {
                    Console.WriteLine("{0} ", Current.children[0].phrase);
                    break;
                }
                else break;
            }
            Console.WriteLine("End of");
          Console.ReadKey();
            return Current;
        }


       
    }
    public class ConversationNode
    {
        public List<ConversationNode> children = new List<ConversationNode>();


        public string phrase;
        public WHO talking;


        public ConversationNode(string Phrase,
                        List<string> childPhrases, WHO who)
        {
            talking = who;
            phrase = Phrase;
            if (childPhrases != null)
            {
                foreach (var p in childPhrases)
                {
                    children.Add(new ConversationNode(p, null, talking == WHO.COMPUTER?WHO.HUMAN:WHO.COMPUTER));
                }
            }
        }


    }
}
