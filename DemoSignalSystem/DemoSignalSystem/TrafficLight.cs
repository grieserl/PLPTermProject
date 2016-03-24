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

        public TrafficLight(bool hasForward, bool forward, bool hasRight, bool right, bool hasLeft, bool left)
        {
            this.hasForward = hasForward;
            this.forward    = forward;
            this.hasRight   = hasRight;
            this.right      = right;
            this.hasLeft    = hasLeft;
            this.left       = left;
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


    }
}
