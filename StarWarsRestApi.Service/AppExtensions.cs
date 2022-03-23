namespace StarWarsRestApi.Service
{
    public static class AppExtensions
    {
        /// <summary>
        /// Adds the elements in the <paramref name="source"/> to the <paramref name="destination"/>.
        /// </summary>
        /// <typeparam name="T">The type of element to iterate over.</typeparam>
        /// <param name="source">The source elements.</param>
        /// <param name="destination">The destination elements.</param>
        public static void AddTo<T>(this IEnumerable<T> source, IList<T> destination)
        {
            foreach (var item in source)
            {
                destination.Add(item);
            }
        }
    }
}
