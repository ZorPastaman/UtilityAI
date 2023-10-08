// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine.Profiling;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core
{
	/// <summary>
	/// Utility AI action.
	/// </summary>
	public abstract class Action
	{
		/// <summary>
		/// Used <see cref="Blackboard"/>. Set via <see cref="Brain"/>.
		/// </summary>
		private Blackboard m_blackboard;

		/// <summary>
		/// Action's name. It's used for debugging mainly.
		/// </summary>
		public string name { get; set; }

		/// <summary>
		/// Used <see cref="Blackboard"/>. Set via <see cref="Brain"/>.
		/// </summary>
		[NotNull]
		protected Blackboard blackboard
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_blackboard;
		}

		/// <summary>
		/// The method is called once before a first tick of <see cref="Brain"/>.
		/// It's called for all actions even if they're inactive.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual void OnInitialize() {}

		/// <summary>
		/// The method is called when the action becomes active.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual void OnBegin() {}

		/// <summary>
		/// The method is called each tick of <see cref="Brain"/> if the action is active.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual void OnTick() {}

		/// <summary>
		/// The method is called when the action becomes inactive.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual void OnEnd() {}

		/// <summary>
		/// The method is called when <see cref="Brain"/> is disposed.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected virtual void OnDispose() {}

		/// <summary>
		/// Initializes an action.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Initialize()
		{
			Profiler.BeginSample(GetType().FullName);

			OnInitialize();

			Profiler.EndSample();
		}

		/// <summary>
		/// Begins an action.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Begin()
		{
			Profiler.BeginSample("Action.Begin");
			Profiler.BeginSample(GetType().FullName);

			OnBegin();

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Ticks an action.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Tick()
		{
			Profiler.BeginSample("Action.Tick");
			Profiler.BeginSample(GetType().FullName);

			OnTick();

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Ends an action.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void End()
		{
			Profiler.BeginSample("Action.End");
			Profiler.BeginSample(GetType().FullName);

			OnEnd();

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Disposes an action.
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Dispose()
		{
			Profiler.BeginSample(GetType().FullName);

			OnDispose();

			Profiler.EndSample();
		}

		/// <summary>
		/// Sets <see cref="Blackboard"/> into an action.
		/// </summary>
		/// <param name="blackboardToSet"><see cref="Blackboard"/> to set.</param>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void SetBlackboard([NotNull] Blackboard blackboardToSet)
		{
			m_blackboard = blackboardToSet;
		}

		/// <summary>
		/// Creates an action.
		/// </summary>
		/// <typeparam name="TAction">Action type.</typeparam>
		/// <returns>Created action.</returns>
		[NotNull]
		public static TAction Create<TAction>() where TAction : Action, INotSetupable, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		/// <summary>
		/// Creates an action.
		/// </summary>
		/// <param name="arg">Argument in a setup method.</param>
		/// <typeparam name="TAction">Action type.</typeparam>
		/// <typeparam name="TArg">Argument in a setup method type.</typeparam>
		/// <returns>Created action</returns>
		[NotNull]
		public static TAction Create<TAction, TArg>([CanBeNull] TArg arg) where TAction : Action, ISetupable<TArg>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();

			Profiler.BeginSample("Setup");
			action.Setup(arg);
			Profiler.EndSample();

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		/// <summary>
		/// Creates an action.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <typeparam name="TAction"></typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <returns>Created action.</returns>
		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1)
			where TAction : Action, ISetupable<TArg0, TArg1>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();

			Profiler.BeginSample("Setup");
			action.Setup(arg0, arg1);
			Profiler.EndSample();

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		/// <summary>
		/// Creates an action.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <typeparam name="TAction"></typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <returns>Created action.</returns>
		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();

			Profiler.BeginSample("Setup");
			action.Setup(arg0, arg1, arg2);
			Profiler.EndSample();

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		/// <summary>
		/// Creates an action.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <typeparam name="TAction"></typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <returns>Created action.</returns>
		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();

			Profiler.BeginSample("Setup");
			action.Setup(arg0, arg1, arg2, arg3);
			Profiler.EndSample();

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		/// <summary>
		/// Creates an action.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <typeparam name="TAction"></typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
		/// <returns>Created action.</returns>
		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();

			Profiler.BeginSample("Setup");
			action.Setup(arg0, arg1, arg2, arg3, arg4);
			Profiler.EndSample();

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		/// <summary>
		/// Creates an action.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <typeparam name="TAction"></typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
		/// <returns>Created action.</returns>
		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();

			Profiler.BeginSample("Setup");
			action.Setup(arg0, arg1, arg2, arg3, arg4, arg5);
			Profiler.EndSample();

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		/// <summary>
		/// Creates an action.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <param name="arg6">Seventh argument in a setup method.</param>
		/// <typeparam name="TAction"></typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg6">Seventh argument in a setup method type.</typeparam>
		/// <returns>Created action.</returns>
		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();

			Profiler.BeginSample("Setup");
			action.Setup(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
			Profiler.EndSample();

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		/// <summary>
		/// Creates an action.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <param name="arg6">Seventh argument in a setup method.</param>
		/// <param name="arg7">Eighth argument in a setup method.</param>
		/// <typeparam name="TAction"></typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg6">Seventh argument in a setup method type.</typeparam>
		/// <typeparam name="TArg7">Eighth argument in a setup method type.</typeparam>
		/// <returns>Created action.</returns>
		[NotNull]
		public static TAction Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6, [CanBeNull] TArg7 arg7)
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(typeof(TAction).FullName);

			var action = new TAction();

			Profiler.BeginSample("Setup");
			action.Setup(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7);
			Profiler.EndSample();

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		/// <summary>
		/// Creates an action.
		/// </summary>
		/// <param name="type">Action type. Must be derived from <see cref="Action"/>.</param>
		/// <returns>Created action.</returns>
		/// <remarks>
		/// This method doesn't call a setup method.
		/// </remarks>
		[NotNull]
		public static Action Create([NotNull] Type type)
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(type.FullName);

			var action = (Action)Activator.CreateInstance(type);

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}

		/// <summary>
		/// Creates an action.
		/// </summary>
		/// <param name="type">Action type. Must be derived from <see cref="Action"/>.</param>
		/// <param name="parameters">Setup method arguments. Must be up to 8 in length.</param>
		/// <returns>Created action.</returns>
		[NotNull]
		public static Action Create([NotNull] Type type, [NotNull, ItemCanBeNull] params object[] parameters)
		{
			Profiler.BeginSample("Action.Create");
			Profiler.BeginSample(type.FullName);

			var action = (Action)Activator.CreateInstance(type);
			SetupableHelper.CreateSetup(action, parameters);

			Profiler.EndSample();
			Profiler.EndSample();

			return action;
		}
	}
}
