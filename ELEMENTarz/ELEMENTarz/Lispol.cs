using HtmlAgilityPack;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ELEMENTarz
{
    public class Lispol : Shop
    {
        public Lispol()
        {
            NameSpliter = ':';
            NameNode = "/html[1]/body[1]/div[5]/div[1]/div[2]/div[2]/div[2]/div[1]/div[4]/div/div[1]/div[2]/div[1]/div[2]/div[1]";
            PriceNode = "/html[1]/body[1]/div[5]/div[1]/div[2]/div[2]/div[2]/div[1]/div[4]/div/div[1]/div[2]/div[2]/div[1]/p[2]";
            SecondNameNode = "/html[1]/body[1]/div[5]/div[1]/div[2]/div[2]/div[2]/div[1]/div[4]/div/div[1]/div[2]/div[2]/div[1]/p[1]";
            Searcher = "http://lispol.com/oferta-szukaj/";
            Name = "Lispol";
        }
        override public async Task<List<Result>> SearchParts(string phrase)
        {
            List<Result> toReturn = await base.SearchParts(phrase);
            if (toReturn.Count == 0)
                return toReturn;
            HtmlNodeCollection secondNameNodes = doc.DocumentNode.SelectNodes(SecondNameNode);
            List<string> secondNames = secondNameNodes.Select(node => node.InnerText).ToList();
            for (int i = 0; i < toReturn.Count(); i++)
            {
                toReturn[i].Name = NewName(toReturn[i].Name, secondNames[i]);
            }
            return toReturn;

        }
        private string NewName(string longName, string other)
        {
            var text = other.Trim().Split(NameSpliter);
            var newName = longName + text[1];
            return newName;
        }
    }

}
