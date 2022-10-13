using CommonActions.Classes;
using CommonActions.Interfaces;
using Microsoft.VisualBasic;
using ServiceDownloadAPI.Classes;
using ServiceDownloadAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainFormWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string filesStoragePath { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean text box values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdClean_Click(object sender, RoutedEventArgs e)
        {
            url1Txt.Text = String.Empty;
            url2Txt.Text = String.Empty;
            url3Txt.Text = String.Empty;
        }

        /// <summary>
        /// Sends url to donwload files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdTransmit_Click(object sender, RoutedEventArgs e)
        {
            //Url1
            if (url1Txt.Text != String.Empty) 
            { 
                WebClient webClient1 = new WebClient();
                webClient1.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient1_OpenReadCompleted);
                Uri url1 = new Uri(url1Txt.Text);
                webClient1.OpenReadAsync(url1);
            }

            //Url2
            if (url2Txt.Text != String.Empty)
            {
                WebClient webClient2 = new WebClient();
                webClient2.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient2_OpenReadCompleted);
                Uri url2 = new Uri(url2Txt.Text);
                webClient2.OpenReadAsync(url2);
            }

            ////Url3
            if (url3Txt.Text != String.Empty)
            {
                WebClient webClient3 = new WebClient();
                webClient3.OpenReadCompleted += new OpenReadCompletedEventHandler(webClient3_OpenReadCompleted);
                Uri url3 = new Uri(url3Txt.Text);
                webClient3.OpenReadAsync(url3);
            }
        }

        /// <summary>
        /// For Url 1. Method that sends and match href tag for donwloading files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webClient1_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            IOpenReadHrefCompleted openReadCompleted = new OpenReadHrefCompleted();
            var arrResultObjects1 = openReadCompleted.OpenReadHrefCompleted(e, url1Txt.Text);
            TextReader TR = (TextReader)arrResultObjects1[0];
            MatchCollection MC = (MatchCollection)arrResultObjects1[1];

            foreach (Match match in MC)
            {
                IPrepareDownloadFilePath prepDownloadFile = new PrepareDownloadFilePath();
                var paths = prepDownloadFile.PrepareDownloadFilePath(match.Value, url1Txt.Text);
                DownloadFile(paths);
            }
            TR.Close();
        }

        /// <summary>
        /// For Url 2. Method that sends and match href tag for donwloading files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webClient2_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            IOpenReadHrefCompleted openReadCompleted = new OpenReadHrefCompleted();
            var arrResultObjects2 = openReadCompleted.OpenReadHrefCompleted(e, url2Txt.Text);
            TextReader TR = (TextReader)arrResultObjects2[0];
            MatchCollection MC = (MatchCollection)arrResultObjects2[1];

            foreach (Match match in MC)
            {
                IPrepareDownloadFilePath prepDownloadFile = new PrepareDownloadFilePath();
                var paths = prepDownloadFile.PrepareDownloadFilePath(match.Value, url2Txt.Text);
                DownloadFile(paths);
            }
            TR.Close();
        }

        /// <summary>
        /// For Url 3. Method that sends and match href tag for donwloading files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webClient3_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            IOpenReadHrefCompleted openReadCompleted = new OpenReadHrefCompleted();
            var arrResultObjects3 = openReadCompleted.OpenReadHrefCompleted(e, url3Txt.Text);
            TextReader TR = (TextReader)arrResultObjects3[0];
            MatchCollection MC = (MatchCollection)arrResultObjects3[1];

            foreach (Match match in MC)
            {
                IPrepareDownloadFilePath prepDownloadFile = new PrepareDownloadFilePath();
                var paths = prepDownloadFile.PrepareDownloadFilePath(match.Value, url3Txt.Text);
                DownloadFile(paths);
            }
            TR.Close();
        }

        /// <summary>
        /// Method that send a specific file path and download to a specific directory
        /// </summary>
        /// <param name="paths"></param>
        private void DownloadFile(string[] paths)
        {
            string cadena = paths[0];
            string tempPath = paths[1];
            string directory = paths[2];
            string web = paths[3];
            string host = paths[4];
            IReadLocalPath ReadLocalPath = new ReadLocalPath();
            

            if (!string.IsNullOrEmpty(cadena))
            {
                string currentTempPath = web + tempPath + cadena;
                var pathToSace = @""+ ReadLocalPath.GetLocalPathValue()+ "\\" + host + directory;

                WebClient webClient1 = new WebClient();
                webClient1.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient1.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                if (!Directory.Exists(pathToSace))
                {
                    Directory.CreateDirectory(pathToSace);
                }
                string fileStoraged = pathToSace + currentTempPath.Split('/')[currentTempPath.Split('/').Length - 1];
                this.filesStoragePath = pathToSace;
                webClient1.DownloadFileAsync(new Uri(currentTempPath), fileStoraged);
            }
        }

        /// <summary>
        /// Catches the download progress of each file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            messageProgressVarLbl.Text = e.ProgressPercentage.ToString();
        }

        /// <summary>
        /// Catches final the finish of a download
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            IWriteFilesDetailsFromDirectory detailInfo = new WriteFilesDetailsFromDirectory();
            detailInfo.WriteFilesDetails(this.filesStoragePath);
        }

        /// <summary>
        /// Open a window dialog frame to set configurations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSet_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Add(new SetUserControl());
           
        }

        /// <summary>
        /// Verify a valid url on focus lost event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void url1Txt_LostFocus(object sender, RoutedEventArgs e)
        {
            verifyUrlPattern(url1Txt);
        }

        /// <summary>
        /// Verify a valid url on focus lost event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void url2Txt_LostFocus(object sender, RoutedEventArgs e)
        {
            verifyUrlPattern(url2Txt);
        }

        /// <summary>
        /// Verify a valid url on focus lost event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void url3Txt_LostFocus(object sender, RoutedEventArgs e)
        {
            verifyUrlPattern(url3Txt);
        }

        /// <summary>
        /// Method that calls a verification method to match a url structure
        /// </summary>
        /// <param name="urlTxt"></param>
        private void verifyUrlPattern(TextBox urlTxt)
        {
            IVerifyUrlPattern verifcUrl = new VerifyUrlPattern();
            if (urlTxt.Text != String.Empty)
            {
                var result = verifcUrl.IsValidUrl(urlTxt.Text);
                if (!result)
                {
                    IErrorCodeHandler errCodeDesc = new LocalErrorCodeHandler();
                    MessageBox.Show(errCodeDesc.GetErrorMessageFromCode(406), "Error 406");
                    urlTxt.Text = String.Empty;
                }
            }
        }

    }
}
