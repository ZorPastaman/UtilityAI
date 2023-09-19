// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Zor.SimpleBlackboard.Core;
using Zor.UtilityAI.Builder;
using Zor.UtilityAI.Core;
using Zor.UtilityAI.Serialization.SerializedActions;
using Zor.UtilityAI.Serialization.SerializedConsiderations;

namespace Zor.UtilityAI.Serialization
{
	[CreateAssetMenu(
		menuName = "Utility AI/Serialized Brain",
		fileName = "SerializedBrain",
		order = 448
	)]
	public sealed class SerializedBrain : SerializedBrain_Base
	{
		[SerializeField] private SerializedAction_Base[] m_SerializedActions;
		[SerializeField] private SerializedConsideration_Base[] m_SerializedConsiderations;
		[SerializeField] private ConsiderationIndices[] m_ConsiderationIndices;

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

				int[] considerationIndices = m_ConsiderationIndices[actionIndex].considerations;

				for (int considerationIndex = 0, considerationCount = considerationIndices.Length;
					considerationIndex < considerationCount;
					++considerationIndex)
				{
					m_SerializedConsiderations[considerationIndices[considerationIndex]].AddConsideration(m_builder);
				}
			}
		}

		private void OnValidate()
		{
			int serializedActionCount = m_SerializedActions.Length;

			Array.Resize(ref m_ConsiderationIndices, serializedActionCount);

			for (int actionIndex = 0, actionCount = m_ConsiderationIndices.Length;
				actionIndex < actionCount;
				++actionIndex)
			{
				int[] considerationIndices = m_ConsiderationIndices[actionIndex].considerations;

				for (int considerationIndex = 0, considerationCount = considerationIndices.Length;
					considerationIndex < considerationCount;
					++considerationIndex)
				{
					int consideration = considerationIndices[considerationIndex];

					if (consideration < 0 || consideration >= serializedActionCount)
					{
						RemoveElement(ref considerationIndices, considerationIndex--);
						considerationCount = considerationIndices.Length;
					}
				}
			}
		}

		private static void RemoveElement(ref int[] array, int element)
		{
			for (int i = element, count = array.Length - 1; i < count; ++i)
			{
				array[i] = array[i + 1];
			}

			Array.Resize(ref array, array.Length - 1);
		}


		[Serializable]
		private struct ConsiderationIndices
		{
			[SerializeField] private int[] m_Considerations;

			[NotNull]
			public int[] considerations
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
				get => m_Considerations;
			}
		}
	}
}
