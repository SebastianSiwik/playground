using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BicycleService.Domain.DomainExceptions
{
    class InvalidBirthDateException: Exception
    {
        public InvalidBirthDateException(DateTime birthDate): base(ModifyMessage(birthDate))
        {
        }

        private static string ModifyMessage(DateTime birthDate)
        {
            return $"Invalid birth date {birthDate}.";
        }
    }
}
