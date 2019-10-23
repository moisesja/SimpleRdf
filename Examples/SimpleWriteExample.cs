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
                    new RdfWriter(),
                    new XmlWriter(),
                    new MyTurtleWriter(),
                };

            writers.ForEach(item => item.Write(graph));
        }

        private interface IWriter
        {
            void Write(IGraph graph);
        }

        private class ConsoleWriter : IWriter
        {
            public void Write(IGraph graph)
            {
                foreach (Triple t in graph.Triples)
                {
                    Console.WriteLine(t.ToString());
                }
            }
        }

        private class RdfWriter : IWriter
        {
            public void Write(IGraph graph)
            {
                var ntwriter = new NTriplesWriter();
                ntwriter.Save(graph, "HelloWorld.nt");
            }
        }

        private class XmlWriter : IWriter
        {
            public void Write(IGraph graph)
            {
                var rdfxmlwriter = new RdfXmlWriter();
                rdfxmlwriter.Save(graph, "HelloWorld.rdf");
            }
        }

        private class MyTurtleWriter : IWriter
        {
            public void Write(IGraph graph)
            {
                var writer = new CompressingTurtleWriter(VDS.RDF.Parsing.TurtleSyntax.W3C);
                writer.Save(graph, "HelloWorld.ttl");
            }
        }
    }
}