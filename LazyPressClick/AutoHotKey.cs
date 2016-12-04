using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
namespace LazyPressClick
{
    public partial class AutoHotKey : Form
    {
        private CDD cdd;
        //主线控制程对象
        private Thread controlThread;
        private ProgramSetting setting;
        private bool isClick = false;
        public AutoHotKey()
        {
            InitializeComponent();

            cdd = new CDD();
            reg_hotkey();
            
        }

        private void BT_Start_Click(object sender, EventArgs e)
        {
            if (isClick)
            {
                StopApply();
                BT_Start.Text = "开始";
            }
            else
            {
                BT_Start.Text = "停止";
                loadSetting();
                isClick = true;
                controlThread = new Thread(new ThreadStart(Run));
                controlThread.Start();
                
            }

        }

        public void Run()
        {

     
            ApplySetting();

        }


        /// <summary>
        /// 加载配置并执行
        /// </summary>
        public void ApplySetting()
        {
            //  DoHotKey();
            if (setting.IsPressAlt)
            {
                cdd.key(602, 1);
            }
            int times = (int)(setting.ClickSpeed * 1000);
            while (isClick)
            {
                DoMouseLeft();
                Thread.Sleep(times);
            }
         
        }
        /// <summary>
        /// 按一下回车
        /// </summary>
        public void DoEnter()
        {

            cdd.key(313, 1);
            cdd.key(313, 2);
        }

        /// <summary>
        /// 按常用快捷键
        /// </summary>
        public void DoHotKey()
        {
            DoEnter();
            Thread.Sleep(500);
            cdd.str("`shortkeymode on");
            Thread.Sleep(200);
            DoEnter();
            Thread.Sleep(200);
            cdd.str("`pickupmode");
            DoEnter();
        }

        /// <summary>
        ///  点一下右键
        /// </summary>
        public void DoMouseRight()
        {
            cdd.btn(4);                                    // 1=左键按下
            cdd.btn(8);                                    // 2=左键放开  
        }


        /// <summary>
        /// 点一下左键
        /// </summary>
        public void DoMouseLeft()
        {
            cdd.btn(1);                                    // 1=左键按下
            cdd.btn(2);                                    // 2=左键放开  

        }

        /// <summary>
        /// 取消执行
        /// </summary>
        public void StopApply()
        {
            isClick = false;
            if (controlThread != null)
            {
                //终止线程
                controlThread.Abort();
            }

            if (setting.IsPressAlt)
            {

                cdd.key(602, 2);
            }
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        public void loadSetting()
        {
            this.setting = new ProgramSetting
            {
                ClickSpeed = double.Parse(cbSpeed.Text),
                IsPressAlt = CB_IsPressAlt.Checked,
                LeftOrRight = false
            };

        }

        private void AutoHotKey_Load(object sender, EventArgs e)
        {
            cbSpeed.SelectedIndex = 0;
            string ddFilePath = Path.Combine(Application.StartupPath, "dddd.dll");
            if (!File.Exists(ddFilePath))
            {
                MessageBox.Show("你的文件不齐全 你搞什么鬼？");
                return;
            }

            int ret = cdd.Load(ddFilePath);
            if (ret == -2) { MessageBox.Show("装载库时发生错误"); return; }
            if (ret == -1) { MessageBox.Show("取函数地址时发生错误"); return; }
            if (ret == 0)
            { //MessageBox.Show("非增强模块"); 
            }
        }

        #region 注册快捷键
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(
         IntPtr hWnd,
         int id,                            // 热键标识
         KeyModifiers modkey,  //  修改键
         Keys vk                         //  虚键码
        );
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(
         IntPtr hWnd,              // 窗口句柄 
         int id                          // 热键标识 
        );

        void reg_hotkey()
        {
            RegisterHotKey(this.Handle, 80, KeyModifiers.Control, Keys.Home);
            RegisterHotKey(this.Handle, 90, KeyModifiers.Alt, Keys.End);
            // RegisterHotKey(this.Handle, 100, 0, Keys.LControlKey);
            //热键为Alt+0
        }

        void unreg_hotkey()
        {
            UnregisterHotKey(this.Handle, 80);
            UnregisterHotKey(this.Handle, 90);
            //   UnregisterHotKey(this.Handle, 100);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;                        //0x0312表示用户热键
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    ProcessHotkey(m);                                      //调用ProcessHotkey()函数
                    break;
            }
            base.WndProc(ref m);
        }

        private void ProcessHotkey(Message msg)              //按下设定的键时调用该函数
        {
            switch (msg.WParam.ToInt32())
            {
                //F10
                case 80:
                    BT_Start.PerformClick();
                    break;
                // F11
                case 90:
                    //调用相关函数
                    BT_Start.PerformClick();
                    break;
                case 100:
                    DoHotKey();
                    break;

            }
        }
        #endregion

        private void AutoHotKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            unreg_hotkey();
        }
 

    }
}
