﻿// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Profiling;
using Zor.SimpleBlackboard.Core;
using Zor.UtilityAI.Builder;
using Zor.UtilityAI.Core;
using Zor.UtilityAI.Debugging;
using Zor.UtilityAI.Serialization.SerializedActions;
using Zor.UtilityAI.Serialization.SerializedConsiderations;

namespace Zor.UtilityAI.Serialization
{
	/// <summary>
	/// Serialized <see cref="Brain"/>.
	/// </summary>
	[CreateAssetMenu(
		menuName = "Utility AI/Serialized Brain",
		fileName = "SerializedBrain",
		order = 449
	)]
	public sealed class SerializedBrain : SerializedBrain_Base
	{
		[SerializeField] private SerializedAction_Base[] m_SerializedActions;
		[SerializeField] private SerializedConsideration_Base[] m_SerializedConsiderations;
		[SerializeField] private ConsiderationIndices[] m_ConsiderationIndices;
		[SerializeField] private BrainSettings m_BrainSettings;

		/// <summary>
		/// Cached <see cref="BrainBuilder"/>.
		/// Serialized data is deserialized only once on the first call of <see cref="CreateBrain"/> and cached here.
		/// </summary>
		private BrainBuilder m_builder;

		public override Brain CreateBrain(Blackboard blackboard)
		{
			Profiler.BeginSample("SerializedBrain.CreateBrain");
			Profiler.BeginSample(name);

			Deserialize();
			Brain brain = m_builder.Build(blackboard, m_BrainSettings);

			Profiler.EndSample();
			Profiler.EndSample();

			return brain;
		}

		/// <summary>
		/// Tries to deserialize data. It does nothing if the data has already been deserialized.
		/// </summary>
		private void Deserialize()
		{
			if (m_builder != null)
			{
				return;
			}

			Profiler.BeginSample("SerializedBrain.Deserialize");

			UtilityAIDebug.Log("Start deserializing brain");

			m_builder = new BrainBuilder();

			for (int actionIndex = 0, actionCount = m_SerializedActions.Length;
				actionIndex < actionCount;
				++actionIndex)
			{
				SerializedAction_Base serializedActionBase = m_SerializedActions[actionIndex];
				UtilityAIDebug.Log("Deserialize Action");
				UtilityAIDebug.Log(serializedActionBase.actionType.FullName);
				serializedActionBase.AddAction(m_builder);

				int[] considerationIndices = m_ConsiderationIndices[actionIndex].considerations;
				UtilityAIDebug.Log("Deserialize Considerations");

				for (int considerationIndex = 0, considerationCount = considerationIndices.Length;
					considerationIndex < considerationCount;
					++considerationIndex)
				{
					SerializedConsideration_Base serializedConsiderationBase =
						m_SerializedConsiderations[considerationIndices[considerationIndex]];
					UtilityAIDebug.Log(serializedConsiderationBase.considerationType.FullName);
					serializedConsiderationBase.AddConsideration(m_builder);
				}
			}

			UtilityAIDebug.Log("Finish deserializing brain");

			Profiler.EndSample();
		}

		[ContextMenu("Log")]
		private void Log()
		{
			Deserialize();
			Debug.Log($"SerializedBehaviorTree {name}\n{m_builder}");
		}

		private void OnValidate()
		{
			m_builder = null;

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

		/// <summary>
		/// Action to considerations binding.
		/// </summary>
		[Serializable]
		private struct ConsiderationIndices
		{
			[SerializeField] private int[] m_Considerations;

			/// <summary>
			/// <see cref="Consideration"/> indices.
			/// </summary>
			[NotNull]
			public int[] considerations
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining), Pure]
				get => m_Considerations;
			}
		}
	}
}
