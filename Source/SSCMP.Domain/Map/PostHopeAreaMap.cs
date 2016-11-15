using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SSCMP.Domain.Entity;

namespace SSCMP.Domain.Maps
{
    public class PostHopeAreaMap : ClassMap<PostHopeArea>
    {
        public PostHopeAreaMap()
        {
            Table("POST_HOPE_AREA");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.PostCharacter).Column("POST_CHARACTER").Not.Nullable().Length(10);
            Map(x => x.PostId).Column("POST_ID").Not.Nullable().Precision(10);
            Map(x => x.AreaId).Column("AREA_ID").Not.Nullable().Precision(10);
        }
    }
}
