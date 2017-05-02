using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace kelime_oyunu
{
    public partial class Kelime : UserControl
    {
        DispatcherTimer timer = new DispatcherTimer();
        string harf;

        public Kelime()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromMilliseconds(950);
            timer.Tick += timer_Tick;

            Storyboard1.Begin();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            TextHarf.Content = harf;
            TextHarf.Opacity = 100;
        }

        public void HarfYerlestir(string gelenHarf)
        {
            timer.Start();
            harf = gelenHarf;
            Storyboard2.Begin();
        }
    }
}
