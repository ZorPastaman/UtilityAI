// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;
using Zor.UtilityAI.Core.Actions;
using Zor.UtilityAI.DrawingAttributes;

namespace Zor.UtilityAI.Serialization.SerializedActions
{
	[NameOverride("Color", 0), NameOverride("Property Name", 1)]
	public sealed class SerializedSetColorAction : SerializedAction<SetStructValueAction<Color>, Color, string>
	{
	}
}
