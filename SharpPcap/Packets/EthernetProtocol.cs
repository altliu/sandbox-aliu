// $Id$

/// <summary>************************************************************************
/// Copyright (C) 2001, Patrick Charles and Jonas Lehmann                   *
/// Distributed under the Mozilla Public License                            *
/// http://www.mozilla.org/NPL/MPL-1.1.txt                                *
/// *************************************************************************
/// </summary>
using System;
namespace Tamir.IPLib.Packets
{
	
	
	/// <summary> Ethernet protocol utility class.
	/// 
	/// </summary>
	/// <author>  Patrick Charles and Jonas Lehmann
	/// </author>
	/// <version>  $Revision$
	/// </version>
	/// <lastModifiedBy>  $Author$ </lastModifiedBy>
	/// <lastModifiedAt>  $Date$ </lastModifiedAt>
	public class EthernetProtocol : EthernetProtocols, EthernetFields
	{
		/// <summary> Extract the protocol type field from packet data.
		/// <p>
		/// The type field indicates what type of data is contained in the 
		/// packet's data block.
		/// </summary>
		/// <param name="packetBytes">packet bytes.
		/// </param>
		/// <returns> the ethernet type code. i.e. 0x800 signifies IP datagram.
		/// </returns>
		public static int extractProtocol(byte[] packetBytes)
		{
			// convert the bytes that contain the type code into a value..
			return packetBytes[EthernetFields_Fields.ETH_CODE_POS] << 8 | packetBytes[EthernetFields_Fields.ETH_CODE_POS + 1];
		}
	}
}