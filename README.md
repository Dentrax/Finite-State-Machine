<h1 align="center">Finite State Machine Public Source Repository</h1>

[What It Is](#what-it-is)

[How To Use](#how-to-use)

[Requirements](#requirements)

[About](#about)  

[Collaborators](#collaborators)  

[Branches](#branches) 

[Copyright & Licensing](#copyright--licensing)  

[Contributing](#contributing)  

[Contact](#contact)

## What It Is

**Finite State Machine with .NET Core**

Finite State Machine guide for .NET Core language is an easy and advanced way to learn how algorithms works in theory.

**Uses : `.NET Core`** -> **[Official .NET Core](https://dotnet.github.io/)**

**Finite State Machine**

A finite-state machine, or FSM for short, is a model of computation based on a hypothetical machine made of one or more states. Only a single state can be active at the same time, so the machine must transition from one state to another in order to perform different actions.

FSMs are commonly used to organize and represent an execution flow, which is useful to implement AI in games. The "brain" of an enemy, for instance, can be implemented using a FSM.

![Preview Thumbnail](https://cdn.tutsplus.com/gamedev/uploads/2013/10/fsm_enemy_brain.png)

![Preview Thumbnail](http://www.i-programmer.info/images/stories/BabBag/FiniteState/fig2.PNG)

![Preview Thumbnail](https://praveenthomasln.files.wordpress.com/2012/04/figure-1-state-machines.png)

![Preview Thumbnail](https://cdn.tutsplus.com/gamedev/uploads/2013/12/fsm_steering_enemy_brain.png)

Reference: https://gamedevelopment.tutsplus.com/tutorials/finite-state-machines-theory-and-implementation--gamedev-11867

**Who is the target audience?**

This course is meant for anyone who wants to learn Finite State Machine algorithm and theory in C#. The examples are made with C# using .NET Core.

* Warning : This course assumes you have some C# knowledge, and `does not teach C# itself.`

* Warning : These example tutorials are not a "How to make State Machine" or "How State Machines works" and will not teach "State Machine techniques"

## How To Use

Example Usage
--------------------------

![Preview Thumbnail](https://raw.githubusercontent.com/Dentrax/Finite-State-Machine/master/images/console.png)

`StateType` -> Main states (like Booting, Launching, Initializing, etc.)

Classes
--------------------------

| Class			| Access Modifier   | Explanation																|
| ------------- |:-----------------:|:-------------------------------------------------------------------------:|
| `StateBase`	| Abstract		    | Main state base. When creating a new state, you need to inheritance this	|
| `StateInfo`	| Abstract		    | Use this to move information between states. But not mandatory			|


StateBase
--------------------------

| Function	|  Access Modifier  | Explanation                                                   |
| --------- |:-----------------:|:-------------------------------------------------------------:|
| `Begin`	| Public Override   | Trigger when a state is initializing           	            |
| `Load`    | Public Override   | Need to call manually, after state was initialized            |
| `Update`	| Public Override   | Need to call manually, if you want the update with deltaTime	|
| `End`	    | Public Override   | Trigger when a state is terminating                           |

Events
--------------------------

| Event			                |  Type  | Explanation                                      |
| ----------------------------- |:------:|:------------------------------------------------:|
| `FiniteStateBeganEventArgs`	| Action | Trigger when a state is initialized with Begin()	|
| `FiniteStateChangeEventArgs`  | Action | Trigger when a state is changed to another	    |
| `FiniteStateEndedEventArgs`	| Action | Trigger when a state is terminated with End()	|

State Machine
--------------------------

| Function		|  Args              | Explanation                              |
| ------------- |:------------------:|:----------------------------------------:|
| `Initialize`  | -                  | Initialize the FSM	                    |
| `AddState`	| -                  | Add a State to FSM	                    |
| `MoveTo`      | StateType, OnEvent | Change the current State to given State  |

Example State
--------------------------

```csharp

public sealed class ExampleState : StateBase {

    public ExampleState(FiniteStateMachine fsm, StateType stateKey) : base(fsm, stateKey) {
        //Your Constructor() codes
    }

    public override void Begin(FiniteStateChangeEventArgs eventArgs, StateType previousStateKey) {
        //Your Begin() codes 
    }

    public override void End() {
        //Your End() codes
    }

    public override void Load() {
        //Your Load() codes
    }

    public override void Update(float deltaTime) {
        //Your Update() codes
    }
}

```

Example StateInfo
--------------------------

```csharp

public sealed class ExampleStateInfo : StateInfo {

    //Your variables, events, functions, etc.

    public override string ToString() {
        //Example ToString()
    }
}

```

Example Usage
--------------------------

```csharp

FiniteStateMachine.Instance.Initialize();
FiniteStateMachine.Instance.AddState(new Example1State(FiniteStateMachine.Instance, StateType.EXAMPLE1));
FiniteStateMachine.Instance.AddState(new Example2State(FiniteStateMachine.Instance, StateType.EXAMPLE2));
FiniteStateMachine.Instance.AddState(new Example3State(FiniteStateMachine.Instance, StateType.EXAMPLE3));


FiniteStateMachine.Instance.MoveTo(StateType.EXAMPLE1, new FiniteStateChangeEventArgs(StateType.EXAMPLE1, new ExampleStateInfo()));
FiniteStateMachine.Instance.MoveTo(StateType.EXAMPLE2, new FiniteStateChangeEventArgs(StateType.EXAMPLE2, new ExampleStateInfo()));
FiniteStateMachine.Instance.MoveTo(StateType.EXAMPLE3, new FiniteStateChangeEventArgs(StateType.EXAMPLE3, new ExampleStateInfo()));

```

Example Event Handling
--------------------------

```csharp

FiniteStateMachine.Instance.OnStateBegan += new Action<FiniteStateBeganEventArgs>(this.OnFiniteStateBegan);
FiniteStateMachine.Instance.OnStateEnded += new Action<FiniteStateEndedEventArgs>(this.OnFiniteStateEnded);
FiniteStateMachine.Instance.OnStateChange += new Action<FiniteStateChangeEventArgs>(this.OnFiniteStateChange);

public void OnFiniteStateBegan(FiniteStateBeganEventArgs e) {
    //Trigger when OnFiniteStateBegan
    //Began: e.Type
}

public void OnFiniteStateChange(FiniteStateChangeEventArgs e) {
    //Trigger when OnFiniteStateChange
    //RequestedType: e.RequestedType
    //StateInfo: e.StateInfo (Returns null, if no parameters are given)
}

public void OnFiniteStateEnded(FiniteStateEndedEventArgs e) {
    //Trigger when OnFiniteStateEnded
    //End: e.Type
}

```


## Requirements

* You should be familiar with .NET Core family
* You will need a text editor (like VSCode) or IDE (Visual Studio)
* You will need a computer on which you have the rights to install .NET Core

## About

Finite State Machine was created to serve three purposes:

**Finite State Machine is a basically State Machine learning repository which base state-machine library coded in C# language**

1. To act as a guide to learn Finite State Machine with enhanced and rich content using `.NET Core`.

2. To act as a guide to exemplary and educational purpose.

3. To create an advanced State-Machine with few lines.

## Collaborators

**Project Manager** - Furkan Türkal (GitHub: **[dentrax](https://github.com/dentrax)**)

## Branches

We publish source for the **[Finite-State-Machine]** in single rolling branch:

The **[master branch](https://github.com/dentrax/Finite-State-Machine/tree/master)** is extensively tested by our QA team and makes a great starting point for learning the algorithms. Also tracks [live changes](https://github.com/dentrax/Finite-State-Machine/commits/master) by our team. 

## Copyright & Licensing

The base project code is copyrighted by Furkan 'Dentrax' Türkal and is covered by single licence.

All program code (i.e. C#) is licensed under MIT License unless otherwise specified. Please see the **[LICENSE.md](https://github.com/Dentrax/Finite-State-Machine/blob/master/LICENSE)** file for more information.

**References**

While this repository is being prepared, it may have been quoted from some sources. 
If there is an unspecified source, please contact me.

## Contributing

Please check the [CONTRIBUTING.md](CONTRIBUTING.md) file for contribution instructions and naming guidelines.

## Contact

Finite-State-Machine was created by Furkan 'Dentrax' Türkal

 * <https://www.furkanturkal.com>
 
You can contact by URL:
    **[CONTACT](https://github.com/dentrax)**

<kbd>Best Regards</kbd>