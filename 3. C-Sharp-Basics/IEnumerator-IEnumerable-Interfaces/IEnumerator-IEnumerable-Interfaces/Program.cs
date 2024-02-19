using IEnumerator_IEnumerable_Interfaces.src;



class Program
{

   

    static void Main(string[] args)
    {
        var fibonacci = new FibonacciSequence(10);
        foreach (var number in fibonacci)
        {
            Console.WriteLine(number);
        }

        IEnumerable<Cat> FetchCatsPage(int pageNumber)
        {
            var catsPerPage = 20;
            var totalPages = 5; // Simulating a total of 100 cats divided into 5 pages.
            var totalCats = totalPages * catsPerPage;
            var cats = new List<Cat>();

            if (pageNumber < totalPages)
            {
                for (int i = 1; i <= catsPerPage; i++)
                {
                    int catNumber = pageNumber * catsPerPage + i;
                    if (catNumber <= totalCats)
                    {
                        cats.Add(new Cat($"Cat {catNumber}"));
                    }
                }
            }
            return cats; // Returns an empty list when no more pages are available.
        }

        // Using PaginatedCollection<Cat>
        var paginatedCats = new PaginatedCollection<Cat>(FetchCatsPage, 20);
        foreach (var cat in paginatedCats)
        {
            Console.WriteLine(cat.Name);
        }
    }
}