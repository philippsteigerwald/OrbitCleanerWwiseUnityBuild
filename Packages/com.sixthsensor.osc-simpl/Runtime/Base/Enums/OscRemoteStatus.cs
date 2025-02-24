﻿/*
	Created by Carl Emil Carlsen.
	Copyright 2016-2023 Sixth Sensor.
	All rights reserved.
	http://sixthsensor.dk
*/

namespace OscSimpl
{
	/// <summary>
	/// Enum representing the connection status to a remote device.
	/// Can be either Connected, Disconnected or Unknown.
	/// For broadcast and multicast mode the status will always be Unknown.
	/// </summary>
	public enum OscRemoteStatus { Connected, Disconnected, Unknown }
}