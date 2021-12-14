using System;
using System.Collections;
using UnityEngine;

namespace Player.States
{
    public abstract class State: MonoBehaviour
    {
       
        public int _sizeIndex;
        private State _currentState;
        public virtual void Start()
        {
            
        }

        public virtual void Update()
        {
           
        }

        public virtual void Ability()
        {
           
        }

        public virtual void Scale(int scale)
        {
            
        }
        
    }
}
