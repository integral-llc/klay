using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using klay.Hooks;
using Newtonsoft.Json;

namespace klay
{
    public partial class MainForm : Form
    {
        private GlobalKeyboardHook _globalKeyboardHook;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.SysKeyDown
                && e.KeyboardData.VirtualCode == (int) Keys.U
                && (e.KeyboardData.Flags & GlobalKeyboardHook.LlkhfAltdown) == GlobalKeyboardHook.LlkhfAltdown)
            {
                Debug.WriteLine("OK - " +  JsonConvert.SerializeObject(e));
            }
            else
            {
                Debug.WriteLine(JsonConvert.SerializeObject(e) + ":" + (int)Keys.U + ":" + GlobalKeyboardHook.LlkhfAltdown
                                + ":" + (int)GlobalKeyboardHook.KeyboardState.SysKeyDown);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _globalKeyboardHook?.Dispose();
        }
    }
}
