﻿/*
	Created by Carl Emil Carlsen.
	Copyright 2018-2023 Sixth Sensor.
	All rights reserved.
	http://sixthsensor.dk

	In this class, we use StructLayout Explicit to convert from and to bytes,
	without generating garbage.
*/


using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace OscSimpl.Internal
{
	[Serializable, StructLayout( LayoutKind.Explicit )]
	public struct EightByteOscData
	{
		[FieldOffset( 0 )] double _doubleValue;
		[FieldOffset( 0 )] long _longValue;
		[FieldOffset( 0 )] OscTimeTag _timeTagValue;
		[FieldOffset( 0 )] Vector2 _vector2Value;
		[FieldOffset( 0 )] Vector2Int _vector2IntValue;
		[FieldOffset( 0 )] byte _b0;
		[FieldOffset( 1 )] byte _b1;
		[FieldOffset( 2 )] byte _b2;
		[FieldOffset( 3 )] byte _b3;
		[FieldOffset( 4 )] byte _b4;
		[FieldOffset( 5 )] byte _b5;
		[FieldOffset( 6 )] byte _b6;
		[FieldOffset( 7 )] byte _b7;

		public const int byteCount = 8;

		public double doubleValue { get { return _doubleValue; } }
		public long longValue { get { return _longValue; } }
		public OscTimeTag timeTagValue { get { return _timeTagValue; } }
		public Vector2 vector2Value { get { return _vector2Value; } }
		public Vector2Int vector2IntValue { get { return _vector2IntValue; } }


		public EightByteOscData( byte b0, byte b1, byte b2, byte b3, byte b4, byte b5, byte b6, byte b7 ) : this()
		{
			if( BitConverter.IsLittleEndian ) {
				_b0 = b7;
				_b1 = b6;
				_b2 = b5;
				_b3 = b4;
				_b4 = b3;
				_b5 = b2;
				_b6 = b1;
				_b7 = b0;
			} else {
				_b0 = b0;
				_b1 = b1;
				_b2 = b2;
				_b3 = b3;
				_b4 = b4;
				_b5 = b5;
				_b6 = b6;
				_b7 = b7;
			}
		}


		public EightByteOscData( double value ) : this() { _doubleValue = value; }
		public EightByteOscData( long value ) : this() { _longValue = value; }
		public EightByteOscData( OscTimeTag value ) : this() { _timeTagValue = value; }
		public EightByteOscData( Vector2 value ) : this() { _vector2Value = value; }
		public EightByteOscData( Vector2Int value ) : this() { _vector2IntValue = value; }


		public static bool TryReadFrom( byte[] data, ref int index, out EightByteOscData value )
		{
			if( index + byteCount > data.Length ) {
				value =new EightByteOscData();
				return false;
			}
			value = new EightByteOscData( data[index++], data[index++], data[index++], data[index++], data[index++], data[index++], data[index++], data[index++] );
			return true;
		}


		public bool TryWriteTo( byte[] data, ref int index )
		{
			if( index + byteCount > data.Length ) return false;

			if( BitConverter.IsLittleEndian ) {
				data[index++] = _b7;
				data[index++] = _b6;
				data[index++] = _b5;
				data[index++] = _b4;
				data[index++] = _b3;
				data[index++] = _b2;
				data[index++] = _b1;
				data[index++] = _b0;
			} else {
				data[index++] = _b0;
				data[index++] = _b1;
				data[index++] = _b2;
				data[index++] = _b3;
				data[index++] = _b4;
				data[index++] = _b5;
				data[index++] = _b6;
				data[index++] = _b7;
			}

			return true;
		}
	}
}