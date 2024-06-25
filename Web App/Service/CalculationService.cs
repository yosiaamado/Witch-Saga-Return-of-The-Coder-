using FlexiDev.Interface;
using FlexiDev.Models;

namespace FlexiDev.Service
{
    public class CalculationService : ICalculationService
    {
        public double AverageKills(List<Person> datas)
        {
            int totalKills = 0;
            int count = 0;

            foreach (var data in datas)
            {
                if (data.Age <= 0)
                    return -1;

                int birthYear = data.YearOfDeath - data.Age;
                if (birthYear < 0)
                    return -1;

                int killInBirthYear = YearKilled(birthYear);
                totalKills += killInBirthYear;
                count++;
            }

            if (count == 0)
                return -1;

            return (double)totalKills / count;
        }
        private int YearKilled(int year)
        {
            if (year <= 0)
                return 0;

            int totalKill = 0;
            for (int i = 0; i <= year; i++)
            {
                totalKill += Fibbonaci(i);
            }

            return totalKill;
        }
        private int Fibbonaci(int n)
        {
            if (n <= 0)
                return 0;
            if (n == 1)
                return 1;

            int a = 0, b = 1;
            for (int i = 2; i <= n; i++)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return b;
        }
    }
}
