// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using Zor.SimpleBlackboard.Core;

namespace Zor.UtilityAI.Core.Actions
{
	public sealed class SetColorAction : SetStructValueAction<Color>
	{
		public SetColorAction(Color value, BlackboardPropertyName propertyName) : base(value, propertyName)
		{
		}
	}
}
