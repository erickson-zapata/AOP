using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOP.Business;
using AOP.Business.Objects;


namespace AOPConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer newCustomer = BusinessObjectFactory.Create<Customer>();

            newCustomer.PropertyChanging += delegate(object o, PropertyChangingEventArgs e) 
            { 
                var value=o.GetType().GetProperty(e.PropertyName).GetValue(o);
                Console.WriteLine("{0} value before is {1}", e.PropertyName, value);
            };

            newCustomer.PropertyChanged += delegate(object o, PropertyChangedEventArgs e) 
            { 
                var value =o.GetType().GetProperty(e.PropertyName).GetValue(o);
                Console.WriteLine("{0} value after is {1}", e.PropertyName,value ); 
            };


            newCustomer.FirstName = "Erickson";
            newCustomer.FirstName = "Edward";

            Console.ReadLine();
        }
        
    }
}
