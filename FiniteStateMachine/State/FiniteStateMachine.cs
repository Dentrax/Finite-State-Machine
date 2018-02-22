#region License
// ====================================================
// FiniteStateMachine Copyright(C) 2018 Furkan Türkal
// This program comes with ABSOLUTELY NO WARRANTY; This is free software,
// and you are welcome to redistribute it under certain conditions; See
// file LICENSE, which is part of this source code package, for details.
// ====================================================
#endregion

using System;
using System.Collections.Generic;

namespace FiniteStateMachine
{
    public sealed class FiniteStateMachine : StateMachine<StateType>
    {
        public static readonly FiniteStateMachine Instance = new FiniteStateMachine();

        public FiniteStateMachine() {
        }

        public override void Initialize() {
            base.Initialize();
        }

        public override void Update(float deltaTime) {
            base.Update(deltaTime);
        }

        public override StateType MoveTo(StateType targetStateKey, FiniteStateChangeEventArgs eventArgs = null) {
            this.OnStateChange?.Invoke(eventArgs);
            return base.MoveTo(targetStateKey, eventArgs);
        }
    }
}
