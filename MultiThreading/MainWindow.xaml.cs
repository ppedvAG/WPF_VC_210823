using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MultiThreading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public int Counter { get; set; } = 0;

        private int progressState;
        public int ProgressState
        {
            get { return progressState; }
            set
            {
                progressState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProgressState)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();

            // Async aus Sync aufrufen
            // https://docs.microsoft.com/en-us/archive/msdn-magazine/2015/july/async-programming-brownfield-async-development#the-blocking-hack
            Task.Run(SomeMethod);

            DataContext = this;

            HideStatusBar();

            Tbl_LongTask.Text = "Status";
            Tbl_ShortTask.Text = "Count";
        }

        private async void SomeMethod() { }

        private void HideStatusBar()
        {
            Pgb_Status.Visibility = Visibility.Hidden;
        }

        private async void Btn_LongTask_Click(object sender, RoutedEventArgs e)
        {
            Btn_LongTask.IsEnabled = false;

            Pgb_Status.Visibility = Visibility.Visible;

            // Exception Handling
            //string taskResult;

            //try
            //{
            //    taskResult = await Task.Run(() => {
            //        Thread.Sleep(2000);

            //            //throw new Exception("test exception");

            //        return "Long Task Completed";
            //    });                
            //}
            //catch (Exception ex)
            //{
            //    taskResult = ex.Message;
            //}

            //Tbl_LongTask.Text = taskResult;

            // Mehrere Tasks starten
            var task1 = Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "Long Task 1 Completed";
            });
            var task2 = Task.Run(() =>
            {
                Thread.Sleep(3000);
                return "Long Task 2 Completed";
            });
            var task3 = Task.Run(() =>
            {
                Thread.Sleep(4000);
                return "Long Task 3 Completed";
            });

            string[] results = await Task.WhenAll(task1, task2, task3);
                        
            Tbl_LongTask.Text = $"Completed: {string.Join(", ", results)}";

            Btn_LongTask.IsEnabled = true;
            HideStatusBar();
        }

        private void Btn_ShortTask_Click(object sender, RoutedEventArgs e)
        {
            Counter += 1;
            Tbl_ShortTask.Text = Counter.ToString();
        }

        private async void Btn_LongTask2_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(100);
                    ProgressState = i;
                }

                MessageBox.Show("LongTask2 is done...");
            });
        }

        private void Btn_Sound_Click(object sender, RoutedEventArgs e)
        {
            //PlaySystemSounds();

            PlayMp3();
        }

        private static void PlaySystemSounds()
        {
            SystemSounds.Beep.Play();
            //SystemSounds.Hand.Play();
        }

        private static void PlayMp3()
        {
            MediaPlayer mediaPlayer = new MediaPlayer();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                mediaPlayer.Open(new Uri(openFileDialog.FileName));
                mediaPlayer.Play();
            }
        }

    }
}
