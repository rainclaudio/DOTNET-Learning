namespace _9.Interface__Generics.src.Interfaces
{
    interface IMovable
    {
        public const int minSpeed = 0;
        private static int maxSpeed = 60;
        public void Move();
        protected internal string Name { get; set; }
        public delegate void MoveHand1er(string message);
        public event MoveHand1er MoveEvent;
    }
}
