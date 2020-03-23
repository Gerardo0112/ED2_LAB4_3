using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ED_2_LAB4__3.Models
{
    public class Node
    {
        public Reading data { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
    }
}
