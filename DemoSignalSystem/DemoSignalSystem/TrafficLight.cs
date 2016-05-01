using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignalSystem
{
    class TrafficLight
    {
        bool hasForward;
        bool hasRight;
        bool hasLeft;

        bool forward;
        bool right;
        bool left;

        string type; //car, train, bike;

        List<Vehicle>  vehicleQueue = new List<Vehicle>();

        

        public TrafficLight(bool hasForward, bool forward, bool hasRight, bool right, bool hasLeft, bool left, string type)
        {
            this.hasForward = hasForward;
            this.forward    = forward;
            this.hasRight   = hasRight;
            this.right      = right;
            this.hasLeft    = hasLeft;
            this.left       = left;
            this.type       = type;
        }

        public void forwardOn()
        {
           if (this.hasForward) this.forward = true;
        }

        public void forwardOff()
        {
            if (this.hasForward) this.forward = false;
        }

        public void rightOn()
        {
           if (this.hasRight) this.right = true;
        }

        public void rightOff()
        {
            if (this.hasRight) this.right = false;
        }

        public void leftOn()
        {
           if (this.hasLeft)  this.left = true;
        }

        public void leftOff()
        {
           if (this.hasLeft) this.left = false;
        }

        public bool forStatus()
        {
            return forward;
        }

        public bool rightStatus()
        {
            return right;
        }

        public bool leftStatus()
        {
            return left;

        }

        public bool isForward()
        {
            return hasForward;
        }

        public bool isRight()
        {
            return hasRight;
        }

        public bool isLeft()
        {
            return hasLeft;
        }

        public void greenPop(string direction)
        {
            for (int i = 0; i < this.vehicleQueue.Count(); i++)
            {
                if (vehicleQueue[i].direction == direction) vehicleQueue.RemoveAt(i);
            }
        }

    }
}
