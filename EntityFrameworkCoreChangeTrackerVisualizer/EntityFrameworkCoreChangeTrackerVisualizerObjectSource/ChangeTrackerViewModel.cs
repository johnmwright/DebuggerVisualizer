using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EntityFrameworkCoreChangeTrackerVisualizerObjectSource
{


    [Serializable]
    public class ChangeTrackerEntityMemberViewModel
    {
        public ChangeTrackerEntityMemberViewModel(MemberEntry mem)
        {
            IsModified = mem.IsModified;
            CurrentValue = mem.CurrentValue?.ToString() ?? "(null)";
            MetaName = mem.Metadata.Name;
            
        }

        public string MetaName { get; }

        public string CurrentValue { get; }

        public bool IsModified { get; }
    }


    [Serializable]
    public class ChangeTrackerEntityNavigationViewModel
    {
        public ChangeTrackerEntityNavigationViewModel(NavigationEntry nav)
        {

            IsLoaded = nav.IsLoaded;
            IsModified = nav.IsModified;
            CurrentValue = nav.CurrentValue?.ToString() ?? "(null)";
            MetaName = nav.Metadata.Name;
        }

        public bool IsLoaded { get; }

        public bool IsModified { get; }

        public string MetaName { get; }

        public string CurrentValue { get; }

    }


    [Serializable]
    public class ChangeTrackerEntityReferenceViewModel
    {
        public ChangeTrackerEntityReferenceViewModel(ReferenceEntry refr)
        {
            IsLoaded = refr.IsLoaded;
            IsModified = refr.IsModified;
            MetaName = refr.Metadata.Name;
        }

        public bool IsLoaded { get; }
        public bool IsModified { get; }
        public string MetaName { get; }

    }

    [Serializable]
    public class ChangeTrackerEntityViewModel
    {
        public ChangeTrackerEntityViewModel(EntityEntry entity)
        {
            State = entity.State;
            EntityType = entity.Entity.GetType().ToString();
            StrigifiedEntity = entity.Entity.ToString();
            IsKeySet = entity.IsKeySet;
            Members = entity.Members.Select(mem => new ChangeTrackerEntityMemberViewModel(mem)).ToList();
            Navigations = entity.Navigations.Select(nav => new ChangeTrackerEntityNavigationViewModel(nav)).ToList();
            References = entity.References.Select(refr => new ChangeTrackerEntityReferenceViewModel(refr)).ToList();
        }

        public IReadOnlyList<ChangeTrackerEntityReferenceViewModel> References { get; set; }

        public IReadOnlyList<ChangeTrackerEntityNavigationViewModel> Navigations { get; }

        public IReadOnlyList<ChangeTrackerEntityMemberViewModel> Members { get; }
        
        public string ModifiedMembersDescription => $"{ Members.Count(m => m.IsModified)} of {Members.Count}";
        public string ModifiedNavigationsDescription => $"{ Navigations.Count(m => m.IsModified)} of {Navigations.Count}";
        public string ModifiedReferencesDescription => $"{ References.Count(m => m.IsModified)} of {References.Count}";

        public bool IsKeySet { get; }

        public EntityState State { get; }

        public string EntityType { get; }
        public string StrigifiedEntity { get; }

    }


    [Serializable]
    public class ChangeTrackerViewModel
    {
        public ChangeTrackerViewModel(ChangeTracker source)
        {
            ContextName = source.Context.GetType().ToString();
            AutoDetectChangesEnabled = source.AutoDetectChangesEnabled;

            Entries = source.Entries().Select(ent => new ChangeTrackerEntityViewModel(ent)).ToList();

        }

        public bool AutoDetectChangesEnabled { get; }
        public string ContextName { get; }
        public IReadOnlyList<ChangeTrackerEntityViewModel> Entries { get; }

      
    }
}
