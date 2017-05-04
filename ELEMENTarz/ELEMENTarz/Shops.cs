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
            //HtmlNodeCollection secondNameNodes = doc.DocumentNode.SelectNodes(SecondNameNode);

            //If these are null it means the name/score nodes couldn't be found on the html page
            if (nameNodes == null || priceNodes == null)
                return new List<Result>();

            List<string> names = nameNodes.Select(node => node.InnerText).ToList();
            List<string> price = priceNodes.Select(node => node.InnerText).ToList();
            //List<string> secondNames = secondNameNodes.Select(node => node.InnerText).ToList();

            List<Result> toReturn = new List<Result>();
            for (int i = 0; i < names.Count(); ++i)
                toReturn.Add(new Result() { Name = getName(names[i]), Price = price[i] });

            return toReturn;
        }
        virtual public string  getName(string longName)
        {
            var name = longName.Split(NameSpliter);
            return name[0];
        }
    }
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
            HtmlNodeCollection secondNameNodes = doc.DocumentNode.SelectNodes(SecondNameNode);
            List<string> secondNames = secondNameNodes.Select(node => node.InnerText).ToList();
            for (int i = 0; i < toReturn.Count(); i++)
            {
                toReturn[i].Name = newName(toReturn[i].Name, secondNames[i]);
            }
            return toReturn;

        }
        private string newName(string longName, string other)
        {
            var text = other.Trim().Split(NameSpliter);
            var newName = longName + text[1];
            return newName;
        }
    }
    public class Elbrod : Shop
    {
        public Elbrod()
        {
            NameSpliter = '/';
            NameNode = "/html[1]/body[1]/div[1]/div[6]/section[1]/div[1]/div//div[2]/h3[1]/a[1]";
            PriceNode = "/html[1]/body[1]/div[1]/div[6]/section[1]/div[1]/div//div[2]/span[1]/em[1]/text()";
            Searcher = "http://elbrod.pl/szukaj.html/szukaj=";
            Name = "Elbrod";
            SecondNameNode = "/html[1]/body[1]/div[1]/div[6]/section[1]/div[1]/div//div[2]/h3[1]/a[1]";
        }
    }

}
