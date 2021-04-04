using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AbstractFactory.Logging;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();
            Console.ReadLine();
        }
    }

    public abstract class Logging
    {
        public abstract void Log(string message);

        public class NLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with nlogger");
            }
        }

        public class Log4NetLogger : Logging
        {
            public override void Log(string message)
            {
                Console.WriteLine("Logged with log4netlogger");
            }
        }

        public abstract class Caching
        {
            public abstract void Cache(string data);
        }

        public class MemCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with MemCache");
            }
        }

        public class RedIsCache : Caching
        {
            public override void Cache(string data)
            {
                Console.WriteLine("Cached with rediscache");
            }
        }

        public abstract class CrossCuttingConcernsFactory1
        {
            public abstract Logging CreateLogger();
            public abstract Caching CreateCaching();
        }

        public class Factory1 : CrossCuttingConcernsFactory1
        {
            public override Caching CreateCaching()
            {
                return new RedIsCache();
            }

            public override Logging CreateLogger()
            {
                return new Log4NetLogger();
            }
        }

        public class Factory2 : CrossCuttingConcernsFactory1
        {
            public override Caching CreateCaching()
            {
                return new MemCache();
            }

            public override Logging CreateLogger()
            {
                return new NLogger();
            }
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernsFactory1 _crossCuttingConcernsFactory;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernsFactory1 crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _crossCuttingConcernsFactory.CreateLogger();
            _caching = _crossCuttingConcernsFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("Products listed!");
        }
    }
}
