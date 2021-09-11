using lab.api.Contracts;

namespace lab.api.Data
{
    public class Calculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int GetFahrenheitFromCelsius(int celcius)
        {
            return 32 + (int)(celcius / 0.5556);
        }
    }
}
