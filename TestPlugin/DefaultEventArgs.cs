using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestPlugin
{
    public class CommandRoutedEventArgs : RoutedEventArgs
    {
        public CommandRoutedEventArgs(RoutedEvent routedEvent, Object source, String message) : base(routedEvent, source)
        {
            MyProperty = message; ;

        }
        public String MyProperty { get; set; }

    }

  


}








//List<RotateTransform> result = rotateEventHandler.OnDragDelta(sender, e);
//RaiseEvent(new RotateRoutedEventArgs(RotateAdornerVisual.RotateRoutedEvent, sender, result));
       