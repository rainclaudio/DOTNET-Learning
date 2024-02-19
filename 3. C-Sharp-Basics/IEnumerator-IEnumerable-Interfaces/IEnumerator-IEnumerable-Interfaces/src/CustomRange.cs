using System.Collections;

namespace IEnumerator_IEnumerable_Interfaces.src
{

    public class CustomRange : IEnumerable<int>
    {
        private readonly int _start;
        private readonly int _end;

        public CustomRange(int start, int end)
        {
            _start = start;
            _end = end;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new RangeEnumerator(_start, _end);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class RangeEnumerator : IEnumerator<int>
        {
            private readonly int _start;
            private readonly int _end;
            private int _current;

            public RangeEnumerator(int start, int end)
            {
                _start = start;
                _end = end;
                _current = _start - 1; // Start before the first element
            }

            public int Current => _current;

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                if (_current < _end)
                {
                    _current++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _current = _start - 1;
            }

            public void Dispose()
            {
                // No resources to dispose in this case
            }
        }
    }
}
