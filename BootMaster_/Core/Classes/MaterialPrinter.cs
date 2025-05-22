using BudMayster.Interfaces;

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
