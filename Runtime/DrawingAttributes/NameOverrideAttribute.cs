// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using JetBrains.Annotations;

namespace Zor.UtilityAI.DrawingAttributes
{
	/// <summary>
	/// Overrides a default field name in a
	/// <see cref="Zor.UtilityAI.Serialization.SerializedActions"/> and
	/// <see cref="Zor.UtilityAI.Serialization.SerializedConsiderations"/>.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public sealed class NameOverrideAttribute : Attribute
	{
		/// <summary>
		/// New field name.
		/// </summary>
		[NotNull] public readonly string name;
		/// <summary>
		/// Target field index.
		/// </summary>
		public readonly int index;

		/// <param name="name">New field name.</param>
		/// <param name="index">Target field index.</param>
		public NameOverrideAttribute([NotNull] string name, int index)
		{
			this.name = name;
			this.index = index;
		}
	}
}
