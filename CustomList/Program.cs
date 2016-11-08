using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();

            list.OnAdd += (new PerformListOperation(OnAddEventHandler));

            list.OnContains += (result) =>
            {
                Console.WriteLine("Contains was called successfully with result: {0}", result);
            };

            list.OnRemove += () =>
            {
                Console.WriteLine("Remove was successfully executed!");
            };

            try
            {
                list.Add(8);
                list.Add(5);
                list.Add(1);
                list.Add(2);
                list.Add(10);
                list.Add(11);

                list.Contains(0);

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
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void OnAddEventHandler()
        {
            Console.WriteLine("New element is added successfully!!!!!!");
        }
    }
}
