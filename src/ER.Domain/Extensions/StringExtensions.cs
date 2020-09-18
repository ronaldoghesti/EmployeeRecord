using System;
using System.Collections.Generic;
using System.Text;

namespace ER.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value)
        {
            return (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value));
        }
    }
}
