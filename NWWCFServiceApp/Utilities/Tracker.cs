using Microsoft.Win32;
using NWWCFServiceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Web;
using System.Diagnostics;

namespace NWWCFServiceApp.Utilities
{
    public static class Tracker
    {
        public static int RegisterTrackingInfo(string methodName)
        {
            var sourceIP = String.Empty;
            var urlRequest = String.Empty;

            try
            {
                var properties = OperationContext.Current.IncomingMessageProperties;

                if (properties.ContainsKey(RemoteEndpointMessageProperty.Name))
                {
                    var endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

                    sourceIP = endpoint?.Address;
                }

                Uri requestUrl = OperationContext.Current.IncomingMessageHeaders.To;
                methodName = String.IsNullOrEmpty(methodName) ? String.Empty : methodName;
                urlRequest = $"{requestUrl.ToString()}";

                var tracker = new WebTracker
                {
                    URLRequest = urlRequest,
                    SourceIP = String.IsNullOrEmpty(sourceIP)?"<Unknown>":sourceIP,
                    TimeOfAction = DateTime.Now
                };

                return RegisterTrackingInfo(tracker);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static int RegisterTrackingInfo(WebTracker webTracker)
        {
            var registers = 0;

            try
            {
                using (var dbContext = new NWDBContext())
                {
                    dbContext.WebTracker.Add(webTracker);
                    registers = dbContext.SaveChanges();
                }

                return registers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetCurrentMethodName()
        {
            // Crear una traza de la pila
            StackTrace stackTrace = new StackTrace();

            // Obtener el marco de la pila actual (el método que está ejecutándose)
            StackFrame frame = stackTrace.GetFrame(1);  // 1 porque 0 sería GetCurrentMethodName()

            // Obtener el nombre del método
            return frame.GetMethod().Name;
        }
    }
}