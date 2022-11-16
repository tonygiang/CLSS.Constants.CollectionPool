# CLSS.Constants.CollectionPool

### Problem

In many real-world situations, the most straight-forward way to solve a problem is to construct a temporary collection to hold your elements. However, since the creation of a new collection on the fly costs an allocation for the collection itself, hot code paths usually have a persistent collection as a class field to avoid this allocation. This not only puts bloat on a class source file by mixing data fields with reuse-able collections, it can also cost more memory space than necessary when a large number of objects have persistent collection field but only a few objects actually make use of their persistent collection fields at any given moment.

While .NET Standard 2.1 shipped with the [`ArrayPool<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.arraypool-1?view=net-6.0) class, the inflexibility of arrays makes it unsuitable for many situations.

### Solution

Inspired by the [`ArrayPool<T>`](https://www.nuget.org/packages/CLSS.Types.AgnosticObjectPool) class, this package provides global pools of BCL collection types under the `System.Collections.Generic` namespace up to what is contained in .NET Standard 2.0. This means the following collection types are pooled:

- [`Dictionary<TKey,TValue>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0)
- [`HashSet<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1?view=net-6.0)
- [`LinkedList<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1?view=net-6.0)
- [`List<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-6.0)
- [`Queue<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=net-6.0)
- [`SortedDictionary<TKey,TValue>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-6.0)
- [`SortedList<TKey,TValue>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2?view=net-6.0)
- [`SortedSet<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedset-1?view=net-6.0)
- [`Stack<T>`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=net-6.0)

The type of the pools themselves are [`AgnosticObjectPool`](https://www.nuget.org/packages/CLSS.Types.AgnosticObjectPool) - this package's only dependency. Their available instance predicate function is a check for emptiness. Since `AgnosticObjectPool` does not formally have a mechanism for manual releasing of pooled instances and only checks for availability on-demand, you have to mark a pooled collection instance as "available" again after you are done using it by emptying it.

The type parameters for the pooled collections are passed through the `CollectionPool` class.

```csharp
using CLSS;

SortedSet<int> sortedUniqueIDs = CollectionPool<int>.SortedSet.TakeOne();
foreach (int id in bookAuthorIDs) sortedUniqueIDs.Add(id);
[...] // Do something with sortedUniqueIDs
// The pool can now give this SortedSet instance to another code path
sortedUniqueIDs.Clear();

Dictionary<int, SteerAgent> neighbours
  = CollectionPool<int, SteerAgent>.Dictionary.TakeOne();
// out parameter is another good use-case for pooled collections
PollForNeighbours(out neighbours);
[...] // Do something with neighbours
neighbours.Clear();
```

The pools provided by this package have the initial size of 0 and a grow step of 1. Since `AgnosticObjectPool` has all of its fields and methods public, you can manually pre-grow them and set a different grow step at runtime, should you need to.

The .NET Standard 1.0 assembly of this package does not contain a pool for `SortedList`. The lowest .NET Standard version that supports `SortedList` is 1.3. Hence this package provides an extra assembly for .NET Standard 1.3 which does contain a pool for `SortedList`.

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).