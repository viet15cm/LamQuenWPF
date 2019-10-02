﻿using System;
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
using System.IO;
using Microsoft.Win32;
namespace LamQuenWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ContextMenu windowContextMenu = null;

        private string[] towers = { "Great Shevington", "Little Mudford",
                                "Upper Gumtree", "Downley Hatch" };

        private string[] ringingMethods = { "Plain Bob", "Reverse Canterbury",
                                "Grandsire", "Stedman", "Kent Treble Bob", "Old Oxford Delight",
                                             "Winchendon Place", "Norwich Surprise", "Crayford Little Court" };


        public MainWindow()
        {
            InitializeComponent();

            this.Reset();
            MenuItem saveMemberMenuItem = new MenuItem();
            saveMemberMenuItem.Header = "Save Member Details";
            saveMemberMenuItem.Click += new RoutedEventHandler(saveMember_Click);
            MenuItem clearFormMenuItem = new MenuItem();
            clearFormMenuItem.Header = "Clear Form";
            clearFormMenuItem.Click += new RoutedEventHandler(Clear_Click);
            windowContextMenu = new ContextMenu();
            windowContextMenu.Items.Add(saveMemberMenuItem);
            windowContextMenu.Items.Add(clearFormMenuItem);

        }

        public void Reset()
        {
            firstName.Text = String.Empty;
            lastName.Text = String.Empty;

            towerNames.Items.Clear();
            foreach (string towerName in towers)
            {
                towerNames.Items.Add(towerName);
            }
            towerNames.Text = towerNames.Items[0] as string;

            towerNames.Items.Clear();
            foreach (string towerName in towers)
            {
                towerNames.Items.Add(towerName);
            }
            towerNames.Text = towerNames.Items[0] as string;

            methods.Items.Clear();
            CheckBox method = null;
            foreach (string methodName in ringingMethods)
            {
                method = new CheckBox();
                method.Margin = new Thickness(0, 0, 0, 10);
                method.Content = methodName;
                methods.Items.Add(method);
            }

            isCaptain.IsChecked = false;
            novice.IsChecked = true;

        }

        private void newMember_Click(object sender, RoutedEventArgs e)
        {
            this.Reset();
            saveMember.IsEnabled = true;
            firstName.IsEnabled = true;
            lastName.IsEnabled = true;
            towerNames.IsEnabled = true;
            isCaptain.IsEnabled = true;
            memberSince.IsEnabled = true;
            yearsExperience.IsEnabled = true;
            methods.IsEnabled = true;
            clear.IsEnabled = true;

           this.ContextMenu = windowContextMenu;
            
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveMember_Click(object sender, RoutedEventArgs e)

        {

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "txt";
            saveDialog.AddExtension = true;
            saveDialog.FileName = "Members";
            saveDialog.InitialDirectory = @"E:\Filetxtc#\";
            saveDialog.OverwritePrompt = true;
            saveDialog.Title = "Bell Ringers";
            saveDialog.ValidateNames = true;

            if (saveDialog.ShowDialog().Value)
            {
                 using (StreamWriter writer = new StreamWriter(saveDialog.FileName))

                {


                    writer.WriteLine("First Name: {0}", firstName.Text);

                    writer.WriteLine("Last Name: {0}", lastName.Text);

                    writer.WriteLine("Tower: {0}", towerNames.Text);

                    writer.WriteLine("Captain: {0}", isCaptain.IsChecked.ToString());

                    writer.WriteLine("Member Since: {0}", memberSince.Text);

                    writer.WriteLine("Methods: ");

                    foreach (CheckBox cb in methods.Items)

                    {

                        if (cb.IsChecked.Value)

                        {

                            writer.WriteLine(cb.Content.ToString());

                        }

                    }

                    MessageBox.Show("Member details saved", "Saved");

                }
            }

        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.ShowDialog();
        }

        private void clearName_Click(object sender, RoutedEventArgs e)
        {
            firstName.Clear();
            lastName.Clear();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
    }
}
