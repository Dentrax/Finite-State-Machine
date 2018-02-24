#region License
// ====================================================
// FiniteStateMachine Copyright(C) 2018 Furkan Türkal
// This program comes with ABSOLUTELY NO WARRANTY; This is free software,
// and you are welcome to redistribute it under certain conditions; See
// file LICENSE, which is part of this source code package, for details.
// ====================================================
#endregion

using System;
using System.Reflection;

namespace FiniteStateMachine.Example
{

    #region States

    public sealed class Example1State : StateBase {

        public Example1State(FiniteStateMachine fsm, StateType stateKey) : base(fsm, stateKey) {

        }

        public override void Begin(FiniteStateChangeEventArgs eventArgs, StateType previousStateKey) {
            Console.WriteLine("[ExampleState::Begin()] -> EXAMPLE 1");
        }

        public override void End() {
            Console.WriteLine("[ExampleState::End()] -> EXAMPLE 1");
        }

        public override void Load() {
            Console.WriteLine("[ExampleState::Load()] -> EXAMPLE 1");
        }

        public override void Update(float deltaTime) {
            Console.WriteLine("[ExampleState::Update()] -> EXAMPLE 1");
        }
    }

    public sealed class Example2State : StateBase {

        public Example2State(FiniteStateMachine fsm, StateType stateKey) : base(fsm, stateKey) {

        }

        public override void Begin(FiniteStateChangeEventArgs eventArgs, StateType previousStateKey) {
            Console.WriteLine("[ExampleState::Begin()] -> EXAMPLE 2");
        }

        public override void End() {
            Console.WriteLine("[ExampleState::End()] -> EXAMPLE 2");
        }

        public override void Load() {
            Console.WriteLine("[ExampleState::Load()] -> EXAMPLE 2");
        }

        public override void Update(float deltaTime) {
            Console.WriteLine("[ExampleState::Update()] -> EXAMPLE 2");
        }

    }

    public sealed class Example3State : StateBase {

        public Example3State(FiniteStateMachine fsm, StateType stateKey) : base(fsm, stateKey) {

        }

        public override void Begin(FiniteStateChangeEventArgs eventArgs, StateType previousStateKey) {
            Console.WriteLine("[ExampleState::Begin()] -> EXAMPLE 3");
        }

        public override void End() {
            Console.WriteLine("[ExampleState::End()] -> EXAMPLE 3");
        }

        public override void Load() {
            Console.WriteLine("[ExampleState::Load()] -> EXAMPLE 3");
        }

        public override void Update(float deltaTime) {
            Console.WriteLine("[ExampleState::Update()] -> EXAMPLE 1");
        }
    }

    #endregion

    public sealed class ExampleStateInfo : StateInfo {
        public override string ToString() {
            return string.Format("{0}", "Test State Info");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Program.SetupConsole();

            Console.WriteLine("\nNon-Deterministic FiniteStateMachine Engine\n");

            new Program().Start();

            Console.Read();
        }

        public void Start() {
            FiniteStateMachine fsm = FiniteStateMachine.Instance;
            fsm.Initialize();
            fsm.AddState(new Example1State(fsm, StateType.EXAMPLE1));
            fsm.AddState(new Example2State(fsm, StateType.EXAMPLE2));
            fsm.AddState(new Example3State(fsm, StateType.EXAMPLE3));

            fsm.OnStateBegan += new Action<FiniteStateBeganEventArgs>(this.OnFiniteStateBegan);
            fsm.OnStateEnded += new Action<FiniteStateEndedEventArgs>(this.OnFiniteStateEnded);
            fsm.OnStateChange += new Action<FiniteStateChangeEventArgs>(this.OnFiniteStateChange);

            fsm.MoveTo(StateType.EXAMPLE1, new FiniteStateChangeEventArgs(StateType.EXAMPLE1, new ExampleStateInfo()));
            fsm.MoveTo(StateType.EXAMPLE2, new FiniteStateChangeEventArgs(StateType.EXAMPLE2, new ExampleStateInfo()));
            fsm.MoveTo(StateType.EXAMPLE3, new FiniteStateChangeEventArgs(StateType.EXAMPLE3, new ExampleStateInfo()));
        }

        public void OnFiniteStateBegan(FiniteStateBeganEventArgs e) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[EventRequest::OnFiniteStateBegan()] -> " + "Began: " + e.Type);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void OnFiniteStateChange(FiniteStateChangeEventArgs e) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[EventRequest::OnFiniteStateChange()] -> " + "RequestedType: " + e.RequestedType + " - StateInfo: " + e.StateInfo);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void OnFiniteStateEnded(FiniteStateEndedEventArgs e) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[EventRequest::OnFiniteStateEnded()] -> " + "End: " + e.Type);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void SetupConsole() {

            #region GetAssemblyInformation

            var asm = Assembly.GetExecutingAssembly();
            var title = asm.GetCustomAttribute<AssemblyTitleAttribute>()?.Title;
            var version = asm.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
            var configuration = asm.GetCustomAttribute<AssemblyConfigurationAttribute>()?.Configuration;
            var informationalVersion = asm.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
            var copyright = asm.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright;

            //Display
            Console.WindowWidth = 140;
            Console.BufferHeight = 5000;
            Console.Title = string.Format("{0} {1} ({2}) [{3}] {4}",
                title,
                version,
                System.IO.File.GetLastWriteTime(asm.Location),
                string.IsNullOrEmpty(configuration) ? "Undefined" : string.Format("{0}", configuration),
                string.IsNullOrEmpty(informationalVersion) ? "" : string.Format("<{0}>", informationalVersion));

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(string.Format("Copyright (C) {0}", copyright));
            Console.ForegroundColor = ConsoleColor.White;

            #endregion GetAssemblyInformation
        }

    }
}
