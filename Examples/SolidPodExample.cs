using SimpleRdfConsole.Examples.Rest;
using System;
using System.IO;
using VDS.RDF;
using VDS.RDF.Parsing;

namespace SimpleRdfConsole.Examples
{
    public class SolidPodExample : IExample
    {
        public readonly string _podUri;        

        public object GetPublicLdContainer(IGraph graph)
        {
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
            try
            {
                var solidClient = new SolidRestClient(_podUri);

                var returnedText = solidClient.GetAsync("public/financial-aggregator/accounts").GetAwaiter().GetResult();

                var parser = new TurtleParser();
                
                var textReader = new StringReader(returnedText);
                

                IGraph graph = new Graph();
                parser.Load(graph, textReader);
                graph.Write("public-folder");


            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }        
        }
    }
}