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
        public int n;
        public char[] alphabet;
        public int k;
        public Program(int _n, int _k)
        {
            n = _n;
            k = _k;
            obj = new int[k];
            alphabet = new char[n];

        }
        public void SetAlphabet() // Устанавливаем множество для генерации перестановок - порядок ввода == порядку в генерации
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Simvol alfavita:");
                alphabet[i] = Convert.ToChar(Console.ReadLine());
            }
        }
        public void NextCombObj() // генерация следующего объекта
        {
            for (int i = k - 1; i > -1; i--)
            {
                if (obj[i] == n - 1)
                {
                    obj[i] = 0;
                    continue;
                }
                obj[i]++;
                break;
            }
        }
        public bool LastObj() // true - последняя подстановка сгенерирована
        {
            bool b = true;
            for(int i = 0;i<k;i++)
            {
                if (obj[i] != n - 1)
                {
                    b = false;
                    break;
                }
            }
            return b;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Vvedite razmernost alpfavita");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dlinu slova:");
            int k = Convert.ToInt32(Console.ReadLine());
            Program obj = new Program(n, k);
            obj.SetAlphabet();
            for (int i = 0; i < obj.k; i++)
            {
                obj.obj[i] = 0;
            }
            FileInfo file = new FileInfo(@"C:\dm2021\Lab1.1\Lab1.1\list.txt");
            StreamWriter sw = file.AppendText();

            sw.Write("n = " +n+ " k = "+k+ " kolvo strok = n^k = " +Math.Pow(obj.n,obj.k) + " alphabet = {");

            for (int i =0;i<n;i++)
            {
                sw.Write(obj.alphabet[i]+" ");
            }
            sw.WriteLine("}");

            while (!obj.LastObj())
            {
                for (int i = 0; i < k; i++) // вывод текущего объекта
                {
                    sw.Write(obj.alphabet[obj.obj[i]]);

                }
                sw.WriteLine();

                obj.NextCombObj();
            }
            for (int i = 0; i < k; i++)
            {
                sw.Write(obj.alphabet[obj.obj[i]]);

            }
            sw.Close();

            Console.WriteLine("1");
        }
    }
}
