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

            IUriNode dotNetRDF = graph.CreateUriNode(UriFactory.Create("http://www.dotnetrdf.org"));
            IUriNode says = graph.CreateUriNode(UriFactory.Create("http://example.org/says"));
            ILiteralNode helloWorld = graph.CreateLiteralNode("Hello World");
            ILiteralNode bonjourMonde = graph.CreateLiteralNode("Bonjour tout le Monde", "fr");

            graph.Assert(new Triple(dotNetRDF, says, helloWorld));
            graph.Assert(new Triple(dotNetRDF, says, bonjourMonde));

            var writers = new List<IWriter>()
                {
                    new ConsoleWriter(),
                    new RdfWriter(),
                    new XmlWriter()
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
                NTriplesWriter ntwriter = new NTriplesWriter();
                ntwriter.Save(graph, "HelloWorld.nt");
            }
        }

        private class XmlWriter : IWriter
        {
            public void Write(IGraph graph)
            {
                RdfXmlWriter rdfxmlwriter = new RdfXmlWriter();
                rdfxmlwriter.Save(graph, "HelloWorld.rdf");
            }
        }
    }
}