using System;
using System.Net;
using Vocab;
using VDS.RDF;
using VDS.RDF.Parsing;
using System.Collections.Generic;
using VDS.RDF.Query;
using VDS.RDF.Query.Builder;

namespace SimpleRdfConsole.Examples
{
    public class SolidPodExample : IExample
    {
        public readonly string _podUri;

        public object GetPublicLdContainer(IGraph graph)
        {
            var queryString = new SparqlParameterizedString();
            
            string x = "x";
            var queryBuilder =
                QueryBuilder
                .Select(new string[] { x })
                .Where(
                    (triplePatternBuilder) =>
                    {
                        triplePatternBuilder
                            .Subject(x)
                            .Predicate ("rdf:type")
                            .Object("ldp:BasicContainer");
                    });

            //ldp: .

            var prefixes = new NamespaceMapper();

            prefixes.AddNamespace("ldp", new Uri("http://www.w3.org/ns/ldp#"));

            queryBuilder.Prefixes = prefixes;

            var processor = new GenericQueryProcessor();


            Console.WriteLine(queryBuilder.BuildQuery().ToString());

            return null;
        }

        public object GetAccounts()
        {
            return null;
        }

        public object GetTransactions(object account)
        {
            return null;
        }

        public object CreateCashAccountForProfile()
        {
            return null;
        }

        /// <summary>
        /// The operation will be a cash transfer from me to Liz
        /// </summary>
        /// <returns></returns>
        public object CreateCashTransaction()
        {
            return null;
        }

        public void PersistGraph()
        {

        }

        #region Constructor

        public SolidPodExample(string podUri)
        {
            _podUri = podUri;
        }

        #endregion

        public void Execute()
        {
            using (IGraph rootPodGraph = new Graph())
            {
                try
                {
                    var podEndPoint = new SparqlRemoteEndpoint(new Uri());
                    //UriLoader.Load(rootPodGraph, new Uri(_podUri));

                    //Options.HttpFullDebugging = true;

                    //rootPodGraph.Write("root-pod");

                    //var publicFolder = GetPublicLdContainer(rootPodGraph);
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
}