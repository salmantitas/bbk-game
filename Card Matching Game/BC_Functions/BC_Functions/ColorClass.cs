using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BC_Functions
{
    public static class ColorClass
    {
        const decimal MAX_COLOR_VALUE=255;
        const bool DEFALT_AUTO_FIX_VALUE=false;

        private static void ValueCheck(ref decimal value,bool autoFix=DEFALT_AUTO_FIX_VALUE)
        {
            if (value>100m)
            {
                if (autoFix)
                {
                    value = 100m;
                }
                else
                {
                    throw new Exception("The value is to high");
                }
            }
            else if (value<0m)
            {
                if (autoFix)
                {
                    value = 0m;
                }
                else
                {
                    throw new Exception("The value is to low");
                }
            }
        }

        public static Color HeatColor(decimal value, bool autoFix = DEFALT_AUTO_FIX_VALUE)
        {
            decimal red = 0;
            decimal green = 0;
            decimal blue = 0;
            Color color = new Color();
            ValueCheck(ref value,autoFix);

            if (value < 12.5m)
            {
                blue = MAX_COLOR_VALUE;
                green = value * MAX_COLOR_VALUE / 12.5m;
            }
            else if (value < 25)
            {
                green = MAX_COLOR_VALUE;
                blue = MAX_COLOR_VALUE * ((25 - value) / 12.5m);
            }
            else if (value < 50)
            {
                green = MAX_COLOR_VALUE;
                red = (value - 25) * MAX_COLOR_VALUE / 25;
            }
            else if (value <= 100)
            {
                red = MAX_COLOR_VALUE;
                green = MAX_COLOR_VALUE * ((100 - value) / 50);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
            color = Color.FromArgb((int)red, (int)green, (int)blue);

            return color;
        }

        public static Color HeatColor(int value, bool autoFix = DEFALT_AUTO_FIX_VALUE)
        {
            return HeatColor((decimal)value);
        }

        public static Color HeatColor(int value, int max, bool autoFix = DEFALT_AUTO_FIX_VALUE)
        {
            return HeatColor(value * 100 / max);
        }

        public static Color RedGreen(decimal value, bool autoFix = DEFALT_AUTO_FIX_VALUE)
        {
            decimal red = 0;
            decimal green = 0;
            decimal blue = 0;
            Color color = new Color();
            ValueCheck(ref value,autoFix);

            if (value<50m)
            {
                red = MAX_COLOR_VALUE;
                green = value / 50 * MAX_COLOR_VALUE;
            }
            else
            {
                
                green = MAX_COLOR_VALUE;
                red = (100m - value) / 50 * MAX_COLOR_VALUE;
            }

            color = Color.FromArgb((int)red, (int)green, (int)blue);
            return color;
        }
        public static Color RedGreen(int value, bool autoFix = DEFALT_AUTO_FIX_VALUE)
        {
            return RedGreen((decimal)value);
        }

        public static Color RedGreen(int value, int max, bool autoFix = DEFALT_AUTO_FIX_VALUE)
        {
            return RedGreen(value * 100 / max);
        }

        public static Color RedDarkGreen(decimal value, bool autoFix = DEFALT_AUTO_FIX_VALUE)
        {
            decimal red = 0;
            decimal green = 0;
            decimal blue = 0;
            Color color = new Color();
            ValueCheck(ref value, autoFix);

            if (value < 50m)
            {
                red = MAX_COLOR_VALUE;
                green = value / 50 * MAX_COLOR_VALUE;
            }
            else if (value <75m)
            {
                green = MAX_COLOR_VALUE;
                red = (75m-value) / 25 * MAX_COLOR_VALUE;
            }
            else
            {
                green = ((100 - value) / 25 * (MAX_COLOR_VALUE/2)+MAX_COLOR_VALUE/2);
            }

            color = Color.FromArgb((int)red, (int)green, (int)blue);
            return color;
        }
        public static Color RedDarkGreen(int value, bool autoFix = DEFALT_AUTO_FIX_VALUE)
        {
            return RedDarkGreen((decimal)value);
        }

        public static Color RedDarkGreen(int value, int max, bool autoFix = DEFALT_AUTO_FIX_VALUE)
        {
            return RedDarkGreen(value * 100 / max);
        }

        public static Color BlackWhite(decimal value, bool autoFix = DEFALT_AUTO_FIX_VALUE)
        {
            decimal colorValue = 0;
            colorValue = value / 100 * MAX_COLOR_VALUE;

            return Color.FromArgb((int)colorValue, (int)colorValue, (int)colorValue);
        }
        public static Color BlackWhite(int value, bool autoFix = DEFALT_AUTO_FIX_VALUE)
        {
            return BlackWhite((decimal)value);
        }

        public static Color BlackWhite(int value, int max, bool autoFix = DEFALT_AUTO_FIX_VALUE)
        {
            return BlackWhite(value * 100 / max);
        }
    }
}
