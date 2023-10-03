// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.UtilityAI.Core;
using Action = Zor.UtilityAI.Core.Action;

namespace Zor.UtilityAI.Builder
{
	/// <summary>
	/// Generic <see cref="Action"/> builder.
	/// </summary>
	/// <typeparam name="TAction">Built <see cref="Action"/> type.</typeparam>
	internal sealed class ActionBuilder<TAction> : IActionBuilder where TAction : Action, INotSetupable, new()
	{
		/// <summary>
		/// <see cref="Action"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="name"><see cref="Action"/> name.</param>
		public ActionBuilder([NotNull] string name)
		{
			m_name = name;
		}

		public Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public Action Build()
		{
			var action = Action.Create<TAction>();
			action.name = m_name;
			return action;
		}

		public override string ToString()
		{
			return $"Serialized {actionType.FullName} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Action"/> builder.
	/// </summary>
	/// <typeparam name="TAction">Built <see cref="Action"/> type.</typeparam>
	/// <typeparam name="TArg">Setup method argument type.</typeparam>
	internal sealed class ActionBuilder<TAction, TArg> : IActionBuilder where TAction : Action, ISetupable<TArg>, new()
	{
		/// <summary>
		/// Setup method argument.
		/// </summary>
		[CanBeNull] private readonly TArg m_arg;

		/// <summary>
		/// <see cref="Action"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg">Setup method argument.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		public ActionBuilder([CanBeNull] TArg arg, [NotNull] string name)
		{
			m_arg = arg;

			m_name = name;
		}

		public Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public Action Build()
		{
			TAction action = Action.Create<TAction, TArg>(m_arg);
			action.name = m_name;
			return action;
		}

		public override string ToString()
		{
			return $"Serialized {actionType.FullName} {{{m_arg}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Action"/> builder.
	/// </summary>
	/// <typeparam name="TAction">Built <see cref="Action"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	internal sealed class ActionBuilder<TAction, TArg0, TArg1> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1>, new()
	{
		/// <summary>
		/// First argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg0 m_arg0;
		/// <summary>
		/// Second argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg1 m_arg1;

		/// <summary>
		/// <see cref="Action"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		public ActionBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;

			m_name = name;
		}

		public Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public Action Build()
		{
			TAction action = Action.Create<TAction, TArg0, TArg1>(m_arg0, m_arg1);
			action.name = m_name;
			return action;
		}

		public override string ToString()
		{
			return $"Serialized {actionType.FullName} {{{m_arg0}, {m_arg1}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Action"/> builder.
	/// </summary>
	/// <typeparam name="TAction">Built <see cref="Action"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2>, new()
	{
		/// <summary>
		/// First argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg0 m_arg0;
		/// <summary>
		/// Second argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg1 m_arg1;
		/// <summary>
		/// Third argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg2 m_arg2;

		/// <summary>
		/// <see cref="Action"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		public ActionBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2,
			[NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;

			m_name = name;
		}

		public Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public Action Build()
		{
			TAction action = Action.Create<TAction, TArg0, TArg1, TArg2>(m_arg0, m_arg1, m_arg2);
			action.name = m_name;
			return action;
		}

		public override string ToString()
		{
			return $"Serialized {actionType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Action"/> builder.
	/// </summary>
	/// <typeparam name="TAction">Built <see cref="Action"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
	/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
	{
		/// <summary>
		/// First argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg0 m_arg0;
		/// <summary>
		/// Second argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg1 m_arg1;
		/// <summary>
		/// Third argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg2 m_arg2;
		/// <summary>
		/// Fourth argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg3 m_arg3;

		/// <summary>
		/// <see cref="Action"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		public ActionBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3,
			[NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;

			m_name = name;
		}

		public Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public Action Build()
		{
			TAction action = Action.Create<TAction, TArg0, TArg1, TArg2, TArg3>(m_arg0, m_arg1, m_arg2, m_arg3);
			action.name = m_name;
			return action;
		}

		public override string ToString()
		{
			return $"Serialized {actionType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Action"/> builder.
	/// </summary>
	/// <typeparam name="TAction">Built <see cref="Action"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
	/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
	{
		/// <summary>
		/// First argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg0 m_arg0;
		/// <summary>
		/// Second argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg1 m_arg1;
		/// <summary>
		/// Third argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg2 m_arg2;
		/// <summary>
		/// Fourth argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg3 m_arg3;
		/// <summary>
		/// Fifth argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg4 m_arg4;

		/// <summary>
		/// <see cref="Action"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		public ActionBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4,
			[NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
			m_arg4 = arg4;

			m_name = name;
		}

		public Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public Action Build()
		{
			TAction action = Action.Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4>(m_arg0, m_arg1, m_arg2, m_arg3, m_arg4);
			action.name = m_name;
			return action;
		}

		public override string ToString()
		{
			return $"Serialized {actionType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}, {m_arg4}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Action"/> builder.
	/// </summary>
	/// <typeparam name="TAction">Built <see cref="Action"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
	/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
	{
		/// <summary>
		/// First argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg0 m_arg0;
		/// <summary>
		/// Second argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg1 m_arg1;
		/// <summary>
		/// Third argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg2 m_arg2;
		/// <summary>
		/// Fourth argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg3 m_arg3;
		/// <summary>
		/// Fifth argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg4 m_arg4;
		/// <summary>
		/// Sixth argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg5 m_arg5;

		/// <summary>
		/// <see cref="Action"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		public ActionBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5,
			[NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
			m_arg4 = arg4;
			m_arg5 = arg5;

			m_name = name;
		}

		public Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public Action Build()
		{
			TAction action = Action.Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(m_arg0, m_arg1, m_arg2, m_arg3, m_arg4, m_arg5);
			action.name = m_name;
			return action;
		}

		public override string ToString()
		{
			return $"Serialized {actionType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}, {m_arg4}, {m_arg5}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Action"/> builder.
	/// </summary>
	/// <typeparam name="TAction">Built <see cref="Action"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
	/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg6">Seventh argument in a setup method type.</typeparam>
	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
	{
		/// <summary>
		/// First argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg0 m_arg0;
		/// <summary>
		/// Second argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg1 m_arg1;
		/// <summary>
		/// Third argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg2 m_arg2;
		/// <summary>
		/// Fourth argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg3 m_arg3;
		/// <summary>
		/// Fifth argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg4 m_arg4;
		/// <summary>
		/// Sixth argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg5 m_arg5;
		/// <summary>
		/// Seventh argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg6 m_arg6;

		/// <summary>
		/// <see cref="Action"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <param name="arg6">Seventh argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		public ActionBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6,
			[NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
			m_arg4 = arg4;
			m_arg5 = arg5;
			m_arg6 = arg6;

			m_name = name;
		}

		public Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public Action Build()
		{
			TAction action = Action.Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(m_arg0, m_arg1, m_arg2, m_arg3, m_arg4, m_arg5, m_arg6);
			action.name = m_name;
			return action;
		}

		public override string ToString()
		{
			return $"Serialized {actionType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}, {m_arg4}, {m_arg5}, {m_arg6}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Action"/> builder.
	/// </summary>
	/// <typeparam name="TAction">Built <see cref="Action"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
	/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg6">Seventh argument in a setup method type.</typeparam>
	/// <typeparam name="TArg7">Eighth argument in a setup method type.</typeparam>
	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
	{
		/// <summary>
		/// First argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg0 m_arg0;
		/// <summary>
		/// Second argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg1 m_arg1;
		/// <summary>
		/// Third argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg2 m_arg2;
		/// <summary>
		/// Fourth argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg3 m_arg3;
		/// <summary>
		/// Fifth argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg4 m_arg4;
		/// <summary>
		/// Sixth argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg5 m_arg5;
		/// <summary>
		/// Seventh argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg6 m_arg6;
		/// <summary>
		/// Eighth argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg7 m_arg7;

		/// <summary>
		/// <see cref="Action"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <param name="arg6">Seventh argument in a setup method.</param>
		/// <param name="arg7">Eighth argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		public ActionBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6, [CanBeNull] TArg7 arg7,
			[NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
			m_arg4 = arg4;
			m_arg5 = arg5;
			m_arg6 = arg6;
			m_arg7 = arg7;

			m_name = name;
		}

		public Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public Action Build()
		{
			TAction action = Action.Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(m_arg0, m_arg1, m_arg2, m_arg3, m_arg4, m_arg5, m_arg6, m_arg7);
			action.name = m_name;
			return action;
		}

		public override string ToString()
		{
			return $"Serialized {actionType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}, {m_arg4}, {m_arg5}, {m_arg6}, {m_arg7}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Non-generic <see cref="Action"/> builder.
	/// </summary>
	internal sealed class ActionBuilder : IActionBuilder
	{
		/// <summary>
		/// Built <see cref="Action"/> type.
		/// </summary>
		[NotNull] private readonly Type m_actionType;
		/// <summary>
		/// Setup arguments.
		/// </summary>
		[CanBeNull] private readonly object[] m_parameters;

		/// <summary>
		/// <see cref="Action"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="actionType">Built <see cref="Action"/> type.</param>
		/// <param name="parameters">Setup arguments.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		public ActionBuilder([NotNull] Type actionType, [CanBeNull, ItemCanBeNull] object[] parameters,
			string name)
		{
			m_actionType = actionType;
			m_parameters = parameters;

			m_name = name;
		}

		public Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_actionType;
		}

		public Action Build()
		{
			Action action = m_parameters != null
				? Action.Create(m_actionType, m_parameters)
				: Action.Create(m_actionType);
			action.name = m_name;
			return action;
		}
	}
}
