// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.UtilityAI.Builder;
using Zor.UtilityAI.Core;
using Zor.UtilityAI.DrawingAttributes;
using Action = Zor.UtilityAI.Core.Action;

namespace Zor.UtilityAI.Serialization.SerializedActions
{
	public abstract class SerializedAction<TAction> : SerializedAction_Base where TAction : Action, INotSetupable, new()
	{
		public sealed override Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public sealed override void AddAction(BrainBuilder builder)
		{
			builder.AddAction<TAction>(name);
		}
	}

	public abstract class SerializedAction<TAction, TArg> : SerializedAction_Base
		where TAction : Action, ISetupable<TArg>, new()
	{
		[SerializeField, NameOverriden(0)] private TArg m_Arg;

		public sealed override Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public sealed override void AddAction(BrainBuilder builder)
		{
			builder.AddAction<TAction, TArg>(m_Arg, name);
		}
	}

	public abstract class SerializedAction<TAction, TArg0, TArg1> : SerializedAction_Base
		where TAction : Action, ISetupable<TArg0, TArg1>, new()
	{
		[SerializeField, NameOverriden(0)] private TArg0 m_Arg0;
		[SerializeField, NameOverriden(1)] private TArg1 m_Arg1;

		public sealed override Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public sealed override void AddAction(BrainBuilder builder)
		{
			builder.AddAction<TAction, TArg0, TArg1>(m_Arg0, m_Arg1, name);
		}
	}

	public abstract class SerializedAction<TAction, TArg0, TArg1, TArg2> : SerializedAction_Base
		where TAction : Action, ISetupable<TArg0, TArg1, TArg2>, new()
	{
		[SerializeField, NameOverriden(0)] private TArg0 m_Arg0;
		[SerializeField, NameOverriden(1)] private TArg1 m_Arg1;
		[SerializeField, NameOverriden(2)] private TArg2 m_Arg2;

		public sealed override Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public sealed override void AddAction(BrainBuilder builder)
		{
			builder.AddAction<TAction, TArg0, TArg1, TArg2>(m_Arg0, m_Arg1, m_Arg2, name);
		}
	}

	public abstract class SerializedAction<TAction, TArg0, TArg1, TArg2, TArg3> : SerializedAction_Base
		where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
	{
		[SerializeField, NameOverriden(0)] private TArg0 m_Arg0;
		[SerializeField, NameOverriden(1)] private TArg1 m_Arg1;
		[SerializeField, NameOverriden(2)] private TArg2 m_Arg2;
		[SerializeField, NameOverriden(3)] private TArg3 m_Arg3;

		public sealed override Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public sealed override void AddAction(BrainBuilder builder)
		{
			builder.AddAction<TAction, TArg0, TArg1, TArg2, TArg3>(m_Arg0, m_Arg1, m_Arg2, m_Arg3, name);
		}
	}

	public abstract class SerializedAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4> : SerializedAction_Base
		where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
	{
		[SerializeField, NameOverriden(0)] private TArg0 m_Arg0;
		[SerializeField, NameOverriden(1)] private TArg1 m_Arg1;
		[SerializeField, NameOverriden(2)] private TArg2 m_Arg2;
		[SerializeField, NameOverriden(3)] private TArg3 m_Arg3;
		[SerializeField, NameOverriden(4)] private TArg4 m_Arg4;

		public sealed override Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public sealed override void AddAction(BrainBuilder builder)
		{
			builder.AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4>(m_Arg0, m_Arg1, m_Arg2, m_Arg3, m_Arg4, name);
		}
	}

	public abstract class SerializedAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> : SerializedAction_Base
		where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
	{
		[SerializeField, NameOverriden(0)] private TArg0 m_Arg0;
		[SerializeField, NameOverriden(1)] private TArg1 m_Arg1;
		[SerializeField, NameOverriden(2)] private TArg2 m_Arg2;
		[SerializeField, NameOverriden(3)] private TArg3 m_Arg3;
		[SerializeField, NameOverriden(4)] private TArg4 m_Arg4;
		[SerializeField, NameOverriden(5)] private TArg5 m_Arg5;

		public sealed override Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public sealed override void AddAction(BrainBuilder builder)
		{
			builder.AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(m_Arg0, m_Arg1, m_Arg2, m_Arg3, m_Arg4, m_Arg5, name);
		}
	}

	public abstract class SerializedAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : SerializedAction_Base
		where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
	{
		[SerializeField, NameOverriden(0)] private TArg0 m_Arg0;
		[SerializeField, NameOverriden(1)] private TArg1 m_Arg1;
		[SerializeField, NameOverriden(2)] private TArg2 m_Arg2;
		[SerializeField, NameOverriden(3)] private TArg3 m_Arg3;
		[SerializeField, NameOverriden(4)] private TArg4 m_Arg4;
		[SerializeField, NameOverriden(5)] private TArg5 m_Arg5;
		[SerializeField, NameOverriden(6)] private TArg6 m_Arg6;

		public sealed override Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public sealed override void AddAction(BrainBuilder builder)
		{
			builder.AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(m_Arg0, m_Arg1, m_Arg2, m_Arg3, m_Arg4, m_Arg5, m_Arg6, name);
		}
	}

	public abstract class SerializedAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : SerializedAction_Base
		where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
	{
		[SerializeField, NameOverriden(0)] private TArg0 m_Arg0;
		[SerializeField, NameOverriden(1)] private TArg1 m_Arg1;
		[SerializeField, NameOverriden(2)] private TArg2 m_Arg2;
		[SerializeField, NameOverriden(3)] private TArg3 m_Arg3;
		[SerializeField, NameOverriden(4)] private TArg4 m_Arg4;
		[SerializeField, NameOverriden(5)] private TArg5 m_Arg5;
		[SerializeField, NameOverriden(6)] private TArg6 m_Arg6;
		[SerializeField, NameOverriden(7)] private TArg7 m_Arg7;

		public sealed override Type actionType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TAction);
		}

		public sealed override void AddAction(BrainBuilder builder)
		{
			builder.AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(m_Arg0, m_Arg1, m_Arg2, m_Arg3, m_Arg4, m_Arg5, m_Arg6, m_Arg7, name);
		}
	}
}
