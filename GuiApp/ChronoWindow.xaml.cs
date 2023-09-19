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
using System.Windows.Shapes;
using System.IO;

namespace GuiApp
{
    /// <summary>
    /// ChronoWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ChronoWindow : Window
    {

        /// <summary>
        /// インスタンス化
        /// ViewModelオブジェクトを作成
        /// </summary> 
        ChronoViewModel ChronoViewModel = new ChronoViewModel();


        /// <summary>
        /// コンストラクタ
        /// ChronoWindow(View)のデータ元の設定
        /// </summary>
        public ChronoWindow()
        {
            InitializeComponent();
            this.DataContext = ChronoViewModel;
        }


        /// <summary>
        /// 「CSVファイル読み込み」のボタン押下時イベント
        /// </summary>
        private void CsvButton_Click(object sender, RoutedEventArgs e)
        {
            // "ChronoWindow.xaml"「CSVファイル読み込み」ボタンの,
            // "x:Name ="CsvFileLoad"" プロパティ情報を通知
            // 理由：ボタンのx:Nameで、ファイル読み込み時の拡張子を指定
            // 詳細：OutputSignalModel
            Button csvButton = (Button)sender;
            ChronoViewModel.CsvButtonCommand(csvButton.Name);
        }

    }
}
