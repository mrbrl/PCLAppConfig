using PCLResolver.Interfaces;

namespace PCLResolver
{
    public class Resolver<T> where T : IResolver, new()
    {
        static Resolver()
        {
            Instance = new T();
        }

        public static void Reset()
        {
            Instance = null;
            Instance = new T();
        }

        /// <summary>
        ///     Gets or sets the instance.
        /// </summary>
        public static IResolver Instance { get; set; }

    }
}
