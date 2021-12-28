using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab1_1
{
    // ДО МЕТОДА MAIN ПРОГРАММА ПОВТОРЯЕТ ЛАБ1 и ЛАБ2 КОММЕНТИТЬ НЕ БУДУ, хочу спать...
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
        public void SetAlphabet(char a, int i) 
        {

            alphabet[i] = a;

        }
        void Swap(int i, int j)
        {
            int b = obj[i];
            obj[i] = obj[j];
            obj[j] = b;
        }
        public void NextASPovt() 
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
        public bool LastASPoct() 
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
            ////////////////////////////////////////////3.1 ПОЧТИ ПОВТОРЯЕТ 2.2 НУЖЕН ЕЩЕ ОДИН ЦИКЛ ЧТОБЫ БРАТЬ НЕ ТОЛЬКО а т.е. количество = 600 * 6 = 3600
            Program obj3 = new Program(6, 3, 0);  
            obj3.alphabet[0] = 'a';
            obj3.alphabet[1] = 'b';
            obj3.alphabet[2] = 'c';
            obj3.alphabet[3] = 'd';
            obj3.alphabet[4] = 'e';
            obj3.alphabet[5] = 'f';
            for (int i = 0; i < 5; i++)
            {
                obj3.obj[i] = i;
            }
            obj3._n = 5;

            Program obj4 = new Program(5, 2);
            obj4.alphabet[0] = '1';
            obj4.alphabet[1] = '2';
            obj4.alphabet[2] = '3';
            obj4.alphabet[3] = '4';
            obj4.alphabet[4] = '5';

            StreamWriter sw2 = new StreamWriter(@"C:\dm2021\laba3\laba3\lab3.1.txt");
            for (int i = 0; i < 2; i++)
            {
                obj4.obj[i] = i;
            }
            for (int p = 0; p < 6; p++) // Вот тут отличается от 2.2
            {
                Array.Resize(ref obj3.alphabet, 6); 
                obj3.alphabet[0] = 'a';
                obj3.alphabet[1] = 'b';
                obj3.alphabet[2] = 'c';
                obj3.alphabet[3] = 'd';
                obj3.alphabet[4] = 'e';
                obj3.alphabet[5] = 'f';
                char a = obj3.alphabet[p];
                obj3.alphabet[p] = '0';
                Array.Sort(obj3.alphabet); // Нечто страшное, тут мы вычленяем из алфавита, букву которая будет 2 раза повторяться, наверное можно сделать и эффективнее
                Array.Reverse(obj3.alphabet); 
                Array.Resize(ref obj3.alphabet, 5);
                Array.Reverse(obj3.alphabet);

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
                                sw2.Write(a);
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
            }

            sw2.WriteLine();
            sw2.Close();


            //////////////////////////////////////////3.2 4 ВЛОЖЕННЫХ ЦИКЛА  CHOOSE ОТВЕЧАЕТ ЗА ВЫБОР 2 БУКВ КОТОРЫЕ ПОВТОРЯЮТСЯ 2 РАЗА C(2/6), c26 - выбираем 2 места из 6 для 1 буквы С(2/6)
            ///////////////////////////////////////// C(2/4) - c24 Выбираем 2 места для второй буквы. obj31 - тут генерим размещения из 4 по 2 A(2/4)
            ///////////////////////////////////////// ИТОГОВАЯ ФОРМУЛА: C(2/6) * C(2/6) * C(2/4) * A(2/4) = 16200
            Program obj31 = new Program(6, 2,0);
            Program c26 = new Program(6, 2);
            Program c24 = new Program(6, 2);
            Program choose = new Program(6, 2);

            choose.alphabet[0] = 'a';
            choose.alphabet[1] = 'b';
            choose.alphabet[2] = 'c';
            choose.alphabet[3] = 'd';
            choose.alphabet[4] = 'e';
            choose.alphabet[5] = 'f';


            c26.alphabet[0] = '1';
            c26.alphabet[1] = '2';
            c26.alphabet[2] = '3';
            c26.alphabet[3] = '4';
            c26.alphabet[4] = '5';
            c26.alphabet[5] = '6';

            StreamWriter sw = new StreamWriter(@"C:\dm2021\laba3\laba3\lab3.2.txt");

            for(int i = 0; i <2;i++)
            {
                choose.obj[i] = i;
            }
            do
            {
                char a = choose.alphabet[choose.obj[0]];
                char b = choose.alphabet[choose.obj[1]];

                c26.alphabet[0] = '1';
                c26.alphabet[1] = '2';
                c26.alphabet[2] = '3';
                c26.alphabet[3] = '4';
                c26.alphabet[4] = '5';
                c26.alphabet[5] = '6';

                for (int j = 0; j<2; j++)
                {
                    c26.obj[j] = j;
                }

                Array.Resize(ref obj31.alphabet, 6);
                obj31.alphabet[0] = 'a';
                obj31.alphabet[1] = 'b';
                obj31.alphabet[2] = 'c';
                obj31.alphabet[3] = 'd';
                obj31.alphabet[4] = 'e';
                obj31.alphabet[5] = 'f';

                for (int j = 0; j<6;j++)
                {
                    if(obj31.alphabet[j]==a || obj31.alphabet[j] ==b)
                    {
                        obj31.alphabet[j] = '0';
                    }
                }

                obj31._n = 4;
                Array.Sort(obj31.alphabet); // Нечто страшное
                Array.Reverse(obj31.alphabet);
                Array.Resize(ref obj31.alphabet, 4);
                Array.Reverse(obj31.alphabet);


                do
                {
                    Array.Resize(ref c24.alphabet, 6);
                    c24.alphabet[0] = '1';
                    c24.alphabet[1] = '2';
                    c24.alphabet[2] = '3';
                    c24.alphabet[3] = '4';
                    c24.alphabet[4] = '5';
                    c24.alphabet[5] = '6';


                    for (int l = 0; l<6;l++ )
                    {
                        if(c24.alphabet[l] == c26.alphabet[c26.obj[0]] || c24.alphabet[l] == c26.alphabet[c26.obj[1]])
                        {
                            c24.alphabet[l] = '0';
                        }

                    }
                    c24._n = 4;
                    Array.Sort(c24.alphabet); // Нечто страшное
                    Array.Reverse(c24.alphabet);
                    Array.Resize(ref c24.alphabet, 4);
                    Array.Reverse(c24.alphabet);
                    for (int l = 0; l < 2; l++)
                    {
                        c24.obj[l] = l;
                    }

                    do
                    {
                      

                        for(int l = 0; l<4;l++)
                        {
                            obj31.obj[l] = l;
                        }

                        do
                        {
                            for (int i = 1, k = 0; i < 7; i++)
                            {
                                if (c26.alphabet[c26.obj[0]] == (char)i + 48 || c26.alphabet[c26.obj[1]] == (char)i + 48)
                                {
                                    sw.Write(a);
                                }
                                else if (c24.alphabet[c24.obj[0]] == (char)i + 48 || c24.alphabet[c24.obj[1]] == (char)i + 48)
                                {
                                    sw.Write(b);
                                }
                                else
                                {
                                    sw.Write(obj31.alphabet[obj31.obj[k]]);
                                    k++;
                                }
                                
                            }
                            sw.WriteLine();
                        } while (obj31.NextA());
                    } while (c24.NextSoch(2));
                }while(c26.NextSoch(2));
            }while(choose.NextSoch(2));

            sw.Close();

        }
    }
}
//┈┈┈┈★┈┈┈┈
//┈┈┈★▇★┈┈┈
//┈┈★▇▇▇★┈┈
//┈★▇▇▇▇▇★┈
//★▇▇▇▇▇▇▇★
//┈┈┈┈▇┈┈┈┈
