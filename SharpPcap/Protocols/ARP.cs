using System;
using Tamir.IPLib;
using Tamir.IPLib.Packets;
using Tamir.IPLib.Util;

/*
Copyright (c) 2006 Tamir Gal, http://www.tamirgal.com, All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

	1. Redistributions of source code must retain the above copyright notice,
		this list of conditions and the following disclaimer.

	2. Redistributions in binary form must reproduce the above copyright 
		notice, this list of conditions and the following disclaimer in 
		the documentation and/or other materials provided with the distribution.

	3. The names of the authors may not be used to endorse or promote products
		derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED ``AS IS'' AND ANY EXPRESSED OR IMPLIED WARRANTIES,
INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE AUTHOR
OR ANY CONTRIBUTORS TO THIS SOFTWARE BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA,
OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE,
EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

namespace Tamir.IPLib.Protocols
{
	/// <summary>
	/// Resolves MAC addresses from IP addresses using the Address Resolution Protocol (ARP)
	/// </summary>
	/// <author>Tamir Gal</author>
	/// <version>  $Revision$ </version>
	/// <lastModifiedBy>  $Author$ </lastModifiedBy>
	/// <lastModifiedAt>  $Date$ </lastModifiedAt>
	public class ARP
	{
		private string			_localMAC;
		private string			_localIP;
		private string			_deviceName;

		/// <summary>
		/// Constructs a new ARP Resolver
		/// </summary>
		public ARP()
		{
		}

		/// <summary>
		/// Constructs a new ARP Resolver
		/// </summary>
		/// <param name="deviceName">The name of the network device on which this resolver sends its ARP packets</param>
		public ARP(string deviceName)
		{
			DeviceName=deviceName;
		}

		/// <summary>
		/// The source MAC address to be used for ARP requests.
		/// If null, the local device MAC address is used
		/// </summary>
		public string LocalMAC
		{
			get
			{
				return _localMAC;
			}
			set
			{
				_localMAC = value;
			}
		}

		/// <summary>
		/// The source IP address to be used for ARP requests.
		/// If null, the local device IP address is used
		/// </summary>
		public string LocalIP
		{
			get
			{
				return _localIP;
			}
			set
			{
				_localIP = value;
			}
		}

		/// <summary>
		/// The default device name on which to send ARP requests
		/// </summary>
		public string DeviceName
		{
			get
			{
				return _deviceName;
			}
			set
			{
				_deviceName = value;
			}
		}

		/// <summary>
		/// Resolves the MAC address of the specified IP address. The 'DeviceName' propery must be set
		/// prior to using this method.
		/// </summary>
		/// <param name="destIP">The IP address to resolve</param>
		/// <returns>The MAC address that matches to the given IP address</returns>
		public string Resolve(String destIP)
		{
			if(DeviceName==null)
				throw new Exception("Can't resolve host: A network device must be specified");

			return Resolve(destIP, DeviceName);
		}

		/// <summary>
		/// Resolves the MAC address of the specified IP address
		/// </summary>
		/// <param name="destIP">The IP address to resolve</param>
		/// <param name="deviceName">The local network device name on which to send the ARP request</param>
		/// <returns>The MAC address that matches to the given IP address</returns>
		public string Resolve(String destIP, string deviceName)
		{
			string localMAC = LocalMAC;
			string localIP = LocalIP;			
			NetworkDevice device = new NetworkDevice(DeviceName);

			//if no local IP and MAC addresses specified, use the ones
			//configured on the local device
			if(localIP==null)
				localIP	= device.IpAddress;
			if(LocalMAC==null)
				localMAC = device.MacAddress;

			//Build a new ARP request packet
			ARPPacket request = BuildRequest(destIP, localMAC, localIP);

			//create a "tcpdump" filter for allowing only arp replies to be read
			String arpFilter = "arp and ether dst " + IPUtil.MacFormat(localMAC);

			//open the device with 20ms timeout
			device.PcapOpen(true, 20);
			//set the filter
			device.PcapSetFilter(arpFilter);
			//inject the packet to the wire
			device.PcapSendPacket(request);

			ARPPacket reply;

			while(true)
			{
				//read the next packet from the network
				reply = (ARPPacket)device.PcapGetNextPacket();
				if(reply==null)continue;
                
				//if this is the reply we're looking for, stop
				if(reply.ARPSenderProtoAddress.Equals(destIP))
				{
					break;
				}
			}
			//free the device
			device.PcapClose();
			//return the resolved MAC address
			return reply.ARPSenderHwAddress;
		}


		private ARPPacket BuildRequest(string destIP, string localMAC, string localIP)
		{
			ARPPacket arp = BuildARP(localMAC, localIP);
			arp.ARPOperation = ARPFields_Fields.ARP_OP_REQ_CODE;
			arp.ARPTargetHwAddress = "00:00:00:00:00:00";
			arp.ARPTargetProtoAddress = destIP;
			arp.DestinationHwAddress = "ff:ff:ff:ff:ff:ff";
			return arp;
		}

		private ARPPacket BuildARP(string localMAC, string localIP)
		{
			ARPPacket arp = new ARPPacket(14, new byte[60]);
			// arp fields
			arp.ARPHwLength = 6;
			arp.ARPHwType = ARPFields_Fields.ARP_ETH_ADDR_CODE;
			arp.ARPProtocolLength = 4;
			arp.ARPProtocolType = ARPFields_Fields.ARP_IP_ADDR_CODE;
			arp.ARPSenderHwAddress = localMAC;
			arp.ARPSenderProtoAddress = localIP;
			// ether fields
			arp.SourceHwAddress = localMAC;
			arp.EthernetProtocol = EthernetProtocols_Fields.ARP;
			return arp;
		}
	}
}
