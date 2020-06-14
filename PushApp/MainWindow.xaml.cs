using System.Windows;

namespace PushApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private string appPath = "";

        public MainWindow()
        {
            InitializeComponent();
            appPath = "起動するトーストappのパスを入力してボタンを押してください。\nex.(c:\\hoge\\hoge.exe)";
            text.Text = appPath;
        }

        /// <summary>
        /// テキストボックスから起動したいexeの実行パスを取得して、
        /// コマンドプロンプトを非表示でアプリを起動する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //textboxの文字列を取得
            appPath = text.Text;

            //Processオブジェクトを作成する
            var p = new System.Diagnostics.Process();
            //起動する実行ファイルのパスを設定する
            p.StartInfo.FileName = appPath;
            //powershell非表示
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            //起動する。プロセスが起動した時はTrueを返す。
            try
            {
                var result = p.Start();

                if (!result)
                {
                    MessageBox.Show("プロセスを起動できませんでした", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("プロセスを起動できませんでした\nExceptionに入りました。パスを入力してください。", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
