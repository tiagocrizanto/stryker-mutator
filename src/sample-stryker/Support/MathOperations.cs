namespace sample_stryker
{
    public class MathOperations
    {
        public int Sum(int n1, int n2) => n1 + n2;
        public double Division(int n1, int n2)
        {
            if (n2 == 0)
                return 0;

            return n1 / n2;
        }
    }
}
