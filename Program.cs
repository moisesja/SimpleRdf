using SimpleRdfConsole.Examples;

namespace SimpleRdfConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //const string POD_URI = "https://moisesj.inrupt.net";
            const string POD_URI = "https://moisesj.solid.community";

            var example = new SolidPodExample(POD_URI);
            example.Execute();
        }
    }
}