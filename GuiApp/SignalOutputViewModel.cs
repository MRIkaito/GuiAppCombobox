using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GuiApp
{
    abstract class ViewModelBase : INotifyPropertyChanged
    {
        // プロパティの変更通知
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(name));
        }
    }


    internal class SignalOutputViewModel : ViewModelBase
    {
        // 電卓クラスのインスタンス化
        SignalOutputModel SignalOutputModel = new SignalOutputModel();


        // コンボボックステキスト表示
        // 制御方式のプロパティ
        public static string[] Tmp_HowToOutput { get; set; } = { "制御なし",    // Digtal1
                                                              "制御なし",       // Digital2
                                                              "制御なし",
                                                              "制御なし",
                                                              "制御なし",
                                                              "制御なし",
                                                              "制御なし",
                                                              "制御なし",
                                                              "制御なし",
                                                              "制御なし",
                                                              "制御なし",       // PWM1
                                                              "制御なし",       // PWM2
                                                              "制御なし",       // PWM3
                                                              "制御なし",       // Analog1
                                                              "制御なし"};      // Analog2

        // コンボボックス選択肢
        // デジタル制御方式の選択肢のプロパティ・ItemsSource="{Binding Path=DigitalOutputItems, Mode=OneWay}" 
        public static string[] DigitalOutputItems { get; set; } = { "制御なし", "瞬時値", "時系列" };
        // PWM、アナログ制御方式の選択肢のプロパティ・ItemsSource="{Binding Path=PwmAnalogOutputItems, Mode=OneWay}" 
        public static string[] PwmAnalogOutputItems { get; set; } = { "制御なし", "瞬時値", "時系列", "sin波", "三角波", "矩形波" };


        // コンボボックス選択時のコマンド
        public void ComboBoxCommand(ComboBox cmbbox)
        {
            // (n)行目の制御方式に(n-1)番のUid(ID番号) 割振済み
            int cmbboxID = int.Parse(cmbbox.Uid);

            // 選択された項目を文字列に変換
            string cmbboxItem = (cmbbox.SelectedItem).ToString();
            
            // 表示するコンボボックスTextに、選択されたものを表示
            Tmp_HowToOutput[cmbboxID] = cmbboxItem;


        }


        // キャンセルボタン押下時のコマンド
        public void CancelButtonCommand()
        {
            // 当ViewModelにある一時保存用 Tmp_データに、SignalOutputModelにある送信・キャンセル用 Ctrl_データを代入
            for(int i = 0; i < 15; i++)
            {
                Tmp_HowToOutput[i] = SignalOutputModel.Ctrl_HowToOutput[i];
            }

            OnPropertyChanged(nameof(Tmp_HowToOutput));

        }


    }

}


























        //public static string Digital1 = "制御なし";
        //public static string Digital2 = "制御なし";

        //public static string[] tmpCtrlHowtomethod = new string[]
        //{
        //        "制御なし",
        //        "制御なし",
        //        "制御なし",
        //        "制御なし",
        //        "制御なし",
        //        "制御なし",
        //        "制御なし",
        //        "制御なし",
        //        "制御なし",
        //        "制御なし",
        //        "制御なし",
        //        "制御なし",
        //        "制御なし",
        //        "制御なし",
        //        "制御なし",
        //};

        //public static string[] TmpCtrlHowtomethod
        //{
        //    get;
        //    set;
        //}



        //public static float[] tmp_Ctrl_RealtimeValue = new float[]
        //{
        //    0, 
        //    0, 
        //    0, 
        //    0,
        //    0,
        //    0,
        //    0,
        //    0,
        //    0,
        //    0,
        //    0,
        //    0,
        //    0,
        //    0,
        //    0,
        //};


        ///// <summary>
        ///// プロパティ：HowToOutput
        ///// "制御なし","時系列", "sin波", "三角波", "矩形波"
        ///// static で、呼び出されるたび初期値の上書きを防ぐ
        ///// </summary>
        //public static string HowToOutput { get; set; } = "制御なし";


        ///* 
        //* --------------------------------------------------------------------
        //// 名称：outputComboBoxCommand
        //// 概要：「制御方式」コンボボックスを変更したとき 機能するメソッド
        ////       制御方式を選択し、HowToOutputプロパティに格納
        ////       DetailButtonCommand(詳細ボタン押下時コマンド)で、画面遷移する
        ////       条件分岐のために使用する
        //// 引数 selectedItem："制御なし" , "sin波"…などの制御方式の名称
        //// 返り値：なし
        //*--------------------------------------------------------------------
        //*/
        //public void OutputComboBoxCommand(ComboBoxItem selected_item, int combo_box_id)
        //{
        //    // コンボボックスで選択された項目を string型へキャスト
        //    tmpCtrlHowtomethod[combo_box_id] = selected_item.Content.ToString();
        //}

        ///* 
        //* --------------------------------------------------------------------
        //// 名称：DetailButtonCommand
        //// 概要：「詳細」ボタンを押下した時 機能するメソッド
        ////       制御方式によって、遷移する画面を変更する
        //// 引数：なし
        //// 返り値：なし
        //*--------------------------------------------------------------------
        //*/
        //public void DigitalDetailButtonCommand()
        //{
        //    // 制御方式(HowToOutput)によって遷移先画面が分岐
        //    if (HowToOutput == "制御なし" || HowToOutput == "瞬時値")
        //    {
        //        // DO NOTHING
        //    }
        //    //else if (HowToOutput == "sin波")
        //    //{
        //    //    SinWaveWindow sinWaveWindow = new SinWaveWindow();
        //    //    sinWaveWindow.Show();
        //    //}
        //    else if (HowToOutput == "時系列")
        //    {
        //        ChronoWindow chronoWindow = new ChronoWindow();
        //        chronoWindow.Show();
        //    }
        //    else
        //    {
        //        // DO NOTHING
        //        // 本来それぞれの制御画面に遷移
        //    }
        //}