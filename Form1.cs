using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaMemoria
{
    public partial class Form1 : Form
    {
        // firstClicked points to the first Label control
        // that the player clicks, but it will be null
        // if the player hasn't clicked a label yet
        Label firstClicked = null;

        // secondClicked points to the second Label control
        // that the player clicks
        Label secondClicked = null;

        // This will be used to choose random icons for the squares
        Random random = new Random();

        // Each of the letters here represens an icon,
        // in the Webdings font,
        // and each icon appears twice in this list
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k", // 8
            "b", "b", "v", "v", "w", "w", "z", "z", // 16
            "n", "n", "a", "a", "e", "e", "s", "s", // 22
            "Y", "Y", "-", "-", "J", "J", "T", "T" // 30
        };

        private void AssignIconsToSquares()
        {
            // The TableLayoutPanel has 30 labels,
            // and the icon List has 30 icons,
            // so an icon is pullad at random from the list
            // and added to each label.
            foreach (Control control in tableLayoutPanel1.Controls) // Control represents all of the elements inside C#
                                                                    // This means that this loop runs every element inside
                                                                    // tableLayoutPanel1.Controls
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            // The timer is only on after two non-matching 
            // icons have been shown to the player, 
            // so ignore any clicks if the timer is running
            if (timer1.Enabled)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                // If the clicked label is black, the player clicked
                // an icon that's already been reavealder --
                // ignore the click
                if (clickedLabel.ForeColor == Color.Black)
                    return;


                // In the firstClicked is null, this is the first icon
                // in the pair the player clicked,
                // so set firstClicked to the label that the player
                // clicked, change its color to black, and return
               if (firstClicked == null)
               {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;

                    return;
               }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer1.Stop();

            //Hide both icons
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            // Reset firstClicked and secondClicked
            // so the next time a label is 
            // clicked, the program knows it's the first click
            firstClicked = null;
            secondClicked = null;
        }
    }
}
