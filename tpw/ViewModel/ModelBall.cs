﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ModelBall : ViewModelBase
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Radius { get; set; }

        public String Color { get; set; }


        public ModelBall(double x, double y, double radius, String color)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
            this.Color = color;
        }

        public void Update(Object s, PropertyChangedEventArgs e)
        {
            Logic.LogicBall ball = (Logic.LogicBall)s;
            X = ball.X;
            Y = ball.Y;
        }
    }
}