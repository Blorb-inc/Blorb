using UnityEngine;

namespace Player.States
{
    public abstract class StateMachine: MonoBehaviour
    {
        protected State MState;

        public void SetState(State state)
        {
            MState = state;
            
        }
    }
}
