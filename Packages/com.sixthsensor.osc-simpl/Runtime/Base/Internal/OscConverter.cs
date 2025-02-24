﻿/*
	Created by Carl Emil Carlsen.
	Copyright 2016-2023 Sixth Sensor.
	All rights reserved.
	http://sixthsensor.dk

	Note: Tests showed that switch statements are faster than Dictionary lookups in this case.
*/

namespace OscSimpl.Internal
{
	public static class OscConverter
	{
		public static OscArgType ToArgType( byte tagByte )
		{
			switch( tagByte )
			{
				case OscConst.tagNullByte:		return OscArgType.Null;
				case OscConst.tagImpulseByte:	return OscArgType.Impulse;
				case OscConst.tagTrueByte:
				case OscConst.tagFalseByte:		return OscArgType.Bool;
				case OscConst.tagFloatByte:		return OscArgType.Float;
				case OscConst.tagIntByte:		return OscArgType.Int;
				case OscConst.tagCharByte:		return OscArgType.Char;
				case OscConst.tagColorByte:		return OscArgType.Color;
				case OscConst.tagMidiByte:		return OscArgType.Midi;
				case OscConst.tagDoubleByte:	return OscArgType.Double;
				case OscConst.tagLongByte:		return OscArgType.Long;
				case OscConst.tagTimetagByte:	return OscArgType.TimeTag;
				case OscConst.tagSymbolByte:
				case OscConst.tagStringByte:	return OscArgType.String;
				case OscConst.tagBlobByte:		return OscArgType.Blob;
			}
			return OscArgType.Unsupported;
		}


		public static byte ToTagByte( OscArgType argType )
		{
			switch( argType )
			{
				case OscArgType.Null:		return OscConst.tagNullByte;
				case OscArgType.Impulse:	return OscConst.tagImpulseByte;
				case OscArgType.Bool:		return OscConst.tagFalseByte; // Bool defaults to false
				case OscArgType.Float:		return OscConst.tagFloatByte;
				case OscArgType.Int:		return OscConst.tagIntByte;
				case OscArgType.Char:		return OscConst.tagCharByte;
				case OscArgType.Color:		return OscConst.tagColorByte;
				case OscArgType.Midi:		return OscConst.tagMidiByte;
				case OscArgType.Double:		return OscConst.tagDoubleByte;
				case OscArgType.Long:		return OscConst.tagLongByte;
				case OscArgType.TimeTag:	return OscConst.tagTimetagByte;
				case OscArgType.String:		return OscConst.tagStringByte;
				case OscArgType.Blob:		return OscConst.tagBlobByte;
			}
			return OscConst.tagUnsupportedByte;
		}

		/*
		// Returns one of four type (fits into 2 bits).
		public static byte ToArgSizeType( byte tagByte )
		{
			switch( tagByte )
			{
				case OscConst.tagNullByte:
				case OscConst.tagImpulseByte:
				case OscConst.tagTrueByte:
				case OscConst.tagFalseByte:
					return OscConst.argSizeTypeZero;
				case OscConst.tagFloatByte:
				case OscConst.tagIntByte:
				case OscConst.tagCharByte:
				case OscConst.tagColorByte:
				case OscConst.tagMidiByte:
					return OscConst.argSizeTypeFour;
				case OscConst.tagDoubleByte:
				case OscConst.tagLongByte:
				case OscConst.tagTimetagByte:
					return OscConst.argSizeTypeFour;
				case OscConst.tagSymbolByte:
				case OscConst.tagStringByte:
				case OscConst.tagBlobByte:
					return OscConst.argSizeTypeVariable;
			}
			return 0;
		}
		*/

		/*
		// Returns one of four type (fits into 2 bits).
		public static byte ToArgSizeType( OscMessageType messageType )
		{
			switch( messageType )
			{
				case OscConst.tagNullByte:
				case OscConst.tagImpulseByte:
				case OscConst.tagTrueByte:
				case OscConst.tagFalseByte:
					return OscConst.argSizeTypeZero;
				case OscConst.tagFloatByte:
				case OscConst.tagIntByte:
				case OscConst.tagCharByte:
				case OscConst.tagColorByte:
				case OscConst.tagMidiByte:
					return OscConst.argSizeTypeFour;
				case OscConst.tagDoubleByte:
				case OscConst.tagLongByte:
				case OscConst.tagTimetagByte:
					return OscConst.argSizeTypeFour;
				case OscConst.tagSymbolByte:
				case OscConst.tagStringByte:
				case OscConst.tagBlobByte:
					return OscConst.argSizeTypeVariable;
			}
			return 0;
		}
		*/
	}
}