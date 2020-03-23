using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED_2_LAB4__3.Models
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
        public void asign_prefix(Node actual, string prefix)
        {
            if (actual.right != null)
            {
                if (actual.left != null)
                {
                    asign_prefix(actual.right, prefix + "0");
                    asign_prefix(actual.left, prefix + "1");
                }
            }
            else
            {
                actual.data.prefix_c = prefix;
                prefixes.Add(actual.data.c, actual.data.prefix_c);
            }
        }
        public Dictionary<byte, string> fill()
        {
            asign_prefix(root, "");
            return prefixes;
        }
        int BiToDe(string prefix)
        {
            char[] prefix_array = prefix.ToCharArray();
            Array.Reverse(prefix_array);
            int decimal_ = 0;
            for (int i = 0; i < prefix_array.Length; i++)
            {
                if (prefix[i] == '1')
                {
                    decimal_ += (int)Math.Pow(2, i);
                }
            }
            return decimal_;
        }
        string DeToBi(string decimal_)
        {
            string prefix = "";
            int n = Convert.ToInt32(decimal_);
            while (n > 0)
            {
                if (n % 2 != 0)
                {
                    prefix = "1" + prefix;
                }
                else
                {
                    prefix = "0" + prefix;
                }
                n = (n / 2);
            }

            return prefix;
        }
        public byte[] codification(byte[] decodification, int length)
        {
            //8 bits juntos.
            byte[] codification_ = new byte[length];
            string chain = "";
            int position = 0;

            for (int i = 0; i < decodification.Length && i < length; i++)
            {
                chain += prefixes[decodification[i]];
                //Guarda bits.
                if (chain.Length == 8)
                {
                    codification_[position] = Convert.ToByte(BiToDe(chain));
                    position++;
                    chain = "";
                }
                //Si supera, deja los restantes.
                else if (chain.Length > 8)
                {
                    //Almacena el prefijo.
                    string chain_ = "";
                    for (int x = 0; x < 8; x++)
                    {
                        chain_ += chain[x];
                    }
                    codification_[position] = Convert.ToByte(BiToDe(chain_));
                    position++;
                    chain_ = "";
                    for (int y = 8; y < chain.Length; y++)
                    {
                        chain_ += chain[y];
                    }
                    chain = chain_;

                }
                //Añade ceros.
                else if (i == decodification.Length - 1)
                {
                    string chain_a = chain;
                    chain = "";
                    for (int z = 0; z < 8 - chain_a.Length; z++)
                    {
                        chain += "0";
                    }
                    chain += chain_a;
                    codification_[position] = Convert.ToByte(BiToDe(chain_a));
                    position++;
                }
            }
            return codification_;
        }
    }
}
