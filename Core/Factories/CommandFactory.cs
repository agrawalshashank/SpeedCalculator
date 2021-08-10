using Core.Enum;
using Core.Models;

namespace Core.Factories
{
    public static class CommandFactory
    {
        public static BaseClass Create(string parameters)
        {
            var parameter = parameters.Split(" ");
            if (parameter[(int)ParameterEnum.CommandType].ToLower() == "driver"
                && parameter.Length > 1)
            {
                return new Driver(parameter[(int)ParameterEnum.DriverName]);
            }
            else if (parameter[(int)ParameterEnum.CommandType].ToLower() == "trip" && parameter.Length == 5)
            {
                return new Trip(parameter[(int)ParameterEnum.DriverName], parameter[(int)ParameterEnum.StartTime],
                    parameter[(int)ParameterEnum.EndTime], parameter[(int)ParameterEnum.DistanceCovered]);
            }

            return null;
        }
    }
}
