using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LAB4_3.Models
{
    public class Huffman_A
    {
        private Node root;
        private Dictionary<byte, string> prefixes = new Dictionary<byte, string>();
        public Dictionary<string, byte> descompression_prefixes = new Dictionary<string, byte>();

        public Dictionary<byte, string> dictionary()
        {
            return prefixes;
        }

        Node node_(Node less, Node higher)
        {
            var father = new Node();
            var info_father = new Reading();
            father.data = info_father;
            father.left = less;
            father.right = higher;
            father.data.probability = (less.data.probability + higher.data.probability);
            return father;
        }

        public void Huffman(List<Node> characters)
        {
            while (characters.Count > 1)
            {
                var node = new Node();
                node = node_(characters[0], characters[1]);
                characters.RemoveAt(0);
                characters.RemoveAt(0);

                var new_n = characters.FindIndex(x => x.data.probability >= node.data.probability);
                if (new_n != -1)
                {
                    characters.Insert(new_n, node);
                }
                else
                {
                    characters.Add(node);
                }
            }
            root = characters[0];
            characters.Clear();
            characters = null;
        }
    }
}
