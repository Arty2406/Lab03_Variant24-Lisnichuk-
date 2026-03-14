using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using IntervalMergerApp;

namespace IntervalMergerApp
{
    public static class IntervalMerger
    {
        // 1. Метод полного перебора
        public static (List<Interval> result, double elapsedMilliseconds) MergeBruteForce(List<Interval> intervals)
        {
            if (intervals == null)
                throw new ArgumentNullException(nameof(intervals));

            // инструмент для измерения промежутков времени с высокой точностью (обычно до сотых долей секунды)
            var stopwatch = Stopwatch.StartNew();
            var result = new List<Interval>(intervals);

            bool hasChanges;
            do
            {
                hasChanges = false;
                for (int i = 0; i < result.Count - 1; i++)
                {
                    for (int j = i + 1; j < result.Count; j++)
                    {
                        if (DoIntervalsOverlap(result[i], result[j]))
                        {
                            var merged = MergeTwoIntervals(result[i], result[j]);
                            // Удаляем сначала больший индекс, чтобы избежать сдвига
                            result.RemoveAt(j);
                            result.RemoveAt(i);
                            result.Add(merged);
                            hasChanges = true;
                            // Выходим из обоих циклов для перезапуска
                            i = result.Count; // Выходим из внешнего цикла
                            break; // Выходим из внутреннего цикла
                        }
                    }
                }
            }
            while (hasChanges);

            // Сортируем результат по Start для соответствия ожидаемому порядку
            result = result.OrderBy(i => i.Start).ToList();

            // остановка и передача данных из Stopwatch
            stopwatch.Stop();
            return (result, stopwatch.Elapsed.TotalMilliseconds);
        }

        // 2. Оптимизированный метод через сортировку
        public static (List<Interval> result, double elapsedMilliseconds) MergeOptimized(List<Interval> intervals)
        {
            var stopwatch = Stopwatch.StartNew();

            // Проверка на null — выбрасываем исключение
            if (intervals == null)
                throw new ArgumentNullException(nameof(intervals));

            // Обработка пустого списка
            if (!intervals.Any())
            {
                stopwatch.Stop();
                return (new List<Interval>(), stopwatch.Elapsed.TotalMilliseconds);
            }

            // Сортируем интервалы по началу (Start)
            var sorted = intervals.OrderBy(i => i.Start).ToList();
            var result = new List<Interval>();
            result.Add(sorted[0]); // Добавляем первый интервал

            // Проходим по оставшимся интервалам
            for (int i = 1; i < sorted.Count; i++)
            {
                Interval last = result.Last(); // Последний интервал в результате
                Interval current = sorted[i];  // Текущий интервал из отсортированного списка

                if (DoIntervalsOverlap(last, current))
                {
                    // Если перекрываются — сливаем с последним в результате
                    var merged = MergeTwoIntervals(last, current);
                    result[result.Count - 1] = merged; // Обновляем последний интервал
                }
                else
                {
                    // Если не перекрываются — добавляем как новый
                    result.Add(current);
                }
            }

            stopwatch.Stop();
            return (result, stopwatch.Elapsed.TotalMilliseconds);
        }

        // 3. Проверка перекрытия интервалов
        public static bool DoIntervalsOverlap(Interval a, Interval b)
        {
            return a.Start <= b.End && b.Start <= a.End;
        }

        // 4. Слияние двух интервалов
        public static Interval MergeTwoIntervals(Interval a, Interval b)
        {
            return new Interval(Math.Min(a.Start, b.Start), Math.Max(a.End, b.End));
        }

        // 5. Сравнение результатов (корректен)
        public static bool AreResultsEqual(List<Interval> list1, List<Interval> list2)
        {
            if (list1.Count != list2.Count) return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].Start != list2[i].Start || list1[i].End != list2[i].End)
                    return false;
            }
            return true;
        }

        internal static bool AreResultsEqual((List<Interval> result, double elapsedMilliseconds) resultBruteForce, (List<Interval> result, double elapsedMilliseconds) resultOptimized)
        {
            throw new NotImplementedException();
        }
    }
}
