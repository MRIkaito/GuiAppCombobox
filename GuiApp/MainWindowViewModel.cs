using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace GuiApp.ViewModel
{

    /// <summary>
    /// ViewModelからViewに, プロパティ変更・更新されたことを知らせるクラス・メソッド
    /// </summary.
    abstract class ViewModelBase : INotifyPropertyChanged
    {

        // プロパティ変更通知
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// プロパティ変更が生じるクラスはViewModelBaseクラスを継承することで、以下メソッドを使用可
        /// </summary>
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(name));
        }

    }


    /// <summary>
    /// MainWindowにラベルの変更箇所あり
    /// 故に、ViewModelBaseを継承
    /// </summary.
    internal class MainWindowViewModel : ViewModelBase
    {

        /// <summary>
        /// プロパティ
        /// 通信状態を示す。画面状態が「通信待ち」「通信中」のいずれかを示す
        /// </summary>
        public string communicationStatus { get; set; } = "NO SIGNAL";


        /* 
        * --------------------------------------------------------------------
        // 名称：CommunicatonButtonCommand()
        // 概要：「通信開始」ボタン押下時 機能するメソッド
        //      　本例では、ボタンを押下しただけで、通信中となり、Viewに変更を通知
        // 引数：なし
        // 返り値：なし
        *--------------------------------------------------------------------
        */
        public void CommunicatonButtonCommand()
        {
            // ボタン押下で「通信中」状態に変更
            communicationStatus = "通信中";

            // (View)通信状態ラベルの名称変更を通知
            OnPropertyChanged(nameof(communicationStatus));
        }


        /* 
        * --------------------------------------------------------------------
        // 名称：CommunicatonButtonCommand()
        // 概要：「制御」ボタンを押下時 機能するメソッド
        //       「通信中」状態で画面遷移する
        //       「NO SIGNAL」では画面遷移せず
        // 引数：なし
        // 返り値：なし
        *--------------------------------------------------------------------
        */
        public void OutputButtonCommand()
        {
            if (communicationStatus == "通信中")
            {
                SignalControlWindow signalControlWindow = new SignalControlWindow();
                signalControlWindow.Show();
            }
            // 「通信中」以外では画面遷移せず
            else
            {
                // DO NOTHING
            }
        }


    }
}