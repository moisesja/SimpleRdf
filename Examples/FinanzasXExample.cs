using System;
using System.Collections.Generic;
using System.Net;
using VDS.RDF;
using VDS.RDF.Parsing;

namespace SimpleRdfConsole.Examples
{
    public class FinanzasXExample : IExample
    {
        public void Execute()
        {
            var graph = new Graph();

            var cashAccount = graph.CreateUriNode(UriFactory.Create("https://moisesj.solid.community/private/FinanzasX/Accounts/Cash"));

            var isOwnedBy = graph.CreateUriNode(UriFactory.Create("http://example.org/isowned"));
            var me = graph.CreateUriNode(UriFactory.Create("https://moisesj.inrupt.net/profile/card#me"));

            var accountType = graph.CreateUriNode(UriFactory.Create("http://example.org/accountType"));
            var cash = graph.CreateLiteralNode("Cash");

            graph.Assert(new Triple(cashAccount, isOwnedBy, me));
            graph.Assert(new Triple(cashAccount, accountType, cash));

            var writers = new List<IWriter>()
                {
                    new ConsoleWriter(),                    
                    new MyTurtleWriter("cashAccount.ttl"),
                };

            writers.ForEach(item => item.Write(graph));
        }
    }
}