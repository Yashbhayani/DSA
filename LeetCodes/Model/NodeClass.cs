using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodes.Model
{
    internal class NodeClass
    {
        public int data;
        public NodeClass left, right;

        public NodeClass(int value)
        {
            data = value;
            left = null;
            right = null;
        }
    }

}
