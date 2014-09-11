
using Microsoft.Xna.Framework;
namespace XFormsRadioButton.WinPhone
{
    public static class VectorExtensions
    {
        public static Vector3 AsVector3(this Microsoft.Xna.Framework.Vector3 reading)
        {
            return new Vector3(reading.X, reading.Y, reading.Z);
        }
    }
}
