
class Counter
{
    public static int count = 0;
}
internal class Program
{
    private static void Main(string[] args)
    {
        
        Thread[] threads = new Thread[5];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(() =>
            {
                for (int i = 0; i < 1_000_000; i++)
                {
                    Interlocked.Increment(ref Counter.count);
                }
            });
            threads[i].Start();
        }

        for (int i = 0; i < threads.Length; i++)
        {
            threads[i].Join(); // wait
        }

        Console.WriteLine($"counter = {Counter.count}"); // 5_000_000
    }
}