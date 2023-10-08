// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using UnityEngine;

namespace Zor.UtilityAI.DrawingAttributes
{
	/// <summary>
	/// The name of a field with this attribute may be overriden with <see cref="NameOverrideAttribute"/>.
	/// They are bound by index.
	/// </summary>
	public sealed class NameOverridenAttribute : PropertyAttribute
	{
		/// <summary>
		/// Bind index.
		/// </summary>
		public readonly int index;

		/// <param name="index">Bind index.</param>
		public NameOverridenAttribute(int index)
		{
			this.index = index;
		}
	}
}
