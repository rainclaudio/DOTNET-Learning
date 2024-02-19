using System.Collections;

namespace IEnumerator_IEnumerable_Interfaces.src
{
    public class FibonacciSequence : IEnumerable<int>
    {
        private readonly int _maxCount;

        public FibonacciSequence(int maxCount)
        {
            _maxCount = maxCount;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int previous = -1;
            int next = 1;

            for (int i = 0; i < _maxCount; i++)
            {
                int sum = previous + next;
                previous = next;
                next = sum;
                yield return sum;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
