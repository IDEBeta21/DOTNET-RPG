using DotNetRPG.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetRPG.API.Dtos.Character
{
    public class AddCharacterDtoRequest
    {
        public string Name { get; set; } = "Devian";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; }  = RpgClass.Knight;
    }
}