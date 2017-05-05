namespace ELEMENTarz
{
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
