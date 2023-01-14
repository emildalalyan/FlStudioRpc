using System;

namespace FlStudioInfoHelper
{
    /// <summary>
    /// Class intended to extending other classes.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// If provided array is empty (or null), then it returns null, otherwise it returns first element of the array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
#nullable enable
        public static T? IfNotEmptyReturnFirst<T>(this T[] array) where T : class
#nullable disable
        {
            if (array.Length < 1 || array == null) return null;
            else return array[0];
        }
    }
}
