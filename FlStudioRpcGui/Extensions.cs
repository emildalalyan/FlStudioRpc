using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlStudioRpcGui
{
    /// <summary>
    /// Class intended to extending other classes.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Dispose all <see cref="Form"/>s in provided <see cref="FormCollection"/>.
        /// </summary>
        /// <param name="collection"></param>
        public static void DisposeAll(this FormCollection collection)
        {
            for (int i = 0; i < collection.Count; ++i) collection[i]?.Dispose();
        }
    }
}
