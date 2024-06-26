﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace GeoServerNet.Common.Helpers;

public static class JsonHelper
{
    public static JsonSerializerOptions GetDefaultOptions()
    {
        var options = new JsonSerializerOptions();
        
        options.PropertyNameCaseInsensitive = true;
        options.PropertyNamingPolicy = null;
        options.WriteIndented = true;
        options.IncludeFields = true;
        options.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
        
        //This adds converters by default which would be applied in every applicable property
        //options.Converters.Add(new StringTrimmingConverter());
        options.Converters.Add(new JsonStringEnumConverter());
        
        return options;
    }
}