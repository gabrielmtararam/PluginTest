using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestPlugin
{
    class DefaultEvents
    {

        public class MyEventArgs
        {
            public String Prop1 { get; set; }
        }
        public void CommandEvent(Object sender, RoutedEventArgs e)
        {
            CommandRoutedEventArgs argumentos = e as CommandRoutedEventArgs;
            String message = argumentos.MyProperty;
            //RotateTransform rotateFirst = argumentos.MyProperty[0];
            // RotateTransform rotateLast = argumentos.MyProperty[1];

        }


    }
}