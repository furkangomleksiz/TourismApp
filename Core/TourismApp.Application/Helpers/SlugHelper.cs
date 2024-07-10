using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourismApp.Application.Helpers
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string title)
        {
            return title.ToLower().Replace(" ", "-").Replace("'", "").Replace("?", "").Replace(".", "");
        }
    }

}