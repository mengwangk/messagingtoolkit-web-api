using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MessagingToolkit.Service.Common.Helpers
{
    /// <summary>
    /// Entity class helper methods.
    /// </summary>
    public static class EntityHelper
    {

        private static string DatePattern = @"yyyy-MM-dd HH:mm:ss zzz";

        /// <summary>
        /// Generates a unique identifier.
        /// </summary>
        /// <returns>A unique identifier string</returns>
        public static string GenerateGuid()
        {
            return System.Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// Get current local date string.
        /// </summary>
        /// <returns>UTC date string</returns>
        public static string CurrentLocalDateString()
        {
            string dateString = DateTime.Now.ToString(DatePattern);
            return dateString;
        }

        /// <summary>
        /// Converts the date.
        /// </summary>
        /// <param name="dateString">The date string in <seealso cref="DatePattern"/> format.</param>
        /// <returns></returns>
        public static DateTime ConvertDate(string dateString)
        {
            try
            {
                return DateTime.ParseExact(dateString, DatePattern, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// To the transportable representation string value. E.g. JSON or XML.
        /// In this case we are using JSON string 
        /// </summary>
        /// <typeparam name="T">The object type to be converted</typeparam>
        /// <param name="obj">The object</param>
        /// <returns>Common representaion string</returns>
        public static string ToCommonRepreseentation<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        /// <summary>
        /// Derive the object from the represented string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="representedObj">The represented obj.</param>
        /// <returns></returns>
        public static T FromCommonRepresentation<T>(string representedObj)
        {
            return JsonConvert.DeserializeObject<T>(representedObj);
        }

        /// <summary>
        /// Converts the value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T ConvertValue<T, U>(U value) where U : IConvertible
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

    }
}
