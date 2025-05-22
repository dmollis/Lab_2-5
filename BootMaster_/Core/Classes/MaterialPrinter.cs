using BudMayster.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudMayster_.Core.Classes
{
    public class MaterialPrinter
    {
        private readonly IМaterial _material;

        public MaterialPrinter(IМaterial material)
        {
            _material = material;
        }

        public string PrintMaterial()
        {
            return _material.ToString();
        }
    }

}
