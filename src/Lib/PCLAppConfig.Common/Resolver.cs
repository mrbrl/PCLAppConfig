using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLResolver.Interfaces;
using PCLResolver.Resolvers;

namespace PCLAppConfig.Common
{
    public class Resolver
    {
        static Resolver()
        {
            Instance = new AutoFacResolver();
        }

        public static void Reset()
        {
            Instance = null;
            Instance = new AutoFacResolver();
        }

        /// <summary>
        ///     Gets or sets the instance.
        /// </summary>
        public static IResolver Instance { get; set; }

    }
}
