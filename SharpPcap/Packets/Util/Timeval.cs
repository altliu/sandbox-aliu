// $Id$

/// <summary>************************************************************************
/// Copyright (C) 2001, Patrick Charles and Jonas Lehmann                   *
/// Distributed under the Mozilla Public License                            *
/// http://www.mozilla.org/NPL/MPL-1.1.txt                                *
/// *************************************************************************
/// </summary>
using System;
namespace Tamir.IPLib.Packets.Util
{
	
	
	/// <summary> POSIX.4 timeval for Java.
	/// <p>
	/// Container for java equivalent of c's struct timeval.
	/// 
	/// </summary>
	/// <author>  Patrick Charles and Jonas Lehmann
	/// </author>
	/// <version>  $Revision$
	/// </version>
	/// <lastModifiedBy>  $Author$ </lastModifiedBy>
	/// <lastModifiedAt>  $Date$ </lastModifiedAt>
	[Serializable]
	public class Timeval
	{
        private const long BASE_TICKS = 621355968000000000;

		/// <summary> Convert this timeval to a java Date.</summary>
		virtual public System.DateTime Date
		{
			get
			{
				//UPGRADE_TODO: Constructor 'java.util.Date.Date' was converted to 'System.DateTime.DateTime' which has a different behavior. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1073_javautilDateDate_long'"
                long ticks = BASE_TICKS + seconds * 10000000 + microseconds * 10;
                return new System.DateTime(ticks); 
			}
			
		}
		virtual public long Seconds
		{
			get
			{
				return seconds;
			}
			
		}
		virtual public int MicroSeconds
		{
			get
			{
				return microseconds;
			}
			
		}
		public Timeval(long seconds, int microseconds)
		{
			this.seconds = seconds;
			this.microseconds = microseconds;
		}
		
		public override System.String ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append(seconds);
			sb.Append('.');
			sb.Append(microseconds);
			sb.Append('s');
			
			return sb.ToString();
		}
		
		internal long seconds;
		internal int microseconds;
	}
}