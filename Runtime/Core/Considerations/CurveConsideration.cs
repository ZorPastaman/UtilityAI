// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Considerations
{
	public sealed class CurveConsideration : Consideration, IEquatable<CurveConsideration>
	{
		[NotNull] private readonly AnimationCurve m_curve;
		private readonly BlackboardPropertyName m_valuePropertyName;

		public CurveConsideration([NotNull] AnimationCurve curve, BlackboardPropertyName valuePropertyName)
		{
			m_curve = curve;
			m_valuePropertyName = valuePropertyName;
		}

		[NotNull]
		public AnimationCurve curve
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_curve;
		}

		public BlackboardPropertyName valuePropertyName
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
			get => m_valuePropertyName;
		}

		[Pure]
		public override float ComputeUtility()
		{
			return blackboard.TryGetStructValue(m_valuePropertyName, out float value) ? m_curve.Evaluate(value) : 0f;
		}

		[Pure]
		public bool Equals(CurveConsideration other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}

			return m_curve.Equals(other.m_curve) && m_valuePropertyName.Equals(other.m_valuePropertyName);
		}

		[Pure]
		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj) || obj is CurveConsideration other && Equals(other);
		}

		[Pure]
		public override int GetHashCode()
		{
			return HashCode.Combine(m_curve, m_valuePropertyName);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator ==(CurveConsideration left, CurveConsideration right)
		{
			return Equals(left, right);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
		public static bool operator !=(CurveConsideration left, CurveConsideration right)
		{
			return !Equals(left, right);
		}
	}
}
