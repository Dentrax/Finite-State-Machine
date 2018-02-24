#region License
// ====================================================
// FiniteStateMachine Copyright(C) 2018 Furkan Türkal
// This program comes with ABSOLUTELY NO WARRANTY; This is free software,
// and you are welcome to redistribute it under certain conditions; See
// file LICENSE, which is part of this source code package, for details.
// ====================================================
#endregion

namespace FiniteStateMachine
{
    public abstract class StateBase : State<StateType>, IState<StateType> {

        public StateBase(FiniteStateMachine fsm, StateType stateKey) : base(fsm, stateKey) { }

        public sealed override void _Begin(FiniteStateChangeEventArgs eventArgs, StateType previousStateKey) {
            FiniteStateMachine.Instance.OnStateBegan?.Invoke(new FiniteStateBeganEventArgs(base.StateKey));
            this.Begin(eventArgs, previousStateKey);
        }

        public sealed override void _Update(float dt) {
            this.Update(dt);
        }

        public sealed override void _End() {
            this.End();
            FiniteStateMachine.Instance.OnStateEnded?.Invoke(new FiniteStateEndedEventArgs(base.StateKey));
        }
    }
}
