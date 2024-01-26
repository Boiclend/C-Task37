using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


// Написать класс «массив». Реализовать в классе такие методы:

// конструктор по умолчанию, конструктор с параметрами, конструктор копии;
// деструктор;
// поиск элемента в массиве по ключу;
// сортировка элементов по возрастанию;
// ввод с клавиатуры и вывод на экран (в виде методов класса и при помощи перегруженных операций потокового ввода и вывода);
// перегрузить следующие операции:
// +  (поэлементное сложение);
// += (добавление элемента в конец массива);
// –  (удаление элемента по ключу);
// =  (присвоение);
// == (сравнение по элементам);
// [] (взятие элемента с заданным индексом).



namespace ConsoleApp6
{
    class Massive
    {
        private static int size;
        private int[] arr;


        public Massive()
        {
        }

        public Massive(int size)
        {
            Array.Resize(ref arr, size);
        }

        public void findElement(int key)
        {
            int index = -1;
            index = Array.IndexOf(arr, key);
            if (index >= 0)
            {
                Console.WriteLine($"Элемент который вы искали находится под индексом - {index}");
            }
        }

        public void sortMassive()
        {
        
            Array.Sort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }

        public void printMassive()
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        public int[] fillMassive()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Введите {i + 1} элемент массива: ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            return arr;
        }

        public int addition(int num1, int num2)
        {
            Console.Write("Сумма элементов = ");
            return arr[num1] + arr[num2];
        }

        public int[] addLastElem(int num)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = num;
            return arr;
            
        }
        public int[] deleteElem(int index)
        {
            int[] temp = arr;
            Array.Resize(ref arr, arr.Length - 1);
            for (int i = 0; i < temp.Length; i++)
            {
                if(i < index)
                {
                   arr[i] = temp[i];
                }
                else if (i > index)
                {
                    arr[i - 1] = temp[i];
                }
                
            }
            return arr;
        }
        
        public int[] assign(int index, int num)
        {
            arr[index] = num;
            return arr;
        }

        public void compare(int firstIndex, int secondIndex)
        {
            if(arr[firstIndex] > arr[secondIndex])
            {
                Console.WriteLine($"Элемент {arr[firstIndex]} под индексом - {firstIndex} больше, чем {arr[secondIndex]} под индексом - {secondIndex} ");
            } 
            else if (arr[firstIndex] < arr[secondIndex])
            {
                Console.WriteLine($"Элемент {arr[secondIndex]} под индексом - {secondIndex} больше, чем {arr[firstIndex]} под индексом - {firstIndex} ");
            }
            else
            {
                Console.WriteLine($"Элемент {arr[firstIndex]} под индексом - {firstIndex} равен элементу {arr[secondIndex]} под индексом - {secondIndex} ");
            }
        }

        public int getElem(int index)
        {
            int elem = arr[index];
            return elem;
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива");
            int size = int.Parse(Console.ReadLine());
            Massive massive = new Massive(size);
            Console.WriteLine("Массив после создания: ");
            massive.printMassive();
            int choice = 1;
            
            while(choice != 0)
            {
                Console.WriteLine("Поиск элемента в массиве по ключу - 1");
                Console.WriteLine("Cортировка элементов по возрастанию - 2");
                Console.WriteLine("Ввод элементов массива - 3");
                Console.WriteLine("Вывод элементов массива - 4");
                Console.WriteLine("Сложить элементы массива - 5");
                Console.WriteLine("Добавить элемент в конец массива - 6");
                Console.WriteLine("Удалить элемент по индексу - 7");
                Console.WriteLine("Присвоить новое значение элементу по индексу - 8");
                Console.WriteLine("Сравнить два элемента массива - 9");
                Console.WriteLine("Взятие элемента массива с заданным индексом - 10");
                Console.WriteLine("Выход - 0");
                Console.WriteLine("Выберите действие: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        Console.Write("Введите число которое хотите найти в массиве - ");
                        int index = int.Parse(Console.ReadLine());
                        massive.findElement(index);
                         Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("Отсортированный массив:");
                        massive.sortMassive();
                        Console.WriteLine();
                        break;
                    case 3:
                        massive.fillMassive();
                        Console.WriteLine();
                        break;
                    case 4:
                        massive.printMassive();
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.Write("Введите индекс первого элемента массива - ");
                        int firstNum = int.Parse(Console.ReadLine());
                        Console.Write("Введите индекс второго элемента массива - ");
                        int secondNum = int.Parse(Console.ReadLine());
                        Console.WriteLine(massive.addition(firstNum, secondNum));
                        Console.WriteLine();
                        break;
                    case 6:
                        Console.Write("Введите элемент для добавления в конец массива - ");
                        int num = int.Parse(Console.ReadLine());
                        massive.addLastElem(num);
                        massive.printMassive();
                        Console.WriteLine();
                        break;
                    case 7:
                        Console.Write("Введите индекс элемента для удаления из массива - ");
                        int ind = int.Parse(Console.ReadLine());
                        massive.deleteElem(ind);
                        massive.printMassive();
                        Console.WriteLine();
                        break;
                    case 8:
                        Console.Write("Введите индекс элемента который хотите изменить - ");
                        int n = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите элемент");
                        int z = int.Parse(Console.ReadLine());
                        massive.assign(n, z);
                        massive.printMassive();
                        Console.WriteLine();
                        break;
                    case 9:
                        Console.Write("Введите первый индекс элемента который хотите сравнить - ");
                        int y = int.Parse(Console.ReadLine());
                        Console.Write("Введите первый индекс элемента который хотите сравнить - ");
                        int a = int.Parse(Console.ReadLine());
                        massive.compare(y, a);
                        Console.WriteLine();
                        break;
                    case 10:
                        Console.Write("Введите индекс элемента, что бы взять его из массива - ");
                        int f = int.Parse(Console.ReadLine());
                        int number = massive.getElem(f);
                        Console.WriteLine($"Число - {number}");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Некорректные данные");
                        Console.WriteLine();
                        break;
                }
            }




        }
    }
}
