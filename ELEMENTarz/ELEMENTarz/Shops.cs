using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELEMENTarz
{
    public class Result
    {
        public string Name { get; set; }
        public string Price { get; set; }
    }
    public class ShopList
    {
        public List<Shop> ListOfShops;
        public ShopList()
        {
            ListOfShops = new List<Shop>
            {
                new Lispol(),
                new Elbrod()
            };
        }
    }
    public class Shop
    {
        HtmlWeb web = new HtmlWeb();
        protected  HtmlDocument doc;
        public string NameNode { get; set; }
        public string SecondNameNode { get; set; }
        public string PriceNode { get; set; }
        public string Searcher { get; set; }
        public string Name { get; set; }
        public char NameSpliter { get; set; }

        public Shop()
        {

        }

        virtual public async Task<List<Result>> SearchParts( string phrase)
        {
            string url = Searcher + phrase;
            doc = await Task.Factory.StartNew(() => web.Load(url));
            HtmlNodeCollection nameNodes = doc.DocumentNode.SelectNodes(NameNode);
            HtmlNodeCollection priceNodes = doc.DocumentNode.SelectNodes(PriceNode);

            //If these are null it means the name/score nodes couldn't be found on the html page
            if (nameNodes == null || priceNodes == null)
                return new List<Result>();

            List<string> names = nameNodes.Select(node => node.InnerText).ToList();
            List<string> price = priceNodes.Select(node => node.InnerText).ToList();

            List<Result> toReturn = new List<Result>();
            for (int i = 0; i < names.Count(); ++i)
                toReturn.Add(new Result() { Name = GetName(names[i]), Price = price[i] });

            return toReturn;
        }
        virtual public string  GetName(string longName)
        {
            var name = longName.Split(NameSpliter);
            return name[0];
        }
    }

}
