# IEnumerable and Custom Enumerator Pattern in .NET

## Overview
This repository shows implementations of the `IEnumerable` interface and custom enumerator patterns in .NET, showcasing two classes: `FibonacciSequence` and `PaginatedCollection<T>`. These patterns provide a way to iterate over a collection or sequence of data in a controlled manner.

## IEnumerable in .NET
The `IEnumerable` interface is a core part of the .NET Framework that facilitates iteration over a non-generic collection. An `IEnumerable<T>` interface represents a generic collection that can be iterated over using the `foreach` loop in C#. It requires the implementation of the `GetEnumerator` method, which returns an `IEnumerator` or `IEnumerator<T>` for iterating over the collection.

## Fibonacci Sequence Class
The `FibonacciSequence` class generates a sequence of Fibonacci numbers up to a specified count, implementing the `IEnumerable<int>` interface.

### Fibonacci Usage
To use the `FibonacciSequence` class:

```csharp
var fibonacci = new FibonacciSequence(10);
foreach (var number in fibonacci)
{
    Console.WriteLine(number);
}
```
## Paginated Collection Class
The PaginatedCollection<T> class provides an example of a custom enumerator that can be particularly useful for handling paginated data, such as API responses. It uses a function delegate to fetch data for each page and seamlessly iterates over the entire dataset.

### PaginatedCollection<T> Usage
```csharp
var paginatedCats = new PaginatedCollection<Cat>(FetchCatsPage, 5);
foreach (var cat in paginatedCats)
{
    Console.WriteLine($"Name: {cat.Name}, Breed: {cat.Breed}, Description: {cat.Description}");
}
```