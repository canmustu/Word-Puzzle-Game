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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace kelime_oyunu
{
    public partial class MainPage : UserControl
    {

        #region Global Değişkenler Oluşturuldu

        List<int> harfSecRastgele = new List<int>();

        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer timer30 = new DispatcherTimer();

        DispatcherTimer timerDiz = new DispatcherTimer();

        DispatcherTimer timer_1snBekle = new DispatcherTimer();
        DispatcherTimer timer_2snBekle = new DispatcherTimer();

        ClassSorular soru;

        Random rando = new Random();

        int harfSayisi = 0;

        int toplamPuan = 0;
        int soruNo = 0;

        bool kutucuklarEklendi = false;
        
        int saniye30 = 0;

        int dakika = 4;
        int saniye = 0;

        List<ClassSorular> Sorular4 = new List<ClassSorular>();
        List<ClassSorular> Sorular5 = new List<ClassSorular>();
        List<ClassSorular> Sorular6 = new List<ClassSorular>();
        List<ClassSorular> Sorular7 = new List<ClassSorular>();
        List<ClassSorular> Sorular8 = new List<ClassSorular>();
        List<ClassSorular> Sorular9 = new List<ClassSorular>();
        List<ClassSorular> Sorular10 = new List<ClassSorular>();

        #endregion

        public MainPage()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            HarfAlInAktif();
            ButonInAktif();

            SureyiYenile();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;

            timerDiz.Interval = TimeSpan.FromMilliseconds(500);
            timerDiz.Tick += timerDiz_Tick;

            timer_1snBekle.Interval = TimeSpan.FromSeconds(1);
            timer_1snBekle.Tick += timer_1snBekle_Tick;

            timer_2snBekle.Interval = TimeSpan.FromSeconds(2);
            timer_2snBekle.Tick += timer_2snBekle_Tick;

            timer30.Interval = TimeSpan.FromSeconds(1);
            timer30.Tick += timer30_Tick;

            #region Sorular Eklendi

                #region 4 harfliler

                Sorular4.Add(new ClassSorular()
                {
                    soru = "Tek nefeste çıkan ses",
                    cevap = "hece",
                    harfSayisi = 4
                });

                Sorular4.Add(new ClassSorular()
                {
                    soru = "Kötünün de ötesinde olan, yürekler acısı şey",
                    cevap = "feci",
                    harfSayisi = 4
                });

                Sorular4.Add(new ClassSorular()
                {
                    soru = "Kız evlatlarıyla ata sözlerine konu olan meslek sahibi",
                    cevap = "kadı",
                    harfSayisi = 4
                });

                Sorular4.Add(new ClassSorular()
                {
                    soru = "Güzel koku",
                    cevap = "ıtır",
                    harfSayisi = 4
                });

                #endregion

                #region 5 harfliler

                Sorular5.Add(new ClassSorular()
                {
                    soru = "Yakışıklı delikanlı",
                    cevap = "civan",
                    harfSayisi = 5
                });

                Sorular5.Add(new ClassSorular()
                {
                    soru = "Çok zayıf insanlara yakıştırılan bir tabir",
                    cevap = "çırpı",
                    harfSayisi = 5
                });

                Sorular5.Add(new ClassSorular()
                {
                    soru = "Teklifsiz konuşmada çok güzel, mükemmel anlamındaki söz",
                    cevap = "kıyak",
                    harfSayisi = 5
                });

                Sorular5.Add(new ClassSorular()
                {
                    soru = "Bilimin temelindeki insani duygu",
                    cevap = "merak",
                    harfSayisi = 5
                });

                #endregion

                #region 6 harfliler

                Sorular6.Add(new ClassSorular()
                {
                    soru = "Toplumsal yaşantıdan kaçış",
                    cevap = "inziva",
                    harfSayisi = 6
                });

                Sorular6.Add(new ClassSorular()
                {
                    soru = "Tırnakla açılan yara",
                    cevap = "çırmık",
                    harfSayisi = 6
                });

                Sorular6.Add(new ClassSorular()
                {
                    soru = "\'Ne yazik ki\' anlamında kullanılan bir söz",
                    cevap = "heyhat",
                    harfSayisi = 6
                });

                Sorular6.Add(new ClassSorular()
                {
                    soru = "Güzel rastlantı",
                    cevap = "isabet",
                    harfSayisi = 6
                });

                #endregion

                #region 7 harfliler

                Sorular7.Add(new ClassSorular()
                {
                    soru = "Bir bilim yada sanat dalıyla ilgili kuruluş",
                    cevap = "akademi",
                    harfSayisi = 7
                });

                Sorular7.Add(new ClassSorular()
                {
                    soru = "Boş ve temelsiz söz",
                    cevap = "safsata",
                    harfSayisi = 7
                });

                Sorular7.Add(new ClassSorular()
                {
                    soru = "Göçebe lünepark",
                    cevap = "panayır",
                    harfSayisi = 7
                });

                Sorular7.Add(new ClassSorular()
                {
                    soru = "Kadın siyasetçi üniforması",
                    cevap = "dopiyes",
                    harfSayisi = 7
                });

                #endregion

                #region 8 harfliler

                Sorular8.Add(new ClassSorular()
                {
                    soru = "Uyumsuz olduklarında armonik faciaya neden olan grup",
                    cevap = "orkestra",
                    harfSayisi = 8
                });

                Sorular8.Add(new ClassSorular()
                {
                    soru = "Dönerek uzanan yolun kıvrıntısı",
                    cevap = "dolambaç",
                    harfSayisi = 8
                });

                Sorular8.Add(new ClassSorular()
                {
                    soru = "mecazi anlamada fena halde azarlamak",
                    cevap = "haşlamak",
                    harfSayisi = 8
                });

                Sorular8.Add(new ClassSorular()
                {
                    soru = "Samimi arkadaşlar için kullanılan söz dizisi",
                    cevap = "sıkıfıkı",
                    harfSayisi = 8
                });

                #endregion

                #region 9 harfliler

                Sorular9.Add(new ClassSorular()
                {
                    soru = "Değersiz eski eşya",
                    cevap = "pılıpırtı",
                    harfSayisi = 9
                });

                Sorular9.Add(new ClassSorular()
                {
                    soru = "Isınmak için halk dilinde yakılan alet",
                    cevap = "kalorifer",
                    harfSayisi = 9
                });

                Sorular9.Add(new ClassSorular()
                {
                    soru = "Pervasızca, sonunu düşünmeden ileriye atılmak",
                    cevap = "bodoslama",
                    harfSayisi = 9
                });

                Sorular9.Add(new ClassSorular()
                {
                    soru = "Somut yasalara bağlı olmayan bilim dalı",
                    cevap = "metafizik",
                    harfSayisi = 9
                });

                #endregion

                #region 10 harfliler

                Sorular10.Add(new ClassSorular()
                {
                    soru = "Boşa konuşup durmak, nefes tüketmek",
                    cevap = "çeneyormak",
                    harfSayisi = 10
                });

                Sorular10.Add(new ClassSorular()
                {
                    soru = "Mizaç özellikleri",
                    cevap = "cibilliyet",
                    harfSayisi = 10
                });

                Sorular10.Add(new ClassSorular()
                {
                    soru = "Teklisiz konuşmada güzel bir kadını izlemek",
                    cevap = "gözbanyosu",
                    harfSayisi = 10
                });

                Sorular10.Add(new ClassSorular()
                {
                    soru = "Yumuşak huylu kişiler için kullanılan söz",
                    cevap = "halimselim",
                    harfSayisi = 10
                });

                #endregion

            #endregion

            soruGetir();
        }



        private void HarfAl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HarfAl.Source = new BitmapImage(new Uri("img/butonHover.png", UriKind.Relative));
        }

        private void HarfAl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) // harf alındı butonuna basıldı
        {
            HarfAlInAktif();

            HarfAl.Source = new BitmapImage(new Uri("img/buton.png", UriKind.Relative));

            int rastGeldi = harfSecRastgele[rando.Next(0, harfSecRastgele.Count)];

            HarfiKoy(rastGeldi);
            harfSecRastgele.Remove(rastGeldi);

            if (harfSecRastgele.Count == 0) // tüm harfler alındı
            {
                ButonInAktif();
                HarfAlInAktif();

                timer.Stop();
                timer_2snBekle.Start();
            }

            else
                timer_1snBekle.Start();
        }

        private void Buton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Buton.Source = new BitmapImage(new Uri("img/butonHover.png", UriKind.Relative));
        }

        private void Buton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) // bilindi butonuna basıldı 
        {
            Buton.Source = new BitmapImage(new Uri("img/buton.png", UriKind.Relative));

            if (Buton.Tag.ToString() == "0")
            {
                timer.Stop();
                timer30.Start();

                // HarfAl InAktif
                HarfAl.MouseLeftButtonDown -= HarfAl_MouseLeftButtonDown;
                HarfAl.MouseLeftButtonUp -= HarfAl_MouseLeftButtonUp;
                HarfAl.Opacity = .6;

                // TextBilindi Aktif
                TextBilindi.IsEnabled = true;

                Buton.Tag = "1";
            }

            else if (Buton.Tag.ToString() == "1")
            {
                timer30.Stop();
                saniye30 = 0;

                ButonInAktif();

                TextBilindi.IsEnabled = false;

                if (soru.cevap.ToUpper() == TextBilindi.Text.ToUpper())
                    dogruBilindi();

                else
                    yanlisBilindi();

                Buton.Tag = "0";
            }
        }




        private void soruGetir() // soru değiştirildi 
        {
            soruNo++;
            if (soruNo > 14)
                OyunBitti();

            else
            {
                StackPanelKelimeler.Children.Clear();

                if (soruNo <= 2) // 4 harflik sorular ekleniyor
                {
                    soru = Sorular4[rando.Next(0, Sorular4.Count)];
                    Sorular4.Remove(soru);
                }

                else if (soruNo <= 4) // 5 harflik sorular ekleniyor
                {
                    soru = Sorular5[rando.Next(0, Sorular5.Count)];
                    Sorular5.Remove(soru);
                }

                else if (soruNo <= 6) // 6 harflik sorular ekleniyor
                {
                    soru = Sorular6[rando.Next(0, Sorular6.Count)];
                    Sorular6.Remove(soru);
                }

                else if (soruNo <= 8) // 7 harflik sorular ekleniyor
                {
                    soru = Sorular7[rando.Next(0, Sorular7.Count)];
                    Sorular7.Remove(soru);
                }

                else if (soruNo <= 10) // 8 harflik sorular ekleniyor
                {
                    soru = Sorular8[rando.Next(0, Sorular8.Count)];
                    Sorular8.Remove(soru);
                }

                else if (soruNo <= 12) // 9 harflik sorular ekleniyor
                {
                    soru = Sorular9[rando.Next(0, Sorular9.Count)];
                    Sorular9.Remove(soru);
                }

                else if (soruNo <= 14) // 10 harflik sorular ekleniyor
                {
                    soru = Sorular10[rando.Next(0, Sorular10.Count)];
                    Sorular10.Remove(soru);
                }

                TextSoru.Text = soru.soru;
                TextSoruPuani.Text = (soru.harfSayisi * 100) + "";

                harfSecRastgele.Clear();

                for (int i = 0; i < soru.harfSayisi; i++)
                    harfSecRastgele.Add(i);

                timerDiz.Start(); // sayfaya harf kutularını ekle
            }
        }

        private void HarfiKoy(int index) // Harfi Yerine Koyar 
        {
            (StackPanelKelimeler.Children[index] as Kelime).HarfYerlestir((StackPanelKelimeler.Children[index] as Kelime).Tag.ToString());
        }

        private void Cevaplandi_HarfleriGetir()
        {
            for (int i = 0; i < StackPanelKelimeler.Children.Count; i++)
                if ((StackPanelKelimeler.Children[i] as Kelime).TextHarf.Content.ToString() == "")
                    HarfiKoy(i); // harfleri yerleştir

            timer_2snBekle.Start(); // 2saniye bekle
        }



        void timer_Tick(object sender, EventArgs e) // yarışma süresini yeniliyor 
        {
            if (saniye == 0)
            {
                dakika--;

                if (dakika == -1)
                {
                    timer.Stop();

                    OyunBitti();
                }

                else
                    saniye = 59;
            }

            else
                saniye--;

            SureyiYenile();
        }

        private void SureyiYenile()
        {
            TextSure.Text = "Kalan Süre   0" + dakika + ":";
            TextSure.Text += (saniye < 10) ? "0" + saniye : saniye + "";
        }

        void timer_1snBekle_Tick(object sender, EventArgs e)
        {
            timer_1snBekle.Stop();

            if (kutucuklarEklendi)
            {
                HarfAlAktif();
                ButonAktif();
                TextBilindi.Text = "";
                kutucuklarEklendi = false;
            }
            else
                HarfAlAktif();
        }

        void timer_2snBekle_Tick(object sender, EventArgs e) // diğer soruya geçiliyor. 2 saniye bekleniyor 
        {
            timer_2snBekle.Stop();
            soruGetir();
        }

        void timerDiz_Tick(object sender, EventArgs e) // harf kutuları sayfaya ekleniyor 
        {
            StackPanelKelimeler.Children.Add(new Kelime()
                {
                    Tag = soru.cevap[harfSayisi].ToString().ToUpper()
                });

            harfSayisi++;

            if (soru.harfSayisi == harfSayisi) // hepsi eklendiyse
            {
                kutucuklarEklendi = true;
                harfSayisi = 0;

                timer_1snBekle.Start(); // 1 saniye bekle

                timerDiz.Stop();
                timer.Start();
            }
        }

        void timer30_Tick(object sender, EventArgs e) // 30sn giriş bilindi için yazı giriş izni 
        {
            saniye30++;

            if (saniye30 == 30)
            {
                Buton.Tag = "0";
                ButonInAktif();
                TextBilindi.IsEnabled = false;

                timer30.Stop();
                saniye30 = 0;

                yanlisBilindi();
            }
        }




        private void ButonAktif()
        {
            Buton.MouseLeftButtonDown += Buton_MouseLeftButtonDown;
            Buton.MouseLeftButtonUp += Buton_MouseLeftButtonUp;
            Buton.Opacity = 1;
        }

        private void ButonInAktif()
        {
            Buton.MouseLeftButtonDown -= Buton_MouseLeftButtonDown;
            Buton.MouseLeftButtonUp -= Buton_MouseLeftButtonUp;
            Buton.Opacity = .6;
        }

        private void HarfAlAktif()
        {
            HarfAl.MouseLeftButtonDown += HarfAl_MouseLeftButtonDown;
            HarfAl.MouseLeftButtonUp += HarfAl_MouseLeftButtonUp;
            HarfAl.Opacity = 1;
        }

        private void HarfAlInAktif()
        {
            HarfAl.MouseLeftButtonUp -= HarfAl_MouseLeftButtonUp;
            HarfAl.MouseLeftButtonDown -= HarfAl_MouseLeftButtonDown;
            HarfAl.Opacity = .6;
        }




        private void dogruBilindi()
        {
            int kazandigiPuan = harfSecRastgele.Count * 100;
            toplamPuan += kazandigiPuan;
            TextToplamPuan.Text = toplamPuan + "";

            Cevaplandi_HarfleriGetir();

            AnimasyonPuan puanGosterge = new AnimasyonPuan();
            puanGosterge.PuanGoster("+ " + kazandigiPuan, new SolidColorBrush(Colors.LightGray));
            CanvasPuanGostergesi.Children.Add(puanGosterge);
        }

        private void yanlisBilindi()
        {
            int kaybettigiPuan = harfSecRastgele.Count * 100;
            toplamPuan -= kaybettigiPuan;
            TextToplamPuan.Text = toplamPuan + "";

            Cevaplandi_HarfleriGetir();

            AnimasyonPuan puanGosterge = new AnimasyonPuan();
            puanGosterge.PuanGoster("-" + kaybettigiPuan, new SolidColorBrush(Colors.LightGray));
            CanvasPuanGostergesi.Children.Add(puanGosterge);
        }

        private void OyunBitti()
        {
            TextSure.Text = "";
            TextBilindi.Text = "";
            TextToplamPuan.Text = "";
            TextSoruPuani.Text = "";

            TextSure.Text = "Oyun bitti.\n\n Puanınız : " + toplamPuan;

            timer.Stop();
            ButonInAktif();
            HarfAlInAktif();
            StackPanelKelimeler.Children.Clear();

            MessageBox.Show("Oyun bitti. Puanınız : " + toplamPuan);
        }
    }
}
