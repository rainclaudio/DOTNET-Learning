namespace _9.Interface__Generics.src.Interfaces
{
    internal class Car : IMovable
    {
        string IMovable.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event IMovable.MoveHand1er MoveEvent;

        event IMovable.MoveHand1er IMovable.MoveEvent
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        void IMovable.Move()
        {
            throw new NotImplementedException();
        }
    }
}
