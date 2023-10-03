// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Builder
{
	/// <summary>
	/// Generic <see cref="Consideration"/> builder.
	/// </summary>
	/// <typeparam name="TConsideration">Built <see cref="Consideration"/> type.</typeparam>
	internal sealed class ConsiderationBuilder<TConsideration> : IConsiderationBuilder
		where TConsideration : Consideration, INotSetupable, new()
	{
		/// <summary>
		/// <see cref="Consideration"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="name"><see cref="Consideration"/> name.</param>
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

		public bool AreEqual(object[] parameters)
		{
			return parameters == null || parameters.Length == 0;
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Consideration"/> builder.
	/// </summary>
	/// <typeparam name="TConsideration">Built <see cref="Consideration"/> type.</typeparam>
	/// <typeparam name="TArg">Argument in a setup method type.</typeparam>
	internal sealed class ConsiderationBuilder<TConsideration, TArg> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg>, new()
	{
		/// <summary>
		/// Argument in a setup method.
		/// </summary>
		[CanBeNull] private readonly TArg m_arg;

		/// <summary>
		/// <see cref="Consideration"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg">Argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		public ConsiderationBuilder([CanBeNull] TArg arg, [NotNull] string name)
		{
			m_arg = arg;

			m_name = name;
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

		public bool AreEqual([CanBeNull] TArg arg)
		{
			return EqualityComparer<TArg>.Default.Equals(m_arg, arg);
		}

		public bool AreEqual(object[] parameters)
		{
			if (parameters == null)
			{
				return false;
			}

			return m_arg == null ? parameters[0] == null : parameters[0] is TArg parameter && EqualityComparer<TArg>.Default.Equals(m_arg, parameter);
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Consideration"/> builder.
	/// </summary>
	/// <typeparam name="TConsideration">Built <see cref="Consideration"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1>, new()
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
		/// <see cref="Consideration"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		public ConsiderationBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;

			m_name = name;
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

		public bool AreEqual([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1)
		{
			return EqualityComparer<TArg0>.Default.Equals(m_arg0, arg0) &&
				EqualityComparer<TArg1>.Default.Equals(m_arg1, arg1);
		}

		public bool AreEqual(object[] parameters)
		{
			if (parameters == null)
			{
				return false;
			}

			return m_arg0 == null ? parameters[0] == null : parameters[0] is TArg0 parameter0 && EqualityComparer<TArg0>.Default.Equals(m_arg0, parameter0) &&
				m_arg1 == null ? parameters[1] == null : parameters[1] is TArg1 parameter1 && EqualityComparer<TArg1>.Default.Equals(m_arg1, parameter1);
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Consideration"/> builder.
	/// </summary>
	/// <typeparam name="TConsideration">Built <see cref="Consideration"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2>, new()
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
		/// <see cref="Consideration"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		public ConsiderationBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2,
			[NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;

			m_name = name;
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

		public bool AreEqual([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2)
		{
			return EqualityComparer<TArg0>.Default.Equals(m_arg0, arg0) &&
				EqualityComparer<TArg1>.Default.Equals(m_arg1, arg1) &&
				EqualityComparer<TArg2>.Default.Equals(m_arg2, arg2);
		}

		public bool AreEqual(object[] parameters)
		{
			if (parameters == null)
			{
				return false;
			}

			return m_arg0 == null ? parameters[0] == null : parameters[0] is TArg0 parameter0 && EqualityComparer<TArg0>.Default.Equals(m_arg0, parameter0) &&
				m_arg1 == null ? parameters[1] == null : parameters[1] is TArg1 parameter1 && EqualityComparer<TArg1>.Default.Equals(m_arg1, parameter1) &&
				m_arg2 == null ? parameters[2] == null : parameters[2] is TArg2 parameter2 && EqualityComparer<TArg2>.Default.Equals(m_arg2, parameter2);
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Consideration"/> builder.
	/// </summary>
	/// <typeparam name="TConsideration">Built <see cref="Consideration"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
	/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
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
		/// <see cref="Consideration"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		public ConsiderationBuilder([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3,
			[NotNull] string name)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;

			m_name = name;
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

		public bool AreEqual([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3)
		{
			return EqualityComparer<TArg0>.Default.Equals(m_arg0, arg0) &&
				EqualityComparer<TArg1>.Default.Equals(m_arg1, arg1) &&
				EqualityComparer<TArg2>.Default.Equals(m_arg2, arg2) &&
				EqualityComparer<TArg3>.Default.Equals(m_arg3, arg3);
		}

		public bool AreEqual(object[] parameters)
		{
			if (parameters == null)
			{
				return false;
			}

			return m_arg0 == null ? parameters[0] == null : parameters[0] is TArg0 parameter0 && EqualityComparer<TArg0>.Default.Equals(m_arg0, parameter0) &&
				m_arg1 == null ? parameters[1] == null : parameters[1] is TArg1 parameter1 && EqualityComparer<TArg1>.Default.Equals(m_arg1, parameter1) &&
				m_arg2 == null ? parameters[2] == null : parameters[2] is TArg2 parameter2 && EqualityComparer<TArg2>.Default.Equals(m_arg2, parameter2) &&
				m_arg3 == null ? parameters[3] == null : parameters[3] is TArg3 parameter3 && EqualityComparer<TArg3>.Default.Equals(m_arg3, parameter3);
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Consideration"/> builder.
	/// </summary>
	/// <typeparam name="TConsideration">Built <see cref="Consideration"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
	/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
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
		/// <see cref="Consideration"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
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

		public bool AreEqual([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4)
		{
			return EqualityComparer<TArg0>.Default.Equals(m_arg0, arg0) &&
				EqualityComparer<TArg1>.Default.Equals(m_arg1, arg1) &&
				EqualityComparer<TArg2>.Default.Equals(m_arg2, arg2) &&
				EqualityComparer<TArg3>.Default.Equals(m_arg3, arg3) &&
				EqualityComparer<TArg4>.Default.Equals(m_arg4, arg4);
		}

		public bool AreEqual(object[] parameters)
		{
			if (parameters == null)
			{
				return false;
			}

			return m_arg0 == null ? parameters[0] == null : parameters[0] is TArg0 parameter0 && EqualityComparer<TArg0>.Default.Equals(m_arg0, parameter0) &&
				m_arg1 == null ? parameters[1] == null : parameters[1] is TArg1 parameter1 && EqualityComparer<TArg1>.Default.Equals(m_arg1, parameter1) &&
				m_arg2 == null ? parameters[2] == null : parameters[2] is TArg2 parameter2 && EqualityComparer<TArg2>.Default.Equals(m_arg2, parameter2) &&
				m_arg3 == null ? parameters[3] == null : parameters[3] is TArg3 parameter3 && EqualityComparer<TArg3>.Default.Equals(m_arg3, parameter3) &&
				m_arg4 == null ? parameters[4] == null : parameters[4] is TArg4 parameter4 && EqualityComparer<TArg4>.Default.Equals(m_arg4, parameter4);
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}, {m_arg4}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Consideration"/> builder.
	/// </summary>
	/// <typeparam name="TConsideration">Built <see cref="Consideration"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
	/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
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
		/// <see cref="Consideration"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
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

		public bool AreEqual([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5)
		{
			return EqualityComparer<TArg0>.Default.Equals(m_arg0, arg0) &&
				EqualityComparer<TArg1>.Default.Equals(m_arg1, arg1) &&
				EqualityComparer<TArg2>.Default.Equals(m_arg2, arg2) &&
				EqualityComparer<TArg3>.Default.Equals(m_arg3, arg3) &&
				EqualityComparer<TArg4>.Default.Equals(m_arg4, arg4) &&
				EqualityComparer<TArg5>.Default.Equals(m_arg5, arg5);
		}

		public bool AreEqual(object[] parameters)
		{
			if (parameters == null)
			{
				return false;
			}

			return m_arg0 == null ? parameters[0] == null : parameters[0] is TArg0 parameter0 && EqualityComparer<TArg0>.Default.Equals(m_arg0, parameter0) &&
				m_arg1 == null ? parameters[1] == null : parameters[1] is TArg1 parameter1 && EqualityComparer<TArg1>.Default.Equals(m_arg1, parameter1) &&
				m_arg2 == null ? parameters[2] == null : parameters[2] is TArg2 parameter2 && EqualityComparer<TArg2>.Default.Equals(m_arg2, parameter2) &&
				m_arg3 == null ? parameters[3] == null : parameters[3] is TArg3 parameter3 && EqualityComparer<TArg3>.Default.Equals(m_arg3, parameter3) &&
				m_arg4 == null ? parameters[4] == null : parameters[4] is TArg4 parameter4 && EqualityComparer<TArg4>.Default.Equals(m_arg4, parameter4) &&
				m_arg5 == null ? parameters[5] == null : parameters[5] is TArg5 parameter5 && EqualityComparer<TArg5>.Default.Equals(m_arg5, parameter5);
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}, {m_arg4}, {m_arg5}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Consideration"/> builder.
	/// </summary>
	/// <typeparam name="TConsideration">Built <see cref="Consideration"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
	/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg6">Seventh argument in a setup method type.</typeparam>
	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
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
		/// <see cref="Consideration"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <param name="arg6">Seventh argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
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

		public bool AreEqual([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6)
		{
			return EqualityComparer<TArg0>.Default.Equals(m_arg0, arg0) &&
				EqualityComparer<TArg1>.Default.Equals(m_arg1, arg1) &&
				EqualityComparer<TArg2>.Default.Equals(m_arg2, arg2) &&
				EqualityComparer<TArg3>.Default.Equals(m_arg3, arg3) &&
				EqualityComparer<TArg4>.Default.Equals(m_arg4, arg4) &&
				EqualityComparer<TArg5>.Default.Equals(m_arg5, arg5) &&
				EqualityComparer<TArg6>.Default.Equals(m_arg6, arg6);
		}

		public bool AreEqual(object[] parameters)
		{
			if (parameters == null)
			{
				return false;
			}

			return m_arg0 == null ? parameters[0] == null : parameters[0] is TArg0 parameter0 && EqualityComparer<TArg0>.Default.Equals(m_arg0, parameter0) &&
				m_arg1 == null ? parameters[1] == null : parameters[1] is TArg1 parameter1 && EqualityComparer<TArg1>.Default.Equals(m_arg1, parameter1) &&
				m_arg2 == null ? parameters[2] == null : parameters[2] is TArg2 parameter2 && EqualityComparer<TArg2>.Default.Equals(m_arg2, parameter2) &&
				m_arg3 == null ? parameters[3] == null : parameters[3] is TArg3 parameter3 && EqualityComparer<TArg3>.Default.Equals(m_arg3, parameter3) &&
				m_arg4 == null ? parameters[4] == null : parameters[4] is TArg4 parameter4 && EqualityComparer<TArg4>.Default.Equals(m_arg4, parameter4) &&
				m_arg5 == null ? parameters[5] == null : parameters[5] is TArg5 parameter5 && EqualityComparer<TArg5>.Default.Equals(m_arg5, parameter5) &&
				m_arg6 == null ? parameters[6] == null : parameters[6] is TArg6 parameter6 && EqualityComparer<TArg6>.Default.Equals(m_arg6, parameter6);
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}, {m_arg4}, {m_arg5}, {m_arg6}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Generic <see cref="Consideration"/> builder.
	/// </summary>
	/// <typeparam name="TConsideration">Built <see cref="Consideration"/> type.</typeparam>
	/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
	/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
	/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
	/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
	/// <typeparam name="TArg6">Seventh argument in a setup method type.</typeparam>
	/// <typeparam name="TArg7">Eighth argument in a setup method type.</typeparam>
	internal sealed class ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : IConsiderationBuilder
		where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
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
		/// <see cref="Consideration"/> name.
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
		/// <param name="name"><see cref="Consideration"/> name.</param>
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

		public bool AreEqual([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6, [CanBeNull] TArg7 arg7)
		{
			return EqualityComparer<TArg0>.Default.Equals(m_arg0, arg0) &&
				EqualityComparer<TArg1>.Default.Equals(m_arg1, arg1) &&
				EqualityComparer<TArg2>.Default.Equals(m_arg2, arg2) &&
				EqualityComparer<TArg3>.Default.Equals(m_arg3, arg3) &&
				EqualityComparer<TArg4>.Default.Equals(m_arg4, arg4) &&
				EqualityComparer<TArg5>.Default.Equals(m_arg5, arg5) &&
				EqualityComparer<TArg6>.Default.Equals(m_arg6, arg6) &&
				EqualityComparer<TArg7>.Default.Equals(m_arg7, arg7);
		}

		public bool AreEqual(object[] parameters)
		{
			if (parameters == null)
			{
				return false;
			}

			return m_arg0 == null ? parameters[0] == null : parameters[0] is TArg0 parameter0 && EqualityComparer<TArg0>.Default.Equals(m_arg0, parameter0) &&
				m_arg1 == null ? parameters[1] == null : parameters[1] is TArg1 parameter1 && EqualityComparer<TArg1>.Default.Equals(m_arg1, parameter1) &&
				m_arg2 == null ? parameters[2] == null : parameters[2] is TArg2 parameter2 && EqualityComparer<TArg2>.Default.Equals(m_arg2, parameter2) &&
				m_arg3 == null ? parameters[3] == null : parameters[3] is TArg3 parameter3 && EqualityComparer<TArg3>.Default.Equals(m_arg3, parameter3) &&
				m_arg4 == null ? parameters[4] == null : parameters[4] is TArg4 parameter4 && EqualityComparer<TArg4>.Default.Equals(m_arg4, parameter4) &&
				m_arg5 == null ? parameters[5] == null : parameters[5] is TArg5 parameter5 && EqualityComparer<TArg5>.Default.Equals(m_arg5, parameter5) &&
				m_arg6 == null ? parameters[6] == null : parameters[6] is TArg6 parameter6 && EqualityComparer<TArg6>.Default.Equals(m_arg6, parameter6) &&
				m_arg7 == null ? parameters[7] == null : parameters[7] is TArg7 parameter7 && EqualityComparer<TArg7>.Default.Equals(m_arg7, parameter7);
		}

		public override string ToString()
		{
			return $"Serialized {considerationType.FullName} {{{m_arg0}, {m_arg1}, {m_arg2}, {m_arg3}, {m_arg4}, {m_arg5}, {m_arg6}, {m_arg7}}} \"{m_name}\"";
		}
	}

	/// <summary>
	/// Non-generic <see cref="Consideration"/> builder.
	/// </summary>
	internal sealed class ConsiderationBuilder : IConsiderationBuilder
	{
		/// <summary>
		/// Built <see cref="Consideration"/> type.
		/// </summary>
		[NotNull] private readonly Type m_considerationType;
		/// <summary>
		/// Setup arguments.
		/// </summary>
		[CanBeNull, ItemCanBeNull] private readonly object[] m_parameters;

		/// <summary>
		/// <see cref="Consideration"/> name.
		/// </summary>
		[NotNull] private readonly string m_name;

		/// <param name="considerationType">Built <see cref="Consideration"/> type.</param>
		/// <param name="parameters">Setup arguments.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		public ConsiderationBuilder([NotNull] Type considerationType, [CanBeNull, ItemCanBeNull] object[] parameters,
			[NotNull] string name)
		{
			m_considerationType = considerationType;
			m_parameters = parameters;

			m_name = name;
		}

		public Type considerationType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_considerationType;
		}

		public Consideration Build()
		{
			Consideration consideration = m_parameters != null
				? Consideration.Create(m_considerationType, m_parameters)
				: Consideration.Create(m_considerationType);
			consideration.name = m_name;
			return consideration;
		}

		public bool AreEqual(object[] parameters)
		{
			if (m_parameters == null)
			{
				return parameters == null;
			}

			if (parameters == null)
			{
				return false;
			}

			if (m_parameters.Length != parameters.Length)
			{
				return false;
			}

			for (int i = 0, count = m_parameters.Length; i < count; ++i)
			{
				if (m_parameters[i] == null)
				{
					if (parameters[i] != null)
					{
						return false;
					}
				}
				else if (!m_parameters[i].Equals(parameters[i]))
				{
					return false;
				}
			}

			return true;
		}
	}
}
