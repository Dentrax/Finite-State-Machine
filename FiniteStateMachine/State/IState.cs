#region License
// ====================================================
// EasySSA Copyright(C) 2018 Furkan Türkal
// This program comes with ABSOLUTELY NO WARRANTY; This is free software,
// and you are welcome to redistribute it under certain conditions; See
// file LICENSE, which is part of this source code package, for details.
// ====================================================
#endregion

namespace FiniteStateMachine
{
    public interface IState {
        void Load();

        void Begin();

        void End();
    }
}
