using System;

namespace BrentsAlgorithm
{
    public sealed class CycleDetectionResult
    {
        public int Mu { get; set; }
        public int Lambda { get; set; }

        public CycleDetectionResult(int mu, int lambda)
        {
            this.Mu = mu;
            this.Lambda = lambda;
        }
    }

    public static class BrentCycleDetection
    {
        public static CycleDetectionResult FindCycle<T>(T x0, Func<T, T> f)
        {
            if (f == null)
            {
                return new CycleDetectionResult(0, 0);
            }

            int power = 1;
            int lambda = 1;
            T tortoise = x0;
            T hare = f(x0);
            while (!object.Equals(tortoise, hare))
            {
                if (power == lambda)
                {
                    tortoise = hare;
                    power *= 2;
                    lambda = 0;
                }

                hare = f(hare);
                lambda++;
            }

            int mu = 0;
            tortoise = x0;
            hare = x0;
            for (int i = 0; i < lambda; i++)
            {
                hare = f(hare);
            }

            while (!object.Equals(tortoise, hare))
            {
                tortoise = f(tortoise);
                hare = f(hare);
                mu++;
            }

            return new CycleDetectionResult(mu, lambda);
        }
    }
}