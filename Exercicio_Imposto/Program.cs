using System;
using System.Globalization;
using System.Collections.Generic;
using Exercicio_Imposto.Entities;

namespace Exercicio_Imposto
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            var n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Tax Payer #{i} data:");

                Console.Write("Individual or company(i/c): ");
                var taxPayer = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                var name = Console.ReadLine();

                Console.Write("Anual Income: ");
                var anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(taxPayer == 'i' || taxPayer == 'I')
                {
                    Console.Write("Health expenditures: ");
                    var healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else if(taxPayer == 'c' || taxPayer == 'C')
                {
                    Console.Write("Number of Employees: ");
                    var numberOfEmployees = int.Parse(Console.ReadLine());
                    
                    list.Add(new Company(name, anualIncome, numberOfEmployees));
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }
            }
            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");
            foreach(TaxPayer tax in list)
            {
                Console.WriteLine(
                        tax.Name
                        + ": $ "
                        + tax.Tax().ToString("F2", CultureInfo.InvariantCulture)
                    );
            }

            Console.WriteLine();
            var sum = 0.0;

            foreach (TaxPayer tax in list)
            {
                sum += tax.Tax();
            }

            Console.WriteLine("TOTAL TAXES: $" + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}