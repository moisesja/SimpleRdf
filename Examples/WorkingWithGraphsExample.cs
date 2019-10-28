using System;
using VDS.RDF;
using VDS.RDF.Query;

namespace SimpleRdfConsole.Examples
{
    public class WorkingWithGraphsExample : IExample
    {
        public void Execute()
        {
            //First define a SPARQL Endpoint for DBPedia
            SparqlRemoteEndpoint endpoint = new SparqlRemoteEndpoint(new Uri("http://dbpedia.org/sparql"));

            //Next define our query
            //We're going to ask DBPedia to describe the first thing it finds which is a Person
            String query = "DESCRIBE ?person WHERE {?person a <http://dbpedia.org/ontology/Person>} LIMIT 1";

            //Get the result
            var graph = endpoint.QueryWithResultGraph(query);

            if (!graph.IsEmpty)
            {
                foreach (Triple t in graph.Triples)
                {
                    Console.WriteLine(t.ToString());
                    Console.WriteLine("\n\n");
                }
            }
        }
    }
}
