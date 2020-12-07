using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace PictureBox
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            InitializePhoto();



        }








        private void BtnAddPhoto_Click(object sender, EventArgs e)
        {
            oFDPhotoDirectory.ShowDialog();
            var photoDirectory = oFDPhotoDirectory.FileName;
            InsertImage(photoDirectory);
            
        }
        private void BtnRemovePhoto_Click(object sender, EventArgs e)
        {
            var dialog = MessageBox.Show("Czy na pewno chcesz usunąć zdjęcie?", "Potwierdzenie usunięcia", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                pbPhoto.Image = null;
                btnRemovePhoto.Visible = false;
            }
        }
        private void InitializePhoto()
        {
            var photoTxtDirectory = Program.filePath;
            if (!File.Exists(photoTxtDirectory))
                File.Create(photoTxtDirectory);
            else
            {
                string photoDirectory = File.ReadAllText(photoTxtDirectory, Encoding.UTF8);
                if (photoDirectory != "")
                {
                   InsertImage(photoDirectory);
                }
            }
        }
        private void InsertImage(string filePath)
        {
            try
            {
                pbPhoto.Image = Image.FromFile(filePath);
                InsertPhotoDirectoryToFile(filePath);
                btnRemovePhoto.Visible = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void InsertPhotoDirectoryToFile(string filePath)
        {
            var photoTxtDirectory = Program.filePath;
            if (File.Exists(photoTxtDirectory))
                File.Delete(photoTxtDirectory);
            using (FileStream fileStream = File.Create(photoTxtDirectory))
            {
                Byte[] textToFile = new UTF8Encoding(true).GetBytes(filePath);
                fileStream.Write(textToFile, 0, textToFile.Length);
            }
        }
    }
}