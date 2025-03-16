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
        static void Main(string[] args) //Список с нуля
        {
            const string AddDossierComand = "1";
            const string WriteAllDossiersCommand = "2";
            const string DeleteDossierComand = "3";
            const string ExitprojectCommand = "4";

            List<string>  positions = new List<string>();
            List<string> FullNames = new List<string>();
            bool isFinished = true;
            string input;

            while (isFinished == true)
            {
                Console.WriteLine("введите команду\n" + AddDossierComand + " добавить досье\n" + WriteAllDossiersCommand + " показать все досье\n" + DeleteDossierComand + " удалить досье\n"  + ExitprojectCommand + " выход");
                input = Console.ReadLine();

                switch (input)
                {

                    case ExitprojectCommand:
                        isFinished = false;
                        break;
                    case AddDossierComand:
                        AddDossier( FullNames, positions);
                        break;
                    case WriteAllDossiersCommand:
                        AllDossiers(ref FullNames, ref positions);
                        break;
                    case DeleteDossierComand:
                        DeleteDossier(ref FullNames, ref positions);
                        break;
                }

                Console.Clear();
            }

            Console.ReadKey();
        }

        static void AddDossier(List<string> fullNames, List<string> positions)
        {
            string name;
            string position;

            Console.WriteLine("введите ФИО сотрудника");
            name = Console.ReadLine();
            Console.WriteLine("введите должность");
            position = Console.ReadLine();

            fullNames.Add(name);
            positions.Add(position);
        }


        static void AllDossiers(ref List<string> fullNames, ref List<string> positions)//глагол или глагол + сущ
        {
            for (int i = 0; i < fullNames.Count; i++)
            {
                int j = 1;
                Console.WriteLine("фио сотрудника его номер "+ j +" :" + fullNames[i]);
                Console.WriteLine(" должность сотрудника его номер "+ j +":" + positions[i]);
                j++;
            }

            Console.ReadKey();
        }

        private static void DeleteDossier(ref List<string> fullNames, ref List<string> positions)
        {
            int nummber;
            Console.WriteLine("напишите номер сотрудника и я удалю:");
            nummber = Convert.ToInt32(Console.ReadLine());
            nummber--;
            fullNames.RemoveAt(nummber);
            positions.RemoveAt(nummber);

            Console.ReadKey();
        }
    }
}
