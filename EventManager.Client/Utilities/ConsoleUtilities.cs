namespace EventManager.Client.Utilities
{
    using EventManager.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ConsoleUtilities
    {
        private static int tableWidth = 77;

        public static string DrawTable<T>(IEnumerable<T> entities) where T : class
        {
            StringBuilder sb = new StringBuilder();
            string[] columnHeaders = entities.First().GetType().GetProperties().Select(p => p.Name).ToArray();
            sb.AppendLine(PrintRow(columnHeaders));
            sb.AppendLine(PrintLine());

            foreach (var entity in entities)
            {
                string[] entityValues = GenericPropertyFinder<T>.GetPropertiesValues(entity);
                sb.AppendLine(PrintRow(entityValues));
            }
            sb.AppendLine(PrintLine());

            return sb.ToString().Trim();
        }

        private static string PrintLine()
        {
            return new string('-', tableWidth);
        }

        private static string PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            return row;
        }

        private static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
