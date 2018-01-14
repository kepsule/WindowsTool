using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCreator
{
    public partial class Form1 : Form
    {
        //保存するフォルダ
        private const String SavedFolder = @"D:\temp\";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "タイトルを入力してください。";
            label2.Text = "詳細を入力してください。";
            textBox1.Focus();
            System.IO.Directory.CreateDirectory(SavedFolder);
        }

        //ボタン押下時の動作
        private void Button1_Click(object sender, EventArgs e)
        {

            //データチェック
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("タイトルを入力してください。");
                return;
            }

            //エラーない場合、ファイル生成
            CreateFile(DateTime.Now.ToString("yyyyMMdd_HHmmss"));
        }

        //ファイル生成、入力処理
        private void CreateFile(String fileNamePrefix)
        {

            //ファイル名生成
            String fileName = SavedFolder + fileNamePrefix + "_" + textBox1.Text + ".txt";

            //ファイル生成
            System.IO.File.Create(fileName).Close();

            //詳細入力
            System.IO.StreamWriter sw =
                new System.IO.StreamWriter(fileName, true,
                System.Text.Encoding.GetEncoding("shift_jis"));
            sw.Write(textBox2.Text);
            sw.Close();

            //完了時の動作
            MessageBox.Show("保存完了");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "title1";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(SavedFolder);
        }
    }
}
