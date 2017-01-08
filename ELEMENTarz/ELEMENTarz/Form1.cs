using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELEMENTarz
{
    public partial class Form1 : Form
    {
        ShopList listOfShops;
        DataTable table;
        HtmlWeb web = new HtmlWeb();
        public Form1()
        {
            InitializeComponent();
            InitTable();
            listOfShops = new ShopList();
        }
        private void InitTable()
        {
            table = new DataTable("Data");
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Price", typeof(string));
            data_View.DataSource = table;
        }
        private async Task<List<Result>> SearchParts(Shop shop, string phrase)
        {
            string url = shop.Searcher + phrase;
            var doc = await Task.Factory.StartNew(() => web.Load(url));
            var nameNodes = doc.DocumentNode.SelectNodes(shop.NameNode);
            var priceNodes = doc.DocumentNode.SelectNodes(shop.PriceNode);
            //If these are null it means the name/score nodes couldn't be found on the html page
            if (nameNodes == null || priceNodes == null)
                return new List<Result>();

            var names = nameNodes.Select(node => node.InnerText).ToList();
            var price = priceNodes.Select(node => node.InnerText).ToList();

            List<Result> toReturn = new List<Result>();
            for (int i = 0; i < names.Count(); ++i)
                toReturn.Add(new Result() { Name = names[i], Price = price[i]});

            return toReturn;
        }

        private async void search_btn_Click(object sender, EventArgs e)
        {
            table.Clear();
            if (!String.IsNullOrEmpty(toSearch_tb.Text.Trim()))
            {
                var data = await SearchParts(listOfShops.ListOfShops[1], toSearch_tb.Text.Trim());
                foreach (var element in data)
                    table.Rows.Add(element.Name, element.Price);
            }
        }
    }
}
