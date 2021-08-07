using System;

namespace BLRecords
{
    public abstract class EntityBase
    {
        public bool HasChanges { get; set; }
        public bool IsNew { get; private set; }
        public bool isValid => Validate();
        public abstract bool Validate();

    }
}