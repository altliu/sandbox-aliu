/*
Copyright (c) 2005 Tamir Gal, http://www.tamirgal.com, All rights reserved.

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

using System;
using System.Text;
using System.IO;

namespace Tamir.IPLib
{
	/// <summary>
	/// Capture packets from an offline pcap file
	/// </summary>
	/// <author>Tamir Gal</author>
	/// <version>  $Revision$ </version>
	/// <lastModifiedBy>  $Author$ </lastModifiedBy>
	/// <lastModifiedAt>  $Date$ </lastModifiedAt>
	public class PcapOfflineDevice : PcapDevice
	{
		private string m_pcapFile;
		/// <summary>
		/// The description of this device
		/// </summary>
		private const string PCAP_OFFLINE_DESCRIPTION 
			= "Offline pcap file";

		/// <summary>
		/// Constructs a new offline device for reading 
		/// pcap files
		/// </summary>
		/// <param name="pcapFile"></param>
		internal PcapOfflineDevice(string pcapFile)
		{
			m_pcapFile = pcapFile;
		}

		public override string PcapName
		{
			get
			{
				return m_pcapFile;
			}
		}

		public override string PcapDescription
		{
			get
			{
				return PCAP_OFFLINE_DESCRIPTION;
			}
		}

		public long PcapFileSize
		{
			get
			{
				return new FileInfo( PcapName ).Length;
			}
		}


		/// <summary>
		/// The underlying pcap file name
		/// </summary>
		public string PcapFileName
		{
			get{ return System.IO.Path.GetFileName( this.PcapName );}
		}

		/// <summary>
		/// Opens the device for capture
		/// </summary>
		public override void PcapOpen()
		{
			//holds errors
			StringBuilder errbuf = new StringBuilder( SharpPcap.PCAP_ERRBUF_SIZE ); //will hold errors
			//opens offline pcap file
			IntPtr adapterHandle = SharpPcap.pcap_open_offline( this.PcapName, errbuf);

			//handle error
			if ( adapterHandle == IntPtr.Zero)
			{
				string err = "Unable to open offline adapter: "+errbuf.ToString();
				throw new Exception( err );
			}
			//set the local handle
			this.PcapHandle = adapterHandle;
		}
		/// <summary>
		/// Opens the device for capture
		/// </summary>
		/// <param name="promiscuous_mode">This parameter
		/// has no affect on this method since it's an 
		/// offline device</param>
		public override void PcapOpen(bool promiscuous_mode)
		{
			this.PcapOpen();
		}		

		/// <summary>
		/// Opens the device for capture
		/// </summary>
		/// <param name="promiscuous_mode">This parameter
		/// has no affect on this method since it's an 
		/// offline device</param>
		/// <param name="read_timeout">This parameter
		/// has no affect on this method since it's an 
		/// offline device</param>
		public override void PcapOpen(bool promiscuous_mode, int read_timeout)
		{
			this.PcapOpen();
		}

		/// <summary>
		/// Setting a capture filter on this offline device is not supported
		/// </summary>
		public override void PcapSetFilter( string filter )
		{
			throw new PcapException("It is not possible to set a capture filter on an offline device");
		}

//		/// <summary>
//		/// The underlying pcap device handle
//		/// </summary>
//		protected override IntPtr PcapHandle
//		{
//			get
//			{
//				return base.PcapHandle;
//			}
//			set
//			{
//				//This is an offline device so we need to close
//				//the file handle before zeroing the handle
//				if((value==IntPtr.Zero)&&(PcapHandle!=IntPtr.Zero))
//					SharpPcap.pcap_close(PcapHandle);
//				base.PcapHandle = value;
//			}
//		}

	}
}
