//
// Magico  Copyright (C) 2024  Aptivi
//
// This file is part of Magico
//
// Magico is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// Magico is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Magico.Enumeration
{
    /// <summary>
    /// Extensions class for non-generic <see cref="IEnumerable"/> instances.
    /// </summary>
	public static class EnumerableExtensions
    {
        /// <summary>
        /// Counts the elements found in this enumerable
        /// </summary>
        /// <param name="enumerable">The target enumerable to count its elements</param>
        /// <returns>A number of elements</returns>
        public static int Length(this IEnumerable enumerable)
        {
            // First, focus on the known types
            if (enumerable is Array arrayEnumerable)
            {
                // It's an array!
                return arrayEnumerable.Length;
            }
            else if (enumerable is IList listEnumerable)
            {
                // It's a list!
                return listEnumerable.Count;
            }
            else if (enumerable is IDictionary dictionaryEnumerable)
            {
                // It's a dictionary!
                return dictionaryEnumerable.Count;
            }
            else if (enumerable is ICollection collectionEnumerable)
            {
                // It's a collection!
                return collectionEnumerable.Count;
            }

            // We're in the unknown IEnumerable.
            var generic = enumerable.OfType<object>();
            return generic.Count();
        }

        /// <summary>
        /// Gets an element from the index
        /// </summary>
        /// <param name="enumerable">The target enumerable to get an element</param>
        /// <param name="index">Zero-based index number of an element</param>
        /// <returns>An element from this enumerable</returns>
        public static object? GetElementFromIndex(this IEnumerable enumerable, int index)
        {
            if (index < 0)
                return null;

            // First, focus on the known types
            if (enumerable is Array arrayEnumerable)
            {
                // It's an array!
                return arrayEnumerable.GetValue(index);
            }
            else if (enumerable is IList listEnumerable)
            {
                // It's a list!
                return listEnumerable[index];
            }
            else if (enumerable is IDictionary dictionaryEnumerable)
            {
                // It's a dictionary!
                var keys = new object[dictionaryEnumerable.Count];
                dictionaryEnumerable.Keys.CopyTo(keys, 0);
                var key = keys[index];
                return dictionaryEnumerable[key];
            }
            else if (enumerable is ICollection collectionEnumerable)
            {
                var collection = collectionEnumerable.OfType<object>();
                return collection.ElementAt(index);
            }

            // Here, it's getting uglier as we don't have ElementAt() in IEnumerable, too!
            var generic = enumerable.OfType<object>();
            return generic.ElementAt(index);
        }

        /// <summary>
        /// Merges the two input sequences into one
        /// </summary>
        /// <typeparam name="TFirst">First type</typeparam>
        /// <typeparam name="TSecond">Second type</typeparam>
        /// <param name="source">Source sequence to merge</param>
        /// <param name="second">Second sequence to merge</param>
        /// <returns>Merged sequences</returns>
        public static IEnumerable<(TFirst First, TSecond Second)> Zip<TFirst, TSecond>(
            this IEnumerable<TFirst> source, IEnumerable<TSecond> second)
        {
            // Sanity checks
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (second is null)
                throw new ArgumentNullException(nameof(second));

            return source.Zip(second, (first, second) => (first, second));
        }

        /// <summary>
        /// Safely converts the source enumerable to the dictionary
        /// </summary>
        /// <typeparam name="TSource">Source element type</typeparam>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TValue">Value type</typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="valueSelector"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> ToDictionarySafe<TSource, TKey, TValue>(
            this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector)
            where TKey : notnull
        {
            // Sanity checks
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (valueSelector is null)
                throw new ArgumentNullException(nameof(valueSelector));

            var dictionary = new Dictionary<TKey, TValue>();
            foreach (var item in source)
            {
                // Get the key and the value
                var key = keySelector(item);
                var value = valueSelector(item);

                // Set the value
                dictionary[key] = value;
            }
            return dictionary;
        }
    }
}
