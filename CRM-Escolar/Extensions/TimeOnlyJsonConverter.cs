﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace CRM_Escolar.Extensions
{
    public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        private const string TimeFormat = "HH:mm";

        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var timeString = reader.GetString();
            if (TimeOnly.TryParseExact(timeString, TimeFormat, out var time))
            {
                return time;
            }
            throw new JsonException($"Unable to parse {timeString} to TimeOnly.");
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(TimeFormat));
        }
    }
}
