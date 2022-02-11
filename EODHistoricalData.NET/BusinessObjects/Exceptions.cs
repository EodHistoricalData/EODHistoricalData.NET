namespace EODHistoricalData.NET.BusinessObjects
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;

    [Serializable]
    public class EODException : ApplicationException
    {
        public HttpStatusCode Status { get; private set; }
        public string Details { get; private set; }
        public EODException(HttpStatusCode status, string message, string details)
            : this(message, null)
        {
            this.Details = details;
            this.Status = status;
        }

        public EODException() : this("Something has gone wrong.", null) { }
        public EODException(string message, Exception inner = null) : base(message, inner) { }

        protected EODException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this.Details = info.GetString("Details");
            this.Status = (HttpStatusCode)info.GetValue("Status", typeof(HttpStatusCode));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            info.AddValue("Details", this.Details);
            info.AddValue("Status", this.Status);
            base.GetObjectData(info, context);
        }
    }
}
