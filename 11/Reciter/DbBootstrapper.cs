using Reciter.Data;
using Reciter.Entity;

namespace Reciter;

public static class DbBootstrapper
{
    public static void Bootstrap()
    {
        try
        {
            using var context = new ReciterDataContext();
            context.Database.EnsureCreated();
            if (context.Words.Any()) return;
            context.Words.Add(new Word { Chinese = "你好", English = "hello" });
            context.Words.Add(new Word { Chinese = "放弃", English = "abandon" });
            context.Words.Add(new Word { Chinese = "知识", English = "knowledge" });
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}