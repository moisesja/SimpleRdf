﻿using System;
using VDS.RDF;
using VDS.RDF.Writing;

namespace SimpleRdfConsole.Examples
{
    public interface IWriter
    {
        void Write(IGraph graph);
    }

    public class ConsoleWriter : IWriter
    {
        public void Write(IGraph graph)
        {
            foreach (Triple t in graph.Triples)
            {
                Console.WriteLine(t.ToString());
            }
        }
    }

    public abstract class FileWriter : IWriter
    {
        public FileWriter(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }

        protected abstract BaseRdfWriter SpecializedWriter { get; }

        public void Write(IGraph graph)
        {
            SpecializedWriter.Save(graph, FileName);
        }
    }

    public class RdfWriter : FileWriter
    {
        public RdfWriter(string fileName) : base(fileName)
        {
        }

        protected override BaseRdfWriter SpecializedWriter => new NTriplesWriter();
    }

    public class XmlWriter : FileWriter
    {
        public XmlWriter(string fileName) : base(fileName)
        {
        }

        protected override BaseRdfWriter SpecializedWriter => new RdfXmlWriter();        
    }

    public class MyTurtleWriter : FileWriter
    {
        public MyTurtleWriter(string fileName) : base(fileName)
        {
        }

        protected override BaseRdfWriter SpecializedWriter => new CompressingTurtleWriter(VDS.RDF.Parsing.TurtleSyntax.W3C);
    }    
}
