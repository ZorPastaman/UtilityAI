// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Considerations
{
	/// <summary>
	/// <para>
	/// <see cref="Consideration"/> using formula y = steepness * logbase(x - verticalShift) + horizontalShift.
	/// </para>
	/// <para>
	/// <list type="number">
	/// 	<listheader>
	/// 		<term>Setup arguments:</term>
	/// 	</listheader>
	/// 	<item>
	/// 		<description>Base of type <see cref="float"/>.</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Steepness of type <see cref="float"/>.</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Vertical shift of type <see cref="float"/>.</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Horizontal shift of type <see cref="float"/>.</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Property name of x value of type <see cref="float"/>.</description>
	/// 	</item>
	/// </list>
	/// </para>
	/// </summary>
	public sealed class LogarithmicConsideration : Consideration,
		ISetupable<float, float, float, float, BlackboardPropertyName>,
		ISetupable<float, float, float, float, string>
	{
		private float m_base;
		private float m_steepness;
		private float m_verticalShift;
		private float m_horizontalShift;
		private BlackboardPropertyName m_valuePropertyName;

		void ISetupable<float, float, float, float, BlackboardPropertyName>.Setup(float @base, float steepness,
			float verticalShift, float horizontalShift, BlackboardPropertyName valuePropertyName)
		{
			m_base = @base;
			m_steepness = steepness;
			m_verticalShift = verticalShift;
			m_horizontalShift = horizontalShift;
			m_valuePropertyName = valuePropertyName;
		}

		void ISetupable<float, float, float, float, string>.Setup(float @base, float steepness, float verticalShift,
			float horizontalShift, string valuePropertyName)
		{
			m_base = @base;
			m_steepness = steepness;
			m_verticalShift = verticalShift;
			m_horizontalShift = horizontalShift;
			m_valuePropertyName = new BlackboardPropertyName(valuePropertyName);
		}

		[Pure]
		public override float ComputeUtility()
		{
			return blackboard.TryGetStructValue(m_valuePropertyName, out float value)
				? m_steepness * Mathf.Log(value - m_verticalShift, m_base) + m_horizontalShift
				: 0f;
		}
	}
}
