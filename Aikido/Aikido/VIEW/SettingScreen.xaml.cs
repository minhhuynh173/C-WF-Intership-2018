﻿using Aikido.BLO;
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
using Aikido.BLO;
namespace Aikido.VIEW
{
    /// <summary>
    /// Interaction logic for SettingScreen.xaml
    /// </summary>
    public partial class SettingScreen : Window
    {
        SettingImage_BLO settingImage_BLO= new SettingImage_BLO();
        byte[] arrImage = null;
        private List<bool> btnSelect = new List<bool>();
        //Cóntructor
        public SettingScreen()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                btnSelect.Add(true);
            }
            btnSelect[4] = false;
          
            ImageBrush x= settingImage_BLO.GetImage_FromDB();
            if (x != null) { checkboxDefault.IsChecked = false; }
            else checkboxDefault.IsChecked =true;
            ImageButton.Background = x;

        }

        // Evant Handles
        private void Image_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ImageBrush image = settingImage_BLO.LoadImage_Button();
                if (image == null) return;
                ImageButton.Background = image;
                arrImage = settingImage_BLO.ConvertImage_ToBytes(image.ImageSource);
                checkboxDefault.IsChecked = false;
                
            }
            catch { MessageBox.Show("Ảnh không hợp lệ", "Lỗi"); }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                SettingImage_BLO settingImage_BLO = new SettingImage_BLO();
                settingImage_BLO.SaveImage_ToDB(arrImage);
                MessageBox.Show("Lưu thành công");
            }
            catch
            {
                MessageBox.Show("Lưu không thành công", "Lỗi");
            }
        }

        private void checkboxDefault_Checked(object sender, RoutedEventArgs e)
        {
            arrImage = null;
            checkboxDefault.IsChecked = true;
            ImageButton.Background= Brushes.WhiteSmoke;
        }

        private void checkboxDefault_Unchecked(object sende, RoutedEventArgs ee)
        {
            if (arrImage != null) return;
            Image_Click(sende, ee);
        }

        //------------------------------Tab Menu 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDKHV_MouseEnter(object sender, MouseEventArgs e)
        {
            btnDKHVb.Background = Brushes.DarkBlue;
            btnDKHV.Background = Brushes.LightGray;
        }

        private void btnDKHV_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[0] == true)
            {
                btnDKHVb.Background = Brushes.White;
                btnDKHV.Background = Brushes.White;
            }
        }

        private void btnSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            btnSearchb.Background = Brushes.DarkBlue;
            btnSearch.Background = Brushes.LightGray;
            btnSearchC.Visibility = Visibility.Visible;
            btnSearchQ.Visibility = Visibility.Visible;
        }

        private void btnSearch_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[1] == true)
            {
                btnSearch.Background = Brushes.White;
            }
        }

        private void btnQLHP_MouseEnter(object sender, MouseEventArgs e)
        {
            btnQLHPb.Background = Brushes.DarkBlue;
            btnQLHP.Background = Brushes.LightGray;
        }

        private void btnQLHP_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[2] == true)
            {
                btnQLHPb.Background = Brushes.White;
                btnQLHP.Background = Brushes.White;
            }
        }

        private void btnQLL_MouseEnter(object sender, MouseEventArgs e)
        {
            btnQLLb.Background = Brushes.DarkBlue;
            btnQLL.Background = Brushes.LightGray;
        }

        private void btnQLL_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[3] == true)
            {
                btnQLLb.Background = Brushes.White;
                btnQLL.Background = Brushes.White;
            }
        }

        private void btnTL_MouseEnter(object sender, MouseEventArgs e)
        {
            btnTLb.Background = Brushes.DarkBlue;
            btnTL.Background = Brushes.LightGray;
        }

        private void btnTL_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[4] == true)
            {
                btnTLb.Background = Brushes.White;
                btnTL.Background = Brushes.White;
            }
        }

        private void btnDKHV_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegisterMemberScreen rgm = new RegisterMemberScreen();
            rgm.Show();
            this.Close();
        }

        private void btnSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnQLHP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FeeScreen fs = new FeeScreen();
            fs.Show();
            this.Close();
        }

        private void btnQLL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ClassScreen cs = new ClassScreen();
            cs.Show();
            this.Close();
        }

        private void btnTL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //SettingScreen sc = new SettingScreen();
            //sc.Show();
            //this.Close();
        }

        private void btnSearchQ_MouseEnter(object sender, MouseEventArgs e)
        {
            btnSearchb.Background = Brushes.DarkBlue;
            if (btnSelect[1] == false)
            {
                btnSearchQ.Background = Brushes.LightGray;
                btnSearchC.Background = Brushes.White;
            }
            else btnSearchQ.Background = Brushes.LightGray;
        }

        private void btnSearchQ_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[1] == true)
            {
                btnSearchQ.Background = Brushes.White;
                btnSearchb.Background = Brushes.White;
            }
            btnSearchQ.Visibility = Visibility.Hidden;
            btnSearchC.Visibility = Visibility.Hidden;
        }

        private void btnSearchQ_MouseDown(object sender, MouseButtonEventArgs e)
        {
            QuickSearch qs = new QuickSearch();
            qs.Show();
            this.Close();
        }

        private void btnSearchC_MouseEnter(object sender, MouseEventArgs e)
        {
            if (btnSelect[1] == false)
            {
                btnSearchC.Background = Brushes.LightGray;
                btnSearchQ.Background = Brushes.White;
            }
            else btnSearchC.Background = Brushes.LightGray;
            btnSearchb.Background = Brushes.DarkBlue;

        }

        private void btnSearchC_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[1] == true)
            {
                btnSearchC.Background = Brushes.White;
                btnSearchb.Background = Brushes.White;
            }
            btnSearchQ.Visibility = Visibility.Hidden;
            btnSearchC.Visibility = Visibility.Hidden;

        }

        private void btnSearchC_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SearchCondition sc = new SearchCondition();
            sc.Show();
            this.Close();
        }

        
    }
}