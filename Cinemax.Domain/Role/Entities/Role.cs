using Cinemax.Domain.Common.Models;
using Cinemax.Domain.Role.ValueObjects;

namespace Cinemax.Domain.Role.Entities;
public class Role: Entity<RoleId>{
    public string Name {get;set;} = null!;
    public virtual ICollection<User.Entities.User> Users {get;set;} = null!;

    #pragma warning disable CS8618
    private Role(){}
    #pragma warning restore CS8618
    private Role(RoleId roleId, string name)
        : base(roleId){
            Name = name;
    }

    public static Role Create(string name){
        return new(RoleId.CreateUnique(), name);
    }

}