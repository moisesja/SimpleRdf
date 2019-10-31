using System;
using System.Collections.Generic;
using System.Net;
using VDS.RDF;
using VDS.RDF.Parsing;

namespace SimpleRdfConsole.Examples
{
    public class FinanzasXExample : IExample
    {
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

        public void Execute()
        {
            var graph = new Graph();

            var cashAccount = graph.CreateUriNode(UriFactory.Create("https://moisesj.inrupt.net/private/finanzasx/accounts/cash"));

            var isOwnedBy = graph.CreateUriNode(UriFactory.Create("http://example.org/isowned"));
            var me = graph.CreateUriNode(UriFactory.Create("https://moisesj.inrupt.net/profile/card#me"));

            graph.Assert(new Triple(cashAccount, isOwnedBy, me));

            var writers = new List<IWriter>()
                {
                    new ConsoleWriter(),                    
                    new MyTurtleWriter("cashAccount.ttl"),
                };

            writers.ForEach(item => item.Write(graph));
        }
    }
}