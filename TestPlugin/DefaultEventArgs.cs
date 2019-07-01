using Proculus.UnicViewTerminal.PluginApi.BaseClasses.Payloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestPlugin
{


    public class CommandExecEventArgs : EventArgs
    {
        public CommandExecEventArgs(byte header, byte bytecount, byte command, byte address, byte valueCount, byte[] values)
        {
            _header = header;
            _bytecount = bytecount;
            _command = command;
            _address = address;
            _values = values;
            _valueCount = valueCount;
        }
        public byte _header { get; }
        public byte _bytecount { get; }
        public byte _command { get; }
        public byte _address { get; }
        public byte _valueCount { get; }
        public byte[] _values { get; }

    }

    public class CommandCompleteEventArgs : EventArgs
    {
        public CommandCompleteEventArgs(DataOutPayloadBase command)
        {
            _command = command;
        }
        public DataOutPayloadBase _command { get; }
      
    }



  


}








//List<RotateTransform> result = rotateEventHandler.OnDragDelta(sender, e);
//RaiseEvent(new RotateRoutedEventArgs(RotateAdornerVisual.RotateRoutedEvent, sender, result));
       