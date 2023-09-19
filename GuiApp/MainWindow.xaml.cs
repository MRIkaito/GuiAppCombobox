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
using GuiApp.ViewModel;

namespace GuiApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// インスタンス化
        /// ViewModelオブジェクトの生成
        /// </summary>
        MainWindowViewModel MainWindowViewModel = new MainWindowViewModel();


        /// <summary>
        /// コンストラクタ
        /// MainWindow(View)のデータ元の設定
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MainWindowViewModel;
        }


        /// <summary>
        /// 「通信開始」ボタン押下時のイベントドリブン
        /// </summary>
        private void CommunicationButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.CommunicatonButtonCommand();
        }


        /// <summary>
        /// 「制御」ボタン押下時のイベントドリブン
        /// </summary>
        private void OutputButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.OutputButtonCommand();
        }

    }
}