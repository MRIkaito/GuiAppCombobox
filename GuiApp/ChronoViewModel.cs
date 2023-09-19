using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiApp.ViewModel;

namespace GuiApp
{

    internal class ChronoViewModel : ViewModelBase
    {

        /// <summary>
        /// インスタンス化
        /// 目的：ファイル名取得(GetFileName), CSVファイルの中身取得(CSVInput)
        /// </summary>
        SignalOutputModel OutputSignalModel = new SignalOutputModel();


        /// <summary>
        /// プロパティ
        /// CSVファイルの中身を表示する
        /// ラベルに本プロパティを表示している
        /// </summary>
        public string CsvContents { get; set; } = "読み込みなし";


        /* 
        * --------------------------------------------------------------------
        // 名称：CsvButtonCommand
        // 概要：「CSVファイル読み込み」ボタン押下時 機能するメソッド
        //       読み込む(CSV)ファイルのパスを取得し、
        //       その中身をCsvContentsラベルに格納、ラベルの更新を通知
        // 引数 fileLoadButtonName：「***ファイル読み込み」ボタンの x;Nameプロパティ
        // 返り値：なし
        *--------------------------------------------------------------------
        */
        public void CsvButtonCommand(string fileLoadButtonName)
        {
            // CSVファイルパスを取得
            string filePath = OutputSignalModel.GetFileName(fileLoadButtonName);

            // CsvContents(ラベル)に表示
            CsvContents = OutputSignalModel.CsvFileLoad(filePath);

            // ラベルの表示する情報変更を通知
            OnPropertyChanged(nameof(CsvContents));
        }

    }
}
