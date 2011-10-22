using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OpenNETCF.Drawing.Imaging;
using System.Collections;
using System.Runtime.InteropServices;


namespace TubeRun
{
    public partial class FormMap : Form
    {
        FormMainN father;
        Boolean killed = true;
        public FormMap(FormMainN father)
        {
            InitializeComponent();
        }
        Bitmap map;
        public FormMap(FormMainN father,Bitmap pmap)
        {
            this.father = father;
            FileStream fsImage = null; ;
            InitializeComponent();
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\tubemap.jpg";
            try
            {
                if (pmap == null)
                {
                    IBitmapImage imageBitmap;

                    fsImage = new FileStream(appPath, FileMode.Open);
                    if (Screen.PrimaryScreen.Bounds.Height > 600)
                    {
                        pictureBox1.Size = new Size(2051, 1369);
                        imageBitmap = CreateThumbnail(fsImage, new Size(2051, 1369));
                    }
                    else
                        imageBitmap = CreateThumbnail(fsImage, new Size(1755, 1238));

                    map = ImageUtils.IBitmapImageToBitmap(
                        imageBitmap);
                    pictureBox1.Image = map;
                }
                else pictureBox1.Image = pmap;
            }
            catch (Exception e)
            {
                String s = e.ToString();
            }
            finally
            {
                if (fsImage != null) fsImage.Close();
            }
            Cursor.Current = Cursors.Default;
            Cursor.Show();
        }
        public Bitmap getBitmap() 
        {
            return map;
        }
        private void menuItem2_Click(object sender, EventArgs e)
        {
            father.Show();
            killed = false;
            this.Close();
        }

        static public IBitmapImage CreateThumbnail(Stream stream, Size size)
        {
            IBitmapImage imageBitmap;
            ImageInfo ii;
            IImage image;
            ImagingFactory factory = new ImagingFactoryClass();
            factory.CreateImageFromStream(
            new StreamOnFile(stream),
            out image);
            image.GetImageInfo(out ii);
            factory.CreateBitmapFromImage(
                image,
                (uint)size.Width,
                (uint)size.Height,
                ii.PixelFormat,
                InterpolationHint.InterpolationHintDefault,
                out imageBitmap);
            return imageBitmap;
        }

        private void MapForm_Closed(object sender, EventArgs e)
        {
            if (killed) father.exit(null, null);
        }
    }
}