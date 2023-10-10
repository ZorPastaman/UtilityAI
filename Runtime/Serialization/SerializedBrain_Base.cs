// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using JetBrains.Annotations;
using UnityEngine;
using Zor.SimpleBlackboard.Core;
using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Serialization
{
	/// <summary>
	/// Base class for serialized utility ai brain.
	/// </summary>
	public abstract class SerializedBrain_Base : ScriptableObject
	{
		/// <summary>
		/// Creates a <see cref="Brain"/> by the serialized data.
		/// </summary>
		/// <returns>Creates <see cref="Brain"/>.</returns>
		/// <remarks>It creates a new <see cref="Blackboard"/> for the <see cref="Brain"/>.</remarks>
		[NotNull]
		public Brain CreateBrain()
		{
			return CreateBrain(new Blackboard());
		}

		/// <summary>
		/// Creates a <see cref="Brain"/> by the serialized data.
		/// </summary>
		/// <param name="blackboard"><see cref="Blackboard"/> for the <see cref="Brain"/>.</param>
		/// <returns>Creates <see cref="Brain"/>.</returns>
		[NotNull]
		public abstract Brain CreateBrain([NotNull] Blackboard blackboard);
	}
}
