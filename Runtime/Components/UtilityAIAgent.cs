// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Profiling;
using Zor.SimpleBlackboard.Components;
using Zor.UtilityAI.Core;
using Zor.UtilityAI.Debugging;
using Zor.UtilityAI.Serialization;

namespace Zor.UtilityAI.Components
{
	/// <summary>
	/// Creator and holder of <see cref="Brain"/>.
	/// </summary>
	/// <remarks>
	/// <para>Agent deserializes a <see cref="Brain"/> on Awake.</para>
	/// <para>Agent disposes a <see cref="Brain"/> on OnDestroy.</para>
	/// </remarks>
	[AddComponentMenu("Utility AI/Utility AI Agent")]
	public sealed class UtilityAIAgent : MonoBehaviour
	{
		[SerializeField, Tooltip("Serialized brain. It's automatically deserialized on Awake.")]
		private SerializedBrain_Base m_SerializedBrain;
		[SerializeField, Tooltip("Blackboard container. It's used as a blackboard for the brain.")]
		private SimpleBlackboardContainer m_BlackboardContainer;

		/// <summary>
		/// Deserialized <see cref="Brain"/>.
		/// </summary>
		private Brain m_brain;

		/// <summary>
		/// Cached <see cref="GameObject.name"/> to use in <see cref="Profiler.BeginSample(string)"/>.
		/// </summary>
		private string m_name;

		/// <summary>
		/// Ticks a holden <see cref="Brain"/>.
		/// </summary>
		public void Tick()
		{
			Profiler.BeginSample(m_name);

			m_brain.Tick();

			Profiler.EndSample();
		}

		/// <summary>
		/// Fills debug info of a holden <see cref="Brain"/> into <paramref name="brainDebugInfo"/>.
		/// </summary>
		/// <param name="brainDebugInfo">Brain debug info.</param>
		public void FillDebugInfo([NotNull] BrainDebugInfo brainDebugInfo)
		{
			m_brain?.FillDebugInfo(brainDebugInfo);
		}

		/// <summary>
		/// Recreates a <see cref="Brain"/> with the same serialized brain.
		/// </summary>
		/// <remarks>
		/// This doesn't return a serialized brain or a blackboard to their original states.
		/// </remarks>
		[ContextMenu("Recreate Brain")]
		public void RecreateBrain()
		{
			Awake();
		}

		private void Awake()
		{
#if DEBUG
			if (m_SerializedBrain == null)
			{
				UtilityAIDebug.LogError(this, "Serialized brain is null");
				return;
			}

			if (m_BlackboardContainer == null)
			{
				UtilityAIDebug.LogError(this, "Blackboard container is null");
				return;
			}
#endif

			m_brain = m_SerializedBrain.CreateBrain(m_BlackboardContainer.blackboard);
			m_brain.Initialize();

			m_name = gameObject.name;
		}

		private void OnDestroy()
		{
			m_brain?.Dispose();
		}
	}
}
