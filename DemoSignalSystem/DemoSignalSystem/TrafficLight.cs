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

        string type; 
        
        //Called to create new traffic light
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

        //Turns forward light green
        public void forwardOn()
        {
           if (this.hasForward) this.forward = true;
        }
        
        //turns forward light red
        public void forwardOff()
        {
            if (this.hasForward) this.forward = false;
        }

        //turns right light green
        public void rightOn()
        {
           if (this.hasRight) this.right = true;
        }

        //turns right light red
        public void rightOff()
        {
            if (this.hasRight) this.right = false;
        }

        //turns left light green
        public void leftOn()
        {
           if (this.hasLeft)  this.left = true;
        }

        //turns left light red
        public void leftOff()
        {
           if (this.hasLeft) this.left = false;
        }

        //returns status of forward light
        public bool forStatus()
        {
            return forward;
        }

        //returns status of right light
        public bool rightStatus()
        {
            return right;
        }

        //returns status of left light
        public bool leftStatus()
        {
            return left;
        }
        
        //returns if light has forward
        public bool isForward()
        {
            return hasForward;
        }

        //returns if light has right
        public bool isRight()
        {
            return hasRight;
        }

        //returns if light has left
        public bool isLeft()
        {
            return hasLeft;
        }

    }
}
