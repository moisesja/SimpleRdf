using SimpleRdfConsole.Examples;

namespace SimpleRdfConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IExample example = new SimpleWriteExample();
            example.Execute();

            example = new SimpleReadExample();
            example.Execute();
        }
    }
}
