// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using UnityEngine.AI;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	/// <summary>
	/// <para>
	/// Calculates a <see cref="NavMeshPath"/> and puts it into the <see cref="Blackboard"/>.
	/// </para>
	/// <para>
	/// <list type="number">
	/// 	<listheader>
	/// 		<term>Setup arguments:</term>
	/// 	</listheader>
	/// 	<item>
	/// 		<description>Property name of a source of type <see cref="Vector3"/>.</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Property name of a target of type <see cref="Vector3"/>.</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Property name of a filter of type <see cref="NavMeshQueryFilter"/>.</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Property name for a result of type <see cref="NavMeshPath"/>.</description>
	/// 	</item>
	/// </list>
	/// </para>
	/// </summary>
	/// <remarks>
	/// The result is set only if all the required data is available and
	/// <see cref="NavMesh.CalculatePath(Vector3,Vector3,NavMeshQueryFilter,NavMeshPath)"/> is successful.
	/// Otherwise the property is removed from the <see cref="Blackboard"/>.
	/// </remarks>
	public sealed class CalculateNavMeshPathAction : Action,
		ISetupable<BlackboardPropertyName, BlackboardPropertyName, BlackboardPropertyName, BlackboardPropertyName>,
		ISetupable<string, string, string, string>
	{
		private BlackboardPropertyName m_sourcePropertyName;
		private BlackboardPropertyName m_targetPropertyName;
		private BlackboardPropertyName m_filterPropertyName;
		private BlackboardPropertyName m_pathPropertyName;

		private readonly NavMeshPath m_path = new();

		void ISetupable<BlackboardPropertyName, BlackboardPropertyName, BlackboardPropertyName, BlackboardPropertyName>.Setup(
			BlackboardPropertyName sourcePropertyName, BlackboardPropertyName targetPropertyName,
			BlackboardPropertyName filterPropertyName, BlackboardPropertyName pathPropertyName)
		{
			m_sourcePropertyName = sourcePropertyName;
			m_targetPropertyName = targetPropertyName;
			m_filterPropertyName = filterPropertyName;
			m_pathPropertyName = pathPropertyName;
		}

		void ISetupable<string, string, string, string>.Setup(
			string sourcePropertyName, string targetPropertyName, string filterPropertyName, string pathPropertyName)
		{
			m_sourcePropertyName = new BlackboardPropertyName(sourcePropertyName);
			m_targetPropertyName = new BlackboardPropertyName(targetPropertyName);
			m_filterPropertyName = new BlackboardPropertyName(filterPropertyName);
			m_pathPropertyName = new BlackboardPropertyName(pathPropertyName);
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
