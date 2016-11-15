using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SSCMP.Domain.Entity;

namespace SSCMP.Domain.Maps
{    
    public class AreaDataMap : ClassMap<AreaData>
    {
        public AreaDataMap()
        {
            Table("AREA_DATA");
            LazyLoad();
            Id(x => x.AreaId).GeneratedBy.Identity().Column("AREA_ID");
            Map(x => x.AreaName).Column("AREA_NAME").Not.Nullable().Length(10);
            Map(x => x.TreeLevel).Column("TREE_LEVEL").Not.Nullable().Precision(10);
            Map(x => x.OrderNumber).Column("ORDER_NUMBER").Not.Nullable().Precision(10);
            Map(x => x.AreaParentId).Column("AREA_PARENT_ID").Not.Nullable().Precision(10);
        }
    }
}
