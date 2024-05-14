using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
namespace PPPwn_Calzone_Extensions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Process.Start(Environment.CurrentDirectory + "\\Src\\exe\\PPPwn GUI 1.7.exe"); // IF EVER THERES AN UPDATE, REPLACE THE PROVIDED EXE WITH THE NEW ONE!
            Thread.Sleep(2000);
            timer1.Start();
        }
        static void EnableAdapter(string interfaceName)
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }
        static void DisableAdapter(string interfaceName)
        {
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }
        static void _start()
        {
            var a = Process.GetProcessesByName("PPPwn GUI 1.7");
            if (a.Length == 1)
            {
                Application.Exit();
            }
            else
            {
                var b = Process.GetProcessesByName("PPPwn GUI 1.7"); // IF EVER THERES AN UPDATE, CHANGE THIS TO THE NEW VERSION'S NAME
                if (b.Length == 1)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        DisableAdapter("enp0s3"); // CHANGE THIS TO YOUR NETWORK INTERFACE IF NOT DETECTED
                        Thread.Sleep(2500);
                        EnableAdapter("enp0s3"); // CHANGE THIS TO YOUR NETWORK INTERFACE IF NOT DETECTED
                        Thread.Sleep(1500);
                        int hitman = Process.GetCurrentProcess().Id;
                        Process.GetProcessById(hitman).Kill();
                    }
                    Application.Exit();
                }
                else
                {
                    SecondConnectionCheck();
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            ConnectionCheck();
        }
        static void ConnectionCheck()
        {
            Thread update = new Thread(ConnectionCheck);
            var timer = new System.Timers.Timer(3000);
            timer.Elapsed += (sender, args) => { _start(); };
            timer.Start();
        }
        static void SecondConnectionCheck()
        {
            Thread update = new Thread(ConnectionCheck);
            var timer = new System.Timers.Timer(10000);
            timer.Elapsed += (sender, args) => { _start(); };
            timer.Start();
        }
    }
}
