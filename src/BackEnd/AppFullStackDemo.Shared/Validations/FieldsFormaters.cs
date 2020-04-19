using System;

namespace AppFullStackDemo.Shared.Validations
{
    public static class FieldsFormaters
    {
        public static string formatBatteryLevel(string value)
        {
            if (value.Length > 2)
            {
                decimal realValue = Convert.ToDecimal(value.Replace(".", ",")) * 100;
                return realValue.ToString().Substring(0, 2);
            }
            return "100";
        }

        public static string formatSpeed(string value)
        {
            if (value.Length > 2)
            {
                decimal realValue = Convert.ToDecimal(value.Replace(".", ",")) * 100;
                return realValue.ToString().Substring(0, 2);
            }
            return "0";
        }

        public static string ConvertTimeStampToBRDateTime(string value)
        {
            if (value.Length > 11)
            {
                double timestamp = Convert.ToDouble(value.Substring(0, 10));
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                return origin.AddSeconds(timestamp).ToString("dd/MM/yyyy hh:mm:ss");
            }
            return "?";
        }

        public static string reasonPostFormater(int reason)
        {
            if (reason == 1)
            {
                return "Bateria";
            }
            if (reason == 2)
            {
                return "Carregamento";
            }
            if (reason == 3)
            {
                return "Posição GPS";
            }
            if (reason == 4)
            {
                return "Velocidade GPS";
            }
            return "Indefinido";
        }

        public static string normalizeStr(string value)
        {
            if (value != "")
            {
                // The Devices (Smartphones) sometimes send un-pattern texts like "motorola" or " motorola"
                // or "Motorola" or " Motorola ": So I'll Patternize it to "Motorola" always: Rule will be
                // appllied to "Description", "ApiLevelDesc", "Brand", "Manufacturer" and "Model".
                value = value.TrimEnd().TrimStart().Trim().ToLower();
                value = value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
            }
            return value;
        }
    }
}
