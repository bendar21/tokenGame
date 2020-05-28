using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class token
    {
        //Declare private global variables
        PictureBox tokenPB;
        Bitmap tokenImage;

        //Constructor which gets run when you make a new object of type token.
        //Arguments set up the pictureBox
        public token(int argsLeft, int argsTop, Bitmap argsImageFile)
        {
            tokenPB = new PictureBox();
            tokenPB.Image = argsImageFile;
            tokenPB.Left = argsLeft;
            tokenPB.Top = argsTop;
            tokenPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;

        }

        //public accessor so that we can see the pictureBox from our main form
        public PictureBox TokenPB
        {
            get { return tokenPB; }
            set { tokenPB = value; }
        }

        //move up and down method. Direction will either be 1 for down or -1 for up
        public void moveUpDown(int direction, int distance, Bitmap tokenImage)
        {
            tokenPB.Top = tokenPB.Top + (direction * distance);
        }

        //move right or left method. Direction will either be 1 for right or -1 for Left
        public void moveRightLeft(int direction, int distance, Bitmap tokenImage)
        {
            tokenPB.Left = tokenPB.Left + (direction * distance);
        }
    }
}

    

