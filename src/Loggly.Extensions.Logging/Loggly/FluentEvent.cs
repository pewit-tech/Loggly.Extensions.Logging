﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Loggly
{
    /// <summary>
    /// Wrapper for a Loggly.Event which provides a fluent API for setting properties
    /// </summary>
    public class FluentEvent : FluentEventBase<FluentEvent>
    {
        // inherits for creating a simple API
    }

    /// <summary>
    /// Base class for the FluentEvent wrapper that enables a simple inheritance model
    /// </summary>
    /// <typeparam name="T">A user-defined event wrapper that inherits from the FluentEvent class</typeparam>
    public class FluentEventBase<T> : IFluentEvent<T> where T : class, IFluentEvent<T>, new()
    {
        protected Event _event = new Event();
        protected LogClient _client;

        protected FluentEventBase()
        {
        }

        internal static T Create()
        {
            return new T();
        }

        #region Fluent Methods

        /// <summary>
        /// Property that exposes the underlying Loggly.Event class
        /// </summary>
        public Event Event
        {
            get
            {
                return _event;
            }
        }

  

        /// <summary>
        /// Posts this event to Loggly
        /// </summary>
        /// <param name="Async">A bool that specifies how the event should be posted. Typically an application will post asynchronously for best performance, but sometimes an event needs to be posted synchronously if the application needs to block until the event has completed posting</param>
        /// <returns></returns>
        public virtual T Post(string apiKey)
        {
            if (_client == null)
            {
                _client = new LogClient(apiKey);
            }
            _client.Post(this.Event);
            return this as T;
        }

        /// <summary>
        /// Resets the underlying Loggly.Event properties
        /// </summary>
        /// <returns></returns>
        public virtual T Clear()
        {
            _event = new Event();
            return this as T;
        }

        /// <summary>
        /// Assigns the Loggly.Event's Text property
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public virtual T Text(string Text)
        {
            this.Event.Text = AssignWithMacro(Text, this.Event.Text);
            return this as T;
        }

        /// <summary>
        /// Assigns the Loggly.Event's Text property using a formatted list of arguments
        /// </summary>
        /// <param name="FormatString"></param>
        /// <param name="FormatArguments"></param>
        /// <returns></returns>
        public virtual T Text(string FormatString, params object[] FormatArguments)
        {
            return Text(string.Format(FormatString, FormatArguments));
        }

        /// <summary>
        /// Appends text to the Loggly.Event's Text property
        /// </summary>
        /// <param name="Text">Text to append</param>
        /// <returns></returns>
        public virtual T AddText(string Text)
        {
            this.Event.Text += AssignWithMacro(Text, this.Event.Text);
            return this as T;
        }

        /// <summary>
        /// Appends text to the Loggly.Event's Text property using a formatted list of arguments
        /// </summary>
        /// <param name="FormatString"></param>
        /// <param name="FormatArguments"></param>
        /// <returns></returns>
        public virtual T AddText(string FormatString, params object[] FormatArguments)
        {
            return AddText(string.Format(FormatString, FormatArguments));
        }

        /// <summary>
        /// Assigns the Loggly.Event's Link property
        /// </summary>
        /// <param name="Link"></param>
        /// <returns></returns>
        public virtual T Link(string Link)
        {
            this.Event.Link = AssignWithMacro(Link, this.Event.Link);
            return this as T;
        }

        /// <summary>
        /// Assigns the Loggly.Event's Link property using a formatted list of arguments
        /// </summary>
        /// <param name="FormatString"></param>
        /// <param name="FormatArguments"></param>
        /// <returns></returns>
        public virtual T Link(string FormatString, params object[] FormatArguments)
        {
            return Link(string.Format(FormatString, FormatArguments));
        }

        /// <summary>
        /// Assigns the Loggly.Event's Source property
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public virtual T Source(string Source)
        {
            this.Event.Source = AssignWithMacro(Source, this.Event.Source);
            return this as T;
        }

        /// <summary>
        /// Assigns the Loggly.Event's Source property using a formatted list of arguments
        /// </summary>
        /// <param name="FormatString"></param>
        /// <param name="FormatArguments"></param>
        /// <returns></returns>
        public virtual T Source(string FormatString, params object[] FormatArguments)
        {
            return Source(string.Format(FormatString, FormatArguments));
        }

        /// <summary>
        /// Assigns the Loggly.Event's User property
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public virtual T User(string User)
        {
            this.Event.User = AssignWithMacro(User, this.Event.User);
            return this as T;
        }

        /// <summary>
        /// Assigns the Loggly.Event's User property using a formatted list of arguments
        /// </summary>
        /// <param name="FormatString"></param>
        /// <param name="FormatArguments"></param>
        /// <returns></returns>
        public virtual T User(string FormatString, params object[] FormatArguments)
        {
            return User(string.Format(FormatString, FormatArguments));
        }

        /// <summary>
        /// Assigns the Loggly.Event's Timestamp property.
        /// This is used to indicate when an event was created. This is typically not needed unless your application
        /// is queuing events for later posting to Loggly.
        /// </summary>
        /// <param name="Timestamp">When the event occured, in local time. It will be converted to Coordinated Universal Time (UTC) to be sent to Loggly.</param>
        /// <returns></returns>
        public virtual T Timestamp(DateTime Timestamp)
        {
            return this.Timestamp(Timestamp, true);
        }

        /// <summary>
        /// Assigns the Loggly.Event's Timestamp property.
        /// This is used to indicate when an event was created. This is typically not needed unless your application
        /// is queuing events for later posting to Loggly.
        /// </summary>
        /// <param name="Timestamp">When the event occured. </param>
        /// <param name="convertToUTC">Convert the timestamp to Coordinated Universal Time (UTC) which is required by Loggly</param>
        /// <returns></returns>
        public virtual T Timestamp(DateTime Timestamp, bool convertToUTC)
        {
            if (convertToUTC)
                this.Event.Timestamp = Timestamp.ToUniversalTime();
            else this.Event.Timestamp = Timestamp;
            return this as T;
        }

        /// <summary>
        /// Resets the Loggly.Event's Timestamp property
        /// </summary>
        /// <returns></returns>
        public virtual T TimestampClear()
        {
            this.Event.Timestamp = null;
            return this as T;
        }

        /// <summary>
        /// Assigns the Loggly.Event's Tags property using a space-delimited list of tags
        /// </summary>
        /// <param name="Tags"></param>
        /// <returns></returns>
        public virtual T Tags(string Tags)
        {
            this.Event.Tags = new List<string>();
            return this.AddTags(Tags);
        }

        /// <summary>
        /// Assigns the Loggly.Event's Tags property using a string array of tags
        /// </summary>
        /// <param name="Tags"></param>
        /// <returns></returns>
        public virtual T Tags(string[] Tags)
        {
            this.Event.Tags = new List<string>();
            return this.AddTags(Tags);
        }

        /// <summary>
        /// Appends the Loggly.Event's Tags property using a space-delimited list of tags
        /// </summary>
        /// <param name="Tags"></param>
        /// <returns></returns>
        public virtual T AddTags(string Tags)
        {
            this.Event.Tags.AddRange(Utility.Tags.TokenizeAndFormat(Tags));
            return this as T;
        }

        /// <summary>
        /// Appends the Loggly.Event's Tags property using a string array of tags
        /// </summary>
        /// <param name="Tags"></param>
        /// <returns></returns>
        public virtual T AddTags(string[] Tags)
        {
            this.Event.Tags.AddRange(Utility.Tags.TokenizeAndFormat(Tags));
            return this as T;
        }

        /// <summary>
        /// Assigns the Loggly.Event's Value property
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        public virtual T Value(double Value)
        {
            this.Event.Value = Value;
            return this as T;
        }

        /// <summary>
        /// Resets the Loggly.Event's Value property
        /// </summary>
        /// <returns></returns>
        public virtual T ValueClear()
        {
            this.Event.Value = null;
            return this as T;
        }

        /// <summary>
        /// Assigns the Loggly.Event's Data property
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public virtual T Data(string Data)
        {
            this.Event.Data = AssignWithMacro(Data, this.Event.Data);
            return this as T;
        }

        /// <summary>
        /// Assigns the Loggly.Event's Data property using a formatted list of arguments
        /// </summary>
        /// <param name="FormatString"></param>
        /// <param name="FormatArguments"></param>
        /// <returns></returns>
        public virtual T Data(string FormatString, params object[] FormatArguments)
        {
            return Data(string.Format(FormatString, FormatArguments));
        }

        /// <summary>
        /// Appends the Loggly.Event's Data property
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public virtual T AddData(string Data)
        {
            this.Event.Data += AssignWithMacro(Data, this.Event.Data);
            return this as T;
        }

        /// <summary>
        /// Appends the Loggly.Event's Data property using a formatted list of arguments
        /// </summary>
        /// <param name="FormatString"></param>
        /// <param name="FormatArguments"></param>
        /// <returns></returns>
        public virtual T AddData(string FormatString, params object[] FormatArguments)
        {
            return AddData(string.Format(FormatString, FormatArguments));
        }

        /// <summary>
        /// Sets the type of Data for the Loggly.Event's Data property
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public virtual T DataType(DataType type)
        {
            this.Event.DataType = type;
            return this as T;
        }

        /// <summary>
        /// Assigns the Loggly.Event's Geo property using a latitude and longitude
        /// </summary>
        /// <param name="Lat">Double representing the latitude of the event's location</param>
        /// <param name="Lon">Double representing the longitude of the event's location</param>
        /// <returns></returns>
        public virtual T Geo(double Lat, double Lon)
        {
            this.Event.Geo = String.Format(CultureInfo.InvariantCulture, "{0},{1}", Lat, Lon);
            return this as T;
        }

        /// <summary>
        /// Assigns the Loggly.Event's Geo property using a latitude and longitude
        /// </summary>
        /// <param name="Lat">string representing the latitude of the event's location</param>
        /// <param name="Lon">string representing the longitude of the event's location</param>
        /// <returns></returns>
        public virtual T Geo(string Lat, string Lon)
        {
            double lat = 0, lon = 0;
            double.TryParse(Lat, NumberStyles.Any, CultureInfo.InvariantCulture, out lat);
            double.TryParse(Lon, NumberStyles.Any, CultureInfo.InvariantCulture, out lon);
            return this.Geo(lat, lon);
        }

        /// <summary>
        /// Assigns the Loggly.Event's Geo property using an IP address (translated to latitude and longitude at the server)
        /// </summary>
        /// <param name="IPAddress"></param>
        /// <returns></returns>
        public virtual T GeoIP(string IPAddress)
        {
            this.Event.Geo = String.Format("ip:{0}", IPAddress);
            return this as T;
        }

        /// <summary>
        /// Resets the Loggly.Event's Geo property
        /// </summary>
        /// <returns></returns>
        public virtual T GeoClear()
        {
            this.Event.Geo = null;
            return this as T;
        }

 

        /// <summary>
        /// Specifies posting keys the event should be posted with (by-passes the application's configuration file) 
        /// </summary>
        /// <param name="apiKey">Key used to provide access to API on Loggly</param>
        /// <returns></returns>
        public T UseLog(string apiKey)
        {
            _client = new LogClient(apiKey);
            return this as T;
        }

        /// <summary>
        /// Specifies the log client the event should be posted with (mainly used for testing)
        /// </summary>
        /// <param name="client">The LogClient to use</param>
        /// <returns></returns>
        public T UseLogClient(LogClient client)
        {
            _client = client;
            return this as T;
        }

        #endregion

        #region Protected Methods

        protected string AssignWithMacro(string Input, string Base)
        {
            return Input.Replace("$$", Base);
        }

        #endregion
    }
}
