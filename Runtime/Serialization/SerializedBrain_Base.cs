// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using JetBrains.Annotations;
using UnityEngine;
using Zor.SimpleBlackboard.Core;
using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Serialization
{
	public abstract class SerializedBrain_Base : ScriptableObject
	{
		public Brain CreateBrain()
		{
			return CreateBrain(new Blackboard());
		}

		public abstract Brain CreateBrain([NotNull] Blackboard blackboard);
	}
}
