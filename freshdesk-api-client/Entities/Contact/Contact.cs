using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace Freshdesk.Entity
{
    [DataContract]
    public class Contact 
    {
        [DataMember(EmitDefaultValue = false, Name ="active")]
        public bool? Active { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="address")]
        public string Address { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="avatar")]
        public object Avatar { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="company_id")]
        public long? CompanyId { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="view_all_tickets")]
        public bool? ViewAllTickets { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="custom_fields")]
        public Dictionary<string, object> CustomFields { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="deleted")]
        public bool? Deleted { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="description")]
        public string Description { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="email")]
        public string Email { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="id")]
        public long? Id { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="job_title")]
        public string JobTitle { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="language")]
        public string Language { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="mobile")]
        public string Mobile { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="name")]
        public string Name { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="tags")]
        public List<string> Tags { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="time_zone")]
        public string TimeZone { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="twitter_id")]
        public string TwitterId { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="other_companies")]
        public List<string> OtherCompanies { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="created_at")]
        private string _createdAt { get; set; }
        [IgnoreDataMember]
        public DateTime CreatedAt
        {
            get
            {
                return DateTime.ParseExact(_createdAt, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            }
        }

        [DataMember(EmitDefaultValue = false, Name ="updated_at")]
        private string _updatedAt { get; set; }
        [IgnoreDataMember]
        public DateTime UpdatedAt
        {
            get
            {
                return DateTime.ParseExact(_updatedAt, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            }
        }

    }
}
