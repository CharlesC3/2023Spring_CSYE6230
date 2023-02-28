using System.Diagnostics;

internal class Program
{
    static double[] arr = new double[50000000];
    static double[] portionSum = new double[4];
    static int portionSize = arr.Length / 4;
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        generateValue();
        multiply();

        Stopwatch watch = new Stopwatch();
        watch.Start();
        double sum = 0;
        for(int i = 0; i < arr.Length; i++){
            sum += arr[i];
        }
        watch.Stop();
        Console.WriteLine("The sum is " + sum);
        Console.WriteLine("Serial time elapsed = " + watch.Elapsed);

        watch.Reset();

        watch.Start();
        Thread[] threads = new Thread[4];
        for(int i = 0; i < threads.Length; i++){
            threads[i] = new Thread(calculateSum);
            threads[i].Start(i);
        }
        for(int i = 0; i < threads.Length; i++){
            threads[i].Join();
        }
        double sumParallel = 0;
        for(int i = 0; i < portionSum.Length; i++){
            sumParallel += portionSum[i];
        }
        watch.Stop();
        Console.WriteLine("Total sum is " + sumParallel);
        Console.WriteLine("Parallel time elapsed = " + watch.Elapsed);
    }

    static void generateValue(){
        Random rand = new Random();
        for(int i = 0; i < arr.Length; i++){
            arr[i] = rand.Next(10);
        }
    }

    static void multiply(){
        Random rand = new Random();
        for(int i = 0; i < arr.Length; i++){
            arr[i] *= rand.NextDouble() * (0.9 - 0.1) + 0.1;
        }
    }

    static void calculateSum(object obj){
        int portion = (int) obj;
        double sum = 0;
        for(int i = portion * portionSize; i < portion * portionSize + portionSize; i++){
            sum += arr[i];
        }
        portionSum[portion] = sum;
    }
}