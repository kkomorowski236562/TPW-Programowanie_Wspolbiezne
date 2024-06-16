using System;

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

        private static readonly string DateFormat = "yyyy-MM-dd HH:mm:ss.fff";

        public InformationAboutBall(double XPos, double YPos, double XSpeed, double YSpeed, int Hash)
        {
            this.XPos = XPos;
            this.YPos = YPos;
            this.XSpeed = XSpeed;
            this.YSpeed = YSpeed;
            this.Hash = Hash;
            Date = DateTime.Now.ToString(DateFormat);
        }

        public override string ToString()
        {
            string toWrite = "circle:" + "\n";
            toWrite += "  - Hash: " + Hash + "\n";
            toWrite += "  - XPos: " + XPos + "\n";
            toWrite += "  - YPos: " + YPos + "\n";
            toWrite += "  - XSpeed: " + XSpeed + "\n";
            toWrite += "  - YSpeed: " + YSpeed + "\n";
            toWrite += "  - Date: " + Date + "\n";
            return toWrite;
        }
    }
}
