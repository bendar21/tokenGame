using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int count = 0;
        Random rand = new Random();
        Timer tickerTimer = new Timer();

        Bitmap blueImage = Game.Properties.Resources.blueCircle;
        Bitmap redImage = Game.Properties.Resources.redCircle;

        const int NUMBER_OF_REDTOKENS = 10;
        token[] redTokens = new token[NUMBER_OF_REDTOKENS];
        token blueToken;

       

        private void Form1_Load(object sender, EventArgs e)
        {
            //loop through array to place the ten redTokens
            for (int i = 0; i < redTokens.Length; i++)
            {
                int xCoordinate = rand.Next(this.Width - 50);
                int yCoordinate = rand.Next(this.Height - 50);
                redTokens[i] = new token(xCoordinate, yCoordinate, redImage);
                Controls.Add(redTokens[i].TokenPB);
            }
            blueToken = new token(200, 200, blueImage);
            Controls.Add(blueToken.TokenPB);

            //enable timer
            tickerTimer.Enabled = true;
            tickerTimer.Interval = 500; //every half a second
            //create timer event
            tickerTimer.Tick += TickerTimer_Tick;
            //create keyDown event
            KeyDown += new KeyEventHandler(Form1_KeyDown);

        }

        private void TickerTimer_Tick(object sender, EventArgs e)
        {
            
            for (int i = 0; i < redTokens.Length; i++)
            {
                if (blueToken.TokenPB.Bounds.IntersectsWith(redTokens[i].TokenPB.Bounds))
                {
                    count++;
                    redTokens[i].TokenPB.Top = 1000;
                    redTokens[i].TokenPB.Left = 1000;
                    label1.Text = "Tokens Collected: " + count;
                }
            }
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Variables to determine direction
            int right = 1;
            int left = -1;
            int up = -1;
            int down = 1;

            //Distance variables

            int blueDist = 15;



            //blueToken control keys. w:Up; a:Down; s:Left; d:Right
            if (e.KeyCode == Keys.W)
            {
                blueToken.moveUpDown(up, blueDist, blueImage);
            }
            if (e.KeyCode == Keys.S)
            {
                blueToken.moveUpDown(down, blueDist, blueImage);
            }
            if (e.KeyCode == Keys.A)
            {
                blueToken.moveRightLeft(left, blueDist, blueImage);
            }
            if (e.KeyCode == Keys.D)
            {
                blueToken.moveRightLeft(right, blueDist, blueImage);
            }
        

        
            
        }
    }
}

