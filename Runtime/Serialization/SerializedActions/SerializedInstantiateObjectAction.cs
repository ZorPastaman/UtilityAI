// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using Zor.UtilityAI.Core.Actions;
using Zor.UtilityAI.DrawingAttributes;

namespace Zor.UtilityAI.Serialization.SerializedActions
{
	[NameOverride("Prefab Property Name", 0), NameOverride("Position Property Name", 1),
	NameOverride("Rotation Property Name", 2)]
	public sealed class SerializedInstantiateObjectAction : SerializedAction<InstantiateObjectAction, string, string, string>
	{
	}
}
