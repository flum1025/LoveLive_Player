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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace Synth_Player_ver0_1_2_by_ふらん
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        string musicdir = null;

        string file_off = null;
        string file_honoka = null;
        string file_eri = null;
        string file_kotori = null;
        string file_umi = null;
        string file_rin = null;
        string file_maki = null;
        string file_nozomi = null;
        string file_hanayo = null;
        string file_nico = null;

        string off = "off";
        string honoka = "honoka";
        string eri = "eri";
        string kotori = "kotori";
        string umi = "umi";
        string rin = "rin";
        string maki = "maki";
        string nozomi = "nozomi";
        string hanayo = "hanayo";
        string nico = "nico";

        string[] us = new string[] { "honoka", "eri", "kotori", "umi", "rin", "maki", "nozomi", "hanayo", "nico" };

        [DllImport("winmm.dll")]
        extern static int mciSendString(string s1, StringBuilder s2, int i1, int i2);
        // 返り値 = 0 @正常終了
        // s1     = Command String
        // s2     = Return String
        // i1     = Return String Size
        // i2     = Callback Hwnd

        public MainWindow()
        {
            InitializeComponent();
            //this.KeyPreview = true;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string stParentName = System.IO.Path.GetDirectoryName(appPath);

            DirectoryInfo di = new DirectoryInfo(stParentName + "\\music");
            musiclist.Items.Clear();

            foreach (DirectoryInfo diSub in di.GetDirectories())
            {
                musiclist.Items.Add(diSub.Name);
            }
            musiclist.SelectedIndex = 0;

        }

        private void OnKeyDownHandler(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                System.Windows.Forms.MessageBox.Show("test");
            }
        }

        private void musiclist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sound_close(off);
            for (int i = 0; i <= us.Length - 1; i++)
            {
                sound_close(us[i]);
            }
            maki_f.Visibility = Visibility.Hidden;
            eri_f.Visibility = Visibility.Hidden;
            nico_f.Visibility = Visibility.Hidden;
            kotori_f.Visibility = Visibility.Hidden;
            honoka_f.Visibility = Visibility.Hidden;
            hanayo_f.Visibility = Visibility.Hidden;
            rin_f.Visibility = Visibility.Hidden;
            umi_f.Visibility = Visibility.Hidden;
            nozomi_f.Visibility = Visibility.Hidden;

            maki_b.IsEnabled = false;
            eri_b.IsEnabled = false;
            nico_b.IsEnabled = false;
            kotori_b.IsEnabled = false;
            honoka_b.IsEnabled = false;
            hanayo_b.IsEnabled = false;
            rin_b.IsEnabled = false;
            umi_b.IsEnabled = false;
            nozomi_b.IsEnabled = false;




            int index = musiclist.SelectedIndex;
            string select_music = musiclist.Items[index].ToString();

            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string stParentName = System.IO.Path.GetDirectoryName(appPath);
            musicdir = stParentName + "\\music\\" + select_music;
            file_off = musicdir + "\\Off.mp3";
            file_honoka = musicdir + "\\HONOKA.mp3";
            file_eri = musicdir + "\\ELI.mp3";
            file_kotori = musicdir + "\\KOTORI.mp3";
            file_umi = musicdir + "\\UMI.mp3";
            file_rin = musicdir + "\\RIN.mp3";
            file_maki = musicdir + "\\MAKI.mp3";
            file_nozomi = musicdir + "\\NOZOMI.mp3";
            file_hanayo = musicdir + "\\HANAYO.mp3";
            file_nico = musicdir + "\\NICO.mp3";

            Console.WriteLine(file_off);

            sound_open(file_off, off);
            sound_open(file_honoka, honoka);
            sound_open(file_eri, eri);
            sound_open(file_kotori, kotori);
            sound_open(file_umi, umi);
            sound_open(file_rin, rin);
            sound_open(file_maki, maki);
            sound_open(file_nozomi, nozomi);
            sound_open(file_hanayo, hanayo);
            sound_open(file_nico, nico);

        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.D1 || e.Key == Key.NumPad1)
            {
                maki1();

            }
            else if (e.Key == Key.D2 || e.Key == Key.NumPad2)
            {
                eri1();

            }
            else if (e.Key == Key.D3 || e.Key == Key.NumPad3)
            {
                nico1();

            }
            else if (e.Key == Key.D4 || e.Key == Key.NumPad4)
            {
                
                kotori1();
            }
            else if (e.Key == Key.D5 || e.Key == Key.NumPad5)
            {
                honoka1();

            }
            else if (e.Key == Key.D6 || e.Key == Key.NumPad6)
            {
                hanayo1();

            }
            else if (e.Key == Key.D7 || e.Key == Key.NumPad7)
            {
                rin1();

            }
            else if (e.Key == Key.D8 || e.Key == Key.NumPad8)
            {
                
                umi1();
            }
            else if (e.Key == Key.D9 || e.Key == Key.NumPad9)
            {
                
                nozomi1();
            }
            else if (e.Key == Key.D0 || e.Key == Key.NumPad0)
            {
                all();
            }
            else if (e.Key == Key.OemMinus || e.Key == Key.Divide)
            {
                play1();
            }
            else if (e.Key == Key.OemQuotes || e.Key == Key.Multiply)
            {
                pause1();
            }
            else if (e.Key == Key.Oem5 || e.Key == Key.Subtract)
            {
                stop1();
            }

        }


        private int sound_open(string file_name, string member)// ファイルを open
        {   return mciSendString("open \"" + file_name + "\" alias " + member, null, 0, 0);  }

        
        private void sound_close(string member)// ファイルを close
        {   mciSendString("close  " + member, null, 0, 0);  }

       
        private void sound_play(string member) // 再生を開始
        {   mciSendString("play   " + member, null, 0, 0);  }

        private void sound_seek_play(int seek, string member)// 位置を指定
        {   mciSendString("seek   " + member + " to " + seek, null, 0, 0); }
        
        private void sound_stop(string member)// 停止
        {   mciSendString("stop   " + member, null, 0, 0);  }

        
        private void sound_pause(string member)// 一時停止
        {   mciSendString("pause  " + member, null, 0, 0);  }

       
        private void sound_resume(string member) // 一時停止解除
        {   mciSendString("resume " + member, null, 0, 0);  }

        StringBuilder sb = new StringBuilder(32) ;  // mciSendString() の Return String 格納用
        
        private string sound_get_mode(string member)// 状態を取得
        {   //   返り値: 再生中          = "playing"
            //           停止中/再生終了 = "stopped"
            //           一時停止中      = "paused"
            mciSendString("status " + member + " mode", sb, sb.Capacity,0);
            return sb.ToString() ;
        }

        
        private int sound_get_position(string member)// play 中のファイルの位置を ms単位 で返す
        {   mciSendString("status " + member + " position", sb, sb.Capacity, 0);
            return int.Parse(sb.ToString()) ;
        }


        private int sound_get_length(string member)// open 中のファイルの曲長を ms単位 で返す
        {
            mciSendString("status " + member + " length", sb, sb.Capacity, 0);
            return int.Parse(sb.ToString());
        }

        private void sound_volume(int volume, string member)//ボリュームの変更
        {
            mciSendString("setaudio " + member + " volume to " + volume.ToString(), sb, sb.Capacity, 0);
        }

        private void honoka1()
        {
            if (honoka_b.IsEnabled)
            {
                var mode = sound_get_mode(honoka);
                if (mode == "playing")
                {
                    sound_stop(honoka);
                    honoka_f.Visibility = Visibility.Hidden;
                }
                else
                {
                    int position = sound_get_position(off);
                    sound_seek_play(position + 40, honoka);
                    sound_play(honoka);
                    honoka_f.Visibility = Visibility.Visible;
                }
            }
        }

        private void eri1()
        {
            if (eri_b.IsEnabled)
            {
                var mode = sound_get_mode(eri);
                if (mode == "playing")
                {
                    sound_stop(eri);
                    eri_f.Visibility = Visibility.Hidden;
                }
                else
                {
                    int position = sound_get_position(off);
                    sound_seek_play(position + 40, eri);
                    sound_play(eri);
                    eri_f.Visibility = Visibility.Visible;
                }
            }
        }

        private void kotori1()
        {
            if (kotori_b.IsEnabled)
            {
                var mode = sound_get_mode(kotori);
                if (mode == "playing")
                {
                    sound_stop(kotori);
                    kotori_f.Visibility = Visibility.Hidden;

                }
                else
                {
                    int position = sound_get_position(off);
                    sound_seek_play(position + 40, kotori);
                    sound_play(kotori);
                    kotori_f.Visibility = Visibility.Visible;
                }
            }
        }

        private void umi1()
        {
            if (umi_b.IsEnabled)
            {
                var mode = sound_get_mode(umi);
                if (mode == "playing")
                {
                    sound_stop(umi);
                    umi_f.Visibility = Visibility.Hidden;

                }
                else
                {
                    int position = sound_get_position(off);
                    sound_seek_play(position + 40, umi);
                    sound_play(umi);
                    umi_f.Visibility = Visibility.Visible;
                }
            }
        }

        private void rin1()
        {
            if (rin_b.IsEnabled)
            {
                var mode = sound_get_mode(rin);
                if (mode == "playing")
                {
                    sound_stop(rin);
                    rin_f.Visibility = Visibility.Hidden;
                }
                else
                {
                    int position = sound_get_position(off);
                    sound_seek_play(position + 40, rin);
                    sound_play(rin);
                    rin_f.Visibility = Visibility.Visible;
                }
            }
        }

        private void maki1()
        {
            if (maki_b.IsEnabled)
            {
                var mode = sound_get_mode(maki);
                if (mode == "playing")
                {
                    sound_stop(maki);
                    maki_f.Visibility = Visibility.Hidden;

                }
                else
                {
                    int position = sound_get_position(off);
                    sound_seek_play(position + 40, maki);
                    sound_play(maki);
                    maki_f.Visibility = Visibility.Visible;

                }
            }
        }

        private void nozomi1()
        {
            if (maki_b.IsEnabled)
            {
                var mode = sound_get_mode(nozomi);
                if (mode == "playing")
                {
                    sound_stop(nozomi);
                    nozomi_f.Visibility = Visibility.Hidden;
                }
                else
                {
                    int position = sound_get_position(off);
                    sound_seek_play(position + 40, nozomi);
                    sound_play(nozomi);
                    nozomi_f.Visibility = Visibility.Visible;

                }
            }
        }

        private void hanayo1()
        {
            if (hanayo_b.IsEnabled)
            {
                var mode = sound_get_mode(hanayo);
                if (mode == "playing")
                {
                    sound_stop(hanayo);
                    hanayo_f.Visibility = Visibility.Hidden;
                }
                else
                {
                    int position = sound_get_position(off);
                    sound_seek_play(position + 40, hanayo);
                    sound_play(hanayo);
                    hanayo_f.Visibility = Visibility.Visible;
                }
            }
        }

        private void nico1()
        {
            if (nico_b.IsEnabled)
            {
                var mode = sound_get_mode(nico);
                if (mode == "playing")
                {
                    sound_stop(nico);
                    nico_f.Visibility = Visibility.Hidden;
                }
                else
                {
                    int position = sound_get_position(off);
                    sound_seek_play(position + 40, nico);
                    sound_play(nico);
                    nico_f.Visibility = Visibility.Visible;
                }
            }
        }

        private void all()
        {
            if (maki_b.IsEnabled)
            {
                var mode_maki = sound_get_mode(maki);
                var mode_eri = sound_get_mode(eri);
                var mode_nico = sound_get_mode(nico);
                var mode_kotori = sound_get_mode(kotori);
                var mode_honoka = sound_get_mode(honoka);
                var mode_hanayo = sound_get_mode(hanayo);
                var mode_rin = sound_get_mode(rin);
                var mode_umi = sound_get_mode(umi);
                var mode_nozomi = sound_get_mode(nozomi);

                if (mode_maki == "playing" || mode_eri == "playing" || mode_nico == "playing" || mode_kotori == "playing" || mode_honoka == "playing" || mode_hanayo == "playing" || mode_rin == "playing" || mode_umi == "playing" || mode_nozomi == "playing")
                {
                    for (int i = 0; i <= us.Length - 1; i++)
                    {
                        sound_stop(us[i]);

                    }
                        maki_f.Visibility = Visibility.Hidden;
                        eri_f.Visibility = Visibility.Hidden;
                        nico_f.Visibility = Visibility.Hidden;
                        kotori_f.Visibility = Visibility.Hidden;
                        honoka_f.Visibility = Visibility.Hidden;
                        hanayo_f.Visibility = Visibility.Hidden;
                        rin_f.Visibility = Visibility.Hidden;
                        umi_f.Visibility = Visibility.Hidden;
                        nozomi_f.Visibility = Visibility.Hidden;

                }
                else
                {
                    int position = 0;
                    for (int i = 0; i <= us.Length - 1; i++)
                    {
                        position = sound_get_position(off);
                        sound_seek_play(position + 40, us[i]);
                        sound_play(us[i]);
                    }
                    maki_f.Visibility = Visibility.Visible;
                    eri_f.Visibility = Visibility.Visible;
                    nico_f.Visibility = Visibility.Visible;
                    kotori_f.Visibility = Visibility.Visible;
                    honoka_f.Visibility = Visibility.Visible;
                    hanayo_f.Visibility = Visibility.Visible;
                    rin_f.Visibility = Visibility.Visible;
                    umi_f.Visibility = Visibility.Visible;
                    nozomi_f.Visibility = Visibility.Visible;

                }
            }
        }

        private void play1()
        {
            var mode = sound_get_mode(off);
            Console.Write(mode);
            if (mode == "playing")
            {
                sound_stop(off);
                sound_seek_play(0, off);
                maki_b.IsEnabled = false;
                eri_b.IsEnabled = false;
                nico_b.IsEnabled = false;
                kotori_b.IsEnabled = false;
                honoka_b.IsEnabled = false;
                hanayo_b.IsEnabled = false;
                rin_b.IsEnabled = false;
                umi_b.IsEnabled = false;
                nozomi_b.IsEnabled = false;


            }
            else
            {
                sound_play(off);
                maki_b.IsEnabled = true;
                eri_b.IsEnabled = true;
                nico_b.IsEnabled = true;
                kotori_b.IsEnabled = true;
                honoka_b.IsEnabled = true;
                hanayo_b.IsEnabled = true;
                rin_b.IsEnabled = true;
                umi_b.IsEnabled = true;
                nozomi_b.IsEnabled = true;

            }

        }

        private void pause1()
        {
            sound_pause(off);
            sound_pause(maki);
            sound_pause(eri);
            sound_pause(nico);
            sound_pause(kotori);
            sound_pause(honoka);
            sound_pause(hanayo);
            sound_pause(rin);
            sound_pause(umi);
            sound_pause(nozomi);
            maki_f.Visibility = Visibility.Hidden;
            eri_f.Visibility = Visibility.Hidden;
            nico_f.Visibility = Visibility.Hidden;
            kotori_f.Visibility = Visibility.Hidden;
            honoka_f.Visibility = Visibility.Hidden;
            hanayo_f.Visibility = Visibility.Hidden;
            rin_f.Visibility = Visibility.Hidden;
            umi_f.Visibility = Visibility.Hidden;
            nozomi_f.Visibility = Visibility.Hidden;


        }

        private void stop1()
        {
            sound_seek_play(0, off);
            sound_stop(off);
            sound_stop(maki);
            sound_stop(eri);
            sound_stop(nico);
            sound_stop(kotori);
            sound_stop(honoka);
            sound_stop(hanayo);
            sound_stop(rin);
            sound_stop(umi);
            sound_stop(nozomi);
            maki_f.Visibility = Visibility.Hidden;
            eri_f.Visibility = Visibility.Hidden;
            nico_f.Visibility = Visibility.Hidden;
            kotori_f.Visibility = Visibility.Hidden;
            honoka_f.Visibility = Visibility.Hidden;
            hanayo_f.Visibility = Visibility.Hidden;
            rin_f.Visibility = Visibility.Hidden;
            umi_f.Visibility = Visibility.Hidden;
            nozomi_f.Visibility = Visibility.Hidden;


        }


        private void maki_Click(object sender, RoutedEventArgs e)
        {
            maki1();

        }

        private void eri_Click(object sender, RoutedEventArgs e)
        {
            eri1();

        }

        private void nico_Click(object sender, RoutedEventArgs e)
        {
            nico1();

        }

        private void kotori_Click(object sender, RoutedEventArgs e)
        {
            kotori1();

        }

        private void honoka_Click(object sender, RoutedEventArgs e)
        {
            honoka1();

        }

        private void hanayo_Click(object sender, RoutedEventArgs e)
        {
            hanayo1();

        }

        private void rin_Click(object sender, RoutedEventArgs e)
        {
            rin1();


        }

        private void umi_Click(object sender, RoutedEventArgs e)
        {
            umi1();


        }

        private void nozomi_Click(object sender, RoutedEventArgs e)
        {
            nozomi1();


        }

        private void rew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            play1();
        }

        private void ff_Click(object sender, RoutedEventArgs e)
        {

        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            pause1();

        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            stop1();


        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double volume_d = Math.Floor(e.NewValue);
            int volume = (int)volume_d;
            sound_volume(volume, off);
            sound_volume(volume, maki);
            sound_volume(volume, eri);
            sound_volume(volume, nico);
            sound_volume(volume, kotori);
            sound_volume(volume, honoka);
            sound_volume(volume, hanayo);
            sound_volume(volume, rin);
            sound_volume(volume, umi);
            sound_volume(volume, nozomi);

        }







    }
}
