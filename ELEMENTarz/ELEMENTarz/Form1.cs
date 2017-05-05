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
        ShopList shops;
        HtmlWeb web = new HtmlWeb();
        int labelCounter;
        bool buttonBlock = false;
        bool cancelSearching = false;

        public Form1()
        {
            InitializeComponent();
            shops = new ShopList();
            for (int i = 0; i < shops.ListOfShops.Count; i++)
            {
                listOfShopsToSearch.Items.Add(shops.ListOfShops[i].Name, true);
            }
        }

        private void DisplayResoults(List<Result> resoultsList, Shop shop)
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
                AddShopLabel(shop, resoultTable);
                var rows = resoultsList.Count + 1;
                resoultTable.RowCount = rows;
                resoultTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                for (int i = 0; i < rows - 1; i++)
                {
                    resoultTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
                    AddLabels(resoultsList[i], shop.Name, i + 1, resoultTable);
                }
                resoultTable.Size = new Size(155, (rows - 1) * 40 + rows + 1 + 30);
                resoultTable.ResumeLayout(false);
                resoultTable.PerformLayout();
            }
        }

        private void AddShopLabel(Shop shop, TableLayoutPanel table)
        {
            Label resoultLabel = new Label()
            {
                Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right))),
                Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(238))),
                Location = new Point(4, 1),
                Name = shop.Name + "Label",
                TextAlign = ContentAlignment.MiddleCenter,
                Text = shop.Name
            };
            table.SetColumnSpan(resoultLabel, 2);
            table.Controls.Add(resoultLabel, 0, 0);
        }
        private void AddLabels(Result resoult, string shop, int row, TableLayoutPanel table)
        {
            Label resoultLabel1 = new Label()
            {
                Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right))),
                Location = new Point(4, 1),
                Name = shop + "Label" + labelCounter++,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = resoult.Name
            };
            Label resoultLabel2 = new Label()
            {
                Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right))),
                Location = new Point(4, 1),
                Name = shop + "Label" + labelCounter++,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = resoult.Price
            };
            table.Controls.Add(resoultLabel1, 0, row);
            table.Controls.Add(resoultLabel2, 1, row);
        }

        private async void Search_btn_Click(object sender, EventArgs e)
        {
            if (!buttonBlock)
            {
                if (!String.IsNullOrEmpty(toSearch_tb.Text.Trim()))
                {
                    flowLayoutPanel1.Controls.Clear();
                    buttonBlock = true;
                    search_btn.Text = "Anuluj";
                    progressBar.Visible = true;
                    cancelSearching = false;
                    progressBar.Maximum = shops.ListOfShops.Count * 10;
                    progressBar.Maximum = listOfShopsToSearch.CheckedItems.Count * 10;
                    for (int i = 0; i < shops.ListOfShops.Count; i++)
                    {
                        if (!cancelSearching)
                        {
                            if (listOfShopsToSearch.CheckedItems.Contains(shops.ListOfShops[i].Name))
                            {
                                progressBar.PerformStep();
                                List<Result> data = await shops.ListOfShops[i].SearchParts(toSearch_tb.Text.Trim());
                                DisplayResoults(data, shops.ListOfShops[i]);
                            }
                        }
                        else
                            i = shops.ListOfShops.Count;
                    }
                    buttonBlock = false;
                    progressBar.Value = progressBar.Minimum;
                    progressBar.Visible = false;
                    search_btn.Text = "Wyszukaj";
                }
            }
            else
            {
                cancelSearching = true;
            }

        }

        private void ToSearch_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search_btn_Click(this, new EventArgs());
            }
        }
    }
}
