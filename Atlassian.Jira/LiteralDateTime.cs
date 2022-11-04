using System;
using System.Diagnostics.CodeAnalysis;

namespace Atlassian.Jira
{
    /// <summary>
    /// Force a DateTime field to use a string provided as the JQL query value.
    /// </summary>
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public class LiteralDateTime
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
    {
        private readonly string _dateTimeString;

        public LiteralDateTime(string dateTimeString)
        {
            _dateTimeString = dateTimeString;
        }

        public override string ToString()
        {
            return _dateTimeString;
        }

        public static bool operator ==(DateTime dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator !=(DateTime dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator >(DateTime dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator <(DateTime dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator >=(DateTime dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator <=(DateTime dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator ==(DateTime? dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator !=(DateTime? dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator >(DateTime? dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator <(DateTime? dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator >=(DateTime? dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }

        public static bool operator <=(DateTime? dateTime, LiteralDateTime literalDateTime)
        {
            return false;
        }
    }
}
