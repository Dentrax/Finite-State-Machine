using System;
using System.Collections.Generic;
using System.Text;

namespace FiniteStateMachine
{
    public abstract class StateMachine<T> where T : struct, IConvertible {

        public Action<FiniteStateBeganEventArgs> OnStateBegan;
        public Action<FiniteStateEndedEventArgs> OnStateEnded;
        public Action<FiniteStateChangeEventArgs> OnStateChange;

        private Dictionary<T, State<T>> m_states;

        private State<T> m_currentState;

        public T CurrentState {
            get { return this.m_currentState.StateKey; }
        }

        public StateMachine() {
            this.m_states = new Dictionary<T, State<T>>();
        }

        public virtual void Initialize() {
            //TODO: Your base Initialize codes...
        }

        public virtual void Update(float deltaTime) {
            if (this.m_currentState != null) {
                this.m_currentState._Update(deltaTime);
            }
        }

        public void AddState(State<T> state) {
            if (state.StateMachine != this) {
                throw new Exception("[FiniteStateMachine::AddState()] -> The State can only be added to the State Machine that was used to create it.");
            }
            this.m_states.Add(state.StateKey, state);
        }

        public virtual T MoveTo(T targetStateKey, FiniteStateChangeEventArgs eventArgs = null) {
            if (!this.m_states.ContainsKey(targetStateKey)) {
                throw new Exception("[FiniteStateMachine::MoveTo()] -> Target state did not exist. Please add the State<T> for key: '" + targetStateKey);
            }
            T previousStateKey = targetStateKey;
            if (this.m_currentState != null) {
                previousStateKey = this.m_currentState.StateKey;
                this.m_currentState._End();
            }
            this.m_currentState = this.m_states[targetStateKey];
            this.m_currentState._Begin(eventArgs, previousStateKey);
            return this.m_currentState.StateKey;
        }
    }
}
