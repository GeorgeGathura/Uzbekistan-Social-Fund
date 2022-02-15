using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Uzbekistan_Social_Fund.Utilities
{
    public static class RolesHelper
    {
        public const string Admin = "admin";
        public const string DataEntry = "Data Entry";

        public static List<SelectListItem> GetRoles()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{ Text=Admin, Value=Admin},
                new SelectListItem{ Text=DataEntry, Value=DataEntry}
            };
        }
    }
}
