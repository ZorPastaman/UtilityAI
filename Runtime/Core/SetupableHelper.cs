// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine.Profiling;

namespace Zor.UtilityAI.Core
{
	/// <summary>
	/// Collection of methods to help working with setup methods.
	/// </summary>
	internal static class SetupableHelper
	{
		/// <summary>
		/// Calls setup method using reflection.
		/// </summary>
		/// <param name="obj">Target object.</param>
		/// <param name="parameters">Setup method arguments. Must be up to 8 elements.</param>
		/// <exception cref="ArgumentException">
		/// Thrown when <paramref name="parameters"/> have more than 8 elements
		/// or no appropriate setup method found on <paramref name="obj"/>.
		/// </exception>
		internal static void CreateSetup([NotNull] object obj, [NotNull, ItemCanBeNull] object[] parameters)
		{
			Type type = obj.GetType();
			Type[] interfaceTypes = type.GetInterfaces();

			int parametersCount = parameters.Length;
			var parameterTypes = new Type[parametersCount];

			for (int i = 0; i < parametersCount; ++i)
			{
				object parameter = parameters[i];
				parameterTypes[i] = parameter?.GetType();
			}

			Type baseSetupableType = parametersCount switch
			{
				1 => typeof(ISetupable<>),
				2 => typeof(ISetupable<,>),
				3 => typeof(ISetupable<,,>),
				4 => typeof(ISetupable<,,,>),
				5 => typeof(ISetupable<,,,,>),
				6 => typeof(ISetupable<,,,,,>),
				7 => typeof(ISetupable<,,,,,,>),
				8 => typeof(ISetupable<,,,,,,,>),
				_ => throw new ArgumentException($"Failed to setup an object of type {type}. Too many parameters are passed. It supports up to 8 parameters.")
			};

			for (int i = 0, iCount = interfaceTypes.Length; i < iCount; ++i)
			{
				Type interfaceType = interfaceTypes[i];

				// TODO Support derivation
				if (!interfaceType.IsGenericType || interfaceType.GetGenericTypeDefinition() != baseSetupableType)
				{
					continue;
				}

				Type[] interfaceParameters = interfaceType.GetGenericArguments();
				bool goodInterface = true;

				for (int j = 0, jCount = interfaceParameters.Length; j < jCount & goodInterface; ++j)
				{
					goodInterface = parameterTypes[j] == null
						? interfaceParameters[j].IsClass
						: interfaceParameters[j].IsAssignableFrom(parameterTypes[j]);
				}

				if (!goodInterface)
				{
					continue;
				}

				Profiler.BeginSample("Setup");
				interfaceType.InvokeMember("Setup", BindingFlags.InvokeMethod, null, obj, parameters);
				Profiler.EndSample();

				return;
			}

			throw new ArgumentException($"Failed to setup an object of type {type}. It doesn't have an appropriate setup method for passed arguments.");
		}
	}
}
