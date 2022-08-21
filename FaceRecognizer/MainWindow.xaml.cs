using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace FaceRecognizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Load sample data
            
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                string directoryPath = System.IO.Path.GetDirectoryName(op.FileName);
                var imageBytes = File.ReadAllBytes(op.FileName);
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                MLModel2.ModelInput sampleData = new MLModel2.ModelInput()
                {
                    ImageSource = op.FileName,
                };

                //Load model and predict output
                var result = MLModel2.Predict(sampleData);
                
                if (result.Prediction == "Bill Gates")
                {
                    leeel.Text = result.Prediction;
                    leeel2.Text = CheckBiggestPossibility(result.Score);
                }
                else
                {
                    leeel.Text = result.Prediction;
                    leeel2.Text = CheckBiggestPossibility(result.Score);
                }

            }

        }
        private string CheckBiggestPossibility(float[] scoreTab)
        {
            var biggestScore = 0f;
            string biggestScoreS = "0";
            for (int i = 0; i < scoreTab.Length; i++)
            {
                if(scoreTab[i] > biggestScore)
                biggestScore = scoreTab[i];
            }
            biggestScoreS = (Math.Round(biggestScore, 2) * 100).ToString() + " %";
            return biggestScoreS;
        }

        
    }
}
