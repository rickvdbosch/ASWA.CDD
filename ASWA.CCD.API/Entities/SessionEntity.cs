using Azure;
using Azure.Data.Tables;

using System.Runtime.Serialization;

namespace ASWA.CCD.API.Entities
{
    public class SessionEntity : ITableEntity
    {
        #region ITableEntity Members

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        #endregion


        [IgnoreDataMember]
        public string Id { get => RowKey; set => RowKey = value; }
        public string Title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        public string Room { get; set; }
    }
}
