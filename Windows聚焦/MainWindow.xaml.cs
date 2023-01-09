using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Windows聚焦
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string path1 = "C:/Users/iamca/AppData/Local/Packages/Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy/LocalState/Assets/";
            string path2 = "D:/CODE/Visual Studio/Windows聚焦/image/";



            DirectoryInfo dir1 = new DirectoryInfo(path1);
            FileSystemInfo[] all = dir1.GetFileSystemInfos();

            int i = 1;
            foreach (FileSystemInfo file in all)
            {
                var image = new BitmapImage(new Uri(file.FullName));

                
                if (image.Width == 1920 && image.Height == 1080)
                {
                    if (i == 1)
                    {
                        Image1.Source = new BitmapImage(new Uri(file.FullName));
                        text1.Text = file.CreationTime.ToString();
                    }
                    else if(i==2)
                    {
                        Image2.Source = new BitmapImage(new Uri(file.FullName));
                        text2.Text = file.CreationTime.ToString();
                    }
                    else if(i==3)
                    {
                        Image3.Source = new BitmapImage(new Uri(file.FullName));
                        text3.Text = file.CreationTime.ToString();
                    }
                    else
                    {
                        Image4.Source = new BitmapImage(new Uri(file.FullName));
                        text4.Text = file.CreationTime.ToString();
                    }

                    string newName = file.CreationTime.ToString();
                    newName = newName.Replace("/", "-");
                    newName = newName.Replace(":", "-");
                    
                    File.Copy(file.FullName, path2 + newName + "_" + i.ToString() + ".jpg");

                    i++;
                }


                //textbox1.Text = image.Width.ToString();
            }
        }

        

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            string path2 = "D:/CODE/Visual Studio/Windows聚焦/image/";
            string path3 = "D:/iamca/Pictures/Camera Roll/Windows聚焦/";

            DirectoryInfo dir2 = new DirectoryInfo(path2);
            FileSystemInfo[] all = dir2.GetFileSystemInfos();

            foreach (FileSystemInfo file in all)
            { 
                File.Move(file.FullName, path3 + file.Name);
            }

            text5.Text = "√ 已保存";
        }
    }
}
