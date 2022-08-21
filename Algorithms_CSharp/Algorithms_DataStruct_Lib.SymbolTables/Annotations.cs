namespace Algorithms_DataStruct_Lib.SymbolTables
{
    public class Annotations
    {
        /*
     * -------------  
     *  - Symbol Table allows to add a value using a key and then retrieve that data by the key
     *  
     *  - Often, developers and mathematicians refer to symbol tables as to dictionaries
     *      (Symbol Tables are called dictionaries in the .NET plataform aswell)
     *  
     *  - Key doesn't have to be an integer, or any other particular type
     *  
     *  - Consists of key/value pairs and data types don't have to match
     *  
     *  - Four ways of implementing a symbol table,
     *    3 of which are competitive while one is basic and trivial
     * -------------   
     * 
     * In general, it's possible divide Symbol Tables in two categories:
     * 
     *  *Ordered (sorted)
     *  *Unordered (unsorted)   
     *  
     *      both categories should support the following API
     *  
     *  
     * [Symbol Table - Basic API]:
     * 
     *      - A default constructor and a constructor which allows a client to pass a custom keys comparer
     *      
     *      - bool TryGet(TKey key) - returns true if a value was found, otherwise false
     *      - void Add(Tkey key, TValue val) - inserts a key-value pair into a table (a key can't be null)
     *      - bool Remove(TKey) - explicity removes a key-value pair (doesn't just pass null to a value, remove entirely)
     *      - bool Contains(Tkey key) - checks if a certain key is presented in a table
     *      - bool IsEmpty() - auxiliary method which returns true if there are no keys and false otherwise
     *      - IEnumerable<TKey>Keys() - return all the keys from a table
     * 
     * [Ordered Symbol Table]:
     *      -TKey Min() - the least key
     *      -Tkey Max() - the greatest key
     *      void RemoveMin() - remove least key
     *      void RemoveMax() - remove greatest key
     *      TKey Floor(TKey key) - get the greatest key which is less or equal the requested key
     *      TKey Ceiling(Tkey key) - get the least key which is greater or equals the requested key
     *      int Rank(TKey key) - counts the number of keys which are less than the requested key
     *      TKey Select(int k) - searches for a key with a specific rank
     *      int Range(TKey a, TKey b) - allows to quickly get the number of keys between a and b [a..b] (a and b inclued)
     * 
     */
    }
}