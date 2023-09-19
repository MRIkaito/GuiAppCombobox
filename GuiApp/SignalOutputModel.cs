using Microsoft.Win32;              // OpenFileDialogクラス利用に必要
using System.IO;                    // StreamReaderクラスを利用に必要
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GuiApp
{
    internal class SignalOutputModel
    {

        // 送信用・キャンセル用　Ctrl_データ
        public static string[] Ctrl_HowToOutput { get; set; } = {"制御なし",       // Digital1
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


        /* 
         * --------------------------------------------------------------------
        // 名称：CsvFileLoad
        // 概要：読み込んだCSVファイルのデータをcsvText変数に格納、それを返り値として返す
        // 引数"string fileName"：ファイルの名称
        // 返り値：CSVファイルの中身を返す
         *--------------------------------------------------------------------
         */
        public string CsvFileLoad(string filePath)
        {
            using (StreamReader streamReader = new(filePath, Encoding.Default))
            {
                // 概要：CSVファイルの中身を最初から最後まで、csvText変数に格納
                string csvText = streamReader.ReadToEnd();

                return csvText;
            }

        }



        /* 
         * --------------------------------------------------------------------
        // 名称：GetFileName
        // 概要：「***ファイル読み込み」ボタン押下時に、エクスプローラを開き、
        //        ファイルの名称・フルパスを取得するメソッド
        // 引数"string fileLoadButtonName"：「***ファイル読み込み」ボタンの、x:Name(プロパティ)
        // 返り値：エクスプローラをオープンして、選択したファイルのファイル名(フルパス)を返す
         *--------------------------------------------------------------------
         */
        public string GetFileName(string fileLoadButtonName)
        {
            // 概要：オープンするダイアログボックスのインスタンス生成
            OpenFileDialog loadFileDialog = new OpenFileDialog();


            // 概要：「***ファイル読み込み」ボタンのx:Name毎に、読込ファイルの拡張子を指定
            //       以下、「CSVファイル読み込み」ボタン押下時の挙動
            if (fileLoadButtonName == "CsvFileLoad")
            {
                // 概要：選択可能なファイル拡張子を指定
                // 記述例：
                // loadFileDialog.Filter = "テキストファイル (*.txt)|*.txt|全てのファイル (*.*)|*.*";
                loadFileDialog.Filter = "CSVファイル (*.csv)|*.csv";


                // 概要：エクスプローラ表示
                if (loadFileDialog.ShowDialog() == true)
                {
                    // 概要：選択ファイル名称(ファイルのフルパス)を メッセージボックス表示
                    // 引数"dialog.FileName"：FileNameプロパティに ファイルパス格納
                    MessageBox.Show(loadFileDialog.FileName);
                }
            }
            // 仮にSinWaveWindowでファイル読み込みを実装した時の挙動
            else if (fileLoadButtonName == "SinWave")
            {
                // 概要：選択可能なファイル拡張子を指定
                loadFileDialog.Filter = "INIファイル (*.ini)|*.ini";

                // 概要：エクスプローラ表示
                if (loadFileDialog.ShowDialog() == true)
                {
                    // 概要：選択ファイル名称(ファイルのフルパス)を メッセージボックス表示
                    // 引数"dialog.FileName"：FileNameプロパティに ファイルパス格納
                    MessageBox.Show(loadFileDialog.FileName);
                }
            }
            else
            {
                // DO NOTHING
            }


            // 概要：ファイルの名称(フルパス)を返す
            return loadFileDialog.FileName;
        }

    }
}
