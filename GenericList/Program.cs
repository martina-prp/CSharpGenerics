using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<string> stringList = new GenericList<string>();
            stringList.Add("test");
            stringList.Add("test2");
            Console.WriteLine(stringList.GetElementByIndex(1));

            GenericList<int> list = new GenericList<int>();
            list.OnAddEvent += (int size) =>
            {
                Console.WriteLine(String.Format("Array size: {0}", size));
            };

            try
            {
                list.Add(8);
                list.Add(5);
                list.Add(1);
                list.Add(2);
                list.Add(20);
                list.Add(7);
                list.Add(11);

                Console.WriteLine("List contains: {0}", list.Contains(33));

                Console.WriteLine(list.GetElementByIndex(2));

                Console.WriteLine("Element removed: {0}", list.Remove(1));

                Console.WriteLine(list.GetElementByIndex(2));
                Console.WriteLine(list.GetElementByIndex(7));
                Console.WriteLine(list[4]);

                list[6] = 23;
                Console.WriteLine(list[6]);

                Console.WriteLine(list[0]);
                list[0] = 14;
                Console.WriteLine(list[0]);

                foreach (int item in list)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
