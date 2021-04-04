using System;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Tekrarlayıcı tasarım kalıbı; birleşik bir nesnenin bileşenlerine, 
            nesnenin esas ifadesinin 
            gösterilimini açığa çıkarmadan sırayla erişebilmeyi sağlar.
            
            Tekrarlayıcı tasarım kalıbı, bir listenin yapısının ve 
            çalışma tarzının uygulamanın diğer kısımları ile olan 
            bağlantılarını en aza indirmek için; listede yer alan nesnelerin, 
            sırasıyla uygulamadan soyutlanması amacıyla kullanılır.
            */
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";
            ConcreteIterator i = new ConcreteIterator(a);
            Console.WriteLine("Iterating over collection:");
            object item = i.First();

            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }
            Console.ReadKey();
        }
    }
}
