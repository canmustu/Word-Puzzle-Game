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

namespace kelime_oyunu
{
    public partial class AnimasyonPuan : UserControl
    {
        public AnimasyonPuan()
        {
            InitializeComponent();

            Storyboard1.Begin();
        }

        public void PuanGoster(string deger, SolidColorBrush renk)
        {
            TextPuan.Text = deger;
            TextPuan.Foreground = renk;
        }
    }
}
