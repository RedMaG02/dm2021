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
        public Program(int n,int k,int j)
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
        public bool NextPer()
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
                if (obj[i] < _n - k + i )
                {
                    obj[i]++;
                    for (int j = i + 1; j < k; j++)
                        obj[j] = obj[j - 1]+1 ;
                    return true;
                }
            return false;
        }
        bool NextSochSPovt()
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
            /*StreamWriter sw = new StreamWriter(@"C:\dm2021\Lab1.1\Lab1.1\list1.txt");*/                                          //1
            StreamWriter sw = new StreamWriter(@"D:\dm2021\dm2021\Lab1.1\Lab1.1\list1.txt");
            sw.Write("n = " +n+ " k = "+k+ " kolvo strok = n^k = " +Math.Pow(obj._n,obj._k) + " alphabet = {");

            for (int i =0;i<n;i++)
            {
                sw.Write(obj.alphabet[i]+" ");
            }
            sw.WriteLine("}");

            while (!obj.LastASPoct()) //Вывод перестановок с повт
            {
                for (int i = 0; i < k; i++) 
                {
                    sw.Write(obj.alphabet[obj.obj[i]]);

                }
                sw.WriteLine();

                obj.NextASPovt();
            }
            for (int i = 0; i < k; i++)
            {
                sw.Write(obj.alphabet[obj.obj[i]]);

            }
            sw.Close();

            /* StreamWriter sw2 = new StreamWriter(@"C:\dm2021\Lab1.1\Lab1.1\list2.txt");*/                       //2
            StreamWriter sw2 = new StreamWriter(@"D:\dm2021\dm2021\Lab1.1\Lab1.1\list2.txt");
            for (int i = 0; i < obj2._k; i++)
            {
                obj2.obj[i] = i;
            }
            int c = 1;
            for(int i = 1;i < n+1;i++)
            {
                c *= i;
            }
            sw2.Write("n = " + n + " kolvo strok = n! = " + c + " alphabet = {");

            for (int i = 0; i < n; i++)
            {
                sw2.Write(obj2.alphabet[i] + " ");
            }
            sw2.WriteLine("}");

            for (int i =0;i<n;i++)
            {
                obj2.obj[i] = i;
            }

            for (int i = 0; i < n; i++)
            {
                sw2.Write(obj2.alphabet[obj2.obj[i]]);

            }
            sw2.WriteLine();

            while (obj2.NextPer()) //Вывод перестановок с повт
            {
                for (int i = 0; i < n; i++)
                {
                    sw2.Write(obj2.alphabet[obj2.obj[i]]);

                }
                sw2.WriteLine();

            }
            
            sw2.Close();

            int c1;
            if (obj3._k <= obj3._n)
            {
                //for (int i = 0; i < obj3._k; i++)
                //{
                //    obj3.obj[i] = i;
                //}
                /* StreamWriter sw3 = new StreamWriter(@"C:\dm2021\Lab1.1\Lab1.1\list3.txt");*/                           //3
                StreamWriter sw3 = new StreamWriter(@"D:\dm2021\dm2021\Lab1.1\Lab1.1\list3.txt");
                c = 1;
                for (int i = 1; i < n + 1; i++)
                {
                    c *= i;
                }
                c1=1;
                for (int i = 1; i < (n - k) + 1; i++)
                {
                    c1 *= i;
                }
                sw3.Write("n = " + n + " k = " + k + " kolvo strok = n!/(n-k)! = " + c/c1 + " alphabet = {");

                for (int i = 0; i < n; i++)
                {
                    sw3.Write(obj3.alphabet[i] + " ");
                }
                sw3.WriteLine("}");

                for (int i = 0; i < n; i++)
                {
                    obj3.obj[i] = i;
                }


                for (int i = 0; i < k; i++)
                {
                    sw3.Write(obj3.alphabet[obj3.obj[i]]);

                }
                sw3.WriteLine();
                while (obj3.NextA()) //Вывод перестановок с повт
                {
                    for (int i = 0; i < k; i++)
                    {
                        sw3.Write(obj3.alphabet[obj3.obj[i]]);

                    }
                    sw3.WriteLine();

                }

                sw3.Close();
            }


            //StreamWriter sw5 = new StreamWriter(@"C:\dm2021\Lab1.1\Lab1.1\list5.txt");
            StreamWriter sw5 = new StreamWriter(@"D:\dm2021\dm2021\Lab1.1\Lab1.1\list5.txt");

            c = 1;
            for (int i = 1; i < n + 1; i++)
            {
                c *= i;
            }
            c1 = 1;
            for (int i = 1; i < (n - k) + 1; i++)
            {
                c1 *= i;
            }
            int c2 = 1;
            for (int i = 1; i < k + 1; i++)
            {
                c2 *= i;
            }

            sw5.Write("n = " + n + " k = " + k + " kolvo strok = n!/((n-k)!*k!) = " + c/(c1*c2) + " alphabet = {");

            for (int i = 0; i < n; i++)
            {
                sw5.Write(obj5.alphabet[i] + " ");
            }
            sw5.WriteLine("}");

            for(int i = 0; i < k;i++)
            {
                obj5.obj[i] = i;
            }

            for (int i = 0; i < k; i++)
            {
                sw5.Write(obj5.alphabet[obj5.obj[i]]);

            }
            sw5.WriteLine();

            while (obj5.NextSoch(obj5._k)) //Вывод перестановок с повт
            {
                for (int i = 0; i < k; i++)
                {
                    sw5.Write(obj5.alphabet[obj5.obj[i]]);

                }
                sw5.WriteLine();

            }
            
            sw5.Close();


            //StreamWriter sw4 = new StreamWriter(@"C:\dm2021\Lab1.1\Lab1.1\list4.txt");
            StreamWriter sw4 = new StreamWriter(@"D:\dm2021\dm2021\Lab1.1\Lab1.1\list4.txt");

            

            sw4.Write("n = " + n +  " kolvo strok = 2^n = " + Math.Pow(2,n) + " alphabet = {");

            for (int i = 0; i < n; i++)
            {
                sw4.Write(obj4.alphabet[i] + " ");
            }
            sw4.WriteLine("}");
            for (int l = 0; l < n+1; l++)
            {
                for (int i = 0; i < l; i++)
                {
                    obj4.obj[i] = i;
                }

                for (int i = 0; i <l; i++)
                {
                    sw4.Write(obj4.alphabet[obj4.obj[i]]);

                }
                sw4.WriteLine();

                while (obj4.NextSoch(l)) //Вывод перестановок с повт
                {
                    for (int i = 0; i < l; i++)
                    {
                        sw4.Write(obj4.alphabet[obj4.obj[i]]);

                    }
                    sw4.WriteLine();

                }
            }
            sw4.Close();


            //StreamWriter sw5 = new StreamWriter(@"C:\dm2021\Lab1.1\Lab1.1\list5.txt");
            StreamWriter sw6 = new StreamWriter(@"D:\dm2021\dm2021\Lab1.1\Lab1.1\list6.txt");

            c = 1;
            for (int i = 1; i < n; i++)
            {
                c *= i;
            }
            c1 = 1;
            for (int i = 1; i < (n + k) ; i++)
            {
                c1 *= i;
            }
            c2 = 1;
            for (int i = 1; i < k + 1; i++)
            {
                c2 *= i;
            }

            sw6.Write("n = " + n + " k = " + k + " kolvo strok = (n+k-1)!/((n-1)! * k!) = " + c1 / (c * c2) + " alphabet = {");

            for (int i = 0; i < n; i++)
            {
                sw6.Write(obj6.alphabet[i] + " ");
            }
            sw6.WriteLine("}");

            for (int i = 0; i < k; i++)
            {
                obj6.obj[i] = 0;
            }

            for (int i = 0; i < k; i++)
            {
                sw6.Write(obj6.alphabet[obj6.obj[i]]);

            }
            sw6.WriteLine();

            while (obj6.NextSochSPovt()) //Вывод перестановок с повт
            {
                for (int i = 0; i < k; i++)
                {
                    sw6.Write(obj6.alphabet[obj6.obj[i]]);

                }
                sw6.WriteLine();

            }

            sw6.Close();

            Console.WriteLine("1");
        }
    }
}
