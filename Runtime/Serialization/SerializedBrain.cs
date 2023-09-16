// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using Zor.SimpleBlackboard.Core;
using Zor.UtilityAI.Builder;
using Zor.UtilityAI.Core;
using Zor.UtilityAI.Serialization.SerializedActions;
using Zor.UtilityAI.Serialization.SerializedConsiderations;

namespace Zor.UtilityAI.Serialization
{
	public sealed class SerializedBrain : SerializedBrain_Base
	{
		[SerializeField] private SerializedAction_Base[] m_SerializedActions;
		[SerializeField] private SerializedConsideration_Base[] m_SerializedConsiderations;

		private BrainBuilder m_builder;

		public override Brain CreateBrain(Blackboard blackboard)
		{
			Deserialize();

			return m_builder.Build(blackboard);
		}

		private void Deserialize()
		{
			if (m_builder != null)
			{
				return;
			}

			m_builder = new BrainBuilder();

			for (int actionIndex = 0, actionCount = m_SerializedActions.Length;
				actionIndex < actionCount;
				++actionIndex)
			{
				SerializedAction_Base serializedActionBase = m_SerializedActions[actionIndex];
				serializedActionBase.AddAction(m_builder);

				int[] considerationIndices = serializedActionBase.considerationIndices;

				for (int considerationIndex = 0, considerationCount = considerationIndices.Length;
					considerationIndex < considerationCount;
					++considerationIndex)
				{
					m_SerializedConsiderations[considerationIndices[considerationIndex]].AddConsideration(m_builder);
				}
			}
		}
	}
}
