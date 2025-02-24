﻿/*
	Created by Carl Emil Carlsen.
	Copyright 2016-2023 Sixth Sensor. 
	All rights reserved.
	http://sixthsensor.dk
*/

using UnityEngine;

namespace OscSimpl.Examples
{
	public class Optimisations : MonoBehaviour
	{
		// We will be sending this string as an example.
		public string outgoingText = "Hello";

		// Always store outgoing messages that contain more than one argument.
		OscMessage _outgoingMessage;

		// Always cache incoming strings and blobs so that we only generate 
		// garbage when the strings change content and blobs change length.
		string _incomingText;

		// Always store strings that never change in constants. 
		const string address = "/test";

		OscOut _oscOut;
		OscIn _oscIn;


		void Start()
		{
			// Set up OscIn and OscOut for local testing.
			_oscOut = gameObject.AddComponent<OscOut>();
			_oscIn = gameObject.AddComponent<OscIn>(); 
			_oscOut.Open( 7000 );
			_oscIn.Open( 7000 );

			// OPTIMISATION #1
			// Instantiate outgoing messages once and cache them locally.
			// If you are sending a single argument that is neither a string
			// nor a blob, then you can use the optimised method
			// Send( address, value ) instead.
			_outgoingMessage = new OscMessage( address );

			// OPTIMISATION #2
			// When receving strings and blobs then handle the message yourself.
			// Otherwise new strings and byte arrays will be generated continously.
			_oscIn.Map( address, OnMessageReceived );
		}


		void Update()
		{
			// Update the outgoing message.
			_outgoingMessage.Set( 0, outgoingText );

			// Send the message. It will be bundled automatically with other messages and send in LateUpdate.
			_oscOut.Send( _outgoingMessage );
		}


		void OnMessageReceived( OscMessage incomingMessage )
		{
			// Try to get the string from the message at arg index 0.
			if( incomingMessage.TryGet( 0, ref _incomingText ) )
			{
				// We have now received a string that will only
				// generate garbage when it changes.

				// However, this Debug.Log call will generate garbage. Lots of it ;)
				Debug.Log( _incomingText );
			}

			// OPTIMISATION #4
			// Always recycle incoming messages when you handle them yourself.
			OscPool.Recycle( incomingMessage );
		}
	}
}