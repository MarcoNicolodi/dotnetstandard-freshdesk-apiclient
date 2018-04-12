using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace Freshdesk.Entity
{
    [DataContract]
    public class Ticket
    {
        [DataMember(EmitDefaultValue = false, Name ="attachments")]
        public object[] Attachments { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="cc_emails")]
        public string[] CcEmails { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="company_id")]
        public long? CompanyId { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="custom_fields")]
        public Dictionary<string, string> CustomFields { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="deleted")]
        public bool Deleted { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="description")]
        public string Description { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="description_text")]
        public string DescriptionText { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="due_by")]
        private string _dueBy { get; set; }
        [IgnoreDataMember]
        public DateTime DueBy
        {
            get
            {
                return DateTime.ParseExact(_dueBy, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            }
        }
        [DataMember(EmitDefaultValue = false, Name ="email")]
        public string Email { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="email_config_id")]
        public long? EmailConfigId { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="facebook_id")]
        public string FacebookId { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="fr_due_by")]
        private string _frDueBy { get; set; }
        [IgnoreDataMember]
        public DateTime FrDueBy
        {
            get
            {
                return DateTime.ParseExact(_frDueBy, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
            }
        }
        [DataMember(EmitDefaultValue = false, Name ="fr_escalated")]
        public bool FrEscalated { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="fwd_emails")]
        public string[] FwdEmails { get; set; }
        //needs to be long
        [DataMember(EmitDefaultValue = false, Name ="group_id")]
        public long? GroupId { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="id")]
        public long? Id { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="is_escalated")]
        public bool IsEscalated { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="name")]
        public string Name { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="priority")]
        public TicketPriority Priority { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="product_id")]
        public long? ProductId { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="reply_cc_emails")]
        public List<string> ReplyCcEmails { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="requester_id")]
        public long? RequesterId { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="responder_id")]
        public long? ResponderId { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="source")]
        public TicketSource Source { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="spam")]
        public bool Spam { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="status")]
        public TicketStatus Status { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="subject")]
        public string Subject { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="tags")]
        public List<string> Tags { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="to_emails")]
        public List<string> ToEmails { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="twitter_id")]
        public string TwitterId { get; set; }
        [DataMember(EmitDefaultValue = false, Name ="type")]
        public string Type { get; set; }
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