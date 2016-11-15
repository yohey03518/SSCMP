using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SSCMP.Domain.Entity;

namespace SSCMP.Domain.Maps
{
    public class LearnTypeDataMap : ClassMap<LearnTypeData>
    {
        public LearnTypeDataMap()
        {
            Table("LEARN_TYPE_DATA");
            LazyLoad();
            Id(x => x.TypeId).GeneratedBy.Identity().Column("TYPE_ID");
            Map(x => x.TypeName).Column("TYPE_NAME").Not.Nullable().Length(10);
            Map(x => x.TreeLevel).Column("TREE_LEVEL").Not.Nullable().Precision(10);
            Map(x => x.OrderNumber).Column("ORDER_NUMBER").Not.Nullable().Precision(10);
            Map(x => x.TypeParentId).Column("TYPE_PARENT_ID").Not.Nullable().Precision(10);
        }
    }
}
