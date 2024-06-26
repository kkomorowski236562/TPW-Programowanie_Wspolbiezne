﻿using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Model
{
    public class PoolModel
    {
        public PoolModel(double canvasWidth, double canvasHeight, PoolAbstractAPI? poolAPI = null)
        {
            _canvasWidth = canvasWidth;
            _canvasHeight = canvasHeight;
            PoolAPI = poolAPI ?? PoolAbstractAPI.CreateLayer();
        }

        public ObservableCollection<AbstractLogicBall> GetStartingBallPositions(int ballCount)
        {
            Animating = true;
            return PoolAPI.CreateBalls(_canvasWidth, _canvasHeight, ballCount); ;
        }

        public void InterruptThreads()
        {
            PoolAPI.InterruptThreads();
        }

        public void StartThreads()
        {
            PoolAPI.StartThreads();
        }

        private bool _animating;

        public bool Animating
        {
            get => _animating; set => _animating = value;
        }

        private readonly double _canvasWidth;
        private readonly double _canvasHeight;
        private readonly PoolAbstractAPI? PoolAPI = default;
    }
}
