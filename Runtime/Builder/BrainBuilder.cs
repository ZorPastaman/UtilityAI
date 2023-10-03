// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using UnityEngine.Profiling;
using Zor.SimpleBlackboard.Core;
using Zor.UtilityAI.Core;
using Action = Zor.UtilityAI.Core.Action;

namespace Zor.UtilityAI.Builder
{
	/// <summary>
	/// Behavior tree builder. The builder helps to create behavior trees in the easy way.
	/// </summary>
	/// <example>
	/// <code>
	/// var builder = new BrainBuilder();
	/// builder.AddAction&lt;DoNothingAction&gt;();
	/// builder.AddConsideration&lt;ConstantConsideration, float&gt;(2f);
	/// builder.AddConsideration&lt;AbsoluteConsideration, float, float, float, string&gt;(1f, -3f, 0f, value);
	/// builder.AddConsideration&lt;QuadraticConsideration, float, float, float, float, BlackboardPropertyName&gt;(1f, 1f, 1f, 1f, value);
	/// builder.AddAction&lt;InstantiateObjectAction, BlackboardPropertyName, BlackboardPropertyName, BlackboardPropertyName&gt;(prefab, position, rotation);
	/// builder.AddConsideration&lt;ConstantConsideration, float&gt;(0.5f);
	/// builder.AddConsideration&lt;LinearConsideration, float, float, float, string&gt;(1f, -3f, 0f, valueMax);
	/// builder.AddConsideration&lt;QuadraticConsideration, float, float, float, float, BlackboardPropertyName&gt;(1f, 1f, 1f, 1f, value);
	/// Brain brain = builder.Build(new BrainSettings(0.1f));
	/// </code>
	/// </example>
	/// <remarks>
	/// The builder can merge the same considerations.
	/// When you add a consideration that was already added, it'll just reuse the first consideration for an action.
	/// </remarks>
	public sealed class BrainBuilder
	{
		/// <summary>
		/// Added actions.
		/// </summary>
		[NotNull, ItemNotNull] private readonly List<IActionBuilder> m_actionBuilders = new();
		/// <summary>
		/// Added considerations.
		/// </summary>
		[NotNull, ItemNotNull] private readonly List<IConsiderationBuilder> m_considerationBuilders = new();
		/// <summary>
		/// Action to considerations bindings.
		/// </summary>
		[NotNull, ItemNotNull] private readonly List<List<int>> m_actionConsiderationsBindings = new();

		/// <summary>
		/// Consideration index cache based on parameter count.
		/// </summary>
		[NotNull, ItemNotNull] private readonly List<int>[] m_fastConsiderationsLookup = new List<int>[9]
		{
			new(), new(), new(), new(), new(), new(), new(), new(), new()
		};
		/// <summary>
		/// Parameters cache. Used not to create a new object array each time.
		/// </summary>
		[NotNull, ItemNotNull] private readonly object[][] m_parametersCache = new object[8][]
		{
			new object[1], new object[2], new object[3], new object[4], new object[5], new object[6], new object[7], new object[8]
		};

		/// <summary>
		/// Adds an <see cref="Action"/> of type <typeparamref name="TAction"/> to the build config.
		/// </summary>
		/// <param name="name"><see cref="Action"/> name.</param>
		/// <typeparam name="TAction"><see cref="Action"/> type.</typeparam>
		public void AddAction<TAction>([NotNull] string name = "") where TAction : Action, INotSetupable, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction>(name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds an <see cref="Action"/> of type <typeparamref name="TAction"/> to the build config.
		/// </summary>
		/// <param name="arg">Argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		/// <typeparam name="TAction"><see cref="Action"/> type.</typeparam>
		/// <typeparam name="TArg">Argument in a setup method type.</typeparam>
		public void AddAction<TAction, TArg>([CanBeNull] TArg arg, [NotNull] string name = "") where TAction : Action, ISetupable<TArg>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg>(arg, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds an <see cref="Action"/> of type <typeparamref name="TAction"/> to the build config.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		/// <typeparam name="TAction"><see cref="Action"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		public void AddAction<TAction, TArg0, TArg1>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1>(arg0, arg1, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds an <see cref="Action"/> of type <typeparamref name="TAction"/> to the build config.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		/// <typeparam name="TAction"><see cref="Action"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		public void AddAction<TAction, TArg0, TArg1, TArg2>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2,
			[NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2>(arg0, arg1, arg2, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds an <see cref="Action"/> of type <typeparamref name="TAction"/> to the build config.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		/// <typeparam name="TAction"><see cref="Action"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3,
			[NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3>(arg0, arg1, arg2, arg3, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds an <see cref="Action"/> of type <typeparamref name="TAction"/> to the build config.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		/// <typeparam name="TAction"><see cref="Action"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4,
			[NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4>(arg0, arg1, arg2, arg3, arg4, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds an <see cref="Action"/> of type <typeparamref name="TAction"/> to the build config.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		/// <typeparam name="TAction"><see cref="Action"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5,
			[NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(arg0, arg1, arg2, arg3, arg4, arg5, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds an <see cref="Action"/> of type <typeparamref name="TAction"/> to the build config.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <param name="arg6">Seventh argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		/// <typeparam name="TAction"><see cref="Action"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg6">Seventh argument in a setup method type.</typeparam>
		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6,
			[NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds an <see cref="Action"/> of type <typeparamref name="TAction"/> to the build config.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <param name="arg6">Seventh argument in a setup method.</param>
		/// <param name="arg7">Eighth argument in a setup method.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		/// <typeparam name="TAction"><see cref="Action"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg6">Seventh argument in a setup method type.</typeparam>
		/// <typeparam name="TArg7">Eighth argument in a setup method type.</typeparam>
		public void AddAction<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6, [CanBeNull] TArg7 arg7,
			[NotNull] string name = "")
			where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(typeof(TAction).FullName);

			m_actionBuilders.Add(new ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds an <see cref="Action"/> of type <paramref name="actionType"/> to the build config.
		/// </summary>
		/// <param name="actionType"><see cref="Action"/> type.</param>
		/// <param name="name"><see cref="Action"/> name.</param>
		/// <param name="parameters">Setup method arguments. Up to 8 elements.</param>
		/// <exception cref="ArgumentException">
		/// Thrown if <paramref name="parameters"/> has more than 8 elements.
		/// </exception>
		public void AddAction([NotNull] Type actionType, string name = "",
			[CanBeNull, ItemCanBeNull] params object[] parameters)
		{
			Profiler.BeginSample("BrainBuilder.AddAction");
			Profiler.BeginSample(actionType.FullName);

#if DEBUG
			if (parameters is { Length: > 8 })
			{
				throw new ArgumentException($"Failed to add an action of type {actionType}. Too many {nameof(parameters)} were passed. The method supports up to 8.");
			}
#endif

			m_actionBuilders.Add(new ActionBuilder(actionType, parameters, name));
			m_actionConsiderationsBindings.Add(new List<int>());

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds a <see cref="Consideration"/> of type <typeparamref name="TConsideration"/>
		/// to the previously added <see cref="Action"/>.
		/// </summary>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		/// <typeparam name="TConsideration"><see cref="Consideration"/> type.</typeparam>
		/// <exception cref="InvalidOperationException">
		/// Thrown if no <see cref="Action"/> was added before the call of this method.
		/// </exception>
		public void AddConsideration<TConsideration>([NotNull] string name = "") where TConsideration : Consideration, INotSetupable, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

#if DEBUG
			if (m_actionConsiderationsBindings.Count == 0)
			{
				throw new InvalidOperationException($"Failed to add a consideration of type {typeof(TConsideration)}. No action was added before.");
			}
#endif

			const int parametersCount = 0;
			List<int> considerationsLookup = m_fastConsiderationsLookup[parametersCount];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];
				IConsiderationBuilder considerationBuilder = m_considerationBuilders[considerationIndex];

				if (considerationBuilder is ConsiderationBuilder<TConsideration>)
				{
					sameIndex = considerationIndex;
					break;
				}

				if (considerationBuilder is ConsiderationBuilder nonGenericConsiderationBuilder &&
					nonGenericConsiderationBuilder.considerationType == typeof(TConsideration))
				{
					sameIndex = considerationIndex;
					break;
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration>(name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds a <see cref="Consideration"/> of type <typeparamref name="TConsideration"/>
		/// to the previously added <see cref="Action"/>.
		/// </summary>
		/// <param name="arg">Argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		/// <typeparam name="TConsideration"><see cref="Consideration"/> type.</typeparam>
		/// <typeparam name="TArg">Argument in a setup method type.</typeparam>
		/// <exception cref="InvalidOperationException">
		/// Thrown if no <see cref="Action"/> was added before the call of this method.
		/// </exception>
		public void AddConsideration<TConsideration, TArg>([CanBeNull] TArg arg, [NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

#if DEBUG
			if (m_actionConsiderationsBindings.Count == 0)
			{
				throw new InvalidOperationException($"Failed to add a consideration of type {typeof(TConsideration)}. No action was added before.");
			}
#endif

			const int parametersCount = 1;
			List<int> considerationsLookup = m_fastConsiderationsLookup[parametersCount];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];
				IConsiderationBuilder considerationBuilder = m_considerationBuilders[considerationIndex];

				if (considerationBuilder is ConsiderationBuilder<TConsideration, TArg> genericConsiderationBuilder)
				{
					if (genericConsiderationBuilder.AreEqual(arg))
					{
						sameIndex = considerationIndex;
						break;
					}
				}
				else if (considerationBuilder is ConsiderationBuilder nonGenericConsiderationBuilder &&
						nonGenericConsiderationBuilder.considerationType == typeof(TConsideration))
				{
					const int parametersCacheIndex = parametersCount - 1;
					object[] parametersCache = m_parametersCache[parametersCacheIndex];
					parametersCache[0] = arg;

					if (nonGenericConsiderationBuilder.AreEqual(parametersCache))
					{
						sameIndex = considerationIndex;
						Array.Clear(parametersCache, 0, parametersCount);
						break;
					}

					Array.Clear(parametersCache, 0, parametersCount);
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg>(arg, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds a <see cref="Consideration"/> of type <typeparamref name="TConsideration"/>
		/// to the previously added <see cref="Action"/>.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		/// <typeparam name="TConsideration"><see cref="Consideration"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <exception cref="InvalidOperationException">
		/// Thrown if no <see cref="Action"/> was added before the call of this method.
		/// </exception>
		public void AddConsideration<TConsideration, TArg0, TArg1>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

#if DEBUG
			if (m_actionConsiderationsBindings.Count == 0)
			{
				throw new InvalidOperationException($"Failed to add a consideration of type {typeof(TConsideration)}. No action was added before.");
			}
#endif

			const int parametersCount = 2;
			List<int> considerationsLookup = m_fastConsiderationsLookup[parametersCount];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];
				IConsiderationBuilder considerationBuilder = m_considerationBuilders[considerationIndex];

				if (considerationBuilder is ConsiderationBuilder<TConsideration, TArg0, TArg1> genericConsiderationBuilder)
				{
					if (genericConsiderationBuilder.AreEqual(arg0, arg1))
					{
						sameIndex = considerationIndex;
						break;
					}
				}
				else if (considerationBuilder is ConsiderationBuilder nonGenericConsiderationBuilder &&
						nonGenericConsiderationBuilder.considerationType == typeof(TConsideration))
				{
					const int parametersCacheIndex = parametersCount - 1;
					object[] parametersCache = m_parametersCache[parametersCacheIndex];
					parametersCache[0] = arg0;
					parametersCache[1] = arg1;

					if (nonGenericConsiderationBuilder.AreEqual(parametersCache))
					{
						sameIndex = considerationIndex;
						Array.Clear(parametersCache, 0, parametersCount);
						break;
					}

					Array.Clear(parametersCache, 0, parametersCount);
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1>(arg0, arg1, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds a <see cref="Consideration"/> of type <typeparamref name="TConsideration"/>
		/// to the previously added <see cref="Action"/>.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		/// <typeparam name="TConsideration"><see cref="Consideration"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <exception cref="InvalidOperationException">
		/// Thrown if no <see cref="Action"/> was added before the call of this method.
		/// </exception>
		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

#if DEBUG
			if (m_actionConsiderationsBindings.Count == 0)
			{
				throw new InvalidOperationException($"Failed to add a consideration of type {typeof(TConsideration)}. No action was added before.");
			}
#endif

			const int parametersCount = 3;
			List<int> considerationsLookup = m_fastConsiderationsLookup[parametersCount];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];
				IConsiderationBuilder considerationBuilder = m_considerationBuilders[considerationIndex];

				if (considerationBuilder is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2> genericConsiderationBuilder)
				{
					if (genericConsiderationBuilder.AreEqual(arg0, arg1, arg2))
					{
						sameIndex = considerationIndex;
						break;
					}
				}
				else if (considerationBuilder is ConsiderationBuilder nonGenericConsiderationBuilder &&
						nonGenericConsiderationBuilder.considerationType == typeof(TConsideration))
				{
					const int parametersCacheIndex = parametersCount - 1;
					object[] parametersCache = m_parametersCache[parametersCacheIndex];
					parametersCache[0] = arg0;
					parametersCache[1] = arg1;
					parametersCache[2] = arg2;

					if (nonGenericConsiderationBuilder.AreEqual(parametersCache))
					{
						sameIndex = considerationIndex;
						Array.Clear(parametersCache, 0, parametersCount);
						break;
					}

					Array.Clear(parametersCache, 0, parametersCount);
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2>(arg0, arg1, arg2, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds a <see cref="Consideration"/> of type <typeparamref name="TConsideration"/>
		/// to the previously added <see cref="Action"/>.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		/// <typeparam name="TConsideration"><see cref="Consideration"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <exception cref="InvalidOperationException">
		/// Thrown if no <see cref="Action"/> was added before the call of this method.
		/// </exception>
		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

#if DEBUG
			if (m_actionConsiderationsBindings.Count == 0)
			{
				throw new InvalidOperationException($"Failed to add a consideration of type {typeof(TConsideration)}. No action was added before.");
			}
#endif

			const int parametersCount = 4;
			List<int> considerationsLookup = m_fastConsiderationsLookup[parametersCount];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];
				IConsiderationBuilder considerationBuilder = m_considerationBuilders[considerationIndex];

				if (considerationBuilder is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3> genericConsiderationBuilder)
				{
					if (genericConsiderationBuilder.AreEqual(arg0, arg1, arg2, arg3))
					{
						sameIndex = considerationIndex;
						break;
					}
				}
				else if (considerationBuilder is ConsiderationBuilder nonGenericConsiderationBuilder &&
						nonGenericConsiderationBuilder.considerationType == typeof(TConsideration))
				{
					const int parametersCacheIndex = parametersCount - 1;
					object[] parametersCache = m_parametersCache[parametersCacheIndex];
					parametersCache[0] = arg0;
					parametersCache[1] = arg1;
					parametersCache[2] = arg2;
					parametersCache[3] = arg3;

					if (nonGenericConsiderationBuilder.AreEqual(parametersCache))
					{
						sameIndex = considerationIndex;
						Array.Clear(parametersCache, 0, parametersCount);
						break;
					}

					Array.Clear(parametersCache, 0, parametersCount);
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3>(arg0, arg1, arg2, arg3, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds a <see cref="Consideration"/> of type <typeparamref name="TConsideration"/>
		/// to the previously added <see cref="Action"/>.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		/// <typeparam name="TConsideration"><see cref="Consideration"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
		/// <exception cref="InvalidOperationException">
		/// Thrown if no <see cref="Action"/> was added before the call of this method.
		/// </exception>
		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

#if DEBUG
			if (m_actionConsiderationsBindings.Count == 0)
			{
				throw new InvalidOperationException($"Failed to add a consideration of type {typeof(TConsideration)}. No action was added before.");
			}
#endif

			const int parametersCount = 5;
			List<int> considerationsLookup = m_fastConsiderationsLookup[parametersCount];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];
				IConsiderationBuilder considerationBuilder = m_considerationBuilders[considerationIndex];

				if (considerationBuilder is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4> genericConsiderationBuilder)
				{
					if (genericConsiderationBuilder.AreEqual(arg0, arg1, arg2, arg3, arg4))
					{
						sameIndex = considerationIndex;
						break;
					}
				}
				else if (considerationBuilder is ConsiderationBuilder nonGenericConsiderationBuilder &&
						nonGenericConsiderationBuilder.considerationType == typeof(TConsideration))
				{
					const int parametersCacheIndex = parametersCount - 1;
					object[] parametersCache = m_parametersCache[parametersCacheIndex];
					parametersCache[0] = arg0;
					parametersCache[1] = arg1;
					parametersCache[2] = arg2;
					parametersCache[3] = arg3;
					parametersCache[4] = arg4;

					if (nonGenericConsiderationBuilder.AreEqual(parametersCache))
					{
						sameIndex = considerationIndex;
						Array.Clear(parametersCache, 0, parametersCount);
						break;
					}

					Array.Clear(parametersCache, 0, parametersCount);
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4>(arg0, arg1, arg2, arg3, arg4, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds a <see cref="Consideration"/> of type <typeparamref name="TConsideration"/>
		/// to the previously added <see cref="Action"/>.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		/// <typeparam name="TConsideration"><see cref="Consideration"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
		/// <exception cref="InvalidOperationException">
		/// Thrown if no <see cref="Action"/> was added before the call of this method.
		/// </exception>
		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

#if DEBUG
			if (m_actionConsiderationsBindings.Count == 0)
			{
				throw new InvalidOperationException($"Failed to add a consideration of type {typeof(TConsideration)}. No action was added before.");
			}
#endif

			const int parametersCount = 6;
			List<int> considerationsLookup = m_fastConsiderationsLookup[parametersCount];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];
				IConsiderationBuilder considerationBuilder = m_considerationBuilders[considerationIndex];

				if (considerationBuilder is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> genericConsiderationBuilder)
				{
					if (genericConsiderationBuilder.AreEqual(arg0, arg1, arg2, arg3, arg4, arg5))
					{
						sameIndex = considerationIndex;
						break;
					}
				}
				else if (considerationBuilder is ConsiderationBuilder nonGenericConsiderationBuilder &&
						nonGenericConsiderationBuilder.considerationType == typeof(TConsideration))
				{
					const int parametersCacheIndex = parametersCount - 1;
					object[] parametersCache = m_parametersCache[parametersCacheIndex];
					parametersCache[0] = arg0;
					parametersCache[1] = arg1;
					parametersCache[2] = arg2;
					parametersCache[3] = arg3;
					parametersCache[4] = arg4;
					parametersCache[5] = arg5;

					if (nonGenericConsiderationBuilder.AreEqual(parametersCache))
					{
						sameIndex = considerationIndex;
						Array.Clear(parametersCache, 0, parametersCount);
						break;
					}

					Array.Clear(parametersCache, 0, parametersCount);
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(arg0, arg1, arg2, arg3, arg4, arg5, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds a <see cref="Consideration"/> of type <typeparamref name="TConsideration"/>
		/// to the previously added <see cref="Action"/>.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <param name="arg6">Seventh argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		/// <typeparam name="TConsideration"><see cref="Consideration"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg6">Seventh argument in a setup method type.</typeparam>
		/// <exception cref="InvalidOperationException">
		/// Thrown if no <see cref="Action"/> was added before the call of this method.
		/// </exception>
		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

#if DEBUG
			if (m_actionConsiderationsBindings.Count == 0)
			{
				throw new InvalidOperationException($"Failed to add a consideration of type {typeof(TConsideration)}. No action was added before.");
			}
#endif

			const int parametersCount = 7;
			List<int> considerationsLookup = m_fastConsiderationsLookup[parametersCount];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];
				IConsiderationBuilder considerationBuilder = m_considerationBuilders[considerationIndex];

				if (considerationBuilder is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> genericConsiderationBuilder)
				{
					if (genericConsiderationBuilder.AreEqual(arg0, arg1, arg2, arg3, arg4, arg5, arg6))
					{
						sameIndex = considerationIndex;
						break;
					}
				}
				else if (considerationBuilder is ConsiderationBuilder nonGenericConsiderationBuilder &&
					nonGenericConsiderationBuilder.considerationType == typeof(TConsideration))
				{
					const int parametersCacheIndex = parametersCount - 1;
					object[] parametersCache = m_parametersCache[parametersCacheIndex];
					parametersCache[0] = arg0;
					parametersCache[1] = arg1;
					parametersCache[2] = arg2;
					parametersCache[3] = arg3;
					parametersCache[4] = arg4;
					parametersCache[5] = arg5;
					parametersCache[6] = arg6;

					if (nonGenericConsiderationBuilder.AreEqual(parametersCache))
					{
						sameIndex = considerationIndex;
						Array.Clear(parametersCache, 0, parametersCount);
						break;
					}

					Array.Clear(parametersCache, 0, parametersCount);
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds a <see cref="Consideration"/> of type <typeparamref name="TConsideration"/>
		/// to the previously added <see cref="Action"/>.
		/// </summary>
		/// <param name="arg0">First argument in a setup method.</param>
		/// <param name="arg1">Second argument in a setup method.</param>
		/// <param name="arg2">Third argument in a setup method.</param>
		/// <param name="arg3">Fourth argument in a setup method.</param>
		/// <param name="arg4">Fifth argument in a setup method.</param>
		/// <param name="arg5">Sixth argument in a setup method.</param>
		/// <param name="arg6">Seventh argument in a setup method.</param>
		/// <param name="arg7">Eighth argument in a setup method.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		/// <typeparam name="TConsideration"><see cref="Consideration"/> type.</typeparam>
		/// <typeparam name="TArg0">First argument in a setup method type.</typeparam>
		/// <typeparam name="TArg1">Second argument in a setup method type.</typeparam>
		/// <typeparam name="TArg2">Third argument in a setup method type.</typeparam>
		/// <typeparam name="TArg3">Fourth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg4">Fifth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg5">Sixth argument in a setup method type.</typeparam>
		/// <typeparam name="TArg6">Seventh argument in a setup method type.</typeparam>
		/// <typeparam name="TArg7">Eighth argument in a setup method type.</typeparam>
		/// <exception cref="InvalidOperationException">
		/// Thrown if no <see cref="Action"/> was added before the call of this method.
		/// </exception>
		public void AddConsideration<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>([CanBeNull] TArg0 arg0, [CanBeNull] TArg1 arg1, [CanBeNull] TArg2 arg2, [CanBeNull] TArg3 arg3, [CanBeNull] TArg4 arg4, [CanBeNull] TArg5 arg5, [CanBeNull] TArg6 arg6, [CanBeNull] TArg7 arg7,
			[NotNull] string name = "")
			where TConsideration : Consideration, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(typeof(TConsideration).FullName);

#if DEBUG
			if (m_actionConsiderationsBindings.Count == 0)
			{
				throw new InvalidOperationException($"Failed to add a consideration of type {typeof(TConsideration)}. No action was added before.");
			}
#endif

			const int parametersCount = 8;
			List<int> considerationsLookup = m_fastConsiderationsLookup[parametersCount];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];
				IConsiderationBuilder considerationBuilder = m_considerationBuilders[considerationIndex];

				if (considerationBuilder is ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> genericConsiderationBuilder)
				{
					if (genericConsiderationBuilder.AreEqual(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7))
					{
						sameIndex = considerationIndex;
						break;
					}
				}
				else if (considerationBuilder is ConsiderationBuilder nonGenericConsiderationBuilder &&
					nonGenericConsiderationBuilder.considerationType == typeof(TConsideration))
				{
					const int parametersCacheIndex = parametersCount - 1;
					object[] parametersCache = m_parametersCache[parametersCacheIndex];
					parametersCache[0] = arg0;
					parametersCache[1] = arg1;
					parametersCache[2] = arg2;
					parametersCache[3] = arg3;
					parametersCache[4] = arg4;
					parametersCache[5] = arg5;
					parametersCache[6] = arg6;
					parametersCache[7] = arg7;

					if (nonGenericConsiderationBuilder.AreEqual(parametersCache))
					{
						sameIndex = considerationIndex;
						Array.Clear(parametersCache, 0, parametersCount);
						break;
					}

					Array.Clear(parametersCache, 0, parametersCount);
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder<TConsideration, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(arg0, arg1, arg2, arg3, arg4, arg5, arg6, arg7, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Adds a <see cref="Consideration"/> of type <paramref name="considerationType"/>
		/// to the previously added <see cref="Action"/>.
		/// </summary>
		/// <param name="considerationType"><see cref="Consideration"/> type.</param>
		/// <param name="name"><see cref="Consideration"/> name.</param>
		/// <param name="parameters">Setup method arguments. Up to 8 elements.</param>
		/// <exception cref="ArgumentException">
		/// Thrown if <paramref name="parameters"/> has more than 8 elements.
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Thrown if no <see cref="Action"/> was added before the call of this method.
		/// </exception>
		public void AddConsideration([NotNull] Type considerationType, [NotNull] string name = "",
			[CanBeNull, ItemCanBeNull] params object[] parameters)
		{
			Profiler.BeginSample("BrainBuilder.AddConsideration");
			Profiler.BeginSample(considerationType.FullName);

#if DEBUG
			if (parameters is { Length: > 8 })
			{
				throw new ArgumentException($"Failed to add a consideration of type {considerationType}. Too many {nameof(parameters)} were passed. The method supports up to 8.");
			}

			if (m_actionConsiderationsBindings.Count == 0)
			{
				throw new InvalidOperationException($"Failed to add a consideration of type {considerationType}. No action was added before.");
			}
#endif

			List<int> considerationsLookup = m_fastConsiderationsLookup[parameters?.Length ?? 0];
			int sameIndex = -1;

			for (int i = 0, count = considerationsLookup.Count; i < count; ++i)
			{
				int considerationIndex = considerationsLookup[i];
				IConsiderationBuilder considerationBuilder = m_considerationBuilders[considerationIndex];

				if (considerationBuilder.considerationType == considerationType &&
					considerationBuilder.AreEqual(parameters))
				{
					sameIndex = considerationIndex;
					break;
				}
			}

			if (sameIndex >= 0)
			{
				m_actionConsiderationsBindings[^1].Add(sameIndex);
			}
			else
			{
				int count = m_considerationBuilders.Count;
				m_actionConsiderationsBindings[^1].Add(count);
				considerationsLookup.Add(count);
				m_considerationBuilders.Add(new ConsiderationBuilder(considerationType, parameters, name));
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		/// <summary>
		/// Builds a <see cref="Brain"/> with the added actions and considerations.
		/// </summary>
		/// <param name="brainSettings">Brain settings.</param>
		/// <returns>Built <see cref="Brain"/>.</returns>
		/// <remarks>
		/// This methods creates a new <see cref="Blackboard"/> for the built <see cref="Brain"/>.
		/// </remarks>
		[NotNull]
		public Brain Build(BrainSettings brainSettings)
		{
			Profiler.BeginSample("BrainBuilder.Build");

			Brain brain = Build(new Blackboard(), brainSettings);

			Profiler.EndSample();

			return brain;
		}

		/// <summary>
		/// Builds a <see cref="Brain"/> with the added actions and considerations.
		/// </summary>
		/// <param name="blackboard"><see cref="Blackboard"/> for the built <see cref="Brain"/>.</param>
		/// <param name="brainSettings">Brain settings.</param>
		/// <returns>Built <see cref="Brain"/>.</returns>
		[NotNull]
		public Brain Build([NotNull] Blackboard blackboard, BrainSettings brainSettings)
		{
			Profiler.BeginSample("BrainBuilder.Build");

			Consideration[] considerations = MakeConsiderations();
			Action[] actions = MakeActions();
			int[][] actionConsiderationsBindings = MakeActionConsiderationsBindings();

			var brain = new Brain(considerations, actions, actionConsiderationsBindings, blackboard, brainSettings);

			Profiler.EndSample();

			return brain;
		}

		/// <summary>
		/// Creates an array of <see cref="Consideration"/> by the added info.
		/// </summary>
		/// <returns>Created array of <see cref="Consideration"/>.</returns>
		[NotNull, ItemNotNull]
		private Consideration[] MakeConsiderations()
		{
			int count = m_considerationBuilders.Count;
			var considerations = new Consideration[count];

			for (int i = 0; i < count; ++i)
			{
				considerations[i] = m_considerationBuilders[i].Build();
			}

			return considerations;
		}

		/// <summary>
		/// Creates an array of <see cref="Action"/> by the added info.
		/// </summary>
		/// <returns>Created array of <see cref="Action"/>.</returns>
		[NotNull, ItemNotNull]
		private Action[] MakeActions()
		{
			int count = m_actionBuilders.Count;
			var actions = new Action[count];

			for (int i = 0; i < count; ++i)
			{
				actions[i] = m_actionBuilders[i].Build();
			}

			return actions;
		}

		/// <summary>
		/// Creates an array of action to considerations bindings.
		/// </summary>
		/// <returns>Created array.</returns>
		[NotNull]
		private int[][] MakeActionConsiderationsBindings()
		{
			int count = m_actionConsiderationsBindings.Count;
			int[][] bindings = new int[count][];

			for (int i = 0; i < count; ++i)
			{
				bindings[i] = m_actionConsiderationsBindings[i].ToArray();
			}

			return bindings;
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("BrainBuilder");

			for (int actionIndex = 0, actionCount = m_actionConsiderationsBindings.Count;
				actionIndex < actionCount;
				++actionIndex)
			{
				stringBuilder.AppendLine($"\t{m_actionBuilders[actionIndex]}");

				List<int> considerationIndices = m_actionConsiderationsBindings[actionIndex];

				for (int considerationIndex = 0, considerationCount = considerationIndices.Count;
					considerationIndex < considerationCount;
					++considerationIndex)
				{
					stringBuilder.AppendLine(
						$"\t\t{m_considerationBuilders[considerationIndices[considerationIndex]]}");
				}
			}

			return stringBuilder.ToString();
		}
	}
}
