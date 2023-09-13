// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	public sealed class SetVector3Action : SetStructValueAction<Vector3>
	{
		public SetVector3Action(Vector3 value, BlackboardPropertyName propertyName) : base(value, propertyName)
		{
		}
	}
}
