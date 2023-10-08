// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	/// <summary>
	/// <para>
	/// Instantiates an <see cref="Object"/>.
	/// </para>
	/// <para>
	/// <list type="number">
	/// 	<listheader>
	/// 		<term>Setup arguments:</term>
	/// 	</listheader>
	/// 	<item>
	/// 		<description>Property name of a prefab of type <see cref="Object"/>.</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Property name of a position of type <see cref="Vector3"/>.</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Property name of a rotation of type <see cref="Quaternion"/>.</description>
	/// 	</item>
	/// </list>
	/// </para>
	/// </summary>
	public sealed class InstantiateObjectAction : Action,
		ISetupable<BlackboardPropertyName, BlackboardPropertyName, BlackboardPropertyName>,
		ISetupable<string, string, string>
	{
		private BlackboardPropertyName m_prefabPropertyName;
		private BlackboardPropertyName m_positionPropertyName;
		private BlackboardPropertyName m_rotationPropertyName;

		void ISetupable<BlackboardPropertyName, BlackboardPropertyName, BlackboardPropertyName>.Setup(
			BlackboardPropertyName prefabPropertyName, BlackboardPropertyName positionPropertyName,
			BlackboardPropertyName rotationPropertyName)
		{
			m_prefabPropertyName = prefabPropertyName;
			m_positionPropertyName = positionPropertyName;
			m_rotationPropertyName = rotationPropertyName;
		}

		void ISetupable<string, string, string>.Setup(string prefabPropertyName, string positionPropertyName, string rotationPropertyName)
		{
			m_prefabPropertyName = new BlackboardPropertyName(prefabPropertyName);
			m_positionPropertyName = new BlackboardPropertyName(positionPropertyName);
			m_rotationPropertyName = new BlackboardPropertyName(rotationPropertyName);
		}

		protected override void OnTick()
		{
			base.OnTick();

			if (!(blackboard.TryGetClassValue(m_prefabPropertyName, out Object prefab) &
					blackboard.TryGetStructValue(m_positionPropertyName, out Vector3 position) &
					blackboard.TryGetStructValue(m_rotationPropertyName, out Quaternion rotation)))
			{
				return;
			}

			Object.Instantiate(prefab, position, rotation);
		}
	}
}
