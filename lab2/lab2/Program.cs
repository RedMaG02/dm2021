using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab1_1
{
    class Program
    {
        public int[] obj;
        public int _n;
        public char[] alphabet;
        public int _k;
        public Program(int n, int k)
        {
            _n = n;
            _k = k;
            obj = new int[k];
            alphabet = new char[n];

        }
        public Program(int n, int k, int j)
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
        public void NextASPovt() // генерация следующего размещения 
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
        public bool LastASPoct() // true - размещение сгенерирована
        {
            bool b = true;
            for (int i = 0; i < _k; i++)
            {
                if (obj[i] != _n - 1)
                {
                    b = false;
                    break;
                }
            }
            return b;
        }
        public bool NextPer()
        {
            int j = _n - 2;
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

            return true;
        }
        public bool NextA()
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

        bool NextSoch(int c)
        {
            int k = c;
            for (int i = k - 1; i >= 0; i--)
                if (obj[i] < _n - k + i)
                {
                    obj[i]++;
                    for (int j = i + 1; j < k; j++)
                        obj[j] = obj[j - 1] + 1;
                    return true;
                }
            return false;
        }
        bool NextSochSPovt()
        {
            int j = _k - 1;
            while (j >= 0 && obj[j] == _n - 1) j--;
            if (j < 0) return false;
            if (obj[j] >= _n - 1)
                j--;
            obj[j]++;
            if (j == _k - 1) return true;
            for (int k = j + 1; k < _k; k++)
                obj[k] = obj[j];
            return true;
        }



        static void Main(string[] args)
        {
            //////////////////////////////////////////////////////////// C(2/5)*5*5*5
            Program obj1 = new Program(5, 3); // тут перестановки
            obj1.alphabet[0] = 'b';
            obj1.alphabet[1] = 'c';
            obj1.alphabet[2] = 'd';
            obj1.alphabet[3] = 'e';
            obj1.alphabet[4] = 'f';
            for(int i = 0; i < 3; i++)
            {
                obj1.obj[i] = 0;
            }

            Program obj2 = new Program(5, 2);// тут позиция для а
            obj2.alphabet[0] = '1';
            obj2.alphabet[1] = '2';
            obj2.alphabet[2] = '3';
            obj2.alphabet[3] = '4';
            obj2.alphabet[4] = '5';

            StreamWriter sw = new StreamWriter(@"C:\dm2021\lab2\lab2\zad2.1.txt");
            for (int i = 0; i < 2; i++)
            {
                obj2.obj[i] = i;
            }
            do
            {
                do
                {
                    for(int i = 1,k=0; i < 6;i++)
                    {
                        if (obj2.alphabet[obj2.obj[0]] == (char)i+48 || obj2.alphabet[obj2.obj[1]] == (char)i + 48) 
                        {
                                sw.Write('a');
                        }
                        else
                        {
                            sw.Write(obj1.alphabet[obj1.obj[k]]);
                            k++;
                        }
                    }
                    sw.WriteLine();
                    obj1.NextASPovt();
                } while (!obj1.LastASPoct());
            } while (obj2.NextSoch(2));

            for (int i = 1, k = 0; i < 6; i++) // можно заменить на sw.Write("fffaa") ну или нельзя
            {                                   //
                if (obj2.alphabet[obj2.obj[0]] == (char)i + 48 || obj2.alphabet[obj2.obj[1]] == (char)i + 48)//
                {//
                    sw.Write('a');//
                }//
                else//
                {//
                    sw.Write(obj1.alphabet[obj1.obj[k]]);//
                    k++;//
                }//
            }//
            sw.WriteLine();
            sw.Close();
            ////////////////////////////////////////////
            ////////////////////////////////////////////
            //////////////////////////////////////////// 2.2 C(2/5)*A(3/5) = 600

            Program obj3 = new Program(5, 3,0); // тут перестановки
            obj3.alphabet[0] = 'b';
            obj3.alphabet[1] = 'c';
            obj3.alphabet[2] = 'd';
            obj3.alphabet[3] = 'e';
            obj3.alphabet[4] = 'f';
            for (int i = 0; i < 5; i++)
            {
                obj3.obj[i] = i;
            }

            Program obj4 = new Program(5, 2);// тут позиция для а
            obj4.alphabet[0] = '1';
            obj4.alphabet[1] = '2';
            obj4.alphabet[2] = '3';
            obj4.alphabet[3] = '4';
            obj4.alphabet[4] = '5';

            StreamWriter sw2 = new StreamWriter(@"C:\dm2021\lab2\lab2\zad2.2.txt");
            for (int i = 0; i < 2; i++)
            {
                obj4.obj[i] = i;
            }
            do
            {
                for (int i = 0; i < 5; i++)
                {
                    obj3.obj[i] = i;
                }
                do
                {
                    for (int i = 1, k = 0; i < 6; i++)
                    {
                        if (obj4.alphabet[obj4.obj[0]] == (char)i + 48 || obj4.alphabet[obj4.obj[1]] == (char)i + 48)
                        {
                            sw2.Write('a');
                        }
                        else
                        {
                            sw2.Write(obj3.alphabet[obj3.obj[k]]);
                            k++;
                        }
                    }
                    sw2.WriteLine();
                } while (obj3.NextA());
            } while (obj4.NextSoch(2));

    
            sw2.WriteLine();
            sw2.Close();
        }
    }
}
