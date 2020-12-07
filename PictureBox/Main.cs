using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureBox
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();


            

        }

       






        private void BtnAddPhoto_Click(object sender, EventArgs e)
        {
            oFDPhotoDirectory.ShowDialog();
            var photoDirectory = oFDPhotoDirectory.FileName;
            try
            {
                pbPhoto.Image = Image.FromFile(photoDirectory);
                btnRemovePhoto.Visible = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

          


        }

        private void BtnRemovePhoto_Click(object sender, EventArgs e)
        {


            pbPhoto.Image = null;
            btnRemovePhoto.Visible = false;
        }
    }
}
