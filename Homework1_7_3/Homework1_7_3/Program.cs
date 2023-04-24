using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Homework1_7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();
            hospital.Work();
        }
    }

    class Hospital
    {
        private List<Patient> _patients;
        private IEnumerable<Patient> _filtredPatients;
        private bool _isSearched;

        public Hospital ()
        {
            _patients = new List<Patient>()
            {
                new Patient("Борисов Андрей Андреевич",45,"ОРВИ"),
                new Patient("Васюков Игорь Степанович",29,"Грипп"),
                new Patient("Гулагин Федор Игоревич",58,"Пневмония"),
                new Patient("Дидаш Юлия Андреевна",27,"Дистрофия"),
                new Patient("Егоров Егор Егорович",34,"ОРВИ"),
                new Patient("Иванов Петр Павлович",61,"СДВГ"),
                new Patient("Федорова Вероника Андреевна",25,"Дистрофия"),
                new Patient("Смирнов Андрей Андреевич",24,"Грипп"),
                new Patient("Смирнов Петр Иванович",78,"Пневмония"),
                new Patient("Федорова Дарья Борисовна",27,"Дистрофия"),
                new Patient("Сохина Ксения Павловна",25,"СДВГ")
            };

            _isSearched = true;
        }

        public void Work()
        {
            const string ResetFiltersCommand = "0";
            const string SortByFullNameCommand = "1";
            const string SortByAgeCommand = "2";
            const string FilterByIllnessCommand = "3";
            const string ExitCommand = "4";

            bool isWork = true;
            ResetFilters();

            while (isWork)
            {
                Console.Clear();
                Console.WriteLine("БОЛЬНИЦА:\n");
                Console.WriteLine($"{ResetFiltersCommand}. Сбросить все фильтры");
                Console.WriteLine($"{SortByFullNameCommand}. Отсортировать всех больных по ФИО");
                Console.WriteLine($"{SortByAgeCommand}. Отсортировать всех больных по возрасту");
                Console.WriteLine($"{FilterByIllnessCommand}. Вывести больных с определенным заболеванием");
                Console.WriteLine($"{ExitCommand}. Закончить работу");
                Console.Write("\nВведите номер команды: ");

                string userInput = Console.ReadLine();
                
                switch (userInput)
                {
                    case ResetFiltersCommand:
                        ResetFilters();
                        break;

                    case SortByFullNameCommand:
                        SortByFullName();
                        break;

                    case SortByAgeCommand:
                        SortByAge();
                        break;

                    case FilterByIllnessCommand:
                        FilterByIllness();
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Введена неверная команда");
                        break;
                }

                if (isWork)
                {
                    ShowListPrisoners();
                }

                Console.ReadKey();
            }
        }

        private void SortByFullName()
        {
            _filtredPatients = _filtredPatients.OrderBy(patient => patient.FullName);
            _isSearched = true;
        }

        private void SortByAge()
        {
            _filtredPatients = _filtredPatients.OrderBy(patient => patient.Age);
            _isSearched = true;
        }

        private void FilterByIllness()
        {
            Console.Write("Введите название заболевания: ");
            string userInput = Console.ReadLine();

            _filtredPatients = _filtredPatients.Where(patient => patient.Illness == userInput);
            _isSearched = true;
        }

        private void ShowListPrisoners()
        {
            Console.WriteLine();

            if (_filtredPatients.Count() > 0)
            {
                foreach (var Patient in _filtredPatients)
                {
                    Console.WriteLine(Patient.FullName);
                }
            }
            else
            {
                Console.WriteLine("Пусто");
            }
        }

        private void ResetFilters()
        {
            if (_isSearched)
            {
                _filtredPatients = _patients.Select(criminal => criminal);
                _isSearched = false;
            }
            else
            {
                Console.WriteLine("Фильтров нет");
            }
        }
    }

    class Patient
    {
        public Patient (string fullName, int age, string illness)
        {
            FullName = fullName;
            Age = age;
            Illness = illness;
        }

        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Illness { get; private set; }
    }
}