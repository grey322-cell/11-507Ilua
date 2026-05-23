class ParallelProcessor
{
    public static void ProcessInParallel(List<object> objects)
    {
        int totalCount = objects.Count;
        int chunkSize = totalCount / 4;
        
        Parallel.For(0, 4, i =>
        {
            int start = i * chunkSize;
            int end = (i == 3) ? totalCount : start + chunkSize;
            int processedCount = 0;
            
            for (int j = start; j < end; j++)
            {
                Type type = objects[j].GetType();
                processedCount++;
            }
            
            Console.WriteLine($"id {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"objs {processedCount}");
        });
    }
}