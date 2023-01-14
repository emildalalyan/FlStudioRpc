using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlStudioRpc
{
    /// <summary>
    /// Class, which providing constants to help with RPC.
    /// </summary>
    internal static class RpcHelper
    {
        /// <summary>
        /// Constant, representing Discord RPC application ID.
        /// </summary>
        internal const string ApplicationId = "";

        /// <summary>
        /// Difference between UTC time and system time.
        /// </summary>
        internal readonly static TimeSpan DifferenceBetweenUtcAndSystem = DateTime.Now - DateTime.UtcNow;

        /// <summary>
        /// Key (name) of the large icon.
        /// </summary>
        internal const string LargeImageKey = "flicon";
    }
}
