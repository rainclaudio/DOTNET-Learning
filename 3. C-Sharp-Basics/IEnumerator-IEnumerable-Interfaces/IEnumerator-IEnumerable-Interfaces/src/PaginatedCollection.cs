using System.Collections;


// PaginatedCollection: Encapsulates pagination logic, presenting a unified enumerable collection.
public class PaginatedCollection<T> : IEnumerable<T>
{
    private readonly Func<int, IEnumerable<T>> _pageFetcher;
    private readonly int _pageSize;


    public PaginatedCollection(Func<int, IEnumerable<T>> pageFetcher, int pageSize)
    {
        _pageFetcher = pageFetcher ?? throw new ArgumentNullException(nameof(pageFetcher));
        _pageSize = pageSize;
    }

    // GetEnumerator: Returns an enumerator that iterates through the collection.
    // "Generic Enumerator Generates" 
    public IEnumerator<T> GetEnumerator()
    {
        return new PaginatedEnumerator<T>(_pageFetcher, _pageSize);
    }

    // Explicit non-generic interface implementation for IEnumerable.
    // "Enumerable's Enumerator" - Mnemonic for remembering IEnumerable's explicit implementation.
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class PaginatedEnumerator<T> : IEnumerator<T>
    {
        private readonly Func<int, IEnumerable<T>> _pageFetcher;
        private readonly int _pageSize;
        private int _currentPage;
        private IEnumerator<T> _currentPageEnumerator;


        // Constructor for the enumerator.
        // "Fetching Freshly Formed Pages" - Mnemonic for constructor's role.
        public PaginatedEnumerator(Func<int, IEnumerable<T>> pageFetcher, int pageSize)
        {
            _pageFetcher = pageFetcher;
            _pageSize = pageSize;
            _currentPage = 0;
            _currentPageEnumerator = _pageFetcher(_currentPage).GetEnumerator();
        }

        // Current: Returns the item in the collection at the current position of the enumerator.
        public T Current => _currentPageEnumerator.Current;


        // Explicit non-generic interface implementation for current item.
        object IEnumerator.Current => Current;


        // MoveNext: Advances the enumerator to the next element in the collection, fetching new pages as needed.
        public bool MoveNext()
        {
            if (_currentPageEnumerator.MoveNext())
            {
                return true;
            }


            // Fetches the next page and updates the enumerator.
            _currentPage++;
            var nextPage = _pageFetcher(_currentPage);
            _currentPageEnumerator.Dispose();
            _currentPageEnumerator = nextPage.GetEnumerator();

            return _currentPageEnumerator.MoveNext();
        } 


        // Reset: Sets the enumerator to its initial position, which is before the first element in the collection.
        // "Reset Returns" - Mnemonic for remembering Reset's role.
        public void Reset()
        {
            _currentPage = 0;
            _currentPageEnumerator = _pageFetcher(_currentPage).GetEnumerator();
        }

        public void Dispose()
        {
            _currentPageEnumerator.Dispose();
        }
    }
}
