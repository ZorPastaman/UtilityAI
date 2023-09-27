// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.UtilityAI.Core;
using Action = Zor.UtilityAI.Core.Action;

namespace Zor.UtilityAI.Builder
{
	internal sealed class ActionBuilder<TAction> : IActionBuilder where TAction : Action, INotSetupable, new()
	{
		[NotNull] private readonly string m_name;

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

	internal sealed class ActionBuilder<TAction, TArg> : IActionBuilder where TAction : Action, ISetupable<TArg>, new()
	{
		[CanBeNull] private readonly TArg m_arg;

		[NotNull] private readonly string m_name;

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

	internal sealed class ActionBuilder<TAction, TArg0, TArg1> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1>, new()
	{
		[CanBeNull] private readonly TArg0 m_arg0;
		[CanBeNull] private readonly TArg1 m_arg1;

		[NotNull] private readonly string m_name;

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

	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2>, new()
	{
		[CanBeNull] private readonly TArg0 m_arg0;
		[CanBeNull] private readonly TArg1 m_arg1;
		[CanBeNull] private readonly TArg2 m_arg2;

		[NotNull] private readonly string m_name;

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

	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
	{
		[CanBeNull] private readonly TArg0 m_arg0;
		[CanBeNull] private readonly TArg1 m_arg1;
		[CanBeNull] private readonly TArg2 m_arg2;
		[CanBeNull] private readonly TArg3 m_arg3;

		[NotNull] private readonly string m_name;

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

	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
	{
		[CanBeNull] private readonly TArg0 m_arg0;
		[CanBeNull] private readonly TArg1 m_arg1;
		[CanBeNull] private readonly TArg2 m_arg2;
		[CanBeNull] private readonly TArg3 m_arg3;
		[CanBeNull] private readonly TArg4 m_arg4;

		[NotNull] private readonly string m_name;

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

	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
	{
		[CanBeNull] private readonly TArg0 m_arg0;
		[CanBeNull] private readonly TArg1 m_arg1;
		[CanBeNull] private readonly TArg2 m_arg2;
		[CanBeNull] private readonly TArg3 m_arg3;
		[CanBeNull] private readonly TArg4 m_arg4;
		[CanBeNull] private readonly TArg5 m_arg5;

		[NotNull] private readonly string m_name;

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

	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
	{
		[CanBeNull] private readonly TArg0 m_arg0;
		[CanBeNull] private readonly TArg1 m_arg1;
		[CanBeNull] private readonly TArg2 m_arg2;
		[CanBeNull] private readonly TArg3 m_arg3;
		[CanBeNull] private readonly TArg4 m_arg4;
		[CanBeNull] private readonly TArg5 m_arg5;
		[CanBeNull] private readonly TArg6 m_arg6;

		[NotNull] private readonly string m_name;

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

	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
	{
		[CanBeNull] private readonly TArg0 m_arg0;
		[CanBeNull] private readonly TArg1 m_arg1;
		[CanBeNull] private readonly TArg2 m_arg2;
		[CanBeNull] private readonly TArg3 m_arg3;
		[CanBeNull] private readonly TArg4 m_arg4;
		[CanBeNull] private readonly TArg5 m_arg5;
		[CanBeNull] private readonly TArg6 m_arg6;
		[CanBeNull] private readonly TArg7 m_arg7;

		[NotNull] private readonly string m_name;

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
}
