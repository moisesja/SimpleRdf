using System;
using VDS.RDF;
using VDS.RDF.Parsing;

namespace SimpleRdfConsole.Examples
{
    public class SimpleReadExample : IExample
    {
        public void Execute()
        {
            IGraph ttlGraph = new Graph();
            
            TurtleParser ttlparser = new TurtleParser();

            try
            {
                //Load using a Filename
                ttlparser.Load(ttlGraph, "HelloWorld.ttl");

                foreach (Triple t in ttlGraph.Triples)
                {
                    Console.WriteLine(t.ToString());
                }

                IGraph g = new Graph();
                UriLoader.Load(g, new Uri("http://dbpedia.org/resource/Barack_Obama"));

                foreach (Triple t in g.Triples)
                {
                    Console.WriteLine(t.ToString());
                }

            }
            catch (Exception exc)
            {
                
            }
        }
    }
}
