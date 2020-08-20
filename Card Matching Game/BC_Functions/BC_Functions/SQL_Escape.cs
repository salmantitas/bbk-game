/*
 * Brian Chaves
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC_Functions
{
    public static class SQL_Escape
    {
        /// <summary>
        /// SQL Escape string to ensure no SQL injectsons happen :(
        /// </summary>
        /// <param name="value">string value</param>
        /// <returns></returns>
        public static string Escape(string value)
        {
            try
            {
                return value.Replace("'", "''");
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// SQL Escape string to ensure no SQL injectsons happen :(
        /// </summary>
        /// <param name="value">string value to change</param>
        public static void Escape(ref string value)
        {
            value = Escape(value);
        }
    }
}