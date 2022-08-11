using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace plannerCRM.Module.BusinessObjects.MyModels
{
    [NavigationItem("MyModels")]
    [Persistent("MyModels.spOrganization")]
    [Appearance("ConiditionOrgView", AppearanceItemType = "LayoutItem", TargetItems = "*", Criteria = "IsActive = false",
        Context = "Any", BackColor = "Red", FontColor = "Maroon", Priority = 1)]
    public class spOrganization : BaseModel
    {
        public spOrganization(Session session) : base(session)
        {
        }


        private long? fChatId;
        [Nullable(true)]
        [RuleRequiredField(DefaultContexts.Save)]
        public long? ChatId
        {
            get { return fChatId; }
            set { SetPropertyValue(nameof(ChatId), ref fChatId, value); }
        }


        private string fAddress;
        [Size(150)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Address
        {
            get { return fAddress; }
            set { SetPropertyValue(nameof(Address), ref fAddress, value); }
        }


        private string fAInfo;
        [Nullable(true)]
        public string Info
        {
            get { return fAInfo; }
            set { SetPropertyValue(nameof(Info), ref fAInfo, value); }
        }


        private float? fLatitudeo;
        [Nullable(true)]
        [RuleRequiredField(DefaultContexts.Save)]
        public float? Latitude
        {
            get { return fLatitudeo; }
            set { SetPropertyValue(nameof(Latitude), ref fLatitudeo, value); }
        }


        private float? fLongitude;
        [Nullable(true)]
        [RuleRequiredField(DefaultContexts.Save)]
        public float? Longitude
        {
            get { return fLongitude; }
            set { SetPropertyValue(nameof(Longitude), ref fLongitude, value); }
        }


        private string fName;
        [Size(100)]
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue(nameof(Name), ref fName, value); }
        }


        private DateTime? fBreakTimeStart;
        [Nullable(true)]
        public DateTime? BreakTimeStart
        {
            get { return fBreakTimeStart; }
            set { SetPropertyValue(nameof(BreakTimeStart), ref fBreakTimeStart, value); }
        }


        private DateTime? fBreakTimeEnd;
        [Nullable(true)]
        public DateTime? BreakTimeEnd
        {
            get { return fBreakTimeEnd; }
            set { SetPropertyValue(nameof(BreakTimeEnd), ref fBreakTimeEnd, value); }
        }


        private DateTime? fWorkStart;
        [Nullable(true)]
        public DateTime? WorkStart
        {
            get { return fWorkStart; }
            set { SetPropertyValue(nameof(WorkStart), ref fWorkStart, value); }
        }


        private DateTime? fWorkEnd;
        [Nullable(true)]
        public DateTime? WorkEnd
        {
            get { return fWorkStart; }
            set { SetPropertyValue(nameof(WorkEnd), ref fWorkEnd, value); }
        }



        private string fMessageUz;
        [Size(150)]
        public string MessageUz
        {
            get { return fMessageUz; }
            set { SetPropertyValue(nameof(MessageUz), ref fMessageUz, value); }
        }


        private string fMessageRu;
        [Size(150)]
        public string MessageRu
        {
            get { return fMessageRu; }
            set { SetPropertyValue(nameof(MessageRu), ref fMessageRu, value); }
        }


        private string fMessageLt;
        [Size(150)]
        public string MessageLt
        {
            get { return fMessageLt; }
            set { SetPropertyValue(nameof(MessageLt), ref fMessageLt, value); }
        }


        private int fOrderIndex;
        [ColumnDefaultValue(1)]
        public int OrderIndex
        {
            get { return fOrderIndex; }
            set { SetPropertyValue(nameof(OrderIndex), ref fOrderIndex, value); }
        }



        private spSpecialization specialization;
        [Association("Specialization-Organization")]
        public spSpecialization Specialization
        {
            get { return specialization; }
            set { SetPropertyValue(nameof(spSpecialization), ref specialization, value); }
        }

        [Association("Analize-Organization")]
        public XPCollection<tbAnalizeResult> tbAnalizeResults
        {
            get
            {
                return GetCollection<tbAnalizeResult>(nameof(tbAnalizeResults));
            }
        }

        private int? fRating;
        [Nullable(true)]
        public int? Rating
        {
            get { return fRating; }
            set { SetPropertyValue(nameof(Rating), ref fRating, value); }
        }

        public string PhotoPath { get; set; }
    }
}
