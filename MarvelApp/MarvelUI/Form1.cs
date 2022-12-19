using MarvelLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarvelUI
{
    public partial class Form1 : Form
    {
        int st;
        int en;
        MarvelManager marvelManager;
        public Form1()
        {
            InitializeComponent();
            marvelManager = new MarvelManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void buttosn(object sender, EventArgs e)
        {
            int id = Convert.ToInt32((sender as Button).Tag.ToString());

            foreach (var character in marvelManager.GetCharacters(st, en))
               if(character.Id ==id)
                    using (Context s = new Context())
                    {
                       
                    }
               
            
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            st = Convert.ToInt32(textBox1.Text);
            en = Convert.ToInt32(textBox2.Text);
            flowLayoutPanel1.Controls.Clear();
            foreach (var character in marvelManager.GetCharacters(st,en))
            {
                Panel panel = new Panel
                {
                    Width = 300,
                    Height = 300,
                    BackColor = Color.Gray
                };
                Button button = new Button(); 
                Label label = new Label
                {
                    Text = character.Name,
                    Font = new Font(FontFamily.GenericMonospace, 24),
                    Width = 300,
                    Height = 50,
                    Location = new Point(0, 30),
                    Tag = character.Description
                };

                PictureBox picture = new PictureBox
                {
                    Width = 200,
                    Height = 200,

                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location= new Point(0,60)
                };

                picture.LoadAsync(character.ImageUrl);

                panel.Controls.Add(button);
                panel.Controls.Add(label);

                panel.Controls.Add(picture);
                
                flowLayoutPanel1.Controls.Add(panel);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
