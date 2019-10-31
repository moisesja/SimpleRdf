using System;
using System.Collections.Generic;
using System.Linq;
using VDS.RDF;
using VDS.RDF.Writing;

namespace SimpleRdfConsole.Examples
{
    public class SimpleWriteExample : IExample
    {
        public void Execute()
        {
            IGraph graph = new Graph();

            var dotNetRDF = graph.CreateUriNode(UriFactory.Create("http://www.dotnetrdf.org"));
            var says = graph.CreateUriNode(UriFactory.Create("http://example.org/says"));
            var helloWorld = graph.CreateLiteralNode("Hello World");
            var bonjourMonde = graph.CreateLiteralNode("Bonjour tout le Monde", "fr");

            graph.Assert(new Triple(dotNetRDF, says, helloWorld));
            graph.Assert(new Triple(dotNetRDF, says, bonjourMonde));

            var writers = new List<IWriter>()
                {
                    new ConsoleWriter(),
                    new RdfWriter("HelloWorld.nt"),
                    new XmlWriter("HelloWorld.rdf"),
                    new MyTurtleWriter("HelloWorld.ttl"),
                };

            writers.ForEach(item => item.Write(graph));
        }        
    }
}