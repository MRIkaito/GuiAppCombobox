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

namespace GuiApp
{
    /// <summary>
    /// SignalControlWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SignalControlWindow : Window
    {
        // インスタンス
        SignalOutputViewModel SignalControlViewModel = new SignalOutputViewModel();


        // コンストラクタ
        public SignalControlWindow()
        {
            InitializeComponent();

            // データ元の設定
            this.DataContext = SignalControlViewModel;
        }


        // コンボボックス選択時のイベントハンドラ
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 各コンボボックスのインスタンスを取得
            var cmbbox = (ComboBox)sender;
            SignalControlViewModel.ComboBoxCommand(cmbbox);
        }


        // キャンセルボタン押下時のイベントハンドラ
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            SignalControlViewModel.CancelButtonCommand();
        }
    }
}


















        ///// <summary>
        ///// 「制御方式」コンボボックスのイベントドリブン
        ///// </summary>
        //private void outputComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    // コンボボックスの選択された制御方式
        //    // "制御なし", "瞬時値", "sin波", "時系列", "三角波", "矩形波"
        //    //　の情報を渡す
        //    ComboBox comboBox = (ComboBox)sender;
        //    ComboBoxItem selected_item = (ComboBoxItem)comboBox.SelectedItem;
        //    int comobo_box_id = int.Parse(comboBox.Uid);
        //    SignalControlViewModel.OutputComboBoxCommand(selected_item, comobo_box_id);
        //}


        ///// <summary>
        ///// 「詳細」ボタンのイベントドリブン
        ///// </summary>
        //private void digitalDetailButtonClick(object sender, RoutedEventArgs e)
        //{
        //    SignalControlViewModel.DigitalDetailButtonCommand();
        //}