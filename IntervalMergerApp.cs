using System;

namespace IntervalMergerApp
{
    public class Interval
    {
        public int Start { get; set; }
        public int End { get; set; }

        // Публичный конструктор
        public Interval(int start, int end)
        {
            if (start > end)
                throw new ArgumentException("Начало не может быть больше конца!");

            Start = start;
            End = end;
        }

#nullable enable
        public override string ToString() => $"[{Start}, {End}]";

        // Переопределяем сравнение объектов по значениям полей
        public override bool Equals(object? obj)
        {
            if (obj is not Interval other) return false;
            return Start == other.Start && End == other.End;
        }

        // Важно: GetHashCode должен быть согласован с Equals
        public override int GetHashCode() => HashCode.Combine(Start, End);
#nullable disable

        // Метод для парсинга строки вида "[10, 20]" в объект Interval
        public static Interval Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Входная строка не может быть пустой или состоять только из пробелов", nameof(input));

            // Убираем квадратные скобки и пробелы
            var trimmed = input.Trim().Trim('[', ']');
            var parts = trimmed.Split(',', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
                throw new FormatException($"Неверный формат строки: '{input}'. Ожидаемый формат: '[начало, конец]'");

            try
            {
                int start = int.Parse(parts[0].Trim());
                int end = int.Parse(parts[1].Trim());

                return new Interval(start, end);
            }
            catch (FormatException ex)
            {
                throw new FormatException($"Ошибка при преобразовании числа в строке '{input}': {ex.Message}", ex);
            }
        }

        // Оператор == для удобства сравнения
#nullable enable
        public static bool operator ==(Interval? left, Interval? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        // Оператор != для удобства сравнения
        public static bool operator !=(Interval? left, Interval? right) => !(left == right);
#nullable disable
    }
}