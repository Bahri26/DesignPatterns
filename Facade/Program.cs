using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    class Logging:ILogging
    {
        public void Log() { Console.WriteLine("Logged");}
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching:ICaching
    {
        public void Cache() { Console.WriteLine("Cached");}
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorizing:IAuthorizing
    {
        public void CheckUser() { Console.WriteLine("User checked"); }
    }

    internal interface IAuthorizing
    {
        void CheckUser();
    }

    class Validation : IValidate
    {
        public void Validate() { Console.WriteLine("User validated"); }
    }

    internal interface IValidate
    {
        void Validate();
    }

    class CustomerManager
    {

        CrossCuttingConcernsFecade _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFecade(); 
        }

        public void Save()
        {
            _concerns.Logging.Log();
            _concerns.Caching.Cache();
            _concerns.Authorizing.CheckUser();
            _concerns.Validation.Validate();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcernsFecade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorizing Authorizing;
        public IValidate Validation;

        public CrossCuttingConcernsFecade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorizing = new Authorizing();
            Validation = new Validation();
        }

    }
}
