// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Considerations
{
	public sealed class LogarithmicConsideration : Consideration, IEquatable<LogarithmicConsideration>
	{
		private readonly float m_base;
		private readonly float m_steepness;
		private readonly float m_verticalShift;
		private readonly float m_horizontalShift;
		private readonly BlackboardPropertyName m_valuePropertyName;

		public LogarithmicConsideration(float @base, float steepness, float verticalShift, float horizontalShift,
			BlackboardPropertyName valuePropertyName)
		{
			m_base = @base;
			m_steepness = steepness;
			m_verticalShift = verticalShift;
			m_horizontalShift = horizontalShift;
			m_valuePropertyName = valuePropertyName;
		}

		public float @base
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_base;
		}

		public float slope
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_steepness;
		}

		public float verticalShift
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_verticalShift;
		}

		public float horizontalShift
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_horizontalShift;
		}

		public BlackboardPropertyName valuePropertyName
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_valuePropertyName;
		}

		[Pure]
		public override float ComputeUtility()
		{
			return blackboard.TryGetStructValue(m_valuePropertyName, out float value)
				? m_steepness * Mathf.Log(value - m_verticalShift, m_base) + m_horizontalShift
				: 0f;
		}

		[Pure]
		public bool Equals(LogarithmicConsideration other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return m_base.Equals(other.m_base) && m_steepness.Equals(other.m_steepness) &&
				m_verticalShift.Equals(other.m_verticalShift) && m_horizontalShift.Equals(other.m_horizontalShift) &&
				m_valuePropertyName.Equals(other.m_valuePropertyName);
		}

		[Pure]
		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is LogarithmicConsideration other && Equals(other);
		}

		[Pure]
		public override int GetHashCode()
		{
			return HashCode.Combine(m_base, m_steepness, m_verticalShift, m_horizontalShift, m_valuePropertyName);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator ==(LogarithmicConsideration left, LogarithmicConsideration right)
		{
			return Equals(left, right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator !=(LogarithmicConsideration left, LogarithmicConsideration right)
		{
			return !Equals(left, right);
		}
	}
}
