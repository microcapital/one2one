using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OneTwoOne.Infrastructure.Models;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Cms.Models
{
    public class MenuItem : EntityBase
    {
        public long? ParentId { get; set; }

        public MenuItem Parent { get; set; }

        public IList<MenuItem> Children { get; protected set; } = new List<MenuItem>();

        public long MenuId { get; set; }

        public Menu Menu { get; set; }

        public long? EntityId { get; set; }

        public Entity Entity { get; set; }

        [StringLength(450)]
        public string CustomLink { get; set; }

        [StringLength(450)]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }
    }
}
