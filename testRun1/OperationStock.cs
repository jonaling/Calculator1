using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1
{
    public class OperationStock
    {
        private string[] operations;

        public OperationStock(string[] operations)
        {
            this.operations = operations;

        }

        public string[] Ops { get => operations; set => operations = value; }

        public int GetLength()
        {

            return operations.Length;
        }
    }
}
