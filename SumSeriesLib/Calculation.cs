using System.Collections.ObjectModel;

namespace SumSeriesLib
{
    /// <summary>
    /// Класс с формулами для вычисления
    /// </summary>
    public class Calculation
    {
        /// <summary>
        /// Метод для вычисления суммы рядом с точность eps
        /// </summary>
        /// <param name="x"> Число x должно быть меньше 1</param>
        /// <param name="eps">Точность eps</param>
        public static ObservableCollection<string> CalculateSumSeries( double x ,double eps)
        {
            ObservableCollection<string> list = new ObservableCollection<string>();
            if( Module(x) < 1 || eps > 0)
            {
                double sum = 1+ x;
                double a = x;
                int i = 2;

                while (Module(a) > eps)
                {
                    a =  (a * x) / i;
                    sum += a;
                    list.Add($"Шаг {i} Сумма шага: {a} Сумма: {sum} EPS: {eps}");
                    i++;
                }
            }
            return list;
        }

        public static double Module(double x)
        {
            if(x < 0)
            {
                return x * -1;
            }
            else
            {
                return x;
            }
        }
    }
}