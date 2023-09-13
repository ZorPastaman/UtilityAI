// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using UnityEngine.AI;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	public sealed class CalculateNavMeshPathAction : Action
	{
		private readonly BlackboardPropertyName m_sourcePropertyName;
		private readonly BlackboardPropertyName m_targetPropertyName;
		private readonly BlackboardPropertyName m_filterPropertyName;
		private readonly BlackboardPropertyName m_pathPropertyName;

		private readonly NavMeshPath m_path = new();

		public CalculateNavMeshPathAction(BlackboardPropertyName sourcePropertyName,
			BlackboardPropertyName targetPropertyName, BlackboardPropertyName filterPropertyName,
			BlackboardPropertyName pathPropertyName)
		{
			m_sourcePropertyName = sourcePropertyName;
			m_targetPropertyName = targetPropertyName;
			m_filterPropertyName = filterPropertyName;
			m_pathPropertyName = pathPropertyName;
		}

		protected override void OnBegin()
		{
			base.OnBegin();

			if (!(blackboard.TryGetStructValue(m_sourcePropertyName, out Vector3 source) &
					blackboard.TryGetStructValue(m_targetPropertyName, out Vector3 target) &
					blackboard.TryGetStructValue(m_filterPropertyName, out NavMeshQueryFilter filter)))
			{
				return;
			}

			if (NavMesh.CalculatePath(source, target, filter, m_path))
			{
				blackboard.SetClassValue(m_pathPropertyName, m_path);
			}
			else
			{
				blackboard.RemoveObject(m_pathPropertyName);
			}
		}
	}
}
