using System;

namespace State
{
    class Program
    {
        //Bir nesnenin iç durumu değişince davranışının da değişmesini sağlamak.
        static void Main(string[] args)
        {
            Context context = new Context();
            ModifiedState modified = new ModifiedState();
            modified.doAction(context);

            Console.WriteLine(context.GetState());
            Console.ReadLine();
        }
    }

    interface IState
    {
        void doAction(Context context);
    }

    class ModifiedState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("State : Modified");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Modified";
        }
    }

    class DeletedState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("State : Deleted");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Deleted";
        }
    }

    class AddedState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("State : Added");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Added";
        }
    }

    class Context
    {
        private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}
