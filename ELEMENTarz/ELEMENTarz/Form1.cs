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
        //DataTable table;
        HtmlWeb web = new HtmlWeb();
        int labelCounter;
        bool buttonBlock=false;

        public Form1()
        {
            InitializeComponent();
            //InitTable();
            listOfShops = new ShopList();
            //aaa
        }
        //private void InitTable()
        //{
        // koment
        //    table = new DataTable("Data");
        //    table.Columns.Add("Name", typeof(string));
        //    table.Columns.Add("Price", typeof(string));
        //    data_View.DataSource = table;
        //}
        private async Task<List<Result>> SearchParts(Shop shop, string phrase)
        {
            string url = shop.Searcher + phrase;
            var doc = await Task.Factory.StartNew(() => web.Load(url));
            var nameNodes = doc.DocumentNode.SelectNodes(shop.NameNode);
            var priceNodes = doc.DocumentNode.SelectNodes(shop.PriceNode);
            var secondNameNodes = doc.DocumentNode.SelectNodes(shop.SecondNameNode);
            
            //If these are null it means the name/score nodes couldn't be found on the html page
            if (nameNodes == null || priceNodes == null)
                return new List<Result>();

            var names = nameNodes.Select(node => node.InnerText).ToList();
            var price = priceNodes.Select(node => node.InnerText).ToList();
            var secondNames = secondNameNodes.Select(node => node.InnerText).ToList();

            List<Result> toReturn = new List<Result>();
            for (int i = 0; i < names.Count(); ++i)
                toReturn.Add(new Result() { Name = shop.getName(names[i], secondNames[i]), Price = price[i]});

            return toReturn;
        }

        private void displayResoults (List<Result> resoultsList, Shop shop)
        {
            //Create TableLayoutPanel for resoults
            if (resoultsList.Count > 0)
            {
                TableLayoutPanel resoultTable = new TableLayoutPanel();
                resoultTable.SuspendLayout();
                resoultTable.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
                resoultTable.ColumnCount = 2;
                resoultTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
                resoultTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 55F));
                resoultTable.Location = new Point(3, 3);
                resoultTable.Name = "tableLayoutPanel3";
                resoultTable.TabIndex = 4;
                flowLayoutPanel1.Controls.Add(resoultTable);
                //Label resoultLabel = new Label();
                //resoultLabel.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
                //resoultTable.SetColumnSpan(resoultLabel, 2);
                //resoultLabel.Location = new Point(4, 1);
                //resoultLabel.Name = shop.Name+"Label";
                ////resoultLabel.Size = new Size(192, 98);
                //resoultLabel.TextAlign = ContentAlignment.MiddleCenter;
                //resoultLabel.Text = shop.Name;   
                addShopLabel(shop, resoultTable);
                var rows = resoultsList.Count + 1;
                resoultTable.RowCount = rows;
                resoultTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                for (int i = 0; i < rows - 1; i++)
                {
                    resoultTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                    addLabels(resoultsList[i], shop.Name, i + 1, resoultTable);
                }
                resoultTable.Size = new Size(155, (rows - 1) * 40 + rows + 1 + 30);
                resoultTable.ResumeLayout(false);
                resoultTable.PerformLayout();
                //resoultTable.Controls.Add(resoultLabel, 0, 0);      
            }      
        }

        private void addShopLabel(Shop shop, TableLayoutPanel table)
        {
            Label resoultLabel = new Label();
            resoultLabel.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            resoultLabel.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238)));
            table.SetColumnSpan(resoultLabel, 2);
            resoultLabel.Location = new Point(4, 1);
            resoultLabel.Name = shop.Name + "Label";
            //resoultLabel.Size = new Size(192, 98);
            resoultLabel.TextAlign = ContentAlignment.MiddleCenter;
            resoultLabel.Text = shop.Name;
            table.Controls.Add(resoultLabel, 0, 0);
        }
        private void addLabels(Result resoult, string shop, int row, TableLayoutPanel table)
        {
            Label resoultLabel1 = new Label();
            resoultLabel1.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            resoultLabel1.Location = new Point(4, 1);
            resoultLabel1.Name = shop + "Label"+labelCounter++;
            //resoultLabel1.Size = new Size(192, 98);
            resoultLabel1.TextAlign = ContentAlignment.MiddleCenter;
            resoultLabel1.Text = resoult.Name;
            Label resoultLabel2 = new Label();
            resoultLabel2.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            resoultLabel2.Location = new Point(4, 1);
            resoultLabel2.Name = shop + "Label" + labelCounter++;
            //resoultLabel.Size = new Size(192, 98);
            resoultLabel2.TextAlign = ContentAlignment.MiddleCenter;
            resoultLabel2.Text = resoult.Price;
            //label2.Text = resoult.Price;
            table.Controls.Add(resoultLabel1, 0, row);
            table.Controls.Add(resoultLabel2, 1, row);
        }

        private async void search_btn_Click(object sender, EventArgs e)
        {
            // table.Clear();
            flowLayoutPanel1.Controls.Clear();
            
            if (!String.IsNullOrEmpty(toSearch_tb.Text.Trim())&&!buttonBlock)
            {
                buttonBlock = true;
                for (int i = 0; i <listOfShops.ListOfShops.Count; i++)
                {
                    var data = await SearchParts(listOfShops.ListOfShops[i], toSearch_tb.Text.Trim());
                    displayResoults(data, listOfShops.ListOfShops[i]);
                }
                buttonBlock = false;
                //var data = await SearchParts(listOfShops.ListOfShops[1], toSearch_tb.Text.Trim());
                //displayResoults(data, listOfShops.ListOfShops[1]);
                //foreach (var element in data)

                //  table.Rows.Add(element.Name, element.Price);
            }
        }

        private void toSearch_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) search_btn_Click(this, new EventArgs());
        }
    }
}
