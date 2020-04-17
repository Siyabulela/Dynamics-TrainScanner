using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using RestSharp;

namespace TrainScanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {    
            InitializeComponent();
            this.BackColor = Color.White;
            label3.Text = "Scan your card";
            textBox1.Text = string.Empty;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            callAsync();
            
        }

        public async Task callAsync()
        {
            var client = new RestClient("https://trainapp-a54e.restdb.io/rest/contact");
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("x-apikey", "e951252bc93c396fe5f2e7f8d37f501202f41");
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);

            string resp = response.Content;

            int color = 3;

            int count = 99;

            for (int i = 0; i < count; i++)
            {
                if (resp.Contains(textBox1.Text))
                {
                    //textBox1.Text = string.Empty;
                    label3.Text = "Pass";
                    color = 1;
                    //await Task.Delay(2000);
                }
                if (!(resp.Contains(textBox1.Text)))
                {
                    //textBox1.Text = string.Empty;
                    label3.Text = "Number not registered";
                    color = 2;
                    //await Task.Delay(2000);
                }

                if (color == 1)
                {
                    this.BackColor = Color.Green;
                }
                if (color == 2)
                {
                    this.BackColor = Color.Red;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}