﻿//
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
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;
using NLog;

namespace NmeaParser
{
	public class SerialPortDevice : NmeaDevice
	{
        private const int VistaMajorVersion = 6;
        private const int VistaMinorVersion = 0;
        private SerialPort m_port;

		public SerialPortDevice(SerialPort port)
		{
            m_port = port;
            
            if (Environment.OSVersion.Version.Major < VistaMajorVersion || 
                (Environment.OSVersion.Version.Major == VistaMajorVersion && Environment.OSVersion.Version.Minor <= VistaMinorVersion))
		    {
                SerialPortFixer.Execute(port.PortName);
            }
        }

		protected override Task<Stream> OpenStreamAsync()
		{
            m_port.Open();
			return TaskEx.FromResult<Stream>(m_port.BaseStream);
		}

		protected override Task CloseStreamAsync(Stream stream)
		{
			m_port.Close();
			return TaskEx.FromResult(true);
		}
	}
}
