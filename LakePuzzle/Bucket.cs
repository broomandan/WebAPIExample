using System.Collections.Generic;
using System;
using System.Collections;
namespace LakePuzzle.Business
{
    public class Bucket
    {
        internal Bucket(uint capacity)
        {
            Capacity = capacity;
        }

        internal uint Capacity { get; private set; }
        private uint _currentVolume;

        internal bool IsEmpty()
        {
            return CurrentVolume == 0;
        }

        internal bool IsFull()
        {
            return Capacity == CurrentVolume;
        }

        internal uint RemainingVolume
        {
            get
            {
                return Capacity - _currentVolume;
            }
        }

        internal uint CurrentVolume
        {
            get { return _currentVolume; }
            private set
            {
                if (value > Capacity)
                {
                    _currentVolume = Capacity;
                }
                else
                {
                    _currentVolume = value;
                }
            }
        }

        internal void Empty()
        {
            CurrentVolume = 0;
        }

        internal void Fill()
        {
            CurrentVolume = Capacity;
        }

        internal void Transfer(uint volume)
        {
            CurrentVolume = CurrentVolume + volume;
        }

        internal void TransferTo(Bucket targetBucket)
        {

            uint diff = CurrentVolume > targetBucket.RemainingVolume ? CurrentVolume - targetBucket.RemainingVolume : 0;

            targetBucket.Transfer(CurrentVolume);

            CurrentVolume = diff;

        }
    }
}
