using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator
{
    abstract class Aggregate
    {
        //Tekrarlayıcı nesnelerin yaratılması için bir arabirim oluşturur.
        public abstract Iterator CreateIterator();
    }
}
