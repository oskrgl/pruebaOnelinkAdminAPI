using Microsoft.Extensions.Options;
using System;
using System.Reflection;


namespace pruebaEmpleadoAPI.Domain.Helpers
{
    public class AppSettingGlobal
    {
        private AppSetting ListSettings { get; set; }

        public AppSettingGlobal(IOptions<AppSetting> settings)
        {
            ListSettings = settings.Value;
        }
        public string GetValue(string key)
        {
            try
            {
                var properties = this.ListSettings.GetType();
                PropertyInfo value = properties.GetProperty(key);
                return value.GetValue(ListSettings,null).ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}
