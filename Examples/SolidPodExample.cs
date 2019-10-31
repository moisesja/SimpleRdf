using System;
using System.Net;
using VDS.RDF;
using VDS.RDF.Parsing;

namespace SimpleRdfConsole.Examples
{
    public class SolidPodExample : IExample
    {
        public void Execute()
        {
            var graph = new Graph();

            try
            {
                //UriLoader.Load(graph, new Uri("https://moisesj.inrupt.net/profile/card#me"));
                UriLoader.Load(graph, new Uri("https://moisesj.inrupt.net/public"));

                foreach (Triple t in graph.Triples)
                {
                    Console.WriteLine(t.ToString());
                }
            }
            catch (WebException webExc)
            {

            }
            catch (Exception exc)
            {

            }
        }
    }
}
