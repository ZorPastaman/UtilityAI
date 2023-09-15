// Copyright (c) 2023 Vladimir Popov zor1994@gmail.com https://github.com/ZorPastaman/UtilityAI

namespace Zor.UtilityAI.Core
{
	/// <summary>
	/// Setup interface. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
	/// because they must have only a default constructor.
	/// </summary>
	/// <typeparam name="TArg">Setup method argument type.</typeparam>
	public interface ISetupable<in TArg>
	{
		/// <summary>
		/// Setup method.It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
		/// because they must have only a default constructor.
		/// </summary>
		/// <param name="arg">Setup method argument.</param>
		void Setup(TArg arg);
	}

	/// <summary>
	/// Setup interface. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
	/// because they must have only a default constructor.
	/// </summary>
	/// <typeparam name="TArg0">First setup method argument type.</typeparam>
	/// <typeparam name="TArg1">Second setup method argument type.</typeparam>
	public interface ISetupable<in TArg0, in TArg1>
	{
		/// <summary>
		/// Setup method. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
		/// because they must have only a default constructor.
		/// </summary>
		/// <param name="arg0">First setup method argument.</param>
		/// <param name="arg1">Second setup method argument.</param>
		void Setup(TArg0 arg0, TArg1 arg1);
	}

	/// <summary>
	/// Setup interface. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
	/// because they must have only a default constructor.
	/// </summary>
	/// <typeparam name="TArg0">First setup method argument type.</typeparam>
	/// <typeparam name="TArg1">Second setup method argument type.</typeparam>
	/// <typeparam name="TArg2">Third setup method argument type.</typeparam>
	public interface ISetupable<in TArg0, in TArg1, in TArg2>
	{
		/// <summary>
		/// Setup method. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
		/// because they must have only a default constructor.
		/// </summary>
		/// <param name="arg0">First setup method argument.</param>
		/// <param name="arg1">Second setup method argument.</param>
		/// <param name="arg2">Third setup method argument.</param>
		void Setup(TArg0 arg0, TArg1 arg1, TArg2 arg2);
	}

	/// <summary>
	/// Setup interface. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
	/// because they must have only a default constructor.
	/// </summary>
	/// <typeparam name="TArg0">First setup method argument type.</typeparam>
	/// <typeparam name="TArg1">Second setup method argument type.</typeparam>
	/// <typeparam name="TArg2">Third setup method argument type.</typeparam>
	/// <typeparam name="TArg3">Fourth setup method argument type.</typeparam>
	public interface ISetupable<in TArg0, in TArg1, in TArg2, in TArg3>
	{
		/// <summary>
		/// Setup method. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
		/// because they must have only a default constructor.
		/// </summary>
		/// <param name="arg0">First setup method argument.</param>
		/// <param name="arg1">Second setup method argument.</param>
		/// <param name="arg2">Third setup method argument.</param>
		/// <param name="arg3">Fourth setup method argument.</param>
		void Setup(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3);
	}

	/// <summary>
	/// Setup interface. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
	/// because they must have only a default constructor.
	/// </summary>
	/// <typeparam name="TArg0">First setup method argument type.</typeparam>
	/// <typeparam name="TArg1">Second setup method argument type.</typeparam>
	/// <typeparam name="TArg2">Third setup method argument type.</typeparam>
	/// <typeparam name="TArg3">Fourth setup method argument type.</typeparam>
	/// <typeparam name="TArg4">Fifth setup method argument type.</typeparam>
	public interface ISetupable<in TArg0, in TArg1, in TArg2, in TArg3, in TArg4>
	{
		/// <summary>
		/// Setup method. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
		/// because they must have only a default constructor.
		/// </summary>
		/// <param name="arg0">First setup method argument.</param>
		/// <param name="arg1">Second setup method argument.</param>
		/// <param name="arg2">Third setup method argument.</param>
		/// <param name="arg3">Fourth setup method argument.</param>
		/// <param name="arg4">Fifth setup method argument.</param>
		void Setup(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);
	}

	/// <summary>
	/// Setup interface. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
	/// because they must have only a default constructor.
	/// </summary>
	/// <typeparam name="TArg0">First setup method argument type.</typeparam>
	/// <typeparam name="TArg1">Second setup method argument type.</typeparam>
	/// <typeparam name="TArg2">Third setup method argument type.</typeparam>
	/// <typeparam name="TArg3">Fourth setup method argument type.</typeparam>
	/// <typeparam name="TArg4">Fifth setup method argument type.</typeparam>
	/// <typeparam name="TArg5">Sixth setup method argument type.</typeparam>
	public interface ISetupable<in TArg0, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5>
	{
		/// <summary>
		/// Setup method. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
		/// because they must have only a default constructor.
		/// </summary>
		/// <param name="arg0">First setup method argument.</param>
		/// <param name="arg1">Second setup method argument.</param>
		/// <param name="arg2">Third setup method argument.</param>
		/// <param name="arg3">Fourth setup method argument.</param>
		/// <param name="arg4">Fifth setup method argument.</param>
		/// <param name="arg5">Sixth setup method argument.</param>
		void Setup(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5);
	}

	/// <summary>
	/// Setup interface. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
	/// because they must have only a default constructor.
	/// </summary>
	/// <typeparam name="TArg0">First setup method argument type.</typeparam>
	/// <typeparam name="TArg1">Second setup method argument type.</typeparam>
	/// <typeparam name="TArg2">Third setup method argument type.</typeparam>
	/// <typeparam name="TArg3">Fourth setup method argument type.</typeparam>
	/// <typeparam name="TArg4">Fifth setup method argument type.</typeparam>
	/// <typeparam name="TArg5">Sixth setup method argument type.</typeparam>
	/// <typeparam name="TArg6">Seventh setup method argument type.</typeparam>
	public interface ISetupable<in TArg0, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, in TArg6>
	{
		/// <summary>
		/// Setup method. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
		/// because they must have only a default constructor.
		/// </summary>
		/// <param name="arg0">First setup method argument.</param>
		/// <param name="arg1">Second setup method argument.</param>
		/// <param name="arg2">Third setup method argument.</param>
		/// <param name="arg3">Fourth setup method argument.</param>
		/// <param name="arg4">Fifth setup method argument.</param>
		/// <param name="arg5">Sixth setup method argument.</param>
		/// <param name="arg6">Seventh setup method argument.</param>
		void Setup(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6);
	}

	/// <summary>
	/// Setup interface. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
	/// because they must have only a default constructor.
	/// </summary>
	/// <typeparam name="TArg0">First setup method argument type.</typeparam>
	/// <typeparam name="TArg1">Second setup method argument type.</typeparam>
	/// <typeparam name="TArg2">Third setup method argument type.</typeparam>
	/// <typeparam name="TArg3">Fourth setup method argument type.</typeparam>
	/// <typeparam name="TArg4">Fifth setup method argument type.</typeparam>
	/// <typeparam name="TArg5">Sixth setup method argument type.</typeparam>
	/// <typeparam name="TArg6">Seventh setup method argument type.</typeparam>
	/// <typeparam name="TArg7">Eighth setup method argument type.</typeparam>
	public interface ISetupable<in TArg0, in TArg1, in TArg2, in TArg3, in TArg4, in TArg5, in TArg6, in TArg7>
	{
		/// <summary>
		/// Setup method. It's an equivalent to constructor for <see cref="Consideration"/> or <see cref="Action"/>
		/// because they must have only a default constructor.
		/// </summary>
		/// <param name="arg0">First setup method argument.</param>
		/// <param name="arg1">Second setup method argument.</param>
		/// <param name="arg2">Third setup method argument.</param>
		/// <param name="arg3">Fourth setup method argument.</param>
		/// <param name="arg4">Fifth setup method argument.</param>
		/// <param name="arg5">Sixth setup method argument.</param>
		/// <param name="arg6">Seventh setup method argument.</param>
		/// <param name="arg7">Eighth setup method argument.</param>
		void Setup(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6, TArg7 arg7);
	}

	/// <summary>
	/// Setup interface without arguments. It's an equivalent to constructor for
	/// <see cref="Consideration"/> or <see cref="Action"/> because they must have only a default constructor.
	/// </summary>
	public interface INotSetupable
	{
	}
}
