using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddDossier = "1";
            const string AllDossiers = "2";
            const string DeleteDossier = "3";
            const string LastNameSearch = "4";
            const string Exit = "5";

            string[] positions = new string[0];
            string[] fullNames = new string[0];
            bool isFinish = true;
            string input;

            while (isFinish == true)
            {
                Console.WriteLine("введите команду\n" + AddDossier + " добавить досье\n" + AllDossiers + " показать все досье\n" + DeleteDossier + " удалить досье\n" + LastNameSearch + " поиск по фамилии\n" + Exit + " выход");
                input = Console.ReadLine();

                switch (input)
                {
                    case Exit:
                        isFinish = false;
                        break;
                    case AddDossier:
                        AddDossierFunsion(ref fullNames, ref positions);
                        break;

                    case AllDossiers:
                        AllDossiersFunsion(fullNames, positions);
                        break;
                    case DeleteDossier:
                        DeleteDossierFunction(ref fullNames, ref positions);
                        break;
                    case LastNameSearch:
                        SearchDossier(fullNames, positions);
                        break;
                }
            }
            Console.ReadKey();
        }

        static void AddDossierFunsion(ref string[] names, ref string[] positions)
        {
            string name;
            string position;

            Console.WriteLine("введите ФИО сотрудника");
            name = Console.ReadLine();
            Console.WriteLine("введите должность");
            position = Console.ReadLine();

            names = IncreasArray(names, name);
            positions = IncreasArray(positions, position);
        }

        static string[] IncreasArray(string[] array, string text)
        {
            string[] temporaryArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                temporaryArray[i] = array[i];
            }

            temporaryArray[temporaryArray.Length - 1] = text;
            array = temporaryArray;
            return array;
        }

        static void AllDossiersFunsion(string[] fullNames, string[] positions)
        {
            int i = 1;
            if(fullNames.Length == 0 &&  positions.Length == 0)
            {
                Console.WriteLine("вы не ввели не одного досье");
            }
            for ( i = 0; i < positions.Length; i++)
            {
                Console.WriteLine(i + ". ФИО : " + fullNames[i] + " должность : " + positions[i]);
                
            }

            
        }

        private static void DeleteDossierFunction(ref string[] fullNames, ref string[] positions)
        {
            Console.Write("Введите номер досье :");
            int number = int.Parse(Console.ReadLine());

            if (number > 0 && number <= fullNames.Length)
            {
                int index = number - 1;
                fullNames = decreaseArray(fullNames, index);
                positions = decreaseArray(positions, index);
                Console.WriteLine($"Досье с индексом " + number + " удалено");
            }
            else
            {
                Console.WriteLine("Досье с  не существует");
            }
        }
        private static string[] decreaseArray(string[] array, int count)
        {
            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < count; i++) 
            {
                tempArray[i] = array[i];
            }

            for (int i = count; i < array.Length - 1; i++)
            {
                tempArray[i] = array[i + 1];
            }

            array = tempArray;
            return array;
        }

        static void SearchDossier(string[] fullNames, string[] positions)
        {
            Console.WriteLine("Введите фамилию для поиска досье");
            string surname = Console.ReadLine();
            bool isSuccessfulSearch = false;

            for (int i = 0; i < fullNames.Length; i++)
            {
                string[] split = fullNames[i].Split(' ');

                if (split[0].ToLower() == surname.ToLower())
                {
                    Console.WriteLine($"Номер [ {i + 1}  | ФИО : " + fullNames[i] + " | должность : " +positions[i]);
                    isSuccessfulSearch = true;
                }
            }

            if (isSuccessfulSearch == false)
            {
                Console.WriteLine($"Досье сотрудников с фамилией " + surname +" не найдено!!!");
            }

        }
    }
}
