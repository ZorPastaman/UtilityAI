// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

using Zor.UtilityAI.Core;

namespace Zor.UtilityAI.Builder
{
	internal sealed class ActionBuilder<TAction> : IActionBuilder where TAction : Action, INotSetupable, new()
	{
		public Action Build()
		{
			return Action.Create<TAction>();
		}
	}

	internal sealed class ActionBuilder<TAction, TArg> : IActionBuilder where TAction : Action, ISetupable<TArg>, new()
	{
		private readonly TArg m_arg;

		public ActionBuilder(TArg arg)
		{
			m_arg = arg;
		}

		public Action Build()
		{
			return Action.Create<TAction, TArg>(m_arg);
		}
	}

	internal sealed class ActionBuilder<TAction, TArg0, TArg1> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;

		public ActionBuilder(TArg0 arg0, TArg1 arg1)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
		}

		public Action Build()
		{
			return Action.Create<TAction, TArg0, TArg1>(m_arg0, m_arg1);
		}
	}

	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;
		private readonly TArg2 m_arg2;

		public ActionBuilder(TArg0 arg0, TArg1 arg1, TArg2 arg2)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
		}

		public Action Build()
		{
			return Action.Create<TAction, TArg0, TArg1, TArg2>(m_arg0, m_arg1, m_arg2);
		}
	}

	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;
		private readonly TArg2 m_arg2;
		private readonly TArg3 m_arg3;

		public ActionBuilder(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
		}

		public Action Build()
		{
			return Action.Create<TAction, TArg0, TArg1, TArg2, TArg3>(m_arg0, m_arg1, m_arg2, m_arg3);
		}
	}

	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;
		private readonly TArg2 m_arg2;
		private readonly TArg3 m_arg3;
		private readonly TArg4 m_arg4;

		public ActionBuilder(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
			m_arg4 = arg4;
		}

		public Action Build()
		{
			return Action.Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4>(m_arg0, m_arg1, m_arg2, m_arg3, m_arg4);
		}
	}

	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;
		private readonly TArg2 m_arg2;
		private readonly TArg3 m_arg3;
		private readonly TArg4 m_arg4;
		private readonly TArg5 m_arg5;

		public ActionBuilder(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
			m_arg4 = arg4;
			m_arg5 = arg5;
		}

		public Action Build()
		{
			return Action.Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5>(m_arg0, m_arg1, m_arg2, m_arg3, m_arg4, m_arg5);
		}
	}

	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;
		private readonly TArg2 m_arg2;
		private readonly TArg3 m_arg3;
		private readonly TArg4 m_arg4;
		private readonly TArg5 m_arg5;
		private readonly TArg6 m_arg6;

		public ActionBuilder(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
			m_arg4 = arg4;
			m_arg5 = arg5;
			m_arg6 = arg6;
		}

		public Action Build()
		{
			return Action.Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(m_arg0, m_arg1, m_arg2, m_arg3, m_arg4, m_arg5, m_arg6);
		}
	}

	internal sealed class ActionBuilder<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> :
		IActionBuilder where TAction : Action, ISetupable<TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>, new()
	{
		private readonly TArg0 m_arg0;
		private readonly TArg1 m_arg1;
		private readonly TArg2 m_arg2;
		private readonly TArg3 m_arg3;
		private readonly TArg4 m_arg4;
		private readonly TArg5 m_arg5;
		private readonly TArg6 m_arg6;
		private readonly TArg7 m_arg7;

		public ActionBuilder(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7)
		{
			m_arg0 = arg0;
			m_arg1 = arg1;
			m_arg2 = arg2;
			m_arg3 = arg3;
			m_arg4 = arg4;
			m_arg5 = arg5;
			m_arg6 = arg6;
			m_arg7 = arg7;
		}

		public Action Build()
		{
			return Action.Create<TAction, TArg0, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(m_arg0, m_arg1, m_arg2, m_arg3, m_arg4, m_arg5, m_arg6, m_arg7);
		}
	}
}
