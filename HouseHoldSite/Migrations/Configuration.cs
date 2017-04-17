using HouseHoldSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace HouseHoldSite.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<HouseHoldSite.Models.ApplicationDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(HouseHoldSite.Models.ApplicationDbContext context)
		{
			var absentRoleNames = AbsentRoleNames(context);
			if (absentRoleNames.Count != 0)
			{
				var manager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

				foreach (var roleName in absentRoleNames)
				{
					manager.Create(new IdentityRole { Name = roleName });
				}
			}
		}

		private static List<string> AbsentRoleNames(ApplicationDbContext context)
		{
			var existsRoleByName = new Dictionary<string, bool> { ["user"] = false, ["admin"] = false };
			foreach (var role in context.Roles)
			{
				if (existsRoleByName.ContainsKey(role.Name))
					existsRoleByName[role.Name] = true;
				if (existsRoleByName.Values.All(exists => exists))
					break;
			}

			var absentRoleNames = existsRoleByName.Where(pair => pair.Value == false)
													.Select(pair => pair.Key)
													.ToList();
			return absentRoleNames;
		}
	}
}
