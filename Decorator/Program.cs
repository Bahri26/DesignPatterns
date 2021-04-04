using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonalCar
            {
                Make = "Mercedes",
                Model = "E",
                HirePrice=95000
            };

            SpecialOffer specialOffer = new SpecialOffer(personelCar);
            specialOffer.DiscountPercentage = 20;
            Console.WriteLine("Concrete  : {0}", personelCar.HirePrice);
            Console.WriteLine("Special Offer : {0}",specialOffer.HirePrice);
        }
    }

    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Make { get ; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase:CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carbase;
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
        }

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice 
        {
            get { return _carbase.HirePrice-(_carbase.HirePrice * DiscountPercentage/100); }
            set { }
        }
    }
}
