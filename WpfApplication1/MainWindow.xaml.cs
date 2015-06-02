using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Net;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;
using System.Printing;
using MahApps.Metro.Controls;
using WpfApplication1.localhost;
using System.Windows.Ink;
//using System.Threading;
using System.Windows.Threading;
using System.Windows.Markup;
using System.Windows.Media.Animation;


//using System.Windows.Forms;


public static class Visuals
{

    

    
    public static TextBlock font(this TextBlock cur_text)
    {
        if (cur_text.Height < 10)
        {
            cur_text.Text = cur_text.Text.Replace("\n", " ");
            cur_text.FontSize = 5;
            cur_text.LineHeight = 5;
            cur_text.Padding = new Thickness(0);
        }
        else
        {
            if (cur_text.Height <= 19)
            {
                cur_text.FontSize = 6;
                cur_text.LineHeight = 6;
                cur_text.Padding = new Thickness(0);
            }
            else
            {
                if (cur_text.Height <= 35)
                {
                    cur_text.FontSize = 7;
                    cur_text.LineHeight = 7;
                }
                else
                {
                    if (cur_text.Height <= 55)
                    {
                        cur_text.FontSize = 8;
                        cur_text.LineHeight = 8;
                    }
                    else
                    {
                        cur_text.FontSize = 9;
                        cur_text.LineHeight = 10;
                    }
                }
            }
        }

        return cur_text;
    }


    


    public static VisualBrush grid_brush(this VisualBrush vb, double right, double zoom_coef)
    {
        Canvas brush_canvas = new Canvas();
        Line hour_line = new Line()
        {
            Stroke = Brushes.Red,

            X1 = 3-3*right,
            Y1 = 0,
            X2 = 10-3*right,
            Y2 = 0
        };
        Line line10 = new Line()
        {
            Stroke = Brushes.Black,
            X1 = 8-8*right,
            Y1 = 10 * zoom_coef,
            X2 = 10-8*right,
            Y2 = 10 * zoom_coef
        };
        Line line20 = new Line()
        {
            Stroke = Brushes.Black,
            X1 = 8 - 8 * right,
            Y1 = 20 * zoom_coef,
            X2 = 10 - 8 * right,
            Y2 = 20 * zoom_coef
        };
        Line line30 = new Line()
        {
            Stroke = Brushes.Black,
            X1 = 6 - 6 * right,
            Y1 = 30 * zoom_coef,
            X2 = 10 - 6 * right,
            Y2 = 30 * zoom_coef
        };
        Line line40 = new Line()
        {
            Stroke = Brushes.Black,
            X1 = 8 - 8 * right,
            Y1 = 40 * zoom_coef,
            X2 = 10 - 8 * right,
            Y2 = 40 * zoom_coef
        };
        Line line50 = new Line()
        {
            Stroke = Brushes.Black,
            X1 = 8 - 8 * right,
            Y1 = 50 * zoom_coef,
            X2 = 10 - 8 * right,
            Y2 = 50 * zoom_coef
        };
        Line right_line = new Line()
        {
            Stroke = Brushes.Black,

            X1 = 10-10*right,
            Y1 = 0,
            X2 = 10-10*right,
            Y2 = 60 * zoom_coef
        };
        if (right==0.0) brush_canvas.Children.Add(right_line);



        brush_canvas.Children.Add(hour_line);
        brush_canvas.Children.Add(line30);

        if (zoom_coef >= 0.75)
        {
            brush_canvas.Children.Add(line10);
            brush_canvas.Children.Add(line20);
            brush_canvas.Children.Add(line40);
            brush_canvas.Children.Add(line50);
        }

        VisualBrush vBrush = new VisualBrush()
        {
            TileMode = TileMode.Tile,
            Viewport = new Rect(0, 0, 20, 60 * zoom_coef),
            ViewportUnits = BrushMappingMode.Absolute,
            Viewbox = new Rect(0, 0, 10, 60 * zoom_coef),
            ViewboxUnits = BrushMappingMode.Absolute,
            Visual = brush_canvas,
        };

        return vBrush;
    }

    public static VisualBrush hours_brush(this VisualBrush vb, double zoom_coef)
    {
        Canvas brush_canvas = new Canvas();
        Line hour_line = new Line()
        {
            Stroke = Brushes.Black,

            X1 = 0,
            Y1 = 0,
            X2 = 1,
            Y2 = 0
        };
        brush_canvas.Children.Add(hour_line);
       
        
        VisualBrush vBrush = new VisualBrush()
        {
            TileMode = TileMode.Tile,
            Viewport = new Rect(0, 0, 5, 60 * zoom_coef),
            ViewportUnits = BrushMappingMode.Absolute,
            Viewbox = new Rect(0, 0, 10, 60 * zoom_coef),
            ViewboxUnits = BrushMappingMode.Absolute,
            Visual = brush_canvas,
        };

        return vBrush;
    }

    public static VisualBrush hatch_brush(this VisualBrush vb, double zoom_coef)
    {

        Canvas brush_canvas = new Canvas();
        Line hour_line = new Line()
        {
            Stroke = Brushes.Black,

            X1 = 0,
            Y1 = 0,
            X2 = 10,
            Y2 = 0
        };
        Line line10 = new Line()
        {
            Stroke = Brushes.Black,

            X1 = 0,
            Y1 = 10*zoom_coef,
            X2 = 1,
            Y2 = 10 * zoom_coef
        };
        Line line20 = new Line()
        {
            Stroke = Brushes.Black,

            X1 = 0,
            Y1 = 20 * zoom_coef,
            X2 = 1,
            Y2 = 20 * zoom_coef
        };
        Line line30 = new Line()
        {
            Stroke = Brushes.Black,

            X1 = 0,
            Y1 = 30 * zoom_coef,
            X2 = 3,
            Y2 = 30 * zoom_coef
        };
        Line line40 = new Line()
        {
            Stroke = Brushes.Black,

            X1 = 0,
            Y1 = 40 * zoom_coef,
            X2 = 1,
            Y2 = 40 * zoom_coef
        };
        Line line50 = new Line()
        {
            Stroke = Brushes.Black,

            X1 = 0,
            Y1 = 50 * zoom_coef,
            X2 = 1,
            Y2 = 50 * zoom_coef
        };
        


        brush_canvas.Children.Add(hour_line);
        brush_canvas.Children.Add(line10);
        brush_canvas.Children.Add(line20);
        brush_canvas.Children.Add(line30);
        brush_canvas.Children.Add(line40);
        brush_canvas.Children.Add(line50);
        

        VisualBrush vBrush = new VisualBrush()
        {
            TileMode = TileMode.Tile,
            Viewport = new Rect(0, 0, 5, 60 * zoom_coef),
            ViewportUnits = BrushMappingMode.Absolute,
            Viewbox = new Rect(0, 0, 10, 60 * zoom_coef),
            ViewboxUnits = BrushMappingMode.Absolute,
            Visual = brush_canvas,
        };

        return vBrush;


    }

}



public static class StringExtensions
{

    public static int channel_text_to_int(this string s)
    {

        int channel = 10;
         if (s=="Первый канал")
                    {
                        channel = 10;
                    }
                    else
                    {
                        if (s == "Россия-1")
                        {
                            channel = 21;
                        }   
                        else
                        {
                            if (s == "НТВ")
                            {
                                channel = 40;
                            }
                            else
                            {
                                //СТС и ТНТ пока не дописаны
                                if (s == "СТС")
                                {
                                    channel = 52;
                                }
                                else
                                {
                                    if (s == "ТНТ")
                                    {
                                        channel = 51;
                                    }
                                    else
                                    {
                                        if (s == "Орбита-1" || s == "Все орбиты")
                                        {
                                            channel = 11;
                                        }
                                        else
                                        {
                                            if (s == "Орбита-2")
                                            {
                                                channel = 12;
                                            }
                                            else
                                            {
                                                if (s == "Орбита-3")
                                                {
                                                    channel = 13;
                                                }
                                                else
                                                {
                                                    if (s == "Орбита-4")
                                                    {
                                                        channel = 14;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
        return channel;
    }

    public static int get_day(this string s)
    {
        int day_num=0;

        if (Left(s,4)=="prog") day_num=Convert.ToInt32(s.Substring(4,s.IndexOf("_")-4));
        if (Left(s, 4) == "news") day_num = Convert.ToInt32(s.Substring(4, s.IndexOf("_") - 4));
        if (Left(s,3)=="day") day_num=Convert.ToInt32(s.Substring(3,s.IndexOf("_")-3));
        if (Left(s,10)=="headerbord") day_num=Convert.ToInt32(s.Substring(10,s.IndexOf("_")-10));

        return day_num;
    }

    public static Tuple<string, string, string, string, string, string, string> deconstruct(this string s)
    {
        string beg_time_str = "";
        string total_dur = "";
        string title = "";
        string dur = "";
        string r = "0";
        string t = "0";
        string a = "0";
        string code = "";
        
        string full_timing = s.sqbr();
        string[] parts = full_timing.Split('+');

        


        if (parts.Length > 1)
        {
            r= parts[1].clear_spaces();
        }
        else
        {
            r= "0";
            t= "0";
            a= "0";
        }

        if (r.IndexOf("Р") >= 0)
        {
            r= r.Left(r.IndexOf("Р"));
            t= parts[1].clear_spaces();
            t= t.Substring(t.IndexOf("(") + 1, t.IndexOf(")") - t.IndexOf("(") - 1);
        }
        else
        {
            r = "0";
        }

        if (parts.Length > 2)
        {
            a = parts[2].clear_spaces();
            a = a.Left(a.IndexOf("А"));
        }

        if (parts[0].IndexOf("+") >= 0)
        {            
            //dur = s.sqbr().Substring(0, s.sqbr().IndexOf("+") - 1);
            dur = parts[0].Substring(0, parts[0].IndexOf("+") - 1).clear_spaces();
        }
        else
        {
            //dur = s.sqbr();            
            dur = parts[0].clear_spaces();
        }



        beg_time_str = s.Left(s.IndexOf(" "));
        title = s.full_title();
        total_dur = s.Substring(s.IndexOf("(")+1, s.IndexOf(")") - s.IndexOf("(") - 1);
        code = s.Substring(s.LastIndexOf("(") + 1, s.LastIndexOf(")") - s.LastIndexOf("(") - 1);

        //create_prog(prog_name, day_num - 1, beg_time, t_timing, r_timing, t_t, a_timing, code);
        if (dur == "0") dur = total_dur;
        return Tuple.Create(title, beg_time_str, dur, r, t, a, code);
        
    }


    public static string sqbr(this string s)
    {
        string string2trim = s;
        while (string2trim.IndexOf("[") > 0)
        {
            string2trim = string2trim.Substring(string2trim.IndexOf("[") + 1, string2trim.Length - string2trim.IndexOf("[") - 1);
        }
        string2trim = string2trim.Substring(0, string2trim.IndexOf("]"));

        return string2trim;
    }

    public static string full_title(this string s)
    {
        string string2trim = s;
        int cur_sqbr = 0;
        int last_sqbr = 0;

        /*while (string2trim.IndexOf("[") > 0)
        {
            last_sqbr = string2trim.IndexOf("[");
            cur_sqbr += last_sqbr;
            string2trim = string2trim.Substring(string2trim.IndexOf("[") + 1, string2trim.Length - string2trim.IndexOf("[") - 1);
        }          
        s = s.Substring(s.IndexOf(")") + 2, cur_sqbr - s.IndexOf(")") - 2);
         */
        s = s.Substring(s.IndexOf(")") + 2, s.LastIndexOf("[") - s.IndexOf(")") - 2);
        /*
        while (s.Right(1) == "\n") 
        {
            s=s.Substring(0, s.Length - 1);            
        }
         */ 
        return s;
    }


    public static string leading_zeros(this string s)
    {
        if (s.IndexOf(":") >= 0)
        {
            if (s.IndexOf(":") == 1) s = "0" + s;
            if (s.Length < 5) s = s.Replace(":", ":0");
        }
        return s;
    }


    public static string Left(this string s, int left)
    {
        if (s.Length >= left)
        {
            return s.Substring(0, left);
        }
        else 
        {
            return s;
        }
        
    }
    public static string Right(this string s, int right)
    {
        if (s.Length>=right)
        {
            return s.Substring(s.Length - right, right);
        }
        else
        {
            return s;
        }
        
    }
    public static string clear_age(this string s)
    {
        s= s.Replace("(12+)", "");
        s=s.Replace("(16+)", "");
        s=s.Replace("(18+)", "");                
        return s;
    }
    
    public static string clear_spaces(this string s)
    {
        if (s.Length>0)
        {
            while (s.Right(1) == " ")
            {
                s = s.Substring(0, s.Length - 1);
            }
        }

        if (s.Length > 0)
        {
            while (s.Left(1) == " ")
            {
                s = s.Substring(1, s.Length - 1);
            }
        }
        return s;
    }

    public static string minutes_to_time(this double min)
    {
        string hour_str = Math.Floor(min / 60).ToString();
        string minute_str = (min - Math.Floor(min / 60)*60).ToString();
        if (Convert.ToDouble(hour_str) > 23) hour_str = (Convert.ToDouble(hour_str) - 24).ToString();
        if (Convert.ToDouble(hour_str) < 0) hour_str = (Convert.ToDouble(hour_str) + 24).ToString();
        if (hour_str.Length < 2) hour_str = "0" + hour_str;
        if (minute_str.Length < 2) minute_str = "0" + minute_str;
        

        string beg_time_str = hour_str+":"+minute_str ;
        return beg_time_str;
    }


    public static string add_minute(this string time, double min)
    {
        //Добавляем указанное количество минут
        string new_time = "";
        double hours = 0;
        double minutes = 0;


        if (time.IndexOf(":") >= 0)
        {
            hours = Convert.ToDouble(time.Left(time.IndexOf(":")));
            minutes = Convert.ToDouble(time.Substring(time.IndexOf(":") + 1, time.Length - time.IndexOf(":") - 1));
        }
        else
        {
            minutes = Convert.ToDouble(time);
        }

        minutes += min;

        while (minutes<0)
        {
            minutes += 60;
            hours -= 1;
        }

        while (minutes>=60)
        {
            minutes -= 60;
            hours += 1;
        }

        string hours_str = "";
        string minutes_str = "";


        minutes_str = minutes.ToString();
        if (minutes < 10)
        {
            minutes_str = "0" + minutes_str;
        }
        hours_str = hours.ToString();
        if (hours< 10)
        {
            hours_str = "0" + hours_str;
        }
        

        new_time = hours_str + ":" + minutes_str;

        return new_time;
    }


    public static double time_to_minutes(this string timing)
    {
        double hours = 0;
        double minutes = 0;
        if (timing.IndexOf("N") < 0)
        {
            if (timing.IndexOf(":") >= 0)
            {
                hours = Convert.ToInt32(timing.Left(timing.IndexOf(":")));
                minutes = Convert.ToInt32(timing.Substring(timing.IndexOf(":") + 1, timing.Length - timing.IndexOf(":") - 1));
            }
            else
            {
                minutes = Convert.ToInt32(timing);
            }
        }
        double total_minutes = hours * 60 + minutes;
        return total_minutes;
    }


    public static Tuple<double, double, double, double, double, double> ads_int_new(this string timing)
    {
        //По чистому хронометражу, определяем количество рекламы/анонсов
        double hours = 0;
        double minutes = timing.time_to_minutes();

        while (minutes >= 60)
        {
            hours += 1;
            minutes -= 60;
        }

        //int hours = Convert.ToInt32(timing.Left(2));
        //int minutes = Convert.ToInt32(timing.Substring(3, 2));
        double duration = hours * 60 + minutes;

        double r = 0;
        double t = 0;
        double a = 0;

        double temp_dur = duration;
        bool odd = true;
        while (temp_dur>0)
        {
          if (odd==true && t>0)
           {
               r += 2;
               temp_dur += 2;
           }
            if (odd==false)
            {
                r += 2;
                t += 1;
                a += 1;
                temp_dur += 3;
            }
            odd = !odd;
            temp_dur-=15;
            
        }


        temp_dur = duration+r+a;
        //Странная поправка на ветер
        if (temp_dur < 120) 
            r += 2;
        //Добавляем раз в час на анонсы для новостей часа
        a += Math.Floor(temp_dur / 60);
        //Проверяем количество точек
        if (r - t * 4 > 0) t += 1;

        //Для коротких передач делаем на 1 анонс больше, чем точек
        while (a <= t) a += 1;

        minutes += Convert.ToInt32(r);
        minutes += Convert.ToInt32(a);
        while (minutes >= 60)
        {
            hours += 1;
            minutes -= 60;
        }

        return Tuple.Create(r, t, a, duration, hours, minutes);

    }

    public static Tuple<double,double,double, double, double,double> ads_int(this string timing)
    {
        //По чистому хронометражу, определяем количество рекламы/анонсов
        double hours = 0;
        double minutes = timing.time_to_minutes();
        
        while (minutes>=60)
        {
            hours += 1;
            minutes -= 60;
        }

        //int hours = Convert.ToInt32(timing.Left(2));
        //int minutes = Convert.ToInt32(timing.Substring(3, 2));
        double duration = hours * 60 + minutes;

        double r = 0;
        double t = 0;
        double a = 0;

        if (duration >= 0 & duration <= 15)
        {
            r = 3;
            t = 1;
            a = 1;
        }
        else
        {
            if (duration >= 16 & duration <= 30)
            {
                r = 4;
                t = 1;
                a = 2;
            }
            else
            {
                if (duration >= 31 & duration <= 40)
                {
                    r = 6;
                    t = 2;
                    a = 2;
                }
                else
                {
                    if (duration >= 41 & duration <= 50)
                    {
                        r = 8;
                        t = 2;
                        a = 3;
                    }
                    else
                    {
                        if (duration >= 51 & duration <= 60)
                        {
                            r = 9;
                            t = 3;
                            a = 4;
                        }
                        else
                        {
                            if (duration >= 61 & duration <= 90)
                            {
                                r = 12;
                                t = 3;
                                a = 4;
                            }
                            else
                            {
                                if (duration >= 91 & duration <= 110)
                                {
                                    r = 16;
                                    t = 4;
                                    a = 4;
                                }
                                else
                                {
                                    if (duration >= 111 & duration <= 130)
                                    {
                                        r = 20;
                                        t = 5;
                                        a = 7;
                                    }
                                    else
                                    {
                                        if (duration >= 131 & duration <= 150)
                                        {
                                            r = 24;
                                            t = 6;
                                            a = 7;
                                        }
                                        else
                                        {
                                            if (duration > 150)
                                            {
                                                
                                                r = Math.Floor((Math.Floor(Convert.ToDouble(duration)) / 60)) * 8;
                                                t = Math.Floor(Convert.ToDouble(r) / 4);
                                                a = t + 1;
                                                
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        minutes += Convert.ToInt32(r);
        minutes += Convert.ToInt32(a);
        while (minutes>=60)
        {
            hours += 1;
            minutes -= 60;
        }

        return Tuple.Create(r, t, a, duration, hours,minutes);

    }

  


    public static string ads(this string timing)
    {

        double r = ads_int(timing).Item1;
        double t = ads_int(timing).Item2;
        double a = ads_int(timing).Item3;

        


       



        string ads = " + "+r.ToString()+"Р("+t.ToString()+") + "+a.ToString()+"А";        
        return ads;
    }
}

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>



    public partial class MainWindow : MetroWindow     
    {
        //Double start_pos;
        Double start_pos_x =0;
        Double start_pos_y=0;
        Double template_top;
        private bool _isRectDragInProg;
        private bool dragged = false;
        //private bool mouseDownInToolbar;
        private int shape_count;
        private int days_count = 0;
        private List<TextBlock> progs = new List<TextBlock>(); // Коллекция программ, добавленных в сетку
        private List<Border> bords = new List<Border>(); // Коллекция программ, добавленных в сетку
        private List<Rectangle> day_rects = new List<Rectangle>(); // Коллекция дней, добавленных в сетку
        private List<Border> temp_bord = new List<Border>(); // Коллекция шаблонов
        private List<TextBlock> temp_text = new List<TextBlock>(); // Коллекция шаблонов
        private List<UIElement> p_items = new List<UIElement>(); // Коллекция элементов всплывающего окна
        private List<TextBlock> selected_progs = new List<TextBlock>(); // Коллекция выбранных программ
        private List<TextBlock> selected_days = new List<TextBlock>(); // Коллекция выбранных дней
        private List<UIElement> service_elements = new List<UIElement>(); //Коллекция служебных графических элементов
        //Point startPoint;
        private List<String> TouchDevices_list = new List<String>();
        private List<TouchDevice> TD_list = new List<TouchDevice>();
        private System.Windows.Forms.Timer doubleClickTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer update_timer = new System.Windows.Forms.Timer();
        private DispatcherTimer hold_timer = new DispatcherTimer();
        
        private double hold_seconds = 0;
        private bool isFirstClick = true;
        private bool isDoubleClick = false;
        private int milliseconds = 0;
        private int milliseconds2 = 0;
        private double initial_pos = 0;
        private double initial_dist = 0;
        private int day_num = 0;
        private int strokes_num = 0;
        private int direction = -1;
        private List<TVWeekType> l_weeks= new List<TVWeekType>();
        private List<TVWeekType> all_weeks = new List<TVWeekType>();
        private List<InkCanvas> ink_canvases = new List<InkCanvas>();        
        private InkCanvas visible_canvas = new InkCanvas();
        private AdornerLayer myAdornerLayer;
        private List<Label> right_labels = new List<Label>();
        List<TextBlock> days_to_check = new List<TextBlock>();
        List<TextBlock> all_the_days = new List<TextBlock>();        
        List<Rectangle> blinders = new List<Rectangle>();        
        private string cur_week_ref="";
        private UIElement cur_element;
        private SqlConnection con_plan12;
        private bool connected = false;
        public WebСервис1 wc = new WebСервис1();

        private TextBlock current_text = new TextBlock();
        private Border current_bord = new Border();
        


        //ini vars
        //private int is_buf_activated = 1; //Почему-то все получилось наоборот - т.е. deactivated



        private double zoom_coef = 1;
        private double x_scroll_speed = 1;
        private double y_scroll_speed = 1.5;
        private double days_handicap = 7;
        private double dummy = 1;
        private double zoom_tick1 = 50;
        private double zoom_tick2 = 0.1;
        private double day_top = 10;
        private double top_shift = 110;
        private bool shortened_titles = false;
        //private double forced_fontsize = 10;
        //private double base_fontsize = 9;
        
        //public double forced_fontsize = Convert.ToDouble(Properties.Settings.Default["forced_fontsize"]);
        //public double base_fontsize = Convert.ToDouble(Properties.Settings.Default["base_fontsize"]);
        public double forced_fontsize = WpfApplication1.Properties.Settings.Default.forced_fontsize;
        public double base_fontsize = WpfApplication1.Properties.Settings.Default.base_fontsize;
        
    


        public static string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string 
            // representing the plain text content of the TextRange. 
            return textRange.Text;
            
        }
       

        public class age_adorner : Adorner
        {
            int age = 0;
            // Be sure to call the base class constructor. 
            public age_adorner(UIElement adornedElement, int age2)
                : base(adornedElement)
            {
                age = age2;
            }

            // A common way to implement an adorner's rendering behavior is to override the OnRender 
            // method, which is called by the layout system as part of a rendering pass. 
            protected override void OnRender(DrawingContext drawingContext)
            {
                Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);

                SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
                renderBrush.Opacity = 0.0;
                Pen renderPen = new Pen(new SolidColorBrush(Colors.Black), 1);

                Point pt0 = new Point();
                pt0.X = adornedElementRect.TopRight.X - 18;
                pt0.Y = adornedElementRect.TopRight.Y;
                Point pt1 = new Point();
                pt1.X = adornedElementRect.TopRight.X - 18;
                pt1.Y = adornedElementRect.TopRight.Y + 10;

                Point pt3 = new Point();
                pt3.X = adornedElementRect.TopRight.X - 18;
                pt3.Y = adornedElementRect.TopRight.Y + 10;
                Point pt4 = new Point();
                pt4.X = adornedElementRect.TopRight.X;
                pt4.Y = adornedElementRect.TopRight.Y + 10;


                drawingContext.DrawLine(renderPen, pt0, pt1);
                drawingContext.DrawLine(renderPen, pt3, pt4);


                CultureInfo russian = new CultureInfo("ru-RU");
                Typeface tf = new Typeface("Segoe UI");
                string age_string = age.ToString() + "+";
                FormattedText ft = new FormattedText(age_string, russian, FlowDirection.LeftToRight, tf, 9, Brushes.Black);
                ft.SetFontWeight(FontWeights.Bold);
                Point pt = new Point();
                pt.X = adornedElementRect.TopRight.X - 16;
                pt.Y = adornedElementRect.TopRight.Y - 2;

                drawingContext.DrawText(ft, pt);

            }
        }

        public MainWindow()
        {

            InitializeComponent();


            //Пока урл и реквизиты прибиты гвоздями
            wc.Url = "http://plan12r/plan1cw/ws/ws1.1cws";
            wc.Credentials = new System.Net.NetworkCredential("mike", "123");
            con_plan12 = new SqlConnection("user id=sa;" +
                           "password=945549;server=Plan12r;" +
                           "Trusted_Connection=no;" +
                           "database=Plan; " +
                           "connection timeout=30");
            try
            {
                wc.GetWeeks();
                main_window.Title += " — Plan12";
                connected = true;
            }
            catch (Exception e)
            {
                try
                {
                    wc.Url = "http://tsurface/plan1cw/ws/ws1.1cws";
                    wc.Credentials = new System.Net.NetworkCredential("mike", "123");
                    con_plan12 = new SqlConnection("user id=sa;" +
                                   "password=945549;server=tsurface\\SQLEXPRESS;" +
                                   "Trusted_Connection=no;" +
                                   "database=Plan; " +
                                   "connection timeout=30");

                    wc.GetWeeks();
                    main_window.Title += " — TSurface";
                    connected = true;

                    
                }
                catch (Exception ex)
                {
                    wc.Url = "http://localhost/plan1cf/ws/ws1.1cws";
                    con_plan12 = new SqlConnection("user id=sa;" +
                               "password=945549;server=localhost\\SQLEXPRESS;" +
                               "Trusted_Connection=no;" +
                               "database=Plan; " +
                               "connection timeout=30");
                    main_window.Title += " — local";
                }
            }
           // MessageBox.Show(wc.Url);

                        
            
            shape_count = canvasArea.Children.Count;
            template_top = 400;

            /*
            TVDayVariantT[] test = new TVDayVariantT[2];
            TVDayVariantT day1 = new TVDayVariantT();
            day1.TVDayRef = "";
            day1.VariantNumber = "";
            
            TVDayVariantT[] test2 = new TVDayVariantT[2];
            //test2 = wc.CheckVariants(test, );
            */

            //Руками добавлены 3 шаблона программ
            temp_text.Add(ptemp45_200);
            temp_text.Add(ptemp52_280);
            temp_text.Add(ntemp15_360);

            doubleClickTimer.Interval = 100;
            doubleClickTimer.Tick += new EventHandler(doubleClickTimer_Tick);


            //service_elements.Add(ptemp45_200_border);
            //service_elements.Add(ptemp52_280_border);
            //service_elements.Add(ntemp15_360);
            service_elements.Add(print_button);
            service_elements.Add(week_button);
            //service_elements.Add(search_string);
            service_elements.Add(zoom_slider);
            //service_elements.Add(Buf);
            //service_elements.Add(Buf_on_bord);
            //service_elements.Add(Buf_on);
            service_elements.Add(glue);
            //service_elements.Add(hor);

            right_labels.Add(right_05);
            right_labels.Add(right_06);
            right_labels.Add(right_07);
            right_labels.Add(right_08);
            right_labels.Add(right_09);
            right_labels.Add(right_10);
            right_labels.Add(right_11);
            right_labels.Add(right_12);
            right_labels.Add(right_13);
            right_labels.Add(right_14);
            right_labels.Add(right_15);
            right_labels.Add(right_16);
            right_labels.Add(right_17);
            right_labels.Add(right_18);
            right_labels.Add(right_19);
            right_labels.Add(right_20);
            right_labels.Add(right_21);
            right_labels.Add(right_22);
            right_labels.Add(right_23);
            right_labels.Add(right_100);
            right_labels.Add(right_101);
            right_labels.Add(right_102);
            right_labels.Add(right_103);
            right_labels.Add(right_104);
            right_labels.Add(right_105);
            right_labels.Add(right_106);

            hold_timer.Tick += hold_timer_Tick;
            hold_timer.Interval = new TimeSpan(0, 0, 0, 0,100);
        }

        void hold_timer_Tick(object sender, EventArgs e)
        {
            hold_seconds += 100;
            Debug.WriteLine(hold_seconds.ToString());
            if (hold_seconds>=500)
            {
                if (current_text.Name.Left(4) == "prog" || current_text.Name.Left(4) == "news")
                {
                    selected_progs.Clear();
                    selected_progs.Add(current_text);
                    //Ищем части разрезанных программ
                    select_parts(current_text, e);

                    foreach (UIElement uie in p_items)
                    {
                        canvasArea.Children.Remove(uie);
                    }
                    p_items.Clear();
                    simply_align(current_text, Canvas.GetLeft(current_bord), Canvas.GetTop(current_bord), e);
                    //add_control_elements(cur_shape, e);

                    foreach (TextBlock tb in selected_progs)
                    {
                        //tb.Background = Brushes.LightBlue;
                        current_bord.BorderBrush = Brushes.CornflowerBlue;
                        current_bord.BorderThickness = new Thickness(3);
                    }

                    new_double_click(current_text, e);

                    hold_seconds = 0;
                    hold_timer.Stop();
                }
                if (current_text.Name.Left(6)=="header")
                {
                    Border cur_bord = new Border();
                    foreach (TextBlock tb in selected_days)
                    {
                        cur_bord = (Border)tb.Parent;
                        cur_bord.BorderThickness = new Thickness(1);
                        cur_bord.BorderBrush = Brushes.Black;
                    }
                    selected_days.Clear();

                    Flyout_day.IsOpen = true;
                    Flyout_day.Width = main_window.ActualWidth - 200;
                    Flyout_bottom.IsOpen = false;


                    selected_days.Add(current_text);




                    ch_rus1.Opacity = 0.3;
                    ch_ntv.Opacity = 0.3;
                    ch_sts.Opacity = 0.3;
                    ch_tnt.Opacity = 0.3;



                    foreach (UIElement tb in canvasArea.Children)
                    {
                        if (tb.GetType() == typeof(Border))
                        {

                            Border cur_tb = (Border)tb;
                            TextBlock day_text = (TextBlock)cur_tb.Child;
                            if (cur_tb.Name.Left(10) == "headerbord")
                            {
                                string s1 = current_bord.ToolTip.ToString();
                                string s2 = cur_tb.ToolTip.ToString();
                                if (current_bord.ToolTip.ToString() == cur_tb.ToolTip.ToString())
                                {
                                    if (day_text.Text.Contains("Россия-1")) ch_rus1.Opacity = 1;
                                    if (day_text.Text.Contains("НТВ")) ch_ntv.Opacity = 1;
                                }
                            }

                        }
                    }


                    ch_activate();
                    day_title.Text = selected_days[0].Text.Replace("\n", "#");
                }
            }
        }





        void doubleClickTimer_Tick(object sender, EventArgs e)
        {
            milliseconds += 100;

            // The timer has reached the double click time limit. 
            if (milliseconds >= System.Windows.Forms.SystemInformation.DoubleClickTime)
            {
                doubleClickTimer.Stop();
                isFirstClick = true;
                isDoubleClick = false;
                milliseconds = 0;

            }
        }




        public void add_and_align(object sender, double l_coord, double t_coord, MouseEventArgs e)
        {

            var cur_shape = (TextBlock)sender;
            //var cur_bord = (Border)cur_shape.Parent;

            Border Rendershape = null;
            shape_count += 1; //Нумеруем shape'ы программ
            String cur_name = string.Concat("prog0_", shape_count.ToString());
            String bord_name = string.Concat("bord0_", shape_count.ToString());

            //Создали Border под именем Rendershape
            Rendershape = new Border() { Name = bord_name, Height = cur_shape.Height * zoom_coef + 2, Width = cur_shape.Width * zoom_coef, Background = Brushes.Black };
            //Породили внутри TextBlock
            Rendershape.Child = new TextBlock() { Name = cur_name, Background = Brushes.White, Text = cur_shape.Text, TextWrapping = TextWrapping.Wrap, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center, TextAlignment = TextAlignment.Center, FontSize = base_fontsize, Padding = new Thickness(2), Height = Rendershape.Height - 2, Width = Rendershape.Width - 2 };


            //Добавили на Canvas
            canvasArea.Children.Add(Rendershape);
            //Выровняли по вертикали/горизонтали
            simply_align(Rendershape.Child, l_coord, t_coord, e);




            TextBlock cur_text = (TextBlock)Rendershape.Child;
            Border cur_bord = (Border)Rendershape;

 

            //Кладем где взяли
           // Canvas.SetLeft(cur_shape, 870);
           // Canvas.SetLeft(cur_bord, 870);
            //Предполагаем, что имя шаблона содержит _xpos            
           // Canvas.SetTop(cur_shape, Convert.ToDouble(cur_shape.Name.Substring(cur_shape.Name.IndexOf("_") + 1)));
           // Canvas.SetTop(cur_bord, Convert.ToDouble(cur_shape.Name.Substring(cur_shape.Name.IndexOf("_") + 1)));

            // Добавляем handler'ы для drag'n'drop
            Rendershape.Child.MouseLeftButtonDown += rect_MouseLeftButtonDown;
            Rendershape.Child.MouseMove += rect_MouseMove;
            Rendershape.Child.MouseLeftButtonUp += rect_MouseLeftButtonUp;

            //Добавили в коллекции
            progs.Add((TextBlock)Rendershape.Child);
            bords.Add((Border)Rendershape);


            //Добавляем в базу эфиров





            int day_num2 = Convert.ToInt32(cur_text.Name.Substring(4, cur_text.Name.IndexOf("_") - 4));
            Border cur_bord2 = new Border();
            TextBlock cur_text2 = new TextBlock();

            foreach (UIElement child in canvasArea.Children)
            {

                if (child.GetType() == typeof(Border))
                {
                    cur_bord2 = (Border)child;
                    cur_text2 = (TextBlock)cur_bord2.Child;

                    if (cur_bord2.Name.Left(10) == "headerbord")
                    {
                        if (cur_bord2.Name.Right(cur_bord2.Name.Length - 10) == day_num2.ToString())
                        {
                            //MessageBox.Show(cur_text2.Tag.ToString());
                            break;
                        }
                    }
                }
            }

            
            DateTime dt_time;
            string[] tb_name = cur_text2.Text.Split('\n');

            CultureInfo russian = new CultureInfo("ru-RU");
            DateTime date_var = DateTime.Parse(tb_name[1]);
            
            
                                        string title = cur_text.Text.deconstruct().Item1;
                                        if (title.Right(1) == "\n")
                                        {
                                            title = title.Substring(0, title.Length - 1);
                                        }

                                        double b_time = cur_text.Text.deconstruct().Item2.time_to_minutes();
                                        if (cur_text.Text.deconstruct().Item2.time_to_minutes() <= 10 * 60 && Canvas.GetTop(cur_bord) > 15 * 60 * zoom_coef)
                                        {                                            
                                            dt_time = DateTime.Parse(tb_name[1]+" "+cur_text.Text.deconstruct().Item2).AddDays(1);                                            
                                        }
                                        else
                                        {
                                            dt_time = DateTime.Parse(tb_name[1] + " " + cur_text.Text.deconstruct().Item2);                                            
                                        }


                                        int variant = 0;
                                        if (cur_text2.Text.IndexOf(" ") >= 0)
                                        {

                                            //MessageBox.Show(tb.Text.Substring(tb.Text.LastIndexOf(" ")+1, 1));
                                            variant = Convert.ToInt32(cur_text2.Text.Substring(cur_text2.Text.LastIndexOf(" ")+1, 1));
                                        }
                                        else
                                        {
                                            variant = 1;
                                        }


                 
                                        double timing = cur_text.Text.deconstruct().Item3.time_to_minutes();
                                        double rec = cur_text.Text.deconstruct().Item4.time_to_minutes();
                                        int tochki = Convert.ToInt32(cur_text.Text.deconstruct().Item5);
                                        double anons = cur_text.Text.deconstruct().Item6.time_to_minutes();
                                        string code = cur_text.Text.deconstruct().Item7;


                                        EfirType ef = new EfirType();
                                        ef.Variant = new VarType();

                                        ITCType itc_rec = new ITCType();
                                        itc_rec.Title = "Р";
                                        itc_rec.Timing=Convert.ToInt32(rec*60);
                                        itc_rec.PointCount= tochki;
                                        itc_rec.CapTiming = 0;

                                        ITCType itc_anons = new ITCType();
                                        itc_anons .Title = "А";
                                        itc_anons .Timing=Convert.ToInt32(anons*60);
                                        itc_anons .PointCount= tochki;
                                        itc_anons .CapTiming = 0;

                                        ITCType[] ra = new ITCType[2] {itc_rec,itc_anons};
                                        

                                        //ra[0]=itc_rec;
                                        //ra[1]=itc_anons;
                                        

                                        ef.Variant.TVData = date_var;
                                        ef.Variant.ChannelCode = 10;
                                        ef.Variant.VariantCode = variant; //!!!
                                        ef.Mask = variant;
                                        ef.Beg = dt_time;
                                        ef.Timing = Convert.ToInt32(timing*60+rec*60+anons*60);
                                        ef.Title = title;
                                        ef.ProducerCode = code.Left(2);
                                        ef.SellerCode = code.Right(3);
                                        ef.ITC = ra;
                                        ef.TVDayRef = cur_text2.Tag.ToString();

                                        ef.Ref=wc.AddEfir(ef);
                                        cur_text.Tag = ef.Ref.ToString();                                                
        }



        public void simply_align(object sender, double l_coord, double t_coord, EventArgs e)
        {
            //выравниваем программы по горизонтали
            double day;
            var cur_shape = (TextBlock)sender;
            var cur_bord = (Border)cur_shape.Parent;

            day = Math.Floor(l_coord / (160 * zoom_coef));
            if (day < 0) day = 0;

            



            //выставляем ровно в день
            
            //   Canvas.SetLeft(cur_shape, day * 150 + 1);
            cur_bord.Width = 160 * zoom_coef;
            if (cur_shape.Name.Left(5) == "ptemp" || cur_shape.Name.Left(5) == "ntemp")
            {
                cur_bord.Height = cur_bord.Height * zoom_coef;
                cur_shape.Height = cur_bord.Height - 2;
            }

            cur_shape.Width = cur_bord.Width - 2;
            Canvas.SetTop(cur_bord, t_coord);
            Canvas.SetTop(cur_shape, t_coord);
            Canvas.SetLeft(cur_bord, day * 159 * zoom_coef + 20);
            Canvas.SetLeft(cur_shape, day * 159 * zoom_coef + 20);

            //Меняем номер дня в имени
            cur_shape.Name = cur_shape.Name.Replace("prog" + cur_shape.Name.Substring(4, cur_shape.Name.IndexOf("_") - 4), "prog" + (day).ToString());
            cur_shape.Name = cur_shape.Name.Replace("ptemp" + cur_shape.Name.Substring(5, cur_shape.Name.IndexOf("_") - 5), "prog" + (day).ToString());
            cur_shape.Name = cur_shape.Name.Replace("news" + cur_shape.Name.Substring(4, cur_shape.Name.IndexOf("_") - 4), "news" + (day).ToString());

            

            cur_bord.Name = cur_bord.Name.Replace("bord" + cur_bord.Name.Substring(4, cur_bord.Name.IndexOf("_") - 4), "bord" + (day).ToString());

            //cur_shape.ToolTip = cur_shape.Name;


            if (glue.IsChecked == true)
                vert_glue((TextBlock)cur_shape, cur_bord, e);

            get_position_text((TextBlock)cur_shape, e);

            zoom_slider.Value += 0.01;
            zoom_slider.Value -= 0.01;

        }




        public void get_position_text(TextBlock sender, EventArgs e)
        {
            //MessageBox.Show(Canvas.GetTop(sender).ToString());

            //double time = (Canvas.GetTop(sender) - top_shift * zoom_coef) * zoom_coef;


            /*
            double hours = Math.Floor((Canvas.GetTop(sender)-80)/60);
            double minutes = Math.Floor((Canvas.GetTop(sender)-hours*60-80)/1);
            */


            //double full_minutes = Math.Floor(((Math.Floor((Canvas.GetTop(sender) - 80 * zoom_coef) / 1) + 300 * zoom_coef) / zoom_coef)/1);
            double full_minutes = Math.Floor((Canvas.GetTop(sender) - top_shift) / zoom_coef) + 300;



            //Хронометраж берется из первых скобок в текстбоксе
            double duration = sender.Text.Substring(sender.Text.IndexOf("(") + 1, sender.Text.IndexOf(")") - sender.Text.IndexOf("(") - 1).time_to_minutes();


            //hours += 5;



            /*
            string hours_str = hours.ToString();
            if (hours_str.Length < 2)
                
                hours_str = string.Concat("0", hours.ToString());
            string minutes_str = minutes.ToString();
            if (minutes_str.Length < 2)
                minutes_str = string.Concat("0", minutes_str);

            */

            //string new_time_start = string.Concat(hours_str, ":", minutes_str);
            string new_time_start = full_minutes.minutes_to_time();


            /*
            double time_end = time + duration;
            double hours_end = Math.Floor(time_end/ 60);
            double minutes_end = Math.Floor((time_end-(hours_end * 60))/1);

            hours_end += 5;

            

            string hours_end_str = hours_end.ToString();
            if (hours_end_str.Length < 2)
                hours_end_str = string.Concat("0", hours_end.ToString());
            string minutes_end_str = minutes_end.ToString();
            if (minutes_end_str.Length < 2)
                minutes_end_str = string.Concat("0", minutes_end_str);

            //string new_time_end = string.Concat(hours_end_str, ":", minutes_end_str);
            //string new_time_end = new_time_start.add_minute(duration);
             */

            string new_time_end = (new_time_start.time_to_minutes() + duration).minutes_to_time();



            string total_str = string.Concat(new_time_start, " - ", new_time_end);
            //string dur_str = duration.minutes_to_time();

            //sender.Text = sender.Text.Replace(sender.Text.Substring(0, 13), total_str);
            if (sender.Text.IndexOf("(") >= 0)
            {
                sender.Text = sender.Text.Replace(sender.Text.Substring(0, sender.Text.IndexOf("(") - 1), total_str);
                //   sender.Text = sender.Text.Replace(sender.Text.Substring(sender.Text.IndexOf("(") + 1, sender.Text.IndexOf(")") - sender.Text.IndexOf("(")-1), dur_str);
            }



        }



        public void vert_glue(TextBlock cur_shape, Border cur_bord, EventArgs e)
        {
            //Приклеивание по высоте
            foreach (TextBlock element in progs)
            {
                if (element.Name != cur_shape.Name)
                {
                    if (Canvas.GetLeft(element) == Canvas.GetLeft(cur_shape))
                    {

                        if (Canvas.GetTop(cur_shape) < Canvas.GetTop(element) + element.Height & Canvas.GetTop(cur_shape) > Canvas.GetTop(element))
                        {
                            Canvas.SetTop(cur_bord, Canvas.GetTop(element) + element.Height);
                            Canvas.SetTop(cur_shape, Canvas.GetTop(element) + element.Height);
                            break;
                        }

                        //Возможно, проверку нужно будет разделить на два цикла по очереди
                        if (Canvas.GetTop(cur_shape) + cur_shape.Height < Canvas.GetTop(element) + element.Height & Canvas.GetTop(cur_shape) + cur_shape.Height > Canvas.GetTop(element))
                        {
                            Canvas.SetTop(cur_bord, Canvas.GetTop(element) - cur_shape.Height);
                            Canvas.SetTop(cur_shape, Canvas.GetTop(element) - cur_shape.Height);
                            break;
                        }


                    }
                }

            }
        }

















        private void time_beg_plus(object sender, MouseEventArgs e)
        {
            double direction = 0;
            TextBlock cur_text = (TextBlock)sender;

            if (cur_text.Name.IndexOf("m") >= 0)
            {

                direction = 1;
            }
            else
            {

                direction = -1;
            }
            foreach (UIElement tb in canvasArea.Children)
            {
                if (tb.GetType() == typeof(TextBox))
                {

                    TextBox cur_tb = (TextBox)tb;

                    if (cur_tb.Name.Right(11) == "time_beg_tb")
                    {
                        cur_tb.Text = (cur_tb.Text.time_to_minutes() + direction).minutes_to_time();
                    }
                    break;
                }
            }


            
            string cur_name = cur_text.Name.Left(cur_text.Name.IndexOf("t")).Replace("prog", "bord");
            cur_name = cur_name.Replace("news", "bord");

            foreach (UIElement tb in canvasArea.Children)
            {
                if (tb.GetType() == typeof(Border))
                {
                    Border cur_bord = (Border)tb;

                    if (cur_bord.Name == cur_name)
                    {
                        TextBlock prog_text = (TextBlock)cur_bord.Child;
                        Canvas.SetTop(cur_bord, Canvas.GetTop(cur_bord) + direction * zoom_coef);
                        Canvas.SetTop(prog_text, Canvas.GetTop(prog_text) + direction * zoom_coef);
                        foreach (UIElement p in p_items)
                        {
                            Canvas.SetTop(p, Canvas.GetTop(p) + direction * zoom_coef);
                        }


                        get_position_text(prog_text, e);
                        break;
                    }
                }
            }


        }

        private void duration_plus(object sender, MouseEventArgs e)
        {

            TextBlock cur_text = (TextBlock)sender;
            double direction = 0;
            if (cur_text.Name.IndexOf("m") >= 0)
            {
                //MessageBox.Show("Minus!");
                direction = -1;
            }
            else
            {
                //MessageBox.Show("Plus!");
                direction = 1;
            }

            //TextBox cur_tb = new TextBox();
            TextBox dur_tb = new TextBox();
            TextBox r_tb = new TextBox();
            TextBox t_tb = new TextBox();
            TextBox a_tb = new TextBox();
            string total_dur1 = "";
            string total_dur2 = "";

            foreach (UIElement tb in canvasArea.Children)
            {
                if (tb.GetType() == typeof(TextBox))
                {
                    TextBox cur_tb = (TextBox)tb;
                    if (cur_tb.Name.Right(6) == "dur_tb")
                    {
                        dur_tb = (TextBox)tb;
                        dur_tb.Text = dur_tb.Text.add_minute(direction);
                    }
                    if (cur_tb.Name.Right(6) == "rec_tb")
                    {
                        r_tb = (TextBox)tb;
                    }
                    if (cur_tb.Name.Right(9) == "tochki_tb")
                    {
                        t_tb = (TextBox)tb;
                    }
                    if (cur_tb.Name.Right(8) == "anons_tb")
                    {
                        a_tb = (TextBox)tb;
                    }

                }
            }



            r_tb.Text = dur_tb.Text.ads_int().Item1.ToString();
            t_tb.Text = dur_tb.Text.ads_int().Item2.ToString();
            a_tb.Text = dur_tb.Text.ads_int().Item3.ToString();

            //TextBlock cur_text = (TextBlock)sender;
            string cur_name = "";
            
            if (cur_text.Name.IndexOf("t") >= 0)
            {                
                cur_name = cur_text.Name.Left(cur_text.Name.IndexOf("t")).Replace("prog", "bord");
                cur_name = cur_name.Replace("news", "bord");
            }
            else
            {
                MessageBox.Show(cur_text.Name);
            }
            

            foreach (UIElement tb in canvasArea.Children)
            {
                if (tb.GetType() == typeof(Border))
                {
                    Border cur_bord = (Border)tb;

                    if (cur_bord.Name == cur_name)
                    {

                        TextBlock prog_text = (TextBlock)cur_bord.Child;
                        total_dur1 = prog_text.Text.Substring(prog_text.Text.IndexOf("("), prog_text.Text.IndexOf(")") - prog_text.Text.IndexOf("(") + 1);



                        string duration = dur_tb.Text;
                        string r = r_tb.Text;
                        string a = a_tb.Text;
                        string t = t_tb.Text;




                        string sq_br_text = "["+dur_tb.Text;
                        if (Convert.ToDouble(r) != 0)
                        {
                            sq_br_text += " + " + r + "Р(" + t + ")";
                        }
                        if (Convert.ToDouble(a) != 0)
                        {
                            sq_br_text += " + " + a + "А";
                        }
                        sq_br_text += "]";
                        prog_text.Text = prog_text.Text.Replace(prog_text.Text.Substring(prog_text.Text.IndexOf("["), prog_text.Text.IndexOf("]") - prog_text.Text.IndexOf("[") + 1), sq_br_text);



                        //prog_text.Text = prog_text.Text.Replace(prog_text.Text.Substring(prog_text.Text.IndexOf("[") + 1, prog_text.Text.IndexOf("]") - prog_text.Text.IndexOf("[") - 1), dur_tb.Text+dur_tb.Text.ads());
                        //prog_text.Text = prog_text.Text.Replace(prog_text.Text.Substring(prog_text.Text.IndexOf("(") + 1, prog_text.Text.IndexOf(")") - prog_text.Text.IndexOf("(") - 1), dur_tb.Text.add_minute(Convert.ToDouble(r_tb.Text)).add_minute(Convert.ToDouble(a_tb.Text)));
                        string replacement_string = "(" + dur_tb.Text.add_minute(Convert.ToDouble(r_tb.Text)).add_minute(Convert.ToDouble(a_tb.Text)) + ")";
                        prog_text.Text = prog_text.Text.Replace(total_dur1, replacement_string);
                        total_dur2 = prog_text.Text.Substring(prog_text.Text.IndexOf("(") + 1, prog_text.Text.IndexOf(")") - prog_text.Text.IndexOf("(") - 1);
                        total_dur1 = total_dur1.Substring(1, total_dur1.Length - 2);
                        cur_bord.Height += (total_dur2.time_to_minutes() - total_dur1.time_to_minutes()) * zoom_coef;
                        prog_text.Height += (total_dur2.time_to_minutes() - total_dur1.time_to_minutes()) * zoom_coef;
                        foreach (UIElement p in p_items)
                        {
                            if (Canvas.GetTop(p) > Canvas.GetTop(cur_bord))
                            {
                                Canvas.SetTop(p, Canvas.GetTop(p) + total_dur2.time_to_minutes() - total_dur1.time_to_minutes());
                            }

                        }


                        get_position_text(prog_text, e);
                        break;
                    }
                }
            }


        }

        private void new_double_click(object sender, System.EventArgs e)
        {
            Flyout_bottom.Width = main_window.ActualWidth;
            Flyout_bottom.IsOpen = true;
            Flyout_day.IsOpen = false;

            if (Flyout_bottom.IsOpen==true)
            {
                TextBlock cur_text = (TextBlock)sender;
                Border cur_bord = (Border)cur_text.Parent;
                Label cur_label = null;

                //!шрифтfont_test(cur_text);


                //string anons_str = "0";
                //string tochki = "0";
                //string time_beg = cur_text.Text.Left(cur_text.Text.IndexOf(" "));
                string time_beg = cur_text.Text.deconstruct().Item2;
                string dur = "";

                string ts_hours = time_beg.Substring(0,time_beg.IndexOf(":"));
                string ts_minutes = time_beg.Substring(time_beg.IndexOf(":") + 1, time_beg.Length - time_beg.IndexOf(":")-1);

                string prev_sq_br_text = cur_text.Text.sqbr();


                
                /*
                if (cur_text.Text.IndexOf("+") >= 0)
                {
                    //dur = cur_text.Text.Substring(cur_text.Text.IndexOf("[") + 1, cur_text.Text.IndexOf("+") - cur_text.Text.IndexOf("[") - 2);
                    dur = prev_sq_br_text.Substring(0, prev_sq_br_text.IndexOf("+") - 1);
                }
                else
                {                
                    dur = cur_text.Text.Substring(cur_text.Text.IndexOf("[") + 1, cur_text.Text.IndexOf("]") - cur_text.Text.IndexOf("[") - 1);
                    //???dur = prev_sq_br_text.Substring(0, prev_sq_br_text.IndexOf("]") - 0);
                }
                 */
                dur = cur_text.Text.deconstruct().Item3;


                string dur_hours;
                string dur_minutes;

                if (dur.IndexOf(":")>=0)
                {
                    dur_hours = dur.Substring(0, dur.IndexOf(":"));
                    dur_minutes = dur.Substring(dur.IndexOf(":") + 1, dur.Length - dur.IndexOf(":") - 1);
                }
                else
                {
                    dur_hours = "00";
                    if (dur.Length == 1)
                    {
                        dur_minutes = "0" + dur;
                    }
                    else
                    {
                        dur_minutes = dur;
                    }
                }


                
                    
                //string full_timing = cur_text.Text.Substring(cur_text.Text.IndexOf("[") + 1, cur_text.Text.IndexOf("]") - cur_text.Text.IndexOf("[") - 1);
                string full_timing = cur_text.Text.sqbr();



                /*
                string string2trim = cur_text.Text;
                while (string2trim.IndexOf("[")>0)
                {
                    string2trim = string2trim.Substring(string2trim.IndexOf("[") + 1, string2trim.Length - string2trim.IndexOf("[") - 1);
                }
                string2trim = string2trim.Substring(0, string2trim.IndexOf("]") - 1);

                MessageBox.Show(string2trim);
                */
                
                //MessageBox.Show(cur_text.Text.Substring(cur_text.Text.IndexOf("[") + 1, cur_text.Text.Length - cur_text.Text.IndexOf("[") - 1));
                /*
                string[] parts = full_timing.Split('+');

                string rec_str = "";
                if (parts.Length > 1)
                {
                    rec_str = parts[1].clear_spaces();
                }
                else
                {
                    rec_str = "0";
                    tochki = "0";
                    anons_str = "0";
                }

                if (rec_str.IndexOf("Р") >= 0)
                {
                    rec_str = rec_str.Left(rec_str.IndexOf("Р"));
                    tochki = parts[1].clear_spaces();
                    tochki = tochki.Substring(tochki.IndexOf("(") + 1, tochki.IndexOf(")") - tochki.IndexOf("(") - 1);
                }
                if (parts.Length > 2)
                {
                    anons_str = parts[2].clear_spaces();
                    anons_str = anons_str.Left(anons_str.IndexOf("А"));
                }
                  
                //!!
                //string title = cur_text.Text.Substring(cur_text.Text.IndexOf(")") + 2, cur_text.Text.IndexOf("[") - cur_text.Text.IndexOf(")")-3);
                string title = cur_text.Text.full_title();
                */

                
                string rec_str = cur_text.Text.deconstruct().Item4;
                string tochki = cur_text.Text.deconstruct().Item5;
                string anons_str = cur_text.Text.deconstruct().Item6;
                string title = cur_text.Text.deconstruct().Item1;
                

                cur_label = (Label)timestart_hours.Content;
                cur_label.Content = ts_hours;
                cur_label = (Label)timestart_minutes.Content;
                cur_label.Content = ts_minutes;
                cur_label = (Label)duration_hours.Content;
                cur_label.Content = dur_hours;
                cur_label = (Label)duration_minutes.Content;
                cur_label.Content = dur_minutes;
                cur_label = (Label)r.Content;
                cur_label.Content = rec_str;
                cur_label = (Label)t.Content;
                cur_label.Content = tochki;
                cur_label = (Label)a.Content;
                cur_label.Content = anons_str;
                //tb_title.Text = title.Replace("\n","#");

                tb_title.Text = cur_bord.Tag.ToString()+ title.Replace("\n", "#").Replace("\\B0","").Replace("\\B1","").Replace("\\B","").Replace("\\I","");                
                
                //MessageBox.Show(cur_bord.Tag.ToString());
                //Пишем обновление эфира
                //MessageBox.Show(cur_text.Name.Substring(4,cur_text.Name.IndexOf("_")-4));



                

                

                

                
                
            }
            
        }


        private string update_efir(TextBlock cur_text)
        {

            string[] date_text = null;
            string doc_num = cur_text.Tag.ToString();
            int variant = 1;
            int channel = 10;
            DateTime date_var = DateTime.Parse("01.01.2011");

            foreach (UIElement tb in canvasArea.Children)
            {
                if (tb.GetType() == typeof(Border))
                {
                    Border cur_bord = (Border)tb;
                    if (cur_bord.Name == "headerbord" + cur_text.Name.Substring(4, cur_text.Name.IndexOf("_") - 4))
                    {
                        TextBlock header_text = (TextBlock)cur_bord.Child;
                        date_text = header_text.Text.Split('\n');
                        date_var = DateTime.Parse(date_text[1]);
                        if (header_text.Text.IndexOf(" ") >= 0)
                        {
                            variant = Convert.ToInt32(header_text.Text.Substring(header_text.Text.LastIndexOf(" ") + 1, 1));
                        }
                        else
                        {
                            variant = 1;
                        }

                        break;
                    }
                }
            }


            string title = cur_text.Text.deconstruct().Item1;
            
            title = title.Replace("\n"," ");
            

            string title_ANR = title.Replace("\n", "#");

            double b_time = cur_text.Text.deconstruct().Item2.time_to_minutes();
            DateTime dt_time;
            Border cur_bord2 = (Border)cur_text.Parent;
            if (cur_text.Text.deconstruct().Item2.time_to_minutes() <= 10 * 60 && Canvas.GetTop(cur_bord2) > 15 * 60 * zoom_coef)
            {
                dt_time = DateTime.Parse(date_text[1] + " " + cur_text.Text.deconstruct().Item2).AddDays(1);
            }
            else
            {
                dt_time = DateTime.Parse(date_text[1] + " " + cur_text.Text.deconstruct().Item2);
            }



            double timing = cur_text.Text.deconstruct().Item3.time_to_minutes();
            double rec = cur_text.Text.deconstruct().Item4.time_to_minutes();
            int tochki = Convert.ToInt32(cur_text.Text.deconstruct().Item5);
            double anons = cur_text.Text.deconstruct().Item6.time_to_minutes();
            string code = cur_text.Text.deconstruct().Item7;

            EfirType[] efirs = wc.GetEfirs(date_var, channel, variant);

            for (int j = 0; j < efirs.Length; j++)
            {
                if (efirs[j].Ref == doc_num)
                {
                    EfirType ef = new EfirType();
                    ef.Variant = new VarType();

                    ITCType itc_rec = new ITCType();
                    itc_rec.Title = "Р";
                    itc_rec.Timing = Convert.ToInt32(rec * 60);
                    itc_rec.PointCount = tochki;
                    itc_rec.CapTiming = 0;

                    ITCType itc_anons = new ITCType();
                    itc_anons.Title = "А";
                    itc_anons.Timing = Convert.ToInt32(anons * 60);
                    itc_anons.PointCount = tochki;
                    itc_anons.CapTiming = 0;

                    ITCType[] ra = new ITCType[2] { itc_rec, itc_anons };

                    //efirs[j].Variant.TVData = date_var;
                    //efirs[j].Variant.ChannelCode = 10;
                    //efirs[j].Variant.VariantCode = variant; //!!!
                    //efirs[j].Mask = variant;
                    efirs[j].Beg = dt_time;
                    efirs[j].Timing = Convert.ToInt32(timing * 60 + rec * 60 + anons * 60);
                    efirs[j].ANR = title_ANR;
                    efirs[j].Title = title;
                    efirs[j].ProducerCode = code.Left(2);
                    efirs[j].SellerCode = code.Right(3);
                    efirs[j].ITC = ra;                                        
                    wc.EfirUpdate(efirs[j]);
                    
                    break;
                }
            }

            return "1";
            
        }

        private void add_control_elements(object sender, System.EventArgs e)// MouseButtonEventArgs e)
        {

            TextBlock cur_text = (TextBlock)sender;


            string anons_str = "0";
            string tochki = "0";
            string time_beg = cur_text.Text.Left(cur_text.Text.IndexOf(" "));
            string dur = "";


            string sqbr_text = cur_text.Text.sqbr();

            //string dur = cur_text.Text.Substring(cur_text.Text.IndexOf("(") + 1, cur_text.Text.IndexOf(")") - cur_text.Text.IndexOf("(") - 1);

                if (cur_text.Text.IndexOf("+") >= 0)
                {
                    
                    //dur = cur_text.Text.Substring(cur_text.Text.IndexOf("[") + 1, cur_text.Text.IndexOf("+") - cur_text.Text.IndexOf("[") - 2);
                    dur = sqbr_text.Substring(0, sqbr_text.IndexOf("+") - 1);
                }
                else
                {
                 //   MessageBox.Show(cur_text.Text.Substring(cur_text.Text.IndexOf("[") + 1, cur_text.Text.IndexOf("]") - 1));
                    //dur = cur_text.Text.Substring(cur_text.Text.IndexOf("[") + 1, cur_text.Text.IndexOf("]") - cur_text.Text.IndexOf("[") - 1);
                    dur = sqbr_text.Substring(0, sqbr_text.IndexOf("]") - 0);
                }
            

            TextBox time_beg_tb = new TextBox()
            {
                Name = cur_text.Name + "time_beg_tb",
                //Text = cur_text.Text.Left(cur_text.Text.IndexOf(" ")),
                Text = time_beg,
                Height = 20,
                Width = 60
            };
            Canvas.SetLeft(time_beg_tb, (Canvas.GetLeft(cur_text) + 10));
            Canvas.SetTop(time_beg_tb, (Canvas.GetTop(cur_text) - 19));
            Canvas.SetZIndex(time_beg_tb, 2001);
            canvasArea.Children.Add(time_beg_tb);
            p_items.Add(time_beg_tb);
            time_beg_tb.KeyUp += ptb_KeyUp;


            TextBox dur_tb = new TextBox()
            {
                Name = cur_text.Name + "tdur_tb",
                //Text = cur_text.Text.Substring(cur_text.Text.IndexOf("(")+1,cur_text.Text.IndexOf(")")-cur_text.Text.IndexOf("(")-1),
                Text = dur,
                Height = 20,
                Width = 60
            };
            Canvas.SetLeft(dur_tb, (Canvas.GetLeft(cur_text) + 90));
            Canvas.SetTop(dur_tb, (Canvas.GetTop(cur_text) - 19));
            Canvas.SetZIndex(dur_tb, 2002);
            canvasArea.Children.Add(dur_tb);
            p_items.Add(dur_tb);
            dur_tb.KeyUp += ptb_KeyUp;


            //string full_timing = cur_text.Text.Substring(cur_text.Text.IndexOf("[") + 1, cur_text.Text.IndexOf("]") - cur_text.Text.IndexOf("[") - 1);
            string full_timing = cur_text.Text.sqbr();
            string[] parts = full_timing.Split('+');
            /*MessageBox.Show(parts[0]+'\n'+
                            parts[1]+'\n'+
                            parts[2]+'\n');
             */

            string rec_str = "";
            if (parts.Length > 1)
            {
                rec_str = parts[1].clear_spaces();
            }
            else
            {
                rec_str = "0";
                tochki = "0";
                anons_str = "0";
            }

            if (rec_str.IndexOf("Р") >= 0)
            {
                rec_str = rec_str.Left(rec_str.IndexOf("Р"));
                tochki = parts[1].clear_spaces();
                tochki = tochki.Substring(tochki.IndexOf("(") + 1, tochki.IndexOf(")") - tochki.IndexOf("(") - 1);
            }
            if (parts.Length > 2)
            {
                anons_str = parts[2].clear_spaces();
                anons_str = anons_str.Left(anons_str.IndexOf("А"));
            }



            TextBox rec_tb = new TextBox()
            {
                Name = cur_text.Name + "trec_tb",
                Text = rec_str,
                Height = 20,
                Width = 30
            };
            Canvas.SetLeft(rec_tb, (Canvas.GetLeft(cur_text) + 15));
            Canvas.SetTop(rec_tb, (Canvas.GetTop(cur_text) + cur_text.Height + 1));
            Canvas.SetZIndex(rec_tb, 2003);
            canvasArea.Children.Add(rec_tb);
            p_items.Add(rec_tb);
            KeyEventArgs k = null;
            rec_tb.KeyUp += ptb_KeyUp;
            rec_tb.MouseWheel += tb_MouseWheel;

            TextBox tochki_tb = new TextBox()
            {
                Name = cur_text.Name + "tochki_tb",
                Text = tochki,
                Height = 20,
                Width = 30
            };
            Canvas.SetLeft(tochki_tb, (Canvas.GetLeft(cur_text) + 65));
            Canvas.SetTop(tochki_tb, (Canvas.GetTop(cur_text) + cur_text.Height + 1));
            Canvas.SetZIndex(tochki_tb, 2004);
            canvasArea.Children.Add(tochki_tb);
            p_items.Add(tochki_tb);
            tochki_tb.KeyUp += ptb_KeyUp;
            rec_tb.MouseWheel += tb_MouseWheel;

            TextBox anons_tb = new TextBox()
            {
                Name = cur_text.Name + "tanons_tb",
                Text = anons_str,
                Height = 20,
                Width = 30
            };
            Canvas.SetLeft(anons_tb, (Canvas.GetLeft(cur_text) + 115));
            Canvas.SetTop(anons_tb, (Canvas.GetTop(cur_text) + cur_text.Height + 1));
            Canvas.SetZIndex(anons_tb, 2005);
            canvasArea.Children.Add(anons_tb);
            p_items.Add(anons_tb);
            anons_tb.KeyUp += ptb_KeyUp;
            rec_tb.MouseWheel += tb_MouseWheel;



            Border bd_plus = new Border()
            {
                Height = 20,
                Width = 20,
                Background = Brushes.Black,
            };
            Canvas.SetLeft(bd_plus, (Canvas.GetLeft(cur_text) + cur_text.Width + 1));
            Canvas.SetTop(bd_plus, (Canvas.GetTop(cur_text) - 19));
            Canvas.SetZIndex(bd_plus, 2006);
            canvasArea.Children.Add(bd_plus);
            p_items.Add(bd_plus);
            bd_plus.Child = new TextBlock()
            {
                Name = cur_text.Name + "td_plus",
                Text = "+",
                FontSize = 30,
                LineHeight = 22,
                LineStackingStrategy = LineStackingStrategy.BlockLineHeight,
                Background = Brushes.White,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                Height = 18,
                Width = 18
            };
            TextBlock tb = (TextBlock)bd_plus.Child;
            tb.MouseDown += duration_plus;

            Border bd_minus = new Border()
            {
                Height = 20,
                Width = 20,
                Background = Brushes.Black,
            };
            Canvas.SetLeft(bd_minus, (Canvas.GetLeft(cur_text) + cur_text.Width + 1));
            Canvas.SetTop(bd_minus, (Canvas.GetTop(cur_text) + cur_text.Height + 1));
            Canvas.SetZIndex(bd_minus, 2007);
            canvasArea.Children.Add(bd_minus);
            p_items.Add(bd_minus);
            bd_minus.Child = new TextBlock()
            {
                Name = cur_text.Name + "td_minus",
                Text = "-",
                FontSize = 30,
                LineHeight = 22,
                LineStackingStrategy = LineStackingStrategy.BlockLineHeight,
                Background = Brushes.White,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                Height = 18,
                Width = 18
            };
            tb = (TextBlock)bd_minus.Child;
            tb.MouseDown += duration_plus;

            //Кнопка сдвига на минута вниз
            Border bbeg_plus = new Border()
            {
                Height = 20,
                Width = 20,
                Background = Brushes.Black,
            };
            Canvas.SetLeft(bbeg_plus, (Canvas.GetLeft(cur_text) - 19));
            Canvas.SetTop(bbeg_plus, (Canvas.GetTop(cur_text) - 19));
            Canvas.SetZIndex(bbeg_plus, 2008);
            canvasArea.Children.Add(bbeg_plus);
            p_items.Add(bbeg_plus);
            bbeg_plus.Child = new TextBlock()
            {
                Name = cur_text.Name + "tbeg_plus",
                Text = char.ConvertFromUtf32(9650).ToString(),
                FontSize = 20,
                LineHeight = 20,
                LineStackingStrategy = LineStackingStrategy.BlockLineHeight,
                Background = Brushes.White,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                Height = 18,
                Width = 18

            };
            tb = (TextBlock)bbeg_plus.Child;
            tb.MouseDown += time_beg_plus;

            //Кнопка сдвига на минуту вверх
            Border bbeg_minus = new Border()
            {
                Height = 20,
                Width = 20,
                Background = Brushes.Black,
            };
            Canvas.SetLeft(bbeg_minus, (Canvas.GetLeft(cur_text) - 19));
            Canvas.SetTop(bbeg_minus, (Canvas.GetTop(cur_text) + cur_text.Height + 1));
            Canvas.SetZIndex(bbeg_minus, 2009);
            canvasArea.Children.Add(bbeg_minus);
            p_items.Add(bbeg_minus);
            bbeg_minus.Child = new TextBlock()
            {
                Name = cur_text.Name + "tbeg_minus",
                Text = char.ConvertFromUtf32(9660).ToString(),
                FontSize = 20,
                LineHeight = 22,
                LineStackingStrategy = LineStackingStrategy.BlockLineHeight,
                Background = Brushes.White,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                Height = 18,
                Width = 18
            };
            tb = (TextBlock)bbeg_minus.Child;
            tb.MouseDown += time_beg_plus;

        }









        private void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            var cur_shape = (TextBlock)sender;
            var cur_bord2 = (Border)cur_shape.Parent;

            current_text = cur_shape;
            current_bord = cur_bord2;

            cur_element = cur_shape;
            start_pos_x = Mouse.GetPosition(null).X;
            start_pos_y = Mouse.GetPosition(null).Y;


            if (isFirstClick)
            {
                isFirstClick = false;
                // Start the double click timer.
                doubleClickTimer.Start();
                hold_timer.Start();

            }

           // This is the second mouse click. 
            else
            {
                if (milliseconds < System.Windows.Forms.SystemInformation.DoubleClickTime)
                {
                    
                    isDoubleClick = true;
                    doubleClickTimer.Stop();
                    //MessageBox.Show(milliseconds.ToString()+'\n'+System.Windows.Forms.SystemInformation.DoubleClickTime.ToString());
                }

            }



            bool bylo = false;

            if (isDoubleClick == false)
            {               
                    //Одиночное нажатие
                    _isRectDragInProg = true;
                    cur_shape.CaptureMouse();




                    if (Keyboard.Modifiers.ToString() == "Control")
                    {
                        foreach (TextBlock element in progs)
                            element.Opacity = 0.5;
                        foreach (Border element in bords)
                        {
                            //element.Background= Brushes.White;
                            element.Opacity = 0.3;
                        }

                        VisualBrush vb = new VisualBrush();
                        foreach (Rectangle element in day_rects)
                        {
                            //element.Fill = (Brush)element.FindResource("HatchBrush");
                            element.Fill = vb.hatch_brush(zoom_coef);
                            element.Opacity = 0.5;
                        }
                    }
                    else
                    {
                        selected_progs.Clear();
                        
                        if (Flyout_bottom.IsOpen == true) Flyout_bottom.IsOpen = false;
                        if (Flyout_day.IsOpen == true) Flyout_day.IsOpen = false;
                        Border cur_bord = new Border();
                        foreach (TextBlock tb in selected_days)
                        {
                            cur_bord = (Border)tb.Parent;
                            cur_bord.BorderThickness = new Thickness(1);
                            cur_bord.BorderBrush = Brushes.Black;
                        }
                        selected_days.Clear();
                    }
                

            }
            else
            {
                //Двойное нажатие
                isDoubleClick = false;
                isFirstClick = true;
                milliseconds = 0;



                foreach (TextBlock tb in selected_progs)
                {
                    //tb.Background = Brushes.LightBlue;
                    cur_bord2.BorderBrush = Brushes.CornflowerBlue;
                    cur_bord2.BorderThickness = new Thickness(3);  
                }

                selected_progs.Clear();
                selected_progs.Add(cur_shape);
                //Ищем части разрезанных программ
                select_parts(cur_shape, e);

                foreach (UIElement uie in p_items)
                {
                    canvasArea.Children.Remove(uie);
                }
                p_items.Clear();
                simply_align(cur_shape, Canvas.GetLeft(cur_bord2), Canvas.GetTop(cur_bord2), e);
                //add_control_elements(cur_shape, e);
                new_double_click(cur_shape, e);
            }

            

            if (Keyboard.Modifiers.ToString() == "Control")
            {
                foreach (TextBlock stb in selected_progs)
                {
                    if (stb.Name == cur_shape.Name)
                    {
                        //if (stb.name.ToUpper().Contains("НОВОСТИ") || stb.Text.ToUpper() == "\"ВРЕМЯ\"")
                        if (stb.Name.Left(4)=="news")
                        {
                            stb.Background = Brushes.Gold;
                        }
                        else
                        {
                            stb.Background = Brushes.White;
                        }
                        selected_progs.Remove(stb);
                        bylo = true;
                        break;
                    }
                }


                if (bylo == false)
                {
                    selected_progs.Add(cur_shape);
                }
                else
                {
                    foreach (UIElement uie in p_items)
                    {
                        canvasArea.Children.Remove(uie);
                    }
                    p_items.Clear();
                }
            }

            foreach (TextBlock tb in progs)
            {
                //tb.Background = Brushes.White;
                if (tb.Name.Left(4) == "news")
                {
                    tb.Background = Brushes.Gold;
                }
                else
                {
                   // tb.Background = Brushes.White;
                }
                Border cur_bord = (Border)tb.Parent;
                cur_bord.BorderThickness = new Thickness(1);
                cur_bord.BorderBrush = Brushes.Black;
            }



        }
        
        private void select_parts(TextBlock prog_text, EventArgs e)
        {
            int day_num = prog_text.Name.get_day();

            if (prog_text.Name.Right(2).Left(1)=="d")
            {
                foreach (UIElement child in canvasArea.Children)
                {
                    int day_num2 = 0;
                    if (child.GetType() == typeof(Border))
                    {
                        Border cur_bord = new Border();
                        TextBlock cur_text = new TextBlock();
                        cur_bord = (Border)child;
                        cur_text = (TextBlock)cur_bord.Child;
                        day_num2 = cur_text.Name.get_day();
                        if (day_num == day_num2)
                        {
                            if (cur_text.Name.Length >= 4)
                            {
                                if (cur_text.Name.Right(2).Left(1) == "d" && cur_text.Name!=prog_text.Name)
                                {
                                    selected_progs.Add(cur_text);
                                }
                            }
                        }
                    }
                }
            }

            
        }

        private void rect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            hold_seconds = 0;
            hold_timer.Stop();
            _isRectDragInProg = false;
            var cur_shape = (TextBlock)sender;
            Border cur_bord = (Border)cur_shape.Parent;
            cur_shape.ReleaseMouseCapture();
            

            foreach (UIElement uie in p_items)
            {
                canvasArea.Children.Remove(uie);
            }
            p_items.Clear();


            foreach (TextBlock tb in selected_progs)
            {
                //tb.Background = Brushes.LightBlue;
                Border cur_bord2 = (Border)tb.Parent;
                cur_bord2.BorderBrush = Brushes.CornflowerBlue;
                cur_bord2.BorderThickness = new Thickness(3);
            }


            foreach (TextBlock element in progs)
                element.Opacity = 1;

            foreach (Border element in bords)
            {
                element.Background = Brushes.Black;
                element.Opacity = 1;
            }
            
            VisualBrush vb = new VisualBrush();
            foreach (Rectangle element in day_rects)
            {
                element.Fill = vb.hours_brush(zoom_coef);
                element.Opacity = 1;
            }

            dragged = false;


            if (Keyboard.Modifiers.ToString() == "Control")
            {
                //MessageBox.Show(Canvas.GetLeft(cur_bord).ToString());                
                if (cur_shape.Name.Left(5) == "ptemp" | cur_shape.Name.Left(5) == "ntemp")
                    //Вызываем функцию выравнивания
                    if (Canvas.GetLeft(cur_shape) < 160*days_count+50)
                        //add_and_align(sender, Canvas.GetLeft(cur_bord), Canvas.GetTop(cur_bord), e);\
                        simply_align(sender, Canvas.GetLeft(cur_bord), Canvas.GetTop(cur_bord), e);

                if (cur_shape.Name.Left(4) == "prog" || cur_shape.Name.Left(4) == "news")
                    simply_align(sender, Canvas.GetLeft(cur_bord), Canvas.GetTop(cur_bord), e);
            }




            if (selected_progs.Count == 1 && cur_shape.Name.Left(5) != "ptemp")
            {
                foreach (UIElement uie in p_items)
                {
                    canvasArea.Children.Remove(uie);
                }
                p_items.Clear();
                if (!dragged)
                {
                    //add_control_elements(sender, e);
                    //new_double_click(cur_shape, e);
                }

            }
            milliseconds2 = 0;
        }



        private void rect_MouseMove(object sender, MouseEventArgs e)
        {
            hold_seconds = 0;
            hold_timer.Stop();
            if (Keyboard.Modifiers.ToString() == "Control")
            {

                if (!_isRectDragInProg) return;

                // get the position of the mouse relative to the Canvas
                var mousePos = e.GetPosition(canvasArea);
                var DragOffset = e.GetPosition(canvasArea);

                var cur_shape = (TextBlock)sender;
                var cur_bord = (Border)cur_shape.Parent;




                if (cur_bord.Parent==first_sp)
                {
                    first_sp.Children.Remove(cur_bord);
                    canvasArea.Children.Add(cur_bord);
                    //bords.Add(cur_bord);
                    progs.Add((TextBlock)cur_bord.Child);
                }
                if (cur_bord.Parent == second_sp)
                {
                    second_sp.Children.Remove(cur_bord);
                    canvasArea.Children.Add(cur_bord);
                    //bords.Add(cur_bord);
                    progs.Add((TextBlock)cur_bord.Child);
                }


                // center the rect on the mouse

                double left = mousePos.X - (cur_shape.ActualWidth / 2);
                double top = mousePos.Y - (cur_shape.ActualHeight / 2);

                if (left != 0 || top != 0) dragged = true;

                Canvas.SetLeft(cur_shape, left);
                Canvas.SetLeft(cur_bord, left);
                Canvas.SetTop(cur_shape, top);
                Canvas.SetTop(cur_bord, top);


            }
            else
            {
                milliseconds2 = 0;
                if (_isRectDragInProg)
                ControlClickMethod((MouseEventArgs)e);                
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            /*
            SqlConnection con_plan12 = new SqlConnection("user id=sa;" +
                                       "password=945549;server=Plan12r;" +
                                       "Trusted_Connection=no;" +
                                       "database=Plan; " +
                                       "connection timeout=30");

              
            try
            {
                con_plan12.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            */

            SqlConnection con_local_cat = new SqlConnection("user id=sa;" +
                                       "password=945549;server=Shevchenko;" +
                                       "Trusted_Connection=no;" +
                                       "database=Plan; " +
                                       "connection timeout=30");


            try
            {
                con_local_cat.Open();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            string sstring = search_string.Text;



            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT BCDate, BeginTimeText, TimingText, Title, Bit_Repetition, DSti, DM, DR " +
                                                      "FROM TCBCList4Themes " +
                                                      "WHERE Title like '%заговор диетологов%'",
                                                      con_local_cat);
                string select = "SELECT BCDate, BeginTimeText, TimingText, Title, Bit_Repetition, DSti, DM, DR, ProducerCode, SellerCode " +
                                "FROM TCBCList4Themes " +
                                "WHERE Title like '%" +
                                sstring +
                                "%'";

                //SqlDataAdapter dataAdapter = new SqlDataAdapter(select, con_plan12);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(select, con_local_cat);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                ds.Tables.Add(dt);
                //con_plan12.Close();
                con_local_cat.Close();

                //dgrid1.ItemsSource = ds.Tables[0].DefaultView;
                DataView dv = new DataView(dt);








                myReader = myCommand.ExecuteReader();


                while (myReader.Read())
                {
                    //   sql_result.Text = myReader["Title"].ToString();
                    //                  MessageBox.Show(sql_result.Text);

                    //Console.WriteLine(myReader["Column1"].ToString());
                    //Console.WriteLine(myReader["Column2"].ToString());
                }
                //SqlDataAdapter sda = new SqlDataAdapter;

            }
            catch (Exception ex)
            {
                //                MessageBox.Show(ex.ToString());
                Console.WriteLine(ex.ToString());
            }


            //SqlCommand myCommand = new SqlCommand("Command String", myConnection);




            /*
             * Эта штука открывает диалог выбора файла
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                //MessageBox.Show(filename);
                ReadFileButton_Click(sender, e, filename);
            }
            */
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //create_infosheet(sender, e);
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".rtf"; // Default file extension
            //dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            RichTextBox rtfBox = new RichTextBox();
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;


                TextRange tr = new TextRange(rtfBox.Document.ContentStart, rtfBox.Document.ContentEnd);


                FileStream fs = File.Open(filename, FileMode.Open);

                using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(1251)))
                {
                    int counter = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        tr.Text = line;
                    }
                }

                MemoryStream stream = new MemoryStream();
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(tr.Text);
                writer.Flush();
                stream.Position = 0;
                tr.Load(stream, System.Windows.DataFormats.Rtf);
                //MessageBox.Show(tr.Text);
                string[] lines = tr.Text.Split('\n');
                int cunter = 0;
                 day_num = 0;
                foreach (string l in lines)
                {
                    //MessageBox.Show(l);
                    if (cunter < 1000000)
                    {
                        if (l.Length > 2)
                        {
                            string l2 = l;
                            while (l2.Left(1) == " ")
                            {
                                l2 = l2.Substring(1, l2.Length - 1);
                            }
                            if (l2.Left(3) == "Пон" || l2.Left(3) == "Вто" || l2.Left(3) == "Сре" || l2.Left(3) == "Чет" || l2.Left(3) == "Пят" || l2.Left(3) == "Суб" || l2.Left(3) == "Вос")
                            {
                                
                                day_num += 1;
                                //days_count += 1;
                              //  if (day_num == 1)
                                //{
                                   // header1.Text = l2;

                                //}
                                //else
                                //{
                                    create_day(l2, day_num);
                                //}
                            }
                        }





                        //MessageBox.Show(l);
                        if (l.Length > 2 && (l.Substring(1, 1) == "." || l.Substring(2, 1) == "."))
                        {
                            string[] parts = l.Split('\t');
                            //считаем time_beg в минутах
                            double beg_time = Convert.ToDouble(parts[0].Substring(0, parts[0].IndexOf("."))) * 60 + Convert.ToDouble(parts[0].Substring(parts[0].IndexOf(".") + 1, 2));
                            double t_timing = 0;
                            double r_timing = 0;
                            int t_t = 0;
                            double a_timing = 0;
                            // MessageBox.Show(l+'\n'+parts.Length.ToString()+'\n'+parts[parts.Length-2] );

                            bool last_one = false;
                            int cur_pos = 0;
                            // MessageBox.Show(parts[2].Length+'\n'+"\""+parts[2]+"\"");

                            string code = "(" + parts[2].clear_spaces().Left(5) + ")";


                            while (parts[1].Right(1) == " ")
                            {
                                parts[1] = parts[1].Substring(0, parts[1].Length - 1);
                            }

                            //string prog_name = parts[1].Substring(0, parts[1].Length - parts[1].IndexOf("["));
                            string prog_name = parts[1].Substring(0, parts[1].IndexOf("[")).clear_age();
                            while (last_one == false)
                            {
                                if (parts[1].Substring(cur_pos, parts[1].Length - cur_pos).IndexOf("[") >= 0)
                                {
                                    cur_pos += parts[1].Substring(cur_pos, parts[1].Length - cur_pos).IndexOf("[");
                                    cur_pos += 1;
                                }
                                else
                                {
                                    last_one = true;
                                    //cur_pos -= 1;
                                }


                            }

                            //s.Substring(cur_pos, s.Length - cur_pos-1)
                            string temp_time = parts[1].Substring(cur_pos, parts[1].Length - cur_pos - 1);
                            //string temp_time = parts[1].Substring(cur_pos, parts[1].Substring(cur_pos, parts[1].Length - cur_pos).IndexOf("]") - cur_pos);
                            //MessageBox.Show(temp_time);
                            string[] parts2 = temp_time.Split('+');


                            //
                            if (parts2.Length > 1)
                            {
                                if (parts2[0].IndexOf(".") >= 0)
                                {
                                    t_timing = Convert.ToDouble(parts2[0].Left(parts2[0].IndexOf("."))) * 60 + Convert.ToDouble(parts2[0].Substring(parts2[0].IndexOf(".") + 1, 2));
                                }
                                else
                                {
                                    if (parts2[0].IndexOf("'") >= 0)
                                    {
                                        t_timing = Convert.ToDouble(parts2[0].Left(parts2[0].IndexOf("'")));
                                    }
                                    else
                                    {
                                        t_timing = Convert.ToDouble(parts2[0]);
                                    }

                                    cunter += 1;
                                }


                                for (int i = 1; i <= parts2.Length - 1; i++)
                                {
                                    if (parts2[i].IndexOf("Р") >= 0)
                                    {
                                        if (parts2[i].IndexOf("'") >= 0)
                                        {
                                            r_timing += Convert.ToDouble(parts2[i].Left(parts2[i].IndexOf("'")));
                                            //MessageBox.Show(parts2[i].Substring(parts2[i].IndexOf("(")+1, parts2[i].IndexOf(")") - parts2[i].IndexOf("(")-1));
                                            if (parts2[i].IndexOf("(") >= 0 & parts2[i].IndexOf("Р99") < 0 & parts2[i].IndexOf("СР") < 0)
                                            {
                                                t_t += Convert.ToInt32(parts2[i].Substring(parts2[i].IndexOf("(") + 1, (parts2[i].IndexOf(")") - parts2[i].IndexOf("(") - 1)));
                                            }

                                        }
                                        else
                                        {
                                            r_timing += Convert.ToDouble(parts2[i].Left(parts2[i].IndexOf("Р")));
                                            if (parts2[i].IndexOf("(") >= 0 & parts2[i].IndexOf("Р99") < 0 & parts2[i].IndexOf("СР") < 0)
                                            {
                                                t_t += Convert.ToInt32(parts2[i].Substring(parts2[i].IndexOf("(") + 1, parts2[i].IndexOf(")") - parts2[i].IndexOf("(") - 1));
                                            }
                                        }
                                    }

                                    if (parts2[i].IndexOf("А") >= 0)
                                    {
                                        if (parts2[i].IndexOf("'") >= 0)
                                        {
                                            a_timing = Convert.ToDouble(parts2[i].Left(parts2[i].IndexOf("'")));

                                        }
                                        else
                                        {
                                            a_timing = Convert.ToDouble(parts2[i].Left(parts2[i].IndexOf("А")));

                                        }
                                    }
                                }




                            }
                            else
                            {
                                if (parts2[0].IndexOf("'") >= 0)
                                {
                                    t_timing = Convert.ToDouble(parts2[0].Left(parts2[0].IndexOf("'")));
                                }
                                else
                                {
                                    t_timing = Convert.ToDouble(parts2[0]);
                                }

                                //double t_timing = Convert.ToDouble(parts2[0].Substring(1, parts2[0].Length - 2));
                                //MessageBox.Show(parts2[0].ToString()+"y");
                            }
                            /*
                            MessageBox.Show(prog_name+'\n'+
                                               "Beg_time: "+beg_time.ToString()+'\n'+
                                               "Timing: "+t_timing.ToString()+'\n'+
                                               "P: "+r_timing.ToString()+'\n'+
                                               "T: "+t_t.ToString()+'\n'+
                                               "A: "+a_timing.ToString());
                         */
                            //MessageBox.Show(beg_time.ToString());



                            if ((beg_time / 60) < 5)
                            {
                                //MessageBox.Show(prog_name + '\n' + beg_time);
                                beg_time += 24 * 60;
                            }
                            prog_name = prog_name.clear_spaces();

                            


                            // MessageBox.Show(prog_name + '\n' + beg_time);
                            if (t_timing > 5 && day_num <= days_handicap)
                                create_prog(prog_name, day_num - 1, beg_time, t_timing, r_timing, t_t, a_timing, code, null, 0);
                        }




                        cunter += 1;
                    }

                }



                //MessageBox.Show(lines[10]) ;






                /*        canvasArea.Children.Add(rtfBox);
                        Canvas.SetTop(rtfBox,0);
                        Canvas.SetLeft(rtfBox,0 );
                        rtfBox.Width = 700;*/



            }
        }



        private void create_day(string day_name, int day_num, int var_num=1, string dayRef="")
        {

            //day_num = day_num - 1;
            
            days_count += 1;
            if (days_count == 1)
            {
                canvasArea.Children.Remove(day1);
                canvasArea.Children.Remove(header1);
                canvasArea.Children.Remove(headerbord0);
                //day_rects.Clear();
            }
             
                
            VisualBrush vb = new VisualBrush();

            //Добавили прямоугольник дня
            Rectangle cur_day = new Rectangle()
            {
                //Name = "day" + days_count.ToString(),
                Name = "day" + (day_num+1).ToString(),
                Width = 160 * zoom_coef,
                Height = 1600 * zoom_coef,
                Stroke = Brushes.Black,
                Fill = vb.hours_brush(zoom_coef)
            };
            canvasArea.Children.Add(cur_day);
            animation_opacity(cur_day, 0);

            day_rects.Add(cur_day);
            //MessageBox.Show(day_num.ToString() + "-vs-" + days_count.ToString());

            Canvas.SetLeft(cur_day, 20 + 159 * day_num * zoom_coef);

            Canvas.SetTop(cur_day, top_shift);



            if (canvasArea.Width <= 20 + 159 * (day_rects.Count()) * zoom_coef)
                canvasArea.Width = 20 + 159 * (day_rects.Count()) * zoom_coef + 30 + 400;


            Border cur_header = new Border()
            {
                Name = "headerbord" + day_num.ToString(),
                Width = 160 * zoom_coef,
                Height = 50,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Tag=dayRef,
                ToolTip=""
            };
            
            canvasArea.Children.Add(cur_header);
            

            Canvas.SetZIndex(cur_header, 9999);
            string header_text = "";
            if (var_num == 1)
            {
                header_text= day_name;
            }
            else
            {
                header_text = day_name + '\n' + "Вариант " + var_num.ToString();
            }

            string[] tb_name = header_text.Split('\n');
            CultureInfo russian = new CultureInfo("ru-RU");
            DateTime date = DateTime.Parse(tb_name[1]);

            cur_header.ToolTip = date.ToString("dd/MM/yyyy"); ;

            //Добавили заголовок дня
            cur_header.Child = new TextBlock()
            {
                Name = "headertext" + day_num.ToString(),
                Text = header_text,
                //Text = "headertext"+days_count-1.ToString(),
                Width = cur_header.Width - 2,
                Height = cur_header.Height - 2,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = Brushes.White,
                TextAlignment = TextAlignment.Center,
                FontSize = 14,
                Padding = new Thickness(1),
                FontWeight = FontWeights.SemiBold,
                LineStackingStrategy = LineStackingStrategy.BlockLineHeight,
                LineHeight = 15,
                
                //Tag = DateTime.Now.ToString()                
                Tag = wc.GetCurrentTime().ToString()
            };


            TextBlock cur_header_text = (TextBlock)cur_header.Child;
            //MessageBox.Show(dayRef);
            cur_header.Child.MouseLeftButtonDown += header_MouseDown;
            cur_header.Child.MouseLeftButtonUp += header_MouseUp;
            cur_header.Child.MouseRightButtonDown +=Child_MouseRightButtonDown;
            all_the_days.Add(cur_header_text);


            Canvas.SetTop(cur_header, day_top+sc_view.VerticalOffset);
            Canvas.SetLeft(cur_header, 20 + 159 * day_num  * zoom_coef);

            //cur_header.Tag = date.ToString("dd/MM/yyyy");
            animation_opacity(cur_header,0);

            //Добавляем шапку
            Border sh_bord= new Border()
            {
                Name = "sh_bord" + day_num.ToString(),
                Width = 160 * zoom_coef,
                Height = 50,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),                
            };
            canvasArea.Children.Add(sh_bord);



            //Добавили заглушку для вариантов
            /*
            Rectangle blinder = new Rectangle()
            {
                Width=150*zoom_coef,
                Height=20,
                Fill=Brushes.White,
                Opacity=1*show_variant_headers*0, // Отрубили
                Name = "blinder"+day_num.ToString()
            };
            Canvas.SetTop(blinder, 40);
            Canvas.SetLeft(blinder, 25 + 159 * day_num * zoom_coef);
            Canvas.SetZIndex(blinder, 500000);
            canvasArea.Children.Add(blinder);
            blinders.Add(blinder);
            */
            string sh_text_str = "";
            Canvas.SetZIndex(sh_bord, days_count - 1);
            int ch_code;
            if (dayRef != "" &! cur_header_text.Text.Contains("НТВ") &! cur_header_text.Text.Contains("Россия-1"))
            {

                sh_text_str = wc.GetVarTVDayParam(date, 10, var_num).Cap.Replace("#", "\n");
                days_to_check.Add((TextBlock)cur_header.Child);
            }
            else
            {
                TVDayVariantType[] variants = wc.GetDayVariants(date, 10);
                if (variants.Count()>0&! cur_header_text.Text.Contains("НТВ") &! cur_header_text.Text.Contains("Россия-1"))
                {
                    sh_text_str = wc.GetVarTVDayParam(date, 10, variants[0].VariantCode).Cap.Replace("#", "\n");
                }

            }

            double cur_font_size = 12;
            if (sh_text_str.Contains("$Ш"))
            {
                sh_text_str = sh_text_str.Substring(sh_text_str.IndexOf("$") + 3);
                cur_font_size = 10;
            }
            sh_bord.Child = new TextBlock()            
            {
                Name = "sh_text" + day_num.ToString(),
                Text = sh_text_str,
                //Text = "headertext"+days_count-1.ToString(),
                Width = cur_header.Width - 2,
                Height = cur_header.Height - 2,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                Background = Brushes.White,
                TextAlignment = TextAlignment.Center,
                FontSize = cur_font_size,
                Padding = new Thickness(1),
                //FontWeight = FontWeights.SemiBold,
                LineStackingStrategy = LineStackingStrategy.BlockLineHeight,
                LineHeight = cur_font_size+1,
                //Тэг - дата
                //Tag = DateTime.Now.ToString()
            };
            
            animation_opacity(sh_bord, 0);
            TextBlock sh_text = (TextBlock)sh_bord.Child;
            

            Canvas.SetTop(sh_bord, day_top+cur_header.Height);
            Canvas.SetLeft(sh_bord, 20 + 159 * day_num * zoom_coef);
            
            /*<TextBlock x:Name="header1" Height="38" Width="158" 
             * TextWrapping="Wrap" VerticalAlignment="Top" HorizontalAlignment="Center" 
             * \Background="White" Foreground="Black" ScrollViewer.VerticalScrollBarVisibility="Disabled" 
             * TextAlignment="Center" FontSize="14" Padding="1" Text="Понедельник&#xA;15/09/2014" FontWeight="SemiBold" 
             * LineStackingStrategy="BlockLineHeight" LineHeight="15" MouseEnter="header_MouseEnter" MouseLeave="header_MouseLeave"/>*/


            

            foreach (UIElement l in canvasArea.Children)
            {
                if (l.GetType() == typeof(Label))
                {
                    Label cur_label = (Label)l;
                    double pos = 0;
                    if (cur_label.Name.IndexOf("_") >= 0)
                    {
                        //pos = Convert.ToDouble(cur_label.Name.Substring(cur_label.Name.IndexOf("_") + 1, cur_label.Name.Length - cur_label.Name.IndexOf("_") - 1));
                        //pos = Convert.ToDouble(cur_label.Name.Right(2)) - 5;
                        //if (pos < 0) pos += 24;
                        pos = Convert.ToDouble(cur_label.Name.Right(cur_label.Name.Length - cur_label.Name.IndexOf("_") - 1)) - 5;
                        if (pos > 24) pos -= 76;                        
                        //Canvas.SetTop(cur_label, 74 + pos * 60 * zoom_coef);
                        //if (pos > 24) pos -= top_shift-4;                                                
                        Canvas.SetTop(cur_label, top_shift-6 + pos * 60 * zoom_coef);
                        if (cur_label.Name.Left(5) == "right")
                        {
                            Canvas.SetLeft(cur_label, (20 + days_count * 159 * zoom_coef));
                            //Canvas.SetLeft(cur_label, (20 + day_rects.Count() * 159 * zoom_coef));
                        }
                    }
                    //MessageBox.Show(cur_label.Name + '\n' + pos.ToString());
                }
            }

            //MessageBox.Show(day_rects.Count.ToString());
            Canvas.SetLeft(right_grid, (20 + days_count * 159 * zoom_coef));
            Canvas.SetTop(right_grid, top_shift);
            Canvas.SetTop(left_grid, top_shift);
            //Canvas.SetLeft(right_grid, (20 + day_rects.Count()* 159 * zoom_coef));
            
            /*
            animation_day_slide(right_grid, day_num + 2);
            foreach (Label l in right_labels)
            {
                animation_day_slide(l, day_num + 2);
            }
             */ 
            
        }

        /*
        private static TextBlock color_prog(TextBlock cur_text)
        {

            if (cur_text.Text.ToUpper().Contains("НОВОСТИ") || cur_text.Text.ToUpper() == "\"ВРЕМЯ\"") cur_text.Background = Brushes.Gold;
            if (cur_text.Text.ToUpper().Contains("ВЕСТИ")) cur_text.Background = Brushes.LightBlue;
            
            //if (cur_text.Text.ToUpper().Contains("НОВОСТИ") || cur_text.Text.ToUpper() == "\"ВРЕМЯ\"") cur_text.Background = Brushes.Green;
            return cur_text;
        }
        */

        private TextBlock create_prog(string prog_name, int day_num, double beg_time, double timing, double r_timing, int t_t, double a_timing, string code, string doc_number = null, int age = 0, int channel = 10)
        {



            double full_timing = timing + r_timing + a_timing;
            double end_time = beg_time + full_timing;
            /*
            string text_fill = beg_time.minutes_to_time() + " - " + end_time.minutes_to_time() +
                       " (" + timing.minutes_to_time().add_minute(r_timing).add_minute(a_timing) + ")" + '\n' +
                       prog_name.ToUpper() + '\n' +
                        "[" + timing.minutes_to_time() +
                        " + " + r_timing.ToString() + "Р(" + t_t.ToString() + ") + " + a_timing.ToString() + "А" +
                        "]" + '\n' + code;
            */

            prog_name = prog_name.Replace('#', '\n');

            string text_fill = "";
            text_fill = beg_time.minutes_to_time() + " - " + end_time.minutes_to_time() +
                       " (" + timing.minutes_to_time().add_minute(r_timing).add_minute(a_timing) + ")" + '\n' +
                       prog_name.ToUpper();
                       
          //  if (prog_name.ToUpper().Contains("НОВОСТИ"))                         
          //  {
          //      text_fill += " [" + timing.minutes_to_time();
          //  }
          //  else
          //  {
          //      text_fill+= '\n' + "[" + timing.minutes_to_time();
          //  }                    



            //text_fill += '\n' + "[" + timing.minutes_to_time();
            text_fill += "[" + timing.minutes_to_time();

            if (r_timing > 0) text_fill += " + " + r_timing.ToString() + "Р(" + t_t.ToString() + ")";
            if (a_timing>0) text_fill+=  " + " + a_timing.ToString() + "А";
            text_fill += "] " + "("+code+")";


            beg_time -= 5 * 60;

            shape_count += 1;
            
            string cur_name = "";
            if ((prog_name.ToUpper().Contains("ВОСКРЕСНОЕ \"ВРЕМЯ\"") || prog_name.ToUpper().Contains("НОВОСТИ") || prog_name.ToUpper() == "\"ВРЕМЯ\"") && !prog_name.ToUpper().Contains("В ПЕРЕРЫВЕ"))            
            {
                cur_name = string.Concat("news",day_num.ToString(),"_", shape_count.ToString());
            }
            else
            {
                cur_name = string.Concat("prog",day_num.ToString(),"_", shape_count.ToString());
            }
            
            //Добавляем тип программы в хвост имени:
            //если разорванная передача - d1 / d2 / ...
            //если обычная - s1

            //Пока все они - обычные
            cur_name = cur_name + "s1";

            String bord_name = string.Concat("bord",day_num.ToString(),"_", shape_count.ToString());

            Border cur_bord = new Border()
            {
                Name = bord_name,
                //Height = Convert.ToDouble(row["TimingText"].ToString().Substring(3, 2)),
                Height = (timing + r_timing + a_timing) * zoom_coef,
                Width = 160 * zoom_coef,
                Background = Brushes.Black,
                Tag = ""
            };

            Canvas.SetTop(cur_bord, beg_time * zoom_coef + top_shift);
            Canvas.SetLeft(cur_bord, day_num * 159 * zoom_coef + 20);
            Canvas.SetZIndex(cur_bord, shape_count);
            canvasArea.Children.Add(cur_bord);



      




            //string ads_timing = str_timing.ads();
            //string total_timing = "";


            cur_bord.Child = new TextBlock()
            {
                Name = cur_name,
                Background = Brushes.White,
                Text = text_fill,                
                //Text = cur_name,
                TextWrapping = TextWrapping.Wrap,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                FontSize = base_fontsize,
                LineStackingStrategy = System.Windows.LineStackingStrategy.BlockLineHeight,
                LineHeight = base_fontsize+1,
                Padding = new Thickness(2),
                Height = cur_bord.Height - 2,
                Width = cur_bord.Width - 2,
                IsManipulationEnabled=false,
                ToolTip = ""                
                
            };

            
            
            
            

            //xxx
            //MessageBox.Show(text_fill + '\n' + (text_fill.Length-49).ToString());
            



            TextBlock cur_text = (TextBlock)cur_bord.Child;
            if (doc_number!=null)
            {
                cur_text.Tag = doc_number;
            }

            

            //!шрифтcur_text.font();

            
            if (age > 0)
            {
                //myAdornerLayer = AdornerLayer.GetAdornerLayer(cur_text);
                myAdornerLayer.Add(new age_adorner(cur_text, age));                
            }

            /*
            if (age == 12)
            {
                AdornerLayer myAdornerLayer = AdornerLayer.GetAdornerLayer(cur_text);
                myAdornerLayer.Add(new twelve(cur_text));
            }
            if (age == 18)
            {
                AdornerLayer myAdornerLayer = AdornerLayer.GetAdornerLayer(cur_text);
                myAdornerLayer.Add(new eighteen(cur_text));
            }
            */
            //Забота о маленьких
            /*
            if (timing < 30)
            {
                cur_text.FontSize = 7;
                cur_text.LineStackingStrategy = System.Windows.LineStackingStrategy.BlockLineHeight;
                cur_text.LineHeight = 7;
            }
            */
             
            //Новости - наше золото!
            if ((prog_name.ToUpper().Contains("НОВОСТИ") || prog_name.ToUpper().Contains("\"ВРЕМЯ\"") || (prog_name.ToUpper().Contains("ВРЕМЯ") && prog_name.ToUpper().Contains("АНАЛИТИЧЕСКАЯ"))) && !prog_name.ToUpper().Contains("В ПЕРЕРЫВЕ")) cur_text.Background = Brushes.Gold;


            // Добавляем handler'ы для drag'n'drop
            cur_bord.Child.MouseLeftButtonDown += rect_MouseLeftButtonDown;
            cur_bord.Child.MouseMove += rect_MouseMove;
            cur_bord.Child.MouseLeftButtonUp += rect_MouseLeftButtonUp;

            cur_bord.Child.MouseRightButtonDown += Child_MouseRightButtonDown;
            
       //     cur_bord.Child.ManipulationDelta += rect_Manipulation;
            cur_bord.Child.ManipulationCompleted += rect_manipulation_started;

            //Добавили в коллекции
            progs.Add((TextBlock)cur_bord.Child);
            bords.Add(cur_bord);




            tb_keys(cur_text);
            cur_text.Text = cur_text.Text.Replace('#', '\n');
            animation_opacity(cur_bord, 0);


            return cur_text;
        }

        void Child_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            foreach (TextBlock tb in progs)
            {
                //tb.Background = Brushes.White;
                if (tb.Name.Left(4) == "news")
                {
                    tb.Background = Brushes.Gold;
                }
                else
                {
                    // tb.Background = Brushes.White;
                }
                Border cur_bord2 = (Border)tb.Parent;
                cur_bord2.BorderThickness = new Thickness(1);
                cur_bord2.BorderBrush = Brushes.Black;
            }

            foreach (TextBlock element in progs)
                element.Opacity = 1;

            foreach (Border element in bords)
            {
                element.Background = Brushes.Black;
                element.Opacity = 1;
            }

            VisualBrush vb = new VisualBrush();
            foreach (Rectangle element in day_rects)
            {
                element.Fill = vb.hours_brush(zoom_coef);
                element.Opacity = 1;
            }
            

            current_text = (TextBlock)sender;
            current_bord = (Border)current_text.Parent;
            
            if (current_text.Name.Left(4) == "prog" || current_text.Name.Left(4) == "news")
            {

                selected_progs.Clear();
                selected_progs.Add(current_text);
                //Ищем части разрезанных программ
                select_parts(current_text, e);

                foreach (UIElement uie in p_items)
                {
                    canvasArea.Children.Remove(uie);
                }
                p_items.Clear();
                simply_align(current_text, Canvas.GetLeft(current_bord), Canvas.GetTop(current_bord), e);
                //add_control_elements(cur_shape, e);

                foreach (TextBlock tb in selected_progs)
                {
                    //tb.Background = Brushes.LightBlue;
                    current_bord.BorderBrush = Brushes.CornflowerBlue;
                    current_bord.BorderThickness = new Thickness(3);
                }

                new_double_click(current_text, e);

                hold_seconds = 0;
                hold_timer.Stop();
            }
            if (current_text.Name.Left(6) == "header")
            {
                Border cur_bord = new Border();
                foreach (TextBlock tb in selected_days)
                {
                    cur_bord = (Border)tb.Parent;
                    cur_bord.BorderThickness = new Thickness(1);
                    cur_bord.BorderBrush = Brushes.Black;
                }
                selected_days.Clear();

                Flyout_day.IsOpen = true;
                Flyout_day.Width = main_window.ActualWidth - 200;
                Flyout_bottom.IsOpen = false;


                selected_days.Add(current_text);




                ch_rus1.Opacity = 0.3;
                ch_ntv.Opacity = 0.3;
                ch_sts.Opacity = 0.3;
                ch_tnt.Opacity = 0.3;



                foreach (UIElement tb in canvasArea.Children)
                {
                    if (tb.GetType() == typeof(Border))
                    {

                        Border cur_tb = (Border)tb;
                        TextBlock day_text = (TextBlock)cur_tb.Child;
                        if (cur_tb.Name.Left(10) == "headerbord")
                        {
                            string s1 = current_bord.ToolTip.ToString();
                            string s2 = cur_tb.ToolTip.ToString();
                            if (current_bord.ToolTip.ToString() == cur_tb.ToolTip.ToString())
                            {
                                if (day_text.Text.Contains("Россия-1")) ch_rus1.Opacity = 1;
                                if (day_text.Text.Contains("НТВ")) ch_ntv.Opacity = 1;
                            }
                        }

                    }
                }


                ch_activate();
                day_title.Text = selected_days[0].Text.Replace("\n", "#");
            }
        }



        private TextBlock tb_keys(TextBlock cur_text)
        {
            //Обработка ключей
            Border cur_bord = (Border)cur_text.Parent;
            
            forced_fontsize = base_fontsize;
            string cur_string = cur_text.Text;
            string cur_key = "";
            string temp = "";
            cur_bord.Tag = "";


            cur_text.FontSize = forced_fontsize;
            cur_text.LineHeight = forced_fontsize+1;
            cur_bord.Background = Brushes.Black;
            cur_text.Text = cur_text.Text.Replace("#####[", "[");
            cur_text.FontStyle = FontStyles.Normal;
            cur_text.FontWeight = FontWeights.Normal;
            if (cur_text.Background == Brushes.LightGray) cur_text.Background = Brushes.White;

            
            

            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1;
            myDoubleAnimation.To = 1;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(1000));

            this.RegisterName(cur_text.Name, cur_text);
            
            Storyboard.SetTargetName(myDoubleAnimation, cur_text.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(TextBlock.OpacityProperty));
            Storyboard opac_sb = new Storyboard();
            opac_sb.Children.Add(myDoubleAnimation);
            opac_sb.RepeatBehavior = RepeatBehavior.Forever;
            opac_sb.AutoReverse = true;

            try
            {
                opac_sb.Begin(cur_text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }



            

            if (cur_text.Text.Contains("$Ш") || cur_text.Text.Contains("$Х") ||cur_text.Text.Contains("$X") ||cur_text.Text.Contains("$C") ||cur_text.Text.Contains("$С") ||cur_text.Text.Contains("$Ц"))
            {
                while (cur_string.IndexOf("$") >= 0)
                {
                    temp = cur_string.Substring(cur_string.IndexOf("$") + 1, 1);
                    //Размер шрифта
                    if (cur_string.Substring(cur_string.IndexOf("$") + 1, 1) == "Ш")
                    {
                        cur_key = cur_string.Substring(cur_string.IndexOf("$"), 3);
                        forced_fontsize = Convert.ToDouble(cur_key.Right(1)) + 1;
                        cur_bord.Tag = cur_bord.Tag.ToString() + cur_key;
                        cur_string = cur_string.Replace(cur_key, "");
                    }
                    //Загадочный ключ
                    if (cur_string.Substring(cur_string.IndexOf("$") + 1, 1) == "X" || cur_string.Substring(cur_string.IndexOf("$") + 1, 1) == "Х")
                    {
                        cur_key = cur_string.Substring(cur_string.IndexOf("$"), 2);
                        cur_bord.Tag = cur_bord.Tag.ToString() + cur_key;
                        //cur_string.Insert(cur_string.LastIndexOf("[") - 2, "#####");
                        cur_string = cur_string.Replace(cur_string.Substring(cur_string.LastIndexOf("["), 1), "#####[");
                        cur_string = cur_string.Replace(cur_key, "");
                    }
                    //Заливка
                    if (cur_string.Substring(cur_string.IndexOf("$") + 1, 1) == "C" || cur_string.Substring(cur_string.IndexOf("$") + 1, 1) == "С")
                    {
                        
                        cur_key = cur_string.Substring(cur_string.IndexOf("$"), 4);
                        //Без нюансов, так сказать...
                        try
                        {
                            if (Convert.ToDouble(cur_key.Right(2))>0)
                            {
                                cur_text.Background = Brushes.LightGray;
                            }
                            else
                            {
                                cur_text.Background = Brushes.White;
                            }
                            cur_bord.Tag = cur_bord.Tag.ToString() + cur_key;
                            cur_string = cur_string.Replace(cur_key, "");
                        }
                        catch (Exception e)
                        {
                            
                        }
                        
                        
                    }
                    //Заливка фона
                    if (cur_string.Substring(cur_string.IndexOf("$") + 1, 1) == "Ц")
                    {
                        cur_key = cur_string.Substring(cur_string.IndexOf("$"), 4);
                        //Blink-blink
                        if (cur_key.Right(2) == "00")
                        {
                            cur_bord.Background = Brushes.Red;
                            //DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                            myDoubleAnimation.From = 0.6;
                            myDoubleAnimation.To = 0.99;
                            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(3000));
                            this.RegisterName(cur_text.Name, cur_text);
                            
                            Storyboard.SetTargetName(myDoubleAnimation, cur_text.Name);
                            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(TextBlock.OpacityProperty));
                            
                            //Storyboard opac_sb = new Storyboard();
                            opac_sb.Children.Add(myDoubleAnimation);
                            opac_sb.RepeatBehavior = RepeatBehavior.Forever;
                            opac_sb.AutoReverse = true;



                            try
                            {
                                opac_sb.Begin(cur_text);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.ToString());
                            }

                        }


                        cur_bord.Tag = cur_bord.Tag.ToString() + cur_key;
                        cur_string = cur_string.Replace(cur_key, "");
                        
                    }
                }

                cur_text.Text = cur_string;

            }
            if (cur_string.Contains("\\B1") || cur_string.Contains("\\B0"))
            {
                cur_text.FontWeight = FontWeights.Bold;

                    cur_bord.Tag = cur_bord.Tag.ToString() + "\\B";
                
                while (cur_string.Contains("\\B"))
                {
                    cur_string = cur_string.Replace("\\B1", "");
                    cur_string = cur_string.Replace("\\B0", "");
                }
            }
            if (cur_string.Contains("\\B"))
            {
                cur_text.FontWeight = FontWeights.Bold;
                
                    cur_bord.Tag = cur_bord.Tag.ToString() + "\\B";
               
                while (cur_string.Contains("\\B"))
                {
                    cur_string = cur_string.Replace("\\B", "");
                }
            }
            if (cur_string.Contains("\\I"))
            {
                cur_text.FontStyle = FontStyles.Italic;
                
                    cur_bord.Tag = cur_bord.Tag.ToString() + "\\I";
                
                while (cur_string.Contains("\\I"))
                {
                    cur_string = cur_string.Replace("\\I", "");
                }
            }
            


            cur_text.FontSize = forced_fontsize;
            cur_text.LineHeight = forced_fontsize;
            cur_text.Text = cur_string;

            return cur_text;
        }


        private void rect_manipulation_started(object sender, ManipulationCompletedEventArgs e)
        {
            MessageBox.Show("fff");
        }

        private void button_manipulation(object sender, ManipulationDeltaEventArgs e)
        {
            header1.Text = e.DeltaManipulation.Translation.ToString();
        }
        private void rect_Manipulation(object sender, ManipulationDeltaEventArgs e)
        {
            //header1.Text=e.DeltaManipulation.Scale.Length.ToString();
            
            
            if (e.DeltaManipulation.Scale.X != 0 && e.DeltaManipulation.Scale.X != 1)
            {
                //zoom_slider.Value *= e.DeltaManipulation.Scale.X;
                
                header1.Text = (e.DeltaManipulation.Scale.X).ToString();
                zoom_coef *= e.DeltaManipulation.Scale.X;
                if (zoom_coef > 2) zoom_coef = 2;
                if (zoom_coef < 0.5) zoom_coef = 0.5;
               
                zoom_slider.Value = zoom_coef;
            }
                //double dd = 1 - Convert.ToDouble(e.DeltaManipulation.Scale);
            //double d = zoom_coef -dd;
            //zoom_slider.Value = d;
            
            
            dummy *= e.DeltaManipulation.Scale.X;
            //header1.Text = dummy.ToString();
            header1.Text = e.DeltaManipulation.Scale.X.ToString();

        }


        private void ReadFileButton_Click(object sender, RoutedEventArgs e, string filename)
        {



            try
            {
                using (StreamReader sr = new StreamReader(filename, Encoding.GetEncoding(1251)))
                {
                    //String line = await sr.ReadToEndAsync();
                    //       ResultBlock.Text = line;
                    int counter = 0;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (counter < 10)
                            //Находим строчку со временем
                            //  ResultBlock.Text += line.Substring(2, 1);
                            //line.su
                            //MessageBox.Show(line);
                            counter++;
                    }

                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                //ResultBlock.Text = "Could not read the file";
            }
        }

        public class MyAdorner : Adorner
        {
            public MyAdorner(UIElement targetElement) : base(targetElement) { }

            protected override void OnRender(DrawingContext drawingContext)
            {
                Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
                drawingContext.DrawRectangle(null, new Pen(Brushes.Red, 1), adornedElementRect);
            }


        }


        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            /*AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this.Tue);
            MyAdorner myAdorner = new MyAdorner(this.Tue);
            adornerLayer.Add(myAdorner);
            */

            /*if (System.Windows.SystemParameters.PrimaryScreenHeight < 1200)
            {
                zoom_coef = 0.9;
                zoom_slider.Value = 0.9;
            }
            if (System.Windows.SystemParameters.PrimaryScreenHeight > 1200)
            {
                zoom_coef = 1.1;
                zoom_slider.Value = 1.1;

            }
             */
            //Пока так, потому что криво считает
            zoom_coef = 1;
            zoom_slider.Value = 1;

            Canvas.SetTop(bg_rect, top_shift);            

            myAdornerLayer = AdornerLayer.GetAdornerLayer(bg_rect);
            
            
            Style style = new Style(typeof(Label));
            //style.Setters.Add(new Setter(Label.BackgroundProperty, Brushes.Green));

            Resources.Add(typeof(Label), style);

            // right_05.Style = style;
            foreach (UIElement l in canvasArea.Children)
            {
                if (l.GetType() == typeof(Label))
                {
                    Label cur_label = (Label)l;
                    if (cur_label.Name.Length >= 5)
                    {
                        if (cur_label.Name.Right(5) == "right")
                        {
                            double pos = 0;
                            //pos = Convert.ToDouble(cur_label.Name.Substring(cur_label.Name.IndexOf("_") + 1, cur_label.Name.Length - cur_label.Name.IndexOf("_") - 1));
                            //pos = Convert.ToDouble(cur_label.Name.Right(2));
                            pos = Convert.ToDouble(cur_label.Name.Right(cur_label.Name.Length - cur_label.Name.IndexOf("_") - 1)) - 5;
                            if (pos > 24) pos -= 76;
                            //Canvas.SetTop(cur_label, 74 + (pos - 5) * 60 * zoom_coef);
                            //if (pos > 24) pos -= top_shift - 4;
                            Canvas.SetTop(cur_label, top_shift - 6 + pos * 60 * zoom_coef);
                        }
                    }
                    //MessageBox.Show(cur_label.Name + '\n' + pos.ToString());
                }
            }


            //MessageBox.Show(this_rect.Parent.GetType().ToString());



            //Разбираемся с набором ТВНедель

            try 
            {
                draw_first_week();
                connected = true;
            }
            catch
            {
                connected = false;
            }

            
            


            

            DispatcherTimer aTimer = new DispatcherTimer();
            aTimer.Interval = new TimeSpan(0, 0, 5);
            aTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            aTimer.IsEnabled = true;
        }

            

        private void draw_first_week()
        {
            TVWeekType[] available_weeks = wc.GetWeeks();


            foreach (TVWeekType week in available_weeks)
            {
                all_weeks.Add(week);
                if (week.Letuchka == true)
                {
                    l_weeks.Add(week);
                    InkCanvas cur_icanvas = new InkCanvas();
                    Canvas.SetLeft(cur_icanvas, 0);
                    Canvas.SetTop(cur_icanvas, 0);
                    Canvas.SetZIndex(cur_icanvas, 100000);
                    cur_icanvas.Width = 2000;
                    cur_icanvas.Height = 1600;
                    cur_icanvas.Opacity = 1;
                    cur_icanvas.Background = null;
                    cur_icanvas.IsHitTestVisible = false;
                    ink_canvases.Add(cur_icanvas);
                    cur_icanvas.IsEnabled = false;
                    cur_icanvas.Tag = week.Ref;
                }
            }



            if (l_weeks.Count() > 0)
            {
                week_construct(l_weeks[0]);
                cur_week_ref = l_weeks[0].Ref;
                window_title_variants();
                
                timestamp.Content = DateTime.Now.ToString();
                //timestamp.Content = wc.GetCurrentTime().ToString();
                if (days_count >= 1) Canvas.SetLeft(timestamp, 80 + (days_count - 1) * 159 * zoom_coef);

                visible_canvas = ink_canvases[0];

                canvasArea.Children.Add(visible_canvas);
                foreach (InkCanvas ic in ink_canvases)
                {
                    ic.IsEnabled = false;
                }
                visible_canvas.IsEnabled = true;
                //Canvas.SetZIndex(visible_canvas, 100000);
                visible_canvas.Width = canvasArea.Width;
                visible_canvas.Height = canvasArea.Height;
                
                main_window.Title = main_window.Title.Replace(main_window.Title.Substring(main_window.Title.IndexOf("[")+1, 8), l_weeks[0].BegDate.ToString("dd.MM.yy", CultureInfo.InvariantCulture));
            }
        }
          

        // Specify what you want to happen when the Elapsed event is raised.
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            
            //Разбираемся с набором ТВНедель
            try
            {
                TVWeekType[] available_weeks = wc.GetWeeks();

                l_weeks.Clear();
                all_weeks.Clear();
                foreach (TVWeekType week in available_weeks)
                {
                    all_weeks.Add(week);
                    if (week.Letuchka == true)
                    {
                        l_weeks.Add(week);
                    }
                }

                connected = true;
                if (main_window.Title.Right(15) == " (disconnected)")
                {
                    main_window.Title = main_window.Title.Left(main_window.Title.Length - 15);
                }

                

            }
            catch (Exception ex)
            {
                connected = false;
                if (main_window.Title.Right(15) != " (disconnected)")
                {
                    main_window.Title += " (disconnected)";
                }
            }


            window_title_variants();
            
            
            


            /*
            
            //Проверяем, изменились ли дни
            foreach (UIElement child in canvasArea.Children)
            {
                if (child.GetType() == typeof(Border))
                {
                    Border cur_bord = (Border)child;
                    TextBlock cur_text = (TextBlock)cur_bord.Child;

                    if (cur_bord.Name.Left(10) == "headerbord" && !cur_text.Text.Contains("Россия-1") && !cur_text.Text.Contains("НТВ"))
                    {
                        days_to_check.Add(cur_text);
                        //break;
                    }
                }

            }

             */

            if (connected)
            {
                TVDayVariantT[] t = new TVDayVariantT[days_to_check.Count()];
                //DateTime date = DateTime.Now;
                DateTime date = wc.GetCurrentTime();
                string cur_time = date.ToString();
                TVDayVariantT[] t_res;
                int i_counter = 0;
                int variant = 0;

                

                foreach (TextBlock tb in days_to_check)
                {
                    Border cur_bord = (Border)tb.Parent;
                    if (tb.Text.IndexOf(" ") >= 0)
                    {
                        //MessageBox.Show(tb.Text.Substring(tb.Text.LastIndexOf(" ")+1, 1));
                        variant = Convert.ToInt32(tb.Text.Substring(tb.Text.LastIndexOf(" ") + 1, 1));
                    }
                    else
                    {
                        variant = 1;
                    }


                    string[] tb_name = tb.Text.Split('\n');
                    CultureInfo russian = new CultureInfo("ru-RU");
                    DateTime date2 = DateTime.Parse(tb_name[1]);
                    //if (Convert.ToDateTime(tb.Tag.ToString())<date) date = Convert.ToDateTime(tb.Tag.ToString());
                    if (date >= Convert.ToDateTime(tb.Tag.ToString()))
                    date = Convert.ToDateTime(tb.Tag.ToString());
                    //Ругается на что-то


                    //TVDayVariantParam vpar = wc.GetVarTVDayParam(date2, 10, variant);

                    t[i_counter] = new TVDayVariantT();
                    //t[i_counter].TVDayRef = vpar.TVDayRef;
                    t[i_counter].TVDayRef = cur_bord.Tag.ToString();
                    t[i_counter].VariantNumber = variant;
                    i_counter += 1;

                }
                //TVDayVariantT[] rez = wc.CheckVariants(t, date);

                /*
                TVDayVariantT[] tvd_vars = new TVDayVariantT[1];
                //DateTime test = DateTime.Now;
                TVDayVariantParam vpar2 = wc.GetVarTVDayParam(new DateTime(2014, 11, 03), 10, 6);
                tvd_vars[0] = new TVDayVariantT();
                tvd_vars[0].TVDayRef = vpar2.TVDayRef;
                tvd_vars[0].VariantNumber = 6;
                      */
                DateTime cur_dt = new DateTime(2014, 11, 19, 12, 0, 0);
                //TVDayVariantT[] rez = wc.CheckVariants(t, cur_dt);
                try
                {
                    TVDayVariantT[] rez = wc.CheckVariants(t, date);
                    if (rez.Count() > 0)
                    {
                        int day_num = -1;
                        foreach (TextBlock tb in days_to_check)
                        {

                            Debug.WriteLine("Дни для перерисовки: " + rez.Count().ToString());
                            day_num += 1;
                            Border cb = (Border)tb.Parent;
                            if (tb.Text.IndexOf(" ") >= 0)
                            {
                                //MessageBox.Show(tb.Text.Substring(tb.Text.LastIndexOf(" ")+1, 1));
                                variant = Convert.ToInt32(tb.Text.Substring(tb.Text.LastIndexOf(" ") + 1, 1));
                            }
                            else
                            {
                                variant = 1;
                            }
                            string[] tb_name = tb.Text.Split('\n');
                            CultureInfo russian = new CultureInfo("ru-RU");
                            string cur_date = tb_name[1];


                            TVDayVariantParam vpar2 = wc.GetVarTVDayParam(DateTime.Parse(cur_date), 10, variant);
                            
                            foreach (TVDayVariantT tvd in rez)
                            {
                                if (vpar2.TVDayRef.ToString() == tvd.TVDayRef.ToString())
                                {
                                    //Обновляем день
                                    WeekTVDayType wd = new WeekTVDayType();
                                    wd.KanalKod = 10;
                                    wd.TVDate = vpar2.TVDate;
                                    wd.TVDayRef = vpar2.TVDayRef;
                                    wd.VariantKod = variant;

                                    
                                    //RoutedEventArgs k = new RoutedEventArgs();
                                    //right_shift_days(e);
                                    //delete_day_Click(tb, e);
                                    //create_day(tb.Text, day_num, variant, vpar2.TVDayRef);


                                    List<Border> progs2remove = new List<Border>();
                                    foreach (UIElement el in canvasArea.Children)
                                    {
                                        if (el.GetType() == typeof(Border))
                                        {
                                            Border cur_bord = (Border)el;
                                            TextBlock cur_text = (TextBlock)cur_bord.Child;
                                    
                                            int llen = 0;
                                            if (day_num<10)
                                            {
                                                llen = 1;
                                            }
                                            else
                                            {
                                                llen = 2;
                                            }
                                            if (cur_text.Name.Left(4+llen) == "prog" + day_num.ToString() || cur_text.Name.Left(5) == "news" + day_num.ToString())
                                            {
                                                progs2remove.Add(cur_bord);
                                            }
                                            if (cur_text.Name.Left(7+llen)=="sh_text"+day_num.ToString())
                                            {
                                                cur_text.Text = vpar2.Cap;
                                            }
                                        }
                                    }

                                    foreach (Border b in progs2remove)
                                    {
                                        canvasArea.Children.Remove(b);
                                    }

                                    
                                    //tb.Tag = DateTime.Now.ToString();
                                    
                                    day_construct(wd, day_num);
                                }
                            }
                        }
                        //timestamp.Content = DateTime.Now.ToString();
                        timestamp.Content = cur_time;
                    }

                    foreach (TextBlock tb in days_to_check)
                    {
                        //tb.Tag = DateTime.Now.ToString();
                        tb.Tag = cur_time;
                    }
                }

                catch (Exception ex)
                {
                    return;
                }

            }
            
            
            


            //t_res = wc.CheckVariants(t, cur_dt);
            //Debug.WriteLine("");

        }




        private void window_title_variants()
        {            
            List<Border> bords_to_remove = new List<Border>();
            foreach (UIElement el in sp_header_variants.Children)
            {
                if (el.GetType() == typeof(Border))
                {
                    Border cur_bord = (Border)el;
                    bords_to_remove.Add(cur_bord);
                }
            }

            Debug.WriteLine("Удалили " +bords_to_remove.Count().ToString()+" картинки");
            foreach(Border b in bords_to_remove)
            {
                sp_header_variants.Children.Remove(b);
            }

            /*
                for (int i = 1; i <= l_weeks.Count(); i++)
                {
                    Border my_bord = new Border();
                    my_bord.Padding = new Thickness(4, 0, 4, 0);

                    Rectangle my_rect = new Rectangle();
                    my_bord.Child = my_rect;

                    my_rect.Width = 20;
                    my_rect.Height = 20;


                    string my_string = "appbar_page_number_";
                    int var_num = i;
                    if (i > 1)
                    {
                        my_string = my_string + var_num.ToString();
                    }
                    else
                    {
                        my_string = my_string + "!";
                    }
                    VisualBrush myvb = new VisualBrush() { Visual = (Visual)Resources[my_string] };
                    my_rect.Fill = Brushes.White;
                    my_rect.OpacityMask = myvb;


                    sp_header_variants.Children.Add(my_bord);
                }
            */

            //Наверху цикл рисует плашки по количеству недель
            //Здесь рисуется только одна плашка с количеством недель
            Border my_bord = new Border();
            my_bord.Padding = new Thickness(4, 0, 4, 0);

            Rectangle my_rect = new Rectangle();
            my_bord.Child = my_rect;

            my_rect.Width = 20;
            my_rect.Height = 20;


            //string my_string = "appbar_page_number_";
            string my_string = "appbar_card_";
            int var_num = l_weeks.Count();
            if (l_weeks.Count() >= 1 && l_weeks.Count()<10)
            {
                my_string = my_string + var_num.ToString();
            }
            else
            {
                //my_string = my_string + "!";
            }
            VisualBrush myvb = new VisualBrush() { Visual = (Visual)Resources[my_string] };
            my_rect.Fill = Brushes.White;
            my_rect.OpacityMask = myvb;


            sp_header_variants.Children.Add(my_bord);

            
        }

        void week_destroy(object sender, EventArgs e)
        {
            
            Rectangle cur_rect;
            TextBlock cur_tb;
            string cur_tag="";

            if (sender.GetType() == typeof(Rectangle))
            {
                cur_rect = (Rectangle)sender;
                cur_tag = cur_rect.Tag.ToString();
            }
            if (sender.GetType() == typeof(TextBlock))
            {
                cur_tb = (TextBlock)sender;
                cur_tag = cur_tb.Tag.ToString();
            }
            
            //MessageBox.Show(cur_element.GetType().ToString());
            selected_days.Clear();
            days_to_check.Clear();
            progs.Clear();
            TextBlock cur_shape = new TextBlock();
            for (int i = 0; i < days_count; i++)
            {
                foreach (UIElement el in canvasArea.Children)
                {
                    if (el.GetType() == typeof(Border))
                    {
                        Border cur_bord = (Border)el;
                        if (cur_bord.Name.Left(10)=="headerbord")
                        {
                            cur_shape = (TextBlock)cur_bord.Child;
                            selected_days.Add(cur_shape);
                            break;
                        }
                    }
                }                
            }
            
            delete_day_Click(cur_shape, (RoutedEventArgs)e);

            
            for (int i = 0; i<days_count; i++)
            {
                
            }


            List<Border> headers2remove = new List<Border>();
            foreach (UIElement el in canvasArea.Children)
            {
                if (el.GetType() == typeof(Border))
                {
                    Border cur_bord = (Border)el;
                    headers2remove.Add(cur_bord);
                    //MessageBox.Show(cur_bord.Name);
                }
            }
            foreach(Border b in headers2remove)
            {
                canvasArea.Children.Remove(b);
            }



            //Рисуем новую неделю
            foreach (TVWeekType week in all_weeks)
            {
                if (cur_tag == week.Ref)
                {
                    week_construct(week);
                    cur_week_ref = week.Ref;
                    main_window.Title = main_window.Title.Replace(main_window.Title.Substring(main_window.Title.IndexOf("[") + 1, 8), week.BegDate.ToString("dd.MM.yy", CultureInfo.InvariantCulture));
                    //Canvas.SetZIndex(visible_canvas, 100000);
                    canvasArea.Children.Remove(visible_canvas);
                    //visible_canvas = ink_canvases[l_weeks.IndexOf(week)];
                    bool canvas_found = false;
                    foreach( InkCanvas ic in ink_canvases)
                    {
                        ic.IsEnabled = false;
                        if (ic.Tag.ToString()==cur_week_ref)
                        {
                            visible_canvas = ic;
                            canvas_found = true;
                        }
                    }
                    if (!canvas_found)
                    {
                        visible_canvas = new InkCanvas();
                        Canvas.SetLeft(visible_canvas, 0);
                        Canvas.SetTop(visible_canvas, 0);
                        Canvas.SetZIndex(visible_canvas, 100000);
                        visible_canvas.Width = 2000;
                        visible_canvas.Height = 1600;
                        visible_canvas.Opacity = 1;
                        visible_canvas.Background = null;
                        visible_canvas.IsHitTestVisible = false;
                        ink_canvases.Add(visible_canvas);
                        visible_canvas.IsEnabled = false;
                        visible_canvas.Tag = cur_week_ref;
                    }
                    visible_canvas.IsEnabled = true;
                    canvasArea.Children.Add(visible_canvas);
                    visible_canvas.Width = canvasArea.Width;
                    visible_canvas.Height = canvasArea.Height;
                    break;
                }
            }
            timestamp.Content = DateTime.Now.ToString();
            //timestamp.Content = wc.GetCurrentTime().ToString();
            if (days_count >= 1) Canvas.SetLeft(timestamp, 80 + (days_count - 1) * 159 * zoom_coef);
            Flyout_top.IsOpen = false;

        }



        private void week_construct(TVWeekType week)
        {
            int[] array_channel_codes = new int[3];
            array_channel_codes[0] = 10;
            array_channel_codes[1] = 21;
            array_channel_codes[2] = 40;
            WeekTVDayType[] weekTVday = wc.GetWeekTVDays(week.Ref, array_channel_codes);
            
            foreach (WeekTVDayType wtvday in weekTVday)
            {
                
                CultureInfo russian = new CultureInfo("ru-RU");
                string dayName = wtvday.TVDate.ToString("dddd", russian);
                dayName = dayName.Substring(0, 1).ToUpper() + dayName.Substring(1, dayName.Length - 1) +
                         '\n' + wtvday.TVDate.ToString("dd/MM/yyyy");
                
                create_day(dayName, days_count, wtvday.VariantKod, wtvday.TVDayRef);
                day_construct(wtvday);

                


                
            }

        }

        private void day_construct(WeekTVDayType tvday, int day_num=1000)
        {


            if (day_num == 1000)
            {
                day_num = days_count - 1;
            }

            

            EfirType[] efirs = wc.GetEfirs(tvday.TVDate, tvday.KanalKod, tvday.VariantKod);

            string DayRef = "";
            if (efirs.Length > 0)
            {
                DayRef = efirs[1].TVDayRef;
            }

            for (int j = 0; j < efirs.Length; j++)
            {
                //MessageBox.Show(efirs[i].Beg.Hour.ToString());


                int t = 0;
                double r = 0;
                double a = 0;
                double raw_timing = efirs[j].Timing;
                string beg_time = efirs[j].Beg.Hour.ToString() + ":" + efirs[j].Beg.Minute.ToString();
                beg_time = beg_time.leading_zeros();
                if (tvday.TVDate < efirs[j].Beg.Date.Date) beg_time = (beg_time.time_to_minutes() + 24 * 60).ToString();
                if (efirs[j].ITC.Length > 0)
                {
                    foreach (ITCType itc in efirs[j].ITC)
                    {

                        if (itc.Title == "Р" || itc.Title == "Р99" || itc.Title == "СР")
                        {
                            r += itc.Timing;
                            if (itc.Title == "Р") t += itc.PointCount;
                        }
                        if (itc.Title == "А")
                        {
                            a += itc.Timing;
                        }
                    }
                }

                raw_timing = raw_timing - r - a;
                raw_timing = raw_timing / 60;
                raw_timing = Math.Floor(raw_timing / 1);

                r /= 60;
                a /= 60;
                //r = Math.Ceiling(r);
                //a = Math.Ceiling(a);
                r = Math.Round(r);
                a = Math.Round(a);

                string s_timing = raw_timing.minutes_to_time();
                string code = efirs[j].ProducerCode.ToString() + efirs[j].SellerCode.ToString();
                string doc_number = efirs[j].Ref;
                
                //string t_timing = efirs[i].Timing
                //Debug.WriteLine(efirs[j].Title + " -- " + beg_time.leading_zeros() + "--" + efirs[j].Timing.ToString());
                //Создаем программы


                //Добавляем х часов к времени начала на орбитах: все по местному времени
                if (tvday.KanalKod >= 11 && tvday.KanalKod <= 14)
                    beg_time = beg_time.add_minute((10 - (tvday.KanalKod - 10) * 2) * 60);


                TextBlock cur_prog = new TextBlock();
                //!!!if (raw_timing >= 5)  cur_prog = create_prog(efirs[j].Title, day_num, beg_time.time_to_minutes(), raw_timing, r, t, a, code, doc_number, Convert.ToInt32(efirs[j].Age)); 
                if (raw_timing >= 5) cur_prog = create_prog(efirs[j].ANR, day_num, beg_time.time_to_minutes(), raw_timing, r, t, a, code, doc_number, Convert.ToInt32(efirs[j].Age));

                Border cur_bord = (Border)cur_prog.Parent;
                
                
                

                if (tvday.KanalKod == 21)
                {
                    cur_prog.Background = Brushes.AliceBlue;
                    if (cur_prog.Text.ToUpper().Contains("ВЕСТИ")) cur_prog.Background = Brushes.LightBlue;
                    
                }
                if (tvday.KanalKod == 40)
                {
                    cur_prog.Background = Brushes.LightGreen;
                    if (cur_prog.Text.ToUpper().Contains("СЕГОДНЯ")) cur_prog.Background = Brushes.LawnGreen;
                }
                
                

            }
        }

        /*
        private void Buf_MouseDown(object sender, MouseButtonEventArgs e)
        {


            foreach (TextBlock element in temp_text)
            {
                if (element.Visibility == Visibility.Visible)
                {
                    element.Visibility = Visibility.Hidden;
                    Border cur_bord = (Border)element.Parent;
                    cur_bord.Visibility = Visibility.Hidden;
                }
                else
                {
                    element.Visibility = Visibility.Visible;
                    Border cur_bord = (Border)element.Parent;
                    cur_bord.Visibility = Visibility.Visible;
                }
            }

        }
        */
        private void search_string_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            //search_string.Text = "";
            tb.Text = "";
        }

        private void search_string_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                //Button_Click(sender,e);
                create_infosheet(sender, e);

            }
        }



        private void update_duration_time_text(TextBlock prog_text, string timestart, string duration, string r_str, string a_str, string t_str)
        {
            Border cur_bord = (Border)prog_text.Parent;
            string total_dur1 = "";
            string total_dur2 = "";
            total_dur1 = prog_text.Text.Substring(prog_text.Text.IndexOf("("), prog_text.Text.IndexOf(")") - prog_text.Text.IndexOf("(") + 1);


            //Правим текст в квадратных скобках
            string sq_br_text = duration;
            if (Convert.ToDouble(r_str) != 0)
            {
                sq_br_text += " + " + r_str + "Р(" + t_str + ")";
            }
            if (Convert.ToDouble(a_str) != 0)
            {
                sq_br_text += " + " + a_str + "А";
            }            

            string prev_sq_br_text = prog_text.Text.sqbr();


            //prog_text.Text = prog_text.Text.Replace(prog_text.Text.Substring(prog_text.Text.IndexOf("[") + 1, prog_text.Text.IndexOf("]") - prog_text.Text.IndexOf("[") - 1), sq_br_text);
            prog_text.Text = prog_text.Text.Replace("[" + prev_sq_br_text + "]", "[" + sq_br_text+"]");

            string replacement_str = "(" + duration.add_minute(Convert.ToDouble(r_str)).add_minute(Convert.ToDouble(a_str)) + ")";
            prog_text.Text = prog_text.Text.Replace(total_dur1, replacement_str);
            total_dur2 = prog_text.Text.Substring(prog_text.Text.IndexOf("(") + 1, prog_text.Text.IndexOf(")") - prog_text.Text.IndexOf("(") - 1);
            total_dur1 = total_dur1.Substring(1, total_dur1.Length - 2);
            cur_bord.Height += total_dur2.time_to_minutes() - total_dur1.time_to_minutes();
            prog_text.Height += total_dur2.time_to_minutes() - total_dur1.time_to_minutes();



            string total_str = timestart + " - " + timestart.add_minute(total_dur2.time_to_minutes());
            prog_text.Text = prog_text.Text.Replace(prog_text.Text.Substring(0, prog_text.Text.IndexOf("(") - 1), total_str);


            double beg_time = Convert.ToDouble(timestart.time_to_minutes());

            if ((beg_time / 60) < 5)
            {
                beg_time += 24 * 60;
            }
            beg_time -= 5 * 60;

            
            Canvas.SetTop(cur_bord, beg_time * zoom_coef + top_shift);
            Canvas.SetTop(prog_text, beg_time * zoom_coef + top_shift);
            //Ключи
            tb_keys(prog_text);
        }

        private void update_prog(object sender, EventArgs e)
        {

                Button cur_button = (Button)sender;
                Label label_timestart_hours = (Label)timestart_hours.Content;
                Label label_timestart_minutes = (Label)timestart_minutes.Content;

                Label label_duration_hours = (Label)duration_hours.Content;
                Label label_duration_minutes = (Label)duration_minutes.Content;
                Label label_r = (Label)r.Content;
                Label label_t = (Label)t.Content;
                Label label_a = (Label)a.Content;                                
                //tb_title.Text;
             
            



            if (selected_progs.Count() == 2 && cur_button.Name!="r" && cur_button.Name!="a" && cur_button.Name!="t")
            {                
                TextBlock prog_text = selected_progs[0];
                Border cur_bord = (Border)prog_text.Parent;
                TextBlock prog_text2 = selected_progs[1];
                Border cur_bord2 = (Border)prog_text2.Parent;
                TextBlock news_text = new TextBlock();
                Border news_bord = new Border();
                
                int day_num = prog_text.Name.get_day();


                if (prog_text.Name.Right(2).Left(1)=="d" && prog_text2.Name.Right(2).Left(1)=="d")
                {
                    double sum_duration = prog_text.Text.deconstruct().Item3.time_to_minutes() + prog_text2.Text.deconstruct().Item3.time_to_minutes();



                    foreach (UIElement child in canvasArea.Children)
                    {
                        int day_num2 = 0;
                        if (child.GetType() == typeof(Border))
                        {

                            news_bord = (Border)child;
                            news_text = (TextBlock)news_bord.Child;
                            day_num2 = news_text.Name.get_day();
                            if (day_num == day_num2)
                            {
                                if (news_text.Name.Length >= 4)
                                {
                                    if (news_text.Name.Left(4)=="news" )
                                    {
                                        if (news_text.Name.Right(2).Left(1)=="n")
                                        {
                                            news_bord = (Border)child;
                                            news_text = (TextBlock)news_bord.Child;
                                            
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }


                    

                    int on_top=-1;


                    // MessageBox.Show((Canvas.GetTop(cur_bord) + cur_bord.Height).ToString() + '\n' + Canvas.GetTop(news_bord) + '\n' + '\n' + (Canvas.GetTop(cur_bord2) + cur_bord2.Height).ToString());


                    if (Canvas.GetTop(cur_bord)+cur_bord.Height==Canvas.GetTop(news_bord))
                    {
                        on_top = 1;

                    }

                    if (Canvas.GetTop(cur_bord2) + cur_bord2.Height == Canvas.GetTop(news_bord))
                    {
                        on_top = 2;
                    }


                    //if (on_top != 1 && on_top != 2) MessageBox.Show("Что-то не то с определением порядка кусков");




                    string duration = string.Concat(label_duration_hours.Content.ToString(), ":", label_duration_minutes.Content.ToString());
                    string timestart = string.Concat(label_timestart_hours.Content.ToString(), ":", label_timestart_minutes.Content.ToString());
                    string r_str = label_r.Content.ToString();
                    string t_str = label_t.Content.ToString();
                    string a_str = label_a.Content.ToString();
                    string title = prog_text.Text.full_title();


                    //Ключи
                    tb_keys(prog_text);
                    //Правим название программы
                    prog_text.Text = prog_text.Text.Replace(title, tb_title.Text.Replace("#", "\n"));
                    
                    update_duration_time_text(prog_text, timestart, duration, r_str, a_str, t_str);
                    



                    if (on_top == 2)
                    {
                        if (Canvas.GetTop(cur_bord) < Canvas.GetTop(news_bord) + news_bord.Height)
                        {
                            update_duration_time_text(prog_text, timestart.add_minute(1).ToString(), duration.add_minute(-1).ToString(), r_str, a_str, t_str);                            
                            update_duration_time_text(prog_text2, prog_text2.Text.deconstruct().Item2.add_minute(-1).ToString(), prog_text2.Text.deconstruct().Item3.add_minute(1).ToString(), prog_text2.Text.deconstruct().Item4, prog_text2.Text.deconstruct().Item6, prog_text2.Text.deconstruct().Item5);                            
                        //    new_double_click(prog_text, e);
                        }                                                                       
                        if (Canvas.GetTop(cur_bord) > Canvas.GetTop(news_bord)+news_bord.Height)
                        {
                            update_duration_time_text(prog_text2, prog_text2.Text.deconstruct().Item2.add_minute(1), prog_text2.Text.deconstruct().Item3.add_minute(-1), prog_text2.Text.deconstruct().Item4, prog_text2.Text.deconstruct().Item6, prog_text2.Text.deconstruct().Item5);
                            update_duration_time_text(prog_text, timestart.add_minute(-1).ToString(), duration.add_minute(1).ToString(), r_str, a_str, t_str);

                            //new_double_click(prog_text, e);
                        }

                        string r_comp1 = prog_text.Text.deconstruct().Item3.ads_int_new().Item1.ToString();
                        string t_comp1 = prog_text.Text.deconstruct().Item3.ads_int_new().Item2.ToString();
                        string a_comp1 = prog_text.Text.deconstruct().Item3.ads_int_new().Item3.ToString();

                        string r_comp2 = prog_text2.Text.deconstruct().Item3.ads_int_new().Item1.ToString();
                        string t_comp2 = prog_text2.Text.deconstruct().Item3.ads_int_new().Item2.ToString();
                        string a_comp2 = prog_text2.Text.deconstruct().Item3.ads_int_new().Item3.ToString();

                        int shift1 = Convert.ToInt32(r_str) - Convert.ToInt32(r_comp1) + Convert.ToInt32(a_str) - Convert.ToInt32(a_comp1);
                        int shift2 = Convert.ToInt32(prog_text2.Text.deconstruct().Item4) - Convert.ToInt32(r_comp2) + Convert.ToInt32(prog_text2.Text.deconstruct().Item6) - Convert.ToInt32(a_comp2);
                        

                        update_duration_time_text(prog_text2, prog_text2.Text.deconstruct().Item2.add_minute(shift2), prog_text2.Text.deconstruct().Item3, r_comp2, a_comp2, t_comp2);
                        update_duration_time_text(prog_text, prog_text.Text.deconstruct().Item2, prog_text.Text.deconstruct().Item3, r_comp1, a_comp1, t_comp1);
                        new_double_click(prog_text, e);
                        prog_text.font();
                        prog_text2.font();

                    }

                    
                    if (on_top == 1)
                    {
                        if (Canvas.GetTop(cur_bord)+cur_bord.Height > Canvas.GetTop(news_bord))
                        {
                            update_duration_time_text(prog_text, timestart, duration.add_minute(-1).ToString(), r_str, a_str, t_str);
                            update_duration_time_text(prog_text2, prog_text2.Text.deconstruct().Item2, prog_text2.Text.deconstruct().Item3.add_minute(1).ToString(), prog_text2.Text.deconstruct().Item4, prog_text2.Text.deconstruct().Item6, prog_text2.Text.deconstruct().Item5);
                            //new_double_click(prog_text, e);
                        }
                        if (Canvas.GetTop(cur_bord) + cur_bord.Height < Canvas.GetTop(news_bord))
                        {
                            update_duration_time_text(prog_text, timestart, duration.add_minute(1).ToString(), r_str, a_str, t_str);
                            update_duration_time_text(prog_text2, prog_text2.Text.deconstruct().Item2, prog_text2.Text.deconstruct().Item3.add_minute(-1).ToString(), prog_text2.Text.deconstruct().Item4, prog_text2.Text.deconstruct().Item6, prog_text2.Text.deconstruct().Item5);
                            //new_double_click(prog_text, e);
                        }

                        string r_comp1 = prog_text.Text.deconstruct().Item3.ads_int_new().Item1.ToString();
                        string t_comp1 = prog_text.Text.deconstruct().Item3.ads_int_new().Item2.ToString();
                        string a_comp1 = prog_text.Text.deconstruct().Item3.ads_int_new().Item3.ToString();

                        string r_comp2 = prog_text2.Text.deconstruct().Item3.ads_int_new().Item1.ToString();
                        string t_comp2 = prog_text2.Text.deconstruct().Item3.ads_int_new().Item2.ToString();
                        string a_comp2 = prog_text2.Text.deconstruct().Item3.ads_int_new().Item3.ToString();

                        int shift2 = Convert.ToInt32(r_str) - Convert.ToInt32(r_comp2) + Convert.ToInt32(a_str) - Convert.ToInt32(a_comp2);
                        int shift1 = Convert.ToInt32(prog_text.Text.deconstruct().Item4) - Convert.ToInt32(r_comp1) + Convert.ToInt32(prog_text.Text.deconstruct().Item6) - Convert.ToInt32(a_comp1);


                        update_duration_time_text(prog_text2, prog_text2.Text.deconstruct().Item2, prog_text2.Text.deconstruct().Item3, r_comp2, a_comp2, t_comp2);
                        update_duration_time_text(prog_text, prog_text.Text.deconstruct().Item2.add_minute(shift1), prog_text.Text.deconstruct().Item3, r_comp1, a_comp1, t_comp1);
                        new_double_click(prog_text, e);
                        prog_text.font();
                        prog_text2.font();


                    }
                    

                    if (cur_bord.Height<15)
                    {
                        if (on_top==1)
                        {
                            string r_comp2 = sum_duration.ToString().ads_int_new().Item1.ToString();
                            string t_comp2 = sum_duration.ToString().ads_int_new().Item2.ToString();
                            string a_comp2 = sum_duration.ToString().ads_int_new().Item3.ToString();

                            update_duration_time_text(prog_text2, prog_text2.Text.deconstruct().Item2, sum_duration.minutes_to_time(), r_comp2, a_comp2, t_comp2);
                            canvasArea.Children.Remove(cur_bord);
                            selected_progs.Clear();
                            selected_progs.Add(prog_text2);
                            prog_text2.Name = prog_text2.Name.Left(prog_text2.Name.Length - 2) + "s1";
                            prog_text2.Text = prog_text2.Text.Replace("ПРОДОЛЖЕНИЕ" + '\n', "");                            
                            prog_text2.Text = prog_text2.Text.Replace("["+sum_duration.minutes_to_time()+"]"+'\n', "");
                            new_double_click(prog_text2, e);
                            
                        }
                        if (on_top == 2)
                        {
                            string r_comp2 = sum_duration.ToString().ads_int_new().Item1.ToString();
                            string t_comp2 = sum_duration.ToString().ads_int_new().Item2.ToString();
                            string a_comp2 = sum_duration.ToString().ads_int_new().Item3.ToString();
                            string new_timestart = (prog_text2.Text.deconstruct().Item2.time_to_minutes() - r_comp2.time_to_minutes() - a_comp2.time_to_minutes()).minutes_to_time();

                            update_duration_time_text(prog_text2, new_timestart, sum_duration.minutes_to_time(), r_comp2, a_comp2, t_comp2);
                            canvasArea.Children.Remove(cur_bord);
                            selected_progs.Clear();
                            selected_progs.Add(prog_text2);
                            prog_text2.Name = prog_text2.Name.Left(prog_text2.Name.Length - 2) + "s1";
                            prog_text2.Text = prog_text2.Text.Replace("ПРОДОЛЖЕНИЕ" + '\n', "");
                            prog_text2.Text = prog_text2.Text.Replace("[" + sum_duration.minutes_to_time() + "]" + '\n', "");
                            new_double_click(prog_text2, e);
                            
                        }
                    }
                    if (cur_bord2.Height < 15)
                    {
                        if (on_top == 1)
                        {
                            string r_comp1 = sum_duration.ToString().ads_int_new().Item1.ToString();
                            string t_comp1 = sum_duration.ToString().ads_int_new().Item2.ToString();
                            string a_comp1 = sum_duration.ToString().ads_int_new().Item3.ToString();
                            string new_timestart = (prog_text.Text.deconstruct().Item2.time_to_minutes() - r_comp1.time_to_minutes() - a_comp1.time_to_minutes()).minutes_to_time();


                            update_duration_time_text(prog_text, prog_text.Text.deconstruct().Item2, sum_duration.minutes_to_time(), r_comp1, a_comp1, t_comp1);
                            canvasArea.Children.Remove(cur_bord2);
                            selected_progs.Clear();
                            selected_progs.Add(prog_text);
                            prog_text.Name = prog_text.Name.Left(prog_text.Name.Length - 2) + "s1";
                            prog_text.Text = prog_text.Text.Replace("ПРОДОЛЖЕНИЕ"+'\n', "");
                            prog_text.Text = prog_text.Text.Replace("[" + sum_duration.minutes_to_time() + "]" + '\n', "");
                            new_double_click(prog_text, e);
                            
                        }
                        if (on_top == 2)
                        {
                            string r_comp1 = sum_duration.ToString().ads_int_new().Item1.ToString();
                            string t_comp1 = sum_duration.ToString().ads_int_new().Item2.ToString();
                            string a_comp1 = sum_duration.ToString().ads_int_new().Item3.ToString();

                            update_duration_time_text(prog_text, prog_text.Text.deconstruct().Item2, sum_duration.minutes_to_time(), r_comp1, a_comp1, t_comp1);
                            canvasArea.Children.Remove(cur_bord2);
                            selected_progs.Clear();
                            selected_progs.Add(prog_text);
                            prog_text.Name = prog_text.Name.Left(prog_text.Name.Length - 2) + "s1";
                            prog_text.Text = prog_text.Text.Replace("ПРОДОЛЖЕНИЕ" + '\n', "");
                            prog_text.Text = prog_text.Text.Replace("[" + sum_duration.minutes_to_time() + "]" + '\n', "");

                            new_double_click(prog_text, e);
                            
                        }
                    }



                }

            }

            if (selected_progs.Count() == 1 || cur_button.Name=="r" || cur_button.Name=="a" || cur_button.Name=="t")
            {
                TextBlock prog_text = selected_progs[0];
                Border cur_bord = (Border)prog_text.Parent;

                //Вырезаем кусок inkcanvas'а
                cut_strokes(Canvas.GetLeft(cur_bord), Canvas.GetTop(cur_bord), cur_bord.Width, cur_bord.Height);



                //string total_dur1="";
                //string total_dur2 = "";
                //total_dur1 = prog_text.Text.Substring(prog_text.Text.IndexOf("("), prog_text.Text.IndexOf(")") - prog_text.Text.IndexOf("(") + 1);
                

                string duration = string.Concat(label_duration_hours.Content.ToString(),":",label_duration_minutes.Content.ToString());
                string timestart = string.Concat(label_timestart_hours.Content.ToString(), ":", label_timestart_minutes.Content.ToString());
                string r_str = label_r.Content.ToString();
                string a_str = label_a.Content.ToString();
                string t_str = label_t.Content.ToString();                
                string title = prog_text.Text.full_title();

                //Правим название программы
                prog_text.Text = prog_text.Text.Replace(title, tb_title.Text.Replace("#", "\n"));


                //Сдвигаем timestart верхней части разорванной программы
                double shift = 0;
                if (selected_progs.Count() == 2 && Canvas.GetTop(selected_progs[0]) < Canvas.GetTop(selected_progs[1]))
                {
                    shift = Convert.ToDouble(r_str) - Convert.ToDouble(prog_text.Text.deconstruct().Item4) + Convert.ToDouble(a_str) - Convert.ToDouble(prog_text.Text.deconstruct().Item6);
                    timestart = (timestart.time_to_minutes() - shift).minutes_to_time();
                }


                //Обновляем служебную информацию в отдельной процедурке
                
                update_duration_time_text(prog_text, timestart, duration, r_str, a_str, t_str);
                new_double_click(prog_text, e);
                split_prog(prog_text, e);

                

            }
        }

        private void daytb_KeyUp(object sender, KeyEventArgs k)
        {
            if (k.Key == Key.Return)
            {
                selected_days[0].Text = day_title.Text.Replace("#", "\n");
            }
        }


        private void ptb_KeyUp(object sender, KeyEventArgs k)
        {
            if (k.Key == Key.Return)
            {
                //Button_Click(sender,e);
                TextBox cur_text = (TextBox)sender;
                TextBox tbeg_tb = new TextBox();
                TextBox dur_tb = new TextBox();
                TextBox r_tb = new TextBox();
                TextBox t_tb = new TextBox();
                TextBox a_tb = new TextBox();
                //string time_beg1 = "";
                //string time_beg2 = "";
                string total_dur1 = "";
                string total_dur2 = "";

                foreach (UIElement tb in canvasArea.Children)
                {
                    if (tb.GetType() == typeof(TextBox))
                    {
                        TextBox cur_tb = (TextBox)tb;
                        if (cur_tb.Name.Right(6) == "dur_tb")
                        {
                            dur_tb = (TextBox)tb;
                        }
                        if (cur_tb.Name.Right(11) == "time_beg_tb")
                        {
                            tbeg_tb = (TextBox)tb;
                        }
                        if (cur_tb.Name.Right(6) == "rec_tb")
                        {
                            r_tb = (TextBox)tb;
                        }
                        if (cur_tb.Name.Right(9) == "tochki_tb")
                        {
                            t_tb = (TextBox)tb;
                        }
                        if (cur_tb.Name.Right(8) == "anons_tb")
                        {
                            a_tb = (TextBox)tb;
                        }

                    }
                }
                string cur_name = "";
                if (cur_text.Name.IndexOf("t") >= 0)
                {
                    cur_name = cur_text.Name.Left(cur_text.Name.IndexOf("t")).Replace("prog", "bord");
                    cur_name = cur_name.Replace("news", "bord");
                }
                else
                {
                    MessageBox.Show(cur_text.Name);
                }


                if (tbeg_tb.Text.Length == 4)
                {
                    tbeg_tb.Text = tbeg_tb.Text.Left(2) + ":" + tbeg_tb.Text.Right(2);
                }

                foreach (UIElement tb in canvasArea.Children)
                {
                    if (tb.GetType() == typeof(Border))
                    {
                        Border cur_bord = (Border)tb;

                        if (cur_bord.Name == cur_name)
                        {
                            TextBlock prog_text = (TextBlock)cur_bord.Child;
                            total_dur1 = prog_text.Text.Substring(prog_text.Text.IndexOf("(") , prog_text.Text.IndexOf(")") - prog_text.Text.IndexOf("(")+1);
                            //MessageBox.Show(total_dur1);

                            string duration = dur_tb.Text;
                            string r = r_tb.Text;
                            string a = a_tb.Text;
                            string t = t_tb.Text;


                            string sq_br_text = dur_tb.Text;
                            if (Convert.ToDouble(r) != 0)
                            {
                                sq_br_text += " + " + r + "Р(" + t + ")";
                            }
                            if (Convert.ToDouble(a) != 0)
                            {
                                sq_br_text += " + " + a + "А";
                            }

                            string prev_sq_br_text = prog_text.Text.sqbr();


                            
                            prog_text.Text = prog_text.Text.Replace(prev_sq_br_text, sq_br_text);

                            //prog_text.Text = prog_text.Text.Replace(prog_text.Text.Substring(prog_text.Text.IndexOf("[") + 1, prog_text.Text.IndexOf("]") - prog_text.Text.IndexOf("[") - 1), sq_br_text);
                            string replacement_str = "(" + dur_tb.Text.add_minute(Convert.ToDouble(r_tb.Text)).add_minute(Convert.ToDouble(a_tb.Text)) + ")";
                            prog_text.Text = prog_text.Text.Replace(total_dur1, replacement_str);
                            total_dur2 = prog_text.Text.Substring(prog_text.Text.IndexOf("(") + 1, prog_text.Text.IndexOf(")") - prog_text.Text.IndexOf("(") - 1);
                            total_dur1 = total_dur1.Substring(1, total_dur1.Length - 2);
                            cur_bord.Height += total_dur2.time_to_minutes() - total_dur1.time_to_minutes();
                            prog_text.Height += total_dur2.time_to_minutes() - total_dur1.time_to_minutes();



                            string total_str = tbeg_tb.Text + " - " + tbeg_tb.Text.add_minute(total_dur2.time_to_minutes());
                            prog_text.Text = prog_text.Text.Replace(prog_text.Text.Substring(0, prog_text.Text.IndexOf("(") - 1), total_str);


                            double beg_time = Convert.ToDouble(tbeg_tb.Text.time_to_minutes());

                            if ((beg_time / 60) < 5)
                            {
                                beg_time += 24 * 60;
                            }
                            beg_time -= 5 * 60;


                            Canvas.SetTop(cur_bord, beg_time * zoom_coef + top_shift);
                            Canvas.SetTop(prog_text, beg_time * zoom_coef + top_shift);

                            foreach (UIElement element in p_items)
                            {
                                canvasArea.Children.Remove(element);
                            }
                            p_items.Clear();
                            //add_control_elements(prog_text, k);
                            

                            break;
                        }
                    }
                }


            }
        }

        /*
        public static void Convertt<T>(this DataColumn column, Func<object, T> conversion)
        {
            foreach (DataRow row in column.Table.Rows)
            {
                row[column] = conversion(row[column]);
            }
        }
        */
        private void infosheet_databinding(DataGrid dg)
        {
            string sstring = search_string.Text;

            string select = "SELECT TimingText, Title, Bit_Repetition, BCDate, BeginTimeText, DSti, DM, DR, ProducerCode, SellerCode " +
                               "FROM TCBCList4Themes " +
                               "WHERE Title like '%" +
                               sstring +
                               "%'";

            
            
            try
            {

                SqlDataAdapter dataAdapter = new SqlDataAdapter(select, con_plan12);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                               
                dataAdapter.Fill(dt);
                

                ds.Tables.Add(dt);
                
                con_plan12.Close();

                
                ds.Tables[0].Columns[0].ColumnName = "Хр";
                ds.Tables[0].Columns[1].ColumnName= "Название";
                ds.Tables[0].Columns[2].ColumnName = "Повтор";                
                ds.Tables[0].Columns[3].ColumnName = "Дата";
                
                //ds.Tables[0].Columns[3].DataType = System.Type.GetType("System.DateTime");
                
                ds.Tables[0].Columns[4].ColumnName = "Время";
                ds.Tables[0].Columns[5].ColumnName = "СТИ";
                ds.Tables[0].Columns[6].ColumnName = "ДМ";
                ds.Tables[0].Columns[7].ColumnName = "ДР";

                
               

                
                dg.ItemsSource = ds.Tables[0].DefaultView;
                



            }
            catch (Exception ex)
            {
                return;
            }

            //DataView dv = new DataView(dt);

        }



        private void create_template(object sender, RoutedEventArgs e)
        {

            foreach (UIElement element in canvasArea.Children)
            {
                if (element.GetType() == typeof(DataGrid))
                {
                    DataGrid cur_element = (DataGrid)element;
                    if (cur_element.Name == "temp_dg")
                    {
                        
                        DataGrid dg = cur_element;
                        
                        //Пока работаем только с одним рядом
                        //int i =0;
                        for (int i = 0; i < dg.SelectedItems.Count; i++)
                        {
                            DataRowView row = (DataRowView)dg.SelectedItems[i];


                            //string str_timing = row["TimingText"].ToString().Left(5);
                            string str_timing = row["Хр"].ToString().Left(5);
                            double h = str_timing.ads_int().Item1 + str_timing.ads_int().Item3 + str_timing.ads_int().Item4;
                            shape_count += 1;
                            Border cur_bord = new Border()
                            {
                                //Height = Convert.ToDouble(row["TimingText"].ToString().Substring(3, 2)),
                                Height = h,
                                Width = 160,
                                Background = Brushes.Black,                                
                                Name = string.Concat("bord0", shape_count.ToString(),"_0"),
                                Tag = ""
                            };
                            //Canvas.SetTop(cur_bord, template_top);
                            //Canvas.SetLeft(cur_bord, 870);
                            //canvasArea.Children.Add(cur_bord);
                            second_sp.Children.Add(cur_bord);
                            template_top += h + 30;


                            String cur_name = string.Concat("ptemp_", shape_count.ToString());


                            string ads_timing = str_timing.ads();
                            string total_timing = "";

                            if (str_timing.ads_int().Item6 < 10)
                            {
                                total_timing = str_timing.ads_int().Item5 + ":0" + str_timing.ads_int().Item6;
                            }

                            else
                            {
                                total_timing = str_timing.ads_int().Item5 + ":" + str_timing.ads_int().Item6;
                            }

                            if (total_timing.Left(2) == "0:") total_timing = total_timing.Substring(2, total_timing.Length - 2);

                            string prod_code = row["ProducerCode"].ToString();
                            string sel_code = row["SellerCode"].ToString();

                            while (prod_code.Length < 2) prod_code = "0" + prod_code;
                            while (sel_code.Length < 3) sel_code = "0" + sel_code;

                            cur_bord.Child = new TextBlock()
                            {
                                Name = cur_name,
                                Background = Brushes.White,
                                Foreground = Brushes.Black,
                                Text = row["Время"].ToString().Left(5) + " - " + (row["Время"].ToString().Left(5).time_to_minutes() + total_timing.time_to_minutes()).minutes_to_time() +
                                //Text = row["BeginTimeText"].ToString().Left(5) +" - " + (row["BeginTimeText"].ToString().Left(5).time_to_minutes()+total_timing.time_to_minutes()).minutes_to_time()+
                                    //" ("+row["TimingText"].ToString().Left(5)+")"+
                                        " (" + total_timing + ")" +
                                        "\n" +
                                        //row["Title"].ToString().ToUpper() +
                                        row["Название"].ToString().ToUpper() +
                                        "\n" +
                                    //"[" + row["TimingText"].ToString().Left(5) + + "]" +
                                        "[" + str_timing + ads_timing + "]" +
                                        " ("+ prod_code+sel_code+")",
                                TextWrapping = TextWrapping.Wrap,
                                VerticalAlignment = VerticalAlignment.Center,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                TextAlignment = TextAlignment.Center,
                                FontSize = base_fontsize,

                                LineStackingStrategy = System.Windows.LineStackingStrategy.BlockLineHeight,
                                LineHeight = 11,
                                Padding = new Thickness(2),
                                Height = cur_bord.Height - 2,
                                Width = cur_bord.Width - 2
                            };

                            TextBlock cur_text = (TextBlock)cur_bord.Child;


                            //Забота о маленьких
                            if (str_timing.ads_int().Item1 + str_timing.ads_int().Item3 + str_timing.ads_int().Item4 < 30)
                            {
                                cur_text.FontSize = 7;
                                cur_text.LineStackingStrategy = System.Windows.LineStackingStrategy.BlockLineHeight;
                                cur_text.LineHeight = 7;

                            }

                            // Добавляем handler'ы для drag'n'drop
                            cur_bord.Child.MouseLeftButtonDown += rect_MouseLeftButtonDown;
                            cur_bord.Child.MouseMove += rect_MouseMove;
                            cur_bord.Child.MouseLeftButtonUp += rect_MouseLeftButtonUp;
                            cur_bord.Child.MouseRightButtonDown += Child_MouseRightButtonDown;




                            //Добавили в коллекции
                            progs.Add((TextBlock)cur_bord.Child);
                            Canvas.SetZIndex(cur_bord, Canvas.GetZIndex(bords[bords.Count() - 1]) + 1);
                            bords.Add(cur_bord);


                        }
                        





                        //Все закрыли
                        clear_infosheet(sender, e);


                        break;







                        //MessageBox.Show(row["TimingText"].ToString().Substring(3,2));


                        //MessageBox.Show(row["Title"].ToString());
                    }
                }
            }


            /*
            Border cur_bord = new Border() 
            {
                Height = cur_bord.Height, 
                Width = cur_shape.Width, 
                Background = Brushes.Black 
            };
            //Породили внутри TextBlock
            Rendershape.Child = new TextBlock() 
            { 
                Name = cur_name, 
                Background = Brushes.White, 
                Text = cur_shape.Text, 
                TextWrapping = TextWrapping.Wrap, 
                VerticalAlignment = VerticalAlignment.Center, 
                HorizontalAlignment = HorizontalAlignment.Center, 
                TextAlignment = TextAlignment.Center, 
                FontSize = 9, 
                Padding = new Thickness(2), 
                Height = Rendershape.Height - 2, 
                Width = Rendershape.Width - 2 
            };
            */
            //3,2

        }


        private void create_infosheet(object sender, RoutedEventArgs e)
        {

   
            myAdornerLayer.Visibility = Visibility.Hidden;

            //Делаем подложку
            Rectangle podlozhka = new Rectangle()
            {
                Stroke = Brushes.DarkGray,
                StrokeThickness = 1,
                Width = main_window.ActualWidth-Flyout_right.Width-100,
                Height = main_window.ActualHeight-300,
                Fill = Brushes.White,
                Opacity = 0.9
            };
            Canvas.SetLeft(podlozhka, 50 + sc_view.HorizontalOffset);
            Canvas.SetTop(podlozhka, 100 + sc_view.VerticalOffset);
            canvasArea.Children.Add(podlozhka);
            p_items.Add(podlozhka);

            //Data.grid
            DataGrid dg = new DataGrid()
            {
                Width = podlozhka.Width-120,
                Height = podlozhka.Height-150,
                Name = "temp_dg"
            };

            Canvas.SetLeft(dg, Canvas.GetLeft(podlozhka)+50);
            Canvas.SetTop(dg, Canvas.GetTop(podlozhka) + 70);
            canvasArea.Children.Add(dg);
            p_items.Add(dg);
            infosheet_databinding(dg);
            


            //Кнопочка получения шаблона
            Button get_prog = new Button()
            {
                Width = 150,
                Height = 50,
                Content = "Добавить в шаблоны"
            };

            Canvas.SetLeft(get_prog, Canvas.GetLeft(podlozhka) + 50);
            Canvas.SetTop(get_prog, Canvas.GetTop(dg)+dg.Height + 20);
            get_prog.Click += new RoutedEventHandler(create_template);            
            canvasArea.Children.Add(get_prog);
            p_items.Add(get_prog);



            //Кнопочка удаления всего понастроенного
            Label close_label = new Label()
            {
                Width = 30,
                Height = 40,
                FontSize=20,
                Content = "X"
            };
            close_label.MouseDown += new MouseButtonEventHandler(clear_infosheet);
            Canvas.SetLeft(close_label, Canvas.GetLeft(podlozhka)+ podlozhka.Width-close_label.Width);
            Canvas.SetTop(close_label, Canvas.GetTop(podlozhka));
            canvasArea.Children.Add(close_label);
            p_items.Add(close_label);

            foreach (UIElement p in p_items)
            {
                Canvas.SetZIndex(p, 100000);
            }

        }


        private void clear_infosheet(object sender, RoutedEventArgs e)
        {
            myAdornerLayer.Visibility = Visibility.Visible;
            foreach (UIElement element in p_items)
            {
                canvasArea.Children.Remove(element);
            }
            p_items.Clear();

        }

        private void change_day(object sender, RoutedEventArgs e)
        {

        }







        private void header_MouseEnter(object sender, MouseEventArgs e)
        {

            /*
            TextBlock cur_text = (TextBlock)sender;
            cur_text.Tag = cur_text.Text;
            cur_text.Text = "...";
            cur_text.FontSize = 40;
            cur_text.LineHeight = 40;
            cur_text.MouseDown += new MouseButtonEventHandler(change_day);
            */
        }
        private void header_MouseLeave(object sender, MouseEventArgs e)
        {
            /*
            TextBlock cur_text = (TextBlock)sender;
            cur_text.Text = cur_text.Tag.ToString();
            cur_text.Tag = "";
            cur_text.FontSize = 14;
            cur_text.LineHeight = 15;
            */
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //string s = "ABC [Повтор] [1.28 + 14]";
            string s = "ABC [17]";

            bool last_one = false;
            int cur_pos = 0;


            while (last_one == false)
            {
                if (s.Substring(cur_pos, s.Length - cur_pos).IndexOf("[") > 0)
                {
                    cur_pos += s.Substring(cur_pos, s.Length - cur_pos).IndexOf("[");
                    cur_pos += 1;
                }
                else
                {
                    last_one = true;
                    //cur_pos -= 1;
                }
            }

            MessageBox.Show(cur_pos.ToString());
            MessageBox.Show(s.Substring(cur_pos, s.Length - cur_pos - 1));

            //string temp_time = s.Substring(cur_pos, s.Substring(cur_pos, s.Length - cur_pos).IndexOf("]") - cur_pos);


        }


        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            day_rects.Clear();
            Slider cur_slider = (Slider)sender;
            //double coef = 2 * (cur_slider.Value / 20);
            double coef = cur_slider.Value;
            zoom_coef = coef;
            forced_fontsize = Math.Floor(base_fontsize + (zoom_coef - 1) * 2.5);



            //Меняем боковые шкалы            
            VisualBrush vBrush = new VisualBrush();
            vBrush = vBrush.grid_brush(0, zoom_coef);
            left_grid.Fill = vBrush;
            vBrush = vBrush.grid_brush(1, zoom_coef);
            right_grid.Fill = vBrush;

            //Меняем часовую шкалу на фоне
            vBrush = vBrush.hours_brush(zoom_coef);
            bg_rect.Fill = vBrush;



            //Считаем дни
            foreach (UIElement l in canvasArea.Children)
            {
                if (l.GetType() == typeof(Rectangle))
                {
                    Rectangle cur_rect = (Rectangle)l;
                    if (cur_rect.Name.Left(3) == "day")
                    {
                        day_rects.Add(cur_rect);
                    }
                }
                if (l.GetType() == typeof(TextBlock))
                {
                    TextBlock cur_text = (TextBlock)l;
                }
            }


            //Меняем размер canvas'а
            canvasArea.Height = 1600 * zoom_coef + top_shift+100;
            canvasArea.Width = days_count * 160 * zoom_coef + 40+400;
            if (canvasArea.Width > 160)
            {
                //inkcanvas1.Width = canvasArea.Width+500;
                //inkcanvas1.Height = canvasArea.Height;
                visible_canvas.Width = canvasArea.Width;
                visible_canvas.Height = canvasArea.Height;
            }
            if (days_count == 0)
            {
                //  inkcanvas1.Width = 160;
            }
            else
            {
                //inkcanvas1.Width = (days_count) * 160 * zoom_coef;
            }
            //Canvas.SetTop(inkcanvas1, Canvas.GetTop(bg_rect));
            //Canvas.SetLeft(inkcanvas1, Canvas.GetLeft(bg_rect));



            //bg_rect.Width = canvasArea.Width - 40;
            //bg_rect.Height = canvasArea.Height;
            bg_rect.Width = days_count * 160*zoom_coef;
            //bg_rect.Width = day_rects[0].Height;




            
            double cur_width = 160 * zoom_coef;
            lgrid_bgrd.Height = 1600 * zoom_coef;



            foreach (UIElement l in canvasArea.Children)
            {
                if (l.GetType() == typeof(Rectangle))
                {
                    Rectangle cur_rect = (Rectangle)l;
                    if (cur_rect.Name.Length >= 4)
                    {


                        //Шкалы времени
                        if (cur_rect.Name.Right(4) == "grid")
                        {
                            cur_rect.Height = 1600 * zoom_coef;                                                        
                        }
                        //Дни
                        if (cur_rect.Name.Left(3) == "day")
                        {
                            //day_rects.Add(cur_rect);
                            //double day_num = Math.Round((Canvas.GetLeft(cur_rect) - 20) / (159 * zoom_coef), 0);
                            double day_num = Convert.ToDouble(cur_rect.Name.Substring(3, cur_rect.Name.Length - 3)) - 1;
                            double new_left = (20 + day_num * 159 * zoom_coef);
                            //header2.Text = new_left.ToString()+'\n'+zoom_coef+"*"+day_num;
                            Canvas.SetLeft(cur_rect, new_left);
                            cur_rect.Height = 1600 * zoom_coef;
                            cur_rect.Width = 160 * zoom_coef;
                            cur_rect.Fill = vBrush;
                        }


                    }
                    if (l.GetType() == typeof(Border))
                    {
                        Border cur_bord = (Border)l;
                    }
                }
                if (l.GetType() == typeof(Border))
                {
                    Border cur_bord = (Border)l;
                    if (cur_bord.Name.Length >= 6)
                    {
                        //Заголовки дней
                        if (cur_bord.Name.Left(6) == "header")
                        {
                            TextBlock cur_text = new TextBlock();
                            cur_text = (TextBlock)cur_bord.Child;

                            //double day_num = Math.Round((Canvas.GetLeft(cur_bord) - 20) / (159 * zoom_coef), 0);
                            //MessageBox.Show(cur_bord.Name.Substring(10, cur_bord.Name.Length - 10));
                            double day_num = Convert.ToDouble(cur_bord.Name.Substring(10, cur_bord.Name.Length - 10));
                            double new_left = (20 + day_num * 159 * zoom_coef);
                            //header2.Text = new_left.ToString() + '\n' + zoom_coef + "*" + day_num;
                            Canvas.SetLeft(cur_bord, new_left);
                            cur_bord.Width = 160 * zoom_coef;
                            cur_text.Width = 158 * zoom_coef;
                        }

                        //Шапки
                        if (cur_bord.Name.Left(7) == "sh_bord")
                        {
                            TextBlock cur_text = new TextBlock();
                            cur_text = (TextBlock)cur_bord.Child;

                            //double day_num = Math.Round((Canvas.GetLeft(cur_bord) - 20) / (159 * zoom_coef), 0);
                            //MessageBox.Show(cur_bord.Name.Substring(10, cur_bord.Name.Length - 10));
                            double day_num = Convert.ToDouble(cur_bord.Name.Substring(7, cur_bord.Name.Length - 7));
                            double new_left = (20 + day_num * 159 * zoom_coef);
                            //header2.Text = new_left.ToString() + '\n' + zoom_coef + "*" + day_num;
                            Canvas.SetLeft(cur_bord, new_left);
                            cur_bord.Width = 160 * zoom_coef;
                            cur_text.Width = 158 * zoom_coef;
                        }

                        //Добавленные программы
                        if (cur_bord.Name.Left(4) == "bord")
                        {
                            TextBlock cur_text = new TextBlock();
                            cur_text = (TextBlock)cur_bord.Child;

                            //double day_num = Math.Round((Canvas.GetLeft(cur_bord) - 20) / (159 * zoom_coef), 0);
                            double day_num = Convert.ToDouble(cur_bord.Name.Substring(4, cur_bord.Name.IndexOf("_") - 4));
                            double new_left = (20 + day_num * 159 * zoom_coef);
                            //header2.Text = new_left.ToString() + '\n' + zoom_coef + "*" + day_num;
                            Canvas.SetLeft(cur_bord, new_left);
                            cur_bord.Width = 160 * zoom_coef;
                            cur_text.Width = 158 * zoom_coef;


                            double duration = cur_text.Text.Substring(cur_text.Text.IndexOf("(") + 1, cur_text.Text.IndexOf(")") - cur_text.Text.IndexOf("(") - 1).time_to_minutes();
                            cur_bord.Height = duration * zoom_coef;
                            cur_text.Height = cur_bord.Height - 2;


                            string time_beg = cur_text.Text.Left(cur_text.Text.IndexOf(" "));


                            double beg_time = Convert.ToDouble(time_beg.time_to_minutes());
                            if (Canvas.GetTop(cur_bord) >= 15 * 60 * zoom_coef && beg_time > 5 * 60 && beg_time < 10 * 60) beg_time += 24 * 60;

                            if ((beg_time / 60) < 5)
                            {
                                beg_time += 24 * 60;
                            }
                            beg_time -= 5 * 60;


                            Canvas.SetTop(cur_bord, beg_time * zoom_coef + top_shift);
                            Canvas.SetTop(cur_text, beg_time * zoom_coef + top_shift);

                            //double time = (Canvas.GetTop(sender) - 80*zoom_coef) * zoom_coef;

                            //cur_text = cur_text.font();
                            
                            //!шрифтfont_test(cur_text);
                            font_test2(cur_text);
                        }

                    }
                }
                
                
                if (l.GetType() == typeof(Label))
                {
                    Label cur_label = (Label)l;
                    double pos = 0;
                    if (cur_label.Name.IndexOf("_") >= 0)
                    {
                        //pos = Convert.ToDouble(cur_label.Name.Substring(cur_label.Name.IndexOf("_") + 1, cur_label.Name.Length - cur_label.Name.IndexOf("_") - 1));
                        
                        //pos = Convert.ToDouble(cur_label.Name.Right(2)) - 5;
                        pos = Convert.ToDouble(cur_label.Name.Right(cur_label.Name.Length - cur_label.Name.IndexOf("_") - 1)) - 5;                        
                        if (pos > 24) pos -= 76;                        
                        //Canvas.SetTop(cur_label, 74 + pos * 60 * zoom_coef);
                        //if (pos > 24) pos -= top_shift - 4;
                        Canvas.SetTop(cur_label, top_shift - 6 + pos * 60 * zoom_coef);

                        if (cur_label.Name.Left(5) == "right")
                        {
                            //Canvas.SetLeft(cur_label, (20 + day_rects.Count() * 159 * zoom_coef));
                            Canvas.SetLeft(cur_label, (20 + (days_count)* 159 * zoom_coef));

                        }
                    }
                    //MessageBox.Show(cur_label.Name + '\n' + pos.ToString());
                }
            }

            //Canvas.SetLeft(right_grid, (20 + day_rects.Count() * 159 * zoom_coef));
            Canvas.SetLeft(right_grid, (20 + (days_count) * 159 * zoom_coef));
            Canvas.SetTop(right_grid, top_shift);
            Canvas.SetTop(left_grid, top_shift);
            Canvas.SetLeft(timestamp, 80 + (days_count - 1) * 159 * zoom_coef);

            Matrix scaleMatrix = new Matrix();

            //double factor = cur_width/160;
            double prefactor = (e.NewValue - e.OldValue) / e.OldValue;
            double factor = prefactor + 1;

            Debug.WriteLine("Factor: " + factor.ToString() + "   Coef: " + zoom_coef.ToString());
            scaleMatrix.ScaleAt(factor, factor, 20, top_shift);
            //inkcanvas1.Strokes.Transform(scaleMatrix, false);
            foreach (InkCanvas ic in ink_canvases)
            {
                ic.Strokes.Transform(scaleMatrix, false);
            }
            /*
            foreach (Rectangle r in blinders)
            {
                r.Width = 150 * zoom_coef;
                Canvas.SetLeft(r, 25+blinders.IndexOf(r)*159*zoom_coef);
            }
             */ 
           // visible_canvas.Strokes.Transform(scaleMatrix, false);

            

        }

        private void main_window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //Двигаем буфер  
            //Canvas.SetLeft(BufferToggleButton, main_window.ActualWidth - 70);
            
           /*
            Canvas.SetTop(Buf, 80);
            Canvas.SetTop(Buf_on_bord, 80);
            Canvas.SetTop(ptemp45_200_border, Canvas.GetTop(Buf) + 70);
            Canvas.SetTop(ptemp52_280_border, Canvas.GetTop(Buf) + 150);
            Canvas.SetTop(ntemp15_360_border, Canvas.GetTop(Buf) + 230);

            Canvas.SetLeft(Buf, main_window.ActualWidth - Buf.Width - 30 + 200);
            Canvas.SetLeft(Buf_on_bord, main_window.ActualWidth - Buf_on_bord.Width - 30);
            Canvas.SetLeft(ptemp45_200_border, Canvas.GetLeft(Buf) + 20);
            Canvas.SetLeft(ptemp52_280_border, Canvas.GetLeft(Buf) + 20);
            Canvas.SetLeft(ntemp15_360_border, Canvas.GetLeft(Buf) + 20);

            */



          /*  if (hor.IsChecked == true)
            {
                canvasArea.Width = main_window.Width - 35;
                bg_rect.Width = main_window.Width - 75;
            }
           */ 
           

            //if (canvasArea.Width <= 20 + 160 * (days_count) * zoom_coef)
                canvasArea.Width = 20 + 160 * (days_count) * zoom_coef + 30+400;


            Canvas.SetLeft(right_grid, 20 + 159 * (days_count) * zoom_coef);
            Canvas.SetTop(right_grid, top_shift);
            Canvas.SetTop(left_grid, top_shift);
            foreach (UIElement l in canvasArea.Children)
            {
                /*
                if (l.GetType() == typeof(Rectangle))
                {
                    Rectangle cur_rect = (Rectangle)l;
                    if (cur_rect.Name.Length >= 4)
                    {
                        //Шкалы времени
                        if (cur_rect.Name.Right(4) == "grid" && cur_rect.Name.Left(5)=="right")
                        {
                            Canvas.SetLeft(cur_rect, canvasArea.Width - 20);
                            if (Canvas.GetLeft(cur_rect) <= 20 + 170 * (days_count) * zoom_coef)
                                Canvas.SetLeft(cur_rect,20 + 159 * (days_count) * zoom_coef);
                            
                        }
                    }
                }
                 */ 
                if (l.GetType() == typeof(Label))
                {
                    Label cur_label = (Label)l;                    
                    if (cur_label.Name.IndexOf("_") >= 0)
                    {                        
                        if (cur_label.Name.Left(5) == "right")
                        {                     
                            Canvas.SetLeft(cur_label, canvasArea.Width-18);
                            //if (Canvas.GetLeft(cur_label) <= 170 * (days_count) * zoom_coef+22)
                                Canvas.SetLeft(cur_label, 159 * (days_count) * zoom_coef+22);
                        }
                    }
                    //MessageBox.Show(cur_label.Name + '\n' + pos.ToString());
                }

            }
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            Canvas.SetLeft(lgrid_bgrd, (0 + sc_view.HorizontalOffset));
            Canvas.SetLeft(left_grid, (0 + sc_view.HorizontalOffset));
            Canvas.SetTop(top_blank, sc_view.VerticalOffset);
            foreach (UIElement l in canvasArea.Children)
            {
                if (l.GetType() == typeof(Label))
                {
                    Label cur_label = (Label)l;
                    double pos = 0;
                    if (cur_label.Name.IndexOf("_") >= 0)
                    {                        
                        //pos = Convert.ToDouble(cur_label.Name.Right(2)) - 5;
                        //if (pos < 0) pos += 24;
                        pos = Convert.ToDouble(cur_label.Name.Right(cur_label.Name.Length - cur_label.Name.IndexOf("_") - 1)) - 5;
                        if (pos > 24) pos -= 76;                        
                        //Canvas.SetTop(cur_label, 74 + pos * 60 * zoom_coef);
                        //if (pos > 24) pos -= top_shift - 4;
                        Canvas.SetTop(cur_label, top_shift - 6 + pos * 60 * zoom_coef);
                        if (cur_label.Name.Left(4) == "left")
                        {
                            Canvas.SetLeft(cur_label, (0+sc_view.HorizontalOffset));
                        }
                    }
                    //MessageBox.Show(cur_label.Name + '\n' + pos.ToString());
                }
                if (l.GetType() == typeof(Border))
                {
                    Border cur_bord = (Border)l;
                    if (cur_bord.Name.Left(10)=="headerbord")
                    {
                        Canvas.SetTop(cur_bord, day_top + sc_view.VerticalOffset);
                    }
                }
                if (l.GetType()==typeof(Rectangle))
                {
                    Rectangle r = (Rectangle)l;
                    if (r.Name.Left(7) == "blinder")
                    {
                        Canvas.SetTop(r, day_top+29 + sc_view.VerticalOffset);
                    }
                }
            }




            //Canvas.SetLeft(BufferToggleButton, main_window.ActualWidth +sc_view.HorizontalOffset- 70);
            //Canvas.SetTop(BufferToggleButton, 80+sc_view.VerticalOffset);



            //header1.Text = sc_view.VerticalOffset.ToString();
            /*
            Canvas.SetTop(Buf, 80 + sc_view.VerticalOffset);
            Canvas.SetTop(Buf_on_bord, Canvas.GetTop(Buf));
            Canvas.SetTop(ptemp45_200_border, Canvas.GetTop(Buf) + 70);
            Canvas.SetTop(ptemp52_280_border, Canvas.GetTop(Buf) + 150);
            Canvas.SetTop(ntemp15_360_border, Canvas.GetTop(Buf) + 230);

            Canvas.SetLeft(Buf, (main_window.ActualWidth - Buf.Width - 30) + sc_view.HorizontalOffset+200);
            Canvas.SetLeft(Buf_on_bord, (main_window.ActualWidth - Buf_on_bord.Width - 30) +sc_view.HorizontalOffset);
            Canvas.SetLeft(ptemp45_200_border, Canvas.GetLeft(Buf) + 20);
            Canvas.SetLeft(ptemp52_280_border, Canvas.GetLeft(Buf) + 20);
            Canvas.SetLeft(ntemp15_360_border, Canvas.GetLeft(Buf) + 20);
           // MessageBox.Show(Canvas.GetLeft(Buf_on_bord).ToString());
            */
        }


        private void bg_rect_MouseLeftButtonDown(object sender, EventArgs e)
        {
            start_pos_x = Mouse.GetPosition(null).X;
            start_pos_y = Mouse.GetPosition(null).Y;
            _isRectDragInProg = true;
            Rectangle cur_shape = (Rectangle)sender;
            cur_shape.CaptureMouse();
        }

        private void ControlClickMethod(MouseEventArgs e)
        {

            var mousePos = e.GetPosition(main_window);
            var DragOffset = e.GetPosition(main_window);

            // center the rect on the mouse


            double left = mousePos.X;
            double top = mousePos.Y;

            header1.Text = left.ToString() + '\n' + top.ToString();

            
            sc_view.ScrollToHorizontalOffset(sc_view.HorizontalOffset-(left-start_pos_x) * x_scroll_speed);
            //Canvas.SetLeft(canvasArea,Canvas.GetLeft(canvasArea) + (left - start_pos_x) * x_scroll_speed);
            sc_view.ScrollToVerticalOffset(sc_view.VerticalOffset - (top - start_pos_y) * y_scroll_speed);
            start_pos_y = top;
            start_pos_x = left;


        }

        private void ClickMethod()
        {
            //MessageBox.Show("Control is not pressed");
        }

        private void bg_rect_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isRectDragInProg)
            {
                if (Keyboard.Modifiers.ToString() == "Control")
                {
                    //ControlClickMethod((MouseEventArgs)e);
                    ClickMethod();
                }
                else
                {
                    ControlClickMethod((MouseEventArgs)e);
                    //ClickMethod();
                }
            }
        }

        private void bg_rect_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isRectDragInProg = false;
            Rectangle cur_shape = (Rectangle)sender;
            cur_shape.ReleaseMouseCapture();
        }

        /*
        private void Buf_on_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            is_buf_activated = 1;
        }


        private void Buf_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            is_buf_activated = 0;
        }
        */
        /*
        private void hor_Click(object sender, RoutedEventArgs e)
        {
            double cur_width = main_window.Width;
            double cur_height = main_window.Height;

            main_window.Height = cur_width;
            main_window.Width = cur_height;

            //canvasArea.Width = main_window.Width - 35;
            //bg_rect.Width = main_window.Width - 75;

        }
        */
        private void _printScreenButtton_Click(object sender, RoutedEventArgs e)
        {
            //Подготавливаем для печати
            while (zoom_slider.Value > 0.9)
            {
                zoom_slider.Value -= 0.01;
            }
            while (zoom_slider.Value < 0.9)
            {
                zoom_slider.Value += 0.01;
            }
            




            canvasArea.Width += 40;

            //Canvas.SetTop(canvasArea, Canvas.GetTop(canvasArea) + 100);
            foreach (UIElement el in canvasArea.Children)
            {
                Canvas.SetLeft(el, Canvas.GetLeft(el) + 40);
                Canvas.SetTop(el, Canvas.GetTop(el) + 40);
            }

            foreach (UIElement el in service_elements)
            {
                el.Visibility = Visibility.Hidden;
            }


            //Печатаем
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Printdlg.PrintVisual(canvasArea, "Print Canvas");
            }
            

            //Возвращаем на место
            
            foreach (UIElement el in service_elements)
            {
                el.Visibility = Visibility.Visible;
            }
            foreach (UIElement el in canvasArea.Children)
            {
                Canvas.SetLeft(el, Canvas.GetLeft(el) - 40);
                Canvas.SetTop(el, Canvas.GetTop(el) - 40);
            }
            canvasArea.Width -= 40;
            //Canvas.SetTop(canvasArea,Canvas.GetTop(canvasArea) - 100);
            
            while (zoom_slider.Value > 1)
            {
                zoom_slider.Value -= 0.01;
            }
            while (zoom_slider.Value < 1)
            {
                zoom_slider.Value += 0.01;
            }
            
        }
        private void OnPrint(object sender, RoutedEventArgs e, PrintDialog Printdlg)
        {
            //you can make your own precise calculation here
            Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
            // sizing of the element.
            canvasArea.Measure(pageSize);
            canvasArea.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Printdlg.PrintVisual(canvasArea, "Print Canvas");
            }
        }

        private void tb_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            TextBox cur_tb = (TextBox)sender;


            if (e.Delta>0)
            {
                cur_tb.Text = (Convert.ToDouble(cur_tb.Text) + 1).ToString();
            }
            else
            {
                if (Convert.ToDouble(cur_tb.Text) > 0)
                {
                    cur_tb.Text = (Convert.ToDouble(cur_tb.Text) - 1).ToString();
                }                
            }
        }

        private void circle_button_Click(object sender, RoutedEventArgs e)
        {

            Flyout_left.IsOpen = !Flyout_left.IsOpen;
            
            
        }

        private void weeks_combobox_SelectionChanged(object sender, EventArgs e)
        {
            ComboBox weeks_combobox = (ComboBox)sender;
            Rectangle new_rect = new Rectangle();
            new_rect.Tag = all_weeks[weeks_combobox.SelectedIndex].Ref.ToString();
            week_destroy(new_rect, e);
            //MessageBox.Show(weeks_combobox.Items[weeks_combobox.SelectedIndex].ToString() + '\n' + all_weeks[weeks_combobox.SelectedIndex].Note.ToString());
            
        }

        private void MenuToggleButton_Click(object sender, EventArgs e)
        {
            Flyout_top.Width = main_window.ActualWidth;
            Flyout_top.IsOpen = !Flyout_top.IsOpen;

            sp_weeks.Children.Clear();

            StackPanel combo_panel = new StackPanel();
            combo_panel.Orientation = Orientation.Vertical;
            combo_panel.Margin = new Thickness(4, 0, 4, 0);
            Label combo_label = new Label();
            combo_label.Content = "Выбор недели:";
            combo_label.FontSize = 12;
            combo_label.Foreground = Brushes.White;

            ComboBox weeks_combobox = new ComboBox();            
            foreach (TVWeekType week in all_weeks)
            {
                if (week.Note.Length > 0)
                {
                    weeks_combobox.Items.Add(week.Note);
                }
                else
                {
                    weeks_combobox.Items.Add(week.Name);                    
                }
            }

            
            weeks_combobox.SelectionChanged += weeks_combobox_SelectionChanged;            
            weeks_combobox.Width = 200;
            weeks_combobox.Height = 30;


            combo_panel.Children.Add(combo_label);
            combo_panel.Children.Add(weeks_combobox);
            sp_weeks.Children.Add(combo_panel);


            for (int i = 1; i <= l_weeks.Count(); i++)
            {

                Border my_bord = new Border();
                my_bord.Padding = new Thickness(4, 0, 4, 0);

                Rectangle my_rect = new Rectangle();
                my_bord.Child = my_rect;
                my_rect.Width = 55*0.8;
                my_rect.Height = 60*0.8;
                my_rect.Name = "var_rect_" + i.ToString();

                string my_string = "appbar_page_number_";
                int var_num = i;
                if (i > 1)
                {
                    my_string = my_string + var_num.ToString();
                }
                else
                {
                    my_string = my_string + "!";
                }
                VisualBrush myvb = new VisualBrush() { Visual = (Visual)Resources[my_string] };
                my_rect.Fill = Brushes.White;
                my_rect.OpacityMask = myvb;

                sp_weeks.Children.Add(my_bord);
                my_rect.Tag = l_weeks[i - 1].Ref;

                 my_rect.MouseEnter += var_MouseEnter;
                 my_rect.MouseLeave += var_MouseLeave;
                 my_rect.MouseDown += week_destroy;
                

                 TextBlock week_description = new TextBlock();
                 week_description.Name = "week_text_" + i.ToString();
                 week_description.Tag = l_weeks[i - 1].Ref;
                 week_description.Height = 60*0.8;
                 week_description.Width= 200*0.8;
                 //week_description.Text = l_weeks[i - 1].Name;
                 week_description.Text = l_weeks[i - 1].Note;
                 week_description.FontSize = 16;
                 week_description.Foreground = Brushes.White;
                 week_description.TextWrapping = TextWrapping.Wrap;
                 week_description.LineStackingStrategy = LineStackingStrategy.BlockLineHeight;
                 week_description.LineHeight = 18;
                 sp_weeks.Children.Add(week_description);
                 week_description.MouseEnter += var_MouseEnter;
                 week_description.MouseLeave += var_MouseLeave;
                 week_description.MouseDown += week_destroy;
            }
            
            int ii = -1;
            for (int i = 1; i <= l_weeks.Count(); i++)
            {
                foreach(UIElement child in sp_weeks.Children)
                {
                    if (child.GetType() == typeof(Border))
                    {
                        Border cur_bord = (Border)child;
                        Rectangle rect = (Rectangle)cur_bord.Child;
                        if (rect.Name=="var_rect_"+i.ToString() && rect.Tag.ToString() != cur_week_ref)
                        {
                            rect.Fill = Brushes.LightGray;
                            ii = i;
                        }
                    }
                    if (child.GetType() == typeof(TextBlock))
                    {
                        TextBlock week_text = (TextBlock)child;
                        if (week_text.Name == "week_text_" + i.ToString() && i==ii)
                        {
                            week_text.Foreground= Brushes.LightGray;
                        }
                    }
                }
            }
        }


        

        void var_MouseEnter(object sender, MouseEventArgs e)
        {

            if (sender.GetType() == typeof(TextBlock))
            {
                
                TextBlock cur_text = (TextBlock)sender;
                int i = Convert.ToInt32(cur_text.Name.Substring(cur_text.Name.LastIndexOf("_")+1,cur_text.Name.Length-cur_text.Name.LastIndexOf("_")-1));
                foreach (UIElement child in sp_weeks.Children)
                {
                    if (child.GetType() == typeof(Border))
                    {
                        Border cur_bord = (Border)child;
                        Rectangle rect = (Rectangle)cur_bord.Child;
                        if (rect.Name == "var_rect_" + i.ToString())
                        {
                            rect.Fill = Brushes.White;
                            break;
                        }
                    }
                }
                cur_text.Foreground = Brushes.White;
            }
            if (sender.GetType() == typeof(Rectangle))
            {
                Rectangle cur_rect = (Rectangle)sender;
                int i = Convert.ToInt32(cur_rect.Name.Substring(cur_rect.Name.LastIndexOf("_") + 1, cur_rect.Name.Length - cur_rect.Name.LastIndexOf("_") - 1));
                foreach (UIElement child in sp_weeks.Children)
                {
                    if (child.GetType() == typeof(TextBlock))
                    {
                        TextBlock week_text = (TextBlock)child;
                        if (week_text.Name == "week_text_" + i.ToString())
                        {
                            week_text.Foreground = Brushes.White;
                        }
                    }
                }
                cur_rect.Fill = Brushes.White;
            }
        }


        void var_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(TextBlock))
            {               
                TextBlock cur_text = (TextBlock)sender;

                int i = Convert.ToInt32(cur_text.Name.Substring(cur_text.Name.LastIndexOf("_") + 1, cur_text.Name.Length - cur_text.Name.LastIndexOf("_") - 1));
                foreach (UIElement child in sp_weeks.Children)
                {
                    if (child.GetType() == typeof(Border))
                    {
                        Border cur_bord = (Border)child;
                        Rectangle rect = (Rectangle)cur_bord.Child;
                        if (rect.Name == "var_rect_" + i.ToString() && rect.Tag.ToString() != cur_week_ref)
                        {
                            rect.Fill = Brushes.LightGray;
                            cur_text.Foreground = Brushes.LightGray;
                            break;
                        }
                    }
                }

            }
            if (sender.GetType() == typeof(Rectangle))
            {
                Rectangle cur_rect = (Rectangle)sender;
                int i = Convert.ToInt32(cur_rect.Name.Substring(cur_rect.Name.LastIndexOf("_") + 1, cur_rect.Name.Length - cur_rect.Name.LastIndexOf("_") - 1));
                foreach (UIElement child in sp_weeks.Children)
                {
                    if (child.GetType() == typeof(TextBlock))
                    {
                        TextBlock week_text = (TextBlock)child;
                        if (week_text.Name == "week_text_" + i.ToString() && cur_rect.Tag !=cur_week_ref)
                        {
                            week_text.Foreground = Brushes.LightGray;
                            cur_rect.Fill = Brushes.LightGray;
                        }
                    }
                }

            }
        }

        private void buttons_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            Button cur_button = (Button)sender;
            Label cur_label = (Label)cur_button.Content;
            //Label cur_hours = null;
            if (e.Delta > 0)
            {
                update_buttons_content(cur_button, cur_label, true);
            }
            else
            {
                update_buttons_content(cur_button, cur_label, false);
            }

            update_prog(sender, e);
            




        }

        private void update_buttons_content(Button cur_button, Label cur_label, bool plus)
        {
            Label cur_hours = null;
            if (plus == true)
            {
                cur_label.Content = (Convert.ToDouble(cur_label.Content) + 1).ToString();

                if (cur_button.Name.Right(7) == "minutes" && Convert.ToDouble(cur_label.Content) == 60)
                {
                    if (cur_button.Name.Left(9) == "timestart")
                    {
                        cur_hours = (Label)timestart_hours.Content;
                        cur_hours.Content = (Convert.ToDouble(cur_hours.Content) + 1).ToString();
                        cur_label.Content = (Convert.ToDouble(cur_label.Content) - 60).ToString();
                    }
                    if (cur_button.Name.Left(8) == "duration")
                    {
                        cur_hours = (Label)duration_hours.Content;
                        cur_hours.Content = (Convert.ToDouble(cur_hours.Content) + 1).ToString();
                        cur_label.Content = (Convert.ToDouble(cur_label.Content) - 60).ToString();
                    }
                }

            }
            else
            {
                //if (Convert.ToDouble(cur_label.Content) > 0)
                //{
                cur_label.Content = (Convert.ToDouble(cur_label.Content) - 1).ToString();
                //}
                if (cur_button.Name.Right(7) == "minutes" && Convert.ToDouble(cur_label.Content) < 0)
                {
                    if (cur_button.Name.Left(9) == "timestart")
                    {
                        cur_hours = (Label)timestart_hours.Content;
                        cur_hours.Content = (Convert.ToDouble(cur_hours.Content) - 1).ToString();
                        cur_label.Content = (Convert.ToDouble(cur_label.Content) + 60).ToString();
                    }
                    if (cur_button.Name.Left(8) == "duration")
                    {
                        cur_hours = (Label)duration_hours.Content;
                        cur_hours.Content = (Convert.ToDouble(cur_hours.Content) - 1).ToString();
                        cur_label.Content = (Convert.ToDouble(cur_label.Content) + 60).ToString();
                    }
                }

            }

            if (cur_button.Name == "r" || cur_button.Name == "t" || cur_button.Name == "a")
            {
                if (Convert.ToDouble(cur_label.Content) < 0) cur_label.Content = "0";
            }
            if (cur_button.Name == "timestart_hours")
            {
                if (Convert.ToDouble(cur_label.Content) == 24) cur_label.Content = "0";
                if (Convert.ToDouble(cur_label.Content) < 0) cur_label.Content = "23";
            }
            if (cur_button.Name == "duration_hours")
            {
                if (Convert.ToDouble(cur_label.Content) < 0) cur_label.Content = "0";
            }


            //Добавляем ведущие нули
            if (cur_button.Name.Left(9) == "timestart" || cur_button.Name.Left(8) == "duration")
            {
                if (cur_label.Content.ToString().Length == 1) cur_label.Content = string.Concat("0", cur_label.Content.ToString());
            }
            if (cur_hours != null)
            {
                if (cur_hours.Content.ToString().Length == 1) cur_hours.Content = string.Concat("0", cur_hours.Content.ToString());
            }
        }

        private void tb_title_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (selected_progs.Count() == 1 && (e.Key == Key.Return))
            {
                TextBlock prog_text = selected_progs[0];
                //string title = prog_text.Text.Substring(prog_text.Text.IndexOf(")") + 2, prog_text.Text.IndexOf("[") - prog_text.Text.IndexOf(")") - 3);
                string title = prog_text.Text.full_title();
                //prog_text.Text = prog_text.Text.full_title();

                //Правим название программы
                if (tb_title.Text.Length == 0) tb_title.Text = "БЕЗ НАЗВАНИЯ";
                //tb_title.Text = tb_title.Text.Replace(",,,", "\n");

                //Ключи
                tb_keys(prog_text);
                prog_text.Text = prog_text.Text.Replace(title, tb_title.Text.Replace("#", "\n"));



               // update_efir(prog_text);
            }
        }

        
        private void button_TouchUp(object sender, TouchEventArgs e)
        {
            Button cur_button = (Button)sender;
            string g=e.TouchDevice.GetTouchPoint(main_window).Position.X.ToString();
            cur_button.ReleaseTouchCapture(e.TouchDevice);
            double final_pos = e.GetTouchPoint(main_window).Position.X;
            double distance = final_pos - initial_pos;
        }

        private void button_TouchDown(object sender, TouchEventArgs e)
        {
            Button cur_button = (Button)sender;
            cur_button.CaptureTouch(e.TouchDevice);
            initial_pos = e.GetTouchPoint(main_window).Position.X;
        }

        private void button_TouchMove(object sender, TouchEventArgs e)
        {            
            Button cur_button = (Button)sender;
            Label cur_label = (Label)cur_button.Content;
            double cur_pos = e.GetTouchPoint(main_window).Position.X;
            double distance = initial_pos - cur_pos;
            if (Math.Abs(distance)>=30)
            {
                initial_pos = cur_pos;
                if (distance < 0) update_buttons_content(cur_button, cur_label, true);
                if (distance > 0) update_buttons_content(cur_button, cur_label, false);
                update_prog(sender, e);
            }
        }

        private void bg_rect_TouchDown(object sender, TouchEventArgs e)
        {

            bool bylo = false;
           // e.TouchDevice.Capture(day1);
            
           // MessageBox.Show(e.TouchDevice.Id.ToString());
           // day1.ReleaseTouchCapture(e.TouchDevice);
            if (TouchDevices_list.Count()==0)
            {
                TouchDevices_list.Add(e.TouchDevice.Id.ToString());
            }
            else
            {
                foreach (String td in TouchDevices_list)
                {
                    if (td == e.TouchDevice.Id.ToString())
                    {
                        bylo = true;
                        break;
                    }
                }
                if (bylo == false) TouchDevices_list.Add(e.TouchDevice.Id.ToString());
            }

            Debug.WriteLine("Всего девайсов: "+ TouchDevices_list.Count().ToString());

        }

        private void main_window_TouchDown(object sender, TouchEventArgs e)
        {
          
            //inkcanvas1.IsHitTestVisible = false;
            visible_canvas.IsHitTestVisible = false;

        //    Canvas.SetZIndex(inkcanvas1, -10000);

            bool bylo = false;
            
            if (TD_list.Count() == 0)
            {
                TD_list.Add(e.TouchDevice);
            }
            else
            {
                foreach (TouchDevice td in TD_list)
                {
                    if (td.Id == e.TouchDevice.Id)
                    {
                        bylo = true;
                        break;
                    }
                }
                if (bylo == false) TD_list.Add(e.TouchDevice);
            }
            Debug.WriteLine("Всего девайсов: " + TD_list.Count().ToString());
            TouchPoint tp = e.GetTouchPoint(main_window);
            Debug.WriteLine("Размер" + tp.Size.ToString());
            if (TD_list.Count() == 2)
            {
                e.Handled = true;
                TouchDevice td1 = (TouchDevice)TD_list[0];
                TouchDevice td2 = (TouchDevice)TD_list[1];

                Debug.WriteLine("И зовут их: " + td1.Id + " и " + td2.Id + "!");

                td1.Capture(main_window);
                td2.Capture(main_window);

            }
            
        }



        private void main_window_TouchUp(object sender, TouchEventArgs e)
        {
         //   Canvas.SetZIndex(inkcanvas1, 10000);
            //e.Handled = true;
            /*
            if (inkcanvas1.Strokes.Count > strokes_num)
                inkcanvas1.Strokes.Remove(inkcanvas1.Strokes.Last());
            */
            if (visible_canvas.Strokes.Count > strokes_num)
                visible_canvas.Strokes.Remove(visible_canvas.Strokes.Last());

            foreach (TouchDevice td in TD_list)
            {
                if (td.Id == e.TouchDevice.Id)
                {
                    main_window.ReleaseAllTouchCaptures();
                    initial_dist = 0;
                    TD_list.Remove(td);
                    break;
                }
            }
            
        }

        private void main_window_TouchMove(object sender, TouchEventArgs e)
        {
            if (TD_list.Count()==2)
            {
                e.Handled = true;
                TouchDevice td1 = (TouchDevice)TD_list[0];
                TouchDevice td2 = (TouchDevice)TD_list[1];

                double X1 = td1.GetTouchPoint(main_window).Position.X;
                double X2 = td2.GetTouchPoint(main_window).Position.X;
                double Y1 = td1.GetTouchPoint(main_window).Position.Y;
                double Y2 = td2.GetTouchPoint(main_window).Position.Y;

                


                double distance = Math.Sqrt(Math.Abs((X1 - X2) * (X1 - X2) + (Y1 - Y2) * (Y1 - Y2)));
                
                if (initial_dist == 0) initial_dist = distance;

                double delta = distance - initial_dist;

                if (Math.Abs(delta)>=zoom_tick1)
                {
                    if (delta >0)
                    {
                       //   if (zoom_coef<2) zoom_coef += 0.1;
                        if (zoom_slider.Value < 2) zoom_slider.Value += zoom_tick2;
                    }
                    else
                    {
                     //   if (zoom_coef>0.5) zoom_coef -= 0.1;
                        if (zoom_slider.Value > 0.5) zoom_slider.Value -= zoom_tick2;
                    }
                    initial_dist = distance;
                }
                
                //Debug.WriteLine(initial_dist.ToString()+"-"+distance.ToString()+"-"+ zoom_coef.ToString());



                //Debug.WriteLine("Координаты1: " + X1.ToString() + "," + Y1.ToString() + '\n' + X2.ToString() + "," + Y2.ToString());

            }
        }

        private void addDaysButton_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            //wc.GetEfirs(new DateTime(2014, 10, 13), 10, 1);
        }

        private void addDaysButton_Click(object sender, RoutedEventArgs e)
        {
            Flyout_right.IsOpen = !Flyout_right.IsOpen;
        }

        private void CreateDaysButton_Click(object sender, RoutedEventArgs e)
        {

            

            //EfirType[] efirs = null;
            Label date_label = new Label();
            Label variant_label = new Label();
            ToggleButton variant_tb = new ToggleButton();
            Label channel_label = new Label();
            ComboBox channel_combobox = new ComboBox();
            StackPanel stckp = new StackPanel();
            List<Tuple<DateTime,int>> date_var = new List<Tuple<DateTime,int>>();
            


            int channel = 10;
            int variant = 1;
            
            
            
            DateTime date = new DateTime();
            if (de_grid.RowDefinitions.Count() > 0)
            {
                for (int i=0; i < de_grid.RowDefinitions.Count; i++ )
                {
                    List<int> var_list = new List<int>();

                       foreach (UIElement child in de_grid.Children)
                        {
                            if (child.GetType() == typeof(Label))
                            {
                                
                                if (Grid.GetRow(child) == i)
                                {
                                    if (Grid.GetColumn(child) == 0)
                                    {
                                        date_label = (Label)child;
                                        date = DateTime.Parse((string)date_label.Content);
                                    }
                                    if (Grid.GetColumn(child) == 1)
                                    {
                                        //channel_label = (Label)child;
                                        channel_combobox = (ComboBox)child;
                                        MessageBox.Show(channel_combobox.SelectedValue.ToString());
                                    }
                                    if (Grid.GetColumn(child) == 2)
                                    {
                                        channel_label = (Label)child;
                                    }
                                    
                                }
                            }
                           if (child.GetType() == typeof(StackPanel ))
                           {
                               if (Grid.GetRow(child) == i)
                               {
                                   stckp = (StackPanel)child;
                                   foreach (ToggleButton tb in stckp.Children)
                                   {
                                       if (tb.IsChecked==true)  date_var.Add(Tuple.Create(date, Convert.ToInt32(tb.Content)));
                                   }
                               }
                           }
                           if (child.GetType()==typeof(ComboBox))
                           {
                               if (Grid.GetColumn(child) == 1)
                               {                                   
                                   channel_combobox = (ComboBox)child;
                                   //MessageBox.Show(channel_combobox.SelectedValue.ToString());
                               }
                           }
                        }
                }
                

                for (int i = 0; i < date_var.Count; i++) // Надо цикл пускать по новой коллекции
                {
                    //MessageBox.Show(date_var[i].Item2.ToString());
                //Пускаем цикл по дням


                       if (channel_combobox.SelectedValue == "Все орбиты")
                       {
                           for (int ii = 10; ii<=14; ii++)
                           {
                               //Пускаем цикл по дням
                               CultureInfo russian = new CultureInfo("ru-RU");
                               string dayName = date_var[i].Item1.ToString("dddd", russian);
                               dayName = dayName.Substring(0, 1).ToUpper() + dayName.Substring(1, dayName.Length - 1) +
                                        '\n' + date_var[i].Item1.ToString("dd/MM/yyyy");
                               channel = ii;
                               EfirType[] efirs = wc.GetEfirs(date_var[i].Item1, channel, date_var[i].Item2);
                               string DayRef = "";
                               if (efirs.Length > 0)
                               {
                                   DayRef = efirs[1].TVDayRef;
                               }
                               if (channel >= 11 && channel <= 14)
                                   dayName += '\n' + "Орбита-" + (channel - 10).ToString();



                               create_day(dayName, days_count, date_var[i].Item2, DayRef);

                               for (int j = 0; j < efirs.Length; j++)
                               {
                                   //MessageBox.Show(efirs[i].Beg.Hour.ToString());


                                   int t = 0;
                                   double r = 0;
                                   double a = 0;
                                   double raw_timing = efirs[j].Timing;
                                   string beg_time = efirs[j].Beg.Hour.ToString() + ":" + efirs[j].Beg.Minute.ToString();
                                   beg_time = beg_time.leading_zeros();
                                   if (date_var[i].Item1.Date < efirs[j].Beg.Date.Date) beg_time = (beg_time.time_to_minutes() + 24 * 60).ToString();
                                   if (efirs[j].ITC.Length > 0)
                                   {
                                       foreach (ITCType itc in efirs[j].ITC)
                                       {
                                           if (itc.Title == "Р" || itc.Title == "Р99" || itc.Title == "СР")
                                           {
                                               r += itc.Timing;
                                               if (itc.Title == "Р") t += itc.PointCount;
                                           }
                                           if (itc.Title == "А")
                                           {
                                               a += itc.Timing;
                                           }
                                       }
                                   }

                                   raw_timing = raw_timing - r - a;
                                   raw_timing = raw_timing / 60;
                                   raw_timing = Math.Floor(raw_timing / 1);

                                   r /= 60;
                                   a /= 60;
                                   //r = Math.Ceiling(r);
                                   //a = Math.Ceiling(a);
                                   r = Math.Round(r);
                                   a = Math.Round(a);

                                   string s_timing = raw_timing.minutes_to_time();
                                   string code = efirs[j].ProducerCode.ToString() + efirs[j].SellerCode.ToString();
                                   string doc_number = efirs[j].Ref;
                                   //string t_timing = efirs[i].Timing
                                   //Debug.WriteLine(efirs[j].Title + " -- " + beg_time.leading_zeros() + "--" + efirs[j].Timing.ToString());
                                   //Создаем программы
                                   if (channel >= 11 && channel <= 14)
                                   {
                                       beg_time = beg_time.add_minute((10 - (channel - 10) * 2) * 60);
                                       if (beg_time.time_to_minutes() >= 29 * 60 && date_var[i].Item1.Date > efirs[j].Beg.Date.Date) beg_time = beg_time.add_minute(-24 * 60);
                                   }
                                   string prog_name = "";
                                   if (efirs[j].ANR.Length>0)
                                   {
                                       prog_name=efirs[j].ANR;
                                   }
                                   else
                                   {
                                       prog_name=efirs[j].Title;
                                   }
                                   if (raw_timing >= 5) create_prog(prog_name, days_count - 1, beg_time.time_to_minutes(), raw_timing, r, t, a, code, doc_number, Convert.ToInt32(efirs[j].Age));
                               }
                           }
                       }
                       else
                       {
                           CultureInfo russian = new CultureInfo("ru-RU");
                           string dayName = date_var[i].Item1.ToString("dddd", russian);
                           dayName = dayName.Substring(0, 1).ToUpper() + dayName.Substring(1, dayName.Length - 1) +
                                    '\n' + date_var[i].Item1.ToString("dd/MM/yyyy");


                           channel = channel_combobox.SelectedValue.ToString().channel_text_to_int();
                           //EfirType[] efirs = null;
                           EfirType[] efirs = wc.GetEfirs(date_var[i].Item1, channel, date_var[i].Item2);
                           string DayRef = "";
                           if (efirs.Length > 0)
                           {
                               DayRef = efirs[1].TVDayRef;
                           }
                           if (channel >= 11 && channel <= 14)
                               dayName += '\n' + "Орбита-" + (channel - 10).ToString();



                           create_day(dayName, days_count, date_var[i].Item2, DayRef);

                           for (int j = 0; j < efirs.Length; j++)
                           {
                               //MessageBox.Show(efirs[i].Beg.Hour.ToString());


                               int t = 0;
                               double r = 0;
                               double a = 0;
                               double raw_timing = efirs[j].Timing;
                               string beg_time = efirs[j].Beg.Hour.ToString() + ":" + efirs[j].Beg.Minute.ToString();
                               beg_time = beg_time.leading_zeros();
                               if (date_var[i].Item1.Date < efirs[j].Beg.Date.Date) beg_time = (beg_time.time_to_minutes() + 24 * 60).ToString();
                               if (efirs[j].ITC.Length > 0)
                               {
                                   foreach (ITCType itc in efirs[j].ITC)
                                   {
                                       if (itc.Title == "Р" || itc.Title == "Р99" || itc.Title == "СР")
                                       {
                                           r += itc.Timing;
                                           if (itc.Title == "Р") t += itc.PointCount;
                                       }
                                       if (itc.Title == "А")
                                       {
                                           a += itc.Timing;
                                       }
                                   }
                               }

                               raw_timing = raw_timing - r - a;
                               raw_timing = raw_timing / 60;
                               raw_timing = Math.Floor(raw_timing / 1);

                               r /= 60;
                               a /= 60;
                               //r = Math.Ceiling(r);
                               //a = Math.Ceiling(a);
                               r = Math.Round(r);
                               a = Math.Round(a);

                               string s_timing = raw_timing.minutes_to_time();
                               string code = efirs[j].ProducerCode.ToString() + efirs[j].SellerCode.ToString();
                               string doc_number = efirs[j].Ref;
                               //string t_timing = efirs[i].Timing
                               //Debug.WriteLine(efirs[j].Title + " -- " + beg_time.leading_zeros() + "--" + efirs[j].Timing.ToString());
                               //Создаем программы
                               if (channel >= 11 && channel <= 14)
                               {
                                   beg_time = beg_time.add_minute((10 - (channel - 10) * 2) * 60);
                                   if (beg_time.time_to_minutes() >= 29 * 60 && date_var[i].Item1.Date > efirs[j].Beg.Date.Date) beg_time = beg_time.add_minute(-24 * 60);
                               }
                               string prog_name = "";
                               if (efirs[j].ANR.Length > 0)
                               {
                                   prog_name = efirs[j].ANR;
                               }
                               else
                               {
                                   prog_name = efirs[j].Title;
                               }
                               if (raw_timing >= 5) create_prog(prog_name, days_count - 1, beg_time.time_to_minutes(), raw_timing, r, t, a, code, doc_number, Convert.ToInt32(efirs[j].Age));
                           }
                       }



                }
                

            }
            

            


        }

        private void days_calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (de_grid.RowDefinitions.Count() > 0)
            {
                de_grid.RowDefinitions.RemoveRange(0, de_grid.RowDefinitions.Count());       
                if (de_grid.Children.Count>0)
                {
                    de_grid.Children.RemoveRange(0, de_grid.Children.Count);
                }
            }
            create_day_entry(days_calendar.SelectedDates);           
        }

        private void create_day_entry(SelectedDatesCollection sd)
        {



            





            foreach( DateTime date in sd)
            {
                RowDefinition rowDef1 = new RowDefinition();
                de_grid.RowDefinitions.Add(rowDef1);
                
                

                Label date_label = new Label()
                {
                    Name = "test",
                    Content = date.ToShortDateString().ToString(),
                    FontSize = 14,
                    Foreground = Brushes.White
                };

                Grid.SetColumn(date_label, 0);
                Grid.SetRow(date_label, de_grid.RowDefinitions.Count() - 1);
                de_grid.Children.Add(date_label);

                /*
                Label channel_label = new Label()
                {
                    Name = "test",
                    Content = "Первый канал",
                    FontSize = 18
                };
                 */
                
                ComboBox channel_combobox = new ComboBox();
                channel_combobox.Items.Add("Первый канал");
                channel_combobox.Items.Add("Россия-1");
                channel_combobox.Items.Add("НТВ");
                channel_combobox.Items.Add("СТС");
                channel_combobox.Items.Add("ТНТ");
                channel_combobox.Items.Add("Все орбиты");
                channel_combobox.Items.Add("Орбита-1");
                channel_combobox.Items.Add("Орбита-2");
                channel_combobox.Items.Add("Орбита-3");
                channel_combobox.Items.Add("Орбита-4");
                if (ch_oneb.Opacity==1) channel_combobox.SelectedItem = channel_combobox.Items[0];                
                if (ch_rus1b.Opacity == 1) channel_combobox.SelectedItem = channel_combobox.Items[1];
                if (ch_ntvb.Opacity == 1) channel_combobox.SelectedItem = channel_combobox.Items[2];
                if (ch_stsb.Opacity == 1) channel_combobox.SelectedItem = channel_combobox.Items[3];
                if (ch_tntb.Opacity == 1) channel_combobox.SelectedItem = channel_combobox.Items[4];
                if (ch_orbb.Opacity == 1) channel_combobox.SelectedItem = channel_combobox.Items[5];
                channel_combobox.SelectionChanged += channel_combobox_SelectionChanged;
                channel_combobox.Tag = date.ToShortDateString().ToString();
                channel_combobox.Width = 115;
                channel_combobox.Height = 25;
                
                

                Grid.SetColumn(channel_combobox, 1);
                Grid.SetRow(channel_combobox, de_grid.RowDefinitions.Count() - 1);
                de_grid.Children.Add(channel_combobox);




                EfirType ef = new EfirType();
                ef.Variant = new VarType();

                TVDayVariantType[] variants = wc.GetDayVariants(date, 10);
                int counter = 0;





                if (variants.Length == 0)
                {
                    Label variant_label = new Label();
                    variant_label.Name = "var" + counter.ToString();
                    variant_label.Content = "Нет вариантов расписания";
                    variant_label.FontSize = 14;
                    variant_label.Foreground = Brushes.White;
                    Grid.SetColumn(variant_label, 3);
                    Grid.SetRow(variant_label, de_grid.RowDefinitions.Count() - 1);

                    de_grid.Children.Add(variant_label);
                    de_grid.HorizontalAlignment = HorizontalAlignment.Center;
                }
                else
                {
                    StackPanel vars_spanel = new StackPanel();
                    vars_spanel.Orientation = Orientation.Horizontal;
                    Grid.SetColumn(vars_spanel, 3);
                    Grid.SetRow(vars_spanel, de_grid.RowDefinitions.Count() - 1);
                    de_grid.Children.Add(vars_spanel);


                    /*
                    foreach (TVDayVariantType v in variants)
                    {
                        counter += 1;
                        Label variant_label = new Label();
                        variant_label.Name = "var" + counter.ToString();
                        variant_label.Content = counter.ToString();
                        variant_label.FontSize = 18;
                        Grid.SetColumn(variant_label, 3);
                        Grid.SetRow(variant_label, de_grid.RowDefinitions.Count() - 1);
                        de_grid.Children.Add(variant_label);
                    }
                     */ 
                    foreach (TVDayVariantType v in variants)
                    {
                        counter += 1;
                       
                        ToggleButton variant_button = new ToggleButton();
                        variant_button.Name = "var" + v.VariantCode.ToString();
                        variant_button.Content = v.VariantCode.ToString();
                        variant_button.FontSize = 12;
                        variant_button.Height = 25;
                        variant_button.Width = 25;
                        if (counter==1)
                        {
                            variant_button.IsChecked = true;
                        }

                        /*

                        Label variant_label = new Label();
                        variant_label.Name = "var" + counter.ToString();
                        variant_label.Content = counter.ToString();
                        variant_label.FontSize = 18;

                        variant_label.BorderBrush = Brushes.White;
                        variant_label.BorderThickness = new Thickness(1);
                        variant_label.Height = 50;
                        variant_label.Width = 50;
                        */
                        vars_spanel.Children.Add(variant_button);


                        
                        /*
                        Grid.SetColumn(variant_label, 3);
                        Grid.SetRow(variant_label, de_grid.RowDefinitions.Count() - 1);
                        de_grid.Children.Add(variant_label);
                          */                                          
                          
                    }


                }
            }
            


        }

        void channel_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            ComboBox cur_cb = (ComboBox)sender;
            string ch_string = cur_cb.SelectedValue.ToString();
            StackPanel vars_spanel = new StackPanel();
            int channel = ch_string.channel_text_to_int();
            DateTime date =  DateTime.Parse(cur_cb.Tag.ToString());
            

                       foreach (UIElement child in de_grid.Children)
                       {
                           if (Grid.GetRow(child) == Grid.GetRow(cur_cb))
                           {
                               if (Grid.GetColumn(child) == 3)
                               {
                                   if (child.GetType() == typeof(StackPanel))
                                   {
                                       vars_spanel = (StackPanel)child;
                                       vars_spanel.Children.RemoveRange(0, vars_spanel.Children.Count);
                                       break;
                                   }
                               }
                           }
                       }
                
                                




            TVDayVariantType[] variants = wc.GetDayVariants(date, channel);
                int counter = 0;

                if (variants.Length == 0)
                {
                    Label variant_label = new Label();
                    variant_label.Name = "var" + counter.ToString();
                    variant_label.Content = "Нет вариантов расписания";
                    variant_label.FontSize = 14;
                    variant_label.Foreground = Brushes.White;
                    //Grid.SetColumn(variant_label, 3);
                    //Grid.SetRow(variant_label, Grid.GetRow(cur_cb));


                    vars_spanel.Children.Add(variant_label);
                    //de_grid.Children.Add(variant_label);
                    //de_grid.HorizontalAlignment = HorizontalAlignment.Center;
                }
                else
                {
                    //StackPanel vars_spanel = new StackPanel();
                    //vars_spanel.Orientation = Orientation.Horizontal;
                    //Grid.SetColumn(vars_spanel, 3);
                    //Grid.SetRow(vars_spanel, Grid.GetRow(cur_cb));
                    //de_grid.Children.Add(vars_spanel);


                    foreach (TVDayVariantType v in variants)
                    {
                        counter += 1;

                        ToggleButton variant_button = new ToggleButton();
                        variant_button.Name = "var" + v.VariantCode.ToString();
                        variant_button.Content = counter.ToString();
                        variant_button.FontSize = 12;
                        variant_button.Height = 25;
                        variant_button.Width = 25;
                        if (counter == 1)
                        {
                            variant_button.IsChecked = true;
                        }


                        vars_spanel.Children.Add(variant_button);

                    }
                }


        }

        private void header_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock cur_shape = (TextBlock)sender;
            Border cur_bord2 = (Border)cur_shape.Parent;

            current_text = cur_shape;
            current_bord = cur_bord2;

            if (isFirstClick)
            {
                isFirstClick = false;
                // Start the double click timer.
                doubleClickTimer.Start();
                hold_timer.Start();

            }

           // This is the second mouse click. 
            else
            {
                if (milliseconds < System.Windows.Forms.SystemInformation.DoubleClickTime)
                {
                    isDoubleClick = true;
                    doubleClickTimer.Stop();
                    //MessageBox.Show(milliseconds.ToString()+'\n'+System.Windows.Forms.SystemInformation.DoubleClickTime.ToString());
                }

            }





            if (isDoubleClick == true)
            {
                isDoubleClick = false;
                isFirstClick = true;
                milliseconds = 0;
                
                Border cur_bord = new Border();
                foreach (TextBlock tb in selected_days)
                {
                    cur_bord = (Border)tb.Parent;
                    cur_bord.BorderThickness = new Thickness(1);
                    cur_bord.BorderBrush = Brushes.Black;
                }
                selected_days.Clear();
                 
                Flyout_day.IsOpen = true;
                Flyout_day.Width = main_window.ActualWidth-200;
                Flyout_bottom.IsOpen = false;
                
                
                selected_days.Add(cur_shape);




                ch_rus1.Opacity = 0.3;
                ch_ntv.Opacity = 0.3;
                ch_sts.Opacity = 0.3;
                ch_tnt.Opacity = 0.3;



                foreach (UIElement tb in canvasArea.Children)
                {
                    if (tb.GetType() == typeof(Border))
                    {

                        Border cur_tb = (Border)tb;
                        TextBlock day_text = (TextBlock)cur_tb.Child;
                        if (cur_tb.Name.Left(10) == "headerbord")
                        {
                            string s1 = cur_bord2.ToolTip.ToString();
                            string s2 = cur_tb.ToolTip.ToString();
                            if (cur_bord2.ToolTip.ToString() == cur_tb.ToolTip.ToString())
                            
                            {
                                if (day_text.Text.Contains("Россия-1")) ch_rus1.Opacity = 1;
                                if (day_text.Text.Contains("НТВ")) ch_ntv.Opacity = 1;
                            }
                        }
                        
                    }
                }


                ch_activate();
                /*
                cur_bord = (Border)cur_shape.Parent;
                cur_bord.BorderThickness = new Thickness(3);
                cur_bord.BorderBrush = Brushes.Blue;
                */

                day_title.Text = selected_days[0].Text.Replace("\n","#");



            }
        }


        private void ch_activate()
        {            
            
            TextBlock cur_header = selected_days[0];
            Border c_border = (Border)cur_header.Parent;
            string[] tb_name = cur_header.Text.Split('\n');
            CultureInfo russian = new CultureInfo("ru-RU");
            DateTime date = DateTime.Parse(tb_name[1]);
            
            if (cur_header.Text.Contains("Россия-1") || cur_header.Text.Contains("НТВ") || cur_header.Text.Contains("СТС") || cur_header.Text.Contains("ТНТ"))
            {
                foreach (UIElement child in canvasArea.Children)
                {
                    if (child.GetType() == typeof(Border))
                    {
                        Border cur_bord = (Border)child;
                        TextBlock cur_text = (TextBlock)cur_bord.Child;

                        if (cur_bord.Name.Left(10) == "headerbord")
                        {
                            if (cur_text.Text.Contains(tb_name[1]) && cur_text.Text.Contains("Россия-1")) ch_rus1.Opacity = 1;
                            if (cur_text.Text.Contains(tb_name[1]) && cur_text.Text.Contains("НТВ")) ch_ntv.Opacity = 1;
                            if (cur_text.Text.Contains(tb_name[1]) && cur_text.Text.Contains("СТС")) ch_sts.Opacity = 1;
                            if (cur_text.Text.Contains(tb_name[1]) && cur_text.Text.Contains("ТНТ")) ch_tnt.Opacity = 1;
                            
                            if (cur_text.Text.Contains(tb_name[1]) &! (cur_text.Text.Contains("Россия-1") || cur_text.Text.Contains("НТВ") || cur_text.Text.Contains("СТС") || cur_text.Text.Contains("ТНТ")))
                            {
                                foreach (TextBlock tb in selected_days)
                                {
                                    c_border = (Border)tb.Parent;
                                    c_border.BorderThickness = new Thickness(1);
                                    c_border.BorderBrush = Brushes.Black;
                                }
                                selected_days.Clear();
                                selected_days.Add(cur_text);                                
                                cur_bord.BorderThickness = new Thickness(3);
                                cur_bord.BorderBrush = Brushes.Blue;                                
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (UIElement child in canvasArea.Children)
                {
                    if (child.GetType() == typeof(Border))
                    {
                        Border cur_bord = (Border)child;
                        TextBlock cur_text = (TextBlock)cur_bord.Child;

                        if (cur_bord.Name.Left(10) == "headerbord")
                        {
                            if (cur_text.Text.Contains(tb_name[1]) && cur_text.Text.Contains("Россия-1")) ch_rus1.Opacity = 1;
                            if (cur_text.Text.Contains(tb_name[1]) && cur_text.Text.Contains("НТВ")) ch_ntv.Opacity = 1;
                            if (cur_text.Text.Contains(tb_name[1]) && cur_text.Text.Contains("СТС")) ch_sts.Opacity = 1;
                            if (cur_text.Text.Contains(tb_name[1]) && cur_text.Text.Contains("ТНТ")) ch_tnt.Opacity = 1;
                        }
                    }
                }


                //selected_days.Add(cur_header);
                c_border = (Border)cur_header.Parent;
                c_border.BorderThickness = new Thickness(3);
                c_border.BorderBrush = Brushes.Blue;
            }

        }





        private void header_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _isRectDragInProg = false;
            var cur_shape = (TextBlock)sender;
            Border cur_bord = (Border)cur_shape.Parent;
            hold_timer.Stop();
            hold_seconds = 0;
            cur_shape.ReleaseMouseCapture();

            


        }

        public void delete_day_Click(object sender, EventArgs e)
        {
            //updated 16.10.14 - испралена ошиба с днями >10
            //List<TextBlock> progs2remove = new List<TextBlock>();
            List<UIElement> progs2remove = new List<UIElement>();
            Border shapka_bord = new Border();
            if (selected_days.Count > 0)
            {
                foreach (TextBlock tb in selected_days)
                {
                    if (progs2remove.Count > 0) progs2remove.Clear();
                    days_count -= 1;
                    int day_num = Convert.ToInt32(tb.Name.Replace("headertext", ""));








                    foreach (UIElement child in canvasArea.Children)
                    {
                        int day_num2 = 0;
                        if (child.GetType() == typeof(Border))
                        {
                            Border cur_bord = new Border();
                            TextBlock cur_text = new TextBlock();
                            cur_bord = (Border)child;
                            cur_text = (TextBlock)cur_bord.Child;



                            if (cur_text.Name.Length >= 4)
                            {
                                if (cur_text.Name.Left(4) == "prog" || cur_text.Name.Left(4) == "news")
                                {
                                    //day_num2 = Convert.ToInt32(cur_text.Name.Substring(4, 1));
                                    day_num2 = Convert.ToInt32(cur_text.Name.Substring(4, cur_text.Name.IndexOf("_") - 4));
                                    if (day_num == day_num2)
                                    {
                                        progs2remove.Add(child);
                                    }
                                    if (day_num2 > day_num)
                                    {
                                        //Только до 9 дней - fixed
                                        string new_name = cur_text.Name.Left(4) + (Convert.ToInt32(cur_text.Name.Substring(4, cur_text.Name.IndexOf("_") - 4)) - 1).ToString();

                                        cur_text.Name = cur_text.Name.Replace(cur_text.Name.Left(cur_text.Name.IndexOf("_")), new_name);
                                        //cur_text.Text = cur_text.Name;
                                        cur_bord.Name = cur_text.Name.Replace("prog", "bord").Replace("news", "bord");
                                        //animation_day_slide(cur_bord, Convert.ToInt32(cur_text.Name.Substring(4, cur_text.Name.IndexOf("_") - 4)));
                                    }
                                }
                            }
                            if (cur_bord.Name.Left(10) == "headerbord")
                            {
                                //  day_num2 = Convert.ToInt32(cur_bord.Name.Substring(10, 1));
                                day_num2 = Convert.ToInt32(cur_bord.Name.Replace("headerbord", ""));
                                if (day_num2 > day_num)
                                {
                                    //string new_name = cur_bord.Name.Left(10) + (Convert.ToInt32(cur_bord.Name.Substring(10, 1)) - 1).ToString();
                                    string new_name = "headerbord" + (Convert.ToInt32(cur_bord.Name.Replace("headerbord", "")) - 1).ToString();
                                    // cur_bord.Name = cur_bord.Name.Replace(cur_bord.Name.Left(11), new_name);
                                    cur_bord.Name = new_name;
                                    cur_text = (TextBlock)cur_bord.Child;
                                    cur_text.Name = cur_bord.Name.Replace("headerbord", "headertext");
                                    //animation_day_slide(cur_bord, Convert.ToInt32(cur_bord.Name.Replace("headerbord", "")));
                                    //cur_text.Text = cur_bord.Name;
                                }

                            }
                            if (cur_bord.Name.Left(7) == "sh_bord")
                            {
                                //  day_num2 = Convert.ToInt32(cur_bord.Name.Substring(10, 1));
                                day_num2 = Convert.ToInt32(cur_bord.Name.Replace("sh_bord", ""));
                                if (day_num2 > day_num)
                                {
                                    //string new_name = cur_bord.Name.Left(10) + (Convert.ToInt32(cur_bord.Name.Substring(10, 1)) - 1).ToString();
                                    string new_name = "sh_bord" + (Convert.ToInt32(cur_bord.Name.Replace("sh_bord", "")) - 1).ToString();                                    
                                    cur_bord.Name = new_name;
                                    cur_text = (TextBlock)cur_bord.Child;
                                    cur_text.Name = cur_bord.Name.Replace("sh_bord", "ch_text");
                                    //animation_day_slide(cur_bord, Convert.ToInt32(cur_bord.Name.Replace("sh_bord", "")));
                                    //cur_text.Text = cur_bord.Name;
                                }
                                if (day_num2 == day_num)
                                {
                                    shapka_bord = cur_bord;
                                    //animation_opacity(cur_bord, 1);
                                }

                            }
                        }
                        if (child.GetType() == typeof(Rectangle))
                        {
                            Rectangle cur_rect = new Rectangle();
                            cur_rect = (Rectangle)child;
                            if (cur_rect.Name.Length > 3)
                            {
                                if (cur_rect.Name.Left(3) == "day")
                                {
                                    //  day_num2 = Convert.ToInt32(cur_rect.Name.Substring(3, 1))-1;
                                    day_num2 = Convert.ToInt32(cur_rect.Name.Replace("day", "")) - 1;
                                    //MessageBox.Show(cur_rect.Name+'\n'+day_num2.ToString());
                                    if (day_num == day_num2)
                                    {
                                        progs2remove.Add(child);
                                    }
                                    if (day_num2 > day_num)
                                    {
                                        cur_rect.Name = "day" + day_num2.ToString();
                                        //animation_day_slide(cur_rect, day_num2-1);
                                        //animation_day_slide(right_grid, day_num2);
                                        foreach (Label l in right_labels)
                                        {
                                            //animation_day_slide(l, day_num2);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    foreach (UIElement tb2r in progs2remove)
                    {
                        //Border cur_bord = new Border();
                        //cur_bord = (Border)tb2r.Parent;
                        //canvasArea.Children.Remove(cur_bord);
                        canvasArea.Children.Remove(tb2r);
                    }

                    Border header_bord = new Border();
                    header_bord = (Border)tb.Parent;

                    all_the_days.Remove((TextBlock)shapka_bord.Child);

                    canvasArea.Children.Remove(header_bord);
                    canvasArea.Children.Remove(shapka_bord);
                    
                    zoom_slider.Value += 0.01;
                    zoom_slider.Value -= 0.01;

                    Debug.WriteLine("Осталось дней: " + days_count.ToString());
                    
                }
            }
        }

        private int next_variant(DateTime date, int channel)
        {
            int variant = 2;
            try
            {
                TVDayVariantType[] variants = wc.GetDayVariants(date, 10);
                variant = variants.Length + 1;
            }
            catch
            { }

            return variant;
        }

        private void animation_day_slide(Object sender, int day_num)
        {
            DoubleAnimation da = new DoubleAnimation();
            UIElement cur_element = (UIElement)sender;

            //Canvas.GetLeft(cur_element);
            if (Canvas.GetLeft(cur_element) - (20 + day_num * 159 * zoom_coef) == 0)
            {
                da.From = 20 + (day_num - 1) * 159 * zoom_coef;
            }
            else
            {
                da.From = Canvas.GetLeft(cur_element);
            }
            da.To = 20 + day_num * 159 * zoom_coef;
            da.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            cur_element.BeginAnimation(Canvas.LeftProperty, da);
        }

        private void animation_opacity(Object sender, double from)
        {
            DoubleAnimation da = new DoubleAnimation();
            UIElement cur_element = (UIElement)sender;
            /*
            da.From = cur_element.Opacity;
            
            if (cur_element.Opacity==0)
            {
                da.To = 1;
            }
            else
            {
                da.To = 0;
            }
            */
            da.From = from;
            da.To = 1-from;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            cur_element.BeginAnimation(OpacityProperty, da);
        }



        private void right_shift_days(EventArgs e)
        {
            if (selected_days.Count > 0)
            {
                foreach (TextBlock tb in selected_days)
                {

                    int day_num = Convert.ToInt32(tb.Name.Replace("headertext", ""));


                    foreach (UIElement child in canvasArea.Children)
                    {
                        int day_num2 = 0;
                        if (child.GetType() == typeof(Border))
                        {
                            Border cur_bord = new Border();
                            TextBlock cur_text = new TextBlock();
                            cur_bord = (Border)child;
                            cur_text = (TextBlock)cur_bord.Child;

                            if (cur_text.Name.Length >= 4)
                            {
                                if (cur_text.Name.Left(4) == "prog" || cur_text.Name.Left(4) == "news")
                                {
                                    day_num2 = Convert.ToInt32(cur_text.Name.Substring(4, cur_text.Name.IndexOf("_") - 4));
                                    if (day_num2 > day_num)
                                    {
                                        string new_name = cur_text.Name.Left(4) + (Convert.ToInt32(cur_text.Name.Substring(4, cur_text.Name.IndexOf("_") - 4)) + 1).ToString();
                                        cur_text.Name = cur_text.Name.Replace(cur_text.Name.Left(cur_text.Name.IndexOf("_")), new_name);
                                        //cur_text.Name = new_name;
                                        cur_bord.Name = cur_text.Name.Replace("prog", "bord").Replace("news", "bord");
                                        //animation_day_slide(cur_bord, Convert.ToInt32(cur_text.Name.Substring(4, cur_text.Name.IndexOf("_") - 4)));
                                    }
                                }
                            }
                            if (cur_bord.Name.Left(10) == "headerbord")
                            {
                                day_num2 = Convert.ToInt32(cur_bord.Name.Substring(10, cur_bord.Name.Length - 10));
                                if (day_num2 > day_num)
                                {

                                    string new_name = cur_bord.Name.Left(10) + (Convert.ToInt32(cur_bord.Name.Substring(10, cur_bord.Name.Length - 10)) + 1).ToString();
                                    cur_bord.Name = cur_bord.Name.Replace(cur_bord.Name.Left(cur_bord.Name.Length), new_name);
                                    //cur_bord.Name = new_name;
                                    cur_text = (TextBlock)cur_bord.Child;
                                    cur_text.Name = cur_bord.Name.Replace("headerbord", "headertext");
                                    //animation_day_slide(cur_bord, Convert.ToInt32(cur_bord.Name.Substring(10, cur_bord.Name.Length - 10)));
                                }

                            }
                            if (cur_bord.Name.Left(7) == "sh_bord")
                            {
                                day_num2 = Convert.ToInt32(cur_bord.Name.Substring(7, cur_bord.Name.Length - 7));
                                if (day_num2 > day_num)
                                {

                                    string new_name = cur_bord.Name.Left(7) + (Convert.ToInt32(cur_bord.Name.Substring(7, cur_bord.Name.Length - 7)) + 1).ToString();
                                    cur_bord.Name = cur_bord.Name.Replace(cur_bord.Name.Left(cur_bord.Name.Length), new_name);
                                    //cur_bord.Name = new_name;
                                    cur_text = (TextBlock)cur_bord.Child;
                                    cur_text.Name = cur_bord.Name.Replace("sh_bord", "sh_text");
                                    //animation_day_slide(cur_bord, Convert.ToInt32(cur_bord.Name.Substring(7, cur_bord.Name.Length - 7)));
                                }

                            }
                        }
                        if (child.GetType() == typeof(Rectangle))
                        {
                            Rectangle cur_rect = new Rectangle();
                            cur_rect = (Rectangle)child;
                            if (cur_rect.Name.Length > 3)
                            {
                                if (cur_rect.Name.Left(3) == "day")
                                {
                                    day_num2 = Convert.ToInt32(cur_rect.Name.Substring(3, cur_rect.Name.Length - 3)) - 1;
                                    if (day_num2 > day_num)
                                    {
                                        cur_rect.Name = "day" + (day_num2 + 2).ToString();
                                        //animation_day_slide(cur_rect, day_num2+1);
                                        //animation_day_slide(right_grid, day_num2 + 2);
                                        foreach (Label l in right_labels)
                                        {
                                            //animation_day_slide(l, day_num2+2);
                                        }
                                    }
                                }
                            }
                        }
                    }




                    break;
                }
            }
            zoom_slider.Value += 0.01;
            zoom_slider.Value -= 0.01;
        }



        private void copy_day_Click(object sender, RoutedEventArgs e)
        {
            List<Tuple<string, int, bool, string>> progs2create = new List<Tuple<string, int, bool, string>>();

            if (selected_days.Count > 0)
            {
                foreach (TextBlock tb in selected_days)
                {

                    int day_num = Convert.ToInt32(tb.Name.Replace("headertext", ""));
                    TextBlock shapka_text = new TextBlock();


                    //Стало тут
                    string[] tb_name = tb.Text.Split('\n');

                    CultureInfo russian = new CultureInfo("ru-RU");
                    DateTime date_var = DateTime.Parse(tb_name[1]);
                    string dayName = date_var.ToString("dddd", russian);
                    dayName = dayName.Substring(0, 1).ToUpper() + dayName.Substring(1, dayName.Length - 1) +
                             '\n' + date_var.ToString("dd/MM/yyyy");


                    //Пока варианты берутся только для Первого канала
                    int variant = next_variant(date_var, 10);
                    right_shift_days(e);
                    create_day(dayName, day_num+1, variant);

                    foreach (UIElement child in canvasArea.Children)
                    {
                        int day_num2 = 0;
                        if (child.GetType() == typeof(Border))
                        {
                            Border cur_bord = new Border();
                            TextBlock cur_text = new TextBlock();
                            cur_bord = (Border)child;
                            cur_text = (TextBlock)cur_bord.Child;
                            /*
                            if (cur_text.Name.Length >= 4)
                            {
                                if (cur_text.Name.Left(4) == "prog" || cur_text.Name.Left(4) == "news")
                                {
                                    day_num2 = Convert.ToInt32(cur_text.Name.Substring(4, cur_text.Name.IndexOf("_") - 4));                                    
                                    if (day_num2 > day_num)
                                    {
                                        string new_name = cur_text.Name.Left(4) + (Convert.ToInt32(cur_text.Name.Substring(4, cur_text.Name.IndexOf("_") - 4)) + 1).ToString();
                                        cur_text.Name = cur_text.Name.Replace(cur_text.Name.Left(cur_text.Name.IndexOf("_")), new_name);                                        
                                        //cur_text.Name = new_name;
                                        cur_bord.Name = cur_text.Name.Replace("prog", "bord").Replace("news", "bord");
                                    }
                                }
                            }
                           
                            if (cur_bord.Name.Left(10) == "headerbord")
                            {
                                day_num2 = Convert.ToInt32(cur_bord.Name.Substring(10, cur_bord.Name.Length-10));
                                if (day_num2 > day_num)
                                {
                                    
                                    string new_name = cur_bord.Name.Left(10) + (Convert.ToInt32(cur_bord.Name.Substring(10, cur_bord.Name.Length-10)) + 1).ToString();
                                    cur_bord.Name = cur_bord.Name.Replace(cur_bord.Name.Left(cur_bord.Name.Length), new_name);
                                    //cur_bord.Name = new_name;
                                    cur_text = (TextBlock)cur_bord.Child;
                                    cur_text.Name = cur_bord.Name.Replace("headerbord", "headertext");                                 
                                }

                            }
                            if (cur_bord.Name.Left(7) == "sh_bord")
                            {
                                day_num2 = Convert.ToInt32(cur_bord.Name.Substring(7, cur_bord.Name.Length - 7));
                                if (day_num == day_num2) shapka_text = cur_text;

                                if (day_num2 > day_num)
                                {

                                    string new_name = cur_bord.Name.Left(7) + (Convert.ToInt32(cur_bord.Name.Substring(7, cur_bord.Name.Length - 7)) + 1).ToString();
                                    cur_bord.Name = cur_bord.Name.Replace(cur_bord.Name.Left(cur_bord.Name.Length), new_name);
                                    //cur_bord.Name = new_name;
                                    cur_text = (TextBlock)cur_bord.Child;
                                    cur_text.Name = cur_bord.Name.Replace("sh_bord", "sh_text");
                                    //animation_day_slide(cur_bord, Convert.ToInt32(cur_bord.Name.Substring(7, cur_bord.Name.Length - 7)));
                                }

                            }
                            */ 
                        }
                        /*
                        if (child.GetType() == typeof(Rectangle))
                        {
                            Rectangle cur_rect = new Rectangle();
                            cur_rect = (Rectangle)child;
                            if (cur_rect.Name.Length > 3)
                            {
                                if (cur_rect.Name.Left(3) == "day")
                                {
                                    day_num2 = Convert.ToInt32(cur_rect.Name.Substring(3, cur_rect.Name.Length-3)) - 1;
                                    if (day_num2 > day_num)
                                    {
                                        cur_rect.Name = "day" + (day_num2+2).ToString();
                                    }
                                }
                            }
                        }
                         */ 
                    }









                    //Было тут
                    /*
                    string[] tb_name = tb.Text.Split('\n');

                    CultureInfo russian = new CultureInfo("ru-RU");
                    DateTime date_var = DateTime.Parse(tb_name[1]);
                    string dayName = date_var.ToString("dddd", russian);
                    dayName = dayName.Substring(0, 1).ToUpper() + dayName.Substring(1, dayName.Length - 1) +
                             '\n' + date_var.ToString("dd/MM/yyyy");


                    //Пока варианты берутся только для Первого канала
                    int variant = next_variant(date_var,10);


                    
                    create_day(dayName, day_num + 1, variant);
                    */


                    foreach (UIElement child in canvasArea.Children)
                    {
                        int day_num2 = 0;
                        if (child.GetType() == typeof(Border))
                        {
                            Border cur_bord = new Border();
                            TextBlock cur_text = new TextBlock();
                            cur_bord = (Border)child;
                            cur_text = (TextBlock)cur_bord.Child;

                            if (cur_text.Name.Length >= 4)
                            {
                                if (cur_text.Name.Left(4) == "prog" || cur_text.Name.Left(4) == "news")
                                {
                                    day_num2 = Convert.ToInt32(cur_text.Name.Substring(4, cur_text.Name.IndexOf("_") - 4));
                                    string doc_num = cur_text.Tag.ToString();
                                    if (day_num2 == day_num)
                                    {
                                        //Определяем, что рисовать внизу раскладки
                                        bool reserv = false;
                                        if (cur_text.Text.deconstruct().Item2.time_to_minutes()<=10*60 && Canvas.GetTop(cur_bord)>15*60*zoom_coef)
                                        {
                                            reserv=true;
                                        }

                                        progs2create.Add(Tuple.Create(cur_text.Text, day_num+1,reserv,doc_num));
                                        
                                        
                                        //create_prog(cur_text.Text.full_title(), day_num, Canvas.GetTop(cur_bord) / zoom_coef, dur.time_to_minutes(),r, t_t,a,"000000");
                                        
                                    }
                                }
                                
                            }
                        }
                    }
                    foreach (Tuple<string,int,bool,string> t in progs2create)
                    {
                        string title = t.Item1.deconstruct().Item1;
                        if (title.Right(1) == "\n")
                        {
                            title = title.Substring(0, title.Length - 1);
                        }
                        int d_num = t.Item2;
                        double b_time = t.Item1.deconstruct().Item2.time_to_minutes();
                        if (t.Item3 == true) b_time +=24*60;
                        double timing = t.Item1.deconstruct().Item3.time_to_minutes();                        
                        double rec= t.Item1.deconstruct().Item4.time_to_minutes();
                        int tochki = Convert.ToInt32(t.Item1.deconstruct().Item5);
                        double anons = t.Item1.deconstruct().Item6.time_to_minutes();
                        string code = t.Item1.deconstruct().Item7;
                        
                        create_prog(title,d_num,b_time,timing,rec,tochki,anons,code,t.Item4, 0);
                    }

                    zoom_slider.Value += 0.01;
                    zoom_slider.Value -= 0.01;
                }
            }
        }

        private void save_day_Click(object sender, RoutedEventArgs e)
        {
            bool var_exists = false;
            string cur_dayRef;

            if (selected_days.Count > 0)
            {
                foreach (TextBlock tb in selected_days)
                {
                    int day_num = Convert.ToInt32(tb.Name.Replace("headertext", ""));
                    int variant = 0;
                    if (tb.Text.IndexOf(" ") >= 0)
                    {

                        //MessageBox.Show(tb.Text.Substring(tb.Text.LastIndexOf(" ")+1, 1));
                        variant = Convert.ToInt32(tb.Text.Substring(tb.Text.LastIndexOf(" ")+1, 1));
                    }
                    else
                    {
                        variant = 1;
                    }

                    
                    //days_to_check.Add(tb);

                    

                    string[] tb_name = tb.Text.Split('\n');

                    CultureInfo russian = new CultureInfo("ru-RU");
                    DateTime date_var = DateTime.Parse(tb_name[1]);

                    //Тоже только Первый
                    TVDayVariantType[] variants = wc.GetDayVariants(date_var, 10);
                    if (variant<=variants.Length)
                    {
                        //MessageBox.Show("Такой вариант дня уже есть!");                        
                        //break;

                        if (MessageBox.Show("Такой вариант дня уже есть!\nИзменить его?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                        {


                            break;
                        }
                        else
                        {
                            //do yes stuff
                            
                            //update_efir(prog_text);

                            var_exists = true;                            

                           // MessageBox.Show("Конец");

                        }

                    }
                    

                    if (var_exists==true)
                    {


                        TVDayVariantParam vpar = wc.GetVarTVDayParam(date_var, 10, variant);
                        cur_dayRef = vpar.TVDayRef;

                        //cur_dayRef = tb.Tag.ToString();



                    }
                    else
                    {
                        cur_dayRef = wc.AddTVDay(date_var, 10, variant, variant, null);
                    }
                    
                    DateTime dt_time = DateTime.Parse("01.01.2000");


                    foreach (UIElement child in canvasArea.Children)
                    {
                        int day_num2 = 0;
                        if (child.GetType() == typeof(Border))
                        {
                            Border cur_bord = new Border();
                            TextBlock cur_text = new TextBlock();
                            cur_bord = (Border)child;
                            cur_text = (TextBlock)cur_bord.Child;

                            if (cur_text.Name.Length >= 4)
                            {
                                if (cur_text.Name.Left(4) == "prog" || cur_text.Name.Left(4) == "news")
                                {
                                    day_num2 = Convert.ToInt32(cur_text.Name.Substring(4, cur_text.Name.IndexOf("_") - 4));
                                    if (day_num2 == day_num)
                                    {

                                        string title = cur_text.Text.deconstruct().Item1;
                                        //if (title.Right(1) == "\n")
                                        //{
                                        //    title = title.Substring(0, title.Length - 1);
                                        //}
                                        string ANR = title.Replace("\n", "#");
                                        

                                        double b_time = cur_text.Text.deconstruct().Item2.time_to_minutes();
                                        if (cur_text.Text.deconstruct().Item2.time_to_minutes() <= 10 * 60 && Canvas.GetTop(cur_bord) > 15 * 60 * zoom_coef)
                                        {                                            
                                            dt_time = DateTime.Parse(tb_name[1]+" "+cur_text.Text.deconstruct().Item2).AddDays(1);                                            
                                        }
                                        else
                                        {
                                            dt_time = DateTime.Parse(tb_name[1] + " " + cur_text.Text.deconstruct().Item2);                                            
                                        }


                 
                                        double timing = cur_text.Text.deconstruct().Item3.time_to_minutes();
                                        double rec = cur_text.Text.deconstruct().Item4.time_to_minutes();
                                        int tochki = Convert.ToInt32(cur_text.Text.deconstruct().Item5);
                                        double anons = cur_text.Text.deconstruct().Item6.time_to_minutes();
                                        string code = cur_text.Text.deconstruct().Item7;


                                        EfirType ef = new EfirType();
                                        ef.Variant = new VarType();

                                        ITCType itc_rec = new ITCType();
                                        itc_rec.Title = "Р";
                                        itc_rec.Timing=Convert.ToInt32(rec*60);
                                        itc_rec.PointCount= tochki;
                                        itc_rec.CapTiming = 0;

                                        ITCType itc_anons = new ITCType();
                                        itc_anons.Title = "А";
                                        itc_anons.Timing=Convert.ToInt32(anons*60);
                                        itc_anons.PointCount= tochki;
                                        itc_anons.CapTiming = 0;

                                        ITCType[] ra = new ITCType[2] {itc_rec,itc_anons};
                                        

                                        //ra[0]=itc_rec;
                                        //ra[1]=itc_anons;
                                        

                                        ef.Variant.TVData = date_var;
                                        ef.Variant.ChannelCode = 10;
                                        ef.Variant.VariantCode = variant; //!!!
                                        ef.Mask = variant;
                                        ef.Beg = dt_time;
                                        ef.Timing = Convert.ToInt32(timing*60+rec*60+anons*60);
                                        ef.Title = title;
                                        ef.ANR = ANR;
                                        ef.ProducerCode = code.Left(2);
                                        ef.SellerCode = code.Right(3);
                                        ef.ITC = ra;
                                        ef.TVDayRef = cur_dayRef;

                                        if (var_exists==true)
                                        {
                                            //Нужно добавить проверку на лишние/недостающие эфиры
                                            update_efir(cur_text);
                                            
                                        }
                                        else
                                        {
                                            wc.AddEfir(ef);
                                        }
                                        

                                    }
                                }
                            }
                        }
                    }


                    //TVDay tvd = ;
                    /*
                    ef.TVDayRef = tc.TVDayRef;
                    ef.Variant.ChannelCode = tc.channel_code;
                    ef.Variant.TVData = tc.tvdate;
                    ef.Variant.VariantCode = tc.variant_code;
                    ef.Mask = tc.mask;
                    ef.Beg = tc.dtbeg;
                    ef.Timing = tc.chron;
                    ef.Title = tc.nazv;
                    ef.ProducerCode = tc.ProducerCode;
                    ef.SellerCode = tc.SellerCode;
                    ef.ITC = tc.reklama;
                    src_1c.AddEfir(ef);
                     * 
                     * 
                     * 
                     * 
                     * 
                      aTC[i] = new EfirType();
                aTC[i].Variant = new VarType();
                aTC[i].Variant.TVData = tele.Variant.TVData;
                aTC[i].Variant.ChannelCode = tele.Variant.ChannelCode;
                aTC[i].Variant.VariantCode = tele.Variant.VariantCode;
                aTC[i].Mask = tele.Mask;
                aTC[i].Title = tele.Title;
                aTC[i].TVDayRef = tele.TVDayRef;

                aTC[i].Timing = (int)(news[i].Beg - tele.Beg).TotalSeconds;
                aTC[i + 1].Beg = news[i].Beg.AddSeconds(news[i].Timing);
                    */
                    break;
                }
            }



        }


        private void delete_prog_button_Click(object sender, RoutedEventArgs e)
        {
            if (selected_progs.Count() == 1)
            {
                TextBlock prog_text = selected_progs[0];
                Border cur_bord = (Border)prog_text.Parent;
                canvasArea.Children.Remove(cur_bord);
                Flyout_bottom.IsOpen = false;
            }
            if (selected_progs.Count() == 2)
            {
                TextBlock prog_text = selected_progs[0];
                Border cur_bord = (Border)prog_text.Parent;
                canvasArea.Children.Remove(cur_bord);
                
                TextBlock prog_text2 = selected_progs[1];
                Border cur_bord2 = (Border)prog_text2.Parent;
                canvasArea.Children.Remove(cur_bord2);
                Flyout_bottom.IsOpen = false;
            }

        }

        private void main_window_StylusDown(object sender, StylusDownEventArgs e)
        {

      //      Canvas.SetZIndex(inkcanvas1, 10000);

            //  StylusPointCollection points=new StylusPointCollection();
            //   Debug.WriteLine("***");
            //   System.Windows.Input.StylusPointCollection pp = e.StylusDevice.GetStylusPoints(main_window);

            //TouchPoint tp = e.StylusDevice.GetStylusPoints(main_window)[0];

            //Debug.WriteLine(tp.Size.ToString());
        }

        private void main_window_StylusUp(object sender, StylusEventArgs e)
        {

        }

        private void main_window_StylusEnter(object sender, StylusEventArgs e)
        {
            Debug.WriteLine("enter");

          
           // inkcanvas1.IsHitTestVisible = true;
            visible_canvas.IsHitTestVisible = true;

        }

        private void main_window_StylusLeave(object sender, StylusEventArgs e)
        {
            Debug.WriteLine("leave");
        
            //inkcanvas1.IsHitTestVisible = false;
            visible_canvas.IsHitTestVisible = false;
            //strokes_num = inkcanvas1.Strokes.Count();
            strokes_num = visible_canvas.Strokes.Count();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (zoom_slider.Visibility == Visibility.Hidden)
            {
                zoom_slider.Width = 161;
                zoom_slider.Visibility = Visibility.Visible;
            }
            else
            {
                zoom_slider.Width = 1;
                zoom_slider.Visibility = Visibility.Hidden;
            }

        }

        private void roundbutton_Click(object sender, RoutedEventArgs e)
        {
            Button cur_button = (Button)sender;
            Label cur_label = (Label)cur_button.Content;
            cur_label.Content = (Convert.ToDouble(cur_label.Content) + 1).ToString();
            update_prog(sender, e);
        }

        private void cut_strokes(double left, double top, double width, double height)
        {

            Rect re = new Rect(left, top, width, height);

            //IEnumerable<StrokeCollection> x = inkcanvas1.Strokes.Select(s => s.GetClipResult(re));
            /*
            StrokeCollection strokes = new StrokeCollection(inkcanvas1.Strokes.SelectMany(s => s.GetClipResult(re)));
            inkcanvas1.Select(strokes);
            */
            StrokeCollection strokes = new StrokeCollection(visible_canvas.Strokes.SelectMany(s => s.GetClipResult(re)));
            visible_canvas.Select(strokes);
            
        }

        private void cut_prog_button_Click(object sender, RoutedEventArgs e)
        {
            if (selected_progs.Count() == 1)
            {
                TextBlock prog_text = selected_progs[0];
                Border cur_bord = (Border)prog_text.Parent;
                canvasArea.Children.Remove(cur_bord);
                second_sp.Children.Add(cur_bord);
                prog_text.Foreground = Brushes.Black;
                prog_text.Name = prog_text.Name.Replace(prog_text.Name.Left(4), "ptemp");
                Flyout_bottom.IsOpen = false;
                Flyout_left.IsOpen = true;

                
                
            }
        }

        private void copy_prog_button_Click(object sender, RoutedEventArgs e)
        {
            if (selected_progs.Count() == 1)
            {
                
                TextBlock prog_text = selected_progs[0];
                Border cur_bord = (Border)prog_text.Parent;
                //canvasArea.Children.Remove(cur_bord);
                string saved_bord = XamlWriter.Save(cur_bord);
                StringReader stringReader = new StringReader(saved_bord);
                Border new_bord = (Border)XamlReader.Parse(saved_bord);
                second_sp.Children.Add(new_bord);
                TextBlock new_text = (TextBlock)new_bord.Child;

                
                new_text.MouseLeftButtonDown += rect_MouseLeftButtonDown;
                new_text.MouseMove += rect_MouseMove;
                new_text.MouseLeftButtonUp += rect_MouseLeftButtonUp;


                new_text.Foreground = Brushes.Black;
                
                
                if (prog_text.Name.Left(4) == "prog") new_text.Name = new_text.Name.Replace(new_text.Name.Left(4), "ptemp");                    
                if (prog_text.Name.Left(4) == "news") new_text.Name = new_text.Name.Replace(new_text.Name.Left(4), "ntemp");
                shape_count += 1;
                new_text.Name = new_text.Name.Substring(0, new_text.Name.IndexOf("_")+1) + shape_count.ToString();
                

                Flyout_bottom.IsOpen = false;
                Flyout_left.IsOpen = true;
            }
        }

        private void ads_calc_Click(object sender, RoutedEventArgs e)
        {
            Label hours_label = (Label)duration_hours.Content;
            Label minutes_label = (Label)duration_minutes.Content;
            Label r_label = (Label)r.Content;
            Label t_label = (Label)t.Content;
            Label a_label = (Label)a.Content;
            
            string timing_str = hours_label.Content.ToString() + ":" + minutes_label.Content.ToString();
            //MessageBox.Show(timing_str);
            double a1;
            double r1;
            double t1;
            r1 = timing_str.ads_int_new().Item1;
            t1 = timing_str.ads_int_new().Item2;
            a1 = timing_str.ads_int_new().Item3;

            r_label.Content = r1.ToString();
            t_label.Content = t1.ToString();
            a_label.Content = a1.ToString();
            update_prog(sender, e);
            
        }



        

        private void split_prog(TextBlock prog_text, EventArgs e)
        {

            //TextBlock prog_text = (TextBlock)sender;
            Border prog_bord = (Border)prog_text.Parent;

            int day_num = prog_text.Name.get_day();
            string total_dur_str;
            

            if (prog_text.Name.Right(2).Left(1)=="d")
            {
                
            }


            if (prog_text.Name.Right(2).Left(1) == "s" && prog_text.Name.Left(4) != "news")
            {
                foreach (UIElement child in canvasArea.Children)
                {
                    int day_num2 = 0;
                    if (child.GetType() == typeof(Border))
                    {
                        Border cur_bord = new Border();
                        TextBlock cur_text = new TextBlock();
                        cur_bord = (Border)child;
                        cur_text = (TextBlock)cur_bord.Child;

                        if (cur_text.Name.Length >= 4)
                        {
                            if (cur_text.Name.Left(4) == "news")
                            {
                                day_num2 = cur_text.Name.get_day();
                                if (day_num == day_num2)
                                {
                                    //Если залезли снизу
                                    if (Canvas.GetTop(prog_bord) <= Canvas.GetTop(cur_bord)+cur_bord.Height - 10 && Canvas.GetTop(prog_bord) >= Canvas.GetTop(cur_bord))

                                    {
                                        double margin = Canvas.GetTop(cur_bord) + cur_bord.Height - Canvas.GetTop(prog_bord); //На сколько минут залезли на новости

                                         total_dur_str ="[" + prog_text.Text.deconstruct().Item3 + "]";
                                         prog_text.Text = prog_text.Text.Replace(prog_text.Text.deconstruct().Item1, prog_text.Text.deconstruct().Item1 + "ПРОДОЛЖЕНИЕ"+"\n");
                                        //Переименовали новости и программу
                                        cur_text.Name = cur_text.Name.Left(cur_text.Name.Length - 2) + "n1";
                                        prog_text.Name = prog_text.Name.Left(prog_text.Name.Length - 2) + "d2";

                                        


                                        string timestart1 = (cur_text.Text.deconstruct().Item2.time_to_minutes() + cur_bord.Height).minutes_to_time();
                                        string duration1 = (prog_text.Text.deconstruct().Item3.time_to_minutes() - margin).minutes_to_time();
                                        string r_str1 = duration1.ads_int().Item1.ToString();
                                        string t_str1 = duration1.ads_int().Item2.ToString();
                                        string a_str1 = duration1.ads_int().Item3.ToString();

                                        update_duration_time_text(prog_text, timestart1, duration1, r_str1, a_str1, t_str1);


                                        //Создали новый кусок

                                        Label hours_label = (Label)duration_hours.Content;
                                        Label minutes_label = (Label)duration_minutes.Content;


                                        string duration2 = (Convert.ToDouble(hours_label.Content.ToString()) * 60 + Convert.ToDouble(minutes_label.Content.ToString()) - prog_text.Text.deconstruct().Item3.time_to_minutes()).minutes_to_time(); //Пока берем снизу

                                        string r_str2 = duration2.ads_int().Item1.ToString();
                                        string t_str2 = duration2.ads_int().Item2.ToString();
                                        string a_str2 = duration2.ads_int().Item3.ToString();
                                        string title="";

                                        title = prog_text.Text.deconstruct().Item1.Replace("ПРОДОЛЖЕНИЕ"+'\n',"") + total_dur_str;
                                        
                                        
                                        
                                        
                                        double full_timing2 = duration2.time_to_minutes() + Convert.ToDouble(r_str2) + Convert.ToDouble(a_str2);
                                        double timestart2 = cur_text.Text.deconstruct().Item2.time_to_minutes() - full_timing2;
                                        TextBlock prog_text2 = create_prog(title, day_num, timestart2, duration2.time_to_minutes(), Convert.ToDouble(r_str2), Convert.ToInt32(t_str2), Convert.ToDouble(a_str2), prog_text.Text.deconstruct().Item7,null, 0);
                                        prog_text2.Name = prog_text2.Name.Left(prog_text2.Name.Length - 2) + "d1";
                                        select_parts(prog_text,e);
                                        foreach (TextBlock tb in selected_progs)
                                        {                                         
                                            Border cur_bord2 = (Border)tb.Parent;
                                            cur_bord2.BorderBrush = Brushes.CornflowerBlue;
                                            cur_bord2.BorderThickness = new Thickness(3);
                                        }
                                        new_double_click(prog_text, e);




                                        break;



                                    }

                                    //Если залезли сверху
                                    if (Canvas.GetTop(prog_bord) + prog_bord.Height >= Canvas.GetTop(cur_bord) + 10 && Canvas.GetTop(prog_bord) + prog_bord.Height <= Canvas.GetTop(cur_bord) + cur_bord.Height)
                                    {
                                        double margin = 10; //На сколько минут залезли на новости
                                     

                                        total_dur_str = "[" + prog_text.Text.deconstruct().Item3 + "]";

                                        string title = prog_text.Text.deconstruct().Item1;
                                        prog_text.Text = prog_text.Text.Replace(title, title+total_dur_str+'\n');

                                        //Переименовали новости и программу
                                        cur_text.Name = cur_text.Name.Left(cur_text.Name.Length - 2) + "n1";
                                        prog_text.Name = prog_text.Name.Left(prog_text.Name.Length - 2) + "d1";

                                        string duration1 = (prog_text.Text.deconstruct().Item3.time_to_minutes() - margin).minutes_to_time();
                                        string r_str1 = duration1.ads_int().Item1.ToString();
                                        string t_str1 = duration1.ads_int().Item2.ToString();
                                        string a_str1 = duration1.ads_int().Item3.ToString();
                                        string timestart1 = (cur_text.Text.deconstruct().Item2.time_to_minutes() - duration1.time_to_minutes() - Convert.ToDouble(r_str1) - Convert.ToDouble(a_str1)).minutes_to_time();

                                        update_duration_time_text(prog_text, timestart1, duration1, r_str1, a_str1, t_str1);

                                        //Создали новый кусок
                                        string duration2 = margin.minutes_to_time(); //Пока берем снизу

                                        string r_str2 = duration2.ads_int().Item1.ToString();
                                        string t_str2 = duration2.ads_int().Item2.ToString();
                                        string a_str2 = duration2.ads_int().Item3.ToString();

                                        double full_timing2 = duration2.time_to_minutes() + Convert.ToDouble(r_str2) + Convert.ToDouble(a_str2);
                                        double timestart2 = cur_text.Text.deconstruct().Item2.time_to_minutes()+cur_text.Text.deconstruct().Item3.time_to_minutes()+cur_text.Text.deconstruct().Item4.time_to_minutes()+cur_text.Text.deconstruct().Item6.time_to_minutes();


                                        

                                        TextBlock prog_text2 = create_prog(title+"ПРОДОЛЖЕНИЕ", day_num, timestart2, duration2.time_to_minutes(), Convert.ToDouble(r_str2), Convert.ToInt32(t_str2), Convert.ToDouble(a_str2), prog_text.Text.deconstruct().Item7,null, 0);
                                        prog_text2.Name = prog_text2.Name.Left(prog_text2.Name.Length - 2) + "d2";
                                        select_parts(prog_text,e);
                                        foreach (TextBlock tb in selected_progs)
                                        {                                            
                                            Border cur_bord2 = (Border)tb.Parent;
                                            cur_bord2.BorderBrush = Brushes.CornflowerBlue;
                                            cur_bord2.BorderThickness = new Thickness(3);
                                        }
                                        new_double_click(prog_text, e);
                                        break;
                                        
                                    }


                                    

                                }
                            }
                        }
                    }
                }
            }

        }

        private void stack_button_Click(object sender, RoutedEventArgs e)
        {
            if (selected_progs.Count()<1)
            {
                return;
            }
            double direction=1;
            Button cur_button = (Button)sender;
            TextBlock prog_text = (TextBlock)selected_progs[0];
            Border prog_bord = (Border)prog_text.Parent;
            int day_num = prog_text.Name.get_day();


            if (cur_button.Name.Right(2)=="up")
            {
                direction = -1;
            }            

            if (selected_progs.Count()==1)
            {
                Border top_bord = new Border();
                Border bottom_bord = new Border();
                Canvas.SetTop(top_bord, 0);
                Canvas.SetTop(bottom_bord, 20000);
                foreach (UIElement child in canvasArea.Children)
                {
                    int day_num2 = 0;
                    if (child.GetType() == typeof(Border))
                    {
                        Border cur_bord = new Border();
                        TextBlock cur_text = new TextBlock();
                        cur_bord = (Border)child;
                        cur_text = (TextBlock)cur_bord.Child;

                        if (cur_text.Name.Length >= 4)
                        {
                            if (cur_text.Name != prog_text.Name &&(cur_text.Name.Left(4) == "news" || cur_text.Name.Left(4) == "prog"))
                            {
                                day_num2 = cur_text.Name.get_day();
                                if (day_num == day_num2)
                                {
                                    if (Canvas.GetTop(cur_bord) < Canvas.GetTop(prog_bord))
                                    {
                                        if (Canvas.GetTop(cur_bord) > Canvas.GetTop(top_bord))
                                        {                                            
                                            top_bord = cur_bord;
                                        }
                                    }
                                    if (Canvas.GetTop(cur_bord) > Canvas.GetTop(prog_bord))
                                    {
                                        if (Canvas.GetTop(cur_bord) < Canvas.GetTop(bottom_bord))
                                        {
                                            bottom_bord = cur_bord;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                /*
                TextBlock top_text = (TextBlock)top_bord.Child;
                TextBlock bottom_text = (TextBlock)bottom_bord.Child;
                MessageBox.Show(top_text.Text.deconstruct().Item1 + '\n' + bottom_text.Text.deconstruct().Item1);
                */
                if (direction==-1)
                {

                    Canvas.SetTop(prog_bord, Canvas.GetTop(top_bord) + top_bord.Height);
                }
                else
                {
  
                    Canvas.SetTop(prog_bord, Canvas.GetTop(bottom_bord) - prog_bord.Height);
                }
                //double time = 60 * 5 + (Canvas.GetTop(prog_bord) - top_shift * zoom_coef)*zoom_coef;
                double time = Math.Floor((Canvas.GetTop(prog_bord) - top_shift) / zoom_coef) + 300;
                
              //  MessageBox.Show(time.minutes_to_time());
                update_duration_time_text(prog_text, time.minutes_to_time(), prog_text.Text.deconstruct().Item3, prog_text.Text.deconstruct().Item4, prog_text.Text.deconstruct().Item6, prog_text.Text.deconstruct().Item5);
                new_double_click(prog_text, e);

            }


        }

        public Border get_topbotton_tb(TextBlock prog_text, int top=1)
        {
        
            Border prog_bord = (Border)prog_text.Parent;
            int day_num = prog_text.Name.get_day();
            Border top_bord = new Border();
            Border bottom_bord = new Border();
            Canvas.SetTop(top_bord, 0);
            Canvas.SetTop(bottom_bord, 20000);


            if (selected_progs.Count() == 1)
            {
                foreach (UIElement child in canvasArea.Children)
                {
                    int day_num2 = 0;
                    if (child.GetType() == typeof(Border))
                    {
                        Border cur_bord = new Border();
                        TextBlock cur_text = new TextBlock();
                        cur_bord = (Border)child;
                        cur_text = (TextBlock)cur_bord.Child;

                        if (cur_text.Name.Length >= 4)
                        {
                            if (cur_text.Name != prog_text.Name && (cur_text.Name.Left(4) == "news" || cur_text.Name.Left(4) == "prog"))
                            {
                                day_num2 = cur_text.Name.get_day();
                                if (day_num == day_num2)
                                {
                                    if (Canvas.GetTop(cur_bord) < Canvas.GetTop(prog_bord))
                                    {
                                        if (Canvas.GetTop(cur_bord) > Canvas.GetTop(top_bord))
                                        {
                                            top_bord = cur_bord;
                                        }
                                    }
                                    if (Canvas.GetTop(cur_bord) > Canvas.GetTop(prog_bord))
                                    {
                                        if (Canvas.GetTop(cur_bord) < Canvas.GetTop(bottom_bord))
                                        {
                                            bottom_bord = cur_bord;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
            if (top == 1)
            {
                return top_bord;
            }
            else
            {
                return bottom_bord;
            }
        }


        private void switch_button_Click(object sender, EventArgs e)
        {
            TextBlock prog_text = selected_progs[0];
            Border prog_bord = (Border)prog_text.Parent;
            Border top_bord = get_topbotton_tb(prog_text, 1);
            Border bottom_bord = get_topbotton_tb(prog_text,0);

            TextBlock top_text = (TextBlock)top_bord.Child;

            TextBlock bottom_text = (TextBlock)bottom_bord.Child;
            //MessageBox.Show(top_text.Text.deconstruct().Item1+'\n'+bottom_text.Text.deconstruct().Item1);
            //Меняем местами с нижней программой
            
            //учесть хрнмтрж

            Canvas.SetTop(bottom_bord, Canvas.GetTop(prog_bord));
            Canvas.SetTop(prog_bord, Canvas.GetTop(bottom_bord)+bottom_bord.Height);

            //double time = 60 * 5 + (Canvas.GetTop(prog_bord) - top_shift * zoom_coef) * zoom_coef;
            double time = Math.Floor((Canvas.GetTop(prog_bord) - top_shift) / zoom_coef) + 300;
            update_duration_time_text(prog_text, time.minutes_to_time(), prog_text.Text.deconstruct().Item3, prog_text.Text.deconstruct().Item4, prog_text.Text.deconstruct().Item6, prog_text.Text.deconstruct().Item5);


            //time = 60 * 5 + (Canvas.GetTop(bottom_bord) - top_shift * zoom_coef) * zoom_coef;
            time = Math.Floor((Canvas.GetTop(bottom_bord) - top_shift) / zoom_coef) + 300;
            update_duration_time_text(bottom_text, time.minutes_to_time(), bottom_text.Text.deconstruct().Item3, bottom_text.Text.deconstruct().Item4, bottom_text.Text.deconstruct().Item6, bottom_text.Text.deconstruct().Item5);
            new_double_click(bottom_text, e);
            new_double_click(prog_text, e);
        }

        public void font_test(TextBlock cur_text)
        {
            TextBox tb = new TextBox();
            tb.Loaded += tb_Loaded;
            tb.Height = cur_text.Height;
            tb.Width = cur_text.Width;
            Canvas.SetTop(tb, Canvas.GetTop(cur_text));
            Canvas.SetLeft(tb, Canvas.GetLeft(cur_text));
            //canvasArea.Children.Add(tb);
            tb.FontFamily = cur_text.FontFamily;
            tb.FontSize = cur_text.FontSize;
            //tb.Background = Brushes.Black;
            tb.TextWrapping = cur_text.TextWrapping;
            tb.Text = cur_text.Text;
            
            //MessageBox.Show(tb.IsLoaded.ToString());
            //MessageBox.Show("Lines: "+tb.LineCount.ToString());
           // canvasArea.Children.Remove(tb);

        }

        public void font_test2(TextBlock cur_text)
        {
            Border cur_bord = (Border)cur_text.Parent;
            if (cur_bord.Tag.ToString().Contains("$Ш"))
            {
                string cur_string = cur_bord.Tag.ToString().Replace("$X", "").Replace("$Х", "").Replace("$С", "").Replace("$C", "").Replace("$Ц", "");
                string cur_key = cur_string.Substring(cur_string.IndexOf("$"), 3);

                //От отчаяния введенный коэффициет размера шрифта
                double font_coef = forced_fontsize / 10;

                cur_text.FontSize = Math.Floor((Convert.ToDouble(cur_key.Right(1)) + 1)*font_coef + (zoom_coef - 1) * 4);
            }
            else
            {
                //cur_text.FontSize = Math.Floor(9 + (zoom_coef-1)*2.5);
                cur_text.FontSize = forced_fontsize;                
            }
            cur_text.LineHeight = cur_text.FontSize;
            

            //MessageBox.Show(tb.IsLoaded.ToString());
            //MessageBox.Show("Lines: "+tb.LineCount.ToString());
            // canvasArea.Children.Remove(tb);

        }

        //Какой-то кривой подход, но уж что есть
        void tb_Loaded(object sender, EventArgs e)
        {
            TextBox tbb = (TextBox)sender;
            TextBlock cur_text = new TextBlock();
            MessageBox.Show(tbb.LineCount.ToString());
            foreach (UIElement child in canvasArea.Children)
            {
                if (child.GetType() == typeof(Border))
                {
                    Border cur_bord = (Border)child;
                    cur_text = (TextBlock)cur_bord.Child;
                        if (Canvas.GetTop(tbb)==Canvas.GetTop(cur_text) && Canvas.GetLeft(tbb)==Canvas.GetLeft(cur_text))
                        {
                            MessageBox.Show(cur_text.Text+'\n'+tbb.LineCount.ToString());
                            break;
                        }
                }
            }
            



        }

        private void ch_MouseEnter(object sender, MouseEventArgs e)
        {
            Button cur_button = (Button)sender;
            if (cur_button.Opacity < 1)
            {
                cur_button.Opacity = 0.9;
            }
        }

        private void ch_MouseLeave(object sender, MouseEventArgs e)
        {
            Button cur_button = (Button)sender;
            if (cur_button.Opacity<1) cur_button.Opacity = 0.3;
        }



        private void ch_Click(object sender, RoutedEventArgs e)
        {
            Button cur_button = (Button)sender;
            int channel = 0;            
            TextBlock cur_header = selected_days[0];
            Border cur_header_bord = (Border)cur_header.Parent;
            string[] tb_name = cur_header.Text.Split('\n');
            CultureInfo russian = new CultureInfo("ru-RU");
            //DateTime date = DateTime.Parse(tb_name[1]);
            DateTime date = DateTime.Parse(cur_header_bord.ToolTip.ToString());

            if (DateTime.Parse(cur_header_bord.ToolTip.ToString()) != date)
            {
                date = DateTime.Parse(cur_header_bord.ToolTip.ToString());
            }
            
            int variant = 1;
            //string dayName = cur_header.Text + '\n' + cur_button.Tag.ToString();
            
            //string dayName = cur_header.Text.Substring(0, 1).ToUpper() + cur_header.Text.Substring(1, cur_header.Text.IndexOf("\n") - 1) +
            //                 '\n' + date.ToString("dd/MM/yyyy") + '\n' + cur_button.Tag.ToString();

            string dayName = date.ToString("dddd", russian);
            dayName = dayName.Substring(0, 1).ToUpper() + dayName.Substring(1, dayName.Length - 1) +
                     '\n' + date.ToString("dd/MM/yyyy") + '\n' + cur_button.Tag.ToString();


            Border cur_bord;
            TextBlock cur_text;



            if (cur_button.Opacity < 1)
            {
                //Если кнопка еще не нажата
                cur_button.Opacity = 1;                
                channel = cur_button.Tag.ToString().channel_text_to_int();
                

                int day_num = Convert.ToInt32(selected_days[0].Name.Replace("headertext", ""));
                EfirType[] efirs = wc.GetEfirs(date, channel, variant);
                string DayRef = "";


                int weeks_counter=0;
                /*
                while (efirs.Length<=0 && weeks_counter<100)
                {
                    date = date.AddDays(-7);
                    efirs = wc.GetEfirs(date, channel, variant);

                    dayName = date.ToString("dddd", russian);
                    dayName = dayName.Substring(0, 1).ToUpper() + dayName.Substring(1, dayName.Length - 1) +
                             '\n' + date.ToString("dd/MM/yyyy") + '\n' + cur_button.Tag.ToString();
                    weeks_counter += 1;                                        
                }
                if (weeks_counter>=70)
                {
                    MessageBox.Show("Предыдущих недель в базе пока нет.");
                    cur_header_bord.ToolTip = tb_name[1];
                    ch_rus1.Opacity = 0.3;
                    ch_ntv.Opacity = 0.3;
                    ch_sts.Opacity = 0.3;
                    ch_tnt.Opacity = 0.3;                    
                    return;
                }
                */


                if (efirs.Length > 0)
                {
                    DayRef = efirs[1].TVDayRef;
                }


                //Фиксируем дату
                
                //cur_header_bord.Tag = date.ToString("dd/MM/yyyy");
                cur_header_bord.ToolTip = date.ToString("dd/MM/yyyy");
                //TextBox tb_day = (TextBox)concur_curday.Content;
                //TextBox tb_month = (TextBox)concur_month.Content;
                //TextBox tb_year = (TextBox)concur_year.Content;
                //tb_day.Text = date.Day.ToString();
                //tb_month.Text = date.Month.ToString();
                //tb_year.Text = date.Year.ToString().Right(2);



                //MessageBox.Show(cur_button.Tag.ToString());
                right_shift_days(e);

                


                create_day(dayName, day_num + 1, variant,DayRef);
                WeekTVDayType wtvday = new WeekTVDayType();
                wtvday.KanalKod = channel;
                wtvday.TVDate = date;
                wtvday.VariantKod = variant;                
                day_construct(wtvday,day_num+1);
                selected_days.Clear();
                selected_days.Add(cur_header);

            }
            else
            {
                //Если уже нажата
                

                foreach (UIElement child in canvasArea.Children)
                {
                    if (child.GetType() == typeof(Border))
                    {
                        cur_bord = (Border)child;
                        cur_text = (TextBlock)cur_bord.Child;

                        if (cur_bord.Name.Left(10) == "headerbord")
                        {
                            //string cur_date = cur_header_bord.Tag.ToString();
                            string cur_date = cur_header_bord.ToolTip.ToString();
                            if ((cur_button.Tag.ToString().Contains("Россия-1") && cur_text.Text.Contains(cur_date) && cur_text.Text.Contains("Россия-1")) ||
                                (cur_button.Tag.ToString().Contains("НТВ") && cur_text.Text.Contains(cur_date) && cur_text.Text.Contains("НТВ")) ||
                                (cur_button.Tag.ToString().Contains("СТС") && cur_text.Text.Contains(cur_date) && cur_text.Text.Contains("СТС")) ||
                                (cur_button.Tag.ToString().Contains("ТНТ") && cur_text.Text.Contains(cur_date) && cur_text.Text.Contains("ТНТ")))
                            {
                                selected_days.Clear();
                                selected_days.Add(cur_text);
                               // cur_button.Tag = cur_button.Tag.ToString().Substring(0,cur_button.Tag.ToString().IndexOf("_"));
                                break;                                
                            }                            
                        }
                    }
                }

                date = DateTime.Parse(tb_name[1]);
                if (ch_rus1.Opacity < 1 && ch_ntv.Opacity < 1)
                {
                    cur_header_bord.ToolTip = date.ToString("dd/MM/yyyy");
                }

                delete_day_Click(cur_header, (RoutedEventArgs)e);

                selected_days.Clear();
                selected_days.Add(cur_header);
                cur_button.Opacity = 0.3;

                /*
                 //С какой-то целью все это было написано, но история не сохранила упоминаний об этой цели
                if (cur_header.Text.Contains("Россия-1") || cur_header.Text.Contains("НТВ") || cur_header.Text.Contains("СТС") || cur_header.Text.Contains("ТНТ"))
                {
                    delete_day_Click(cur_header, (RoutedEventArgs)e);
                }
                */
            }
        }

        private void main_window_Initialized(object sender, EventArgs e)
        {
            SplashScreen splashScreen = new SplashScreen("Resources/main_tile.png");
            
            splashScreen.Show(true);
            
        }


        private void period_behind_Click(object sender, RoutedEventArgs e)
        {
            Button cur_button = (Button)sender;
            


            bool rus1 = false;
            bool ntv = false;
            bool sts = false;
            bool tnt = false;

            if (ch_rus1.Opacity == 1) rus1 = true;
            if (ch_ntv.Opacity == 1) ntv = true;
            if (ch_sts.Opacity == 1) sts = true;
            if (ch_tnt.Opacity == 1) tnt = true;

            TextBlock cur_header = selected_days[0];
            Border cur_header_bord = (Border)cur_header.Parent;
            string[] tb_name = cur_header.Text.Split('\n');
            CultureInfo russian = new CultureInfo("ru-RU");
            DateTime date = DateTime.Parse(tb_name[1]);

            

            if (rus1) ch_Click(ch_rus1, e);
            if (ntv) ch_Click(ch_ntv, e);
            if (sts) ch_Click(ch_sts, e);
            if (tnt) ch_Click(ch_tnt, e);

            if (cur_button.Tag.ToString() == "Текущий день") cur_header_bord.ToolTip = date.ToString("dd/MM/yyyy");
            if (cur_button.Tag.ToString() == "День") cur_header_bord.ToolTip = DateTime.Parse(cur_header_bord.ToolTip.ToString()).AddDays(1*direction).ToString("dd/MM/yyyy");
            if (cur_button.Tag.ToString() == "Неделя") cur_header_bord.ToolTip = DateTime.Parse(cur_header_bord.ToolTip.ToString()).AddDays(7*direction).ToString("dd/MM/yyyy");
            if (cur_button.Tag.ToString() == "Месяц") cur_header_bord.ToolTip = DateTime.Parse(cur_header_bord.ToolTip.ToString()).AddDays(7*4*direction).ToString("dd/MM/yyyy");
            if (cur_button.Tag.ToString() == "Год") cur_header_bord.ToolTip = DateTime.Parse(cur_header_bord.ToolTip.ToString()).AddYears(1*direction).ToString("dd/MM/yyyy"); ;


            

            if (rus1) ch_Click(ch_rus1, e);

            //Довольно глупая проверка на наличие предыдущих недель в базе, см. ch_click
            if (ch_rus1.Opacity<1)
            {
                ntv = false;
                sts = false;
                tnt = false;
            }

            if (ntv) ch_Click(ch_ntv, e);
            if (sts) ch_Click(ch_sts, e);
            if (tnt) ch_Click(ch_tnt, e);


            
            
        }


        private void direction_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            Button cur_button = (Button)sender;
                       
            if (e.Delta > 0)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            if (cur_button.Tag.ToString()=="День" || cur_button.Tag.ToString()=="Неделя" || cur_button.Tag.ToString()=="Месяц" || cur_button.Tag.ToString()=="Год")
            {
                period_behind_Click(sender, e);
            }

            //Возвращаем, как было
            direction = -1;

        }

        private string week_behind_Click(object sender, RoutedEventArgs e, TextBlock cur_header)
        {
            
            
            Border cur_header_bord = (Border)cur_header.Parent;
            int orig_day_num = Convert.ToInt32(cur_header.Name.Replace("headertext", ""))-1;

            string cur_date = cur_header_bord.ToolTip.ToString();
            string dayName = "";


            string[] tb_name = cur_header.Text.Split('\n');
            CultureInfo russian = new CultureInfo("ru-RU");
            DateTime date = DateTime.Parse(tb_name[1]);
            int variant = 1;
            int channel = 0;
            int day_num = 0;
            string ch_str ="";

            Border cur_bord;
            TextBlock cur_text;


            foreach (TextBlock child in all_the_days)
            {
                
                    cur_bord = (Border)child.Parent;
                    cur_text = (TextBlock)child;

                    if (cur_bord.Name.Left(10) == "headerbord")
                    {                        
                        
                        if ((cur_text.Text.Contains(cur_date) && cur_text.Text.Contains("Россия-1")) ||
                            (cur_text.Text.Contains(cur_date) && cur_text.Text.Contains("НТВ")) ||
                            (cur_text.Text.Contains(cur_date) && cur_text.Text.Contains("СТС")) ||
                            (cur_text.Text.Contains(cur_date) && cur_text.Text.Contains("ТНТ")))
                        {

                            
                            
                   

                            ////                            

                            if (cur_text.Text.Contains("Россия-1")) 
                            {
                                channel = 21;
                                ch_str = "Россия-1";
                            }
                            if (cur_text.Text.Contains("НТВ"))
                            {
                                channel = 40;
                                ch_str = "НТВ";
                            }

                            tb_name = cur_text.Text.Split('\n');
                            russian = new CultureInfo("ru-RU");
                            date = DateTime.Parse(tb_name[1]);

                            day_num = Convert.ToInt32(cur_text.Name.Replace("headertext", ""))-1;
                            

                            selected_days.Clear();
                            selected_days.Add(cur_text);
                            break;
                            ////

                        }
                    }
           }


            delete_day_Click(cur_header, (RoutedEventArgs)e);
            selected_days.Clear();
            selected_days.Add(cur_header);
            /*
            EfirType[] efirs = wc.GetEfirs(date, channel, variant);
            string DayRef = "";


            date = date.AddDays(-7);

            efirs = wc.GetEfirs(date, channel, variant);

            
            dayName = date.ToString("dddd", russian);
            dayName = dayName.Substring(0, 1).ToUpper() + dayName.Substring(1, dayName.Length - 1) +
                     '\n' + date.ToString("dd/MM/yyyy") + '\n' + ch_str;


            if (efirs.Length > 0)
            {
                DayRef = efirs[1].TVDayRef;
            }


            //Фиксируем дату

            //cur_header_bord.ToolTip = date.ToString("dd/MM/yyyy");
            right_shift_days(e);

            create_day(dayName, day_num + day_num-orig_day_num, variant, DayRef);
            WeekTVDayType wtvday = new WeekTVDayType();
            wtvday.KanalKod = channel;
            wtvday.TVDate = date;
            wtvday.VariantKod = variant;
            day_construct(wtvday, day_num + day_num - orig_day_num);
            selected_days.Clear();
            selected_days.Add(cur_header);
             */ 
            string new_tooltip = date.ToString("dd/MM/yyyy");
            return new_tooltip;

        }

        private void settings_button_Click(object sender, RoutedEventArgs e)
        {
            settings_flyout.IsOpen = !settings_flyout.IsOpen;
            Button plan12_button = new Button();
            Button localhost_button = new Button();
            Button tsurf_button = new Button();
            TextBox tbox = new TextBox();
            CheckBox variants_checkbox = new CheckBox();


            
            if (sp_set.Children.Count < 2)
            {
                plan12_button.Name = "plan12_button";
                plan12_button.Width = 100;
                plan12_button.Height = 50;
                plan12_button.Content = "Plan12";
                plan12_button.Click += url_button_Click;
                plan12_button.Margin = new Thickness(10);
                sp_set.Children.Add(plan12_button);

                localhost_button.Name = "localhost_button";
                localhost_button.Width = 100;
                localhost_button.Height = 50;
                localhost_button.Content = "Localhost";
                localhost_button.Click += url_button_Click;
                localhost_button.Margin = new Thickness(10);
                sp_set.Children.Add(localhost_button);

                tsurf_button.Name = "tsurf_button";
                tsurf_button.Width = 100;
                tsurf_button.Height = 50;
                tsurf_button.Content = "TSurf";
                tsurf_button.Click += url_button_Click;
                tsurf_button.Margin = new Thickness(10);
                sp_set.Children.Add(tsurf_button);

                tbox.Name = "tb_server_name";
                tbox.Width = 200;
                tbox.Height = 20;
                tbox.Text = "Введите имя сервера";
                tbox.GotFocus += tbox_GotFocus;
                tbox.KeyUp += tbox_KeyUp;
                tbox.Margin = new Thickness(10);
                sp_set.Children.Add(tbox);

                variants_checkbox.Name = "v_checkbox";
                variants_checkbox.Width = 200;
                variants_checkbox.Height = 40;
                variants_checkbox.Content = "Показывать варианты";
                variants_checkbox.IsChecked = false;
                variants_checkbox.Checked += variants_checkbox_Checked;
                variants_checkbox.Unchecked += variants_checkbox_Checked;
                variants_checkbox.Margin = new Thickness(10);
                sp_set.Children.Add(variants_checkbox);
            }



        }

        void variants_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chbox = (CheckBox)sender;
            /*
            if (chbox.IsChecked==true)
            {
                show_variant_headers = 1;
                foreach (Rectangle r in blinders)
                {
                    r.Opacity = 0;
                }
            }
            else
            {
                show_variant_headers = 0;
                foreach (Rectangle r in blinders)
                {
                    r.Opacity = 1;
                }
            }
             */ 
        }

        void tbox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            tbox.Text = "";
        }

        void tbox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tbox = (TextBox)sender;
            if (e.Key==Key.Enter)
            {
                if (tbox.Text.Length > 0)
                {
                    wc.Url = "http://" + tbox.Text + "/plan1c/ws/ws1.1cws";
                    wc.Credentials = new System.Net.NetworkCredential("mike", "123");
                    con_plan12 = new SqlConnection("user id=sa;" +
                                   "password=945549;server=" + tbox.Text + "\\SQLEXPRESS;" +
                                   "Trusted_Connection=no;" +
                                   "database=Plan; " +
                                   "connection timeout=30");
                    try
                    {
                        wc.GetWeeks();
                        main_window.Title = main_window.Title.Substring(0, main_window.Title.IndexOf(" ")) + " — " + tbox.Text;
                        connected = true;
                    }
                    catch (Exception ex)
                    {
                        connected = false;
                        return;
                    }
                }
            }
        }

        private void url_button_Click(object sender, RoutedEventArgs e)
        {
            if (Flyout_top.IsOpen) Flyout_top.IsOpen = false;
            


            Button cur_button = (Button)sender;
            if (cur_button.Name == "plan12_button")
            {
                wc.Url = "http://plan12r/plan1cw/ws/ws1.1cws";
                wc.Credentials = new System.Net.NetworkCredential("mike", "123");
                con_plan12 = new SqlConnection("user id=sa;" +
                               "password=945549;server=Plan12r;" +
                               "Trusted_Connection=no;" +
                               "database=Plan; " +
                               "connection timeout=30");
                try
                {
                    wc.GetWeeks();
                    
                    main_window.Title = main_window.Title.Substring(0, main_window.Title.IndexOf(" ")) + " (Plan12)";
                    connected = true;
                }
                catch (Exception ex)
                {
                    connected = false;
                    return;
                }
            }
            if (cur_button.Name == "localhost_button")
            {
                wc.Url = "http://localhost/plan1cf/ws/ws1.1cws";
                //wc.Url = "http://localhost/plan1c/ws/ws1.1cws";
                wc.Credentials = new System.Net.NetworkCredential("mike", "123");
                con_plan12 = new SqlConnection("user id=sa;" +
                               "password=945549;server=localhost\\SQLEXPRESS;" +
                               "Trusted_Connection=no;" +
                               "database=Plan; " +
                               "connection timeout=30");
                try
                {
                    wc.GetWeeks();
                    main_window.Title = main_window.Title.Substring(0, main_window.Title.IndexOf(" ")) + " (Localhost)";
                    connected = true;
                }
                catch (Exception ex)
                {
                    connected = false;
                    return;
                }
            }
            if (cur_button.Name == "tsurf_button")
            {
                //wc.Url = "http://tsurface/plan1cf/ws/ws1.1cws";
                wc.Url = "http://tsurface/plan1cw/ws/ws1.1cws";
                wc.Credentials = new System.Net.NetworkCredential("mike", "123");
                con_plan12 = new SqlConnection("user id=sa;" +
                               "password=945549;server=tsurface\\SQLEXPRESS;" +
                               "Trusted_Connection=no;" +
                               "database=Plan; " +
                               "connection timeout=30");
                try
                {
                    wc.GetWeeks();
                    main_window.Title = main_window.Title.Substring(0,main_window.Title.IndexOf(" ")) + " (TSurface)";
                    connected = true;
                }
                catch (Exception ex)
                {
                    connected = false;
                    return;
                }
            }

        }

        private void main_window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers.ToString() == "Control")
            {
                if (e.Delta>0)
                {
                    zoom_slider.Value += 0.05;
                }
                else
                {
                    zoom_slider.Value -= 0.05;
                }
            }
        }

        private void text_size_up_Click(object sender, RoutedEventArgs e)
        {
            Button cur_button = (Button)sender;

            if (cur_button.Name.Contains("up"))
            {
            //    forced_fontsize += 2;                
                base_fontsize += 1;
            }
            else
            {
            //    forced_fontsize -= 2;
                base_fontsize -= 1;
                
            }
            //base_fontsize = forced_fontsize - 1;
            WpfApplication1.Properties.Settings.Default.base_fontsize = base_fontsize;            
            WpfApplication1.Properties.Settings.Default.Save();

            zoom_slider.Value += 0.01;
            zoom_slider.Value -= 0.01;
        }


        private void chb_Click(object sender, RoutedEventArgs e)
        {
            //Переключение дефолтного канала для календаря

            Button cur_button = (Button)sender;
            List<Button> buttons = new List<Button>();
            buttons.Add(ch_oneb);
            buttons.Add(ch_rus1b);
            buttons.Add(ch_ntvb);
            buttons.Add(ch_stsb);
            buttons.Add(ch_tntb);
            buttons.Add(ch_orbb);
            
            foreach (Button b in buttons) b.Opacity=0.3;            
            cur_button.Opacity = 1;      

            if (de_grid.Children.Count >= 0)
            {
                if (de_grid.RowDefinitions.Count() > 0)
                {
                    de_grid.RowDefinitions.RemoveRange(0, de_grid.RowDefinitions.Count());
                    if (de_grid.Children.Count > 0)
                    {
                        de_grid.Children.RemoveRange(0, de_grid.Children.Count);
                    }
                }
                create_day_entry(days_calendar.SelectedDates);
            }
            
        }

        private void title_button_Click(object sender, RoutedEventArgs e)
        {
            string temp_string = "";
            if (!shortened_titles)
            {                
                foreach (TextBlock cur_tb in progs)
                {
                    
                    temp_string = cur_tb.Text.deconstruct().Item1;
                    cur_tb.ToolTip = cur_tb.Text;
                    temp_string += "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n";
                    cur_tb.Text = cur_tb.Text.Replace(temp_string.Left(temp_string.Length-30), temp_string);
                    shorten_dict(cur_tb);
                }
            }



            if (shortened_titles)
            {
                foreach (TextBlock cur_tb in progs)
                {
                    
                    //cur_tb.Text = cur_tb.Text.Replace("\n\n\n\n\n\n\n\n\n\n", "");
                    cur_tb.Text = cur_tb.ToolTip.ToString();
                    cur_tb.ToolTip = "";

                }
            }

            shortened_titles = !shortened_titles;

        }

        
        private TextBlock shorten_dict(TextBlock cur_text)
        {

            char[] arr = new char[] { '\n', ' ', ' ' }; // Trim these characters.
            bool premiera = false;



            //Общие правила
            if (!cur_text.Text.Contains(" ИЛИ") & !cur_text.Text.Contains("\nИЛИ"))
                //Иначе - режет все к чертовой матери. Потом - страдает.
            {
                if (cur_text.Text.Contains("В ФИЛЬМЕ"))
                {
                    trim_substr("В ФИЛЬМЕ", cur_text);
                    cur_text.Text = cur_text.Text.Replace("В ФИЛЬМЕ", "Х/Ф ");
                    if (cur_text.Text.Contains("ПРЕМЬЕРА")) premiera = true;
                }
                if (cur_text.Text.Contains("В ТРИЛЛЕРЕ"))
                {
                    trim_substr("В ТРИЛЛЕРЕ", cur_text);
                    cur_text.Text = cur_text.Text.Replace("В ТРИЛЛЕРЕ", "Х/Ф ");
                    if (cur_text.Text.Contains("ПРЕМЬЕРА")) premiera = true;
                }
                if (cur_text.Text.Contains("В КОМЕДИИ"))
                {
                    trim_substr("В КОМЕДИИ", cur_text);
                    cur_text.Text = cur_text.Text.Replace("В КОМЕДИИ", "Х/Ф ");
                    if (cur_text.Text.Contains("ПРЕМЬЕРА")) premiera = true;
                }
                if (cur_text.Text.Contains("В ПРИКЛЮЧЕНЧЕСКОМ ФИЛЬМЕ"))
                {
                    trim_substr("В ПРИКЛЮЧЕНЧЕСКОМ ФИЛЬМЕ", cur_text);
                    cur_text.Text = cur_text.Text.Replace("В ПРИКЛЮЧЕНЧЕСКОМ ФИЛЬМЕ", "Х/Ф ");
                    if (cur_text.Text.Contains("ПРЕМЬЕРА")) premiera = true;
                }
                if (cur_text.Text.Contains("В ЛИРИЧЕСКОЙ КОМЕДИИ"))
                {
                    trim_substr("В ЛИРИЧЕСКОЙ КОМЕДИИ", cur_text);
                    cur_text.Text = cur_text.Text.Replace("В ЛИРИЧЕСКОЙ КОМЕДИИ", "Х/Ф ");
                    if (cur_text.Text.Contains("ПРЕМЬЕРА")) premiera = true;
                }
                if (cur_text.Text.Contains("В ДЕТЕКТИВЕ"))
                {
                    trim_substr("В ДЕТЕКТИВЕ", cur_text);
                    cur_text.Text = cur_text.Text.Replace("В ДЕТЕКТИВЕ", "Х/Ф ");
                    if (cur_text.Text.Contains("ПРЕМЬЕРА")) premiera = true;
                }

                if (cur_text.Text.Contains("В МНОГОСЕРИЙНОМ ФИЛЬМЕ"))
                {
                    trim_substr("В МНОГОСЕРИЙНОМ ФИЛЬМЕ", cur_text);
                    cur_text.Text = cur_text.Text.Replace("В МНОГОСЕРИЙНОМ ФИЛЬМЕ", "СЕРИАЛ ");
                    if (cur_text.Text.Contains("ПРЕМЬЕРА")) premiera = true;
                }


                if (cur_text.Text.Contains("МНОГОСЕРИЙНЫЙ ФИЛЬМ"))
                {
                    cur_text.Text = cur_text.Text.Replace("МНОГОСЕРИЙНЫЙ ФИЛЬМ", "СЕРИАЛ");
                    if (cur_text.Text.Contains("ПРЕМЬЕРА")) premiera = true;
                    //cur_text.Text += "\nСЕРИАЛ";
                }
            }

            cur_text.Text = cur_text.Text.Replace("(S)", "");



            string title = cur_text.Text.deconstruct().Item1;
            string new_title = title;
            cur_text.Text = cur_text.Text.Replace(title, title.TrimStart(arr));
            if (premiera) new_title = "ПРЕМЬЕРА.\n" + new_title;
            cur_text.Text = cur_text.Text.Replace(title, new_title);
            

            
            /*
            if (cur_text.Text.Contains("В ФИЛЬМЕ"))
            {
                cur_text.Text = cur_text.Text.Substring(cur_text.Text.IndexOf("В ФИЛЬМЕ") + 8, cur_text.Text.Length - cur_text.Text.IndexOf("В ФИЛЬМЕ") - 8);            
            }
            */
            
            






            //Первый канал
            cur_text.Text = cur_text.Text.Replace("\nС АНДРЕЕМ МАЛАХОВЫМ", "");
            cur_text.Text = cur_text.Text.Replace(" С АНДРЕЕМ МАЛАХОВЫМ", "");
            cur_text.Text = cur_text.Text.Replace(".\nПРОГРАММА ЮЛИИ МЕНЬШОВОЙ", "");
            cur_text.Text = cur_text.Text.Replace("\nС ДМИТРИЕМ ДИБРОВЫМ", "");
            cur_text.Text = cur_text.Text.Replace("\nС АЛЕКСЕЕМ ПИМАНОВЫМ", "");
            cur_text.Text = cur_text.Text.Replace("КЛУБ ВЕСЕЛЫХ И НАХОДЧИВЫХ", "КВН");
            cur_text.Text = cur_text.Text.Replace("\n(С СУБТИТРАМИ)", "");
            cur_text.Text = cur_text.Text.Replace("(С СУБТИТРАМИ)", "");
            if (cur_text.Text.Contains("ВОСКРЕСНОЕ "))
            {
                cur_text.Text = cur_text.Text.Replace(".\nИНФОРМАЦИОННО-АНАЛИТИЧЕСКАЯ ПРОГРАММА", "");
                cur_text.Text = cur_text.Text.Replace(".\nИНФОРМАЦИОННО\n-АНАЛИТИЧЕСКАЯ ПРОГРАММА", "");
                cur_text.Text = cur_text.Text.Replace(".\nИНФОРМАЦИОННО-\nАНАЛИТИЧЕСКАЯ ПРОГРАММА", "");    
     
            }


            return cur_text;
        }

        private TextBlock trim_substr(string cur_string, TextBlock cur_text)
        {
            

            int len = cur_string.Length;
            int start = cur_text.Text.IndexOf(cur_string) + len;
            int end = cur_text.Text.Length - cur_text.Text.IndexOf(cur_string) - len;

            string title = cur_text.Text.deconstruct().Item1;
            string new_title = title.Substring(title.IndexOf(cur_string), title.Length - title.IndexOf(cur_string));

            cur_text.Text=cur_text.Text.Replace(title, new_title);
            
            return cur_text;
        }

        private void orbits_button_click(object sender, RoutedEventArgs e)
        {
         
               
                       
        }




    }



}





/*
 * Полезности - stored procedure
 using (SqlConnection conn = new SqlConnection("Server=(local);DataBase=Northwind;Integrated Security=SSPI")) {
    conn.Open();

    // 1.  create a command object identifying the stored procedure
    SqlCommand cmd  = new SqlCommand("CustOrderHist", conn);

    // 2. set the command object so it knows to execute a stored procedure
    cmd.CommandType = CommandType.StoredProcedure;

    // 3. add parameter to command, which will be passed to the stored procedure
    cmd.Parameters.Add(new SqlParameter("@CustomerID", custId));

    // execute the command
    using (SqlDataReader rdr = cmd.ExecuteReader()) {
        // iterate through results, printing each to console
        while (rdr.Read())
        {
            Console.WriteLine("Product: {0,-35} Total: {1,2}",rdr["ProductName"],rdr["Total"]);
        }
    }
}
*/