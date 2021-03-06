﻿﻿//
// Copyright (c) 2014 Morten Nielsen
//
// Licensed under the Microsoft Public License (Ms-PL) (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://opensource.org/licenses/Ms-PL.html
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NmeaParser.Nmea.Gps
{
	/// <summary>
	/// Bearing Origin to Destination
	/// </summary>
	[NmeaMessageType(Type = "GPBOD")]
	public class Gpbod : NmeaMessage
	{
		protected override void LoadMessage(string[] message)
		{
			if (message[0].Length > 0)
				TrueBearing = double.Parse(message[0], CultureInfo.InvariantCulture);
			else
				TrueBearing = double.NaN;
			if (message[2].Length > 0)
				MagneticBearing = double.Parse(message[2], CultureInfo.InvariantCulture);
			else
				MagneticBearing = double.NaN;
			if (message.Length > 4 && !string.IsNullOrEmpty(message[4]))
				DestinationID = message[4];
			if (message.Length > 5 && !string.IsNullOrEmpty(message[5]))
				OriginID = message[5];
		}
		/// <summary>
		/// True Bearing from start to destination
		/// </summary>
		public double TrueBearing { get; private set; }

		/// <summary>
		/// Magnetic Bearing from start to destination
		/// </summary>
		public double MagneticBearing { get; private set; }

		/// <summary>
		/// Name of origin
		/// </summary>
		public string OriginID { get; set; }

		/// <summary>
		/// Name of destination
		/// </summary>
		public string DestinationID { get; set; }
	}
}
