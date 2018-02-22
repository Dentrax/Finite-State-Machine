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
    public abstract class State<T> where T : struct, IConvertible
    {
        public StateMachine<T> StateMachine { get; private set; }

        public T StateKey { get; private set; }

        public State(StateMachine<T> fsm, T stateKey)
        {
            this.StateMachine = fsm;
            this.StateKey = stateKey;
        }

        public abstract void Load();

        public virtual void _Begin(FiniteStateChangeEventArgs eventArgs, T previousStateKey)
        {
            this.Begin(eventArgs, previousStateKey);
        }

        public abstract void Begin(FiniteStateChangeEventArgs eventArgs, T previousStateKey);

        public virtual void _Update(float deltaTime)
        {
            this.Update(deltaTime);
        }

        public abstract void Update(float deltaTime);

        public virtual void _End()
        {
            this.End();
        }

        public abstract void End();
    }
}
