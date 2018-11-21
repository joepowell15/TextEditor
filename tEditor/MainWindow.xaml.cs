﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ICSharpCode.AvalonEdit;
using System.IO;
using System.Reflection;

namespace tEditor
{
    public static class MyStaticValues
    {
        public static string myStaticFile { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //this is needed so we can access the main window and its functions from other classes
        public static MainWindow mainWindow;

        public MainWindow()
        {
            //immediately hides the main window and only shows the creation screen
            InitializeComponent();
            init();
            this.Visibility = Visibility.Hidden;
            new pCreate().Show();
           
            
            
            //this is needed so we can access the main window and its functions from other classes
            mainWindow = this;
        }
        //this function add in hello world c++ code
        public void setTheme(string theme)
        {
            if (theme == "dark")
            {
                Uri uri3 = new Uri("Themes/MetroDark/MetroDark.MSControls.Core.Implicit.xaml", UriKind.RelativeOrAbsolute);
                Uri uri4 = new Uri("Themes/MetroDark/MetroDark.MSControls.Toolkit.Implicit.xaml", UriKind.RelativeOrAbsolute);
                ThemeDictionary.MergedDictionaries.Clear();
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri3 });
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri4 });
                var brush = new SolidColorBrush(Color.FromArgb(255, (byte)45, (byte)45, (byte)48));
                var brush2 = new SolidColorBrush(Color.FromArgb(255, (byte)104, (byte)104, (byte)119));
                Grid.Background = brush;
                menu.Foreground = Brushes.White;
                Tlbar.Background = brush;
                menu.Background = brush;
                Tray.Background = brush;
                tabControl.Background = brush;
                editor.Background = brush;
                file.Foreground = Brushes.White;
                edit.Foreground = Brushes.White;
                NFuncFile.Foreground = Brushes.White;
                tbtnimg.Source = new BitmapImage(new Uri("/Resources/invtheme.png", UriKind.RelativeOrAbsolute));
            }
            else if(theme=="light")
            {
                Uri uri = new Uri("Themes/Metro/Metro.MSControls.Core.Implicit.xaml", UriKind.RelativeOrAbsolute);
                Uri uri2 = new Uri("Themes/Metro/Metro.MSControls.Toolkit.Implicit.xaml", UriKind.RelativeOrAbsolute);
                ThemeDictionary.MergedDictionaries.Clear();
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri2 });
                var brush = new SolidColorBrush(Color.FromArgb(255, (byte)45, (byte)45, (byte)48));
                Tray.Background = Brushes.White;
                Grid.Background = brush;
                Grid.Background = Brushes.White;
                menu.Foreground = brush;
                menu.Background = Brushes.White;
                Tlbar.Background = Brushes.White;
                tabControl.Background = brush;
                editor.Background = Brushes.White;
                file.Foreground = Brushes.Black;
                edit.Foreground = Brushes.Black;
                NFuncFile.Foreground = Brushes.Black;
                tbtnimg.Source = new BitmapImage(new Uri("/Resources/theme.png", UriKind.RelativeOrAbsolute));
            }
        }
        private void ThemeChng_Click(object sender, RoutedEventArgs e)
        {
            //if light theme found, set to dark
            if (ThemeDictionary.MergedDictionaries[0].Source.ToString().Equals("Themes/Metro/Metro.MSControls.Core.Implicit.xaml"))
            {
                Uri uri3 = new Uri("Themes/MetroDark/MetroDark.MSControls.Core.Implicit.xaml", UriKind.RelativeOrAbsolute);
                Uri uri4 = new Uri("Themes/MetroDark/MetroDark.MSControls.Toolkit.Implicit.xaml", UriKind.RelativeOrAbsolute);
                ThemeDictionary.MergedDictionaries.Clear();
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri3 });
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri4 });
                var brush = new SolidColorBrush(Color.FromArgb(255, (byte)45, (byte)45, (byte)48));
                var brush2 = new SolidColorBrush(Color.FromArgb(255, (byte)104, (byte)104, (byte)119));
                Grid.Background = brush;
                menu.Foreground = Brushes.White;
                Tlbar.Background = brush;
                menu.Background = brush;
                Tray.Background = brush;
                tabControl.Background = brush;
                editor.Background = brush;
                file.Foreground = Brushes.White;
                edit.Foreground = Brushes.White;
                NFuncFile.Foreground = Brushes.White;
                tbtnimg.Source= new BitmapImage(new Uri("/Resources/invtheme.png", UriKind.RelativeOrAbsolute));
            }

            //else set to light theme
            else
            {
                Uri uri = new Uri("Themes/Metro/Metro.MSControls.Core.Implicit.xaml", UriKind.RelativeOrAbsolute);
                Uri uri2 = new Uri("Themes/Metro/Metro.MSControls.Toolkit.Implicit.xaml", UriKind.RelativeOrAbsolute);
                ThemeDictionary.MergedDictionaries.Clear();
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri2 });
                var brush = new SolidColorBrush(Color.FromArgb(255, (byte)45, (byte)45, (byte)48));
                Tray.Background = Brushes.White;
                Grid.Background = brush;
                Grid.Background = Brushes.White;
                menu.Foreground = brush;
                menu.Background = Brushes.White;
                Tlbar.Background = Brushes.White;
                tabControl.Background = brush;
                editor.Background = Brushes.White;
                file.Foreground = Brushes.Black;
                edit.Foreground = Brushes.Black;
                NFuncFile.Foreground = Brushes.Black;
                tbtnimg.Source = new BitmapImage(new Uri("/Resources/theme.png", UriKind.RelativeOrAbsolute));
            }
        }
        public void setAva(string name, string text, string path)
        {
            tab1.Header = name;
            editor.Text = text;
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path, true))
            {
                file.WriteLine(editor.Text);
            }
        }

      

        private void openf()
        {

        var fileContent = string.Empty;
        var filePath = string.Empty;
        var openFileDialog1 = new OpenFileDialog();
        openFileDialog1.Filter = "C++ Files|*.c*";
            openFileDialog1.Title = "Select a C++ or Cpp File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog1.FileName;
                MyStaticValues.myStaticFile = filePath;
                //Read the contents of the file into a stream
                var fileStream = openFileDialog1.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                    editor.Text = fileContent;
                }
            }
        }

        private void openfile_Click(object sender, RoutedEventArgs e)
        {
            openf();
           
        }

        private void NewFunc_Click(object sender, RoutedEventArgs e)
        {
            new pCreate().Show();
        }

        private void OpenFile_Click_1(object sender, RoutedEventArgs e)
        {
            openf();
        }

        private void SaveFunc_Click(object sender, RoutedEventArgs e)
        {
            string filename = MyStaticValues.myStaticFile;
            System.IO.File.WriteAllText(filename, editor.Text);
            
        }

        private void savefile_Click(object sender, RoutedEventArgs e)
        {

            string filename = MyStaticValues.myStaticFile;
            System.IO.File.WriteAllText(filename, editor.Text);
        }

        private void newProj_Click(object sender, RoutedEventArgs e)
        {
            new pCreate().Show();
        }

        private void newFile_Click(object sender, RoutedEventArgs e)
        {


        }
        private void init()
        {
            editor.Options.InheritWordWrapIndentation = true;
            editor.Options.HighlightCurrentLine = true;
            inttxt.Text=Properties.Resources.integer_variables;
            dbltxt.Text = Properties.Resources.double_variables;
            flttxt.Text = Properties.Resources.float_variables;
            chrtxt.Text = Properties.Resources.character_variables;
            booltxt.Text = Properties.Resources.boolean_variables;
            rectxt.Text = Properties.Resources.recursive_functions;
            rettxt.Text = Properties.Resources.returning_functions;
            voitxt.Text = Properties.Resources.void_functions;
            poitxt.Text = Properties.Resources.pointers;
            memtxt.Text = Properties.Resources.memory_allocation;
            int offset = editor.CaretOffset;
            var line = editor.Document.GetLineByOffset(offset);

            sText.Text = line.ToString();


        }


        public void Expanded(object sender, RoutedEventArgs e)
        {
            var exp = (Expander)sender;
            exp1.Visibility = Visibility.Collapsed;
            exp2.Visibility = Visibility.Collapsed;
            exp3.Visibility = Visibility.Collapsed;
            exp4.Visibility = Visibility.Collapsed;
            exp5.Visibility = Visibility.Collapsed;
            exp6.Visibility = Visibility.Collapsed;
            exp7.Visibility = Visibility.Collapsed;
            exp8.Visibility = Visibility.Collapsed;
            exp9.Visibility = Visibility.Collapsed;
            exp10.Visibility = Visibility.Collapsed;
            exp.Visibility = Visibility.Visible;
        }

        private void Collapsed(object sender, RoutedEventArgs e)
        {
            exp1.Visibility = Visibility.Visible;
            exp2.Visibility = Visibility.Visible;
            exp3.Visibility = Visibility.Visible;
            exp4.Visibility = Visibility.Visible;
            exp5.Visibility = Visibility.Visible;
            exp6.Visibility = Visibility.Visible;
            exp7.Visibility = Visibility.Visible;
            exp8.Visibility = Visibility.Visible;
            exp9.Visibility = Visibility.Visible;
            exp10.Visibility = Visibility.Visible;
        }

        private void editor_TextChanged(object sender, EventArgs e)
        {
            int offset = editor.CaretOffset;
            var line = editor.Document.GetLineByOffset(offset);

            sText.Text =line.ToString();
           
            
        }
    }
}
