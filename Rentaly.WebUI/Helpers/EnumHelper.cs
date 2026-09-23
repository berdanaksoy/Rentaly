using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rentaly.WebUI.Helpers
{
    public static class EnumHelper
    {
        public static SelectList ToSelectList<TEnum>() where TEnum : struct, Enum
        {
            var items = Enum.GetValues<TEnum>()
                .Select(x => new
                {
                    Id = Convert.ToInt32(x),
                    Name = typeof(TEnum).GetField(x.ToString())
                        ?.GetCustomAttribute<DisplayAttribute>()?.Name ?? x.ToString()
                })
                .ToList();

            return new SelectList(items, "Id", "Name");
        }
    }
}