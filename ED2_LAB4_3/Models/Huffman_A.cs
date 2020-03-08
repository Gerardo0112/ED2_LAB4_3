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
    }
}
