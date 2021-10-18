using System;

namespace GameLogic.Utility
{
    public class Timer
    {
        public bool Enabled { get; set; }
        public bool AutoReset { get; set; }
        private float _waitTime;
        private float _startTime;

        public void Update(float deltaTime)
        {
            if (Enabled)
            {
                _waitTime -= deltaTime;
                if (_waitTime <= 0)
                {
                    Elapsed();

                    if (AutoReset)
                    {
                        _waitTime = _startTime;
                    }
                    else
                    {
                        Stop();
                    }
                }
            }
        }

        public Timer(float waitTime, bool enabled = true, bool autoReset = true)
        {
            _waitTime = waitTime;
            _startTime = waitTime;
            Enabled = enabled;
            AutoReset = autoReset;
        }

        public void Stop()
        {
            Enabled = false;
            Elapsed = null;
        }

        public event Action Elapsed = delegate { };
    }
}