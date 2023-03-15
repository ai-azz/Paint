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

//Superclass Kelas Bentuk
class Bentuk
{
    //Properti / Atribut
    public string Tipe = "Garis";
    public double ketebalan;
    public SolidColorBrush warna;
    public Point mulai, selesai;

    //Constructors
    public Bentuk()
    {
        warna = Brushes.Red;
        Tipe = "Garis";
    }

    //Metode / Behavior

    //Subclass bentuk garis
    public Line GambarGaris()
    {
        Line garisBaru = new Line()
        {
            Stroke = warna,
            StrokeThickness = ketebalan,
            X1 = mulai.X,
            Y1 = mulai.Y - 70,
            X2 = selesai.X,
            Y2 = selesai.Y - 70
        };

        return garisBaru;
    }

    //Subclass bentuk lingkaran
    public Ellipse GambarLingkaran()
    {
        Ellipse ellipseBaru = new Ellipse()
        {
            Stroke = Brushes.Black,
            StrokeThickness = ketebalan
        };

        //Tekan Kanan dan Kiri
        if (selesai.X >= mulai.X)
        {
            ellipseBaru.Width = selesai.X - mulai.X;
            ellipseBaru.SetValue(Canvas.LeftProperty, mulai.X);
        }
        else
        {
            ellipseBaru.Width = mulai.X - selesai.X;
            ellipseBaru.SetValue(Canvas.LeftProperty, selesai.X);
        }

        //Tekan Atas dan Bawah
        if (selesai.X >= mulai.X)
        {
            ellipseBaru.Height = selesai.X - mulai.X;
            ellipseBaru.SetValue(Canvas.TopProperty, mulai.Y - 70);
        }
        else
        {
            ellipseBaru.Height = mulai.X - selesai.X;
            ellipseBaru.SetValue(Canvas.TopProperty, selesai.Y - 70);
        }

        return ellipseBaru;
    }

    //subclass bentuk lingkaran penuh
    public Ellipse GambarLingkaranPenuh()
    {
        Ellipse ellipseBaru = new Ellipse()
        {
            Stroke = warna,
            Fill = warna,
            StrokeThickness = ketebalan
        };

        //Tekan Kanan dan Kiri
        if (selesai.X >= mulai.X)
        {
            ellipseBaru.Width = selesai.X - mulai.X;
            ellipseBaru.SetValue(Canvas.LeftProperty, mulai.X);
        }
        else
        {
            ellipseBaru.Width = mulai.X - selesai.X;
            ellipseBaru.SetValue(Canvas.LeftProperty, selesai.X);
        }

        //Tekan Atas dan Bawah
        if (selesai.X >= mulai.X)
        {
            ellipseBaru.Height = selesai.X - mulai.X;
            ellipseBaru.SetValue(Canvas.TopProperty, mulai.Y - 70);
        }
        else
        {
            ellipseBaru.Height = mulai.X - selesai.X;
            ellipseBaru.SetValue(Canvas.TopProperty, selesai.Y - 70);
        }

        return ellipseBaru;
    }

    //Subclass bentuk kotak
    public Rectangle GambarKotak()
    {
        Rectangle kotakBaru = new Rectangle()
        {
            Stroke = warna,
            StrokeThickness = ketebalan
        };

        if (selesai.X >= mulai.X)
        {
            kotakBaru.Width = selesai.X - mulai.X;
            kotakBaru.SetValue(Canvas.LeftProperty, mulai.X);
        }
        else
        {
            kotakBaru.Width = mulai.X - selesai.X;
            kotakBaru.SetValue(Canvas.LeftProperty, mulai.X);
        }

        if (selesai.X >= mulai.X)
        {
            kotakBaru.Height = selesai.X - mulai.X;
            kotakBaru.SetValue(Canvas.TopProperty, mulai.Y - 70);
        }
        else
        {
            kotakBaru.Height = mulai.X - selesai.X;
            kotakBaru.SetValue(Canvas.TopProperty, mulai.Y - 70);
        }

        return kotakBaru;
    }

    //Subclass bentuk kotak penuh
    public Rectangle GambarKotakPenuh()
    {
        Rectangle kotakBaru = new Rectangle()
        {
            Stroke = warna,
            Fill = warna,
            StrokeThickness = ketebalan
        };

        if (selesai.X >= mulai.X)
        {
            kotakBaru.Width = selesai.X - mulai.X;
        }
        else
        {
            kotakBaru.Width = mulai.X - selesai.X;
        }

        if (selesai.X >= mulai.X)
        {
            kotakBaru.Height = selesai.X - mulai.X;
        }
        else
        {
            kotakBaru.Height = mulai.X - selesai.X;
        }

        kotakBaru.SetValue(Canvas.LeftProperty, mulai.X);
        kotakBaru.SetValue(Canvas.TopProperty, mulai.Y - 77);

        return kotakBaru;
    }
}

namespace coba_aplikasi_paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Bentuk bentukSekarang = new Bentuk();


        private void Tombol_Garis_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Tipe = "Garis";
        }

        private void Tombol_Lingkaran_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Tipe = "Lingkaran1";
        }

        private void Tombol_Kotak_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Tipe = "Kotak1";
        }

        private void Tombol_lingkaranPenuh_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Tipe = "Lingkaran2";
        }

        private void Tombol_KotakPenuh_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.Tipe = "Kotak2";
        }


        //Ketika mouse ditekan
        private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bentukSekarang.mulai = e.GetPosition(this);
        }

        //Ketika mouse dilepas
        private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Shape BentukYangDigambar;
            if (bentukSekarang.Tipe == "Garis")
            {
                BentukYangDigambar = bentukSekarang.GambarGaris();
            }
            else if (bentukSekarang.Tipe == "Lingkaran2")
            {
                BentukYangDigambar = bentukSekarang.GambarLingkaranPenuh();
            }
            else if (bentukSekarang.Tipe == "Kotak2")
            {
                BentukYangDigambar = bentukSekarang.GambarKotakPenuh();
            }
            else if (bentukSekarang.Tipe == "Lingkaran1")
            {
                BentukYangDigambar = bentukSekarang.GambarLingkaran();
            }
            else
            {
                BentukYangDigambar = bentukSekarang.GambarKotak();
            }
            myCanvas.Children.Add(BentukYangDigambar);
        }

        //Ketika mouse bergerak
        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                bentukSekarang.selesai = e.GetPosition(this);
            }
        }


        private void Warna_Abu_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.Gray;
        }

        private void Warna_Hitam_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.Black;
        }

        private void Warna_Coklat_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.Brown;
        }

        private void Warna_CoklatMuda_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.RosyBrown;
        }

        private void Warna_Merah_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.Red;
        }

        private void Warna_Pink_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.Pink;
        }

        private void Warna_Orange_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.Orange;
        }

        private void Warna_Coral_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.Coral;
        }

        private void Warna_Kuning_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.Yellow;
        }

        private void Warna_KuningMuda_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.LightYellow;
        }

        private void Warna_Hijau_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.Green;
        }

        private void Warna_HijauMuda_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.Gray;
        }

        private void Warna_BiruMuda_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.YellowGreen;
        }

        private void Warna_BiruAwan_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.DeepSkyBlue;
        }

        private void Warna_Ungu_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.Purple;
        }

        private void Warna_UnguMuda_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.MediumPurple;
        }

        private void Warna_BiruLaut_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.CornflowerBlue;
        }

        private void Warna_PinkTua_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.PaleVioletRed;
        }

        private void Warna_PinkLipstik_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.warna = Brushes.HotPink;
        }

        //Fungsi ketebalan 1pt
        private void tebal_1_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.ketebalan = 1;
        }

        //Fungsi ketebalan 2pt
        private void tebal_2_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.ketebalan = 3;
        }

        //Fungsi ketebalan 3pt
        private void tebal_3_Click(object sender, RoutedEventArgs e)
        {
            bentukSekarang.ketebalan = 6;
        }

        //Fungsi Undo
        private void undo_Click(object sender, RoutedEventArgs e)
        {
            int count = myCanvas.Children.Count;
            if (count > 0)
            {
                myCanvas.Children.RemoveAt(count - 1);
            }
        }

    }

}
