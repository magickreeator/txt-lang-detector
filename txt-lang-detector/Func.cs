using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace txt_lang_detector
{
    class Func
    {
        // Если текущий элемент больше тех, что расположены ниже, то нужно вернуть истину.
        bool check_down(double[] count, int i)
        {
            for (int j = i; j < count.Length - 1; j++)
            {

                if (count[i] > count[j + 1])
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        // Если текущий элемент меньше тех, что расположены выше, то нужно вернуть истину.
        bool check_up(double[] count, int i)
        {
            for (int j = i; j > 1; j--)
            {

                if (count[i] < count[j - 1])
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public int detect(char[] lang, string text)
        {
            // Для  хранения частот.
            double[] Freq = new double[lang.Length];
            // 
            bool[] rank_check = new bool[lang.Length];
            // Для хранения количества букв.
            double letter_count = 0;
            // Обнуление значений элементов массива.
            for (int i = 0; i < lang.Length; i++)
            {
                Freq[i] = 0;
            }
            // 
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < lang.Length; j++)
                {
                    // Если рассматриваемый символ является буквой.
                    if (text[i] >= 'a' && text[i] <= 'z' || text[i] >= 'а' && text[i] <= 'я')
                    {
                        letter_count++;
                        if (text[i] == lang[j])
                        {
                            //char[] ccounter = new char[lang.Length];
                            // Инкрементировать количество найденных букв в позиции предпологаемых частот.
                            Freq[j]++;
                        }
                    }
                }
            }
            for (int i = 0; i < lang.Length; i++)
            {
                // Вычисление частот по формуле Freq_x=Q_x/Q_all.
                Freq[i] = Freq[i] / letter_count;
            }
            // Для хранения совпадений найденных частот и эталонных частот.
            int equals = 0;
            for (int i = 0; i < lang.Length; i++)
            {
                if (check_down(Freq, i))
                {
                    equals++;
                }

            }
            if (check_up(Freq, lang.Length - 1))
            {
                equals++;
            }
            // Если количество совпадений больше хотя бы половины количества букв в языке, то вернуть истину.

            return equals;

        }
    }
}
