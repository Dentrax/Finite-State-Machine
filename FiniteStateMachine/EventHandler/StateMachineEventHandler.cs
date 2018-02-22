#region License
// ====================================================
// FiniteStateMachine Copyright(C) 2018 Furkan Türkal
// This program comes with ABSOLUTELY NO WARRANTY; This is free software,
// and you are welcome to redistribute it under certain conditions; See
// file LICENSE, which is part of this source code package, for details.
// ====================================================
#endregion

using System;

namespace FiniteStateMachine
{
    public sealed class FiniteStateBeganEventArgs : EventArgs
    {
        public StateType Type { get; private set; }

        public FiniteStateBeganEventArgs(StateType beganState)
        {
            this.Type = beganState;
        }
    }

    public sealed class FiniteStateEndedEventArgs : EventArgs
    {
        public StateType Type { get; private set; }

        public FiniteStateEndedEventArgs(StateType endedState)
        {
            this.Type = endedState;
        }
    }

    public sealed class FiniteStateChangeEventArgs : EventArgs
    {
        public StateType RequestedType { get; private set; }
        public StateInfo StateInfo { get; private set; }

        public FiniteStateChangeEventArgs(StateType requestedState)
        {
            this.RequestedType = requestedState;
        }

        public FiniteStateChangeEventArgs(StateType requestedState, StateInfo stateInfo)
        {
            this.RequestedType = requestedState;
            this.StateInfo = stateInfo;
        }
    }
}
