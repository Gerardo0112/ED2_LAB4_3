using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED2_LAB4_3.Models
{
    public class Node
    {
        public Reading data { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
    }
}
