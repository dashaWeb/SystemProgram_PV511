

static class LockCounter
{
    static int number = 0;
    static int eventNumber = 0;
    public static int Number { get => number; }
    public static int EventNumber { get => eventNumber; }


    public static void UpdateFields()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            /* Interlocked.Increment(ref number);
             if (number % 2 == 0)
                 Interlocked.Increment(ref eventNumber);*/
            lock (typeof(LockCounter))
            {
                ++number;
                if (number % 2 == 0)
                    ++eventNumber;
            }


            /*Monitor.Enter(this); // block this class
            try
            {
                ++number;
                if (number % 2 == 0)
                    ++eventNumber;
            }
            finally
            {
                Monitor.Exit(this); // unblock
            }*/
        }
    }

}
internal class Program
{
    private static void Main(string[] args)
    {
        //LockCounter c = new LockCounter();
        Thread[] threads = new Thread[5];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(LockCounter.UpdateFields);
            threads[i].Start();
        }
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i].Join();
        }
        Console.WriteLine($"Number :: {LockCounter.Number} \t Event number : {LockCounter.EventNumber}"); // number = 5M, event = 2.5M
    }
}