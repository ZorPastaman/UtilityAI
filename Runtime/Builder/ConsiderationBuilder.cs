// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Builder
{
	internal sealed class ConsiderationBuilder<TConsideration> : IConsiderationBuilder
		where TConsideration : Consideration, INotSetupable, new()
	{
		[NotNull] private readonly string m_name;

		public ConsiderationBuilder([NotNull] string name)
		{
			m_name = name;
		}

		public Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public Consideration Build()
		{
			var consideration = Consideration.Create<TConsideration>();
			consideration.name = m_name;
			return consideration;
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} \"{m_name}\"";
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg>, new()
	{
		[CanBeNull] private readonly TArg m_arg;

		[NotNull] private readonly string m_name;

		public ConsiderationBuilder([CanBeNull] TArg arg, [NotNull] string name)
		{
			m_arg = arg;

			m_name = name;
		}

		[CanBeNull]
		public TArg arg
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg;
		}

		public Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public Consideration Build()
		{
			TConsideration consideration = Consideration.Create<TConsideration, TArg>(m_arg);
			consideration.name = m_name;
			return consideration;
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg}}} \"{m_name}\"";
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1>, new()
	{
		[CanBeNull] private readonly TArg0 m_arg0;
		[CanBeNull] private readonly TArg1 m_arg1;

		[NotNull] private readonly string m_name;

		public ConsiderationBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;

			m_name = name;
		}

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		public Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public Consideration Build()
		{
			TConsideration consideration = Consideration.Create<TConsideration, TArg0, TArg1>(m_arg0, m_arg1);
			consideration.name = m_name;
			return consideration;
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}}} \"{m_name}\"";
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2>, new()
	{
		[CanBeNull] private readonly TArg0 m_arg0;
		[CanBeNull] private readonly TArg1 m_arg1;
		[CanBeNull] private readonly TArg2 m_arg2;

		[NotNull] private readonly string m_name;

		public ConsiderationBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2,
			[NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;

			m_name = name;
		}

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		[CanBeNull]
		public TArg2 arg2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg2;
		}

		public Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public Consideration Build()
		{
			TConsideration consideration = Consideration.Create<TConsideration, TArg0, TArg1, TArg2>(m_arg0, m_arg1, m_arg2);
			consideration.name = m_name;
			return consideration;
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}}} \"{m_name}\"";
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
	{
		[CanBeNull] private readonly TArg0 m_arg0;
		[CanBeNull] private readonly TArg1 m_arg1;
		[CanBeNull] private readonly TArg2 m_arg2;
		[CanBeNull] private readonly TArg3 m_arg3;

		[NotNull] private readonly string m_name;

		public ConsiderationBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3,
			[NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;

			m_name = name;
		}

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		[CanBeNull]
		public TArg2 arg2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg2;
		}

		[CanBeNull]
		public TArg3 arg3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg3;
		}

		public Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public Consideration Build()
		{
			TConsideration consideration = Consideration.Create<TConsideration, TArg0, TArg1, TArg2, TArg3>(m_arg0, m_arg1, m_arg2, m_arg3);
			consideration.name = m_name;
			return consideration;
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}}} \"{m_name}\"";
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
	{
		[CanBeNull] private readonly TArg0 m_arg0;
		[CanBeNull] private readonly TArg1 m_arg1;
		[CanBeNull] private readonly TArg2 m_arg2;
		[CanBeNull] private readonly TArg3 m_arg3;
		[CanBeNull] private readonly TArg4 m_arg4;

		[NotNull] private readonly string m_name;

		public ConsiderationBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4,
			[NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
			m_arg4 = arg4;

			m_name = name;
		}

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		[CanBeNull]
		public TArg2 arg2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg2;
		}

		[CanBeNull]
		public TArg3 arg3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg3;
		}

		[CanBeNull]
		public TArg4 arg4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg4;
		}

		public Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public Consideration Build()
		{
			TConsideration consideration = Consideration.Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4>(m_arg0, m_arg1, m_arg2, m_arg3, m_arg4);
			consideration.name = m_name;
			return consideration;
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}, {m_arg4}}} \"{m_name}\"";
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
	{
		[CanBeNull] private readonly TArg0 m_arg0;
		[CanBeNull] private readonly TArg1 m_arg1;
		[CanBeNull] private readonly TArg2 m_arg2;
		[CanBeNull] private readonly TArg3 m_arg3;
		[CanBeNull] private readonly TArg4 m_arg4;
		[CanBeNull] private readonly TArg5 m_arg5;

		[NotNull] private readonly string m_name;

		public ConsiderationBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5,
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

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		[CanBeNull]
		public TArg2 arg2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg2;
		}

		[CanBeNull]
		public TArg3 arg3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg3;
		}

		[CanBeNull]
		public TArg4 arg4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg4;
		}

		[CanBeNull]
		public TArg5 arg5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg5;
		}

		public Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public Consideration Build()
		{
			TConsideration consideration = Consideration.Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(m_arg0, m_arg1, m_arg2, m_arg3, m_arg4, m_arg5);
			consideration.name = m_name;
			return consideration;
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}, {m_arg4}, {m_arg5}}} \"{m_name}\"";
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
	{
		[CanBeNull] private readonly TArg0 m_arg0;
		[CanBeNull] private readonly TArg1 m_arg1;
		[CanBeNull] private readonly TArg2 m_arg2;
		[CanBeNull] private readonly TArg3 m_arg3;
		[CanBeNull] private readonly TArg4 m_arg4;
		[CanBeNull] private readonly TArg5 m_arg5;
		[CanBeNull] private readonly TArg6 m_arg6;

		[NotNull] private readonly string m_name;

		public ConsiderationBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6,
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

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		[CanBeNull]
		public TArg2 arg2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg2;
		}

		[CanBeNull]
		public TArg3 arg3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg3;
		}

		[CanBeNull]
		public TArg4 arg4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg4;
		}

		[CanBeNull]
		public TArg5 arg5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg5;
		}

		[CanBeNull]
		public TArg6 arg6
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg6;
		}

		public Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public Consideration Build()
		{
			TConsideration consideration = Consideration.Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(m_arg0, m_arg1, m_arg2, m_arg3, m_arg4, m_arg5, m_arg6);
			consideration.name = m_name;
			return consideration;
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}, {m_arg4}, {m_arg5}, {m_arg6}}} \"{m_name}\"";
		}
	}

	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
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

		public ConsiderationBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6, [CanBeNull] TArg7 arg7,
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

		[CanBeNull]
		public TArg0 arg0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg0;
		}

		[CanBeNull]
		public TArg1 arg1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg1;
		}

		[CanBeNull]
		public TArg2 arg2
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg2;
		}

		[CanBeNull]
		public TArg3 arg3
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg3;
		}

		[CanBeNull]
		public TArg4 arg4
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg4;
		}

		[CanBeNull]
		public TArg5 arg5
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg5;
		}

		[CanBeNull]
		public TArg6 arg6
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg6;
		}

		[CanBeNull]
		public TArg7 arg7
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_arg7;
		}

		public Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => typeof(TConsideration);
		}

		public Consideration Build()
		{
			TConsideration consideration = Consideration.Create<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(m_arg0, m_arg1, m_arg2, m_arg3, m_arg4, m_arg5, m_arg6, m_arg7);
			consideration.name = m_name;
			return consideration;
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}, {m_arg4}, {m_arg5}, {m_arg6}, {m_arg7}}} \"{m_name}\"";
		}
	}
}
