﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Models
{
    enum QuestionTimelineAction : byte
    {
        question = 1,
        answer = 2,
        comment = 3,
        unaccepted_answer = 4,
        accepted_answer = 5,
        vote_aggregate = 6,
        revision = 7,
        post_state_changed = 8
    }

    [ProtoContract]
    class QuestionTimeline : IGenericEquality<QuestionTimeline>
    {
        [ProtoMember(1)]
        public QuestionTimelineAction? timeline_type { get; set; }
        [ProtoMember(2)]
        public int? question_id { get; set; }
        [ProtoMember(3)]
        public int? post_id { get; set; }
        [ProtoMember(4)]
        public int? comment_id { get; set; }
        [ProtoMember(5)]
        public string revision_guid { get; set; }
        [ProtoMember(6)]
        public int? up_vote_count { get; set; }
        [ProtoMember(7)]
        public int? down_vote_count { get; set; }
        [ProtoMember(8)]
        public DateTime? creation_date { get; set; }
        [ProtoMember(9)]
        public ShallowUser user { get; set; }
        [ProtoMember(10)]
        public ShallowUser owner { get; set; }

        public bool Equals(QuestionTimeline obj)
        {
            return
                this.comment_id.TrueEquals(obj.comment_id) &&
                this.creation_date.TrueEquals(obj.creation_date) &&
                this.down_vote_count.TrueEquals(obj.down_vote_count) &&
                this.owner.TrueEquals(obj.owner) &&
                this.post_id.TrueEquals(obj.post_id) &&
                this.question_id.TrueEquals(obj.question_id) &&
                this.revision_guid.TrueEqualsString(obj.revision_guid) &&
                this.timeline_type.TrueEquals(obj.timeline_type) &&
                this.up_vote_count.TrueEquals(obj.up_vote_count) &&
                this.user.TrueEquals(obj.user);
        }
    }
}
