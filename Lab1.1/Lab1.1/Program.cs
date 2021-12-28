using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Сами объекты хранятся в списках в папке проекта, там же находится рассчитанное кол-во этих объектов по формулам
//
//
namespace lab1_1
{
    class Program
    {
        public int[] obj; // хранит сам объект
        public int _n; // n
        public char[] alphabet; // Хранит алфавит
        public int _k; // k
        public Program(int n, int k) // конструктор стандартный
        {
            _n = n;
            _k = k;
            obj = new int[k];
            alphabet = new char[n];

        }
        public Program(int n,int k,int j) // конструктор для размещений из н по к
        {
            _n = n;
            _k = k;
            obj = new int[n];
            alphabet = new char[n];

        }
        public void SetAlphabet(char a, int i) // Устанавливаем множество для генерации перестановок - порядок ввода == порядку в генерации
        {

                alphabet[i] = a;

        }
        void Swap(int i, int j)
        {
            int b = obj[i];
            obj[i] = obj[j];
            obj[j] = b;
        }
        public void NextASPovt() // генерация следующего размещения с повторением
        {
            for (int i = _k - 1; i > -1; i--)
            {
                if (obj[i] == _n - 1)
                {
                    obj[i] = 0;
                    continue;
                }
                obj[i]++;
                break;
            }
        }
        public bool LastASPoct() // true - последнее размещение с повторением сгенерировано 
        {
            bool b = true;
            for(int i = 0;i<_k;i++)
            {
                if (obj[i] != _n - 1)
                {
                    b = false;
                    break;
                }
            }
            return b;
        }
        public bool NextPer() // генерация перестановки возвращает false когда последняя сгенерирована
        {
            int j = _n - 2;
            while(j!=-1 && obj[j] >= obj[j+1])
            {
                j--;
            }

            if (j == -1)
            {
                return false;
            }

            int k = _n - 1;
            while(obj[j]>=obj[k])
            {
                k--;
            }

            Swap(j, k);

            int c = j + 1;
            int r = _n - 1;

            while(c<r)
            {
                Swap(c++, r--);
            }
            
            return true;
        }
        public bool NextA() // генерация размещения возвращает false когда последняя сгенерирована
        {
            int j;
            do
            {
                j = _n - 2; 
                while (j != -1 && obj[j] >= obj[j + 1])
                {
                    j--;
                }

                if (j == -1)
                {
                    return false;
                }

                int k = _n - 1;
                while (obj[j] >= obj[k])
                {
                    k--;
                }

                Swap(j, k);

                int c = j + 1;
                int r = _n - 1;

                while (c < r)
                {
                    Swap(c++, r--);
                }
            } while (j > _k - 1);

            return true;
        }

        bool NextSoch(int c) // генерация сочетания из н по к. int c == k false когда последняя сгенерирована
        {
            int k = c;
            for (int i = k - 1; i >= 0; i--)
                if (obj[i] < _n - k + i )
                {
                    obj[i]++;
                    for (int j = i + 1; j < k; j++)
                        obj[j] = obj[j - 1]+1 ;
                    return true;
                }
            return false;
        }
        bool NextSochSPovt() // генерация сочетаний с повторением  false когда последняя сгенерирована
        {
            int j = _k - 1;
            while ( j >= 0 && obj[j] == _n - 1) j--;
            if (j < 0) return false;
            if (obj[j] >= _n-1)
                j--;
            obj[j]++;
            if (j == _k - 1) return true;
            for (int k = j + 1; k < _k; k++)
                obj[k] = obj[j];
            return true;
        }



        static void Main(string[] args)
        {
            ////////////////////////////////////////////////////////////1.1  РАЗМЕЩЕНИЯ С ПОВТОРЕНИЯМИ ИЗ N по K
            Console.WriteLine("Vvedite razmernost alpfavita");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dlinu slova:");
            int k = Convert.ToInt32(Console.ReadLine());
            Program obj = new Program(n, k);
            Program obj2 = new Program(n, n);
            Program obj3 = new Program(n, k, 0);
            Program obj4 = new Program(n, n);
            Program obj5 = new Program(n, k);
            Program obj6 = new Program(n, k);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("simvol alfavita: ");
                char a = Convert.ToChar(Console.ReadLine());
                obj.SetAlphabet(a,i);
                obj2.SetAlphabet(a,i);
                obj3.SetAlphabet(a,i);
                obj4.SetAlphabet(a,i);
                obj5.SetAlphabet(a,i);
                obj6.SetAlphabet(a,i);
            }
            for (int i = 0; i < obj._k; i++)
            {
                obj.obj[i] = 0;
            }

            /*StreamWriter sw = new StreamWriter(@"C:\dm2021\Lab1.1\Lab1.1\list1.txt");*/                                          
            StreamWriter sw = new StreamWriter(@"D:\dm2021\dm2021\Lab1.1\Lab1.1\list1.txt");
            sw.Write("n = " +n+ " k = "+k+ " kolvo strok = n^k = " +Math.Pow(obj._n,obj._k) + " alphabet = {"); // Вывод строки информации об объектах

            for (int i =0;i<n;i++)
            {
                sw.Write(obj.alphabet[i]+" ");
            }
            sw.WriteLine("}");

            while (!obj.LastASPoct()) // вывод слова в цикле и генерация следующего 
            {
                for (int i = 0; i < k; i++) 
                {
                    sw.Write(obj.alphabet[obj.obj[i]]);

                }
                sw.WriteLine();

                obj.NextASPovt();
            }
            for (int i = 0; i < k; i++) // последнее слово
            {
                sw.Write(obj.alphabet[obj.obj[i]]);

            }
            sw.Close();

            ////////////////////////////////////////////////////////////////////////////////////1.2 ПЕРЕСТАНОВКИ ИЗ N

            /* StreamWriter sw2 = new StreamWriter(@"C:\dm2021\Lab1.1\Lab1.1\list2.txt");*/                       
            StreamWriter sw2 = new StreamWriter(@"D:\dm2021\dm2021\Lab1.1\Lab1.1\list2.txt");
            for (int i = 0; i < obj2._k; i++)
            {
                obj2.obj[i] = i;
            }
            int c = 1;
            for(int i = 1;i < n+1;i++)       // Тут факториалы для формул расчета количества объектов
            {
                c *= i;
            }
            sw2.Write("n = " + n + " kolvo strok = n! = " + c + " alphabet = {");   // Вывод строки информации об объектах

            for (int i = 0; i < n; i++)
            {
                sw2.Write(obj2.alphabet[i] + " ");
            }
            sw2.WriteLine("}");

            for (int i =0;i<n;i++) // первое слово
            {
                obj2.obj[i] = i;
            }

            for (int i = 0; i < n; i++)
            {
                sw2.Write(obj2.alphabet[obj2.obj[i]]);

            }
            sw2.WriteLine();

            while (obj2.NextPer()) // вывод слова в цикле и генерация следующего 
            {
                for (int i = 0; i < n; i++)
                {
                    sw2.Write(obj2.alphabet[obj2.obj[i]]);

                }
                sw2.WriteLine();

            }
            
            sw2.Close();

            ////////////////////////////////////////////////////////////////////////////////////1.3 РАЗМЕЩЕНИЯ БЕЗ ПОВТОРЕНИЙ ИЗ N по K

            int c1;
            if (obj3._k <= obj3._n)
            {                  
                StreamWriter sw3 = new StreamWriter(@"D:\dm2021\dm2021\Lab1.1\Lab1.1\list3.txt");
                c = 1;
                for (int i = 1; i < n + 1; i++)       // Тут факториалы для формул расчета количества объектов
                {
                    c *= i;
                }
                c1=1;
                for (int i = 1; i < (n - k) + 1; i++)
                {
                    c1 *= i;
                }
                sw3.Write("n = " + n + " k = " + k + " kolvo strok = n!/(n-k)! = " + c/c1 + " alphabet = {");  // Вывод строки информации об объектах

                for (int i = 0; i < n; i++)
                {
                    sw3.Write(obj3.alphabet[i] + " ");
                }
                sw3.WriteLine("}");

                for (int i = 0; i < n; i++) // первое слово
                {
                    obj3.obj[i] = i;
                }


                for (int i = 0; i < k; i++)
                {
                    sw3.Write(obj3.alphabet[obj3.obj[i]]);

                }
                sw3.WriteLine();
                while (obj3.NextA()) // вывод слова в цикле и генерация следующего 
                {
                    for (int i = 0; i < k; i++)
                    {
                        sw3.Write(obj3.alphabet[obj3.obj[i]]);

                    }
                    sw3.WriteLine();

                }

                sw3.Close();
            }


            ////////////////////////////////////////////////////////////////////////////////////1.5 СОЧЕТАНИЯ ИЗ N по K

            //StreamWriter sw5 = new StreamWriter(@"C:\dm2021\Lab1.1\Lab1.1\list5.txt");
            StreamWriter sw5 = new StreamWriter(@"D:\dm2021\dm2021\Lab1.1\Lab1.1\list5.txt");

            c = 1;
            for (int i = 1; i < n + 1; i++)
            {
                c *= i;
            }
            c1 = 1;
            for (int i = 1; i < (n - k) + 1; i++)       // Тут факториалы для формул расчета количества объектов
            {
                c1 *= i;
            }
            int c2 = 1;
            for (int i = 1; i < k + 1; i++)
            {
                c2 *= i;
            }

            sw5.Write("n = " + n + " k = " + k + " kolvo strok = n!/((n-k)!*k!) = " + c/(c1*c2) + " alphabet = {");  // Вывод строки информации об объектах

            for (int i = 0; i < n; i++)
            {
                sw5.Write(obj5.alphabet[i] + " ");
            }
            sw5.WriteLine("}");

            for(int i = 0; i < k;i++) // первое слово
            {
                obj5.obj[i] = i;
            }

            for (int i = 0; i < k; i++)
            {
                sw5.Write(obj5.alphabet[obj5.obj[i]]);

            }
            sw5.WriteLine();

            while (obj5.NextSoch(obj5._k)) // вывод слова в цикле и генерация следующего 
            {
                for (int i = 0; i < k; i++)
                {
                    sw5.Write(obj5.alphabet[obj5.obj[i]]);

                }
                sw5.WriteLine();

            }
            
            sw5.Close();


            ////////////////////////////////////////////////////////////////////////////////////1.4 ВСЕ ПОДМНОЖЕСТВА МНОЖЕСТВА

            //StreamWriter sw4 = new StreamWriter(@"C:\dm2021\Lab1.1\Lab1.1\list4.txt");
            StreamWriter sw4 = new StreamWriter(@"D:\dm2021\dm2021\Lab1.1\Lab1.1\list4.txt");

            

            sw4.Write("n = " + n +  " kolvo strok = 2^n = " + Math.Pow(2,n) + " alphabet = {");  // Вывод строки информации об объектах

            for (int i = 0; i < n; i++)
            {
                sw4.Write(obj4.alphabet[i] + " ");
            }
            sw4.WriteLine("}");
            for (int l = 0; l < n+1; l++)
            {
                for (int i = 0; i < l; i++) // первое слово
                {
                    obj4.obj[i] = i;
                }

                for (int i = 0; i <l; i++)
                {
                    sw4.Write(obj4.alphabet[obj4.obj[i]]);

                }
                sw4.WriteLine();

                while (obj4.NextSoch(l)) // вывод слова в цикле и генерация следующего 
                {
                    for (int i = 0; i < l; i++)
                    {
                        sw4.Write(obj4.alphabet[obj4.obj[i]]);

                    }
                    sw4.WriteLine();

                }
            }
            sw4.Close();


            ////////////////////////////////////////////////////////////////////////////////////1.6 СОЧЕТАНИЯ С ПОВТОРЕНИЯМИ ИЗ N по K

            //StreamWriter sw5 = new StreamWriter(@"C:\dm2021\Lab1.1\Lab1.1\list5.txt");
            StreamWriter sw6 = new StreamWriter(@"D:\dm2021\dm2021\Lab1.1\Lab1.1\list6.txt");

            c = 1;
            for (int i = 1; i < n; i++)
            {
                c *= i;
            }
            c1 = 1;
            for (int i = 1; i < (n + k) ; i++)       // Тут факториалы для формул расчета количества объектов
            {
                c1 *= i;
            }
            c2 = 1;
            for (int i = 1; i < k + 1; i++)
            {
                c2 *= i;
            }

            sw6.Write("n = " + n + " k = " + k + " kolvo strok = (n+k-1)!/((n-1)! * k!) = " + c1 / (c * c2) + " alphabet = {");  // Вывод строки информации об объектах

            for (int i = 0; i < n; i++)
            {
                sw6.Write(obj6.alphabet[i] + " ");
            }
            sw6.WriteLine("}");

            for (int i = 0; i < k; i++) // первое слово
            {
                obj6.obj[i] = 0; 
            }

            for (int i = 0; i < k; i++) // вывод 1 слова
            {
                sw6.Write(obj6.alphabet[obj6.obj[i]]);

            }
            sw6.WriteLine();

            while (obj6.NextSochSPovt()) 
            {
                for (int i = 0; i < k; i++)
                {
                    sw6.Write(obj6.alphabet[obj6.obj[i]]);  // вывод слова в цикле и генерация следующего 

                }
                sw6.WriteLine();

            }

            sw6.Close();

            Console.WriteLine("1");
        }
    }
}
//┈┈┈┈★┈┈┈┈
//┈┈┈★▇★┈┈┈
//┈┈★▇▇▇★┈┈
//┈★▇▇▇▇▇★┈
//★▇▇▇▇▇▇▇★
//┈┈┈┈▇┈┈┈┈