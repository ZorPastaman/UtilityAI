// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;

namespace Zor.UtilityAI.DrawingAttributes
{
	public sealed class NameOverridenAttribute : PropertyAttribute
	{
		public readonly int index;

		public NameOverridenAttribute(int index)
		{
			this.index = index;
		}
	}
}
