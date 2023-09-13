// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	public sealed class InstantiateObjectAction : Action
	{
		private readonly BlackboardPropertyName m_prefabPropertyName;
		private readonly BlackboardPropertyName m_positionPropertyName;
		private readonly BlackboardPropertyName m_rotationPropertyName;

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
