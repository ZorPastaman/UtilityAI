// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Considerations
{
	/// <summary>
	/// <para>
	/// <see cref="Consideration"/> using formula y = curveFunc(x).
	/// </para>
	/// <para>
	/// <list type="number">
	/// 	<listheader>
	/// 		<term>Setup arguments:</term>
	/// 	</listheader>
	/// 	<item>
	/// 		<description>Curve of type <see cref="AnimationCurve"/>.</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Property name of x value of type <see cref="float"/>.</description>
	/// 	</item>
	/// </list>
	/// </para>
	/// </summary>
	public sealed class CurveConsideration : Consideration,
		ISetupable<AnimationCurve, BlackboardPropertyName>,
		ISetupable<AnimationCurve, string>
	{
		private AnimationCurve m_curve;
		private BlackboardPropertyName m_valuePropertyName;

		void ISetupable<AnimationCurve, BlackboardPropertyName>.Setup(AnimationCurve curve, BlackboardPropertyName valuePropertyName)
		{
			m_curve = curve;
			m_valuePropertyName = valuePropertyName;
		}

		void ISetupable<AnimationCurve, string>.Setup(AnimationCurve curve, string valuePropertyName)
		{
			m_curve = curve;
			m_valuePropertyName = new BlackboardPropertyName(valuePropertyName);
		}

		[Pure]
		public override float ComputeUtility()
		{
			return blackboard.TryGetStructValue(m_valuePropertyName, out float value) ? m_curve.Evaluate(value) : 0f;
		}
	}
}
