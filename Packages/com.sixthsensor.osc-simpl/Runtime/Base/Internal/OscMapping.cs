﻿/*
	Copyright © Carl Emil Carlsen 2016-2023
	http://cec.dk
*/

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace OscSimpl.Internal
{
	[Serializable]
	public class OscMapping
	{
		[FormerlySerializedAs("address")] // Update 1.3 -> 2.0
		[SerializeField] string _address = "/";
		[SerializeField] OscMessageType _type = OscMessageType.OscMessage;
		[SerializeField] List<OscMappingEntry> _entries = new List<OscMappingEntry>();

		bool _isDirty = true;
		bool _dirtyAddressHash = true;
		uint _addressHash;

		// Actions that will be rebuild as needed on the fly.
		Action<OscMessage> _oscMessageAction;
		Action<float> _floatAction;
		Action<double> _doubleAction;
		Action<int> _intAction;
		Action<long> _longAction;
		Action<string> _stringAction;
		Action<char> _charAction;
		Action<bool> _boolAction;
		Action<Color32> _colorAction;
		Action<byte[]> _blobAction;
		Action<OscTimeTag> _timeTagAction;
		Action<OscMidiMessage> _midiMessageAction;
		Action _impulseNullEmptyAction;

		[NonSerialized] bool _hasSpecialPattern;
		[NonSerialized] bool _hasCheckedForSpecialPattern;


		public string address
		{
			get { return _address; }
			set {
				OscAddress.Sanitize( ref value );
				_address = value;
				_hasCheckedForSpecialPattern = false;
				_dirtyAddressHash = true;
			}
		}

		public bool hasSpecialPattern {
			get {
				if( _hasCheckedForSpecialPattern ) return _hasSpecialPattern;
				_hasSpecialPattern = OscAddress.HasAnySpecialPatternCharacter( _address );
				_hasCheckedForSpecialPattern = true;
				return _hasSpecialPattern;
			}
		}

		public OscMessageType type { get { return _type; } }

		public int entryCount { get { return _entries.Count; } }


		public OscMapping( string address, OscMessageType type )
		{
			this.address = address;
			_type = type;
		}


		[MethodImpl( MethodImplOptions.AggressiveInlining )]
		public bool IsMatching( string address )
		{
			if( hasSpecialPattern ) return OscAddress.IsMatching( address, _address );
			return string.Compare( address, _address ) == 0;
		}


		public void AddEmptyEntry()
		{
			_entries.Add( new OscMappingEntry() );
		}


		public void SetDirty()
		{
			_isDirty = true;
			_dirtyAddressHash = true;
		}


		public uint GetAddressHash()
		{
			// Return cached when possible.
			if( !_dirtyAddressHash ) return _addressHash;

			// Compute and return.
			_addressHash = OscStringHash.Pack( _address );
			_dirtyAddressHash = false;
			return _addressHash;
		}


		public static Type OscMessagTypeToSystemType( OscMessageType type )
		{
			Type paramType = null;
			switch( type ) {
				case OscMessageType.OscMessage: paramType = typeof( OscMessage ); break;
				case OscMessageType.Float: paramType = typeof( float ); break;
				case OscMessageType.Double: paramType = typeof( double ); break;
				case OscMessageType.Int: paramType = typeof( int ); break;
				case OscMessageType.Long: paramType = typeof( long ); break;
				case OscMessageType.String: paramType = typeof( string ); break;
				case OscMessageType.Char: paramType = typeof( char ); break;
				case OscMessageType.Bool: paramType = typeof( bool ); break;
				case OscMessageType.Color: paramType = typeof( Color32 ); break;
				case OscMessageType.Blob: paramType = typeof( byte[] ); break;
				case OscMessageType.TimeTag: paramType = typeof( OscTimeTag ); break;
				case OscMessageType.Midi: paramType = typeof( OscMidiMessage ); break;
			}
			return paramType;
		}


		public void Map( Action<OscMessage> m ){ _type = OscMessageType.OscMessage; Map( m.Target, m.Method ); }
		public void Map( Action<float> m ) { _type = OscMessageType.Float; Map( m.Target, m.Method ); }
		public void Map( Action<double> m ) { _type = OscMessageType.Double; Map( m.Target, m.Method ); }
		public void Map( Action<int> m ) { _type = OscMessageType.Int; Map( m.Target, m.Method ); }
		public void Map( Action<long> m ) { _type = OscMessageType.Long; Map( m.Target, m.Method ); }
		public void Map( Action<string> m ) { _type = OscMessageType.String; Map( m.Target, m.Method ); }
		public void Map( Action<char> m ) { _type = OscMessageType.Char; Map( m.Target, m.Method ); }
		public void Map( Action<bool> m ) { _type = OscMessageType.Bool; Map( m.Target, m.Method ); }
		public void Map( Action<Color32> m ) { _type = OscMessageType.Color; Map( m.Target, m.Method ); }
		public void Map( Action<byte[]> m ) { _type = OscMessageType.Blob; Map( m.Target, m.Method ); }
		public void Map( Action<OscTimeTag> m ) { _type = OscMessageType.TimeTag; Map( m.Target, m.Method ); }
		public void Map( Action m ) { _type = OscMessageType.ImpulseNullEmpty; Map( m.Target, m.Method ); }


		public void Unmap( Action<OscMessage> m ) { Unmap( m.Target, m.Method ); }
		public void Unmap( Action<float> m ) { Unmap( m.Target, m.Method ); }
		public void Unmap( Action<double> m ) { Unmap( m.Target, m.Method ); }
		public void Unmap( Action<int> m ) { Unmap( m.Target, m.Method ); }
		public void Unmap( Action<long> m ) { Unmap( m.Target , m.Method ); }
		public void Unmap( Action<string> m ) { Unmap( m.Target, m.Method ); }
		public void Unmap( Action<char> m ) { Unmap( m.Target, m.Method ); }
		public void Unmap( Action<bool> m ) { Unmap( m.Target, m.Method ); }
		public void Unmap( Action<Color32> m ) { Unmap( m.Target, m.Method ); }
		public void Unmap( Action<byte[]> m ) { Unmap( m.Target, m.Method ); }
		public void Unmap( Action<OscTimeTag> m ) { Unmap( m.Target, m.Method ); }
		public void Unmap( Action m ) { Unmap( m.Target, m.Method ); }


		public void Invoke( OscMessage m ) { CleanAndInvoke( ref _oscMessageAction, m ); }
		public void Invoke( float m ) { CleanAndInvoke( ref _floatAction, m ); }
		public void Invoke( double m ) { CleanAndInvoke( ref _doubleAction, m ); }
		public void Invoke( int m ) { CleanAndInvoke( ref _intAction, m ); }
		public void Invoke( long m ) { CleanAndInvoke( ref _longAction, m ); }
		public void Invoke( string m ) { CleanAndInvoke( ref _stringAction, m ); }
		public void Invoke( char m ) { CleanAndInvoke( ref _charAction, m ); }
		public void Invoke( bool m ) { CleanAndInvoke( ref _boolAction, m ); }
		public void Invoke( Color32 m ) { CleanAndInvoke( ref _colorAction, m ); }
		public void Invoke( byte[] m ) { CleanAndInvoke( ref _blobAction, m ); }
		public void Invoke( OscTimeTag m ) { CleanAndInvoke( ref _timeTagAction, m ); }
		public void Invoke( OscMidiMessage m ) { CleanAndInvoke( ref _midiMessageAction, m ); }
		public void Invoke() { CleanAndInvoke( ref _impulseNullEmptyAction ); }



		/// <summary>
		/// Add listender presuming that the method is of compatible data type.
		/// If the target is a property your should reference the set method.
		/// </summary>
		public bool Map( object targetObject, string targetPropertyOrMethodName )
		{
			Type t = targetObject.GetType();
			PropertyInfo info = t.GetProperty( targetPropertyOrMethodName );
			if( info != null ) return Map( targetObject, info.GetSetMethod() );
			return Map( targetObject, t.GetMethod( targetPropertyOrMethodName ) );
		}


		/// <summary>
		/// Add listender presuming that the method is of compatible data type.
		/// If the target is a property your should reference the set method.
		/// </summary>
		public bool Map( object targetObject, MethodInfo targetMethodInfo )
		{
			_entries.Add( new OscMappingEntry( targetObject, targetMethodInfo ) );

			_isDirty = true;

			return true;
		}


		/// <summary>
		/// Add listender presuming that the field is of compatible data type.
		/// If the target is a property your should reference the set method.
		/// </summary>
		public bool Map( object targetObject, FieldInfo targetFieldInfo )
		{
			_entries.Add( new OscMappingEntry( targetObject, targetFieldInfo ) );

			_isDirty = true;

			return true;
		}


		/// <summary>
		/// Remove listener.
		/// If the target is a property your should reference the set method.
		/// </summary>
		public bool Unmap( object targetObject, string targetPropertyOrMethodName )
		{
			Type t = targetObject.GetType();
			PropertyInfo info = t.GetProperty( targetPropertyOrMethodName );
			if( info != null ) return Unmap( targetObject, info.GetSetMethod() );

			return Unmap( targetObject, t.GetMethod( targetPropertyOrMethodName ) );
		}


		/// <summary>
		/// Remove listener.
		/// If the target is a property your should reference the set method.
		/// </summary>
		public bool Unmap( object targetObject, MethodInfo targetMethodInfo )
		{
			string methodName = targetMethodInfo.Name;
			int index = _entries.FindIndex( ( OscMappingEntry e ) => e.targetObject == targetObject && e.targetMethodName == methodName );
			if( index == -1 ) return false;

			_entries.RemoveAt( index );

			_isDirty = true;

			return true;
		}


		/// <summary>
		/// Clean and invoke a method with a single parameter.
		/// </summary>
		void CleanAndInvoke<T>( ref Action<T> action, T m )
		{
			if( _isDirty ) Clean( ref action );
			if( action != null ) action.Invoke( m );
		}


		/// <summary>
		/// Clean and invoke a method with no parameters.
		/// </summary>
		void CleanAndInvoke( ref Action action )
		{
			if( _isDirty ) Clean( ref action );
			if( action != null ) action.Invoke();
		}


		void Clean<T>( ref Action<T> action )
		{
			// Rebuild action.
			action = null;
			Type mappingParamType = OscMessagTypeToSystemType( _type );
			foreach( OscMappingEntry entry in _entries )
			{
				Action<T> entryAction;
				if( entry.TryCreateAction( mappingParamType, out entryAction ) ) {
					action += entryAction;

				} else {
					// Delete methods that are invalid. This could be because the method was renamed.
					entry.ClearTargetMember();
				}
			}

			// Clean!
			_isDirty = false;
		}


		void Clean( ref Action action )
		{
			// Rebuild action.
			action = null;
			foreach( OscMappingEntry entry in _entries )
			{
				Action entryAction;
				if( entry.TryCreateAction( out entryAction ) ) {
					action += entryAction;

				} else {
					// Delete methods that are invalid. This could be because the method was renamed.
					entry.ClearTargetMember();
				}
			}

			// Clean!
			_isDirty = false;
		}
	}
}