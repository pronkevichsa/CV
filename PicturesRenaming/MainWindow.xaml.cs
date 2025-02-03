using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.Net;
using System.Globalization;
using System.Drawing.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;





namespace PicturesRenaming
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TreeViewDrivers();
        }
        public DirectoryInfo dir;
        public bool ModifyPicture;

        void TreeViewDrivers()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Tag = drive;
                item.Header = drive.ToString();
                item.Items.Add("*");
                //trw_Products.Items.Add(item);
                treeView1.Items.Add(item);
                item.Expanded += new RoutedEventHandler(item_DirExpanded);
            }
        }

        void Item_FileExpanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)e.OriginalSource;
            item.Items.Clear();
            DirectoryInfo driv;
            if (item.Tag is DriveInfo)
            {
                DriveInfo dr = (DriveInfo)item.Tag;
                driv = dr.RootDirectory;
            }
            else driv = (DirectoryInfo)item.Tag;

            try
            {
                listView1.Items.Clear();
                foreach (FileInfo fi in driv.GetFiles())
                {
                    switch (fi.Extension.ToLower())
                    {
                        case ".jpg":
                        case ".jpeg":
                        case ".png":
                            {
                                TreeViewItem newItem1 = new TreeViewItem();
                                newItem1.Tag = fi;
                                newItem1.Header = fi.ToString();
                                newItem1.Items.Add("*");
                                item.Items.Add(newItem1);
                                listView1.Items.Add(fi);
                                break;
                            }
                    }
                }
            }
            catch { }
        }

        void item_DirExpanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)e.OriginalSource;
            item.Items.Clear();
            if (item.Tag is DriveInfo)
            {
                DriveInfo drive = (DriveInfo)item.Tag;
                dir = drive.RootDirectory;
            }
            else dir = (DirectoryInfo)item.Tag;
            try
            {
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    TreeViewItem newItem = new TreeViewItem();
                    newItem.Tag = subDir;
                    newItem.Header = subDir.ToString();
                    newItem.Items.Add("*");
                    item.Items.Add(newItem);

                    newItem.Expanded += new RoutedEventHandler(Item_FileExpanded);
                }
            }
            catch
            { }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (RBtn1.IsChecked == true)
            {
                string str = (string)Label1.Content;
                DateTime dt = GetExif(str);
                FileAddText(str, dt.ToString());
                FileRename(dir.FullName, listView1.SelectedValue.ToString(), dt.ToString().Replace(':', '_'));
            }
            else
            {

            }

            //MessageBox.Show(RBtn1.IsChecked.ToString());

            //OpenFileDialog op = new OpenFileDialog();
            //op.Title = "Select a picture";
            //op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
            //  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            //  "Portable Network Graphic (*.png)|*.png";
            //if (op.ShowDialog() == true)
            //{               
            //    loadText.Text = op.FileName;
            //    BitmapImage bitmap= new BitmapImage(new Uri(op.FileName));
            //    image1.Source = new BitmapImage(new Uri(op.FileName));             
            //}            
        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                loadText.Text = listView1.SelectedValue.ToString();
                string str = dir.FullName + "\\" + listView1.SelectedValue.ToString();
                Label1.Content = str;
                //DateTime dt = GetExif(str);
                //FileAddText(str, dt.ToString());
                //FileRename(dir.FullName, listView1.SelectedValue.ToString(), dt.ToString().Replace(':','_'));             
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FileAddText(string path, string strAdd)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                System.Drawing.Image image = System.Drawing.Image.FromStream(fs);
                fs.Close();
                Bitmap b = new Bitmap(image);
                Graphics graphics = Graphics.FromImage(b);
                graphics.DrawString(strAdd, new Font("Arial", 72), System.Drawing.Brushes.Red, 100, 100);
                // b.Save(path, image.RawFormat);
                b.Save(path, image.RawFormat);
                image.Dispose();
                b.Dispose();
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        static public DateTime GetExif(string path)
        {
            DateTime dateOfImage = Convert.ToDateTime("01/01/1900");
            string exiftitle;
            string title;
            try
            {
                using (FileStream file = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    BitmapDecoder decoder = JpegBitmapDecoder.Create(file, BitmapCreateOptions.IgnoreColorProfile, BitmapCacheOption.Default);
                    BitmapMetadata metadata = (BitmapMetadata)decoder.Frames[0].Metadata.Clone();
                    //  title = metadata.Title;
                    dateOfImage = Convert.ToDateTime(metadata.DateTaken);
                    if (dateOfImage.ToString().Substring(0, 10) == "01.01.0001")
                        dateOfImage = System.IO.File.GetCreationTime(path);

                    exiftitle = (string)metadata.GetQuery(@"/app1/ifd/{ushort=40091}");
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dateOfImage;
        }

        static public void FileRename(string filePath, string oldfileName, string newfileName)
        {
            // Directory.CreateDirectory(this.dir.FullName + "\\AddedData");
            string str1 = filePath + "\\" + oldfileName;
            string fileExt;
            fileExt = System.IO.Path.GetExtension(str1);
            string str2 = filePath + "\\" + newfileName + fileExt;
            //   string strbak = filePath + "\\" + newfileName + ".bak";
            // File.Replace(str1, str2, strbak);
            File.Copy(str1, newfileName + fileExt);
            MessageBox.Show("Done");

        }

        private void BtnSortDate_Click(object sender, RoutedEventArgs e)
        {
            string[] extensions = new[] { ".jpg", ".jpeg", ".png" };
            List<DateTime> dtFile = new List<DateTime>();
            try
            {
                FileInfo[] files = dir.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();
                foreach (FileInfo fi in files)
                {
                    dtFile.Add(GetExif(fi.FullName));
                    try
                    {
                        string strDir = dir.FullName + "\\" + GetExif(fi.FullName).Year.ToString();
                        Directory.CreateDirectory(strDir);
                        File.Copy(fi.FullName, strDir + "\\" + fi.Name);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch { }
            MessageBox.Show("Sorted by Year");
        }

        private void AddDateToFoto_Checked(object sender, RoutedEventArgs e)
        {
            BtnSortDate.IsEnabled = false;
            btnAdd.IsEnabled = true;
            loadText.IsEnabled = true;
            RBtn1.IsEnabled = true;
            Rbtn2.IsEnabled = true;
        }

        private void AddDateToFoto_Unchecked(object sender, RoutedEventArgs e)
        {
            BtnSortDate.IsEnabled = true;
            btnAdd.IsEnabled = false;
            loadText.IsEnabled = false;
            RBtn1.IsEnabled = false;
            Rbtn2.IsEnabled = false;
        }


        public static void AddDataToAllFoto()
        {

        }

        public static void AddDataToSelectedFoto(string fotoPath)
        {

        }

        private void RBtn1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRename_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Directory.CreateDirectory(dir.FullName + "\\Renamed");
                string[] extensions = new[] { ".jpg", ".jpeg", ".png" };
                List<DateTime> dtFile = new List<DateTime>();
                FileInfo[] files = dir.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();
                foreach (FileInfo fi in files)
                {
                    dtFile.Add(GetExif(fi.FullName));
                    string newName = GetExif(fi.FullName).ToString().Replace(':', '_');
                    FileRename(fi.DirectoryName, fi.Name, dir.FullName + "\\Renamed\\" + newName);
                }

            }
            catch (IOException ex)
            {

            }

        }

        private void BtnMap_Click(object sender, RoutedEventArgs e)
        {
            string s = (string)Label1.Content;
            FileStream foto = File.Open(s, FileMode.Open, FileAccess.Read);
            System.Drawing.Image image = new Bitmap(foto);
            
            TextBox1.Text = GetLatitude(image) + "\n"; 
            TextBox1.Text += GetLongitude(image) + "\n";

            TextBox1.Text += SearchObject(GetLatitude(image), GetLongitude(image));
            
            string point = SearchMapImage(GetLatitude(image), GetLongitude(image));

            string imageUrl =
            "https://static-maps.yandex.ru/1.x/?ll=" + point +
            "&size=350,350&z=17&l=map&pt=" + point + ",pm2lbm&lang=ru-RU";

            Bitmap bitmap = DownloadMapImage(imageUrl);
            
            BitmapImage bitmapImage = ToBitmapImage(bitmap);
              
            image1.Source = bitmapImage;

            foto.Close();
        }

        // Получение GPS координат из EXIF
        public static string GetLatitude(System.Drawing.Image targetImg)
        {
            try
            {
                PropertyItem propItemRef = targetImg.GetPropertyItem(1);

                PropertyItem propItemLat = targetImg.GetPropertyItem(2);

                return ExifGpsToString(propItemRef, propItemLat);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        public static string GetLongitude(System.Drawing.Image targetImg)
        {
            try
            {
                //Property Item 0x0003 - PropertyTagGpsLongitudeRef
                PropertyItem propItemRef = targetImg.GetPropertyItem(3);
                //Property Item 0x0004 - PropertyTagGpsLongitude
                PropertyItem propItemLong = targetImg.GetPropertyItem(4);
                return ExifGpsToString(propItemRef, propItemLong);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        private static string ExifGpsToString(PropertyItem propItemRef, PropertyItem propItem)
        {
            double degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
            double degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
            double degrees = degreesNumerator / degreesDenominator;

            double minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
            double minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
            double minutes = minutesNumerator / minutesDenominator;

            double secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
            double secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
            double seconds = secondsNumerator / secondsDenominator;

            string gpsRef = System.Text.Encoding.ASCII.GetString(new byte[1] { propItemRef.Value[0] }); //N, S, E, or W
            string coorditate = String.Format("{0}°{1}'{2}''{3}",
                degrees.ToString(CultureInfo.InvariantCulture).Replace(",", "."),
                minutes.ToString(CultureInfo.InvariantCulture).Replace(",", "."),
                seconds.ToString(CultureInfo.InvariantCulture).Replace(",", "."), gpsRef);

            return coorditate;
        }

        //#endregion

        #region Address

        // Поиск объекта по координатам
        // name="latitude">Широта
        // name="longitude">Долгота
        public string SearchObject(string latitude, string longitude)
        {
            string urlXml = "https://geocode-maps.yandex.ru/1.x/?geocode= " + latitude + ", " + longitude +
                            " &results=1";

            string result = GetAddress(GetResponseToString(Get(urlXml)));
            return result;
        }

        public Stream Get(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            //Получение ответа.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responsestream = response.GetResponseStream();
            return responsestream;
        }

        public string GetResponseToString(Stream requestMetod)
        {
            using (StreamReader responseStreamReader = new StreamReader(requestMetod))
            {
                return responseStreamReader.ReadToEnd();
            }
        }

        // Получаем найденный адрес
        // Возвращает адрес
        public string GetAddress(string resultSearchObject)
        {
            string address = "";

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(resultSearchObject);

            XmlNodeList geoObjectTemp = xd.GetElementsByTagName("GeocoderMetaData");

            foreach (XmlNode node in geoObjectTemp)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    if (item.Name == "text")
                    {
                        address = item.LastChild.InnerText;
                        break;
                    }
                }
                break;
            }

            return address;
        }

        #endregion

        #region MapImage
        public string SearchMapImage(string latitude, string longitude)
        {
            string urlXml = "https://geocode-maps.yandex.ru/1.x/?geocode= " + latitude + ", " + longitude +
                            " &results=1";

            string result = GetGpsMap(GetResponseToString(Get(urlXml)));
            return result;
        }

        public string GetGpsMap(string resultSearchObject)
        {
            string point = "";

            XmlDocument xd = new XmlDocument();
            xd.LoadXml(resultSearchObject);

            XmlNodeList geoObjectTemp = xd.GetElementsByTagName("GeoObject");

            foreach (XmlNode node in geoObjectTemp)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    if (item.Name == "Point")
                    {
                        point = item.LastChild.InnerXml.Replace(' ', ',');
                    }
                }

                break;
            }

            return point;
        }
       
        public Bitmap DownloadMapImage(string imageUrl)
        {

            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            var bitmap = new Bitmap(stream ?? throw new InvalidOperationException());

            bitmap.Save("map.png", ImageFormat.Png);

            stream.Flush();
            stream.Close();
            client.Dispose();
            return bitmap;
        }

        #endregion

        public static BitmapImage ToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }
}