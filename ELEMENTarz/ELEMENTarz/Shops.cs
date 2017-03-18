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
        public string NameNode { get; set; }
        public string SecondNameNode { get; set; }
        public string PriceNode { get; set; }
        public string Searcher { get; set; }
        public string Name { get; set; }
        public char nameSpliter { get; set; }
        public List<Result> resoults;

        public Shop()
        {

        }
        virtual public string  getName(string longName, string other)
        {
            var name = longName.Split(nameSpliter);
            return name[0];
        }
    }
    public class Lispol : Shop
    {
        public Lispol()
        {
            nameSpliter = ':';
            NameNode = "/html[1]/body[1]/div[5]/div[1]/div[2]/div[2]/div[2]/div[1]/div[4]/div/div[1]/div[2]/div[1]/div[2]/div[1]";
            PriceNode = "/html[1]/body[1]/div[5]/div[1]/div[2]/div[2]/div[2]/div[1]/div[4]/div/div[1]/div[2]/div[2]/div[1]/p[2]";
            SecondNameNode = "/html[1]/body[1]/div[5]/div[1]/div[2]/div[2]/div[2]/div[1]/div[4]/div/div[1]/div[2]/div[2]/div[1]/p[1]";
            //NameNode = "/html[1]/body[1]/div[5]/div[1]/div[1]/div[2]/div[2]/div[1]/table[1]/tr//td//div[1]/div[2]/div[1]/div[2]/div[1]";
            //PriceNode = "/html[1]/body[1]/div[5]/div[1]/div[1]/div[2]/div[2]/div[1]/table[1]/tr//td/div[1]/div[2]/div[2]/div[1]/p[2]";
            Searcher = "http://lispol.com/oferta-szukaj/";
            Name = "Lispol";
        }
        public override string getName(string longName, string other)
        {
            var text = other.Trim().Split(nameSpliter);
            var newName = longName + text[1];
            //var name = longName.Split(nameSpliter);
            return newName;
        }
    }
    public class Elbrod : Shop
    {
        public Elbrod()
        {
            nameSpliter = '/';
            NameNode = "/html[1]/body[1]/div[1]/div[6]/section[1]/div[1]/div//div[2]/h3[1]/a[1]";
            PriceNode = "/html[1]/body[1]/div[1]/div[6]/section[1]/div[1]/div//div[2]/span[1]/em[1]/text()";
            Searcher = "http://elbrod.pl/szukaj.html/szukaj=";
            Name = "Elbrod";
            SecondNameNode = "/html[1]/body[1]/div[1]/div[6]/section[1]/div[1]/div//div[2]/h3[1]/a[1]";
        }
    }

}
