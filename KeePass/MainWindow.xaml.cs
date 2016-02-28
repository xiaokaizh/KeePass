using KeePass.Class;
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

namespace KeePass
{
    //1.保存常用密码，记录密码使用时间和测试密码强度
    //2.根据规则生成密码
    // 1.加密的规则  2.文件的本地保存
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string d;
            bool dl = Sh1.SHA1("赵晓凯是个大笨蛋", out d);
        }
    }
}
