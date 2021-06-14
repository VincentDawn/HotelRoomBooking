using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HotelRoomCodeFirstDb.Converters
{
    public static class EnumFunctions
    {
        public interface IEnumModel<TModel, TModelIdType>
        {
            TModelIdType Id { get; set; }
            string Description { get; set; }
        }

        public static IEnumerable<TModel> GetModelsFromEnum<TModel, TEnum>() where TModel : IEnumModel<TModel, TEnum>, new()
        {
            var enums = new List<TModel>();
            foreach (var enumVar in (TEnum[])Enum.GetValues(typeof(TEnum)))
            {
                // Get description
                var parsedEnum = Enum.Parse(typeof(TEnum), enumVar.ToString());
                var field = parsedEnum.GetType().GetField(parsedEnum.ToString());
                var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var description = ((DescriptionAttribute)attributes.ElementAt(0)).Description;

                enums.Add(new TModel
                {
                    Id = enumVar,
                    Description = description
                });
            }

            return enums;
        }
    }
}
