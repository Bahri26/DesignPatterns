using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        /*Bütüne ve bütünü oluşturan parçalarına aynı şekilde
        erişim sağlamaktır.
        Nesne yapısal
        */
        static void Main(string[] args)
        {
            Employee bahri = new Employee { Name="Bahri KOÇ"};
            Employee salih = new Employee { Name = "Salih Sarı" };
            Employee ahmet = new Employee { Name = "Ahmet Sarı" };
            bahri.AddSubordinate(salih);
            salih.AddSubordinate(ahmet);

            Contractor ali = new Contractor { Name = "Ali" };
            ahmet.AddSubordinate(ali);

            foreach (Employee manager in bahri)
            {
                Console.WriteLine(manager.Name);
                foreach (IPerson employees in manager)
                {
                    Console.WriteLine(employees.Name);
                }
            }

            Console.ReadLine();
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get ; set ; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
