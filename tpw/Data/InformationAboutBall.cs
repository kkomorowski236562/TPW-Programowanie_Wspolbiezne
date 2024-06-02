using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data
{
    internal class InformationAboutBall
    {
        public double XPos { get; set; }
        public double YPos { get; set; }
        public double XSpeed { get; set; }
        public double YSpeed { get; set; }
        public int Hash { get; set; }
        public string Date { get; set; }

        public InformationAboutBall(double XPos, double YPos, double XSpeed, double YSpeed, int Hash)
        {
            this.XPos = XPos;
            this.YPos = YPos;
            this.XSpeed = XSpeed;
            this.YSpeed = YSpeed;
            this.Hash = Hash;
            string millisecondFormat = $"{NumberFormatInfo.CurrentInfo.NumberDecimalSeparator}fff";
            string fullPattern = DateTimeFormatInfo.CurrentInfo.FullDateTimePattern;
            fullPattern = Regex.Replace(fullPattern, "(:ss|:s)", $"$1{millisecondFormat}");
            Date = DateTime.Now.ToString(fullPattern);
        }

        public override string ToString()
        {
            string toWrite = "circle:" + "\n";
            toWrite += "  - Hash: " + Hash + "\n";
            toWrite += "  - XPos: " + XPos + "\n";
            toWrite += "  - Ypos: " + YPos + "\n";
            toWrite += "  - XSpeed: " + XSpeed + "\n";
            toWrite += "  - YSpeed: " + YSpeed + "\n";
            toWrite += "  - Date: " + Date + "\n";
            return toWrite;
        }
    }
}
