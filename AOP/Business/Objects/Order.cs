using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Business.Objects
{
    public class Order:Business.Core.BusinessObject
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        public string ProductName { get; set; }
    }
}
