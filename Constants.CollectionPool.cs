// A part of the C# Language Syntactic Sugar suite.

using System.Collections.Generic;

namespace CLSS
{
  /// <summary>
  /// A global container of pools of single-type BCL collections.
  /// </summary>
  /// <typeparam name="T">The element type of the pooled collections.</typeparam>
  public partial class CollectionPool<T>
  {
    /// <summary>
    /// A global pool of <see cref="List{T}"/> collections.
    /// </summary>
    public static AgnosticObjectPool<List<T>> List
      = new AgnosticObjectPool<List<T>>(0,
        1,
        () => new List<T>(),
        c => c.Count == 0);

    /// <summary>
    /// A global pool of <see cref="HashSet{T}"/> collections.
    /// </summary>
    public static AgnosticObjectPool<HashSet<T>> HashSet
      = new AgnosticObjectPool<HashSet<T>>(0,
        1,
        () => new HashSet<T>(),
        c => c.Count == 0);

    /// <summary>
    /// A global pool of <see cref="SortedSet{T}"/> collections.
    /// </summary>
    public static AgnosticObjectPool<SortedSet<T>> SortedSet
      = new AgnosticObjectPool<SortedSet<T>>(0,
        1,
        () => new SortedSet<T>(),
        c => c.Count == 0);

    /// <summary>
    /// A global pool of <see cref="LinkedList{T}"/> collections.
    /// </summary>
    public static AgnosticObjectPool<LinkedList<T>> LinkedList
      = new AgnosticObjectPool<LinkedList<T>>(0,
        1,
        () => new LinkedList<T>(),
        c => c.Count == 0);

    /// <summary>
    /// A global pool of <see cref="Queue{T}"/> collections.
    /// </summary>
    public static AgnosticObjectPool<Queue<T>> Queue
      = new AgnosticObjectPool<Queue<T>>(0,
        1,
        () => new Queue<T>(),
        c => c.Count == 0);

    /// <summary>
    /// A global pool of <see cref="Stack{T}"/> collections.
    /// </summary>
    public static AgnosticObjectPool<Stack<T>> Stack
      = new AgnosticObjectPool<Stack<T>>(0,
        1,
        () => new Stack<T>(),
        c => c.Count == 0);
  }

  /// <summary>
  /// A global container of pools of key-value-type BCL collections.
  /// </summary>
  /// <typeparam name="TKey">The key type of the pooled collections.</typeparam>
  /// <typeparam name="TValue">The value type of the pooled collections.</typeparam>
  public partial class CollectionPool<TKey, TValue>
  {
    /// <summary>
    /// A global pool of <see cref="Dictionary{TKey, TValue}"/> collections.
    /// </summary>
    public static AgnosticObjectPool<Dictionary<TKey, TValue>> Dictionary
      = new AgnosticObjectPool<Dictionary<TKey, TValue>>(0,
        1,
        () => new Dictionary<TKey, TValue>(),
        c => c.Count == 0);

    /// <summary>
    /// A global pool of <see cref="SortedDictionary{TKey, TValue}"/> collections.
    /// </summary>
    public static AgnosticObjectPool<SortedDictionary<TKey, TValue>> SortedDictionary
      = new AgnosticObjectPool<SortedDictionary<TKey, TValue>>(0,
        1,
        () => new SortedDictionary<TKey, TValue>(),
        c => c.Count == 0);

#if NETSTANDARD1_3_OR_GREATER || NET_STANDARD_2_0
    /// <summary>
    /// A global pool of <see cref="SortedList{TKey, TValue}"/> collections.
    /// </summary>
    public static AgnosticObjectPool<SortedList<TKey, TValue>> SortedList
      = new AgnosticObjectPool<SortedList<TKey, TValue>>(0,
        1,
        () => new SortedList<TKey, TValue>(),
        c => c.Count == 0);
#endif
  }
}